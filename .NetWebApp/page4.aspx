<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page4.aspx.cs" Inherits="WebApp.page4" %>

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
        input[type="submit"] { padding: 10px 20px; background-color: #4CAF50; color: white; border: none; cursor: pointer;font-size:24pt;font-weight:bold; }
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
        <h1>Service Status</h1>
        <asp:Label ID="VerificationStatusLabel" runat="server" Text="Підтверджуємо пошту..." />
        <br />
        <asp:Label ID="ServiceStatusLabel" runat="server" />
        <br />
        <asp:Button ID="HomeButton" runat="server" Text="На головну" OnClientClick="disableButtons()" OnClick="HomeButton_Click" />
    </form>
</body>
</html>
