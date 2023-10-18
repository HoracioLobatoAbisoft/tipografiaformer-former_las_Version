Imports FormerDALSql
Imports FormerLib
Imports FormerLib.FormerEnum
Imports Telerik.WinControls.UI

Public Class ucMagazzinoCercaRisorsa
    Inherits ucFormerUserControl

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BackColor = Color.White

    End Sub

    Public Event RisorsaSelezionata(R As Risorsa)

    Private _IdRis As Integer = 0

    Public Property SoloAttivi As Boolean = False

    Public Sub Inizializza(Optional IdRis As Integer = 0,
                           Optional TipoMovRiferimento As enTipoMovMagaz = enTipoMovMagaz.RichiestaAcquisto)
        _IdRis = IdRis
        _TipoMovRiferimento = TipoMovRiferimento
        MgrControl.InizializeGridview(dgRisorseEx)
        CaricaMacchinari()
        CaricaCombo()

        If IdRis Then
            AvviaRicerca()
        End If

    End Sub

    Private Sub CaricaCombo()

        Try
            Using mgr As New RisorseDAO
                Dim l As List(Of String) = mgr.GetCategorie()

                cmbCategoria.DataSource = l

            End Using

            Using mgr As New UtentiDAO
                Dim l As List(Of Utente) = mgr.FindAll(LFM.Utente.Login,
                                                       New LUNA.LunaSearchParameter(LFM.Utente.Attivo, enSiNo.Si),
                                                       New LUNA.LunaSearchParameter(LFM.Utente.IdUt, FormerConst.UtentiSpecifici.IdUtenteAdmin, "<>"))

                cmbUtenti.DisplayMember = LFM.Utente.Login.Name
                cmbUtenti.ValueMember = LFM.Utente.IdUt.Name
                cmbUtenti.DataSource = l
                MgrControl.SelectIndexCombo(cmbUtenti, PostazioneCorrente.UtenteConnesso.IdUt)
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaMacchinari()
        Try
            cmbMacchinarioSel.Items.Clear()

            Cursor.Current = Cursors.WaitCursor

            Dim descriptionItem As New DescriptionTextListDataItem
            'descriptionItem.Text = "Selezionare un macchinario"
            'descriptionItem.Image = New Bitmap(My.Resources.no_image, 80, 80)
            'descriptionItem.DescriptionText = ""
            'descriptionItem.Value = 0
            'cmbMacchinarioSel.Items.Add(descriptionItem)
            Dim I As Integer = 0

            Dim l As List(Of Macchinario) = Nothing
            Dim IdRepartoSel As Integer = 0
            Dim pRep As LUNA.LunaSearchParameter = Nothing
            Dim AddEmpty As Boolean = True
            If rdoTutto.Checked Then
                IdRepartoSel = 0
                'AddEmpty = True
            ElseIf rdoOffset.Checked Then
                IdRepartoSel = enRepartoWeb.StampaOffset
            ElseIf rdoDigitale.Checked Then
                IdRepartoSel = enRepartoWeb.StampaDigitale
            ElseIf rdoRicamo.Checked Then
                IdRepartoSel = enRepartoWeb.Ricamo
            ElseIf rdoEtichette.Checked Then
                IdRepartoSel = enRepartoWeb.Etichette
            ElseIf rdoPackaging.Checked Then
                IdRepartoSel = enRepartoWeb.Packaging
            End If

            If IdRepartoSel Then
                pRep = New LUNA.LunaSearchParameter(LFM.Macchinario.IdRepartoDefault, IdRepartoSel)
            End If


            Using M As New MacchinariDAO
                l = M.FindAll(New LUNA.LunaSearchOption() With {.AddEmptyItem = AddEmpty, .OrderBy = LFM.Macchinario.Tipo.Name & "," & LFM.Macchinario.Descrizione.Name},
                          pRep)

                For Each Mc As Macchinario In l

                    Dim Aggiungi As Boolean = True


                    descriptionItem = New DescriptionTextListDataItem
                    descriptionItem.Text = Mc.Descrizione
                    descriptionItem.Image = Mc.Img
                    descriptionItem.DescriptionText = Mc.TipoStr
                    descriptionItem.Value = Mc.IdMacchinario
                    cmbMacchinarioSel.Items.Add(descriptionItem)

                Next

            End Using

            cmbMacchinarioSel.SelectedIndex = 0

            Cursor.Current = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgRisorseEx_SelectionChanged(sender As Object, e As EventArgs) Handles dgRisorseEx.SelectionChanged

        Dim r As Risorsa = Nothing

        If dgRisorseEx.SelectedRows.Count Then
            Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)

            r = dr.DataBoundItem


        End If

        RaiseEvent RisorsaSelezionata(r)

    End Sub

    Private Sub rdoOffset_CheckedChanged(sender As Object, e As EventArgs) Handles rdoOffset.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub rdoTutto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTutto.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub rdoDigitale_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDigitale.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub rdoRicamo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRicamo.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub rdoPackaging_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPackaging.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub rdoEtichette_CheckedChanged(sender As Object, e As EventArgs) Handles rdoEtichette.CheckedChanged
        CaricaMacchinari()
    End Sub

    Private Sub cmbMacchinarioSel_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbMacchinarioSel.SelectedIndexChanged
        AvviaRicerca()
    End Sub

    Private Sub dgRisorseEx_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgRisorseEx.ViewCellFormatting

        If TypeOf e.CellElement Is GridImageCellElement Then
            e.Row.Height = 64
        End If

    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged

        AvviaRicerca()

    End Sub

    Public Property TipoRisorsaToShow As enTipoRisOffSet = enTipoRisOffSet.Tutto

    Public Sub AvviaRicerca()

        Using mgr As New RisorseDAO

            Dim lFin As New List(Of Risorsa)

            If _IdRis Then

                Using R As New Risorsa
                    R.Read(_IdRis)
                    lFin.Add(R)
                End Using

            Else

                Dim pDescr As LUNA.LunaSearchParameter = Nothing
                Dim pCat As LUNA.LunaSearchParameter = Nothing
                Dim pIdUsati As LUNA.LunaSearchParameter = Nothing

                If txtDescr.Text.Length Then
                    pDescr = New LUNA.LunaSearchParameter(LFM.Risorsa.Descrizione, "%" & txtDescr.Text & "%", "LIKE")
                End If

                If cmbCategoria.Text.Length Then
                    pCat = New LUNA.LunaSearchParameter(LFM.Risorsa.Categoria, cmbCategoria.Text)
                End If

                Dim pTipo As LUNA.LunaSearchParameter = Nothing

                If TipoRisorsaToShow <> enTipoRisOffSet.Tutto Then
                    pTipo = New LUNA.LunaSearchParameter(LFM.Risorsa.TipoRis, TipoRisorsaToShow)
                End If

                If chkOnlyRisMovimentate.Checked Then

                    Using mgrMag As New MagazzinoDAO

                        Dim listaId As String = mgrMag.IdRisUsateStr(cmbUtenti.SelectedValue, _TipoMovRiferimento)

                        If listaId.Length = 0 Then
                            listaId = "-1"
                        End If

                        pIdUsati = New LUNA.LunaSearchParameter(LFM.Risorsa.IdRis, "(" & listaId & ")", "IN")
                    End Using

                End If

                Dim l As List(Of Risorsa) = mgr.FindAll(pTipo,
                                                        New LUNA.LunaSearchParameter(LFM.Risorsa.Stato, enStato.Attivo),
                                                        pDescr,
                                                        pCat,
                                                        pIdUsati)



                If cmbMacchinarioSel.SelectedValue Then
                    Using mgrR As New RisorseSuMacchinaDAO
                        Dim lR As List(Of RisorsaSuMacchina) = mgrR.FindAll(New LUNA.LunaSearchParameter(LFM.RisorsaSuMacchina.IdMacchinario, cmbMacchinarioSel.SelectedValue))

                        For Each singR As Risorsa In l
                            If lR.FindAll(Function(x) x.IdRisorsa = singR.IdRis).Count Then
                                lFin.Add(singR)
                            End If
                        Next

                    End Using
                Else
                    lFin.AddRange(l)
                End If

            End If

            lFin.Sort(Function(x, y) x.Descrizione.CompareTo(y.Descrizione))

            dgRisorseEx.DataSource = lFin

        End Using


    End Sub

    Public Property _TipoMovRiferimento As enTipoMovMagaz

    Public ReadOnly Property RisorsaScelta As Risorsa
        Get
            Dim ris As Risorsa = Nothing

            If dgRisorseEx.SelectedRows.Count Then
                Dim dr As GridViewRowInfo = dgRisorseEx.SelectedRows(0)
                ris = dr.DataBoundItem
            End If

            Return ris

        End Get
    End Property

    Private Sub lnkCerca_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCerca.LinkClicked
        AvviaRicerca()
    End Sub
End Class
