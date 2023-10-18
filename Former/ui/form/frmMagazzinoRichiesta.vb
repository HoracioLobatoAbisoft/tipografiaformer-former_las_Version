Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Friend Class frmMagazzinoRichiesta
    'Inherits baseFormInternaFixed

    Private _Ris As Integer

    Friend Function Carica() As Integer

        'MgrControl.InizializeGridview(dgRisorseEx)

        'CaricaMacchinari()

        'CaricaCombo()

        UcMagazzinoCercaRisorsa.Inizializza(, enTipoMovMagaz.RichiestaAcquisto)

        'UcMagazzinoCercaRisorsa.TipoRisorsaToShow = enTipoRisOffSet.Tutto

        UcMagazzinoMgrMovimenti.ShowRichiesteAcquisto()

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
        Try
            If Not UcMagazzinoCercaRisorsa.RisorsaScelta Is Nothing Then
                If lnkRichiestaEsistente.Visible = False Then
                    'Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)
                    If txtGiacReale.Text.Trim.Length = 0 OrElse txtQta.Text.Trim.Length = 0 Then
                        MessageBox.Show("Inserire Giacenza reale e quantità richiesta")
                    Else
                        If CInt(lblGiacFinale.Text) > 0 Then
                            Dim r As Risorsa = UcMagazzinoCercaRisorsa.RisorsaScelta 'dr.DataBoundItem
                            lblRisSel.Text = r.Descrizione

                            If MessageBox.Show("Confermi il salvataggio della richiesta di acquisto per '" & lblRisSel.Text & "'?", "Gestionale Former", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                If txtGiacReale.Text <> lblGiacPresunta.Text Then
                                    'qui prima devo fare uno storno

                                    Using m As New MovimentoMagazzino
                                        m.IdRis = r.IdRis
                                        m.DataMov = Now
                                        m.TipoMov = enTipoMovMagaz.Storno
                                        m.Qta = CInt(txtGiacReale.Text) - CInt(lblGiacPresunta.Text)
                                        m.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                                        m.Save()

                                        'Using Mgr As New MagazzinoDAO
                                        '    Mgr.AggiornaQta(m)
                                        'End Using
                                    End Using


                                End If

                                Using m As New MovimentoMagazzino
                                    m.IdRis = r.IdRis
                                    m.DataMov = Now
                                    m.TipoMov = enTipoMovMagaz.RichiestaAcquisto
                                    m.Qta = txtQta.Text
                                    m.IdUt = PostazioneCorrente.UtenteConnesso.IdUt
                                    If chkUrgente.Checked Then m.Urgenza = enSiNo.Si
                                    m.Nota = txtNote.Text
                                    m.Save()

                                    'Using Mgr As New MagazzinoDAO
                                    '    Mgr.AggiornaQta(m)
                                    'End Using
                                End Using

                                MessageBox.Show("Richiesta di acquisto salvata")
                                Close()

                            End If
                        Else
                            MessageBox.Show("La quantità richiesta non è valida. La risorsa deve avere una giacenza finale minima di 1 pezzo")
                        End If
                    End If



                Else
                    MessageBox.Show("Per la risorsa selezionata esiste gia una richiesta di acquisto pendente, modificare quella!")
                End If


            Else
                MessageBox.Show("Selezionare una risorsa")
            End If
        Catch ex As Exception

        End Try



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

    'Private Sub CalcolaScarico()
    '    Try
    '        Dim Rimanenza As Integer = 0

    '        Rimanenza = CInt(lblGiacPresunta.Tag) - CInt(txtRimanenza.Text)

    '        txtQta.Text = Rimanenza

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub CalcolaRimanenza()
        Try
            Dim Rimanenza As Integer = 0

            Rimanenza = CInt(txtGiacReale.Text) + CInt(txtQta.Text)

            lblGiacFinale.Text = Rimanenza

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtQta_TextChanged(sender As Object, e As EventArgs) Handles txtQta.TextChanged
        CalcolaRimanenza()
    End Sub

    'Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    MostraDati()

    'End Sub

    Private Sub dgRisorseEx_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs)

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub

    Private Sub UcMagazzinoCercaRisorsa_RisorsaSelezionata(R As Risorsa) Handles UcMagazzinoCercaRisorsa.RisorsaSelezionata

        If Not R Is Nothing Then 'dgRisorseEx.SelectedRows.Count Then
            'Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)

            lblRisSel.Text = R.Descrizione
            lblGiacPresunta.Text = R.Giacenza
            lblGiacPresunta.Tag = R.Giacenza
            'txtGiacReale.Text = R.Giacenza
            txtGiacReale.Text = String.Empty

            If R.imgPath.Length Then
                Try
                    pctRis.Image = Image.FromFile(R.imgPath)
                Catch ex As Exception

                End Try
            Else
                pctRis.Image = My.Resources.no_image
            End If

            Using mgr As New MagazzinoDAO
                Dim l As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, R.IdRis),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdOrdineAcquisto, 0),
                                                                   New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.TipoMov, enTipoMovMagaz.RichiestaAcquisto))

                If l.Count Then
                    lnkRichiestaEsistente.Visible = True
                    'lnkRichiestaEsistente.Tag = l(0).IdCarMag
                Else

                    'qui controllo se c'è stato un carico dopo l'ultima richiesta di acquisto 
                    Dim BloccareRichiesta As Boolean = False

                    Dim lMov As List(Of MovimentoMagazzino) = mgr.FindAll(New LUNA.LunaSearchOption() With {.OrderBy = "IdCarMag DESC"},
                                                                          New LUNA.LunaSearchParameter(LFM.MovimentoMagazzino.IdRis, R.IdRis))

                    Dim Counter As Integer = 0
                    Dim TrovatoCarico As Boolean = False

                    If lMov.FindAll(Function(x) x.TipoMov = enTipoMovMagaz.RichiestaAcquisto).Count Then
                        For Each Mov As MovimentoMagazzino In lMov

                            If Mov.TipoMov = enTipoMovMagaz.Carico Then
                                TrovatoCarico = True
                            End If

                            If Mov.TipoMov = enTipoMovMagaz.RichiestaAcquisto Then
                                If Counter = 0 Then
                                    'qui sicuro blocco e esco
                                    BloccareRichiesta = True
                                Else
                                    If TrovatoCarico = False Then
                                        BloccareRichiesta = True
                                    End If
                                End If
                                Exit For
                            End If

                            Counter += 1

                        Next
                    Else
                        'qui non ci sono richieste di acquisto e' inutile cercare
                    End If

                    If BloccareRichiesta Then
                        lnkRichiestaEsistente.Visible = True
                        'lnkRichiestaEsistente.Tag = lMov(0).IdCarMag
                    Else
                        lnkRichiestaEsistente.Visible = False
                        lnkRichiestaEsistente.Tag = 0
                    End If


                End If

            End Using

            'If R.Giacenza < 0 Then
            '    txtQta.Text = 1 + Math.Abs(R.Giacenza)
            'Else
            '    txtQta.Text = 1
            'End If
            txtQta.Text = String.Empty
        Else
            lnkRichiestaEsistente.Visible = False
            lnkRichiestaEsistente.Tag = 0
            'txtQta.Text = 1
            txtQta.Text = String.Empty
        End If

        'lblGiacFinale.Text = String.Empty

    End Sub

    Private Sub lnkRichiestaEsistente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRichiestaEsistente.LinkClicked
        'Sottofondo()
        'Using f As New frmMagazzinoMovimento

        '    Using m As New MovimentoMagazzino
        '        m.Read(lnkRichiestaEsistente.Tag)
        '        f.Carica(, m)
        '    End Using

        'End Using
        'Sottofondo()
    End Sub

    Private Sub txtGiacReale_TextChanged(sender As Object, e As EventArgs) Handles txtGiacReale.TextChanged
        'If txtGiacReale.Focused Then
        CalcolaRimanenza()
        'End If
    End Sub

    Private Sub UcMagazzinoCercaRisorsa_Load(sender As Object, e As EventArgs) Handles UcMagazzinoCercaRisorsa.Load

    End Sub
End Class