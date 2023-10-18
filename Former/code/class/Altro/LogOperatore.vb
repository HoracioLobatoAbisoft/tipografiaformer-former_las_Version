Public Class LogOperatore

    Public Property ImgRif As Image

    Public Property QuandoD As Date

    Public ReadOnly Property Quando As String
        Get
            Return QuandoD.ToString("dd/MM/yyyy HH:mm.ss")
        End Get
    End Property

    Public Property Operatore As String
    Public Property Attivita As String

End Class
