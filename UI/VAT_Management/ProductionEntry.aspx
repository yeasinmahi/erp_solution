<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionEntry.aspx.cs" Inherits="UI.VAT_Management.ProductionEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Production Entry </title>
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
    
    
</head>
<body>
    <form id="frmProductionEntry" runat="server">        
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
    <asp:HiddenField ID="hdnVatAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" />
          
    <div class="divbody" style="padding-right:10px;">
        
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr><td colspan="5" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="5" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Production Entry" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
                        
            <tr><td colspan="5"><hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Production Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>                
                <td style="text-align:right; padding-left:30px"><asp:Label ID="lblstart" runat="server" CssClass="lbl" Text="Production Time"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><MKB:TimeSelector ID="tpkProductionTime" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>               
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="VAT Product"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td colspan="4" style="text-align:left;">
                <asp:DropDownList ID="ddlVATProduct" CssClass="ddList" Font-Bold="False" runat="server" width="530px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Material Issue By"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlMIssueBy" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlMIssueBy_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblQuantity" runat="server" Text="Quantity" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox1" Width="80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblBandroll" runat="server" CssClass="lbl" Text="Bandroll Used :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlBandroll" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblWastage" runat="server" Text="Wasage :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtWastage" runat="server" CssClass="txtBox1" Width="80px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:right; padding: 15px 22px 15px 0px;"><asp:Button ID="btnSaveProduction" runat="server" class="myButton" Text="Save Production" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnSaveProduction_Click"/></td>
            </tr>
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>