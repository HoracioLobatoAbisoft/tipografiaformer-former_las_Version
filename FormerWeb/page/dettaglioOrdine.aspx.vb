Imports FormerDALWeb
Imports FormerLib.FormerEnum
Imports FormerBusinessLogicInterface
Imports CuteWebUI
Imports System.IO
Imports FormerBancaSella
Imports FormerLib
Imports FormerBusinessLogic

Public Class pDettaglioOrdine
    Inherits FormerSecurePage
    Protected NextUrl As String = "/"
    Private _IdConsegna As Integer = 0
    Private _C As Consegna = Nothing

    Public ReadOnly Property Ordine As Consegna
        Get
            Return _C
        End Get
    End Property

    Public Function GetTraceUrl() As String

        Dim Url As String = String.Empty

        Select Case Ordine.IdCorriere
            Case enCorriere.GLS, enCorriere.PortoAssegnatoGLS, enCorriere.GLSIsole
                Url = MgrTraceCorriere.GetUrlTraceGLS(Ordine.CodTrack)
                'in caso di GLS basta mettere il codtrack nell'url 
            Case enCorriere.Bartolini, enCorriere.PortoAssegnatoBartolini
                Url = MgrTraceCorriere.GetUrlTraceBartolini(Ordine.CodTrack)
        End Select

        Return Url

    End Function

    Public ReadOnly Property MostraBancaSella As Boolean
        Get
            Dim ris As Boolean = False

            Return ris
        End Get
    End Property

    Public Function GetIdConsView() As String
        Dim ris As String = String.Empty

        If Ordine.IdConsegnaInt Then
            ris = Ordine.IdConsegnaInt
        Else
            ris = "PROVVISORIO " & Ordine.IdConsegna
        End If

        Return ris
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _IdConsegna = Convert.ToInt32(Page.RouteData.Values("ido"))
        Dim CheckVisOrd As Boolean = False

        If _IdConsegna Then
            _C = New Consegna
            _C.Read(_IdConsegna)
            If _C.IdConsegna Then
                If _C.IdUt = UtenteConnesso.IdUtente AndAlso _C.IdStatoConsegna <> enStatoConsegna.Eliminata Then
                    CheckVisOrd = True
                End If
            End If
        End If

        If CheckVisOrd = False Then
            Response.Redirect("/i-tuoi-ordini")
        End If

        rptOrdini.DataSource = _C.ListaOrdini
        rptOrdini.DataBind()

        'se il pagamento e' gia stato fatto scrivo che e' stato fatto altrimenti scrivo il metodo di pagamento scelto e lascio
        'la possibilta di pagare in qualsiasi modo
        If _C.IdStatoConsegna = enStatoConsegna.Pagato OrElse Not _C.PagamentoOrdine Is Nothing Then
            pnlPagamAnticip.Visible = False
            pnlPagamentoEffettuato.Visible = True
            If _C.PagamentoOrdine Is Nothing Then
                lblPagamentoEffettuato.Text = "Il Pagamento è stato Registrato ma i dettagli del pagamento non sono disponibili."
            Else
                lblPagamentoEffettuato.Text = "<img src=""" & _C.PagamentoOrdine.TipoPagamento.ImgWeb & """ class=""roundedBorder"" /> Pagamento effettuato <b>" & _C.PagamentoOrdine.Quando.ToString("dddd dd MMMM alle HH:mm:ss") & "</b> tramite <b>" & _C.PagamentoOrdine.TipoPagamento.TipoPagam & "</b>"
            End If
        End If

        CheckDocPDF()

    End Sub

    Private Sub CheckDocPDF()

        Dim Path As String = FormerWebApp.PathConsegne & _IdConsegna & "\"

        Dim Dire As New DirectoryInfo(Path)
        If _C.IdConsegnaInt Then
            If Directory.Exists(Path) Then
                If Dire.GetFiles("*.pdf").Count Then
                    lblDocFiscDownload.Visible = True
                    lblNoDocFisc.Visible = False
                Else
                    lblDocFiscDownload.Visible = False
                    lblNoDocFisc.Visible = True
                End If
            End If
        End If

    End Sub

    Public ReadOnly Property Pagabile As Boolean
        Get
            Dim ris As Boolean = True

            If _C.IdStatoConsegna <> enStatoConsegna.InAttesaDiPagamento Then
                ris = False
            End If

            If _C.GuidTransazione.Length = 0 Then ris = False

            Return ris
        End Get
    End Property

    Private Sub rptOrdini_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOrdini.ItemDataBound

        Dim O As OrdineWeb = e.Item.DataItem
        Dim HO As ucBoxHeaderLavoro = e.Item.FindControl("HeaderLavoro")
        Dim CO As ucBoxCorpoLavoro = e.Item.FindControl("CorpoLavoro")
        Dim FO As ucBoxFooterLavoro = e.Item.FindControl("FooterLavoro")

        If Not HO Is Nothing Then
            HO.Ordine = O
            CO.Ordine = O
            FO.Ordine = O
        End If

    End Sub

    Private Sub lblDocFiscDownload_Click(sender As Object, e As EventArgs) Handles lblDocFiscDownload.Click

        'qui gestisco il download
        'creo la chiamata alla pagina di download utilizzando una funzione della helper in security
        Dim path As String = "/scarica-documento-fiscale/" & FormerLib.FormerHelper.Security.CriptaID(_C.IdConsegnaInt)

        Response.Redirect(path)

    End Sub

    Private Sub btnPayBancaSella_Click(sender As Object, e As EventArgs) Handles btnPayBancaSella.Click

        Dim R As New BancaSellaRequest

        R.amount = Ordine.ImportoTot
        R.ShopTransactionId = Ordine.GuidTransazione 'Ordine.IdConsegna
        'R.CustomInfo = "Guid=" & Ordine.GuidTransazione

        Dim bsResult As BancaSellaResult = MgrBancaSella.Encript(R)

        If bsResult.Risultato = "OK" Then

            Dim urlToGo As String = MgrBancaSella.UrlPageCreator(bsResult)

            Response.Redirect(urlToGo)
        Else
            Dim Subject As String = "Errore in chiamata Gestpay"
            Dim Testo As String = bsResult.ErrorDescription
            FormerLib.FormerHelper.Mail.InviaMail(Subject, Testo, FormerConst.EmailAssistenzaTecnica)

        End If

    End Sub
End Class