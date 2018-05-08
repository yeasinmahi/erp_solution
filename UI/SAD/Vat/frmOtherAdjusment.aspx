<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOtherAdjusment.aspx.cs" Inherits="UI.SAD.Vat.frmOtherAdjusment" %>
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
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var Amount = document.forms["frmPurchase"]["txtAmount"].value;          
            var dtedate = document.forms["frmPurchase"]["txtDate"].value;
           
            if (dtedate == null || dtedate == "") {
                alert("Please Select Date !");
            }

            else if (Amount == null || Amount == "") {
                alert("Purchase Fill-up  Amount !");
            }
           
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
</head>
<body>
    <form id="frmPurchase" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> OTHER ADJUSTMENTS<hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                               
    <tr><td>Type</td>
        <td><asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem Value="1">Payable Increase</asp:ListItem>
            <asp:ListItem Value="2">Receivable Increase</asp:ListItem>
            </asp:DropDownList></td>
        <td>For</td>
        <td><asp:DropDownList ID="ddlfor" runat="server">
            <asp:ListItem Value="1">SD</asp:ListItem>
            <asp:ListItem Value="2">VAT</asp:ListItem>
            <asp:ListItem Value="3">Surcharge</asp:ListItem>
            </asp:DropDownList></td>
        <td>Amount</td>
        <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox"  MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>   
     </tr> 
    <tr><td>Date</td>
        <td><asp:TextBox ID="txtDate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
        <td>Remarks</td>
        <td colspan="4"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine"  Width="350" Height="50"  MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
     </tr>
    <tr><td style="text-align:right" colspan="6"> <asp:Button ID="btnSave" runat="server" OnClientClick="ValidationBasicInfo()" Text="Save" OnClick="btnSave_Click" /> </td></tr>
    </tr></table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
