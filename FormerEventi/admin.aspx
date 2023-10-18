<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="admin.aspx.vb" Inherits="FormerEventi.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        P <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" ></asp:TextBox><br /><br />
        <asp:Button ID="btnOk" runat="server" Text="Ok" /><br /><br />

        N <asp:label ID="lblTot" runat="server"></asp:label><br /><br />

        <asp:GridView ID="grdDati" runat="server"></asp:GridView>

    </div>
    </form>
</body>
</html>
