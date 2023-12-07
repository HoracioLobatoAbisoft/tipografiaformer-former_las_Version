<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucCarrelloHelp.ascx.vb" Inherits="FormerWeb.ucCarrelloHelp" %>
<script>

    function CarrelloHelp() {

   $(function () {
        var icons = {
            header: "ui-icon-plus",
            activeHeader: "ui-icon-minus"
        };
        
        $("#accordionHelp").accordion({
            icons: icons,
            collapsible: true,            
            heightStyle: "content"
        });
    });

    }

    $(document).ready(function () {
        CarrelloHelp();
    });

 
</script>
<br />
<br />
<div class="CarrelloHelp">
<h2>Informazioni sul Carrello</h2>
<div id="accordionHelp">
    <h3>Come funziona il Carrello?</h3>

        <div>
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
    <h3>Quando posso allegare i file PDF ai lavori contenuti nell'ordine?</h3>
    <div>
        Una volta completato l'ordine, ed eventualmente effettuato il pagamento (se sceglierai una modalità di pagamento anticipata), potrai allegare i file PDF entrando nel dettaglio di ogni lavoro dalla sezione <b>'I tuoi lavori'</b>.
    </div>
    <h3>Come posso utilizzare un Coupon di Sconto?</h3>
        <div>
            Puoi trovare tutte le informazioni necessarie sui Coupon di sconto nella pagina dedicata <a  style="color:#f58220;" href="/i-tuoi-coupon-di-sconto">cliccando qui</a><br /><br />
            Se hai un Coupon di sconto puoi inserirlo nella sezione del Carrello relativa al Pagamento
       </div>
    <h3>Perchè il mio Carrello è vuoto?</h3>
    <div>
        Per inserire dei prodotti nel carrello, vai nella scheda del prodotto che ti interessa e clicca sul pulsante <b>'Aggiungi al Carrello'</b>
    </div>
    <h3>Dove posso scegliere il tipo di Consegna che preferisco?</h3>
    <div>
        Nella sezione del carrello <b>"Scegli la Consegna"</b> potrai selezionare il tipo di consegna che preferisci.<br /><br /> Potrai anche specificare un indirizzo di consegna differente da quello fornito al momento della registrazione. 
    </div>
    <h3>In che modo posso pagare il mio ordine? </h3>
    <div>
        Nella sezione del carrello <b>"Scegli il Pagamento"</b> potrai scegliere la modalità di pagamento che preferisci.<br /><br /> Se hai a disposizione un Coupon di sconto potrai inserirlo in modo che il tuo sconto venga applicato all'ordine.
    </div>
</div>
</div>

        <script type="text/javascript">
        // Create the event handler for PageRequestManager.endRequest
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(CarrelloHelp);
    </script>