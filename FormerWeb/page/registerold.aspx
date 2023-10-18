<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="registerold.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="FormerWeb.registerOld" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Contattaci" Src="~/userControl/ucContattaci.ascx" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" lang= "javascript">

    function onlyNumber() {


        if ((event.keyCode < 48) || (event.keyCode > 57)) {
            event.returnValue = false;
        }

    }
   

    function checkNum(text) {
       
       
        var regex = /^[0-9]+$/;
      
        if (text.value.match(regex)) {
            return true;
        }
        text.value=''
        return false
    }

</script>

  
    <script type="text/javascript">
 
        $(document).ready(function() {
 
            $("#<%=txtTel.ClientID%>").bind({
               
                paste : function(){
                    checkInp("<%=txtTel.ClientID%>".value);
                }
               
            });
 
        });	
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     
       

     <div class="Registrati">
       
         <div id="tabs">

                  <ul>
                    <li><a href="#tabs-1"><img src="/img/icoLock16.png" alt="Registrati" class="icoImg"/> Registrati</a></li>
                    <li><a href="#tabs-2"><img src="/img/icoMondo.png" alt="Un breve tour" class="icoImg"/> Perchè registrarsi? Un breve Tour</a></li>
                      <li><a href="#tabs-3"><img src="/img/icoAssistenza16.png" alt="Contattaci per ricevere assistenza" class="icoImg"/> Contattaci</a></li>
                  </ul>

             <div id="tabs-1">
                 
                <div class="registrati">
                    
                    <%--<h2 class="orange">Registrati</h2>--%>
                    <div id="contattaci">
                        <asp:Panel ID="pnlRegister" runat="server">

                        
                        <asp:UpdatePanel ID="updForm" runat="server">
                                                    <ContentTemplate>
                        <asp:ImageButton ID="imgRiv" runat="server" CssClass="imgRegRiv" OnClientClick="location.href='/diventa-rivenditore';" ImageUrl="/img/imgBusinessCliBanner.jpg" Visible="false" />

                        
                          <table border="0">  
                            <tr>
                            <td class="bkgOrange" style="color:white;" colspan="4">
                                <b>&nbsp;Tipologia di Cliente</b></hr>
                            </td>
                        </tr>     
                        <tr>
                            <td></td>
                            <td colspan="2"><br /><asp:RadioButton CssClass="lblSceltaTipoCli" autopostback="true" ID="rdoCli" GroupName="tipoCli" runat="server" Text="Privato o Società" />
                            <br /><asp:RadioButton CssClass="lblSceltaTipoCli" autopostback="true" ID="rdoRiv" GroupName="tipoCli" runat="server" Text="Rivenditore" /><br /><br /></td>
                            <td>
                                <asp:Label ID="lblErrTipo" runat="server" Text="Selezionare la Tipologia di Cliente" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblInfoRiv" runat="server" Font-Size="Small"  Text="* Registrazione riservata agli operatori del settore delle arti grafiche (i dati inseriti saranno controllati da un operatore)" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="bkgOrange" style="color:white;" colspan="4">
                                <b>&nbsp;Dati Anagrafici e di Fatturazione</b></hr>
                            </td>
                        </tr>                        
                        <tr>
                            <td width="120">
                                <asp:Label ID="lblNomeAzienda" runat="server" Text="Ragione Sociale"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNomeAz" runat="server" Enabled="true" Font-Size="11px" MaxLength="100" width="270"></asp:TextBox>
                            </td>
                            <td width="16"></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rqAz" runat="server" ControlToValidate="txtNomeAz" CssClass="mandatoryField" Enabled="false" ErrorMessage="La Ragione Sociale è obbligatoria"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="lblTipoAtt" runat="server" Text="Tipo Attività *" Visible="false"></asp:Label></td>
                            <td colspan="3">
                                 <asp:DropDownList ID="ddlTipoAtt" runat="server" AutoPostBack="true" Font-Size="11px" MaxLength="100" width="270" Visible="false"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Nome *</td>
                            <td>
                                <asp:TextBox ID="txtNome" runat="server" AutoPostBack="true"  Font-Size="11px" MaxLength="50" width="270"></asp:TextBox>
                            </td>
                            <td width="16"><asp:Image ID="imgNomeval" ImageUrl="" runat="server" CssClass="icoImg" /></td>
                            <td><asp:RequiredFieldValidator ID="rqNome" runat="server" ControlToValidate="txtNome" CssClass="mandatoryField" Visible="true" ErrorMessage="Il Nome è obbligatorio"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regNome" ValidationGroup="nome" runat="server" ControlToValidate="txtNome" Visible="true"  CssClass="mandatoryField" ErrorMessage="Il Nome sembra errato" ValidationExpression="^[a-zA-Z][a-zA-Z ]*[a-zA-Z]$"></asp:RegularExpressionValidator>
                                 </td>
                        </tr>
                        <tr>
                            <td>Cognome *</td>
                            <td>
                                <asp:TextBox ID="txtCognome" runat="server" AutoPostBack="true"  Font-Size="11px" MaxLength="50" width="270"></asp:TextBox>
                            </td>
                            <td width="16"><asp:Image ID="imgCognomeval" ImageUrl="" runat="server" CssClass="icoImg" /></td><td><asp:RequiredFieldValidator ID="rqCogn" runat="server" ControlToValidate="txtCognome" CssClass="mandatoryField" ErrorMessage="Il Cognome è obbligatorio"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="regCognome" ValidationGroup="cognome" runat="server" ControlToValidate="txtCognome" CssClass="mandatoryField" ErrorMessage="Il Cognome sembra errato" ValidationExpression="^[a-zA-Z][a-zA-Z ]*[a-zA-Z]$"></asp:RegularExpressionValidator>
                        
                            </td>
                        </tr>
                        <tr>
                            <td>Indirizzo *</td>
                            <td>
                                <asp:TextBox ID="txtIndirizzo" runat="server" Font-Size="11px" MaxLength="100" width="270"></asp:TextBox>
                            </td>
                            <td></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIndirizzo" CssClass="mandatoryField" ErrorMessage="L'indirizzo è obbligatorio"></asp:RequiredFieldValidator></td>
                        </tr>        
                        <tr>
                            <td colspan="4" class="noteReg">Indicaci l'<b>Indirizzo <asp:Label ID="lblSpecifIndirizzo" runat="server" Text="Principale"></asp:Label></b>, potrai aggiungere ulteriori indirizzi per la consegna nella tua area riservata</td>
                        </tr>

                        <tr>
                            <td>Provincia *</td>
                            <td>
                                <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" Font-Size="11px" MaxLength="100" width="270"></asp:DropDownList>
                            </td>
                            <td colspan="2"></td>
                        </tr>

                          <tr>
                            <td>Comune * </td>
                            <td>
                                <asp:DropDownList ID="ddlComune" runat="server" Font-Size="11px" width="270"></asp:DropDownList>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td>Cap * </td>
                            <td>
                                <asp:TextBox ID="txtCAP" runat="server" Font-Size="11px" MaxLength="5" width="50" onkeypress="javascript:onlyNumber()" Onblur="checkNum(this)"></asp:TextBox>
                            </td>
                            <td></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCap" CssClass="mandatoryField" ErrorMessage="Il CAP è obbligatorio"></asp:RequiredFieldValidator></td>
                        </tr>
                         <tr>
                            <td>Località * </td>
                            <td>
                                <asp:TextBox ID="txtCitta" runat="server" ClientIDMode="Static" Font-Size="11px" MaxLength="100" width="270"  onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                            </td>
                             <td></td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCitta" CssClass="mandatoryField" ErrorMessage="La Località è obbligatoria"></asp:RequiredFieldValidator></td>
                        </tr> 
                     
                        <tr>
                            <td>
                                <asp:Label ID="lblPiva" runat="server" Text="P. Iva"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPiva" AutoPostBack="true"  runat="server" Font-Size="11px" MaxLength="11" width="270"></asp:TextBox>
                            </td>
                            <td width="16"><asp:Image ID="imgPivaVal" ImageUrl="" runat="server" CssClass="icoImg"  /></td>
                            <td> <asp:RequiredFieldValidator ID="rqPiva" runat="server" ControlToValidate="txtPiva" CssClass="mandatoryField" Enabled="true" ErrorMessage="La Partita IVA è obbligatoria"></asp:RequiredFieldValidator>
                       
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodFisc"  runat="server" font-bold="false" Text="Codice Fiscale *"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodFisc" AutoPostBack="true" runat="server" Enabled="true" Font-Size="11px" MaxLength="16" width="270"></asp:TextBox>
                            </td>
                            <td width="16"><asp:Image ID="imgCodFiscVal" ImageUrl="" runat="server" CssClass="icoImg"  /></td>
                            <td><asp:RequiredFieldValidator ID="rqCodFisc" runat="server" ControlToValidate="txtCodFisc" CssClass="mandatoryField" Enabled="true" ErrorMessage="Il Cod.Fisc. è obbligatorio"></asp:RequiredFieldValidator>                              
                                <asp:RegularExpressionValidator ID="regcodFisc" ValidationGroup="fiscale" runat="server" ControlToValidate="txtCodFisc" CssClass="mandatoryField" ErrorMessage="Il Cod.Fisc. sembra errato" ValidationExpression="^[a-zA-Z]{6}[0-9]{2}[abcdehlmprstABCDEHLMPRST]{1}[0-9]{2}([a-zA-Z]{1}[0-9]{3})[a-zA-Z]{1}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="bkgOrange" style="color:white;" colspan="4">
                                <b>&nbsp;Contatti</b></hr>
                            </td>
                        </tr>
                      <tr>
                            <td>Telefono</td>
                            <td>
                                <asp:TextBox ID="txtTel" runat="server" Font-Size="11px" MaxLength="30" width="270"  onkeypress="javascript:onlyNumber()" Onblur="checkNum(this)" ></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                      <tr>
                            <td>Fax</td>
                            <td>
                                <asp:TextBox ID="txtFax" runat="server" Font-Size="11px" MaxLength="30"  width="270" onkeypress="javascript:onlyNumber()" Onblur="checkNum(this)"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr>
                               <tr>
                            <td>Cellulare</td>
                            <td>
                                <asp:TextBox ID="txtCel" runat="server" Font-Size="11px" MaxLength="30" width="270" onkeypress="javascript:onlyNumber()" Onblur="checkNum(this)"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr> 
                        <tr>
                            <td>Sito Internet</td>
                            <td>
                                <asp:TextBox ID="txtSito" runat="server" Font-Size="11px" MaxLength="250" width="270"></asp:TextBox>
                            </td>
                            <td colspan="2"></td>
                        </tr> 
                    <tr>

                        <td class="bkgOrange"  style="color:white;" colspan="4"><b>&nbsp;Email di Accesso</b></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            Questa email sarà la chiave di accesso per entrare nella tua <b>Area Riservata</b>
                        </td>                             
                    </tr>
                    <tr>
                    <td>Email * <font size="1" color="#505050"></font></td>
                    <td><asp:TextBox MaxLength="50" Font-Size="11px"  width="270" AutoPostBack="true"  ID="txtEmail" runat="server" onblur="valida('mail')"></asp:TextBox></td>
                    <td width="16"><asp:Image ID="imgEmail" ImageUrl="" runat="server" CssClass="icoImg"  /></td>
                    <td><asp:RequiredFieldValidator ID="rqEmail" runat="server" CssClass="mandatoryField" ErrorMessage="L' email è obbligatoria" ControlToValidate="txtEmail">                    </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="email"  EnableClientScript="true" ID="regEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" CssClass="mandatoryField" ErrorMessage="L' email non sembra corretta" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
                    </tr> 
                    <tr>
                        <td>Ripeti Email * <font color="#505050" size="1"></font></td>
                        <td>
                            <asp:TextBox ID="txtEmailRip" runat="server" Font-Size="11px" AutoPostBack="true" MaxLength="50" width="270"></asp:TextBox>
                        </td>
                        <td width="16"><asp:Image ID="imgEmailRip" ImageUrl="" runat="server"  CssClass="icoImg" /></td>
                        <td><asp:RequiredFieldValidator ID="rqEmailRip" runat="server" ControlToValidate="txtEmailRip" CssClass="mandatoryField" ErrorMessage="Ripetere l'email"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regEmailRip" ValidationGroup="EmailRip" runat="server" ControlToValidate="txtEmailRip" CssClass="mandatoryField" ErrorMessage="L' email non sembra corretta" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
        
               
                    
                  
                    </table><h6>(*) indica un campo obbligatorio</h6><br />
<hr style="border:1px solid #f58220;width:80%;"/>
                    <asp:Panel ID="pnlErrore" Visible="false" runat="server">
                         <div class="errorMessagePopup">
                                <img src="/img/icoWarning32.png" />
                                <asp:Label ID="lblErrore" runat="server" Text="-"></asp:Label>
                        </div>
                    </asp:Panel><br />
                                                        
                    <b class="registratiLabel">Cliccando sul pulsante "Registrati", acconsento che:</b>
                                                        <ul>
                                                            <li>Consento al <a  style="color:#f58220;text-decoration:underline;" href="/privacy">trattamento dei miei dati personali</a></li>
                                                            <li>Posso ricevere comunicazioni tramite email dalla Tipografia Former</li>
                                                            <li>Ho almeno 18 anni di età</li>
                                                        </ul>
                                                        
                                                        <center><asp:ImageButton ID="btnRegistrami" ImageUrl="/img/btnRegister.png" runat="server" CssClass="button" /><br /><br />
                                                            </center>
                                        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" 
                                            AssociatedUpdatePanelID="updForm" runat="server">
                                        <ProgressTemplate>
                                            <div class="progressW"><img src="/img/progress.gif" /></div> 
                                        </ProgressTemplate>
                                        </asp:UpdateProgress>

                            </ContentTemplate>
                           


                        </asp:UpdatePanel>
                 </asp:Panel>
                    </div>
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
