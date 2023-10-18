Public Class RisCheckNumeroDocumentiFiscali

    Public ReadOnly Property Errori As Boolean
        Get
            Dim ris As Boolean = False

            If BufferErrori.Length Then ris = True

            Return ris
        End Get
    End Property

    Public Property BufferErrori As String = String.Empty

End Class
