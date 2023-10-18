Public Class ScatolaProposta

    Public Property TipoScatola As TipoScatola

    Public Property Cubetti As New List(Of Cubetto)


    Public ReadOnly Property Peso As Single
        Get
            Dim ris As Single = 0

            For Each c As Cubetto In Cubetti
                ris += c.Peso
            Next

            Return ris
        End Get
    End Property

End Class
