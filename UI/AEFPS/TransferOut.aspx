<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferOut.aspx.cs" Inherits="UI.AEFPS.TransferOut" %>
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

        $(function () {
            ////$("[id*=txtQty]").val("0");
        });

        $("[id*=txtQty]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });
        //*** txtQty Selection Change Start ****************************************************************************
        $("[id*=txtQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=lblRate]", row).html()) * ($(this).val())).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            var grandTotal = 0;
            var grandTotalqty = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            
            $("[id*=txtQty]").each(function () {
                grandTotalqty = grandTotalqty + parseFloat($(this).val());
            });
            $("[id*=lblGrandTotalQty]").html(parseFloat(grandTotalqty.toString()).toFixed(2));
           
        });
        //*** txtQty Selection Change End ****************************************************************************        
        
    </script>
           
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
    
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
          
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> TRANSFER OUT FORM :<hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToWHName" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>         
        </tr>                
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="QR Code : "></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtQRCode" runat="server" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtQRCode_TextChanged"></asp:TextBox></td>              
            
            <td style="text-align:right;"><asp:Label ID="lblitms" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>   
            <td style="text-align:left;" colspan="3"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="210px" OnTextChanged="txtItem_TextChanged"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetFPSItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td> 
        </tr> 
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" ForeColor="Black" Text="" Width="1px" Height="1px" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="4"><hr /></td></tr>
        <tr><td colspan="4">Product List :<hr /></td></tr>    
        <tr>
        <td colspan="4">
            <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            FooterStyle-BackColor="#808080" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvItem_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Item Master ID" SortExpression="intMasterId" Visible="false">
            <ItemTemplate><asp:Label ID="lblItemMasterID" runat="server" Text='<%# Bind("intMasterId") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>    
                                
            <asp:TemplateField HeaderText="MRR ID" SortExpression="intMRRID" Visible="true">
            <ItemTemplate><asp:Label ID="lblMRRID" runat="server" Text='<%# Bind("intMRRID") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Code" SortExpression="strCode" Visible="true">
            <ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="strName">
            <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>' Width="230px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="230px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="strUOM">
            <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Stock Quantity" SortExpression="numStockQty">
            <ItemTemplate><asp:Label ID="lblStockQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numStockQty") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
            <FooterTemplate><asp:Label ID="lblStockQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalstockqty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="numSPrice">
            <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numSPrice") %>' Width="45px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="40px" />
            <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" SortExpression="vat">
            <ItemTemplate><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}" Text='<%# Bind("TQty") %>' Width="65px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="65px" />
            <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
            <ItemTemplate><asp:Label ID="lblTotalVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAmount"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval %>" /></FooterTemplate></asp:TemplateField>
                 
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>  
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnAdd" runat="server" CssClass="nextclick" ForeColor="Black" Text="Add" OnClick="btnAdd_Click" /></td>   
        </tr>
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4">Transfer Product List :<hr /></td></tr>
        <tr>
        <td colspan="4">
            <asp:GridView ID="dgvTransferItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            FooterStyle-BackColor="#808080" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvTransferItem_RowDataBound" OnRowDeleting="dgvTransferItem_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Item Master ID" SortExpression="masterid" Visible="false">
            <ItemTemplate><asp:Label ID="lblItemMasterID1" runat="server" Text='<%# Bind("masterid") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>    
                                
            <asp:TemplateField HeaderText="MRR ID" SortExpression="mrrid" Visible="true">
            <ItemTemplate><asp:Label ID="lblMRRID1" runat="server" Text='<%# Bind("mrrid") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Code" SortExpression="code" Visible="true">
            <ItemTemplate><asp:Label ID="lblCode1" runat="server" Text='<%# Bind("code") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblItemName1" runat="server" Text='<%# Bind("itemname") %>' Width="230px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="230px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblUOM1" runat="server" Text='<%# Bind("uom") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Stock Quantity" SortExpression="sqty">
            <ItemTemplate><asp:Label ID="lblStockQty1" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("sqty") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
            <FooterTemplate><asp:Label ID="lblStockQtyTotal1" runat="server" DataFormatString="{0:0.00}" Text="<%# totalstockqty1 %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="price">
            <ItemTemplate><asp:Label ID="lblRate1" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("price") %>' Width="45px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="40px" />
            <FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" SortExpression="tqty">
            <ItemTemplate><asp:Label ID="lblTQty1" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("tqty") %>' Width="65px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="65px" />
            <FooterTemplate><asp:Label ID="lblGrandTotalQty1" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty1 %>" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="amount">
            <ItemTemplate><asp:Label ID="lblTotalVal1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("amount"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblGrandTotal1" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval1 %>" /></FooterTemplate></asp:TemplateField>
                 
            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" ForeColor="Black" Text="Submit" OnClientClick = "ConfirmAll()" OnClick="btnSubmit_Click" /></td>   
        </tr>
        </table>
       
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>