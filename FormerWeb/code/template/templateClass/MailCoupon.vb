Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class MailCoupon
        Private _C As CouponW

        Public Property C As CouponW
            Get
                Return _C
            End Get
            Set(value As CouponW)
                _C = value
            End Set
        End Property
    End Class

End Namespace