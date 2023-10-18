Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailOrdineOk
        Private _O As Consegna

        Public Property O As Consegna
            Get
                Return _O
            End Get
            Set(value As Consegna)
                _O = value
            End Set
        End Property
    End Class

End Namespace