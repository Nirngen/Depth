<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SrtingOffset.aspx.cs" Inherits="HelloWorld.SrtingOffset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtStr" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" Text="左文本右位数" OnClick="Button1_Click" />
        </p>
    </form>
</body>
</html>
