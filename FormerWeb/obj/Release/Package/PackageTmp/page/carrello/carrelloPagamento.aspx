<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="carrelloPagamento.aspx.vb" Inherits="FormerWeb.pCarrelloPagamento" %>
<%@ Register  TagPrefix="FormerWeb" TagName="HeaderOrdine" Src="~/userControl/ucBoxHeaderLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="CorpoOrdine" Src="~/userControl/ucBoxCorpoLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="FooterOrdine" Src="~/userControl/ucBoxFooterLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="CarrelloHelp" Src="~/userControl/ucCarrelloHelp.ascx" %>
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

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        
        </asp:ScriptManager>--%>

    <%If UtenteConnesso.UtenteAutorizato Then %>
        <asp:Literal runat="server" ID="IframecarreloStp4"/>
    <%Else %>
            <div class="Carrello">
       
        <asp:UpdatePanel ID="PannelloDinamico" runat="server">
                    <ContentTemplate>
            <div class="CarrelloHeader">
                 <img src="/img/StrisciaCarrello_4.png" class="hasTooltip" usemap="MapCarrello"/>
                 <div class="hidden tooltiptext">
                <img src="/img/icoCarrelloW.png" class="imgSx" />
                <h4>Carrello</h4><br />
                <b style="color:#f58220;">1) Controlla il carrello</b><br />
                Controlla i prodotti che hai inserito nel carrello e clicca su 'ALLEGA I FILE' per continuare<br />
                <b style="color:#f58220;">2) Allega i file</b><br />
                I file si potranno allegare (per il momento) solo DOPO la conclusione dell'ordine. Clicca su 'SCEGLI LA CONSEGNA' per continuare<br />
                <b style="color:#f58220;">3) Scegli la Consegna</b><br />
                Seleziona il tipo di consegna che desideri e clicca su 'SCEGLI IL PAGAMENTO' per continuare<br />
                <b style="color:#f58220;">4) Scegli il Pagamento</b><br />
                Seleziona il tipo di forma di pagamento tra quelle disponibili e clicca su 'RIVEDI E ACQUISTA' per continuare<br />
                <b style="color:#f58220;">5) Completa l' Ordine</b><br />
                Rivedi e controlla il tuo Ordine e clicca su 'ACQUISTA ORA' per completare l' Ordine
                </div>
            </div>
          <div class="CarrelloLeft">
            <h3 style="margin-bottom:0px"><img src="/img/icoPrezzo16.png" />&nbsp;&nbsp;Scegli il Pagamento</h3>
            <hr />
              <div class="riepilogoOrdini boxConCheck" style="padding-top:10px;">
                             
              <asp:RadioButtonList runat="server" ID="rdoPagam" RepeatDirection="Vertical" AutoPostBack="true"  >

              </asp:RadioButtonList>
                         
              </div>
              
<%If Carrello.ApplicabileCoupon(UtenteConnesso.Utente.TipoRub) Then%>

    <div class="riepilogoOrdini" style="margin-top:10px;padding-top:10px;">
<b class="CarrelloTitolettoNoBord "><img src="/img/icoCoupon20.png" />&nbsp;&nbsp;<b class="percPromo">COUPON DI SCONTO</b></b>              
    <% If Carrello.ApplicatoCouponAlCarrello = False Then%>
    
        <asp:Panel id="pnlCouponCarrello" runat="server" DefaultButton="btnCoupon">
        <center>
            <table style="width:90%;">
                <tr>
                    <td>Hai un Coupon di Sconto? Inserisci qui il codice e ti verrà applicato</td>
                    <td><asp:TextBox MaxLength="30" id="txtCoupon" runat="server"></asp:TextBox></td>
                    <td><asp:LinkButton ID="btnCoupon" runat="server" CssClass ="linkbtn bkgOrange" Text="Applica"/></td>
                </tr>
            </table>
        </center>
        </asp:Panel>
                
    <%          End If %>
    <asp:Panel runat="server" ID="pnlRisCoupon" Visible="false" CssClass="AlertCoupon">
        <asp:Label ID="lblRisCoupon" ForeColor="Red" runat="server" ></asp:Label>
    </asp:Panel>
    
    <div style="height:20px;margin-top:10px;">
        <div class="couponHelper" ><a href="javascript:ShowCouponHelper();" ><img src="/img/icoInfo16.png" width="16"/> Cosa e' un Coupon di sconto?</a></div>
        <div class="couponHelper"><a href="/i-tuoi-coupon-di-sconto" ><img src="/img/icoMieiCoupon20.png" width="16"/> Vai ai tuoi Coupon di Sconto</a></div>
    </div>
        
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

            </div>
        
            <div class="CarrelloRight">
                <div class="CarrelloBordato">

                <div class="totaleCarrello">
                    <table>
                        <tr>
                            <td colspan="2" align="center"><b>Totale Provvisorio</b></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                    <hr style="margin-top:0px;border-top: 2px solid #d6e03d;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Totale Lavori:
                            </td>
                            <td align="right">€ <%=Carrello.TotaleImportiNettiOriginaleStr%></td>
                        </tr>
                        <%If Carrello.TotaleSconti Then %>
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
                            <td align="right">€ <%=Carrello.TotaleImportiNettiStr %></td>
                        </tr>

                        <%end if %>
                        <tr>
                            <td align="left">
                                Spedizioni:
                            </td>
                            <td align="right">€ <%=Carrello.TotaleSpedizioniStr%></td>
                        </tr>
                        <tr>
                            <td align="left">
                                IVA (<%=FormerWeb.FormerWebApp.GetPercIva %>%):
                            </td>
                            <td align="right">€ <%=Carrello.TotaleIVAStr%></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                    <hr style="margin-top:0px;border-top: 2px solid #d6e03d;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <b>Totale ordine</b>
                            </td>
                            <td align="right">
                                <b>€ <%=Carrello.TotaleCarrelloStr %></b>
                            </td>
                        </tr>
                    </table>
                </div>

                 <a href="/carrello-riepilogo" class="pulsanteOrdina">RIVEDI E ACQUISTA</a>
                </div>
               <FormerWeb:CarrelloHelp id="carrelloHelp" runat="server"></FormerWeb:CarrelloHelp>
             
            </div>
<asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" AssociatedUpdatePanelID="PannelloDinamico" runat="server">
    <ProgressTemplate>
        <div class="progressW"><img src="/img/progress.gif" /></div>                                            
    </ProgressTemplate>
</asp:UpdateProgress>
                    </ContentTemplate>
        </asp:UpdatePanel>
         
        <div class="CarrelloFooter">
          
            <!--QUI CI VA GLI ORDINI GIA -->
            <%If Carrello.Ordini.Count Then%>
                Se vuoi completare l'acquisto clicca su <b>RIVEDI E ACQUISTA</b><br /><br />
                Se vuoi ordinare altri prodotti clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a>.<br /><br />
            <%Else%>
                Il tuo carrello è vuoto, clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a><br /><br />
            <%end if %>

        </div>

 </div>
    <%End If%>   

</asp:Content>
