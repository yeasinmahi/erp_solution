<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VatMonthlyReturnM19.aspx.cs" Inherits="UI.Vat.VatMonthlyReturnM19" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Vat Monthly Return ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var monOtherAdjustment = document.forms["frmvatmonthlyreturn"]["monOtherAdjustment"].value;
            var monOtherRebateForExport = document.forms["frmvatmonthlyreturn"]["monOtherRebateForExport"].value;
            var monExemptedPurchase = document.forms["frmvatmonthlyreturn"]["monExemptedPurchase"].value;
            var monOtherRebateAdjustment = document.forms["frmvatmonthlyreturn"]["monOtherRebateAdjustment"].value;
            var monDEDO = document.forms["frmvatmonthlyreturn"]["monDEDO"].value;
            var txtDate = document.forms["frmvatmonthlyreturn"]["txtDate"].value;

            if (monOtherAdjustment == null || monOtherAdjustment == "" || isNaN(monOtherAdjustment)) {
                alert("Other adjustment must be filled by numeric value.");
            }
            else if (monOtherRebateForExport == null || monOtherRebateForExport == "" || isNaN(monOtherRebateForExport)) {
                alert("Other rebate for export must be filled by numeric value.");
            }
            else if (monExemptedPurchase == null || monExemptedPurchase == "" || isNaN(monExemptedPurchase)) {
                alert("Exempted purchase must be filled by numeric value.");
            }
            else if (monOtherRebateAdjustment == null || monOtherRebateAdjustment == "" || isNaN(monOtherRebateAdjustment)) {
                alert("Other rebate adjustment must be filled by numeric value.");
            }
            else if (monDEDO == null || monDEDO == "" || isNaN(monDEDO)) {
                alert("DEDO must be filled by numeric value.");
            }
            else if (txtDate == null || txtDate == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }

        function Confirmreport() {
            document.getElementById("hdnreport").value = "0";
            var txtDate = document.forms["frmvatmonthlyreturn"]["txtDate"].value;
            if (txtDate == null || txtDate == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnreport").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnreport").value = "0"; }
            }
        }
        function ShowReport(vtacc, date)
        {
            var url = 'PrintReturn.aspx?VATACC=' + vtacc + '&DATE=' + date;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,top=50,left=200');
            if (window.focus) { newwindow.focus() }
        }
        function PrintBackSide() {
            var url = 'PrintBackSide19.aspx';
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,top=50,left=200');
            if (window.focus) { newwindow.focus() }
        }

    </script>

</head>
<body>
    <form id="frmvatmonthlyreturn" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
   <div class="tabs_container">Vat Monthly Return: <asp:HiddenField ID="hdnvtacc" runat="server" />
   <asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>

       <table border="0" style="width:auto;">
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc" OnSelectedIndexChanged="ddlVatAcc_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        <td style="text-align:right; font-size:11px;">Date : </td>
        <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
        </tr>

        <tr><td style="text-align:right;" colspan="4"><asp:HiddenField ID="hdnreport" runat="server" /><asp:Button ID="btnBackside" 
        runat="server" class="nextclick" style="font-size:11px;" Text="BackSide" OnClick="btnBackside_Click"/><asp:Button ID="btnShowReport" 
        runat="server" class="nextclick" style="font-size:11px;" Text="ShowReport" OnClientClick="Confirmreport()" OnClick="btnShowReport_Click"/>
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Prepared Report" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
        </td></tr> 


        <tr style="visibility:hidden;">
        <td style="text-align:right; font-size:11px;">Other Adjustment Payable : </td>
        <td><asp:TextBox ID="monOtherAdjustment" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number" Enabled="false"></asp:TextBox>
        </td>
        <td style="text-align:right; font-size:11px;">Other Rebate For Export : </td>
        <td><asp:TextBox ID="monOtherRebateForExport" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number" Enabled="false"></asp:TextBox></td>
        </tr>

        <tr style="visibility:hidden;">
        <td style="text-align:right; font-size:11px;">Exempted Purchase : </td>
        <td><asp:TextBox ID="monExemptedPurchase" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number" Enabled="false"></asp:TextBox>
        </td>
        <td style="text-align:right; font-size:11px;">Other Rebate Adjustment : </td>
        <td><asp:TextBox ID="monOtherRebateAdjustment" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number" Enabled="false"></asp:TextBox></td>
        </tr>
           
        <tr style="visibility:hidden;">
        <td style="text-align:right; font-size:11px;">DEDO : </td>
        <td><asp:TextBox ID="monDEDO" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;" colspan="2"></td>
        </tr> 
       </table>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
