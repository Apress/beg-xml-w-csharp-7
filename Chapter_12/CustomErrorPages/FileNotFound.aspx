<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileNotFound.aspx.cs" Inherits="FileNotFound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="The page you are looking for doesn't exist." Font-Size="Large"></asp:Label><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" Font-Size="Large">Go Back</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
