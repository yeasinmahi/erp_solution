<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoodReceive.aspx.cs" Inherits="UI.WoodPurchase.WoodReceive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    <script language="javascript" type="text/javascript">        

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }    
        function CalculateInstallmentAmount() {
            var TotalQty = document.getElementById('txtTotalWeight').value;
            if (isNaN(TotalQty) == true) { TotalQty = 0; }
            var Deduction = document.getElementById('txtDeduction').value;
            if (isNaN(Deduction) == true) { Deduction = 0; }
            var NetQty = (TotalQty - Deduction);
            document.getElementById('txtNetWeight').value = NetQty;
        }
        
        function ViewDispatchPopup(Id) {
            window.open('LoanScheduleDetailsN.aspx?ID=' + Id, 'sub', "height=500, width=650, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnPOAmount" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Wood Receive<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4" style="text-align:center"><asp:Label ID="lblWH" runat="server" CssClass="label" Text="Weare House :"></asp:Label>
            <asp:DropDownList ID="ddlWHList" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWHList_SelectedIndexChanged"></asp:DropDownList></td></tr>
            
            
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Supplier/PO :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlPOList" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlPOList_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="lblReceiveDate" runat="server" CssClass="lbl" Text="Receive Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtReceiveDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReceiveDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text="Item Name :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlItemList" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlItemList_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Challan Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtChallanDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtChallanDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="PO Quantity :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPOQty" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Challan No :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtChallanNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Pre-Receive :" CssClass="lbl" ></asp:Label></td>
                <td><asp:TextBox ID="txtPrereceive" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Gate Entry No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtGateEntry" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Vat Challan No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVatChallan" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Vehicle No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVehicleNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="Zone :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlZone" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>

                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Weight ID :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtWeightID" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text="Type Of Wood :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlWoodType" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>

                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Total Weight :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalWeight" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();" onKeyUp="javascript:CalculateInstallmentAmount();"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="Store Location :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>

                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Deduction :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDeduction" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();" onKeyUp="javascript:CalculateInstallmentAmount();"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>

                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" Text="Net Weight :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtNetWeight" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="Rate :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>

                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Moisture :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMoisture" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click"/></td>        
            </tr>            
        </table>
    </div>
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>