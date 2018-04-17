<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Audit_R_Details.aspx.cs" Inherits="UI.Dairy.Milk_Audit_R_Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Details Audit Report </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />       
      
</head>
<body>
    <form id="frmTransferOut" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>    
    <%--=========================================Start My Code From Here===============================================--%>

    <table>
        <tr><td><hr /></td></tr>
        <%--===========Summary Report============--%>
        <tr style="background-color:lightgray;"><td style='text-align: center; background-color:lightgray; font-size:18px; font-weight:bold;'><asp:Label ID="lblDetailsHeading" runat="server" Text="Details Audit Report & Bill compllete Form :"></asp:Label></td></tr>
            
        <tr><td>   
            <asp:GridView ID="dgvAuditAppDetails" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" 
            ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvAuditAppDetails_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Chilling Center Name" SortExpression="strChillingCenterName">
            <ItemTemplate><asp:Label ID="lblChillingCenter" runat="server" Text='<%# Bind("strChillingCenterName") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Supplier Name" SortExpression="SupplierName">
            <ItemTemplate><asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("SupplierName") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Challan No" SortExpression="strChallanNo">
            <ItemTemplate><asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("strChallanNo") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="MRR Quantity" SortExpression="Quantity">
            <ItemTemplate><asp:Label ID="lblMRRQty" runat="server" Text='<%# Bind("Quantity", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblMRRQtyTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalmrrqty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Fat Percent" SortExpression="FatPercent">
            <ItemTemplate><asp:Label ID="lblFatPercent" runat="server" Text='<%# Bind("FatPercent", "{0:n}") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" SortExpression="Rate">
            <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# Bind("Rate", "{0:n}") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Deduct Qty. Amount" SortExpression="DeductQtyAmount">
            <ItemTemplate><asp:Label ID="lblDeductQtyAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("DeductQtyAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblDeductQtyAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totaldedqtyamou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Deduct Fat% Amount" SortExpression="DeductFatAmount">
            <ItemTemplate><asp:Label ID="lblDeductFatPer" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("DeductFatAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblDeductFatPerTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totaldedfatamou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="MRR Amount" SortExpression="NetAmount">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("NetAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalmrramou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Bonus Amount" SortExpression="BonusAmount">
            <ItemTemplate><asp:Label ID="lblBonusAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("BonusAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblBonusAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalbonusamou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Payable Amount" SortExpression="PayableAmount">
            <ItemTemplate><asp:Label ID="lblPayableAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("PayableAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblPayableAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalpayableamou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Challan Quantity" SortExpression="ChallanQty">
            <ItemTemplate><asp:Label ID="lblChallanQty" runat="server" Text='<%# Bind("ChallanQty", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblChallanQtyTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalchallanqty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Challan Fat%" SortExpression="ChallanFatPercent">
            <ItemTemplate><asp:Label ID="lblChallanFatPer" runat="server" Text='<%# Bind("ChallanFatPercent", "{0:n}") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Challan Amount" SortExpression="ChallanAmount">
            <ItemTemplate><asp:Label ID="lblChallanAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("ChallanAmount", "{0:n}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblChallanAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalchallanamou %>" /></FooterTemplate></asp:TemplateField>
                        
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </td></tr>         
    </table> 
         
    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>