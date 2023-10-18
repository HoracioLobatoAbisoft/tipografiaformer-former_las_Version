<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucAggregateReview.ascx.vb" Inherits="FormerWeb.ucAggregateReview" %>
<div class="AggregateReviews">
<table>
    <tr>
        <td><%=GetStars %></td>

        <% If GetNumeroRecensioni() Then%>
        <td><b><%= GetNumeroRecensioni()%></b> <%If ShortVersion = False Then%>recensioni<%end if %></td>
        <%Else%>
        <td><%If ShortVersion = False Then%>Non sono ancora presenti recensioni<%end if %></td>
        <%End If%>
    </tr>
    <%If ShortVersion = False And GetNumeroRecensioni() Then%>
    <tr>
        <td colspan="2">&nbsp;&nbsp;&nbsp;<b><%=GetVoto%></b> su 5 stelle</td>
    </tr>
    <%End if%>
</table>
</div>
<% If GetNumeroRecensioni() Then%>
<div style="display:none;" itemscope itemtype="https://schema.org/Product">
  <h2 itemprop="name"><%=GetNome()%></h2>
  <div itemprop="description"><%=GetDescrizione()%></div>
  <div itemprop="aggregateRating" itemscope itemtype="https://schema.org/AggregateRating">
    <span itemprop="ratingValue"><%=GetVoto()%></span>  
    <span itemprop="bestRating">5</span> 
    <span itemprop="reviewCount"><%=GetNumeroRecensioni()%></span> 
  </div>
</div>
<%End If %>