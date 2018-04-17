<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintM16.aspx.cs" Inherits="UI.Vat.PrintM16" %>

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
    <form id="frmpurchaseregister" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    <div id="report" runat="server" style="padding-top:5%;"></div>
    
    <%--<table border='.2' style='text-align:center; font:bold 9px verdana;'> 
    <tr style="border:1px solid #000"><td colspan='19' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
    <tr><td colspan='19' style='text-align:right;font-size:11px;'>Musok-16</td></tr>
    <tr><td colspan='19' style='font-size:11px;'>Purchase Register</td></tr>

    <tr style="border:1px solid #000"><td rowspan='3'>SL</td><td rowspan='3'>Date</td><td colspan='2' rowspan='2'>Opening Balance Of Material</td><td colspan='12'>Material Purchase</td><td colspan='2' rowspan='2'>Closing Balance Of Material</td><td rowspan='3'>Remarks</td></tr>
    <tr><td rowspan='2'>Challan/BEO Number</td><td rowspan='2'>Date</td><td colspan='3'>Seller / Suplier</td><td rowspan='2'>Description</td>
    <td rowspan='2'>Quantity</td><td rowspan='2'>Value(Without SD & Vat)</td><td rowspan='2'>SD (if any)</td><td rowspan='2'>VAT</td><td colspan='2'>Use In Production</td></tr>
    <tr><td>Quantity</td><td>Value</td><td>Name</td><td>Address</td><td>Reg No</td><td>Quantity</td><td>Value</td><td>Quantity</td><td>Value</td></tr>
    <tr><td style='width:50px;'>1</td><td style='width:85px;'>2</td><td style='width:100px;'>3</td><td style='width:100px;'>4</td><td style='width:100px;'>5</td>
    <td style='width:85px;'>6</td><td style='width:300px;'>7</td><td style='width:150px;'>8</td><td style='width:100px;'>9</td><td style='width:155px;'>10</td>
    <td style='width:50px;'>11</td><td style='width:85px;'>12</td><td style='width:75px;'>13</td><td style='width:50px;'>14</td><td style='width:85px;'>15</td>
    <td style='width:85px;'>16</td><td style='width:85px;'>17</td><td style='width:85px;'>18</td><td style='width:50px;'>19</td></tr>
    </table>--%>


    </form>
</body>
</html>
