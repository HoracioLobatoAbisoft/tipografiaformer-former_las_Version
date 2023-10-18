<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="carrelloFile.aspx.vb" Inherits="FormerWeb.pCarrelloFile" %>
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

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

    <div class="Carrello">
       
        <asp:UpdatePanel ID="PannelloDinamico" runat="server">
                    <ContentTemplate>
            <div class="CarrelloHeader">
                   <img src="/img/StrisciaCarrello_2.png"  class="hasTooltip" usemap="MapCarrello" />
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
            <h3 style="margin-bottom:0px"><img src="/img/icoAttach16.png" />&nbsp;&nbsp;Allega i file</h3>
            <hr />
             
              <div class="riepilogoOrdini" style="margin-top:10px;padding:20px;line-height:20px;">
               <center><b class="CarrelloDataConsegna">COME ALLEGARE I FILE</b></center>
<br />Una volta completato l'ordine, ed eventualmente effettuato il pagamento (se sceglierai una modalità di pagamento anticipata), potrai allegare i file PDF entrando nel dettaglio di ogni lavoro dalla sezione <b>'I tuoi lavori'</b>.
              </div>

              <asp:Panel id="pnlTrace" runat="server" Visible="false">

                  <div class="riepilogoOrdini" style="margin-top:10px;padding:20px;line-height:25px;">
                      Vuoi ricevere tramite email gli <b>aggiornamenti sullo stato della spedizione</b> dal Corriere?<br />    
                      Indica qui una email dove ricevere le notifiche <asp:TextBox ID="txtTrace" runat="server" Width="200px" MaxLength="100" placeholder="Indica un email per ricevere aggiornamenti sulla spedizione dal corriere"></asp:TextBox>&nbsp;&nbsp;<asp:LinkButton ID="lnkMiaMail" cssclass="linkbtn bkgOrange " ForeColor="black" runat="server" Text="Usa la mia mail"></asp:LinkButton>
                      <br /><center><asp:Label ID="lblErrEmail" runat="server" Visible="false" ForeColor="red" Font-Size="14px" Font-Bold="true" Text="Attenzione! L'email non sembra valida"></asp:Label></center>
                  </div>

              </asp:Panel>

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

                <a  href="/carrello-consegna" class="pulsanteOrdina">SCEGLI LA CONSEGNA</a>

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
            <%If Carrello.Ordini.Count Then%>
                Se vuoi completare l'acquisto clicca su <b>SCEGLI LA CONSEGNA</b><br /><br />
                Se vuoi ordinare altri prodotti clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a>.<br /><br />
            <%Else%>
                Il tuo carrello è vuoto, clicca qui e <a href="/" style="font-size:16px;color:#f58220;font-weight:bold;">Continua gli acquisti</a><br /><br />
            <%end if %>



        </div>

        

 </div>   

</asp:Content>
