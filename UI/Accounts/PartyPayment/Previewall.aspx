<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Previewall.aspx.cs" Inherits="UI.Accounts.PartyPayment.Previewall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;  
    	    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            /*border: solid 1px #c0c0c0;*/
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
    </style>

    <script>
        function Print() {
            breakeveryheader();
            window.print();
            self.close();
        }
        function breakeveryheader() {
            var thestyle = "always";
            for (i = 1; i < document.getElementsByTagName("div").length; i++)
            document.getElementsByTagName("div")[i].style.pageBreakAfter = thestyle;
            document.getElementById("btnprint").style.display = "none";
        }
    </script>



</head>
<body>
    <form id="frmprevwall" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
        
    
    </form>
</body>
</html>
