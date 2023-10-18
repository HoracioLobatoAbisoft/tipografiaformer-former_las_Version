<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="riepilogo.aspx.vb" Inherits="FormerWeb.riepilogo" %>

<%@ Import Namespace="FormerDALWEB" %>
<%@ Import Namespace="FormerLib" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="riepilogoOrdine">
        <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=O.L.ImgSito%>" class="imgRiepilogoOrdine"/>
         
<h5>Tipografia FORMER - <%=Now.ToString("dd MMM yyyy HH.mm")%></h5>
       <hr />
        
    <table>
<tr class="rigaEvidenza">
    <td class="TDIntestazione">Prodotto:</td>
    <td class="TDValore"><%=O.P.Descrizione%></td>
</tr>
<tr>
    <td class="TDIntestazione">Formato prodotto:</td>
    <td class="TDValore"><%=O.F.Formato%></td>
</tr>
<tr>
    <td class="TDIntestazione">Tipo di carta:</td>
    <td class="TDValore"><%=O.TC.Tipologia%></td>
</tr>
<tr>
    <td class="TDIntestazione">Colori di stampa:</td>
    <td class="TDValore"><%=O.C.Descrizione%></td>
</tr>
<%If O.L.ShowLabelFogli() Then%>
    <tr>
        <td class="TDIntestazione"><%=O.L.GetLabelFogli%></td>
        <td class="TDValore"><%=O.NFogliVis%></td>
    </tr>
<%end if %>
<%If O.LavorazioniIncluse.Count Then%>
    <tr>
        <td class="TDIntestazione">Lavorazioni incluse:</td>
        <td class="TDValore"><ul><%For Each L As lavorazioneW In O.LavorazioniIncluse%>
            <li><%=L.Descrizione%></li>
            <%Next%></ul>
        </td>
    </tr>
<%End If%>
<tr class="rigaEvidenza">
    <td class="TDIntestazione">Quantità:</td>
    <td class="TDValore"><%=O.Qta%></td>
</tr>
<%--<tr>
    <td class="TDIntestazione">Prezzo:</td>
    <td class="TDValore"><%=FormerWeb.FormerHelper.Stringhe.FormattaPrezzo(O.PrezzoCalcolatoNetto)%></td>
</tr>--%>
<tr>
    <td class="TDIntestazione">Modalita di consegna:</td>
    <td class="TDValore"><%=StrConv(O.Corriere.Descrizione,VbStrConv.ProperCase)%></td>
</tr>
<%--<tr>
    <td class="TDIntestazione">Data di consegna:</td>
    <td class="TDValore"><%=O.DataConsegna.ToLongDateString%> pomeriggio</td>
</tr>--%>
<tr>
    <td class="TDIntestazione">Peso:</td>
    <td class="TDValore"> <%=O.Peso%> kg &#177;</td>
</tr>
<tr>
    <td class="TDIntestazione">Colli:</td>
    <td class="TDValore"><%=O.Colli%></td>
</tr>
<%--<tr>
    <td class="TDIntestazione">Spese di trasporto:</td>
    <td class="TDValore"><%=FormerWeb.FormerHelper.Stringhe.FormattaPrezzo(O.Corriere.Costo)%></td>
</tr>
<tr class="rigaEvidenza">
    <td class="TDIntestazione">Prezzo Netto:</td>
    <td class="TDValore"><%=FormerWeb.FormerHelper.Stringhe.FormattaPrezzo(O.TotaleNetto)%></td>
</tr>
<tr>
    <td class="TDIntestazione">IVA: (<%=FormerWeb.FormerWebApp.GetPercIva()%>%)</td>
    <td class="TDValore"><%=FormerWeb.FormerHelper.Stringhe.FormattaPrezzo(O.TotaleIva)%></td>
</tr>--%>
    </table>
     
    <hr />
     
    <div class="AlRight"><span class="<%=IIf(UtenteConnesso.Tipo = enTipoRubrica.Cliente, "RigaTotaleOrdinePubblico", "RigaTotaleOrdine")%>"> <img src="/img/icoPrezzo.png" />&nbsp;&nbsp; <span class="TotaleOrdine">€ <%=FormerHelper.Stringhe.FormattaPrezzo(O.PrezzoCalcolatoNetto)%> + iva</span></span></div>
    <%If O.SpeseDiTrasporto Then%>
    <div class="AlRight RigaTotalePicc"><%If O.Corriere.TipoCorriere = 2 Then%>Spese di Imballo<%Else%>Spese di Trasporto<%End If%> € <b><%=FormerHelper.Stringhe.FormattaPrezzo(O.SpeseDiTrasporto)%></b></div>
    <%End If%>
        <div class="AlRight RigaTotalePicc">IVA € <b><%=FormerHelper.Stringhe.FormattaPrezzo(O.TotaleIva)%></b></div>
        <div class="AlRight RigaTotalePicc">TOTALE ORDINE (IVA e Trasporto inclusi) € <b><%=FormerHelper.Stringhe.FormattaPrezzo(O.TotaleOrdine)%></b></div>
        <div class="AlRight RigaTotalePicc">Il materiale sarà pronto <b><span class="orange"><%=StrConv(O.DataConsegna.toString("dddd dd/MM/yyyy"), vbProperCase)%> <%=O.QuandoMomento%></span></b> per <b><%=O.Corriere.TestoMail  %></b></div>
    <hr />
Per <b>COMPLETARE L' ORDINE</b> riempi le informazioni richieste di seguito e clicca sul pulsante <b>INVIA ORDINE</b><br /><br />
<table width="100%">
<tr>
    <td class="TDIntestazione">Email Riferimento:</td>
    <td ><asp:TextBox width="300"  placeholder="Inserisci la mail a cui riceverai risposta" ID="txtEmailRiferimento" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator6" runat="server" 
            ErrorMessage="- Inserire la mail di riferimento!" 
            ControlToValidate="txtEmailRiferimento"></asp:RequiredFieldValidator>
    </td>
    
</tr>
<tr>
    <td class="TDIntestazione">Preventivo:</td>
    <td ><asp:CheckBox ID="chkPreventivo" runat="server" Text="(richiedi preventivo)" Font-Size="Smaller"  /></td>
   
</tr>
<tr>
    <td class="TDIntestazione">Note:</td>
    <td ><asp:TextBox ID="txtNote" placeholder="Qui puoi aggiungere note o indicazioni particolari riguardanti questo ordine"  TextMode="MultiLine"  Width="600" Height="35" runat="server"></asp:TextBox></td>
    
</tr>
</table>
<h5>Allega i file all'ordine &nbsp;&nbsp;<a href="/suggerimenti-per-inviarci-i-file" target="_blank" class="notafile" ><img src="/img/icoUploadW16.png" valign="middle" /> <b>Se hai bisogno di indicazioni su come inviarci i file clicca qui</b></a></h5>
<div id="tabs">

                  <ul>
                    <li><a href="#tabs-1"><img src="/img/icoUpload16.png" alt="Standard Upload" class="icoImg"/> Standard Upload</a></li>
                    <li><a href="#tabs-2"><img src="/img/icoUpload16.png" alt="Advanced Upload" class="icoImg"/> Advanced Upload</a></li>
                    <li><a href="#tabs-3"><img src="/img/icoUpload16.png" alt="HTTP Upload" class="icoImg"/> HTTP Upload</a></li>
                    <li><a href="#tabs-4"><img src="/img/icoUpload16.png" alt="HTTP Upload" class="icoImg"/> Email Upload</a></li>
                  </ul>

             <div id="tabs-1">
<table>
<%--<tr>
    <td colspan="3"><br /><b>File di anteprima</b></td>
</tr>
<tr>
    <td align="center"><img src="/img/icofiletypeJPG.png" /></td>
    <td colspan="2" >
        <asp:FileUpload ID="fileAnteprima" runat="server"  /></td>
   
</tr>--%>
<tr>
    <td colspan="3"><b>File Sorgenti</b></td>
</tr>
<tr>
    <td align="center"><img src="/img/icofiletypePDF.png" /></td>
    <td width="130"><b>Sorgente Fronte</b></td><td><asp:FileUpload ID="fileFronte" runat="server" /><asp:RequiredFieldValidator 
            ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="- Inserire il Sorgente Fronte" 
            ControlToValidate="fileFronte"></asp:RequiredFieldValidator></td>
</tr>
<asp:Panel ID="pnlRetro" runat="server" Visible="false">
<tr>
    <td></td>
    <td><b>Sorgente Retro </b></td><td><asp:FileUpload ID="fileRetro" Enabled="false" runat="server" /><asp:RequiredFieldValidator 
            ID="rqFileRetro" runat="server" 
            ErrorMessage="- Inserire il Sorgente Retro" 
            ControlToValidate="fileRetro" Enabled="false"></asp:RequiredFieldValidator></td>
</tr>
</asp:Panel>

</table>
                  </div>
            <div id="tabs-2"><br /><b>Advanced Upload</b><br /><br />
                Carica i file con un indicatore che ti mostra lo stato di avanzamento. <br /><br /><b><i>Disponibile a breve</i></b>
            </div>
            <div id="tabs-3"><br /><b>HTTP Upload</b><br /><br />
                Indicaci un percorso HTTP (un indirizzo internet es. www.miosito.com/miofile.pdf), ci occuperemo noi di scaricare i file sui nostri server andando a scaricarli automaticamente.  <br /><br /><b><i>Disponibile a breve</i></b>
            </div>
            <div id="tabs-4"><br /><b>Email Upload</b><br /><br />
                Inviaci tramite EMAIL a un indirizzo che ti indicheremo i file sorgenti e noi li allegheremo all'ordine.  <br /><br /><b><i>Disponibile a breve</i></b>
            </div>
</div>
    <h3>
        <a href="<%=NextUrl%>"><img src="/img/btnIndietro.png" class="button" /></a> <a href="javascript:window.print()"><img src="/img/btnStampa.png" class="button"/></a>
        <asp:ImageButton ID="btnInviaOrdine" ImageUrl="/img/btnInviaOrdine.png" runat="server" CssClass="button" />
    </h3>
        <br />
    
        <asp:Panel ID="pnlError" runat="server" Visible="false">
    <div class="errorMessagePopup">
            <img src="/img/icoWarning32.png" />
            <asp:Label ID="lblErrore" runat="server" Text="-"></asp:Label>
    </div>
        </asp:Panel>  

        <div class="qrCodeContainer">
            <asp:Image ID="imgQrCode" runat="server" CssClass="qrCode" /> <div class="qrCodeText"><b>Il tuo prodotto</b><br />Leggi questo <b>QRCODE</b> dal tuo smartphone o tablet per tornare velocemente al prodotto che stai acquistando</div>
        </div>
        
    
</div>

</asp:Content>
