<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/main.master" CodeBehind="richiedipreventivo.aspx.vb" Inherits="FormerWeb.pRichiediPreventivo" %>
<%@ Register  TagPrefix="FormerWeb" TagName="AlberoPreventivazioni" Src="~/userControl/ucPreventivazioni.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
         $(function () {
             var icons = {
                 header: "ui-icon-plus",
                 activeHeader: "ui-icon-minus"
             };
             $(".varianteLB").accordion({
                 icons: icons,
                 collapsible: true,
                 active:0,                 
                 heightStyle: "content"
             });
             $(".PrevCatLav").accordion({
                 icons: icons,
                 collapsible: true,
                 active:false,                 
                 heightStyle: "content"
             });

             var parameter = Sys.WebForms.PageRequestManager.getInstance();

            parameter.add_endRequest(function() {
                 $(".varianteLB").accordion({
                     icons: icons,
                     collapsible: true,
                     active:0,                 
                     heightStyle: "content"
                 });
                 $(".PrevCatLav").accordion({
                     icons: icons,
                     collapsible: true,
                     active:false,                 
                     heightStyle: "content"
                 });
            });

         });

    </script>
    
    <script>

         function onlyNos(e, t) {

            try {

                if (window.event) {

                    var charCode = window.event.keyCode;

                }

                else if (e) {

                    var charCode = e.which;

                }

                else { return true; }

                if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                    return false;

                }

                return true;

            }

            catch (err) {

                alert(err.Description);

            }

        }

        $(function CaricaCarta () {
            var prodotti = [
            <%=BufferTipoCarta%>
            ];

            $("#txtTipoCarta").autocomplete({
                source: prodotti,
                'open': function(e, ui) {
                    $('.ui-autocomplete').css('background-color', 'white');
                    $('.ui-autocomplete').css('font-family', 'sans-serif');
                    $('.ui-autocomplete').css('font-size', 'small');
                
        }
            });

        });
        
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

        <div class="colSx">
                <!--PREVENTIVAZIONI-->
                <FormerWeb:AlberoPreventivazioni id = "AlberoPreventivazioni" runat="server"/>
        </div>

    <div class="colDx">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:panel ID="pnlNewInd" runat="server" >
                                
<h3 class="orange"><img src="/img/icoPrev24.png" /> RICHIEDI UN PREVENTIVO</h3>

Qui puoi richiedere un preventivo per una variante di uno dei nostri prodotti<br /><br />
<asp:UpdatePanel ID="updForm" runat="server">
                            <ContentTemplate>

    <div class="riepilogoOrdini">

        <div class="fintoAccordionHeader"><b>Dettaglio Lavoro richiesto</b></div>

        <%If LRif.IdListinoBase Then %>
        
        <div class="varianteLB">
            <h3>Variante su</h3>
            <div>
                <b style="font-size:14px;"><a href="<%=GetUrlListino%>"><%=LRif.Nome  %></a></b><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.GetImgFormato%>" class="imgFormato "/>
            </div>
        </div>
        <%End If %>

        <table style="margin:0 auto 0 auto;">
            <tr>
                <td></td>
                <td class="cellaEtichetta">Reparto</td>
                <td class="cellaValore">
                    <asp:DropDownList runat="server" ID="ddlReparto" Font-Size="14px" Width="300px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td></td>
                <td class="cellaEtichetta">Nome Lavoro</td>
                <td class="cellaValore"><asp:textBox runat="server" id="txtNome" Font-Size="14px" width="250px" MaxLength="50"></asp:textBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="cellaEtichetta">Quantità</td>
                <td class="cellaValore"><asp:textBox FilterType="Numbers" runat="server" id="txtQtaUser" Font-Size="14px" width="65px" MaxLength="6"></asp:textBox></td>
            </tr>
            <tr>
                <td></td>
                <td class="cellaEtichetta">Formato</td>
                <td class="cellaValore">
                    <table border="0">
                        <tr>
                            <td style="font-size:11px;font-weight:bold;vertical-align:central;">Larghezza</td>
                            <td style="font-size:11px;vertical-align:central;"><asp:textBox onkeypress="return onlyNos(event,this);" runat="server" id="txtLarghezza" Font-Size="14px" width="65px" MaxLength="6"></asp:textBox> (millimetri)</td>
                        </tr>
                        <tr>
                            <td style="font-size:11px;font-weight:bold;vertical-align:central;">Altezza</td>
                            <td style="font-size:11px;vertical-align:central;"><asp:textBox onkeypress="return onlyNos(event,this);" runat="server" id="txtLunghezza" Font-Size="14px" width="65px" MaxLength="6"></asp:textBox> (millimetri)</td>
                        </tr>

                    </table>
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="cellaEtichetta">Orientamento</td>
                <td class="cellaValore">
                    <asp:DropDownList runat="server" ID="ddlOrientamento" Font-Size="14px" Width="300px" ></asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td></td>
                <td class="cellaEtichetta">Tipologia carta</td>
                <td class="cellaValore">
                    <asp:DropDownList ID="ddlTipologia" runat="server" Font-Size="14px" Width="300px" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td></td>
                <td class="cellaEtichetta">Tipo carta</td>
                <td class="cellaValore">
                    <asp:DropDownList ID="ddlTipoCarta" runat="server" Font-Size="14px" Width="300px"></asp:DropDownList>
                    <%--<asp:TextBox id="txtTipoCarta" ClientIDMode="Static" runat="server" Font-Size="14px" Width="300px"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="cellaEtichetta">Colori di stampa</td>
                <td class="cellaValore">
                    <asp:DropDownList ID="ddlColoreStampa" runat="server" Font-Size="14px" Width="300px"></asp:DropDownList>
                </td>
            </tr>

            <%If LRif.IdListinoBase = 0 OrElse LRif.ShowLabelFogli() Then%>

            <tr>
                <td></td>
                <td class="cellaEtichetta">Multipagina</td>
                <td class="cellaValore">
                    <table border="0">
                        <tr>
                            <td style="font-size:11px;font-weight:bold;vertical-align:central;">Multipagina?</td>
                            <td style="vertical-align:central;"><asp:CheckBox ID="chkMultipagina" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="font-size:11px;font-weight:bold;vertical-align:central;">Numero Facciate</td>
                            <td style="vertical-align:central;"><asp:TextBox  onkeypress="return onlyNos(event,this);" ID="txtNumFacciate" runat="server"  Font-Size="14px" width="65px" MaxLength="3"/></td>
                        </tr>
                        <tr>
                            <td style="font-size:11px;font-weight:bold;vertical-align:central;">Autocopertinato?</td>
                            <td style="vertical-align:central;"><asp:CheckBox ID="chkAutocopertinato" runat="server" /></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <%end If%>
            
        </table>
        <h5 class="preventivatoreH5">Opzioni disponibili</h5>
        <div class="preventivoOpzioni">
            <!--QUI GESTISCO LE LAVORAZIONI-->
            <asp:Table ID="tableLav" runat="server">

            </asp:Table>
                              
        </div>
       
        <h5 class="preventivatoreH5">Note e Indicazioni aggiuntive</h5>

        <asp:TextBox ID="txtNote" runat="server" CssClass="NotePreventivo" TextMode="MultiLine" Font-Size="14px" placeholder="Inserire qui indicazioni aggiuntive riguardanti il preventivo o annotazioni"></asp:TextBox>
        <br />



        <div style="padding:20px;text-align:right;"><asp:linkbutton id="lnkRichiedi" runat="server" cssclass="pulsante120Orange" OnClientClick = "return confirm('Vuoi inviare questa richiesta di preventivo?');" ><img src="/img/icoSaveW.png" /> Richiedi</asp:linkbutton></div>

        <asp:Panel ID="pnlPreventivo" runat="server" Visible ="false">

            <div>
                <h5 class="preventivatoreH5">Preventivo Calcolato</h5>

                <br /><br />
                <asp:Label ID="lblBufferPreventivo" runat="server"></asp:Label>

            </div>

        </asp:Panel>

        </div>

</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlReparto"  EventName="SelectedIndexChanged" />
        <%--<asp:AsyncPostBackTrigger ControlID="ddlTipologia"  EventName="SelectedIndexChanged" />--%>
    </Triggers>
</asp:UpdatePanel>

         </asp:panel>

        <div class="DescrizioneDinamica" style="width:90%;margin:20px 0px 20px 0px">
    <h1>Stato Preventivi</h1>
    Vuoi sapere cosa significano gli <b>Stati dei Preventivi</b>? Ecco una spiegazione dettagliata di ogni stato.<br /><br />
        <table>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="icoPrev"><img src="/img/icoPrevInserito.png" /></div>
                    </td>
                    <td>
                        <b>INSERITO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I preventivi in questo stato sono stati inseriti dall'utente ma non ancora scaricati nei nostri sistemi.<br /><br />
                    </td>
                </tr>
                <tr>
                    <td valign="top" rowspan="2">
                        <div class="icoPrev"><img src="/img/icoPrevConsegnato.png" /></div>
                    </td>
                    <td>
                        <b>CONSEGNATO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I preventivi in questo stato sono stati scaricati nei nostri sistemi e a breve verranno presi in carico da uno dei nostri operatori.<br /><br />
                    </td>
                </tr>

                <tr>
                    <td valign="top" rowspan="2">
                        <div class="icoPrev"><img src="/img/icoPrevLetto.png" /></div>
                    </td>
                    <td>
                        <b>LETTO</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        I preventivi in questo stato sono stati presi in carico da uno dei nostri operatori. A breve riceverai una risposta!<br /><br />
                    </td>
                </tr>

        </table>
  </div>

    </div>
</asp:Content>