<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="search.aspx.vb" Inherits="FormerWeb.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="ricercaAvanzata">

        <h3>Ricerca Avanzata</h3>

        <asp:TextBox ID="txtCerca" runat="server"></asp:TextBox><br />

        <asp:ImageButton id="btnCerca" runat="server" ImageUrl="/img/btnCerca.png" CssClass="button" />

    </div>
    
</asp:Content>
