Public Class RisValidazioneIndirizzo

    Public Property Valido As Boolean = False

    Public Property Esito As String = String.Empty

    Public Property XmlResponse As String = String.Empty

    Public ReadOnly Property Messaggio As String
        Get
            'qui interpreto l'xml response
            Dim msg As String = Esito

            Dim Lunghezza As Integer = msg.IndexOf("A seguire") - 1

            If Lunghezza > 0 Then
                msg = msg.Substring(0, Lunghezza).Trim
            End If

            Return msg

        End Get
    End Property

    Public ListaIndirizziSuggeriti As New List(Of String)


End Class
