<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xe10.aspx.cs" Inherits="HelloWorld.xe10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="txtSum" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求阶乘" />
        </p>
    </form>
</body>
</html>
