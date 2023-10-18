Imports FormerDALWeb
Namespace My.Templates

    Partial Public Class PreventivazioneWizard
        Private _P As PreventivazioneW

        Public Property P As PreventivazioneW
            Get
                Return _P
            End Get
            Set(value As PreventivazioneW)
                _P = value
            End Set
        End Property
    End Class

End Namespace