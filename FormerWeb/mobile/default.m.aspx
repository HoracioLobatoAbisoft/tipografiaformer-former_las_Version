<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mobile/master/main.m.Master" CodeBehind="default.m.aspx.vb" Inherits="FormerWeb.default_m" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<section>
		<div class="features">			
			<asp:Repeater ID="rptHome" runat="server" >

				<ItemTemplate>
					<article class="wizardObj">
						<div class="content">
						<a href="<%#Eval("Url")%>" class="image"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg %><%#Eval("Img")%>" alt="" />
						<h3><%#Eval("Descrizione")%></h3>
							<p><%#Eval("DescrizioneEstesa")%></p></a>
						</div>
					</article>
				</ItemTemplate>

			</asp:Repeater>
		</div>
	</section>

	<div class="bannerRecensioni">
		<a href="/recensioni"><h2><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /><img src="/img/icoRecensione.png" /> LE RECENSIONI DEI CLIENTI</h2>
		Scopri il parere di chi ha provato i nostri prodotti</a>
	</div>

</asp:Content>