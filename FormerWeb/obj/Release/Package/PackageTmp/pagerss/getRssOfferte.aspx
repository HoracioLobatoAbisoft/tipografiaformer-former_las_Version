<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="getRssPreventivazioni.aspx.vb" Inherits="FormerWeb.pGetRssOfferte" %><?xml version="1.0" encoding="UTF-8" ?>
<rss version="2.0" xmlns:content="http://purl.org/rss/1.0/modules/content/">
    <channel>
        <title>TipografiaFormer.it</title>
        <link>https://www.tipografiaformer.it/</link>
        <description>Ecco i prodotti in vendita sul nostro sito</description>
        <pubDate><%=GetPubDate%></pubDate>
        <language>it</language>
        <asp:Repeater ID="rptPreventivazione" runat="server">
    <ItemTemplate>
        <item>
            <title><%#eval("Descrizione")%></title>
            <link>https://www.tipografiaformer.it/<%#Eval("IdPrev")%>/<%#eval("NomeInUrl")%></link><description><%#Eval("percCoupon")%>% - Per ogni acquisto di <%#eval("DescrizioneEstesa")%> riceverai automaticamente un Coupon di Sconto pari al <%#Eval("percCoupon")%>% dell'importo speso, utilizzabile sul successivo acquisto dello stesso prodotto.</description>
            <content:encoded></content:encoded>
            <pubDate><%=GetPubDate%></pubDate>
            <enclosure url="https://www.tipografiaformer.it<%=FormerWeb.FormerWebApp.PathListinoImg%><%#Eval("Imgrif")%>" length="" type="image/jpeg"></enclosure>
            <category><%#eval("RepartoStr")%></category>
        </item></ItemTemplate>
</asp:Repeater>
    </channel>
</rss>