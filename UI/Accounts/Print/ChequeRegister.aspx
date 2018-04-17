<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Print.ChequeRegister" Codebehind="ChequeRegister.aspx.cs" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>Print Cheque Register</title>
    <style type="text/css">
    .regTable
    {
    	border-collapse:collapse;
    	border:solid 1px #909090;    	
    }
    .regTableWhite
    {
    	border-collapse:collapse;
    	border:solid 1px #FFFFFF;    	
    }
    .header
    {
    	font-family:Verdana;
    	font-size:20px;
    	font-weight:bold;
    	text-align:center;
    	border-collapse:collapse;
    	border:solid 1px #FFFFFF;  
    	padding-top:60px;
    }
    .unit
    {
    	font-family:Verdana;    	
    	font-size:16px;
    	font-weight:bold;
    	text-align:center;
    	border-collapse:collapse;
    	border:solid 1px #FFFFFF;    
    }
    .bnk
    {
    	font-family:Verdana;    	
    	font-size:12px;
    	font-weight:bold;    	
    	border-collapse:collapse;
    	border:solid 1px #FFFFFF;    
    }
    </style>
    <script type="text/javascript">        
    function Print(){                
        dv = document.getElementById("btn");
        dv.style.display = "none"; 
        window.print();
        self.close();
    }
    </script>
    
</head>

<body>
    <form id="form1" runat="server">
    <div id="btn" style="text-align: center; width: 1030px; ">
        <a href="#" onclick="Print()"><b>Print</b></a>    
    </div>
    <div style=" padding-left:0px;">
    <table width="100%" border="1px" cellpadding="0" cellspacing="0" style="font-size:10px; font-family:Verdana;" class="regTable">        
        <asp:Panel ID="Panel1" runat="server">
            <%# sb.ToString() %>
        </asp:Panel>
    </table>
    </div>
    </form>
</body>
</html>
