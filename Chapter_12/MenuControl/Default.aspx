<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Navigation.xml"></asp:XmlDataSource>
    
    </div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" DataSourceID="XmlDataSource1"
            DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Verdana" Font-Size="Large"
            ForeColor="#666666" StaticSubMenuIndent="10px">
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuStyle BackColor="#E3EAEB" />
            <StaticSelectedStyle BackColor="#1C5E55" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DataBindings>
                <asp:MenuItemBinding DataMember="node" NavigateUrlField="url" TextField="text" />
                <asp:MenuItemBinding DataMember="node" NavigateUrlField="url" TextField="text" />
                <asp:MenuItemBinding DataMember="node" NavigateUrlField="url" TextField="text" />
            </DataBindings>
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
        </asp:Menu>
    </form>
</body>
</html>
