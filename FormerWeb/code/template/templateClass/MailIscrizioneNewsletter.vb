Imports FormerDALWeb
Imports FormerLib
Namespace My.Templates

    Partial Public Class MailIscrizioneNewsletter
        Private _Email As String
        Public Property Email As String
            Get
                Return _Email
            End Get
            Set(value As String)
                _Email = value
            End Set
        End Property

        Public ReadOnly Property EmailCrypt As String
            Get
                Dim EmailFull As String = FormerHelper.Security.GeneraPassword() & Email
                Dim ris As String = FormerHelper.Security.CriptaURL(EmailFull)
                Return ris
            End Get
        End Property
    End Class

End Namespace