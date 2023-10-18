<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.master" CodeBehind="fogliW.aspx.vb" Inherits="FormerWeb.pfogliW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <div class="bloccoWSmall hasTooltip"><a href="/<%=P.IdPrev%>/<%=F.IdFormProd%>/<%=P.NomeInUrl%>_<%=F.NomeInUrl%>"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=TC.ImgRif%>"/></a></div>
    <div class="hidden">
        <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=TC.ImgRif%>" class="imgSx" />
         <h4><%=TC.Finitura & " " & TC.Grammi%></h4>
        <%=TC.Tipologia%>
      </div>
    <div class="bloccoWSmall hasTooltip"><a href="/<%=P.IdPrev%>/<%=F.IdFormProd%>/<%=TC.IdTipoCarta%>/<%=P.NomeInUrl%>_<%=F.NomeInUrl%>_<%=TC.NomeInUrl%>"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=C.imgrif%>"/></a></div>
     <div class="hidden">
        <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=C.imgrif%>" class="imgSx" />
         <h4><%=C.Descrizione%></h4>
        <%=C.Descrizione%>
      </div>
    <div class="riassuntoW">
        <b><i>Riepilogo</i></b><br />
        Prodotto: <b>-</b><br />
        Formato: <b>-</b><br />
        Tipo di carta: <b>-</b><br />
        Colori di stampa: <b>-</b><br />
    </div>
</div>
    <p class="titoloWizard"><%=P.Descrizione  %></p>
    <p class="sottotitoloWizard"><%=P.DescrizioneEstesa%></p>
<p class="effettuaScelta">Scegli il numero di <%=L.GetLabelFogli.ToUpper()%> tra quelli/e disponibili</p>    
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
</asp:Content>
