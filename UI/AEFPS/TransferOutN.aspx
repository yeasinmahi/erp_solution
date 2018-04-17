<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferOutN.aspx.cs" Inherits="UI.AEFPS.TransferOutN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Transfer Out </title>
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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
    </script>    
    
</head>
<body>
    <form id="frmTransferOut" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> TRANSFER OUT<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>                
                <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH Name :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To WH Name :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlToWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>                      
            </tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="QR Code"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtQRCode" runat="server" CssClass="txtBox1" AutoPostBack="true" OnTextChanged="txtQRCode_TextChanged"></asp:TextBox></td>              
                <td style="text-align:right; width:15px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                
                <td style="text-align:right;"><asp:Label ID="lblitms" CssClass="lbl" runat="server" Text="Item List"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>   
                <td style="text-align:left;"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox1" AutoPostBack="true" OnTextChanged="txtItem_TextChanged" TextMode="MultiLine" Height="30px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender></td> 
            </tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblEName" runat="server" Text="Stock Quantity :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtStockQty" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="Quantity" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr>
                <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnAdd" runat="server" class="myButtonGrey" Text="Add" Width="100px" OnClick="btnAdd_Click"/></td>        
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr><td colspan="5">   
                <asp:GridView ID="dgvProduct" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvProduct_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="ItemID" SortExpression="itemid" Visible="false">
                <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Product Code" SortExpression="itemcode">
                <ItemTemplate><asp:Label ID="lblProductCode" runat="server" Text='<%# Bind("itemcode") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name" SortExpression="itemname">
                <ItemTemplate><asp:Label ID="lblProductName" runat="server" Text='<%# Bind("itemname") %>' Width="246px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="246px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="UOM" SortExpression="uom">
                <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="80px" /></asp:TemplateField>
                                
                <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                <ItemTemplate><asp:Label ID="lblQuantity" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" />
                <FooterTemplate><asp:Label ID="lblQuantityTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate></asp:TemplateField>
            
                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />                       
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
            </td></tr> 
            <tr><td colspan="5"><hr /></td></tr> 
            <tr>
                <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSave" runat="server" class="myButtonGrey" Text="Save" Width="100px" OnClientClick = "ConfirmAll()" OnClick="btnSave_Click"/></td>        
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
        </table>   
    </div> 
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>