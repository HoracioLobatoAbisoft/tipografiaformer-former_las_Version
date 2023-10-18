Public Class TracciaWeb

    Public Property Quando As String = String.Empty
    Public Property UrlTarget As String = String.Empty
    Public Property IdSito As String = String.Empty
    Public ReadOnly Property UrlWeb As String
        Get
            Dim ris As String = UrlTarget
            If ris.StartsWith("/") Then ris = "http://www.tipografiaformer.it" & ris
            Return ris
        End Get
    End Property

    Public ReadOnly Property TipoPagina As String
        Get
            Dim ris As String = "-"

            If UrlTarget.StartsWith("/") Then
                If UrlTarget.ToList().FindAll(Function(x) x = "/").Count = 6 Then
                    ris = "Scheda Prodotto"
                End If
            End If

            Return ris
        End Get
    End Property

End Class
