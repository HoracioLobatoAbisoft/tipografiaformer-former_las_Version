<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="faq.aspx.vb" Inherits="FormerWeb.pFaq" %>
<%@ Register  TagPrefix="FormerWeb" TagName="Contattaci" Src="~/userControl/ucContattaci.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

                   <script>
                       $(function () {
                           var availableTags = [
                            <%=BufferGlossario %>
                           ];
                           $("#<%=txtSearch.ClientID %>").autocomplete({
                               source: availableTags
                           });
                       });
                </script>

    <%If VaiAGlossario() Then%>

    <script type="text/javascript">
        $(function () {

            $("#tabs").tabs({ active: 2 });

        });
	</script>

    <%end if %>

    <%If VaiAFaq() Then%>

    <script type="text/javascript">
        $(function () {

            $("#tabs").tabs({ active: 1 });

        });
	</script>

    <%end if %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"/>--%>
    <div class="Faq">

         <div id="tabs">

                  <ul>
                    <li><a href="#tabs-3"><img src="/img/icoTel24.png" alt="Contattaci per ricevere assistenza" class="icoImg"/> Contattaci</a></li>
                    <li><a href="#tabs-1"><img src="/img/icoAssistenza16.png" alt="Domande e Risposte frequenti" class="icoImg"/> Domande e Risposte frequenti</a></li>
                    <li><a href="#tabs-2"><img src="/img/icoGlossario16.png" alt="Glossario Tipografico" class="icoImg"/> Glossario tipografico</a></li>
                  </ul>

             <div id="tabs-1">
         
            <h3><img src="/img/icoAssistenza64.png" border="0" />DOMANDE E RISPOSTE FREQUENTI</h3><br />

                 <script>

                    function FaqHelp() {

                   $(function () {
                        var icons = {
                            header: "ui-icon-plus",
                            activeHeader: "ui-icon-minus"
                        };
        
                        $(".accordionHelp").accordion({
                            icons: icons,
                            active: false,
                            collapsible: true,            
                            heightStyle: "content"
                        });
                    });

                    }

                    $(document).ready(function () {
                        FaqHelp();
                    });

 
                </script>
                  
                <asp:Repeater ID="rptArgomenti" runat="server">
                <ItemTemplate>
                <div class="argomentoAss">
                <h1><%#Eval("Titolo")%></h1>
                <h2><%#Eval("DescrizioneBreve")%></h2>
                <div class="accordionHelp">
                   <asp:Repeater ID="rptDomande" runat="server">
                        <ItemTemplate>
                        <h3><%#Eval("Domanda")%></h3>
                         <div><%#Eval("Risposta")%></div>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                </div>
                </ItemTemplate>
                </asp:Repeater>
                 </div>

             <div id="tabs-2">
                 
                 <h3><img src="/img/icoGlossario64.png" border="0" />GLOSSARIO TIPOGRAFICO</h3>
<div class="glossario">
    Benvenuti nel <b>Glossario Tipografico</b>! <br /><br />In questa sezione troverete un aiuto per comprendere le terminologie più utilizzate nel mondo della Tipografia. Vi basterà cercare una parola o parte di essa e otterrete tutti i termini corrispondenti con la relativa definizione.<br /><br /><br />
    <asp:Panel ID="pnlGloss" runat="server" DefaultButton="lnkCerca">
    <center>
                <asp:TextBox ID="txtSearch" clientidMode="static" placeholder="Scrivi qui quello che cerchi" Width="400" Font-Size="small" runat="server"></asp:TextBox><br />
                                    <br /><asp:linkbutton id="lnkCerca" runat="server" cssclass="pulsante120Orange" ><img src="/img/icoSearch32w.png" /> Cerca</asp:linkbutton><br /><br />
        <b>Attenzione! Si devono inserire almeno 3 caratteri per effettuare la ricerca</b>
        </center>
    <br />oppure scegli un iniziale per consultare tutti i termini che iniziano con quella lettera<br /><br />
    <center>
    <asp:LinkButton ID="lnkA" ForeColor="white" runat="server" Text="A" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkB" ForeColor="white" runat="server" Text="B" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkC" ForeColor="white" runat="server" Text="C" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkD" ForeColor="white" runat="server" Text="D" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkE" ForeColor="white" runat="server" Text="E" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkF" ForeColor="white" runat="server" Text="F" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkG" ForeColor="white" runat="server" Text="G" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkH" ForeColor="white" runat="server" Text="H" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkI" ForeColor="white" runat="server" Text="I" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkJ" ForeColor="white" runat="server" Text="J" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkK" ForeColor="white" runat="server" Text="K" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkL" ForeColor="white" runat="server" Text="L" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkM" ForeColor="white" runat="server" Text="M" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkN" ForeColor="white" runat="server" Text="N" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkO" ForeColor="white" runat="server" Text="O" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkP" ForeColor="white" runat="server" Text="P" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkQ" ForeColor="white" runat="server" Text="Q" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkR" ForeColor="white" runat="server" Text="R" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkS" ForeColor="white" runat="server" Text="S" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkT" ForeColor="white" runat="server" Text="T" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkU" ForeColor="white" runat="server" Text="U" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkV" ForeColor="white" runat="server" Text="V" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkW" ForeColor="white" runat="server" Text="W" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkX" ForeColor="white" runat="server" Text="X" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkY" ForeColor="white" runat="server" Text="Y" CssClass="glossLetter"></asp:LinkButton>
    <asp:LinkButton ID="lnkZ" ForeColor="white" runat="server" Text="Z" CssClass="glossLetter"></asp:LinkButton>
    </center>
                 <br /><br />
    <hr style="border:2px solid #f58220;width:80%;"/><br /><br />

                   <asp:UpdatePanel ID="PannelloDinamico"  runat="server" UpdateMode="Conditional">

                                <ContentTemplate>
                                    <center>
                           
                                   
                 <div id="inputText">
                 <asp:GridView ID="gridRis" runat="server" AutoGenerateColumns="False"
        ShowHeaderWhenEmpty="True" width="80%">                     
                    
                     <Columns>
                        <asp:BoundField  ItemStyle-Wrap="false" HeaderText="TERMINE" DataField="Termine"  ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Small" ItemStyle-Font-Bold="true"/>
                         <asp:BoundField  HeaderText="DEFINIZIONE" DataField="Definizione"  ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Size="Small" />
                         </Columns>

                 </asp:GridView>
                </div>
                </center>


                            <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" 
                                AssociatedUpdatePanelID="PannelloDinamico" runat="server">
                            <ProgressTemplate>
                               <div class="progressW"><img src="/img/progress.gif" /></div> 
                            </ProgressTemplate>
                            </asp:UpdateProgress>

                                </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="lnkCerca" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkA" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkB" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkC" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkD" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkE" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkF" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkG" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkH" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkI" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkJ" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkK" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkL" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkM" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkN" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkO" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkP" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkQ" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkR" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkS" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkT" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkU" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkV" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkW" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkX" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkY" EventName ="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="lnkZ" EventName ="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
        </asp:Panel>
                     </div>
                 </div>
              <div id="tabs-3">
                <!--CONTATTACI-->
                <FormerWeb:Contattaci id="ContattaciUC" runat="server"/>
            </div>
        </div>
   
        </div>


</asp:Content>
