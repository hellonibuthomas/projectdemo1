<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="DemoProject.SendMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="ddlTemplate" runat="server">
            <asp:ListItem Value="Select">
                Select
            </asp:ListItem>
            <asp:ListItem Value="Template1">
                Template1
            </asp:ListItem>
            <asp:ListItem Value="Template2">
                Template1
            </asp:ListItem>
            <asp:ListItem Value="Template3">
                Template1
            </asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" OnClick="btnSendMail_Click" style="height: 26px" />
    </div>
    </form>
</body>
</html>
