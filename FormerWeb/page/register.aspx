<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="register.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FormerWeb.register" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Contattaci" Src="~/userControl/ucContattaci.ascx" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
     <div class="Registrati">
       
         <div id="tabs">

                  <ul>
                    <li><a href="#tabs-1"><img src="/img/icoLock16.png" alt="Registrati" class="icoImg"/> Registrati</a></li>
                    <li><a href="#tabs-2"><img src="/img/icoMondo.png" alt="Un breve tour" class="icoImg"/> Perchè registrarsi? Un breve Tour</a></li>
                      <li><a href="#tabs-3"><img src="/img/icoAssistenza16.png" alt="Contattaci per ricevere assistenza" class="icoImg"/> Contattaci</a></li>
                  </ul>

             <div id="tabs-1">
                 <div class=" containerForm">
                    <asp:Panel id="Panel1" runat="server" DefaultButton="btnRegistrami">
                    <div>
                    <asp:Panel ID="Panel2" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <div class="containerRegister">
                            <h2 class="titleForm">TIPOLOGIA DI CLIENTE</h2>
                            <div class="input-group-radio " title="Ragione Sociale">
                                <div class="input-group-radios">
                                    <asp:RadioButton CssClass="lblSceltaTipoCli" AutoPostBack="true" ID="rdoCli" GroupName="tipoCli" runat="server" Text="Privato o Società" />
                                    <asp:RadioButton CssClass="lblSceltaTipoCli" AutoPostBack="true" ID="rdoRiv" GroupName="tipoCli" runat="server" Text="Rivenditore" />
                                </div>
                                <asp:ImageButton ID="imgRiv" runat="server" CssClass="imgInfo" OnClientClick="location.href='/diventa-rivenditore';" ImageUrl="/img/imgBusinessCliBanner.jpg" Visible="false" />                     
                                <asp:Label ID="lblInfoRiv" runat="server" Font-Size="Small"  Text="* Registrazione riservata agli operatori del settore delle arti grafiche (i dati inseriti saranno controllati da un operatore)" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="containerRegister">
                            <h2 class="titleForm">DATI ANAGRAFICI E DI FATTURAZIONE</h2>
                            <h6 >
                                <asp:Label ID="lblNomeAzienda" runat="server" Text="Ragione Sociale "  ></asp:Label>
                            </h6>
                            <div class="input-group input-group-icon" title="Ragione Sociale">
                                <asp:TextBox ID="txtNomeAz" runat="server" placeholder="Inserisci la Ragione Sociale dell'azienda" Enabled="true" MaxLength="100" CssClass="inputText" ></asp:TextBox>
                                <div class="input-icon">
                                    <i class="fa-solid fa-file-signature"></i>
                                </div>
                            </div>
                            <h6>
                                <asp:Label ID="lblTipoAtt" runat="server" Text="Tipo Attività *" Visible="false"></asp:Label>
                            </h6>
                            <div class="" title="Ragione Sociale">
                                <asp:DropDownList ID="ddlTipoAtt" runat="server" Width="49.5%" Visible="false"></asp:DropDownList>
                            </div>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6>Nome *</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtNome" Width="84%" placeholder="Inserisci il tuo Nome" runat="server"  MaxLength="50" CssClass="inputText"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-address-card"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6>Cognome *</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtCognome" Width="84%" placeholder="Inserisci il tuo Cognome"  runat="server" MaxLength="50" CssClass="inputText"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-address-card"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h6 >
                                Indirizzo *
                            </h6>
                            <div class="input-group input-group-icon" title="Ragione Sociale">
                                <asp:TextBox ID="txtIndirizzo"  placeholder="Inserisci l'indirizzo" font-size="14px" runat="server" MaxLength="100" CssClass="inputText"></asp:TextBox>
                                <div class="input-icon">
                                    <i class="fa-solid fa-location-dot"></i>
                                </div>
                            </div>
                            <p >
                                Indicaci l'<b>Indirizzo <asp:Label ID="lblSpecifIndirizzo" runat="server" Text="Principale"></asp:Label></b>, potrai aggiungere ulteriori indirizzi per la consegna nella tua area riservata
                            </p>
                            <h6 >
                                Nazione *
                            </h6>
                            <div class="" title="Ragione Sociale">
                                <asp:DropDownList ID="ddlNazione" Width="49.5%" AutoPostBack="true" runat="server"></asp:DropDownList>
                            </div>
                            <asp:Panel ID="pnlLocalitaIT" runat="server" Visible="true">
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6>Cap * </h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtCAP" AutoPostBack="true" runat="server" placeholder="Inserisci il CAP"  Width="84%" CssClass="inputText"></asp:TextBox>
                                        <div class="input-icon" >
                                            <i class="fa-solid fa-envelopes-bulk"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6>Località *</h6>
                                    <div class="" title="Ragione Sociale">
                                        <asp:DropDownList ID="ddlCitta" Width="100%" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlLocalitaNonIT" runat="server" Visible="false">
                            <h6 >
                                Localita e CAP *
                            </h6>
                            <div class="input-group input-group-icon" title="Ragione Sociale">
                                <asp:TextBox ID="txtLocalita"  placeholder="Inserisci la Località e il CAP" runat="server" Visible="true"  CssClass="inputText"></asp:TextBox>
                                <div class="input-icon">
                                    <i class="fa-solid fa-map-location-dot"></i>
                                </div>
                            </div>
                            </asp:Panel>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6 ><asp:Label ID="lblPiva" runat="server" Text="P. Iva"></asp:Label></h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtPiva" placeholder="Inserisci la Partita IVA" runat="server" CssClass="inputText" Width="85%"></asp:TextBox>
                                        <div class="input-icon input-group input-group-icon" >
                                            <i style="font-size:1.5em;width:20%;"><asp:TextBox ID="txtPrefisso"  placeholder="Inserisci il Prefisso Partita IVA" runat="server" Text="IT" ReadOnly="true" CssClass="inputTextIcon" ></asp:TextBox></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6><asp:Label ID="lblCodFisc"  runat="server" Text="Codice Fiscale *"></asp:Label></h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtCodFisc" placeholder="Inserisci il Codice Fiscale"  runat="server" Enabled="true" CssClass="inputText" Width="85.5%"></asp:TextBox>
                                        <div class="input-icon" >
                                            <i class="fa-solid fa-address-card"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6><asp:Label ID="lblPec" runat="server" Text="PEC"></asp:Label></h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtPec" placeholder="Inserisci la casella PEC" runat="server" MaxLength="50" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon input-group input-group-icon" >
                                            <i class="fa-solid fa-paper-plane"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6><asp:Label ID="lblSdi"  runat="server" Text="Codice SDI"></asp:Label></h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtSDI" placeholder="Inserisci il Codice SDI"  runat="server" Enabled="true"  MaxLength="7" Width="84%" CssClass="inputText"></asp:TextBox>
                                        <div class="input-icon" >
                                            <i class="fa-solid fa-address-card"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="containerRegister">
                            <h2 class="titleForm">CONTATTI</h2>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6>Telefono *</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtTel" runat="server"  placeholder="Inserisci un numero di rete fissa" MaxLength="30" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-phone"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6>Cellulare</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtCel" runat="server"  placeholder="Inserisci un numero Cellulare" MaxLength="30" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-mobile-screen"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6>Fax</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtFax"  placeholder="Inserisci un numero di Fax"  runat="server" MaxLength="30" CssClass="inputText" Width="84%" ></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-fax"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6>	Sito Internet</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtSito" placeholder="Inserisci il tuo sito internet" runat="server" MaxLength="250" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-globe"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="containerRegister">
                            <h2 class="titleForm">EMAIL DI ACCESSO</h2>
                            <p style="font-size:14px;font-style:normal">Questa email sarà la login di accesso per entrare nella tua <b>Area Riservata</b></p>
                            <div class="row-2">
                                <div class="containerTextBox">
                                    <h6>Email *</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox MaxLength="50" placeholder="Inserisci la tua Email"  ID="txtEmail" runat="server" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-solid fa-envelope"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="containerTextBox">
                                    <h6>Ripeti Email *</h6>
                                    <div class="input-group input-group-icon" title="Ragione Sociale">
                                        <asp:TextBox ID="txtEmailRip" runat="server" placeholder="Ripeti la tua Email"  MaxLength="50" CssClass="inputText" Width="84%"></asp:TextBox>
                                        <div class="input-icon">
                                            <i class="fa-regular fa-envelope"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <h6 style="text-align:right;border-bottom:0px;">(*) indica un campo obbligatorio</h6>
                            <hr/>
                            <asp:Panel ID="pnlErrore" Visible="false" runat="server">
                                 <div class="errorMessagePopup">
                                        <img src="/img/icoWarning32.png" />
                                        <asp:Label ID="lblErrore" runat="server" Text="-"></asp:Label>

                                </div>
                            </asp:Panel>
                            <div class="btnContainer">
                                <asp:Linkbutton ID="btnRegistrami" runat="server" CssClass="btnRegistrati"><i class="fa-solid fa-floppy-disk" style="font-size:2em"></i> Registrati</asp:Linkbutton>
                            </div>
                            
                        </div>
                        <div class="containerRegister">
                            <b>Cliccando sul pulsante "Registrati", acconsento che:</b>
                            <ul>
                                <li>
                                    <asp:CheckBox ID="chkConsensoDati" runat="server" Text="Consento al trattamento dei miei dati personali" /> <a  style="color:#f58220;text-decoration:underline;" href="/privacy">Leggi l'informativa sulla privacy</a>
                                </li>
                                <li>
                                    <asp:CheckBox ID="chkConsensoNewsletter" runat="server" Text="Voglio ricevere comunicazioni e OFFERTE promozionali tramite email dalla Tipografia Former" /></li>
                                <li>Ho almeno 18 anni di età</li>
                            </ul>
                        </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </asp:Panel>
                    </div>
                    </asp:Panel>
                </div>
                <div class="registrati">
                    <%--<asp:Panel id="pnlReg" runat="server" DefaultButton="btnRegistrami">
                        <h2 class="orange">Registrati</h2>
                        <div>
                            <asp:Panel ID="pnlRegister" runat="server">

        
                            <asp:UpdatePanel ID="updForm" runat="server">
                                                        <ContentTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="imgRegRiv" OnClientClick="location.href='/diventa-rivenditore';" ImageUrl="/img/imgBusinessCliBanner.jpg" Visible="false" />

        
                              <table>  
                                <tr>
                                <td class="bkgOrange" style="color:white;" colspan="4">
                                    <b>&nbsp;TIPOLOGIA DI CLIENTE</b></hr>
                                </td>
                            </tr>     
                            <tr>
                                <td></td>
                                <td colspan="2"><br /><asp:RadioButton CssClass="lblSceltaTipoCli" AutoPostBack="true" ID="RadioButton1" GroupName="tipoCli" runat="server" Text="Privato o Società" />
                                <br /><asp:RadioButton CssClass="lblSceltaTipoCli" AutoPostBack="true" ID="RadioButton2" GroupName="tipoCli" runat="server" Text="Rivenditore" /><br /><br /></td>
                                <td>
                
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label1" runat="server" Font-Size="Small"  Text="* Registrazione riservata agli operatori del settore delle arti grafiche (i dati inseriti saranno controllati da un operatore)" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="bkgOrange" style="color:white;" colspan="4">
                                    <b>&nbsp;DATI ANAGRAFICI E DI FATTURAZIONE</b></hr>
                                </td>
                            </tr>                        
                            <tr>
                                <td style="font-weight:bold;">
                                    <asp:Label ID="Label2" runat="server" Text="Ragione Sociale"></asp:Label>
                                </td>
                                <td class="tdDati" colspan="3">
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Size="14px" Width="558px" placeholder="Inserisci la Ragione Sociale dell'azienda" Enabled="true" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;"><asp:Label ID="Label3" runat="server" Text="Tipo Attività *" Visible="false"></asp:Label></td>
                                <td colspan="3">
                                     <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="14px" Width="200px" MaxLength="100" Visible="false"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="120"  style="font-weight:bold;">Nome *</td>
                                <td class="tdDati"  width="230">
                                    <asp:TextBox ID="TextBox2" Width="200px" placeholder="Inserisci il tuo Nome" runat="server" Font-Size="14px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td width="120" style="font-weight:bold;">Cognome *</td>
                                <td width="230">
                                    <asp:TextBox ID="TextBox3" Width="200px" placeholder="Inserisci il tuo Cognome"  runat="server" Font-Size="14px" MaxLength="50"></asp:TextBox>
                                </td>
            
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">Indirizzo *</td>
                                <td class="tdDati"  colspan="3">
                                    <asp:TextBox ID="TextBox4" Width="558px" placeholder="Inserisci l'indirizzo" font-size="14px" runat="server" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>        
                            <tr>
                                <td colspan="4" class="noteReg">Indicaci l'<b>Indirizzo <asp:Label ID="Label4" runat="server" Text="Principale"></asp:Label></b>, potrai aggiungere ulteriori indirizzi per la consegna nella tua area riservata</td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">Nazione * </td>
                                <td class="tdDati" >
                                    <asp:DropDownList ID="DropDownList2" Width="200px" AutoPostBack="true" runat="server" Font-Size="14px" MaxLength="5"></asp:DropDownList>
                                </td>
                                <td style="font-weight:bold;"></td>
                                <td></td>
                            </tr>
                            <asp:Panel ID="Panel3" runat="server" Visible="true">
                            <tr>
                                <td style="font-weight:bold;">Cap * </td>
                                <td class="tdDati" >
                                    <asp:TextBox ID="TextBox5" AutoPostBack="true" runat="server" placeholder="Inserisci il CAP"  Font-Size="14px" MaxLength="5" width="100"></asp:TextBox>
                                </td>
                                <td style="font-weight:bold;">Località * </td>
                                <td><asp:DropDownList ID="DropDownList3" Width="200px" AutoPostBack="true" runat="server" Font-Size="14px"></asp:DropDownList></td>
                            </tr>
                            </asp:Panel>
                            <asp:Panel ID="Panel4" runat="server" Visible="false">
                            <tr>
                                <td style="font-weight:bold;">Localita e CAP * </td>
                                <td class="tdDati" colspan="3"><asp:TextBox ID="TextBox6" Width="400px" placeholder="Inserisci la Località e il CAP" runat="server" Font-Size="14px" MaxLength="50" Visible="true"></asp:TextBox></td>
                            </tr>
                            </asp:Panel>
                            <tr>
                                <td style="font-weight:bold;">
                                    <asp:Label ID="Label5" runat="server" Text="P. Iva"></asp:Label>
                                </td>
                                <td class="tdDati">
                                    <asp:TextBox ID="TextBox7"  Width="20px" placeholder="Inserisci il Prefisso Partita IVA" runat="server" Font-Size="14px" MaxLength="2" Text="IT" ReadOnly="true"></asp:TextBox>
                                    <asp:TextBox ID="TextBox8"  Width="160px" placeholder="Inserisci la Partita IVA" runat="server" Font-Size="14px" MaxLength="11"></asp:TextBox>
                                </td>
                                <td style="font-weight:bold;">
                                    <asp:Label ID="Label6"  runat="server" Text="Codice Fiscale *"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox9" Width="200px" placeholder="Inserisci il Codice Fiscale"  runat="server" Enabled="true" Font-Size="14px" MaxLength="16"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-weight:bold;">
                                    <asp:Label ID="Label7" runat="server" Text="PEC"></asp:Label>
                                </td>
                                <td class="tdDati" >
                                    <asp:TextBox ID="TextBox10"  Width="200px" placeholder="Inserisci la casella PEC" runat="server" Font-Size="14px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td style="font-weight:bold;">
                                    <asp:Label ID="Label8"  runat="server" Text="Codice SDI"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox11" Width="200px" placeholder="Inserisci il Codice SDI"  runat="server" Enabled="true" Font-Size="14px" MaxLength="7"></asp:TextBox>
                                </td>
                            </tr>
                                         <tr><td colspan="4" style="height:10px;"></td></tr>                           
                            <tr>
                                <td class="bkgOrange" style="color:white;" colspan="4">
                                    <b>&nbsp;CONTATTI</b></hr>
                                </td>
                            </tr>
                          <tr>
                                <td style="font-weight:bold;">Telefono * </td>
                                <td class="tdDati" >
                                    <asp:TextBox ID="TextBox12" runat="server" Width="200px" placeholder="Inserisci un numero di rete fissa"  Font-Size="14px" MaxLength="30"></asp:TextBox>
                                </td> 
                                <td style="font-weight:bold;">Cellulare</td>
                                <td>
                                    <asp:TextBox ID="TextBox13" runat="server" Width="200px" placeholder="Inserisci un numero Cellulare"  Font-Size="14px" MaxLength="30" ></asp:TextBox>
                                </td>
                            </tr>
                          <tr>
                                <td style="font-weight:bold;">Fax</td>
                                <td class="tdDati" >
                                    <asp:TextBox ID="TextBox14" Width="200px" placeholder="Inserisci un numero di Fax"  runat="server" Font-Size="14px" MaxLength="30" ></asp:TextBox>
                                </td>
                                <td style="font-weight:bold;">Sito Internet</td>
                                <td>
                                    <asp:TextBox ID="TextBox15"  Width="200px" placeholder="Inserisci il tuo sito internet" runat="server" Font-Size="14px" MaxLength="250"></asp:TextBox>
                                </td>
                            </tr>
                        <tr><td colspan="4" style="height:10px;"></td></tr>                     
                        <tr>
                            <td class="bkgOrange"  style="color:white;" colspan="4"><b>&nbsp;EMAIL DI ACCESSO</b></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                Questa email sarà la login di accesso per entrare nella tua <b>Area Riservata</b>
                            </td>                             
                        </tr>
                        <tr>
                        <td style="font-weight:bold;">Email *</td>
                        <td class="tdDati" ><asp:TextBox MaxLength="50" Font-Size="14px" Width="200px" placeholder="Inserisci la tua Email"  ID="TextBox16" runat="server"></asp:TextBox></td>
                        <td style="font-weight:bold;">Ripeti Email * <font color="#505050" size="1"></font></td>
                            <td>
                                <asp:TextBox ID="TextBox17" runat="server" Width="200px" placeholder="Ripeti la tua Email"  Font-Size="14px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                    <h6 style="text-align:right;border-bottom:0px;">(*) indica un campo obbligatorio</h6>
                    <hr style="border:1px solid #f58220;width:80%;"/>
                        <asp:Panel ID="Panel5" Visible="false" runat="server">
                             <div class="errorMessagePopup">
                                    <img src="/img/icoWarning32.png" />
                                    <asp:Label ID="Label9" runat="server" Text="-"></asp:Label>
    
                            </div>
                        </asp:Panel>
                        <br />
                        <center><asp:Linkbutton ID="Linkbutton1" runat="server" CssClass="pulsante120Orange" ><img src="/img/icoChiaveW.png" /> Registrati</asp:Linkbutton> <br /><br /></center>
                        <b class="registratiLabel">Cliccando sul pulsante "Registrati", acconsento che:</b>
                                                            <ul>
                                                                <li><asp:CheckBox ID="CheckBox1" runat="server" Text="Consento al trattamento dei miei dati personali" /> <a  style="color:#f58220;text-decoration:underline;" href="/privacy">Leggi l'informativa sulla privacy</a></li>
                                                                <li><asp:CheckBox ID="CheckBox2" runat="server" Text="Voglio ricevere comunicazioni e OFFERTE promozionali tramite email dalla Tipografia Former" /></li>
                                                                <li>Ho almeno 18 anni di età</li>
                                                            </ul>
                      
                                </ContentTemplate>
                        </asp:UpdatePanel>
                     </asp:Panel>
                        </div>
                            </asp:Panel>--%>
                     <%If MostraOmaggi() Then %>
                <div class="Omaggi">

                    <h3 style="margin-bottom:0px;background-color:white;"><img src="/img/_Omaggio.png" />&nbsp;&nbsp;AL PRIMO ORDINE POTRAI SCEGLIERE UNO DEI SEGUENTI OMAGGI</h3><hr />
                
                    <asp:Repeater ID="rptOmaggi" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td valign="top" align="center" rowspan="2"  align="center" ><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("GetImgFormato") %>" width="64" /></td>
                                    <td><b><%#Eval("Nome")%></b></td>
                                    <td rowspan="2" valign="center" align="center" width="150" ><asp:Panel ID="pnlInfoOmaggio" runat="server" Visible="true">
                                        <img src="/img/icoinfoomaggio.png" class="hasTooltip"/>
                                        <div class="hidden tooltiptext">
                                            <img src="/img/icoinfoomaggio.png" class="imgSx" />
                                            <h4><%#Eval("Nome")%></h4>
                                            <%#Eval("CondizioneStr")%>
                                        </div></asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="OmaggioCellaInfo"><i><%#Eval("DescrSito")%></i></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="2" class="OmaggioTdInfo">* <%#Eval("CondizioneStr")%></td>
                                </tr>
                            </table>
                        
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                 <%End If %>

                 </div>
                                
             </div>
            <div id="tabs-2">
                <div class="depliant">
                    <img src="/img/registrati/tour.png" />
                    <br /><br />
                    Perchè registrarsi a TipografiaFormer.it? <b>Solo gli utenti registrati</b> al nostro sito avranno a disposizione:<br /><br />
                    <ul>
                        <li><b class="violet">Listino Wizard</b>: sapere il prezzo di un prodotto non è mai stato cosi facile. Utilizza il nostro semplice wizard e potrai scegliere tutte le opzioni che desideri nella creazione del tuo prodotto.<br />
                            <br /><center><img src="/img/registrati/screen1.jpg" class="immagineContornata" /></center><br />
                        </li>
                        <li><b class="violet">Scheda Prodotto Completa</b>: nella scheda di ogni prodotto avrai la possibilità di scegliere le varianti e le opzioni disponibili. Inoltre troverai i template che ti aiuteranno a fornirci i file nella maniera corretta.<br />
                            <br /> <center><img src="/img/registrati/screen2.jpg" class="immagineContornata" /></center><br />
                        </li>
                        <li><b class="violet">Area Riservata</b>: nella tua area riservata potrai tenere sempre sotto controllo lo stato dei tuoi ordini, scaricare i documenti contabili e accedere a tutte le funzioni riservate agli utenti registrati</li>
                        <li><b class="violet">Glossario Tipografico</b>: hai dubbi su un termine tecnico? Accedi al nostro glossario tipografico e troverai le definizioni di più di trecento termini riguardanti il mondo della tipografia</li>
                    </ul>
                   <br />
                    <b>Quindi che aspetti?</b> <br />Riempi il breve modulo di registrazione e ti invieremo tramite email i codici di accesso!<br /><br />
                    <b>Tipografia Former</b>
                </div>
             </div>
            <div id="tabs-3">
            <!--CONTATTACI-->
            <FormerWeb:Contattaci id="ContattaciUC" runat="server"/>
            </div>
         </div>
    </div>


</asp:Content>
