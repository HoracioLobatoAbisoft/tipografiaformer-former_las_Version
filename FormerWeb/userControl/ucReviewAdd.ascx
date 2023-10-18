<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucReviewAdd.ascx.vb" Inherits="FormerWeb.ucReviewAdd" %>

<div class="ReviewAdd">

    <table>
         <tr>
            <td colspan="2">
                Dai un voto a questo prodotto:<br /><br />
                <asp:RadioButtonList ID="rdoVoto" runat="server" >
                <asp:ListItem Value="5" Selected="true" ><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /> <b>Eccellente</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="4" ><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /> <b>Buono</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="3" ><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /> <b>Discreto</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="2" ><img src="/img/icoStarFull.png" /><img src="/img/icoStarFull.png" /> <b>Sufficiente</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                <asp:ListItem Value="1" ><img src="/img/icoStarFull.png" /> <b>Insufficiente</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                            </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="2">Se vuoi qui puoi spiegare perchè hai dato questa valutazione</td>
        </tr>
        <tr><td class="reviewCell"><div class="reviewPro">+ Pro</div></td><td class="reviewTesto"><asp:TextBox ID="txtPro" runat="server" MaxLength="200" TextMode="MultiLine" Height="40" Width="550" placeholder="Cosa ne pensi? Cosa ti è piaciuto?"></asp:TextBox></td></tr>
        <tr><td class="reviewCell"><div class="reviewContro">- Contro</div></td><td class="reviewTesto"><asp:TextBox ID="txtContro" runat="server" MaxLength="200" TextMode="MultiLine" Height="40" Width="550" placeholder="Qualcosa non andava? Cosa non ti è piaciuto?"></asp:TextBox></td></tr>
        <tr>
            <td colspan="2" align="center"><asp:LinkButton ID="lnkSalva" runat="server" cssclass="pulsante120Green"  OnClientClick = "return confirm('Vuoi salvare la recensione inserita?');"><img src="/img/icoSave.png" /> Salva</asp:LinkButton></td>
        </tr>
    </table>
 
</div>
