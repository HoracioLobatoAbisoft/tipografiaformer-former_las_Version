<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="datiutente.aspx.vb" Inherits="FormerWeb.pDatiUtente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="containerProfilo">
        <h2>IL TUO PROFILO</h2>
        <div class="containerData">
            <div class="containerDatiAccesso">
                <div class="containerIcono">
                    <i class="fa-solid fa-circle-user"></i>
                    <h3> I TUOI DATI DI ACCESSO</h3>
                    <asp:linkbutton id="lnkShutdown" runat="server" CssClass="btnEsci"><i class="fa-solid fa-right-from-bracket" style="font-size:1em;"></i> Esci</asp:linkbutton>
                </div>
                <div class="containerDati" >
                    <h5> La tua ID di accesso: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-id-card-clip"></i> <asp:Label ID="lblIdCli" runat="server" Text="-" ></asp:Label> </p>
                    <h5> La tua Email di accesso: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-envelope-open-text"></i><asp:Label ID="lblEmail" runat="server" Text="-" ></asp:Label></p>
                </div>
            </div>
            <div class="containerDatiAccesso">
                <div class="containerIcono">
                    <h3>  I TUOI DATI FISCALI</h3>
                    <i class="fa-solid fa-address-card"></i>
                </div>
                <div class="containerDati">
                    <h5> Ragione Sociale: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-file-signature"></i><asp:Label ID="lblRagSoc" runat="server" Text="-" ></asp:Label></p>
                    <h5> Nominativo: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-address-card"></i>	<asp:Label ID="lblNominativo" runat="server"></asp:Label></p>
                    <h5>P.IVA: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-location-arrow"></i>	<asp:Label ID="lblPiva" runat="server" Text="-" ></asp:Label></p>
                    <h5> Codice Fiscale: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-address-card"></i><asp:Label ID="lblCodFisc" runat="server" Text="-" ></asp:Label></p>
                    <h5> PEC: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-paper-plane"></i><asp:Label ID="lblPec" runat="server" Text="-"></asp:Label></p>
                    <h5> Codice SDI: </h5>
                    <p class="spanDati"><i class="fa-solid fa-address-card"></i><asp:Label ID="lblSDI" runat="server" Text="-"></asp:Label></p>
                    <h5> Indirizzo: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-location-dot"></i><asp:Label ID="lblInd" runat="server" Text="-"></asp:Label></p>
                    <h5> Recapiti: </h5>
                    <p class="spanDati"> <i class="fa-solid fa-address-book"></i>	<asp:Label ID="lblRecap" runat="server" Text="-"></asp:Label></p>
                </div>
                <a href="/aggiorna-dati-fiscali" class="btnModifica"><i class="fa-solid fa-pen-to-square"></i>Modifica</a>
            </div>
            <div class="containerDatiAccesso" style="gap:2px">
                <div class="containerIcono">
                    <h3>  MODIFICA PASSWORD </h3>
                    <i class="fa-solid fa-key"></i>
                </div>
                <div class="containerDati">
                    <h5> Immetti la nuova password  </h5>
                    <p class="spanDati spanInput"> <i class="fa-solid fa-lock"></i><asp:TextBox ID="txtPwd" CssClass="inputText" TextMode="Password"  MaxLength="20" runat="server" Placeholder="esempio : 64$%164#as"></asp:TextBox></p>
                    <h5> e riscrivi la nuova Password </h5>
                    <p class="spanDati spanInput"> <i class="fa-solid fa-lock"></i><asp:TextBox ID="txtPwdRip" TextMode="Password" MaxLength="20" runat="server"  Placeholder="riscrivi la password" CssClass="inputText"></asp:TextBox></p>
                </div>
                <asp:linkbutton id="lnkModPwd" runat="server"  CssClass="btnModifica"><i class="fa-solid fa-pen-to-square"></i> Modifica</asp:linkbutton>
                <asp:Label ID="lblEsitoPwd" Visible="false"  CssClass="esitoPwd" runat="server" Text=""></asp:Label>
            </div>
            <div class="containerDatiAccesso">
                <div class="containerIcono">
                    <h3>  NEWSLETTER E OFFERTE</h3>
                    <i class="fa-solid fa-envelope"></i>
                </div>
                <div class="containerDati">
                    <p class="textP">Se non vuoi più ricevere la nostra Newsletter e le nostre Offerte <a href="unsubscribe/<%=FormerLib.FormerHelper.Security.CriptaURL(UtenteConnesso.Utente.Email)%>" class="spanLink">clicca qui</a> </p>
                    <p class="textP"><a href="/privacy" target="_blank" class="spanLink">Cliccando qui </a> puoi leggere la nostra informativa sulla privacy</p>
                </div>
            </div>
        </div>
    </div>
    <%--<h3 class="orange"><img src="/img/icoUt50.png" />IL TUO PROFILO</h3>
    <div class="arearis line25"> 
         <table>
            <tr>
                <td>La tua ID di accesso: </td>
                <td><asp:Label ID="Label1" runat="server" Text="-" Font-Size="14" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>La tua Email di accesso:</td>
                <td><asp:Label ID="Label2" runat="server" Text="-" Font-Size="14" Font-Bold="true" ></asp:Label></td>
            </tr>
         </table>   
        <br />
    <h3 class="gray"><img src="/img/icoDatiUt30.png" /> I TUOI DATI FISCALI</h3>
        <table width="90%">
            <tr>
                <td>Ragione Sociale:</td>
                <td><asp:Label ID="Label3" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Nominativo:</td>
                <td><asp:Label ID="Label4" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>P.IVA:</td>
                <td><asp:Label ID="Label5" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Codice Fiscale:</td>
                <td><asp:Label ID="Label6" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>PEC:</td>
                <td><asp:Label ID="Label7" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Codice SDI:</td>
                <td><asp:Label ID="Label8" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Indirizzo:</td>
                <td><asp:Label ID="Label9" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr>
                <td>Recapiti:</td>
                <td><asp:Label ID="Label10" runat="server" Text="-" Font-Size="11" Font-Bold="true" ></asp:Label></td>
            </tr>
            <tr><td colspan="2" style="text-align:right;"><a href="/aggiorna-dati-fiscali" class="pulsante120Orange"><img src="/img/icoEditW.png" /> Modifica</a></td></tr>
        </table>
       <br />
    <h3 class="gray"><img src="/img/icoPwd30.png" /> MODIFICA PASSWORD <asp:Label ID="lblEsitoPwd" Visible="false"  CssClass="esitoPwd" runat="server" Text=""></asp:Label></h3>
        Immetti la nuova password <asp:TextBox ID="TextBox1" width="120" TextMode="Password" MaxLength="20" runat="server"></asp:TextBox> e riscrivi la nuova Password <asp:TextBox ID="TextBox2" TextMode="Password" MaxLength="20" runat="server" Width="120"></asp:TextBox> 
        <asp:linkbutton id="Linkbutton1" runat="server" cssclass="pulsante120Orange" ><img src="/img/icoEditW.png" /> Modifica</asp:linkbutton><br />
        <i><B>ATTENZIONE</B> Le password devono essere di almeno 8 caratteri e devono contenere almeno un numero</i>  
    <br /><br />
    <h3 class="gray"><img src="/img/icoMail30.png"/> NEWSLETTER E OFFERTE</h3>

        <%If UtenteConnesso.Utente.NoMail = FormerLib.FormerEnum.enSiNo.Si Then %>
            Hai scelto di non ricevere comunicazioni tramite email da parte nostra. Se vuoi ricevere di nuovo Newsletter e Offerte scrivici all'indirizzo info@tipografiaformer.it
        <%else %>
            Se non vuoi più ricevere la nostra Newsletter e le nostre Offerte <a href="unsubscribe/<%=FormerLib.FormerHelper.Security.CriptaURL(UtenteConnesso.Utente.Email)%>">clicca qui</a>
        <%End If %>
        <br />
        <a href="https://www.tipografiaformer.it/privacy" target="_blank" >Cliccando qui</a> puoi leggere la nostra informativa sulla privacy
    <br /><br />
        <center><asp:linkbutton id="Linkbutton2" runat="server" cssclass="pulsante120Green" ><img src="/img/icoShutdown.png" /> Esci</asp:linkbutton></center>

        </div>--%>
</asp:Content>
