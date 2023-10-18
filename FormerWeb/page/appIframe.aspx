<%--<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="appIframe.aspx.vb" Inherits="FormerWeb.appIframe" %>--%>
<%--<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.master" CodeBehind="appIframe.aspx.vb" Inherits="FormerWeb.appIframe" %>--%>
<%--if you need a frame whith is equal box father --%>
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="appIframe.aspx.vb" Inherits="FormerWeb.appIframe" %>
<%--<%@ Register  TagPrefix="FormerWeb" TagName="RisultatoRicerca" Src="~/userControl/ucRisultatoRicerca.ascx" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<asp:ContentPlaceHolder id="head" runat="server"></asp:ContentPlaceHolder>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Iframe" runat="server">
     <div class="depliant" style="height:1000px">  
         <asp:Panel ID="pnlAppIframe" runat="server" visible="true" Height="100%">
            <asp:Literal runat="server" ID="iframeApp" />   
            <%--<center><h3>Applicazione in React </h3></center>
         <%--<a href="https://localhost:44311/" style="color:chocolate; font-weight:800;font-family:Arial">INIZIO</a>--%>
        </asp:Panel>
        <%--<asp:ContentPlaceHolder id="body" runat="server"></asp:ContentPlaceHolder>--%>
    </div>
</asp:Content>
