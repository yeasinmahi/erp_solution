<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Order.ChallanCancel" Codebehind="ChallanCancel.aspx.cs" %>
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
        function ShowPopUpE(url) {
            if (!confirm('Do you want to delete this challan?')) {
                
            }
            else {
                var rand_no = Math.floor(11 * Math.random());
                url = url + '&rnd=' + rand_no;
                newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
                if (window.focus) { newwindow.focus() }
            }
        }        
    </script>

</head>
<body>
    <form id="form1" runat="server">    
    
    <div id="print">        
        <asp:Panel ID="pnlChallan" runat="server">
            <%# mainD.ToString() %>
        </asp:Panel>
    </div>    
    </form>
</body>
</html>