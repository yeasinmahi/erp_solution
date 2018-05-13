<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mushak11.aspx.cs" Inherits="UI.VAT_Management.Mushak11" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Create Item And Material </title>
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnVATAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" /><asp:HiddenField ID="hdnconfirmTax" runat="server" />
          
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
            <tr><td style="text-align:right; padding-top:7px;"><asp:Label ID="Label8" runat="server" Text="Address :" CssClass="lbl"  Font-Size="14px"></asp:Label></td>
            <td colspan="5" style="text-align:left; padding: 0px 0px 0px 0px;"><asp:Label ID="lblAddress" runat="server" Text="Address :" CssClass="lbl" Font-Size="14px"></asp:Label></td></tr>
            <tr><td style="text-align:right; padding-top:7px;"><asp:Label ID="Label10" runat="server" Text="VAT Reg. No. :" CssClass="lbl"  Font-Size="14px"></asp:Label></td>
            <td colspan="5" style="text-align:left; padding: 0px 0px 0px 0px;"><asp:Label ID="lblVATReg" runat="server" Text="VAT Reg. No." CssClass="lbl" Font-Size="14px"></asp:Label></td></tr>
            <tr><td colspan="5" style="text-align:center; padding: 20px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Mushak 11 Print" CssClass="lbl" Font-Size="16px" Font-Underline="true" Font-Bold="true"></asp:Label></td></tr>
               
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblRegNo" runat="server" Text="Challan No." CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td colspan="4"><asp:TextBox ID="txtChallanSearch" runat="server" AutoPostBack="false"  CssClass="txtBox1" Width="640px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtChallanSearch"
                ServiceMethod="GetSearchChallanListForM11" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender></td>                                               
            </tr>
            <tr>
                <td style="text-align:right; padding-top:7px;"><asp:Label ID="lblFCompany" runat="server" Text="Customer Name :" CssClass="lbl"></asp:Label></td>
                <td style="padding-top:7px;"><asp:TextBox ID="txtCustomerName" runat="server" CssClass="txtBox1"></asp:TextBox></td> 
                <td style="text-align:right; width:15px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding-top:7px;"><asp:Label ID="Label1" runat="server" Text="Challan Paid Date & Time (YYYY-MM-DD H:MM:SS) :" CssClass="lbl" Width="180px"></asp:Label></td>
                <td style="padding-top:7px;"><asp:TextBox ID="txtChallanPaidDateTime" runat="server" CssClass="txtBox1"></asp:TextBox></td>                                
            </tr>
            <tr>
                <td style="text-align:right; padding-top:7px;"><asp:Label ID="Label3" runat="server" Text="Vehicle No. :" CssClass="lbl"></asp:Label></td>
                <td style="padding-top:7px;"><asp:TextBox ID="txtVehicleNo" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding-top:7px;"><asp:Label ID="Label4" runat="server" Text="Customer VAT :" CssClass="lbl"></asp:Label></td>
                <td style="padding-top:7px;"><asp:TextBox ID="txtCustomerVAT" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right; padding-top:7px;"><asp:Label ID="Label6" runat="server" Text="Final Destination :" CssClass="lbl"></asp:Label></td>
                <td style="padding-top:7px;"><asp:TextBox ID="txtFinalDestination" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="40px"></asp:TextBox></td>   
                <td style="text-align:right; width:15px;"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right;  padding-top:15px; padding-bottom:7px"><asp:Button ID="btnM11Save" runat="server" class="myButton" Text="M11 Print" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnM11Save_Click"/></td>
            </tr>

        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>