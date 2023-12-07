<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucLbConsigliato.ascx.vb" Inherits="FormerWeb.ucLbConsigliato" %>
<%@ Register  TagPrefix="FormerWeb" TagName="AggregateReview" Src="~/userControl/ucAggregateReview.ascx" %>
<div class="risultatoRicerca">
    <table class="MainTable">
        <tr>
            <td rowspan="5" width="133" valign="top">
                <img width="128"src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=Listinobase.GetImgFormato%>" />
            </td>
            <td valign="top"><a  class="titoloRisRicerca" href="/<%=ListinoBase.IdPrev%>/<%=ListinoBase.IdFormProd%>/<%=ListinoBase.IdTipoCarta%>/<%=ListinoBase.IdColoreStampa%>/<%=ListinoBase.NomeInUrl%>"><%=ListinoBase.Nome%></a></td>
        </tr>
        <tr><td>
            Categoria: <%=ListinoBase.Preventivazione.Descrizione%><br />
            Formato: <%=ListinoBase.FormatoProdotto.Formato%><br />
            Carta: <%=ListinoBase.TipoCarta.Tipologia %> <br />
            Colori: <%=ListinoBase.ColoreStampa.Descrizione  %> <br />
            <div class="descrRisRicerca"><%=ListinoBase.DescrSito%></div></td></tr>
        
        <%If ListinoBase.ExistPromo Then %>

            <tr><td colspan="2">
                <div class="boxPromo">
                <img src="/img/icoPromo20.png" /> <b class="labPromo">Promo</b> Prodotto in promozione con sconto del <b class="labPromo"><%=ListinoBase.Promo.Percentuale%>%</b><br />
                <font size="1">* Valido fino al <%=ListinoBase.Promo.DataFineValidita.ToString("dd/MM/yyyy") %> salvo esaurimento scorte</font>
                </div>
                </td></tr>

        <%End If %>

        <tr><td colspan="2"><FormerWeb:AggregateReview ID="AggregateReview" runat="server" /></td></tr>
        <tr><td colspan="2" align="right"><hr /><a href="<%=FormerWeb.FormerUrlCreator.GetUrl(ListinoBase.IdPrev, ListinoBase.IdFormProd, ListinoBase.IdTipoCarta, ListinoBase.IdColoreStampa)%>"><img src="/img/icoFreccia16.png" /> Vai al dettaglio del Prodotto</a></td></tr>
    </table>
</div>
