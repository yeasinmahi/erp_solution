<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptM19G.aspx.cs" Inherits="UI.SAD.Vat.rptM19G" %>
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
 
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
 
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
    <tr><td style="text-align:center" colspan="6">Government Of Peoples Republic Of Bangladesh</td> </tr> 
    <tr> <td style="text-align:center" colspan="6">National Board Of Revenue, Dhaka</td></tr>
    <tr><td style="text-align:right" colspan="3">VAT Return &nbsp &nbsp &nbsp</td>
        <td style="text-align:right" colspan="3">Mushak 19</td>
    </tr>
    <tr> <td style="text-align:center" colspan="6">[Described in Rule 24(1)]</td></tr>
   
     <tr><td>From Date</td>
        <td><asp:TextBox ID="txtfdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtfdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
        ID="CalendarExtender2" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td><asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Summary" /></td>
        <td><asp:Button ID="btnprepare" runat="server"  Text="Prepare" OnClick="btnprepare_Click" />  </td>
        <td></td>
     </tr>
    <tr><td>VAT Period</td>
        <td><asp:Label ID="lblMoth" runat="server"></asp:Label>&nbsp <asp:Label ID="lblyear" runat="server"></asp:Label></td>
        <td></td>
        <td></td>
    </tr> 
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
     <tr><td></td>
        <td></td>
        <td colspan="2" style="text-align:right">  </td>
        <td></td>
     </tr> 
     <tr><td colspan="6"><hr /></td></tr>  
     <tr><td colspan="2">Sales Related Information</td> <td>Selling Value</td><td>SD</td><td>VAT</td> </tr> 
     <tr><td>1</td><td colspan="1"><b>Net sales of VAT chargeable goods and service</b></td> <td><asp:Label ID="lblSellingValue" runat="server"></asp:Label></td><td><asp:Label ID="lblOpsB" runat="server"></asp:Label></td><td><asp:Label ID="lblVat" runat="server"></asp:Label></td> </tr>
     <tr><td>2</td><td colspan="1"><b>  Sales of goods and service (Export)</td> <td>&nbsp;</td><td>&nbsp;</td> </tr>
     <tr><td>3</td><td colspan="1"> Net sales of Examted goods and service</td>  <td><asp:Label ID="lblTDSD" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td colspan="2" style="text-align:center"><b>Accounts Payable</b></td> <td><b>Amount</b></td><td>&nbsp;</td> </tr>
     <tr><td>4</td><td colspan="1">Total tax payable (SD+VAT from Row 1)</td> <td style="border-bottom:medium"><asp:Label ID="lblSDVAT" runat="server"></asp:Label></td><td>&nbsp;</td> </tr>
     <tr><td>5</td><td colspan="1">Other Adjustment (Payable)</td> <td><asp:Label ID="lblOthersPayRow" runat="server"></asp:Label></td><td style="border-bottom:medium"></td> </tr>
     <tr><td class="auto-style1">6</td><td colspan="1" class="auto-style1">Total payable (Row 4+5)</td> <td class="auto-style1"><asp:Label ID="lblTotalPayable" runat="server"></asp:Label></td><td style="border-bottom:medium" class="auto-style1"></td> </tr>   
     <tr><td colspan="3" style="text-align:center"><b>Purchase Related Information</b></td><td><b>Purchase Value</b><td>Tax Rebate</td>  </tr>
     <tr><td class="auto-style1">7</td><td colspan="2" class="auto-style1">Local purchase of taxable goods and service</td> <td style="border-bottom:medium" class="auto-style1"><asp:Label ID="lblLocalPurchaseValue" runat="server"></asp:Label></td><td class="auto-style1"><asp:Label ID="lblLocalTaxRebit" runat="server"></asp:Label></td> </tr>
     <tr><td>8</td><td colspan="2">Import of taxable goods and service</td> <td style="border-bottom:medium"><asp:Label ID="lblImportTableValue" runat="server"></asp:Label></td><td><asp:Label ID="lblImporttaxRebit" runat="server"></asp:Label></td> </tr>
     <tr><td>9</td><td colspan="2">Other tax rebate for export</td> <td><asp:Label ID="lblOtherTaxValue" runat="server"></asp:Label></td><td style="border-bottom:medium"><asp:Label ID="lblOtherTaxRebit" runat="server"></asp:Label></td> </tr>
     <tr><td>10</td><td colspan="2">Purchase of tax exemted goods and service</td> <td><asp:Label ID="lblPurExam" runat="server"></asp:Label></td><td style="border-bottom:medium"><asp:Label ID="lblPurExamTax" runat="server"></asp:Label></td> </tr>
     <tr><td colspan="4" style="text-align:center"><b>Rebate/Return Account</b></td> <td><b>Amount</b></td><td>&nbsp;</td> </tr>
     <tr><td class="auto-style1">11</td><td colspan="3" class="auto-style1">Total tax rebate (Row 7+8+9)</td> <td style="border-bottom:medium" class="auto-style1"><asp:Label ID="lblRowTotal789" runat="server"></asp:Label></td></tr>
     <tr><td>12</td><td colspan="3">Other Adjustment (Rebate/Receivable)</td> <td style="border-bottom:medium"><asp:Label ID="lblOthersRowtotal" runat="server"></asp:Label></td></tr>
     <tr><td>13</td><td colspan="3">Balance of previous month</td> <td style="border-bottom:medium"><asp:Label ID="lblBalancePrev" runat="server"></asp:Label></td></tr>
     <tr><td>14</td><td colspan="3">Total rebate (Row 11+12+13)</td> <td style="border-bottom:medium"><asp:Label ID="lblTotalRebit111213" runat="server"></asp:Label></td></tr>
    
     <tr><td colspan="4" style="text-align:center"><b>Final Account</b></td> <td><b>Amount</b></td><td>&nbsp;</td> </tr>

     <tr><td>15</td><td colspan="3">Net payable (Row 6-14)</td> <td style="border-bottom:medium"><asp:Label ID="lblFinalNetPayable" runat="server"></asp:Label></td></tr>
     <tr><td>16</td><td colspan="3">Treasury deposit &nbsp &nbsp &nbsp SD :<asp:Label ID="lblFinalSD" runat="server"></asp:Label>&nbsp &nbsp VAT : <asp:Label ID="lblFinalVat" runat="server"></asp:Label> </td> <td style="border-bottom:medium"><asp:Label ID="lblTreasury" runat="server"></asp:Label></td></tr>
     <tr><td>17</td><td colspan="3">Opening balance of next month</td> <td style="border-bottom:medium"><asp:Label ID="lblOpeningBalanceFinal" runat="server"></asp:Label></td></tr>
     <tr><td>18</td><td colspan="3">DEDO</td> <td style="border-bottom:medium"><asp:Label ID="lblDEDO" runat="server"></asp:Label></td></tr>
    
     <tr><td colspan="4" style="text-align:center"><b>Final Account</b></td> <td><b>Amount</b></td><td>&nbsp;</td> </tr>
     <tr><td>19</td><td colspan="3">Total VAT deducted at source</td> <td style="border-bottom:medium"><asp:Label ID="lblTotalVAT" runat="server"></asp:Label></td></tr>
     <tr><td colspan="6"></td></tr>
     <tr><td colspan="6">I hereby declare that all information given in this return true and accurate </td></tr>
  
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

