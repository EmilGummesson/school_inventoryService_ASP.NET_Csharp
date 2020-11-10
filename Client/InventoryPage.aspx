<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryPage.aspx.cs" Inherits="Client.InventoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Table ID="ProductTable" runat="server">
        </asp:Table>
        
        </div>
        
        
        <asp:Button ID="OrderButton" runat="server" Text="Order" OnClick="OrderButton_Click"/>
        <asp:Label ID="Label2" runat="server" Text="Type in products to oder and press button labeled 'order'"></asp:Label>
        
    </form>
    </body>
</html>
