Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucRandomListinoBase
    Inherits FormerUserControl
    Private _ListinoBase As ListinoBaseW
    Public Property ListinoBase As ListinoBaseW
        Get
            If _ListinoBase Is Nothing Then _ListinoBase = New ListinoBaseW
            Return _ListinoBase
        End Get
        Set(value As ListinoBaseW)
            _ListinoBase = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub Carica()

        'inizializza il controllo
        Dim l As List(Of ListinoBaseW) = Nothing

        If FormerWebApp.UseStaticCollection = enSiNo.Si Then
            l = FormerWebApp.StaticListiniBase.FindAll(Function(x) x.FormatoProdotto.ProdottoFinito = True)
        Else
            Using mgr As New ListinoBaseWDAO
                l = mgr.ListiniUtilizzabili.FindAll(Function(x) x.FormatoProdotto.ProdottoFinito = True)
            End Using
        End If

        If l.Count Then
            Dim Quale As Integer = 0
            Dim rnd As New Random
            Randomize()

            Quale = rnd.Next(0, l.Count - 1)
            ListinoBase = l(Quale)

        Else
            ListinoBase = New ListinoBaseW
        End If

    End Sub

End Class