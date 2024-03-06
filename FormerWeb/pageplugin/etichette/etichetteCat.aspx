<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="etichetteCat.aspx.vb" Inherits="FormerWeb.pEtichetteCat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="descrPrev">
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
    <h1 class="titoloWizard"><%=P.Descrizione  %></h1>
    <h2 class="sottotitoloWizard"><%=P.DescrizioneEstesa%></h2>
<p class="effettuaScelta">Scegli un TIPO DI ETICHETTA tra quelle disponibili</p> 
    <asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
</asp:Content>
