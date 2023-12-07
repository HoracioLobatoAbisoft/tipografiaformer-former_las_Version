<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/home.master" CodeBehind="crearicamo.aspx.vb" Inherits="FormerWeb.pCreaRicamo" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Tavolozza" Src="~/userControl/ucTavolozzaColori.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br />
    <img src="/img/plugin/titoloRicamo.png" />
    <br /><br />

    <Formerweb:Tavolozza id="tavolozza" runat="server">

    </Formerweb:Tavolozza>


    <asp:FileUpload ID="uplImg" runat="server" />
    <br /><br />
    <asp:Button ID="btnElabora" runat="server" Text="Elabora" />
    <br /><br />
    
     <%=BufferSVG%>

    <script>
        <!--
        function testSVG()
        {
        
            var svg = document.getElementsByTagName('svg')[0];
            var kids = svg.childNodes;
            
            for (var i = 0, len = kids.length; i < len; ++i) {
                var kid = kids[i];
                if (kid.nodeType != 1) continue; // skip anything that isn't an element
                switch (kid.nodeName) {

                    case 'path':
                        if (kid.style['fill'] == '#ffff00')
                            kid.style['fill'] = "#ff0000"
                        
                        // ...
                        break;
                        // ...
                }
            }

        }



        //-->

    </script>

    <input type="button" value="Cambia Colore" onclick="testSVG();" />

</asp:Content>
