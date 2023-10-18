<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.master" CodeBehind="ituoipreventivi.aspx.vb" Inherits="FormerWeb.ituoipreventivi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange"><img src="/img/icoMieiCoupon30.png" />I TUOI COUPON DI SCONTO</h3>
    <div class="ordini">
         <div id="tabs" >
        <ul>
        <li><a href="#tabs-1"><img src="/img/icoMieiCoupon20.png" alt="I tuoi Coupon di Sconto" class="icoImg"/> I tuoi Coupon di Sconto <img src="/img/new.gif" /></a></li>
        <li><a href="#tabs-2"><img src="/img/icoInfo20.png" alt="Come funzionano i Coupon?" class="icoImg"/> Come funzionano i Coupon?</a></li>
        </ul>
        <div id="tabs-1" style="min-height:400px;">
            <div class="offerte">
            Qui trovi i tuoi <b>Coupon di Sconto</b> esclusivi che hai a disposizione per acquistare i nostri prodotti usufruendo di una promozione a te riservata.<br />
            (* I coupon già utilizzati o scaduti non vengono visualizzati)<br />
            <br />
            <asp:Repeater runat="server" ID="rptCoupon">

                <ItemTemplate>

                    <div class="YourCoupon">
                        <table width="100%" border="0">
                            <tr>
                                <td width="100" align="center" rowspan="2">
                                    <img runat="server" id="imgLB" />
                                </td>
                                <td align="center">
                                    Acquista <span class="couponLabel"><%#Eval("Riassunto")%></span> <br />
                                    Sconto Netto <span class="couponLabel"><%#Eval("ScontoStr") %></span> (Valido fino al <b class="red"><%#Eval("DataFineValiditaStr")%></b>)
                                </td>
                                <td width="100" rowspan="2" align="center">
                                    <img src="/img/icoMieiCoupon30.png" /><br />
                                    <span class="couponLabel"><%#Eval("Disponibili")%></span> Disponibili
                                    
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>Codice da inserire per attivare la promozione: <span class="couponLabel"><%#Eval("Codice")%></span></td>
                            </tr>
                            <asp:Panel ID="pnlLnkToProd" runat="server" Visible="false">
                            <tr>
                                <td colspan="3" align="right">
                                <hr />
                                <a id="lnkToProd" runat="server" ><img src="/img/icoFreccia16.png" /> Vai alla scheda del Prodotto in Promozione</a>
                                </td>
                            </tr>
                            </asp:Panel>
                        </table>
                    </div>
                    
                </ItemTemplate>

            </asp:Repeater><center><asp:Label ID="lblNoCoupon" runat="server" Font-Bold="true" Font-Size="Large"  Visible="false" Text="<br>Al momento non sono presenti Coupon di Sconto"></asp:Label></center>
                </div>
        </div>
        <div id="tabs-2">
            <div class="offerte">
            <b> - Cosa sono i Coupon di Sconto?</b><br />
            I <b>tuoi Coupon di Sconto</b> sono dei sconti esclusivi che hai a disposizione per acquistare i nostri prodotti usufruendo di una promozione a te riservata.<br /><br />
            <b> - Come ottenere i Coupon di Sconto?</b><br />
            Per ottenere Coupon di Sconto ti basta ordinare i prodotti che trovi nella sezione <b>Offerte e Promozioni</b>. Per andare alla sezione <b>Offerte e Promozioni</b> <a href="/offerte-e-promozioni"><b class="orange">clicca qui</b></a><br /><br />
            <b> - Quando ricevo i Coupon di Sconto per un mio ordine?</b><br />
            Ogni volta che ordini un prodotto su cui è attiva una promozione riceverai un Coupon di Sconto. Il Coupon ti verrà recapitato tramite email <b>DOPO CHE AVRAI ALLEGATO I FILE AL RELATIVO LAVORO</b> e lo troverai nella sezione <b>I tuoi Coupon di Sconto</b><br /><br />
            <b> - Come utilizzare i Coupon di Sconto?</b><br />
            Utilizzare i Coupon di Sconto è molto semplice. In ognuno dei <b>tuoi Coupon di Sconto</b> trovi il codice da inserire per attivare la promozione<br /> 
                <br /><center><img src="/img/guida/guidaCoupon1.png" class="immagineContornata"/></center><br /><br />
            Copia il codice del coupon e aggiungi al carrello il prodotto sui cui il coupon è utilizzabile nella quantità indicata.<br /><br /> Nel carrello troverai una sezione <b>Coupon di Sconto</b> dove potrai inserire il codice del tuo coupon<br />
                <br /><center><img src="/img/guida/guidaCoupon2.png" class="immagineContornata"/></center><br /><br />
            Clicca sul pulsante <b>Applica Coupon</b> e l'importo ti verrà scalato dal totale dell'ordine.<br />
            <br />
                <b>ATTENZIONE</b>    <br />
                Nell'utilizzo dei coupon ricorda queste semplici regole:
                <ul>
                    <li>Il Coupon ti verrà recapitato tramite email <b>DOPO CHE AVRAI ALLEGATO I FILE AL RELATIVO LAVORO</b> e lo troverai nella sezione <b>I tuoi Coupon di Sconto</b></li>
                    <li>Puoi utilizzare un <b>Coupon di Sconto</b> solo sul prodotto specificato e nella quantità indicata;</li>
                    <li>Ogni <b>Coupon di Sconto</b> ha una data di scadenza dopodichè non sarà più utilizzabile;</li>
                    <li>Puoi utilizzare un solo <b>Coupon di Sconto</b> in ogni ordine;</li>
                    <li>Puoi utilizzare un <b>Coupon di Sconto</b> un numero di volte uguale a quanto indicato dalla dicitura <b>Disponibili</b> presente in ogni Coupon;</li>
                </ul>
            
            </div>
        </div>
        </div>
    </div>


</asp:Content>
