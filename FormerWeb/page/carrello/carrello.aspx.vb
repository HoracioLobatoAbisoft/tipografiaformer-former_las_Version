Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrello
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'check dati fiscali

        Dim Eviroment As Boolean = UtenteConnesso.Eviroment
        Dim UrlProdottoEnviroment As String = UtenteConnesso.UrlIframe & "/carrelloStp1"
        'If Eviroment Then
        '    UrlProdottoEnviroment = "https://react.tipografiaformertest.it:6060/#/carrelloStp1"
        'Else
        '    UrlProdottoEnviroment = "http://localhost:5173/#/carrelloStp1"
        'End If

        If UtenteConnesso.UtenteAutorizato Then
            Dim UrlProdotto2 As String = UrlProdottoEnviroment

            iframeCarrello.Text = "<iframe id='carrelloStp1' style='width:100%; height: 100vh;border: none;' src=" & UrlProdotto2 & " ></iframe>"
        End If
        CaricaDati()

    End Sub

    Public Function MostraOmaggi() As Boolean

        Dim ris As Boolean = True

        ''se non ha gia in carrello un omaggio puo avere un omaggio
        ''se ci sono omaggi puo avere un omaggio

        'If Carrello.Ordini.Count <> 0 Then
        '    '    ris = False
        '    'Else
        '    If Carrello.Ordini.FindAll(Function(x) x.Omaggio = enSiNo.Si).Count Then
        '        ris = False
        '    End If
        'End If

        'If ris Then
        '    Using p As New PreventivazioneW
        '        p.Read(FormerConst.ProdottiParticolari.IdPreventivazioneOmaggi)
        '        Dim l As List(Of ListinoBaseW) = p.GetListiniBase

        '        If l.FindAll(Function(x) x.Disattivo = enSiNo.No).Count = 0 Then
        '            ris = False
        '        End If

        '    End Using
        'End If

        'If ris Then
        '    'qui vado a valutare quali omaggi mostrare
        '    Dim l As List(Of OmaggioW) = MgrOmaggi.GetOmaggi(UtenteConnesso)

        '    If l.Count = 0 Then
        '        ris = False
        '    End If
        'End If
        ris = MgrOmaggi.MostraOmaggi(UtenteConnesso, Carrello.Ordini)

        Return ris

    End Function

    Private Sub CaricaOmaggi()

        rptOmaggi.DataSource = MgrOmaggi.GetOmaggi(UtenteConnesso)
        rptOmaggi.DataBind()

    End Sub

    Private Sub CaricaDati()
        rptOrdini.DataSource = Carrello.Ordini
        rptOrdini.DataBind()

        CaricaOmaggi()
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

    Private Sub lnkSvuota_Click(sender As Object, e As EventArgs) Handles lnkSvuota.Click
        Carrello.SvuotaCarrello()
        Carrello.IdIndirizzoScelto = UtenteConnesso.DefaultIdIndirizzoPredefinito
        Response.Redirect("/carrello")
    End Sub

    Private Sub rptOmaggi_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptOmaggi.ItemCommand
        If e.CommandName = "Aggiungi" Then
            Dim IdOmaggioToAdd As Integer = e.CommandArgument

            'qui devo aggiungere al carrello l'omaggio scelto in quantita 1
            Dim O As ProdottoInCarrello = GetOmaggioScelto(IdOmaggioToAdd)

            Carrello.AggiungiOrdine(O)
            Response.Redirect("/carrello")

        End If
    End Sub

    Private Function GetOmaggioScelto(IdOmaggioScelto As Integer) As ProdottoInCarrello

        Dim O As ProdottoInCarrello = New ProdottoInCarrello()
        Using Omg As New OmaggioW

            Omg.Read(IdOmaggioScelto)

            O.L = Omg.ListinoBaseOmaggio
            O.C = Omg.ListinoBaseOmaggio.ColoreStampa
            O.F = Omg.ListinoBaseOmaggio.FormatoProdotto
            O.P = Omg.ListinoBaseOmaggio.Preventivazione

            O.IdOmaggioRegola = IdOmaggioScelto

            Dim LCorr As New List(Of ICorriereBusiness)
            Using mgrC As New CorrieriWDAO
                LCorr = mgrC.GetListaCorrieri
            End Using

            Dim Cap As String = UtenteConnesso.Utente.Cap

            If Carrello.IdIndirizzoScelto = -1 Then
                If UtenteConnesso.DefaultIdIndirizzoPredefinito Then
                    Using i As New Indirizzo
                        i.Read(UtenteConnesso.DefaultIdIndirizzoPredefinito)
                        Cap = i.Cap
                    End Using
                End If
            Else
                If Carrello.IdIndirizzoScelto <> 0 Then
                    Using i As New Indirizzo
                        i.Read(Carrello.IdIndirizzoScelto)
                        Cap = i.Cap
                    End Using
                End If
            End If

            Dim Cs As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(UtenteConnesso.Utente.Corriere, LCorr, Cap, FormerWebApp.NonPrendereInConsiderazioneCorriereFormer)

            Dim Corr As New CorriereW
            Corr.Read(Cs.IdCorriere)

            O.Corriere = Corr
            O.TC = Omg.ListinoBaseOmaggio.TipoCarta
            O.Qta = Omg.QtaOmaggio
            If Carrello.SpedizioneCumulativa Is Nothing Then
                O.Quando = "N" & Now.ToString("ddMMyyyy")
            Else
                O.Quando = "N" & Carrello.SpedizioneCumulativa.Quando.ToString("ddMMyyyy")
            End If

            O.NFogli = 1
            O.NFogliVis = 1

            O.NomeLavoro = "OMAGGIO " & Omg.ListinoBaseOmaggio.Nome.Substring(0, Omg.ListinoBaseOmaggio.Nome.IndexOf(" "))
            O.OrdineOmaggio = enSiNo.Si

            O.OrientamentoScelto = Omg.ListinoBaseOmaggio.FormatoProdotto.Orientamento

            O.PrezzoCalcolatoNettoOriginale = 0
            O.Colli = 1
            O.Peso = 1
            O.Note = Omg.CondizioneStr
            O.LavorazioniIncluse = New List(Of LavorazioneW)

        End Using

        Return O

    End Function

    Private Sub rptOmaggi_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptOmaggi.ItemDataBound

        Dim c As Control = e.Item.FindControl("btnAddOmaggio")

        If Not c Is Nothing Then

            Using O As OmaggioW = e.Item.DataItem

                If MgrOmaggi.OmaggioUtilizzabile(O, Carrello.Ordini, Carrello.TotaleImportiNetti) = False Then
                    c.Visible = False

                    Dim pnl As Control = e.Item.FindControl("pnlInfoOmaggio")

                    pnl.Visible = True

                End If
            End Using

        End If

    End Sub
End Class