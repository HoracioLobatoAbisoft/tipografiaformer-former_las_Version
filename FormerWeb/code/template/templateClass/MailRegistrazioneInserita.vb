Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailRegistrazioneInserita
        Private _U As Utente

        Public Property U As Utente
            Get
                Return _U
            End Get
            Set(value As Utente)
                _U = value
            End Set
        End Property

        Private _Pwd As String
        Public Property Pwd As String
            Get
                Return _Pwd
            End Get
            Set(value As String)
                _Pwd = value
            End Set
        End Property

    End Class

End Namespace