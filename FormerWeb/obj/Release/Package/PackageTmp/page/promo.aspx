<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="promo.aspx.vb" Inherits="FormerWeb.pPromo" %>
<%@ Register  TagPrefix="FormerWeb" TagName="RisultatoRicerca" Src="~/userControl/ucRisultatoRicerca.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="depliant">
       <img src="/img/titoloOfferte.png" height="60"/><br /><br />
                          In questa pagina trovi tutti i prodotti in <b class="labPromo">PROMO</b>. Approfittane e risparmia sull' acquisto dei nostri prodotti!<br /><br />

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

        <center><h3>Al momento non ci sono PROMO attivi</h3></center>

    </asp:Panel>
    </div>
</asp:Content>
