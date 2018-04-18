<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntryForm.aspx.cs" Inherits="UI.MedialManagement.EntryForm" %>

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
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Entry<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td style="text-align:right"><asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Unit :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList></td>
            <td style="text-align:right"><asp:Label ID="lblEntryType" runat="server" CssClass="label" Text="Entry Type :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlEntryType" runat="server" CssClass="ddList" Width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlEntryType_SelectedIndexChanged"><asp:ListItem Selected="True" Value="1">Program Type</asp:ListItem>
                <asp:ListItem Value="2">Brand Type</asp:ListItem><asp:ListItem Value="3">Brand</asp:ListItem><asp:ListItem Value="4">Program</asp:ListItem></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblBrandType" runat="server" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:DropDownList ID="ddlBrandType" runat="server" CssClass="ddList" Width="220px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>
                <td style="text-align:right"><asp:Label ID="lblBrandName" runat="server" Text="Brand Name :" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:DropDownList ID="ddlBrandName" runat="server" CssClass="ddList" Width="220px" height="23px" BackColor="WhiteSmoke"></asp:DropDownList></td>
            </tr>
            <%--<tr>
                
                <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
            
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
            </tr>--%>
            
            <tr>
                <td style="text-align:right"><asp:Label ID="lblEntryName" runat="server" CssClass="label"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtEntry" runat="server" Width="220px" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right"><asp:Label ID="lblDuration" runat="server" CssClass="label" Text="Duration (sec):"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtDuration" runat="server" Width="220px" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click" /></td>        
            </tr>
        </table>
    </div>
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>