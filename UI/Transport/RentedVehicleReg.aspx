<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentedVehicleReg.aspx.cs" Inherits="UI.Transport.RentedVehicleReg" %>
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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>

    <script type="text/javascript">
        function hideGrid1() {
            document.getElementById("divBillForLocalAccounts").style.display = "none";
            document.getElementById("divDriverWiseLB").style.display = "none";
            document.getElementById("divDriverLBALL").style.display = "none";
        }
        function hideGrid2() {
            document.getElementById("divFundApproval").style.display = "none";
            document.getElementById("divDriverWiseLB").style.display = "none";
            document.getElementById("divDriverLBALL").style.display = "none";
        }
        function hideGrid3() {

            document.getElementById("divFundApproval").style.display = "none";
            document.getElementById("divBillForLocalAccounts").style.display = "none";
            document.getElementById("divDriverLBALL").style.display = "none";
        }
        function hideGrid4() {
            document.getElementById("divDriverWiseLB").style.display = "none";
            document.getElementById("divFundApproval").style.display = "none";
            document.getElementById("divBillForLocalAccounts").style.display = "none";
        }
        function hideGridAll() {
            document.getElementById("divFundApproval").style.display = "none";
            document.getElementById("divBillForLocalAccounts").style.display = "none";
            document.getElementById("divDriverWiseLB").style.display = "none";
            document.getElementById("divDriverLBALL").style.display = "none";
        }
        function BillSubmitOfVehicleCost() {
            document.getElementById("divTopSheet").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
        }
        function BillSubmitOfFuelCost() {
            document.getElementById("divTopSheet").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
        }

        function TripDetails(reqsid) {
            window.open('InternalTTripDetails.aspx?intID=' + reqsid, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
        }

        function ViewDocList(Id) {
            //window.open('InternalTDocPathList.aspx?ID=' + Id, 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
            window.open('InternalTDocPathList.aspx?ID=' + Id, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
            ///Transport/DocPathList.aspx
            //newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=250,width=500,top=50,left=150, close=no');
            //if (window.focus) { newwindow.focus() }
        }

    </script>

</head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnTopSheetCount" runat="server" /><asp:HiddenField ID="hdnFuelCostCount" runat="server" /> 
    <asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <div class="tabs_container">RENTED VEHICLE REGISTRATION FORM <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Text="Vehicle No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleNo" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblVType" runat="server" CssClass="lbl" Text="Vehicle Type:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleType" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblDriverName" runat="server" CssClass="lbl" Text="Driver Name:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDriverName" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblDContactNo" runat="server" CssClass="lbl" Text="Driver Contact No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDContactNo" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>

            <td style="text-align:right;"><asp:Label ID="lblDriverNID" runat="server" CssClass="lbl" Text="Driver NID:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDriverNID" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>            
        </tr>
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblDriverLisenceNo" runat="server" CssClass="lbl" Text="Driver Lisence No:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtDriverLisenceNo" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>

            <td style="text-align:right;"><asp:Label ID="lblHelperName" runat="server" CssClass="lbl" Text="Helper Name:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtHelperName" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>
        </tr>
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblVehicleSupplier" runat="server" CssClass="lbl" Text="Vehicle Supplier:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleSupplier" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
        </tr>

        <tr>           
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnCreate" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Create"   OnClientClick="ConfirmAll()" OnClick="btnCreate_Click"/></td>
        </tr>              

     </table>     
</div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
