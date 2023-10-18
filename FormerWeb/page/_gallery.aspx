<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Home.Master" CodeBehind="_gallery.aspx.vb" Inherits="FormerWeb.pGallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="/scripts/freewall/freewall.js"></script>

     <style type="text/css">
    #container {
      
    }
    .item {
        background-color:red;
       border:5px solid  #2b2b2b ;
    }
  </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

  <div id="container">
      <asp:Repeater ID="rptImg" runat="server">
          <ItemTemplate>
              <div class="item" style="width:<%#Eval("Width")%>px; height:<%#Eval("Height")%>px;"><img src="<%#Eval("Url")%>" width="<%#Eval("Width")%>" height="<%#Eval("Height")%>" /></div>
          </ItemTemplate>
      </asp:Repeater>
  </div>
  <script>
    $(function() {
      var wall = new freewall("#container");
      wall.reset({
          selector: '.item',
          animate: true,
          cellW: 20,
          cellH: 200,
          onResize: function () {
              wall.fitWidth();
          }
      });
      wall.fitWidth();
        // for scroll bar appear;
      $(window).trigger("resize");
    });
  </script>

</asp:Content>
