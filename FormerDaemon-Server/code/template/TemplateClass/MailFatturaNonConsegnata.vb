Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailFatturaNonConsegnata
        Private _U As Utente

        Public Property U As Utente
            Get
                Return _U
            End Get
            Set(value As Utente)
                _U = value
            End Set
        End Property
    End Class

End Namespace