
Public Class FormerPricingHelper

    Public Shared ReadOnly Property PercentualeFast(P As ipreventivazione) As Single
        Get
            Return 1.15
        End Get
    End Property

    Public Shared ReadOnly Property PercentualeNormale As Single
        Get
            Return 1
        End Get
    End Property


    Public Shared ReadOnly Property PercentualeSlow As Single
        Get
            Return 0.95
        End Get
    End Property

End Class
