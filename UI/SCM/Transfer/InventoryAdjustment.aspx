<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryAdjustment.aspx.cs" Inherits="UI.SCM.Transfer.InventoryAdjustment" %>

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
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>

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
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnPreConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUom" runat="server" />
                    <asp:HiddenField ID="hdnStockQty" runat="server" />
                    <asp:HiddenField ID="hdnValue" runat="server" />
                    <div class="tabs_container">
                        INVENTORY ADJUSTMENT
                        <hr />
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
                    <table style="border-radius: 10px; width: 800px; border-style: groove">
                        <caption style="text-align: left">Inventory Adjustment</caption>
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
                            <td style='text-align: left;'>Type:</td>
                            <td style='text-align: left;'>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="ddList">
                                    <asp:ListItem Text="Increase Inventory" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Decrease Inventory" Value="2"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style='text-align: left;'>Location:</td>
                            <td style='text-align: left;' colspan="3">
                                <asp:DropDownList ID="ddlLcation" Width="320px" runat="server" CssClass="ddList"></asp:DropDownList>
                                <asp:Label ID="Label3" Text="Quantity:" runat="server"></asp:Label>
                                <asp:TextBox ID="txtQty" CssClass="txtBox" Width="130px" Text="0" runat="server"></asp:TextBox>
                                <asp:Label ID="Label4" Text="Rate:" runat="server"></asp:Label>
                                <asp:TextBox ID="txtRate" CssClass="txtBox" Width="130px" Text="0" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="Label2" Text="Remarks:" runat="server"></asp:Label></td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtRemarks" CssClass="txtBox" Width="400px" runat="server"></asp:TextBox>
                            <td colspan="2" style="text-align: right">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="showLoader();" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClientClick="showLoader();" OnClick="btnSubmit_Click" />
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
                                            <ItemStyle HorizontalAlign="center" Width="10px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Bind("item") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Id" ItemStyle-HorizontalAlign="right" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%# Bind("rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="monValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue" runat="server" Text='<%# Bind("monValue") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Location Id" ItemStyle-HorizontalAlign="right" SortExpression="locationName" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocationId" Width="120px" runat="server" Text='<%# Bind("locationId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="TransType" ItemStyle-HorizontalAlign="right" SortExpression="transType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrans" runat="server" Width="" Text='<%# Bind("transType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="transType">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Width="" Text='<%# Bind("remarks") %>'></asp:Label>
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
