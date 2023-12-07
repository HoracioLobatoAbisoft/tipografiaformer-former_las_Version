<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="selCatVirtuale.aspx.vb" Inherits="FormerWeb.selCatVirtuale" %>
<%@ Register  TagPrefix="FormerWeb" TagName="PrevPromo" Src="~/userControl/ucPrevPromo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
<p class="titoloWizard"><%=C.Nome%></p>
<p class="effettuaScelta">Scegli un PRODOTTO</p>    
<asp:Table ID="tableWizard" class="tableWizard" runat="server"></asp:Table>
<FormerWeb:PrevPromo runat="server" Id="PrevPromo" visible="false"/>

</asp:Content>