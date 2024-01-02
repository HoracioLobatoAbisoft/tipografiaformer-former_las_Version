<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucBoxFooterLavoro.ascx.vb" Inherits="FormerWeb.ucBoxFooterLavoro" %>
<%@ Import Namespace="Formerlib.formerenum" %>

<div class="BoxOrdFooter">
    <hr />

    <%If Ordine.IdOrdineWeb Then%>
        <%If Ordine.StatoOrdine = enStatoOrdine.InAttesaAllegati And Ordine.Omaggio <> enSiNo.Si Then%>
            <a href="/<%=Ordine.IdOrdineWeb%>/dettaglio-lavoro"  class="pulsanteOperativoR"><img src="/img/icoAttach16.png"/> <b>INVIA I FILE</b></a>&nbsp;&nbsp;&nbsp;
        <%End If %>

    <%If Ordine.Omaggio<> enSiNo.Si then %>
        <a href="/<%=Ordine.IdOrdineWeb%>/dettaglio-lavoro" class="pulsanteOperativo"><img src="/img/icoFreccia16.png" /> Vai al Dettaglio Ordine</a>&nbsp;&nbsp;&nbsp;
    <%End if %>
        
    <%end if %>
    <%If Ordine.PathTemplate.Length And Ordine.Omaggio <> enSiNo.Si Then%>
                <a href="<%=FormerWeb.FormerWebApp.PathListinoTemplate%><%=Ordine.PathTemplate%>" target="_blank" class="pulsanteOperativo" ><img src="/img/icoInfo16.png" /> Scarica il Template</a>&nbsp;&nbsp;&nbsp;
    <%End If%>

    <%If Ordine.StatoOrdine < enStatoOrdine.Registrato Then%>
         <%If Ordine.IdOrdineWeb = 0 And Ordine.Omaggio <> enSiNo.Si Then%>
            <asp:LinkButton ID="lnkDelGo" CssClass="pulsanteOperativo" runat="server"  OnClientClick = "return confirm('Sicuro di voler eliminare questo Lavoro dal Carrello?');" ><img src="/img/icoCestinoGo16.png" />Elimina dal carrello e vai al Prodotto</asp:LinkButton>&nbsp;&nbsp;&nbsp;
         <%End If%>
        <%If (Ordine.IdOrdineInt = 0 And Ordine.Omaggio <> enSiNo.Si) Or (Ordine.IdOrdineWeb = 0 And Ordine.Omaggio = enSiNo.Si) Then%>
            <asp:LinkButton ID="lnkDelOrd" CssClass="pulsanteOperativo" runat="server" OnClientClick = "return confirm('Sicuro di voler eliminare questo Lavoro? Verrà modificato anche il relativo Ordine');"><img src="/img/icoCestino16.png" />Elimina <%If Ordine.IdOrdineWeb Then%>Ordine<%Else%>dal carrello<%end if %></asp:LinkButton>
        <%Else %>
            
        <%End If%>
    <%Else
            If Ordine.StatoOrdine >= enStatoOrdine.Registrato And Ordine.StatoOrdine <= enStatoOrdine.InCodaDiStampa Then
                
            End If
            %>    
    <%End If%>
</div>