<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="indirizzosped.aspx.vb" Inherits="FormerWeb.pIndirizzoSpedizione" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         $(function () {
             var icons = {
                 header: "ui-icon-plus",
                 activeHeader: "ui-icon-minus"
             };
             $("#accordionOrdini").accordion({
                 icons: icons,
                 collapsible: true,
                 heightStyle: "content"
             });

         });

                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <h3 class="orange"><img src="/img/icoInd50.png" />INDIRIZZI DI SPEDIZIONE</h3>
    <div class="arearis">
        <div class="infoInd">
          Da qui puoi gestire i tuoi indirizzi per la consegna degli ordini. Clicca sul <b style="font-size:14px;">+</b> che vedi accanto a ogni Indirizzo per visualizzare il dettaglio dell'indirizzo.<br /><br />
         </div>
        <table class="BoxOrdInt">
            <tr>
                <td width="30">&nbsp;</td>
                <td width="30"></td>
                <td width="30"></td>
                <td width="150">
                <b class="red">RIFERIMENTO</b>
                </td>
                <td><b class="red">INDIRIZZO</b></td>
            </tr>
        </table>
            <asp:Repeater ID="rptInd" runat="server">
             <HeaderTemplate><div id="accordionOrdini"></HeaderTemplate>
             <ItemTemplate>
                 <h3>
                     <div class="BoxOrdTit"> 
                        <table>
                            <tr>
                                <td width="30"><img src="/img/icoFav20<%# If(Eval("Predefinito") <> 0, "On", "Off")%>.png" title="<%# If(Eval("Predefinito") <> 0, "Predefinito", "Non Predefinito")%>"/></td>
                                <td width="30"><img src="/img/icoInd20.png" /></td>
                                <td width="150">
                                <b><%#Eval("Nome") %></b>
                                </td>
                                <td><%#Eval("Riassunto")%></td>
                            </tr>
                        </table>
                    </div>
                 </h3>
                 <div>
                     <div class="BoxOrdBody">
                         <table>
                             <tr>
                                 <td width="100"></td>
                                 <td width="80">Riferimento</td>
                                 <td><b><%#Eval("Nome")%></b></td>
                             </tr>
                             <tr>
                                 <td width="100"></td>
                                 <td width="80">Destinatario</td>
                                 <td><b><%#Eval("Destinatario")%></b></td>
                             </tr>
                             <tr>
                                 <td></td>
                                 <td>Indirizzo</td>
                                 <td><b><%#Eval("Indirizzo")%></b></td>
                             </tr>
                             <tr>
                                 <td></td>
                                 <td>Località</td>
                                 <td><b><%#Eval("LocalitaStr")%></b></td>
                             </tr>
                            <tr>
                                 <td></td>
                                 <td>Nazione</td>
                                 <td><b><%#Eval("NazioneStr")%></b></td>
                             </tr
                             <tr>
                                 <td width="100"></td>
                                 <td width="80">Telefono</td>
                                 <td><b><%#Eval("Telefono")%></b></td>
                             </tr>
                         </table>
                     </div>
                     
                     <div class="BoxOrdFooter">
                         <hr />
                         
                         <asp:LinkButton ID="lnkPredefinito" Visible='<%# If(Eval("predefinito") = 0, True, False)%>' CommandName="Pred" CommandArgument='<%#Eval("idindirizzo")%>' runat="server"><img src="/img/icoFav20On.png"/> Rendi Predefinito</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                         <asp:LinkButton ID="lnkDelOrd"  Visible='<%# If(Eval("idindirizzo") <> 0, True, False)%>' CommandName="DelInd" CommandArgument='<%#Eval("idindirizzo")%>' runat="server"><img src="/img/icoCestino16.png" />Elimina indirizzo</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                     </div>
                 </div>
             </ItemTemplate>
             <FooterTemplate></div></FooterTemplate>
         </asp:Repeater>
        <div class="newIndlnk">
            <a href="/aggiungi-indirizzo" class="pulsante150Orange"><img src="/img/icoInd20.png" /> Aggiungi Indirizzo</a>
        </div>        
    <h3 class="orange"><img src="/img/icoSped50.png" />CORRIERE PREDEFINITO: <b class="blue"><asp:Label ID="lblCorrPred" runat="server" Text="-"></asp:Label></b></h3>
        Qui puoi specificare il corriere prefefinito che verrà selezionato automaticamente ogni volta che aggiungerai un prodotto al carrello. <br /><br />Dopo aver selezionato il Corriere che preferisci clicca sul pulsante <b>Modifica</b>.<br /><br />
        
        <div class="infoBox">
        <asp:RadioButtonList ID="rdoCorr" runat="server"></asp:RadioButtonList>
        <center><br /><asp:linkbutton id="lnkModCorriere" runat="server" cssclass="pulsante120Orange" ><img src="/img/icoCorriere20W.png" /> Modifica</asp:linkbutton><br /><br /></center>
        </div>
         <br /><br />
        <%--<h3 class="gray">COME SCEGLIERE IL CORRIERE</h3>    
            Puoi scegliere il corriere che preferisci ogni volta che effettui un ordine direttamente dalla colonna destra della scheda del prodotto come vedi nell'immagine sottostante.<br />
    <br /><center><img src="/img/imgCorriereScheda.jpg" class="immagineContornata"/></center>--%>

    </div>
</asp:Content>
