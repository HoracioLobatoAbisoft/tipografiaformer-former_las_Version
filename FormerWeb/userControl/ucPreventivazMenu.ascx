<%@ Control Language="vb" 
    AutoEventWireup="false" 
    CodeBehind="ucPreventivazMenu.ascx.vb" 
    Inherits="FormerWeb.ucPreventivazMenu" %>
<%@ Import Namespace="FormerDALWeb" %>

<!--Menu Preventivazioni-->

 <script>

    
     $(function () {
         $("#menu").menu();
     });




  </script>

    <ul id="menu">
        <li class="mnuTitoloGenerale">I NOSTRI PRODOTTI</li>

        <%For Each P As PreventivazioneW In (New PreventivazioniWDAO).GetAll("Descrizione")%>

            <li class="mnuPreventivazione"><a href="/<%=P.IdPrev%>/<%=P.NomeInUrl%>"><%--
                <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=P.ImgRif%>" class="icoMenu"/>
                --%><b><%=P.Descrizione%></b></a></li>

            <%For Each F As FormatoProdottoW In (New FormatiProdottoWDAO).GetFormatiProdottoByPrev(P.IdPrev)%>
                <li class="mnuVoce"><a href="/<%=P.IdPrev%>/<%=F.IdFormProd%>/<%=P.NomeInUrl%>_<%=F.NomeInUrl%>"><%=F.Formato %></a>
                    <ul>
                     <%For Each T As TipoCartaW In (New TipiCartaWDAO).GetTipiCarta(P.IdPrev,F.IdFormProd )%>
                        <li class="sottovoci"><a href="/<%=P.IdPrev%>/<%=F.IdFormProd%>/<%=T.IdTipoCarta%>/<%=P.NomeInUrl%>_<%=F.NomeInUrl%>_<%=T.NomeInUrl%>"><%=T.Tipologia%></a>
                            <ul>
                               <%For Each C As ColoreStampaW In (New ColoriStampaWDAO).GetColoriStampa(P.IdPrev, F.IdFormProd,T.IdTipoCarta )%>
                                <li class="sottovoci"><a href="/<%=P.IdPrev%>/<%=F.IdFormProd%>/<%=T.IdTipoCarta%>/<%=C.IdColoreStampa%>/<%=P.NomeInUrl%>_<%=F.NomeInUrl%>_<%=T.NomeInUrl%>_<%=C.NomeInUrl%>"><%=C.Descrizione%></a>
                                <%Next %>
                            </ul>
                        </li>
                    <%Next %>
                    </ul>
                </li>
            <%Next %>
        <%Next %>

    </ul>

<img src="/img/BannerHome200.png" class="banner200" />
                 <!--I NOSTRI SERVIZI -->
<%--<div class="servizi">
    <h5>I NOSTRI SERVIZI</h5>
    <div class="row">
        <a href="#"><img src="/img/btnServiceGrafica.png" /> Ideazione e Realizzazione Grafica</a><br />
    </div>
    <div class="row">
        <a href="#"><img src="/img/btnServiceFustelle.png" /> Realizzazione Fustelle personalizzate</a><br />
    </div>
    <div class="row">
        <a href="#"><img src="/img/btnServiceRicamo.png" /> Ricamo su capo confezionato in 24 ore</a><br />
    </div>
    <div class="row">
        <a href="#"><img src="/img/btnServiceTaglioPannelli.png" /> Taglio pannelli a misura richiesta</a><br />
    </div>
</div>--%>