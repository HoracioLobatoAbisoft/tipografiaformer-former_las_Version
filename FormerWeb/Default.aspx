<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="default.aspx.vb" Inherits="FormerWeb.pHomePage" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Reparti" Src="~/userControl/ucReparti.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta property="og:title" content="<%=FormerWeb.FormerWebApp.MetaTitle%>" />
    <meta property="og:description" content="<%=FormerWeb.FormerWebApp.MetaDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it" />
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<FormerWeb:Reparti id="Reparti" runat="server"/>
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
</asp:Content>

<asp:Content ID="contentSecondaFascia" runat="server" ContentPlaceHolderID="secondaFascia">

    <div class="secondaFascia"> 
        <div style="width:950px;margin:0px auto 0px auto;">
            <div class="bannerRecensioni">
                <a href="/recensioni"><h2><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /> LE RECENSIONI DEI CLIENTI</h2>
                Scopri il parere di chi ha provato i nostri prodotti</a>
            </div>
        </div>
        <div style="float:left;padding-left:40px;margin-bottom:40px;">
        <div class="secondaFasciaBlock">
            <h1>La tipografia Former</h1>
            <img src="/img/logosmall.png" /> Dal 1996 la <b>Tipografia Former</b> opera a Roma nel settore della stampa tipografica industriale.<br /> Oggi, come protagonisti nel mercato della stampa, siamo in grado di produrre in proprio prodotti di qualità grazie a macchinari di prestampa, stampa offset e finitura dalla tecnologia all' avanguardia. <br /><br />

Stampa Offset, anzitutto, ma anche Stampa Digitale, Etichette, Packaging e Ricamo.<br /><br />
            <a style="color:#f58220;font-weight:bold;" href="/la-nostra-azienda">Scopri la nostra azienda...</a>
        </div>
        <div class="secondaFasciaBlock">
            <h1>Diventa rivenditore</h1>
            <img src="/img/icoRivenditore.png"/>Sei un operatore del settore arti grafiche? Hai uno studio pubblicitario?<br /> Una tipografia?<br /><br />
Scegli un partner affidabile! Registra ora la tua azienda come Rivenditore e avrai accesso riservato al listino prezzi riservato a operatori del settore.<br /><br />
            <a style="color:#f58220;font-weight:bold;" href="/registrati">Registrati...</a>
        </div>
        <div class="secondaFasciaBlock">
            <h1>Verifica file</h1>
            <img src="/img/icoVerificaFile.png" /> Verifica file automatica su tutti i file PDF allegati ai lavori. Per ogni ordine che effettuerai verranno verificati automaticamente i file PDF per ottenere il migliore risultato possibile. <br />
            <br />
            Saranno controllati:
            <ul>
                <li>presenza dei font incorporati;</li>
                <li>dimensioni del pdf e dei margini di taglio;</li>
                <li>Orientamento;</li>
            </ul>
        </div>
        </div>

    <div style="float:left;padding-left:100px;vertical-align:top;">

        <div class="secondaFasciaIco"><a href="/i-tuoi-coupon-di-sconto">
            <img src="/img/icoCoupon.png"  />
            <h3>Coupon di Sconto</h3>
            Risparmia e accumula sconti</a>
        </div>
        
        <div class="secondaFasciaIco"><a href="/diventa-rivenditore">
            <img src="/img/icoRivenditore.png" />
            <h3>Listino Rivenditori</h3>
            Listino per operatori del settore</a>
        </div>

        <div class="secondaFasciaIco"><a href="/suggerimenti-per-inviarci-i-file">
            <img src="/img/icoVerificaFile.png" />
            <h3>Verifica File</h3>
            Verifica file automatica gratuita</a>
        </div>
        
        <div class="secondaFasciaIco"><a href="/assistenza-clienti">
            <img src="/img/icoAssistenzatelefonica.png" />
            <h3>Assistenza Professionale</h3>
            Telefonica e tramite chat</a>
        </div>
    </div>
       
    </div>
</asp:Content>
