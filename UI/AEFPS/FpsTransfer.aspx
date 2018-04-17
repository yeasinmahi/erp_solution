<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FpsTransfer.aspx.cs" Inherits="UI.AEFPS.FpsTransfer" %>
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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
           
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
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> TRANSFER OUT FORM :<hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFromWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToWHName" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>         
        </tr>         
        
        <tr><td colspan="4"><hr /></td></tr>
        <tr> 
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="QR Code :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQRCode" runat="server" CssClass="txtBox" OnTextChanged="txtQRCode_TextChanged"></asp:TextBox></td>   
            
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Item Name :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox"></asp:TextBox></td>                          
        </tr> 
        <tr> 
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Stock :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox"></asp:TextBox></td>   
            
            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Quantity :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox"></asp:TextBox></td>                          
        </tr> 
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" ForeColor="Black" Text="" Width="1px" Height="1px" OnClick="btnShow_Click"/></td>   
        </tr>
            
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4">Transfer Product List :<hr /></td></tr>  
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvProductDTR" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvProductDTR_RowDataBound" OnRowDeleting="dgvProductDTR_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="QRCode" Visible="false" SortExpression="qrcode"><ItemTemplate>            
            <asp:Label ID="lblQRCodeR" runat="server" Text='<%# Bind("qrcode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="intRefSalesID" Visible="false" SortExpression="reffid"><ItemTemplate>            
            <asp:Label ID="lblReffIDR" runat="server" Text='<%# Bind("reffid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="ProductID" Visible="false" SortExpression="itemid"><ItemTemplate>            
            <asp:Label ID="lblProductIDR" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name" SortExpression="itemname"><ItemTemplate>            
            <asp:Label ID="lblProductNameR" runat="server" Text='<%# Bind("itemname") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="285px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="uom"><ItemTemplate>            
            <asp:Label ID="lblUOMR" runat="server" Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="60px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblQtyR" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("qty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="right" SortExpression="price" >
            <ItemTemplate><asp:Label ID="lblPriceR" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("price"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                                     
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="amount">
            <ItemTemplate><asp:Label ID="lblAmountR" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("amount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalamount1 %>' /></FooterTemplate></asp:TemplateField>
                             
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr><td colspan="4"><hr /></td></tr> 
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnReturn" runat="server" CssClass="nextclick" ForeColor="Black" Text="Return" OnClientClick="ConfirmAll()" OnClick="btnReturn_Click"/></td>   
        </tr>

        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4">Pending Report:<hr /></td></tr>
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvProductDT" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvProductDT_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="strQRCode" Visible="false" SortExpression="strQRCode"><ItemTemplate>            
            <asp:Label ID="lblQRCode" runat="server" Text='<%# Bind("strQRCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ProductID" Visible="false" SortExpression="intProductID"><ItemTemplate>            
            <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="To WH" SortExpression="ToWH"><ItemTemplate>            
            <asp:Label ID="lblToWH" runat="server" Text='<%# Bind("ToWH") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Voucher No." SortExpression="strVoucher"><ItemTemplate>            
            <asp:Label ID="lblVoucherNo" runat="server" Text='<%# Bind("strVoucher") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="285px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="strUOM"><ItemTemplate>            
            <asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="60px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("numQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="right" SortExpression="monPrice" >
            <ItemTemplate><asp:Label ID="lblPrice" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPrice"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text = '' /></FooterTemplate></asp:TemplateField>
                                     
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="monAmount">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAmount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="80px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalamount %>' /></FooterTemplate></asp:TemplateField>
              
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
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