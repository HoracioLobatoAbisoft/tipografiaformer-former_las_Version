<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="carrello.aspx.vb" Inherits="FormerWeb.pCarrello" %>
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

    <script type="text/javascript">
            $(document).ready(function () {
                $('#jsCarousel').jsCarousel({ autoscroll: true });
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <%If UtenteConnesso.UtenteAutorizato Then %>
    <div class="">
        <asp:Literal runat="server" ID="iframeCarrello" />
    </div>
    <%Else%>
    <div class="Carrello" >
           <div class="CarrelloHeader">
            <img src="/img/StrisciaCarrello_1.png" class="hasTooltip"/>
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
            <h3 style="margin-bottom:0px"><img src="/img/icoCarrello16.png" />&nbsp;&nbsp;CARRELLO</h3>
            <hr />
                <div class="riepilogoOrdini">

         <%If Carrello.Ordini.Count = 0 Then%>
                            <br /><br />
                   <center><h1 class="orange">Il tuo carrello è vuoto</h1></center>

        <%Else%>
                    <div class="fintoAccordionHeader">
                    <div style="float:left;"><img src="/img/icoCarrello16.png" /> <b>CARRELLO ACQUISTI: <%=GetTotOrdCarrello %></b> Lavoro/i contenuti in questo Ordine.</div>
                        <div style="text-align:right;float:right;margin-right:10px;width:150px;">
                            <asp:LinkButton ID="lnkSvuota" ForeColor="Black" runat="server"><img src="/img/icoDel20.png" /> Svuota il Carrello</asp:LinkButton>
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
        <%End If%>

                
                </div>
        
                            <%If MostraOmaggi Then %>

                <div class="Omaggi">

                    <h3 style="margin-bottom:0px"><img src="/img/_Omaggio.png" />&nbsp;&nbsp;PUOI SCEGLIERE UNO DEI SEGUENTI OMAGGI</h3><hr />
                
                    <asp:Repeater ID="rptOmaggi" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td valign="top" align="center" rowspan="2"  align="center" ><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("GetImgFormato") %>" width="64" /></td>
                                    <td><b><%#Eval("Nome")%></b></td>
                                    <td rowspan="2" valign="center" align="center" width="150" ><asp:LinkButton ID="btnAddOmaggio" runat="server" CssClass="pulsante100Violet" CommandName ="Aggiungi" CommandArgument ='<%#Eval("IdOmaggio") %>'>Aggiungi</asp:LinkButton><asp:Panel ID="pnlInfoOmaggio" runat="server" Visible="false">
                                        <img src="/img/icoinfoomaggio.png" class="hasTooltip"/>
                                        <div class="hidden tooltiptext">
                                            <img src="/img/icoinfoomaggio.png" class="imgSx" />
                                            <h4><%#Eval("Nome")%></h4>
                                            <%#Eval("CondizioneStr")%>
                                        </div></asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="OmaggioCellaInfo" ><i><%#Eval("DescrSito")%></i></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="2" class="OmaggioTdInfo">* <%#Eval("CondizioneStrHref")%></td>
                                </tr>
                            </table>
                        
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
            
                <%end if %>


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
                    <%If Carrello.Ordini.FindAll(Function(x) x.Omaggio = FormerLib.FormerEnum.enSiNo.No).Count <> 0 Then%>
                 <a  href="/carrello-file" class="pulsanteOrdina">ALLEGA I FILE</a>
                    <%End If%>
                </div>
                <FormerWeb:CarrelloHelp id="carrelloHelp" runat="server"></FormerWeb:CarrelloHelp> 
            

            </div>

            <div class="CarrelloFooter">

                <%If Carrello.Ordini.Count Then%>
                Se vuoi completare l'acquisto clicca su <b>ALLEGA I FILE</b><br /><br />
                Se vuoi ordinare altri prodotti clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a>.<br /><br />
                <%Else%>
                    Il tuo carrello è vuoto, clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a><br /><br />
                <%end if %>
            </div>
     </div>   
    <%End If %>
</asp:Content>
