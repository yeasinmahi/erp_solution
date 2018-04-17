<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfitAndLossReport.aspx.cs" Inherits="UI.AEFPS.ProfitAndLossReport" %>

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
                <div class="tabs_container">REPORT OF PROFIT & LOSS
                    <hr />
                </div>

                <table class="tbldecoration" style="width:auto; float:left;">    
            
                <tr>                
                    <td colspan="4" style="text-align:center;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label>
                        <asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                    <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>

                    <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                    <td style="text-align:left"><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="dtpTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
                </tr>       
                <tr>
                    <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
                </tr>
                <tr><td colspan="4"><hr /></td></tr>
        
       </table>
            </div>
            <div class="leaveApplication_container" id="divReport">
                <table>
                    <tr>
                        <td colspan="2" style="text-align: center;"><asp:Label ID="lblWHName" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: left;"><asp:Label ID="lblReportName" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label></td>
                        <td style="text-align: right;"><asp:Label ID="lblReportDate" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                        <asp:GridView ID="dgvProfitLoss" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvProfitLoss_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>

                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="250px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="30px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity" SortExpression="numQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblQty" Width="40px" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="CPU" SortExpression="monBuyPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblCPU" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monBuyPrice", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTCost" runat="server" Text="Total Cost : "></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Cost Value" SortExpression="TotalBuy" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblCostValue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalBuy", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTCostValue" runat="server" Text ='<%# costvalue %>' /></FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales Price" SortExpression="monPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblRate" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monPrice", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTSales" runat="server" Text="Total Sales : "></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales Value" SortExpression="TotalSales" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblTotalValue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalSales", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTSalesValue" runat="server" Text ='<%# salesvalue %>' /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Price Differnce" SortExpression="monPriceDiff" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblDiff" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monPriceDiff", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTProfit" runat="server" Text="Total Profit : "></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Profit" SortExpression="TotalProfit" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblProfit" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalProfit", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTProfit" runat="server" Text ='<%# profit %>' /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Loss" SortExpression="TotalLoss" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblLoss" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalLoss", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTLoss" runat="server" Text ='<%# loss %>' /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Profit Earned" SortExpression="NetProfit" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblPEarned" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("NetProfit", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTNetProfit" runat="server" Text ='<%# netprofit %>' /></FooterTemplate></asp:TemplateField>

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
