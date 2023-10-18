<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucRisultatoRicerca.ascx.vb" Inherits="FormerWeb.ucRisultatoRicerca" %>
<%@ Register  TagPrefix="FormerWeb" TagName="AggregateReview" Src="~/userControl/ucAggregateReview.ascx" %>
<div class="risultatoRicerca">
    <table class="MainTable">
        <tr>
            <td rowspan="5" width="133" valign="top">
                <a href="<%=FormerWeb.FormerUrlCreator.GetUrl(ListinoBase.IdPrev, ListinoBase.IdFormProd, ListinoBase.IdTipoCarta, ListinoBase.IdColoreStampa)%>"><img width="128"src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=Listinobase.GetImgFormato%>" /></a>
            </td>
            <td valign="top"><a  class="titoloRisRicerca" href="/<%=ListinoBase.IdPrev%>/<%=ListinoBase.IdFormProd%>/<%=ListinoBase.IdTipoCarta%>/<%=ListinoBase.IdColoreStampa%>/<%=ListinoBase.NomeInUrl%>"><%=ListinoBase.Nome%></a></td>
        <td rowspan="2" class="cellaPrezzi">
            <table cellpadding="0" cellspacing="0">
                <%If ListinoBase.ExistPromo Then%>
                <tr style="background-color:#f1f1f1;"><td class="prezzoRisRicerca TestoBarrato">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo1RivStr, IndiceRicerca.Prezzo1Str)%></td><td width="70" nowrap>(<%=IndiceRicerca.Qta1%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <tr><td colspan="2" class="prezzoRisRicercaPromo"><b class='prezzoPromo'><%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo1RivPStr, IndiceRicerca.Prezzo1PStr)%></b> <b class='labelPromo'>Promo</b></td></tr>
                <tr><td class="prezzoRisRicerca TestoBarrato">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo2RivStr, IndiceRicerca.Prezzo2Str)%></td><td nowrap>(<%=IndiceRicerca.Qta2%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <tr><td colspan="2" class="prezzoRisRicercaPromo"><b class='prezzoPromo'><%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo2RivPStr, IndiceRicerca.Prezzo2PStr)%></b> <b class='labelPromo'>Promo</b></td></tr>
                <tr style="background-color:#f1f1f1;"><td class="prezzoRisRicerca TestoBarrato">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo3RivStr, IndiceRicerca.Prezzo3Str)%></td><td nowrap>(<%=IndiceRicerca.Qta3%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <tr><td colspan="2" class="prezzoRisRicercaPromo"><b class='prezzoPromo'><%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo3RivPStr, IndiceRicerca.Prezzo3PStr)%></b> <b class='labelPromo'>Promo</b></td></tr>
                <%else%>
                <tr style="background-color:#f1f1f1;"><td class="prezzoRisRicerca">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo1RivStr, IndiceRicerca.Prezzo1Str)%></td><td width="70" nowrap>(<%=IndiceRicerca.Qta1%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <tr><td class="prezzoRisRicerca">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo2RivStr, IndiceRicerca.Prezzo2Str)%></td><td nowrap>(<%=IndiceRicerca.Qta2%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <tr style="background-color:#f1f1f1;"><td class="prezzoRisRicerca">€ <%= IIf(ShowPrezziRiv, IndiceRicerca.Prezzo3RivStr, IndiceRicerca.Prezzo3Str)%></td><td nowrap>(<%=IndiceRicerca.Qta3%> <%=IndiceRicerca.UnitaMisura%>)</td></tr>
                <%end If%>
            </table>
        </td>
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
