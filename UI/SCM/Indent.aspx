<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Indent.aspx.cs" Inherits="UI.SCM.Indent" %>

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
    <style type="text/css"> 
        .ajax__calendar_inactive  {color:#dddddd;}
    </style>
    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if ((charCode > 57))
                return false;
            return true;
        }
    </script>

    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }
        }
        function autoCompleteEx_ItemSelected(sender, args) {
            document.getElementById("hdnItemSeleced").value = "Selected";
        }
    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>

    <%--    <script>
        function isNumeric(num) {
            return !isNaN(num)
        }
    </script>--%>
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
                        Indent Entry :  <span style="color: red">Indent Policy (Please Create Indents between 1st to 3rd day of every month in case of Regular Items and for Irregular Items  only on Saturday And Tuesday)</span><hr />
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="400px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                    ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Qty:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtQty" CssClass="txtBox" Font-Bold="False" Text="0" runat="server" Width="100px"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="QC Person:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlQcPersonal" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblPurpose" runat="server" CssClass="lbl" Text="Purpose:"></asp:Label></td>

                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPurpose" CssClass="txtBox" Font-Bold="False" Width="400px" runat="server"></asp:TextBox>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Due Date:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox" Width="100px" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtDueDate">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text=" Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                </asp:DropDownList></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Req ID" Visible="false"></asp:Label>
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text=" Department:"></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlReqId" CssClass="ddList" Font-Bold="False" Visible="false" AutoPostBack="true" runat="server"></asp:DropDownList>
                                <asp:Button ID="btnReq" runat="server" Text="Req Add" OnClick="btnReq_Click" Visible="false" />
                                <asp:DropDownList ID="ddlDepartment" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </td>

                            <td colspan="2" style="text-align: right;">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" ForeColor="Blue" OnClick="btnAdd_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ForeColor="Blue" OnClientClick="showLoader();" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>

                            <td colspan="6">
                                <asp:Label ID="lblIndentNo" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#0066cc"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="6">

                                <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999"  OnRowDeleting="dgvGridView_RowDeleting"
                                    BorderWidth="1px" CellPadding="5" border-right="" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="25px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item ID" SortExpression="itemId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("itemId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="itemName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UoM" ItemStyle-HorizontalAlign="right" SortExpression="uom">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUoM" runat="server" Text='<%# Bind("uom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ReqCode" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="reqCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblreqCode" runat="server" Text='<%# Bind("reqCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Curnt.Stock" ItemStyle-HorizontalAlign="right" SortExpression="stock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("stock","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SaftyStock" ItemStyle-HorizontalAlign="right" SortExpression="sftyStock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSftyStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("sftyStock") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Purpose" ItemStyle-HorizontalAlign="right" SortExpression="purpose">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpurpose" Width="200px" runat="server" Text='<%# Bind("purpose") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Indent Qty." ItemStyle-HorizontalAlign="right" SortExpression="indentQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIndentQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("indentQty","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Prv.Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%# Bind("rate","{0:n2}") %>'></asp:Label>
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
