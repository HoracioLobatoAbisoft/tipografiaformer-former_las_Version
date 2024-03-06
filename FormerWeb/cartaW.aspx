<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="cartaW.aspx.vb" Inherits="FormerWeb.pCartaW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
    <meta property="og:image" content="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="descrPrev" style="display:none;">
    <div class="bloccoWSmall hasTooltip"><a href="/"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" /></a></div>
    <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" class="imgSx" />
        <h4><%=P.Descrizione%></h4>
        <%=P.DescrizioneEstesa%>
    </div>
    <div class="bloccoWSmall hasTooltip"><a href="/<%=P.IdPrev%>/<%=P.NomeInUrl%>"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=F.ImgRif%>" /></a></div>
    <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=F.ImgRif%>" class="imgSx" />
        <h4><%=F.Formato & " " & F.FormatoCartaStr & " " & F.OrientamentoStr%></h4>
        <%=F.DimensioniCartaStr%>
    </div>
  <div class="bloccoWSmall hasTooltip"><img src="/img/noTipoCarta.png" /></div>
    <div class="hidden tooltiptext"><img src="/img/noTipoCarta.png"  class="imgSx" />
        <h4>Nessun Tipo di Carta scelto</h4><br />
       Non è stato ancora selezionato un tipo di carta per il prodotto
    </div>
    <div class="bloccoWSmall hasTooltip"><img src="/img/noColoreStampa.png" /></div>
    <div class="hidden tooltiptext"><img src="/img/noColoreStampa.png"  class="imgSx" />
        <h4>Nessun Colore di stampa scelto</h4><br />
        Non è stato ancora selezionato un colore di stampa per il prodotto
    </div>
    <div class="riassuntoW">
        <b><i>Riepilogo</i></b><br />
        Prodotto: <b>-</b><br />
        Formato: <b>-</b><br />
        Tipo di carta: <b>-</b><br />
        Colori di stampa: <b>-</b><br />
    </div>
</div>
    <h1 class="titoloWizard"><%=P.Descrizione  %></h1>
    <h2 class="sottotitoloWizard"><%=P.DescrizioneEstesa%></h2>
<p class="effettuaScelta">Scegli un <%=IIf(P.IdReparto = FormerLib.FormerEnum.enRepartoWeb.Ricamo, "PRODOTTO", "TIPO DI CARTA")%> tra quelli disponibili.</p>    
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
<div class="icoConsigliato">
<b class="FormerChoice">FORMER CHOICE</b> Il simbolo <img src="/img/icoConsigliatoEx.png" border="0"/> ti indica la scelta ottimale per questo prodotto.
</div>
</asp:Content>
