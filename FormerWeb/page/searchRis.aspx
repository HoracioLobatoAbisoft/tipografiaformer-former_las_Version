<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="searchRis.aspx.vb" Inherits="FormerWeb.searchRis" %>
<%@ Register  TagPrefix="FormerWeb" TagName="RisultatoRicerca" Src="~/userControl/ucRisultatoRicerca.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/scripts/find5/find5.js"></script>
    <style>
        .highlight
        {
	        background-color: blue;
        }
        .find_selected
        {
	        background-color: green;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%If RowCount Then%>
    <script type="text/javascript" >
        $(document).ready(function () {
            finditExt('<%=GetHtmlKeywords%>');
        });
    </script>
    <%End If%>

    <div class="staiCercando">Stai cercando <b><%=GetHtmlKeywords %></b> (<asp:Label id="lblRisCount" runat="server" Font-Size="Small" ></asp:Label>)</div>
    <asp:Panel ID="pnlForse" Visible="false" runat="server">
        <div class="forseCercavi">Forse cercavi </div>
    </asp:Panel>
    <div id="risRicerca">
    <asp:Repeater ID="rptRis" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <FormerWeb:RisultatoRicerca runat="server" Id="RisultatoRicerca" />
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
    </div>
    <asp:Panel id="pnlPagine" runat="server" Visible="false">
        <div class="pager">Vai alla pagina <asp:PlaceHolder ID="plcPaging" runat="server" /> </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoRis" runat="server" visible="false">

        <center><h3>La ricerca non ha prodotto nessun risultato</h3></center>

    </asp:Panel>
    
</asp:Content>
