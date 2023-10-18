Imports FormerDALWeb
Imports FormerLib.FormerEnum

Public Class ucReviewAdd
    Inherits FormerUserControl

    'Public Event RecensioneSalvata()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Lavoro Is Nothing Then Cache("Lavoro") = Lavoro
        End If
    End Sub

    'Public Property PrevedeCoupon As Boolean = False

    Private _Lavoro As OrdineWeb = Nothing
    Public Property Lavoro As OrdineWeb
        Get
            If _Lavoro Is Nothing Then
                If Not Cache("Lavoro") Is Nothing Then
                    _Lavoro = Cache("Lavoro")
                End If
            End If
            Return _Lavoro
        End Get
        Set(value As OrdineWeb)
            _Lavoro = value
        End Set
    End Property

    Public Property IdLavoro As Integer = 0

    Private Sub lnkSalva_Click(sender As Object, e As EventArgs) Handles lnkSalva.Click

        Dim PrevedeCoupon As Integer = enSiNo.No

        'qui vedo se prevede coupon
        If FormerLib.FormerConst.Coupon.ImportoCouponScontoPerRecensione Then

            Using mgr As New ReviewDAO
                Dim l As List(Of Review) = mgr.FindAll(New LUNA.LunaSearchParameter("IdUt", UtenteConnesso.IdUtente), _
                                                       New LUNA.LunaSearchParameter("IdListinoBase", Lavoro.IdListinoBase))
                If l.Count = 0 Then
                    PrevedeCoupon = enSiNo.Si
                End If
            End Using

        End If


        Dim Voto As Integer = 0

        Voto = rdoVoto.SelectedValue

        Using R As New Review

            R.IdUt = UtenteConnesso.IdUtente
            R.IdLavoro = Lavoro.IdOrdine
            R.IdListinoBase = Lavoro.IdListinoBase
            R.Voto = Voto
            R.Pregi = txtPro.Text
            R.Difetti = txtContro.Text
            R.Quando = Now
            R.Stato = enStatoReview.DaApprovare
            R.PrevedeCoupon = PrevedeCoupon
            R.Save()

        End Using

        Response.Redirect("/le-tue-recensioni")
       
        'RaiseEvent RecensioneSalvata()

    End Sub

    Public Function GetNome() As String
        Dim ris As String = String.Empty

        If Not Lavoro Is Nothing Then
            ris = Lavoro.L.Nome
        End If

        Return ris
    End Function

    Public Function GetIco() As String
        Dim ris As String = String.Empty

        If Not Lavoro Is Nothing Then
            ris = FormerWeb.FormerWebApp.PathListinoImg & Lavoro.BoxImgRif
        End If

        Return ris
    End Function

End Class