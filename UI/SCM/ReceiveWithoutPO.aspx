<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveWithoutPO.aspx.cs" Inherits="UI.SCM.ReceiveWithoutPO" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />

    <script type="text/javascript"> 
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
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
    </script>
</head>
<body>
    <form id="frmselfresign" runat="server">
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
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnDA" runat="server" />
                    <div class="tabs_container">
                        Receive without PO  From<hr />
                    </div>

                    <table>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Location"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlLocation" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPurpose" runat="server" CssClass="lbl" Text="Remarks"></asp:Label></td>

                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPurpose" CssClass="txtBox" Font-Bold="False" Width="300px" runat="server"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Qty"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQty" CssClass="txtBox" Font-Bold="False" Text="0" runat="server"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Rate"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtRate" CssClass="txtBox" Font-Bold="False"  Text="0" runat="server"></asp:TextBox>

                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="showLoader();" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="funConfirmAll();" OnClick="btnSubmit_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="dgvRecive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="itemId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="itemName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Adjust Qty" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="right" SortExpression="Location">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOcation" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("Location") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location ID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="locationid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLOcationId" Width="200px" runat="server" Text='<%# Bind("locationid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("remarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
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
