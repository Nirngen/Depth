
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExampleCrawLink.aspx.cs" Inherits="ProjectCrawler.ExampleCrawLink" %>



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

        <asp:Label ID="Label2" runat="server" Text="目标贴吧"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label1" runat="server" Text="关键词"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="页数"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="爬取词频" />
        </p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="爬取超链接" />

    </form>

</body>

</html>