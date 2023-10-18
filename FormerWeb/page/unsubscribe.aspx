<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="unsubscribe.aspx.vb" Inherits="FormerWeb.pUnsubscribe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta name="robots" content="noindex,nofollow">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="titolo">
        <center><h2>Non vuoi più ricevere email da noi?</h2></center><br />
        Se non sei più interessato a ricevere email al tuo indirizzo di posta elettronica clicca sul pulsante qui sotto<br /><br /><center><h3><%=emailRif%></h3></center><br /><br />
        <center>
        <asp:ImageButton ID="btnCancellati" runat="server" CssClass="button" ImageUrl="~/img/btnCancellati.png"/>
    </center>
    </div>

</asp:Content>
