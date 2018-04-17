<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortDatedItemsReport.aspx.cs" Inherits="UI.AEFPS.ShortDatedItemsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="frmSalesReturn" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
        <div>

            <div class="leaveApplication_container">
                <div class="tabs_container">REPORT OF SHORT DATED ITEMS
                    <hr />
                </div>

                <table class="tbldecoration" style="width: auto; float: left;">

                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
                        <td style="text-align: right;">
                            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Report Type:"></asp:Label></td>
                        <td style="text-align: left;">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="1">Short Dated Item</asp:ListItem>
                                <asp:ListItem Value="2">Expired Item</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: right;">
                            <asp:Button ID="btnPrint" runat="server" CssClass="myButtonGrey" ForeColor="Black" Text="Print" /></td>
                        <td style="text-align: right;">
                            <asp:Button ID="btnShow" runat="server" CssClass="myButtonGrey" ForeColor="Black" Text="Show" OnClick="btnShow_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <hr />
                        </td>
                    </tr>

                </table>
            </div>
            <div class="leaveApplication_container" id="divReport">
                <table>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Label ID="lblWHName" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: left;">
                            <asp:Label ID="lblReportName" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label></td>
                        <td style="text-align: right;">
                            <asp:Label ID="lblReportDate" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:GridView ID="dgvShortDated" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>

                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="15px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID" HeaderStyle-HorizontalAlign="Center" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemID" Width="60px" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" Width="200px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOM" Width="30px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Received Qty" SortExpression="numActualMRRQty" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalQty" Width="40px" runat="server" Text='<%# Bind("numActualMRRQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Rate" SortExpression="numMRRPrice" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate" Width="35px" runat="server" Text='<%# Bind("numMRRPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Value" SortExpression="TotalValue" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalValue" Width="55px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalValue", "{0:n}"))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="55px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Receive Date" SortExpression="dteReceiveDate" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceiveDate" Width="70px" runat="server" Text='<%# Eval("dteReceiveDate", "{0:dd-MM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Short Dated Qty" SortExpression="numStockQty" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShortDated" Width="40px" runat="server" Text='<%# Bind("numStockQty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Short Dated Stock Value" SortExpression="ValueOfShortDated" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShortDatedValue" Width="55px" runat="server" Text='<%# (decimal.Parse(""+Eval("ValueOfShortDated", "{0:n}"))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="55px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Expired Date" SortExpression="dteExpire" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiredDate" Width="70px" runat="server" Text='<%# Eval("dteExpire", "{0:dd-MM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </asp:TemplateField>

                                </Columns>
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
