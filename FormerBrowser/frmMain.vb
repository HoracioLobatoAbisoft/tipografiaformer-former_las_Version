Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum

Public Class frmMain
    Private _IdSchedaSel As Integer = 0
    Private _Modificato As Boolean = False
    Private Sub AddTab(Optional Url As String = "", _
                       Optional FromSite As Boolean = False)

        Dim t As New TabPage
        t.Text = "Former Browser"
        Dim uc As New ucBrowser(t)
        t.Controls.Add(uc)
        t.ImageIndex = 2
        uc.Left = 3
        uc.Top = 3
        uc.Dock = DockStyle.Fill
        If Url.Length Then
            If FromSite Then
                uc.NavigaAlSito(Url)
            Else
                uc.CercaConGoogle(Url)
            End If
        End If
        Dim Pos As Integer = tabMain.TabPages.Count - 2

        tabMain.TabPages.Insert(Pos, t)
        tabMain.SelectedIndex = Pos
        uc.Focus()
    End Sub

    Private Sub tabMain_MouseClick(sender As Object, e As MouseEventArgs) Handles tabMain.MouseClick
        If tabMain.SelectedIndex = (tabMain.TabPages.Count - 1) Then
            AddTab()
        End If
    End Sub

    Private Sub tabMain_MouseUp(sender As Object, e As MouseEventArgs) Handles tabMain.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Middle Then

            If tabMain.SelectedIndex = 0 Then
                If tabMain.TabPages.Count = 3 Then
                    Close()
                End If
            End If
            Dim t As TabPage = tabMain.SelectedTab
            If t.Tag <> "F" Then
                tabMain.TabPages.Remove(t)
            End If

        End If

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _Modificato Then
            If MessageBox.Show("Ci sono state delle modifiche alla scheda corrente, vuoi salvare?", "Salvataggio modifiche", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SalvaScheda()
            End If
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        Text = "Former Browser " & Application.ProductVersion
        splitMain.SplitterDistance = 1200
        CaricaCombo()
        'aggiungo il primo tab
        AddTab()
        CaricaDati()

    End Sub

    Private Sub CaricaCombo()

        Dim LTipi As New List(Of cEnum)
        Dim vTipo As New cEnum

        vTipo = New cEnum
        vTipo.Id = enTipoRubrica.Cliente
        vTipo.Descrizione = "Cliente"
        LTipi.Add(vTipo)

        vTipo = New cEnum
        vTipo.Id = enTipoRubrica.Rivenditore
        vTipo.Descrizione = "Rivenditore"
        LTipi.Add(vTipo)

        cmbTipo.DataSource = LTipi
        cmbTipo.DisplayMember = "Descrizione"
        cmbTipo.ValueMember = "Id"

        Using c As New CatRubrMarketingDAO

            Dim lC As List(Of CatRubrMarketing) = c.GetAll("Descrizione")

            cmbCat.DataSource = lC
            cmbCat.DisplayMember = "Descrizione"
            cmbCat.ValueMember = "IdCatRubr"

            Dim lCFind As List(Of CatRubrMarketing) = c.GetAll("Descrizione", True)

            cmbFindCat.DataSource = lCFind
            cmbFindCat.DisplayMember = "Descrizione"
            cmbFindCat.ValueMember = "IdCatRubr"


        End Using

    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        If _Modificato Then
            If MessageBox.Show("Ci sono state delle modifiche alla scheda corrente, vuoi salvare?", "Salvataggio modifiche", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SalvaScheda()
            End If
        End If
        _IdSchedaSel = 0
        resetForm()
    End Sub

    Private Sub resetForm()
        txtNomeAz.Text = String.Empty
        txtSito.Text = String.Empty
        txtEmail.Text = String.Empty
        txtIndirizzo.Text = String.Empty
        txtCitta.Text = String.Empty
        txtTel.Text = String.Empty
        txtFax.Text = String.Empty
        txtNote.Text = String.Empty
        txtCap.Text = String.Empty
        chkLavorato.Checked = False
    End Sub

    Private Sub SalvaScheda()
        Try
            Cursor = Cursors.WaitCursor
            Dim x As New VoceRubricaMarketing
            If _IdSchedaSel Then
                x.Read(_IdSchedaSel)
            End If
            x.NomeAzienda = txtNomeAz.Text.TrimStart(" ")
            x.Sito = txtSito.Text.Trim(" ")
            x.Email = txtEmail.Text.Trim(" ").ToLower
            x.Indirizzo = txtIndirizzo.Text
            x.Citta = txtCitta.Text
            x.Telefono = txtTel.Text
            x.Fax = txtFax.Text
            x.IdCategoria = cmbCat.SelectedValue
            x.DataAcquisizione = Now
            x.Annotazioni = txtNote.Text
            x.Cap = txtCap.Text
            x.Lavorato = chkLavorato.Checked
            x.Tipo = cmbTipo.SelectedValue
            'x.UrlProvenienza = 
            x.IdUtente = 1
            _IdSchedaSel = x.Save()
            _Modificato = False

            'resetForm()
            'CaricaDati()

        Catch ex As Exception

        Finally
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        SalvaScheda()

    End Sub

    Private Sub CaricaDati(Optional Cerca As String = "")
        Using m As New VoceRubricaMarketingDAO
            Dim l As List(Of VoceRubricaMarketing) = Nothing

            Dim SoloDaLav As LUNA.LunaSearchParameter = Nothing
            Dim SoloLav As LUNA.LunaSearchParameter = Nothing
            If chkSoloDaLav.Checked Then
                SoloDaLav = New LUNA.LunaSearchParameter() With {.FieldName = "Lavorato", .Value = IIf(chkSoloDaLav.Checked, enSiNo.No, enSiNo.Si)}
            End If

            If chkSoloLavorati.Checked Then
                SoloLav = New LUNA.LunaSearchParameter() With {.FieldName = "Lavorato", .Value = IIf(chkSoloLavorati.Checked, enSiNo.Si, enSiNo.No)}
            End If

            Dim CatLav As LUNA.LunaSearchParameter = Nothing

            If cmbFindCat.SelectedValue Then
                CatLav = New LUNA.LunaSearchParameter() With {.FieldName = "IdCategoria", .Value = cmbFindCat.SelectedValue}
            End If

            Dim NomeAzienda As LUNA.LunaSearchParameter = Nothing

            If Cerca.Length Then
                NomeAzienda = New LUNA.LunaSearchParameter() With {.FieldName = "NomeAzienda", .Value = "%" & Cerca & "%", .SqlOperator = "LIKE"}
            End If

            l = m.FindAll("NomeAzienda", NomeAzienda, SoloDaLav, SoloLav, CatLav)

            lblTot.Text = l.Count
            dgSchede.AutoGenerateColumns = False
            dgSchede.DataSource = l
        End Using

    End Sub

    Private Sub btnAddCat_Click(sender As Object, e As EventArgs) Handles btnAddCat.Click
        Dim NewCat As String = InputBox("Inserisci il nome della nuova categoria merceologica", "Inserimento Categoria Merceologica").Trim
        If NewCat.Length Then
            Using m As New CatRubrMarketingDAO
                Dim l As List(Of CatRubrMarketing) = m.FindAll(New LUNA.LunaSearchParameter("Descrizione", NewCat))
                Dim IdToSelect As Integer = 0
                If l.Count Then
                    IdToSelect = l(0).IDCatRubr
                Else
                    Dim c As New CatRubrMarketing With {.Descrizione = NewCat}
                    IdToSelect = m.Save(c)
                    CaricaCombo()
                End If
                cmbCat.SelectedValue = IdToSelect
            End Using
        End If
    End Sub

    Private Sub dgSchede_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSchede.CellClick

        Try
            Dim r As VoceRubricaMarketing = dgSchede.Rows(e.RowIndex).DataBoundItem

            If _Modificato Then
                If MessageBox.Show("Ci sono state delle modifiche alla scheda corrente, vuoi salvare?", "Salvataggio modifiche", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    SalvaScheda()
                End If
            End If

            CaricaScheda(r)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaScheda(R As VoceRubricaMarketing)
        Cursor = Cursors.WaitCursor
        _IdSchedaSel = R.IDRubMarketing
        txtNomeAz.Text = R.NomeAzienda
        txtSito.Text = R.Sito
        txtEmail.Text = R.Email
        txtIndirizzo.Text = R.Indirizzo
        txtCitta.Text = R.Citta
        txtTel.Text = R.Telefono
        txtFax.Text = R.Fax
        cmbCat.SelectedValue = R.IdCategoria
        txtCap.Text = R.Cap
        chkLavorato.Checked = R.Lavorato
        cmbTipo.SelectedValue = R.Tipo
        _Modificato = False
        Cursor = Cursors.Default
    End Sub

    Private Sub txtCitta_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtCitta.MouseDoubleClick, _
        txtSito.MouseDoubleClick, _
        txtEmail.MouseDoubleClick, _
        txtIndirizzo.MouseDoubleClick, _
        txtTel.MouseDoubleClick, _
        txtFax.MouseDoubleClick, _
        txtNote.MouseDoubleClick, _
        txtNomeAz.MouseDoubleClick

        If sender.text.length Then
            AddTab(sender.text, IIf(sender.name = "txtSito", True, False))
        End If

    End Sub

    Private Sub txtNomeAz_TextChanged(sender As Object, e As EventArgs) Handles txtNomeAz.TextChanged, _
        txtSito.TextChanged, _
        txtEmail.TextChanged, _
        txtIndirizzo.TextChanged, _
        txtTel.TextChanged, _
        txtFax.TextChanged, _
        txtCitta.TextChanged, _
        txtNote.TextChanged, _
        txtCap.TextChanged
        If sender.focused Then _Modificato = True
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCat.SelectedIndexChanged
        If sender.focused Then _Modificato = True
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        If _IdSchedaSel Then
            If MessageBox.Show("ATTENZIONE! Se elimini una scheda non potrai più recuperarla, confermi la cancellazione?", "Cancellazione scheda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminaScheda()
            End If
        Else
            resetForm()
        End If
    End Sub

    Private Sub EliminaScheda()
        Using m As New VoceRubricaMarketingDAO
            m.Delete(_IdSchedaSel)
        End Using
        CaricaDati()
        resetForm()
    End Sub

    Private Sub dgSchede_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgSchede.ColumnHeaderMouseClick
        'OrdinatoreLista(Of VoceRubricaMarketing).OrdinaLista(sender, e)
    End Sub

    Private Sub toolStripMostraTutti_Click(sender As Object, e As EventArgs) Handles toolStripMostraTutti.Click
        CercaToolStripMenuItem.Text = ""
        CaricaDati()
    End Sub

    Private Sub CercaToolStripMenuItem_KeyDown(sender As Object, e As KeyEventArgs) Handles CercaToolStripMenuItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            CaricaDati(CercaToolStripMenuItem.Text)
        End If
    End Sub

    Private Sub chkSoloDaLav_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloDaLav.CheckedChanged, chkSoloLavorati.CheckedChanged
        CaricaDati(CercaToolStripMenuItem.Text)
    End Sub

    Private Sub chkLavorato_CheckedChanged(sender As Object, e As EventArgs) Handles chkLavorato.CheckedChanged
        If sender.focused Then _Modificato = True
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked
        CaricaDati()
    End Sub
End Class
