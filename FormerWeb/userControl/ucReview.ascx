<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucReview.ascx.vb" Inherits="FormerWeb.ucReview" %>

<div class="Review">
    <table >
        <%If WithProduct Then%>

            <%If Review.IdListinoBase <> 0 Then%>
            <tr>
                <td colspan="2"><h2><%=Review.ListinoBase.Nome%></h2>
                    </td>
            </tr>
            <%Else%>
            <tr>
                <td colspan="2"><h2>Prodotto non più disponibile</h2>
                    </td>
            </tr>
            <%End If%>

        <%End If%>
        <tr>
            <td colspan="2"><%=GetStars %> di <b><%=GetNome%></b> il <%=Review.Quando.ToString("dd/MM/yyyy") %></td>
        </tr>
        <tr ><td class="reviewCell"><div class="reviewPro">+ Pro</div></td><td class="reviewTesto" style="border-bottom:1px solid #e8e8e8;">"<%=GetPregi%>"</td></tr>
        <tr><td class="reviewCell"><div class="reviewContro">- Contro</div></td><td class="reviewTesto">"<%=GetDifetti%>"</td></tr>

        <%If Review.Risposta.Length Then%>

        <tr><td class="reviewCell"></td><td><div style="border-radius:3px;padding:10px;background-color:#2b2b2b;color:white;"><b style="color:white;">Risposta da </b><b style="color:#f58220;">Tipografia FORMER</b><br /><br /><i><%=GetRisposta%></i></div></td></tr>

        <%End If%>
        
        <%If WithProduct AndAlso Review.IdListinoBase <> 0 Then%>

        <tr>
            <td colspan="2" align="right"><hr /><a style="color:#2b2b2b;" href="<%=FormerWeb.FormerUrlCreator.GetUrl(Review.ListinoBase.IdPrev, Review.ListinoBase.IdFormProd, Review.ListinoBase.IdTipoCarta, Review.ListinoBase.IdColoreStampa) %>"><img src="/img/icoFreccia16.png" /> Vai al dettaglio del Prodotto</a>
                </td>
        </tr>

        <%End If%>
    </table>
</div>

    <div itemprop="itemReviewed" itemscope itemtype="http://schema.org/Product">
        <span itemprop="name"><%=Review.ListinoBase.Nome%></span>
        <div style="display:none;" itemprop="review" itemscope itemtype="http://schema.org/Review">
            <span itemprop="name">La mia Recensione</span>
        <div itemprop="author" itemscope itemtype="http://schema.org/Person">
            <span itemprop="name"><%=Server.HtmlEncode(GetNome)%></span>
        </div>
            <span itemprop="datePublished"><%=Review.Quando.ToString("yyyy-MM-dd") %></span>
            <div itemprop="reviewRating" itemscope itemtype="http://schema.org/Rating">
              <span itemprop="worstRating">1</span>
              <span itemprop="ratingValue"><%=Review.Voto%></span>/
              <span itemprop="bestRating">5</span>
            </div>
            <span itemprop="description">Pro: <%=GetPregi%><br />Contro: <%=GetDifetti%></span>
        </div>
    </div>
