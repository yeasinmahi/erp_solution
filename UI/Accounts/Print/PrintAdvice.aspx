<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1" Inherits="UI.Accounts.Print.PrintAdvice" Codebehind="PrintAdvice.aspx.cs" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" /> 

    <style type="text/css">
        .style1
        {
            background-color: #C0C0C0;
            border-color:Black
        }
    </style>
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
    
       <div id="btn" style="text-align: center; width:750px; position:absolute; z-index:1; top:5px; left:20px;">
        <a href="#" onclick="Print()"><b>Print</b></a>  
       </div>
       
     <div id="print" style=" width:100%; position:absolute; top:15px;">
      <table style="width: 100%">
        <tr>
        <td style="text-align: center"  valign="top" width="20%">
            <asp:Image ID="Image2" runat="server" />
        &nbsp;
        </td>
         <td style="text-align: center"  valign="top" width="60%"  >
             <asp:Label ID="lblAdvice" runat="server" CssClass="HeaderStyle33" Text="Label"></asp:Label>
        <br />
            <asp:Label ID="lblUnitName" CssClass="HeaderStyle22"  runat="server" Text="Label"></asp:Label>
      <br />
        <asp:Label ID="lblUnitAddress" CssClass="HeaderStyle2" runat="server" Text="Label"></asp:Label>
       

        
        </td>
        <td style="text-align:right"  valign="top" width="20%" >
            <asp:Image ID="Image1" runat="server" />
        </td>
        </tr>
        </table>
    
    
   
    <table style="width: 100%;">
    <tr>
    <td  style="text-align:left" class="HeaderStyle2">Advice No <b>
        <asp:Label ID="lblAdviceNo" runat="server" Text="Label"></asp:Label></b></td>
    <td  style="text-align:left" class="HeaderStyle2">&nbsp</td> 
    <td width="28%"  style="text-align:left" class="HeaderStyle2">Advice Date. &nbsp 
        <asp:Label ID="lblAdviceDate" runat="server" Text="Label"></asp:Label></td>
    </tr>
    <%--<tr>
    <td style="text-align:left" class="HeaderStyle2">Cheque Date :21/10/2010</td>
    <td  style="text-align:left" class="HeaderStyle2">&nbsp</td>
    <td width="28%" style="text-align:left" class="HeaderStyle2">Voucher Date &nbsp&nbsp21/10/2010</td>
    </tr>--%>
    </table>
        <asp:Label ID="lblHtml" runat="server" Text="Label"></asp:Label>
    <%--<br />
    <table width="100%" cellpadding="0" cellspacing="0">
    <tr>
       <td>
          Please Adjust Our loan according to following manners by debiting
          our <b><u>Current Accout No 70003685</u></b>  
       </td> 
     </tr> 
     <tr>
     <td>&nbsp;</td>
     </tr>
      <tr>
       <td align="left">
       <table width="90%" border="1px"  style="text-align:center; border-color:Black; border-collapse:collapse" cellpadding="0" cellspacing="0">
       <tr class="HeaderStyleAdvice" >
        <td class="style1">No.</td>
        <td class="style1">Account Name</td>
        <td class="style1">Account Number</td>
        <td class="style1">Amount</td>
       </tr>
       <tr  >
        <td style="border-color:Black">1.</td>
        <td style="border-color:Black">AFBL</td>
        <td style="border-color:Black" >MPI-9990</td>
        <td style="text-align: right;border-color:Black " >50,000/=</td>
       </tr>
       <tr >
       <td style="border-color:Black">2.</td>
       <td style="border-color:Black">AFBL</td>
        <td style="border-color:Black" >MPI-3352</td>
        <td style="text-align: right;border-color:Black ">7,00,000/=</td>
       </tr>
        <tr style="border-color:Black">
        <td colspan="3" style="border-color:Black"><b>Total</b></td>
        <td style="text-align: right;border-color:Black " ><b style="text-align: right">7,50,000/=</b></td>
       </tr>
       </table>
       </td>
       
    </tr>    
    </table>
    
    <table width="100%">
    <tr>
        <td width="20%">
        <b>Amount In Word:</b>
        </td>
        <td style="font-weight: 700">
        Seven lac Fifty thousand taka only
        </td>
    </tr>
    </table>
    <br />
    <br />
    <table width="100%">
    <tr>
    <td>
    _________________
    </td>
    <td>
    __________________
    </td>
    </tr>
    <tr>
    <td>
        (Accounts Officer)
    </td>
    <td>
        Manager(Banking)
    </td>
    </tr>
    
    </table>--%>
    
    </div>
    </form>
</body>
</html>
