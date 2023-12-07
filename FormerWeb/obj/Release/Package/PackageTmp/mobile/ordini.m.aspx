<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/mobile/master/main.m.Master" CodeBehind="ordini.m.aspx.vb" Inherits="FormerWeb.ordini_m" %>
<%@ Register  TagPrefix="FormerWeb" TagName="HeaderLavoro" Src="~/userControl/ucBoxHeaderLavoro.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
    <asp:Repeater ID="rptCons" runat="server">

        <HeaderTemplate><fieldset></HeaderTemplate>
        <ItemTemplate>  
            <table>
                    <tr style="background-color:#d6e03d;">
                        <td colspan=2 align="center"><b>N° <%#Eval("IdConsegnaView")%> del <%#Eval("InseritoStr")%></b></td>
                        <td width="30"><img src="<%#Eval("IconaCorriere")%>" alt="<%#Eval("IconaCorriereAlt")%>" /></td>
                        <td width="200"><b><%#Eval("StatoStr")%></b></td>
                        <td width="120" align="right"><b><%#Eval("ImportoTotNettoStr")%>€ + iva</b></td>
                    </tr>
                
                    <asp:Repeater ID="rptOrdini" runat="server">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate><tr style="background-color:white;">
                            <td></td>
                            <td><div class="statoOrdineBox" title="<%#Eval("StatoStr")%>" style="background-color:<%#Eval("ColoreStatoHTML")%>;"></div></td>
                            <td colspan="2"><b><%#Eval("QtaStr")%> <%#Eval("BoxTitolo")%></b></td>
                            <td><b><%#Eval("StatoStr")%></b></td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </table>    

        </ItemTemplate>
        <FooterTemplate></FooterTemplate>

    </asp:Repeater>
    <div class="pager">Vai alla pagina <asp:PlaceHolder ID="plcPaging" runat="server" /> <asp:Label runat="server" ID="lblPageName"  /></div>
    </section>

</asp:Content>
