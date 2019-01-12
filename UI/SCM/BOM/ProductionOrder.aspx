<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductionOrder.aspx.cs" Inherits="UI.SCM.BOM.ProductionOrder" %>

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

    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }

        function AddConfirm() {
            var e = document.getElementById("ddlBom");
            var bomtype = e.options[e.selectedIndex].value;
            var inItem = document.getElementById("txtItem").value;
            var quantity = parseFloat(document.getElementById("txtQty").value);

            if ($.trim(bomtype) == 0 || $.trim(bomtype) == "" || $.trim(bomtype) == null || $.trim(bomtype) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select BOM '); }
            else if ($.trim(inItem) == 0 || $.trim(inItem) == "" || $.trim(inItem) == null || $.trim(inItem) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select   Item'); }
            else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input Quantity'); }

            else {
                document.getElementById("hdnPreConfirm").value = "1";
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
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnPreConfirm" runat="server" />

                    <div class="tabs_container" style="text-align: left">
                        Production Order<hr />
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" Style="width: 150px" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItem" runat="server" Style="width: 450px" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="250px" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                                    ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblPurpose" runat="server" CssClass="lbl" Text="Batch No :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtBatchNo" CssClass="txtBox" Font-Bold="False" AutoPostBack="false" runat="server"></asp:TextBox>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQty" Style="width: 150px" CssClass="txtBox" Font-Bold="False" TextMode="Number" AutoPostBack="false" Text="0" runat="server"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="BOM :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlBom" Style="width: 450px" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Line No :"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlLine" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="  Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtdteDate" Style="width: 150px" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteDate"></cc1:CalendarExtender>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="  Time :"></asp:Label></td>
                                <td style="text-align: left">
                                    <%--<asp:TextBox ID="TextBox1" Style="width: 150px" runat="server" CssClass="txtBox"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlFromTime" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server">
                                        <asp:ListItem>12:00 AM</asp:ListItem>
                                        <asp:ListItem>1:00 AM</asp:ListItem>
                                        <asp:ListItem>2:00 AM</asp:ListItem>
                                        <asp:ListItem>3:00 AM</asp:ListItem>
                                        <asp:ListItem>4:00 AM</asp:ListItem>
                                        <asp:ListItem>5:00 AM</asp:ListItem>
                                        <asp:ListItem>6:00 AM</asp:ListItem>
                                        <asp:ListItem>7:00 AM</asp:ListItem>
                                        <asp:ListItem>8:00 AM</asp:ListItem>
                                        <asp:ListItem>9:00 AM</asp:ListItem>
                                        <asp:ListItem>10:00 AM</asp:ListItem>
                                        <asp:ListItem>11:00 AM</asp:ListItem>
                                        <asp:ListItem>12:00 PM</asp:ListItem>
                                        <asp:ListItem>1:00 PM</asp:ListItem>
                                        <asp:ListItem>2:00 PM</asp:ListItem>
                                        <asp:ListItem>3:00 PM</asp:ListItem>
                                        <asp:ListItem>4:00 PM</asp:ListItem>
                                        <asp:ListItem>5:00 PM</asp:ListItem>
                                        <asp:ListItem>6:00 PM</asp:ListItem>
                                        <asp:ListItem>7:00 PM</asp:ListItem>
                                        <asp:ListItem>8:00 PM</asp:ListItem>
                                        <asp:ListItem>9:00 PM</asp:ListItem>
                                        <asp:ListItem>10:00 PM</asp:ListItem>
                                        <asp:ListItem>11:59 PM</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlFromToTime" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server">
                                        <asp:ListItem>12:00 AM</asp:ListItem>
                                        <asp:ListItem>1:00 AM</asp:ListItem>
                                        <asp:ListItem>2:00 AM</asp:ListItem>
                                        <asp:ListItem>3:00 AM</asp:ListItem>
                                        <asp:ListItem>4:00 AM</asp:ListItem>
                                        <asp:ListItem>5:00 AM</asp:ListItem>
                                        <asp:ListItem>6:00 AM</asp:ListItem>
                                        <asp:ListItem>7:00 AM</asp:ListItem>
                                        <asp:ListItem>8:00 AM</asp:ListItem>
                                        <asp:ListItem>9:00 AM</asp:ListItem>
                                        <asp:ListItem>10:00 AM</asp:ListItem>
                                        <asp:ListItem>11:00 AM</asp:ListItem>
                                        <asp:ListItem>12:00 PM</asp:ListItem>
                                        <asp:ListItem>1:00 PM</asp:ListItem>
                                        <asp:ListItem>2:00 PM</asp:ListItem>
                                        <asp:ListItem>3:00 PM</asp:ListItem>
                                        <asp:ListItem>4:00 PM</asp:ListItem>
                                        <asp:ListItem>5:00 PM</asp:ListItem>
                                        <asp:ListItem>6:00 PM</asp:ListItem>
                                        <asp:ListItem>7:00 PM</asp:ListItem>
                                        <asp:ListItem>8:00 PM</asp:ListItem>
                                        <asp:ListItem>9:00 PM</asp:ListItem>
                                        <asp:ListItem>10:00 PM</asp:ListItem>
                                        <asp:ListItem>11:59 PM</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Invoice :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtInvoice" CssClass="txtBox" Font-Bold="False" AutoPostBack="false" runat="server"></asp:TextBox></td>
                            </td>
                        </tr>
                        <tr>
                            <%--<td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Workstation"></asp:Label></td>
                            <td style="text-align: left;">
                                <%--<asp:DropDownList Style="width: 150px" ID="ddlStation" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>--%>

                            <td style="text-align: right" colspan="6">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClientClick="AddConfirm();" OnClick="btnAdd_Click" /><asp:Button ID="btnSubmit" runat="server" OnClientClick="funConfirmAll();" Text="Submit" OnClick="btnSubmit_Click" /></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="dgvBom" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="850px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" OnRowDeleting="dgvGridView_RowDeleting"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="30px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product ID" Visible="false" SortExpression="itemid">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name" SortExpression="item">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Width="200px" Text='<%# Bind("item") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Start Time" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="toTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" Width="80px" runat="server" Text='<%# Bind("toTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="End Time" ItemStyle-HorizontalAlign="right" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndTime" Width="80px" runat="server" Text='<%# Bind("fromtime" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="wasquantitytage">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# Bind("quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="BOM Used" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="bomname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBomUsed" Width="120px" runat="server" Text='<%# Bind("bomName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Batch" ItemStyle-HorizontalAlign="right" SortExpression="strCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBatch" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# Bind("batch") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice No" ItemStyle-HorizontalAlign="right" SortExpression="strCinvoiceode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoice" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("invoice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Line/Process/Machine" ItemStyle-HorizontalAlign="right" SortExpression="lineprocess">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLine" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# Bind("lineprocess") %>'></asp:Label>
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