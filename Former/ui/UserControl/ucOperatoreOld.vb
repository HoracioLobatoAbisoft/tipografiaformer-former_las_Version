Imports FormerDALSql
Imports FormerLib.FormerEnum
Imports FormerLib
Imports System.IO
Imports FormerBusiness
Imports FormerInterop

Public Class ucOperatoreOld
    Inherits ucFormerUserControl
    Private _Giorno As Date = Date.Now
    Public Sub Carica()
        Try
            'FormerDebug.Traccia("CARICAMENTO INIZIALE")
            PrepVociOperatore()
            'CaricaStampa()
            CaricaReparti()
            CaricaCombo()

            If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then

                btnForzaChiusuraCons.Enabled = True
                btnForzaChiusuraCons.Visible = True
                ' ImpostaWatcher()
            Else
                btnAvanzaSenzaStampa.Visible = True
                btnAvanzaSenzaStampa.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaCombo()

        Using mgr As New ZoneDAO
            Dim lst As List(Of Zona) = mgr.GetAll("Descrizione", True)
            cmbZona.DisplayMember = "Descrizione"
            cmbZona.ValueMember = "Id"
            cmbZona.DataSource = lst
        End Using

        '    Dim lst As List(Of VoceRubrica) = (New VociRubricaDAO).ListaCombo(enTipoRubrica.Tutto, True, "AlberoOperatoreConsegna")
        '    cmbCliente.DisplayMember = "Nominativo"
        '    cmbCliente.ValueMember = "IdRub"
        '    cmbCliente.DataSource = lst

    End Sub

    'Private Sub CaricaCombo()
    '    'carico la combo dei clienti con solo quelli che hanno almeno un ordine nello stato da preinserito a prontoritiro
    '    Dim lst As List(Of VoceRubrica) = (New VociRubricaDAO).ListaCombo(enTipoRubrica.Tutto, True, "AlberoOperatoreConsegna")
    '    cmbCliente.DisplayMember = "Nominativo"
    '    cmbCliente.ValueMember = "IdRub"
    '    cmbCliente.DataSource = lst
    'End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

        lblLegRC.BackColor = FormerColori.ColoreCorriereRitiroCliente
        lblLegTF.BackColor = FormerColori.ColoreCorriereTipografiaFormer
        lblLegAC.BackColor = FormerColori.ColoreCorriereAltro
        lblLegACCodTrack.BackColor = FormerColori.ColoreCorriereAltro

    End Sub

    Private Sub CaricaReparti()

        TabOperatore.TabPages.Remove(tpStampaDigitale)

        If PostazioneCorrente.UtenteConnesso.Tipo <> enTipoUtente.Admin Then

            Using M As New UtRepDAO
                Dim L As List(Of UtRep) = M.FindAll(New LUNA.LunaSearchParameter("IdUt", PostazioneCorrente.UtenteConnesso.IdUt))

                TabOperatore.TabPages.Clear()

                For Each R As UtRep In L

                    Select Case R.IdRep
                        Case enRepartoOperatore.StampaOffset
                            TabOperatore.TabPages.Add(tpStampa)
                        Case enRepartoOperatore.ImballaggioCorriere
                            TabOperatore.TabPages.Add(tpImballaggioCorriere)
                        Case enRepartoOperatore.Imballaggio
                            TabOperatore.TabPages.Add(tpImballaggio)
                        Case enRepartoOperatore.FinituraSuProdotto
                            TabOperatore.TabPages.Add(tpFinitProd)
                        Case enRepartoOperatore.FinituraSuCommessa
                            TabOperatore.TabPages.Add(tpFinitCom)
                        Case enRepartoOperatore.Consegne
                            TabOperatore.TabPages.Add(tpConsegne)
                    End Select

                Next

                Select Case PostazioneCorrente.UtenteConnesso.RepDefault
                    Case enRepartoOperatore.StampaOffset
                        TabOperatore.SelectedTab = tpStampa
                    Case enRepartoOperatore.ImballaggioCorriere
                        TabOperatore.SelectedTab = tpImballaggioCorriere
                    Case enRepartoOperatore.Imballaggio
                        TabOperatore.SelectedTab = tpImballaggio
                    Case enRepartoOperatore.FinituraSuProdotto
                        TabOperatore.SelectedTab = tpFinitProd
                    Case enRepartoOperatore.FinituraSuCommessa
                        TabOperatore.SelectedTab = tpFinitCom
                    Case enRepartoOperatore.Consegne
                        TabOperatore.SelectedTab = tpConsegne
                End Select

                CaricaDati() 'carico i dati aperti di default

            End Using
        End If

    End Sub

    Private Sub PrepVociOperatore()
        UcCommesseAnteprimaOp.WebPrew.Navigate("about:blank")
    End Sub

    Private Sub CaricaStampaDigitale()
        Try
            Cursor = Cursors.WaitCursor
            PrepVociOperatore()




            Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CaricaStampa()
        Try
            Cursor = Cursors.WaitCursor
            PrepVociOperatore()
            Using cMgr As New CommesseDAO

                DgCommesse.AutoGenerateColumns = False

                If chkWithImg.Checked Then
                    Dim Lst As List(Of CommessaOperatore) = cMgr.ListaOPStampa()
                    DgCommesse.DataSource = Lst
                Else
                    Dim Lst As List(Of CommessaOperatoreNoImg) = cMgr.ListaOPStampaNoImg()
                    DgCommesse.DataSource = Lst
                End If

                Cursor = Cursors.Default
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CaricaFinituraSuCommessa()

        Cursor = Cursors.WaitCursor

        PrepVociOperatore()

        Using cMgr As New LavLogDAO
            Dim Lst As List(Of LavLog) = cMgr.ElencoFinituraCommessa
            DgFinitCom.AutoGenerateColumns = False
            DgFinitCom.DataSource = Lst
        End Using

        Cursor = Cursors.Default

    End Sub
    'Private Sub btnFinituraProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CaricaFsProd()
    'End Sub
    Private Sub CaricaFinituraSuProdotti()

        Cursor = Cursors.WaitCursor
        PrepVociOperatore()
        Using cMgr As New LavLogDAO
            Dim Lst As List(Of LavLog) = cMgr.ElencoFinituraOrdine
            DgFinitProd.AutoGenerateColumns = False
            DgFinitProd.DataSource = Lst
            'Try

            'Catch ex As Exception

            'End Try
        End Using
        Cursor = Cursors.Default
    End Sub
    'Private Sub btnSped_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CaricaImballaggio()
    'End Sub

    Private _CorrSelConsegnaMerci As Integer = enCorriere.RitiroCliente

    Private Sub CaricaConsegnaMerciRitCli()

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Registrato & "," &
                                enStatoOrdine.InCodaDiStampa & "," &
                                enStatoOrdine.StampaInizio & "," &
                                enStatoOrdine.StampaFine & "," &
                                enStatoOrdine.FinituraCommessaInizio & "," &
                                enStatoOrdine.FinituraCommessaFine & "," &
                                enStatoOrdine.FinituraProdottoInizio & "," &
                                enStatoOrdine.FinituraProdottoFine & "," &
                                enStatoOrdine.Imballaggio & "," &
                                enStatoOrdine.ImballaggioCorriere & "," &
                                enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _
            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, _CorrSelConsegnaMerci, , , ListaStati, , , , , )
            LstM.Sort(AddressOf ComparerConsM)
            tvwConsegnaMerci.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM

                Dim checkOk As Boolean = True

                If chkSoloConsegnabili.Checked Then
                    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                        checkOk = False
                    End If
                End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then
                    Dim ChiaveRubrica As String = "R" & c.IdRub
                    Dim NodoRub As TreeNode = tvwConsegnaMerci.Nodes(ChiaveRubrica)
                    If NodoRub Is Nothing Then

                        Dim DescrRub As String = c.RagSoc

                        NodoRub = tvwConsegnaMerci.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If

                    Dim ChiaveData As String = "S" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                    Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = NodoRub.Nodes.Add(ChiaveData, "Consegna del " & c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        'NodoCorr.Expand()
                    End If

                    'Dim DescrInd As String = c.Cliente.IndirizzoPredefinito

                    'If c.IdIndirizzo Then
                    '    'qui devo calcolare l'indirizzo
                    '    Dim I As New Indirizzo
                    '    I.Read(c.IdIndirizzo)
                    '    DescrInd = I.Riassunto
                    '    I = Nothing
                    'End If

                    'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                    'Dim nodoInd As TreeNode = NodoData.Nodes(ChiaveInd)
                    'If nodoInd Is Nothing Then
                    '    nodoInd = NodoData.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                    'End If

                    Dim ChiaveOrdine As String = "O" & c.IdOrd

                    Dim Icona As Integer = 1

                    Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                    nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                    nodoOrd.Tag = c
                    If c.Giorno.Date = Now.Date Then NodoData.Expand()
                    NodoData.Expand()
                    'NodoRub.Expand()
                End If


            Next
        End Using
    End Sub

    Private Sub CaricaConsegnaMerciTipFormer()

        Using mgr As New ConsegneRicercaDAO

            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Registrato & "," &
                                enStatoOrdine.InCodaDiStampa & "," &
                                enStatoOrdine.StampaInizio & "," &
                                enStatoOrdine.StampaFine & "," &
                                enStatoOrdine.FinituraCommessaInizio & "," &
                                enStatoOrdine.FinituraCommessaFine & "," &
                                enStatoOrdine.FinituraProdottoInizio & "," &
                                enStatoOrdine.FinituraProdottoFine & "," &
                                enStatoOrdine.Imballaggio & "," &
                                enStatoOrdine.ImballaggioCorriere & "," &
                                enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _
            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, _CorrSelConsegnaMerci, , , ListaStati)

            Dim VisualizzaPerCliente As Boolean = False
            If rdoAlberoCliente.Checked Then
                VisualizzaPerCliente = True
            End If

            If VisualizzaPerCliente = False Then
                LstM.Sort(AddressOf Comparer)
            Else
                LstM.Sort(AddressOf ComparerCli)
            End If

            tvwConsegnaMerci.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim checkOk As Boolean = True

                If chkSoloConsegnabili.Checked Then
                    If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                        checkOk = False
                    End If
                End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    If VisualizzaPerCliente Then

                        Dim ChiaveRubrica As String = "R" & c.IdRub
                        Dim NodoRub As TreeNode = tvwConsegnaMerci.Nodes(ChiaveRubrica)
                        If NodoRub Is Nothing Then

                            Dim DescrRub As String = c.RagSoc

                            NodoRub = tvwConsegnaMerci.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        Dim ChiaveData As String = "S" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        Dim NodoData As TreeNode = NodoRub.Nodes(ChiaveData)
                        If NodoData Is Nothing Then
                            NodoData = NodoRub.Nodes.Add(ChiaveData, "Consegna del " & c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                            'NodoCorr.Expand()
                        End If

                        'Dim DescrInd As String = c.Cliente.IndirizzoPredefinito

                        'If c.IdIndirizzo Then
                        '    'qui devo calcolare l'indirizzo
                        '    Dim I As New Indirizzo
                        '    I.Read(c.IdIndirizzo)
                        '    DescrInd = I.Riassunto
                        '    I = Nothing
                        'End If

                        'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        'Dim nodoInd As TreeNode = NodoData.Nodes(ChiaveInd)
                        'If nodoInd Is Nothing Then
                        '    nodoInd = NodoData.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                        'End If

                        Dim ChiaveOrdine As String = "O" & c.IdOrd

                        Dim Icona As Integer = 1

                        Dim nodoOrd As TreeNode = NodoData.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        NodoData.Expand()
                        'NodoRub.Expand()
                    Else

                        Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                        Dim NodoData As TreeNode = tvwConsegnaMerci.Nodes(ChiaveData)
                        If NodoData Is Nothing Then
                            NodoData = tvwConsegnaMerci.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                            'NodoCorr.Expand()
                        End If

                        Dim ChiaveDataMat As String = "D" & c.Giorno.ToString("ddMMyyyy") & "M"
                        Dim ChiaveDataPom As String = "D" & c.Giorno.ToString("ddMMyyyy") & "P"

                        Dim NodoMomRif As TreeNode = Nothing
                        Dim ChiaveRubrica As String = "S" & c.IdCons
                        Dim ChiaveOrdine As String = "O" & c.IdOrd
                        Dim ChiaveMomRif As String = String.Empty
                        Dim DescrNodoMomRif As String = String.Empty

                        If c.MatPom = enMomentoConsegna.Mattina Then
                            NodoMomRif = NodoData.Nodes(ChiaveDataMat)
                            DescrNodoMomRif = "Mattina"
                            ChiaveMomRif = ChiaveDataMat
                        Else
                            NodoMomRif = NodoData.Nodes(ChiaveDataPom)
                            DescrNodoMomRif = "Pomeriggio"
                            ChiaveMomRif = ChiaveDataPom
                        End If
                        If NodoMomRif Is Nothing Then
                            NodoMomRif = NodoData.Nodes.Add(ChiaveMomRif, DescrNodoMomRif.ToUpper, 11, 11)
                        End If

                        Dim NodoRub As TreeNode = NodoMomRif.Nodes(ChiaveRubrica)

                        Dim DescrInd As String = c.Cliente.IndirizzoRegistrazione

                        If c.IdIndirizzo Then
                            'qui devo calcolare l'indirizzo
                            Dim I As New Indirizzo
                            I.Read(c.IdIndirizzo)
                            DescrInd = I.Riassunto
                            I = Nothing
                        End If

                        If NodoRub Is Nothing Then

                            Dim DescrRub As String = c.RagSoc & " (" & DescrInd & ")"

                            NodoRub = NodoMomRif.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                            'NodoRub.Expand()
                            'NodoRub.EnsureVisible()
                        End If

                        'Dim ChiaveInd As String = "I" & c.IdCons 'Giorno.ToString("ddMMyyyy")
                        'Dim nodoInd As TreeNode = NodoRub.Nodes(ChiaveInd)
                        'If nodoInd Is Nothing Then
                        '    nodoInd = NodoRub.Nodes.Add("I" & c.IdCons, DescrInd, 12, 12)
                        'End If

                        Dim Icona As Integer = 1

                        Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                        nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                        nodoOrd.Tag = c
                        If c.Giorno.Date = Now.Date Then NodoData.Expand()
                        NodoMomRif.Expand()
                        'NodoRub.Expand()

                    End If

                End If

            Next
        End Using
    End Sub

    Private Sub CaricaConsegnaMerci()
        Cursor = Cursors.WaitCursor

        Select Case _CorrSelConsegnaMerci
            Case enCorriere.RitiroCliente
                'lblCorrConsScelto.Text = "Ritiro Cliente"
                lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Bold)
                lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Regular)
                lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereRitiroCliente
                CaricaConsegnaMerciRitCli()
            Case enCorriere.TipografiaFormer
                'lblCorrConsScelto.Text = "Tipografia Former"
                lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Regular)
                lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Bold)
                lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereTipografiaFormer
                CaricaConsegnaMerciTipFormer()
            Case enCorriere.AltroCorriere
                'lblCorrConsScelto.Text = "Altro Corriere"
                lblLegRC.Font = New Font(lblLegRC.Font, FontStyle.Regular)
                lblLegTF.Font = New Font(lblLegTF.Font, FontStyle.Regular)
                If _AltroCorrCodTrack = False Then
                    lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Bold)
                    lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Regular)
                Else
                    lblLegAC.Font = New Font(lblLegAC.Font, FontStyle.Regular)
                    lblLegACCodTrack.Font = New Font(lblLegACCodTrack.Font, FontStyle.Bold)
                End If
                lblCorrConsScelto.BackColor = FormerColori.ColoreCorriereAltro
                CaricaConsMerciAltroCorr(, , , tvwConsegnaMerci)
        End Select

        Cursor = Cursors.Default
    End Sub

    Private Sub CaricaImballaggio()

        Cursor = Cursors.WaitCursor
        PrepVociOperatore()

        Using mgr As New OrdiniDAO
            Dim l As List(Of Ordine) = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Imballaggio))

            'TODO: EVENTUALE FILTRAGGIO SU GLS ANCHE PER LA SCHEDA "IMBALLO"; PER ORA LASCIO COMMENTATO PERCHE'
            'IN QUESTO CASO VIENE VERIFICATO IL CORRIERE SUGLI ORDINI ANZICHE' SULLA CONSEGNA E NON SO SE E' CORRETTO
            '(HO NOTATO CHE SE VIENE CAMBIATO CORRIERE ALLA CONSEGNA, GLI ORDINI RESTANO CON IL CORRIERE ORIGINALE)
            'Dim l As List(Of Ordine) = Nothing
            'If chkSoloGlsImballo.Checked Then
            '    l = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Imballaggio), _
            '                    New LUNA.LunaSearchParameter("IdCorriere", "(" & enCorriere.GLS & ", " & enCorriere.PortoAssegnatoGLS & ")", "IN"))
            'Else
            '    l = mgr.FindAll("IdOrd", New LUNA.LunaSearchParameter("Stato", enStatoOrdine.Imballaggio))
            'End If

            DgImballoEx.AutoGenerateColumns = False
            DgImballoEx.DataSource = l

        End Using

        'Dim Dt As DataTable, x As New cOrdiniColl
        'Dt = x.ListaDaLav(enStatoOrdine.Imballaggio)
        'DgImballaggio.DataSource = Dt
        'DgImballaggio.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgImballaggio.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgImballaggio.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Cursor = Cursors.Default
    End Sub

    Private Sub CaricaImballaggioCorriere()
        Cursor = Cursors.WaitCursor
        PrepVociOperatore()
        CaricaConsMerciAltroCorr()

        Cursor = Cursors.Default
    End Sub

    Private _lstConsegne As List(Of ConsegnaProgrammata) = Nothing
    Private _IdCorr As Integer = 0

    Private Sub CaricaConsMerciAltroCorr(Optional ByVal Iniziale As String = "",
                          Optional ByVal IdRub As Integer = 0,
                          Optional ByVal TestoLibero As String = "",
                          Optional ByRef TvwRif As TreeView = Nothing)

        If TvwRif Is Nothing Then
            TvwRif = tvClienti
        End If

        btnBordero.Visible = False

        ' Dim IdCorrString As String = "(" & UcFiltroCorriereImballoCorriere.CorriereSelezionato & ")"
        _IdCorr = UcFiltroCorriereImballoCorriere.CorriereSelezionatoEnum

        Using mgr As New ConsegneProgrammateDAO
            _lstConsegne = mgr.FindAll(New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InConsegna),
                                         New LUNA.LunaSearchParameter("Eliminato", enSiNo.No),
                                         New LUNA.LunaSearchParameter("CodTrack", String.Empty, "<>"),
                                         New LUNA.LunaSearchParameter("DataTrasmissioneCorriere", Now.Date))
        End Using

        If _lstConsegne.Count Then
            btnBordero.Visible = True
        End If


        Dim Corriere As String = String.Empty

        'Dim SoloGls As Boolean = chkSoloGlsImballoCorr.Checked

        Dim FiltroCorriere As String = UcFiltroCorriereConsegne.CorriereSelezionato

        Using mgr As New ConsegneRicercaDAO
            Dim LstM As New List(Of ConsegnaRicerca)
            Dim ListaStati As String = enStatoOrdine.Registrato & "," &
                                enStatoOrdine.InCodaDiStampa & "," &
                                enStatoOrdine.StampaInizio & "," &
                                enStatoOrdine.StampaFine & "," &
                                enStatoOrdine.FinituraCommessaInizio & "," &
                                enStatoOrdine.FinituraCommessaFine & "," &
                                enStatoOrdine.FinituraProdottoInizio & "," &
                                enStatoOrdine.FinituraProdottoFine & "," &
                                enStatoOrdine.Imballaggio & "," &
                                enStatoOrdine.ImballaggioCorriere & "," &
                                enStatoOrdine.ProntoRitiro  '& "," & _'& "," & _
            'enStatoOrdine.ProntoRitiro()
            LstM = mgr.Lista(-1, 0, , , ListaStati, , , Iniziale, TestoLibero, CInt(enCorriere.RitiroCliente) & "," & CInt(enCorriere.TipografiaFormer) & "," & CInt(enCorriere.TipografiaFormerFuoriRaccordo), , , , , , FiltroCorriere)
            LstM.Sort(AddressOf Comparer)
            TvwRif.Nodes.Clear()

            For Each c As ConsegnaRicerca In LstM
                Dim checkOk As Boolean = True

                If TabOperatore.SelectedTab Is tpConsegne Then
                    If chkSoloConsegnabili.Checked Then
                        If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                            checkOk = False
                        End If
                        If _AltroCorrCodTrack = False Then
                            If c.CodTrack = String.Empty Then
                                checkOk = False
                            End If
                        Else
                            If c.CodTrack <> String.Empty Then
                                checkOk = False
                            End If
                        End If
                    Else
                        If _AltroCorrCodTrack Then
                            If c.CodTrack <> String.Empty Then
                                checkOk = False
                            End If
                        End If
                    End If
                End If

                If TabOperatore.SelectedTab Is tpImballaggioCorriere Then
                    If chkSoloProntiRitiroCorr.Checked Then
                        If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count = 0 Then
                            checkOk = False
                        End If
                    End If
                End If

                If TabOperatore.SelectedTab Is tpImballaggioCorriere Then
                    If chkSoloDaImballCorr.Checked Then
                        If c.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ImballaggioCorriere).Count = 0 Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then
                    If cmbZona.SelectedValue Then
                        If c.Cliente.IdZona <> cmbZona.SelectedValue Then
                            checkOk = False
                        End If
                    End If
                End If

                If checkOk Then

                    Dim ChiaveData As String = "D" & c.Giorno.ToString("ddMMyyyy")
                    Dim NodoData As TreeNode = TvwRif.Nodes(ChiaveData)
                    If NodoData Is Nothing Then
                        NodoData = TvwRif.Nodes.Add(ChiaveData, c.Giorno.ToString("dd MMMM yyyy"), 7, 7)
                        'NodoCorr.Expand()
                    End If
                    Dim ChiaveCorriere As String = "C" & c.IdCorr
                    Dim ChiaveRubrica As String = "S" & c.IdCons
                    Dim ChiaveOrdine As String = "O" & c.IdOrd

                    Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
                    If NodoCorr Is Nothing Then
                        NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereNome, 6, 6)
                        'NodoCorr.Expand()
                    End If
                    Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
                    If NodoRub Is Nothing Then

                        Dim DescrRub As String = c.RagSoc

                        Dim DescrInd As String = " (" & c.Cliente.IndirizzoRegistrazione & ")"

                        If c.IdIndirizzo Then
                            'qui devo calcolare l'indirizzo
                            Dim I As New Indirizzo
                            I.Read(c.IdIndirizzo)
                            DescrInd = " (" & I.Riassunto & ")"
                            I = Nothing
                        End If

                        DescrRub &= DescrInd

                        NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, DescrRub, 0, 0)
                        'NodoRub.Expand()
                        'NodoRub.EnsureVisible()
                    End If
                    Dim Icona As Integer = 9

                    If c.Inserito Then Icona = 8

                    Dim nodoOrd As TreeNode = NodoRub.Nodes.Add("O" & c.IdOrd, "Ord." & c.IdOrd & " - " & c.ProdottoNome, Icona, Icona)
                    nodoOrd.BackColor = FormerColori.GetColoreStatoOrdine(c.StatoOrdine)
                    nodoOrd.Tag = c
                    If c.Giorno.Date = Now.Date Then NodoData.Expand()
                    NodoCorr.Expand()
                    'NodoRub.Expand()
                End If

            Next
        End Using
    End Sub

    Private Function ComparerConsM(ByVal x As ConsegnaRicerca,
                                   ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
        If result = 0 Then result = x.Giorno.CompareTo(y.Giorno)

        Return result
    End Function

    Private Function Comparer(ByVal x As ConsegnaRicerca, ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Giorno.CompareTo(y.Giorno)
        If result = 0 Then
            result = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
            If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)
        End If
        Return result
    End Function

    Private Function ComparerCli(ByVal x As ConsegnaRicerca,
                                 ByVal y As ConsegnaRicerca) As Integer
        Dim result As Integer = x.Cliente.RagSocNome.CompareTo(y.Cliente.RagSocNome)
        If result = 0 Then result = x.Inserito.CompareTo(y.Inserito)
        Return result
    End Function

    'Private Function NumColliDaSoluzione(IdOrd As Integer) As Integer

    '    Dim ris As Integer = 0

    '    Dim f As New frmImballo
    '    Sottofondo(Me.ParentForm)
    '    ris = f.Carica(IdOrd)
    '    Sottofondo(Me.ParentForm)
    '    f = Nothing

    '    Return ris

    'End Function

    Private Sub StampaEtichette(Optional StampaEffettiva As Boolean = True)

        Dim MessaggioOperat As String = "Vuoi stampare le etichette per l'ordine selezionato?"

        If StampaEffettiva = False Then
            MessaggioOperat = "Vuoi portare avanti l'ordine senza stampare le etichette?"
        End If

        Dim IdOrd As Integer = 0
        If DgImballoEx.SelectedRows.Count Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            IdOrd = O.IdOrd

            If PostazioneCorrente.StampanteEtichette.Length Then
                Dim PassatoPerSoluzione As Boolean = False
                Dim DovevaPassarePerSoluzione As Boolean = False
                If MessageBox.Show(MessaggioOperat, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim Peso As Single = O.Prodotto.PesoComplessivo
                    Dim NumColli As Integer = 0

                    If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then

                        If O.IdListinoBase Then

                            Dim Altezza As Single = O.ListinoBase.FormatoProdotto.FormatoCarta.Altezza + 3
                            Dim Larghezza As Single = O.ListinoBase.FormatoProdotto.FormatoCarta.Larghezza + 3
                            Dim Profondita As Single = O.ListinoBase.TipoCarta.CalcolaSpessoreCM(O.Prodotto.NumPezzi)

                            Dim SingPeso As Single = 0
                            If O.ListinoBase.Preventivazione.IdReparto <> enRepartoWeb.StampaOffset Then
                                If O.ListinoBase.IdModelloCubetto Then
                                    Using M As New ModelloCubetto
                                        M.Read(O.ListinoBase.IdModelloCubetto)
                                        Altezza = M.Lunghezza / 10
                                        Larghezza = M.Larghezza / 10
                                        Profondita = M.Profondita / 10
                                    End Using

                                    SingPeso = MgrCorriere.CalcolaPesoVolumetrico(Altezza,
                                                                                  Larghezza,
                                                                                  Profondita)
                                    SingPeso = SingPeso * O.NumeroRealeColli
                                End If
                            End If

                            If SingPeso = 0 Then SingPeso = MgrCorriere.CalcolaPesoVolumetrico(Altezza,
                                                                                               Larghezza,
                                                                                               Profondita)

                            Dim PesoVolumetrico As Single = SingPeso

                            If PesoVolumetrico > Peso Then Peso = PesoVolumetrico

                            If O.ConsegnaAssociata.ListaOrdini.Count = 1 Or Peso > FormerConst.Massimali.MaxPesoSingoloOrdineInImballaggio Then
                                DovevaPassarePerSoluzione = True
                                If O.ListinoBase.IdModelloCubetto Then
                                    NumColli = MgrImballo.NumColliDaSoluzione(O.IdOrd, Me.ParentForm)
                                    'If NumColli > -1 Then
                                    PassatoPerSoluzione = True
                                    'End If
                                End If
                            End If

                        End If

                    End If

                    If NumColli = 0 Then

                        NumColli = O.NumeroColliCalcolati
                        'Dim Msg As String = "Inserire il numero di colli reali dell'ordine"
                        'NumColliUtente = InputBox(Msg, "Stampa etichette Ordine", NumColli)

                        Sottofondo(Me.ParentForm)
                        Using x As New frmNumColli
                            x.Carica(IdOrd, NumColli)
                            NumColli = x.NumColli
                        End Using
                        Sottofondo(Me.ParentForm)

                        PassatoPerSoluzione = False

                    End If

                    If Peso = 0 Then
                        Dim PesoUtente As String = InputBox("Inserisci il peso approssimativo dei colli in Kg", "Stampa etichette Ordine", 0)
                        If IsNumeric(PesoUtente) Then
                            'se il peso e' valido lo salvo come default
                            O.Prodotto.PesoComplessivo = PesoUtente
                            O.Prodotto.Save()
                        End If
                    End If


                    'If NumColli > 0 Then
                    If NumColli Then
                        O.NumeroRealeColli = NumColli
                        O.Save()

                        If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then

                            Using mgr As New ConsProgrOrdiniDAO

                                Dim cp As ConsProgrOrdini = mgr.Find(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd))
                                If Not cp Is Nothing Then
                                    cp.Inserito = enSiNo.Si
                                    cp.Save()

                                End If
                                cp = Nothing

                                'Dim l As List(Of ConsProgrOrdini) = mgr.FindAll(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd))
                                'If l.Count Then
                                '    l(0).Inserito = True
                                '    l(0).Save()
                                'End If

                            End Using

                        End If

                        If StampaEffettiva Then
                            Dim x As New myPrinter

                            x.PrinterName = PostazioneCorrente.StampanteEtichette
                            x.IdOrd = IdOrd
                            x.NumColli = NumColli
                            Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteOrdine)
                            t.Start()

                            x = Nothing
                        End If

                        Dim Prossimostato As enStatoOrdine
                        If (O.ConsegnaAssociata.IdCorr = enCorriere.TipografiaFormer _
                            Or O.ConsegnaAssociata.IdCorr = enCorriere.TipografiaFormerFuoriRaccordo _
                            Or O.ConsegnaAssociata.IdCorr = enCorriere.RitiroCliente) Then
                            Prossimostato = enStatoOrdine.ProntoRitiro
                        Else
                            'qui va in imballaggio corriere
                            Prossimostato = enStatoOrdine.ImballaggioCorriere
                        End If

                        Using OMgr As New OrdiniDAO
                            OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrd, Prossimostato)
                        End Using

                        'If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then 'qui lo porto avanti se doveva passare per la soluizione anche se poio non ci e' passato
                        '    Using OMgr As New OrdiniDAO
                        '        OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrd, enStatoOrdine.ProntoRitiro)
                        '    End Using
                        'End If

                        'qui devo vedere se posso accorpare l'ordine
                        Dim TrovataConsegnaDaAccorpare As Boolean = False
                        Using mgr As New ConsegneProgrammateDAO

                            Dim IdOldCons As Integer = O.ConsegnaAssociata.IdCons
                            Dim IdCorr As Integer = O.ConsegnaAssociata.IdCorr
                            Dim IdRub As Integer = O.IdRub
                            Dim IdInd As Integer = O.ConsegnaAssociata.IdIndirizzo

                            Dim l As List(Of ConsegnaProgrammata) = mgr.FindAll(New LUNA.LunaSearchParameter("IdCons", O.ConsegnaAssociata.IdCons, "<>"),
                                                                                New LUNA.LunaSearchParameter("IdCorr", O.ConsegnaAssociata.IdCorr),
                                                                                New LUNA.LunaSearchParameter("IdRub", O.ConsegnaAssociata.IdRub),
                                                                                New LUNA.LunaSearchParameter("IdIndirizzo", O.ConsegnaAssociata.IdIndirizzo),
                                                                                New LUNA.LunaSearchParameter("Eliminato", enSiNo.Si, "<>"),
                                                                                New LUNA.LunaSearchParameter("IdStatoConsegna", enStatoConsegna.InLavorazione),
                                                                                New LUNA.LunaSearchParameter("Giorno", Date.Now.AddDays(-1), ">"),
                                                                                New LUNA.LunaSearchParameter("Giorno", O.ConsegnaAssociata.Giorno, "<"))
                            For Each singC As ConsegnaProgrammata In l
                                If singC.Modificabile(True) Then
                                    'TOLTO IL 08/04/2015
                                    'mgr.EliminaOrdineDaConsegna(IdOldCons, O.IdOrd)
                                    mgr.RegistraConsegnaOrdineSuGiorno(O.IdOrd, IdCorr, singC.Giorno, IdRub, enMomentoConsegna.Pomeriggio, IdInd, singC)
                                    'TOLTO IL 08/04/2015
                                    'mgr.EliminaConsegnaSeVuota(IdOldCons)
                                    TrovataConsegnaDaAccorpare = True
                                    Exit For
                                End If
                            Next

                        End Using

                        O.SvuotaConsegnaAssociata()

                        If TrovataConsegnaDaAccorpare = False Then O.ConsegnaAssociata.AggiornaColliPeso()
                        'O.ConsegnaAssociata.ListaOrdini = Nothing


                        'If DovevaPassarePerSoluzione = True And PassatoPerSoluzione = True Then
                        '    If Prossimostato = enStatoOrdine.ImballaggioCorriere And (O.ConsegnaAssociata.IdCorr = enCorriere.GLS Or O.ConsegnaAssociata.IdCorr = enCorriere.PortoAssegnatoGLS) Then
                        '        Cursor.Current = Cursors.WaitCursor
                        '        Try
                        '            cGls.PrenotaSpedizioneGls(O.ConsegnaAssociata)
                        '            'TODO: QUESTO SALVATAGGIO MI PARE INDISPENSABILE; ALTRIMENTI LA CONSEGNA NON VIENE SALVATA DA ALTRE PARTI
                        '            O.ConsegnaAssociata.Save()
                        '        Catch ex As Exception
                        '            '    'TODO: SE VA IN ERRORE (AD ESEMPIO PERCHE' NON C'E' CONNESSIONE AD INTERNET), MANDA FUORI MESSAGGIO ERRORE
                        '            '    'MA ORMAI LA CONSEGNA E' STATA AVANZATA E NON E' PIU' POSSIBILE, LATO OPERATORE, GENERARE L'ETICHETTA GLS;
                        '            '    'BISOGNA PER FORZA FARLO LATO ADMIN
                        '            Using m As New Messaggio
                        '                m.DataIns = Now
                        '                m.Titolo = "Registrazione Consegna su GLS Fallita: " & O.ConsegnaAssociata.IdCons
                        '                m.Testo = "La registrazione della consegna numero " & O.ConsegnaAssociata.IdCons & " su GLS è fallita:" & vbCrLf & ex.Message & vbCrLf & "La registrazione della spedizione deve essere fatta manualmente."
                        '                m.IdMitt = 0
                        '                m.IdDest = FormerConst.UtentiSpecifici.IdUtenteLidia
                        '                m.Save()
                        '            End Using
                        '            MessageBox.Show("Si è verificato un errore nella creazione del segnacollo di GLS:" & vbCrLf & ex.Message & vbCrLf & "Il segnacollo deve essere generato manualmente")
                        '        End Try
                        '        Cursor.Current = Cursors.Default
                        '    End If
                        'End If

                        If O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo Then
                            If (O.ConsegnaAssociata.ListaOrdini.FindAll(Function(y) y.Stato < enStatoOrdine.ImballaggioCorriere).Count = 0) Then 'And O.ConsegnaAssociata.ListaOrdini.Count > 1) Then 'COMMENTATO 10 MARZO 2014 PER FAR PASSARE SEMPRE 

                                Sottofondo(Me.ParentForm)
                                Dim fr As New frmRiepilogoConsegna
                                fr.Carica(O.ConsegnaAssociata.IdCons)
                                fr = Nothing
                                Sottofondo(Me.ParentForm)

                            End If
                        End If
                        CaricaImballaggio()
                    End If
                End If
            Else
                MessageBox.Show("Selezionare prima la stampante da usare per la stampa etichette!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub btnStampaEtich_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStampaEtich.Click

        Dim IdOrd As Integer = 0
        If DgImballoEx.SelectedRows.Count Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)

            Dim StampaEffettiva As Boolean = FormerException.StampareEtichetteOrdine(O)

            StampaEtichette(StampaEffettiva)
        Else
            Beep()
        End If



    End Sub

    'Private Sub btnStampaEtichAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStampaEtichAll.Click

    '    If Postazione.StampanteEtichette.Length Then


    '        If MessageBox.Show("Vuoi stampare tutte le etichette degli ordini in stato imballaggio?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '            Dim x As New myPrinter

    '            x.PrinterName = Postazione.StampanteEtichette

    '            Dim Dr As DataGridViewRow

    '            For Each Dr In DgCommesse.Rows
    '                Dim IdOrdSel As Integer = Dr.Cells(0).Value
    '                x.StampaEtichetteOrdine(IdOrdSel)
    '            Next


    '            x = Nothing

    '            MessageBox.Show("Le etichette sono state stampate correttamente!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        End If
    '    Else
    '        MessageBox.Show("Selezionare prima la stampante da usare per la stampa etichette!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End If
    'End Sub

    'Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

    '    If _OpIdRel Then

    '        If _OpStatoSel = enStatoCommessa.Completata Then

    '            Select Case _OpStatoOrdine
    '                Case enStatoOrdine.Imballaggio
    '                    If MessageBox.Show("Vuoi passare l'ordine selezionato allo stato di pronto per la consegna?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '                        Dim Ord As New cOrdiniColl
    '                        Ord.AvanzaOrdiniAStatoByIdOrd(_OpIdRel, enStatoOrdine.ProntoRitiro)
    '                        CaricaCommesse()

    '                    End If

    '                Case enStatoOrdine.ProntoRitiro
    '                    'qui devo emettere il documento 

    '                    Sottofondo(Me.ParentForm)
    '                    Dim x As New frmConsegna
    '                    If x.Carica() Then CaricaCommesse()
    '                    x = Nothing
    '                    Sottofondo(Me.ParentForm)


    '                    'If MessageBox.Show("Vuoi passare l'ordine selezionato allo stato di consegnato?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

    '                    '    Dim Ord As New cOrdiniColl
    '                    '    Ord.AvanzaOrdiniAStatoByIdOrd(_OpIdRel, enStatoOrdine.Consegnato)
    '                    '    CaricaCommesse()

    '                    'End If

    '            End Select

    '        Else
    '            'qui devo solamente riaprire il lavoro

    '            Dim IdCrono As Integer = 0, IdLavLog As Integer = 0

    '            Sottofondo(Me.ParentForm)
    '            Dim x As New frmOperatore

    '            Dim Risultato As Integer
    '            Risultato = x.Carica(_OpIdRel, _OpTipoOggCaricatoComm, _OpStatoSel)
    '            'Risultato = x.CaricaByCrono(IdCrono, IdLavLog, DgCommesse.DataSource)

    '            x = Nothing
    '            Sottofondo(Me.ParentForm)

    '            If Risultato Then
    '                FormPrincipale.CalcolaBonus()
    '                CaricaCommesse()

    '            End If

    '        End If

    '    End If
    'End Sub

    Private Sub DgCommesse_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgCommesse.CellClick
        Dim c As CommessaOperatore = DgCommesse.SelectedRows(0).DataBoundItem
        CreaAnteprima(c.IdCom)
    End Sub

    Private Sub DgFinitCom_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgFinitCom.CellClick
        Dim c As LavLog = DgFinitCom.SelectedRows(0).DataBoundItem
        CreaAnteprima(c.IdCom)
    End Sub

    Private Sub CreaAnteprima(Optional IdCom As Integer = 0, Optional IdOrd As Integer = 0)

        Cursor.Current = Cursors.WaitCursor

        If IdCom Then
            Dim Com As New Commessa
            Com.Read(IdCom)

            CreaRiepilogoCom(Com, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Com = Nothing
            UcCommesseAnteprimaOp.CaricaMessaggi(, IdCom)
        Else
            Dim Ord As New Ordine
            Ord.Read(IdOrd)

            CreaRiepilogoOrd(Ord, UcCommesseAnteprimaOp.WebPrew, enTipoAnteprima.Breve)
            Ord = Nothing
            UcCommesseAnteprimaOp.CaricaMessaggi(IdOrd)

        End If
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub DgFinitCom_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs)

        Try
            Dim x As Integer = 0

            Dim Dr As DataGridViewRow = sender.Rows(e.RowIndex)
            x = Dr.Cells(4).Value
            If x = 1 Then
                Dr.Cells(0).Style.BackColor = Color.Red
                Dr.Cells(0).Style.SelectionBackColor = Color.Red

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnStampaEtichGruppo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim IdOrd As Integer = 0
        If Not DgImballoEx.SelectedRows Is Nothing Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            CreaAnteprima(, O.IdOrd)
        End If
        If IdOrd Then
            If PostazioneCorrente.StampanteEtichette.Length Then

                If MessageBox.Show("Vuoi stampare l'etichetta di gruppo per l'ordine selezionato?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Dim x As New myPrinter

                    x.PrinterName = PostazioneCorrente.StampanteEtichette

                    x.StampaEtichettaGruppo(IdOrd)

                    x = Nothing

                    MessageBox.Show("L' etichetta di gruppo dell'ordine selezionato è stata stampata correttamente!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Selezionare prima la stampante da usare per la stampa etichette!", "Stampa etichette", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ApriProgrammiTaglio()
        FormerHelper.File.ShellExtended(FormerPath.PathCentralizzato & "\ProgrammiTaglio")
    End Sub

    Private Sub TabOperatore_Click(sender As Object, e As System.EventArgs) Handles TabOperatore.Click

        CaricaDati()

    End Sub

    Private Sub CaricaDati()
        If TabOperatore.SelectedTab Is tpStampa Then
            CaricaStampa()
        ElseIf TabOperatore.SelectedTab Is tpFinitCom Then
            CaricaFinituraSuCommessa()
        ElseIf TabOperatore.SelectedTab Is tpFinitProd Then
            CaricaFinituraSuProdotti()
        ElseIf TabOperatore.SelectedTab Is tpImballaggio Then
            CaricaImballaggio()
        ElseIf TabOperatore.SelectedTab Is tpImballaggioCorriere Then
            CaricaImballaggioCorriere()
        ElseIf TabOperatore.SelectedTab Is tpConsegne Then
            CaricaConsegnaMerci()
        ElseIf TabOperatore.SelectedTab Is tpStampaDigitale Then
            CaricaStampaDigitale()
        End If
    End Sub

    Private Sub btnTaglio_Click(sender As System.Object, e As System.EventArgs) Handles btnTaglio.Click,
        btnTaglio2.Click,
        btnTaglio3.Click,
        btnTaglio4.Click

        ApriProgrammiTaglio()
    End Sub

    'Private Sub DgFinitProd_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim IdRel As Integer = sender.SelectedRows(0).Cells(0).Value
    '    CreaAnteprima(, IdRel)
    'End Sub

    Private Sub DgFinit_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DgFinitCom.RowPostPaint

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            ''qui sono state aggiunte delle righe calcolo il numero ore
            Try
                Dim x As DataGridViewRow = sender.Rows(e.RowIndex)
                Dim c As CommessaRicerca = DirectCast(x.DataBoundItem, LavLog).CommessaRiferimento

                x.Cells(3).Style.BackColor = c.Colore
                x.Cells(3).Style.SelectionBackColor = c.Colore
            Catch ex As Exception

            End Try

        End If


    End Sub

    Private Sub DgCommesse_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DgCommesse.RowPostPaint

        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            'qui sono state aggiunte delle righe calcolo il numero ore
            Try
                Dim x As DataGridViewRow = sender.Rows(e.RowIndex)
                Dim c As CommessaRicerca = x.DataBoundItem

                x.Cells(3).Style.BackColor = c.Colore
                x.Cells(3).Style.SelectionBackColor = c.Colore
            Catch ex As Exception

            End Try
        End If



    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        If DgCommesse.SelectedRows.Count Then
            Dim D As DataGridViewRow = DgCommesse.SelectedRows(0)
            Dim C As CommessaOperatore = D.DataBoundItem

            Dim IdCrono As Integer = 0, IdLavLog As Integer = 0

            Sottofondo(Me.ParentForm)
            Dim x As New frmOperatore

            Dim Risultato As Integer
            Risultato = x.CaricaPerCommessa(C.IdCom, enStatoCommessa.Stampa)

            x = Nothing
            Sottofondo(Me.ParentForm)

            If Risultato Then
                'FormPrincipale.CalcolaBonus()
                CaricaStampa()
            End If

        End If

    End Sub

    Private Sub btnFinitCom_Click(sender As System.Object, e As System.EventArgs) Handles btnFinitCom.Click
        'avanti da finitura su commessa
        If DgFinitCom.SelectedRows.Count Then
            Dim D As DataGridViewRow = DgFinitCom.SelectedRows(0)
            Dim C As LavLog = D.DataBoundItem

            Dim IdCrono As Integer = 0, IdLavLog As Integer = 0

            Sottofondo(Me.ParentForm)
            Dim x As New frmOperatore

            Dim Risultato As Integer
            Risultato = x.CaricaPerCommessa(C.IdCom, enStatoCommessa.FinituraSuCommessa, C.IdLavLog)

            x = Nothing
            Sottofondo(Me.ParentForm)

            If Risultato Then
                'FormPrincipale.CalcolaBonus()
                CaricaFinituraSuCommessa()
            End If

        End If
    End Sub

    Private Sub btnFinitProd_Click(sender As System.Object, e As System.EventArgs) Handles btnFinitProd.Click
        'avanti da finitura su prodotto
        If DgFinitProd.SelectedRows.Count Then
            Dim D As DataGridViewRow = DgFinitProd.SelectedRows(0)
            Dim C As LavLog = D.DataBoundItem

            Dim IdCrono As Integer = 0, IdLavLog As Integer = 0

            Sottofondo(Me.ParentForm)
            Dim x As New frmOperatore

            Dim Risultato As Integer
            Risultato = x.CaricaPerOrdine(C.IdOrd, C.IdLavLog)

            x = Nothing
            Sottofondo(Me.ParentForm)

            If Risultato Then
                'FormPrincipale.CalcolaBonus()
                CaricaFinituraSuProdotti()
            End If

        End If

    End Sub

    Private Sub btnImballaggio_Click(sender As System.Object, e As System.EventArgs) Handles btnImballaggio.Click
        'avanti da imballaggio
        Dim IdOrd As Integer = 0
        If Not DgImballoEx.SelectedRows Is Nothing Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            IdOrd = O.IdOrd
        End If
        If IdOrd Then
            If MessageBox.Show("Vuoi passare l'ordine selezionato allo stato successivo? ATTENZIONE! Ricorda di stampare le etichette prima!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim Prossimostato As enStatoOrdine
                Dim O As New Ordine
                O.Read(IdOrd)
                If O.IdCorriere = 1 Or O.IdCorriere = 2 Then 'se consegna ritiro cliente o TF

                    Prossimostato = enStatoOrdine.ProntoRitiro
                Else
                    'qui va in imballaggio corriere
                    Prossimostato = enStatoOrdine.ImballaggioCorriere
                End If
                Using OMgr As New OrdiniDAO
                    OMgr.AvanzaOrdiniAStatoByIdOrd(IdOrd, Prossimostato)
                    CaricaImballaggio()
                End Using
            End If
        End If
    End Sub

    Private Function GetIdCons(Nodo As TreeNode) As Integer
        Dim ris As Integer = 0

        If Not Nodo Is Nothing Then

            If Nodo.Name.StartsWith("R") Then
                If Nodo.Nodes.Count = 1 Then
                    ris = GetIdCons(Nodo.Nodes(0))
                End If
            ElseIf Nodo.Name.StartsWith("S") Then
                ris = Nodo.Name.Substring(1)
            Else
                ris = GetIdCons(Nodo.Parent)
            End If
        End If

        Return ris
    End Function

    Private Sub btnConsegne_Click(sender As System.Object, e As System.EventArgs) Handles btnConsegne.Click
        'qui vedo se ho l'id della consegna o se lo posso recuperare
        Dim Nodo As TreeNode = tvwConsegnaMerci.SelectedNode
        Dim IdCons As Integer = GetIdCons(Nodo)

        If IdCons And _CorrSelConsegnaMerci <> enCorriere.AltroCorriere Then
            'avanti da consegna

            Dim C As New ConsegnaProgrammata
            C.Read(IdCons)

            Dim ControlloOrdini As Boolean = False

            If C.ListaOrdini.FindAll(Function(x) x.Stato <> enStatoOrdine.ProntoRitiro).Count Then
                If C.Modificabile(True) = False Then
                    ControlloOrdini = True
                End If
            End If

            If ControlloOrdini = False Then
                If C.ListaOrdini.FindAll(Function(x) x.Stato = enStatoOrdine.ProntoRitiro).Count Then

                    Dim Ris As Integer = 0

                    Sottofondo(Me.ParentForm)
                    Using frm As New frmConsegnaOrdiniRCTF
                        Ris = frm.Carica(IdCons)
                    End Using
                    Sottofondo(Me.ParentForm)

                    If Ris Then CaricaConsegnaMerci()
                Else
                    MessageBox.Show("La consegna non contiene ordini in stato pronto per il ritiro")
                End If
            Else
                MessageBox.Show("La consegna non è modificabile e contiene ordini non pronti per il ritiro")
            End If
        Else
            If _CorrSelConsegnaMerci = enCorriere.AltroCorriere Then

                Dim Ris As Integer = 0

                Sottofondo(Me.ParentForm)
                Using frm As New frmConsegnaOrdiniCorriere
                    Ris = frm.Carica()
                End Using
                Sottofondo(Me.ParentForm)

                If Ris Then CaricaConsegnaMerci()
            Else
                MessageBox.Show("Selezionare una consegna dall'albero")
            End If
        End If


    End Sub

    Private Sub DgFinitProd_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DgFinitProd.CellContentClick
        Dim O As LavLog = DgFinitProd.SelectedRows(0).DataBoundItem

        CreaAnteprima(, O.IdOrd)
    End Sub

    Private Sub DgFinitProd_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgFinitProd.RowPostPaint
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
            ''qui sono state aggiunte delle righe calcolo il numero ore
            Try
                Dim x As DataGridViewRow = sender.Rows(e.RowIndex)
                Dim c As OrdineOperatore = DirectCast(x.DataBoundItem, LavLog).OrdineRiferimento

                x.Cells(3).Style.BackColor = c.StatoColore
                x.Cells(3).Style.SelectionBackColor = c.StatoColore
            Catch ex As Exception

            End Try
        End If

    End Sub

    'Private Watcher As FileSystemWatcher

    'Private Sub ImpostaWatcher()

    '    'DISATTIVATO PER EVITARE ECCESSIVO CARICO SUL DATABASE
    '    'Watcher = New FileSystemWatcher
    '    'Watcher.NotifyFilter = (NotifyFilters.LastWrite)
    '    'Watcher.Path = FormerPath.PathCentralizzato
    '    'Watcher.Filter = "*.mdb"
    '    'Watcher.SynchronizingObject = Me

    '    'AddHandler Watcher.Changed, AddressOf CambiatoDB
    '    'Watcher.EnableRaisingEvents = True

    'End Sub

    Public ReadOnly Property TabSelezionata As String
        Get
            Return TabOperatore.SelectedTab.Name
        End Get
    End Property

    Private Sub AggiornaVisualizzazione()
        Try
            'aggiorno la schermata attiva
            Select Case TabSelezionata
                Case "tpStampa"
                    CaricaStampa()
                Case "tpFinitCom"
                    CaricaFinituraSuCommessa()
                Case "tpFinitProd"
                    CaricaFinituraSuProdotti()
                Case "tpImballaggio"
                    CaricaImballaggio()
                Case "tpImballaggioCorriere"
                    CaricaImballaggioCorriere()
                Case "tpConsegne" 'SU CONSEGNE NON AGGIORNO NEINTE IN AUTOMATICO
                    'CaricaGiorno()
            End Select
            Beep()
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub CambiatoDB(source As Object, e As FileSystemEventArgs)

    '    AggiornaVisualizzazione()

    'End Sub

    Private Sub tmrAggiorna_Tick(sender As Object, e As EventArgs) Handles tmrAggiorna.Tick
        AggiornaVisualizzazione()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnStampaEtichCorr.Click
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                'qui carico la form in cui controllo se tutti i colli sono sparati 
                Dim IdOrd As Integer = Node.Name.Substring(1)
                If MessageBox.Show("Vuoi ristampare le etichette per l'ordine selezionato?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim O As New Ordine
                    O.Read(IdOrd)

                    If O.NumeroRealeColli = 0 Then

                        Dim P As New Prodotto
                        P.Read(O.IdProd)

                        Dim NumColli As Integer = P.NumColli
                        Dim NumColliUtente As String = InputBox("Inserisci il numero di pacchi reali dell'ordine", "Stampa etichette", NumColli)

                        If IsNumeric(NumColliUtente) AndAlso NumColliUtente <> 0 Then
                            O.NumeroRealeColli = NumColliUtente
                            O.Save()
                        End If
                    End If

                    If O.NumeroRealeColli Then
                        Dim x As New myPrinter

                        x.PrinterName = PostazioneCorrente.StampanteEtichette
                        x.IdOrd = IdOrd
                        x.NumColli = O.NumeroRealeColli
                        x.StampaEtichetteOrdine()
                        x = Nothing
                        MessageBox.Show("Etichette stampate correttamente")
                    End If

                End If
            End If
        End If


    End Sub

    'Private Sub btnAvantiCorr_Click(sender As Object, e As EventArgs) Handles btnAvantiCorr.Click

    '    Dim Node As TreeNode = tvClienti.SelectedNode

    '    If Not Node Is Nothing Then
    '        If Node.Name.StartsWith("S") Then
    '            'qui devo controllare prima che tutti i colli sono stati sparati 
    '            'se non e' cosi e qualche ordine resta fuori lo posso fare, lo escludo dalla consegna
    '            'lo resetto e poi mando un mess a tutti gli admin
    '            Dim CheckAllOrd As Boolean = True
    '            Dim TrovatoAlmenoUnOrdine As Boolean = False
    '            For Each n As TreeNode In Node.Nodes
    '                If n.ImageIndex = 8 Then
    '                    TrovatoAlmenoUnOrdine = True
    '                ElseIf n.ImageIndex = 9 Then
    '                    CheckAllOrd = False
    '                End If
    '            Next
    '            If TrovatoAlmenoUnOrdine Then
    '                Dim IdCons As Integer = Node.Name.Substring(1)

    '                If MessageBox.Show("Vuoi passare gli ordini della consegna selezionata allo stato successivo? ATTENZIONE! Ricorda di stampare le etichette per la consegna!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                    Dim CheckOk As Boolean = True
    '                    If CheckAllOrd = False Then
    '                        'qui ci sono ordini non ancora imballati
    '                        If MessageBox.Show("ATTENZIONE! Non tutti gli ordini della consegna sono stati imballati. Si vuole forzare la chiusura della consegna? In tale caso gli ordini non imballati saranno sganciati e dovranno essere riprogrammati per la consegna", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                            'sgancio gli ordini non imballati 
    '                            Using mC As New ConsegneProgrammateDAO
    '                                For Each n As TreeNode In Node.Nodes
    '                                    If n.ImageIndex = 9 Then
    '                                        'CHIEDERE
    '                                        Dim C As ConsegnaRicerca = n.Tag
    '                                        mC.EliminaOrdineDaConsegna(C)

    '                                        'QUI INSERISCO UN MESSAGGIO PER TUTTI GLI ADMIN IN CUI AVVERTO DEL CAMBIAMENTO
    '                                        Dim lu As List(Of Utente) = Nothing
    '                                        Using mgr As New UtentiDAO
    '                                            lu = mgr.FindAll(New LUNA.LunaSearchParameter("Tipo", CInt(enTipoUtente.Admin)))
    '                                        End Using
    '                                        For Each u As Utente In lu
    '                                            Dim m As New Messaggio
    '                                            m.DataIns = Now
    '                                            m.Titolo = "Cambiamento consegna programmata ordine " & C.IdOrd
    '                                            m.Testo = "E' stata forzata la chiusura di una consegna programmata escludendo l'ordine " & C.IdOrd & ". La consegna di tale ordine va riprogrammata."
    '                                            m.IdMitt = 0
    '                                            m.IdDest = u.IdUt
    '                                            m.Save()
    '                                        Next

    '                                    End If
    '                                Next
    '                            End Using
    '                        Else
    '                            CheckOk = False
    '                        End If
    '                    End If

    '                    If CheckOk Then
    '                        Dim Prossimostato As enStatoOrdine = enStatoOrdine.ProntoRitiro
    '                        Using OMgr As New OrdiniDAO
    '                            For Each n As TreeNode In Node.Nodes
    '                                Dim C As ConsegnaRicerca = n.Tag
    '                                OMgr.AvanzaOrdiniAStatoByIdOrd(C.IdOrd, Prossimostato)
    '                            Next
    '                        End Using
    '                        'qui devo per forza ricaricare l'albero
    '                        CaricaImballaggioCorriere()
    '                    End If


    '                End If
    '            Else
    '                MessageBox.Show("E' necessario che almeno un ordine sia stato imballato per la consegna!")
    '            End If
    '        Else
    '            MessageBox.Show("Selezionare una consegna dall'albero")
    '        End If
    '    End If
    'End Sub

    Private Sub btnCarica_Click(sender As Object, e As EventArgs) Handles btnCarica.Click

        Dim IdCons As Integer = 0

        'devo recuperare l'id della consegna
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                IdCons = Node.Parent.Name.Substring(1)
            ElseIf Node.Name.StartsWith("S") Then
                'qui ho la consegna
                IdCons = Node.Name.Substring(1)
            End If
        End If

        If IdCons Then
            Sottofondo(Me.ParentForm)

            Dim frm As New frmMagazzinoImballaggioColli
            frm.Carica(IdCons)
            frm = Nothing

            Sottofondo(Me.ParentForm)
        Else
            MessageBox.Show("Selezionare un ordine o una consegna")
        End If


        'Exit Sub

        'If Not Node Is Nothing Then
        '    If Node.Name.StartsWith("O") Then
        '        'TODO: SISTEMARE - è brutto ma per ora mi baso sull'icona
        '        If Node.ImageIndex = 9 Then
        '            'qui carico la form in cui controllo se tutti i colli sono sparati 
        '            Dim IdOrd As Integer = Node.Name.Substring(1)

        '            Dim O As New Ordine
        '            O.Read(IdOrd)

        '            Dim Messaggio As String = "Per questo ordine devono essere caricati " & O.NumeroRealeColli & " collo/i."

        '            MessageBox.Show(Messaggio, "Inserimento ordine in pacco", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '            Dim Esci As Boolean = False

        '            'qui so gia calcolare i codici che mi aspetto 
        '            Dim CodiciPrevisti As New List(Of String)
        '            For i As Integer = 1 To O.NumeroRealeColli
        '                Dim Codice As String = O.IdOrd.ToString.PadLeft(7, "0")
        '                Codice &= i.ToString.PadLeft(4, "0")
        '                CodiciPrevisti.Add(Codice)
        '            Next

        '            Dim CodiciLetti As New List(Of String)
        '            While Esci = False
        '                Dim f As New frmBarCode
        '                Sottofondo(Me.ParentForm)
        '                Dim MessaggioColli As String = "Devono ancora essere caricati " & CodiciPrevisti.Count - CodiciLetti.Count & " colli"
        '                Dim Codice As String = f.Carica(MessaggioColli, IdOrd)
        '                Sottofondo(Me.ParentForm)
        '                If Codice.Length = 0 Then
        '                    Esci = True
        '                Else
        '                    Codice = Codice.TrimEnd
        '                    Codice = Codice.TrimStart
        '                    If Codice.Length = 12 Or Codice.Length = 13 Then

        '                        Dim ParteOrdine As String = Codice.Substring(0, 7)
        '                        If ParteOrdine = O.IdOrd.ToString.PadLeft(7, "0") Then
        '                            Dim CodiceScelto As String = Codice.Substring(0, 11)
        '                            If Not CodiciLetti.Find(Function(item) item = CodiceScelto) Is Nothing Then
        '                                'MessageBox.Show("Codice a barre già inserito")
        '                                Suona(enTipoSuono.ErroreColloGiaCaricato)
        '                            Else
        '                                'qui non esiste lo aggiungo 
        '                                CodiciLetti.Add(CodiceScelto)
        '                                If CodiciLetti.Count = CodiciPrevisti.Count Then Esci = True
        '                            End If

        '                        Else
        '                            Suona(enTipoSuono.ErroreCodiceABarreRelativoAUnAltroOrdine)
        '                            'MessageBox.Show("Codice a barre inserito non relativo all'ordine selezionato")
        '                        End If
        '                    Else
        '                        Suona(enTipoSuono.ErroreCodiceInseritoNonValido)
        '                        'MessageBox.Show("Codice inserito formalmente non valido")
        '                    End If
        '                End If
        '            End While

        '            'se arrivo qui o sono uscito o ho caricato tutti i codici
        '            'per controllarlo basta che le due liste sono uguali 
        '            If CodiciLetti.Count = CodiciPrevisti.Count Then
        '                'qui devo aggiornare lo stato e metterlo a inserito nel pacco


        '                Dim OCMgr As New ConsProgrOrdiniDAO

        '                Dim l As List(Of ConsProgrOrdini) = OCMgr.Find(New LUNA.LunaSearchParameter("IdOrd", O.IdOrd))

        '                If l.Count Then
        '                    Dim Oc As ConsProgrOrdini = l(0)
        '                    Oc.Inserito = 1
        '                    Oc.Save()

        '                End If
        '                OCMgr.Dispose()

        '                Node.SelectedImageIndex = 8
        '                Node.ImageIndex = 8
        '            End If
        '        Else
        '            MessageBox.Show("L'ordine è stato gia imballato", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    Else
        '        MessageBox.Show("Selezionare un ordine dall'albero", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'End If
    End Sub

    'Private Sub btnEtichCons_Click(sender As Object, e As EventArgs) Handles btnEtichCons.Click
    '    Dim Node As TreeNode = tvClienti.SelectedNode
    '    EtichetteCorriere(Node)
    'End Sub

    'Private Sub EtichetteCorriere(Node As TreeNode)
    '    If Not Node Is Nothing Then
    '        If Node.Name.StartsWith("S") Then
    '            'qui devo controllare prima che tutti i colli sono stati sparati 
    '            'se non e' cosi e qualche ordine resta fuori lo posso fare, lo escludo dalla consegna
    '            'lo resetto e poi mando un mess a tutti gli admin
    '            Dim CheckAllOrd As Boolean = True
    '            Dim TrovatoAlmenoUnOrdine As Boolean = False
    '            For Each n As TreeNode In Node.Nodes
    '                If n.ImageIndex = 8 Then
    '                    TrovatoAlmenoUnOrdine = True
    '                ElseIf n.ImageIndex = 9 Then
    '                    CheckAllOrd = False
    '                End If
    '            Next
    '            If TrovatoAlmenoUnOrdine Then
    '                Dim IdCons As Integer = Node.Name.Substring(1)

    '                If MessageBox.Show("Vuoi stampare le etichette per la consegna selezionata?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                    Dim CheckOk As Boolean = True
    '                    If CheckAllOrd = False Then
    '                        'qui ci sono ordini non ancora imballati
    '                        If MessageBox.Show("ATTENZIONE! Non tutti gli ordini della consegna sono stati imballati. Si vuole forzare la chiusura della consegna? In tale caso gli ordini non imballati saranno sganciati e dovranno essere riprogrammati per la consegna", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                            'sgancio gli ordini non imballati 
    '                            Using mC As New ConsegneProgrammateDAO
    '                                For Each n As TreeNode In Node.Nodes
    '                                    If n.ImageIndex = 9 Then
    '                                        'CHIEDERE
    '                                        Dim C As ConsegnaRicerca = n.Tag
    '                                        mC.EliminaOrdineDaConsegna(C)

    '                                        'QUI INSERISCO UN MESSAGGIO PER TUTTI GLI ADMIN IN CUI AVVERTO DEL CAMBIAMENTO
    '                                        Dim lu As List(Of Utente) = Nothing
    '                                        Using mgr As New UtentiDAO
    '                                            lu = mgr.FindAll(New LUNA.LunaSearchParameter("Tipo", CInt(enTipoUtente.Admin)))
    '                                        End Using
    '                                        For Each u As Utente In lu
    '                                            Dim m As New Messaggio
    '                                            m.DataIns = Now
    '                                            m.Titolo = "Cambiamento consegna programmata ordine " & C.IdOrd
    '                                            m.Testo = "E' stata forzata la chiusura di una consegna programmata escludendo l'ordine " & C.IdOrd & ". La consegna di tale ordine va riprogrammata."
    '                                            m.IdMitt = 0
    '                                            m.IdDest = u.IdUt
    '                                            m.Save()
    '                                        Next

    '                                    End If
    '                                Next
    '                            End Using
    '                            'qui devo per forza ricaricare l'albero
    '                            CaricaImballaggioCorriere()
    '                        Else
    '                            CheckOk = False
    '                        End If
    '                    End If

    '                    If CheckOk Then
    '                        Dim NumColliCons As String = InputBox("Inserisci il numero di pacchi reali della consegna", "Stampa etichette", "1")

    '                        If IsNumeric(NumColliCons) Then
    '                            Dim PesoCalcolato As Single = 0

    '                            Using mC As New ConsProgrOrdiniDAO
    '                                Dim l As List(Of ConsProgrOrdini) = mC.FindAll(New LUNA.LunaSearchParameter("IdCons", IdCons))


    '                                For Each co As ConsProgrOrdini In l
    '                                    Dim singO As New Ordine
    '                                    singO.Read(co.IdOrd)

    '                                    Dim p As New Prodotto
    '                                    p.Read(singO.IdProd)

    '                                    PesoCalcolato += p.PesoComplessivo
    '                                Next

    '                                Dim c As New ConsegnaProgrammata
    '                                c.Read(IdCons)
    '                                c.NumColli = NumColliCons
    '                                c.Peso = PesoCalcolato 'qui ci va il peso di tutti gli ordini contenuti nelal consegna 
    '                                c.Save()
    '                                Dim x As New myPrinter
    '                                x.PrinterName = PostazioneCorrente.StampanteEtichette
    '                                x.IdCons = IdCons
    '                                Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteConsegna)
    '                                t.Start()
    '                                x = Nothing
    '                                'If MessageBox.Show("Le etichette sono state stampate correttamente! Vuoi passare gli ordini allo stato successivo?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                                Dim Prossimostato As enStatoOrdine = enStatoOrdine.ProntoRitiro
    '                                Using mO As New OrdiniDAO
    '                                    mO.AvanzaOrdiniAStatoByIdCons(IdCons, Prossimostato)
    '                                    CaricaImballaggioCorriere()
    '                                End Using
    '                                'End If
    '                            End Using
    '                        End If
    '                    End If

    '                End If
    '            Else
    '                MessageBox.Show("E' necessario che almeno un ordine sia stato imballato per la consegna!")
    '            End If
    '        Else
    '            MessageBox.Show("Selezionare un cliente dall'albero")
    '        End If
    '    End If
    'End Sub

    Private Sub EtichetteCorriere(IdCons As Integer)
        If MessageBox.Show("Vuoi stampare le etichette per la consegna selezionata?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim Cp As New ConsegnaProgrammata
            Cp.Read(IdCons)

            Dim NumColliCons As String = InputBox("Inserisci il numero di pacchi reali della consegna", "Stampa etichette", Cp.NumColli)

            If IsNumeric(NumColliCons) Then
                Dim PesoCalcolato As Single = 0
                Cp.NumColli = NumColliCons
                Cp.Peso = PesoCalcolato 'qui ci va il peso di tutti gli ordini contenuti nelal consegna 
                Cp.Save()
                Dim x As New myPrinter
                x.PrinterName = PostazioneCorrente.StampanteEtichette
                x.IdCons = IdCons
                Dim t As New System.Threading.Thread(AddressOf x.StampaEtichetteConsegna)
                t.Start()
                x = Nothing
                MessageBox.Show("Etichette stampate correttamente")
            End If
        End If

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click,
        btnRefresh1.Click,
        btnRefresh2.Click,
        btnRefresh3.Click,
        btnRefresh4.Click,
        btnRefresh5.Click
        CaricaDati()
    End Sub

    'Private Sub UcConsegneGiorno_OrdineSelezionato() Handles UcConsegneGiorno.OrdineSelezionato

    '    If UcConsegneGiorno.IdOrdSel Then

    '        Cursor.Current = Cursors.WaitCursor

    '        CreaAnteprima(, UcConsegneGiorno.IdOrdSel)

    '        Cursor.Current = Cursors.Default

    '    End If

    'End Sub

    'Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If cmbCliente.Focused Then
    '        CaricaAlberoConsegne(cmbCliente.SelectedValue)
    '    End If
    'End Sub

    Private Function ComparerDataIns(ByVal x As Ordine, ByVal y As Ordine) As Integer
        Dim result As Integer = x.DataPrevConsegna.CompareTo(y.DataPrevConsegna)

        Return result
    End Function

    'Private Sub CaricaAlberoConsegne(IdRub As Integer)

    '    'carico gli ordini
    '    Dim mgr As New OrdiniDAO
    '    Dim LstM As New List(Of OrdineRicerca)

    '    LstM = mgr.Lista(, enStatoOrdine.Registrato & "," & _
    '                        enStatoOrdine.InSospeso & "," & _
    '                        enStatoOrdine.InCodaDiStampa & "," & _
    '                        enStatoOrdine.StampaInizio & "," & _
    '                        enStatoOrdine.StampaFine & "," & _
    '                        enStatoOrdine.FinituraCommessaInizio & "," & _
    '                        enStatoOrdine.FinituraCommessaFine & "," & _
    '                        enStatoOrdine.FinituraProdottoInizio & "," & _
    '                        enStatoOrdine.FinituraProdottoFine & "," & _
    '                        enStatoOrdine.Imballaggio & "," & _
    '                        enStatoOrdine.ImballaggioCorriere & "," & _
    '                        enStatoOrdine.ProntoRitiro, , , , , , , , , , IdRub)

    '    LstM.Sort(AddressOf ComparerDataIns)
    '    tvConsCliente.Nodes.Clear()

    '    For Each c As OrdineRicerca In LstM
    '        Dim ChiaveData As String = "D" & c.DataConsPrevKey
    '        Dim ChiaveCorriere As String = ChiaveData & "C" & c.IdCorriere
    '        Dim ChiaveRubrica As String = ChiaveCorriere & "R" & c.IdRub
    '        Dim ChiaveOrdine As String = "P" & c.IdOrd

    '        Dim NodoData As TreeNode = tvConsCliente.Nodes(ChiaveData)
    '        If NodoData Is Nothing Then
    '            NodoData = tvConsCliente.Nodes.Add(ChiaveData, c.DataConsPrevShort, 7, 7)
    '            'NodoData.Expand()
    '        End If

    '        Dim NodoCorr As TreeNode = NodoData.Nodes(ChiaveCorriere)
    '        If NodoCorr Is Nothing Then
    '            NodoCorr = NodoData.Nodes.Add(ChiaveCorriere, c.CorriereStr, 6, 6)
    '            'NodoCorr.Expand()
    '        End If
    '        Dim NodoRub As TreeNode = NodoCorr.Nodes(ChiaveRubrica)
    '        If NodoRub Is Nothing Then
    '            NodoRub = NodoCorr.Nodes.Add(ChiaveRubrica, c.ClienteNominativo, 0, 0)
    '            ' NodoRub.EnsureVisible()
    '        End If
    '        NodoCorr.Expand()
    '        Dim nodoOrd As TreeNode = NodoRub.Nodes.Add(ChiaveOrdine, "Ord." & c.IdOrd & " - " & c.ProdottoDescrizione, 1, 1)
    '        nodoOrd.BackColor = GetStatoColore(c.Stato)
    '        nodoOrd.Tag = c

    '    Next
    '    tvConsCliente.ExpandAll()
    'End Sub

    Private Sub tvClienti_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvClienti.AfterSelect, tvwConsegnaMerci.AfterSelect

        If e.Node.Name.StartsWith("O") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            CreaAnteprima(, IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub tvConsCliente_AfterSelect(sender As Object, e As TreeViewEventArgs)
        If e.Node.Name.StartsWith("P") Then
            Dim IdOrd As Integer = e.Node.Name.Substring(1)
            Cursor.Current = Cursors.WaitCursor

            CreaAnteprima(, IdOrd)

            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub btnProntoRitiroCliente_Click(sender As Object, e As EventArgs)
        Sottofondo(Me.ParentForm)
        Dim x As New frmProntoRitiroCliente
        x.Carica()
        x = Nothing
        Sottofondo(Me.ParentForm)
    End Sub

    Private Sub btnEtichOrdCons_Click(sender As Object, e As EventArgs) Handles btnEtichOrdCons.Click

        Dim Nodo As TreeNode = tvwConsegnaMerci.SelectedNode

        If Not Nodo Is Nothing AndAlso Nodo.Name.StartsWith("O") Then

            Dim IdOrd As Integer = Nodo.Name.Substring(1)
            If MessageBox.Show("Vuoi ristampare le etichette per l'ordine selezionato?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim O As New Ordine
                O.Read(IdOrd)

                If O.NumeroRealeColli = 0 Then

                    Dim P As New Prodotto
                    P.Read(O.IdProd)

                    Dim NumColli As Integer = P.NumColli
                    Dim NumColliUtente As String = InputBox("Inserisci il numero di pacchi reali dell'ordine", "Stampa etichette", NumColli)

                    If IsNumeric(NumColliUtente) AndAlso NumColliUtente <> 0 Then
                        O.NumeroRealeColli = NumColliUtente
                        O.Save()
                    End If
                End If

                If O.NumeroRealeColli Then
                    Dim x As New myPrinter

                    x.PrinterName = PostazioneCorrente.StampanteEtichette
                    x.IdOrd = IdOrd
                    x.NumColli = O.NumeroRealeColli
                    x.StampaEtichetteOrdine()
                    x = Nothing
                    MessageBox.Show("Etichette stampate correttamente")
                End If

            End If
        Else
            MessageBox.Show("Selezionare un ordine dall'albero delle consegne")
        End If




    End Sub

    Private Sub btnImballo_Click(sender As Object, e As EventArgs)

        Dim IdOrd As Integer = 0
        If Not DgImballoEx.SelectedRows Is Nothing Then
            Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
            IdOrd = O.IdOrd
        End If
        If IdOrd Then

            Dim f As New frmMagazzinoImballo
            Sottofondo(Me.ParentForm)
            f.Carica(IdOrd)
            Sottofondo(Me.ParentForm)
            f = Nothing
        End If

    End Sub

    Private Sub DgImballoEx_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgImballoEx.CellClick
        Dim O As Ordine = DirectCast(DgImballoEx.SelectedRows(0).DataBoundItem, Ordine)
        CreaAnteprima(, O.IdOrd)
    End Sub

    'Private Sub btnPropSel_Click(sender As Object, e As EventArgs)

    '    If Not DgImballoEx.SelectedRows Is Nothing Then

    '        Dim O As Ordine = DgImballoEx.SelectedRows(0).DataBoundItem

    '        If O.IdListinoBase Then
    '            If O.Prodotto.ListinoBase.IdModelloCubetto Then
    '                If O.TipoImballo = enTipoImballo.Scatola Or (O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormer And O.ConsegnaAssociata.IdCorr <> enCorriere.TipografiaFormerFuoriRaccordo And O.ConsegnaAssociata.IdCorr <> enCorriere.RitiroCliente) Then
    '                    'qui posso proporre una soluzione
    '                    Dim f As New frmMagazzinoImballo
    '                    Sottofondo(Me.ParentForm)
    '                    f.Carica(O.IdOrd)
    '                    Sottofondo(Me.ParentForm)
    '                    f = Nothing
    '                Else
    '                    MessageBox.Show("Questo ordine non ha bisogno di essere inscatolato")
    '                End If
    '            Else
    '                MessageBox.Show("Non è possibile proporre una soluzione per questo Ordine")
    '            End If
    '        Else
    '            MessageBox.Show("Non è possibile proporre una soluzione per questo Ordine")
    '        End If
    '    End If
    'End Sub

    Private Sub btnForzaChiusuraCons_Click(sender As Object, e As EventArgs) Handles btnForzaChiusuraCons.Click

        Dim IdCons As Integer = 0

        'devo recuperare l'id della consegna
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                IdCons = Node.Parent.Name.Substring(1)
            ElseIf Node.Name.StartsWith("S") Then
                'qui ho la consegna
                IdCons = Node.Name.Substring(1)
            End If
        End If

        If IdCons Then

            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)
            If c.Modificabile(False) Then
                If MessageBox.Show("Vuoi forzare la chiusura della consegna selezionata sganciando gli ordini CHE SI TROVANO IN STATO PRECEDENTE A IMBALLAGGIO CORRIERE?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    If c.ListaOrdini.Count > 1 Then

                        If c.ListaOrdini.FindAll(Function(singO) singO.Stato = enStatoOrdine.ImballaggioCorriere).Count Then
                            'qui devo prendere gli ordini che non sono ancora stati inseriti e cambiargli la consegna spostandola

                            Dim SalvataScatola As Integer = 0

                            Sottofondo(Me.ParentForm)
                            Using fr As New frmRiepilogoConsegna
                                SalvataScatola = fr.Carica(IdCons, True)
                            End Using
                            Sottofondo(Me.ParentForm)

                            If SalvataScatola = 1 Then

                                'Dim DataNuova As Date = MgrDataConsegna.GetPrimaDataDisponibile(Now, c.IdCorr)

                                ''Dim DataNuova As Date = Now.Date

                                ''Select Case Now.DayOfWeek
                                ''    Case DayOfWeek.Saturday
                                ''        DataNuova = DataNuova.AddDays(2)
                                ''    Case DayOfWeek.Friday
                                ''        If c.IdCorr = enCorriere.RitiroCliente Then
                                ''            DataNuova = DataNuova.AddDays(1)
                                ''        Else
                                ''            DataNuova = DataNuova.AddDays(3)
                                ''        End If
                                ''    Case Else
                                ''        DataNuova = DataNuova.AddDays(1)
                                ''End Select

                                'For Each cpO As Ordine In c.ListaOrdini.FindAll(Function(singO) singO.Stato < enStatoOrdine.ImballaggioCorriere)

                                '    Using mgrC As New ConsegneProgrammateDAO
                                '        'TOLTO IL 08/04/2015
                                '        'mgrC.EliminaOrdineDaConsegna(0, cpO.IdOrd)
                                '        mgrC.RegistraConsegnaOrdineSuGiorno(cpO.IdOrd, c.IdCorr, DataNuova, c.IdRub, enMomentoConsegna.Pomeriggio, c.IdIndirizzo)
                                '    End Using

                                'Next

                                'c.AggiornaColliPeso()

                                CaricaImballaggioCorriere()
                            End If
                        Else
                            MessageBox.Show("Non puoi forzare la chiusura di una consegna in cui nessun ordine è stato preparato")
                        End If
                    Else
                        MessageBox.Show("Non puoi forzare la chiusura di una consegna che contiene un solo ordine")
                    End If

                End If
            Else
                MessageBox.Show("Questa consegna non può essere forzata")
            End If


        End If

    End Sub

    Private Sub btnGestCons_Click(sender As Object, e As EventArgs) Handles btnGestCons.Click

        Dim IdCons As Integer = 0

        'devo recuperare l'id della consegna
        Dim Node As TreeNode = tvClienti.SelectedNode
        If Not Node Is Nothing Then
            If Node.Name.StartsWith("O") Then
                IdCons = Node.Parent.Name.Substring(1)
            ElseIf Node.Name.StartsWith("S") Then
                'qui ho la consegna
                IdCons = Node.Name.Substring(1)
            End If
        End If

        If IdCons Then
            Dim c As New ConsegnaProgrammata
            c.Read(IdCons)

            If c.ListaOrdini.FindAll(Function(xx) xx.Stato < enStatoOrdine.ImballaggioCorriere).Count > 0 Then
                MessageBox.Show("Si possono gestire solo le consegne in cui tutti gli ordini sono in stato Imballaggio Corriere")
            Else
                Sottofondo(Me.ParentForm)

                Dim x As New frmRiepilogoConsegna
                x.Carica(IdCons)
                x = Nothing

                Sottofondo(Me.ParentForm)
            End If


        End If

    End Sub

    Private Property _AltroCorrCodTrack As Boolean = False

    Private Sub lblLegRC_Click(sender As Object, e As EventArgs) Handles lblLegRC.Click
        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = False
        UcFiltroCorriereConsegne.Visible = False
        btnBordero.Visible = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.RitiroCliente
        CaricaConsegnaMerci()
    End Sub

    Private Sub lblLegTF_Click(sender As Object, e As EventArgs) Handles lblLegTF.Click
        lblTipoAlbero.Visible = True
        rdoAlberoCliente.Visible = True
        rdoAlberoData.Visible = True
        'chkSoloGlsConsegne.Visible = False
        UcFiltroCorriereConsegne.Visible = False
        btnBordero.Visible = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.TipografiaFormer
        CaricaConsegnaMerci()
    End Sub

    Private Sub lblLegAC_Click(sender As Object, e As EventArgs) Handles lblLegAC.Click
        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = True
        UcFiltroCorriereConsegne.Visible = True
        btnBordero.Visible = False
        btnConsegne.Visible = True
        btnCodTrack.Visible = False
        _CorrSelConsegnaMerci = enCorriere.AltroCorriere
        _AltroCorrCodTrack = False
        CaricaConsegnaMerci()

    End Sub

    Private Sub lblLegACCodTrack_Click(sender As Object, e As EventArgs) Handles lblLegACCodTrack.Click
        lblTipoAlbero.Visible = False
        rdoAlberoCliente.Visible = False
        rdoAlberoData.Visible = False
        'chkSoloGlsConsegne.Visible = True
        UcFiltroCorriereConsegne.Visible = True
        btnBordero.Visible = False
        btnConsegne.Visible = False
        btnCodTrack.Visible = True
        _CorrSelConsegnaMerci = enCorriere.AltroCorriere
        _AltroCorrCodTrack = True
        CaricaConsegnaMerci()

    End Sub

    Private Sub btnAvanzaSenzaStampa_Click(sender As Object, e As EventArgs) Handles btnAvanzaSenzaStampa.Click
        StampaEtichette(False)
    End Sub

    Private Sub chkSoloConsegnabili_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloConsegnabili.CheckedChanged
        'chkSoloProntiRitiroCorr.Checked = chkSoloConsegnabili.Checked
        If sender.focus Then
            CaricaDati()
        End If

    End Sub

    Private Sub cmbZona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZona.SelectedIndexChanged
        If sender.focus Then CaricaDati()
    End Sub

    Private Sub chkSoloProntiRitiroCorr_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloProntiRitiroCorr.CheckedChanged
        If chkSoloProntiRitiroCorr.Checked Then
            chkSoloDaImballCorr.Checked = False
        End If
        If sender.focus Then
            CaricaDati()
        End If
    End Sub

    Private Sub chkSoloDaImballCorr_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloDaImballCorr.CheckedChanged
        If chkSoloDaImballCorr.Checked Then
            chkSoloProntiRitiroCorr.Checked = False
        End If
        If sender.focus Then
            CaricaDati()
        End If
    End Sub

    Private Sub rdoAlberoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAlberoData.CheckedChanged, rdoAlberoCliente.CheckedChanged
        'TODO: CON LA RIGA SEGUENTE VA IN STACK OVERFLOW (GIRA ALL'INFINITO PASSANDO DA UN RADIO BUTTON ALL'ALTRO)
        'If sender.focus Then CaricaDati()
        CaricaDati()
    End Sub

    Private Sub ucFiltroCorriereConsegne_FiltroCambiato(sender As Object) Handles UcFiltroCorriereConsegne.SelezionatoCorriere
        UcFiltroCorriereImballoCorriere.CorriereSelezionatoEnum = UcFiltroCorriereConsegne.CorriereSelezionatoEnum
        If sender.focus Then
            CaricaDati()
        End If
    End Sub

    Private Sub ucFiltroCorriereImballoCorriere_FiltroCambiato(sender As Object) Handles UcFiltroCorriereImballoCorriere.SelezionatoCorriere
        UcFiltroCorriereConsegne.CorriereSelezionatoEnum = UcFiltroCorriereImballoCorriere.CorriereSelezionatoEnum
        If sender.focus Then
            CaricaDati()
        End If
    End Sub

    'Private Sub chkSoloGlsConsegne_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloGlsConsegne.CheckedChanged
    '    'chkSoloGlsImballo.Checked = chkSoloGlsConsegne.Checked
    '    chkSoloGlsImballoCorr.Checked = chkSoloGlsConsegne.Checked
    '    If sender.focus Then
    '        CaricaDati()
    '    End If
    'End Sub

    'Private Sub chkSoloGlsImballoCorr_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloGlsImballoCorr.CheckedChanged
    '    'chkSoloGlsImballo.Checked = chkSoloGlsImballoCorr.Checked
    '    chkSoloGlsConsegne.Checked = chkSoloGlsImballoCorr.Checked
    '    If sender.focus Then
    '        CaricaDati()
    '    End If
    'End Sub

    'Private Sub chkSoloGlsImballo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoloGlsImballo.CheckedChanged
    '    chkSoloGlsImballoCorr.Checked = chkSoloGlsImballo.Checked
    '    chkSoloGlsConsegne.Checked = chkSoloGlsImballo.Checked
    '    If sender.focus Then
    '        CaricaDati()
    '    End If
    'End Sub

    Private Sub btnBordero_Click(sender As Object, e As EventArgs) Handles btnBordero.Click
        'TODO: QUI DEVO VERIFICARE IL O I CORRIERI SELEZIONATI, FACCIO UN CICLO E, SE IL CASO (GLS) (RI)TRASMETTO LE SPEDIZIONI;
        'POI SIA PER GLS CHE BARTOLINI STAMPO IL BORDERO'

        Dim Corriere As String = String.Empty

        Select Case _IdCorr
            Case enCorriere.GLS
                Corriere = "GLS"
            Case enCorriere.Bartolini
                Corriere = "Bartolini"
        End Select

        If _IdCorr = enCorriere.GLS Then
            If MessageBox.Show("Confermi la ristampa del borderò di " & Corriere & "?", "Trasmissione Spedizione", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'MessageBox.Show("Controlla che nella stampante non ci sia carta per fatture!")

                Dim lstConsegneColliGls As List(Of ConsegnaProgrammata) = New List(Of ConsegnaProgrammata)

                If _lstConsegne.Count Then
                    Dim Pt As New FormerWebLabeling.My.Templates.DistintaTemplate
                    Pt.Consegne = _lstConsegne
                    Dim Path As String = FormerPath.PathTempLocale()
                    'Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".pdf")
                    'FormerHelper.PDF.ConvertHTMLToPDF(Pt.TransformText, Path & NomeFile)
                    'Dim StampanteDistintaSpedizione As String = Configuration.ConfigurationManager.AppSettings("StampantePDF")
                    'FormerHelper.PDF.StampaPdf(Path & NomeFile, StampanteDistintaSpedizione, 842, 595)
                    Dim NomeFile As String = FormerHelper.File.GetNomeFileTemp(".html")
                    Using objWriter As New System.IO.StreamWriter(Path & NomeFile)
                        objWriter.Write(Pt.TransformText)
                    End Using
                    'FormerHelper.File.ShellExtended(Path & NomeFile)

                    'STAMPO LA DISTINTA IN MODO DIRETTO SULLA STAMPANTE PREDEFINITA CON ORIENTAMENTO PREDEFINITO?
                    'Dim myWebBrowser As New WebBrowser
                    'AddHandler myWebBrowser.DocumentCompleted, AddressOf DocumentCompleted
                    'myWebBrowser.Navigate(Path & NomeFile)

                    'STAMPO LA DISTINTA PASSANDO PER FORM DI ANTEPRIMA
                    'qui ho il file completato e lo mando alla form di preview
                    Sottofondo(Me.ParentForm)
                    Using x As New frmStampa
                        x.carica(Path & NomeFile)
                    End Using
                    Sottofondo(Me.ParentForm)
                    If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then
                        If MessageBox.Show("Vuoi anche ri-effettuare la trasmissione delle spedizioni etichettate a " & Corriere & "?", , MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            Cursor.Current = Cursors.WaitCursor
                            For Each C In _lstConsegne
                                For i = 1 To C.NumColli
                                    lstConsegneColliGls.Add(C)
                                Next
                            Next

                            Dim ris As String = String.Empty
                            Try
                                ris = FormerWebLabeling.MgrGls.TrasmettiSpedizioniGls(lstConsegneColliGls)
                            Catch ex As Exception
                                ris = ex.Message
                            End Try
                            MessageBox.Show("Risultato trasmissione spedizioni: " & ris)
                            Cursor.Current = Cursors.Default
                        End If
                    End If
                Else
                    MessageBox.Show("Nessuna spedizione per cui stampare il borderò!")
                End If
            End If
        Else
            MessageBox.Show("Al momento la stampa della distinta e la trasmissione automatica delle spedizioni è disponibile solo per GLS!")
        End If
    End Sub

    'Private Sub DocumentCompleted(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)
    '    With DirectCast(sender, WebBrowser)
    '        If .ReadyState = WebBrowserReadyState.Complete Then
    '            .Print()
    '        End If
    '    End With
    'End Sub

    Private Sub btnCodTrack_Click(sender As Object, e As EventArgs) Handles btnCodTrack.Click

        'qui vedo se ho l'id della consegna o se lo posso recuperare
        Dim Nodo As TreeNode = tvwConsegnaMerci.SelectedNode
        Dim IdCons As Integer = GetIdCons(Nodo)

        If IdCons Then
            'avanti da consegna

            Dim C As New ConsegnaProgrammata
            C.Read(IdCons)

            Dim ris As String = "0"

            Sottofondo(Me.ParentForm)

            If C.IdCorr = enCorriere.Bartolini Or C.IdCorr = enCorriere.PortoAssegnatoBartolini Then
                Using x As New frmCodTrackBrt
                    ris = x.Carica(IdCons)
                End Using
            ElseIf C.IdCorr = enCorriere.GLS Or C.IdCorr = enCorriere.PortoAssegnatoGLS Or C.IdCorr = enCorriere.GLSIsole Then
                If Not C.IdStatoConsegna = enStatoConsegna.RegistrataCorriere Then
                    Using x As New frmCodTrackGls
                        ris = x.Carica(IdCons)
                    End Using
                Else
                    MessageBox.Show("Per poter editare manualmente il codice di tracking, devi prima eliminare la registrazione di gls!")
                End If
            End If

            Sottofondo(Me.ParentForm)

            If ris <> "0" Then
                CaricaConsegnaMerci()
            End If

        Else
            MessageBox.Show("Selezionare una consegna dall'albero")
        End If
    End Sub

    Private Sub UcFiltroCorriereConsegne_Load(sender As Object, e As EventArgs) Handles UcFiltroCorriereConsegne.Load

    End Sub
End Class
