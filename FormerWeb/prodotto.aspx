<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="prodotto.aspx.vb" Inherits="FormerWeb.pProdotto" enableEventValidation="false"%>
<%@ Register  TagPrefix="FormerWeb" TagName="AlberoPreventivazioni" Src="~/userControl/ucPreventivazioni.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="AggregateReviews" Src="~/userControl/ucAggregateReview.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="LBConsigliato" Src="~/userControl/ucLbConsigliato.ascx" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Review" Src="~/userControl/ucReview.ascx" %>
<%@ Import Namespace="Formerlib.formerenum" %>
<%@ Import Namespace="FormerLib" %>
<%@ Register  TagPrefix="FormerWeb" TagName="PrevPromo" Src="~/userControl/ucPrevPromo.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
    <meta property="og:image" content="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.GetImgFormato %>" />
    
    <style>
  .custom-combobox {
    position: relative;
    display: inline-block;
  }
  .custom-combobox-toggle {
    position: absolute;
    top: 0;
    bottom: 0;
    margin-left: -1px;
    padding: 0;
    /* support: IE7 */
    *height: 1.7em;
    *top: 0.1em;
  }
  .custom-combobox-input {
    margin: 0;
    padding: 0.3em;
  }
  </style>
       
  <script>
      (function ($) {
          $.widget("custom.combobox", {
              _create: function () {
                  this.wrapper = $("<span>")
                    .addClass("custom-combobox")
                    .insertAfter(this.element);

                  this.element.hide();
                  this._createAutocomplete();
                  this._createShowAllButton();
              },

              _createAutocomplete: function () {
                  var selected = this.element.children(":selected"),
                    value = selected.val() ? selected.text() : "";

                  this.input = $("<input>")
                    .appendTo(this.wrapper)
                    .val(value)
                    .attr("title", "")
                    .addClass("custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left")
                    .autocomplete({
                        delay: 0,
                        minLength: 0,
                        source: $.proxy(this, "_source")
                    })
                    .tooltip({
                        tooltipClass: "ui-state-highlight"
                    });

                  this._on(this.input, {
                      autocompleteselect: function (event, ui) {
                          ui.item.option.selected = true;
                          this._trigger("select", event, {
                              item: ui.item.option
                          });
                      },

                      autocompletechange: "_removeIfInvalid"
                  });
              },

              _createShowAllButton: function () {
                  var input = this.input,
                    wasOpen = false;

                  $("<a>")
                    .attr("tabIndex", -1)
                    .attr("title", "Mostra tutte le quantità")
                    .tooltip()
                    .appendTo(this.wrapper)
                    .button({
                        icons: {
                            primary: "ui-icon-triangle-1-s"
                        },
                        text: false
                    })
                    .removeClass("ui-corner-all")
                    .addClass("custom-combobox-toggle ui-corner-right")
                    .mousedown(function () {
                        wasOpen = input.autocomplete("widget").is(":visible");
                    })
                    .click(function () {
                        input.focus();

                        // Close if already visible
                        if (wasOpen) {
                            return;
                        }

                        // Pass empty string as value to search for, displaying all results
                        input.autocomplete("search", "");
                    });
              },

              _source: function (request, response) {
                  var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                  response(this.element.children("option").map(function () {
                      var text = $(this).text();
                      if (this.value && (!request.term || matcher.test(text)))
                          return {
                              label: text,
                              value: text,
                              option: this
                          };
                  }));
              },

              _removeIfInvalid: function (event, ui) {

                  // Selected an item, nothing to do
                  if (ui.item) {
                      return;
                  }

                  // Search for a match (case-insensitive)
                  var value = this.input.val(),
                    valueLowerCase = value.toLowerCase(),
                    valid = false;
                  this.element.children("option").each(function () {
                      if ($(this).text().toLowerCase() === valueLowerCase) {
                          this.selected = valid = true;
                          return false;
                      }
                  });

                  // Found a match, nothing to do
                  if (valid) {
                      return;
                  }

                  // Remove invalid value
                  this.input
                    .val("")
                    .attr("title", value + " non è un valore valido")
                    .tooltip("open");
                  this.element.val("");
                  this._delay(function () {
                      this.input.tooltip("close").attr("title", "");
                  }, 2500);
                  this.input.data("ui-autocomplete").term = "";
              },

              _destroy: function () {
                  this.wrapper.remove();
                  this.element.show();
              }
          });
      })(jQuery);

      $(function () {
          $("#combobox").combobox();
          $("#toggle").click(function () {
              $("#combobox").toggle();
          });
      });

        function intOnly(i)
        {
            if(i.value.length>0)
            {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
      }

    
  </script>

<script>

    //function SetCarrelloAlwaysOn() {
    //    var menu = $("#menuLaterale");
    //    var posizione = menu.offset();
    //    // "$(window).scrollTop()" ci dice di quanto abbiamo scrollato la pagina
    //    if ($(window).scrollTop() >= posizione.top) {//390){//
    //        // abbiamo scrollato oltre il div, dobbiamo bloccarlo
    //        menu.addClass("posizioneFissa");
    //    } else {
    //        // abbiamo scrollato verso l'alto, sopra il div, possiamo sbloccarlo
    //        menu.removeClass("posizioneFissa");
    //    }

    //}

    function CarrelloAlwaysOn() {

    $(function () {
        var menu = $("#menuLaterale");
        var posizione = menu.offset();
        
        // intercettiamo qui l'evento "scroll"                 
        $(window).scroll(function () {
            // "$(window).scrollTop()" ci dice di quanto abbiamo scrollato la pagina
            if ($(window).scrollTop() >= posizione.top) {//390){//
                // abbiamo scrollato oltre il div, dobbiamo bloccarlo
                menu.addClass("posizioneFissa");
            } else {
                // abbiamo scrollato verso l'alto, sopra il div, possiamo sbloccarlo
                menu.removeClass("posizioneFissa");
            }
        });
    });
    }

 $(document).ready(function() {
        localStorage['TableHeight'] = "410px";
        CarrelloAlwaysOn();
 });

    //$(document).on('keydown',"input.txtNumero[type=text]", function (e) {
    //    if (e.which === 13) {
            
    //        var self = $(this), form = self.parents('form:eq(0)'), focusable, next;
    //        focusable = form.find('input').filter(':visible');
    //        next = focusable.eq(focusable.index(this) + 1);
    //        if (next.length) {
    //            next.focus();
    //        }
    //        return false;
    //    }
    //});
    
</script>
     
<script lang="javascript">
    function incHeight() {
        var el = document.getElementById("divPrezzi");
        var lbl = document.getElementById("lblPrezziShower");
        var height = el.offsetHeight;

       

        if (height == 410)
        {
            el.style.height = 'auto';
            lbl.text = '▲ Mostra meno quantità ▲'
            localStorage['TableHeight'] = "auto";
        }
        else
        {
            el.style.height = '410px';
            lbl.text = '▼ Mostra più quantità ▼'
            localStorage['TableHeight'] = "410px";
        }
        
    }

    function setHeigthTable(){

        var el = document.getElementById("divPrezzi");
        el.style.height = localStorage['TableHeight'];

    }

    function SelectQTA() {
        document.getElementById("<%=txtQtaUser.ClientID%>").focus();
        document.getElementById("<%=txtQtaUser.ClientID%>").select();
    }

</script>    

    <script type="text/javascript">

        function MostraSlider() {
            $("#lightSlider").lightSlider({
                item: 1,
                autoWidth: false,
                slideMove: 1, // slidemove will be 1 if loop is true
                slideMargin: 10,

                addClass: '',
                mode: "slide",
                useCSS: true,
                cssEasing: 'ease', //'cubic-bezier(0.25, 0, 0.25, 1)',//
                easing: 'linear', //'for jquery animation',////

                speed: 400, //ms'
                auto: true,
                loop: true,
                slideEndAnimation: false,
                pause: 3000,

                keyPress: false,
                controls: true,
                prevHtml: '',
                nextHtml: '',

                rtl: true,
                adaptiveHeight: false,

                vertical: false,
                verticalHeight: 500,
                vThumbWidth: 100,

                thumbItem: 10,
                pager: true,
                gallery: false,
                galleryMargin: 5,
                thumbMargin: 5,
                currentPagerPosition: 'middle',

                enableTouch: true,
                enableDrag: true,
                freeMove: true,
                swipeThreshold: 40,

                responsive: [],

                onBeforeStart: function (el) { },
                onSliderLoad: function (el) { },
                onBeforeSlide: function (el) { },
                onAfterSlide: function (el) { },
                onBeforeNextSlide: function (el) { },
                onBeforePrevSlide: function (el) { }
            });

        }



        $(document).ready(function () {
            MostraSlider();
        });
    </script>

</asp:Content>

<asp:Content ID = "Content2" ContentPlaceHolderID="body" runat="server">

        <div class="colSx">
                <!--PREVENTIVAZIONI-->
                <FormerWeb:AlberoPreventivazioni id = "AlberoPreventivazioni" runat="server"/>
        </div>

    <asp:UpdatePanel ID = "PannelloDinamico" runat="server" UpdateMode="Conditional" >

        <ContentTemplate>

        <div id = "testo_seo" style="display:none;">
        <h1><%=OgTitle%></h1><p><%=OgDescriptionSEO%></p>
    </div>

    <!--STRUCTURED DATA-->
    <div style="display:none;" itemscope itemtype="https://schema.org/Product">
      <span itemprop="name"><%=OgTitle%></span>
      <span itemprop="category"><%=OgCategory%></span>
      <img itemprop="image" src="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.GetImgFormato %>" alt="<%=OgTitle%>" />
      <span itemprop="url">https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%></span><span itemprop="description"><%=OgDescription%></span><div itemprop="offers" itemscope itemtype="https://schema.org/Offer">
        <meta itemprop="priceCurrency" content="EUR" />
        <span itemprop="price"><%=PrimoPrezzo%></span>
        <div itemprop="seller" itemscope itemtype="https://schema.org/Organization">
            <span itemprop="name">Tipografia Former https://www.tipografiaformer.it</span>
            <span itemprop="url">https://www.tipografiaformer.it</span>
            <span itemprop="description">Tipografia Former Online, il tuo mondo della stampa a Roma - Stampa Offset, Stampa Digitale Grande Formato, Packaging Personalizzato, Ricamo, Etichette</span>
            <div itemprop="address" itemscope itemtype="https://schema.org/PostalAddress">
                <span itemprop="streetAddress">Via Cassia 2010 </span>
                <span itemprop="addressLocality">Roma</span>
                <span itemprop="postalCode">000123</span>
                <span itemprop="addressCountry">Italia</span>
            </div>
        </div>
      </div>
        <%If LRif.Reviews.Count Then %>
        <div itemprop="aggregateRating" itemscope itemtype="https://schema.org/AggregateRating">
          <span itemprop="ratingValue"><%=LRif.AggregateRatingStr%></span>  
          <span itemprop="bestRating">5</span> 
          <span itemprop="reviewCount"><%=LRif.Reviews.Count%></span> 
        </div>
        <%End If%>
    </div>
            <div class="colDx">
                <%If ShowFoto() Then%>
                <div class="introProdotto" style="height: 285px;max-height:285px;overflow:hidden;display:inline-block;" id="introProdH2">
                <ul id="lightSlider">
                <%=BufferFoto %>
                </ul>
                    <div class="introTesto"><%=LRif.Nome%></div>
                        <%If LRif.DescrSitoFormatted.Length Then%>
                                <div class="boxDescrBack">
                                <div class="boxDescr"><%=LRif.DescrSitoFormatted%></div></div>
                        <%end If %>     
                </div>
                <%else%>
                <div class="introProdotto" style="background:url('<%=GetImgTestata%>') no-repeat; background-size: 100%;" id="introProdH">
                                <div class="introTesto"><%=LRif.Nome%></div>
                        <%If LRif.DescrSitoFormatted.Length Then%>
                                <div class="boxDescrBack">
                                <div class="boxDescr"><%=LRif.DescrSitoFormatted%></div></div>
                        <%end If %>     
                </div>
                <%End If%>                
                <asp:Literal runat="server" ID="iframeRefactor" />
                <%If UtenteConnesso.IdUtente = 1684 Or UtenteConnesso.IdUtente = 3 Or UtenteConnesso.IdUtente = 292 Or UtenteConnesso.IdUtente = 38 Then %>
                    <div class="schedaProd"  hidden>
                <%Else%>
                    <div class="schedaProd"  >
                <%End If %>
                    <div class="preventivo">
                                    <h5>Configura il tuo Prodotto</h5>
                        <div class="riepilogo">
                            <%If ShowSVG = False Then %>
                            <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=GetImgFormato%>" class="imgFormato" />
                            <%else %>
                            <div class="imgFormato">
                            <%=GetImgFormatoSVG %>
                            </div>
                                <%end if %>
                            <table>
                                    <tr>
                                        <td class="cellaEtichetta"><%=EtichettaFormato %></td>
                                        <td class="cellaValore">
                                            <asp:DropDownList ID="ddlFormato" runat="server" Font-Size="14px" Width="300px" AutoPostBack="true"></asp:DropDownList><%If lrif.idGruppoLogico <> 0 Or LRif.AllowCustomSize = enSiNo.Si Then %>
                                            <br /><br />
                                            <asp:CheckBox ID="chkMisurePersonalizzate" AutoPostBack="true" runat="server" text="Inserisci misure personalizzate"/><br />
                                            <asp:Panel ID="pnlMisurePersonalizzate" runat="server" Visible="true">
                                                <table style="margin:0 auto 0 auto;border:0px solid black;width:90%;">
                                                    <tr>
                                                        <td >Base (mm)</td>
                                                        <td align="left"><asp:textBox runat="server" id="txtMisurePersBase"  FilterType="Numbers" Font-Size="14px" width="65px" MaxLength="4" AutoPostBack="false" Enabled="false" style="text-align:right;"  onkeydown = "return (event.keyCode!=13);"></asp:textBox></td>
                                                    </tr>
                                                     <tr>
                                                        <td >Altezza (mm)</td>
                                                        <td align="left"><asp:textBox runat="server" id="txtMisurePersAltezza" FilterType="Numbers" Font-Size="14px" width="65px" MaxLength="4" AutoPostBack="false" Enabled="false" style="text-align:right;" onkeydown = "return (event.keyCode!=13);"></asp:textBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" style="padding-top:10px;"><asp:LinkButton ID="lnkCalcolaFormatoPersonalizzato" Text="Conferma" runat="server" CssClass="pulsante120Green" style="vertical-align:bottom;"></asp:LinkButton><br /><br />
                                            <center><asp:label ID="lblMisurePersWrong" runat="server" Text="Le misure inserite non sono valide" Visible ="false" forecolor="red" Font-Bold="true"/></center></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            
                                            <%End if %></td>
                                        <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                             <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=GetImgFormato%>" class="imgSx" />
                                                <h4><%=GetFormatoProdotto %></h4>
                                                <%=LRif.FormatoProdotto.DescrizioneHTML%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%If ShowOrientamento() Then%>
                                    <tr><td class="cellaEtichetta">Orientamento</td>
                                        <td class="cellaValore">
                                            <asp:DropDownList runat="server" ID="ddlOrientamento" Font-Size="14px" Width="300px" ></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%End If%>
                                    <tr>
                                        <td class="cellaEtichetta"><%=TipoCarta%></td>
                                        <td class="cellaValore">
                                            <asp:DropDownList ID="ddlTipoCarta" runat="server" Font-Size="14px" Width="300px" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                             <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.TipoCarta.ImgRif%>" class="imgSx" />
                                                <h4><%=LRif.TipoCarta.Tipologia %></h4>
                                                <%=LRif.TipoCarta.DescrizioneHTML%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%If LRif.IdTipoCartaCop Then%>
                                    <tr>
                                    <td class="cellaEtichetta"><%=IIf(P.IdReparto= enRepartoWeb.StampaDigitale,"","Copertina")%></td>
                                    <td class="cellaValore">
                                    <%=LRif.TipoCartaCop.Tipologia%>
                                    </td>
                                        <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                             <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.TipoCartaCop.ImgRif%>" class="imgSx" />
                                                <h4><%=LRif.TipoCartaCop.Tipologia %></h4>
                                                <%=LRif.TipoCartaCop.DescrizioneHTML%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%end if %>
                                    <%If LRif.IdTipoCartaDorso Then%>
                                    <tr>
                                    <td class="cellaEtichetta"><%=IIf(P.IdReparto= enRepartoWeb.StampaDigitale,"","Sottoblocco")%></td>
                                    <td class="cellaValore"><%=LRif.TipoCartaDorso.Tipologia%></td>
                                        <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                             <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.TipoCartaDorso.ImgRif%>" class="imgSx" />
                                                <h4><%=LRif.TipoCartaDorso.Tipologia %></h4>
                                                <%=LRif.TipoCartaDorso.DescrizioneHTML%>
                                            </div>
                                        </td>
                                    </tr>
                                    <%end if%>
                                    <tr>
                                        <td class="cellaEtichetta">Colore di stampa</td>
                                        <td class="cellaValore">
                                            <asp:DropDownList ID="ddlColoreStampa" runat="server" Font-Size="14px" Width="300px" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                            <div class="hidden tooltiptext"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.ColoreStampa.imgrif%>" class="imgSx" />
                                        <h4><%=LRif.ColoreStampa.Descrizione%></h4>
                                        <%=LRif.ColoreStampa.Descrizione%>
                                    </div>
                                        </td>
                                    </tr>
                                    <%If LRif.ShowLabelFogli() Then%>
                                    <tr>
                                        <td class="cellaEtichetta"><%=LRif.GetLabelFogli%></td>
                                        <td class="cellaValore">
                                            <asp:DropDownList ID="ddlFogliPagine" runat="server" Font-Size="14px" Width="200px" AutoPostBack="true"></asp:DropDownList>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%end if %> 




                                <!-- QUI INSERISCO IL BLOCCO MISURE -->
           <%If ShowBloccomisure Then  %>
<tr>
                                                    <td class="cellaEtichetta">Base</td>
                                                    <td class="cellaValore" style="width:300px;"><asp:TextBox AutoPostBack="true" ID="txtLarghezza" MaxLength="4" Width="120px" runat="server" style="text-align:right;" onkeydown = "return (event.keyCode!=13);" onfocus="this.select();"></asp:TextBox> (<%=GetEtichettaMisure %>)
                                                        <asp:label ID="rfvTBase" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label></td>
                                                    <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                                     <div class="hidden tooltiptext">
                                                        <h4>Misure</h4>
                                                        <%If MostraInfoMisure() Then %>
                                                        Inserisci la <b>BASE (<%=getEtichettaMisure %>)</b> del formato che desideri realizzare. <%If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then %>
                                                            <br />Le dimensioni del foglio sono <b><%=LRif.FormatoProdotto.LarghezzaCm %></b> x <b><%=LRif.FormatoProdotto.LunghezzaCm %></b> (<%=getEtichettaMisure %>)
                                                        <%end if%>
                                                        <%else %>
                                                        La dimensione massima del lato corto del prodotto <b><%=GetLarghezzaMaxLato %> cm</b>. In caso si inseriscano dimensioni superiori il prodotto sarà diviso in pannelli con margine
                                                        <%end if %>
                                                    </div>
                                                </td>
                                                </tr>
                                                <%If ShowProfondita Then %>
                                                <tr>
                                                    <td class="cellaEtichetta">Profondità</td>
                                                    <td class="cellaValore" style="width:300px;"><asp:TextBox AutoPostBack="true" ID="txtProfondita" MaxLength="4" Width="120px" runat="server" style="text-align:right;" onfocus="this.select();" onkeydown = "return (event.keyCode!=13);"></asp:TextBox> (<%=GetEtichettaMisure %>)
                                                        <asp:label ID="rfvTProfondita" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label></td>
                                                    <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                                     <div class="hidden tooltiptext">
                                                        <h4>Misure</h4>
                                                        <%If MostraInfoMisure() Then %>
                                                        Inserisci la <b>PROFONDITA' (<%=getEtichettaMisure %>)</b> del formato che desideri realizzare. <%If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then %>
                                                            <br />Le dimensioni del foglio sono <b><%=LRif.FormatoProdotto.LarghezzaCm %></b> x <b><%=LRif.FormatoProdotto.LunghezzaCm %></b> (<%=getEtichettaMisure %>)
                                                        <%end if%>
                                                        <%else %>
                                                        La dimensione massima del lato corto del prodotto <b><%=GetLarghezzaMaxLato %> cm</b>. In caso si inseriscano dimensioni superiori il prodotto sarà diviso in pannelli con margine
                                                        <%end if %>
                                                    </div>
                                                </td>
                                                </tr>
                                                <%end if %>
                                                <tr>
                                                    <td class="cellaEtichetta">Altezza</td>
                                                    <td class="cellaValore" style="width:300px;"><asp:TextBox ID="txtAltezza" autopostback="true" MaxLength="4" Width="120px" runat="server" style="text-align:right;" onkeydown = "return (event.keyCode!=13);" onfocus="this.select();"></asp:TextBox> (<%=GetEtichettaMisure %>)
                                                        <asp:label ID="rfvTAltezza" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label></td>
                                                    <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                                     <div class="hidden tooltiptext">
                                                        <h4>Misure</h4>
                                                        <%If MostraInfoMisure() Then %>
                                                        Inserisci l' <b>ALTEZZA (<%=getEtichettaMisure %>)</b> del formato che desideri realizzare. <%If LRif.TipoPrezzo = enTipoPrezzo.SuFoglio Then %>
                                                            <br />Le dimensioni del foglio sono <b><%=LRif.FormatoProdotto.LarghezzaCm %></b> x <b><%=LRif.FormatoProdotto.LunghezzaCm %></b> (<%=getEtichettaMisure %>)
                                                        <%end if%>
                                                        <%else %>
                                                        La dimensione massima del lato corto del prodotto <b><%=GetLarghezzaMaxLato %> cm</b>. In caso si inseriscano dimensioni superiori il prodotto sarà diviso in pannelli con margine
                                                        <%end if %>
                                                    </div>
                                                </td>
                                                </tr>
                                                

                                            <%End If %>


                                <!--QUI SPOSTO IL BLOCCO QUANTITA -->
 <% If ShowMisureQta Then %>
<%If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.ComboBox Then %>
                                
                                    <tr>
                                        <td class="cellaEtichetta"><asp:Label ID="lblTipoQta" Font-Italic="false" runat="server" Text="Quantità" Font-Size="12px"></asp:Label></td>
                                        <td class="cellaValore"  Width="300px" >
                                        <asp:DropDownList runat="server" id="ddlQta" AutoPostBack="true" Font-Size="14px" ></asp:DropDownList>
	                                    <span class="annotazione"> (<%=QtaLimiteMin%>- <%=QtaLimiteMax%>)</span>
                                        </td>
                                        <td width="20px">
                                             <%If ShowCoupon() Then%>
                                            <img src="/img/icoMieiCoupon20.png" alt="Hai un Coupon di Sconto disponibile" class="hasTooltip " />
                                             <div class="hidden tooltiptext">
	                                            <img src="/img/icoMieiCoupon30.png" class="imgSx"  style="background-color:#f58220;"/>
	                                        <h4>Hai un Coupon di Sconto disponibile</h4>* Hai un Coupon di Sconto disponibile sull'acquisto di <b style="font-size:medium;"><%=QtaCoupon %> pezzi</b> <br /><br />
                                            </div>
                                            <%End If%>
                                        </td>
                                    </tr>    
<%End if%>

<%If ShowQtaCustom Then %> 

    <%If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.TextBox Then%>
                                
                                    <tr>
                                        <td class="cellaEtichetta"><asp:Label ID="Label1" Font-Italic="false" runat="server" Text="Quantità *" Font-Size="12px" Font-Bold="true"></asp:Label></td>
                                        <td class="cellaValore">
                                        <asp:textBox runat="server" id="txtQtaUser" AutoPostBack="True" Font-Size="14px" width="65px" MaxLength="6" onClick="SelectQTA();"  type="number" min="1"  ></asp:textBox>
	                                    <span class="annotazione"> (<%=QtaLimiteMin%>- <%=QtaLimiteMax%>) * inserisci la quantit&agrave; desiderata</span>
                                        </td>
                                        <td width="20px">
                                             <%If ShowCoupon() Then%>
                                            <img src="/img/icoMieiCoupon20.png" alt="Hai un Coupon di Sconto disponibile" class="hasTooltip " />
                                             <div class="hidden tooltiptext">
	                                            <img src="/img/icoMieiCoupon30.png" class="imgSx"  style="background-color:#f58220;"/>
	                                        <h4>Hai un Coupon di Sconto disponibile</h4>* Hai un Coupon di Sconto disponibile sull'acquisto di <b style="font-size:medium;"><%=QtaCoupon %> pezzi</b> <br /><br />
                                            </div>
                                            <%End If%>
                                        </td>
                                    </tr>
    <%Else %>
                                 <tr>
                                        <td class="cellaEtichetta"><asp:Label ID="lblQta" Font-Italic="false" runat="server" Text="Quantità *" Font-Size="12px" Font-Bold="true"></asp:Label></td>
                                        <td class="cellaValore" width="300px">                                       
                                            <asp:TextBox ID="txtQtaCustom" runat="server"  Font-Size="14px" width="170px" MaxLength="6" AutoPostBack="True"  onkeydown = "return (event.keyCode!=13);"  style="padding-left:10px;" onfocus="this.select();"></asp:TextBox>
<%--                                            <asp:LinkButton ID="btnCalcolaQtaCustom" Text="Calcola" runat="server" CssClass="pulsante120Green" style="vertical-align:bottom;"></asp:LinkButton>--%>
                                        </td>
                                        <td></td>
                                    </tr>
    <%end if %>

<%End if%>

<%End if%>
                                    <asp:Repeater ID="rptOpzioni" runat="server" >
                                        <HeaderTemplate>
                                 
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="cellaEtichetta"><%#IIf(Container.ItemIndex = 0, "Opzioni", "&nbsp;")%></td>
                                                <td class="cellaValore">
                                                <%#Eval("Descrizione")%>
                                                </td>
                                                <td align="center"><img src="/img/icoInfo20.png" class="hasTooltip"/>
                                                     <div class="hidden tooltiptext">
                                                    <img class="imgSx" src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("imgRif")%>" />
                                                    <h4><%#Eval("Descrizione")%></h4><%#Eval("DescrizioneEstesaEx")%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate></FooterTemplate>
                              
                                    </asp:Repeater>
                             </table>
                            <asp:Table id="tblDDL" runat="server" visible="false">

                            </asp:Table>
                        </div>
                                                                 
                        <%If ShowLavorazioniWithImg() Then%>
                                    <div class="riepilogo">
                                <%--    <%If ShowPiega() Then%>
                                            <div class="preventivoOpzioni">
                                                <h4>Scegli la Piega</h4>                                      
                                                <!--QUI GESTISCO LA PIEGA-->
                                                  
                                                <asp:RadioButtonList ID="rdoPiega" runat="server" 
                                                    AutoPostBack="true" 
                                                    CssClass="bloccoLav" 
                                                    RepeatLayout="Table" 
                                                    RepeatDirection="Horizontal" ></asp:RadioButtonList>
                                                  
                                        </div>
                                        <%End If%>--%>

                                        <div class="preventivoOpzioni">
                                            <!--QUI GESTISCO LE ALTRE LAVORAZIONI-->
                                         <asp:Table ID="tableLav" runat="server">

                                         </asp:Table>
                              
                                        </div>
                                    </div>
                                    <%End If %>

                        
                        <div class="riepilogo">
                            <%If ShowPulsanteCalcola() Then %>
                                <div style="text-align:center;  margin:20px 0 20px 0;"><asp:LinkButton ID="btnCalcola" Text="Calcola" runat="server" CssClass="pulsante120Green" style="vertical-align:bottom;"></asp:LinkButton></div>
                        <%end if %>
<asp:Panel ID="pnlErrore" Visible="false" runat="server">
                         <div style="text-align:center;font-weight:bold;color:red;text-transform:uppercase;padding:10px;">
                                Per ricevere un preventivo per le misure inserite contattarci telefonicamente<asp:Label ID="lblErroreMisure" ForeColor="red" runat="server"></asp:Label>
                         </div>
</asp:Panel>
<%If ShowFustelleSuggerite Then %>
<li><a href="<%=GetUrlFustellePresenti() %>" style="font-weight:bold;">CLICCA QUI</a> per consultare le fustelle già disponibili;</li>
<%End if %>               
<%If ShowQtaCustom Then %>
                                <li><i>* La quantità potrebbe essere arrotondata automaticamente per motivi tecnici;</i></li>
<%end if%>
<%If ShowSViluppo Then %>
<li>In base alle misure inserite il prodotto genera <asp:Label ID="lblInfoDim" runat="server" Font-Italic="true" Text="-" Font-Bold="true"></asp:Label>&nbsp;;</li>
<%End if%>
</div>
<div class="riepilogo">
<asp:RadioButtonList ID="rdoOpzioniPrezzo" CellPadding="8" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" style="float:right;">
    <asp:ListItem Text="CAD." Value="2"></asp:ListItem>
    <asp:ListItem Text="Senza IVA" Selected="True" Value="0"></asp:ListItem>
    <asp:ListItem Text="Con IVA" Value="1"></asp:ListItem>
</asp:RadioButtonList>
    <span style="float:right;padding:13px;">Visualizza prezzo&nbsp;</span>
</div>                            
                        

                                <div class="preventivoTot">
                                        <h5>Scegli la Data <%=LabelDataConsegna %></h5>
                                        <%If LRif.TipoControlloPrezzo <> enTipoControlloPrezzo.Tabella Then %>
                                        <div class="boxDataCons">  
                                        <asp:RadioButtonList ID="rdoQuando" CssClass="dataCons" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" ></asp:RadioButtonList>
                                        </div>
                                         <%else%>
                                    
                                        <div class="CtrTabellaPrezzi" id="divPrezzi" style='height:410px;'>

                                            <asp:Table ID="tblPrezzi" ViewStateMode="Enabled" EnableViewState="true" runat="server" CssClass="Tabella">
                                            </asp:Table>

                                        </div>
                                        <div class="linkEspandi">
                                            <a href="javascript:incHeight();" id="lblPrezziShower">&#9660 Mostra pi&ugrave; quantit&agrave; &#9660</a>
                                        </div>
                                        <%End if %>
                                    <div class="Totale" >
                                      
                                        <div class="labelPrezzo bkgGreen"> 

                                            <div style="margin-bottom:25px;text-align:right;">
                                                <div style="float:left;">
                                                <img src="/img/icoPrezzo.png" width="20" height="25"/>&nbsp;&nbsp;PREZZO <%=IIf(UtenteConnesso.Tipo <> enTipoRubrica.Cliente, "RISERVATO A: <font size=2><b>" & getNominativoUtente() & "</b></font>", "") %>
                                                </div>
                                                
                                            <asp:Label id="lblPrezzo" CssClass="prezzoRight" runat="server" Text="€ 0.00" Font-Italic="False" Font-Size="22px" Font-Bold="true"  ></asp:Label>
                                           <%-- <asp:Label ID="lblPrezzoValue" visible="false" runat="server" Text="0"></asp:Label>
                                            <asp:Label ID="lblIdMacchinarioProduzione" visible="false" runat="server" Text="0"></asp:Label>--%>
                                            </div>
                                            
                                             <%If ShowCouponIco() Then%>
                                             <div class="boxPrezzoConsigliato">* Utilizzando il <b>Coupon di Sconto <%=CouponConsigliato.Codice %></b> il prezzo sarà <b class="importoCoupon">€ <%=GetImportoSenzaCoupon %> + iva</b></div>
                                             <%end if %>

                                            <div class="boxPrezzoConsigliato"> 
                                            <div class="linkPreventivoPDF">
                                                    <asp:linkbutton id="lnkPreventivoPDF" runat="server"><img src="/img/icoFileTypePDF.png" /> <u>Preventivo PDF</u> &#8595;</asp:linkbutton>
                                            </div>
                                                <%If UtenteConnesso.Tipo <> enTipoRubrica.Cliente Then%>
                                                Prezzo consigliato al pubblico min. <asp:Label id="lblPrezzoConsigliato" runat="server" Text="€ 0.00" Font-Italic="False" Font-Bold="true"  Font-Size="12px" ></asp:Label> (+ grafica € <b><% = FormerHelper.Stringhe.FormattaPrezzo(P.GraficaPerFacciata)  %></b> a facciata)
                                            <%Else%>
                                                Se hai bisogno di realizzare la grafica al prezzo vanno aggiunti € <b><% = FormerHelper.Stringhe.FormattaPrezzo(P.GraficaPerFacciata)  %></b> a facciata
                                                <%End If %>
                                            </div>
                                            <%If ShowIcoDigitale() Then %>
                                            <div class="boxPrezzoConsigliato"><img src="/img/icoStampaInDigitale26.png" /> * Il prodotto verrà realizzato con tecnologia <b>Digital Print</b></div>
                                            <%End if %>                                        
                                        </div>

                                        <div class="boxTotSx grayed">
                                            
                                            <%If LRif.ExistPromo Then %>
                                            <img src="/img/icoPromo20.png" /> <b class="labPromo">Promo</b> Prodotto in promozione con sconto del <b class="labPromo"><%=LRif.Promo.Percentuale%>%</b> fino al <%=LRif.Promo.DataFineValidita.ToString("dd/MM/yyyy") %><br /><br />
                                            <%End If %>

                                            <%If P.PercCoupon Then%>
                                            <img src="/img/icoMieiCoupon20.png" /> <b class="percPromo">Coupon di Sconto</b> Acquistando ora riceverai un Coupon di Sconto netto di <b class="percPromo">€ <%=GetImportoCoupon %></b><br /><br />
                                            <%end if %>
                                            
                                            <img src="/img/icoCorriere20.png" /> <b>SPEDIZIONE:</b> Numero di colli indicativo <b><asp:Label ID="lblColli" runat="server" Text="1" ></asp:Label></b>
                                            , Peso indicativo <b><asp:Label ID="lblPeso" runat="server" Text="0"></asp:Label></b> kg &#177;
                                            <%If UtenteConnesso.Utente.IdCorriereDef <> FormerLib.FormerEnum.enTipoCorriere.Gratis Then %>
                                            , Costo <b style="font-size:12px;">€ <%=GetImportoSpedizioni %></b>
                                            <%end if %>
                                        </div>

                                        <div class="boxOpzOrd">

                                            <h4 class="hasTooltip">Dai un nome al lavoro</h4>
                                                <div class="hidden tooltiptext">
	                                                <img src="/img/icoInformation.png" class="imgSx" />
	                                            <h4>Dai un nome al lavoro</h4> Qui se vuoi puoi dare un nome a questo lavoro per trovarlo più agevolmente in seguito
                                                </div>
                                            <center>
                                                <asp:TextBox ID="txtNomeLavoro" runat="server" MaxLength="100" placeholder="Qui se vuoi puoi dare un nome a questo lavoro per riconoscerlo più agevolmente in seguito" Width="535" onkeydown = "return (event.keyCode!=13);"></asp:TextBox>
                                            </center>

                                            <br />
                                            <h4>Note</h4>    
                                                <center>
                                                <asp:TextBox ID="txtNote" MaxLength="255" placeholder="Qui puoi aggiungere note o indicazioni particolari riguardanti questo ordine"  TextMode="MultiLine"  Width="535" Height="35"  runat="server"></asp:TextBox>
                                                <asp:CheckBox ID="chkVerificaFile" Visible="false" Font-Size="11px" runat="server" Text="Un nostro operatore si occuperà di verificare i file che ci invierai e controllerà che siano stati creati correttamente " />
                                                </center>
                                        </div>
<%If GetSovrapprezzoInserimento Then %>
                                        <div class="boxTotSx SovrapprezzoInserimento" style="margin-top:10px;">
                                            <img src="/img/icoOperatore.png" /> <b style="color:black;">NOTA BENE</b><br />
                                            I prezzi indicati sono validi ESCLUSIVAMENTE per acquisti completati integralmente dal nostro sito internet. In caso di acquisto diretto presso la nostra sede, o di invio dei files tramite email, sarà applicato un sovrapprezzo per ogni lavoro di <b style="font-size:14px;color:black;"><%=GetSovrapprezzoInserimento %>,00 &euro;</b> per il caricamento dei files all'interno dei nostri sistemi.
                                        </div>
<%End if %>
                                        <div class="AggiungiCarrello">
                                            <div class="addToCart">
                                            <a runat="server" id="lnkAddCart" class="pulsante150Green" style="margin-top:0px;width:170px;"><img src="/img/icoCarrello.png" /> Aggiungi al Carrello</a><br />
                                               <hr/> oppure <hr/><br />
                                            <a runat="server" id="lnkCompra1Click" class="pulsante150Orange" style="width:170px;"><img src="/img/ico1Click.png" /> Compralo subito</a><br />
                                            </div>    
                                            
                                        </div>

                                    </div>
                                    </div>                                       
                                </div>
                              
                <FormerWeb:PrevPromo runat="server" Id="PrevPromo" visible="false"/>
            </div>

                <%If UtenteConnesso.IdUtente = 1684 Or UtenteConnesso.IdUtente = 3 Or UtenteConnesso.IdUtente = 292 Or UtenteConnesso.IdUtente = 38 Then %>
                    <div class="colonnaProd" hidden>
                <%Else%>
                    <div class="colonnaProd"  >
                <%End If %>
                   <%-- <div class="CorriereSchedaProd centered">
                        <h3>Corriere</h3>
                        <b>Scegli il tipo di consegna</b>
                        <asp:DropDownList CssClass="Combo" runat="server" id="ddlCorriere" AutoPostBack="true" Width="150"  Font-Size="11px" Font-Bold="True" Font-Names="Arial" ></asp:DropDownList>
                    </div>--%>
                    <div id="menuLaterale" >
                                            
                    <div class="CarrelloSchedaProd">
                        <h3>Riepilogo Carrello</h3>
                        <table>
                            <tr>
                                <td>
                                    Totale Netto
                                </td>
                                <td>
                                    <%=Carrello.TotaleImportiNettiStr%>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    Spedizioni 
                                </td>
                                <td>
                                    <%=Carrello.TotaleSpedizioniStr%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    IVA (<%=FormerWeb.FormerWebApp.GetPercIva %>%)
                                </td>
                                <td>
                                    <%=Carrello.TotaleIVAStr%>
                                </td>
                            </tr>
                          
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>TOTALE</b>
                                </td>
                                <td>
                                    <b><%=Carrello.TotaleCarrelloStr %></b>
                                </td>
                            </tr>
                        </table>
                    <center><a href="/carrello" class="pulsante150Green"><img src="/img/icoCarrello32.png" />Vai al Carrello</a><br /><br /></center>
                    </div>


                    <div class="LavoroSchedaProd">
                         <h3>Riepilogo Lavoro</h3>
                        <table>
                            <tr>
                                <td>
                                    <%=lblTipoQta.Text %>
                                </td>
                                <td>
                                    <b><%=LabelRiepilogoQta%></b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Consegna
                                </td>
                                <td>
                                    <b><%=LabelRiepilogoConsegna%></b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Prezzo Netto
                                </td>
                                <td>
                                    <b><%=LabelRiepilogoPrezzo%></b>
                                </td>
                            </tr>
                              <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <center><a runat="server" id="lnkAddCartRiepilogo" class="pulsante150Orange" style="margin-top:0px;"><img src="/img/ico1Click.png" /> COMPRALO SUBITO</a><br /><br /></center>
                    </div>
<%If AbilitaRichiestaPreventivo() Then %>
                    <div class="RichiediPrevSchedaProd">
                         <h3>Preventivo</h3>
                        <table>
                            <tr>
                                <td style="padding:5px;text-align:justify;">
                                    Hai bisogno di una <b>variante di questo prodotto</b>?<br /> (quantità non in elenco, misure differenti, opzioni aggiuntive, ecc...) 
                                </td>
                            </tr>
                              <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                        </table>
                        <center><a class="pulsante150Viola" style="margin-top:0px;" href="/<%=LRif.IdListinoBase  %>/richiedi-preventivo"><img src="/img/icoPrev24.png" /> RICHIEDI PREVENTIVO</a><br /><br /></center>
                    </div>
<%end if%>
                      <%If ShowTemplate() Then%>
                        <div class="InfoSchedaProd">
                        <h3>Info sul Prodotto</h3>
                        <center>
                        <%If ShowTemplate2D() Then%>
                            <a href="<%=GetTemplatePDF2D%>" target="_blank" class="pulsante150Blu" style="margin-top:5px;"><img src="/img/icoFileTypePdf.png" />Scarica Template</a>
                        <%End If
                            If ShowTemplate3D() Then%>
                            <% If 1=1 then 'FormerWeb.FormerWebApp.IsInternetExplorer Then%>
                                <a href="<%=FormerWeb.FormerWebApp.PathListinoTemplate%><%=LRif.FormatoProdotto.PdfTemplate3D%>" target="_blank" class="pulsante150Blu" style="margin-top:5px;"><img src="/img/ico3D.png" />Modello 3D</a>
                            <%Else%>
                                <asp:LinkButton ID="lnkDownloadModello3d" CssClass="pulsante150Blu" Style="margin-top:5px;" runat="server"><img src="/img/ico3D.png" />Modello 3D</asp:LinkButton>
                            <%End If%>
                        <%end if %>
                        <asp:LinkButton ID="lnkCampGrat" runat="server" CssClass="pulsante150Blu" Style="margin-top:5px;" ><img src="/img/icoCampGratuito.png" /> Campione Gratuito</asp:LinkButton>
                        </center>
                            <br />
                        </div>
                    <%End If%>                                 
                    <asp:Panel ID="pnlPromo" runat="server">
                        <div class="PromoSchedaProd">
                            <h3>OFFERTA - <%=P.PercCoupon  %> %</h3>
                            <h4><img src="/img/icoIMieiCouponlaterale.png" />- <%=P.PercCoupon  %> %</h4> * su questo prodotto&nbsp;
                        </div>
                    </asp:Panel>
                    </div>
                </div>
         
                 <%If MostraOmaggi() Then %>
                <div class="Omaggi" style="float: left;width: 560px;margin:10px 0px 30px 10px;">

                    <h3 style="margin-bottom:0px;background-color:#f1f1f1;"><img src="/img/_Omaggio.png" />&nbsp;&nbsp;ORDINANDO QUESTO PRODOTTO POTRAI SCEGLIERE UNO DEI SEGUENTI OMAGGI</h3><hr />
                
                    <asp:Repeater ID="rptOmaggi" runat="server">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td valign="top" align="center" rowspan="2"  align="center" ><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("GetImgFormato") %>" width="64" /></td>
                                    <td><b><%#Eval("Nome")%></b></td>
                                    <td rowspan="2" valign="center" align="center" width="150" ><asp:Panel ID="pnlInfoOmaggio" runat="server" Visible="true">
                                        <img src="/img/icoinfoomaggio.png" class="hasTooltip"/>
                                        <div class="hidden tooltiptext">
                                            <img src="/img/icoinfoomaggio.png" class="imgSx" />
                                            <h4><%#Eval("Nome")%></h4>
                                            <%#Eval("CondizioneStr")%>
                                        </div></asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="OmaggioCellaInfo"><i><%#Eval("DescrSito")%></i></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="2" class="OmaggioTdInfo">* <%#Eval("CondizioneStr")%></td>
                                </tr>
                            </table>
                        
                        </ItemTemplate>
                    </asp:Repeater>

                </div>
                 <%End If %>
                <%If UtenteConnesso.IdUtente = 1684 Or UtenteConnesso.IdUtente = 3 Or UtenteConnesso.IdUtente = 292 Or UtenteConnesso.IdUtente = 38 Then %>
                    <div class="suggestedProduct" id="sugestedProductHidden" hidden>
                <%Else%>
                    <div class="suggestedProduct" id="sugestedProductHidden" >
                <%End If %>
                <%--<div class="suggestedProduct">--%>
                    <h2>ALCUNI PRODOTTI SUGGERITI PER TE</h2>
                    <FormerWeb:LBConsigliato id="lbConsigliato" runat="server"/>
                    <FormerWeb:LBConsigliato id="lbConsigliato1" runat="server"/>
                    <FormerWeb:LBConsigliato id="lbConsigliato2" runat="server"/>
                </div>
                <%If UtenteConnesso.IdUtente = 1684 Or UtenteConnesso.IdUtente = 3 Or UtenteConnesso.IdUtente = 292 Or UtenteConnesso.IdUtente = 38 Then %>
                    <div class="reviewContainer" id="reviewContainerHidden " hidden>
                <%Else%>
                    <div class="reviewContainer" id="reviewContainerHidden " >
                <%End If %>
                <%--<div class="reviewContainer">--%>
                    <h2>RECENSIONI DEI CLIENTI DI QUESTO PRODOTTO</h2>
                    <table border="0" width="100%">
                        <tr>
                            <td align="left">
                    <FormerWeb:AggregateReviews id="AggregateReview" runat="server"/>
                            </td>
                            <td valign="top" align="center" width="170"><a href="/le-tue-recensioni" class="pulsante150Green"><img src="/img/icoRecensione.png" />Scrivi recensione</a></td>
                        </tr>
                    </table>
                                        
                    <asp:Repeater ID="rptReview"  runat="server">
                        <HeaderTemplate><h3>Le più recenti tra le recensioni dei clienti</h3></HeaderTemplate>
                        <ItemTemplate>
                            <FormerWeb:Review ID="SingReview" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            
                        </FooterTemplate>
                    </asp:Repeater>
    
                </div>  
                <%If UtenteConnesso.IdUtente = 1684 Or UtenteConnesso.IdUtente = 3 Or UtenteConnesso.IdUtente = 292 Or UtenteConnesso.IdUtente = 38 Then %>
                <div class="DescrizioneDinamica" hidden>
                <%Else %>
                <div class="DescrizioneDinamica" >
                <%End If%>
                    <h1><%=LRif.Nome%></h1>
                    <p><%=LRif.FormatoProdotto.DescrizioneEstesa  %></p>
                    <h2>Il <%=TipoCarta%> scelto è <%=LRif.TipoCarta.Tipologia %></h2>
                    <p><%=LRif.TipoCarta.DescrizioneEstesaEx  %></p>
                    <%=GetDescrizioneDinamicaLav %>
                </div>
                
            </div>  
                                         
            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" AssociatedUpdatePanelID="PannelloDinamico" runat="server">
                <ProgressTemplate>
                    <div class="progressW"><img src="/img/progress.gif" /></div> 
                </ProgressTemplate>
            </asp:UpdateProgress>          
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtQtaUser" EventName ="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlQta" EventName ="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="rdoQuando" EventName ="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtAltezza" EventName ="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtLarghezza" EventName ="TextChanged" />
    </Triggers>
 
</asp:UpdatePanel>
     
     <script type="text/javascript">

         function selectDefault() {

             <%If ShowLavorazioniWithImg() Then
             
             For Each singRDO As RadioButtonList In ListaRDO
             %>
             document.getElementById('<%=singRDO.ClientID%>_0').checked = true;
             <%
            Next
 
            End If%>

         }

      $(document).ready(function () {

          //CONTROLLO SE ESISTE PERCHE NON E' DETTO CHE CI SIA'

<%--          var x = document.getElementById('<%=rdoQuando.ClientID%>_<%=IdVoceDefaultQuando%>');
          
          if (x !== null) {
              x.checked = true;
          }
                    --%>
          selectDefault();
           
                 <%--    <%If ShowPiega() Then%>

                document.getElementById('<%=rdoPiega.ClientID%>_0').checked = true;

             <%End if%>--%>

                
             });
    </script>

         <%If MostraMessaggioPrezzo Then%>

     <div id="popupPrezzo" class="popup_block">
         
	    <img src="/img/logo.png" alt="Login" /><br /><br /><br /><br />

        Benvenuto Visitatore, <a href="/registrati" class="orange"><b>Registrati</b></a> o <a href="/login" class="orange"><b>Accedi</b></a><br />
         <br />
         oppure<br /><br /> <a href="#" class="orange close"><b>Continua la navigazione *</b></a> <br /><br />
         <p>* Ricorda che navigando nel sito senza effettuare il login i prezzi potrebbero non essere quelli a te riservati.</p>

     
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

                var popID = 'popupPrezzo';
                var popWidth = 500;

                $('#popupPrezzo').fadeIn().css({ 'width': Number(popWidth) }).prepend('<a href="#" class="close"><img src="/img/close_pop.png" class="btn_close" title="Chiudi Popup" alt="Chiudi Popup" /></a>');

                var popMargTop = ($('#popupPrezzo').height() + 80) / 2;
                var popMargLeft = ($('#popupPrezzo').width() + 80) / 2;

                $('#popupPrezzo').css({
                    'margin-top': -popMargTop,
                    'margin-left': -popMargLeft
                });

                $('body').append('<div id="fade"></div>');
                $('#fade').css({ 'filter': 'alpha(opacity=80)' }).fadeIn();

                $('a.close, #fade').click(function () {

                    $('#fade , .popup_block').fadeOut(function () {
                        $('#fade, a.close').remove();
                    });
                    return false;
                });
            });
        
    </script>
    
        <%  End If %>
<%--   
        <script type="text/javascript">
        
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(CarrelloAlwaysOn);

        </script>--%>



    <!-- Go to www.addthis.com/dashboard to customize your tools -->
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=lunadix"></script>
    
   
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="AfterForm" >
    <script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_endRequest(function (s, e) {
        //alert('Postback!');

        <%If LRif.TipoControlloPrezzo = enTipoControlloPrezzo.Tabella Then%>
            try {
                setHeigthTable();
            }
            catch (e) {
                // handle the unsavoriness if needed
            }

        <%  End If %>
        CarrelloAlwaysOn();
        MostraSlider();
    });

</script>

      
</asp:Content>