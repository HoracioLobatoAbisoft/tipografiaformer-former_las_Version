Imports FormerDALWeb
Imports FormerLib
Imports FormerBusinessLogicInterface
Imports FormerLib.FormerEnum

Public Class pCarrelloOld
    Inherits FormerSecurePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("/carrello")
        CaricaDati()

        If Carrello.Ordini.Count = 0 Then btnOrdina.Enabled = False

        If Carrello.ApplicatoCouponAlCarrello Then
            lblRisCoupon.Text = "Sconto per Coupon " & Carrello.CodiceCouponApplicato & " applicato all' ordine"
            pnlRisCoupon.Visible = True
        End If

        If Not IsPostBack Then

            CaricaMetodiPagamento()
            CaricaCorriere()
            CaricaIndirizzi()

            RicalcolaDataOrdini()
            VisualizzaDataOrdini()
            VisualizzaInfoCorr()

        End If

    End Sub

    'Public ReadOnly Property GetCorrieriScelti() As String
    '    Get
    '        Dim Ris As String = String.Empty

    '        For Each C As CorriereW In Carrello.CorrieriScelti
    '            Ris &= "<li><b>" & C.Descrizione & "</b><ul>"
    '            Carrello.SpedizioniCumulative.Sort(Function(x, y) x.QuandoStr.CompareTo(y.QuandoStr))
    '            For Each S As SpedizioneCumulativa In Carrello.SpedizioniCumulative
    '                If S.Corriere.IdCorriere = C.IdCorriere Then
    '                    Ris &= "<li>" & StrConv(S.Quando.ToString("dddd dd/MM/yyyy"), vbProperCase) & "</li>"
    '                End If
    '            Next
    '            Ris &= "</ul></li>"
    '        Next
    '        Return Ris
    '    End Get
    'End Property


    Private Function GetCap() As String

        Dim ris As String = String.Empty

        If CInt(rdoCorr.SelectedValue) = enTipoCorriere.ConTariffa Then

            If ddlIndirizzo.SelectedValue Then
                Dim I As New Indirizzo
                I.Read(ddlIndirizzo.SelectedValue)
                ris = I.Cap
            Else
                ris = UtenteConnesso.Utente.Cap
            End If

        End If

        Return ris

    End Function

    Private Sub RicalcolaDataOrdini()
        'qui devo Calcolare la data 

        Dim LCorr As New List(Of ICorriereBusiness)
        Using mgrC As New CorrieriWDAO
            LCorr = mgrC.GetListaCorrieri
        End Using

        Dim CorrScelto As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(CInt(rdoCorr.SelectedValue))

        Dim I As New Indirizzo

        'qui ci va il cap selezionato 
        Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(CorrScelto, LCorr, GetCap)
        Dim CorrDaUsare As New CorriereW
        CorrDaUsare.Read(C.IdCorriere)

        For Each O As ProdottoInCarrello In Carrello.Ordini
            O.Corriere = CorrDaUsare
            Dim listaLavB As New List(Of ILavorazioneB)

            For Each L As LavorazioneW In O.LavorazioniIncluse
                listaLavB.Add(L)
            Next

            Dim DateConsegna As RisDataConsegna = MgrDataConsegna.CalcolaDateConsegna(O.P, C, listaLavB)
            Select Case O.TipoConsegna
                Case enTipoConsegna.Fast
                    O.Quando = "F" & DateConsegna.DataFast.ToString("ddMMyyyy")
                Case enTipoConsegna.Normale
                    O.Quando = "N" & DateConsegna.DataNormale.ToString("ddMMyyyy")
                Case enTipoConsegna.Slow
                    O.Quando = "S" & DateConsegna.DataSlow.ToString("ddMMyyyy")
            End Select

        Next

        VisualizzaDataOrdini()

    End Sub

    Private Sub VisualizzaInfoCorr()
        Dim Ris As String = "(Peso complessivo " & Carrello.Peso & " kg &#177;)"

        If rdoCorr.SelectedValue = enTipoCorriere.ConTariffa Then
            'qui mostro anche chi e' il corriere che il programma decide di mandare

            Dim CorrScelto As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(CInt(rdoCorr.SelectedValue))

            Dim LCorr As New List(Of ICorriereBusiness)
            Using mgrC As New CorrieriWDAO
                LCorr = mgrC.GetListaCorrieri
            End Using

            'qui ci va il cap selezionato 
            Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(CorrScelto, LCorr, GetCap)
            Ris = "Il corriere che le consegnerà il suo ordine è <b>" & C.Descrizione & "</b> " & Ris
        Else
            Ris = "La merce potrà essere ritirata presso la nostra sede di Roma " & Ris
        End If

        lblInfoCorr.Text = Ris

    End Sub

    Private Sub VisualizzaDataOrdini()

        lblDataCons.Text = Carrello.DataConsegnaStr

    End Sub

    Private Sub CaricaIndirizzi()

        If CInt(rdoCorr.SelectedValue) = enTipoCorriere.ConTariffa Then
            pnlSelectIndirizzo.Visible = True
            pnlIndRitiro.Visible = False

            ddlIndirizzo.Items.Clear()

            Dim IdPredef As Integer = 0
            Dim l As New ListItem
            Dim lst As List(Of Indirizzo) = Nothing

            Using Mgr As New IndirizziDAO
                lst = Mgr.FindAll(New LUNA.LunaSearchOption With {.OrderBy = "citta"}, _
                                                         New LUNA.LunaSearchParameter("Idut", UtenteConnesso.IdUtente), _
                                                         New LUNA.LunaSearchParameter("Status", CInt(enStato.Attivo)))
            End Using

            Dim PrimoInd As String = UtenteConnesso.Utente.Nominativo & ", " & UtenteConnesso.Utente.Indirizzo & " - " & UtenteConnesso.Utente.Cap & " " & UtenteConnesso.Utente.Citta & " (" & UtenteConnesso.Utente.Provincia & ")"

            If lst.Find(Function(x) x.Predefinito = True) Is Nothing Then
                PrimoInd &= " (predefinito)"
            End If

            l.Text = PrimoInd
            l.Value = 0

            ddlIndirizzo.Items.Add(l)

            For Each I As Indirizzo In lst
                l = New ListItem
                l.Text = I.Nome & ": " & I.Riassunto
                l.Value = I.IdIndirizzo

                If I.Predefinito Then
                    l.Text &= " (predefinito)"
                    IdPredef = I.IdIndirizzo
                End If

                ddlIndirizzo.Items.Add(l)
            Next

            ddlIndirizzo.SelectedValue = IdPredef
        Else
            pnlSelectIndirizzo.Visible = False
            pnlIndRitiro.Visible = True

        End If
    End Sub

    Private Sub CaricaCorriere()

        Dim l As List(Of MetodoConsegna) = MgrMetodiConsegna.Corrieri

        For Each Corr As MetodoConsegna In l
            Dim UsaCorriere As Boolean = True
            If Corr.OnlyAutorized Then
                If Corr.IdMetodoConsegna <> UtenteConnesso.Utente.IdCorriereDef Then
                    UsaCorriere = False
                End If
            End If
            If UsaCorriere Then
                Dim singC As New ListItem

                Dim Descr As String = "<div class=""TipoCorriere""><img src=""/img/pixel.gif""> <b >" & Corr.Descrizione.ToUpper & "</b>, <i style=""font-size:10px;"">" & Corr.Label & "</i>;</div>"

                singC.Text = Descr
                singC.Value = Corr.IdMetodoConsegna
                If UtenteConnesso.Utente.IdCorriereDef = Corr.IdMetodoConsegna Then
                    singC.Selected = True
                End If
                rdoCorr.Items.Add(singC)
            End If
        Next

        'ddlCorriere.Attributes("onChange") = "SetQuandoDefault();"

    End Sub

    Private Sub CaricaMetodiPagamento()

        rdoPagam.Items.Clear()

        Using mgr As New TipiPagamentiWDAO
            Dim l As List(Of TipoPagamentoW) = mgr.FindAll("OrdOnline", New LUNA.LunaSearchParameter("OrdOnline", 0, " <> "))

            If l.Find(Function(x) x.IdTipoPagam = UtenteConnesso.DefaultTipoPagamento) Is Nothing Then
                Dim Pdef As New TipoPagamentoW
                Pdef.Read(UtenteConnesso.DefaultTipoPagamento)
                l.Add(Pdef)
                If UtenteConnesso.DefaultTipoPagamento = enMetodoPagamento.AllaConsegna Then
                    Dim voceContrass As TipoPagamentoW = l.Find(Function(x) x.IdTipoPagam = enMetodoPagamento.ContrassegnoAlRitiro)
                    l.Remove(voceContrass)
                End If
            End If

            For Each singP As TipoPagamentoW In l
                Dim CheckImporto As Boolean = True

                If singP.ImportoMassimoPagabile <> 0 AndAlso Carrello.TotaleCarrello > singP.ImportoMassimoPagabile Then
                    CheckImporto = False
                End If

                If CheckImporto Then
                    Dim listSing As New ListItem
                    listSing.Text = "<div class=""TipoPagamento""><img src=""" & singP.ImgWeb & """><b>" & singP.TipoPagam & "</b>, " & singP.Descrizione

                    If singP.ImportoMaggiorazione Then
                        listSing.Text &= " (* Può comportare una maggiorazione di <b>€ " & FormerHelper.Stringhe.FormattaPrezzo(singP.ImportoMaggiorazione) & "</b>)"
                    End If
                    listSing.Text &= "</div>"
                    listSing.Value = singP.IdTipoPagam
                    'If listSing.Value = UtenteConnesso.DefaultTipoPagamento Then listSing.Selected = True
                    rdoPagam.Items.Add(listSing)
                End If
            Next

            Dim TrovatoDefault As Boolean = False
            For Each item As ListItem In rdoPagam.Items
                If item.Value = UtenteConnesso.DefaultTipoPagamento Then
                    item.Selected = True
                    Dim P As New TipoPagamentoW
                    P.Read(item.Value)
                    Carrello.MetodoPagamentoScelto = P
                End If
            Next

        End Using

        'qui devo selezionare il default, se non c'e' default scelgo paypal. Se il default non e' presente in quelli standard lo aggiungo perche sicuramente ha un accordo 

    End Sub

    Private Sub CaricaDati()
        rptOrdini.DataSource = Carrello.Ordini
        rptOrdini.DataBind()
    End Sub

    Private Sub btnSvuota_Click(sender As Object, e As ImageClickEventArgs) Handles btnSvuota.Click

        Carrello.SvuotaCarrello()

        Response.Redirect("/carrello")
    End Sub

    Private Sub rptOrdini_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptOrdini.ItemCommand

        If e.CommandName = "DelOrd" Then
            Carrello.RimuoviOrdine(e.CommandArgument)
            Response.Redirect("/carrello")
        End If
    End Sub

    Protected Sub btnOrdina_Click(sender As Object, e As ImageClickEventArgs) Handles btnOrdina.Click

        If UtenteConnesso.IdUtente Then
            btnOrdina.Enabled = False
            'salvo gli ordini dal carrello al db e lo svuoto 
            Dim P As New TipoPagamentoW
            P.Read(rdoPagam.SelectedValue)
            Carrello.MetodoPagamentoScelto = P
            If ddlIndirizzo.SelectedValue.Length Then
                Carrello.IdIndirizzoScelto = ddlIndirizzo.SelectedValue
            ElseIf CInt(rdoCorr.SelectedValue) = enTipoCorriere.PortoAssegnato Then
                Carrello.IdIndirizzoScelto = UtenteConnesso.DefaultIdIndirizzoPredefinito
            End If

            Dim IdOrdineSalvato As Integer = 0
            Dim NextUrl As String = "/i-tuoi-lavori"

            IdOrdineSalvato = Carrello.SalvaOrdine
            If IdOrdineSalvato Then
                'VECCHIO SALVATAGGIO ORDINI
                'ORA TUTTO VA FATTO IN TRANSAZIONE 
                'For Each P As ProdottoInCarrello In Carrello.Ordini
                '    P.Salva()
                '    InviaMailOrdineOK(P)
                'Next

                'qui se devo pagare vado al dettaglio ordine 
                'altrimenti alla lista ordini
                InviaMailOrdineOK(IdOrdineSalvato)
                If P.PeriodoPagam = enPeriodoPagamento.Anticipato Then
                    NextUrl = "/" & IdOrdineSalvato & "/dettaglio-ordine"
                End If
                Carrello.SvuotaCarrello()

            End If

            Response.Redirect(NextUrl)

        Else
            Response.Redirect(FormerRouting.GetLoginPage) '"/Login"
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

        End Try


    End Sub

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

    Protected Function GetTotOrdCarrello() As Integer

        Dim Ris As Integer = 0
        If Not Session("Carrello") Is Nothing Then
            Dim C As Carrello = Session("Carrello")
            Ris = C.Ordini.Count

        End If
        Return Ris

    End Function

    Private Sub btnIndietroCarr_Click(sender As Object, e As ImageClickEventArgs) Handles btnIndietroCarr.Click

        If Session("UltimoProdottoVisitato") Is Nothing Then
            Response.Redirect("/")
        Else
            Response.Redirect(Session("UltimoProdottoVisitato"))
        End If
    End Sub

    Private Sub rdoCorr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoCorr.SelectedIndexChanged

        ''cambio il corriere in tutti gli ordini
        'Dim CorrScelto As MetodoConsegna = MgrMetodiConsegna.GetMetodoConsegna(CInt(rdoCorr.SelectedValue))

        'Dim LCorr As New List(Of ICorriereBusiness)
        'Using mgrC As New CorrieriWDAO
        '    LCorr = mgrC.GetListaCorrieri
        'End Using

        ''qui ci va il cap selezionato 
        'Dim C As ICorriereBusiness = MgrMetodiConsegna.GetICorriereB(CorrScelto, LCorr, GetCap)
        'Dim CorrDaUsare As New CorriereW
        'CorrDaUsare.Read(C.IdCorriere)

        'For Each o As ProdottoInCarrello In Carrello.Ordini
        '    o.Corriere = CorrDaUsare
        'Next

        CaricaIndirizzi()
        RicalcolaDataOrdini()
        VisualizzaInfoCorr()

    End Sub

    Private Sub ddlIndirizzo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlIndirizzo.SelectedIndexChanged

        RicalcolaDataOrdini()
        VisualizzaInfoCorr()

    End Sub

    Private Sub rdoPagam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rdoPagam.SelectedIndexChanged
        Dim P As New TipoPagamentoW
        P.Read(rdoPagam.SelectedValue)
        Carrello.MetodoPagamentoScelto = P

    End Sub

    Private Sub btnCoupon_Click(sender As Object, e As ImageClickEventArgs) Handles btnCoupon.Click

        Dim ValCoupon As String = Server.HtmlEncode(txtCoupon.Text)

        Dim Ris As String = Carrello.ApplicaCoupon(ValCoupon, UtenteConnesso.Tipo)

        txtCoupon.Text = ValCoupon.ToUpper()

        If Ris.Length Then
            lblRisCoupon.Text = Ris
            pnlRisCoupon.Visible = True
        Else
            lblRisCoupon.Text = String.Empty
            pnlRisCoupon.Visible = False
        End If

    End Sub

    Private Sub lnkSvuota_Click(sender As Object, e As EventArgs) Handles lnkSvuota.Click
        Carrello.SvuotaCarrello()

        Response.Redirect("/carrello")
    End Sub
End Class