<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                <td colspan="2" nowrap="nowrap">
                    <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="X-Large" Text="Contact Us"></asp:Label>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" nowrap="nowrap">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label2" runat="server" Text="Your Name :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic"
                        ErrorMessage="Please enter your name">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label3" runat="server" Text="Your Email :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic"
                        ErrorMessage="Please enter your email">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
                            Display="Dynamic" ErrorMessage="Please enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label4" runat="server" Text="Contacting For :"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="PS">Please select</asp:ListItem>
                        <asp:ListItem Value="SQ">Sales Quotation</asp:ListItem>
                        <asp:ListItem Value="TP">Technical Problem</asp:ListItem>
                        <asp:ListItem Value="O">Other</asp:ListItem>
                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="Please select a reason for contacting us"
                        InitialValue="PS">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label5" runat="server" Text="Subject :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Columns="37"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3" Display="Dynamic"
                        ErrorMessage="Please enter subject">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap" valign="top">
                    <asp:Label ID="Label6" runat="server" Text="Message :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Columns="30" Rows="3" TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4" Display="Dynamic"
                        ErrorMessage="Please enter message">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label7" runat="server" Text="Web Site (Optional) :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5"
                        Display="Dynamic" ErrorMessage="Please enter a valid URL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?">*</asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">
                    <asp:Label ID="Label8" runat="server" Text="You represent :"></asp:Label></td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="I">Individual</asp:ListItem>
                        <asp:ListItem Value="C">Company</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td align="center" colspan="2" nowrap="nowrap">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" nowrap="nowrap" style="height: 21px">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
