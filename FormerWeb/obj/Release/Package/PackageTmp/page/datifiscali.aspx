<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="datifiscali.aspx.vb" Inherits="FormerWeb.pDatiFiscali" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange"><img src="/img/_icoDatiFiscali.png" />AGGIORNA DATI FISCALI</h3>
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
                <td><asp:TextBox ID="txtPec" runat="server" Text="" Font-Size="11" Font-Bold="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <td>Codice SDI:</td>
                <td><asp:TextBox ID="txtSDI" runat="server" Text="" Font-Size="11" Font-Bold="true" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr style="border:1px solid #f58220;width:80%;"/>
                    <asp:Panel ID="pnlErrore" Visible="false" runat="server">
                         <div class="errorMessagePopup">
                                <img src="/img/icoWarning32.png" />
                                <asp:Label ID="lblErrore" runat="server" Text="-"></asp:Label>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr><td colspan="2" style="text-align:right;"><asp:linkbutton id="lnkModDati" runat="server" cssclass="pulsanteOrdina" >SALVA</asp:linkbutton></td></tr>
        </table>
       <br />
        <table class="tdFile" >
            <tr>
                <td><b>ATTENZIONE!</b><br />
                    Dal 1 gennaio 2019 per tutti i possessori di Partita Iva è obbligatoria l'emissione della fattura elettronica. E' quindi necessario inserire la propria PEC o il proprio codice SDI per poter effettuare ordini sul nostro sito
                </td>
            </tr>
            </table>
        </div>  
</asp:Content>
