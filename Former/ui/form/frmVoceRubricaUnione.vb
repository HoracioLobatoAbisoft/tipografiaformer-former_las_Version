Imports FormerDALSql
Imports Telerik.WinControls.UI.Data
Imports FW = FormerDALWeb

Friend Class frmVoceRubricaUnione
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Private _IdRubStart As Integer = 0
    Friend Function Carica(IdRubStart As Integer) As Integer

        _IdRubStart = IdRubStart

        CaricaCombo()

        cmbPrima.IdRubSelezionato = _IdRubStart

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        cmbPrima.Carica(FormerLib.FormerEnum.enTipoRubrica.Tutto, True,, True, True)
        cmbSeconda.Carica(FormerLib.FormerEnum.enTipoRubrica.Tutto, True,, True, True)

    End Sub

    Private Sub frmBase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        Dim IdRubricaDaTenere As Integer = 0
        Dim IdRubricaDaEliminare As Integer = 0

        IdRubricaDaTenere = cmbPrima.IdRubSelezionato
        IdRubricaDaEliminare = cmbSeconda.IdRubSelezionato

        If IdRubricaDaTenere <> IdRubricaDaEliminare Then
            If MessageBox.Show("Confermi l'operazione? ATTENZIONE! Operazione non reversibile", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Unisci()

            End If
        Else
            MessageBox.Show("Selezionare due voci differenti")
        End If

    End Sub

    Private Sub Unisci()

        Dim IdRubricaDaTenere As Integer = 0
        Dim IdRubricaDaEliminare As Integer = 0

        IdRubricaDaTenere = cmbPrima.IdRubSelezionato
        IdRubricaDaEliminare = cmbSeconda.IdRubSelezionato

        Dim IdUtOnlineDaTenere As Integer = 0
        Dim IdUtOnlineDaEliminare As Integer = 0

        Using r As New VoceRubrica
            r.Read(IdRubricaDaTenere)
            IdUtOnlineDaTenere = r.IdUtOnline
        End Using

        Using r As New VoceRubrica
            r.Read(IdRubricaDaEliminare)
            IdUtOnlineDaEliminare = r.IdUtOnline
        End Using

        Dim Ris As Integer = 0

        Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
            Using tbO As FW.LUNA.LunaTransactionBox = FW.LUNA.LunaContext.CreateTransactionBox
                Try
                    tb.TransactionBegin()

                    Using mgr As New VociRubricaDAO

                        Ris = mgr.Merge(IdRubricaDaTenere, IdRubricaDaEliminare)

                    End Using

                    If Ris = 0 Then

                        If IdUtOnlineDaEliminare <> 0 And IdUtOnlineDaTenere <> 0 Then
                            tbO.TransactionBegin()

                            Using mgr As New FW.UtentiDAO

                                Ris = mgr.Merge(IdUtOnlineDaTenere, IdUtOnlineDaEliminare)

                                If Ris = 0 Then
                                    tbO.TransactionCommit()
                                    tb.TransactionCommit()
                                Else
                                    tbO.TransactionRollBack()
                                    tb.TransactionRollBack()
                                End If
                            End Using
                        End If

                    Else
                        tb.TransactionRollBack()
                    End If

                Catch ex As Exception
                    tbO.TransactionRollBack()
                    tb.TransactionRollBack()
                End Try
            End Using

        End Using

        If Ris = 0 Then
            _Ris = 1
            Close()
        Else
            MessageBox.Show("Si è verificato un errore nell'operazione di unione Voci Rubrica")
        End If

    End Sub

    Private Sub cmbPrima_Load(sender As Object, e As EventArgs) Handles cmbPrima.Load

    End Sub

    Private Sub cmbPrima_SelectedIndexChanged(sender As Object, e As PositionChangedEventArgs) Handles cmbPrima.SelectedIndexChanged

        Dim Id As Integer = cmbPrima.IdRubSelezionato
        If Id Then
            lblIdPrima.Text = Id
        Else
            lblIdPrima.Text = "-"
        End If

        'provo a selezionare in automatico la voce da unire
        Using mgr As New VociRubricaDAO
            Dim l As List(Of VoceRubrica) = mgr.GetDuplicati(False,
                                                            False,
                                                            False,
                                                            False,
                                                            Id)
            If l.Count Then
                Dim VR As VoceRubrica = l(0)
                cmbSeconda.IdRubSelezionato = VR.IdRub
            End If
        End Using

    End Sub

    Private Sub cmbSeconda_Load(sender As Object, e As EventArgs) Handles cmbSeconda.Load

    End Sub

    Private Sub cmbSeconda_SelectedIndexChanged(sender As Object, e As PositionChangedEventArgs) Handles cmbSeconda.SelectedIndexChanged

        Dim Id As Integer = cmbSeconda.IdRubSelezionato
        If Id Then
            lblIdSeconda.Text = Id
        Else
            lblIdSeconda.Text = "-"
        End If
    End Sub

    Private Sub btnSfoglia1_Click(sender As Object, e As EventArgs) Handles btnSfoglia1.Click
        If cmbPrima.IdRubSelezionato Then
            Sottofondo()
            Using f As New frmVoceRubrica
                f.Carica(cmbPrima.IdRubSelezionato)
            End Using
            Sottofondo()
        End If
    End Sub

    Private Sub btnSfoglia2_Click(sender As Object, e As EventArgs) Handles btnSfoglia2.Click
        If cmbSeconda.IdRubSelezionato Then
            Sottofondo()
            Using f As New frmVoceRubrica
                f.Carica(cmbSeconda.IdRubSelezionato)
            End Using
            Sottofondo()
        End If
    End Sub
End Class