<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/main.master" CodeBehind="dettaglioLavoro.aspx.vb" Inherits="FormerWeb.pDettaglioLavoro" %>
<%@ Register Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader" TagPrefix="CuteWebUI" %>
<%@ Import Namespace="FormerDALWEB" %>
<%@ Import Namespace="FormerLib" %>
<%@ Import Namespace="FormerLib.FormerEnum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    
<script runat="server">
       
    Private Sub UploaderF_FileUploaded(ByVal sender As Object, ByVal args As UploaderEventArgs)
        SalvaAllegatoFronte(args)
    End Sub
    
    Private Sub UploaderR_FileUploaded(ByVal sender As Object, ByVal args As UploaderEventArgs)
        SalvaAllegatoRetro(args)
    End Sub
    
</script>
    <div class="dettaglioOrdine">
  
    <h3 class="orange" style="margin-left:80px;"><img src="/img/icoLavoro50.png" />DETTAGLIO DEL TUO LAVORO N° <b class="black"><%=GetIdOrdView%></b> </h3>
        
     <div class="riepilogoOrdine">

        <hr /> 
       
    <table>
<tr>
    <td class="TDIntestazione">Quantità:</td>
    <td class="TDValore"><%=O.Qta%></td>
    <td rowspan="<% 
        Dim RowC As Integer = 6

        If O.L.ShowLabelFogli Then RowC += 1
        If O.ElencoLavorazioni(True).Count Then RowC += 1

        Response.Write(RowC)

        %>" valign="top" align="center"><b class="statoOrdineLabel" style='background-color:<%=O.ColoreStatoHTML%>;'><%=O.StatoStr%></b><br /><br />
         <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=GetImgFormato%>"/>
    </td>
</tr>
<tr>
    <td class="TDIntestazione">Prodotto:</td>
    <td class="TDValore"><%=O.P.Descrizione%></td>
</tr>
<tr>
    <td class="TDIntestazione">Formato prodotto:</td>
    <td class="TDValore"><%=O.DimensioniStr%></td>
</tr>
<tr>
    <td class="TDIntestazione">Supporto:</td>
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
<%If O.ElencoLavorazioni(True).Count Then%>
    <tr>
        <td class="TDIntestazione" valign="top">Opzioni:</td>
        <td class="TDValore"><ul><%For Each L As LavorazioneW In O.ElencoLavorazioni(True)%>
            <li><%=L.Descrizione%></li>
            <%Next%></ul>
        </td>
    </tr>
<%End If%>

<%--<tr>
    <td class="TDIntestazione">Modalita di consegna:</td>
    <td class="TDValore"><%=StrConv(O.Corriere.Descrizione,VbStrConv.ProperCase)%></td>
</tr>--%>

<tr>
    <td class="TDIntestazione">Imballo:</td>
    <td style="padding-left:20px;">Colli <b><%=O.ColliStr%></b>, Peso <b><%=O.PesoStr%></b> kg ±</td>
</tr>
<%--<tr>
    <td valign="top" class="TDIntestazione">Consegna</td>
    <td class="TDValore"><b><%=O.DataConsegnaStr%></b><br /><br /></td>
</tr>--%>
        <tr>
            <td colspan="3" align="right" style="padding:20px 40px 0px 0px;">
                <div class="tdPrezzo"> <img src="/img/icoPrezzo.png" />&nbsp; € <%=O.ImportoNettoStr %> + iva</div> <%If o.IdPromo Then %><br /><br /><b class="labelPromo">Promo <%=O.IdPromo %> %</b><%End if%>
            </td>
        </tr>
</table>
         <br />
     
<asp:UpdatePanel ID="PannelloDinamico" runat="server">
    <ContentTemplate>
        
<h5>Dettagli e Note</h5> 
<table>
    <tr>
        <td valign="top">
<table>
    <tr>
        <td valign="top" class="TDIntestazione">Nome Lavoro:</td>
        <td  class="BloccoNoteLavoro">
        <div class="boxNote"><%=o.NomeLavoro%></div>
        </td>
        <td valign="top" >
        <asp:LinkButton CssClass="pulsanteOperativo " ID="lnkEditNome"  style="color:black;" runat="server"><img src="/img/icoEdit20.png"  class="icoImg " /> Modifica Nome</asp:LinkButton>
    </td>
    </tr>
<%If O.L.NoAttachFile <> enSiNo.Si Then %>    
    <%If Fronteretro Then%>
    <tr>
        <td class="TDIntestazione">Tipo Retro:</td>
        <td colspan="2"><asp:DropDownList ID="ddlTipoRetro" runat="server" AutoPostBack="true" width="200"></asp:DropDownList></td>
    </tr>
    <%end if %>
<%end if %>

<%If ShowPreventivo Then%>
<tr>
    <td class="TDIntestazione">Preventivo:</td>
    <td colspan="2"><asp:CheckBox ID="chkPreventivo" runat="server" Text="(richiedi preventivo)" Font-Size="Small" AutoPostBack="true" /></td>
   
</tr>
<%End If%>
<tr>
    <td valign="top" class="TDIntestazione">Note:</td>
    <td  class="BloccoNoteLavoro">
        <div class="boxNote"><%=o.Annotazioni%></div>
        
    </td>
    <td valign="top" >
        <asp:LinkButton CssClass="pulsanteOperativo " ID="lnkEditNote"  style="color:black;"  runat="server"><img src="/img/icoEdit20.png"  class="icoImg "/> Modifica Note &nbsp;</asp:LinkButton>
    </td>
</tr>
</table>
        </td>
        <td align="center" valign="center">
<%If O.AnteprimaWeb.Length Then%>
    <a href="/ordini/<%=O.IdOrdineWeb%>/<%=o.AnteprimaWeb%>" data-lightbox="ord<%=o.IdOrdineWeb%>"><img src="/ordini/<%=o.IdOrdineWeb%>/<%=O.AnteprimaWeb%>" class="anteprima " /></a>
<%Else%>
    <img src="/img/NoAnteprima.png" class="imgBox" />
<%end if %>
        </td>
    </tr>
</table>


<asp:Panel ID="pnlNote" Visible="false"  runat="server">
   <div class="PopupBox">
            <asp:TextBox ID="txtNote" TextMode="MultiLine"  Width="535" Height="80" MaxLength="255" runat="server"></asp:TextBox><br /><br />
            
            <asp:LinkButton ID="lnkSaveNote" runat="server" CssClass="pulsanteOperativoR" ><img src="/img/icoCheckOk20.png" class="icoImg "/> Salva</asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="lnkChiudi" runat="server" CssClass="pulsanteOperativoR"><img src="/img/icoClose20.png" class="icoImg "/> Chiudi</asp:LinkButton>
    </div>
</asp:Panel>

<%If FileDaInviare Then%>
<h5>Invia i file direttamente &nbsp;&nbsp;<a href="/suggerimenti-per-inviarci-i-file" target="_blank" class="notafile" ><img src="/img/icoUploadW16.png" valign="middle" /> <b>Indicazioni su come inviarci i file</b></a></h5>

<table class="tdFile">
    <tr>
        <td colspan="4">
            Scegli i file dal tuo computer e premi il tasto <b>Invia File</b>. Non uscire da questa pagina finchè il caricamento non è terminato.
        </td>
    </tr>
<tr> 
    <td align="center"  width="140" rowspan="2">
        <asp:LinkButton ID="lnkCarica" ClientIDMode="Static" CssClass ="pulsante120Red" runat="server" OnClientClick="return submitbutton_click();"><img src="/img/icoupload20w.png" /> Invia File</asp:LinkButton>
        
    </td>
    <td width="70" valign="center" align="right"><b>Fronte: </b><img src="/img/icoFileTypePDF.png" class="icoImg"/></td>
    <td  valign="top">
        <%If O.SorgenteFronte.Length = 0 And O.Stato < enStatoOrdine.Registrato Then%>
            <CuteWebUI:Uploader runat="server" ID="UploaderF" 
                                InsertText="Scegli File (Max 50Mb)" 
                                CancelAllMsg="Annulla" 
                                CancelText="Annulla"   
                                FileTooLargeMsg="Il file selezionato è di dimensioni troppo grandi (Max 50mb)" 
                                FileTypeNotSupportMsg="Puoi allegare agli ordini solo file in formato PDF"
                                ProgressPanelWidth="400"
                                ProgressBarBorderStyle="2px solid #f1f1f1"
                                ProgressLabelStyle-CssClass="uploader"
                                InsertButtonStyle-CssClass="uploaderBtn"
                                ClientIDMode="AutoID"
                                ManualStartUpload="true" 
                                OnFileUploaded="UploaderF_FileUploaded">
                <ValidateOption MaxSizeKB="51200" />
                <ValidateOption AllowedFileExtensions="pdf" />
            </CuteWebUI:Uploader>
        <%End If%>
        
    </td>
</tr>
<% If FronteRetro Then%>
<tr>
    <td valign="center" align="right"><b>Retro: </b><img src="/img/icoFileTypePDF.png" class="icoImg"/></td>
    <td valign="top">
        <%If O.TipoRetro = enTipoRetro.RetroDifferente and O.SorgenteRetro.Length=0 Then%>
         <CuteWebUI:Uploader runat="server" ID="UploaderR" 
                        InsertText="Scegli File (Max 50Mb)" 
                        CancelAllMsg="Annulla" 
                        CancelText="Annulla"   
                        FileTooLargeMsg="Il file selezionato è di dimensioni troppo grandi (Max 50mb)" 
                        FileTypeNotSupportMsg="Puoi allegare agli ordini solo file in formato PDF"
                        ProgressPanelWidth="400"
                        ProgressBarBorderStyle="2px solid #f1f1f1"
                        ProgressLabelStyle-CssClass="uploader"
                        InsertButtonStyle-CssClass="uploaderBtn"
                        ClientIDMode="AutoID" 
                        ManualStartUpload="true"
                        OnFileUploaded="UploaderR_FileUploaded">
            <ValidateOption MaxSizeKB="51200" />
            <ValidateOption AllowedFileExtensions="pdf" />
        </CuteWebUI:Uploader>
        <%End If %>
        <asp:Label ID="lblRetro" runat="server" Visible="false" Font-Size="10" Font-Bold="false"></asp:Label>
        
    </td>
</tr>
<%Else%>
    <tr>
        <td></td>
        <td></td>
    </tr>
<%End If%>

</table>
        
        <%If UtenteConnesso.IsAdmin = True And FileDaInviare = True Then%>

        <h5>Allega i file dal Gestionale Former</h5>
        <table class="tdFile">
                <tr>
                    <td align="center">
                        <a href="former:<%=O.IdOrdine%>" class="pulsanteOperativoR "><img src="/img/icoDown16.png"/> Allega file dal Gestionale</a></a>
                    </td>
                </tr>
            </table>
        <br />

        <%end if %>


<%Else
        'QUI CI STA TUTTA LA PARTE IN CUI I FILE NON DEVONO ESSERE INVIATI
        %>            
<%If O.Stato = enStatoOrdine.InAttesaPagamento Then%>

<%If O.L.NoAttachFile <> enSiNo.Si Then %>   
    <h5>Invio File</h5>
        <table class="tdFile"><tr><td align="center">
    Prima di inviare i file devi effettuare il pagamento dell'ordine in cui hai inserito questo lavoro. <br /><br /><a href="/<%=O.ConsegnaAssociata.IdConsegna %>/dettaglio-ordine"><b>CLICCA QUI</b></a> per andare al dettaglio dell'ordine<br /><br />
                          </td></tr></table> 

<%else %>
    <h5>Pagamento</h5>
        <table class="tdFile"><tr><td align="center">
    Devi effettuare il pagamento dell'ordine in cui hai inserito questo lavoro. <br /><br /><a href="/<%=O.ConsegnaAssociata.IdConsegna %>/dettaglio-ordine"><b>CLICCA QUI</b></a> per andare al dettaglio dell'ordine<br /><br />
                          </td></tr></table> 

<%end if %>
    
<%else %>
<%If O.L.NoAttachFile <> enSiNo.Si Then %>  
<h5>I file che ci hai inviato</h5>
    Qui trovi i file che ci hai inviato. Se i file sono presenti online puoi scaricarli cliccando sul link <b>Scarica <i>{e il Nome del File}</i></b>.
<table class="tdFile" >
    <tr>
        <td width="100" valign="center" align="right"><b>Fronte: </b><img src="/img/icoFileTypePDF.png" class="icoImg"/></td>
        <td valign="top"><a runat="server" href="#" id="HrefFronte" class="saveNote" visible="false" ><img src="/img/icoDown16.png" /> Scarica file Fronte</a>
        </td>
    </tr>
<tr> 
<% If FronteRetro And O.SorgenteRetro.Length Then%>
<tr>
    <td valign="center" align="right"><b>Retro: </b><img src="/img/icoFileTypePDF.png" class="icoImg"/></td>
    <td valign="top"><a runat="server" id="HrefRetro" href="#" class="saveNote" visible="false"><img src="/img/icoDown16.png" /> Scarica file Retro</a>
    </td>
</tr>
<%                      End If %>
</table>
<%End if%>

<%end if%>

<%End If%>
        
 
             <script type="text/javascript">
                 
            function submitbutton_click() {
                var uploadobjF = document.getElementById('<%=UploaderF.ClientID%>');
                var uploadobjR = document.getElementById('<%=UploaderR.ClientID%>');

           if (!window.filesuploaded) {
               if (uploadobjF.getqueuecount() > 0) {
                   if (uploadobjR != null) {
                       if (uploadobjR.getqueuecount() > 0)
                           uploadobjF.startupload();
                   }
                   else {
                       uploadobjF.startupload();
                   }
                   if (uploadobjR != null) {
                       if (!window.filesuploaded) {
                           if (uploadobjR.getqueuecount() > 0) {
                               uploadobjR.startupload();
                           }
                           else {
                               //var uploadedcount = parseInt(submitbutton.getAttribute("itemcount")) || 0;
                               //if (uploadedcount > 0) {
                               //    return true;
                               //}
                               alert("Scegli un file per il Retro");
                           }

                           return false;
                       }

                   }
               }
               else {
                   //var uploadedcount = parseInt(submitbutton.getAttribute("itemcount")) || 0;
                   //if (uploadedcount > 0) {
                   //    return true;
                   //}
                   alert("Scegli un file per il Fronte");
               }

               return false;
           }

                 window.filesuploaded = false;

           return true;
       }

       function CuteWebUI_AjaxUploader_OnPostback() {
           window.filesuploaded = true;
           var submitbutton = document.getElementById('<%=lnkCarica.ClientID%>');
           submitbutton.click();
        return false;
    }

</script>
       
                                        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" 
                                            AssociatedUpdatePanelID="PannelloDinamico" runat="server">
                                        <ProgressTemplate>
                                            <div class="progressW"><img src="/img/progress.gif" /></div> 
                                        </ProgressTemplate>
                                        </asp:UpdateProgress>
    </ContentTemplate>
</asp:UpdatePanel>
    <div style="float:right;margin-top:20px;">
        <a href="/i-tuoi-lavori" class="pulsante120Orange"><img src="/img/icoIndietroW.png"/>Indietro</a> <a class="pulsante120Orange" href="javascript:window.print()"><img src="/img/icoPrinterW.png" />Stampa</a> 
        <%If ShowTemplate2D() Then%>
             <a href="<%=GetTemplatePDF2D%>" target="_blank" class="pulsante120Blu"><img src="/img/icoFileTypePdf.png" />Template PDF</a>
        <%End If
            If ShowTemplate3D() Then%>
        <% If FormerWeb.FormerWebApp.IsInternetExplorer Then%>
        <a href="<%=FormerWeb.FormerWebApp.PathListinoTemplate%><%=O.l.FormatoProdotto.PdfTemplate3D%>" target="_blank" class="pulsante120Blu" ><img src="/img/ico3D.png" />Modello 3D</a>
        <%Else%>
        <asp:LinkButton ID="lnkDownloadModello3d" CssClass="pulsante120Blu" runat="server"><img src="/img/ico3D.png" />Modello 3D</asp:LinkButton>
        <%End If%>
        <%end if %>

        
        <a href="/<%=O.IdCons%>/dettaglio-ordine" class="pulsante120Green"><img src="/img/icoCarrello32.png" />Vai all' Ordine</a>
    </div>
   
</div>
    </div>
</asp:Content>
