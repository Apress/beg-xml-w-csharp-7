<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnAuthorized.aspx.cs" Inherits="UnAuthorized" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="You are not allowed to access this page." Font-Size="Large"></asp:Label>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Font-Size="Large">Go Back</asp:HyperLink></div>
    </form>
</body>
</html>
