<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="selFormato.aspx.vb" Inherits="FormerWeb.selFormato" %>
<%@ Register  TagPrefix="FormerWeb" TagName="PrevPromo" Src="~/userControl/ucPrevPromo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
    <meta property="og:image" content="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
<p class="titoloWizard"><%=P.Descrizione  %></p>
<p class="sottotitoloWizard"><%=P.DescrizioneEstesa%></p>
<p class="effettuaScelta">Scegli un FORMATO di <%=C.Nome %></p>    
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
<div class="icoConsigliato">
<b class="FormerChoice">FORMER CHOICE</b> Il simbolo <img src="/img/icoConsigliatoEx.png" border="0"/> ti indica la scelta ottimale per questo prodotto.
</div>
<FormerWeb:PrevPromo runat="server" Id="PrevPromo" visible="false"/>

</asp:Content>