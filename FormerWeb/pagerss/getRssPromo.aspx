<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="getRssPromo.aspx.vb" Inherits="FormerWeb.pGetRssPromo" %><?xml version="1.0" encoding="UTF-8" ?>
<rss version="2.0" xmlns:content="http://purl.org/rss/1.0/modules/content/">
    <channel>
        <title>TipografiaFormer.it</title>
        <link>https://www.tipografiaformer.it/</link>
        <description>Ecco i prodotti in promo sul nostro sito</description>
        <pubDate><%=GetPubDate%></pubDate>
        <language>it</language>
        <asp:Repeater ID="rptPromo" runat="server">
    <ItemTemplate>
        <item>
            <title><%#Eval("Nome")%></title>
            <link>https://www.tipografiaformer.it/<%#FormerWeb.FormerUrlCreator.GetUrlLb(Eval("IdListinoBase")) %></link>
            <description><%#Eval("DescrSito")%></description>
            <content:encoded></content:encoded>
            <pubDate><%=GetPubDate%></pubDate>
        </item>
    </ItemTemplate>
</asp:Repeater>
    </channel>
</rss>