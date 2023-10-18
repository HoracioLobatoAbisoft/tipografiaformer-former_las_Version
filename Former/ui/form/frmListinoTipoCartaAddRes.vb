Imports FormerDALSql

Friend Class frmListinoTipoCartaAddRes
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _IdTipoCarta As Integer = 0
    Friend Function Carica(IdTipoCarta As Integer) As Integer

        _IdTipoCarta = IdTipoCarta

        CaricaDati()

        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaDati(Optional IdRis As Integer = 0)

        Cursor.Current = Cursors.WaitCursor

        Dim l As List(Of RisorsaRicerca) = Nothing

        If IdRis Then
            Using r As New Risorsa
                r.Read(IdRis)
                txtCerca.Text = r.Descrizione
            End Using
        End If

        Using mgr As New RisorseDAO

            l = mgr.FindAllRicerca(_IdTipoCarta, txtCerca.Text.Trim)

        End Using

        If rdoAlfabeto.Checked Then

        ElseIf rdoUltimoCarico.Checked Then
            l.Sort(Function(x, y) y.DataUltimoCarico.CompareTo(x.DataUltimoCarico))
        End If

        DgRiso.AutoGenerateColumns = False
        DgRiso.DataSource = l

        If IdRis Then
            For Each r As DataGridViewRow In DgRiso.Rows
                Dim Risorsa As RisorsaRicerca = r.DataBoundItem

                If Risorsa.IdRis = IdRis Then
                    DgRiso.ClearSelection()
                    r.Selected = True
                    Risorsa.Selezionata = True
                    DgRiso.Refresh()
                    Exit For
                End If
            Next
        End If

        Cursor.Current = Cursors.Default

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

        If MessageBox.Show("Confermi il cambiamento di tutte le risorse selezionate legandole a questo tipo di carta?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim l As List(Of RisorsaRicerca) = DgRiso.DataSource

            For Each singRis In l.FindAll(Function(x) x.Selezionata = True)

                singRis.IdTipoCarta = _IdTipoCarta
                singRis.Save()

            Next

            _Ris = 1
            Close()
        End If

    End Sub

    Private Sub DgRiso_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgRiso.CellMouseClick

        If DgRiso.SelectedRows.Count Then
            Dim R As RisorsaRicerca = DgRiso.SelectedRows(0).DataBoundItem
            R.Selezionata = Not R.Selezionata
            DgRiso.Refresh()
        End If

    End Sub

    Private Sub txtCerca_TextChanged(sender As Object, e As EventArgs) Handles txtCerca.TextChanged

        If sender.focused Then CaricaDati()

    End Sub

    Private Sub btnNuovaRis_Click(sender As Object, e As EventArgs) Handles btnNuovaRis.Click

        Dim Ris As Integer = 0

        Sottofondo()

        Using f As New frmMagazzinoRisorsa
            Ris = f.Carica()
        End Using

        Sottofondo()

        If Ris Then
            CaricaDati(Ris)
        End If

    End Sub

    Private Sub RdoUltimoCarico_CheckedChanged(sender As Object, e As EventArgs) Handles rdoUltimoCarico.CheckedChanged
        If sender.focused Then CaricaDati()
    End Sub

    Private Sub RdoAlfabeto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAlfabeto.CheckedChanged
        If sender.focused Then CaricaDati()
    End Sub
End Class