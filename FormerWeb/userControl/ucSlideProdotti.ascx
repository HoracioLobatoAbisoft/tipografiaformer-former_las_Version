<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucSlideProdotti.ascx.vb" Inherits="FormerWeb.ucSlideProdotti" %>

<div id="jsCarousel">

    <asp:Repeater ID="rptProd" runat="server">

        <ItemTemplate>
            <div>
                <img src="<%=FormerWeb.FormerWebApp.PathListinoImg%><%#eval("GetImgFormato")%>" onclick="window.location.href='/<%#Eval("IdPrev")%>/<%#Eval("IdFormProd")%>/<%#Eval("IdTipoCarta")%>/<%#Eval("IdColoreStampa")%>/<%#eval("NomeInUrl")%>';return true;"/>
            </div>
        </ItemTemplate>
    </asp:Repeater>
  
</div>
