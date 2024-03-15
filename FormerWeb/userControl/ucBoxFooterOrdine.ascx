<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucBoxFooterOrdine.ascx.vb" Inherits="FormerWeb.ucBoxFooterOrdine" %>
<%@ Import Namespace="Formerlib.FormerEnum" %>

<div class="BoxOrdFooter">
    <hr />

    <%If Ordine.IdStatoConsegna = enStatoConsegna.InAttesaDiPagamento Then%>
        <a href="<%=Ordine.IdConsegna%>/dettaglio-ordine"  class="pulsanteOperativoR"><img src="/img/icoPrezzo16.png" /> <b>EFFETTUA IL PAGAMENTO</b></a>&nbsp;&nbsp;&nbsp;
    <%ElseIf Ordine.Tracciabile Then%>
        <a href="<%=GetTraceUrl%>" class="pulsanteOperativo" target="_blank"><img src="/img/icoCorriere20.png" width="16" /> <b>TRACCIA IL MIO PACCO</b></a>&nbsp;&nbsp;&nbsp;
    <%End If%>
    <a href="/<%=Ordine.IdConsegna%>/dettaglio-ordine" class="pulsanteOperativo"><img src="/img/icoFreccia16.png" /> Vai al Dettaglio Consegna</a>&nbsp;&nbsp;&nbsp;
    <%If Ordine.Modificabile Then%>
        <asp:LinkButton ID="lnkDelOrd" CssClass="pulsanteOperativo" runat="server" OnClientClick = "return confirm('Sicuro di voler eliminare questo Ordine?');"><img src="/img/icoCestino16.png" />Elimina Consegna</asp:LinkButton>
    <%      End If%>
   
</div>