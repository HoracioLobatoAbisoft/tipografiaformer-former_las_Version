<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mobile/master/main.m.Master" CodeBehind="prodotto.m.aspx.vb" Inherits="FormerWeb.prodotto_m" %>
<%@ Import Namespace="Formerlib.formerenum" %>
<%@ Import Namespace="FormerLib" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<meta property="og:title" content="<%=OgTitle%>" />
    <meta property="og:description" content="<%=OgDescription%>" />
    <meta property="og:url" content="https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%>" />
    <meta property="og:image" content="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.GetImgFormato %>" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID = "PannelloDinamico" runat="server" UpdateMode="Conditional" >

        <ContentTemplate>
	<div id = "testo_seo" style="display:none;">
        <h1><%=OgTitle%></h1><p><%=OgDescriptionSEO%></p>
    </div>
	<!--STRUCTURED DATA-->
    <div style="display:none;" itemscope itemtype="https://schema.org/Product">
      <span itemprop="name"><%=OgTitle%></span>
      <img itemprop="image" src="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%=LRif.GetImgFormato %>" alt="<%=OgTitle%>" />
      <span itemprop="url">https://www.tipografiaformer.it<%=Request.Url.AbsolutePath%></span>
        <span itemprop="description"><%=OgDescription%></span>
        <div itemprop="offers" itemscope itemtype="https://schema.org/Offer">
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
	<section>
		<div class="boxMobile">
			<img src="<%=GetImgTestata%>" class="image"/><span><%=LRif.DescrSitoFormatted%></span>
		</div>
		
		<asp:textBox runat="server" id="txtQtaUser" AutoPostBack="True" Font-Size="14px" MaxLength="6" FilterType="Numbers" Visible="false" ></asp:textBox>
	    <asp:DropDownList runat="server" id="ddlQta" AutoPostBack="true" Font-Size="14px" visible="false"></asp:DropDownList>                  

		
		<b><%=EtichettaFormato %></b><br /><asp:DropDownList ID="ddlFormato" runat="server" Font-Size="14px"  AutoPostBack="true"></asp:DropDownList>
		<b><%=TipoCarta %></b><br /><asp:DropDownList ID="ddlTipoCarta" runat="server" Font-Size="14px"  AutoPostBack="true"></asp:DropDownList>
		<b>Colore di stampa</b><br /><asp:DropDownList ID="ddlColoreStampa" runat="server" Font-Size="14px"  AutoPostBack="true"></asp:DropDownList>
		<%If LRif.ShowLabelFogli() Then%>
<b><%=LRif.GetLabelFogli%></b> <asp:DropDownList ID="ddlFogliPagine" runat="server" Font-Size="14px"  AutoPostBack="true"></asp:DropDownList>                                           
		<%end If %>

		<asp:Repeater ID="rptOpzioni" runat="server" >
			<HeaderTemplate>
				<br />
                        <table>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td class="cellaEtichetta"><%#IIf(Container.ItemIndex = 0, "<b>Opzioni</b>", "&nbsp;")%></td>
					<td class="cellaValore">
					<%#Eval("Descrizione")%>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>         
			</FooterTemplate>                              
		</asp:Repeater>
		<%If rptOpzioni.Items.Count = 0 And tblDDL.Rows.Count <> 0 Then %><b>Opzioni</b><%end if %>
		<asp:Table ID="tblDDL" runat="server"></asp:Table>

        <%If ShowBloccomisure Then %>
<asp:Panel ID="pnlMisure" runat="server">
                <h4>Inserisci le dimensioni</h4>
            <div class="boxMisure">
                <table>
                    <tr>
                        <td>
                        Base (<%=GetEtichettaMisure %>)
                        </td>
                        <td>
                            <asp:TextBox AutoPostBack="true" ID="txtLarghezza" MaxLength="4" Width="50" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox><asp:label ID="rfvTBase" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        Altezza (<%=GetEtichettaMisure %>)
                        </td>
                        <td>
                            <asp:TextBox AutoPostBack="true" ID="txtAltezza" MaxLength="4" Width="50" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox><asp:label ID="rfvTAltezza" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label>
                        </td>
                    </tr>
                    
                    <%If ShowProfondita Then %>
                    <tr>
                        <td>
                        Profondità (<%=GetEtichettaMisure %>)
                        </td>
                        <td>
                            <asp:TextBox AutoPostBack="true" ID="txtProfondita" MaxLength="4" Width="50" runat="server" onkeydown = "return (event.keyCode!=13);"></asp:TextBox><asp:label ID="rfvTProfondita" runat="server" Font-Size="Larger" Font-Bold="true" ForeColor="red" Visible="false" Text="*"></asp:label>
                        </td>
                    </tr>
                    <%End If%>
                </table>
                                               
            </div>
        </asp:Panel>

        <%end if%>

        <%If ShowQtaCustom Then %>
        <table>
        <tr>
        <td class="cellaEtichetta"><asp:Label ID="lblQta" Font-Italic="false" runat="server" Text="Quantità *" Font-Size="12px" Font-Bold="true"></asp:Label></td>
        <td class="cellaValore" width="300px">                                       
            <asp:TextBox ID="txtQtaCustom"  type="number" min="1" runat="server"  Font-Size="14px" width="170px" MaxLength="6" AutoPostBack="false"  onkeydown = "return (event.keyCode!=13);"  style="padding-left:10px;"></asp:TextBox>
        <%--                                            <asp:LinkButton ID="btnCalcolaQtaCustom" Text="Calcola" runat="server" CssClass="pulsante120Green" style="vertical-align:bottom;"></asp:LinkButton>--%>
        </td>
        <td></td>
        </tr>
        </table>
        <%End If%>	
        
        <%If ShowPulsanteCalcola() Then %>
<div class="riepilogo">
                                <div style="text-align:center;  margin:20px 0 20px 0;"><asp:Button ID="btnCalcola" Text="Calcola" runat="server" CssClass="pulsante120Green" style="vertical-align:bottom;"></asp:Button></div>
<asp:Panel ID="pnlErrore" Visible="false" runat="server">
                         <div style="text-align:center;font-weight:bold;color:red;text-transform:uppercase;padding:10px;">
                                Per ricevere un preventivo per le misure inserite contattarci telefonicamente              
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
        <%End If%>

		<asp:Table ID="tblPrezzi" ViewStateMode="Enabled" EnableViewState="true" runat="server" CssClass="Tabella">
		</asp:Table>
         </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="txtQtaUser" EventName ="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlQta" EventName ="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtAltezza" EventName ="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtLarghezza" EventName ="TextChanged" />
        <asp:AsyncPostBackTrigger ControlID="txtProfondita" EventName ="TextChanged" />
    </Triggers>
</asp:UpdatePanel>
		<br />Per concludere l'acquisto utilizzare la versione <b>DESKTOP</b> del portale<br /><br />

                <div class="DescrizioneDinamica">
                    <h1><%=LRif.Nome%></h1>
                    <p><%=LRif.FormatoProdotto.DescrizioneEstesa  %></p>
                    <h2>Il <%=TipoCarta%> scelto è <%=LRif.TipoCarta.Tipologia %></h2>
                    <p><%=LRif.TipoCarta.DescrizioneEstesaEx  %></p>
                    <%=GetDescrizioneDinamicaLav %>
                </div>

	</section>



</asp:Content>
