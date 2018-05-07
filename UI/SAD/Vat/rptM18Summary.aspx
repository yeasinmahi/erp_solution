<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptM18Summary.aspx.cs" Inherits="UI.SAD.Vat.rptM18Summary" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
 
</head>
<body>
    <form id="frmM18Summary" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnCustname" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> M18 Current Register Summary <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">  
    <tr><td style="text-align:center" colspan="6">Government Of Peoples Republic Of Bangladesh, National Board Of Revenue, Dhaka.</td> </tr> 
    <tr> <td style="text-align:center" colspan="6">Current Register Summary</td></tr>
    <tr><td style="text-align:center" colspan="6">For the Month of May, 2018</td></tr>
    <tr><td>Name </td>
        <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
        <td>Phone No</td>
        <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
    </tr> 
    <tr><td class="auto-style1">Address </td>
        <td class="auto-style1"><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
        <td class="auto-style1">Vat Registration No </td>
        <td class="auto-style1"><asp:Label ID="lblVatRegno" runat="server"></asp:Label></td>
     </tr> 
     <tr><td>From Date</td>
        <td><asp:TextBox ID="txtdtefdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtefdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
        ID="CalendarExtender2" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td>&nbsp;</td>
        <td>  </td>
        <td></td>
     </tr>
     <tr><td></td>
        <td></td>
        <td colspan="2" style="text-align:right"><asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Summary" />  </td>
        <td></td>
     </tr> 
     <tr><td colspan="6"><hr /></td></tr>  
     <tr><td colspan="3"><b>Particulars</b></td> <td><b>Amount</b></td><td><b>Amount</b></td> </tr> 
     <tr><td colspan="3"><b>OPENING BALANCE AS ON MAY 01, 2018</b></td> <td>&nbsp;</td><td><asp:Label ID="lblOpsB" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3"><b>  Add: Treasury Deposit</td> <td>&nbsp;</td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Treasury Deposit for SD</td>  <td><asp:Label ID="lblTDSD" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Treasury Deposit for VAT</td> <td><asp:Label ID="lblTDVAT" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Treasury Deposit for Surcharge</td> <td style="border-bottom:medium"><asp:Label ID="lblTDSur" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b>Total Treasury Deposit</b></td> <td>&nbsp;</td><td style="border-bottom:medium"><asp:Label ID="lblTDTotal" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b>Total Fund Available</b></td> <td>&nbsp;</td><td><asp:Label ID="lblTFA" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b>Add: Rebate</b></td> <td>&nbsp;</td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Local purchase <asp:Label ID="lblLP" runat="server"></asp:Label></td> <td><asp:Label ID="lblLPurAmt" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Exemted Local purchase <asp:Label ID="lblELocalPur" runat="server"></asp:Label></td> <td></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Import <asp:Label ID="lblImport" runat="server"></asp:Label></td> <td><asp:Label ID="lblImportAmt" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   Other rebate for export <asp:Label ID="lblOthersReb" runat="server"></asp:Label></td> <td style="border-bottom:1px"></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Total Rebate</b></td> <td>&nbsp;</td><td style="border-bottom:medium"><asp:Label ID="lblTotalRebate" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Total Balance</b></td> <td>&nbsp;</td><td><asp:Label ID="lblTotalBalane" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Add: Adjustments</b></td> <td>&nbsp;</td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp     SD Adjustment</td> <td><asp:Label ID="lblSDAdj" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp     VAT Adjustment</td> <td><asp:Label ID="lblVatAdj" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp      Surcharge Adjustment</td> <td style="border-bottom:medium"><asp:Label ID="lblSurAdj" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Total Adjustments</b></td> <td>&nbsp;</td><td style="border-bottom:medium"><asp:Label ID="lblTotalAdj" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Net Balance</b></td> <td>&nbsp;</td><td><asp:Label ID="lblNetPayable" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp  <b> Less: Payables</b></td> <td>&nbsp;</td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp     SD Payable &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp Local Sales: &nbsp<asp:Label ID="lblLS" runat="server"></asp:Label> </td> <td><asp:Label ID="lblSDPay" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp       VAT Payable&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp &nbsp&nbsp Export   :&nbsp<asp:Label ID="lblES" runat="server"></asp:Label></td> <td><asp:Label ID="lblVatPay" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp        Surcharge Payable&nbsp&nbsp Exm.Sales :&nbsp<asp:Label ID="lblExmS" runat="server"></asp:Label></td> <td style="border-bottom:medium"><asp:Label ID="lblSurPay" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   <b> Total Payables</b></td> <td>&nbsp;</td><td style="border-bottom:medium"><asp:Label ID="lblTotalPay" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="3">&nbsp&nbsp   <b> CLOSING BALANCE AS ON MAY 31, 2018</b></td> <td>&nbsp;</td><td style="border-bottom:double"><asp:Label ID="lblClosing" runat="server"></asp:Label></td>
     </tr>                  
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
                                    
    <tr><td><hr /></td></tr> 
    <tr><td></td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
