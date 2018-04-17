<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintM17.aspx.cs" Inherits="UI.Vat.PrintM17" %>

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
    <form id="frmsalesregister" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    <div id="report" runat="server" style="padding-top:5%;"></div>
    
    <%--<table border='1' style='text-align:center; font:bold 9px verdana;'> 
    <tr style='border:1px solid #000''><td colspan='19' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
    <tr><td colspan='19' style='text-align:right;font-size:11px;'>Musok-17</td></tr>
    <tr><td colspan='19' style='font-size:11px;'>Sales Register</td></tr>

    <tr><td style='width:50px;' rowspan='2'>SL</td><td style='width:85px;' rowspan='2'>Date</td><td colspan='2'>Opening Balance Of Material</td><td colspan='2'>Production</td>
        <td colspan='3'>Purchaser / Customer</td><td colspan='2'>Challan</td>
        <td colspan='5'>Material Purchase</td><td colspan='2'>Closing Balance Of Material</td><td style='width:50px;' rowspan='2'>Remarks</td></tr>

    <tr><td style='width:100px;'>Quantity</td><td style='width:100px;'>Value</td><td style='width:100px;'>Quantity</td>
    <td style='width:85px;'>Value</td><td style='width:300px;'>Name</td><td style='width:150px;'>Reg No</td><td style='width:100px;'>Address</td><td style='width:155px;'>No</td>
    <td style='width:50px;'>Date & Time</td><td style='width:85px;'>Description</td><td style='width:75px;'>Quantity</td><td style='width:50px;'>SD Chargeable Price</td><td style='width:85px;'>SD</td>
    <td style='width:85px;'>Vat</td><td style='width:85px;'>Quantity</td><td style='width:85px;'>Value</td></tr>

    <tr><td style='width:50px;'>1</td><td style='width:85px;'>2</td><td style='width:100px;'>3</td><td style='width:100px;'>4</td><td style='width:100px;'>5</td>
    <td style='width:85px;'>6</td><td style='width:300px;'>7</td><td style='width:150px;'>8</td><td style='width:100px;'>9</td><td style='width:155px;'>10</td>
    <td style='width:50px;'>11</td><td style='width:85px;'>12</td><td style='width:75px;'>13</td><td style='width:50px;'>14</td><td style='width:85px;'>15</td>
    <td style='width:85px;'>16</td><td style='width:85px;'>17</td><td style='width:85px;'>18</td><td style='width:50px;'>19</td></tr>
    </table>--%>
    </form>
</body>
</html>
