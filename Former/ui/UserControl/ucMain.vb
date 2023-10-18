Imports FormerDALSql
Imports FormerLib.FormerEnum
Public Class ucMain
    Inherits ucFormerUserControl
    Friend WithEvents AnteprimaLavori As New ucAnteprimaLavoro

    Private Sub ucMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White
        SplitContainerOrdini.SplitterDistance = 1000

    End Sub

    Public Sub CaricaTelefonate()

        TabMain.SelectedTab = tpMessaggi

        UcMessaggi.MostraDati()

    End Sub

    Public Sub CaricaMailInCoda(Optional CounterGiaCalcolato As Integer = -1)
        Cursor.Current = Cursors.WaitCursor
        Dim SingRis As Integer = 0

        If CounterGiaCalcolato <> -1 Then
            SingRis = CounterGiaCalcolato
        Else
            SingRis = UcPreventiviMail.CounterDaLavorare
        End If

        Me.tpEmailInEntrata.Text = "Email (" & SingRis & ")"

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub CaricaProduzioneInCoda()

        Cursor.Current = Cursors.WaitCursor
        Dim SingRis As Integer = 0
        SingRis = UcProduzione.CommesseInCoda()
        SetCommesseInCoda("Produzione (" & SingRis & ")")
        Cursor.Current = Cursors.Default

    End Sub

    Delegate Sub SetTextCallback(testo As String)

    Private Sub SetCommesseInCoda(ByVal testo As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.tpProduzione.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetCommesseInCoda)
            Me.Invoke(d, New Object() {testo})
        Else
            Me.tpProduzione.Text = testo
        End If
    End Sub

    Private Sub TickCodaCommesse(ByVal sender As Object, ByVal myEventArgs As EventArgs)

        Dim t As Timers.Timer = DirectCast(sender, Timers.Timer)
        'STOPPO IL TIMER 
        Dim NextRound As Date = Now.AddMilliseconds(t.Interval)
        t.Stop()

        CaricaProduzioneInCoda()

        t.Start()

    End Sub

    Public Sub Carica()
        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        'If FormerDebug.DebugAttivo Then

        'Dim t As New Timers.Timer
        't.Interval = 180000
        'AddHandler t.Elapsed, AddressOf RipulisciMemoria
        't.Start()

        'End If

        'TabMain.TabPages.Remove(tbRubrica)
        TabMain.TabPages.Clear()
        If PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Admin Then

            'TabMain.TabPages.Add(tpPreventivi)
            TabMain.TabPages.Add(tbOrdini)
            TabMain.TabPages.Add(tpProduzione)
            'TabMain.TabPages.Add(tbCommesse)
            'TabMain.TabPages.Add(tpConsegneReali)
            TabMain.TabPages.Add(tpOrdiniFatturare)
            TabMain.TabPages.Add(tbBilancio)
            TabMain.TabPages.Add(tpMagazzino)
            TabMain.TabPages.Add(tpEmailInEntrata)
            TabMain.TabPages.Add(tpListino)
            TabMain.TabPages.Add(tpMessaggi)
            TabMain.TabPages.Add(tpMarketing)
            TabMain.TabPages.Add(tpSitoWeb)
            TabMain.TabPages.Add(tbParametri)
            TabMain.TabPages.Add(tbOperatore)
            'amministratore

            'UcOperatori.Carica()
            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Ordini")
            UcOrdini.Carica()

            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Produzione")
            UcProduzione.Carica()

            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Produzione In Coda")
            CaricaProduzioneInCoda()

            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Mail in Coda")
            CaricaMailInCoda()

            'UcCommesse.Carica()

            'disattivo il caricamento del modulo gestione ordini 
            'UcOrdiniGest.Carica()
            'UcListino.Carica()
            'UcRisorse.Carica()
            'UcFatture.Carica()
            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Parametri")
            UcParametri.Carica()
            'UcReport.Carica()
            'UcSettimanale.Carica(Now.Date)
            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Marketing")
            UcMarketing.Carica()
            'UcPreventivi.Carica()

            'ALL'ADMIN LASCIO ANCHE LA SCHEDA OPERATORE 
            'TabMain.TabPages.Remove(tbOperatore)
            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento Operatore")
            UcOperatore.Carica()

            If PostazioneCorrente.TracciamentoAttivo Then Trace.WriteLine(Now.ToString("dd/MM HH:mm:ss.fff tt") & " - Caricamento OrdiniFatt")
            UcOrdiniFatt.Carica()

            'TabMain.TabPages.Remove(tpAgenda)

            'If FormerDebug.DebugAttivo = False Then TabMain.TabPages.Remove(tpDebug)

            'Dim t As New Timers.Timer
            't.Interval = 600000
            't.Enabled = True
            'AddHandler t.Elapsed, AddressOf tickCodaCommesse
        ElseIf PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.SuperOperatore Then
            TabMain.TabPages.Add(tbOrdini)
            TabMain.TabPages.Add(tpProduzione)
            'TabMain.TabPages.Add(tbCommesse)
            'TabMain.TabPages.Add(tpConsegneReali)
            TabMain.TabPages.Add(tpOrdiniFatturare)
            'TabMain.TabPages.Add(tbBilancio)
            'TabMain.TabPages.Add(tpEmailInEntrata)
            'TabMain.TabPages.Add(tpListino)
            TabMain.TabPages.Add(tpMessaggi)
            'TabMain.TabPages.Add(tpMarketing)
            'TabMain.TabPages.Add(tpSitoWeb)
            'TabMain.TabPages.Add(tbParametri)
            TabMain.TabPages.Add(tbOperatore)
            'amministratore

            'UcOperatori.Carica()
            UcOrdini.Carica()

            UcProduzione.Carica()

            CaricaProduzioneInCoda()
            'CaricaMailInCoda()

            'UcCommesse.Carica()

            'disattivo il caricamento del modulo gestione ordini 
            'UcOrdiniGest.Carica()
            'UcListino.Carica()
            'UcRisorse.Carica()
            'UcFatture.Carica()
            'UcParametri.Carica()
            'UcReport.Carica()
            'UcSettimanale.Carica(Now.Date)
            'UcMarketing.Carica()
            'UcPreventivi.Carica()

            'ALL'ADMIN LASCIO ANCHE LA SCHEDA OPERATORE 
            'TabMain.TabPages.Remove(tbOperatore)

            UcOperatore.Carica()
            UcOrdiniFatt.Carica()

        ElseIf PostazioneCorrente.UtenteConnesso.Tipo = enTipoUtente.Operatore Then
            'operatore
            TabMain.TabPages.Add(tbOperatore)
            TabMain.TabPages.Add(tpMessaggi)
            UcOperatore.Carica()
            TabMain.SelectedTab = tbOperatore
        End If
        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub UcOrdini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcOrdini.Load

    End Sub

    Private Sub UcOrdini_OrdineSelezionato() Handles UcOrdini.OrdineSelezionato
        If UcOrdini.IdOrdSel Then

            Cursor.Current = Cursors.WaitCursor

            Dim x As New Ordine
            x.Read(UcOrdini.IdOrdSel)

            UcOrdineAnteprima.Carica(x)
            'UcOrdineDett.Carica(x)
            x = Nothing
            Cursor.Current = Cursors.Default

        End If
    End Sub

    Private Sub UcOrdiniGest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    'Private Sub UcOrdiniGest_ModelloCommessaSelezionato() 
    '    If UcOrdiniGest.IdModelloCommessaSel Then

    '        Cursor.Current = Cursors.WaitCursor

    '        Dim x As New ModelloCommessa
    '        x.Read(UcOrdiniGest.IdModelloCommessaSel)

    '        UcOrdineAnteprimaGestOrd.Carica(x)
    '        'UcOrdineDett.Carica(x)
    '        x = Nothing
    '        Cursor.Current = Cursors.Default

    '    End If
    'End Sub

    'Private Sub UcOrdiniGest_OrdineSelezionato() 
    '    If UcOrdiniGest.IdOrdSel Then

    '        Cursor.Current = Cursors.WaitCursor

    '        Dim x As New Ordine
    '        x.Read(UcOrdiniGest.IdOrdSel)

    '        UcOrdineAnteprimaGestOrd.Carica(x)
    '        'UcOrdineDett.Carica(x)
    '        x = Nothing
    '        Cursor.Current = Cursors.Default

    '    End If
    'End Sub

    Public Sub SelezionaOrdiniDaTipoFustella(IdTipoFustella As Integer)

        TabMain.SelectedTab = tbOrdini
        UcOrdini.SelezionaOrdiniDaTipoFustella(IdTipoFustella)

    End Sub


    Public Sub SelezionaClienteDaChiamata(IdCli As Integer)

        TabMain.SelectedTab = tbOrdini
        UcOrdini.SelezionaClienteDaChiamata(IdCli)

    End Sub
    'Private Sub UcCommesse_CommessaSelezionata()

    '    If ucCommesse.IdComSel Then

    '        Cursor.Current = Cursors.WaitCursor

    '        Dim x As New Commessa
    '        x.Read(ucCommesse.IdComSel)

    '        ucCommesseAnteprima.Carica(x) ' CARICAMENTO ANTEPRIMA

    '        x = Nothing
    '        Cursor.Current = Cursors.Default

    '    End If
    'End Sub

    Private Sub UcCommesse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UcFatture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcFatture.Load

    End Sub

    Private Sub TabMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabMain.SelectedIndexChanged
        If TabMain.SelectedTab Is tpOrdiniFatturare Then
            UcOrdiniFatt.Carica()
        ElseIf TabMain.SelectedTab Is tpListino Then

        End If
    End Sub

    Private Sub UcPreventiviMail_CambiamentoStatoMail(Conteggio As Integer) Handles UcPreventiviMail.CambiamentoStatoMail

        CaricaMailInCoda(Conteggio)

    End Sub
End Class
