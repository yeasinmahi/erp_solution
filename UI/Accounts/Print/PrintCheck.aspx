<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true"
    Inherits="UI.Accounts.Print.PrintCheck" Codebehind="PrintCheck.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title>Print Cheque</title>
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
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
    function IsAccPayee(){        
        var dv = document.getElementById("pnlAccPay").style.display;        
        if(dv == "block" || dv == "") document.getElementById("pnlAccPay").style.display = "none";
        else document.getElementById("pnlAccPay").style.display = "block";
    }
    </script>
    <style type="text/css">
    
    .main
    {
    	left: 0px; 
    	top: 52px; 
    	z-index: 1; 
    	position: absolute;
    	width: 1030px; 
    	height: 230px;
    	background-color:#FFFFFF;        
    }
    
    .pnlAccPay
    {
    	left: 485px; 
    	top: -35px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 15px; 
        font-weight: bold;         
        background-color:#FFFFFF;
    }
   
    .pnlPayTo
    {
    	width: 615px; 
    	height: 20px; 
    	left: 340px; 
    	top: 70px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 15px; 
        font-weight: normal;
        background-color:#FFFFFF;
    }
    
    .pnlDate
    {
    	width: 180px;
    	height: 30px;
    	left: 770px; 
    	top: 12px; 
    	z-index: 1;     	
    	position: absolute;
        font-size: 15px;         
        letter-spacing: 9px;
        background-color:#FFFFFF;
    }
    
    .pnlInWords
    {
    	width: 440px; 
    	height: 65px; 
    	left: 290px; 
    	 
    	z-index: 1; top: 95px;
    	position: absolute;
         font-size: 14px; 
        font-weight: normal; 
        line-height: 35px;
        background-color:#FFFFFF;
    }
    
    .pnlAmount
    {
    	width: 185px; 
    	height: 30px; 
    	left: 775px; 
    	z-index: 1;  
    	top: 112px;
    	position: absolute;
        font-size: 18px;
        background-color:#FFFFFF;
    }
    
    .pnlUnit
    {
    	width: 330px; 
    	height: 20px; 
    	left: 635px;
    	z-index: 1;  
    	top: 153px; 
    	position: absolute;
        font-size: 11px;
        font-weight:normal;
        text-align:center;
        background-color:#FFFFFF;
    }
    
    .pnlSig1
    {
    	font:Arial Narrow;
    	width: 115px; 
    	height: 20px; 
    	left: 635px; 
    	z-index: 1;  
    	top: 205px;
    	position: absolute;
        font-size: 9px;        
        background-color:#FFFFFF;
    }
    
    .pnlSig2
    {
    	width: 115px; 
    	height: 20px; 
    	left: 745px; 
    	top: 205px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 9px;        
        background-color:#FFFFFF;
    }
    .pnlSig3
    {
    	width: 110px; 
    	height: 20px; 
    	left: 855px; 
    	top: 205px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 9px;
        background-color:#FFFFFF;
    }
    
    .pnlTokDate
    {
    	width: 100px;
    	height: 20px;
    	left: 10px; 
    	top: 58px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 10px;
        background-color:#FFFFFF;
    }
    
    .pnlTokPayee
    {
    	width: 100px; 
    	height: 20px; 
    	left: 15px; 
    	top: 73px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 10px;
        background-color:#FFFFFF;
    }
    
    .pnlTokAmount
    {
    	width: 100px; 
    	height: 20px; 
    	left: 10px; 
    	top: 148px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 10px;
        background-color:#FFFFFF;
    }
    
    .pnlTokCode
    {
    	width: 90px; 
    	height: 20px; 
    	left: 0px; 
    	top: 165px; 
    	z-index: 1; 
    	position: absolute;
        font-size: 10px;
        background-color:#FFFFFF;
    }
    
    </style>
</head>
<body style="margin: 0;">
    <form id="form1" runat="server">
    <div id="btn" style="text-align: center; width: 1030px; ">
        <table width="700px">
            <tr align="left">
                <td>
                    Cheque No:
                    <asp:Label ID="lblChequeNo" runat="server"></asp:Label>
                </td>
                <td>
                    <input id="Checkbox2" type="checkbox" onclick="IsAccPayee()" checked="checked" />Is Account Payee
                    Cheque
                </td>
                <td>
                    <a href="#" onclick="Print()"><b>Print</b></a>
                </td>
            </tr>
        </table>
    </div>
    <div id="print" class="main">
            <asp:Panel ID="pnlAccPay" runat="server">
                <img src="Images/acPayee.png" width="30%" />
            </asp:Panel>
            <asp:Panel ID="pnlPayTo" runat="server">            
                <asp:Label ID="lblPayTo" runat="server" Text=""></asp:Label>            
            </asp:Panel>
            <asp:Panel ID="pnlDate" runat="server">                    
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblD1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblD2" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:1px;">
                            <asp:Label ID="lblM1" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:1px;">
                            <asp:Label ID="lblM2" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:2px;">
                            <asp:Label ID="lblY1" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:2px;">
                            <asp:Label ID="lblY2" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:3px;">
                            <asp:Label ID="lblY3" runat="server" Text=""></asp:Label>
                        </td>
                        <td style="padding-left:3px;">
                            <asp:Label ID="lblY4" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>            
            </asp:Panel>
            <asp:Panel ID="pnlInWords" runat="server">
                <asp:Label ID="lblInWord" runat="server" Text=""></asp:Label>            
            </asp:Panel>
            <asp:Panel ID="pnlAmount" runat="server">            
                <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label>            
            </asp:Panel>
            <asp:Panel ID="pnlUnit" runat="server">
                <asp:Label ID="lblUnit" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlSig1" runat="server">
                <asp:Label ID="lblSig1" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlSig2" runat="server">
                <asp:Label ID="lblSig2" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlSig3" runat="server">
                <asp:Label ID="lblSig3" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlTokDate" runat="server">
                <asp:Label ID="lblTokDate" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlTokPayee" runat="server">
                <asp:Label ID="lblTokPayee" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlTokAmount" runat="server">
                <asp:Label ID="lblTokAmount" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlTokCode" runat="server">
                <asp:Image ID="imgTokCode" runat="server" Height="57px" Width="150px" />
            </asp:Panel>
    </div>
    </form>
</body>
</html>
