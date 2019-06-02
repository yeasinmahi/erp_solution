<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintInvoice.aspx.cs" Inherits="UI.SAD.Delivery.PrintInvoice" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
     <link href="~/Content/CSS/Print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("btn");
            dv.style.display = "none";
        }

        function IsChallan() {
            var dv = document.getElementById("challan").style.display;
            if (dv == "block" || dv == "") document.getElementById("challan").style.display = "none";
            else document.getElementById("challan").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="btn" align="center" width="700px" style="background-color: #E0E0E0;">
        <tr>
            <td align="center" style="width: 33%;">
                <a href="#" onclick="Print()"><b>Print</b></a>
            </td>
        
             <td align="center" style="color: Blue; font-weight: bold; width: 33%;">
                <input id="Checkbox1" type="checkbox" onclick="IsChallan()" checked="checked" />
                Challan
            </td>
        
  
            
        </tr>
    </table>
    <div id="challan">
        <asp:Panel ID="pnlChallan" runat="server">
            <%# mainD.ToString() %>
        </asp:Panel>
    </div>


 <div id="print">        
        <table style="width:700px; text-align:left; height:100px" align="center">

           
            <tr>
               <td style="width:500px; font-size:15px;text-align:center; text font-weight:bold;" colspan="5"> </td>      
            </tr>
            <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                   
            </tr>
             <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>
        </table>


      




      



    </div>    











    </form>
</body>
</html>