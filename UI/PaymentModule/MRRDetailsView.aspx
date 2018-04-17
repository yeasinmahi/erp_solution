<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRRDetailsView.aspx.cs" Inherits="UI.PaymentModule.MRRDetailsView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Registration </title>
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

    <script language="javascript">        
        
        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
            if (window.focus) { newwindow.focus() }
        }  
    </script>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnPOID" runat="server" />
    <asp:HiddenField ID="hdnBillID" runat="server" /><asp:HiddenField ID="hdnEntryType" runat="server" />    
    
    <div class="divbody" style="padding-right:10px;">
       
        <table>
        <tr><td colspan="9" style="color:blue; font-weight:900;"><a id="btnprint11" href="BillDetails.aspx" class="nextclick" style="cursor:pointer; text-align:right;">Back</a></td></tr> 
        </table>
        <table>            
            <tr><td colspan="9" style="text-align:center;"><asp:Label ID="lblUnitName" runat="server" Text="Entry Registration No:" CssClass="lbl" Font-Size="18px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="9" style="text-align:center;"><asp:Label ID="Label4" runat="server" Text="Material Receive Report" CssClass="lbl" Font-Size="13px" Font-Bold="true" Font-Underline="true" ForeColor="Red"></asp:Label>
                </td></tr>
            
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblC" runat="server" Text="CHALLAN NO.:" CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;" colspan="6"><asp:Label ID="lblChallanNo" runat="server" Text="CHALLAN NO" CssClass="lbl" ForeColor="Blue"></asp:Label></td>                
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="MRR NO: " CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="lblMRRNo" runat="server" Text="MRR NO" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="CHALLAN DATE: " CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;" colspan="6"><asp:Label ID="lblChallanDate" runat="server" Text="CHALLAN DATE:" CssClass="lbl" ForeColor="Blue"></asp:Label></td>                
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="MRR DATE: " CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="lblMRRDate" runat="server" Text="MRR DATE:" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="SUPPLIER NAME: " CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;"><asp:Label ID="lblSupplierName" runat="server" Text="SUPPLIER NAME" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label3" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                
                <td style="text-align:left;"><asp:Label ID="Label2" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label1" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label26" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label27" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label28" runat="server" Text="" CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label29" runat="server" Text="" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr> 

            <tr><td colspan="9" style="color:blue; font-weight:900;">ITEM DETAIL<hr /></td></tr>            
            <tr>
                <td colspan="9"> 
                <asp:GridView ID="dgvItemDetails" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                ShowFooter="true"  HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvItemDetails_RowDataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="Item Description" SortExpression="strItem">
                <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/>
                <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>

                <asp:TemplateField HeaderText="PO Qty." SortExpression="numPOQty">
                <ItemTemplate><asp:Label ID="lblPOQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numPOQty") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="RCV Qty." SortExpression="numReceiveQty">
                <ItemTemplate><asp:Label ID="lblRCVQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numReceiveQty") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Rate (WV)" SortExpression="monFCRate">
                <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monFCRate") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Amnt. (WV)" SortExpression="monBDTTotal">
                <ItemTemplate><asp:Label ID="lblAmntWV" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monBDTTotal") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                <FooterTemplate><asp:Label ID="lblGTotalAmntWV" runat="server" DataFormatString="{0:0.00}" Text="<%# ggrandtotalamntwv %>" /></FooterTemplate></asp:TemplateField>

                <asp:TemplateField HeaderText="Rate (V)" SortExpression="allIndent">
                <ItemTemplate><asp:Label ID="lblRTV" runat="server" DataFormatString="{0:0.00}"  Text='0' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="VAT" SortExpression="allIndent">
                <ItemTemplate><asp:Label ID="lblVat" runat="server" DataFormatString="{0:0.00}"  Text='0' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Rate" SortExpression="allIndent">
                <ItemTemplate><asp:Label ID="lblRt" runat="server" DataFormatString="{0:0.00}"  Text='0' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>
                                   
                <asp:TemplateField HeaderText="Amount">
                <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='0' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr> 

            <tr><td colspan="9" style="color:blue; font-weight:900;"> DOCUMENT LIST<hr /></td></tr>
            <tr>
                <td colspan="9">   
                <asp:GridView ID="dgvDocList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

                <asp:TemplateField HeaderText="Document Type" SortExpression="strDocName">
                <ItemTemplate><asp:Label ID="lblDocumentType" runat="server" Text='<%# Bind("strDocName") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="FTP Path" SortExpression="strFtpPath">
                <ItemTemplate><asp:Label ID="lblFTPPath" runat="server" Text='<%# Bind("strFtpPath") %>' Width="180px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="180px"/></asp:TemplateField>

                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView></td>
            </tr> 
            <tr>
                <td style="text-align:left;" colspan="9"><asp:Label ID="Label9" runat="server" Text="CHALLAN NO.:" CssClass="lbl"></asp:Label><asp:Label ID="lblIssuedBy" runat="server" Text="Issued By" CssClass="lbl" ForeColor="Blue"></asp:Label></td>  
                
                              
            </tr>
        </table>

    </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>