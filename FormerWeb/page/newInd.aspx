<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.master" CodeBehind="newInd.aspx.vb" Inherits="FormerWeb.pnewInd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="arearis">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:panel ID="pnlNewInd" runat="server" DefaultButton="lnkSave">
<asp:UpdatePanel ID="updForm" runat="server">
                            <ContentTemplate>
                                
<h3 class="orange"><img src="/img/icoInd50.png" />AGGIUNGI UN NUOVO INDIRIZZO</h3>
Se vuoi salvare un indirizzo differente riempi i campi qui sotto:<br />
<div class="newInd">
<table border="0">  
        <tr>
            <td width="120" valign="bottom"><b>Riferimento (*)</b>:</td>
            <td valign="bottom">
                <asp:TextBox ID="txtNome" runat="server" Font-Size="11px" MaxLength="100" placeholder="Dai un nome a questo indirizzo (es. Casa, Ufficio, ecc...)" width="200"></asp:TextBox> <asp:LinkButton Text="Fermo Deposito?" ID="HlnkFermoDeposito" runat="server"></asp:LinkButton>
            </td>
        </tr> 
        <tr>
            <td valign="bottom">Destinatario (*)</td>
            <td valign="bottom">
                <asp:TextBox ID="txtDestinatario" runat="server" Font-Size="11px" MaxLength="100" placeholder="Inserisci il Destinatario" width="300"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td valign="bottom">Indirizzo (*)</td>
            <td valign="bottom">
                <asp:TextBox ID="txtIndirizzo" runat="server" Font-Size="11px" MaxLength="100" placeholder="Inserisci il tuo indirizzo" width="300"></asp:TextBox>
            </td>
        </tr> 
        <tr>
            <td valign="bottom">Nazione * </td>
            <td valign="bottom" >
                <asp:DropDownList ID="ddlNazione" Width="200px" AutoPostBack="true" runat="server" Font-Size="14px" MaxLength="5"></asp:DropDownList>
            </td>
        </tr>
        <asp:Panel ID="pnlLocalitaIT" runat="server" Visible="true">
        <tr>
            <td valign="bottom">Cap (*)</td>
            <td valign="bottom">
                <asp:TextBox ID="txtCAP" AutoPostBack="true" runat="server" Font-Size="11px" MaxLength="5" placeholder="Inserisci il tuo CAP" width="90"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="bottom">Località (*)</td>
            <td valign="bottom">
                <asp:DropDownList ID="ddlCitta" Width="200px" AutoPostBack="true" runat="server" Font-Size="14px"></asp:DropDownList>
            </td>
        </tr> 
        </asp:Panel>
        <asp:Panel ID="pnlLocalitaNonIT" runat="server" Visible="false">
        <tr>
            <td valign="bottom">Localita e CAP * </td>
            <td valign="bottom"><asp:TextBox ID="txtLocalita" Width="200px" placeholder="Inserisci la Località e il CAP" runat="server" Font-Size="14px" MaxLength="50" Visible="true"></asp:TextBox></td>
        </tr>
        </asp:Panel>
        <tr>
            <td valign="bottom">Telefono</td>
            <td valign="bottom">
                <asp:TextBox ID="txtTelefono" runat="server" Font-Size="11px" MaxLength="100" placeholder="Inserisci un numero di Telefono" width="200"></asp:TextBox>
            </td>
        </tr> 

     
</table>
    <asp:Panel ID="pnlErrore" Visible="false" runat="server">
                <div style="font-weight:bold;text-align:center;"><br />
                        <img src="/img/icoWarning32.png" />
                        <asp:Label ID="lblErrore" runat="server" Text="ATTENZIONE! Tutti i campi contrassegnati dall'asterisco sono obbligatori" Font-Size="X-Small"></asp:Label>
                    
                </div>

</asp:Panel>
    <br />
    <center><asp:linkbutton id="lnkSave" runat="server" cssclass="pulsante120Orange" ><img src="/img/icoSaveW.png" /> Salva</asp:linkbutton></center>

</div>
   
</ContentTemplate>
</asp:UpdatePanel>
     </asp:panel>
    </div>
</asp:Content>
