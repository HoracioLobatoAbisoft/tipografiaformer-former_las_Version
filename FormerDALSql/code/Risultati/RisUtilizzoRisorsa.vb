Imports FormerDALSql
Imports FormerLib.FormerEnum

Public Class RisUtilizzoRisorsa

    Public Property Giorno As Date
    Public Property Risorsa As Risorsa = Nothing
    Public Property Movimenti As New List(Of MovimentoMagazzino)

    Public ReadOnly Property TotPrenotazioni As Integer
        Get
            Dim ris As Integer = 0

            ris = Movimenti.FindAll(Function(x) x.TipoMov = enTipoMovMagaz.Prenotazione).Sum(Function(x) x.Qta)

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotCarico As Integer
        Get
            Dim ris As Integer = 0

            ris = Movimenti.FindAll(Function(x) x.TipoMov = enTipoMovMagaz.Carico).Sum(Function(x) x.Qta)

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotScarico As Integer
        Get
            Dim ris As Integer = 0

            ris = Movimenti.FindAll(Function(x) x.TipoMov = enTipoMovMagaz.Scarico).Sum(Function(x) x.Qta)

            Return ris
        End Get
    End Property

    Public ReadOnly Property GiacenzaAttuale As Integer
        Get
            Dim ris As Integer = 0

            ris = Risorsa.Giacenza

            Return ris
        End Get
    End Property

    Public ReadOnly Property TotDaOrdini As Integer
        Get
            Dim ris As Integer = 0

            Return ris
        End Get
    End Property

End Class
