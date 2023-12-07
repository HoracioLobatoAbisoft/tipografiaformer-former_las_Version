<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucBoxHeaderLavoro.ascx.vb" Inherits="FormerWeb.ucBoxHeaderLavoro" %>
<%@ Import Namespace="FormerliB.FormerEnum" %>
<div class="BoxOrdTit"> 
    <table>
        <tr>
            <td width="30"><%If Ordine.Omaggio <> enSiNo.Si Then %><img src="<%=Ordine.IconaStato%>" title="<%=Ordine.StatoStr%>" class="BoxIcoStato" /><%end If %></td>
            <td width="30"><div class="statoOrdineBox" title="<%=Ordine.StatoStr%>" style="background-color:<%=Ordine.ColoreStatoHTML %>;"></div></td>
            <td><b><%=Ordine.QtaStr%> <%=Ordine.BoxTitolo%></b></td>
            <td width="140"><%If Ordine.StatoOrdine = enStatoOrdine.InAttesaAllegati And Ordine.IdOrdineWeb <> 0 And Ordine.Omaggio <> enSiNo.Si Then%><b class="red">&nbsp;&nbsp;&nbsp;ALLEGARE I FILE!</b><%Else If Ordine.StatoOrdine = enStatoOrdine.InAttesaPagamento Then %><b class="red">&nbsp;&nbsp;&nbsp;EFFETTUA IL PAGAMENTO!</b><%End If%></td>
            <td width="60" align="right"><%=IIf(Ordine.IdOrdineWeb, Ordine.NOrdineStr, "")%></td>
            <td width="100" align="right"><%If Ordine.Omaggio = enSiNo.Si Then %><b class="OmaggioLabel">OMAGGIO</b><%else %><b>€ <%=Ordine.ImportoNettoStr%> + iva</b><%End If%></td>
        </tr>
    </table>
</div>