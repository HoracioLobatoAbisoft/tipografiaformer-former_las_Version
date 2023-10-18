Imports FormerDALWeb

Public Class ucPrevPromo
    Inherits FormerUserControl
    Public Property WithHeader As Boolean = False
    Public Property WithFooter As Boolean = True
    Private _Preventivazione As PreventivazioneW
    Public Property Preventivazione As PreventivazioneW
        Get
            If _Preventivazione Is Nothing Then
                _Preventivazione = New PreventivazioneW
            End If

            Return _Preventivazione
        End Get
        Set(value As PreventivazioneW)
            _Preventivazione = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class