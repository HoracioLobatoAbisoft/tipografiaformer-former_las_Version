<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/main.master" CodeBehind="registrati.aspx.vb" Inherits="FormerEventi.registrati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="registrati">
<div class="festeggia">Festeggia con noi i nostri 20 anni di attività</div>
Compila il modulo sottostante e lascia un biglietto da visita, riceverai un <b>Buono sconto del 30%</b> sul tuo prossimo acquisto.<br />
    <br />

    <asp:UpdatePanel ID="updForm" runat="server">
        <ContentTemplate>
    <b>Ragione Sociale (*)</b><br />
    <asp:TextBox ID="txtRagSoc" runat="server"></asp:TextBox>
    <br />
    <b>Nome e Cognome</b><br />
    <asp:TextBox ID="txtNominativo" runat="server"></asp:TextBox>
    <br />
    <b>Email (*)</b><br />
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <b>Cellulare</b><br />
    <asp:TextBox ID="txtCellulare" runat="server"></asp:TextBox>
    <br />
    <div class="asterisco">* campo obbligatorio</div><br />

    <asp:Panel ID="pnlErrore" Visible="false" runat="server">
        <div class="errorMessagePopup">
            <img src="/img/icoWarning32.png" />ATTENZIONE<br />
            <asp:Label ID="lblErrore" runat="server" Text="-"></asp:Label>
                    
        </div>
    </asp:Panel>

    <center><asp:Button ID="btnRegistra" runat="server" Text="RICHIEDI BUONO" /></center><br />
        </ContentTemplate>
    </asp:UpdatePanel>


</div>


</asp:Content>
