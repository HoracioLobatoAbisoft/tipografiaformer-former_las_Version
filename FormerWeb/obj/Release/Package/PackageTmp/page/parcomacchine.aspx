<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.master" CodeBehind="parcomacchine.aspx.vb" Inherits="FormerWeb.ParcoMacchine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   <div class="depliant">
    <img src="/img/parcomacchine/titoloParcoMacchine.png" /><br /><br />

       Disponiamo di un parco macchine all'avanguardia che viene continuamente arricchito e aggiornato con le migliori e più innovative soluzioni proposte dal mercato.<br /><br />
    <asp:Table ID="tableMacchinari" class="tableWizard" runat="server"></asp:Table>

    </div>

</asp:Content>
