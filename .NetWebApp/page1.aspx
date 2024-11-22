<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="WebApp.page1" %>

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
        input[type="submit"] { padding: 10px 20px; background-color: #4CAF50; color: white; border: none; cursor: pointer; }
        input[type="submit"]:hover { background-color: #45a049; }
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
    <h1>МОЇ TCP-СЛУЖБИ<asp:Image ID="Image1" runat="server" />
        </h1>
    <asp:Table ID="TcpServiceTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>N</asp:TableHeaderCell>
            <asp:TableHeaderCell>АДРЕС</asp:TableHeaderCell>
            <asp:TableHeaderCell>ПОРТ</asp:TableHeaderCell>
            <asp:TableHeaderCell>ЛОГО</asp:TableHeaderCell>
            <asp:TableHeaderCell>ДАТА ПЕРЕВІРКИ</asp:TableHeaderCell>
            <asp:TableHeaderCell>РЕЗУЛЬТАТ</asp:TableHeaderCell>
            <asp:TableHeaderCell>ВЛАСТИВОСТІ</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Button style="font-size:24pt;font-weight:bold;" ID="NewServiceButton" runat="server" Text="NEW TCP SERVICE" OnClientClick="disableButtons()" OnClick="NewServiceButton_Click" />
    </form>
</body>
</html>
