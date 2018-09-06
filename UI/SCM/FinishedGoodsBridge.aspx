<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodsBridge.aspx.cs" Inherits="UI.SCM.FinishedGoodsBridge" %>

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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <div class="tabs_container" style="text-align: left">Finished Goods Bridge<hr /></div>
                    <table>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit Name : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="FG : "></asp:Label></td>
                            <td style="text-align: left;" colspan="3">
                                <asp:DropDownList ID="ddlFG" CssClass="ddList" Width="400px" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblSadUOM" runat="server" CssClass="lbl" Text="SadUOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSadUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInvUOM" runat="server" CssClass="lbl" Text="Inv.UOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlInvUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                        <td>
                                <asp:Button ID="btnAddFg" runat="server" Text="Add FG" CssClass="btnButton" OnClick="btnAddFg_Click" /></td>
                             <td>
                                 <asp:Button ID="btnAddMasterItem" runat="server" Text="Add Master Item" CssClass="btnButton" OnClick="btnAddMasterItem_Click" />
                            </td>
                             </tr>
                            <%--<td style="text-align: right;">
                                <asp:Label ID="lblSadUOM" runat="server" CssClass="lbl" Text="SadUOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSadUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInvUOM" runat="server" CssClass="lbl" Text="Inv.UOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlInvUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                        --%></tr>                       
                    </table>
                   <%-- <table>
                         <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblSadUOM" runat="server" CssClass="lbl" Text="SadUOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSadUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblInvUOM" runat="server" CssClass="lbl" Text="Inv.UOM : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlInvUOM" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                        <td>
                                <asp:Button ID="btnAddFg" runat="server" Text="Add FG" CssClass="btnButton" OnClick="btnAddFg_Click" /></td>
                             <td colspan="2">
                                 <asp:Button ID="btnAddMasterItem" runat="server" Text="Add Master Item" CssClass="btnButton" OnClick="btnAddMasterItem_Click" />
                            </td>
                             </tr>
                    </table>--%>
                </div>
                 <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
