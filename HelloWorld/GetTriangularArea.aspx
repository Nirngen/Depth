<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetTriangularArea.aspx.cs" Inherits="HelloWorld.GetTriangularArea" %>

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
        <p>
            <asp:Label ID="Label1" runat="server" Text="请输入三角形的边长"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求三角形的面积" />
        </p>
    </form>
</body>
</html>
