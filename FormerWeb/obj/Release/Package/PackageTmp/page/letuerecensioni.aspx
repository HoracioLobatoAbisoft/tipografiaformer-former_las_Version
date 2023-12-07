<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.master" CodeBehind="letuerecensioni.aspx.vb" validateRequest="false" Inherits="FormerWeb.pLetuerecensioni" %>
<%@ Register  TagPrefix="FormerWeb" TagName="ReviewAdd" Src="~/userControl/ucReviewAdd.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>

    function ReviewAcc() {

   $(function () {
        var icons = {
            header: "ui-icon-plus",
            activeHeader: "ui-icon-minus"
        };
        
        $("#accordionRev").accordion({
            icons: icons,
            collapsible: true,
            active: true,
            heightStyle: "content"
        });
    });

    }

    $(document).ready(function () {
        ReviewAcc();
    });

 
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="green"><img src="/img/icoRecensione.png" /> LE TUE RECENSIONI</h3>
    <div class="ordini">
         <div id="tabs" >
        <ul>
        <li><a href="#tabs-1"><img src="/img/icoRecensione.png" alt="Le tue Recensioni" class="icoImg"/> Le tue Recensioni <img src="/img/new.gif" /></a></li>
        <li><a href="#tabs-2"><img src="/img/icoInfo20.png" alt="Come funzionano le Recensioni?" class="icoImg"/> Come funzionano le Recensioni?</a></li>
        </ul>
        <div id="tabs-1" style="min-height:400px;">
            
            Qui trovi i prodotti che hai acquistato per cui puoi rilasciare una <b>Recensione</b> e condividere la tua opinione con gli altri clienti.<br />
            <br />

 <div id="accordionRev">
            <asp:Repeater runat="server" ID="rptRecensioni">
                
                <ItemTemplate>
                        <h3><div class="ReviewAccordionHeader"><img src="<%#FormerWeb.FormerWebApp.PathListinoImg & Eval("BoxImgRif")%>" /> <b><%#Eval("L.Nome")%></b></div></h3>
                    <div class="ReviewAccordion">
                        <FormerWeb:ReviewAdd ID="reviewAdd" runat="server" />
                    </div>
                </ItemTemplate>
                
            </asp:Repeater>
                </div>
          <center><asp:Label ID="lblNoRecensioni" runat="server" Font-Bold="true" Font-Size="Large"  Visible="false" Text="<br>Al momento non sono presenti prodotti su cui puoi inserire una Recensione"></asp:Label></center>
        </div>
        <div id="tabs-2">
            <div class="offerte">
            <b> - Cosa sono le Recensioni?</b><br />
            Le <b>Recensioni</b> sono opinioni rilasciate dai clienti che hanno acquistato i nostri prodotti.<br /><br />
            <b> - A cosa servono le Recensioni?</b><br />
            Le <b>Recensioni</b> ti permettono di esaminare come altri clienti hanno valutato i nostri prodotti e potrai condividere la tua opinione con altri clienti.<br /><br />
            <b> - Dove trovo le Recensioni?</b><br />
            Nel dettaglio di ogni prodotto trovi le recensioni inserite dai clienti che lo hanno ordinato. Nella homepage del sito puoi accedere alla sezione "Recensioni dei Clienti" in cui puoi consultare tutte le recensioni inserite in ordine cronologico.<br /><br />
            <b> - Posso rilasciare una Recensione?</b><br />
            Certamente! Ogni volta che acquisti un nostro prodotto potrai rilasciare una recensione da questa sezione del sito.<br /><br />
            <b> - Quante Recensioni posso lasciare?</b><br />
            Ogni mese puoi rilasciare una recensione per ogni prodotto che acquisti. Se ad esempio nel mese precedente hai acquistato tre volte dei biglietti da visita potrai rilasciare una sola recensione per quel prodotto specifico. <br /><br />
            <b> - Come funzionano le Recensioni?</b><br />
            Per ogni recensione che inserisci potrai esprimere un voto che va da <b>1</b> a <b>5</b> stelle secondo questa scala di valori:
                <br />
                <br />
                <img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"> <b>Eccellente</b><br />
                <img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"> <b>Buono</b><br />
                <img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"> <b>Discreto</b><br />
                <img src="/img/icoStarFull.png" width="20"><img src="/img/icoStarFull.png" width="20"> <b>Sufficiente</b><br />
                <img src="/img/icoStarFull.png" width="20"> <b>Insufficiente</b><br /><br />

            Se vorrai potrai inoltre inserire una breve descrizione nelle sezioni <span class="reviewPro">Pro</span> e <span class="reviewContro">Contro</span> per completare la tua recensione.<br /><br />

            <b> - Ho inserito una recensione ma ancora non la vedo nel dettaglio del prodotto. Come mai?</b><br />
            L' opinione dei nostri clienti è importante per noi! Ogni recensione viene analizzata, controllata e poi pubblicata. <br /><br />
            <b> - Pubblicate anche le recensioni negative?</b><br />
            Tutte le recensioni saranno pubblicate.<br /><br />
            <%If FormerLib.FormerConst.Coupon.ImportoCouponScontoPerRecensione Then%>
            <b> - Quando ricevo i Coupon di Sconto per una mia Recensione?</b><br />
            Per la tua prima recensione di OGNI prodotto riceverai un Coupon di sconto di <b><%=FormerLib.FormerHelper.Stringhe.FormattaPrezzo(FormerLib.FormerConst.Coupon.ImportoCouponScontoPerRecensione)%> €</b>. Il Coupon ti verrà recapitato tramite email <b>DOPO CHE LA RECENSIONE SARA' STATA APPROVATA E PUBBLICATA</b> e lo troverai nella sezione <b>I tuoi Coupon di Sconto</b><br /><br />
            <%End If%>
                <b>ATTENZIONE</b>    <br />
                Nell'inserimento delle recensioni ricorda queste semplici regole:
                <ul>
                    <li>Puoi rilasciare una recensione su un prodotto solo dopo che è stato ritirato o spedito;</li>
                    <li>Riceverai <b>Coupon di Sconto</b> solo una volta per ogni prodotto recensito;</li>
                </ul>
            
            </div>
        </div>
        </div>
    </div>


</asp:Content>
