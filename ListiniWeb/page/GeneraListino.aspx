<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/listini.reserved.Master" CodeBehind="GeneraListino.aspx.vb" Inherits="FormerListiniWeb.GeneraListino" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="singPage">

        <div class="TitoloSez">GENERA IL LISTINO AL PUBBLICO</div>

        <asp:Panel ID="pnlLastVersion" runat="server" Visible="false">
            <div class="alert">
                <b>ATTENZIONE</b><br />
                Il tuo listino non risulta aggiornato. Abbiamo modificato i prodotti disponibili quindi ti invitiamo a rigenerarlo per avere sempre l'ultima versione
            </div>
        </asp:Panel>
       
        <asp:Panel ID="pnlScarica" runat="server" Visible="false">
        <div class="container">

        
    <asp:Label ID="lblLastGen" runat="server" CssClass="lastGen"></asp:Label><br />
    <br />
            <asp:Linkbutton ID="lnkScarica" CssClass="pulsante150Blu" runat="server"><img src="/img/icoFileTypePDF.png" /> Scarica Listino</asp:Linkbutton>
    </div>
        </asp:Panel>
    
    Cliccando sul punsante Genera Listino, il tuo listino al pubblico verrà rigenerato in base ai parametri impostati nella sezione <b>Imposta Parametri</b><br /><br />
    <center><asp:Linkbutton ID="btnGenera" CssClass="pulsante150Blu" runat="server"><img src="/img/icoFileTypePDF.png" /> Genera Listino</asp:Linkbutton></center><br />
    Il listino sarà generato applicando una percentuale di <b>ricarico del <asp:label ID="lblPerc" runat="server"></asp:label>%</b>. Se vuoi cambiarla vai nella sezione <a href="/imposta-parametri"><b>Imposta Parametri</b></a>.
        
    <br /><br />
    <asp:Label ID="lblStato" runat="server" CssClass="lastGen"></asp:Label>
    
    <div class="attenzione">
            <b>ATTENZIONE</b><br />
            <ul>
                <li>In questa versione <b>BETA</b> la percentuale di ricarico viene applicata sul <b>PREZZO CONSIGLIATO AL PUBBLICO</b> che è adeguato al corretto prezzo di mercato per un determinato prodotto in una determinata quantità.</li>
                <li>In questa versione <b>BETA</b> al momento è possibile inserire una sola percentuale di ricarico per tutto il listino. A breve sarà attiva una nuova versione con cui potrai inserire una Percentuale di ricarico differente per ogni preventivazione.</li>
                <li>In questa versione <b>BETA</b> non è possibile impostare quantità diverse per i vari prodotti nel listino</li>
            </ul>
        </div>
<div class="pedice">
Se vuoi inviarci consigli o suggerimenti su questa versione <b>BETA</b> invia una mail a <a href="mailto:soft@tipografiaformer.it">soft@tipografiaformer.it</a>        
</div>


    </div>
</asp:Content>
