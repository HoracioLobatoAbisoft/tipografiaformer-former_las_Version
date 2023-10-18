<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucPrevPromo.ascx.vb" Inherits="FormerWeb.ucPrevPromo" %>
 <%If WithHeader Then%>
    <b>Offerta in corso su questo prodotto</b><br />
     <%End If%>
<div class="YourCoupon">
     <table width="100%" border="0">
        <tr>
            <td width="100" align="center">
                <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=Preventivazione.Imgrif%>" class="imgLB" border=0 alt="<%=Preventivazione.Descrizione%>">
            </td>
            <td align="center" valign="center">
                Per ogni acquisto di <span class="couponLabel"><%=Preventivazione.DescrizioneEstesa%></span> <br />
                Riceverai automaticamente un <b>Coupon di Sconto</b> pari al <b class="percPromo"><%=Preventivazione.PercCoupon%>%</b> dell'importo speso, utilizzabile sul successivo acquisto dello stesso prodotto.
            </td>
        </tr>
        <%If WithFooter Then%>
        <tr>
            <td colspan="2" align="right">
            <hr />
            <a id="lnkToProd" href="/<%#Eval("IdPrev")%>/<%#Eval("NomeInUrl")%>" ><img src="/img/icoFreccia16.png" /> Vai ai Prodotti in Offerta</a>
            </td>
        </tr>
        <%End If%>
    </table>
</div>