<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryTransferOut.aspx.cs" Inherits="UI.SCM.Transfer.InventoryTransferOut" %>

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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />


    <script type="text/javascript">  
        function GetTransQty(txt) {
            var inItem = document.getElementById("txtItem").value;
            var quantity = parseFloat(txt.value);
            var stockQty = parseFloat(document.getElementById("hdnStockQty").value);
            var locationddl = document.getElementById("ddlLcation");
            var location = locationddl.options[locationddl.selectedIndex].value;

            if ($.trim(quantity) == 0 ||
                $.trim(quantity) == "" ||
                $.trim(quantity) == null ||
                $.trim(quantity) == undefined) {
                document.getElementById("txTransferQty").value = "0";
                notify('Please input Transfer Qty');
            }
            else if ($.trim(location) == 0 ||
                $.trim(location) == "" ||
                $.trim(location) == null ||
                $.trim(location) == undefined) {
                document.getElementById("txTransferQty").value = "0";
                notify('Please Select Location');
            }
            else if ($.trim(inItem) == 0 ||
                $.trim(inItem) == "" ||
                $.trim(inItem) == null ||
                $.trim(inItem) == undefined) {
                document.getElementById("txTransferQty").value = "0";
                notify('Please Select Item');
            }
            else if ($.trim(stockQty) == 0 ||
                $.trim(stockQty) == "" ||
                $.trim(stockQty) == null ||
                $.trim(stockQty) == undefined) {
                document.getElementById("txTransferQty").value = "0";
                notify('Stock is not avaiable');
            }

            else if (parseFloat(stockQty) < parseFloat(quantity)) {
                document.getElementById("txTransferQty").value = "0";
                notify('Input Quantity greater then stock quantity');
            }
        }
        function notify(msg) {
            ShowNotification(msg, 'Inventory Transfer Out', 'warning');
        }
        function AddConfirm() {
            var e = document.getElementById("ddlTransType");
            var transferType = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlLcation");
            var locationId = e.options[e.selectedIndex].value;

            var inItem = document.getElementById("txtItem").value;
            var quantity = parseFloat(document.getElementById("txTransferQty").value);
            console.log(quantity);
            var stockQty = parseFloat(document.getElementById("hdnStockQty").value);
            var remarks = document.getElementById("txtRemarks").value;
            var vechile = document.getElementById("txtVehicle").value;
            
            if ($.trim(inItem) == 0 || $.trim(inItem) == "" || $.trim(inItem) == null || $.trim(inItem) == undefined) {
                notify('Please select In Item');
                return false;
            }
            else if ($.trim(locationId) == 0 || $.trim(locationId) == "" || $.trim(locationId) == null || $.trim(locationId) == undefined) {
                notify('Please select Sotre Location');
                return false;
            }
            else if ($.trim(remarks) == 0 || $.trim(remarks) == "" || $.trim(remarks) == null || $.trim(remarks) == undefined || $.trim(remarks) == "NaN") {
                notify('Please input Remarks');
                return false;
            }
            else if ($.trim(vechile) == "" || $.trim(vechile) == null || $.trim(vechile) == undefined || $.trim(vechile) == "NaN") {
                notify('Please input Vehicle');
                return false;
            }
            else if ($.trim(transferType) == 0 || $.trim(transferType) == "" || $.trim(transferType) == null || $.trim(transferType) == undefined || $.trim(transferType) == "NaN") {
                notify('Please select Transfer Type');
                return false;
            }
            else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined || $.trim(quantity) == "NaN") {
                notify('Please input Quantity');
                return false;
            }
            else if (parseFloat(stockQty) < parseFloat(quantity)) {
                notify('input Quantity greater then Stock Quantity');
                return false;
            }
            showLoader();
            return true;
        }

        function Confirm() {
            var e = document.getElementById("ddlToWh");
            var towh = e.options[e.selectedIndex].value;
            var vehicle = document.getElementById("txtVehicle").value;

            if ($.trim(towh) == 0 || $.trim(towh) == "" || $.trim(towh) == null || $.trim(towh) == undefined) {
                notify('Please select Transfer Warehouse');
                return false;
            }
            else if ($.trim(vehicle) == 0 || $.trim(vehicle) == "" || $.trim(vehicle) == null || $.trim(vehicle) == undefined) {
                notify('Please input Vehicle Number');
                return false;
            }

            else {
                if (confirm("Do you want to proceed?")) {
                    showLoader();
                    return true;
                }
                else {
                    return false;
                }
            }
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="frmTransferOrder" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnUom" runat="server" />
                    <asp:HiddenField ID="hdnStockQty" runat="server" />
                    <asp:HiddenField ID="hdnValue" runat="server" />
                    <div class="tabs_container">
                        INVENTORY TRANSFER OUT<hr />
                    </div>

                    <table style="width: 800px; text-align: right">
                        <tr>
                            <td style="text-align: right; width: 250px"><span></span></td>

                            <td style="text-align: right;">WH Name:</td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWh" CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"></asp:DropDownList>
                            </td>

                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="border-radius: 10px; border-style: groove">
                        <tr>
                            <td style='text-align: left;'>Item:</td>
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
                                <asp:DropDownList ID="ddlLcation" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlLcation_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                            <td style='text-align: left;' class="auto-style1"><span style="width: 500px">Transfer TO:</span></td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlToWh" runat="server" CssClass="ddList" AutoPostBack="True"></asp:DropDownList></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label2" Text="Remarks:" runat="server"></asp:Label></td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtRemarks" CssClass="txtBox" Width="400px" runat="server"></asp:TextBox>
                            <td style='text-align: left;' class="auto-style1">Vehicle:</td>
                            <td style='text-align: left;'>
                                <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicle"
                                    ServiceMethod="GetVehicleSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                            <td style='text-align: left;' class="auto-style1"><span style="width: 100px">Type :</span></td>
                            <td style='text-align: left;' class="auto-style1">
                                <asp:DropDownList ID="ddlTransType" runat="server" CssClass="ddList" AutoPostBack="True"></asp:DropDownList></td>

                        </tr>

                        <tr>
                            <td>
                                <asp:Label ID="Label1" Text="Transfer Qty:" runat="server"></asp:Label></td>
                            <td colspan="1" style="text-align: left">
                                <asp:TextBox ID="txTransferQty" CssClass="txtBox" Width="100px" onkeyup="GetTransQty(this);" runat="server"></asp:TextBox>
                                <asp:Label ID="lblDetalis" ForeColor="Blue" runat="server"></asp:Label></td>
                            <td>Rate:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtRate" CssClass="txtBox" Width="80px" Text="0" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:Label ID="lblValue" runat="server" ForeColor="Blue"></asp:Label></td>
                            <td colspan="2">
                                <asp:Button ID="btnAdd" runat="server" ForeColor="blue" OnClientClick="return AddConfirm();" Text="Add" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSubmit" runat="server" ForeColor="blue" OnClientClick="return Confirm();" Text="Save" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>

                    <table style="border-color: black; width: 900px; border-radius: 10px;">
                        <tr>
                            <td>
                                <asp:GridView ID="dgvStore" runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDeleting="dgvGridView_RowDeleting"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Bind("item") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="uom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Width="" Text='<%# Bind("uom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="right" SortExpression="locationName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" Width="120px" runat="server" Text='<%# Bind("locationName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TransType" ItemStyle-HorizontalAlign="right" SortExpression="transType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrans" runat="server" Width="" Text='<%# Bind("transType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                    </Columns>
                                    <FooterStyle Font-Size="11px" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
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
