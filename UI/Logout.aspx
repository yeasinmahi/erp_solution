<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Logout" Codebehind="Logout.aspx.cs" %>

<!DOCTYPE html>
<html  >
<head runat="server">
    <title>Welcome to Akij Group</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/js") %>
    </asp:PlaceHolder>   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <script type="text/javascript">
        window.top.location="Exit.aspx";        
    </script>
    </asp:Panel>   
    </form>

</body>
</html>

