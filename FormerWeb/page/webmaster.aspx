<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/reserved.Master" CodeBehind="webmaster.aspx.vb" Inherits="FormerWeb.pWebMaster" %>
<%@ Register  TagPrefix="FormerWeb" TagName="AdminPanel" Src="~/userControl/ucAdmin.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h3 class="orange">WebMaster</h3>
              
<FormerWeb:AdminPanel id="AdminPanel" runat="server"/>
    
</asp:Content>
