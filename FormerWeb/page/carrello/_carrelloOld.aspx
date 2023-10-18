<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="_carrelloOld.aspx.vb" Inherits="FormerWeb.pCarrelloOld" %>
<%@ Register  TagPrefix="FormerWeb" TagName="HeaderOrdine" Src="~/userControl/ucBoxHeaderLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="CorpoOrdine" Src="~/userControl/ucBoxCorpoLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="FooterOrdine" Src="~/userControl/ucBoxFooterLavoro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        $(function () {
            var icons = {
                header: "ui-icon-plus",
                activeHeader: "ui-icon-minus"
            };
            $("#accordion").accordion({
                icons: icons,
                collapsible: true,
                heightStyle: "content"
            });

        });
    </script>
    <script>
        function ShowCouponHelper() {
            $("#dialog-message").dialog({
                modal: true,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        };
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="Carrello">
        <div class="StatiCarrello">
            <b class="StatoCarrello bkgGrey ColorWhite ">1) Aggiungi al Carrello</b>
            <b class="StatoCarrello bkgGreen ">2) ORDINA</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">3) Effettua il Pagamento</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">4) Allega i File</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">5) Noi verifichiamo i File</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">6) Realizziamo il Prodotto</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">7) Ricevi il tuo Ordine</b>
        </div>
 <div class="CarrelloMain" style="*height:1200px;">
     <%If Carrello.Ordini.Count <> 0 Then%>       
<div class="CarrelloRiepilogoOrdini">

<div class="riepilogoOrdini">
                <div class="fintoAccordionHeader">
                <img src="/img/icoCarrello16.png" /> <b>CARRELLO ACQUISTI: <%=GetTotOrdCarrello %></b> Lavoro/i contenuti in questo Ordine.
                <div style="text-align:right;right:80px;top:50px;position:absolute;">
                    
                    <asp:LinkButton ID="lnkSvuota"  ForeColor="black" runat="server" Width="200px"><img src="/img/icoDel20.png" /> Svuota il Carrello</asp:LinkButton>
                </div>
                </div>
                <b>LAVORI NELL' ORDINE</b>
                
                    <asp:Repeater ID="rptOrdini" runat="server">
                        <HeaderTemplate><div id="accordion"></HeaderTemplate>
                        <ItemTemplate>
                            
                            <h3><FormerWeb:HeaderOrdine runat="server" Id="HeaderOrdine" /></h3>
                            <div>
                                <FormerWeb:CorpoOrdine runat="server" Id="CorpoOrdine" />
                                <FormerWeb:FooterOrdine runat="server" Id="FooterOrdine" />
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></div></FooterTemplate>
                    </asp:Repeater>
                </div>
</div>
     <%end If %>
<asp:UpdatePanel ID="PannelloDinamico" runat="server">
                    <ContentTemplate>

            <%If Carrello.Ordini.Count = 0 Then%>
                        <br /><br /><br />
               <center><h1 class="orange">Il tuo carrello è vuoto<br /><br /><a href="/" class="pulsante150Orange"><img src="/img/icoCarrelloW.png" /> Continua gli acquisti</a></h1></center>

            <%Else%>
<div class="CarrelloLeft">
<b class="CarrelloTitolettoNoBord1Click"><img src="/img/icoCorriere20.png" />&nbsp;&nbsp;CONSEGNA</b> <br />             
<div class="infoBox boxConCheck">
            <asp:RadioButtonList ID="rdoCorr" runat="server" AutoPostBack="true"></asp:RadioButtonList><br />
    <div style="padding-left:10px;">
    <asp:Panel ID="pnlSelectIndirizzo" runat="server" Visible="false">
                    <b>INDIRIZZO DI CONSEGNA</b>
        <br />Scegli un Indirizzo per la consegna tra quelli che hai inserito o aggiungine uno nuovo<br />
                        <table style="width:100%;margin:7px 0 6px 0;">    
                            <tr>            
                            <td ><asp:DropDownList ID="ddlIndirizzo" runat="server" AutoPostBack="true" Width="450"></asp:DropDownList> <a href="/aggiungi-indirizzo" id="lnkAddInd" runat="server" class="linkbtn bkgOrange ">Aggiungi Indirizzo</a>
                            </td>
                        </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlIndRitiro" runat="server" Visible="false">
                        <b>INDIRIZZO DI RITIRO</b><br />
                        L'indirizzo per il ritiro presso la nostra sede di Roma è:<br /><br />
                        <span class="CarrelloindTipograf"> <b>Tipografia Former</b>, Via Cassia, 2010 - 00123 Roma </span><br /><br />
                    </asp:Panel>
    <asp:Label ID="lblInfoCorr" runat="server" Text=""></asp:Label>
    </div>
</div>
<%If Carrello.ApplicabileCoupon(UtenteConnesso.Utente.TipoRub) Then%>
<b class="CarrelloTitolettoNoBord1Click "><img src="/img/icoCoupon20.png" width="20"/>&nbsp;&nbsp;<b class="percPromo">COUPON DI SCONTO</b></b>
    <div class="infoBox" style="background-color:white;">
        <div><div class="couponHelper"><a href="javascript:ShowCouponHelper();" ><img src="/img/icoInfo16.png" width="16"/> Cosa e' un Coupon di sconto?</a></div><div class="couponHelper"><a href="/i-tuoi-coupon-di-sconto" ><img src="/img/icoMieiCoupon20.png" width="16"/> Vai ai tuoi Coupon di Sconto</a></div></div><br />
    <% If Carrello.CouponGiaApplicato = False Then%>
    
        <asp:Panel id="pnlCouponCarrello" runat="server" DefaultButton="btnCoupon">
        <center>
            <table style="width:90%;">
                <tr>
                    <td>Hai un Coupon di Sconto? Inserisci qui il codice e ti verrà applicato</td>
                    <td><asp:TextBox MaxLength="30" id="txtCoupon" runat="server"></asp:TextBox></td>
                    <td><asp:ImageButton ID="btnCoupon" runat="server" ImageUrl="/img/btnApplCoupon.png" CssClass ="button"/></td>
                </tr>
            </table>
        </center>
        </asp:Panel>

        <div style="width:100%;display:inline;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        </div>
    <%end if %>
    <asp:Panel runat="server" ID="pnlRisCoupon" Visible="false" CssClass="AlertCoupon">
        <br />
        <asp:Label ID="lblRisCoupon" ForeColor="Red" runat="server" ></asp:Label>
    </asp:Panel>
    
<div id="dialog-message" title="Coupon di Sconto" style="display:none;text-align:justify;">
  <p>
    <img src="/img/icoCoupon20.png" />
    Il Coupon di Sconto è un codice che consente di usufruire di esclusive promozioni a te riservate. 
  </p>
  <p><b>Come funziona?</b><br />
Inseriscilo nella casella di testo sottostante e clicca sul pulsante <img src="/img/btnApplCoupon.png" /> per aggiornare il totale del carrello e ricevere lo sconto.
</p>
    <p><b>Dove trovarli?</b><br />
        Consulta la sezione "Offerte e Promozioni" nella Home Page del sito
    </p>
</div>
</div>
    <%End If%>
<b class="CarrelloTitolettoNoBord1Click"><img src="/img/icoPagam20.png" />&nbsp;&nbsp;PAGAMENTO</b> 
<div class="infoBox boxConCheck">
                    <asp:RadioButtonList runat="server" ID="rdoPagam" RepeatDirection="Vertical" AutoPostBack="true"  >

                    </asp:RadioButtonList>
</div>
                
    <b class="CarrelloTitolettoNoBord1Click"><img src="/img/IcoInfo20.png" />&nbsp;&nbsp;CONDIZIONI DI VENDITA</b><br />
               <div class="CarrelloCondVend">
                    Per proseguire con l'ordine si considerano accettate le seguenti clausole contrattuali <br /><br />
                    <iframe width="700" height="150" border="0" style="background-color:white;"  src="/condizioni.htm" scrolling="auto"></iframe>
                </div>
           
                </div> 
            <div class="CarrelloRight1Click">
 <b class="CarrelloTitolettoNoBord1Click"><img src="/img/icoCalendario16.png" width="20"/>&nbsp;&nbsp;CONSEGNA PREVISTA</b>
 <div class="CarrelloBoxCons">
     <div class="annotazioni">Data di consegna calcolata in riferimento all’evasione dell’intero ordine</div>
     <h3><asp:Label ID="lblDataCons" runat="server" Text="-"></asp:Label></h3>
     
 </div>
                <div class="totaleCarrello1Click">
                    <b class="CarrelloTitolettoNoBord1Click"><img src="/img/icoPagam20.png" width="20"/>&nbsp;&nbsp;TOTALE CARRELLO</b>
                        <table style="border-top: 2px solid #d6e03d;">
                            <tr>
                                <td align="left">
                                    Totale Lavori:
                                </td>
                                <td align="right"><b>€ <%=Carrello.TotaleImportiNettiOriginaleStr%></b></td>
                            </tr>
                            <%If Carrello.TotaleSconti then %>
                            <tr>
                                <td align="left">
                                    Sconto Coupon:
                                </td>
                                <td align="right"><b class="red">- € <%=Carrello.TotaleScontiStr%></b></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Totale Netto:
                                </td>
                                <td align="right"><b>€ <%=Carrello.TotaleImportiNettiStr %></b></td>
                            </tr>

                            <%end if %>
                            <tr>
                                <td align="left">
                                    Spedizioni:
                                </td>
                                <td align="right"><b>€ <%=Carrello.TotaleSpedizioniStr%></b></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    IVA (<%=FormerWeb.FormerWebApp.GetPercIva %>%):
                                </td>
                                <td align="right"><b>€ <%=Carrello.TotaleIVAStr%></b></td>
                            </tr>
                       <%--     <tr>
                                <td align="left">
                                    TOTALE:
                                </td>
                                <td align="right">
                                    <b class="TotCarrelloImporto">€ <%=Carrello.TotaleCarrelloStr %></b>
                                </td>
                            </tr>--%>
                        </table>
                    <div class="CarrelloBoxCons">
                    <table>
                           <tr>
                                <td align="left">
                                    <b>TOTALE:</b>
                                </td>
                                <td align="right">
                                    <b class="TotCarrelloImporto">€ <%=Carrello.TotaleCarrelloStr %></b>
                                </td>
                            </tr>
                    </table>
                    </div>
                    </div>


                <div class="CarrelloPulsant">
                <a href="/" class="pulsante150Orange"><img src="/img/icoCarrelloW.png" /> Continua gli acquisti</a>
                <br /><br />
                <asp:ImageButton ID="btnOrdina" runat="server" ImageUrl="/img/btnOrdina.png" CssClass ="button" /><br /><br />
                <br /><br />
                <asp:ImageButton ID="btnSvuota" visible="false" runat="server" ImageUrl="/img/btnSvuotaCarrello.png" CssClass ="button"/>
                <asp:ImageButton ID="btnIndietroCarr" visible="false" runat="server" ImageUrl="/img/btnIndietroCarr.png" CssClass ="button"/><br />
                
                </div>
            </div>
                                    
    <%End if %>  
                
<asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" AssociatedUpdatePanelID="PannelloDinamico" runat="server">
    <ProgressTemplate>
        <div class="progressW"><img src="/img/progress.gif" /></div>                                            
    </ProgressTemplate>
</asp:UpdateProgress>
                            </ContentTemplate>
    </asp:UpdatePanel>
 </div>   

    </div>

</asp:Content>
