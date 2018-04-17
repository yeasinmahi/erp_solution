<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RePrintQrcode.aspx.cs" Inherits="UI.AEFPS.RePrintQrcode" %>

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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        
       
 

        $("[id*=txtPrtQty]").live("change", function () {
        if (!jQuery.trim($(this).val()) == '') {
            if (!isNaN(parseFloat($(this).val()))) {
                var row = $(this).closest("tr");
                var salsQty = $("[id*=txtSalesQtys]", row).val();
                var printQty = parseFloat($(this).val())
                var salsPrice = $("[id*=txtSalesPrice]", row).val();
                var remainqty = $("[id*=lblRemaingQty]", row).html();
                
                
                if (salsPrice > 0 && salsQty>0)
                {
                    if (remainqty >= salsQty * printQty) {
                    }
                    else {
                        $("[id*=txtPrtQty]", row).val('0');
                        alert("Please Check Print Qty");
                    }
                }
                else
                {
                    $("[id*=txtSalesPrice]", row).val('0');
                    $("[id*=txtPrtQty]", row).val('0');
                    alert("Please Check Sales Price and Sales Qty");
                }
               
            }
        }
    });
 
       
</script>
 

<script> function CloseWindow() {
     window.close();      
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnDA" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnTFare" runat="server" />
        
       <div class="tabs_container">Re-Print<hr /></div>
        
       <tr>
           
            <td style="text-align:right;"><asp:Label ID="lblMrrNo" runat="server" CssClass="lbl" Text="MRR No"></asp:Label></td>
            <td style="text-align:left;">
            <asp:TextBox ID="TxtBatchNo" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px"  ></asp:TextBox>                                                                                       
            </td>

           <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
           </td>
           <td><asp:Button ID="btnView" runat="server" Text="View" OnClick="btnView_Click" /></td>
       </tr>
        
         <tr><td colspan="6"> 
            <asp:GridView ID="dgvPrintView" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intItemID"><ItemTemplate>            
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                
               
            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

             <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
             <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
             </asp:TemplateField>
            
            <asp:TemplateField HeaderText="MRR Qty"   SortExpression="numReceiveQty"><ItemTemplate>            
            <asp:Label ID="lblMrrQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

           <asp:TemplateField HeaderText="Stock Qty"   SortExpression="numReceiveQty"><ItemTemplate>            
            <asp:Label ID="lblMrrQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Sales Qty"   SortExpression="numReceiveQty"><ItemTemplate>            
            <asp:Label ID="lblMrrQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>           
                         
            <asp:TemplateField HeaderText="Mrr Rate" ItemStyle-HorizontalAlign="right" SortExpression="monFCRate" >
            <ItemTemplate><asp:Label ID="lblFCRatet" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFCRate"))) %>'></asp:Label></ItemTemplate>
           </asp:TemplateField>                
            
             <asp:TemplateField HeaderText="Sales Rate" ItemStyle-HorizontalAlign="right" SortExpression="monSalesPrice" >
            <ItemTemplate><asp:Label ID="lblSalesPrice" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monSalesPrice"))) %>'></asp:Label></ItemTemplate>
             </asp:TemplateField> 

            <asp:TemplateField HeaderText="Sales Qty" ItemStyle-HorizontalAlign="right" SortExpression="monSalesQty" >
            <ItemTemplate><asp:TextBox ID="txtSalesQtys" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monSalesQty"))) %>'></asp:TextBox></ItemTemplate>
             </asp:TemplateField> 

            <asp:TemplateField HeaderText="Print Qty" ItemStyle-HorizontalAlign="right" SortExpression="monPrtQty" >
            <ItemTemplate><asp:Label ID="txtPrtQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPrtQty"))) %>'></asp:Label></ItemTemplate>
             </asp:TemplateField>

            <asp:TemplateField HeaderText="QrCode" ItemStyle-HorizontalAlign="right" SortExpression="monPrtQty" >
            <ItemTemplate><asp:Label ID="txtPrtQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPrtQty"))) %>'></asp:Label></ItemTemplate>
             </asp:TemplateField>
                                   
                                             
            <asp:TemplateField HeaderText="Print"><ItemTemplate>
            <asp:Button ID="btnPrint" runat="server" Text="Print"  OnClick="btnPrint_Click" />
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 

        </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
