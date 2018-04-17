<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRClearangeDetails.aspx.cs" Inherits="UI.HR.Settlement.HRClearangeDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <script>$(document).ready(function () { document.getElementById("hiddenbox3").style.display = "none"; });</script>

<script>
    function Print() { document.getElementById("btnprint").style.display = "none"; window.print(); self.close(); }
</script>
</head>
<body>
    <form id="frmhrClearance" runat="server">
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
       <div id="divcontentholder">
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> HR Clearance Details :</td></tr>
         
        <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblHRClearnaceRemarks" CssClass="lbl" runat="server" Text="HR Clearance Remarks : "></asp:Label></td>
            <td><asp:TextBox ID="txtHRClearnaceRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Enabled="true"></asp:TextBox></td>                                                             

            <td style="text-align:right;"><asp:Label ID="lblRequestEmailAddress" CssClass="lbl" runat="server" Text="Request Email Address : "></asp:Label></td>
            <td><asp:TextBox ID="txtRequestEmailAddress" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>                                                                             
        </tr>
        <tr class="tblroweven">  
            <td colspan="3"> 
                <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" OnClick="btnClose_Click"/></td>             
            <td  colspan="4">    
            <%--<asp:Button ID="btnRealize" runat="server" CssClass="button" Text="Realize"onclick="ClearanceDetails()"/></td>  --%>
            <%--<a class="button" style="text-align:left;" onclick="ClearanceDetails()">Realize</a></td>--%>
            <asp:Button ID="btnClearance" runat="server" CssClass="button" Text="Realize" OnClientClick="ConfirmAll()"/></td>             
                     
        </tr>

        <%--<tr>
        <td  colspan="4">    
            <a class="button" style="text-align:left;" "printdiv('hiddenbox3');" value=" Print ">Print</a></td>
        </tr>--%>
        <%--<input name="b_print" type="button" class="ipt"   onClick="printdiv('div_print');" value=" Print ">--%>

        
    </table>
    </div>

    <div id="divcontentholder">
        <asp:Panel ID="pnlHRClearance1" runat="server"><%# hrclearance1 %></asp:Panel><br /> 
        <asp:Panel ID="pnlHRClearance2" runat="server"><%# hrclearance2 %></asp:Panel><br /> 
    </div> 
        
        
    <div id="hiddenbox3"><asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
         
            <table>
            <tr>
                <td><img src="../Content/Images/logo.png" width="65" height="85" /></td>
                <td style='text-align:left; width:500px; font-weight:bold; font-size:12px;'><b style='font-size:45px;'>AKIJ GROUP</b>
                </td>

                <td style='text-align:left; width:300px; font-weight:bold; font-size:12px;'>
                    <p>AKIJ CHAMBER
                    <br/>73, DILKUSHA COMMERCIAL AREA
                    <br/>DHAKA-1000, BANGLADESH.
                    <br/>PHONE : 9563008-9, 7169017-8
                    <br/>FAX : 88-02-9564519
                    <br/>E-mail : info@akij.net
                    <br/>web : www.akij.net</p>
                </td>                        
            </tr>  
                                 
            </table>  
            
            <table class = 'tbldecoration' align='left'>
                    
                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: #999999; padding:2px 0px 2px 2px;'> </td></tr>
                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: white; padding:2px 0px 2px 2px;'> </td></tr>                    
                    
                    <tr  background-color: white;>
                        <td colspan='4' style='text-align: center; padding:4px 0px 4px 2px; font-weight:bold; font-size:23px;'>Statement of employee final settlement</td>                        
                    </tr>

                    <tr  background-color: white;>                        
                        <td colspan='4' style='text-align: right; padding:4px 0px 4px 2px; font-size:12px; font-weight:bold; '> Ref. : /HR & Admin/2015/333685 </td>
                    </tr>
                  
                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Enroll No.: </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Job Station Name : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Code : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Separation Type : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Employee Name : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '></td>
                        
                        <td style='text-align: right; width:150px;'>Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Type of Employee : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Length of Service : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Designation : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Last working Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Department : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Last Working Date By User : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Joining Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Last office provide by Dept Head : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Reason of Separation : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '> </td>                      
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Dept. Accept By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Dept Head Accept Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Dept Head : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Store Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Store Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Transport Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Transport Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                   <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Accounts Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Accounts Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>HR Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By HR Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Legal Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Comments By Legal Dept. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Audit Dept. Release By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Audit Dept. Release Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Accounts Detp. Accept By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Voucher No. & Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>HR Clearange By : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>HR Clearange Date : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:150px;'>Name of Bank & Branch : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:150px;'>Account No. : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: #999999; padding:2px 0px 2px 2px;'> </td></tr>

                    </table>

        <table class = 'tbldecoration' align='left'>
                    <tr class='tblheader'>
                        <td colspan='2' style='text-align: center; padding:4px 0px 4px 2px;'> Payment </td>
                        <td colspan='2' style='text-align: center; padding:4px 0px 4px 2px;'> Deduction </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Salary : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Attendance Deduction : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Privilege Leave/Earn Leave : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Job handover : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr> 

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Provident Fund : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Store particles : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>  

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Company Contribution : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Transport Dues : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Gratuity : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>Accounts Dues : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px; background-color: #F0F0F0;'>
                        <td style='text-align: right; width:200px;'>Legal Adjustment : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; width:200px;'>HR Deduction : </td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr> 

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; font-weight: bold; background-color: #999999; width:200px;'>Total : </td>
                        <td style='text-align: left; font-weight: bold; background-color: #999999; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Loan : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr> 

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Company Contribution : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; background-color: #F0F0F0; width:200px;'>Gratuity : </td>
                        <td style='text-align: left; background-color: #F0F0F0; width:250px; padding:3px 0px 3px 2px; '> </td>
                    </tr>

                    <tr style='font-size: 11px;'>
                        <td style='text-align: right; width:200px;'></td>
                        <td style='text-align: left; width:250px; padding:3px 0px 3px 2px; '> </td>
                        
                        <td style='text-align: right; font-weight: bold; background-color: #999999; width:200px;'>Total : </td>
                        <td style='text-align: left; font-weight: bold; background-color: #999999; width:250px; padding:3px 0px 3px 2px; '> </td>                        
                    </tr> 

                    <tr class='tblheader'><td colspan='4' style='text-align: center; background-color: White; padding:2px 0px 2px 2px;'> </td></tr>

                    <tr style='font-size: 11px; font-weight: bold; background-color: #999999;'>
                        <td style='text-align: right; width:150px;'>Net Payable (Tk.) : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '> </td>                      
                    </tr> 

                    <tr style='font-size: 11px; font-weight: bold; background-color: #999999;'>
                        <td style='text-align: right; width:150px;'>Net Payable (In Word) : </td>
                        <td colspan='3' style='text-align: left; width:250; padding:3px 0px 3px 2px; '> </td>                    
                    </tr>
                                                                         
                    </table>
                    
                    
                    
                    <tr>
                        <td colspan='4' style='text-align: center; background-color: white; padding:7px 0px 7px 7px;'> </td>                      
                        <td><br/><asp:Label ID="nb" colspan='4' runat="server" style='font-size:12px; font-weight:bold;'></asp:Label></td>

                    </tr>
        
            <%--<asp:Panel ID="pnlpaymentfstatus1" runat="server"><%# paymentfstatus1 %></asp:Panel><br /> 
            <asp:Panel ID="pnlpaymentfstatus2" runat="server"><%# paymentfstatus2 %></asp:Panel><br /> --%> 
                   
    </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
