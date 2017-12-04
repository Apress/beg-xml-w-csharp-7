<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        &nbsp;</div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1" Font-Bold="True"
            Font-Size="Large">
        </asp:TreeView>
    </form>
</body>
</html>
