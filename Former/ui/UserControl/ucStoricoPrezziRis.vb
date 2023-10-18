Imports FormerDALSql
Friend Class ucStoricoPrezziRis
    Inherits ucFormerUserControl
    Private _IdRis As Integer = 0
    Friend Property IdRis() As Integer
        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            _IdRis = value
            MostraDati()
        End Set
    End Property

    Public Sub MostraDati(Optional ByVal Cerca As String = "")

        Dim Prod As New cRisorseColl, dt As DataTable


        dt = Prod.StoricoPrezzi(_IdRis)

        DgRisorse.DataSource = dt
        'DgRisorse.Columns(0).Visible = False
        DgRisorse.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgRisorse.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgRisorse.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DgListino.Columns(3).DefaultCellStyle.Format = "0.00"

        DgRisorse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        DgRisorse.AutoResizeColumns()
    End Sub

    Private Sub lnkStampa_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkStampa.LinkClicked
        ParentFormEx.Sottofondo()
        Dim Titolo As String = ""

        Titolo = "Storico Prezzi Risorsa"

        StampaGlobale(Titolo, DgRisorse)
        ParentFormEx.Sottofondo()
    End Sub


    Public Sub New()

        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        BackColor = Color.White

    End Sub
End Class
