<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucAdmin.ascx.vb" Inherits="FormerWeb.ucAdmin" %>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

<div id="tabs">
            <ul>
            <li><a href="#tabs-1">Utenti Connessi</a></li>
            <li><a href="#tabs-2">Ultimi Utenti Registrati</a></li>
            <li><a href="#tabs-4">Lavori Attesa File</a></li>
            <li><a href="#tabs-7">Lavori Attesa Scaricamento</a></li>
            <li><a href="#tabs-5">Ordini Attesa Pagamento</a></li>
            <li><a href="#tabs-6">Google Search</a></li>
           <%-- <li><a href="#tabs-3">Go to</a></li>--%>
            </ul>
            <div id="tabs-1">
<h4>LOG ULTIMI 5 GIORNI</h4>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<asp:Table runat="server" ID="tableLog" Width="100%" Font-Size="Smaller" ></asp:Table><br />
<asp:Label ID="lblTotRecensioni" runat="server" Text="-"></asp:Label><br />
<asp:Label ID="lblTotOrdAll" runat="server" Text="-"></asp:Label><br />
<asp:Label ID="lblTotOrdPag" runat="server" Text="-"></asp:Label><br />
<asp:Label ID="lblTotUtOggi" runat="server" Text="-"></asp:Label><br />
<asp:Label ID="lblTotaleLog" runat="server" Text="-"></asp:Label>
 <h4>UTENTI CONNESSI (ultimi 10 minuti)</h4>
<asp:Label ID="lblTitolo" runat="server" Text="-"></asp:Label> <asp:Label ID="lblTotUtentiGiornata" Visible="false" runat="server" Text="(0 unici in totale)"></asp:Label><br /><br />
    <asp:Button ID="btnAggiornaUtenti" runat="server" Text="Aggiorna lista utenti" />
   
    <asp:Table runat="server" ID="tableAdmin">
    </asp:Table>
<h4>CONNESSIONI DB ATTIVE AL MOMENTO: <asp:Label ID="lblTotConnAttive" runat="server" Text="0" ForeColor="Green" Font-Size="Medium" ></asp:Label></h4>
<h4>DEBUG ATTIVO: <asp:Label ID="lblDebugAttivo" runat="server" Text="No, tutto OK!!!" ForeColor="Green"></asp:Label> </h4>
        <asp:Button ID="btnReset" runat="server" Text="Reset Application Pool" OnClientClick = "return confirm('ATTENZIONE! Sicuro di voler resettare Application Pool e terminare tutte le sessioni attive?');" />
        <asp:Button ID="btnTestTLS12" runat="server" Text="Test TLS" /> <asp:label ID="lblTestTls" runat="server" Text="-"></asp:label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAggiornaUtenti" EventName ="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnReset" EventName ="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnTestTLS12" EventName ="Click" />
    </Triggers>
</asp:UpdatePanel>
            </div>
        <div id="tabs-2">
            <h4>ULTIMI 30 UTENTI REGISTRATI</h4>
            <asp:DataGrid ID="dgUtentiReg" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="Dashed" BorderColor="#aaaaaa">
                <Columns>
                    <asp:BoundColumn HeaderText="DataIns" DataField="DataIns" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Ult. Accesso" DataField="LastLoginStr" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="IdUT" DataField="IdUT" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="IdRubricaInt" DataField="IdRubricaInt" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Email" DataField="Email" ItemStyle-Font-Bold="true" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Nominativo" DataField="Nominativo" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="CAP" DataField="CAP" ></asp:BoundColumn>    
                    <asp:BoundColumn HeaderText="Tipo" DataField="TipoUtStr"  ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>    
                    <asp:BoundColumn HeaderText="News" DataField="NewsletterStr"  ItemStyle-Font-Size="X-Small" ></asp:BoundColumn>    
                </Columns>
            </asp:DataGrid>
        </div>
    <div id="tabs-4">
         <h4>Lavori in Attesa File</h4>
        <asp:DataGrid ID="dgLavFile" AutoGenerateColumns="false" runat="server" BorderStyle="Dashed" BorderColor="#aaaaaa">
                <Columns >
                    <asp:BoundColumn HeaderText="Id Ordine Provvisorio" DataField="IdCons"></asp:BoundColumn>
                    <asp:HyperLinkColumn HeaderText="Id Lavoro Provvisorio" DataNavigateUrlField="IdOrdineWithAttach" DataTextField="IdOrdine"></asp:HyperLinkColumn>
                    <asp:BoundColumn HeaderText="Data Ins" DataField="DataInsStr" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Cliente" DataField="NomeCliente"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Qta" DataField="Qta"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Prodotto" DataField="NomeProdotto"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo" DataField="ImportoNettoStr" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Pagato" DataField="PagatoStr" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Bold="true" ></asp:BoundColumn>
                </Columns>
        </asp:DataGrid>
    </div>
     <div id="tabs-7">
         <h4>Lavori in Attesa di essere scaricati</h4>
        <asp:DataGrid ID="dgLavDownload" AutoGenerateColumns="false" runat="server" BorderStyle="Dashed" BorderColor="#aaaaaa">
                <Columns >
                    <asp:BoundColumn HeaderText="Id Ordine Provvisorio" DataField="IdCons"></asp:BoundColumn>
                    <asp:HyperLinkColumn HeaderText="Id Lavoro Provvisorio" DataNavigateUrlField="IdOrdineWithAttach" DataTextField="IdOrdine"></asp:HyperLinkColumn>
                    <asp:BoundColumn HeaderText="Data Ins" DataField="DataInsStr" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Cliente" DataField="NomeCliente"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Qta" DataField="Qta"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Prodotto" DataField="NomeProdotto"></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Importo" DataField="ImportoNettoStr" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                    <asp:BoundColumn HeaderText="Pagato" DataField="PagatoStr" ItemStyle-HorizontalAlign="Right" ItemStyle-Font-Bold="true" ></asp:BoundColumn>
                </Columns>
        </asp:DataGrid>
    </div>
    <div id="tabs-5">
         <h4>Ordini in Attesa Pagamento</h4>
        <asp:DataGrid ID="dgOrdPag" AutoGenerateColumns="false" runat="server" BorderStyle="Dashed" BorderColor="#aaaaaa">
                            <Columns >
                                <asp:BoundColumn HeaderText="Id Ordine Provvisorio" DataField="IdConsegna"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Data" DataField="DataInserimentoStr"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Cliente" DataField="NomeCliente"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Importo" DataField="ImportoTotStr" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Tipo Pagamento" DataField="PagamentoStr" ></asp:BoundColumn>
                            </Columns>
                            
                        </asp:DataGrid>
    </div>
            <%--<div id="tabs-3">
                <h4>REGISTRO GOTO</h4>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DataGrid ID="dgGoto" AutoGenerateColumns="false" runat="server" BorderStyle="Dashed" BorderColor="#aaaaaa">
                            <Columns >
                                <asp:BoundColumn HeaderText="Id Trace" DataField="IdTraceSource"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Nome" DataField="Nome"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Target Url" DataField="TargetUrl"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Counter" DataField="Counter" ItemStyle-HorizontalAlign="Right" ></asp:BoundColumn>
                            </Columns>
                            
                        </asp:DataGrid><br />
                        <asp:Button ID="btnGoto" Visible="false" runat="server" Text="Aggiorna" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
           <div id="tabs-6">
               <br /><br />
               <script>
              (function() {
                var cx = '001889055259115357444:d4u91wqylla';
                var gcse = document.createElement('script');
                gcse.type = 'text/javascript';
                gcse.async = true;
                gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') +
                    '//www.google.com/cse/cse.js?cx=' + cx;
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(gcse, s);
              })();
            </script>
            <gcse:search></gcse:search>
            <br /><br />
           </div>
</div>


