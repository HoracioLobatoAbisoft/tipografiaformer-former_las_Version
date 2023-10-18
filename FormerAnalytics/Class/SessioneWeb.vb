Public Class SessioneWeb

    Public Sub New(SessionId As String)
        _SessionId = SessionId
    End Sub
    Private _SessionId As String = String.Empty
    Public ReadOnly Property SessionId As String
        Get
            Return _SessionId
        End Get
    End Property

    Public Property Ip As String
    Public Property UserAgent As String

    Public ReadOnly Property Utente As String
        Get
            Dim ris As String = "0(0)"

            Dim T As TracciaWeb = TracceWeb.Find(Function(x) x.IdSito <> ris)
            If Not T Is Nothing Then
                ris = T.IdSito
            End If
            Return ris
        End Get
    End Property

    Public TracceWeb As New List(Of TracciaWeb)

End Class
