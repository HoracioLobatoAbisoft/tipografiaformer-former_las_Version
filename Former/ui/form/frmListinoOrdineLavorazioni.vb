Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmListinoOrdineLavorazioni
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    Private _IdListinoBase As Integer = 0

    Friend Function Carica(IdListinoBase As Integer) As Integer

        _IdListinoBase = IdListinoBase

        Using mgr As New LavorazSuPreventivazDAO

            Dim l As List(Of LavorazSuPreventivaz) = mgr.FindAll(LFM.LavorazSuPreventivaz.Ordine,
                                                                 New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdListinoBase, IdListinoBase))


            Dim lNew As New BindingSource

            If l.FindAll(Function(x) x.IdLavoro = FormerLib.FormerConst.Lavorazioni.StampaRealizzazione).Count Then
                Dim Lav As New Lavorazione
                Lav.Read(FormerLib.FormerConst.Lavorazioni.StampaRealizzazione)
                lNew.Add(Lav)
            End If

            For Each singlav As LavorazSuPreventivaz In l.FindAll(Function(x) x.Lavorazione.IdLavoro <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione)
                Dim Lav As New Lavorazione
                Lav.Read(singlav.IdLavoro)
                lNew.Add(Lav)
            Next

            For Each Lav As Lavorazione In lNew
                Dim R As New DataGridViewRow()
                R.CreateCells(DgLavori)
                R.Cells(0).Value = Lav.Img
                R.Cells(1).Value = Lav.Descrizione

                Dim Note As String = String.Empty

                If Lav.LavorazioneInterna = enSiNo.Si Then
                    Note = "Lavorazione Interna"
                Else
                    If l.Find(Function(x) x.IdLavoro = Lav.IdLavoro).Opzione = enSiNo.Si Then
                        Note = "Opzionale"
                    Else
                        Note = "Obbligatoria"
                    End If
                End If

                R.Cells(2).Value = Note
                R.Tag = Lav.IdLavoro

                If Lav.LavorazioneInterna = enSiNo.Si Then
                    R.DefaultCellStyle.Font = New Font(DgLavori.DefaultCellStyle.Font, FontStyle.Italic)
                    R.DefaultCellStyle.BackColor = Color.Gray
                    R.DefaultCellStyle.SelectionBackColor = Color.Gray
                End If

                DgLavori.Rows.Add(R)
            Next

        End Using

        ShowDialog()

        Return _Ris

    End Function

    Private Sub frmBase_KeyPress(ByVal sender As Object,
                                 ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Dim x As Char = vbCr

        If e.KeyChar = x Then
            e.Handled = True
            SendKeys.Send(vbTab)

        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object,
                                ByVal e As System.EventArgs) Handles btnCancel.Click

        Close()

    End Sub

    Private Sub lnkMaximize_LinkClicked(ByVal sender As System.Object,
                                        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub SalvaLavorazioni()

        If MessageBox.Show("Confermi l'ordine inserito per l'esecuzione delle lavorazioni?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim Ordine As Integer = 0

            For Each Row As DataGridViewRow In DgLavori.Rows
                Dim IdLav As Integer = Row.Tag

                Using mgr As New LavorazSuPreventivazDAO
                    Dim l As List(Of LavorazSuPreventivaz) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdListinoBase, _IdListinoBase),
                                                                         New LUNA.LunaSearchParameter(LFM.LavorazSuPreventivaz.IdLavoro, IdLav))

                    Dim lavSuPre As LavorazSuPreventivaz = l(0)

                    lavSuPre.Ordine = Ordine
                    lavSuPre.Save()

                End Using

                Ordine += 1

            Next

            _Ris = 1
            Close()

        End If

    End Sub

    Private Sub btnOk_Click(sender As Object,
                            e As EventArgs) Handles btnOk.Click

        SalvaLavorazioni()
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        SpostaSu()
    End Sub

    Private Sub SpostaSu()
        If DgLavori.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavori.SelectedRows(0)

            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = DgLavori.Rows(riga.Index - 1)
                Dim IdlavVecchia As Integer = RigaVecchia.Tag

                If IdlavVecchia <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
                    Dim VecchioIndice As Integer = riga.Index
                    DgLavori.Rows.Remove(riga)
                    DgLavori.Rows.Insert(VecchioIndice - 1, riga)

                    riga.Selected = True
                Else
                    MessageBox.Show("La lavorazione non può essere spostata in quella posizione")
                End If
            End If

            'riga.
        End If
    End Sub

    Private Sub SpostaGiu()
        If DgLavori.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavori.SelectedRows(0)
            Dim lavorazione As Integer = riga.Tag

            If lavorazione <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then

                If (riga.Index + 1) <= DgLavori.Rows.Count Then
                    Dim VecchioIndice As Integer = riga.Index
                    Try
                        Dim temp As Integer = DgLavori.Rows(VecchioIndice + 1).Index
                        DgLavori.Rows.Remove(riga)
                        DgLavori.Rows.Insert(VecchioIndice + 1, riga)


                    Catch ex As Exception

                    End Try
                    riga.Selected = True


                End If
            Else
                MessageBox.Show("La lavorazione non può essere spostata")
            End If

            'riga.
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        SpostaGiu()
    End Sub
End Class