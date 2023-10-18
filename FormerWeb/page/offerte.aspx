<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.master" CodeBehind="offerte.aspx.vb" Inherits="FormerWeb.pOfferte" %>
<%@ Register  TagPrefix="FormerWeb" TagName="PrevPromo" Src="~/userControl/ucPrevPromo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange"><img src="/img/icoCoupon30.png" />OFFERTE E PROMOZIONI</h3>
    <div class="ordini">
         <div id="tabs" >
        <ul>
        <li><a href="#tabs-1"><img src="/img/icoOfferte16.png" alt="Offerte e Promozioni" class="icoImg"/> Offerte e Promozioni <img src="/img/new.gif" /></a></li>
        <li><a href="#tabs-2"><img src="/img/icoInfo20.png" alt="Come funzionano le Offerte e Promozioni?" class="icoImg"/> Come funzionano le Offerte e Promozioni?</a></li>
        </ul>
        <div id="tabs-1" style="min-height:400px;">           
            <div class="offerte">
                          In questa pagina trovi le <b>Offerte e le Promozioni</b> in corso. Approfittane e risparmia sull' acquisto dei nostri prodotti!<br /><br />
                          <!--PROMOZIONIIIIIIIIIIII-->
                          <asp:Repeater ID="rptOfferte" runat="server">
                              <HeaderTemplate><b>Promozioni in corso</b><br /></HeaderTemplate>
                <ItemTemplate>

                    <FormerWeb:PrevPromo runat="server" Id="PrevPromo" />
                   
                    
                </ItemTemplate>
                          </asp:Repeater>
                          <center><asp:Label ID="lblNoOfferte" runat="server" Font-Bold="true" Font-Size="Large"  Visible="false" Text="<br>Al momento non sono presenti Offerte e Promozioni"></asp:Label></center>
            </div>
        </div>
        <div id="tabs-2">
            <div class="offerte">
            <b> - Come funzionano le Offerte e Promozioni?</b><br />
                Inseriamo regolarmente delle Offerte e Promozioni su particolari prodotti che puoi trovare nella sezione <b>Offerte e Promozioni</b> in HomePage o nella tua Area Riservata, e che vengono evidenziate da una particolare etichetta nella lista delle Categorie<br /><br />
                <br /><center><img src="/img/guida/guidaOfferte.png" class="immagineContornata"/></center><br /><br />
            Per ogni ordine di uno dei prodotti in queste categorie, riceverai un <b>Coupon di Sconto</b> pari alla percentuale indicata nella promozione sul prossimo acquisto della stessa quantità dello stesso prodotto.<br /><br />
                <b> - Come utilizzare i Coupon di Sconto?</b><br />
                Per utilizzare i <b>Coupon di Sconto</b> ottenuti consulta la sezione <b>I tuoi Coupon di Sconto</b> nella tua area riservata <a href="/i-tuoi-coupon-di-sconto"><b class="orange">cliccando qui</b></a>
            </div>
        </div>
        </div>
    </div>


</asp:Content>
