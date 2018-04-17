<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Print.MR_PrePrinted" Codebehind="MR_PrePrinted.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Print Money Receipt</title>

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

    <style type="text/css">        
        .mrBar
        {
            width: 150px; 
    	    height: 40px; 
    	    left: 600px; 
    	    top: 15px; 
    	    z-index: 1; 
    	    position: absolute;            
            background-color:#FFFFFF;
        }
        .date
        {
            left: 635px; 
    	    top: 103px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 14px;
            background-color:#FFFFFF;       
        }
        .dateChq
        {
        	left: 525px; 
    	    top: 275px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 14px;            
            background-color:#FFFFFF;       
        }
        .mrNo
        {
            left: 635px; 
    	    top: 130px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 13px;
            background-color:#FFFFFF;       
        }
        .receive
        {
        	width:650px;
        	height:50px;
        	line-height:25px;
            left: 50px; 
    	    top: 150px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 13px;
            background-color:#FFFFFF; 
            font-weight:bold;      
        }
        .amount
        {
        	width:170px;        	        	
            left: 120px; 
    	    top: 215px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 15px;
            font-weight:bold;
            background-color:#FFFFFF;       
        }      
        .amountBox
        {
        	width:170px;        	        	
            left: 40px; 
    	    top: 365px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 15px;
            font-weight:bold;
            background-color:#FFFFFF;       
        }        
        .inWords
        {
        	width:650px;
        	height:50px;
        	line-height:25px;
            left: 50px; 
    	    top: 210px; 
    	    z-index: 0; 
    	    position: absolute;
            font-size: 14px;
            background-color:#FFFFFF;             
        }
        .payThrough
        {
        	left: 210px; 
    	    top: 275px; 
    	    z-index: 1; 
    	    position: absolute;
            font-size: 14px;            
            background-color:#FFFFFF;       
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="btn" style="text-align:left; padding-left:100px;">
        <a href="#" onclick="Print()"><b>Print</b></a>
    </div>
    <div id="print">
        <asp:Label ID="lblMR" CssClass="mrNo"  runat="server"></asp:Label>
        <asp:Image ID="Image1" CssClass="mrBar" runat="server"/>
        <asp:Label ID="lblDD" CssClass="date" runat="server"></asp:Label>
        <asp:Label ID="lblChqDD" CssClass="dateChq" runat="server"></asp:Label>
        
        <asp:Label ID="lblReceiveFrom" CssClass="receive" runat="server"></asp:Label>
        <asp:Label ID="lblPayThrough" CssClass="payThrough" runat="server"></asp:Label>
        <asp:Label ID="lblAmount" CssClass="amount" runat="server"></asp:Label>
        <asp:Label ID="lblAmountBox" CssClass="amountBox" runat="server"></asp:Label>
        <asp:Label ID="lblInWords" CssClass="inWords" runat="server"></asp:Label>
                
    </div>
    </form>
</body>
</html>