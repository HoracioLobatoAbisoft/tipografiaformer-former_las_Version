<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/listini.Master" CodeBehind="login.aspx.vb" Inherits="FormerListiniWeb.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Panel id="pnlLogin" runat="server" DefaultButton="btnLoginImg">
    <div class="loginForm">   
        <h2 class="orange">Sei già registrato? Accedi</h2>
        <hr />
    <h3>Accedi alla tua area riservata</h3>
    <p>
        Immettere la tua ID di Accesso o la tua Email e la Password.
    </p>
        
    <div class="Login"><div class="label">ID di Accesso/Email </div><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rqLogin" CssClass="loginErr" ControlToValidate="txtLogin" runat="server" ValidationGroup="group1" ErrorMessage="Il nome utente è obbligatorio"></asp:RequiredFieldValidator></div>
    <div class="Pwd"><div class="label">Password </div><asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="loginErr" ControlToValidate="txtpwd" runat="server" ValidationGroup="group1" ErrorMessage="La password è obbligatoria"></asp:RequiredFieldValidator></div>
        <div><asp:CheckBox runat="server" ID="chkRestaConnesso" Text="Resta connesso" Checked="true"/><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Deseleziona questa casella se utilizzi un computer condiviso)</div>
    <div class="buttonLogin"><asp:Linkbutton ID="btnLoginImg" CssClass="pulsante120Orange" runat="server" ValidationGroup="group1" ><img src="/img/icoChiaveW.png" /> Accedi</asp:Linkbutton></div>
    </div>
    </asp:Panel>
     <div class="RegisterForm">   
        <h2 class="orange">Non sei ancora registrato?</h2>
        <hr />
    <h3>Registrati ora! E' veloce e facile.</h3>Potrai accedere a tutte le funzionalità riservate ai nostri utenti<br /><br />
    <div class="buttonLogin">
        <a href="/registrati" class="pulsante120Orange"><img src="/img/icoChiaveW.png" /> Registrati</a>
    </div>        <br />
        
         <h3>Sei un Rivenditore?</h3>Sei un operatore arti grafiche? Un creativo? Hai una tipografia? Scegli un partner affidabile<br />

         <center><a class="orange" href="/diventa-rivenditore" style="font-size:16px;font-weight:bold;">Listino Riservato</a></center>
    </div>
    <asp:Panel ID="pnlRigenera" runat="server" DefaultButton="btnRigenera">
    <div class="LostPwdForm">
        <h2 class="orange">Password dimenticata?</h2>
        <hr />
        <center>
        <table border="0">
            <tr>
                <td>
                    Inserisci qui l'email con cui sei registrato e te ne invieremo una nuova 
                </td>
                <td>
<asp:TextBox ID="txtNewPwd" runat="server"></asp:TextBox> 
                </td>
                <td>
<asp:LinkButton ID="btnRigenera" ValidationGroup="" CssClass="pulsante120Orange" runat="server"><img src="/img/icoChiaveW.png" /> Rigenera</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="lblEsitoPwd" CssClass="esitoPwd" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
         </center>
    </div>
    </asp:Panel>
</asp:Content>
