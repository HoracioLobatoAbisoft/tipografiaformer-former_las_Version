Imports FormerDALSql
Public Class ucMarketing
    Inherits ucFormerUserControl
    Private _IdRis As Integer

    Public Event AggiornataQta()

    Public Property IdRis() As Integer

        Get
            Return _IdRis
        End Get
        Set(ByVal value As Integer)
            _IdRis = value
        End Set

    End Property

    Public Sub Carica()
        'FormerDebug.Traccia("CARICAMENTO INIZIALE")
        UcGruppi1.Carica()

    End Sub

    Private Sub UcEmail_Load(sender As Object, e As EventArgs) Handles UcEmail.Load

    End Sub

    Public Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        TabMarketing.ItemSize = New Size(100, 40)

    End Sub
End Class
