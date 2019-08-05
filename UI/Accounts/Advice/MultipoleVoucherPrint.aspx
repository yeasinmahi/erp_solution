<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipoleVoucherPrint.aspx.cs" Inherits="UI.Accounts.Advice.MultipoleVoucherPrint" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>Print Voucher</title>

       <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" /> 
       <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript">        
    function Print(){        
        Show();
        window.print();
        self.close();
    }
    function Show(){
        var dv = document.getElementById("print");
        dv.style.display = "block";
        
        dv = document.getElementById("btn");
        dv.style.display = "none"; 
    }   
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="btn" style="text-align:center;">
        <a href="#" onclick="Print()"><b>Print</b></a>
    </div>
    <div  id="print" style="overflow:auto;">
      
        <asp:Label ID="lblhtml" runat="server"></asp:Label>
    </div>   
    </form>
</body>
</html>
