Imports FormerLib.FormerEnum
Imports FormerLib
Public Class ucOrdiniStatoAdvanced
    Inherits ucFormerUserControl
    Private _ClickSuTutti As Boolean = False
    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

        'TESTI MENU PRINCIPALI
        PreinseritoToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito)
        ProntoToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Registrato)
        InLavorazioneToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.StampaInizio)
        ImballaggioToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Imballaggio)
        ProntoStampaToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.ProntoRitiro)
        InConsegnaToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.InConsegna)
        ConsegnatoToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Consegnato)
        PagatoToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.PagatoInteramente)
        RifiutatoToolStripMenuItem.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Rifiutato)

        'TESTI MENU SECONDARI
        PreinseritoToolStripMenuItem1.Text = FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito)

    End Sub

    Private _Vista As String = String.Empty

    Public Sub Carica(Optional Vista As String = "DEFAULT")

        _Vista = Vista

        'COLORO MENU PRINCIPALI

        ColoraMenu(PreinseritoToolStripMenuItem, FormerColori.ColoreStatoOrdinePreinserito)
        ColoraMenu(ProntoToolStripMenuItem, FormerColori.ColoreStatoOrdineRegistrato)
        ColoraMenu(InLavorazioneToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(ImballaggioToolStripMenuItem, FormerColori.ColoreStatoOrdineImballaggio)
        ColoraMenu(ProntoStampaToolStripMenuItem, FormerColori.ColoreStatoOrdineProntoStampa)
        ColoraMenu(InConsegnaToolStripMenuItem, FormerColori.ColoreStatoOrdineInConsegna)
        ColoraMenu(ConsegnatoToolStripMenuItem, FormerColori.ColoreStatoOrdineConsegnato)
        ColoraMenu(PagatoToolStripMenuItem, FormerColori.ColoreStatoOrdinePagato)
        ColoraMenu(RifiutatoToolStripMenuItem, FormerColori.ColoreStatoOrdineRifiutato)

        'COLORO MENU SECONDARI
        ColoraMenu(RefineAutomaticoToolStripMenuItem, FormerColori.ColoreStatoOrdineRefine)
        ColoraMenu(PreinseritoToolStripMenuItem1, FormerColori.ColoreStatoOrdinePreinserito)
        ColoraMenu(RegistratoToolStripMenuItem1, FormerColori.ColoreStatoOrdineRegistrato)
        ColoraMenu(InSospesoToolStripMenuItem, FormerColori.ColoreStatoOrdineInSospeso)
        ColoraMenu(InCodaDiStampaToolStripMenuItem, FormerColori.ColoreStatoOrdineProntoConCommessa)

        ColoraMenu(InStampaToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(StampaFinitaToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(InizioFinituraSuCommessaToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(FineFinituraSuCommessaToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(InizioFinituraSuProdottoToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)
        ColoraMenu(FineFinituraSuProdottoToolStripMenuItem, FormerColori.ColoreStatoOrdineInLavorazione)

        ColoraMenu(ImballaggioToolStripMenuItem1, FormerColori.ColoreStatoOrdineImballaggio)
        ColoraMenu(ImballaggioCorriereToolStripMenuItem, FormerColori.ColoreStatoOrdineImballaggioCorriere)

        ColoraMenu(ProntoPerIlRitiroToolStripMenuItem, FormerColori.ColoreStatoOrdineProntoStampa)
        ColoraMenu(UscitoDaMagazzinoToolStripMenuItem, FormerColori.ColoreStatoOrdineUscitoDaMagazzino)

        ColoraMenu(InConsegnaToolStripMenuItem1, FormerColori.ColoreStatoOrdineInConsegna)
        ColoraMenu(ConsegnatoToolStripMenuItem1, FormerColori.ColoreStatoOrdineConsegnato)

        ColoraMenu(PagatoParzialmenteToolStripMenuItem, FormerColori.ColoreStatoOrdinePagato)
        ColoraMenu(PagatoInteramenteToolStripMenuItem, FormerColori.ColoreStatoOrdinePagato)

        ColoraMenu(RifiutatoToolStripMenuItem1, FormerColori.ColoreStatoOrdineRifiutato)

        'If PostazioneCorrente.CaricamentiAutomatici Then
        Select Case Vista
            Case "DEFAULT"
                VistaDefault()
            Case "LAVORAZIONE"
                VistaInLavorazione()
            Case "CORRIEREPRONTICONSEGNA"
                VistaCorriereProntiConsegna()
            Case "CORRIEREINCONSEGNA"
                VistaCorriereInConsegna()
            Case "CORRIEREINCONSEGNAPRONTICONSEGNA"
                VistaCorriereInConsegnaProntiConsegna()
        End Select
        'End If


    End Sub

    Private Sub ColoraMenu(mnu As ToolStripMenuItem, colore As Color)

        mnu.BackColor = colore
        'For Each m As ToolStripItem In mnu.DropDownItems
        'm.BackColor = colore
        'Next

    End Sub

    Public Event CambiatoStato()

    'Public Sub AbilitaCheck(Optional ByVal PreInserito As Boolean = True, Optional ByVal Pronto As Boolean = True, Optional ByVal InLavorazione As Boolean = True, Optional ByVal Imballaggio As Boolean = True, Optional ByVal ProntoStampa As Boolean = True, Optional ByVal InConsegna As Boolean = True, Optional ByVal Consegnato As Boolean = True, Optional ByVal Pagato As Boolean = True, Optional ByVal Rifiutato As Boolean = True)
    '    chkPreInserito.Enabled = PreInserito
    '    chkPronto.Enabled = Pronto
    '    chkInLavorazione.Enabled = InLavorazione
    '    chkImballaggio.Enabled = Imballaggio
    '    chkProntoStampa.Enabled = ProntoStampa
    '    chkInConsegna.Enabled = InConsegna
    '    chkConsegnato.Enabled = Consegnato
    '    chkPagato.Enabled = Pagato
    '    chkRifiutato.Enabled = Rifiutato
    'End Sub

    'Public Sub VisualizzaCheck(Optional ByVal Tutti As Boolean = True, Optional ByVal PreInserito As Boolean = True, Optional ByVal Pronto As Boolean = True, Optional ByVal InLavorazione As Boolean = True, Optional ByVal Imballaggio As Boolean = True, Optional ByVal ProntoStampa As Boolean = True, Optional ByVal InConsegna As Boolean = True, Optional ByVal Consegnato As Boolean = True, Optional ByVal Pagato As Boolean = True, Optional ByVal Rifiutato As Boolean = True)
    '    chkTutti.Visible = Tutti
    '    chkPreInserito.Visible = PreInserito
    '    chkPronto.Visible = Pronto
    '    chkInLavorazione.Visible = InLavorazione
    '    chkImballaggio.Visible = Imballaggio
    '    chkProntoStampa.Visible = ProntoStampa
    '    chkInConsegna.Visible = InConsegna
    '    chkConsegnato.Visible = Consegnato
    '    chkPagato.Visible = Pagato
    '    chkRifiutato.Visible = Rifiutato
    'End Sub
    'Public Sub AttivaCheck(ByVal PreInserito As Boolean, ByVal Pronto As Boolean, ByVal InLavorazione As Boolean, ByVal Imballaggio As Boolean, ByVal ProntoStampa As Boolean, ByVal InConsegna As Boolean, ByVal Consegnato As Boolean, ByVal Pagato As Boolean, ByVal Rifiutato As Boolean)
    '    chkPreInserito.Checked = PreInserito
    '    chkPronto.Checked = Pronto
    '    ' chkCodaStampa.Checked = Pronto
    '    chkInLavorazione.Checked = InLavorazione
    '    chkImballaggio.Checked = Imballaggio
    '    chkProntoStampa.Checked = ProntoStampa
    '    chkInConsegna.Checked = InConsegna
    '    chkConsegnato.Checked = Consegnato
    '    chkPagato.Checked = Pagato
    '    chkRifiutato.Checked = Rifiutato
    'End Sub

    Public ReadOnly Property StatiSelezionati() As String
        Get
            Dim StringaRis As String = "0,"

            'seleziono tutto il gruppo da lavorare
            If RefineAutomaticoToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.RefineAutomatico & ","
            If PreinseritoToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.Preinserito & ","

            If RegistratoToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.Registrato & ","
            If InSospesoToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.InSospeso & ","
            If InCodaDiStampaToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.InCodaDiStampa & ","

            If InStampaToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.StampaInizio & ","
            If StampaFinitaToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.StampaFine & ","
            If InizioFinituraSuCommessaToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.FinituraCommessaInizio & ","
            If FineFinituraSuCommessaToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.FinituraCommessaFine & ","
            If InizioFinituraSuProdottoToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.FinituraProdottoInizio & ","
            If FineFinituraSuProdottoToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.FinituraProdottoFine & ","

            If ImballaggioToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.Imballaggio & ","
            If ImballaggioCorriereToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.ImballaggioCorriere & ","

            If ProntoPerIlRitiroToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.ProntoRitiro & ","
            If UscitoDaMagazzinoToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.UscitoMagazzino & ","

            If InConsegnaToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.InConsegna & ","

            If ConsegnatoToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.Consegnato & ","

            If PagatoParzialmenteToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.PagatoAcconto & ","
            If PagatoInteramenteToolStripMenuItem.Checked = True Then StringaRis &= enStatoOrdine.PagatoInteramente & ","

            If RifiutatoToolStripMenuItem1.Checked = True Then StringaRis &= enStatoOrdine.Rifiutato & ","

            StringaRis = StringaRis.TrimEnd(",")

            Return StringaRis
        End Get
    End Property

    'Public Property Preinserito() As Boolean
    '    Get
    '        Return chkPreInserito.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkPreInserito.Checked = value
    '    End Set
    'End Property
    'Public Property Pronto() As Boolean
    '    Get
    '        Return chkPronto.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkPronto.Checked = value
    '    End Set
    'End Property
    'Public Property InLavorazione() As Boolean
    '    Get
    '        Return chkInLavorazione.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkInLavorazione.Checked = value
    '    End Set
    'End Property
    'Public Property Imballaggio() As Boolean
    '    Get
    '        Return chkImballaggio.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkImballaggio.Checked = value
    '    End Set
    'End Property
    'Public Property ProntoStampa() As Boolean
    '    Get
    '        Return chkProntoStampa.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkProntoStampa.Checked = value
    '    End Set
    'End Property
    'Public Property InConsegna() As Boolean
    '    Get
    '        Return chkInConsegna.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkInConsegna.Checked = value
    '    End Set
    'End Property
    'Public Property Consegnato() As Boolean
    '    Get
    '        Return chkConsegnato.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkConsegnato.Checked = value
    '    End Set
    'End Property
    'Public Property Pagato() As Boolean
    '    Get
    '        Return chkPagato.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkPagato.Checked = value
    '    End Set
    'End Property
    'Public Property Rifiutato() As Boolean
    '    Get
    '        Return chkRifiutato.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        chkRifiutato.Checked = value
    '    End Set
    'End Property

    'Private Sub chkPreInserito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If sender.focused Then
    '        If _ClickSuTutti = False Then
    '            RaiseEvent CambiatoStato()
    '        End If
    '    End If
    'End Sub

    'Private Sub chkTutti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Application.DoEvents()
    '    chkTutti.Refresh()
    '    _ClickSuTutti = True
    '    chkPreInserito.Checked = chkTutti.Checked
    '    chkPronto.Checked = chkTutti.Checked
    '    chkInLavorazione.Checked = chkTutti.Checked
    '    chkImballaggio.Checked = chkTutti.Checked
    '    chkProntoStampa.Checked = chkTutti.Checked
    '    chkInConsegna.Checked = chkTutti.Checked
    '    chkConsegnato.Checked = chkTutti.Checked
    '    chkPagato.Checked = chkTutti.Checked
    '    chkRifiutato.Checked = chkTutti.Checked
    '    RaiseEvent CambiatoStato()
    '    _ClickSuTutti = False

    'End Sub

    'Public Sub CheckSuTutti()
    '    chkTutti.Checked = True
    'End Sub

    Private Sub InLavorazioneToolStripMenuItem_MouseHover(sender As Object, e As System.EventArgs) Handles InLavorazioneToolStripMenuItem.MouseHover,
                                                                                                            ConsegnatoToolStripMenuItem.MouseHover,
                                                                                                            PreinseritoToolStripMenuItem.MouseHover,
                                                                                                            ProntoToolStripMenuItem.MouseHover,
                                                                                                            InLavorazioneToolStripMenuItem.MouseHover,
                                                                                                            ImballaggioToolStripMenuItem.MouseHover,
                                                                                                            ProntoStampaToolStripMenuItem.MouseHover,
                                                                                                            InConsegnaToolStripMenuItem.MouseHover,
                                                                                                            ConsegnatoToolStripMenuItem.MouseHover,
                                                                                                            PagatoToolStripMenuItem.MouseHover,
                                                                                                            RifiutatoToolStripMenuItem.MouseHover,
                                                                                                            TuttiToolStripMenuItem.MouseHover
        sender.ShowDropDown()
    End Sub

    Private Sub PreinseritoToolStripMenuItem1_CheckStateChanged(sender As Object, e As System.EventArgs) Handles PreinseritoToolStripMenuItem1.CheckStateChanged,
                                                                                                                RefineAutomaticoToolStripMenuItem.CheckedChanged,
                                                                                                                RegistratoToolStripMenuItem1.CheckStateChanged,
                                                                                                                InSospesoToolStripMenuItem.CheckStateChanged,
                                                                                                                InCodaDiStampaToolStripMenuItem.CheckStateChanged,
                                                                                                                InStampaToolStripMenuItem.CheckStateChanged,
                                                                                                                StampaFinitaToolStripMenuItem.CheckStateChanged,
                                                                                                                InizioFinituraSuCommessaToolStripMenuItem.CheckStateChanged,
                                                                                                                FineFinituraSuCommessaToolStripMenuItem.CheckStateChanged,
                                                                                                                InizioFinituraSuProdottoToolStripMenuItem.CheckStateChanged,
                                                                                                                FineFinituraSuProdottoToolStripMenuItem.CheckStateChanged,
                                                                                                                ImballaggioToolStripMenuItem1.CheckStateChanged,
                                                                                                                ImballaggioCorriereToolStripMenuItem.CheckStateChanged,
                                                                                                                ProntoPerIlRitiroToolStripMenuItem.CheckStateChanged,
                                                                                                                UscitoDaMagazzinoToolStripMenuItem.CheckStateChanged,
                                                                                                                InConsegnaToolStripMenuItem1.CheckStateChanged,
                                                                                                                ConsegnatoToolStripMenuItem1.CheckStateChanged,
                                                                                                                PagatoParzialmenteToolStripMenuItem.CheckStateChanged,
                                                                                                                PagatoInteramenteToolStripMenuItem.CheckStateChanged,
                                                                                                                RifiutatoToolStripMenuItem1.CheckStateChanged

        If _ClickSuTutti = False Then
            RaiseEvent CambiatoStato()
        End If

        '  End If

    End Sub

    Private Sub NessunoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NessunoToolStripMenuItem.Click
        _ClickSuTutti = True
        For Each m As ToolStripMenuItem In MenuStati.Items
            For Each mn As Object In m.DropDownItems
                Try
                    mn.Checked = False
                Catch ex As Exception

                End Try

            Next

        Next
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub TuttiGliOrdiniDaLavorareToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TuttiGliOrdiniDaLavorareToolStripMenuItem.Click
        _ClickSuTutti = True
        'seleziono tutto il gruppo da lavorare
        PreinseritoToolStripMenuItem1.Checked = True

        RegistratoToolStripMenuItem1.Checked = True
        InSospesoToolStripMenuItem.Checked = True
        InCodaDiStampaToolStripMenuItem.Checked = True

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = False
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()

    End Sub

    Private Sub TuttiGliOrdiniInLavorazioneToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TuttiGliOrdiniInLavorazioneToolStripMenuItem.Click
        VistaInLavorazione()
    End Sub
    Private Sub VistaInLavorazione()
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = True

        RegistratoToolStripMenuItem1.Checked = True
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = True

        InStampaToolStripMenuItem.Checked = True
        StampaFinitaToolStripMenuItem.Checked = True
        InizioFinituraSuCommessaToolStripMenuItem.Checked = True
        FineFinituraSuCommessaToolStripMenuItem.Checked = True
        InizioFinituraSuProdottoToolStripMenuItem.Checked = True
        FineFinituraSuProdottoToolStripMenuItem.Checked = True

        ImballaggioToolStripMenuItem1.Checked = True
        ImballaggioCorriereToolStripMenuItem.Checked = True

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub
    Private Sub TuttiGliOrdiniConsegnatiToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TuttiGliOrdiniConsegnatiToolStripMenuItem.Click
        _ClickSuTutti = True
        'seleziono tutto il gruppo consegnato
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = False
        UscitoDaMagazzinoToolStripMenuItem.Checked = True

        InConsegnaToolStripMenuItem1.Checked = True

        ConsegnatoToolStripMenuItem1.Checked = True

        PagatoParzialmenteToolStripMenuItem.Checked = True
        PagatoInteramenteToolStripMenuItem.Checked = True

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub
    Public Sub AttivaTutti()
        _ClickSuTutti = True
        'seleziono tutto il gruppo consegnato
        RefineAutomaticoToolStripMenuItem.Checked = True
        PreinseritoToolStripMenuItem1.Checked = True

        RegistratoToolStripMenuItem1.Checked = True
        InSospesoToolStripMenuItem.Checked = True
        InCodaDiStampaToolStripMenuItem.Checked = True

        InStampaToolStripMenuItem.Checked = True
        StampaFinitaToolStripMenuItem.Checked = True
        InizioFinituraSuCommessaToolStripMenuItem.Checked = True
        FineFinituraSuCommessaToolStripMenuItem.Checked = True
        InizioFinituraSuProdottoToolStripMenuItem.Checked = True
        FineFinituraSuProdottoToolStripMenuItem.Checked = True

        ImballaggioToolStripMenuItem1.Checked = True
        ImballaggioCorriereToolStripMenuItem.Checked = True

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = True

        InConsegnaToolStripMenuItem1.Checked = True

        ConsegnatoToolStripMenuItem1.Checked = True

        PagatoParzialmenteToolStripMenuItem.Checked = True
        PagatoInteramenteToolStripMenuItem.Checked = True

        RifiutatoToolStripMenuItem1.Checked = True
        _ClickSuTutti = False
    End Sub

    Private Sub TuttiToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles TuttiToolStripMenuItem1.Click
        AttivaTutti()
        RaiseEvent CambiatoStato()
    End Sub

    Public Sub ReimpostaVistaDefault()
        VistaDefault(False)
    End Sub

    Private Sub VistaDefault(Optional WithRaiseEvent As Boolean = True)
        _ClickSuTutti = True
        'seleziono tutto il gruppo consegnato
        RefineAutomaticoToolStripMenuItem.Checked = True
        PreinseritoToolStripMenuItem1.Checked = True

        RegistratoToolStripMenuItem1.Checked = True
        InSospesoToolStripMenuItem.Checked = True
        InCodaDiStampaToolStripMenuItem.Checked = True

        InStampaToolStripMenuItem.Checked = True
        StampaFinitaToolStripMenuItem.Checked = True
        InizioFinituraSuCommessaToolStripMenuItem.Checked = True
        FineFinituraSuCommessaToolStripMenuItem.Checked = True
        InizioFinituraSuProdottoToolStripMenuItem.Checked = True
        FineFinituraSuProdottoToolStripMenuItem.Checked = True

        ImballaggioToolStripMenuItem1.Checked = True
        ImballaggioCorriereToolStripMenuItem.Checked = True

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = True

        InConsegnaToolStripMenuItem1.Checked = True

        ConsegnatoToolStripMenuItem1.Checked = True

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        If WithRaiseEvent Then RaiseEvent CambiatoStato()
    End Sub
    Private Sub VistaCorriereProntiConsegna()
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub
    Private Sub VistaCorriereInConsegna()
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = False
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = True

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub
    Private Sub VistaCorriereInConsegnaProntiConsegna()
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = True

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub ImballaggioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImballaggioToolStripMenuItem1.Click

    End Sub

    Private Sub ProntoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProntoToolStripMenuItem.Click,
        PreinseritoToolStripMenuItem.Click,
        InLavorazioneToolStripMenuItem.Click,
        ImballaggioToolStripMenuItem.Click,
        ProntoStampaToolStripMenuItem.Click,
        InConsegnaToolStripMenuItem.Click,
        ConsegnatoToolStripMenuItem.Click,
        PagatoToolStripMenuItem.Click,
        RifiutatoToolStripMenuItem.Click
        SelezionaVociFiglie(sender)
    End Sub

    Private Sub SelezionaVociFiglie(Sender As ToolStripMenuItem)
        _ClickSuTutti = True
        For Each m As Object In Sender.DropDownItems
            If TypeOf (m) Is ToolStripMenuItem Then m.Checked = Not m.Checked
        Next
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        _ClickSuTutti = True
        'seleziono tutto il gruppo consegnato
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = False
        UscitoDaMagazzinoToolStripMenuItem.Checked = True

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub DaImpacchettareToolStripMenuItem_Click(sender As Object, e As EventArgs)
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = True

        RegistratoToolStripMenuItem1.Checked = True
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = True

        InStampaToolStripMenuItem.Checked = True
        StampaFinitaToolStripMenuItem.Checked = True
        InizioFinituraSuCommessaToolStripMenuItem.Checked = True
        FineFinituraSuCommessaToolStripMenuItem.Checked = True
        InizioFinituraSuProdottoToolStripMenuItem.Checked = True
        FineFinituraSuProdottoToolStripMenuItem.Checked = True

        ImballaggioToolStripMenuItem1.Checked = True
        ImballaggioCorriereToolStripMenuItem.Checked = True

        ProntoPerIlRitiroToolStripMenuItem.Checked = False
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub ImpacchettatiToolStripMenuItem_Click(sender As Object, e As EventArgs)
        _ClickSuTutti = True
        'seleziono tutto il gruppo in lavorazione
        PreinseritoToolStripMenuItem1.Checked = False

        RegistratoToolStripMenuItem1.Checked = False
        InSospesoToolStripMenuItem.Checked = False
        InCodaDiStampaToolStripMenuItem.Checked = False

        InStampaToolStripMenuItem.Checked = False
        StampaFinitaToolStripMenuItem.Checked = False
        InizioFinituraSuCommessaToolStripMenuItem.Checked = False
        FineFinituraSuCommessaToolStripMenuItem.Checked = False
        InizioFinituraSuProdottoToolStripMenuItem.Checked = False
        FineFinituraSuProdottoToolStripMenuItem.Checked = False

        ImballaggioToolStripMenuItem1.Checked = False
        ImballaggioCorriereToolStripMenuItem.Checked = False

        ProntoPerIlRitiroToolStripMenuItem.Checked = True
        UscitoDaMagazzinoToolStripMenuItem.Checked = False

        InConsegnaToolStripMenuItem1.Checked = False

        ConsegnatoToolStripMenuItem1.Checked = False

        PagatoParzialmenteToolStripMenuItem.Checked = False
        PagatoInteramenteToolStripMenuItem.Checked = False

        RifiutatoToolStripMenuItem1.Checked = False
        _ClickSuTutti = False
        RaiseEvent CambiatoStato()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        'ricarico la vista di default
        Carica(_Vista)
    End Sub
End Class
