Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerPrinter
Imports FormerBusinessLogic
Imports FormerWebLabeling

Friend Class frmConsegnaProgrammata
    'Inherits baseFormInternaRedim

    Private _Ris As Integer
    Private _IdCons As Integer = 0
    Private _InCaricamento As Boolean = False
    Private _IdCorr As Integer = 0
    Private _Giorno As Date

    Private _IdDoc As Integer = 0
    Private _IdPrev As Integer = 0

    Private _Consegna As ConsegnaProgrammata = Nothing

    Dim ClickSuDgIncl As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'lblOrdUsc.BackColor = FormerColori.ColoreStatoOrdineUscitoDaMagazzino
    End Sub

    Private Sub CaricaDocumenti()

        For Each O As Ordine In _Consegna.ListaOrdini

            If O.IdDoc Then

                Using R As New Ricavo
                    R.Read(O.IdDoc)

                    If R.Tipo = enTipoDocumento.Preventivo Then
                        _IdPrev = O.IdDoc
                    Else
                        _IdDoc = O.IdDoc
                    End If
                End Using

            End If

        Next

        If _IdDoc Then
            cmbTipoDoc.Enabled = False
            lnkOpenDoc.Enabled = True
            lnkRegPagDoc.Enabled = True
        Else
            ' cmbTipoDoc.Enabled = True
            lnkOpenDoc.Enabled = False
            lnkRegPagDoc.Enabled = False
        End If

        If _IdPrev Then
            cmbTipoDoc.Enabled = False
            lnkOpenPrev.Enabled = True
            lnkRegPagPrev.Enabled = True
        Else
            ' cmbTipoDoc.Enabled = True
            lnkOpenPrev.Enabled = False
            lnkRegPagPrev.Enabled = False
        End If

        If _IdCorr = enCorriere.Bartolini Or _IdCorr = enCorriere.PortoAssegnatoBartolini Or _IdCorr = enCorriere.GLS Or _IdCorr = enCorriere.GLSIsole Or _IdCorr = enCorriere.PortoAssegnatoGLS Then
            If _Consegna.IdStatoConsegna <> enStatoConsegna.InLavorazione And _Consegna.IdStatoConsegna <> enStatoConsegna.RegistrataCorriere Then
                pctCodTrack.Visible = False
            End If
        Else
            pctCodTrack.Visible = False
        End If

        If _Consegna.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
            chkForzaUscitaSenzaDocumenti.Enabled = True
        Else
            If _Consegna.StampaDocumenti = enStampaDocumenti.ForzaUscita Then
                chkForzaUscitaSenzaDocumenti.Enabled = True
            Else
                chkForzaUscitaSenzaDocumenti.Enabled = False
                chkForzaUscitaSenzaDocumenti.Checked = False
            End If
        End If

    End Sub

    Private Sub CaricaDatiConsegna(IdCons As Integer)

        CaricaTipoDoc()
        If Not _Consegna Is Nothing Then

            _Consegna = Nothing

        End If

        _Consegna = New ConsegnaProgrammata

        lblTipo.Text = "Consegna ID " & IdCons

        _Consegna.Read(IdCons)

        _IdCons = IdCons

        CaricaCombo()

        CaricaConsegneCliente()

        CaricaOrdini()

        CaricaOrdiniInclusiConsegna()

        CaricaOrdiniUscitiMagazzino()

        _InCaricamento = True

        txtNote.Text = _Consegna.Annotazioni
        lblRub.Text = _Consegna.Cliente.RagSocNome

        'If _Consegna.Blocco = enSiNo.Si Then '****COMMENTATO PER ESCLUSIONE BLOCCO DIRETTO
        '    pctSblocca.Visible = True
        '    pctBlocca.Visible = False
        'Else
        '    pctSblocca.Visible = False
        '    pctBlocca.Visible = True
        'End If

        lblQuando.Text = _Consegna.Giorno.ToString("dddd dd/MM/yyyy")

        _Giorno = _Consegna.Giorno
        If _Consegna.MatPom = enMomentoConsegna.Mattina Then
            rdoMattino.Checked = True
        Else
            rdoPomeriggio.Checked = True
        End If
        txtCodTrack.Text = _Consegna.CodTrack

        If _Consegna.HaUnPagamentoAnticipato Then
            lnkPagamAnticip.Visible = True
            If _Consegna.PagamentoAnticipato.IdTipoPagamento = enMetodoPagamento.PayPal Then
                lnkPagamAnticip.Image = My.Resources._paypal
            ElseIf _Consegna.PagamentoAnticipato.IdTipoPagamento = enMetodoPagamento.BonificoBancarioAnticipato Then
                lnkPagamAnticip.Image = My.Resources.billing
            ElseIf _Consegna.PagamentoAnticipato.IdTipoPagamento = enMetodoPagamento.CartaDiCredito Then
                'lnkPagamAnticip.Image = My.Resources._CartaDiCredito
            End If
            lnkRegPagDoc.Enabled = False
            lnkRegPagPrev.Enabled = False

            lnkPrevSi.Enabled = False
            lnkPrevNo.Enabled = False
            cmbTipoDoc.Enabled = False
            cmbPagam.Enabled = False

        End If
        MgrControl.SelectIndexCombo(cmbPagam, _Consegna.IdPagam)
        'Dim Corr As New cCorriere
        'Corr.Read(c.IdCorr)
        'lblCorriere.Text = Corr.Descrizione
        'Corr = Nothing

        lblCorriere.Text = _Consegna.Corriere.Descrizione

        If _Consegna.IdIndirizzo Then
            Dim I As New Indirizzo
            I.Read(_Consegna.IdIndirizzo)
            lblIndirizzo.Text = I.Riassunto
        Else
            lblIndirizzo.Text = _Consegna.Cliente.IndirizzoRegistrazione
        End If

        MgrControl.SelectIndexCombo(cmbOperatore, _Consegna.IdOperatore)


        'If _Consegna.TipoDoc <> enTipoDocumento.Preventivo Then
        '    MgrControl.SelectIndexComboEnum(cmbTipoDoc, _Consegna.TipoDoc)
        'Else

        'End If

        If _ListaOrdiniFisc.Count = 0 Then
            CaricaTipoDoc()
            MgrControl.SelectIndexComboEnum(cmbTipoDoc, enTipoDocumento.Preventivo)
            cmbTipoDoc.Enabled = False
        Else
            CaricaTipoDoc(False)
            cmbTipoDoc.Enabled = True
            MgrControl.SelectIndexComboEnum(cmbTipoDoc, _Consegna.TipoDoc)
        End If

        txtNumPacchi.Text = _Consegna.NumColli

        'calcolo i colli ipotetici
        Dim Buffer As String = String.Empty
        Dim TotaleColli As Integer = 0
        Buffer = "***COLLI IPOTETICI***" & ControlChars.NewLine
        For Each o As Ordine In _Consegna.ListaOrdini
            Dim ColliO As Integer = MgrPreventivazioneB.CalcolaColli(o.QtaOrdine, o.ListinoBase)
            Buffer &= "Lav. " & o.IdOrd & " Colli: " & ColliO & ControlChars.NewLine
            TotaleColli += ColliO
        Next
        Buffer &= "TOTALE COLLI: " & TotaleColli

        toolTipHelp.SetToolTip(txtNumPacchi, Buffer)

        txtPeso.Text = _Consegna.Peso

        _IdCorr = _Consegna.IdCorr

        Dim RegistrataCorr As String = String.Empty
        If _Consegna.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
            If _Consegna.DataTrasmissioneCorriere <> Date.MinValue Then
                RegistrataCorr = " (Web Service)"
            Else
                RegistrataCorr = " (Manuale)"
            End If
        End If

        lblStato.Text = "Stato Consegna: " & FormerEnumHelper.StatoConsegnaString(_Consegna.IdStatoConsegna) & RegistrataCorr
        lblStato.BackColor = FormerColori.GetColoreStatoConsegna(_Consegna.IdStatoConsegna)

        Dim SituazEconomica As String = String.Empty

        Using Mgr As New PagamentiDAO
            Dim LastP As Pagamento = Mgr.GetLastByIdRub(_Consegna.IdRub)

            If Not LastP Is Nothing Then

            Else
                SituazEconomica &= "UP: -"
            End If
        End Using

        Dim LrisTSC As List(Of RisSituazioneCliente) = MgrSituazioneCliente.GetSituazioneClienti(_Consegna.IdRub)
        If LrisTSC.Count Then
            Dim risTSC As RisSituazioneCliente = LrisTSC(0)

            If Not risTSC.UltimoPagamento Is Nothing Then
                SituazEconomica &= "UP: " & risTSC.UltimoPagamento.ImportoStr & " del " & risTSC.UltimoPagamento.DataPag.ToString("dd/MM/yyyy")
            Else
                SituazEconomica &= "UP: "
            End If

            SituazEconomica &= " - TSC: " & FormerLib.FormerHelper.Stringhe.FormattaPrezzo(risTSC.TotaleScopertoComplessivo)
        Else
            SituazEconomica &= "UP: - TSC: -"
        End If

        lblSituazioneEconomica.Text = SituazEconomica

        Select Case True
            Case _Consegna.StampaDocumenti = enStampaDocumenti.No
                chkStampaDocumenti.Checked = False
                chkForzaUscitaSenzaDocumenti.Checked = False
            Case _Consegna.StampaDocumenti = enStampaDocumenti.Si
                chkStampaDocumenti.Checked = True
                chkForzaUscitaSenzaDocumenti.Checked = False
                chkForzaUscitaSenzaDocumenti.Enabled = False
            Case _Consegna.StampaDocumenti = enStampaDocumenti.ForzaUscita
                chkStampaDocumenti.Checked = False
                chkForzaUscitaSenzaDocumenti.Checked = True
        End Select

        If _Consegna.AssRilIntMitt = enSiNo.Si Then
            chkAssRilIntMitt.Checked = True
        End If

        If _Consegna.NoCartaceo = enSiNo.Si Then
            chkNoCartaceo.Checked = True
            'If _Consegna.Blocco = enSiNo.Si Then'****COMMENTATO PER ESCLUSIONE BLOCCO DIRETTO
            '    chkNoCartaceo.Enabled = False
            'End If
        End If

        chkNoAutoGLS.Checked = IIf(_Consegna.NoRegistrazioneGLS = enSiNo.Si, True, False)

        CaricaDocumenti()

        lnkEmettiDocFisc.Enabled = False
        lnkEmettiDocFiscPrev.Enabled = False
        lnkRePrintDoc.Enabled = False

        Dim ListaOrdSenzaDoc As List(Of Ordine) = _Consegna.ListaOrdini.FindAll(Function(x) x.IdDoc = 0)

        If ListaOrdSenzaDoc.Count Then
            'qui alcuni ordini nella consegna non hanno il documento fiscale
            If ListaOrdSenzaDoc.FindAll(Function(x) x.Stato < enStatoOrdine.UscitoMagazzino).Count = 0 Then
                lnkEmettiDocFisc.Enabled = True
            Else 'If ListaOrdSenzaDoc.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count > 0 Then
                lnkEmettiDocFiscPrev.Enabled = True
            End If
        Else
            'qui tutti gli ordini hanno un documento fiscale
            lnkRePrintDoc.Enabled = True
        End If

        ''qui devo abilitare il tasto corretto di stampa documenti fiscali 
        'If _Consegna.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.UscitoMagazzino).Count = 0 Then
        '    'qui sono tutti usciti da magazzino 
        '    'qui sono tutti usciti da magazzino quindi abilito la stampa documenti perche non ci possono essere ordini usciti da magazzino senza documento 
        '    lnkEmettiDocFisc.Enabled = True
        '    lnkEmettiDocFiscPrev.Enabled = False
        '    lnkRePrintDoc.Enabled = False
        'ElseIf _Consegna.ListaOrdini.FindAll(Function(x) x.Stato > enStatoOrdine.UscitoMagazzino).Count And _Consegna.HaDocumentiFiscali = False Then
        '    lnkEmettiDocFisc.Enabled = True
        '    lnkEmettiDocFiscPrev.Enabled = False
        '    lnkRePrintDoc.Enabled = False
        'ElseIf _Consegna.ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.InConsegna).Count = 0 Or
        '        _Consegna.ListaOrdini.FindAll(Function(x) x.IdDoc = 0).Count = 0 Then
        '    'qui abilito la ristampa dei documenti 
        '    lnkEmettiDocFisc.Enabled = False
        '    lnkEmettiDocFiscPrev.Enabled = False
        '    lnkRePrintDoc.Enabled = True
        'ElseIf _Consegna.ListaOrdini.FindAll(Function(x) x.Stato < enStatoOrdine.UscitoMagazzino).Count > 0 _
        '    And _Consegna.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count > 0 _
        '    And _Consegna.ListaOrdini.FindAll(Function(x) x.IdDoc <> 0).Count = 0 Then
        '    lnkEmettiDocFisc.Enabled = False
        '    lnkEmettiDocFiscPrev.Enabled = True
        '    lnkRePrintDoc.Enabled = False
        'Else
        '    lnkEmettiDocFisc.Enabled = False
        '    lnkEmettiDocFiscPrev.Enabled = False
        '    lnkRePrintDoc.Enabled = False
        'End If
        CalcolaTotali()

        If _Consegna.IdAziendaForzata Then
            MgrControl.SelectIndexComboEnum(cmbAzienda, _Consegna.IdAziendaForzata)
        Else
            MgrControl.SelectIndexComboEnum(cmbAzienda, MgrAziende.IdAziende.AziendaSrl)
        End If

        If _Consegna.HaDocumentiFiscali = True OrElse _Consegna.HaUnPagamentoAnticipato = True Then
            cmbAzienda.Enabled = False
        End If

    End Sub

    Friend Function Carica(ByVal IdCons As Integer,
                           Optional ByVal IdRub As Integer = 0) As Integer

        CaricaDatiConsegna(IdCons)
        Me.Text &= " - " & IdCons
        ShowDialog()

        Return _Ris

    End Function

    Private Sub CaricaTipoDoc(Optional WithPrev As Boolean = True)

        Dim L As New List(Of cEnum)
        Dim x As New cEnum

        'x.Id = 0
        'x.Descrizione = "Nessuno"

        'L.Add(x)
        If WithPrev Then
            x = New cEnum
            x.Id = enTipoDocumento.Preventivo
            x.Descrizione = "Preventivo"

            L.Add(x)
        End If

        x = New cEnum
        x.Id = enTipoDocumento.Fattura
        x.Descrizione = "Fattura"

        L.Add(x)

        x = New cEnum
        x.Id = enTipoDocumento.DDT
        x.Descrizione = "DDT"

        L.Add(x)

        cmbTipoDoc.DataSource = L

    End Sub

    Private Sub CaricaCombo()

        Using PM As New TipoPagamentiDAO
            cmbPagam.DataSource = PM.GetAll(LFM.TipoPagamento.IdTipoPagam, False)
            cmbPagam.ValueMember = "IdTipoPagam"
            cmbPagam.DisplayMember = "TipoPagam"
        End Using
        ''cmbPagam.SelectedIndex = 0
        'Dim Corriere As New CorrieriDAO

        'cmbCorriere.ValueMember = "IdCorriere"
        'cmbCorriere.DisplayMember = "Descrizione"
        'cmbCorriere.DataSource = Corriere.GetAll("Descrizione", True)

        Using Mgr As New UtentiDAO()

            Dim lst As List(Of Utente) = Mgr.GetAll(LFM.Utente.Login, True)

            cmbOperatore.DataSource = lst
            cmbOperatore.DisplayMember = "Login"
            cmbOperatore.ValueMember = "IdUt"

        End Using

        Dim laz As New List(Of cEnum)
        Dim az1 As New cEnum(MgrAziende.IdAziende.AziendaSnc, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSnc))
        laz.Add(az1)
        Dim az2 As New cEnum(MgrAziende.IdAziende.AziendaSrl, MgrAziende.GetAziendaStr(MgrAziende.IdAziende.AziendaSrl))
        laz.Add(az2)

        cmbAzienda.ValueMember = "Id"
        cmbAzienda.DisplayMember = "Descrizione"
        cmbAzienda.DataSource = laz

    End Sub

    Private Sub CaricaConsegneCliente()

        'qui non lavoro su una consegna ma su una rubrica 

        tvConsegne.Nodes.Clear()

        Using mgrC As New ConsegneProgrammateDAO

            Dim l As List(Of ConsegnaProgrammata) = mgrC.FindAll(New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdRub, _Consegna.IdRub),
                                                                 New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdStatoConsegna, enStatoConsegna.InLavorazione),
                                                                 New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Eliminato, enSiNo.No),
                                                                 New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.IdCons, _Consegna.IdCons, "<>"),
                                                                 New LUNA.LunaSearchParameter(LFM.ConsegnaProgrammata.Giorno, Date.Now, ">="))

            l.Sort(Function(x, y) y.Giorno.CompareTo(x.Giorno))
            Dim NewL As New List(Of ConsegnaProgrammata)

            For Each SingC As ConsegnaProgrammata In l
                If SingC.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.PagatoInteramente).Count <> SingC.ListaOrdini.Count Then
                    NewL.Add(SingC)
                End If
            Next

            For Each c As ConsegnaProgrammata In NewL

                Using Mgr As New ConsProgrOrdiniDAO

                    Dim lcp As List(Of ConsProgrOrdini) = Mgr.FindAll(New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdCons, c.IdCons))

                    Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")

                    Dim NodoData As TreeNode = tvConsegne.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = tvConsegne.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                    End If
                    If c.IdCons = _Consegna.IdCons Then NodoData.Expand()

                    Dim ChiaveCorriere As String = "C" & c.IdCorr

                    Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                    If NodoCorr Is Nothing Then
                        NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.Corriere.Descrizione, 6, 6)
                        'NodoCorr.Expand()
                    End If

                    Dim ChiaveRubrica As String = "S" & c.IdCons

                    Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)

                    If NodoRub Is Nothing Then
                        NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.Cliente.RagSocNome, 10, 10)
                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If

                    For Each o As ConsProgrOrdini In lcp
                        Dim ChiaveOrdine As String = "O" & o.IdOrd
                        Dim Icona As Integer = 9

                        Dim singO As New Ordine
                        singO.Read(o.IdOrd)

                        If o.Inserito Then Icona = 8

                        Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & o.IdOrd, "Ord." & o.IdOrd & " - " & singO.Prodotto.Descrizione, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(singO.Stato)

                        singO = Nothing
                        NodoCorr.Expand()
                        NodoRub.Expand()
                    Next

                End Using

            Next

        End Using

    End Sub

    Private _ListaOrdiniPrev As New List(Of Ordine)
    Private _ListaOrdiniFisc As New List(Of Ordine)

    Private Sub AggiungiOrdineAListe(O As Ordine)
        If O.IdOrd Then
            If O.Preventivo = enSiNo.Si Then
                _ListaOrdiniPrev.Add(O)
            Else
                _ListaOrdiniFisc.Add(O)
            End If
        End If
    End Sub

    Private Sub CaricaOrdiniInclusiConsegna()

        Dim lst As New List(Of Ordine)
        Using mgr As New OrdiniDAO
            lst = mgr.FindAll("DataIns Desc",
                              New LUNA.LunaSearchParameter(LFM.Ordine.IdConsRiferimento, _Consegna.IdCons))
        End Using

        DGOrdiniInclusi.AutoGenerateColumns = False
        DGOrdiniInclusi.DataSource = lst

        For Each o As Ordine In lst
            AggiungiOrdineAListe(o)
        Next

        'tpOrdIncCons.Text = "Ordini Inclusi nella Consegna (" & lst.Count & ")"

    End Sub

    Private Sub CaricaOrdiniUscitiMagazzino()

        Dim lst As New List(Of Ordine)
        Using mgr As New OrdiniDAO
            Dim listaIdOrdini As String = _Consegna.ListaIdOrdini
            'lst = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("IdRub", _Consegna.IdRub),
            '                            New LUNA.LunaSearchParameter("Stato", enStatoOrdine.UscitoMagazzino),
            '                            New LUNA.LunaSearchParameter("IdConsRiferimento", 0),
            '                            New LUNA.LunaSearchParameter("IdDoc", 0),
            '                            New LUNA.LunaSearchParameter("IdOrd", "(" & listaIdOrdini & ")", " NOT IN "))

            lst = mgr.FindAll(LFM.Ordine.IdOrd,
                              New LUNA.LunaSearchParameter(LFM.Ordine.IdRub, _Consegna.IdRub),
                              New LUNA.LunaSearchParameter(LFM.Ordine.Stato, enStatoOrdine.UscitoMagazzino),
                              New LUNA.LunaSearchParameter(LFM.Ordine.IdConsRiferimento, _Consegna.IdCons, "<>"),
                              New LUNA.LunaSearchParameter(LFM.Ordine.IdDoc, 0),
                              New LUNA.LunaSearchParameter(LFM.Ordine.IdOrd, "(" & listaIdOrdini & ")", " NOT IN "))

        End Using

        DgOrdUscMag.AutoGenerateColumns = False
        DgOrdUscMag.DataSource = lst

        If lst.Count = 0 Then tpConsegne.TabPages.Remove(tpOrdUscMag)

    End Sub

    Private Sub CaricaOrdini()

        _ListaOrdiniFisc.Clear()
        _ListaOrdiniPrev.Clear()

        Dim lst As New List(Of Ordine)
        Using mgr As New ConsProgrOrdiniDAO
            Dim L As List(Of ConsProgrOrdini) = mgr.FindAll(LFM.ConsProgrOrdini.IdOrd,
                                                            New LUNA.LunaSearchParameter(LFM.ConsProgrOrdini.IdCons, _IdCons))

            For Each singO As ConsProgrOrdini In L
                Dim O As New Ordine
                O.Read(singO.IdOrd)
                If O.IdOrd Then
                    If O.Preventivo = enSiNo.Si Then
                        _ListaOrdiniPrev.Add(O)
                    Else
                        _ListaOrdiniFisc.Add(O)
                    End If
                    lst.Add(O)
                End If
            Next

        End Using

        If _ListaOrdiniFisc.Count = 0 Or _Consegna.TipoDoc = enTipoDocumento.Preventivo Then
            CaricaTipoDoc()
            MgrControl.SelectIndexComboEnum(cmbTipoDoc, enTipoDocumento.Preventivo)
            cmbTipoDoc.Enabled = False
        Else
            CaricaTipoDoc(False)
            cmbTipoDoc.Enabled = True
        End If

        DgOrdini.AutoGenerateColumns = False
        DgOrdini.DataSource = lst

    End Sub

    Private Sub CalcolaTotali()

        Dim TotFisc As Decimal = 0
        Dim TotPrev As Decimal = 0
        Dim TotSpedFisc As Decimal = 0
        Dim TotSpedPrev As Decimal = 0
        Dim TotSped As Decimal = 0

        'qui devo calcolare il costo delle spedizioni
        'se c'e' un preventivo allora vanno a preventivo altrimenti vanno a fattura

        'For Each O As Ordine In _Consegna.ListaOrdiniAssociati
        '    If O.Preventivo = enSiNo.Si Then
        '        TotPrev += O.TotaleImponibile
        '    Else
        '        TotFisc += O.TotaleImponibile
        '    End If
        'Next

        If _Consegna.HaDocumentiFiscali Then
            If _Consegna.ListaDocumenti.Count = 1 Then
                TotSped = _Consegna.ListaDocumenti(0).CostoCorr
            Else
                TotSped = _Consegna.ListaDocumenti.Find(Function(x) x.Tipo = enTipoDocumento.Preventivo).CostoCorr
            End If
        Else
            If MgrFormerException.CalcolareSpeseDiSpedizioneInFatturazione(_Consegna) Then
                TotSped = _Consegna.CalcolaImportoSpedizioni(True)
            Else
                TotSped = _Consegna.ImportoNetto
            End If
        End If

        If _ListaOrdiniPrev.Count Then
            TotSpedPrev = TotSped
        Else
            TotSpedFisc = TotSped
        End If

        For Each O As Ordine In _ListaOrdiniFisc
            TotFisc += O.TotaleImponibile
        Next

        lblCostoSped.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotSpedFisc, 2)

        lblTotImp.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotFisc, 2)
        Dim TotIva As Decimal = FormerHelper.Finanziarie.CalcolaIva(TotFisc + TotSpedFisc)
        lblTotIva.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotIva, 2)
        lblTotDocum.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((TotIva + TotSpedFisc + TotFisc), 2)

        For Each O As Ordine In _ListaOrdiniPrev
            TotPrev += O.TotaleImponibile
        Next

        lblCostoSpedPrev.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotSpedPrev, 2)
        lblTotImpPrev.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto(TotPrev, 2)
        lblTotDocumentoPrev.Text = FormerLib.FormerHelper.Finanziarie.ArrotondaImporto((TotSpedPrev + TotPrev), 2)

    End Sub

    Private Sub frmConsegne_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        _InCaricamento = False
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

    Private Sub CaricaDefault()

        'Dim C As New Corriere
        'C.Read(_Consegna.Cliente.IdCorriere)
        Dim met As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(_Consegna.Cliente.IdCorriere)
        lblDefaultCorr.Text = "Default: " & met.Descrizione
    End Sub

    Private Sub SalvaConsegna()
        Using x As New ConsegnaProgrammata
            x.Read(_IdCons)

            x.Annotazioni = txtNote.Text
            x.MatPom = IIf(rdoMattino.Checked, enMomentoConsegna.Mattina, enMomentoConsegna.Pomeriggio)
            x.CodTrack = txtCodTrack.Text
            x.IdOperatore = IIf(cmbOperatore.SelectedValue Is Nothing, 0, cmbOperatore.SelectedValue)
            x.IdPagam = IIf(cmbPagam.SelectedValue Is Nothing, 0, cmbPagam.SelectedValue)
            x.TipoDoc = IIf(cmbTipoDoc.SelectedValue Is Nothing, 0, DirectCast(cmbTipoDoc.SelectedItem, cEnum).Id)
            x.NumColli = txtNumPacchi.Text
            x.Peso = txtPeso.Text

            Dim OldStampaDocumenti As Integer = x.StampaDocumenti

            Select Case True
                Case chkForzaUscitaSenzaDocumenti.Checked
                    x.StampaDocumenti = enStampaDocumenti.ForzaUscita
                Case chkStampaDocumenti.Checked
                    x.StampaDocumenti = enStampaDocumenti.Si
                Case Else
                    x.StampaDocumenti = enStampaDocumenti.No
            End Select

            If x.StampaDocumenti <> OldStampaDocumenti Then
                Dim MsgLog As String = "E' stato cambiato il campo Stampa Automaticamente Documenti fiscali impostato a "

                Select Case x.StampaDocumenti
                    Case enStampaDocumenti.Si
                        MsgLog &= "SI"
                    Case enStampaDocumenti.No
                        MsgLog &= "NO"
                    Case enStampaDocumenti.ForzaUscita
                        MsgLog &= "FORZA USCITA"
                End Select

                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Consegna, x.IdCons, MsgLog, PostazioneCorrente.UtenteConnesso.IdUt)
            End If

            'x.StampaDocumenti = IIf(chkStampaDocumenti.Checked, enSiNo.Si, enSiNo.No)
            x.NoCartaceo = IIf(chkNoCartaceo.Checked, enSiNo.Si, enSiNo.No)
            x.NoRegistrazioneGLS = IIf(chkNoAutoGLS.Checked, enSiNo.Si, enSiNo.No)
            x.AssRilIntMitt = IIf(chkAssRilIntMitt.Checked, enSiNo.Si, enSiNo.No)

            'If x.AssRilIntMitt = enSiNo.Si Then'****COMMENTATO PER ESCLUSIONE BLOCCO DIRETTO
            '    x.Blocco = enSiNo.Si
            'End If

            Dim ValoreComboAzienda As Integer = DirectCast(cmbAzienda.SelectedItem, cEnum).Id
            If _Consegna.IdAziendaForzata Then
                x.IdAziendaForzata = ValoreComboAzienda
            Else
                If _Consegna.HaUnPagamentoAnticipato Then
                    ValoreComboAzienda = MgrAziende.IdAziende.AziendaSrl
                    'If ValoreComboAzienda = FormerConst.Aziende.AziendaSrl Then
                    x.IdAziendaForzata = ValoreComboAzienda
                    'End If
                Else
                    'If ValoreComboAzienda = FormerConst.Aziende.AziendaSnc Then
                    x.IdAziendaForzata = ValoreComboAzienda
                    'End If
                End If
            End If

            x.Save()

            _Consegna = x

            _Ris = x.IdCons
        End Using
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        'qui salvo solo i dati di contorno della consegna non i dati principali
        Dim CheckOk As Boolean = True
        If chkNoCartaceo.Checked Then
            If cmbPagam.SelectedValue = enMetodoPagamento.ContrassegnoAlRitiro Then
                MessageBox.Show("Non è possibile scegliere di non allegare il documento cartaceo per le consegne con pagamento in contrassegno")
                CheckOk = False
            End If
        End If

        If _Consegna.HaUnPagamentoAnticipato Then

            If cmbAzienda.SelectedValue = MgrAziende.IdAziende.AziendaSnc Then

                If MessageBox.Show("I documenti fiscali sono in carico alla Former Snc in presenza di un pagamento anticipato. Confermi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    CheckOk = False
                End If

            End If
        End If

        If CheckOk Then
            If MessageBox.Show("Confermi il salvataggio dei dati della consegna?", PostazioneCorrente.Titolo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                SalvaConsegna()

                'qui dopo che ho salvato la consegna devo vedere se accorparla con un altra 
                If _Consegna.Diritti.PossoModificareOrdiniContenutiOAccorparla.Esito Then '_Consegna.ModificabileEx(False, False, False, True, False, True).Modificabile Then 'If _Consegna.Modificabile(True) Then
                    Using Mgr As New ConsegneProgrammateDAO
                        If _Consegna.ListaOrdini.Count Then
                            Dim O As Ordine = _Consegna.ListaOrdini(0)
                            Dim ConsegnaPossibile As ConsegnaProgrammata = Mgr.GetPrimaConsegnaCompatibileOrdine(O,
                                                                                                                 _Consegna.IdCorr,
                                                                                                                 _Consegna.Giorno,
                                                                                                                 _Consegna.IdRub,
                                                                                                                 _Consegna.MatPom,
                                                                                                                 _Consegna.IdIndirizzo,
                                                                                                                 ,
                                                                                                                 ,
                                                                                                                 _Consegna.IdCons,
                                                                                                                 _Consegna.IdPagam,
                                                                                                                 _Consegna.IdAziendaForzata)
                            If Not ConsegnaPossibile Is Nothing Then

                                'qui vediamo che succede
                                For Each OInC As Ordine In _Consegna.ListaOrdini
                                    'Mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, _Consegna.IdCorr, _Consegna.Giorno, O.IdRub, enMomentoConsegna.Pomeriggio, _Consegna.IdIndirizzo, ConsegnaPossibile)
                                    Mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, _Consegna.IdCorr, _Consegna.Giorno, _Consegna.IdRub, _Consegna.MatPom, _Consegna.IdIndirizzo, ConsegnaPossibile)
                                Next

                            End If
                        End If
                    End Using
                End If

                '    Dim NuovaConsegna As ConsegnaProgrammata = Nothing

                '    Using mgr As New ConsegneProgrammateDAO
                '        For Each O As Ordine In _Consegna.ListaOrdini
                '            NuovaConsegna = mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, _Consegna.IdCorr, _Consegna.Giorno, O.IdRub, enMomentoConsegna.Pomeriggio, _Consegna.IdIndirizzo, NuovaConsegna)
                '            mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, _Consegna.IdCorr, _Consegna.Giorno, O.IdRub, _Consegna.MatPom, _Consegna.IdIndirizzo)
                '        Next
                '    End Using

                'End If

                Dispose()
            End If
        End If

    End Sub

    Private Sub pctCodTrack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctCodTrack.Click

        Dim ris As String = "0"

        Sottofondo()

        If _IdCorr = enCorriere.Bartolini Or _IdCorr = enCorriere.PortoAssegnatoBartolini Then
            Using x As New frmCodTrackBrt
                ris = x.Carica(_IdCons)
            End Using
        ElseIf _IdCorr = enCorriere.GLS Or _IdCorr = enCorriere.PortoAssegnatoGLS Or _IdCorr = enCorriere.GLSIsole Then
            If Not _Consegna.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                Using x As New frmCodTrackGls
                    ris = x.Carica(_IdCons)
                End Using
            Else
                MessageBox.Show("Per poter editare manualmente il codice di tracking, devi prima eliminare la registrazione di gls!")
            End If
        End If

        Sottofondo()

        If ris <> "0" Then
            txtCodTrack.Text = ris
            If ris.Length > 0 Then
                lblStato.Text = "Stato Consegna: " & FormerEnumHelper.StatoConsegnaString(enStatoConsegna.RegistrataCorriere) & " (Manuale)"
                lblStato.BackColor = FormerColori.GetColoreStatoConsegna(enStatoConsegna.RegistrataCorriere)
            Else
                lblStato.Text = "Stato Consegna: " & FormerEnumHelper.StatoConsegnaString(enStatoConsegna.InLavorazione)
                lblStato.BackColor = FormerColori.GetColoreStatoConsegna(enStatoConsegna.InLavorazione)
            End If
        End If
    End Sub

    Private Sub pctCodTrack_Click_Old()
        If txtCodTrack.Text.Length <> 0 And _IdCorr = 3 Then
            'qui costruisco la stringa di connessione basandomi sull'id cliente e sul codice di tgrack 
            Dim IndirizzoInternet As String = "http://as777.bartolini.it/vas/sped_ricdocmit_load.hsm?docmit=" & txtCodTrack.Text & "&ksu=" & PostazioneCorrente.CodCliBart & "&referer=http://www.bartolini.it/home.asp"
            Sottofondo()

            Using x As New frmBrowser
                x.Carica(IndirizzoInternet)
            End Using

            Sottofondo()
        Else
            MessageBox.Show("Il tracking delle spedizioni è disponibile solo quando è stato inserito il codice di rintracciamento e solo per il corriere BARTOLINI!", PostazioneCorrente.Titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub txtNumPacchi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumPacchi.KeyPress
        MgrControl.ControlloNumerico(sender, e, True)
    End Sub

    Private Sub txtPeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        MgrControl.ControlloNumerico(sender, e, False)
    End Sub

    Private Sub DgOrdini_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgOrdini.CellClick
        ClickSuDgIncl = False
    End Sub

    Private Sub DgOrdini_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgOrdini.CellDoubleClick

        If DgOrdini.SelectedRows.Count Then

            Dim Ord As Ordine = DgOrdini.SelectedRows(0).DataBoundItem
            Sottofondo()
            Dim frmO As New frmOrdine
            frmO.Carica(Ord.IdOrd)
            Sottofondo()

        End If

    End Sub

    Private Sub DgOrdUscMag_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgOrdUscMag.CellMouseClick
        If DgOrdUscMag.SelectedRows.Count Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                IncludiOrdineNellaConsegnaToolStripMenuItem.Enabled = True
                EscludiOrdineDallaConsegnaToolStripMenuItem.Enabled = False
                mnuIncludiOrd.Show(MousePosition)
            End If
        End If
    End Sub

    Private Sub DGOrdiniInclusi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGOrdiniInclusi.CellClick
        ClickSuDgIncl = True
    End Sub

    Private Sub DGOrdiniInclusi_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGOrdiniInclusi.CellMouseClick
        If DGOrdiniInclusi.SelectedRows.Count Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                IncludiOrdineNellaConsegnaToolStripMenuItem.Enabled = False
                EscludiOrdineDallaConsegnaToolStripMenuItem.Enabled = True
                mnuIncludiOrd.Show(MousePosition)
            End If
        End If

    End Sub

    Private Sub DgOrdini_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgOrdini.RowPostPaint,
                                                                                                              DGOrdiniInclusi.RowPostPaint,
                                                                                                               DgOrdUscMag.RowPostPaint

        Dim Riga As DataGridViewRow = sender.Rows.Item(e.RowIndex)
        Dim o As Ordine = Riga.DataBoundItem

        Dim ColoreSfondo As Color = o.StatoColore

        Riga.Cells(3).Style.BackColor = ColoreSfondo
        Riga.Cells(3).Style.SelectionBackColor = ColoreSfondo

    End Sub

    Private Sub CambiaOrdinePreventivo(O As Ordine, NuovoStato As enSiNo)

        O.Preventivo = NuovoStato
        O.LastUpdate = enSiNo.Si
        O.Save()

        CaricaOrdini()
        CaricaOrdiniInclusiConsegna()
        CalcolaTotali()

    End Sub

    Private Sub lnkPrevSi_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrevSi.LinkClicked

        Dim RisModConsegna As RisConsegnaModificabile = _Consegna.Diritti.PossoCambiareDocumentoFiscaleOrdini '_Consegna.ModificabileEx(False, False, False, False, True, False)

        If RisModConsegna.Esito Then
            Dim dg As DataGridView

            If ClickSuDgIncl = False Then 'ordini
                dg = DgOrdini
            Else 'ordini inclusi
                dg = DGOrdiniInclusi
            End If

            If dg.SelectedRows.Count Then

                If dg.SelectedRows.Count = 1 Then
                    Dim O As Ordine = dg.SelectedRows(0).DataBoundItem
                    If O.Preventivo = enSiNo.No Then
                        If MessageBox.Show("ATTENZIONE! Vuoi trasformare l'ordine selezionato in un ordine di tipo PREVENTIVO?", "Cambio Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            CambiaOrdinePreventivo(O, enSiNo.Si)
                        End If
                    Else
                        MessageBox.Show("L'ordine selezionato è già di tipo PREVENTIVO")
                    End If
                Else
                    For Each dr As DataGridViewRow In dg.SelectedRows
                        Dim O As Ordine = dr.DataBoundItem
                        If Not O Is Nothing Then
                            If O.Preventivo = enSiNo.No Then
                                O.Preventivo = enSiNo.Si
                                O.LastUpdate = enSiNo.Si
                                O.Save()
                            End If
                        End If
                    Next
                    CaricaOrdini()
                    CaricaOrdiniInclusiConsegna()
                    CalcolaTotali()

                    MessageBox.Show("Gli ordini sono passati a PREVENTIVO")
                End If

            Else
                MessageBox.Show("Selezionare un ordine dalla lista")
            End If
        Else
            MessageBox.Show("La consegna non è modificabile: " & RisModConsegna.BufferErrori)
        End If



    End Sub

    Private Sub lnkPrevNo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPrevNo.LinkClicked
        Dim RisModConsegna As RisConsegnaModificabile = _Consegna.Diritti.PossoCambiareDocumentoFiscaleOrdini '_Consegna.ModificabileEx(False, False, False, False, True, False)

        If RisModConsegna.Esito Then
            Dim dg As DataGridView

            If ClickSuDgIncl = False Then 'ordini
                dg = DgOrdini
            Else 'ordini inclusi
                dg = DGOrdiniInclusi
            End If

            If dg.SelectedRows.Count Then

                If dg.SelectedRows.Count = 1 Then
                    Dim O As Ordine = dg.SelectedRows(0).DataBoundItem
                    If O.Preventivo = enSiNo.Si Then
                        If MessageBox.Show("ATTENZIONE! Vuoi trasformare l'ordine selezionato in un ordine di tipo NON Preventivo?", "Cambio Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            CambiaOrdinePreventivo(O, enSiNo.No)
                        End If
                    Else
                        MessageBox.Show("L'ordine selezionato è già di tipo NON Preventivo")
                    End If
                Else

                    For Each dr As DataGridViewRow In dg.SelectedRows
                        Dim O As Ordine = dr.DataBoundItem

                        If Not O Is Nothing Then
                            If O.Preventivo = enSiNo.Si Then
                                O.Preventivo = enSiNo.No
                                O.LastUpdate = enSiNo.Si
                                O.Save()
                            End If

                        End If
                    Next

                    CaricaOrdini()
                    CaricaOrdiniInclusiConsegna()
                    CalcolaTotali()

                    MgrControl.SelectIndexComboEnum(cmbTipoDoc, _Consegna.TipoDoc)

                    MessageBox.Show("Gli ordini sono passati a NON Preventivo")
                End If
            Else
                MessageBox.Show("Selezionare un ordine dalla lista")
            End If

        Else
            MessageBox.Show("La consegna non è modificabile: " & RisModConsegna.BufferErrori)
        End If


    End Sub

    Private Sub lblRub_Click(sender As Object, e As EventArgs) Handles lblRub.Click
        Sottofondo()

        Using frm As New frmVoceRubrica
            frm.Carica(_Consegna.IdRub)
        End Using

        Sottofondo()
    End Sub

    Private Sub lnkModCons_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModCons.LinkClicked

        Dim RisModConsegna As RisConsegnaModificabile = _Consegna.Diritti.PossoModificareIndirizzoOppureCorriere '_Consegna.ModificabileEx(True, True, False, True, False, False)

        If RisModConsegna.Esito AndAlso _Consegna.CodTrack.Length = 0 Then

            If MessageBox.Show("Sicuro di voler modificare i dati della consegna (Corriere, Indirizzo e Data)?", "Modifica Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim Ris As Integer = 0

                Sottofondo()
                Using x As New frmConsegnaModificaDati
                    Ris = x.Carica(_IdCons)
                End Using
                Sottofondo()

                If Ris Then
                    CaricaDatiConsegna(Ris)
                End If
            End If
        Else
            'Dim Motivo As String = String.Empty

            'If _Consegna.HaDocumentiFiscali Then
            '    Motivo &= " - ha documenti fiscali;"
            'End If

            'If _Consegna.HaUnPagamentoAnticipato Then
            '    Motivo &= " - ha un pagamento anticipato;"
            'End If

            'If _Consegna.IdStatoConsegna <> enStatoConsegna.InLavorazione Then
            '    Motivo &= " - non è nello stato 'In Lavorazione';"
            'End If

            ''If _Consegna.IdStatoConsegna = enStatoConsegna.InConsegna Then
            ''    Motivo &= " - è già in consegna;"
            ''End If

            'If _Consegna.CodTrack.Length <> 0 Then
            '    Motivo &= " - ha un codice di tracking;"
            'End If

            'If _Consegna.Blocco = enSiNo.Si Then
            '    Motivo &= " - è bloccata con il lucchetto;"
            'End If

            MessageBox.Show("Questa consegna non è modificabile perchè:" & RisModConsegna.BufferErrori)
        End If

    End Sub

    Private Sub lnkEmettiDocFisc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEmettiDocFiscPrev.LinkClicked

        'MessageBox.Show("Funzionalità non attiva")
        'Exit Sub

        If MessageBox.Show("Confermi l'emissione PREVENTIVA di tutti i documenti di questa consegna?", "Emissione documenti Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SalvaConsegna()
            'If _Consegna.ListaOrdini.Count > 1 Then
            Dim OkPerEmissione As Boolean = True
            Dim BufferErrore As String = String.Empty

            'solo in questo caso controllo che tutto sia pronto per il ritiro perche la consegna e' bloccata
            'If _Consegna.Modificabile(True) = False Then
            '    If _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ProntoRitiro).Count <> _Consegna.ListaOrdini.Count Then
            '        ' qui devo fermare tutto
            '        OkPerEmissione = False
            '        BufferErrore = "La consegna non è modificabile, devono essere preparati tutti gli ordini che contiene"
            '    End If
            '    'Else
            '    '    If _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
            '    '        OkPerEmissione = False
            '    '        BufferErrore = "Non puoi forzare l'emissione di documenti di una consegna in cui nessun ordine è stato preparato"
            '    '    End If
            'End If

            If _Consegna.ListaOrdini.FindAll(Function(singo) singo.NumeroRealeColli = 0).Count Then
                'qui ci sono ordini che non hanno il numero colli
                OkPerEmissione = False
                BufferErrore = "Inserire il numero colli per tutti gli ordini nella consegna"
            End If

            If OkPerEmissione Then
                'qui devo prendere gli ordini che non sono ancora stati inseriti e cambiargli la consegna spostandola



                'se tutti gli ordini non sono in pronto ritiro devo chiedere colli e peso 



                'If _Consegna.Modificabile(True) = True Then

                '    Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, _Consegna.IdCorr)

                '    'Dim DataNuova As Date = Now.Date

                '    'Select Case Now.DayOfWeek
                '    '    Case DayOfWeek.Saturday
                '    '        DataNuova = DataNuova.AddDays(2)
                '    '    Case DayOfWeek.Friday
                '    '        If _Consegna.IdCorr = enCorriere.RitiroCliente Then
                '    '            DataNuova = DataNuova.AddDays(1)
                '    '        Else
                '    '            DataNuova = DataNuova.AddDays(3)
                '    '        End If
                '    '    Case Else
                '    '        DataNuova = DataNuova.AddDays(1)
                '    'End Select

                '    For Each cpO As Ordine In _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato < enStatoOrdine.ProntoRitiro)

                '        Using mgrC As New ConsegneProgrammateDAO

                '            'TOLTO IL 08/04/2015
                '            'mgrC.EliminaOrdineDaConsegna(0, cpO.IdOrd)
                '            mgrC.RegistraConsegnaOrdineSuGiorno(cpO.IdOrd, _Consegna.IdCorr, DataNuova, _Consegna.IdRub, enMomentoConsegna.Pomeriggio, _Consegna.IdIndirizzo)
                '        End Using
                '    Next

                'End If

                '_Consegna.Blocco = enSiNo.Si'****COMMENTATO PER ESCLUSIONE BLOCCO DIRETTO
                _Consegna.AggiornaColliPeso()

                Dim StampaDocumFisc As Boolean = False
                If MessageBox.Show("Vuoi stampare i documenti fiscali emessi?", "Emissione Documenti", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    StampaDocumFisc = True
                End If

                Dim RisStampaDocumenti As Integer = 0

                'Try
                RisStampaDocumenti = ProxyDocumenti.CreaDocumenti(_Consegna.IdCons,
                                                                  False,
                                                                  StampaDocumFisc,
                                                                  PostazioneCorrente.UtenteConnesso.IdUt)
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                'End Try

                'Using Rub As New VoceRubrica
                '    Rub.Read(_Consegna.IdRub)

                '    'Dim lo As List(Of Ordine) = Nothing
                '    'Using mgr As New OrdiniDAO
                '    '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _Consegna.IdRub), New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Consegnato))
                '    'End Using

                '    'If Rub.HaDocumentiInSospeso(_Consegna.ListaIdDocumenti) Then
                '    '    'If lo.Count Then

                '    '    If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                '    '        'prima di uscire mando in stampa il documento contabile
                '    '        Sottofondo()
                '    '        StampaBuffer(Rub.SituazioneContabile)
                '    '        Sottofondo()

                '    '    End If
                '    'End If
                'End Using
                'qui devo ricaricare

                MgrDocumentiFiscali.CheckNumeroDocumentiFiscali(Now.Year)

                CaricaDatiConsegna(_IdCons)
            Else

                MessageBox.Show(BufferErrore)

            End If
            'Else
            '    MessageBox.Show("Non puoi forzare l'emissione di documenti di una consegna che contiene un solo ordine")
            'End If

        End If
    End Sub

    'Private Sub lnkEmettiDocFisc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEmettiDocFiscPrev.LinkClicked

    '    MessageBox.Show("Funzionalità non attiva")
    '    Exit Sub

    '    If MessageBox.Show("Confermi l'emissione PREVENTIVA di tutti i documenti di questa consegna?", "Emissione documenti Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        SalvaConsegna()
    '        'If _Consegna.ListaOrdini.Count > 1 Then
    '        Dim OkPerEmissione As Boolean = True
    '        Dim BufferErrore As String = String.Empty

    '        'solo in questo caso controllo che tutto sia pronto per il ritiro perche la consegna e' bloccata
    '        If _Consegna.Modificabile(True) = False Then
    '            If _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ProntoRitiro).Count <> _Consegna.ListaOrdini.Count Then
    '                ' qui devo fermare tutto
    '                OkPerEmissione = False
    '                BufferErrore = "La consegna non è modificabile, devono essere preparati tutti gli ordini che contiene"
    '            End If
    '            'Else
    '            '    If _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
    '            '        OkPerEmissione = False
    '            '        BufferErrore = "Non puoi forzare l'emissione di documenti di una consegna in cui nessun ordine è stato preparato"
    '            '    End If
    '        End If

    '        If _Consegna.ListaOrdini.FindAll(Function(singo) singo.NumeroRealeColli = 0).Count Then
    '            'qui ci sono ordini che non hanno il numero colli
    '            OkPerEmissione = False
    '            BufferErrore = "Inserire il numero colli per tutti gli ordini nella consegna"
    '        End If

    '        If OkPerEmissione Then
    '            'qui devo prendere gli ordini che non sono ancora stati inseriti e cambiargli la consegna spostandola



    '            'se tutti gli ordini non sono in pronto ritiro devo chiedere colli e peso 



    '            If _Consegna.Modificabile(True) = True Then

    '                Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, _Consegna.IdCorr)

    '                'Dim DataNuova As Date = Now.Date

    '                'Select Case Now.DayOfWeek
    '                '    Case DayOfWeek.Saturday
    '                '        DataNuova = DataNuova.AddDays(2)
    '                '    Case DayOfWeek.Friday
    '                '        If _Consegna.IdCorr = enCorriere.RitiroCliente Then
    '                '            DataNuova = DataNuova.AddDays(1)
    '                '        Else
    '                '            DataNuova = DataNuova.AddDays(3)
    '                '        End If
    '                '    Case Else
    '                '        DataNuova = DataNuova.AddDays(1)
    '                'End Select

    '                For Each cpO As Ordine In _Consegna.ListaOrdini.FindAll(Function(singO) singO.Stato < enStatoOrdine.ProntoRitiro)

    '                    Using mgrC As New ConsegneProgrammateDAO

    '                        'TOLTO IL 08/04/2015
    '                        'mgrC.EliminaOrdineDaConsegna(0, cpO.IdOrd)
    '                        mgrC.RegistraConsegnaOrdineSuGiorno(cpO.IdOrd, _Consegna.IdCorr, DataNuova, _Consegna.IdRub, enMomentoConsegna.Pomeriggio, _Consegna.IdIndirizzo)
    '                    End Using
    '                Next

    '            End If

    '            _Consegna.Blocco = enSiNo.Si
    '            _Consegna.AggiornaColliPeso()

    '            Dim StampaDocumFisc As Boolean = False
    '            If MessageBox.Show("Vuoi stampare i documenti fiscali emessi?", "Emissione Documenti", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                StampaDocumFisc = True
    '            End If

    '            Dim RisStampaDocumenti As Integer = 0

    '            'Try
    '            RisStampaDocumenti = ProxyDocumenti.CreaDocumenti(_Consegna.IdCons,
    '                                                              False,
    '                                                              StampaDocumFisc,
    '                                                              PostazioneCorrente.UtenteConnesso.IdUt)
    '            'Catch ex As Exception
    '            '    MessageBox.Show(ex.Message)
    '            'End Try

    '            'Using Rub As New VoceRubrica
    '            '    Rub.Read(_Consegna.IdRub)

    '            '    'Dim lo As List(Of Ordine) = Nothing
    '            '    'Using mgr As New OrdiniDAO
    '            '    '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _Consegna.IdRub), New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Consegnato))
    '            '    'End Using

    '            '    'If Rub.HaDocumentiInSospeso(_Consegna.ListaIdDocumenti) Then
    '            '    '    'If lo.Count Then

    '            '    '    If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            '    '        'prima di uscire mando in stampa il documento contabile
    '            '    '        Sottofondo()
    '            '    '        StampaBuffer(Rub.SituazioneContabile)
    '            '    '        Sottofondo()

    '            '    '    End If
    '            '    'End If
    '            'End Using
    '            'qui devo ricaricare

    '            MgrDocumentiFiscali.CheckNumeroDocumentiFiscali(Now.Year)

    '            CaricaDatiConsegna(_IdCons)
    '        Else

    '            MessageBox.Show(BufferErrore)

    '        End If
    '        'Else
    '        '    MessageBox.Show("Non puoi forzare l'emissione di documenti di una consegna che contiene un solo ordine")
    '        'End If

    '    End If
    'End Sub

    Private Sub lnkRePrintDoc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRePrintDoc.LinkClicked
        If MessageBox.Show("Confermi la ristampa di tutti i documenti di questa consegna?", "Emissione documenti Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim NumCopie As Integer = 0
            Try
                NumCopie = InputBox("Inserisci il numero di copie che vuoi stampare", "Numero Copie", FormerLib.FormerConst.Fiscali.NumCopieDocFiscali)
            Catch ex As Exception

            End Try

            If NumCopie > 0 Then
                For Each SingIdDoc In _Consegna.ListaDocumenti
                    'Dim D As New Ricavo
                    'D.Read(SingIdDoc)
                    Try
                        MgrDocumentiFiscali.MessaggioModuloFattura(SingIdDoc, NumCopie)
                        ProxyStampa.StampaDocumentoFiscale(SingIdDoc, True, NumCopie, PostazioneCorrente.UtenteConnesso.IdUt)
                    Catch ex As Exception
                        MessageBox.Show("Si è verificato un errore nella stampa del documento fiscale, riprovare")
                    End Try
                    'D = Nothing
                Next
            Else
                MessageBox.Show("Inserire un numero di copie valido")
            End If

        End If
    End Sub

    Private Sub lnkEmettiDocFisc_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEmettiDocFisc.LinkClicked

        If MessageBox.Show("Confermi l'emissione di tutti i documenti di questa consegna?", "Emissione documenti Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            SalvaConsegna()
            Dim OkFattura As String = String.Empty
            If _Consegna.ListaOrdini.FindAll(Function(x) x.Preventivo = enSiNo.No).Count Then
                OkFattura = _Consegna.Cliente.Fatturabile
            End If

            If OkFattura.Length = 0 Then
                Dim RisStampaDocumenti As Integer = 0

                Dim StampaDocumFisc As Boolean = False
                If MessageBox.Show("Vuoi stampare i documenti fiscali emessi?", "Emissione Documenti", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    StampaDocumFisc = True
                End If

                Dim DiffGiorni As Integer = DateDiff(DateInterval.Day, _Consegna.Giorno, Date.Now)

                If MgrFormerException.SpostareDataConsegnaOggiQuandoEmettoDocumenti(_Consegna) Then
                    If DiffGiorni <> 0 Then ' la sposto solo se e' nel futuro
                        'qui devo forzare la data ad oggi
                        _Consegna.Giorno = Now
                        _Consegna.LastUpdate = enSiNo.Si
                        _Consegna.Save()
                    End If
                End If

                'Try
                RisStampaDocumenti = ProxyDocumenti.CreaDocumenti(_Consegna.IdCons,
                                                                      True,
                                                                      StampaDocumFisc,
                                                                      PostazioneCorrente.UtenteConnesso.IdUt)
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message)
                'End Try

                'Using Rub As New VoceRubrica
                'Rub.Read(_Consegna.IdRub)

                'Dim lo As List(Of Ordine) = Nothing
                'Using mgr As New OrdiniDAO
                '    lo = mgr.FindAll(New LUNA.LunaSearchParameter("IdRub", _Consegna.IdRub), New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Consegnato))
                'End Using

                'If Rub.HaDocumentiInSospeso(_Consegna.ListaIdDocumenti) Then
                '    'If lo.Count Then

                '    If MessageBox.Show("Vuoi stampare la situazione contabile del cliente?", "Situazione Contabile", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                '        'prima di uscire mando in stampa il documento contabile
                '        Sottofondo()
                '        StampaBuffer(Rub.SituazioneContabile)
                '        Sottofondo()

                '    End If
                'End If
                'End Using

                MgrDocumentiFiscali.CheckNumeroDocumentiFiscali(Now.Year)
                CaricaDatiConsegna(_IdCons)
            Else
                MessageBox.Show("Il cliente non ha i dati fiscali completi per l'emissione della fattura: " & OkFattura)

            End If

        End If

    End Sub

    Private Sub lnkOpenDoc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenDoc.LinkClicked

        If _IdDoc Then
            Sottofondo()
            Dim frm As New frmContabilitaRicavo
            frm.Carica(_IdDoc, enTipoVoceContab.VoceVendita, _Consegna.IdRub)
            frm = Nothing
            Sottofondo()
        End If

    End Sub

    Private Sub lnkOpenPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOpenPrev.LinkClicked
        If _IdPrev Then
            Sottofondo()
            Dim frm As New frmContabilitaRicavo
            frm.Carica(_IdPrev, enTipoVoceContab.VoceVendita, _Consegna.IdRub)
            frm = Nothing
            Sottofondo()
        End If
    End Sub

    Private Sub lnkRegPagDoc_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegPagDoc.LinkClicked

        If _IdDoc Then
            Sottofondo()
            Using d As New Ricavo
                d.Read(_IdDoc)
                If d.PagatoInteramente = False Then
                    Using x As New frmContabilitaPagamento
                        If x.Carica(0, _Consegna.IdRub, _IdDoc, enTipoVoceContab.VoceVendita) Then
                            CaricaOrdini()
                            CalcolaTotali()

                        End If
                    End Using
                Else

                    MessageBox.Show("Pagamento già presente")

                End If
            End Using


            Sottofondo()
        End If
    End Sub

    Private Sub lnkRegPagPrev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRegPagPrev.LinkClicked

        If _IdPrev Then
            Sottofondo()

            Using x As New frmContabilitaPagamento
                If x.Carica(0, _Consegna.IdRub, _IdPrev, enTipoVoceContab.VoceVendita) Then
                    CaricaOrdini()
                    CalcolaTotali()
                End If
            End Using

            Sottofondo()
        End If

    End Sub

    Private Sub DgOrdini_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgOrdini.ColumnHeaderMouseClick,
                                                                                                               DGOrdiniInclusi.ColumnHeaderMouseClick,
                                                                                                               DgOrdUscMag.ColumnHeaderMouseClick
        OrdinatoreLista(Of Ordine).OrdinaLista(sender, e)
    End Sub

    Private Sub IncludiOrdineNellaConsegnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncludiOrdineNellaConsegnaToolStripMenuItem.Click
        If _IdDoc <> 0 Or _IdPrev <> 0 Then
            MessageBox.Show("Non è possibile includere ordini in una Consegna per cui è già stato emesso un documento fiscale")
        Else
            Dim Ris As RisConsegnaModificabile = _Consegna.Diritti.PossoModificareOrdiniContenutiOAccorparla '_Consegna.ModificabileEx(False, False, True, True, False, False)

            If Ris.Esito Then
                If DgOrdUscMag.SelectedRows.Count Then
                    If MessageBox.Show("Vuoi INCLUDERE gli ordini selezionati nel documento di questa consegna?", "Includi Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        For Each singRow As DataGridViewRow In DgOrdUscMag.SelectedRows
                            Using O As Ordine = singRow.DataBoundItem
                                MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "ALLEGATO A CONSEGNA " & _Consegna.IdCons)
                                O.IdConsRiferimento = _Consegna.IdCons
                                O.Save()
                            End Using
                        Next
                        CaricaOrdini()
                        CaricaOrdiniInclusiConsegna()
                        CaricaOrdiniUscitiMagazzino()
                        CalcolaTotali()
                    End If
                Else
                    Beep()
                End If

            Else
                MessageBox.Show("Consegna non modificabile: " & Ris.BufferErrori)
            End If

        End If

    End Sub

    Private Sub EscludiOrdineDallaConsegnaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscludiOrdineDallaConsegnaToolStripMenuItem.Click

        If _IdDoc <> 0 Or _IdPrev <> 0 Then
            MessageBox.Show("Non è possibile Escludere ordini in una Consegna per cui è già stato emesso un documento fiscale")
        Else
            Dim Ris As RisConsegnaModificabile = _Consegna.Diritti.PossoModificareOrdiniContenutiOAccorparla '_Consegna.ModificabileEx(False, False, True, True, False, False)

            If Ris.Esito Then
                Dim OrdineIncluso As Boolean = False
                Dim dg As DataGridView = Nothing
                If ClickSuDgIncl = False Then
                    dg = DgOrdini
                Else
                    dg = DGOrdiniInclusi
                    OrdineIncluso = True
                End If

                Dim RicaricaDati As Boolean = True
                If MessageBox.Show("Vuoi ESCLUDERE gli ordini selezionati da questa consegna?", "Escludi Ordine", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If OrdineIncluso Then
                        For Each singRow As DataGridViewRow In dg.SelectedRows
                            Dim O As Ordine = singRow.DataBoundItem
                            MgrLogOperativi.ScriviVoceLog(enTipoVoceLog.Ordine, O.IdOrd, "SLEGATO DA CONSEGNA " & _Consegna.IdCons)
                            O.IdConsRiferimento = 0
                            O.Save()
                        Next
                    Else
                        If _Consegna.ListaOrdini.Count = 1 Then
                            MessageBox.Show("Non si può escludere l'unico ordine presente nella consegna")
                            RicaricaDati = False
                        ElseIf _Consegna.ListaOrdini.Count = dg.SelectedRows.Count Then
                            MessageBox.Show("Non si possono escludere tutti gli ordini di una consegna")
                            RicaricaDati = False
                        Else
                            Using mgr As New ConsegneProgrammateDAO
                                For Each singRow As DataGridViewRow In dg.SelectedRows
                                    Dim O As Ordine = singRow.DataBoundItem
                                    'If O.Stato = enStatoOrdine.UscitoMagazzino Then
                                    Dim ControllaUscitiMagazzino As Boolean = True
                                    If O.Stato = enStatoOrdine.UscitoMagazzino Then ControllaUscitiMagazzino = False
                                    mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd,
                                                                       _Consegna.IdCorr,
                                                                       _Consegna.Giorno,
                                                                       O.IdRub,
                                                                       _Consegna.MatPom,
                                                                       _Consegna.IdIndirizzo,, ControllaUscitiMagazzino, ,
                                                                       _Consegna.IdCons) 'aggiunto per permettere ai uscito da magazzino esclusi di riunirsi
                                    'End If
                                Next
                            End Using
                        End If
                    End If
                    If RicaricaDati Then
                        CaricaOrdini()
                        CaricaOrdiniInclusiConsegna()
                        CaricaOrdiniUscitiMagazzino()
                        CalcolaTotali()
                    End If
                End If
            Else
                MessageBox.Show("Consegna non modificabile: " & Ris.BufferErrori)
            End If

        End If

    End Sub

    Private Sub lnkPagamAnticip_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkPagamAnticip.LinkClicked

        Sottofondo()

        Dim f As New frmContabilitaPagamento
        f.Carica(_Consegna.PagamentoAnticipato.IdPag)

        Sottofondo()

    End Sub

    Private Sub btnAggColli_Click(sender As Object, e As EventArgs) Handles btnAggColli.Click

        If _Consegna.HaDocumentiFiscali = False Then
            If _Consegna.HaUnPagamentoAnticipato = False Then
                If MessageBox.Show("Confermi il ricalcolo di colli e peso?", "Aggiorna Colli e Peso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    _Consegna.AggiornaColliPeso()
                    txtNumPacchi.Text = _Consegna.NumColli
                    txtPeso.Text = _Consegna.Peso
                    MessageBox.Show("Numero Colli e Peso aggiornati")
                End If
            Else
                MessageBox.Show("Per la consegna sono stati già emessi documenti fiscali")
            End If
        Else
            MessageBox.Show("Per la consegna sono stati già emessi documenti fiscali")
        End If
    End Sub

    Private Sub DgOrdini_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgOrdini.CellMouseClick
        If DgOrdini.SelectedRows.Count Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                IncludiOrdineNellaConsegnaToolStripMenuItem.Enabled = False
                EscludiOrdineDallaConsegnaToolStripMenuItem.Enabled = True
                mnuIncludiOrd.Show(MousePosition)

            End If
        End If
    End Sub

    Private Sub lblIndirizzo_MouseClick(sender As Object, e As MouseEventArgs) Handles lblIndirizzo.MouseClick
        lblIndirizzo.SelectAll()
    End Sub

    Private Sub pctBlocco_Click(sender As Object, e As EventArgs) Handles pctSblocca.Click

        If _Consegna.Blocco = enSiNo.Si Then
            Dim ErrMsg As String = String.Empty
            If _Consegna.HaDocumentiFiscali Then
                ErrMsg = " ha documenti fiscali già emessi;"
            End If

            If _Consegna.HaUnPagamentoAnticipato Then
                ErrMsg &= " ha un pagamento anticipato;"
            End If

            If _Consegna.NoCartaceo = enSiNo.Si Then
                ErrMsg &= " il cliente ha richiesto di non ricevere il documento cartaceo"
            End If

            If ErrMsg.Length Then
                MessageBox.Show("La consegna non può essere sbloccata perchè: " & ErrMsg)
            Else
                If MessageBox.Show("Confermi lo sblocco della consegna?", "Sblocco Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    _Consegna.Blocco = enSiNo.No
                    _Consegna.Save()
                    pctSblocca.Visible = False
                    pctBlocca.Visible = True
                End If
            End If

        End If

    End Sub

    Private Sub chkForzaUscitaSenzaDocumenti_CheckedChanged(sender As Object, e As EventArgs) Handles chkForzaUscitaSenzaDocumenti.CheckedChanged
        If sender.checked Then
            chkStampaDocumenti.Checked = False
            chkStampaDocumenti.Enabled = False
        Else
            chkStampaDocumenti.Enabled = True
        End If
    End Sub

    Private Sub chkStampaDocumenti_CheckedChanged(sender As Object, e As EventArgs) Handles chkStampaDocumenti.CheckedChanged

        If sender.checked Then
            chkForzaUscitaSenzaDocumenti.Checked = False
            chkForzaUscitaSenzaDocumenti.Enabled = False
        Else
            chkForzaUscitaSenzaDocumenti.Enabled = True
            chkNoCartaceo.Checked = False
        End If
    End Sub

    Private Sub pctRubrica_Click(sender As Object, e As EventArgs) Handles pctRubrica.Click

        Sottofondo()

        Using frm As New frmVoceRubrica
            frm.Carica(_Consegna.IdRub)
        End Using

        Sottofondo()

    End Sub

    Private Sub txtNote_TextChanged(sender As Object, e As EventArgs) Handles txtNote.TextChanged
        lblNoteCounter.Text = "Note (" & txtNote.Text.Length & "/40)"
    End Sub

    Private Sub pctBlocca_Click(sender As Object, e As EventArgs) Handles pctBlocca.Click
        If MessageBox.Show("Confermi il blocco della consegna?", "Sblocco Consegna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            _Consegna.Blocco = enSiNo.Si
            _Consegna.Save()
            pctSblocca.Visible = True
            pctBlocca.Visible = False
        End If
    End Sub

    Private Sub chkNoCartaceo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoCartaceo.CheckedChanged
        If chkNoCartaceo.Checked Then
            chkStampaDocumenti.Checked = True
            If cmbPagam.SelectedValue = enMetodoPagamento.ContrassegnoAlRitiro Then
                MessageBox.Show("Non è possibile scegliere di non allegare il documento cartaceo per le consegne con pagamento in contrassegno")
                chkNoCartaceo.Checked = False
            End If
        End If
    End Sub

    Private Sub lnkRiportaImballaggio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRiportaImballaggio.LinkClicked

        If _Consegna.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ImballaggioCorriere Or x.Stato = enStatoOrdine.ProntoRitiro).Count Then
            If MessageBox.Show("Confermi il ritorno di tutti gli ordini della consegna che sono in stato IMBALLAGGIO CORRIERE o PRONTO RITIRO allo stato IMBALLAGGIO?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                'qui controllo lo stato della consegna che deve essere o in lavorazione o in registrata corriere 
                Dim DaModificare As Boolean = False
                Dim CancellataRegistrazioneCorriere As Boolean = False

                If _Consegna.IdStatoConsegna = enStatoConsegna.InLavorazione Then
                    DaModificare = True
                ElseIf _Consegna.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                    DaModificare = True
                    _Consegna.IdStatoConsegna = enStatoConsegna.InLavorazione

                    If _Consegna.DataTrasmissioneCorriere <> Date.MinValue And _Consegna.CodTrack.Length <> 0 Then
                        CancellataRegistrazioneCorriere = True
                        'qui va cancellata la registrazione del corriere
                        Try
                            MgrWebLabelingGls.EliminaSpedizione(_Consegna.CodTrack)
                            _Consegna.CodTrack = String.Empty
                            '_Consegna.Blocco = enSiNo.Si
                        Catch ex As Exception
                            MessageBox.Show("Si è verificato un errore nella cancellazione da GLS della registrazione della consegna: " & ex.Message)
                        End Try

                    End If

                    _Consegna.Save()

                Else
                    MessageBox.Show("La consegna si trova in uno stato non modificabile. Possono essere modificate tutte le consegne nello stato 'In Lavorazione' o 'Registrata Corriere'")
                End If

                If DaModificare Then
                    For Each O As Ordine In _Consegna.ListaOrdini
                        If O.Stato = enStatoOrdine.ImballaggioCorriere Or O.Stato = enStatoOrdine.ProntoRitiro Then
                            Using mgrO As New OrdiniDAO
                                mgrO.InserisciLog(O, enStatoOrdine.Imballaggio)
                            End Using
                        End If
                    Next
                    Dim msgStr As String = String.Empty

                    Dim IdCons As Integer = _Consegna.IdCons
                    CaricaDatiConsegna(IdCons)
                    msgStr = "Tutti gli ordini in stato IMBALLAGGIO CORRIERE o PRONTO RITIRO sono stati portati allo stato di IMBALLAGGIO"

                    If CancellataRegistrazioneCorriere Then
                        msgStr &= ControlChars.NewLine & "E' stata cancellata la registrazione automatica del corriere con GLS quindi le etichette sui pacchi vanno staccate e sostituite con le nuove"
                    End If

                    MessageBox.Show(msgStr)

                End If

            End If
        Else
            MessageBox.Show("Non sono presenti ordini in stato IMBALLAGGIO CORRIERE o PRONTO RITIRO da riportare allo stato di IMBALLAGGIO")
        End If

    End Sub

    Private Sub GoTracking()
        If txtCodTrack.Text.Length Then
            Dim PathUrl As String = MgrTraceCorriere.GetUrlTraceGLS(txtCodTrack.Text)

            FormerLib.FormerHelper.File.ShellExtended(PathUrl)
        Else
            MessageBox.Show("Il tracking di questa consegna non può essere effettuato perchè non è presente il codice di tracking")
        End If
    End Sub

    Private Sub lnkTracking_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkTracking.LinkClicked

        GoTracking()

    End Sub

    Private Sub cmbPagam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPagam.SelectedIndexChanged
        Try
            'chkStampaDocumenti.Checked = True
            If cmbPagam.SelectedValue = enMetodoPagamento.ContrassegnoAlRitiro Then
                If chkNoCartaceo.Checked Then
                    MessageBox.Show("Non è possibile scegliere di non allegare il documento cartaceo per le consegne con pagamento in contrassegno")
                    chkNoCartaceo.Checked = False
                End If
                chkAssRilIntMitt.Enabled = True
            Else
                chkAssRilIntMitt.Enabled = False
                chkAssRilIntMitt.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnkEliminaRegistrazione_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkEliminaRegistrazione.LinkClicked

        Dim CodTrack As String = _Consegna.CodTrack

        If CodTrack.Length Then
            If MessageBox.Show("Vuoi eliminare la registrazione al corriere GLS?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                MgrConsegneCorriere.GLS.EliminaRegistrazioneConsegna(_Consegna)
                CaricaOrdini()
                txtCodTrack.Text = String.Empty
            End If
        Else
            MessageBox.Show("Codice tracking non presente!")
            txtCodTrack.Text = String.Empty
        End If

    End Sub

    Private Sub lnkModifNumColli_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkModifNumColli.LinkClicked
        'Dim Ris As RisConsegnaModificabile = _Consegna.ModificabileEx(False, False, True, True, False, False)

        If _Consegna.HaDocumentiFiscali = False OrElse
           _Consegna.IdStatoConsegna = enStatoConsegna.InLavorazione Then
            Dim dg As DataGridView

            If ClickSuDgIncl = False Then 'ordini
                dg = DgOrdini
            Else 'ordini inclusi
                dg = DGOrdiniInclusi
            End If

            If dg.SelectedRows.Count Then

                If dg.SelectedRows.Count = 1 Then
                    Dim O As Ordine = dg.SelectedRows(0).DataBoundItem
                    Sottofondo()
                    Dim Ris As Integer = 0
                    Using f As New frmOrdineNumColli
                        Ris = f.Carica(O.IdOrd, O.NumeroRealeColli)
                    End Using
                    Sottofondo()

                    If Ris Then
                        If O.NumeroRealeColli <> Ris Then
                            O.NumeroRealeColli = Ris
                            O.Save()
                        End If
                    Else
                        MessageBox.Show("Numero colli inserito non valido")
                    End If
                Else
                    MessageBox.Show("Selezionare un SOLO ordine dalla lista")
                End If
            Else
                MessageBox.Show("Selezionare un ordine dalla lista")
            End If
        Else
            MessageBox.Show("La consegna ha già un documento fiscale oppure è in uno stato diverso da In lavorazione")
        End If

    End Sub
    Private Sub LnkCodTracking_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCodTracking.LinkClicked

        GoTracking()

    End Sub

    Private Sub ModificaDatiEconomiciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaDatiEconomiciToolStripMenuItem.Click

        If _IdDoc <> 0 Or _IdPrev <> 0 Then
            MessageBox.Show("Non è possibile Escludere ordini in una Consegna per cui è già stato emesso un documento fiscale")
        Else
            Dim Ris As RisConsegnaModificabile = _Consegna.Diritti.PossoModificareOrdiniContenutiOAccorparla '_Consegna.ModificabileEx(False, False, True, True, True, False)

            If Ris.Esito Then
                Dim OrdineIncluso As Boolean = False
                Dim dg As DataGridView = Nothing
                If ClickSuDgIncl = False Then
                    dg = DgOrdini
                Else
                    dg = DGOrdiniInclusi
                    OrdineIncluso = True
                End If

                Dim RicaricaDati As Boolean = False
                If dg.SelectedRows.Count Then
                    Dim O As Ordine = dg.SelectedRows(0).DataBoundItem
                    If MgrOrdini.ModificaDatiEconomici(O, Me) Then
                        RicaricaDati = True
                    End If
                End If

                If RicaricaDati Then
                    CaricaOrdini()
                    CaricaOrdiniInclusiConsegna()
                    CaricaOrdiniUscitiMagazzino()
                    CalcolaTotali()
                End If

            Else
                MessageBox.Show("Consegna non modificabile: " & Ris.BufferErrori)
            End If

        End If
    End Sub
End Class