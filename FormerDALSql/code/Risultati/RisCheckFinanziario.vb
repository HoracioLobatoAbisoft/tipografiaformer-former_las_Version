Public Class RisCheckFinanziario

    Public Property NonInCodaPerInvio As Integer = 0
    Public Property NonInCodaPerInvio9Giorni As Integer = 0

    Public Property Scartati As Integer = 0
    Public Property InviatiSDIDaOltre5Giorni As Integer = 0

    Public Property InCodaInvioDaOltre3Giorni As Integer = 0

    Public Property FornitoriSenzaCategoria As Integer = 0
    Public Property FornitoriInseritiAutomaticamente As Integer = 0
    Public Property VociDuplicate As Integer = 0

    Public Property ListaCheckMassiviMancanti As New List(Of String)

    Public Property CarichiMagazzinoAnomalia As Integer = 0
    Public Property CarichiMagazzinoNonCollegati As Integer = 0

    Public Property RisorseTipoNonSpecificato As Integer = 0

    Public Property TotAlert As Integer = 0
    Public Property TotError As Integer = 0

End Class
