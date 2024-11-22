<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page2.aspx.cs" Inherits="WebApp.page2" %>

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
        input[type="submit"] { padding: 10px 20px; background-color: #4CAF50; color: white; border: none; cursor: pointer; font-size:14pt;font-weight:bold; }
        input[type="submit"]:hover { background-color: #45a049; }
        input[type="submit"]:disabled { background-color: darkgrey; cursor: not-allowed}
        input[type="text"], input[type="file"] {font-size: 18px;}
        span {font-size: 20px;}
        .warning { color: red; font-weight: bold; }
    </style>
    <script type="text/javascript">
        function disableButtons() {
            var buttons = document.querySelectorAll('input[type="submit"]');
            buttons.forEach(button => button.style.visibility = 'hidden');
        }
            var isDirty = false;

            function markAsDirty() {
                isDirty = true;
                document.getElementById('Label3').innerHTML = "<b style='color:red'>Є незбережені зміни</b>";
            }

            function warnIfUnsaved(event) {
                if (isDirty) {
                    document.getElementById('Label3').text = "";
            }
        }
            window.onload = function () {
                var inputs = document.querySelectorAll('input[type="text"], input[type="file"]');
                inputs.forEach(input => {
                    input.addEventListener('change', markAsDirty);
                });
        };

</script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Service Properties</h1>
    
    <div>
        <asp:Image ID="Icon" runat="server" /><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="IconLabel" runat="server" Text="Icon"></asp:Label><br />
        <asp:FileUpload ID="IconUpload" runat="server" />
        <br />
        <asp:Label ID="AddressLabel" runat="server" Text="TCP Service Address"></asp:Label><br />
        <asp:TextBox ID="AddresTextBox" runat="server" />
        <br />
        <asp:Label ID="PortLabel" runat="server" Text="TCP Port"></asp:Label><br />
        <asp:TextBox ID="PortTextBox" runat="server" />
        <br />
        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label><br />
        <asp:TextBox ID="EmailTextBox" runat="server" />
        <br />
        <asp:Button ID="SaveButton" runat="server" Text="Зберегти" OnClientClick="warnIfUnsaved(event)" OnClick="SaveButton_Click" />
        <asp:Button ID="BackButton" runat="server" Text="Назад" OnClientClick="disableButtons()" OnClick="BackButton_Click" />
        <asp:Button ID="CheckButton" runat="server" Text="Перевірити" OnClientClick="disableButtons()" OnClick="CheckButton_Click" />

    </div>
        <p>
        <asp:Label ID="Label3" runat="server"></asp:Label><br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
