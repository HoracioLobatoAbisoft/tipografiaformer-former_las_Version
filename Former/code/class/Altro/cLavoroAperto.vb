Imports FormerLib.FormerEnum

Public Class LavoroAperto

    Public Property IdLavoro As Integer = 0 'test
    Public Property Tipo As enTipoVoceOrdineCommessa = enTipoVoceOrdineCommessa.Ordine
    Public Property IdUt As Integer = 0
    Public Property Login As String = String.Empty
    Public Property DataOraInizio As Date = Date.MinValue
    Public Property DataOraFine As Date = Date.MinValue
    Public Property DescrizioneBreve As String = String.Empty
    Public Property LoginOperatore As String = String.Empty
    Public Property PathImg As String = String.Empty

End Class
