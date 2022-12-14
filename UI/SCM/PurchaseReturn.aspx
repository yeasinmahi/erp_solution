<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReturn.aspx.cs" Inherits="UI.SCM.PurchaseReturn" %>

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
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%>

    <script type="text/javascript"> 
        function funConfirmAll() {
            if (confirm("Do you want to proceed?")) {
                showLoader();
                return true;
            } else {
                return false;
            }
        }

    </script>
    <script type="text/javascript">
        function getNum(val) {
            if (isNaN(val)) {
                return 0;
            }
            return val;
        }
        $("[id*=txtReturnQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    debugger;
                    var row = $(this).closest("tr");
                    var receivedQuantity = parseFloat($("[id*=lblReceve]", row).html().replace(/,/g, ""));
                    var currentStock = parseFloat($("[id*=lblCurrentStock]", row).html().replace(/,/g, ""));
                    var returnQty = parseFloat($(this).val().replace(/,/g, ""));
                    var returnedQty = getNum(parseFloat($("[id*=lblReturnQty]", row).html().replace(/,/g, "")));

                    if (receivedQuantity < returnQty + returnedQty) {
                        $("[id*=txtReturnQty]", row).val('0');
                        alert('Return Quantity can not be greater then Receive Quantity');
                    } else if (currentStock < returnQty + returnedQty) {
                        $("[id*=txtReturnQty]", row).val('0');
                        alert('Return Quantity can not be greater then Current Stock');
                    }

                }
            } else {
                $(this).val('');
            }

        });
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnMrrNo" runat="server" />
                    <asp:HiddenField ID="hdnSupplierId" runat="server" />
                    <div class="tabs_container" style="text-align: left">
                        Purchase Return:<hr />
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="MRR No:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtMrrNo" runat="server" CssClass="txtBox"></asp:TextBox>
                                <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClientClick="showLoader();" OnClick="btnDetalis_Click" /></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSupp" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvDelivery" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true" Width="800px"
                                    CssClass="GridViewStyle">
                                    <HeaderStyle CssClass="HeaderStyle" />
                                    <FooterStyle CssClass="FooterStyle" />
                                    <RowStyle CssClass="RowStyle" />
                                    <PagerStyle CssClass="PagerStyle" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ItemID" SortExpression="intItemID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemId" runat="server" Width="50px" Text='<%# Bind("intItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ItemName" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUoM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numPOQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoQty" runat="server" Text='<%# Bind("numPOQty","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Received" ItemStyle-HorizontalAlign="right" SortExpression="numReceiveQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceve" runat="server" Text='<%# Bind("numReceiveQty","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Current Stock" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCurrentStock" runat="server" Text='<%# Bind("numQuantity","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Store Location" ItemStyle-HorizontalAlign="right" SortExpression="intLocationID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("intLocationID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Returned" ItemStyle-HorizontalAlign="right" SortExpression="returnQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReturnQty" runat="server" Text='<%# Bind("returnQty","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%# Bind("monFCRate","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Return Qty" ItemStyle-HorizontalAlign="right" SortExpression="strCurrencyName">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtReturnQty" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Resson" ItemStyle-HorizontalAlign="right" SortExpression="strEmployeeName">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtReson" runat="server" Width="150px" CssClass="txtBox"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Return">
                                            <ItemTemplate>
                                                <asp:Button ID="btnReturn" runat="server" Text="Save Return" OnClientClick="return funConfirmAll();" OnClick="btnReturn_Click" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
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
