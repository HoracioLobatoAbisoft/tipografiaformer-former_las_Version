Public Class cCaller

    Public Sub New(BufferCallerId As String)

        'il buffer e' Numerotel,IdRub,Nominativo

        Dim DatiC As String() = BufferCallerId.Split("§")

        NumeroTel = DatiC(0)

        If DatiC.Length > 1 Then
            IdRub = DatiC(1)
            Nominativo = DatiC(2)
        End If

    End Sub

    Public Property IdRub As Integer = 0
    Public Property NumeroTel As String = String.Empty
    Public Property Nominativo As String = String.Empty

End Class
