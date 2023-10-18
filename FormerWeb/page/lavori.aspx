<%@ Page Title="" Language="vb" MaintainScrollPositionOnPostback="true"  AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" 
    CodeBehind="lavori.aspx.vb" Inherits="FormerWeb.pLavori" %>
<%@ Import Namespace="Formerlib.formerenum" %>
<%@ Import Namespace="FormerLib.FormerColori" %>
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
                            $("#accordionOrdini").accordion({
                                icons: icons,
                                collapsible: true,
                                heightStyle: "content"
                            });

                        });

                </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">   
<h3 class="orange"><img src="/img/icoLavoro50.png" />I TUOI LAVORI</h3>
<div class="ordini">
    
    <div id="tabs" >
        <ul>
        <li><a href="#tabs-1"><img src="/img/icoLavoro20.png" alt="I tuoi lavori" class="icoImg"/> Tutti i tuoi Lavori</a></li>
        <li><a href="#tabs-2"><img src="/img/icoLavOpz16.png" alt="Legenda Stato Lavori" class="icoImg"/> Legenda Stato Lavori</a></li>
        </ul>
        <div id="tabs-1"><br />
            Da qui puoi consultare lo stato dei tuoi lavori ed essere sempre informato sulla fase di lavorazione. Lo stato dei lavori viene aggiornato all' incirca <b>ogni 15 minuti</b>.<br /><br />
            Clicca sul <b style="font-size:14px;">+</b> che vedi accanto a ogni Lavoro per visualizzare il dettaglio e le operazioni che puoi effettuare.
            <br /><br />
            <table width="100%" class="BoxOrdInt">
                <tr>
                    <td width="15">&nbsp;</td>
                    <td width="30">&nbsp;</td>
                    <td width="35"><b style="color:red;">STATO</b></td>
                    <td><b style="color:red;">PRODOTTO ACQUISTATO</b></td>
                    <td width="140"><%--<b style="color:red;">CONSEGNA</b>--%></td>
                    <td width="60" align="center"><b style="color:red;">LAVORO</b></td>
                    <td width="100" align="center"><b style="color:red;">IMPORTO NETTO</b></td>
                </tr>
            </table>
            <asp:Repeater ID="rptOrdini" runat="server">
            <HeaderTemplate><div id="accordionOrdini"></HeaderTemplate>
            <ItemTemplate>
                             
                <h3><FormerWeb:HeaderLavoro runat="server" Id="HeaderOrdine" /></h3>
                <div>
                    <FormerWeb:CorpoLavoro runat="server" Id="CorpoOrdine" />
                    <FormerWeb:FooterLavoro runat="server" Id="FooterOrdine" />
                </div>
            </ItemTemplate>
            <FooterTemplate></div></FooterTemplate>
        </asp:Repeater>
                        
            <div class="pager">Vai alla pagina <asp:PlaceHolder ID="plcPaging" runat="server" /> <asp:Label runat="server" ID="lblPageName"  /></div>
            
        </div>
        <div id="tabs-2">
          <div class="StatiCarrello">
                <b class="StatoCarrello bkgGrey ColorWhite ">1) Aggiungi al Carrello</b>
                <b class="StatoCarrello bkgGrey ColorWhite ">2) ORDINA</b>
                <b class="StatoCarrello bkgGrey ColorWhite ">3) Effettua il Pagamento</b>
                <b class="StatoCarrello bkgGrey ColorWhite ">4) Allega i File</b><br /><br />
                <b class="StatoCarrello bkgGrey ColorWhite ">5) Noi verifichiamo i File</b>
                <b class="StatoCarrello bkgGrey ColorWhite ">6) Realizziamo il Prodotto</b>
                <b class="StatoCarrello bkgGrey ColorWhite ">7) Ricevi il tuo Ordine</b>
            </div><br /><br />

            <br />Vuoi sapere cosa significano gli <b>Stati dei Lavori</b>? Ecco una spiegazione dettagliata di ogni stato.<br /><br />
            <table>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InAttesaPagamento, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InAttesaPagamento)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InAttesaPagamento, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono pronti per essere messi in produzione e attendono solamente che tu effettui il pagamento.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InAttesaAllegati, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InAttesaAllegati)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InAttesaAllegati, True).toupper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono in attesa che vengano <b>Allegati i file</b>. Puoi effettuare questa operazione cliccando sul link <b>Vai al Dettaglio</b> oppure cliccando sul link <b>Invia i File</b><br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Preinserito)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Preinserito, True).toupper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono in attesa che l'integrità e la congruenza del formato dei file che ci hai inviato venga verificata dal sistema. <br /><br />
                    </td>
                </tr>

                                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Registrato, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Registrato)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Registrato, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono in produzione, non possono essere modificati e stanno per essere schedulati per la stampa.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InSospeso, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InSospeso)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InSospeso, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono sospesi per vostra o nostra comunicazione.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InCodaDiStampa, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InCodaDiStampa)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InCodaDiStampa, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.StampaInizio, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.StampaInizio)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.StampaInizio, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.StampaFine, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.StampaFine)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.StampaFine, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraCommessaInizio, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.FinituraCommessaInizio)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraCommessaInizio, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraCommessaFine, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.FinituraCommessaFine)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraCommessaFine, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraProdottoInizio, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.FinituraProdottoInizio)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraProdottoInizio, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraProdottoFine, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.FinituraProdottoFine)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.FinituraProdottoFine, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono nel processo produttivo.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Imballaggio, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Imballaggio)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Imballaggio, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato vengono sottoposti al controllo qualità per essere imballati e spediti.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.ImballaggioCorriere, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.ImballaggioCorriere)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.ImballaggioCorriere, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato vengono sottoposti al controllo qualità per essere imballati e spediti con il corriere scelto.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.ProntoRitiro, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.ProntoRitiro)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.ProntoRitiro, True).toupper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono pronti per essere ritirati presso la nostra sede (se concordato).<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.UscitoMagazzino, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.UscitoMagazzino)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.UscitoMagazzino, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono in transito verso l'indirizzo di spedizione.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InConsegna, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.InConsegna)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.InConsegna, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono in transito verso l'indirizzo di spedizione.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Consegnato, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Consegnato)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Consegnato, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono stati consegnati al destinatario.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.PagatoAcconto, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.PagatoAcconto)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.PagatoAcconto, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        Per questi lavori è stato corrisposto solo un acconto.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.PagatoInteramente, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.PagatoInteramente)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.PagatoInteramente, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato risultano interamente saldati.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Rifiutato, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Rifiutato)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Rifiutato, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono stati rifiutati per vostra o nostra comunicazione.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="statoOrdineBox" title="<%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Eliminato, True)%>" style="background-color:<%=FormerLib.FormerColori.GetColoreStatoOrdineHtml(enStatoOrdine.Eliminato)%>;"></div>
                    </td>
                    <td>
                        <b><%=FormerEnumHelper.StatoOrdineString(enStatoOrdine.Eliminato, True).ToUpper%></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I lavori in questo stato sono stati eliminati per vostra o nostra comunicazione.<br /><br />
                    </td>
                </tr>
            </table>


            <br /><br />
             
        </div>

    </div>

</div>
  

  
</asp:Content>
