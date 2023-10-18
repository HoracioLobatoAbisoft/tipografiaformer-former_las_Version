<%@ Control Language="vb" 
    AutoEventWireup="false" 
    CodeBehind="ucPreventivazMenuEx.ascx.vb" 
    Inherits="FormerWeb.ucPreventivazMenu" %>
<%@ Import Namespace="FormerDALWeb" %>

<!--Menu Preventivazioni-->

 <script>


     $(function () {
         $("#accordion").accordion({
             heightStyle: "content",
             event: "click hoverintent"
         });

     });

     $(function () {
         $(".menu").menu();
     });

     /*
        * hoverIntent | Copyright 2011 Brian Cherne
        * http://cherne.net/brian/resources/jquery.hoverIntent.html
        * modified by the jQuery UI team
        */
     $.event.special.hoverintent = {
         setup: function () {
             $(this).bind("mouseover", jQuery.event.special.hoverintent.handler);
         },
         teardown: function () {
             $(this).unbind("mouseover", jQuery.event.special.hoverintent.handler);
         },
         handler: function (event) {
             var currentX, currentY, timeout,
               args = arguments,
               target = $(event.target),
               previousX = event.pageX,
               previousY = event.pageY;

             function track(event) {
                 currentX = event.pageX;
                 currentY = event.pageY;
             };

             function clear() {
                 target
                   .unbind("mousemove", track)
                   .unbind("mouseout", clear);
                 clearTimeout(timeout);
             }

             function handler() {
                 var prop,
                   orig = event;

                 if ((Math.abs(previousX - currentX) +
                     Math.abs(previousY - currentY)) < 7) {
                     clear();

                     event = $.Event("hoverintent");
                     for (prop in orig) {
                         if (!(prop in event)) {
                             event[prop] = orig[prop];
                         }
                     }
                     // Prevent accessing the original event since the new event
                     // is fired asynchronously and the old event is no longer
                     // usable (#6028)
                     delete event.originalEvent;

                     target.trigger(event);
                 } else {
                     previousX = currentX;
                     previousY = currentY;
                     timeout = setTimeout(handler, 100);
                 }
             }

             timeout = setTimeout(handler, 100);
             target.bind({
                 mousemove: track,
                 mouseout: clear
             });
         }
     };
  </script>
<h3 class="mnuTitoloGenerale">I NOSTRI PRODOTTI</h3>
<div id="accordion">
       <%For Each P As PreventivazioneW In (New PreventivazioniWDAO).GetAll("Descrizione")%>
        <h3><%=P.Descrizione%></h3>
      <div>
        <ul class="menu">
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
         </ul>
     </div>
        <%Next %>

 </div>
  
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