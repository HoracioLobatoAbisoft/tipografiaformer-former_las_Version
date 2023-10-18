<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="elencolavorazioni.aspx.vb" Inherits="FormerWeb.pElencoLavorazioni" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="preventivo">
        <br /><br /><img src="/img/lenostrelavorazioni.png" /><br /><br /><br /><br />
     <asp:Repeater ID="rptCatLav" runat="server">
        <ItemTemplate>
            <div class="catLav">
            <h4><img src="/img/icoLavOpz16.png" class="icosez"/><%#Eval("Descrizione")%></h4>
            <asp:Repeater ID="rptLav" runat="server">
                <ItemTemplate>
                    <div class="singolalav hasTooltip"><img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("ImgRif") %>" /></div>
                    <div class="hidden tooltiptext">
                        <img src="/img/icoInformation.png" class="imgSx" />
                        <h4><%#Eval("Descrizione")%></h4><%#Eval("DescrizioneEstesaEx")%>
                    </div>
                </ItemTemplate>                
            </asp:Repeater>
            </div>
        </ItemTemplate>

    </asp:Repeater>

    </div>
   
 
</asp:Content>
