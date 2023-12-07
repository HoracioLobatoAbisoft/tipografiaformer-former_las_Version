<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRandomLB.ascx.vb" Inherits="FormerWeb.ucRandomListinoBase" %>
<div class="randomLb">
     <table width="100%" border="0">
         <tr>
             <td colspan="2">
<i>Riflettori puntati su </i>&nbsp;<b><%=ListinoBase.Nome %></b>
             </td>
         </tr>
        <tr>
            <td width="120" valign="top" align="center">
                <a id="lnkToProdImg" href="/<%=ListinoBase.IdPrev%>/<%=ListinoBase.IdFormProd%>/<%=ListinoBase.IdTipoCarta%>/<%=ListinoBase.IdColoreStampa%>/<%=ListinoBase.NomeInUrl%>" ><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=listinobase.GetImgFormato%>" height="80" width="80" class="imgLB" border=0 alt="<%=listinobase.Nome%>"></a>
            </td>
            <td valign="top"><span><%=ListinoBase.DescrSitoFormatted  %></span></td>
        </tr>
         <tr>
             <td></td>
         </tr>
         <tr>
             <td style="height:25px;text-align:right;" colspan="2">
        <hr />
    <a id="lnkToProd" href="/<%=ListinoBase.IdPrev%>/<%=ListinoBase.IdFormProd%>/<%=ListinoBase.IdTipoCarta%>/<%=ListinoBase.IdColoreStampa%>/<%=ListinoBase.NomeInUrl%>" ><img src="/img/icoFreccia16.png" /> Vai al dettaglio del Prodotto</a>
             </td>
         </tr>
         
    </table>
</div>