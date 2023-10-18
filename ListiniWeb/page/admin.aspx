<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/listini.reserved.Master" CodeBehind="admin.aspx.vb" Inherits="FormerListiniWeb.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <h4>LOG ULTIMI 5 GIORNI</h4>
    <asp:Table runat="server" ID="tableLog" Width="100%" Font-Size="Smaller" ></asp:Table><br />
    <br />
    Totale Rivenditori Entrati: <asp:Label ID="lblTotRiv" runat="server"></asp:Label><br />
    Totale Listini Generati: <asp:Label ID="lblTotList" runat="server"></asp:Label><br />

    <h4>UTENTI CONNESSI (ultimi 10 minuti)</h4>
    <asp:Label ID="lblTitolo" runat="server" Text="-"></asp:Label> <asp:Label ID="lblTotUtentiGiornata" Visible="false" runat="server" Text="(0 unici in totale)"></asp:Label><br /><br />
    <asp:Button ID="btnAggiornaUtenti" runat="server" Text="Aggiorna lista utenti" />
   
    <asp:Table runat="server" ID="tableAdmin">
    </asp:Table>


</asp:Content>
