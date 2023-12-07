<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="carrelloRiepilogo.aspx.vb" Inherits="FormerWeb.pCarrelloRiepilogo" %>

<%@ Import Namespace="FormerLib.FormerEnum" %>
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
                active: false,
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

    <script type="text/javascript">
            $(document).ready(function () {
                $('#jsCarousel').jsCarousel({ autoscroll: true });
            });
    </script>

    <script type="text/javascript">

        function showProgress() {

            document.getElementById("progressW").style.display = "block";
            
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<%If UtenteConnesso.UtenteAutorizato Then %>
    <asp:Literal runat="server" ID="IframecarreloStp5"/>
<%Else %>
    <div class="Carrello">
       <div class="CarrelloHeader">
                       <img src="/img/StrisciaCarrello_5.png"  class="hasTooltip" usemap="MapCarrello"/>
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
        <h3 style="margin-bottom:0px"><img src="/img/icoCarrello16.png"  width="20"/>&nbsp;&nbsp;Riepilogo Ordine</h3>
        <hr />
            <div class="riepilogoOrdini" style="margin-bottom:20px;">

     <%If Carrello.Ordini.Count = 0 Then%>
                        <br /><br /><br />
               <center><h1 class="orange">Il tuo carrello è vuoto<br /><br /><a href="/" class="pulsante150Orange"><img src="/img/icoCarrelloW.png" /> Continua gli acquisti</a></h1></center>

    <%Else%>
                <div class="fintoAccordionHeader">
                <img src="/img/icoCarrello16.png" /> <b>CARRELLO ACQUISTI: <%=GetTotOrdCarrello %></b> Lavoro/i contenuti in questo Ordine.
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
                 <div style="text-align:right;color:black;padding:20px 0px 5px 0px;">
                    <a style="color:black;" href="/carrello">Modifica</a>
                </div>
    <%End If%>
                                
            </div>
        <h3 style="margin-bottom:0px"><img src="/img/icoAttach16.png" width="16" />&nbsp;&nbsp;File allegati</h3>
        <hr />     
            <div style="margin-bottom:20px;padding:5px 0px 5px 15px;line-height:20px;background-color:#f1f1f1;border-radius:5px;border:1px solid #aaaaaa;">
                Una volta completato l'ordine, ed eventualmente effettuato il pagamento (se sceglierai una modalità di pagamento anticipata), potrai allegare i file PDF entrando nel dettaglio di ogni lavoro dalla sezione <b>'I tuoi lavori'</b>.
                </div>
        <h3 style="margin-bottom:0px"><img src="/img/icoCorriere20.png" width="20" />&nbsp;&nbsp;Consegna</h3>
        <hr />
            <div style="margin-bottom:20px;padding:5px 0px 5px 15px;line-height:20px;background-color:#f1f1f1;border-radius:5px;border:1px solid #aaaaaa;">
        <table width="95%">
            <tr><td width="170">Data di Consegna Prevista:</td><td><b style="font-size:16px;background-color:#d6e03d;padding:2px;"><%=Carrello.DataConsegnaStr %></b></td></tr>
            <tr><td>Metodo di Consegna scelto:</td><td><b style="font-size:16px;color:#2b2b2b;"><%=GetCorriereScelto%></b></td></tr>
            <tr><%Select Carrello.IdMetodoConsegnaScelto%>

                        <%Case enTipoCorriere.Gratis%>
                        <td valign="top">Indirizzo di Ritiro:</td><td><b style="font-size:16px;color:#2b2b2b;">Tipografia Former</b>, Via Cassia, 2010 - 00123 Roma </td>
                        <%Case enTipoCorriere.ConTariffa%>
                        <td valign="top">Indirizzo di Consegna:&nbsp;</td><td><%=GetIndirizzoScelto%></td>
                        <%End Select%></tr>
            <tr><td>Peso Complessivo:</td><td><%=Carrello.Peso%> kg &#177;</td></tr>
            <%If Carrello.EmailTracciamento.Length Then%>
            <tr><td>Email notifiche:</td><td><%=Carrello.EmailTracciamento%></td></tr>
            <%End If%>
        </table>
                <div style="text-align:right;color:black;padding-right:10px;">
                    <a style="color:black;" href="/carrello-consegna">Modifica</a>
                </div>
            </div>
        <h3 style="margin-bottom:0px"><img src="/img/icoPrezzo16.png" />&nbsp;&nbsp;&nbsp;Pagamento</h3>
        <hr />
            <div style="padding:10px 0px 5px 0px;background-color:#f1f1f1;border-radius:5px;border:1px solid #aaaaaa;">
            <div class="TipoPagamento" style="line-height:20px;"><img src="<%=Carrello.MetodoPagamentoScelto.ImgWeb%>" style="margin-right:5px;"/><b style="font-size:14px;"><%=GetLabelMetodoPagamento%></b>, <br /><%=Carrello.MetodoPagamentoScelto.Descrizione%></div>
                <%If Carrello.ApplicatoCouponAlCarrello = False Then%>
                    <%If Carrello.ApplicabileCoupon(UtenteConnesso.Tipo) Then%>
                        <br /><br /><a style="color:black;margin-left:55px;" href="/carrello-pagamento">Se vuoi utilizzare un <b style="color:green;">Coupon di Sconto</b> clicca qui</a><br />
                    <%End If%>
                <%End If%>
                <div style="text-align:right;color:black;padding:20px 10px 5px 0px;">
                    <a style="color:black;" href="/carrello-pagamento">Modifica</a>
                </div>
            </div>
        </div>
  
        <div class="CarrelloRight">
            <div class="CarrelloBordato">

            <div class="totaleCarrello">
                                   <table>
                                        <tr>
                                            <td colspan="2" align="center"><b>RIEPILOGO</b></td>
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
             
             
                <asp:LinkButton ID="btnOrdina" runat="server" OnClientClick="showProgress()" CssClass="pulsanteOrdina" Text="ACQUISTA ORA"></asp:LinkButton>
                
            </div>
            <br /><br />
            <center><a href="/" class="pulsante150Orange"><img src="/img/icoCarrelloW.png" /> Continua Acquisti</a></center>
            <FormerWeb:CarrelloHelp id="carrelloHelp" runat="server"></FormerWeb:CarrelloHelp>
        </div>

        <div class="CarrelloFooter">
            <h3 style="margin-bottom:0px;"><img src="/img/IcoInfo20.png" width="20" />&nbsp;&nbsp;Condizioni di Vendita</h3>
            <hr style="border:1px solid #e8e8e8;"/>
                <div class="CarrelloCondVend">
                    Proseguendo con l'ordine si considerano accettate le seguenti clausole contrattuali <br /><br />
                    <iframe width="700" height="150" border="0" style="background-color:white;"  src="/condizioni.htm" scrolling="auto"></iframe>
                </div>

        </div>

        
<div id="progressW" class="progressW" style="display:none;"><img src="/img/progress.gif" /></div> 

 </div>   
<%End If%>   

</asp:Content>
