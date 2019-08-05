<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultipoleAdvicePrint.aspx.cs" Inherits="UI.Accounts.Advice.MultipoleAdvicePrint" %>

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
   
    </table>
        <asp:Label ID="lblHtml" runat="server" Text="Label"></asp:Label>
   
    
    </div>
    </form>
</body>
</html>
