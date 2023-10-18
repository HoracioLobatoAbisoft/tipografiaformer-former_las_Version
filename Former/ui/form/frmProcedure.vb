Imports FormerDALSql

Friend Class frmProcedure
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        CaricaCombo()

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs)

        If MessageBox.Show("Confermi qualcosa?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            _Ris = 1
            Close()

        End If
    End Sub

    Private Sub CaricaCombo()

        Using mgr As New LavorazioniDAO
            Dim l As List(Of Lavorazione) = mgr.GetAll(LFM.Lavorazione.Descrizione, True)
            cmbLavorazione.ValueMember = LFM.Lavorazione.IdLavoro.Name
            cmbLavorazione.DataSource = l
        End Using

        Using mgr As New MacchinariDAO
            Dim l As List(Of Macchinario) = mgr.GetAll(LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name, True)
            cmbMacchinario.ValueMember = LFM.Macchinario.IdMacchinario.Name
            cmbMacchinario.DataSource = l
        End Using

    End Sub

    Private Sub cmbLavorazione_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLavorazione.SelectedIndexChanged
        CaricaDati()
    End Sub

    Private Sub cmbMacchinario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMacchinario.SelectedIndexChanged
        CaricaDati()
    End Sub

    Private Sub CaricaDati()

        Cursor.Current = Cursors.WaitCursor

        Dim IdMacchinario As Integer = cmbMacchinario.SelectedValue
        Dim IdLavorazione As Integer = cmbLavorazione.SelectedValue

        If IdMacchinario = 0 And IdLavorazione = 0 Then
            dgProcedure.DataSource = Nothing
            dgProcedure.Refresh()
        Else
            Dim ParL As LUNA.LunaSearchParameter = Nothing

            If IdLavorazione Then
                ParL = New LUNA.LunaSearchParameter(LFM.Procedura.IdLavorazione, IdLavorazione)
            End If

            Dim ParM As LUNA.LunaSearchParameter = Nothing

            If IdMacchinario Then
                ParM = New LUNA.LunaSearchParameter(LFM.Procedura.IdMacchinario, IdMacchinario)
            End If

            Using mgr As New ProcedureDAO
                Dim l As List(Of Procedura) = mgr.FindAll(LFM.Procedura.Nome,
                                                          ParM,
                                                          ParL)
                dgProcedure.AutoGenerateColumns = False
                dgProcedure.DataSource = l
            End Using
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub ApriProcedura()

        If dgProcedure.SelectedRows.Count Then
            Dim Riga As DataGridViewRow = dgProcedure.SelectedRows(0)
            Dim P As Procedura = Riga.DataBoundItem
            Dim Path As String = FormerConfig.FormerPath.PathProcedure & P.IdProcedura & ".htm"

            Using f As New frmBrowser
                f.Carica(Path)
            End Using
        End If

    End Sub

    Private Sub dgProcedure_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProcedure.CellContentClick


    End Sub

    Private Sub dgProcedure_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProcedure.CellDoubleClick
        ApriProcedura()
    End Sub
End Class