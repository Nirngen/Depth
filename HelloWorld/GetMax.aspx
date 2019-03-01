<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getMax.aspx.cs" Inherits="HelloWorld.GetMax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="请输入第一个数"></asp:Label>
        <asp:TextBox ID="txtNum1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="请输入第二个数"></asp:Label>
            <asp:TextBox ID="txtNum2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="请输入第三个数"></asp:Label>
            <asp:TextBox ID="txtNum3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求最大值" />
        </p>
    </form>
</body>
</html>
