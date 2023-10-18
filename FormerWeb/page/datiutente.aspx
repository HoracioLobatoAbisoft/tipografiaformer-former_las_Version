<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="datiutente.aspx.vb" Inherits="FormerWeb.pDatiUtente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange"><img src="/img/icoUt50.png" />IL TUO PROFILO</h3>
    <div class="arearis line25"> 
         <table>
            <tr>
                <td>La tua ID di accesso: </td>
                <td><asp:Label ID="lblIdCli" runat="server" Text="-" Font-Size="14" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>La tua Email di accesso:</td>
                <td><asp:Label ID="lblEmail" runat="server" Text="-" Font-Size="14" Font-Bold="true" ></asp:Label></td>
            </tr>
         </table>   
        <br />
    <h3 class="gray"><img src="/img/icoDatiUt30.png" /> I TUOI DATI FISCALI</h3>
        <table width="90%">
            <tr>
                <td>Ragione Sociale:</td>
                <td><asp:Label ID="lblRagSoc" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Nominativo:</td>
                <td><asp:Label ID="lblNominativo" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>P.IVA:</td>
                <td><asp:Label ID="lblPiva" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Codice Fiscale:</td>
                <td><asp:Label ID="lblCodFisc" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>PEC:</td>
                <td><asp:Label ID="lblPec" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Codice SDI:</td>
                <td><asp:Label ID="lblSDI" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Indirizzo:</td>
                <td><asp:Label ID="lblInd" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Recapiti:</td>
                <td><asp:Label ID="lblRecap" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr><td colspan="2" style="text-align:right;"><a href="/aggiorna-dati-fiscali" class="pulsante120Orange"><img src="/img/icoEditW.png" /> Modifica</a></td></tr>
        </table>
       <br />
    <h3 class="gray"><img src="/img/icoPwd30.png" /> MODIFICA PASSWORD <asp:Label ID="lblEsitoPwd" Visible="false"  CssClass="esitoPwd" runat="server" Text=""></asp:Label></h3>
        Immetti la nuova password <asp:TextBox ID="txtPwd" width="120" TextMode="Password" MaxLength="20" runat="server"></asp:TextBox> e riscrivi la nuova Password <asp:TextBox ID="txtPwdRip" TextMode="Password" MaxLength="20" runat="server" Width="120"></asp:TextBox> 
        <asp:linkbutton id="lnkModPwd" runat="server" cssclass="pulsante120Orange" ><img src="/img/icoEditW.png" /> Modifica</asp:linkbutton><br />
        <i><B>ATTENZIONE</B> Le password devono essere di almeno 8 caratteri e devono contenere almeno un numero</i>  
    <br /><br />
    <h3 class="gray"><img src="/img/icoMail30.png"/> NEWSLETTER E OFFERTE</h3>

        <%If UtenteConnesso.Utente.NoMail = FormerLib.FormerEnum.enSiNo.Si Then %>
            Hai scelto di non ricevere comunicazioni tramite email da parte nostra. Se vuoi ricevere di nuovo Newsletter e Offerte scrivici all'indirizzo info@tipografiaformer.it
        <%else %>
            Se non vuoi più ricevere la nostra Newsletter e le nostre Offerte <a href="unsubscribe/<%=FormerLib.FormerHelper.Security.CriptaURL(UtenteConnesso.Utente.Email)%>">clicca qui</a>
        <%End if %>
        <br />
        <a href="https://www.tipografiaformer.it/privacy" target="_blank" >Cliccando qui</a> puoi leggere la nostra informativa sulla privacy
    <br /><br />
        <center><asp:linkbutton id="lnkShutdown" runat="server" cssclass="pulsante120Green" ><img src="/img/icoShutdown.png" /> Esci</asp:linkbutton></center>

        </div>  
</asp:Content>
