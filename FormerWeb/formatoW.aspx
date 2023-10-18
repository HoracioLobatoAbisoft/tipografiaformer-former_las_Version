<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="formatoW.aspx.vb" Inherits="FormerWeb.pFormatoW" %>
<%@ Register  TagPrefix="FormerWeb" TagName="PrevPromo" Src="~/userControl/ucPrevPromo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
    <meta property="og:image" content="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<%--<div class="introProdottoSmall">
    <img src="<%=FormerWeb.FormerWebApp.PathImgListino%><%=P.ImgSito%>" class="imgGraficaSmall"/>
</div>--%>
   
<div class="descrPrev" style="display:none;">
    <div class="bloccoWSmall hasTooltip"><a href="/"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" /></a></div>
    <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" class="imgSx" />
        <h4><%=P.Descrizione%></h4>
        <%=P.DescrizioneEstesa%>
    </div>
    <div class="bloccoWSmall hasTooltip"><img src="/img/noformato.png" /></div>
    <div class="hidden tooltiptext"><img src="/img/noformato.png"  class="imgSx" />
        <h4>Nessun Formato scelto</h4>
        Non è stato ancora selezionato un formato per il prodotto
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
</div>
<p class="titoloWizard"><%=P.Descrizione  %></p>
<p class="sottotitoloWizard"><%=P.DescrizioneEstesa%></p>
<p class="effettuaScelta">Scegli un FORMATO tra quelli disponibili</p>    
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
<div class="icoConsigliato">
<b class="FormerChoice">FORMER CHOICE</b> Il simbolo <img src="/img/icoConsigliatoEx.png" border="0"/> ti indica la scelta ottimale per questo prodotto.
</div>
<FormerWeb:PrevPromo runat="server" Id="PrevPromo" visible="false"/>
</asp:Content>
