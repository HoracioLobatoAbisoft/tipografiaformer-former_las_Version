<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/master/Main.Master" CodeBehind="contattaci.aspx.vb" Inherits="FormerWeb.pContattaci" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        
<script type="text/javascript" lang= "javascript">

    function registra() {
        var ris= false;
        var errbuff = '';

        if (document.aspnetForm.<%=txtemail.clientid%>.value != document.aspnetForm.<%=txtEmailCheck.clientid%>.value)
        {
            errbuff = errbuff + 'Le email inserite non corrispondono \n';
        }
        
        if (document.aspnetForm.<%=txtnome.clientid%>.value.length==0)
        {
            errbuff = errbuff + 'Il nominativo è obbligatorio \n';
        }

        if (document.aspnetForm.<%=txtoggetto.clientid%>.value.length==0)
        {
            errbuff = errbuff + 'Il campo oggetto è obbligatorio \n';
        }

        if (document.aspnetForm.<%=txtMessaggio.clientid%>.value.length==0)
        {
            errbuff = errbuff + 'Il campo messaggio è obbligatorio \n';
        }
        if (document.aspnetForm.<%=txtCap.clientid%>.value.length==0)
        {
            errbuff = errbuff + 'Il codice di controllo è obbligatorio \n';
        }

        if (document.aspnetForm.<%=txtemail.clientid%>.value.length==0)
        {
            errbuff = errbuff + 'L\'email è obbligatoria \n';
        }
    else{
        
            if (verifyEmail()==false){
            errbuff = errbuff + 'L\'email non è in formato valido \n';
        }
        
    }
      
    if (errbuff.length==0)
    {
        if (confirm('Confermi la registrazione della richiesta di assistenza?')) {

            var elem=document.getElementById("wait");
            elem.style.visibility="visible";

            ris= true;
        }           
    }
    else {
        alert(errbuff);            
    }

    return ris;
     
    }
    
    function verifyEmail(){
        var status = false;     
        var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
        if (document.aspnetForm.<%=txtemail.clientid%>.value.search(emailRegEx) != -1) {
        status = true;
    }
    return status;

}

function contattaci(){
     
    //var elem=document.getElementById("contattaci");
    //elem.style.visibility="visible";
    //elem.style.height="auto";
     
}
    
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div class="Faq">
            
<h3><img src="/img/icoAssistenza64.png" border="0" />ASSISTENZA CLIENTI</h3>

<table>
<tr>
<td>
Categoria<br />
<asp:ListBox ID="lstCat" runat="server" CssClass="ListaCatAss" Width="300" DataTextField="Titolo" DataValueField="IdArgomento" AutoPostBack="true">
</asp:ListBox>
</td>
<td>
Domanda<br />
<asp:ListBox ID="lstDom" runat="server" CssClass="ListaDomAss"  AutoPostBack="true"
DataTextField="Domanda" DataValueField="IDFAQ" Width="650">
</asp:ListBox>
</td>
</tr>
</table>
<br />    
    <asp:Label ID="lblDomanda" runat="server" Text="Seleziona una domanda tra quelle presenti" CssClass="PanelDomandaAss"></asp:Label><br />
    <asp:Panel ID="pnlRisp" runat="server" Visible="false" CssClass="PanelRispostaAss">
        <h3><asp:Label ID="lblRisp" runat="server" Text="-"></asp:Label></h3><br />
    </asp:Panel>
    <br />

    <asp:Panel ID="pnlContactus" runat="server" CssClass="PanelContactUsAss" DefaultButton="btnInvia">
  <p class="PanelDomandaAss">Se la risposta non ti soddisfa contattaci:</p>
<div id="contattaci">
<table border="0">
<tr>
<td width="200">Email <font size="1" color="#505050">(se sei già registrato utilizza lo stesso indirizzo email)</font></td>
<td><asp:TextBox  placeholder="Inserisci la tua mail" ID="txtEmail" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Email <font size="1" color="#505050">(Ripeti il tuo indirizzo email)</font></td>
<td><asp:TextBox placeholder="Riscrivi la tua mail" ID="txtEmailCheck" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Nome e Cognome</td>
<td><asp:TextBox placeholder="Inserisci il tuo Nome e Cognome" ID="txtNome" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Argomento</td>
<td><asp:DropDownList ID="ddlArgomento" runat="server" DataTextField="Titolo" DataValueField="Titolo"></asp:DropDownList></td>
</tr>
<tr>
<td>Numero Ordine <font size="1" color="#505050">(se la tua domanda è riferita a un ordine già effettuato indicaci il numero d'ordine)</font></td>
<td>
    <asp:TextBox placeholder="Indicati il numero di ordine se presente" ID="txtNumOrd" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Oggetto <font size="1" color="#505050">(fornisci una breve descrizione della richiesta)</font></td>
<td><asp:TextBox placeholder="Inserisci un titolo per questa richiesta" ID="txtOggetto" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td valign="top">Messaggio <font size="1" color="#505050">(specifica qui tutte le informazioni che possono aiutarci a rispondere in maniera esaustiva alla tua richiesta.)</font></td>
<td><asp:TextBox ID="txtMessaggio" placeholder="Inserisci qui una spiegazione dettagliata del problema, o delle informazioni di cui hai bisogno" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox></td>
</tr>
<tr>
<td>Allegato 1 (max 2Megabyte)</td>
<td>
    <asp:FileUpload ID="flAllegato1" runat="server" /></td>
</tr>
<tr>
<td>Allegato 2 (max 2Megabyte)</td>
<td>
    <asp:FileUpload ID="flAllegato2" runat="server" /></td>
</tr>
<tr>
<td valign="top">Codice controllo</td>
<td valign="top"><asp:TextBox ID="txtCap" runat="server" MaxLength="4" Width="40"></asp:TextBox> <asp:Image ID="imgCap" runat="server" ImageAlign="Top"  />
<h3>(Scrivi il codice numerico che leggi nell'immagine)</h3>
    </td>
</tr>
</table>
<br />
<center><asp:Button ID="btnInvia" runat="server" Text="Invia la tua domanda"  OnClientClick="return registra();" />
<br />
<div id="wait" style="visibility:hidden;">
           Stiamo completando la registrazione della richiesta di assistenza, attendere il messaggio di conferma <img src="/img/loading.gif" align="absmiddle" alt="wait" />
           </div></center>
</div><br />
    </asp:Panel>
</div>


</asp:Content>
