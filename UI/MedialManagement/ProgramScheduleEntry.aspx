<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramScheduleEntry.aspx.cs" Inherits="UI.MedialManagement.ProgramScheduleEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
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
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-5px; border-radius:5px;"> Program Schedule Entry<hr />
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td style="text-align:right"><asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Unit :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" width="225px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList></td>
            <td style="text-align:right"><asp:Label ID="lblProgramType" runat="server" CssClass="label" Text="Program Type :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlProgramType" runat="server" CssClass="ddList" Width="225px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlProgramType_SelectedIndexChanged" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblSupplierName" runat="server" CssClass="label" Text="Supplier Name :"></asp:Label></td>
                <td style="text-align:left"><asp:DropDownList ID="ddlSupplierName" runat="server" CssClass="ddList" Width="225px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplierName_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right"><asp:Label ID="lblProgramName" runat="server" Text="Program Name :" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:DropDownList ID="ddlProgramName" runat="server" CssClass="ddList" Width="225px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>
            </tr>
            
            
            <tr>
                <td style="text-align:right"><asp:Label ID="lblPONo" runat="server" CssClass="label" Text="PO No. :"></asp:Label></td>
                <td style="text-align:left"><asp:DropDownList ID="ddlPO" runat="server" CssClass="ddList" Width="225px" Height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                <td style="text-align:right"><asp:Label ID="lblDuration" runat="server" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtDuration" runat="server" Width="220px" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblAdName" runat="server" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtAdname" runat="server" Width="220px" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right"><asp:Label ID="lblCount" runat="server" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtCount" runat="server" CssClass="txtBox1" Width="220px" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                
            </tr>
            <tr>
                
                <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="label" Text="From Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
            
                <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="label" Text="To Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Width="220px"></asp:TextBox>
                <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblstart" CssClass="label" runat="server" Text="Start-Time : "></asp:Label></td>
                <td><MKB:TimeSelector ID="tmStart" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
                <td style="text-align:right;"><asp:Label ID="lblend" CssClass="label" runat="server" Text="End-Time : "></asp:Label></td>
                <td><MKB:TimeSelector ID="tmEnd" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblNarration" runat="server" CssClass="label" Text="Narration :"></asp:Label></td>
                <td colspan="3" style="text-align:left"><asp:TextBox ID="txtNarration" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" TextMode="MultiLine" Width="575px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click" /></td>        
            </tr>
        </table></div>
    </div>
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>