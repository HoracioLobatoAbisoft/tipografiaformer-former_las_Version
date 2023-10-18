<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.master" CodeBehind="offerteepromozioni.aspx.vb" Inherits="FormerWeb.pOfferteEPromozioni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="depliant">

        <img src="/img/titoloOfferte.png" /><br /><br />

         <b> - Come funzionano le Offerte e Promozioni?</b><br />
                Inseriamo regolarmente delle Offerte e Promozioni su particolari prodotti che puoi trovare nella sezione <b>Offerte e Promozioni</b> in HomePage o nella tua Area Riservata, e che vengono evidenziate da una particolare etichetta nella lista delle Categorie<br /><br />
                <br /><center><img src="/img/guida/guidaOfferte.png" class="immagineContornata"/></center><br /><br />
            Per ogni ordine di uno dei prodotti in queste categorie, riceverai un <b>Coupon di Sconto</b> pari alla percentuale indicata nella promozione sul prossimo acquisto della stessa quantità dello stesso prodotto.<br /><br />
            <b> - Cosa sono i Coupon di Sconto?</b><br />
            I <b>tuoi Coupon di Sconto</b> sono dei sconti esclusivi che hai a disposizione per acquistare i nostri prodotti usufruendo di una promozione a te riservata.<br /><br />
            <b> - Come ottenere i Coupon di Sconto?</b><br />
            Puoi ricevere un Coupon di Sconto tramite email in una particolare iniziativa. Puoi inoltre ottenere Coupon di Sconto ordinando i prodotti che trovi nella sezione <b>Offerte e Promozioni</b>. Per andare alla sezione <b>Offerte e Promozioni</b> <a href="/offerte-e-promozioni"><b class="orange">clicca qui</b></a><br /><br />
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
    
     <script type="text/javascript">
         $(function () {
             $("#tabs").tabs({ active: <%=IIf(FormerWeb.FormerWebApp.MostraPromo, 2, 1)%> });
         });
	</script>

</asp:Content>
