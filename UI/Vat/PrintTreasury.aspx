<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintTreasury.aspx.cs" Inherits="UI.Vat.PrintTreasury" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function Print() {
            var dv = document.getElementById("report");
            dv.style.display = "block";
            dv = document.getElementById("btnprint");
            dv.style.display = "none";
            window.print();
            self.close();
        }
    </script>
</head>
<body>
    <form id="frmprint" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    <div id="report" runat="server" style="padding-top:10%;"></div>
    </form>
</body>
</html>
