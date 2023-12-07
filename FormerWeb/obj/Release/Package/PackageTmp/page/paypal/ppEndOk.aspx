<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="ppEndOk.aspx.vb" Inherits="FormerWeb.ppEndOk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div class="titolo">
        <%If UtenteConnesso.UtenteAutorizato Then %>
            <asp:Literal  ID="IFramePayPalOk" runat="server"/>
        <%Else %>
            <center><h2>Pagamento effettuato correttamente!</h2></center><br />
        Il tuo pagamento è stato effettuato in maniera corretta! <br /><br />A breve riceverai tramite email una conferma del pagamento da PayPal.<br /><br />
    Grazie,<br /><b>Lo staff Tipografia Former</b><br /><br />
        <%End If %>
    </div>



</asp:Content>
