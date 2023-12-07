<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="ris.aspx.vb" Inherits="FormerWeb.risAssistenza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="titolo">
    <asp:Panel ID="pnlOk" runat="server" Visible="false">
    <h1>Richiesta di assistenza registrata correttamente!</h1><br />
    Gentile cliente la informiamo che la sua richiesta di assistenza è stata registrata correttamente.<br /><br />
    Sarà nostra cura ricontattarla quanto prima tramite l'email che ci ha indicato per darle tutte le informazioni di cui ha bisogno.<br /><br />
    Cordiali saluti,<br /><b>Lo staff Tipografia Former</b><br /><br /><br />
    </asp:Panel>
    <asp:Panel ID="pnlErr" runat="server" Visible="false">
    <h1>ATTENZIONE! La richiesta di assistenza non è stata registrata!</h1><br />
    Gentile cliente durante la registrazione della richiesta di assistenza si è verificato un errore.<br /><br />
    Questo potrebbe dipendere da un problema momentaneo o dalle dimensioni eccessive degli allegati se sono stati inseriti.<br /><br />
    La invitiamo a riprovare in seguito.<br /><br />
    Cordiali saluti,<br /><b>Lo staff Tipografia Former</b><br /><br /><br />
    </asp:Panel>
    <asp:Panel ID="pnlCap" runat="server" Visible="false">
    <h1>ATTENZIONE! La richiesta di assistenza non è stata registrata!</h1><br />
    Gentile cliente durante la registrazione ha inserito un codice controllo errato.<br /><br />
    La invitiamo a tornare indietro e riprovare.<br /><br />
    Cordiali saluti,<br /><b>Lo staff Tipografia Former</b><br /><br /><br />
    </asp:Panel>
    </div>
</asp:Content>
