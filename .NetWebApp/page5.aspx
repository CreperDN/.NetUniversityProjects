<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page5.aspx.cs" Inherits="WebApp.page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebApp</title>
    <style>
        body { font-family: Arial, sans-serif; background-color: #f0f8ff; margin: 0; padding: 20px; color: #333; }
        h1 { color: #4CAF50; }
        table { width: 100%; border-collapse: collapse; margin: 20px 0; }
        th, td { border: 1px solid #ddd; padding: 12px; text-align: left; }
        th { background-color: #4CAF50; color: white; }
        input[type="submit"] { padding: 10px 20px; background-color: #4CAF50; color: white; border: none; cursor: pointer; font-size:24pt;font-weight:bold; }
        input[type="submit"]:hover { background-color: #45a049; }
        input[type="text"], input[type="file"] {font-size: 18px;}
        span {font-size: 20px;}
        .warning { color: red; font-weight: bold; }
    </style>
    <script type="text/javascript">
        function disableButtons() {
            var buttons = document.querySelectorAll('input[type="submit"]');
            buttons.forEach(button => button.style.visibility = 'hidden');
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <h1>Add New TCP Service</h1>
        <asp:Image ID="Icon" runat="server" /><br />
        <asp:Label ID="IconLabel" runat="server" Text="Service Icon"></asp:Label><br />
        <asp:FileUpload ID="IconUpload" runat="server" />
        <br />
        <asp:Label ID="AddressLabel" runat="server" Text="TCP Service Address"></asp:Label><br />
        <asp:TextBox ID="AddressTextBox" runat="server" />
        <br />
        <asp:Label ID="PortLabel" runat="server" Text="TCP Port"></asp:Label><br />
        <asp:TextBox ID="PortTextBox" runat="server" />
        <br />
        <asp:Label ID="EmailLabel" runat="server" Text="User Email"></asp:Label><br />
        <asp:TextBox ID="EmailTextBox" runat="server" />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClientClick="disableButtons()" OnClick="SaveButton_Click" />
        <asp:Button ID="BackButton" runat="server" Text="Back" OnClientClick="disableButtons()" OnClick="BackButton_Click" />
    </form>
</body>
</html>
<asp:Label ID = "Label2" runat="server"></asp:Label>
