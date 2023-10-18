Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailRichiestaPreventivo
        Private _R As RichiestaPreventivoLogica


        Public Property R As RichiestaPreventivoLogica
            Get
                Return _R
            End Get
            Set(value As RichiestaPreventivoLogica)
                _R = value
            End Set
        End Property
    End Class

End Namespace