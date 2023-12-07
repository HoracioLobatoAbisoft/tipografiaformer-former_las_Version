<%@ Control Language="vb" 
    AutoEventWireup="false" 
    CodeBehind="ucPreventivazioni.ascx.vb" 
    Inherits="FormerWeb.ucPreventivazioni" 
    %>

            <!--ALBERO PREVENTIVAZIONI-->
                <div class="treeview" id="divHidden">
                    <!--OFFERTE-->
                    <%If FormerWeb.FormerWebApp.MostraPromo Then %>
                    <a href="/promo"><div class="tvwPromo"><img src="/img/icoPromo16w.png" /> PRODOTTI IN PROMO</div></a>
                    <%End if %>
                    <%If ShowOfferte Then%>
                    <a href="/offerte-e-promozioni-in-corso"><div class="tvwOfferte"><img src="/img/icoOfferte16w.png" /> OFFERTE</div></a>
                <asp:Repeater ID="rptOfferte" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>"  ><div class="treeviewitem bkgOfferte">
                        <%#eval("Descrizione")%> <b class="percPromo">-<%#Eval("PercCoupon")%>%</b>
                        </div></a>
                    </ItemTemplate>
                </asp:Repeater>
                    <%End If%>

                    <%If FormerWeb.FormerWebApp.MostraCatVirtuali = FormerLib.FormerEnum.enSiNo.Si Then %>
                    <a href="/"><div class="tvwCatVirtuali"><img src="/img/icoEvidenza16w.png" /> IN EVIDENZA</div></a>
                    <asp:Repeater ID="rptCatVirtuali" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="/in-evidenza/<%#Eval("IdCatVirtuale")%>/<%#Eval("NomeInUrl")%>" title="<%#Eval("Nome")%>"  ><div class="treeviewitem bkgOfferte">
                        <%#Eval("Nome")%>
                        </div></a>
                    </ItemTemplate>
                </asp:Repeater>
                    
                    <%End if %>

                    <%--<h5>I NOSTRI PRODOTTI</h5>--%>
                <a href="/stampa-offset"><div class="tvwViolet"><img src="/img/icoOffset16w.png" /> STAMPA OFFSET</div></a>
                <asp:Repeater ID="rptPreventivazione" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>" ><div class="treeviewitem <%#GetClassSelectedItem(Eval("IdPrev"))%>">
                        <%#eval("Descrizione")%> <%# If(Eval("Aggiornata") = True, " <img src=""/img/new.gif"">", "")%> 
                        </div></a>
                        <asp:Repeater ID="rptListiniBase" runat="server">
                            <ItemTemplate>
                                <a href="<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %>" title="<%#Eval("DescrizioneAlberoFPEstesa")%>"><div class="treeViewItemListinoBase">
                                <img src="/img/icoSelected.png" /> <%#Eval("DescrizioneAlberoFP")%>
                                </div></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>

                <%If ShowPackaging() Then%>
                    <a href="/packaging"><div class="tvwOrange"><img src="/img/icoPackaging16w.png" /> PACKAGING</div></a>
                      <asp:Repeater ID="rptPackaging" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>"  ><div class="treeviewitem">
                        <%#eval("Descrizione")%>
                        </div></a>
                        <asp:Repeater ID="rptListiniBase" runat="server">
                            <ItemTemplate>
                                <a href="<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %>" title="<%#Eval("DescrizioneAlberoFPEstesa")%>"><div class="treeViewItemListinoBase">
                                <img src="/img/icoSelected.png" /> <%#Eval("DescrizioneAlberoFP")%>
                                </div></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                    
                <%end if %>
                <%If ShowDigitale() Then%>
                    <a href="/stampa-digitale"><div class="tvwBlu"><img src="/img/icoDigitale16w.png" /> STAMPA DIGITALE</div></a>
                      <asp:Repeater ID="rptDigitale" runat="server">
                   
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>"  ><div class="treeviewitem">
                        <%#eval("Descrizione")%> <%# If(Eval("Aggiornata")= True , " <img src=""/img/new.gif"">", "")%> 
                        </div></a>
                        <asp:Repeater ID="rptListiniBase" runat="server">
                            <ItemTemplate>
                                <a href="<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %>" title="<%#Eval("DescrizioneAlberoFPEstesa")%>"><div class="treeViewItemListinoBase">
                                <img src="/img/icoSelected.png" /> <%#Eval("DescrizioneAlberoFP")%>
                                </div></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                   
                <%end if %>
                
                <%If ShowRicamo() Then%>
                    <a href="/ricamo"><div class="tvwGreen"><img src="/img/icoRicamo16W.png" /> RICAMO</div></a>
                      <asp:Repeater ID="rptRicamo" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>"  ><div class="treeviewitem">
                        <%#eval("Descrizione")%> <%# If(Eval("Aggiornata")= True , " <img src=""/img/new.gif"">", "")%> 
                        </div></a>
                        <asp:Repeater ID="rptListiniBase" runat="server">
                            <ItemTemplate>
                                <a href="<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %>" title="<%#Eval("DescrizioneAlberoFPEstesa")%>"><div class="treeViewItemListinoBase">
                                <img src="/img/icoSelected.png" /> <%#Eval("DescrizioneAlberoFP")%>
                                </div></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                    
                <%end if %>



                <%If ShowEtichette() Then%>
                    <a href="/etichette"><div class="tvwLightRed"><img src="/img/icoEtichette16w.png" /> ETICHETTE</div></a>
                      <asp:Repeater ID="rptEtichette" runat="server">
                   
                    <HeaderTemplate>
                       
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#FormerWeb.FormerUrlCreator.GetUrl(Eval("IdPrev"))%>" title="<%#Eval("DescrizioneEstesa")%>"  ><div class="treeviewitem">
                        <%#eval("Descrizione")%>
                        </div></a>
                        <asp:Repeater ID="rptListiniBase" runat="server">
                            <ItemTemplate>
                                <a href="<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %>" title="<%#Eval("DescrizioneAlberoFPEstesa")%>"><div class="treeViewItemListinoBase">
                                <img src="/img/icoSelected.png" /> <%#Eval("DescrizioneAlberoFP")%>
                                </div></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:Repeater>
                    
                <%end if %>
                </div>
<center id="divHidden2">
                <%--<a href="/diventa-rivenditore"><img src="/img/imgBusinessCli.png" width="185"  class="immagineContornata"/></a>--%>
                <%--<a href="/dal-vecchio-al-nuovo-sito"><img src="/img/dalvecchioalnuovo.png" class="imgNeutraSpaced" /></a>    --%>       
                <a href="/la-nostra-azienda"><img src="/img/btnLaNostraAzienda.png" class="imgNeutra" /></a>
                <a href="/suggerimenti-per-inviarci-i-file"><img src="/img/btnHomeInvioFile.png" class="imgNeutraSpaced" /></a>
                <a href="/glossario-tipografico"><img src="/img/btnHomeGlossario.png" class="imgNeutra" /></a>           
                
                <a href="/le-nostre-lavorazioni"><img src="/img/btnHomeLavorazioni.png" class="imgNeutraSpaced" /></a>
                <%--<a href="/i-tipi-di-carta"><img src="/img/btnHomeCarta.png" class="imgNeutraSpaced" /></a>--%>
                <a href="/assistenza-clienti"><img src="/img/btnHomeAssistenza.png" class="imgNeutra" /></a>
    
                <%--<a href="http://www.google.com/chrome/" target="_blank"><img src="/img/btnHomeBrowser.png" class="imgNeutraSpaced" /></a>--%>
               
               <%-- <img src="/img/BannerHome200.png" class="banner200" />--%>
                <%--<a href="#"><img src="/img/btnHomeRitiro.png" border="0" class="imgSx"/></a>
                <a href="#"><img src="/img/btnHomeShipping.png" border="0" class="imgSx" style="margin-top:5px;" /></a>--%>
</center>  
