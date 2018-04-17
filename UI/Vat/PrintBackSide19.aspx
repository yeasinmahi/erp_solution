<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintBackSide19.aspx.cs" Inherits="UI.Vat.PrintBackSide19" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function Print() {
            var dv = document.getElementById("report");
            dv.style.display = "block";
            dv = document.getElementById("btnprint");
            dv.style.display = "none";
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
    <style>
    table { border-collapse: collapse;  margin:auto; } 
    td { margin: 0px; padding: 1px; border:1px solid #080808; }
    .border { border: 1px solid #080808; }
    .noborders td { border:0; }
    </style>
</head>
<body>
    <form id="frmbacksidereturn19" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    <div id="report" runat="server" style="padding-top:5%;">&nbsp;</div>
    
        <%--<table border="0"><tr class="noborders"><td style="font-weight:bold"><img src="../Content/images/img/M19BackSide.PNG" /></td></tr></table>--%>
    
    </form>
</body>
</html>
