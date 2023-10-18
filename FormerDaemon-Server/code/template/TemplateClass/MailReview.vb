Imports FormerDALSql
Namespace My.Templates

    Partial Public Class MailReview
        Private _U As VoceRubrica

        Public Property U As VoceRubrica
            Get
                Return _U
            End Get
            Set(value As VoceRubrica)
                _U = value
            End Set
        End Property

        Private _O As Ordine
        Public Property O As Ordine
            Get
                Return _O
            End Get
            Set(value As Ordine)
                _O = value
            End Set
        End Property

    End Class

End Namespace