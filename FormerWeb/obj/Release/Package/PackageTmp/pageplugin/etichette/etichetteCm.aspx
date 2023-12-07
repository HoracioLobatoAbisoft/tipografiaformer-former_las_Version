<%@ Page Title="" Language="vb" AutoEventWireup="True" MasterPageFile="~/master/home.master" CodeBehind="etichetteCm.aspx.vb" Inherits="FormerWeb.pEtichetteCm" enableEventValidation="false"%>
<%@ Import Namespace="FormerWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"/>--%>
    
    <div class="pluginF">
    <div class="introP boxNotePlugin">
          <b>INDICAZIONI</b><br />
          <img src="/img/etichettemisure.png" class="imgRight "/>
          <img src="<%=FormerWebApp.PathListinoImg%><%=P.Imgrif%>" class="imgRight "/>
        Inserisci le dimensioni di <b>BASE (B) e ALTEZZA (A)</b> del formato che desideri realizzare. Guarda la figura accanto per avere un riferimento visivo.<br /><br />
        Ti ricordiamo che <b>tutte le misure sono espresse in millimetri (mm)</b> e che alcuni prodotti prevedono delle dimensioni minime che verranno impostate automaticamente qualora tu inserissi un valore più basso.<br /><br />
        Una volta scelto il prodotto che ti soddisfa clicca sul pulsante <b>SELEZIONA</b> per andare avanti<br /><br />
    </div>
   
    <h5>Inserisci le dimensioni del Formato CHIUSO</h5>
    <asp:UpdatePanel ID="PannelloDinamico"  runat="server" UpdateMode="Conditional">
    <ContentTemplate>    
        
    <div class="bodyP" >
            <div style="margin-left:25px;" class="boxMisPack centered MargineAuto">
            <table >
                <tr>
                    <td>
                        <b>Cerca o Crea Fustella</b>
                    </td>
                    <td style="padding-left: 10px;">
                    <b class="orange ">(B)</b> - <b>Base</b> (mm)
                    </td>
                    <td>
                        <asp:TextBox AutoPostBack="true" ID="txtBase" Font-Size="Large" CssClass="txtMisure" MaxLength="3" Width="50" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                    <b class="orange ">(A)</b> - <b>Altezza</b> (mm)
                    </td>
                    <td>
                        <asp:TextBox AutoPostBack="true" ID="txtAltezza" Font-Size="Large" CssClass="txtMisure" MaxLength="3" Width="50" runat="server"></asp:TextBox>
                    </td>
                    <td style="padding-left: 10px;">
                    <b class="orange ">Categoria</b>
                    </td>
                    <td>
                        <asp:DropDownList AutoPostBack="true" runat="server" ID="cmbCat"></asp:DropDownList>
                    </td>
                </tr>
            </table>
                                        
        </div>
 
    </div>
    <div class="risP ">
    <h5>Seleziona l'etichetta tra quelle disponibili</h5>
    <div class="AlRight" style="margin:20px 0 20px 0;">
    <asp:linkbutton id="lnkProseguiTop" runat="server" cssclass="pulsante120Green" ><img src="/img/icoCheckBlack.png" /> Seleziona</asp:linkbutton>
    </div>
      <asp:RadioButtonList ID="rdoFustelle" runat="server" CssClass="svgFustella" RepeatLayout="Table" RepeatDirection="Horizontal" ></asp:RadioButtonList>
        <asp:Panel ID="pnlFuoriMis" Visible="false" runat="server"><div class="msgPanel">Per le misure che hai inserito ti preghiamo di contattarci per un preventivo</div></asp:Panel>
        <asp:Panel ID="pnlTutteMis" Visible="false" runat="server"><div class="msgPanel">Per continuare devi inserire tutte le misure (Base, Altezza)</div></asp:Panel>

    </div>
    <div class="AlRight" style="margin:20px 0 20px 0;">
    <asp:linkbutton id="lnkProsegui" runat="server" Visible="false" cssclass="pulsante120Green" ><img src="/img/icoCheckBlack.png" /> Seleziona</asp:linkbutton>
    </div>
         
        <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" 
                                            AssociatedUpdatePanelID="PannelloDinamico" runat="server">
                                        <ProgressTemplate>
                                            <div class="progressW"><img src="/img/progress.gif" /></div> 
                                        </ProgressTemplate>
        </asp:UpdateProgress>

       </ContentTemplate>
</asp:UpdatePanel>

    </div>
<%--        <script type="text/javascript">
        // Create the event handler for PageRequestManager.endRequest
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(toolTipStart);
    </script>--%>
</asp:Content>
