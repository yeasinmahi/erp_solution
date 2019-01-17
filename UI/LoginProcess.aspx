<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.LoginProcess" CodeBehind="LoginProcess.aspx.cs" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <script type="text/javascript">

                alert('<%# RetStr %>');
                window.opener.ActiveLogInForm();
                self.close();
            </script>
        </asp:Panel>
    </form>
</body>
</html>