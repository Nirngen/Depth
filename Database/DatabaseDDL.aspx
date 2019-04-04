<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseDDL.aspx.cs" Inherits="Database.DatabaseDDL" %>

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
        请选择朝代<asp:DropDownList ID="ddlD" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <p>
            该朝代的年号列表<asp:DropDownList ID="ddlN" runat="server" Height="54px" OnSelectedIndexChanged="ddlN_SelectedIndexChanged">
        </asp:DropDownList>
        </p>
    </form>
</body>
</html>
