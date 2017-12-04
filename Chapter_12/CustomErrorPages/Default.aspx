<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Default.aspx" Font-Size="Large">Go To Admin Folder</asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/notexists.aspx" Font-Size="Large">Go To Non Existent File</asp:HyperLink><br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Font-Size="Large">Throw Exception</asp:LinkButton></div>
    </form>
</body>
</html>
