<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintM18.aspx.cs" Inherits="UI.Vat.PrintM18" %>

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
    <form id="frmcurrentregister" runat="server">
    <a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a>
    <div id="report" runat="server" style="padding-top:5%;"></div>
    
    <%--<table border='1' style='text-align:center; font:bold 9px verdana;'> 
    <tr><td colspan='10' style='font-size:10px;'>Government Of Peoples Republic Of Bangladesh <br /> National Board Of Revenue, Dhaka</td></tr>
    <tr><td colspan='10' style='text-align:right;font-size:11px;'>Musok-18</td></tr>
    <tr><td colspan='10' style='font-size:11px;'>Current Register</td></tr>
    <tr style='text-align:left;'><td colspan='3' style='text-align:right;'>VAT Registration No. : </td><td colspan='7'>-------</td></tr>
    <tr style='text-align:left;'><td colspan='3' style='text-align:right;'>Name : </td><td colspan='7'>-------</td></tr>
    <tr style='text-align:left;'><td colspan='3' style='text-align:right;'>Address : </td><td colspan='7'>-------</td></tr>
    <tr style='text-align:left;'><td colspan='3' style='text-align:right;'>Telephone : </td><td colspan='7'>-------</td></tr>
    <tr><td colspan='10'><br /><br /></td></tr>

    <tr><td rowspan='2'>SL</td><td rowspan='2'>Date</td><td rowspan='2'>Transaction Description</td><td colspan='2'>Purchase / Sales Register&#39;s</td>
    <td>Treasury Deposite</td><td>Rebate</td><td>Payable</td><td>Closing Balance</td><td>Remarks</td></tr>
    <tr><td>SL no.</td><td>Date</td>
    <td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>Value</td><td>10</td></tr>

    <tr><td style='width:50px;'>1</td><td style='width:85px;'>2</td><td style='width:100px;'>3</td><td style='width:100px;'>4</td><td style='width:100px;'>5</td>
    <td style='width:85px;'>6</td><td style='width:300px;'>7</td><td style='width:150px;'>8</td><td style='width:100px;'>9</td><td style='width:155px;'>10</td>
    </tr>
    </table>--%>
    </form>
</body>
</html>
