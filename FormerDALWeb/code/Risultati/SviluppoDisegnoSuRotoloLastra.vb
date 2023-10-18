Public Class SviluppoDisegnoSuRotoloLastra
    Public Property Mq As Single = 0
    Public Property LatoFissoPrincipale As Integer = 0
    Public Property LatoFissoSecondario As Integer = 0
    Public Property AreaStampata As Single = 0

    Public ReadOnly Property Scarto As Single
        Get
            Dim ris As Single = 0

            ris = Mq - AreaStampata

            Return ris
        End Get
    End Property
End Class
