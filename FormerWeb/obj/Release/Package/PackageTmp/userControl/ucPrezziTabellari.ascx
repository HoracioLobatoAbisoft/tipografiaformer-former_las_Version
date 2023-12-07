<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucPrezziTabellari.ascx.vb" Inherits="FormerWeb.ucPrezziTabellari" %>
<script lang="javascript">
    function incHeight() {
        var el = document.getElementById("divPrezzi");
        var lbl = document.getElementById("lblPrezzi");
        var height = el.offsetHeight;

        if (height == 52)
        {
            el.style.height = 'auto';
            lbl.text ='Mostra meno'

        }
        else
        {
            el.style.height = '50px';
            lbl.text = 'Mostra più'
        }
        
    }
</script>

