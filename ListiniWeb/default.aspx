<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/listini.Master" CodeBehind="default.aspx.vb" Inherits="FormerListiniWeb._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="singPage">

    <table border="0" width="100%" >
        <tr>
            <td align=center width="50%">
                <img src="/img/home.jpg"/>
            </td>
            <td class="annuncioHome">
                <a href="/area-riservata" style="color:#009ec9;"><b>Crea Online</b> <br />il tuo listino<br />con i nostri prodotti</b></a>
            </td>
        </tr>
    </table>
    <table border="0" width="100%" cellpadding="0" cellspacing="0">
        <tr style="background-color:#f4f5f5;">
            <td class="imgstepTd"></td>
            <td class="imgstepTd">
                <img src="/img/unlock.png" />
            </td>
            <td class="stepTd" style="color:black;"><b>1) Registrati e Accedi</b><br />
                Registrati come rivenditore sul nostro sito e accedi alla tua area riservata
            </td>
        </tr>
        <tr>
            <td class="imgstepTd"></td>
            <td class="imgstepTd">
                <img src="/img/process.png" />
            </td>
            <td class="stepTd" style="color:black;"><b>2) Inserisci i parametri</b><br />
                Inserisci i parametri utilizzati dal nostro sistema con cui verr&agrave; realizzato il tuo listino personalizzato
            </td>
        </tr>
        <tr style="background-color:#f4f5f5;">
            <td class="imgstepTd"></td>
            <td class="imgstepTd">
                <img src="/img/pdf.png" />
            </td>
            <td class="stepTd" style="color:black;"><b>3) Scarica il tuo Listino</b><br />
                Scarica il tuo listino personalizzato in formato PDF
            </td>
        </tr>

    </table>
        <div style="padding:20px; text-align:right; margin-top:40px;">
            (*) Il servizio è riservato ai Rivenditori registrati sul nostro sito <a style="font-weight:bold;color:#f58220;" href="http://www.tipografiaformer.it">www.tipografiaformer.it</a>
        </div>
       
    </div>
    
</asp:Content>
