Imports FormerDALSql
Imports FormerLib.FormerEnum

Friend Class frmListinoOrdineMacchinari
    'Inherits baseFormInternaRedim

    Private _Ris As Integer

    ' Private _IdListinoBase As Integer = 0

    Friend Function Carica() As Integer

        '    _IdListinoBase = IdListinoBase

        Using mgr As New MacchinariDAO

            Dim l As List(Of Macchinario) = mgr.FindAll("Tipo,Ordinamento")

            Dim lNew As New BindingSource

            For Each m As Macchinario In l
                lNew.Add(m)
            Next

            For Each Lav As Macchinario In lNew
                Dim R As New DataGridViewRow()
                R.CreateCells(DgMacchinari)
                R.Cells(0).Value = Lav.Img
                R.Cells(1).Value = Lav.Descrizione

                Dim Note As String = String.Empty

                If Lav.Tipo = enTipoMacchinario.Produzione Then
                    Note = "Produzione"
                Else
                    Note = "Allestimento"
                End If

                R.Cells(2).Value = Note
                R.Tag = Lav.IdMacchinario

                DgMacchinari.Rows.Add(R)
            Next

        End Using

        ShowDialog()

        Return _Ris

    End Function

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

        If MessageBox.Show("Confermi l'ordine inserito per l'esecuzione delle lavorazioni?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim Ordine As Integer = 0

            For Each Row As DataGridViewRow In DgMacchinari.Rows
                Dim IdMacc As Integer = Row.Tag

                Using m As New Macchinario

                    m.Read(IdMacc)
                    m.Ordinamento = Ordine
                    m.Save()

                End Using

                Ordine += 1

            Next

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        SpostaSu()
    End Sub

    Private Sub SpostaSu()
        If DgMacchinari.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgMacchinari.SelectedRows(0)

            If (riga.Index - 1) >= 0 Then

                Dim RigaVecchia As DataGridViewRow = DgMacchinari.Rows(riga.Index - 1)
                Dim IdMaccVecchia As Integer = RigaVecchia.Tag

                Dim macchin As New Macchinario
                macchin.Read(riga.Tag)

                Dim MacchinVecchia As New Macchinario
                MacchinVecchia.Read(IdMaccVecchia)

                If macchin.Tipo = MacchinVecchia.Tipo Then
                    Dim VecchioIndice As Integer = riga.Index
                    DgMacchinari.Rows.Remove(riga)
                    DgMacchinari.Rows.Insert(VecchioIndice - 1, riga)

                    riga.Selected = True
                Else
                    MessageBox.Show("Il Macchinario non può essere spostato in quella posizione")
                End If

            End If

            'riga.
        End If
    End Sub

    Private Sub SpostaGiu()
        If DgMacchinari.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgMacchinari.SelectedRows(0)
            Dim lavorazione As Integer = riga.Tag

            If (riga.Index + 1) < DgMacchinari.Rows.Count Then

                Dim RigaVecchia As DataGridViewRow = DgMacchinari.Rows(riga.Index + 1)
                Dim IdMaccVecchia As Integer = RigaVecchia.Tag

                Dim macchin As New Macchinario
                macchin.Read(riga.Tag)

                Dim MacchinVecchia As New Macchinario
                MacchinVecchia.Read(IdMaccVecchia)

                If macchin.Tipo = MacchinVecchia.Tipo Then

                    Dim VecchioIndice As Integer = riga.Index
                    DgMacchinari.Rows.Remove(riga)
                    DgMacchinari.Rows.Insert(VecchioIndice + 1, riga)

                    riga.Selected = True
                Else
                    MessageBox.Show("Il Macchinario non può essere spostato in quella posizione")
                End If
            End If

            'Else
            '    MessageBox.Show("La lavorazione non può essere spostata")
            'End If

            'riga.
        End If

    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        SpostaGiu()
    End Sub
End Class