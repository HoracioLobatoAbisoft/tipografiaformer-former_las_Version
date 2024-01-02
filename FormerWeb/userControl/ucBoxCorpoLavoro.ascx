<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucBoxCorpoLavoro.ascx.vb" Inherits="FormerWeb.ucBoxCorpoLavoro" %>
<%@ Import Namespace="FormerliB.FormerEnum" %>
<div class="BoxOrdBody">
    <%
        Dim NumeroRighe As Integer = 9

        If Ordine.ListinoBase.ShowLabelFogli() Then
            NumeroRighe += 1
        End If

        If Ordine.ListinoBase.FormatoProdotto.Orientabile = enSiNo.Si Then
            NumeroRighe +=1
        End If

        If Ordine.BoxLavorazioni.Count Then

            NumeroRighe += 1

        End If

        If Ordine.idcoupon Then
            NumeroRighe += 1
        End If

        %>
    <table>
        <tr>
            <td rowspan="<%=NumeroRighe%>" width="100" valign="top">
                <%If ShowSVG = False Then %>
                <img src='<%=FormerWeb.FormerWebApp.PathListinoImg%><%=Ordine.BoxImgRif%>' class="imgBox" />
                <%else %>
                <div class="imgBox">
                <%=GetImgFormatoSVG %>
                </div>
                <%End if %>
            </td>
            <td>Nome Ordini:</td>
            <td style="font-size:12px;"><b><%=Ordine.NomeLavoro%></b></td>
            <td rowspan="<%=NumeroRighe%>" width="150" align="center" valign="top" >
                <%If Ordine.IdOrdineWeb Then%>
                <b class="statoOrdineLabel" style='background-color:<%=Ordine.ColoreStatoHTML %>;<%=iif(ordine.omaggio=ensino.si,"color:white;","")%>'><%=Ordine.StatoStr %></b><br />
                
                    N° Ordine: <b><%=Ordine.NOrdineStr %></b><br />
                    <%If Ordine.AnteprimaWeb.Length Then%>
                        <a href="/ordini/<%=Ordine.IdOrdineWeb%>/<%=Ordine.AnteprimaWeb%>" data-lightbox="ord<%=Ordine.IdOrdineWeb%>"><img src="/ordini/<%=Ordine.IdOrdineWeb%>/<%=Ordine.AnteprimaWeb%>" class="anteprima" /></a>
                    <%Else%>
                        <img src="/img/NoAnteprima.png" class="imgBox" />
                    <%end if %>
                <br />
                <%end if %>

            </td>
        </tr>
        <tr>
           <td valign="top" width="80">Quantità:</td>
            <td><b><%=Ordine.QtaStr%></b></td>
        </tr>
        <tr>
           <td valign="top" width="80">Prodotto:</td>
            <td><b><%=Ordine.NomeProdotto%></b></td>
        </tr>
        <%If Ordine.ListinoBase.Preventivazione.IdReparto <> FormerLib.FormerEnum.enRepartoWeb.Ricamo Then%>
        <tr>
            <td>Dimensioni:</td>
            <td><b><%=Ordine.DimensioniStr%></b></td>
        </tr>
        <%end if %>
        <%If Ordine.ListinoBase.FormatoProdotto.Orientabile = enSiNo.Si Then%>
        <tr>
            <td>Orientamento:</td>
            <td><b><%=Ordine.OrientamentoSelezionatoStr%></b></td>
        </tr>
        <%end if %>
        <%If Ordine.ListinoBase.Preventivazione.IdReparto <> FormerLib.FormerEnum.enRepartoWeb.Ricamo Then%>
        <tr>
            <td>Supporto:</td>
            <td><b><%=Ordine.SupportoStr%></b></td>
        </tr>
        <%end if %>
        <tr>
            <td>Stampa:</td>
            <td><b><%=Ordine.ColoriStampaStr%></b></td>
        </tr>
        <%If Ordine.ListinoBase.ShowLabelFogli() Then%>
        <tr>
            <td><%=Ordine.ListinoBase.GetLabelFogli%></td>
            <td><b><%=Ordine.NFogliVisStr%><%=Ordine.ListinoBase.LabelCopertina%></b></td>
        </tr>
        <%end if %>
        <%If Ordine.BoxLavorazioni.Count Then%>
        <tr>
            <td  valign="top">Opzioni:</td>
            <td  valign="top"><ul><%
                    For Each SingLav As String In Ordine.BoxLavorazioni
                                             Response.Write("<li><b>" & SingLav & "</b></li>")
                    Next
                    %></ul></td>
        </tr>
        <%end if %>
        <%--<tr>
            <td>Imballo:</td>
            <td><b><%=Ordine.CorriereStr %></b></td>
        </tr>--%>
        <tr>
            <td valign="top">Imballo:</td>
            <td>Colli <b><%=Ordine.ColliStr %></b>, Peso <b><%=Ordine.PesoStr%></b> kg ±<%=IIf(Ordine.IdCoupon, "", "<br /><br />") %></td>
        </tr>
    <%--<tr>
            <td valign="top">Consegna</td>
            <td><b><%=Ordine.DataConsegnaStr%></b><br /><br /></td>
        </tr>--%>
        <%If Ordine.IdCoupon Then %>
        <tr>
            <td valign="top">Coupon:</td>
            <td><b style="color:red;">- € <% =Ordine.ImportoTotaleScontiStr %></b><br /><br /></td>
        </tr>
        <%End If%>

        <tr>
            <td></td>
            <td><%If Ordine.Omaggio <> enSiNo.Si Then %>
                <div class="tdPrezzo"><img src="/img/icoPrezzo.png" /> <b>€ <%=Ordine.ImportoNettoStr%> + iva</b></div> <%If Ordine.Promo Then %><b class="labelPromo">Promo <%=Ordine.Promo %> %</b><%End if%><br /><br />
                <%End If%>
            </td>
        </tr>
        
        <%If Ordine.NoteOrd.Length Then%>
        <tr>
            <td valign="top">Note</td>
            <td class="BloccoNoteLavoro"><%=Ordine.NoteOrd %></td>
        </tr>
        <%End If%>
    </table>
</div>