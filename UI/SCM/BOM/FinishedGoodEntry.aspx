<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodEntry.aspx.cs" Inherits="UI.SCM.BOM.FinishedGoodEntry" %>

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
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }
    </script>

    <script>

        function Viewdetails(productID, productName, bomName, batchName, startTime, endTime, invoice, srNo, quantity, whid, itemId) {
            window.open('FinishedGoodEntryFgSavePopUP.aspx?productID=' + productID + '&productName=' + productName + '&bomName=' + bomName + '&batchName=' + batchName + '&startTime=' + startTime + '&endTime=' + endTime + '&invoice=' + invoice + '&srNo=' + srNo + '&quantity=' + quantity + '&whid=' + whid + '&itemId=' + itemId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
             //window.open('FinishedGoodEntryPopup.aspx?productID=' + productID + '&productName=' + productName + '&bomName=' + bomName + '&batchName=' + batchName + '&startTime=' + startTime + '&endTime=' + endTime + '&invoice=' + invoice + '&srNo=' + srNo + '&quantity=' + quantity + '&whid=' + whid + '&itemId=' + itemId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
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
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />

                    <div class="tabs_container" style="text-align: left">
                        FINISH GOODS ENTRY<hr />
                    </div>
                    <table>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" autoComplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" autoComplete="off"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label3" runat="server"  CssClass="lbl" Text="WH Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>

                            <td style="text-align: right" colspan="2">
                                <asp:Button ID="btnEdit" runat="server" forecolor="green" Text="Edit Production Order" />
                                <asp:Button ID="btnViewProductionOrder" runat="server" Text="Show Production Order" forecolor="blue" OnClientClick="showLoader();" OnClick="btnViewProductionOrder_Click" /></td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>

                                <asp:GridView ID="dgvBom" runat="server" AutoGenerateColumns="False" Font-Size="10px" Width="850px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999"
                                    FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="30px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Prod. ID" Visible="True" SortExpression="intProductionID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("intProductionID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item ID" Visible="false" SortExpression="intItemID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product Name" SortExpression="strName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Width="200px" Text='<%# Bind("strName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="BOM Name" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strBoMName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBomName" Width="150px" runat="server" Text='<%# Bind("strBoMName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Batch No" ItemStyle-HorizontalAlign="right" SortExpression="strBatchNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBatch" runat="server" Width="40px" Text='<%# Bind("strBatchNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Start Time" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="dteStartTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" Width="70px" runat="server" Text='<%# Bind("dteStartTime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="End Time" ItemStyle-HorizontalAlign="right" SortExpression="dteEndtTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndTime" Width="70px" runat="server" Text='<%# Bind("dteEndtTime" ) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Invoice No" ItemStyle-HorizontalAlign="right" SortExpression="strCinvoiceode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoice" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SR NO" ItemStyle-HorizontalAlign="right" SortExpression="strCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSrNO" runat="server" Width="90px" Text='<%# Bind("strCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numOrderQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Width="80px" Text='<%# Eval("numOrderQty","{0:n4}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Line/ Process/ Machine" ItemStyle-HorizontalAlign="right" SortExpression="strplantname">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLine" runat="server" Text='<%# Bind("strplantname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Save FG" ItemStyle-HorizontalAlign="right" SortExpression="lineprocess">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSaveFG" forecolor="Blue" runat="server" Width="70px" OnClick="btnSaveFG_Click" Text="Save FG"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SR Detail" ItemStyle-HorizontalAlign="right" SortExpression="lineprocess">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSRDetail" forecolor="GREEN" runat="server" Width="70px" Text="SR Detail"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Inactive Order" ItemStyle-HorizontalAlign="right"  SortExpression="lineprocess">
                                            <ItemTemplate>
                                                <asp:Button ID="btnInactive" forecolor="Red" runat="server" OnClientClick="return confirmMsg();" OnClick="btnInactive_Click" Text="Inactive Order"></asp:Button>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
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
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>