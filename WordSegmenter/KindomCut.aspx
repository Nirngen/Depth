<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KindomCut.aspx.cs" Inherits="WordSegmenter.KindomCut" %>

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
        <asp:Label ID="Label1" runat="server" Text="请输入Resources下的文件名"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="将json文件命名为"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text=".json 生成至网站根目录（不填默认为story.json）"></asp:Label>
        </p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="输出词频" />
    </form>
</body>
</html>
