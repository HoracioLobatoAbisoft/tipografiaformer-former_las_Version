Imports FormerLib.FormerEnum
Imports FormerLib

Public Class ucCommesseStato
    Inherits ucFormerUserControl

    Private _ClickSuTutti As Boolean = False

    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

    End Sub

    Public Sub Carica()
        chkPreInserito.BackColor = FormerColori.ColoreStatoCommessaPreinserito
        chkPronto.BackColor = FormerColori.ColoreStatoCommessaPronto
        chkStampa.BackColor = FormerColori.ColoreStatoCommessaStampa
        chkFinitCom.BackColor = FormerColori.ColoreStatoCommessaFinituraSuCommessa
        chkFinitProd.BackColor = FormerColori.ColoreStatoCommessaFinituraSuProdotti
        chkCompletata.BackColor = FormerColori.ColoreStatoCommessaCompletata
    End Sub

    Public Event CambiatoStato()

    Public Sub AbilitaCheck(Optional ByVal PreInserito As Boolean = True, Optional ByVal Pronto As Boolean = True, Optional ByVal Stampa As Boolean = True, Optional ByVal FinituraSuCommessa As Boolean = True, Optional ByVal FinituraSuProdotti As Boolean = True, Optional ByVal Completata As Boolean = True)
        chkPreInserito.Enabled = PreInserito
        chkPronto.Enabled = Pronto
        chkStampa.Enabled = Stampa
        chkFinitCom.Enabled = FinituraSuCommessa
        chkFinitProd.Enabled = FinituraSuProdotti
        chkCompletata.Enabled = Completata
    End Sub

    Public Sub VisualizzaCheck(Optional ByVal Tutti As Boolean = True, Optional ByVal PreInserito As Boolean = True, Optional ByVal Pronto As Boolean = True, Optional ByVal Stampa As Boolean = True, Optional ByVal FinituraSuCommessa As Boolean = True, Optional ByVal FinituraSuProdotti As Boolean = True, Optional ByVal Completata As Boolean = True)
        chkTutti.Visible = Tutti
        chkPreInserito.Visible = PreInserito
        chkPronto.Visible = Pronto
        chkStampa.Enabled = Stampa
        chkFinitCom.Visible = FinituraSuCommessa
        chkFinitProd.Visible = FinituraSuProdotti
        chkCompletata.Visible = Completata
    End Sub

    Public Sub AttivaCheck(ByVal PreInserito As Boolean, ByVal Pronto As Boolean, ByVal Stampa As Boolean, ByVal FinituraSuCommessa As Boolean, ByVal FinituraSuProdotti As Boolean, ByVal Completata As Boolean)
        chkPreInserito.Checked = PreInserito
        chkPronto.Checked = Pronto
        chkStampa.Enabled = Stampa
        chkFinitCom.Checked = FinituraSuCommessa
        chkFinitProd.Checked = FinituraSuProdotti
        chkCompletata.Checked = Completata
    End Sub

    Public ReadOnly Property StatiSelezionati() As String
        Get
            Dim StringaRis As String = "0,"

            If chkPreInserito.Checked Then StringaRis &= enStatoCommessa.Preinserito & ","
            If chkPronto.Checked Then StringaRis &= enStatoCommessa.Pronto & ","
            If chkStampa.Checked Then StringaRis &= enStatoCommessa.Stampa & ","
            If chkFinitCom.Checked Then StringaRis &= enStatoCommessa.FinituraSuCommessa & ","
            If chkFinitProd.Checked Then StringaRis &= enStatoCommessa.FinituraSuProdotti & ","
            If chkCompletata.Checked Then StringaRis &= enStatoCommessa.Completata & ","

            StringaRis = StringaRis.TrimEnd(",")

            Return StringaRis
        End Get
    End Property

    Public Property Preinserito() As Boolean
        Get
            Return chkPreInserito.Checked
        End Get
        Set(ByVal value As Boolean)
            chkPreInserito.Checked = value
        End Set
    End Property
    Public Property Pronto() As Boolean
        Get
            Return chkPronto.Checked
        End Get
        Set(ByVal value As Boolean)
            chkPronto.Checked = value
        End Set
    End Property
    Public Property Stampa() As Boolean
        Get
            Return chkStampa.Checked
        End Get
        Set(ByVal value As Boolean)
            chkStampa.Checked = value
        End Set
    End Property
    Public Property FinituraSuCommessa() As Boolean
        Get
            Return chkFinitCom.Checked
        End Get
        Set(ByVal value As Boolean)
            chkFinitCom.Checked = value
        End Set
    End Property
    Public Property FinituraSuProdotti() As Boolean
        Get
            Return chkFinitProd.Checked
        End Get
        Set(ByVal value As Boolean)
            chkFinitProd.Checked = value
        End Set
    End Property
    Public Property Completata() As Boolean
        Get
            Return chkCompletata.Checked
        End Get
        Set(ByVal value As Boolean)
            chkCompletata.Checked = value
        End Set
    End Property

    Private Sub CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreInserito.CheckedChanged, chkFinitProd.CheckedChanged, chkFinitCom.CheckedChanged, chkPronto.CheckedChanged, chkCompletata.CheckedChanged, chkStampa.CheckedChanged
        If _ClickSuTutti = False Then
            RaiseEvent CambiatoStato()
        End If
    End Sub

    Private Sub chkTutti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTutti.CheckedChanged

        Application.DoEvents()
        chkTutti.Refresh()
        _ClickSuTutti = True
        chkPreInserito.Checked = chkTutti.Checked
        chkPronto.Checked = chkTutti.Checked
        chkStampa.Checked = chkTutti.Checked
        chkFinitCom.Checked = chkTutti.Checked
        chkFinitProd.Checked = chkTutti.Checked
        chkCompletata.Checked = chkTutti.Checked
        RaiseEvent CambiatoStato()
        _ClickSuTutti = False

    End Sub

    Public Sub CheckSuTutti()
        chkTutti.Checked = True
    End Sub

End Class
