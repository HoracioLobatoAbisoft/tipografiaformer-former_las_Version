Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Friend Class frmMagazzinoStorno
    'Inherits baseFormInternaFixed

    Private _Ris As Integer
    Private _IdRis As Integer = 0

    Friend Function Carica(Optional IdRis As Integer = 0) As Integer

        'MgrControl.InizializeGridview(dgRisorseEx)

        'CaricaMacchinari()

        'CaricaCombo()
        _IdRis = IdRis
        UcMagazzinoCercaRisorsa.Inizializza(IdRis, enTipoMovMagaz.Storno)
        'UcMagazzinoCercaRisorsa.TipoRisorsaToShow = enTipoRisOffSet.Tutto

        UcMagazzinoMgrMovimenti.ShowStorno()

        dtDataStorno.Value = Now

        ShowDialog()

        Return _Ris

    End Function

    'Private Sub CaricaCombo()

    '    Using mgr As New RisorseDAO
    '        Dim l As List(Of String) = mgr.GetCategorie()

    '        cmbCategoria.DataSource = l

    '    End Using

    'End Sub

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

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        If Not ucMagazzinoCercaRisorsa.RisorsaScelta Is Nothing Then
            'Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)

            Dim r As Risorsa = ucMagazzinoCercaRisorsa.RisorsaScelta 'dr.DataBoundItem
            lblRisSel.Text = r.Descrizione

            If MessageBox.Show("Confermi lo storno di magazzino di '" & lblRisSel.Text & "'?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Using m As New MovimentoMagazzino
                    m.IdRis = r.IdRis
                    m.DataMov = dtDataStorno.Value
                    m.TipoMov = enTipoMovMagaz.Storno
                    m.Qta = txtQta.Text
                    m.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                    m.Save()

                    'Using Mgr As New MagazzinoDAO
                    '    Mgr.AggiornaQta(m)
                    'End Using
                End Using

                MessageBox.Show("Storno effettuato")

                _Ris = 1

                If _IdRis Then
                    Close()
                Else
                    lblRisSel.Text = String.Empty
                    lblGiacenza.Text = String.Empty
                    lblGiacenza.Tag = 0
                    'dgRisorseEx.DataSource = Nothing
                    txtQta.Text = String.Empty
                    txtRimanenza.Text = String.Empty
                    UcMagazzinoCercaRisorsa.AvviaRicerca()
                End If

            End If

        Else
            MessageBox.Show("Selezionare una risorsa")
        End If


    End Sub



    Private Sub dgRisorseEx_SelectionChanged(sender As Object, e As EventArgs)

    End Sub


    'Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    '    MostraDati()
    'End Sub

    'Private Sub dgRisorseEx_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub MostraDati()

    '    Using mgr As New RisorseDAO

    '        Dim pDescr As LUNA.LunaSearchParameter = Nothing
    '        Dim pCat As LUNA.LunaSearchParameter = Nothing

    '        If txtDescr.Text.Length Then
    '            pDescr = New LUNA.LunaSearchParameter(LFM.Risorsa.Descrizione, "%" & txtDescr.Text & "%", "LIKE")
    '        End If

    '        If cmbCategoria.Text.Length Then
    '            pCat = New LUNA.LunaSearchParameter(LFM.Risorsa.Categoria, cmbCategoria.Text)
    '        End If

    '        Dim l As List(Of Risorsa) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.Risorsa.TipoRis, enTipoRisOffSet.ProdottoDiConsumo),
    '                                                New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo),
    '                                                pDescr,
    '                                                pCat)

    '        Dim lFin As New List(Of Risorsa)

    '        If cmbMacchinarioSel.SelectedValue Then
    '            Using mgrR As New RisorseSuMacchinaDAO
    '                Dim lR As List(Of RisorsaSuMacchina) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.RisorsaSuMacchina.IdMacchinario, cmbMacchinarioSel.SelectedValue))

    '                For Each singR As Risorsa In l
    '                    If lR.FindAll(Function(x) x.IdRisorsa = singR.IdRis).Count Then
    '                        lFin.Add(singR)
    '                    End If
    '                Next

    '            End Using
    '        Else
    '            lFin.AddRange(l)
    '        End If

    '        dgRisorseEx.DataSource = lFin

    '    End Using


    'End Sub


    'Private Sub rdoOffset_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub CaricaMacchinari()

    '    cmbMacchinarioSel.Items.Clear()

    '    Cursor.Current = Cursors.WaitCursor

    '    Dim descriptionItem As New DescriptionTextListDataItem
    '    'descriptionItem.Text = "Selezionare un macchinario"
    '    'descriptionItem.Image = New Bitmap(My.Resources.no_image, 80, 80)
    '    'descriptionItem.DescriptionText = ""
    '    'descriptionItem.Value = 0
    '    'cmbMacchinarioSel.Items.Add(descriptionItem)
    '    Dim I As Integer = 0

    '    Dim l As List(Of Macchinario) = Nothing
    '    Dim IdRepartoSel As Integer = 0
    '    Dim pRep As LUNA.LunaSearchParameter = Nothing
    '    Dim AddEmpty As Boolean = True
    '    If rdoTutto.Checked Then
    '        IdRepartoSel = 0
    '        'AddEmpty = True
    '    ElseIf rdoOffset.Checked Then
    '        IdRepartoSel = enRepartoWeb.StampaOffset
    '    ElseIf rdoDigitale.Checked Then
    '        IdRepartoSel = enRepartoWeb.StampaDigitale
    '    ElseIf rdoRicamo.Checked Then
    '        IdRepartoSel = enRepartoWeb.Ricamo
    '    ElseIf rdoEtichette.Checked Then
    '        IdRepartoSel = enRepartoWeb.Etichette
    '    ElseIf rdoPackaging.Checked Then
    '        IdRepartoSel = enRepartoWeb.Packaging
    '    End If

    '    If IdRepartoSel Then
    '        pRep = New LUNA.LunaSearchParameter(LFM.Macchinario.IdRepartoDefault, IdRepartoSel)
    '    End If


    '    Using M As New MacchinariDAO
    '        l = M.FindAll(New LUNA.LunaSearchOption() With {.AddEmptyItem = AddEmpty, .OrderBy = LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name},
    '                      pRep)

    '        For Each Mc As Macchinario In l

    '            Dim Aggiungi As Boolean = True


    '            descriptionItem = New DescriptionTextListDataItem
    '            descriptionItem.Text = Mc.Descrizione
    '            descriptionItem.Image = Mc.Img
    '            descriptionItem.DescriptionText = Mc.TipoStr
    '            descriptionItem.Value = Mc.IdMacchinario
    '            cmbMacchinarioSel.Items.Add(descriptionItem)

    '        Next

    '    End Using

    '    cmbMacchinarioSel.SelectedIndex = 0

    '    lblRisSel.Text = String.Empty
    '    lblGiacenza.Text = String.Empty
    '    lblGiacenza.Tag = 0
    '    txtQta.Text = 1
    '    txtRimanenza.Text = String.Empty

    '    Cursor.Current = Cursors.Default

    'End Sub

    'Private Sub rdoTutto_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub rdoDigitale_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub rdoRicamo_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub rdoPackaging_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub rdoEtichette_CheckedChanged(sender As Object, e As EventArgs)
    '    CaricaMacchinari()
    'End Sub

    'Private Sub cmbMacchinarioSel_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs)
    '    MostraDati()
    'End Sub

    Private Sub CalcolaScarico()
        Try
            Dim Rimanenza As Single = 0

            If CSng(lblGiacenza.Tag) >= CSng(txtRimanenza.Text) Then
                Rimanenza = -(CSng(lblGiacenza.Tag) - CSng(txtRimanenza.Text))
            Else
                Rimanenza = CSng(txtRimanenza.Text) - CSng(lblGiacenza.Tag)
            End If

            txtQta.Text = Rimanenza

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcolaRimanenza()
        Try
            Dim Rimanenza As Single = 0

            Rimanenza = CSng(lblGiacenza.Tag) + CSng(txtQta.Text)

            txtRimanenza.Text = Rimanenza

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtQta_TextChanged(sender As Object, e As EventArgs) Handles txtQta.TextChanged
        If txtQta.Focused Then CalcolaRimanenza()
    End Sub

    'Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    MostraDati()

    'End Sub

    Private Sub txtRimanenza_TextChanged(sender As Object, e As EventArgs) Handles txtRimanenza.TextChanged
        If txtRimanenza.Focused Then CalcolaScarico()
    End Sub

    Private Sub dgRisorseEx_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs)

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub

    Private Sub UcMagazzinoCercaRisorsa_RisorsaSelezionata(R As Risorsa) Handles UcMagazzinoCercaRisorsa.RisorsaSelezionata

        If Not R Is Nothing Then 'dgRisorseEx.SelectedRows.Count Then
            'Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)

            lblRisSel.Text = R.Descrizione
            lblGiacenza.Text = "Giac. " & R.Giacenza
            lblGiacenza.Tag = R.Giacenza
            Try
                If R.imgPath.Length Then
                    pctRis.Image = Image.FromFile(R.imgPath)
                Else
                    pctRis.Image = My.Resources.no_image
                End If
            Catch ex As Exception

            End Try

        End If

        txtQta.Text = 1
        txtRimanenza.Text = String.Empty

    End Sub

    Private Sub UcMagazzinoCercaRisorsa_Load(sender As Object, e As EventArgs) Handles UcMagazzinoCercaRisorsa.Load

    End Sub
End Class