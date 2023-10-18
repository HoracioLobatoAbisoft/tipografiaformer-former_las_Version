Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailPwdChanged

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