
Public Class MgrPercentualiDay

    Public Shared ReadOnly Property PercentualeFast(P As IPreventivazioneB) As Single
        Get
            Dim Ris As Single = 1.15
            If P.PercFast Then
                Ris = P.PercFast / 100
            End If
            Return Ris
        End Get
    End Property

    Public Shared ReadOnly Property PercentualeNormale As Single
        Get
            Return 1
        End Get
    End Property


    Public Shared ReadOnly Property PercentualeSlow(P As IPreventivazioneB) As Single
        Get
            Dim Ris As Single = 0.95
            If P.PercSlow Then
                Ris = P.PercSlow / 100
            End If
            Return Ris
        End Get
    End Property

End Class
