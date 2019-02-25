<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryTransferIN.aspx.cs" Inherits="UI.SCM.Transfer.InventoryTransferIN" %>

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
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />


    <script type="text/javascript">  
        function Validation() {

            var e = document.getElementById("ddlWh");
            var whId = e.options[e.selectedIndex].value;
            e = document.getElementById("ddlTransferItem");
            var transferId = e.options[e.selectedIndex].value;
            e = document.getElementById("ddlLcation");
            var locationId = e.options[e.selectedIndex].value;
            var inItem = document.getElementById("txtItem").value;
            var remarks = document.getElementById("txtRemarsk").value;
            var quantity = parseFloat(document.getElementById("txtQty").value);
            var inQty = parseFloat(document.getElementById("hdnInQty").value);

            if ($.trim(whId) == 0 ||
                $.trim(whId) == "" ||
                $.trim(whId) == null ||
                $.trim(whId) == undefined) {
                ShowNotification('Please select Warehouse','Inventory Transfer IN','warning');
                return false;
            }
            else if ($.trim(transferId) == 0 ||
                $.trim(transferId) == "" ||
                $.trim(transferId) == null ||
                $.trim(transferId) == undefined) {
                ShowNotification('Please select Transfer In Item','Inventory Transfer IN','warning');
                return false;
            }
            else if ($.trim(locationId) == 0 ||
                $.trim(locationId) == "" ||
                $.trim(locationId) == null ||
                $.trim(locationId) == undefined) {
                ShowNotification('Please select Sotre Location','Inventory Transfer IN','warning');
                return false;
            }
            else if ($.trim(inItem) == 0 ||
                $.trim(inItem) == "" ||
                $.trim(inItem) == null ||
                $.trim(inItem) == undefined) {
                ShowNotification('Please select In Item','Inventory Transfer IN','warning');
                return false;
            }
            else if ($.trim(remarks) == 0 ||
                $.trim(remarks) == "" ||
                $.trim(remarks) == null ||
                $.trim(remarks) == undefined) {
                ShowNotification('Please Input Remark','Inventory Transfer IN','warning');
                return false;
            }
            else if ($.trim(quantity) == 0 ||
                $.trim(quantity) == "" ||
                $.trim(quantity) == null ||
                $.trim(quantity) == undefined) {
                ShowNotification('Please input Quantity','Inventory Transfer IN','warning');
                return false;
            }
            else if (parseFloat(inQty) > parseFloat(quantity)) {
                ShowNotification('Input Quantity greater then Transfer In Quantity','Inventory Transfer IN','warning');
                return false;
            }
            else {
                if (confirm("Do you want to proceed?")) {
                    showLoader();
                    return true;
                } else {
                    return false;
                }
            }
        }
    </script>
</head>
<body>
    <form id="frmTransferOrder" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnTransfromValue" runat="server" />
                    <asp:HiddenField ID="hdnInQty" runat="server" />
                    <div class="tabs_container">
                        INVENTORY TRANSFER IN<hr />
                    </div>

                    <table style="width: 750px; text-align: center">
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td style="text-align: right;">WH Name:</td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWh" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>

                    </table>
                    <table style="border-radius: 10px; width: 700px; border-style: groove">

                        <tr>
                            <td style='text-align: left;'>In Item:</td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlTransferItem" CssClass="ddList" Width="400px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferItem_SelectedIndexChanged"></asp:DropDownList></td>
                            <td style="text-align: left;" colspan="2">
                                <asp:Label ID="lblFrom" CssClass="Lbl" ForeColor="Blue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style='text-align: left;'>Item Name:</td>
                            <td>
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="400px" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style='text-align: left;'>Location:</td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlLcation" runat="server" CssClass="ddList" AutoPostBack="True"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblDetalis" ForeColor="Blue" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblRemarks" Text="Remarks:" runat="server"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtRemarsk" CssClass="txtBox" Width="400px" runat="server"></asp:TextBox>

                            </td>
                            <td>Qty:
                            </td>
                            <td>
                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" Width="100px" TextMode="Number"></asp:TextBox>
                                <asp:Button ID="btnSaveIn" runat="server" Style="float: right" OnClientClick="return Validation();" ForeColor="Blue" Text="Transfer IN"  OnClick="btnSaveIn_Click" />
                            </td>
                        </tr>


                    </table>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
