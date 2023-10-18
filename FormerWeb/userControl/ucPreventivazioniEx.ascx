<%@ Control Language="vb" 
    AutoEventWireup="false" 
    CodeBehind="ucPreventivazioniEx.ascx.vb" 
    Inherits="FormerWeb.ucPreventivazioniEx" %>
 <script>


     $(function () {
         $("#accordion").accordion({
             heightStyle: "content"
         });

     });

     
  </script>

            <!--ALBERO PREVENTIVAZIONI-->
                
                <div class="treeview">
                    <h5>I NOSTRI PRODOTTI</h5>
                     
                <asp:Repeater ID="rptPreventivazione" runat="server">                   
                    <HeaderTemplate><div class="tvwViolet"><%=Server.HtmlEncode("•")%> Stampa Offset</div>
                        <div id="accordion"></HeaderTemplate>
                    <ItemTemplate>
                        <h3><%#eval("Descrizione")%></h3>
                        <div>                       
                         <asp:GridView 
                             BorderWidth="0" 
                             ID="gvwListinoBase" 
                             runat="server" 
                             AutoGenerateColumns="False" 
                             ShowHeader="false"
                             CssClass="treeviewTable">
                        <Columns>
                        <asp:HyperLinkField 
                            DataNavigateUrlFields="IdPrev,IdFormProd,IdTipoCarta,IdColoreStampa,NomeInUrl"
                            DataNavigateUrlFormatString="~/{0}/{1}/{2}/{3}/{4}" 
                            DataTextField="Nome" 
                            ControlStyle-Width="165px"
                            ControlStyle-CssClass="treeviewRow1"/>
                        <asp:HyperLinkField 
                            DataNavigateUrlFields="IdPrev,IdFormProd,IdTipoCarta,IdColoreStampa,NomeInUrl"
                            DataNavigateUrlFormatString="~/{0}/{1}/{2}/{3}/{4}"  
                            Text=">"
                            ControlStyle-Width="15px"
                            ControlStyle-CssClass="treeviewLink" />
                        </Columns>
                        </asp:GridView>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate></div><%--chiusura DIV ACCORDION--%></FooterTemplate>
                </asp:Repeater>
                <%If ShowDigitale() Then%>
                    <p class="tvwBlu"><%=Server.HtmlEncode("•")%> Stampa Digitale</p>
                <%end if %>
                
                <%If ShowRicamo() Then%>
                    <div class="tvwGreen"><%=Server.HtmlEncode("•")%> Ricamo</div>
                <%end if %>
                <%If ShowPackaging() Then%>
                    <div class="tvwOrange"><%=Server.HtmlEncode("•")%> Packaging</div>
                <%end if %>
                </div>
<center>
               <a href="/dal-vecchio-al-nuovo-sito"><img src="/img/dalvecchioalnuovo.png" class="imgNeutraSpaced" /></a>
               <a href="/suggerimenti-per-inviarci-i-file"><img src="/img/btnHomeInvioFile.png" class="imgNeutra" /></a>
                <a href="/assistenza-clienti"><img src="/img/btnHomeGlossario.png" class="imgNeutraSpaced" /></a>           
                
                <a href="/le-nostre-lavorazioni"><img src="/img/btnHomeLavorazioni.png" class="imgNeutra" /></a>
                <a href="/assistenza-clienti"><img src="/img/btnHomeAssistenza.png" class="imgNeutraSpaced" /></a>
               
               <a href="http://www.google.com/chrome/" target="_blank"><img src="/img/btnHomeBrowser.png" class="imgNeutra" /></a>
               <a href="http://www.gls-italy.com/" target="_blank"><img src="/img/btnHomeShipping.png" class="imgNeutraSpaced" /></a>
               <%-- <img src="/img/BannerHome200.png" class="banner200" />--%>
                <%--<a href="#"><img src="/img/btnHomeRitiro.png" border="0" class="imgSx"/></a>
                <a href="#"><img src="/img/btnHomeShipping.png" border="0" class="imgSx" style="margin-top:5px;" /></a>--%>
</center>  

<%If TabIndexMenu Then%>
<script>
    $(function () {

        $("#accordion").accordion('option', 'active', <%=TabIndexMenu%>);

    });

</script>

<%end if %>