Public Class AzioneFustella

    Public Property Counter As Integer = 0
    Public Property Descrizione As String = String.Empty
    Public Property Valore As Single = 0

    Public ReadOnly Property ValoreStr As String
        Get
            Return FormattaMM(Valore)
        End Get
    End Property

    Public Property Tipo As String = String.Empty
    Public Property Angolo As Integer = 0
    Public Property Raggio As String = String.Empty

    Private Function FormattaMM(Val As Single) As String

        Dim ris As String = Format(Val, "#,##0.00")
        Return ris

    End Function

End Class
