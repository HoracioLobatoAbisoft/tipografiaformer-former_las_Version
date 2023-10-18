Public Class IntestazioneDocumento

    Public Property pRagSoc As String = String.Empty
    Public Property pIndirizzo As String = String.Empty
    Public Property pCitta As String = String.Empty
    Public Property pCap As String = String.Empty
    Public Property pIva As String = String.Empty

    Public ReadOnly Property Riassunto As String
        Get
            Dim ris As String = String.Empty

            ris = pRagSoc & " " & pIndirizzo & " - " & pCap & " " & pCitta
            If pRagSoc <> "- Nuova intestazione" Then
                ris &= " P.IVA " & pIva
            End If
            Return ris
        End Get
    End Property

End Class
