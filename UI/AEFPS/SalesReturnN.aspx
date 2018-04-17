<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReturnN.aspx.cs" Inherits="UI.AEFPS.SalesReturnN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Transfer In </title>
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

        function hideGrid() {
            document.getElementById("divProduct").style.display = "none";
        }
    </script>  
    <script type="text/javascript">

        $(function () {
            ////$("[id*=txtQty]").val("0");
        });

        $("[id*=txtRQty]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { parseFloat($(this).val($(this).val()).toString()).toFixed(2); }
        });
        //*** txtQty Selection Change Start ****************************************************************************
        $("[id*=txtRQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {

                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    $("[id*=lblTotalVal]", row).html((parseFloat($("[id*=lblPrice]", row).html()) * ($(this).val())).toFixed(2));
                }
            } else {
                $(this).val('');
            }

            //var at = parseFloat($("[id*=lblAIT]", row).html());
            //var atc = $("[id*=lblAIT]", row).val();
            //var atch = $("[id*=lblAIT]", row).html();

            var grandTotal = 0;
            var grandTotalqty = 0;
            var grandTotalVat = 0;
            var grandTotalait = 0;

            $("[id*=lblTotalVal]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).html());
            });
            $("[id*=lblGrandTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));            
        });
        //*** txtQty Selection Change End ****************************************************************************        
       
</script>  
    
</head>
<body>
    <form id="frmTransferIn" runat="server">        
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
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> SALES RETURN<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>                
                <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH Name :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Invoice No."></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSVCode" runat="server" CssClass="txtBox1"></asp:TextBox></td>              
                
            </tr> 
            <tr>                
                <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>                         
            </tr> 
            
            <tr><td colspan="5"><hr /></td></tr>             
        </table> 
    </div>
    <div id="divProduct">
        <table>
            <tr><td><hr /></td></tr>
            <tr><td><asp:GridView ID="dgvProduct" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Center" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvProduct_RowDataBound"  OnRowCommand="dgvProduct_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />      
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="ItemID" SortExpression="intMasterID" Visible="false">
                <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intMasterID") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Code" SortExpression="strVoucher">
                <ItemTemplate><asp:Label ID="lblToCode" runat="server" Text='<%# Bind("strVoucher") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName">
                <ItemTemplate><asp:Label ID="lblProductName" runat="server" Text='<%# Bind("strItemName") %>' Width="246px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="246px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="UOM" SortExpression="strUOM">
                <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="80px" /></asp:TemplateField>
                                
                <asp:TemplateField HeaderText="Quantity" SortExpression="numTQty">
                <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numTQty") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>
            
                <asp:TemplateField HeaderText="Return Quantity" SortExpression="qty">
                <ItemTemplate><asp:TextBox ID="txtRQty" runat="server" CssClass="txtBox" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="60px"></asp:TextBox>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>
                    
                <asp:TemplateField HeaderText="Price" SortExpression="monPrice">
                <ItemTemplate><asp:Label ID="lblPrice" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monPrice") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" /></asp:TemplateField>
            
                <asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="total">
                <ItemTemplate><asp:Label ID="lblTotalVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("total"))) %>'></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalval %>" /></FooterTemplate></asp:TemplateField>
                        
                <%--<asp:TemplateField HeaderText="Total Amount" SortExpression="monTotalAmount">
                <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monTotalAmount") %>' Width="95px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="95px" />
                <FooterTemplate><asp:Label ID="lblAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalamount %>" /></FooterTemplate></asp:TemplateField>--%>
                    
                <asp:TemplateField HeaderText="Return" ItemStyle-HorizontalAlign="Center" SortExpression="">
                <ItemTemplate><asp:Button ID="btnReturn" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="R"  
                Text="Return"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                                         
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
            </td></tr> 
            <tr><td><hr /></td></tr> 
            <tr>
                <td style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSave" runat="server" class="myButtonGrey" Text="Save" Width="100px" OnClientClick = "ConfirmAll()" OnClick="btnSave_Click"/></td>        
            </tr>
            <tr><td><hr /></td></tr> 
        </table> 
    </div>
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>