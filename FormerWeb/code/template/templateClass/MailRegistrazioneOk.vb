Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailRegistrazioneOk
        Private _R As RichiestaRegistrazioneW

        Public Property R As RichiestaRegistrazioneW
            Get
                Return _R
            End Get
            Set(value As RichiestaRegistrazioneW)
                _R = value
            End Set
        End Property
    End Class

End Namespace