﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolveP.aspx.cs" Inherits="HelloWorld.SolveP" %>

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
        <asp:DropDownList ID="ddl1" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddl2" runat="server">
        </asp:DropDownList>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="求素数" />
        </p>
    </form>
</body>
</html>
