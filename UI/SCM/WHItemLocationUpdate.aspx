<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WHItemLocationUpdate.aspx.cs" Inherits="UI.SCM.WHItemLocationUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WH Item Location Update</title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmWhItemLocationUpdate" runat="server">
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
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <div class="tabs_container" align="left">WH Item Location Update</div>
                    <table>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="WH Name :"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" ></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetItemSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="ddList" Width="300px" Font-Bold="False" >
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">
                                <asp:Button ID="Show" runat="server" Text="Show" AutoPostBack="true" OnClientClick="showLoader();" OnClick="Show_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvWHLocation" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                                    CssClass="GridViewStyle">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <FooterStyle CssClass="FooterStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Id" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItem") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ItemName" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" Width="200px" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocId" runat="server" Text='<%# Bind("intLocation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocName" Width="200px" runat="server" Text='<%# Bind("strLocationName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock Qty" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockQty" runat="server" Text='<%# Bind("monStock") %>' DataFormatString="{0:N2}"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Stock Value">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockValue" runat="server" Text='<%# Bind("monValue") %>' DataFormatString="{0:N2}"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="New Location" Visible="true">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlNewLocation" runat="server" CssClass="txtBox"
                                                    DataTextField="strLocationName" DataValueField="intStoreLocationID" DataSourceID="ObjectDataSource1"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetLocationData" TypeName="SCM_DAL.LocationTDSTableAdapters.TblWearHouseStoreLocationTableAdapter">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="intwh" SessionField="WareID" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <%--<asp:ObjectDataSource ID="odsWHLocation" runat="server" SelectMethod="GetWHLocation" TypeName="/UI/SCM/WHItemLocationUpdate">
                                </asp:ObjectDataSource>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script type="text/javascript">
        $("[id*=txtTransferQty]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var IssueQty = parseFloat($(this).val());
                    var StockQty = parseFloat($("[id*=lblStockQty]", row).html());
                    if (StockQty >= IssueQty) {

                    }
                    else {
                        $("[id*=txtTransferQty]", row).val('0');
                        alert("Please Check Issue Quantity");
                    }

                }
            }
        });

        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
                showLoader();
            }
            else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }
        }

        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });
    </script>
</body>
</html>
