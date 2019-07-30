<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mushak19MonthlyReturn.aspx.cs" Inherits="UI.VAT_Management.Mushak19MonthlyReturn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Create Item And Material </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
      
    <script language="javascript">      

        function Print() {
            document.getElementById("divHeader").style.display = "none"; window.print(); //self.close();
        }
    </script>
    <script type="text/javascript">
        function PrintDiv() {
            var divToPrint = document.getElementsByClassName('widget-content')[0];
            var popupWin = window.open('', '_blank', 'width=700,height=650,location=no,left=100px, left=100, top=25, resizable=no, title=Preview, scrollbars=yes');
            popupWin.document.open();
            popupWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</html>');
            popupWin.document.close();
        }
         </script>
      
      
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnVATAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" /><asp:HiddenField ID="hdnconfirmTax" runat="server" />
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr><td> 
            <div id="divHeader" class="divbody" style="padding-right:10px;">        
                <table class="tbldecoration" style="width:auto; float:left; margin-top:0 auto;">
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                        </td>
                        <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Date :" CssClass="lbl"></asp:Label></td>               
                        <td style="text-align:center;"><asp:TextBox ID="txtDate" runat="server" AutoPostBack="true" CssClass="txtBox1" Enabled="true" Width="110px" OnTextChanged="txtDate_TextChanged" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>

                        <td style="text-align:right;  padding-top:5px; padding-bottom:7px; padding-left:15px"><asp:Button ID="btnM11Save" runat="server" class="myButton" Text="Prepare" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnM11Save_Click"/></td>
                        <td style="text-align:right;  padding-top:5px; padding-bottom:7px; padding-left:15px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></td>
                        <td style="text-align:right;  padding-top:5px; padding-bottom:7px; padding-left:15px"><asp:Button ID="btnPrint" runat="server" class="myButton" Text="Print" Height="30px" OnClientClick="PrintDiv()"/></td>
                        
                    </tr>
                </table>
            </div>
        </td></tr>
        <tr><td>
            <div class="widget-content">
            <table class="tbldecoration" style="width:auto; float:left; font-size:12px; border-collapse: collapse; font-size:13px">        
                <tr><td colspan="7" style='text-align: center;'><asp:Label ID="Label1" runat="server" Text ="Government Of Peoples Republic Of Bangladesh" Font-Size="15px"></asp:Label></td></tr>       
                <tr><td colspan="7" style='text-align: center;'><asp:Label ID="Label2" runat="server" Text ="National Board Of Revenue, Dhaka" Font-Size="14px"></asp:Label></td></tr>
                <tr><td colspan="7" style='text-align:right;'><asp:Label ID="Label3" runat="server" Text ="Mushak 19" Font-Bold="true" Font-Size="18px"></asp:Label></td></tr>
                <tr><td colspan="7" style='text-align: center;'><asp:Label ID="Label4" runat="server" Text ="VAT Return"  Font-Bold="true" Font-Size="18px"></asp:Label></td></tr>
                <tr><td colspan="7" style='text-align: center;'><asp:Label ID="Label5" runat="server" Text ="[Described in Rule 24(1)]" Font-Size="15px"></asp:Label></td></tr>
                
                <tr>
                    <td  style='text-align:right;'><asp:Label ID="Label26" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td  style='text-align:right;'><asp:Label ID="Label27" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td  style='text-align:right;'><asp:Label ID="Label28" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td  style='text-align:right;'><asp:Label ID="Label29" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td  style='text-align:right;'><asp:Label ID="Label31" runat="server" Text ="" Width="5px"></asp:Label></td> 
                    <td  style='text-align:right;'><asp:Label ID="Label32" runat="server" Text ="" Width="10px"></asp:Label></td>                     
                </tr>
                
                <tr>
                    <td colspan="2" style='text-align:right;'><asp:Label ID="Label6" runat="server" Text ="VAT Period :"></asp:Label></td>                      
                    <td><span style="padding: 2px 5px 2px 5px; border: 1px solid black; "><span style="padding-right:5px; text-align:center"><asp:Label ID="lblMonth" runat="server" Text ="September" Width="80px"></asp:Label></span><span style="padding: 2px 5px 2px 0px; border-left: 1px solid black"></span><asp:Label ID="lblYear" runat="server" Text ="2018"></asp:Label></span></td>
                    <td style='text-align:right;'><asp:Label ID="Label25" runat="server" Text =""></asp:Label></td> 
                    <td colspan="3" style='text-align:right;'><asp:Label ID="Label7" runat="server" Text ="Vat Registration No :"></asp:Label>
                        <asp:Label ID="lblVATReg" runat="server" Text ="00000"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td colspan="2" style='text-align:right; padding-top:15px'><asp:Label ID="Label8" runat="server" Text ="Name :"></asp:Label></td>
                    <td colspan="5" style='text-align:left; padding-top:15px'><asp:Label ID="lblVATAccountName" runat="server" Text ="AKIJ FOOD & BEVERAGE LTD."></asp:Label></td> 
                </tr>
                <tr>
                    <td colspan="2" style='text-align:right;'><asp:Label ID="Label12" runat="server" Text ="Address :"></asp:Label></td> 
                    <td colspan="5" style='text-align:left;'><asp:Label ID="lblAddress" runat="server" Text ="Krishnapura, Dhamrai, Dhaka."></asp:Label></td> 
                </tr>
                <tr>
                    <td colspan="2" style='text-align:right;'><asp:Label ID="Label14" runat="server" Text ="Phone :"></asp:Label></td> 
                    <td colspan="5" style='text-align:left;'><asp:Label ID="lblPhoneNo" runat="server" Text ="0173609222"></asp:Label></td> 
                </tr>
                <tr>
                    <td style="height:10px"></td>
                </tr> 
                <tr>
                    <td colspan="4" style='text-align:center; border: 1px solid black;' class="auto-style1"><asp:Label ID="Label16" runat="server" Text ="Sales Related Information" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;' class="auto-style1"><asp:Label ID="Label18" runat="server" Text ="Selling Value" Width="110px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;' class="auto-style1"><asp:Label ID="Label17" runat="server" Text ="SD" Width="110px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label19" runat="server" Text ="VAT" Width="110px" Font-Bold="true"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label24" runat="server" Text ="1" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label20" runat="server" Text ="Net sales of VAT chargeable goods and service"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl1A" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl1B" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl1C" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label34" runat="server" Text ="2" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label35" runat="server" Text ="Sales of goods and service (Export)"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl2A" runat="server" Text ="0"></asp:Label></td>          
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label37" runat="server" Text ="3" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label38" runat="server" Text ="Net sales of Examted goods and service"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl3A" runat="server" Text ="0"></asp:Label></td>          
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr> 
                <tr>
                    <td colspan="4" style='text-align:center; border: 1px solid black;'><asp:Label ID="Label40" runat="server" Text ="Accounts Payable" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label41" runat="server" Text ="Amount" Width="110px" Font-Bold="true"></asp:Label></td>               
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label42" runat="server" Text ="4" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label43" runat="server" Text ="Total tax payable (SD+VAT from Row 1)"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl4A" runat="server" Text ="0"></asp:Label></td>          
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label45" runat="server" Text ="5" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label46" runat="server" Text ="Other Adjustment (Payable)"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;' class="auto-style1"><asp:Label ID="lbl5A" runat="server" Text ="0"></asp:Label></td>          
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label48" runat="server" Text ="6" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label49" runat="server" Text ="Total payable (Row 4+5)"></asp:Label></td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl6A" runat="server" Text ="0"></asp:Label></td>          
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr>                
                <tr>
                    <td colspan="5" style='text-align:center; border: 1px solid black;'><asp:Label ID="Label51" runat="server" Text ="Purchase Related Information" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label53" runat="server" Text ="Purchase Value" Width="110px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label54" runat="server" Text ="Tax Rebate" Width="110px" Font-Bold="true"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label52" runat="server" Text ="7" Width="10px"></asp:Label></td> 
                    <td colspan="4" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label55" runat="server" Text ="Local purchase of taxable goods and service"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl7A" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl7B" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label56" runat="server" Text ="8" Width="10px"></asp:Label></td> 
                    <td colspan="4" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label59" runat="server" Text ="Import of taxable goods and service"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl8A" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl8B" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label62" runat="server" Text ="9" Width="10px"></asp:Label></td> 
                    <td colspan="4" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label63" runat="server" Text ="Other tax rebate for export"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl9A" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl9B" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label66" runat="server" Text ="10" Width="10px"></asp:Label></td> 
                    <td colspan="4" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label67" runat="server" Text ="Purchase of tax exemted goods and service"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl10A" runat="server" Text ="0"></asp:Label></td> 
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl10B" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr> 
                <tr>
                    <td colspan="6" style='text-align:center; border: 1px solid black;'><asp:Label ID="Label70" runat="server" Text ="Rebate/Return Account" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label72" runat="server" Text ="Amount" Width="110px" Font-Bold="true"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label71" runat="server" Text ="11" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label73" runat="server" Text ="Total tax rebate (Row 7+8+9)"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl11A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label74" runat="server" Text ="12" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label76" runat="server" Text ="Other Adjustment (Rebate/Receivable)"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl12A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label78" runat="server" Text ="13" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label79" runat="server" Text ="Balance of previous month"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl13A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label81" runat="server" Text ="14" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label82" runat="server" Text ="Total rebate (Row 11+12+13)"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl14A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr> 
                <tr>
                    <td colspan="6" style='text-align:center; border: 1px solid black;'><asp:Label ID="Label84" runat="server" Text ="Final Account" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label85" runat="server" Text ="Amount" Width="110px" Font-Bold="true"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label86" runat="server" Text ="15" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label87" runat="server" Text ="Net payable (Row 6-14)"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl15A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label89" runat="server" Text ="16" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'>
                        <asp:Label ID="Label90" runat="server" Text ="Treasury deposit" Width="180px"></asp:Label>
                        <asp:Label ID="Label92" runat="server" Text ="SD : "></asp:Label><asp:Label ID="lbl16A" runat="server" Text ="0" Width="130px"></asp:Label>
                        <asp:Label ID="Label94" runat="server" Text ="VAT : "></asp:Label><asp:Label ID="lbl16B" runat="server" Text ="0" Width="130px"></asp:Label>
                    </td>                     
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl16C" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label96" runat="server" Text ="17" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label97" runat="server" Text ="Opening balance of next month"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl17A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label99" runat="server" Text ="18" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label100" runat="server" Text ="DEDO"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl18A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr>
                <tr>
                    <td colspan="6" style='text-align:center; border: 1px solid black;'><asp:Label ID="Label102" runat="server" Text ="Deductio of VAT at source account" Width="270px" Font-Bold="true"></asp:Label></td> 
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label103" runat="server" Text ="Amount" Width="110px" Font-Bold="true"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style='text-align:center; border: 1px solid black;'><asp:Label ID="Label104" runat="server" Text ="19" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label105" runat="server" Text ="Total VAT deducted at source"></asp:Label></td>  
                    <td style='text-align:right; border: 1px solid black;'><asp:Label ID="lbl19A" runat="server" Text ="0"></asp:Label></td>                     
                </tr>
                <tr>
                    <td style="height:15px"></td>
                </tr>
                <tr>
                    <td colspan="7" style='text-align:left; border:0;'><asp:Label ID="Label107" runat="server" Text ="I hereby declare that all information given in this return true and accurate" Width="650px"></asp:Label></td> 
                </tr>
                <tr>
                    <td style="height:10px"></td>
                </tr>
                <tr>
                    <td style='text-align:center; border: 0;'><asp:Label ID="Label108" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td colspan="6" style='text-align:left; border: 0;'><asp:Label ID="Label109" runat="server" Text ="Note :" Font-Bold="true"></asp:Label></td>      
                </tr>
                <tr>
                    <td style='text-align:center; border: 0;'><asp:Label ID="Label110" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td colspan="3" style='text-align:left; border: 1px solid black;'><asp:Label ID="Label111" runat="server" Text ="" Height="80px"></asp:Label></td>      
                </tr>
                <tr>
                    <td style="height:10px;"></td>
                </tr>
                <tr>
                    <td style='text-align:center; border: 0;'><asp:Label ID="Label112" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td colspan="4" style='text-align:left; border: 0;'>
                        <asp:Label ID="Label113" runat="server" Text ="Date : " Font-Bold="true"></asp:Label><asp:Label ID="lblDate" runat="server" Font-Bold="true" Text =""></asp:Label>
                    </td> 
                    <td colspan="2" style='text-align:left; border: 0; padding-left:60px'><asp:Label ID="Label115" runat="server" Font-Bold="true" Text ="Signature and Seal"></asp:Label></td>      
                </tr>
                <tr>
                    <td style="height:5px"></td>
                </tr>
                <tr>
                    <td style='text-align:center; border: 0;'><asp:Label ID="Label116" runat="server" Text ="" Width="10px"></asp:Label></td> 
                    <td colspan="5" style='text-align:left; border: 0;'><asp:Label ID="Label117" runat="server" Text ="Enclosed: All papers and documents mentioned in Rule 24"></asp:Label></td> 
                </tr>
            </table>
            </div>





        </td></tr>
     </table>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>