<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mobile/master/main.m.Master" CodeBehind="login.m.aspx.vb" Inherits="FormerWeb.login_m" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><br />
    <h3>Accedi alla tua area riservata</h3>
    <div class="Login"><div class="label">ID di Accesso/Email </div><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rqLogin" CssClass="loginErr" ControlToValidate="txtLogin" runat="server" ValidationGroup="group1" ErrorMessage="Il nome utente è obbligatorio"></asp:RequiredFieldValidator></div>
    <div class="Pwd"><div class="label">Password </div><asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="loginErr" ControlToValidate="txtpwd" runat="server" ValidationGroup="group1" ErrorMessage="La password è obbligatoria"></asp:RequiredFieldValidator></div>
    <div><asp:CheckBox runat="server" ID="chkRestaConnesso" Text="Resta connesso" Checked="true"/><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Deseleziona questa casella se utilizzi un computer condiviso)</div>
    <div class="buttonLogin" style="margin-top:20px;"><center><asp:button ID="btnLoginImg" text="Accedi" runat="server" ValidationGroup="group1" ></asp:button></center></div>
    <br /><center><asp:Label id="lblEsito" runat="server" text="" visible="false" CssClass="esitoPwd"></asp:Label></center>
</asp:Content>
