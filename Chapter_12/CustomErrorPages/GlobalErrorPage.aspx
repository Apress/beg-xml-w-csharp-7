<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GlobalErrorPage.aspx.cs" Inherits="GlobalErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Unexpected Error" Font-Size="Large"></asp:Label><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Font-Size="Large">Go Back</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
