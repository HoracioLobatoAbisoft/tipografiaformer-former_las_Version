<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" 
    CodeBehind="ordini.aspx.vb" Inherits="FormerWeb.pOrdini" %>
<%@ Import Namespace="Formerlib.formerenum" %>
<%@ Import Namespace="FormerLib.FormerColori" %>

<%@ Register  TagPrefix="FormerWeb" TagName="HeaderLavoro" Src="~/userControl/ucBoxHeaderLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="CorpoLavoro" Src="~/userControl/ucBoxCorpoLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="FooterLavoro" Src="~/userControl/ucBoxFooterLavoro.ascx" %>

<%@ Register  TagPrefix="FormerWeb" TagName="FooterOrdine" Src="~/userControl/ucBoxFooterOrdine.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         $(function () {
             var icons = {
                 header: "ui-icon-plus",
                 activeHeader: "ui-icon-minus"
             };
             $("#accordionConsegne").accordion({
                 icons: icons,
                 collapsible: true,
                 heightStyle: "content"
             });

             $(".accordionOrdini").accordion({
                 icons: icons,
                 collapsible: true,
                 active:true,                 
                 heightStyle: "content"
             });

         });

                </script>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%If UtenteConnesso.UtenteAutorizato Then%>
        <div style="
                width: 810px;
                height: 100vh;
                overflow: hidden;
            ">
            <asp:Literal runat="server" ID="IframeOrdini"/>
        </div>
        
    <%Else %>
<h3 class="orange"><img src="/img/icoCart50.png" />Le Tue Consegna</h3>
<div class="ordini">
     <div id="tabs" >
    <ul>
    <li><a href="#tabs-1"><img src="/img/icoCarrello20.png" alt="I tuoi lavori" class="icoImg"/> Tutti i tue Consegna</a></li>
    <li><a href="#tabs-2"><img src="/img/icoLavOpz16.png" alt="Legenda Stato Lavori" class="icoImg"/> Legenda Stato Consegna</a></li>
    </ul>
    <div id="tabs-1"><br />  Da qui puoi visualizzare lo stato dei tuoi Consegne. Clicca sul <b style="font-size:14px;">+</b> che vedi accanto a ogni consegna per visualizzare il dettaglio dell' consenge.<br /><br />
    
    <table width="100%" class="BoxOrdInt">
        <tr>
            <td width="65">&nbsp;</td>
            <td width="130" align="center"><b class="red">STATO</b></td>
            <td width="120" align="center"><b class="red">CONSEGNA</b></td>
            <td width="100" align="center"><b class="red">DATA CONSEGNA</b></td>
            <td><b class="red">CORRIERE</b></td>
            <td width="60"><b class="red">N° ORDINI</b></td>
            <td width="110" align="right"><b class="red">IMPORTO NETTO</b></td>
        </tr>
    </table>
        <asp:Repeater ID="rptCons" runat="server">
         <HeaderTemplate><div id="accordionConsegne" ></HeaderTemplate>
         <ItemTemplate>
             <h3>
                 <div class="BoxOrdTit"> 
                    <table>
                        <tr>
                            <td width="30"><img src="<%#Eval("IconaCorriere")%>" alt="<%#Eval("IconaCorriereAlt")%>" /></td>
                            <td width="30"><div class="statoOrdineBox" title="<%#Eval("StatoStr")%>" style="background-color:<%#Eval("ColoreStatoHtml")%>;"></div></td>
                            <td width="80"><%#Eval("StatoStr")%></td>
                            <td width="130" align="center"><b>N° <%#Eval("IdConsegnaView")%> del <%#Eval("InseritoStr")%></b></td>
                            <td width="90" align="center"><b class="<%#Eval("DataOrdineClasse")%>"><%#Eval("GiornoStr")%></b></td>
                            <td ><b><%#Eval("CorriereStr")%></b></td>
                            <td width="60" align="center"><b><%#Eval("ListaOrdini.Count")%></b></td>
                            <td width="100" align="right"><b>€ <%#Eval("ImportoTotNettoStr")%> + iva</b></td>
                        </tr>
                    </table>
                </div>
             </h3>
             <div>
                 <div class="BoxOrdBody">
                     <b>Riepilogo Consegna</b>
                     <table>
                         <tr height="12">
                             <td width="100">Data Consegna</td>
                             <td><b class="<%#Eval("DataOrdineClasse")%>"><%#Eval("GiornoStr")%> <%#Eval("DataOrdineLabel")%></b></td>
                             <td rowspan="7" width="180" valign="top" >
                                <center><b class="statoOrdineLabel" style='background-color:<%#Eval("ColoreStatoHtml")%>;'><%#Eval("StatoStr")%></b></center><br />
                                 <table>
                                     <tr>
                                         <td>Totale Consegna: </td>
                                         <td align="right"><b>€ <%#Eval("ImportoTotOrdiniNettoOriginaleStr")%></b></td>
                                     </tr>
                                     <asp:Panel ID="pnlCoupon" runat="server" Visible='<%#ShowCoupon(Eval("ImportoTotaleSconti"),Eval("IdCouponUtilizzato"))%>'>
                                        <tr>
                                            <td align="left">
                                                Sconti per Coupon:
                                            </td>
                                            <td align="right"><b class="red">- € <%#Eval("ImportoTotaleScontiStr")%></b></td>
                                        </tr>
                                     </asp:Panel>
                                     <tr>
                                         <td>Totale Spedizioni: </td>
                                         <td align="right"><b>€ <%#Eval("ImportoConsegnaStr")%></b></td>
                                     </tr>
                                     <tr>
                                         <td>IVA (<%=FormerWeb.FormerWebApp.GetPercIva%>%): </td>
                                         <td align="right"><b>€ <%#Eval("ImportoTotIvaStr")%></b></td>
                                     </tr>
                                     <tr class="bkgGreen">
                                         <td><b>TOTALE:</b></td>
                                         <td align="right"><b>€ <%#Eval("ImportoTotStr")%></b></td>
                                     </tr>
                                 </table>
                             </td>
                         </tr>                             
                         <tr height="12">
                             <td width="100">N° Ordini</td>
                             <td ><b><%#Eval("ListaOrdini.Count")%></b></td>
                         </tr>
                        <tr height="12">
                             <td width="100">Corriere</td>
                             <td><b><%#Eval("CorriereStr")%></b></td>
                        </tr>
                         <tr height="12">
                             <td></td>
                             <td> (Colli <b><%#Eval("NumeroColliStr")%></b>, Peso <b><%#Eval("PesoKg")%></b> kg ±)</td>
                         </tr>
                         <tr height="12">
                             <td width="100" valign="top">Indirizzo</td>
                             <td><b><%#Eval("IndirizzoStr")%></b></td>
                         </tr>
                         <tr height="12">
                             <td width="100" valign="top">Pagamento</td>
                             <td><b><%#Eval("PagamentoStr")%></b></td>
                         </tr>
                         <tr>
                             <td></td>
                             <td></td>
                         </tr>
                         <tr>
                             <td colspan="3">                                     
                                 <b>ORDINI NELL' CONSEGNE</b><br />
                                 Qui trovi l'elenco dei ordini che sono contenuti in questo CONSEGNE.
                                 <asp:Repeater ID="rptOrdini" runat="server">
                                     <HeaderTemplate><div class="accordionOrdini"></HeaderTemplate>
                                     <ItemTemplate>
                                        <h3><FormerWeb:HeaderLavoro runat="server" Id="HeaderLavoro" /></h3>
                                        <div>
                                            <FormerWeb:CorpoLavoro runat="server" Id="CorpoLavoro" />
                                            <FormerWeb:FooterLavoro runat="server" Id="FooterLavoro" />
                                        </div>
                                     </ItemTemplate>
                                     <FooterTemplate></div></FooterTemplate>
                                 </asp:Repeater>
                             </td>
                         </tr>
                     </table>
                 </div>
                <FormerWeb:FooterOrdine runat="server" Id="FooterOrdine" />
                </div>
             
         </ItemTemplate>
         <FooterTemplate></div></FooterTemplate>
     </asp:Repeater>
    <div class="pager">Vai alla pagina <asp:PlaceHolder ID="plcPaging" runat="server" /> <asp:Label runat="server" ID="lblPageName"  /></div>
    </div>
    <div id="tabs-2">
        <br />Vuoi sapere cosa significano gli <b>Stati degli Consegna</b>? Ecco una spiegazione dettagliata di ogni stato.<br /><br />
        <table>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoconsegna.Inserito)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoconsegna.Inserito)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.Inserito).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli consegna in questo stato sono stati acquistati dal Carrello.<br /><br />
                </td>
            </tr>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoconsegna.InAttesaDiPagamento)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoconsegna.InAttesadiPagamento)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.InAttesaDiPagamento).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli ordini in questo stato sono in attesa che tu effettui il pagamento. Puoi effettuare il pagamento dal dettaglio dell'consegne con pochi click.<br /><br />
                </td>
            </tr>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoconsegna.InLavorazione)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoconsegna.InLavorazione)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.InLavorazione).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli ordini in questo stato sono entrati nel processo produttivo.<br /><br />
                </td>
            </tr>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoconsegna.InConsegna)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoconsegna.InConsegna)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.InConsegna).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli ordini in questo stato sono in Consegna.<br /><br />
                </td>
            </tr>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.Consegnata)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoConsegna.Consegnata)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.Consegnata).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli ordini in questo stato sono stati Ritirati o Consegnati come da tue indicazioni.<br /><br />
                </td>
            </tr>
            <tr>
                <td valign="top" rowspan="2">
                    <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.Pagato)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoconsegnaHtml(enStatoConsegna.Pagato)%>;"></div>
                </td>
                <td>
                    <b><%=FormerEnumHelper.StatoConsegnaString(enStatoConsegna.Pagato).ToUpper%></b>
                </td>
            </tr>
            <tr>
                <td>
                    Gli ordini in questo stato sono stati pagati.<br /><br />
                </td>
            </tr>

            </table>
        <hr class="separatore"/>
        <br />Vuoi sapere cosa significano i simboli accanto a ogni consegna? Ecco una spiegazione dettagliata di ogni simbolo.<br /><br />
        <table>
            <tr>
                <td>
                    <img src="/img/icoRitiroCli20.png" />
                </td>
                <td>
                    Per gli ordini con questo simbolo accanto hai scelto <b>RITIRO CLIENTE</b><br />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="/img/icoCorriere20.png" />
                </td>
                <td>
                    Per gli ordini con questo simbolo accanto hai scelto di ricevere l'consena tramite un <b>NOSTRO CORRIERE</b><br />
                </td>
            </tr>
            <tr>
                <td>
                    <img src="/img/icoPacco20.png" />
                </td>
                <td>
                    Per gli ordini con questo simbolo accanto hai scelto di inviare un <b>TUO CORRIERE</b> a ritirare l'consegne
                </td>
            </tr>
        </table>
        <hr class="separatore"/>
        <br />Vuoi sapere cosa significano i colori della data di consegna? Ecco una spiegazione dettagliata di ogni colore<br /><br />
        <table>
            <tr>
                <td width="250">
                    <b class="DataOrdinePrevista"><%=Now.Date.ToString("dd/MM/yyyy") %> Consegna PREVISTA</b>
                </td>
                <td>
                    La data della consegna è quella <b>PREVISTA</b> al momento dell'inserimento dell'consegna.<br />
                </td>
            </tr>
             <tr>
                <td>
                    <b class="DataOrdineConfermata"><%=Now.Date.ToString("dd/MM/yyyy") %> Consegna CONFERMATA</b>
                </td>
                <td>
                    La data della consegna è <b>CONFERMATA</b> dal reparto produzione, e verrà rispettata salvo complicazioni eccezionali.<br />
                </td>
            </tr>
            <tr>
                <td>
                    <b class="DataOrdineGarantita"><%=Now.Date.ToString("dd/MM/yyyy") %> Consegna GARANTITA</b>
                </td>
                <td>
                    La data della consegna è <b>GARANTITA</b> dal reparto produzione, e verrà rispettata salvo complicazioni eccezionali.<br />
                </td>
            </tr>
        </table>
        </div>
    </div>
    <br />
</div>
    <%End If %>
    
</asp:Content>
