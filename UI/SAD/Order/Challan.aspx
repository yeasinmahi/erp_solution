<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Order.Challan" Codebehind="Challan.aspx.cs" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("print");
            dv.style.display = "block";

            dv = document.getElementById("btn");
            dv.style.display = "none";
        }
        function IsGatePass() {
            var dv = document.getElementById("gatepass").style.display;
            if (dv == "block" || dv == "") document.getElementById("gatepass").style.display = "none";
            else document.getElementById("gatepass").style.display = "block";
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    
    <table id="btn" align="center" width="700px" style="background-color:#E0E0E0;">
        <tr>
            <td align="right" style="width:50%">
                <a href="#" onclick="Print()"><b>Print</b></a>
            </td>
            <td align="left" style="color: Blue; font-weight: bold; padding-left:20px;">
                <input id="Checkbox2" type="checkbox" onclick="IsGatePass()" checked="checked" />
                Need GatePass
            </td>
        </tr>
    </table>    
    <div id="print">        
        <asp:Panel ID="pnlChallan" runat="server">
            <%# mainD.ToString() %>
        </asp:Panel>
    </div>
    <div id="gatepass" style="page-break-before:always;">
        <asp:Panel ID="pnlGate" runat="server">
            <%# mainG.ToString() %>
        </asp:Panel>
    </div>
    </form>
</body>
</html>