Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerConfig
Imports FormerBusinessLogic
Imports System.IO
Imports FormerIO

Public Class ucOrdiniDettaglio
    Inherits ucFormerUserControl

    Private _OrdSel As Ordine
    'Private _OrdineSel As Ordine
    Private _SolaLettura As Boolean
    Private _CollSorgenti As cSorgentiCollezione
    Private _ProdottoSel As Prodotto


    Public Property SolaLettura() As Boolean
        Get
            Return _SolaLettura
        End Get

        Set(ByVal value As Boolean)

            _SolaLettura = value

            'PreparaControlli()

        End Set
    End Property

    Private _TipoAzione As enTipoAzione = enTipoAzione.Visualizzazione

    Friend Property TipoAzione() As enTipoAzione
        Get
            Return _TipoAzione
        End Get
        Set(ByVal value As enTipoAzione)
            _TipoAzione = value
        End Set
    End Property

    Friend Function SalvaFile(ByRef Ord As Ordine) As Integer

        Dim Ris As Integer = 0

        Try

            Dim NuovoNomeFile As String = ""

            If (Ord.FilePath <> _OrdSel.FilePath) Then
                'salvo l'anteprima se è un ordine nuovo o se è stato cambiato il file

                If Ord.IdCom Then
                    NuovoNomeFile = FormerPath.PathCommesse & Ord.IdCom & "\"
                Else
                    NuovoNomeFile = FormerPath.PathTemp
                End If

                NuovoNomeFile = NuovoNomeFile & FormerLib.FormerHelper.File.EstraiNomeFile(txtFile.Text, Ord.IdOrd)
                'FileCopy(txtFile.Text, NuovoNomeFile)

                MgrIO.FileCopia(Me.ParentForm, txtFile.Text, NuovoNomeFile)
                Ord.FilePath = NuovoNomeFile
                Using mO As New OrdiniDAO
                    mO.SalvaFile(Ord)
                End Using

            End If

            Dim RisalvareSorgenti As Boolean = False

            If _CollSorgenti.Count <> _OrdSel.ListaSorgenti.Count Then
                RisalvareSorgenti = True
            Else
                For Each sorg As FileSorgente In _CollSorgenti
                    If _OrdSel.ListaSorgenti.FindAll(Function(x) x.FilePath = sorg.FilePath).Count = 0 OrElse sorg.IsChanged = True Then
                        RisalvareSorgenti = True
                        Exit For
                    End If
                Next
            End If

            If RisalvareSorgenti Then

                'salvo i sorgenti

                Dim Sorg As FileSorgente
                Using Sorgenti As New cSorgentiColl
                    Sorgenti.EliminaTutti(_OrdSel.IdOrd, _CollSorgenti.ListaIdAncoraPresenti)
                End Using

                Dim AggiuntiNuoviFile As Boolean = False
                For Each Sorg In _CollSorgenti

                    If Sorg.IdSorgente = 0 Then

                        Dim Estensione As String = ""
                        Estensione = Sorg.FilePath.Substring(Sorg.FilePath.Length - 4)

                        FormerPathCreator.GetAnteprima(_OrdSel)
                        If Ord.IdCom Then
                            NuovoNomeFile = FormerPath.PathCommesse & Ord.IdCom & "\"
                        Else
                            NuovoNomeFile = FormerPath.PathTemp
                        End If
                        NuovoNomeFile = NuovoNomeFile & FormerHelper.Web.NormalizzaNomeFile(FormerLib.FormerHelper.File.EstraiNomeFile(Sorg.FilePath, Ord.IdOrd)) 'GetNomeFileTemp(Estensione)
                        'FileCopy(Sorg.FilePath, NuovoNomeFile)
                        'NuovoNomeFile = NuovoNomeFile
                        MgrIO.FileCopia(Me.ParentForm, Sorg.FilePath, NuovoNomeFile)
                        Sorg.FilePath = NuovoNomeFile
                        Sorg.IdOrd = Ord.IdOrd
                        Sorg.Save()
                        AggiuntiNuoviFile = True
                    Else
                        'qui risalvo 
                        If Sorg.IsChanged Then
                            Sorg.Save()
                        End If
                    End If

                Next

                'qui devo vedere se mandare l'ordine in preinserito o in refine automatico

                If AggiuntiNuoviFile Then
                    If Ord.IdCom = 0 And (Ord.Stato = enStatoOrdine.Preinserito Or Ord.Stato = enStatoOrdine.Registrato) Then
                        Dim PreRefineErrorCode As enErroriPreRefine = enErroriPreRefine.Nessuno
                        If Ord.IdTipoProd <> enRepartoWeb.StampaDigitale Then
                            Dim TotPagineNeiSorgenti As Integer = Ord.ListaSorgenti.Count
                            Dim risValidazioneOrdine As ValidationOrderResult = FormerValidator.ValidaOrdineInterno(Ord)
                            PreRefineErrorCode = MgrPreRefineCheck.CheckOrder(risValidazioneOrdine,
                                                                              Ord.ListinoBase,
                                                                              TotPagineNeiSorgenti,
                                                                              Ord.NFogli,
                                                                              Ord.TipoRetro)

                        End If
                        If PreRefineErrorCode = enErroriPreRefine.Nessuno Then
                            'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Nessun errore PreRefine, l'ordine passa a Refineautomatico")
                            Using mgr As New OrdiniDAO
                                mgr.InserisciLog(Ord, enStatoOrdine.RefineAutomatico)
                            End Using
                        Else
                            'MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, IdOrd, "Errore Prerefine " & PreRefineErrorCode & ", l'ordine passa a Preinserito")
                            Using mgr As New OrdiniDAO
                                mgr.InserisciLog(Ord, enStatoOrdine.Preinserito)
                            End Using
                        End If
                    End If

                End If

            End If

        Catch ex As Exception

            Ris = ex.GetHashCode
            ManageError(ex)

        End Try

        Return Ris

    End Function

    Friend Sub RiempiOrdineDaControlli(ByRef Ord As Ordine)

        Ord = _OrdSel.Clone

        Ord.IdOrd = _OrdSel.IdOrd
        Ord.Stato = _OrdSel.Stato
        Ord.IdRub = cmbCli.SelectedValue
        Ord.IdTipoProd = cmbTipoProd.SelectedValue
        Ord.IdProd = cmbProd.SelectedValue
        Ord.IdCorriere = cmbCorriere.SelectedValue
        Ord.NomeLavoro = txtNomeLavoro.Text

        If Ord.IdOrd Then
            Ord.DataIns = _OrdSel.DataIns
            Ord.DataCambioStato = _OrdSel.DataCambioStato
        End If

        Ord.Lungo = txtLunghezza.Text
        Ord.Largo = txtLarghezza.Text

        Ord.PrezzoProd = CDbl(lblTotForn.Text)
        Ord.Qta = txtQta.Text
        'Ord.Iva = CDbl(lblIva.Text)
        Ord.TotaleForn = CDbl(lblTotForn.Text)
        'Ord.CostoSped = CDbl(lblCostoSped.Text)
        Ord.Sconto = CDbl(txtSconto.Text)
        Ord.Ricarico = CDbl(txtRicarico.Text)
        'Ord.Prezzo = CDbl(lblTot.Text)
        Ord.Preventivo = IIf(chkPreventivo.Checked, enSiNo.Si, enSiNo.No)
        Ord.MantieniCampione = IIf(chkMantieniCampione.Checked, enSiNo.Si, enSiNo.No)
        Ord.NFogli = txtNFogli.Text
        If Ord.NFogli = 0 Then Ord.NFogli = 1
        Ord.Annotazioni = txtNote.Text

        Ord.FilePath = txtFile.Text

        If _CollSorgenti.Count Then
            Dim Sorge As FileSorgente
            Sorge = _CollSorgenti.Lista(0)
            Ord.NomeFileOriginale = FormerLib.FormerHelper.File.EstraiNomeFile(Sorge.FilePath)
            Sorge = Nothing
        End If
        Ord.DataPrevConsegna = dataPrevConsegna.Value

        Ord.OrdMail = _OrdSel.OrdMail

        Dim TipoConsegna As Integer = 0
        If rdoFast.Checked Then TipoConsegna = enTipoConsegna.Fast
        If rdoLow.Checked Then TipoConsegna = enTipoConsegna.Slow
        Ord.TipoConsegna = TipoConsegna

        Dim PeriodoConsegna As Integer = 0
        If rdoMatt.Checked Then PeriodoConsegna = enMomentoConsegna.Mattina
        If rdoOrario.Checked Then
            PeriodoConsegna = enMomentoConsegna.OrarioSpecifico
            Ord.OraConsegna = cmbOrari.Text
        End If

        Ord.PeriodoPrevConsegna = PeriodoConsegna
        Ord.Orientamento = cmbOrientamento.SelectedIndex

        'Ord.ListaLavorazioniCustom = UcLavorazioniOrd.ListaIdSelezionati
        Ord.UsaLavorazioniDefault = False

        If _ModificataListaLav Then
            Ord.ModificatiLavLog = True
        End If

        'ord.NomeFileOriginale = 

    End Sub

    Private Sub CaricaCli()

        Using cli As New VociRubricaDAO
            cmbCli.ValueMember = "IdRub"
            cmbCli.DisplayMember = "Nominativo"

            cmbCli.DataSource = cli.ListaCombo(enTipoRubrica.Tutto, False)
        End Using
    End Sub

    Public Sub CaricaCombo()

        CaricaCli()

        Dim TipoProd As New cTipoProdCom(False)
        cmbTipoProd.DataSource = TipoProd
        cmbTipoProd.ValueMember = "Id"
        cmbTipoProd.DisplayMember = "Descrizione"

        Using Corriere As New CorrieriDAO

            cmbCorriere.DataSource = Corriere.GetAll(LFM.Corriere.Descrizione, False)
            cmbCorriere.ValueMember = "IdCorriere"
            cmbCorriere.DisplayMember = "Descrizione"
        End Using

        'carico la combo degli stati
        Dim StatoOrd As New cStatoOrdini(False)
        cmbStato.DataSource = StatoOrd
        cmbStato.ValueMember = "Id"
        cmbStato.DisplayMember = "Descrizione"

        CaricaProdotti()

    End Sub

    Private Sub CaricaLavInCat()

        'carico la lista delle lavorazioni 

        Using mgr As New LavorazioniDAO


            Dim IdCat As Integer = 0

            If Not tvwCatLavoraz.SelectedNode Is Nothing Then

                If tvwCatLavoraz.SelectedNode.Name.StartsWith("C") Then
                    Dim PosizF As Integer = tvwCatLavoraz.SelectedNode.Name.IndexOf("F")
                    If PosizF <> -1 Then
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1, PosizF - 1)
                    Else
                        IdCat = tvwCatLavoraz.SelectedNode.Name.Substring(1)
                    End If
                End If

                Dim l As List(Of LavorazioneEx) = mgr.ListaLavorazioni(0, IdCat) ',cmbCategoria.SelectedValue)
                DgLavorazioni.AutoGenerateColumns = False
                DgLavorazioni.DataSource = l

            End If
        End Using

        'Dim x As New cLavoriColl
        'Dim dtLista As DataTable

        'dtLista = x.ListaLavorazioni

        'DgLavorazioni.DataSource = dtLista

        'DgLavorazioni.Columns(0).Visible = False
        'DgLavorazioni.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgLavorazioni.Columns(3).DefaultCellStyle.Format = "0.00"

        'x = Nothing

    End Sub

    Private Sub tvwCat_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwCatLavoraz.AfterSelect

        CaricaLavInCat()

    End Sub

    Private Sub CaricaCat()

        Using C As New CatLavDAO

            tvwCatLavoraz.Nodes.Clear()


            Dim Node As TreeNode = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Tutto, "TUTTO")
            Node.BackColor = Color.White
            Node.ForeColor = Color.Black

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaOffset, "OFFSET")
            Node.BackColor = FormerColori.ColoreRepartoOffset
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.StampaDigitale, "DIGITALE")
            Node.BackColor = FormerColori.ColoreRepartoDigitale
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Packaging, "PACKAGING")
            Node.BackColor = FormerColori.ColoreRepartoPackaging
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Ricamo, "RICAMO")
            Node.BackColor = FormerColori.ColoreRepartoRicamo
            Node.ForeColor = Color.White

            Node = tvwCatLavoraz.Nodes.Add("R" & enRepartoWeb.Etichette, "ETICHETTE")
            Node.BackColor = FormerColori.ColoreRepartoEtichette
            Node.ForeColor = Color.White

            tvwCatLavoraz.Nodes.Add("C0", "Senza categoria", 0, 0)

            For Each Cat As CatLav In C.GetAll("OrdineEsecuzione, Descrizione")
                Dim ChiavePadre As String = "C" & Cat.IdCatLav

                Dim ChiaveReparto As String = "R" & Cat.RepartoAppartenenza

                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes.Add(ChiavePadre, Cat.Descrizione, 0, 0)

                'qui devo caricare tutti i singoli formati prodotto che sono linkati in tutte le lavorazioni di questa categoria
                'chiamo un metodo specifico che mi torna una serie di IdFormatoProdotto
                'Using mgr As New FormatiProdottoDAO
                '    For Each IdCl As Integer In mgr.ListaIdFormatoByIdCatLav(Cat.IdCatLav)
                '        Dim ChiaveNodo As String = ChiavePadre & "F" & IdCl
                '        Dim TextNodo As String = String.Empty
                '        If IdCl Then
                '            Dim fp As New FormatoProdotto
                '            fp.Read(IdCl)
                '            TextNodo = fp.Formato
                '        Else
                '            TextNodo = " * - Tutti i formati"
                '        End If
                '        tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes.Add(ChiaveNodo, TextNodo, 1, 1)

                '        Using mgrL As New LavorazioniDAO
                '            For Each IdL As Integer In mgrL.ListaIdLavorazioniByFormatoProdotto(IdCl, Cat.IdCatLav)
                '                Dim ChiaveNodoL As String = ChiaveNodo & "L" & IdL
                '                Dim TextNodoL As String = String.Empty

                '                Dim L As New Lavorazione
                '                L.Read(IdL)
                '                TextNodo = L.Sigla & " - " & L.Descrizione

                '                tvwCatLavoraz.Nodes(ChiaveReparto).Nodes(ChiavePadre).Nodes(ChiaveNodo).Nodes.Add(ChiaveNodoL, TextNodo, 2, 2)

                '            Next
                '        End Using



                '    Next
                'End Using

            Next

            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Tutto).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaOffset).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.StampaDigitale).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Ricamo).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Packaging).Expand()
            tvwCatLavoraz.Nodes("R" & enRepartoWeb.Etichette).Expand()

        End Using

    End Sub

    Friend Sub Carica(Optional ByVal OrdSelezionato As Ordine = Nothing, Optional ByVal IdRub As Integer = 0, Optional P As Prodotto = Nothing)

        If OrdSelezionato Is Nothing Then
            _OrdSel = New Ordine
        Else
            _OrdSel = OrdSelezionato
        End If

        ToolTipEsistente.SetToolTip(pctAlertCli, "Il cliente selezionato ha superato lo scoperto massimo impostato!")
        ToolTipEsistente.SetToolTip(pctAlertPrezzo, "Il cliente selezionato ha un prezzo personale per il prodotto scelto!")

        CaricaCombo()

        CaricaCat()

        PreparaControlli()

        If _OrdSel.IdOrd Then

            'riapertura
            pctPreview.Visible = True
            pctPrewSorg.Visible = True
            CaricaOrd()

            'Dim lM As New LavLogDAO
            'Dim lCr As List(Of LavLog) = lM.Find(New LUNA.LunaSearchParameter("IdOrd", _OrdSel.IdOrd))

            'For Each l As LavLog In lCr
            '    lblLavorazioni.Text &= l.Descrizione & ";"
            'Next
            UcCaratProdotto.Carica(_OrdSel)

            MgrAnteprime.CreaRiepilogoOrd(_OrdSel, webRiepilogo, enTipoAnteprima.Generale)

            If TabCommessa.TabPages.Contains(tbRiepilogo) = False Then
                TabCommessa.TabPages.Insert(0, tbRiepilogo)
                TabCommessa.SelectedTab = tbRiepilogo
            End If
            If _OrdSel.Stato > enStatoOrdine.Registrato Then DisattivaControlli()

            'If _OrdSel.IdCom Then lnkApriCom.Visible = True
            'If _OrdSel.IdDoc Then lnkRiapriDocFisc.Visible = True

            UcAllegati.Carica(, _OrdSel.IdOrd)
            'If _OrdSel.Stato > enStatoOrdine.InCodaDiStampa Then
            '    UcLavorazioniOrd.SolaLettura = True
            'End If

            If Not _OrdSel.ListinoBase Is Nothing AndAlso _OrdSel.ListinoBase.FormatoProdotto.Orientabile = enSiNo.Si Then
                pnlOrientamento.Visible = True
            Else
                pnlOrientamento.Visible = False
            End If

            'If PostazioneCorrente.UtenteConnesso.IdUt = FormerConst.UtentiSpecifici.IdUtenteAntonio Then
            'pctSbloccaProd.Visible = True
            'Else
            'pctSbloccaProd.Visible = False
            ' End If

            CaricaFileAllegati()

        Else
            btnApplica.Visible = False
            lblIntestazione.Visible = False

            _CollSorgenti = New cSorgentiCollezione

            lblProdOrd.Visible = False


            pctPreview.Visible = False
            pctPrewSorg.Visible = False

            'nuovo
            TabCommessa.TabPages.Remove(tbRiepilogo)
            TabCommessa.TabPages.Remove(tpMessaggi)

            dataPrevConsegna.Value = _OrdSel.CalcolaDataConsegna(enTipoConsegna.Normale, cmbProd.SelectedValue, cmbCorriere.SelectedValue)

            If SolaLettura = False Then
                TabCommessa.TabPages.Remove(tbLog)
            End If

            If IdRub Then MgrControl.SelectIndexCombo(cmbCli, IdRub)

            If Not P Is Nothing Then
                MgrControl.SelectIndexCombo(cmbProd, P.IdProd)

                cmbCli.Focus()
            End If


        End If

    End Sub

    Private Sub AttivaControlli()

        'lnkNewCli.Visible = True
        'lnkNewProd.Visible = True
        'cmbCli.Enabled = True
        'cmbTipoProd.Enabled = True
        'cmbProd.Enabled = True
        txtLunghezza.ReadOnly = False
        txtLarghezza.ReadOnly = False
        txtQta.Enabled = True
        'txtQta.DropDownStyle = ComboBoxStyle.DropDown
        btnScegliFile.Visible = True
        'cmbCorriere.Enabled = True
        txtSconto.ReadOnly = False
        txtRicarico.ReadOnly = False
        txtNote.ReadOnly = False
        lnkAggiungi.Enabled = True
        lnkRimuovi.Enabled = True
        chkPreventivo.Enabled = True
        txtNFogli.Enabled = True
        lnkSpostaSu.Enabled = True
        lnkSpostaGiu.Enabled = True
        lnkRimuovi.Enabled = True

        txtNomeLavoro.ReadOnly = False

        cmbOrientamento.Enabled = True

    End Sub

    Private Sub DisattivaControlli()

        'mette in sola lettura il componente
        lnkNewCli.Visible = False
        lnkNewProd.Visible = False
        cmbCli.Enabled = False
        cmbCli.BackColor = Color.White
        cmbCli.ForeColor = Color.Black
        cmbTipoProd.Enabled = False
        cmbTipoProd.BackColor = Color.White
        cmbTipoProd.ForeColor = Color.Black
        cmbProd.Enabled = False
        cmbProd.BackColor = Color.White
        cmbProd.ForeColor = Color.Black
        txtLunghezza.ReadOnly = True
        txtLunghezza.BackColor = Color.White
        txtLarghezza.ReadOnly = True
        txtLarghezza.BackColor = Color.White
        txtNFogli.Enabled = False
        txtQta.Enabled = False
        'txtQta.DropDownStyle = ComboBoxStyle.DropDownList
        txtQta.BackColor = Color.White
        txtQta.ForeColor = Color.Black
        btnScegliFile.Visible = False
        cmbCorriere.Enabled = False
        cmbCorriere.BackColor = Color.White
        cmbCorriere.ForeColor = Color.Black
        txtSconto.ReadOnly = True
        txtSconto.BackColor = Color.White
        txtRicarico.ReadOnly = True
        txtRicarico.BackColor = Color.White
        txtNote.ReadOnly = True
        txtNote.BackColor = Color.White
        txtNomeLavoro.ReadOnly = True
        chkPreventivo.Enabled = False

        lnkAggiungi.Enabled = False
        lnkRimuovi.Enabled = False

        lnkSpostaSu.Enabled = False
        lnkSpostaGiu.Enabled = False

        cmbOrientamento.Enabled = False

    End Sub

    Private Sub PreparaControlli()

        If _SolaLettura Then

            DisattivaControlli()
            'If Not _OrdSel Is Nothing Then
            '    If _OrdSel.IdOrd Then
            '        Select Case _OrdSel.Stato
            '            Case enStatoOrdine.Preinserito
            '                lnkPreinserito.Enabled = False
            '                lnkInserito.Enabled = True
            '                lnkRifiutato.Enabled = False

            '            Case enStatoOrdine.Registrato
            '                If _OrdSel.IdCom = 0 Then
            '                    lnkPreinserito.Enabled = True
            '                    lnkInserito.Enabled = False
            '                    lnkRifiutato.Enabled = False
            '                Else
            '                    lnkPreinserito.Enabled = False
            '                    lnkInserito.Enabled = False
            '                    lnkRifiutato.Enabled = False

            '                End If

            '            Case enStatoOrdine.Rifiutato
            '                lnkPreinserito.Enabled = True
            '                lnkInserito.Enabled = True
            '                lnkRifiutato.Enabled = False
            '        End Select
            '    End If
            'End If

        Else
            If _OrdSel Is Nothing Then
                DisattivaControlli()
            Else

                Select Case _OrdSel.Stato
                    Case enStatoOrdine.Preinserito
                        'lnkPreinserito.Enabled = False
                        'lnkInserito.Enabled = True
                        'lnkRifiutato.Enabled = False
                        AttivaControlli()
                        'Case enStatoOrdine.Registrato
                        '    If _OrdSel.IdCom = 0 Then
                        '        lnkPreinserito.Enabled = True
                        '        lnkInserito.Enabled = False
                        '        lnkRifiutato.Enabled = False
                        '    Else
                        '        lnkPreinserito.Enabled = False
                        '        lnkInserito.Enabled = False
                        '        lnkRifiutato.Enabled = False

                        '    End If
                        'DisattivaControlli()

                        'Case enStatoOrdine.Rifiutato
                        '    lnkPreinserito.Enabled = True
                        '    lnkInserito.Enabled = True
                        '    lnkRifiutato.Enabled = False

                End Select

            End If

        End If

    End Sub

    Private Sub CaricaCronologico()

        Using M As New CronoOrdiniDAO
            Dim L As List(Of CronoOrdine) = M.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "DataCrono Desc"},
                                                      New LUNA.LunaSearchParameter(LFM.CronoOrdine.IdOrd, _OrdSel.IdOrd))

            DGCrono.DataSource = Nothing
            If Not _OrdSel Is Nothing Then

                If _OrdSel.IdOrd Then
                    Using mO As New OrdiniDAO
                        Dim dt As DataTable = mO.AvanzamentoLavori(_OrdSel)
                        For Each dr As DataRow In dt.Rows
                            dr(1) = FormerEnumHelper.StatoOrdineString(dr(1), , _OrdSel.IdCorriere)
                        Next
                        DGCrono.DataSource = dt
                    End Using
                End If
            End If
        End Using
    End Sub

    Private Sub TabCommessa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCommessa.SelectedIndexChanged

        Select Case TabCommessa.SelectedIndex
            Case 2 'tblog
                CaricaCronologico()
            Case 4 ' riepilogo commessa
                MgrAnteprime.CreaRiepilogoOrd(_OrdSel, webRiepilogo, enTipoAnteprima.Generale)

        End Select

    End Sub

    Private Sub CaricaOrd()

        If _OrdSel.IdOrd Then

            txtComCod.Text = _OrdSel.Numero

            txtFile.Text = _OrdSel.FilePath

            MgrControl.SelectIndexCombo(cmbCli, _OrdSel.IdRub)
            MgrControl.SelectIndexCombo(cmbTipoProd, _OrdSel.IdTipoProd)
            MgrControl.SelectIndexCombo(cmbProd, _OrdSel.IdProd)
            MgrControl.SelectIndexCombo(cmbCorriere, _OrdSel.IdCorriere)
            cmbOrientamento.SelectedIndex = _OrdSel.Orientamento

            txtLunghezza.Text = _OrdSel.Lungo
            txtLarghezza.Text = _OrdSel.Largo
            txtStato.Text = _OrdSel.StatoStr
            txtStato.BackColor = _OrdSel.StatoColore

            txtNomeLavoro.Text = _OrdSel.NomeLavoro

            lblTotImp.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_OrdSel.TotaleImponibile)
            Try
                txtQta.Text = _OrdSel.Qta
            Catch ex As Exception

            End Try

            ' lblIva.Text = FormattaPrezzo(_OrdSel.Iva)
            lblTotForn.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_OrdSel.TotaleForn)
            'lblCostoSped.Text = FormattaPrezzo(_OrdSel.CostoSped)
            txtSconto.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_OrdSel.Sconto)
            txtRicarico.Text = FormerLib.FormerHelper.Stringhe.FormattaPrezzo(_OrdSel.Ricarico)
            'lblTot.Text = FormattaPrezzo(_OrdSel.Prezzo)
            chkPreventivo.Checked = IIf(_OrdSel.Preventivo = enSiNo.Si, True, False)

            chkMantieniCampione.Checked = IIf(_OrdSel.MantieniCampione = enSiNo.Si, True, False)

            CaricaFile(_OrdSel.FilePath)

            CaricaSorgenti()

            If _OrdSel.NFogli > 1 Then
                txtNFogli.Text = _OrdSel.NFogli
            End If

            Dim TestoLabel As String = _OrdSel.IdOrd & " - " & FormerEnumHelper.RepartoStr(_OrdSel.ListinoBase.Preventivazione.IdReparto) & " - " & _OrdSel.ListinoBase.NomeEx 'cmbProd.Text

            lblProdOrd.BackColor = FormerColori.GetColoreReparto(_OrdSel.ListinoBase.Preventivazione.IdReparto)

            If _OrdSel.ListinoBase.Preventivazione.IdReparto = enRepartoWeb.Ricamo Then
                lblProdOrd.ForeColor = Color.Black
            Else
                lblProdOrd.ForeColor = Color.White
            End If

            lblOrd.BackColor = lblProdOrd.BackColor
            lblOrd.ForeColor = lblProdOrd.ForeColor

            lblProdOrd.Text = TestoLabel

            txtNote.Text = _OrdSel.Annotazioni

            Dim Cliente As New VoceRubrica
            Cliente.Read(_OrdSel.IdRub)
            lblIntestazione.Text = Cliente.Intestazione
            Cliente = Nothing

            rdoNorm.Enabled = False
            rdoFast.Enabled = False
            rdoLow.Enabled = False

            'carico la consegna
            Select Case _OrdSel.TipoConsegna
                Case enTipoConsegna.Normale
                    rdoNorm.Checked = True
                Case enTipoConsegna.Fast
                    rdoFast.Checked = True
                Case enTipoConsegna.Slow
                    rdoLow.Checked = True
            End Select

            If _OrdSel.DataPrevConsegna <> Date.MinValue Then
                dataPrevConsegna.Value = _OrdSel.DataPrevConsegna
            Else
                dataPrevConsegna.Value = _OrdSel.DataIns
            End If

            Select Case _OrdSel.PeriodoPrevConsegna
                Case enMomentoConsegna.Mattina
                    rdoMatt.Checked = True
                Case enMomentoConsegna.Pomeriggio
                    rdoPome.Checked = True
                Case enMomentoConsegna.OrarioSpecifico
                    rdoOrario.Checked = True
                    cmbOrari.Text = _OrdSel.OraConsegna
            End Select

            'If _OrdSel.RilascioCli Then lblRilascioCli.Text = _OrdSel.RilascioCli

            If _OrdSel.Prodotto.TipoProd = enRepartoWeb.StampaOffset Then

                lblLarghezza.Visible = False
                lblLunghezza.Visible = False
                txtLunghezza.Visible = False
                txtLarghezza.Visible = False

            Else

                lblLarghezza.Visible = True
                lblLunghezza.Visible = True
                txtLunghezza.Visible = True
                txtLarghezza.Visible = True

            End If

            If _OrdSel.IdCoupon Then
                lblCoupon.Visible = True
            End If

            CaricaLavorazioniSelezionate()

            If _OrdSel.OrdineInOmaggio = enSiNo.Si Then
                lblOmaggio.Visible = True
            End If

            If _OrdSel.IdPromo Then
                lblPromo.Visible = True
            End If

            txtTipoRetro.Text = _OrdSel.TipoRetroStr

            If _OrdSel.ConsegnaGarantita <> Date.MinValue Then
                dtConsGarantita.Value = _OrdSel.ConsegnaGarantita
                pnlConsGarantita.Visible = True
                lblNomeGarante.Text = "(" & _OrdSel.NomeGarante & ")"
            End If

        Else
            btnApplica.Visible = False
            txtComCod.Text = ""

        End If

        CaricaCronologico()

    End Sub

    Private Sub CaricaLavorazioniSelezionate()

        Dim l As New List(Of LavLog)

        For Each ll As LavLog In _OrdSel.ListLavLog
            l.Add(ll)
        Next

        l.Sort(Function(x, y) x.Ordine.CompareTo(y.Ordine))

        DgLavorazioniSel.AutoGenerateColumns = False
        DgLavorazioniSel.DataSource = l

    End Sub

    Private Sub CaricaSorgenti()

        If _OrdSel.Prodotto.FronteRetro Then
            lblSorgenti.Text = lblSorgenti.Tag & ". Il tipo retro scelto in fase di ordine era " & FormerEnumHelper.TipoRetroStr(_OrdSel.TipoRetro).ToUpper
        Else
            lblSorgenti.Text = lblSorgenti.Tag & ". Il prodotto in fase di ordine era SOLO FRONTE."
        End If

        Dim Sorg As New cSorgentiCollezione(_OrdSel.IdOrd)

        Sorg.RiempiLista()

        _CollSorgenti = Sorg

        RiempiSorgentiDaColl()

    End Sub

    Private Sub RiempiSorgentiDaColl()

        dgSorgenti.DataSource = Nothing

        Dim l As New List(Of FileSorgente)

        For Each singF As FileSorgente In _CollSorgenti
            l.Add(singF)
        Next

        l.Sort(Function(x, y) x.NumPagina.CompareTo(y.NumPagina))

        dgSorgenti.DataSource = l '_CollSorgenti

        If dgSorgenti.ColumnCount Then
            dgSorgenti.Columns(0).Visible = False
            dgSorgenti.Columns(2).Visible = False
            dgSorgenti.Columns(4).Visible = False
            dgSorgenti.Columns(6).Visible = False
            dgSorgenti.Columns(7).Visible = False

            dgSorgenti.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgSorgenti.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        ControllaUguali()

    End Sub

    Private Sub ControllaUguali()

        Dim X As FileSorgente

        Dim collCheck As New Collection, Err As Boolean = False

        For Each X In _CollSorgenti
            Try
                collCheck.Add(X.FilePath, X.FilePath)
            Catch ex As Exception
                Err = True
            End Try
        Next

        pnlAlert.Visible = Err

    End Sub

    Private Sub CaricaFile(ByVal Path As String)

        Try
            pctMain.Load(Path)
            pctPreview.Load(Path)
            pctPrewSorg.Load(Path)

        Catch ex As Exception
            pctMain.Image = Nothing
            pctPreview.Image = Nothing
            pctPrewSorg.Image = Nothing

        End Try

        pctMain.Left = 0
        pctMain.Top = 0

        VScrollBar.SmallChange = 1
        VScrollBar.LargeChange = 100

        Dim DiffV As Integer

        DiffV = pctMain.Height - MainPanel.Height
        If DiffV < 0 Then DiffV = 0

        VScrollBar.Minimum = 0
        VScrollBar.Maximum = DiffV

        HScrollBar.SmallChange = 1
        HScrollBar.LargeChange = 100

        Dim DiffH As Integer

        DiffH = pctMain.Width - MainPanel.Width
        If DiffH < 0 Then DiffH = 0

        HScrollBar.Minimum = 0
        HScrollBar.Maximum = DiffH

    End Sub

    Private Sub VScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar.Scroll
        pctMain.Top = -VScrollBar.Value
    End Sub

    Private Sub HScrollBar_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar.Scroll
        pctMain.Left = -HScrollBar.Value
    End Sub

    Private Sub lnkOpenFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenFile.LinkClicked

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = txtFile.Text

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If

    End Sub

    Private Sub btnScegliFile_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnScegliFile.LinkClicked

        OpenImg.ShowDialog()

        If OpenImg.FileName.Length Then
            'qui ha scelto un file
            CaricaFile(OpenImg.FileName)
            txtFile.Text = OpenImg.FileName

        End If

    End Sub

    Private Sub cmbCli_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCli.EnabledChanged
        If cmbCli.Enabled = False Then
            pctSblocco.Visible = True
        Else
            pctSblocco.Visible = False
        End If
    End Sub

    Private Sub cmbCli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCli.SelectedIndexChanged

        'controllo il limite di spesa e avviso a video con segnalino grafico
        pctAlertCli.Visible = False

        If cmbCli.SelectedIndex <> -1 Then
            Using xMgr As New VociRubricaDAO
                Dim x As New VoceRubrica
                x.Read(cmbCli.SelectedValue)
                'controllo se ha un limite di spesa 
                If xMgr.OltreScopertoMax(x) Then
                    pctAlertCli.Visible = True
                End If

                'If _SolaLettura = False Then

                '    'COMMENTATO 12 12 2013 
                '    'cmbCorriere.SelectedValue = x.IdCorriere

                '    'If cmbProd.SelectedIndex <> -1 Then

                '    '    Dim costo As Single = 0
                '    '    costo = CostoProdotto()
                '    '    lblTotForn.Text = FormattaPrezzo(costo)
                '    '    CalcolaTotali()

                '    'End If

                'End If
                x = Nothing
            End Using

        End If

    End Sub

    Private Function CostoProdotto() As Single

        Dim costo As Single = 0
        If cmbCli.SelectedIndex <> -1 Then
            If cmbProd.SelectedIndex <> -1 Then

                Dim voce As Integer = 0
                voce = cmbProd.SelectedValue

                Using Prod As New cProdottiColl
                    costo = Prod.LeggiPrezzo(voce, cmbCli.SelectedValue)
                End Using

            End If
        End If
        Return costo
    End Function

    Private Sub CalcolaTotali()
        '' calcolo iva e totale
        'If lblPrezzoProd.Text.Length Then


        '    Dim TotaleFornitura As Single = CostoProdotto()

        '    If rdoFast.Checked Then TotaleFornitura = _ProdottoSel.PrezzoFast
        '    If rdoLow.Checked Then TotaleFornitura = _ProdottoSel.PrezzoLow

        '    Dim Qta As Single = txtQta.Text

        '    TotaleFornitura = TotaleFornitura * Qta
        If Not _OrdSel Is Nothing Then
            Dim Sconto As Single = 0

            Sconto = txtSconto.Text

            Dim Ricarico As Single = 0

            Ricarico = txtRicarico.Text

            _OrdSel.Sconto = Sconto
            _OrdSel.Ricarico = Ricarico
            lblTotImp.Text = FormerHelper.Stringhe.FormattaPrezzo(_OrdSel.TotaleImponibile)
        End If

        '    Dim Iva As Single = TotImponibile * FormerHelper.Finanziarie.GetPercentualeIva / 100

        '    'Dim Totale As String = CDbl(lblCostoSped.Text) + TotImponibile + Iva

        '    lblTotForn.Text = FormattaPrezzo(TotaleFornitura)
        '    lblTotImp.Text = FormattaPrezzo(TotImponibile)
        '    'lblIva.Text = FormattaPrezzo(Iva)
        '    '  lblTot.Text = FormattaPrezzo(Totale)
        'End If

    End Sub

    Private Function Comparer(ByVal x As Prodotto, ByVal y As Prodotto) As Integer

        'Dim Result As Integer = y.TutteScatolePiene.CompareTo(x.TutteScatolePiene)
        'If Result = 0 Then Result = x.NumeroScatole.CompareTo(y.NumeroScatole)
        'If result = 0 Then result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Dim Result As Integer = x.Status.CompareTo(y.Status)
        If Result = 0 Then Result = x.TipoProd.CompareTo(y.TipoProd)
        If Result = 0 Then Result = x.Riassunto.CompareTo(y.Riassunto)
        'Dim Result As Integer = x.Selezionatore.CompareTo(y.Selezionatore)
        ''If Result = 0 Then Result = x.SpazioSprecato.CompareTo(y.SpazioSprecato)

        Return Result

    End Function

    Private Sub CaricaProdotti()

        Using mgr As New ProdottiDAO

            Dim L As List(Of Prodotto) = mgr.GetAll()

            L.Sort(AddressOf Comparer)
            cmbProd.ValueMember = "IdProd"
            cmbProd.DisplayMember = "Riassunto"
            cmbProd.DataSource = L

        End Using

        'If cmbTipoProd.SelectedIndex <> -1 Then

        '    Dim voce As cEnum = cmbTipoProd.SelectedItem
        '    Dim TipoProd As Integer = voce.Id

        '    Dim x As New cProdottiColl
        '    cmbProd.ValueMember = "IdProd"
        '    cmbProd.DisplayMember = "Descr"

        '    cmbProd.DataSource = x.ListaPerCombo(TipoProd, , IIf(TipoAzione = enTipoAzione.Nuovo, True, False))

        '    If voce.Id = enRepartoWeb.StampaOffset Then

        '        lblLarghezza.Visible = False
        '        lblLunghezza.Visible = False
        '        txtLunghezza.Visible = False
        '        txtLarghezza.Visible = False

        '    Else

        '        lblLarghezza.Visible = True
        '        lblLunghezza.Visible = True
        '        txtLunghezza.Visible = True
        '        txtLarghezza.Visible = True

        '    End If

        'End If

    End Sub

    Private Sub cmbTipoProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        CaricaProdotti()
    End Sub

    Private Sub cmbProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProd.SelectedIndexChanged

        If _SolaLettura = False Then

            If cmbProd.SelectedIndex <> -1 Then

                If _OrdSel.IdOrd = 0 Then

                    'Dim P As New Prodotto
                    'P.Read(cmbProd.SelectedValue)
                    If _OrdSel.IdListinoBase Then UcCaratProdotto.Carica(_OrdSel.Prodotto.ListinoBase)

                    'Dim Dt As DataTable, x As New cLavoriColl, Dr As DataRow
                    'Dt = x.ListaProdottoSel(cmbProd.SelectedValue)
                    'lblLavorazioni.Text = ""
                    'For Each Dr In Dt.Rows
                    '    lblLavorazioni.Text &= Dr("Descrizione").ToString & ";"
                    '    lblLavorazPreviste.Text = lblLavorazioni.Text
                    'Next
                Else

                    Dim Dt As DataTable, Dr As DataRow
                    Using x As New cLavoriColl
                        Dt = x.ListaProdottoSel(cmbProd.SelectedValue)
                    End Using

                    'lblLavorazPreviste.Text = ""
                    'For Each Dr In Dt.Rows
                    '    lblLavorazPreviste.Text &= Dr("Descrizione").ToString & ";"
                    'Next

                End If
                'UcLavorazioniOrd.CaricaxProd(cmbProd.SelectedValue)
                Dim voce As Integer = 0
                voce = cmbProd.SelectedValue

                Dim prod As New Prodotto
                prod.Read(voce)
                _ProdottoSel = prod

                rdoNorm.Enabled = True
                rdoNorm.Checked = False
                rdoNorm.Checked = True

                If prod.GGFast Then rdoFast.Enabled = True Else rdoFast.Enabled = False
                If prod.GGLow Then rdoLow.Enabled = True Else rdoLow.Enabled = False

            End If

            Dim costo As Single = 0

            ' costo = CostoProdotto()
            'lblTotForn.Text = FormattaPrezzo(costo)

            'CalcolaTotali()

        End If

    End Sub

    Private Sub btnDetCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetCli.Click

        If cmbCli.SelectedIndex <> -1 Then
            ApriCli(cmbCli.SelectedValue)
        End If

    End Sub

    Private Sub ApriCli(Optional ByVal IdRub As Integer = 0)

        Dim frmRif As New frmVoceRubrica
        Dim ObjRif As New VoceRubrica
        Dim Ris As Integer = 0
        ObjRif.Tipo = enTipoRubrica.Cliente

        If IdRub Then
            ObjRif.Read(IdRub)
        End If

        ParentFormEx.Sottofondo()
        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()

        If Ris Then
            If IdRub = 0 Then
                CaricaCli()
            End If
        End If

        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    Private Sub btnDetProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetProd.Click

        If cmbProd.SelectedIndex <> -1 Then
            ApriProd(cmbProd.SelectedValue)
        End If

    End Sub

    Private Sub ApriProd(Optional ByVal IdProd As Integer = 0)

        Dim frmRif As New frmListinoProdotto
        Dim ObjRif As New Prodotto
        Dim Ris As Integer = 0

        ParentFormEx.Sottofondo()

        If IdProd Then ObjRif.Read(IdProd)

        Ris = frmRif.Carica(ObjRif)
        ParentFormEx.Sottofondo()

        If Ris Then
            'aggiorno la combo
            CaricaProdotti()
            MgrControl.SelectIndexCombo(cmbProd, _OrdSel.IdProd)
        End If

        frmRif.Dispose()
        ObjRif = Nothing

    End Sub

    Private Sub lnkNewCli_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNewCli.LinkClicked
        ApriCli()
    End Sub

    Private Sub lnkNewProd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNewProd.LinkClicked
        ApriProd()
    End Sub

    Private Sub txtSconto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSconto.TextChanged, txtRicarico.TextChanged, txtQta.TextChanged

        If _SolaLettura = False Then
            If sender.focused Then
                If sender.text.length = 0 Then
                    sender.text = "0"
                Else
                    CalcolaTotali()
                End If
            End If
        End If

    End Sub

    'Private Sub txtLarghezza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLarghezza.TextChanged, txtLunghezza.TextChanged
    '    If sender.text.length = 0 Then
    '        sender.text = "0"
    '    End If
    'End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'SplitContainerImg.DefaultWidth = 150

        ' Add any initialization after the InitializeComponent() call.

        MgrControl.InizializeCollapsiblePanel(RadCollapsiblePanelMain)
        MgrControl.InizializeCollapsiblePanel(RadCollapsiblePanelDatiEconomici)
        MgrControl.InizializeCollapsiblePanel(RadCollapsiblePanelConsegna)
        MgrControl.InizializeCollapsiblePanel(RadCollapsiblePanelNote)

    End Sub

    'Private Sub lnkPreinserito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '        _OrdSel.InserisciLog(enStatoOrdine.Preinserito)
    '        CaricaCronologico()
    '        PreparaControlli()
    '        RaiseEvent CambioStato()
    '    End If

    'End Sub

    'Private Sub lnkInserito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    'End Sub

    'Private Sub lnkRifiutato_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", Postazione.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '        _OrdSel.InserisciLog(enStatoOrdine.Rifiutato)
    '        CaricaCronologico()
    '        PreparaControlli()
    '        RaiseEvent CambioStato()
    '    End If

    'End Sub

    Public Event CambioStato()

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked

        If _OrdSel.IdOrd Then

            ParentFormEx.Sottofondo()

            'Dim PathMOd As String = webRiepilogo.Url.ToString  'FormerPath.PathLocale & "riepOrd.htm"

            Using x As New frmStampa

                x.Carica(webRiepilogo)

            End Using

            ParentFormEx.Sottofondo()

        End If

    End Sub

    Private Sub lnkOpenFolder_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenFolder.LinkClicked, lnkOpenFoldSorg.LinkClicked
        'apro il path delle immagini

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = FormerLib.FormerHelper.File.GetFolder(txtFile.Text)

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkOpenFileSorg_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOpenFileSorg.LinkClicked

        If dgSorgenti.SelectedRows.Count Then

            Dim FileSel As String

            Dim fileSelezionato As FileSorgente = dgSorgenti.SelectedRows(0).DataBoundItem

            FileSel = fileSelezionato.FilePath

            Try

                Dim PathMod As String = FileSel

                Dim x As New Process

                x.StartInfo.FileName = PathMod
                x.Start()

            Catch ex As Exception

                MessageBox.Show(FileSel & " " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If

    End Sub

    Private Function GetNextNumPagina() As Integer
        Dim ris As Integer = 0

        Dim Progress As Integer = 1

        Dim l As New List(Of FileSorgente)

        For Each singF As FileSorgente In _CollSorgenti
            l.Add(singF)
        Next

        Dim Esci As Boolean = False

        Do

            If l.FindAll(Function(x) x.NumPagina = Progress).Count = 0 Then
                Esci = True
            Else
                Progress += 1
            End If

        Loop Until Esci = True

        ris = Progress

        Return ris
    End Function

    Private Sub lnkAggiungi_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiungi.LinkClicked

        OpenFileSorg.Filter = "File sorgente PDF|*.PDF" '|Altro file sorgente|*.*"
        OpenFileSorg.ShowDialog()
        Dim pathPDF As String = OpenFileSorg.FileName
        'Dim PathPdf As String = FormerLib.FormerHelper.Web.NormalizzaNomeFile(pathPDFOriginale)

        If pathPDF.Length Then

            If pathPDF.ToLower.EndsWith(".pdf") Then
                'qui ha scelto un file
                'CaricaSorg(OpenFileSorg.FileName)

                '        Dim Dr As New DataGridViewRow
                Dim OkDimensioni As Boolean = True

                If FormerHelper.File.GetMB(pathPDF) > 100 Then
                    OkDimensioni = False
                    If MessageBox.Show("Il file che stai allegando pesa piu di 100 Megabyte, questo può creare problemi e si consiglia di ottimizzarlo prima di allegarlo. Vuoi continuare?", "Allega File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        OkDimensioni = True

                    End If
                End If

                If OkDimensioni Then

                    'qui controllo che non ci sia gia un sorgente con lo stesso nome 

                    Dim NomeFile As String = FormerLib.FormerHelper.File.EstraiNomeFile(pathPDF)
                    Dim AlertNomeFile As Boolean = False
                    For Each F As FileSorgente In _CollSorgenti.Lista

                        If FormerLib.FormerHelper.File.EstraiNomeFile(F.FilePath) = NomeFile Then
                            AlertNomeFile = True
                            Exit For
                        End If

                    Next

                    Dim OkNomeFile As Boolean = True

                    If AlertNomeFile Then
                        MessageBox.Show("Ci sono altri file sorgenti che hanno lo stesso nome del file che si sta inserendo, modificare il nome e riprovare.")
                        OkNomeFile = False
                    End If

                    If OkNomeFile Then
                        Dim NumPagTrovate As Integer = FormerHelper.PDF.GetNumeroPagine(pathPDF)
                        'Dim NumPagina As Integer = _CollSorgenti.Count + 1

                        If NumPagTrovate > 1 Then

                            Try

                                For i As Integer = 1 To NumPagTrovate

                                    Dim PathEnd As String = pathPDF.ToLower.Replace(".pdf", ".p" & i.ToString("0000") & ".pdf")

                                    FormerHelper.PDF.EstraiPaginaFromPdf(pathPDF, PathEnd, i)

                                    Dim Sorg As New FileSorgente

                                    Sorg.FilePath = PathEnd
                                    Sorg.IdOrd = _OrdSel.IdOrd
                                    Sorg.NumPagina = GetNextNumPagina()
                                    Sorg.StatoRefine = enStatoRefineSorgente.NonDefinito
                                    Sorg.IdSorgente = 0

                                    _CollSorgenti.Add(Sorg)
                                    ' NumPagina += 1

                                Next

                            Catch ex As Exception

                            End Try

                        Else

                            Dim Sorg As New FileSorgente

                            Sorg.FilePath = OpenFileSorg.FileName
                            Sorg.IdOrd = _OrdSel.IdOrd
                            Sorg.NumPagina = GetNextNumPagina()
                            Sorg.StatoRefine = enStatoRefineSorgente.NonDefinito
                            Sorg.IdSorgente = 0

                            'dgSorgenti.Rows.Add(Sorg)
                            _CollSorgenti.Add(Sorg)
                        End If

                        RiempiSorgentiDaColl()
                    End If

                End If

            Else
                MessageBox.Show("Selezionare un file PDF")
            End If

        End If

    End Sub

    Private Sub lnkDel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkRimuovi.LinkClicked

        If dgSorgenti.SelectedRows.Count Then

            Dim Dr As DataGridViewRow

            Dr = dgSorgenti.SelectedRows(0)

            If MessageBox.Show("Confermi l'eliminazione del file sorgente selezionato?", "Eliminazione file sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim fileSel As FileSorgente = Dr.DataBoundItem

                Dim FileName As String
                FileName = fileSel.FilePath 'dr.Cells(3).Value

                _CollSorgenti.Remove(FileName)

                If MessageBox.Show("Vuoi aggiornare i numeri di pagina di tutti i sorgenti successivi al file rimosso?", "Eliminazione file sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    RicalcolaNumPaginaDa(fileSel.NumPagina, False)
                End If

                'RicalcolaNumPaginaDa(fileSel.NumPagina, False)

                RiempiSorgentiDaColl()

            End If

        End If

    End Sub

    Private Sub RicalcolaNumPaginaDa(NumPaginaStart As Integer,
                                     Optional WithSave As Boolean = True)
        For Each Sorgente As FileSorgente In _CollSorgenti
            If Sorgente.NumPagina > NumPaginaStart Then
                Sorgente.NumPagina = GetNextNumPagina()
                If WithSave Then Sorgente.Save()
            End If
        Next
    End Sub

    Private Sub btnCambiaStato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiaStato.Click
        If MessageBox.Show("Confermi il cambiamento di stato dell'ordine?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Using mO As New OrdiniDAO
                mO.InserisciLog(_OrdSel, cmbStato.SelectedValue)
            End Using

            CaricaCronologico()
            PreparaControlli()
            RaiseEvent CambioStato()
        End If
    End Sub

    Private Sub rdoOrario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOrario.CheckedChanged
        cmbOrari.Enabled = rdoOrario.Checked
    End Sub

    Private Sub btnApplica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplica.Click

        If MessageBox.Show("Confermi il cambiamento dei dati di consegna?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            _OrdSel.DataPrevConsegna = dataPrevConsegna.Value

            Dim PerPrevCons As Integer = 0 'pomeriggio
            If rdoMatt.Checked Then PerPrevCons = enMomentoConsegna.Mattina

            If rdoOrario.Checked Then
                PerPrevCons = enMomentoConsegna.OrarioSpecifico
                _OrdSel.OraConsegna = cmbOrari.Text
            End If

            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _OrdSel.IdOrd, "Cambiata data Consegna Prevista in Origine a " & _OrdSel.DataPrevConsegna.ToString("dd/MM/yyyy"))

            _OrdSel.PeriodoPrevConsegna = PerPrevCons
            _OrdSel.Save()

            MessageBox.Show("Dati di consegna modificati con successo!", "Former", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub rdoFast_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoFast.CheckedChanged

        If Not _OrdSel Is Nothing Then
            If rdoFast.Checked Then
                dataPrevConsegna.Value = _OrdSel.CalcolaDataConsegna(enTipoConsegna.Fast, cmbProd.SelectedValue, cmbCorriere.SelectedValue)

            End If

        End If
        'CalcolaTotali()
    End Sub

    Private Sub rdoNorm_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoNorm.CheckedChanged
        If Not _OrdSel Is Nothing Then If rdoNorm.Checked Then dataPrevConsegna.Value = _OrdSel.CalcolaDataConsegna(enTipoConsegna.Normale, cmbProd.SelectedValue, cmbCorriere.SelectedValue)
        'CalcolaTotali()
    End Sub

    Private Sub rdoLow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoLow.CheckedChanged
        If Not _OrdSel Is Nothing Then If rdoLow.Checked Then dataPrevConsegna.Value = _OrdSel.CalcolaDataConsegna(enTipoConsegna.Slow, cmbProd.SelectedValue, cmbCorriere.SelectedValue)
        'CalcolaTotali()
    End Sub

    Public Event BloccaTastiForm()
    Public Event SbloccaTastiForm()

    Private Sub pctSblocco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctSblocco.Click
        Dim Ris As RisConsegnaModificabile = _OrdSel.ConsegnaAssociata.Diritti.PossoCambiareDocumentoFiscaleOrdini
        If Ris.Esito Then ' _OrdSel.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then

            'If _OrdSel.Stato < enStatoOrdine.Imballaggio Then
            'If MessageBox.Show("Confermi di voler cambiare il proprietario dell'ordine?", "Modifica ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            cmbCli.Enabled = True
            btnApplicaCli.Visible = True
            RaiseEvent BloccaTastiForm()
            'End If
            'Else
            'MessageBox.Show("Si può modificare il cliente solo per gli ordini che non sono andati oltre lo stato Imballaggio")
            'End If
        Else
            MessageBox.Show("Consegna dell'ordine non modificabile:" & Ris.BufferErrori)
        End If
    End Sub

    Private Sub btnApplicaCli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplicaCli.Click
        If MessageBox.Show("Confermi il cambiamento del proprietario dell'ordine? Verrà modificata anche la relativa consegna", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If _OrdSel.IdRub <> cmbCli.SelectedValue Then
                Using TB As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try
                        TB.TransactionBegin()

                        'faccio questo per portare online sto cliente in caso non ci fosse
                        Dim V As New VoceRubrica
                        V.Read(cmbCli.SelectedValue)
                        V.LastUpdate = Now
                        V.Save()

                        Dim VecchiaConsegna As ConsegnaProgrammata = _OrdSel.ConsegnaAssociata

                        MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _OrdSel.IdOrd, "Cambiato Cliente dell'ordine a " & V.RagSocNome)

                        _OrdSel.IdRub = cmbCli.SelectedValue
                        _OrdSel.LastUpdate = enSiNo.Si
                        _OrdSel.IdIndirizzo = V.DefaultIndirizzo.IDIndirizzo
                        _OrdSel.IdConsRiferimento = 0
                        '_OrdSel.DataCambioStato = Now 'TODO: LASTUPDATE = 1
                        _OrdSel.Save()

                        Using mgr As New ConsegneProgrammateDAO
                            'TOLTO IL 08/04/2015
                            'mgr.EliminaOrdineDaConsegna(VecchiaConsegna.IdCons, _OrdSel.IdOrd)
                            mgr.RegistraConsegnaOrdineSuGiorno(_OrdSel.IdOrd, VecchiaConsegna.IdCorr, VecchiaConsegna.Giorno, _OrdSel.IdRub, VecchiaConsegna.MatPom, V.DefaultIndirizzo.IDIndirizzo)
                            'TOLTO IL 08/04/2015
                            'mgr.EliminaConsegnaSeVuota(VecchiaConsegna.IdCons)
                        End Using

                        TB.TransactionCommit()

                        MessageBox.Show("Nuovo cliente salvato!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Question)

                        btnApplicaCli.Visible = False
                        cmbCli.Enabled = False
                        RaiseEvent SbloccaTastiForm()
                        ParentForm.Dispose()
                    Catch ex As Exception
                        TB.TransactionRollBack()
                        MessageBox.Show("Si è verificato un errore nel cambiamento del cliente dell'ordine: " & ex.Message)
                    End Try
                End Using

            Else
                RaiseEvent SbloccaTastiForm()
                btnApplicaCli.Visible = False
                cmbCli.Enabled = False
            End If
        Else
            MgrControl.SelectIndexCombo(cmbCli, _OrdSel.IdRub)
            RaiseEvent SbloccaTastiForm()
            btnApplicaCli.Visible = False
            cmbCli.Enabled = False
        End If
    End Sub

    Private Sub ApriCommessa()

        If _OrdSel.IdCom Then

            ParentFormEx.Sottofondo()

            Dim frmco As New frmCommessa

            frmco.Carica(_OrdSel.IdCom)

            frmco = Nothing
            ParentFormEx.Sottofondo()

        Else
            MessageBox.Show("La commessa non è disponibile")
        End If

    End Sub

    Private Sub lnkApriCom_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lnkRiapriDocFisc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub ApriDocumentoFiscale()

        If _OrdSel.IdDoc Then
            ParentFormEx.Sottofondo()

            Using Vendita As New cContabRicavi
                Vendita.Read(_OrdSel.IdDoc)
                Dim NuovoId As Integer = _OrdSel.IdDoc

                If Vendita.IdDocRif Then
                    NuovoId = Vendita.IdDocRif
                    'Vendita = Nothing

                    'Vendita = New cContabRicavi
                    Vendita.Read(NuovoId)
                End If

                Select Case Vendita.Tipo
                    Case enTipoDocumento.DDT, enTipoDocumento.Fattura, enTipoDocumento.Preventivo
                        Dim frmVend As New frmContabilitaRicavo
                        frmVend.Carica(NuovoId, enTipoVoceContab.VoceVendita)
                        frmVend = Nothing
                    Case enTipoDocumento.FatturaRiepilogativa
                        Dim frmVend As New frmContabilitaFatturaRiepilogativaRicavo
                        frmVend.Carica(NuovoId)
                        frmVend = Nothing

                End Select
            End Using

            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Il documento fiscale non è disponibile")
        End If

    End Sub

    Private Sub lnkNew_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkNew.LinkClicked

        ParentFormEx.Sottofondo()
        Dim Ris As Integer = 0
        Using f As New frmPostit
            Ris = f.Carica(, , _OrdSel.IdOrd)
        End Using
        If Ris Then UcAllegati.Carica(, _OrdSel.IdOrd)
        ParentFormEx.Sottofondo()

    End Sub

    Private Sub lnkAggiorna_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAggiorna.LinkClicked

        UcAllegati.Carica(, _OrdSel.IdOrd)

    End Sub

    Private Sub pctSbloccaProd_Click(sender As Object, e As EventArgs) Handles pctSbloccaProd.Click
        Dim Ris As RisConsegnaModificabile = _OrdSel.ConsegnaAssociata.Diritti.PossoCambiareDocumentoFiscaleOrdini
        If Ris.Esito Then ' _OrdSel.ConsegnaAssociata.ModificabileEx(True, False, True, True, False, False).Modificabile Then

            If _OrdSel.Stato <= enStatoOrdine.Registrato AndAlso _OrdSel.IdCom = 0 Then
                cmbProd.Enabled = True
                btnSalvaProd.Enabled = True
                btnSalvaProd.Visible = True
            Else
                MessageBox.Show("Si può modificare il prodotto solo per gli ordini che non sono andati oltre lo stato Registrato e che non sono in Commessa")
            End If

        Else
            MessageBox.Show("Consegna associata all'ordine non modificabile:" & Ris.BufferErrori)
        End If

    End Sub

    Private Sub btnSalvaProd_Click(sender As Object, e As EventArgs) Handles btnSalvaProd.Click
        If MessageBox.Show("Confermi il cambiamento di Prodotto dell'ordine?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If _OrdSel.IdProd <> cmbProd.SelectedValue Then
                Try
                    Using P As New Prodotto
                        P.Read(cmbProd.SelectedValue)
                        If P.IdListinoBase = 0 Then
                            MessageBox.Show("ATTENZIONE! Il prodotto selezionato non e' utilizzabile perchè vecchio")
                        Else
                            _OrdSel.IdProd = P.IdProd
                            _OrdSel.IdTipoProd = P.TipoProd
                            _OrdSel.Save()
                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, _OrdSel.IdOrd, "Cambiato Prodotto dell'ordine a (" & P.IdProd & ") " & P.Codice & " - " & P.Descrizione)
                            MessageBox.Show("Nuovo Prodotto salvato!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Question)

                            btnSalvaProd.Visible = False
                            cmbProd.Enabled = False
                            ParentForm.Dispose()
                        End If
                    End Using
                    RaiseEvent SbloccaTastiForm()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Else
            MgrControl.SelectIndexCombo(cmbProd, _OrdSel.IdProd)
            btnSalvaProd.Visible = False
            cmbProd.Enabled = False
        End If
    End Sub

    Private Sub pctCoupon_Click(sender As Object, e As EventArgs)

        MessageBox.Show("Per questo Ordine il cliente ha utilizzato un Coupon di Sconto")

    End Sub

    Private Sub ApriConsegna()

        If _OrdSel.IdCons Then
            'riapro la consegna programmata se prevista
            ' Dim x As New cConsColl
            ParentFormEx.Sottofondo()
            Using xc As New frmConsegnaProgrammata
                xc.Carica(_OrdSel.IdCons)
            End Using
            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("La consegna programmata non è disponibile")
        End If

    End Sub

    Private Sub lnkRiapriConsegna_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub ApriLog()


        Dim Path As String = FormerPath.PathLog & _OrdSel.IdOrd & ".log.txt"

        If FileIO.FileSystem.FileExists(Path) Then
            FormerHelper.File.ShellExtended(Path)
        Else
            Path = FormerPath.PathLog & _OrdSel.IdOrd & "\" & _OrdSel.IdOrd & ".log.txt"
            If FileIO.FileSystem.FileExists(Path) Then
                FormerHelper.File.ShellExtended(Path)
            Else
                MessageBox.Show("Il file di Log dell'ordine non è presente")
            End If
        End If

    End Sub
    Private Sub lnkLog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private _ModificataListaLav As Boolean = False

    Private Sub lnkAddLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLavoraz.LinkClicked
        AggiungiLavorazione()
    End Sub

    Private Sub AggiungiLavorazione()

        If SolaLettura = False Then

            If DgLavorazioni.SelectedRows.Count Then
                Dim l As Lavorazione = DgLavorazioni.SelectedRows(0).DataBoundItem

                If _OrdSel.ListLavLog.FindAll(Function(x) x.Idlav = l.IdLavoro).Count = 0 Then
                    If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        _ModificataListaLav = True

                        Dim llast As LavLog = Nothing

                        Dim Ordine As Integer = 0
                        If DgLavorazioniSel.Rows.Count Then
                            llast = DgLavorazioniSel.Rows(DgLavorazioniSel.Rows.Count - 1).DataBoundItem
                        Else
                            llast = New LavLog
                        End If

                        Ordine = llast.Ordine + 1

                        Dim ll As New LavLog
                        ll.Idlav = l.IdLavoro
                        ll.Descrizione = l.Descrizione
                        ll.Macchinario = l.Macchinario
                        ll.IdMacchinario = l.IdMacchinario
                        ll.Tempo = l.TempoRif
                        ll.Premio = l.Premio
                        ll.IdOrd = _OrdSel.IdOrd
                        ll.Ordine = Ordine

                        _OrdSel.ListLavLog.Add(ll)

                        CaricaLavorazioniSelezionate()
                    End If
                Else
                    MessageBox.Show("La lavorazione è gia presente nell'ordine!")
                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If

        Else
            MessageBox.Show("Non è possibile modificare l'ordine in questo stato")
        End If

    End Sub

    Private Sub lnkSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSu.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then
                'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _ModificataListaLav = True
                SpostaSu()
                'End If
            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare l'ordine in questo stato")
        End If
    End Sub

    Private Sub lnkGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkGiu.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then
                'If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                _ModificataListaLav = True
                SpostaGiu()
                'End If
            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare l'ordine in questo stato")
        End If
    End Sub

    Private Sub lnkDelLavoraz_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDelLavoraz.LinkClicked
        If SolaLettura = False Then
            If DgLavorazioniSel.SelectedRows.Count Then

                If MessageBox.Show("Confermi la modifica?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _ModificataListaLav = True

                    Dim l As LavLog = DgLavorazioniSel.SelectedRows(0).DataBoundItem

                    Dim Indice As Integer = DgLavorazioniSel.SelectedRows(0).Index

                    _OrdSel.ListLavLog.Remove(l)

                    For Each row As DataGridViewRow In DgLavorazioniSel.Rows

                        If row.Index > Indice Then
                            row.DataBoundItem.ordine -= 1
                        End If

                    Next

                    CaricaLavorazioniSelezionate()
                End If

            Else
                MessageBox.Show("Selezionare una lavorazione dalla lista")
            End If
        Else
            MessageBox.Show("Non è possibile modificare l'ordine in questo stato")
        End If
    End Sub

    Private Sub SpostaSu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As LavLog = riga.DataBoundItem
            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index - 1)
                Dim LavVecchia As LavLog = RigaVecchia.DataBoundItem

                If LavVecchia.Idlav <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione AndAlso
                   LavVecchia.Idlav <> FormerLib.FormerConst.Lavorazioni.InserimentoNelSistema Then
                    lavorazione.Ordine -= 1
                    LavVecchia.Ordine += 1
                    riga.Selected = True

                    CaricaLavorazioniSelezionate()

                    For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                        If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                            r.Selected = True
                            Exit For
                        End If
                    Next
                Else
                    MessageBox.Show("La lavorazione non può essere spostata in quella posizione")
                End If
            End If
                'riga.
            End If
    End Sub

    Private Sub SpostaGiu()
        If DgLavorazioniSel.SelectedRows.Count Then

            Dim riga As DataGridViewRow = DgLavorazioniSel.SelectedRows(0)
            Dim lavorazione As LavLog = riga.DataBoundItem

            If lavorazione.Idlav <> FormerLib.FormerConst.Lavorazioni.InserimentoNelSistema AndAlso
                lavorazione.Idlav <> FormerLib.FormerConst.Lavorazioni.StampaRealizzazione Then
                If (riga.Index + 1) < DgLavorazioniSel.Rows.Count Then
                    Dim RigaDopo As DataGridViewRow = DgLavorazioniSel.Rows(riga.Index + 1)
                    Dim lavDopo As LavLog = RigaDopo.DataBoundItem
                    lavorazione.Ordine += 1
                    lavDopo.Ordine -= 1
                    riga.Selected = True

                    CaricaLavorazioniSelezionate()

                    For Each r As DataGridViewRow In DgLavorazioniSel.Rows
                        If r.DataBoundItem.idlavoro = lavorazione.IdLavoro Then
                            r.Selected = True
                            Exit For
                        End If
                    Next

                End If
            Else
                MessageBox.Show("La lavorazione non può essere spostata")
            End If

            'riga.
        End If
    End Sub

    Private Sub ApriLogOnline()

        If _OrdSel.IdOrdOnline Then
            Dim UrlOnline As String = "http://www.tipografiaformer.it/ordini/" & _OrdSel.IdOrdOnline & "/" & _OrdSel.IdOrdOnline & ".xml"
            FormerHelper.File.ShellExtended("chrome.exe", UrlOnline)
        Else
            MessageBox.Show("Di questo ordine non è possibile visualizzare il Log Online")
        End If

    End Sub

    Private Sub lnkLogWeb_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub dgSorgenti_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgSorgenti.RowsAdded
        For Each r As DataGridViewRow In dgSorgenti.Rows
            Dim s As FileSorgente = r.DataBoundItem

            Select Case s.StatoRefine
                Case enStatoRefineSorgente.NonDefinito
                    r.Cells(0).Style.BackColor = Color.White
                    r.Cells(0).Style.SelectionBackColor = Color.White
                Case enStatoRefineSorgente.InAttesaDiRefine
                    r.Cells(0).Style.BackColor = Color.Gray
                    r.Cells(0).Style.SelectionBackColor = Color.Orange
                Case enStatoRefineSorgente.CompletatoErrore
                    r.Cells(0).Style.BackColor = Color.Red
                    r.Cells(0).Style.SelectionBackColor = Color.Red
                Case enStatoRefineSorgente.CompletatoCancelled
                    r.Cells(0).Style.BackColor = Color.Orange
                    r.Cells(0).Style.SelectionBackColor = Color.Orange
                Case enStatoRefineSorgente.CompletatoSuccess
                    r.Cells(0).Style.BackColor = Color.Green
                    r.Cells(0).Style.SelectionBackColor = Color.Green
                Case enStatoRefineSorgente.CompletatoWarning
                    r.Cells(0).Style.BackColor = Color.Yellow
                    r.Cells(0).Style.SelectionBackColor = Color.Yellow

            End Select

        Next

        ConteggioSorgenti

    End Sub

    Private Sub ConteggioSorgenti()
        tpSorgenti.Text = "File Sorgenti (" & dgSorgenti.Rows.Count & ")"
    End Sub

    Private Sub ConteggioAltriFile()
        tpAltriFile.Text = "Altri File (" & dgAltriFile.Rows.Count & ")"
    End Sub

    Private Sub SpostaPaginaSu()
        If dgSorgenti.SelectedRows.Count Then

            Dim riga As DataGridViewRow = dgSorgenti.SelectedRows(0)
            Dim file As FileSorgente = riga.DataBoundItem
            If (riga.Index - 1) >= 0 Then
                Dim RigaVecchia As DataGridViewRow = dgSorgenti.Rows(riga.Index - 1)
                Dim FileVecchia As FileSorgente = RigaVecchia.DataBoundItem

                file.NumPagina -= 1
                FileVecchia.NumPagina += 1
                riga.Selected = True

                RiempiSorgentiDaColl()
            End If
            'riga.
        End If
    End Sub

    Private Sub SpostaPaginaGiu()
        If dgSorgenti.SelectedRows.Count Then

            Dim riga As DataGridViewRow = dgSorgenti.SelectedRows(0)
            Dim file As FileSorgente = riga.DataBoundItem

            If (riga.Index + 1) < dgSorgenti.Rows.Count Then
                Dim RigaDopo As DataGridViewRow = dgSorgenti.Rows(riga.Index + 1)
                Dim FileDopo As FileSorgente = RigaDopo.DataBoundItem
                file.NumPagina += 1
                FileDopo.NumPagina -= 1
                riga.Selected = True

                RiempiSorgentiDaColl()

            End If

        End If
    End Sub

    Private Sub lnkSpostaSu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSpostaSu.LinkClicked
        SpostaPaginaSu()
    End Sub

    Private Sub lnkSpostaGiu_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSpostaGiu.LinkClicked
        SpostaPaginaGiu()
    End Sub

    Private Sub lnkApriCon_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriAltriCon.LinkClicked
        If dgAltriFile.SelectedRows.Count Then

            Using Riga As DataGridViewRow = dgAltriFile.SelectedRows(0)
                Using F As FileAllegato = Riga.DataBoundItem
                    Dim Path As String = F.FilePath
                    FormerLib.FormerHelper.File.OpenWithDialog(Path)
                End Using

            End Using

        End If
    End Sub

    Private Sub lnkOpenFileSorgWith_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFileSorgWith.LinkClicked

        If dgSorgenti.SelectedRows.Count Then

            Dim FileSel As String

            Dim fileSelezionato As FileSorgente = dgSorgenti.SelectedRows(0).DataBoundItem

            FileSel = fileSelezionato.FilePath

            Try

                FormerLib.FormerHelper.File.OpenWithDialog(FileSel)

            Catch ex As Exception

                MessageBox.Show(FileSel & " " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try

        End If
    End Sub

    Private Sub lnkOpenFolderAltriFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenFolderAltriFile.LinkClicked
        'apro il path delle immagini

        If txtFile.TextLength Then
            Try

                Dim PathMOd As String = FormerLib.FormerHelper.File.GetFolder(txtFile.Text)

                Dim x As New Process

                x.StartInfo.FileName = PathMOd
                x.Start()
            Catch ex As Exception

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub

    Private Sub lnkAggiungiAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAggiungiAltri.LinkClicked

        OpenFileSorg.Filter = "Tutti i file|*.*"
        OpenFileSorg.ShowDialog()
        Dim OldName As String = OpenFileSorg.FileName

        If OldName.Length Then

            'qui copio il file nella cartella di destinazione. se già c'è chiedo se lo vuole sovrascrivere 
            Dim NewName As String = FormerHelper.File.EstraiNomeFile(OldName)
            NewName = _OrdSel.IdOrd & "-" & NewName
            If _OrdSel.IdCom = 0 Then
                NewName = FormerPath.PathTemp & NewName
            Else
                NewName = FormerPath.PathCommesse & _OrdSel.IdCom & "\" & NewName
            End If

            Try
                IO.File.Copy(OldName, NewName)

                Using A As New FileAllegato
                    A.IdOrd = _OrdSel.IdOrd
                    A.FilePath = NewName
                    A.Save()
                End Using

                CaricaFileAllegati()
            Catch ex As Exception
                MessageBox.Show("Si è verificato un errore nel salvataggio del file. " & ex.Message)
            End Try

        End If

    End Sub

    Private Sub CaricaFileAllegati()

        Using mgr As New FileAllegatiDAO
            Dim l As List(Of FileAllegato) = mgr.FindAll(LFM.FileAllegato.FilePath,
                                                         New LUNA.LunaSearchParameter(LFM.FileAllegato.IdOrd, _OrdSel.IdOrd))

            dgAltriFile.AutoGenerateColumns = False
            dgAltriFile.DataSource = l

        End Using

    End Sub

    Private Sub lnkRimuoviAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRimuoviAltri.LinkClicked

        If dgAltriFile.SelectedRows.Count Then

            Using Riga As DataGridViewRow = dgAltriFile.SelectedRows(0)
                Using F As FileAllegato = Riga.DataBoundItem
                    Dim Path As String = F.FilePath

                    If MessageBox.Show("Confermi la cancellazione del file '" & Path & "'?", "Eliminazione file allegato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                        Using mgr As New FileAllegatiDAO
                            mgr.Delete(F.IdFileAllegato)
                        End Using

                        Try
                            MgrFormerIO.FileDelete(Path)
                        Catch ex As Exception
                            MessageBox.Show("Si è verificato un errore nella cancellazione fisica del file. Il file allegato è stato correttamente eliminato dal database. " & ex.Message)
                        End Try

                        CaricaFileAllegati()

                    End If

                End Using

            End Using
        Else
            Beep()
        End If

    End Sub

    Private Sub ApriFileSelezionato()

        If dgAltriFile.SelectedRows.Count Then

            Using Riga As DataGridViewRow = dgAltriFile.SelectedRows(0)
                Using F As FileAllegato = Riga.DataBoundItem
                    Dim Path As String = F.FilePath

                    FormerLib.FormerHelper.File.ShellExtended(Path)

                End Using

            End Using

        End If

    End Sub

    Private Sub lnkApriAltri_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkApriAltri.LinkClicked
        ApriFileSelezionato()
    End Sub

    Private Sub SpostaInSorgenti()
        If dgAltriFile.SelectedRows.Count Then
            Dim fileSelezionato As FileAllegato = dgAltriFile.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi lo spostamento del file allegato '" & fileSelezionato.FilePath & "' in Sorgenti?", "Spostamento File allegato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                'elimino il file 
                'ricalcolo i numero di pagina

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try

                        tb.TransactionBegin()

                        Using Af As New FileSorgente
                            Af.FilePath = fileSelezionato.FilePath
                            Af.NumPagina = GetNextNumPagina()
                            Af.StatoRefine = enStatoRefineSorgente.NonDefinito
                            Af.IdOrd = fileSelezionato.IdOrd
                            Af.Save()
                            _CollSorgenti.Add(Af)
                        End Using

                        Using mgr As New FileAllegatiDAO
                            mgr.Delete(fileSelezionato.IdFileAllegato)
                        End Using

                        RiempiSorgentiDaColl()
                        CaricaFileAllegati()

                        tb.TransactionCommit()

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Errore Spostamento file allegato ad sorgenti " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End Using
            End If

        End If
    End Sub

    Private Sub SpostaInAltriFile()
        If dgSorgenti.SelectedRows.Count Then
            Dim fileSelezionato As FileSorgente = dgSorgenti.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi lo spostamento del file sorgente '" & fileSelezionato.FilePath & "' in Altri file?", "Spostamento Sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                'elimino il file 
                'ricalcolo i numero di pagina

                Using tb As LUNA.LunaTransactionBox = LUNA.LunaContext.CreateTransactionBox
                    Try

                        tb.TransactionBegin()

                        Using Af As New FileAllegato
                            Af.FilePath = fileSelezionato.FilePath
                            Af.IdOrd = fileSelezionato.IdOrd
                            Af.Save()
                        End Using

                        Using mgr As New FileSorgentiDAO
                            mgr.Delete(fileSelezionato.IdSorgente)
                        End Using

                        _CollSorgenti.Remove(fileSelezionato.FilePath)
                        RiempiSorgentiDaColl()
                        CaricaFileAllegati()

                        tb.TransactionCommit()

                        If MessageBox.Show("Vuoi aggiornare i numeri di pagina di tutti i sorgenti successivi al file rimosso?", "Eliminazione file sorgente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            RicalcolaNumPaginaDa(fileSelezionato.NumPagina, False)
                        End If

                    Catch ex As Exception
                        tb.TransactionRollBack()
                        MessageBox.Show("Errore Spostamento sorgente ad altri file " & ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End Using
            End If

        End If
    End Sub

    Private Sub lnkSpostaInFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSpostaInFile.LinkClicked

        SpostaInAltriFile()

    End Sub

    'Public Shared Function ConvertPdfToImage(ByVal filePath As String) As List(Of ImageSource)
    '    Dim result As List(Of ImageSource) = New List(Of ImageSource)()
    '    Dim tf As ThumbnailFactory = New ThumbnailFactory()
    '    Using stream As Stream = File.Open(filePath, FileMode.Open)
    '        Dim formatProvider As PdfFormatProvider = New PdfFormatProvider(stream, FormatProviderSettings.ReadAllAtOnce)
    '        Dim document As RadFixedDocument = formatProvider.Import()
    '        For Each page As RadFixedPage In document.Pages
    '            Dim pageImg As ImageSource = tf.CreateThumbnail(page, page.Size)
    '            result.Add(pageImg)
    '        Next
    '    End Using

    '    Return result
    'End Function

    Private Sub lnkRigeneraAnteprima_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRigeneraAnteprima.LinkClicked

        If dgSorgenti.SelectedRows.Count Then
            Dim fileSelezionato As FileSorgente = dgSorgenti.SelectedRows(0).DataBoundItem
            If MessageBox.Show("Confermi la rigenerazione dell'anteprima di questo lavoro?", "Rigenera anteprima", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                If _CollSorgenti.Count Then

                    MgrUDP.AnteprimaLavoro(_OrdSel.IdOrd)

                    MessageBox.Show("Richiesta rigenerazione anteprima Lavoro al Demone")

                    ''PER L'ANTEPRIMA LA DEVO CREARE
                    'Dim NomeAnteprima As String = _OrdSel.FilePath

                    'Try

                    '    Dim F As FileSorgente = _CollSorgenti(0)

                    '    FormerHelper.PDF.GetPdfThumbnail(F.FilePath, NomeAnteprima)

                    'Catch ex As Exception
                    '    'qui c'è stato un errore nella creazione dell'anteprima
                    '    'metto un file temporaneo e poi vediamo
                    '    ManageError(ex)

                    'End Try

                Else
                    MessageBox.Show("Impossibile creare l'anteprima perchè non ci sono file sorgenti.")
                End If

            End If
        End If

    End Sub

    Private Sub dgAltriFile_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAltriFile.CellContentClick

    End Sub

    Private Sub dgAltriFile_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAltriFile.CellDoubleClick
        ApriFileSelezionato()

    End Sub

    Private Sub txtNFogli_TextChanged(sender As Object, e As EventArgs) Handles txtNFogli.TextChanged
        txtNumFacciate.Text = txtNFogli.Value * 2
    End Sub

    Private Sub ApriLogOrdineInternoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriLogOrdineInternoToolStripMenuItem.Click
        ApriLog()
    End Sub

    Private Sub ApriLogOrdineOnlineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriLogOrdineOnlineToolStripMenuItem.Click
        ApriLogOnline()
    End Sub

    Private Sub RiapriConsegnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiapriConsegnaToolStripMenuItem.Click
        ApriConsegna()
    End Sub

    Private Sub RiapriCommessaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiapriCommessaToolStripMenuItem.Click
        ApriCommessa()
    End Sub

    Private Sub ApriDocumentoFiscaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriDocumentoFiscaleToolStripMenuItem.Click
        ApriDocumentoFiscale()
    End Sub

    Private Sub ApriListinoBaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApriListinoBaseToolStripMenuItem.Click
        ApriListinoBase
    End Sub

    Private Sub ApriListinoBase()

        If _OrdSel.IdListinoBase Then
            ParentFormEx.Sottofondo()

            Using F As New frmListinoBase
                F.Carica(_OrdSel.ListinoBase)
            End Using

            ParentFormEx.Sottofondo()
        Else
            MessageBox.Show("Per questo ordine non è presente un ListinoBase")
        End If

    End Sub

    Private Sub dgSorgenti_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSorgenti.CellContentClick

    End Sub

    Private Sub dgSorgenti_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgSorgenti.RowsRemoved
        ConteggioSorgenti()
    End Sub

    Private Sub dgAltriFile_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgAltriFile.RowsAdded
        ConteggioAltriFile()
    End Sub

    Private Sub dgAltriFile_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgAltriFile.RowsRemoved
        ConteggioAltriFile()
    End Sub

    Private Sub txtNomeLavoro_TextChanged(sender As Object, e As EventArgs) Handles txtNomeLavoro.TextChanged

    End Sub

    Private Sub ScaricaSorgentiOriginali()

        If MessageBox.Show("Confermi lo scaricamento dei file originali?", "Scaricamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            If _OrdSel.IdOrdOnline Then

                Using O As New FormerDALWeb.OrdineWeb
                    O.Read(_OrdSel.IdOrdOnline)

                    If O.InseritoDa = 0 Then

                        Dim PathFolder As String = String.Empty
                        If dlgFolder.ShowDialog() = DialogResult.OK Then
                            PathFolder = dlgFolder.SelectedPath
                        End If

                        If PathFolder <> String.Empty Then

                            If PathFolder.EndsWith("\") = False Then PathFolder &= "\"

                            Dim PathOnlineFronte As String = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteFronte
                            Dim PathOfflineFronte As String = PathFolder & O.SorgenteFronte

                            Dim PathOnlineRetro As String = String.Empty
                            Dim PathOfflineRetro As String = PathFolder & O.SorgenteRetro

                            If O.SorgenteRetro.Length Then
                                PathOnlineRetro = "/tipografiaformer.it/ordini/" & O.IdOrdine & "/" & O.SorgenteRetro
                            End If

                            Dim Ftp As New FTPclient(FConfiguration.Ftp.ServerNameProduzione,
                                                     FConfiguration.Ftp.ServerLoginProduzione,
                                                     FConfiguration.Ftp.ServerPwdProduzione)

                            MgrFormerIO.FtpTransfer(Ftp, PathOnlineFronte, PathOfflineFronte, enTipoOpFTP.Download, Me.ParentFormEx)

                            'Ftp.Download(PathOnlineFronte, PathOfflineFronte, True)

                            If PathOnlineRetro.Length Then
                                MgrFormerIO.FtpTransfer(Ftp, PathOnlineRetro, PathOfflineRetro, enTipoOpFTP.Download, Me.ParentFormEx)
                                'Ftp.Download(PathOnlineRetro, PathOfflineRetro, True)
                            End If

                            Ftp = Nothing

                            'alla fine apro la cartella
                            FormerHelper.File.ShellExtended(PathFolder)

                        End If

                    Else
                        MessageBox.Show("Questo ordine è stato inserito da noi e i file sorgenti non sono disponibili online")
                    End If

                End Using
            Else
                MessageBox.Show("Questo ordine non ha un ordine online da cui scaricare i sorgenti")
            End If

        End If
    End Sub

    Private Sub lnkScaricaOriginali_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkScaricaOriginali.LinkClicked

        ScaricaSorgentiOriginali()

    End Sub

    Private Sub lnkDelLavoraz_Click(sender As Object, e As EventArgs) Handles lnkDelLavoraz.Click

    End Sub
End Class
