<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccidentRegisterEntry.aspx.cs" Inherits="UI.Transport.AccidentRegisterEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Approval </title>
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

    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

    

</head>
<body>
<form id="frmAccidentRegister" runat="server">
<asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
<%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">--%>
<%--<ContentTemplate>--%>

<%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />          
    <div class="divbody" style="padding-right: 10px;">
    <div id="divLevel1" class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
    <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="ACCIDENT REGISTER" Font-Bold="true" Font-Size="16px"></asp:Label><hr />
    </div>

    <table class="tbldecoration" style="width: auto; float: left;">
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label8" runat="server" Text="Vehicle Registration Number" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtVehicleRegNo" runat="server" CssClass="txtBox1"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtVehicleRegNo"
            ServiceMethod="AutoSearchVehicleAsset" MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="1"
            FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            
            </td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="User Unit" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:DropDownList ID="ddlUserUnit" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="false"></asp:DropDownList></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label2" runat="server" Text="Driver Name" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtDriverName" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label4" runat="server" Text="Driver Enroll" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtDriverEnroll" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label5" runat="server" Text="Traveling Route From" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtTravelingRouteFrom" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label7" runat="server" Text="Traveling Route To" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtTravelingRouteTo" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label10" runat="server" Text="Place of Accident" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtPlaceOfAccident" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label12" runat="server" Text="Time of Accident" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><cc1:TimeSelector ID="tmsReqTime" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label13" runat="server" Text="Accident Type" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:DropDownList ID="ddlAccidentType" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="false">
            <asp:ListItem Selected="True" Value="1">Minor</asp:ListItem><asp:ListItem Value="2">Major</asp:ListItem><asp:ListItem Value="3">Sever</asp:ListItem>
            </asp:DropDownList></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label15" runat="server" Text="Description" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="35px"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label16" runat="server" Text="Loss Incurred by Accident" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:DropDownList ID="ddlLossIncurredByAccident" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="false">
            <asp:ListItem Selected="True" Value="1">Own</asp:ListItem><asp:ListItem Value="2">Others</asp:ListItem>
            </asp:DropDownList></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label18" runat="server" Text="Support Vehicle Registration Number" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtSupportVehicleRegistrationNumber" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label19" runat="server" Text="Settlement Penalty Paid (In BDT)" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtSettlementPenaltyPaid" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label21" runat="server" Text="Settlement Penalty Receive (In BDT)" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtSettlementPenaltyReceive" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label22" runat="server" Text="Settlement Penalty Charged to Company" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:DropDownList ID="ddlSettlementPenaltyChargedtoCompany" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" AutoPostBack="false"></asp:DropDownList></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label23" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label24" runat="server" Text="Settlement Penalty Charged to Duty Driver" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtSettlementPenaltyChargedtoDutyDriver" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label25" runat="server" Text="Recovered Goods/ Materials Quantity :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtRecoveredGoodsMaterialsQuantity" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label26" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label27" runat="server" Text="Recovered Goods/ Materials Value (In BDT) :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtRecoveredGoodsMaterialsValue" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label28" runat="server" Text="Loss Goods/ Materials Quantity :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtLossGoodsMaterialsQuantity" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label29" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label30" runat="server" Text="Loss Goods/ Materials Value (In BDT) :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtLossGoodsMaterialsValue" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
        <tr>
            <td style="text-align: right;">
            <asp:Label ID="Label31" runat="server" Text="Investigation Reported By Name" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtInvestigationReportedByName" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            <td style="text-align: right; width: 15px;">
            <asp:Label ID="Label32" runat="server" Text=""></asp:Label></td>
            <td style="text-align: right;">
            <asp:Label ID="Label33" runat="server" Text="Designation :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox1"></asp:TextBox></td>            
        </tr>
               
        <tr>
            <td colspan="5" style="text-align: right; padding: 10px 0px 5px 0px">
            <asp:Button ID="btnAction" runat="server" class="myButton" Text="Action" OnClientClick = "ConfirmAll()" OnClick="btnAction_Click" /></td>
        </tr>
    </table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>