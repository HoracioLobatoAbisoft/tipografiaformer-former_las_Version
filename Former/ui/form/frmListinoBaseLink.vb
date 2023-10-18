Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmListinoBaseLink
    'Inherits baseFormInternaFixed
    Private _Ris As Integer

    Private _IdPrev As Integer = 0
    Private _idPrevDaEscludere As Integer = 0

    Friend Function Carica(Optional IdPrev As Integer = 0,
                           Optional IdPrevDaEscludere As Integer = 0) As Integer
        _IdPrev = IdPrev
        _idPrevDaEscludere = IdPrevDaEscludere

        CaricaCombo()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaCombo()

        If _IdPrev Then
            Dim P As New Preventivazione
            P.Read(_IdPrev)
            P.CaricaListinoBase(, enTipoListiniBase.Sorgente)
            P.CaricaListiniLinkati()

            Dim ListaLB As String = String.Empty

            For Each L As ListinoBase In P.ListiniBase
                ListaLB &= L.IdListinoBase & ","
            Next

            For Each L As ListinoBase In P.ListiniLinkati
                ListaLB &= L.IdListinoBase & ","
            Next

            ListaLB = ListaLB.TrimEnd(",")

            Dim Lb As List(Of ListinoBase) = Nothing

            Using mgr As New ListinoBaseDAO

                If ListaLB.Length Then
                    ListaLB = "(" & ListaLB & ")"
                    Lb = mgr.FindAll(LFM.ListinoBase.Nome,
                                     New LUNA.LunaSearchParameter(LFM.ListinoBase.IdListinoBase, ListaLB, "NOT IN "))
                Else
                    Lb = mgr.GetAll(LFM.ListinoBase.Nome, True)
                End If

            End Using

            cmbListinoBase.DataSource = Lb
            cmbListinoBase.DisplayMember = "Nome"
            cmbListinoBase.ValueMember = "IdListinoBase"
        Else

            Dim Lb As List(Of ListinoBase) = Nothing

            Using mgr As New ListinoBaseDAO
                Dim pEscl As LUNA.LunaSearchParameter = Nothing

                If _idPrevDaEscludere Then
                    pEscl = New LUNA.LunaSearchParameter(LFM.ListinoBase.IdPrev, _idPrevDaEscludere, "<>")
                End If

                Lb = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "Nome", .AddEmptyItem = True},
                                 pEscl)

            End Using

            Lb.Sort(Function(x, y) x.RiassuntoConPreventivazione.CompareTo(y.RiassuntoConPreventivazione))

            cmbListinoBase.DataSource = Lb
            cmbListinoBase.DisplayMember = "RiassuntoConPreventivazione"
            cmbListinoBase.ValueMember = "IdListinoBase"
        End If

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

        If MessageBox.Show("Confermi il listinobase selezionato?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = cmbListinoBase.SelectedValue
            Close()

        End If
    End Sub
End Class