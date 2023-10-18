<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/main.master" CodeBehind="recensioni.aspx.vb" Inherits="FormerWeb.pRecensioni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ Register  TagPrefix="FormerWeb" TagName="Review" Src="~/userControl/ucReview.ascx" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="recensioni">
    <div class="bannerRecensioni">
        <a href="/recensioni"><h2><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /> LE RECENSIONI DEI CLIENTI</h2>
        Scopri il parere di chi ha provato i nostri prodotti</a>
    </div>
    <table>
        <tr>
            <td>
                <h2><%=GetStars %> <b><%=GetTotRecensioni%></b> recensioni - <b><%=AggregateRating()%></b> su 5 Stelle</h2>
            </td>
            <td valign="top" align="center" width="170"><a href="/le-tue-recensioni" class="pulsante150Green"><img src="/img/icoRecensione.png" />Scrivi recensione</a></td>
        </tr>
    </table>

    <div style="padding:0px 50px 0px 50px">
     <asp:Repeater ID="rptReview"  runat="server">
            <HeaderTemplate><h3>Le più recenti tra le recensioni dei clienti</h3></HeaderTemplate>
            <ItemTemplate>
                <FormerWeb:Review ID="SingReview" runat="server" />
            </ItemTemplate>

     </asp:Repeater>
    <div class="pager">Vai alla pagina <asp:PlaceHolder ID="plcPaging" runat="server" /> <asp:Label runat="server" ID="lblPageName"  /></div>
    </div>

</div>

</asp:Content>
