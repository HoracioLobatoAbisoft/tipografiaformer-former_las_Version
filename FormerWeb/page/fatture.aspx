<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="fatture.aspx.vb" Inherits="FormerWeb.pFatture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange"><img src="/img/icoFileTypePdf.png" />&nbsp;&nbsp;LE TUE FATTURE</h3>
    <div class="arearis"> 
        <div id="tabs" >
        <ul>
        <li><a href="#tabs-1"><img src="/img/icopdf20.png" alt="Le tue fatture" class="icoImg"/> Le tue fatture</a></li>
            </ul>
            
        <div id="tabs-1">
            <div class="infoInd">
              Da qui puoi scaricare le fatture in formato <b>PDF</b> relative ai tuoi ordini dell'ultimo anno e stamparle per tua archiviazione.<br /><br />
            </div>

             <asp:Repeater ID="rptFatture" runat="server">
                 <ItemTemplate>
                <div class="Review">
                    <table>
                        <tr><td><b>- Fattura Numero <%#Eval("Tag")%> relativa all'Ordine N° <%#Eval("IdConsegna")%></b></td></tr>
                        <tr><td colspan="2" align="right"><hr /> <a style="color:#2b2b2b;" href="/<%#Eval("IdConsegna")%>/dettaglio-ordine" ><img src="/img/icoFreccia16.png" /> Vai al Dettaglio Ordine</a> | <asp:LinkButton ID="lblScarica" runat="server" CommandName="scarica" CommandArgument='<%#Eval("IdConsegnaInt")%>' style="color:#2b2b2b;" ><img src="/img/icopdf20.png" />Scarica documento fiscale</asp:LinkButton></td></tr>
                    </table>
                </div>
                 </ItemTemplate>
             </asp:Repeater>
        <br /><br /><center><asp:label ID="lblNoFatture" Font-Bold="true" Font-Size="Large"  runat="server" Text="Al momento non sono presenti fatture disponibili per il download" Visible="false"></asp:label></center><br /><br />

        </div>
        </div>
  </div>  
</asp:Content>
