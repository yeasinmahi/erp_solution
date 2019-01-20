<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentsVsPO.aspx.cs" Inherits="UI.SCM.IndentsVsPO" %>

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

    <script>
        function Viewdetails(dteIndent, dteDue, indentID, dept, whname) {
            window.open('IndentStatusDetalis.aspx?dteIndent=' + dteIndent + '&dteDue=' + dteDue + '&indentID=' + indentID + '&dept=' + dept + '&whname=' + whname, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
        }
        function ShowButtonValidation() {
            var fromDate = document.getElementById("txtDteFrom").value;
            var toDate = document.getElementById("txtdteTo").value;
            if (fromDate == null || fromDate == "") {
                alert("Plese select from date");
                return false;
            } else if (toDate == null || toDate == "") {
                alert("Plese select to date");
                return false;
            }
            return true;
        }
    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>

        window.dataLayer = window.dataLayer || [];
        function gtag() {
            dataLayer.push(arguments);
        }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>
    <style type="text/css">
        .rounds {
            height: 80px;
            width: 30px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }

        .HyperLinkButtonStyle {
            float: right;
            text-align: left;
            border: none;
            background: none;
            color: blue;
            text-decoration: underline;
            font: normal 10px verdana;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 100%;
            height: 100%;
            margin-left: 70px;
            margin-top: 00px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }
    </style>
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
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <div class="tabs_container" style="text-align: left">
                        Indent VS PO<hr />
                    </div>

                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Type: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                    <asp:ListItem Text="Local"></asp:ListItem>
                                    <asp:ListItem Text="Fabrication"></asp:ListItem>
                                    <asp:ListItem Text="Import"></asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>

                            <td style="text-align: right;">
                                <asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDteFrom" runat="server" autocomplete="off" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
                                </cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtdteTo" runat="server" autocomplete="off" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Sort By: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSortBy" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server">
                                    <asp:ListItem Value="0" Text="Pending"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="PO Issued"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="All"></asp:ListItem>
                                </asp:DropDownList></td>

                            <td style="text-align: right" colspan="2">
                            <td style="text-align: left">
                                <asp:Button ID="btnStatement" runat="server" Text="Show" OnClientClick="return ShowButtonValidation();" OnClick="btnStatement_Click" />
                            </td>
                        </tr>
                    </table>

                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Ident ID" SortExpression="indent">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIndent" runat="server" Text='<%# Bind("indent") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Indent Date" ItemStyle-HorizontalAlign="right" SortExpression="stindDaterName">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldteIndent" runat="server" Text='<%# Bind("indDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UoM" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server" Text='<%# Bind("uom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Due Date" ItemStyle-HorizontalAlign="right" SortExpression="dteDueDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDueDate" runat="server" Width="60px" Text='<%# Bind("dteDueDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remain Day" ItemStyle-HorizontalAlign="right" SortExpression="intRemainDays">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemainDays" runat="server" ForeColor="Red" Text='<%# Bind("intRemainDays" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total Day" ItemStyle-HorizontalAlign="right" SortExpression="totalDay">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalDay" runat="server" Text='<%# Bind("totalDay") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Indent Qty" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdentQty" runat="server" Text='<%# Bind("numIndentQty" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Pending Qty" ItemStyle-HorizontalAlign="right" SortExpression="numRemainQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPendingQty" runat="server" Text='<%# Bind("numRemainQty","{0:n2}" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PO Prepared By" ItemStyle-HorizontalAlign="right" SortExpression="strPoUser">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl" runat="server" Text='<%# Bind("strPoUser" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>