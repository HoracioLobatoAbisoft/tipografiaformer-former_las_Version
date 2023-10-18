<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/listini.reserved.Master" CodeBehind="parametri.aspx.vb" Inherits="FormerListiniWeb.parametri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="singPage" style="text-align:justify;">

     <div class="TitoloSez">IMPOSTA PARAMETRI</div>

        In questa sezione potrai inserire i parametri con i quali verrà generato il tuo listino personalizzato.<br /><br /><br />

        <div class="container">
        <h5>PERCENTUALE DI RICARICO</h5>


        Percentuale di ricarico: <asp:TextBox ID="txtPerc" runat="server" MaxLength="3" Width="50" style="text-align:right;"></asp:TextBox> (<%=PercentualeMinimaRicarico%>% - 999%)<br /><br />

        <asp:Linkbutton ID="btnSalva" CssClass="pulsante120Blu" runat="server"><img src="/img/icoparam.png" /> Salva</asp:Linkbutton>

        </div>
        <br />
        <b>Come funziona?</b><br />
        In questa versione BETA la percentuale di ricarico viene applicata sul PREZZO CONSIGLIATO AL PUBBLICO che è adeguato al corretto prezzo di mercato per un determinato prodotto in una determinata quantità. <br />
        <br />
        Puoi visualizzare il prezzo consigliato al pubblico in ogni scheda prodotto sul sito tipografiaformer.it (vedi immagine sotto)<br />
        <center><img src="/img/help.jpg" style="width:450px;border:3px solid #009ec9;border-radius:5px;" /></center><br />
        Impostando la percentuale di ricarico a <b>0%</b>, il listino sarà generato utilizzando per ogni prodotto il prezzo consigliato al pubblico. 

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
