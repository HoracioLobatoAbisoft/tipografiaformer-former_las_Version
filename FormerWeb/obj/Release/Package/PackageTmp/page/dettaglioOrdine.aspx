<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/main.master" CodeBehind="dettaglioOrdine.aspx.vb" Inherits="FormerWeb.pDettaglioOrdine" %>
<%@ Import Namespace="FormerDALWEB" %>
<%@ Import Namespace="FormerLib" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>

<%@ Register  TagPrefix="FormerWeb" TagName="HeaderLavoro" Src="~/userControl/ucBoxHeaderLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="CorpoLavoro" Src="~/userControl/ucBoxCorpoLavoro.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="FooterLavoro" Src="~/userControl/ucBoxFooterLavoro.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script>
            $(function () {
                var icons = {
                    header: "ui-icon-plus",
                    activeHeader: "ui-icon-minus"
                };

                $(".accordionOrdini").accordion({
                    icons: icons,
                    collapsible: true,
                    active: false,
                    heightStyle: "content"
                });

            });

            function ppGo() {
                document.forms[0].action = '<%=FormerWeb.FormerWebApp.PPEntryPoint%>';
                document.forms[0].submit(); 
            }

        </script>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%If UtenteConnesso.UtenteAutorizato Then%>
        <div style="
                
                overflow: hidden;
            ">
            <asp:Literal runat="server" ID="IframeDetaglioOrdini"/>
        </div>
        <div class="dettaglioOrdine" hidden>
    <%Else %>
        <div class="dettaglioOrdine">
    <%End If%>
      <div class="StatiCarrello">
            <b class="StatoCarrello bkgGrey ColorWhite ">1) Aggiungi al Carrello</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">2) ORDINA</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">3) Effettua il Pagamento</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">4) Allega i File</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">5) Noi verifichiamo i File</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">6) Realizziamo il Prodotto</b>
            <b class="StatoCarrello bkgGrey ColorWhite ">7) Ricevi il tuo Ordine</b>
        </div>

    <h3 class="orange" style="margin-left:80px;"><img src="/img/icoCart50.png" />DETTAGLIO DEL TUO ORDINE N° <b class="black"><%=GetIdConsView%></b> del <b class="black"><%=Ordine.DataInserimentoStr %></b></h3>
     <div class="riepilogoOrdine ">
         <hr />
        <div class="BoxOrdBody">
                         <b>Riepilogo Ordine</b>
                         <table>

                             <tr height="12">
                                 <td width="100">N° Ordine</td>
                                 <td class="TDValore"><b><%=GetIdConsView%></b></td>
                                 <td rowspan="5" width="180" valign="top" >
                                    <center><b class="statoOrdineLabel" style='background-color:<%=ordine.ColoreStatoHtml%>;'><%=ordine.StatoStr%></b></center><br />
                                     <table>
                                         <tr>
                                             <td>Totale Lavori: </td>
                                             <td align="right"><b>€ <%=ordine.ImportoTotOrdiniNettoOriginaleStr%></b></td>
                                         </tr>
                                           <%If Ordine.ImportoTotaleSconti <>0 and Ordine.IdCouponUtilizzato <>0  Then%>
                                            <tr>
                                                <td align="left">
                                                    Sconti per Coupon:
                                                </td>
                                                <td align="right"><b class="red">- € <%=Ordine.ImportoTotaleScontiStr%></b></td>
                                            </tr>
                                            <%end if %>
                                         <tr>
                                             <td>Totale Spedizioni: </td>
                                             <td align="right"><b>€ <%=ordine.ImportoConsegnaStr%></b></td>
                                         </tr>
                                         <tr>
                                             <td>IVA (<%=FormerWeb.FormerWebApp.GetPercIva%>%): </td>
                                             <td align="right"><b>€ <%=ordine.ImportoTotIvaStr%></b></td>
                                         </tr>
                                         <tr>
                                             <td>TOTALE: </td>
                                             <td align="right"><b>€ <%=ordine.ImportoTotStr%></b></td>
                                         </tr>
                                     </table>
                                 </td>
                             </tr>                             

                            <tr height="12">
                                 <td width="100">Data Ordine</td>
                                 <td class="TDValore"><b><%=ordine.DataInserimentoStr %></b></td>
                            </tr>
                             <tr height="12">
                                 <td width="100">N° Lavori</td>
                                 <td class="TDValore" ><b><%=ordine.ListaOrdini.Count%></b></td>
                             </tr>
                             <tr height="12">
                                 <td width="100" valign="top">Pagamento</td>
                                 <td class="TDValore"><b><%=ordine.PagamentoStr%></b></td>
                             </tr>
                             <tr>
                                 <td></td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td colspan="3">                                     
                                     <b>LAVORI NELL' ORDINE</b><br />
                                     Qui trovi l'elenco dei lavori che sono contenuti in questo Ordine.
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
    <h5>Riepilogo Consegna</h5> 
        <div class="BoxOrdBody">
            <b>Riepilogo Consegna</b>
              <table>
                    <tr height="12">
                        <td width="100">Data Consegna</td>
                        <td><b class="<%=Ordine.DataOrdineClasse %>"><%=StrConv(Ordine.GiornoConsegna.ToString("dddd dd MMMM yyyy"),VbStrConv.ProperCase) %> <%=Ordine.DataOrdineLabel %></b></td>
                        <td width="250" align="center" rowspan="4">
                            <%If Ordine.Tracciabile Then%>
                                <a href="<%=GetTraceUrl%>" class="linkbtnGreen" target="_blank"><img src="/img/icoCorriere20.png" width="16" /> <b>TRACCIA IL MIO PACCO</b></a>
                            <%End If%>
                        </td>
                    </tr>
                    <tr height="12">
                        <td>Corriere</td>
                        <td> <b><%=Ordine.CorriereStr%></b></td>
                    </tr>

                    <tr height="12">
                        <td></td>
                        <td> (Colli <b><%=ordine.NumeroColliStr%></b>, Peso <b><%=ordine.PesoKg%></b> kg ±)</td>
                    </tr>
                    <tr height="12">
                        <td width="100" valign="top">Indirizzo</td>
                        <td><b><%=ordine.IndirizzoStr%></b></td>
                    </tr>
              </table>
        </div>
      
    <h5>Pagamento</h5> 
        <asp:Panel runat="server" ID="pnlPagamentoEffettuato" Visible="false">
            <br />
            <center><asp:Label runat="server" ID="lblPagamentoEffettuato" Text="-"></asp:Label></center>
            <br />
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlPagamAnticip" Visible="true">
            Puoi effettuare il pagamento di questo ordine tramite: 
            <div class="BoxOrdBody">

<%If Pagabile Then%>
            <div class="MetodoPagamento">
                <img src="/img/payment/icoPP.png" alt="Pagamento con PayPal" class="roundedBorder" style="vertical-align:middle;"/> <b>PAGA CON PAYPAL</b>
                <br /><br />    
                <b>Tipografia Former</b> accetta il pagamento attraverso il circuito sicuro <b>PayPal</b>.<br /><br /> 
            <input type="hidden" name="business" value="<%=FormerWeb.FormerWebApp.PPSeller%>"/>
            <!-- Specify a Buy Now button. -->
            <input type="hidden" name="cmd" value="_xclick"/>
            <!-- Specify details about the item that buyers will purchase. -->
            <input type="hidden" name="item_name" value="Ordine <%=Ordine.IdConsegna%> del <%=Ordine.DataInserimento.ToString("dd/MM/yyyy") %>"/>
            <input type="hidden" name="amount" value="<%=Ordine.ImportoTotPayPal%>"/>
            <input type="hidden" name="currency_code" value="EUR"/>
            <input type="hidden" name="return" value="<%=FormerWeb.FormerWebApp.PPOkUrl %>"/>
            <input type="hidden" name="cancel_return" value="<%=FormerWeb.FormerWebApp.PPKoUrl  %>"/>
            <input type="hidden" name="custom" value="<%=Ordine.GuidTransazione%>"/>
            <!-- Display the payment button. -->
                    <center><a href="#" onclick="ppGo(); return false;" class="pulsante120Green">PAGA ADESSO</a>
                    </center><br /><br />
            <img src="/img/PPVerified.png" style="float:right;"/>
            <b>PayPal</b>, società del gruppo eBay, consente a chiunque possieda un indirizzo e-mail di inviare e ricevere pagamenti online in modo facile, veloce e sicuro. 
            <br />La registrazione al servizio e l'invio di denaro sono gratuiti ed è possibile effettuare pagamenti istantanei in tutta sicurezza con la propria carta di credito. 
           <br /><br /> <b>Tipografia Former</b> non ha accesso in nessun modo ai dati della tua Carta di Credito o ai tuoi dati di accesso a PayPal<br /><br />
            Pagando tramite <b>PayPal</b> il suo ordine passerà automaticamente <b>In Lavorazione</b> appena effettuerà il pagamento.
                
            </div>

                <%If MostraBancaSella Then %>

                <div class="MetodoPagamento">
                    <img src="/img/payment/icoCC.png" alt="Pagamento con Carta di Credito" class="roundedBorder" style="vertical-align:middle;"/> <b>PAGA CON CARTA DI CREDITO</b>
                    <br /><br />    
                <b>Tipografia Former</b> accetta il pagamento attraverso Carta di Credito attraverso il circuito sicuro <b>GestPay Bancasella</b>.<br /><br /> 

                    <center><asp:LinkButton ID="btnPayBancaSella" runat="server" Text="Paga adesso" cssclass="pulsante120Green "></asp:LinkButton></center>

                    <br /><br /> <b>Tipografia Former</b> non ha accesso in nessun modo ai dati della tua Carta di Credito<br /><br />
            Pagando tramite <b>Gestpay Bancasella</b> il suo ordine passerà automaticamente <b>In Lavorazione</b> appena effettuerà il pagamento.
           
                </div>
                <%End If%>       
<%End If%>                
                <div class="MetodoPagamento">
            <img src="/img/payment/icoBB.png" alt="Pagamento con Bonifico Bancario" class="roundedBorder" style="vertical-align:middle;"/> <b>PAGA CON BONIFICO BANCARIO</b>
            <br /><br />

Potrà eseguire il pagamento tramite Bonifico Bancario utilizzando i seguenti dati:<br /><br />

<div style="margin-left:30px;">
Causale: <b>Pagamento Ordine Online <%=Ordine.IdConsegna%></b><br />
<%=MgrAziende.GetNomeBanca(MgrAziende.IdAziende.AziendaSrl) %><br />
Conto corrente intestato a <b>Tipografia Former S.r.l.</b><br />
IBAN: <%=MgrAziende.GetIBAN(MgrAziende.IdAziende.AziendaSrl) %><br />
<br /><br />
</div>
Una  volta effettuato il versamento, sarà necessario inviare i dati identificativi del pagamento (CRO) e la ricevuta del bonifico all'indirizzo email <b><a href="mailto:pagamenti@tipografiaformer.it">pagamenti@tipografiaformer.it</a></b>
<br /><br />Provvederemo alla registrazione del versamento nell'arco di circa 3 gg. lavorativi.

                    </div>
                </div>
        </asp:Panel>
        
        <h5>Documento Fiscale</h5> 
        Da qui puoi scaricare il documento fiscale relativo al tuo ordine in formato <b>PDF</b><br /><br />
        <center><img src="/img/icoPDF32.png" alt="Documento fiscale in PDF" class="roundedBorder"/> 
            <asp:Label ID="lblNoDocFisc" runat="server" Text="Documento fiscale non ancora disponibile" Visible="true"></asp:Label>
            <asp:LinkButton ID="lblDocFiscDownload" runat="server" Font-Bold="true" Text="Scarica Documento fiscale" Visible="false"></asp:LinkButton>
        </center><br /><br /><br /><br /><br />
    </div>
</div>
</asp:Content>
