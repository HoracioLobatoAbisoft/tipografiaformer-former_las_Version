<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.master" CodeBehind="richiediCampione.aspx.vb" Inherits="FormerWeb.pRichiediCampione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="depliant">

        <img src="/img/Campione/Titolo1.png" /><br /><br />
        <table>

            <tr>
                <td>
 Scegliere il materiale più idoneo per avere un prodotto di qualità e funzionale non è facile. Lo sappiamo bene! <br /><br />Scegliere il supporto cartaceo su cui realizzarlo ancora meno. I nostri prodotti sono proposti con le grammature di carta più idonee, ma se non sei convinto o vuoi toccare con mano la consistenza della carta noi ti inviamo gratuitamente
                </td>
                <td width="180" align="center">
                    <img src="/img/campione/img1.png" />
                </td>
            </tr>
        </table>       
        <br /><center><img src="/img/Campione/Titolo2.png" /></center><br />
        già da noi realizzato che ha le stesse caratteristiche di quello da Voi richiesto.<br /><br />
        Una sicurezza in più per non sbagliare!
        <br /><br />
        <div class="infoBox centered "><br />
             Campione Richiesto: <asp:Label ID="lblCampione" Font-Bold="true" Font-Size="Large" runat="server" Text="-"></asp:Label>
            <br /><br />
            <asp:ImageButton ID="imgRichiedi" ImageUrl="/img/btnRichiedi.png" CssClass="button" runat="server" />
            <br /><br />
        </div>
        

    </div>

</asp:Content>
