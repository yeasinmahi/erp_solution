<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipleChequePrint.aspx.cs" Inherits="UI.Accounts.PartyPayment.MultipleChequePrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <style type="text/css">
    .dynamicDivbn { left: 38px;  width: 1001px; height: 283px; background-color:#FFFFFF; /*border: solid 1px #c0c0c0;*/
    font-size: 11px; font-family: verdana; color: #000; }
    </style>
    <script>
        function breakeveryheader() {
            var thestyle = "always";
            for (i = 1; i < document.getElementsByTagName("div").length; i++)
                document.getElementsByTagName("div")[i].style.pageBreakAfter = thestyle
            document.getElementById("btnPrint").style.display = "none";
        }
        function Print() {
            breakeveryheader();
            window.print(); self.close();
        }
    </script>
</head>
<body>
    <form id="frmchequeprint" runat="server">
    <asp:Button ID="btnPrint" runat="server" class="nextclick" style="font-size:11px;" Text="Click For Print" OnClientClick="Print()"/>
    </form>
</body>
</html>
