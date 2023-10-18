Imports FormerDALSql

Public Class RisIsLocked

    'Public Property IdFunctionLock As Integer = 0
    Public Property IdUt As Integer = 0
    Public Property IdOrd As Integer = 0
    Public Property IsLocked As Boolean = False
    Public Property DaQuando As Date = Date.MinValue
    Public Property Postazione As String = String.Empty
    Public Property IdFunction As Integer = 0
    Private _Utente As Utente = Nothing
    Public ReadOnly Property Utente As Utente
        Get
            If _Utente Is Nothing Then
                _Utente = New Utente
                _Utente.Read(IdUt)
            End If
            Return _Utente
        End Get
    End Property

End Class
