Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloRiepilogo
    Inherits FormerSecurePage

    Public ReadOnly Property GetCorriereScelto As String
        Get
            Dim ris As String = String.Empty
            Dim M As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(Carrello.IdMetodoConsegnaScelto)
            ris = M.Descrizione
            Return ris
        End Get
    End Property

    Public ReadOnly Property GetLabelCorriereScelto As String
        Get
            Dim ris As String = String.Empty
            Dim M As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(Carrello.IdMetodoConsegnaScelto)
            ris = M.Label
            Return ris
        End Get
    End Property

    Public ReadOnly Property GetIndirizzoScelto As String

        Get
            Dim Ris As String = String.Empty
            If Carrello.IdIndirizzoScelto > 0 Then
                Using I As New Indirizzo
                    I.Read(Carrello.IdIndirizzoScelto)
                    Ris = I.Riassunto
                End Using
            Else
                Ris = UtenteConnesso.Utente.Nominativo & ", " & UtenteConnesso.Utente.Indirizzo & " - " & UtenteConnesso.Utente.Cap & " " & UtenteConnesso.Utente.Citta
            End If
            Return Ris
        End Get

    End Property

    Public ReadOnly Property GetLabelMetodoPagamento As String
        Get
            Dim ris As String = String.Empty

            If Carrello.MetodoPagamentoScelto.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro Then

                If Carrello.IdMetodoConsegnaScelto = enTipoCorriere.Gratis Then
                    ris = "Al Ritiro"
                Else
                    ris = "Contrassegno"
                End If
            Else
                ris = Carrello.MetodoPagamentoScelto.TipoPagam
            End If

            Return ris
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load





        Dim GiaChiestoAggiornamentoDF As Boolean = False

        Try
            GiaChiestoAggiornamentoDF = Session("GiaChiestoAggiornamentoDF")
        Catch ex As Exception

        End Try

        If GiaChiestoAggiornamentoDF = False AndAlso UtenteConnesso.AggiornareDatiFiscali = True Then
            Response.Redirect("/aggiorna-dati-fiscali")
        Else
            If UtenteConnesso.UtenteAutorizato Then
                Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/carrelloStp5"
                Dim Eviroment As Boolean = UtenteConnesso.Eviroment

                'If Eviroment Then
                '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/carrelloStp5"
                'Else
                '    UrlProdottoEnviroment = "http://localhost:5173/#/carrelloStp5"
                'End If
                IframecarreloStp5.Text = "<iframe id='carrelloStp3' style='width:100%; height: 100vh;border: none;' src=" & UrlProdottoEnviroment & " ></iframe>"
            Else
                If Carrello.Ordini.Count = 0 Then
                    Response.Redirect("/carrello")
                Else
                    CaricaDati()
                End If
            End If
        End If
    End Sub

    Private Sub CaricaDati()
        rptOrdini.DataSource = Carrello.Ordini
        rptOrdini.DataBind()
    End Sub

    Private Sub rptOrdini_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptOrdini.ItemCommand

        If e.CommandName = "DelOrd" Then
            Carrello.RimuoviOrdine(e.CommandArgument)
            Response.Redirect("/carrello")
        End If
    End Sub

    Protected Function GetTotOrdCarrello() As Integer

        Dim Ris As Integer = 0
        If Not Session("Carrello") Is Nothing Then
            Dim C As Carrello = Session("Carrello")
            Ris = C.Ordini.Count

        End If
        Return Ris

    End Function

    Private Sub rptOrdini_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOrdini.ItemDataBound

        Dim O As ProdottoInCarrello = e.Item.DataItem
        Dim HO As ucBoxHeaderLavoro = e.Item.FindControl("HeaderOrdine")
        Dim CO As ucBoxCorpoLavoro = e.Item.FindControl("CorpoOrdine")
        Dim FO As ucBoxFooterLavoro = e.Item.FindControl("FooterOrdine")

        If Not HO Is Nothing Then
            HO.Ordine = O
            CO.Ordine = O
            FO.Ordine = O
        End If

    End Sub

    Private Sub btnOrdina_Click(sender As Object, e As EventArgs) Handles btnOrdina.Click

        If UtenteConnesso.IdUtente Then
            btnOrdina.Enabled = False
            'salvo gli ordini dal carrello al db e lo svuoto 

            If Carrello.IdMetodoConsegnaScelto = enTipoCorriere.PortoAssegnato Then
                Carrello.IdIndirizzoScelto = UtenteConnesso.DefaultIdIndirizzoPredefinito
            End If

            Dim IdOrdineSalvato As Integer = 0
            'Dim NextUrl As String = "/i-tuoi-lavori"
            Dim NextUrl As String = "/ordine-confermato"

            IdOrdineSalvato = Carrello.SalvaOrdine
            If IdOrdineSalvato Then
                'qui se devo pagare vado al dettaglio ordine 
                'altrimenti alla lista ordini
                InviaMailOrdineOK(IdOrdineSalvato)
                'If Carrello.MetodoPagamentoScelto.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                '    NextUrl = "/" & IdOrdineSalvato & "/dettaglio-ordine"
                'Else
                '    'qui se un solo lavoro manda al dettaglio lavoro
                '    Using c As New Consegna
                '        c.Read(IdOrdineSalvato)
                '        If c.ListaOrdini.Count = 1 Then
                '            Dim IdLavoro As Integer = c.ListaOrdini(0).IdOrdine
                '            NextUrl = "/" & IdLavoro & "/dettaglio-lavoro"
                '        End If
                '    End Using

                'End If
                Carrello.SvuotaCarrello()
                Carrello.IdIndirizzoScelto = UtenteConnesso.DefaultIdIndirizzoPredefinito
            Else
                NextUrl = "/opsss"
            End If

            Response.Redirect(NextUrl)

        Else
            Response.Redirect(FormerRouting.GetLoginPage) '"/login")
        End If

    End Sub

    Private Sub InviaMailOrdineOK(IdOrdine As Integer)

        'INVIO MAIL DI CONFERMA DELL'ORDINE RICEVUTO
        Dim O As New Consegna
        O.Read(IdOrdine)

        Dim Pt As New My.Templates.MailOrdineOk
        Pt.O = O
        Dim Buffer As String = Pt.TransformText

        Try
            FormerHelper.Mail.InviaMail("Il suo Ordine è stato Inserito", Buffer, UtenteConnesso.Utente.Email)
        Catch ex As Exception
            Dim test As String = ex.Message
        End Try

    End Sub

End Class