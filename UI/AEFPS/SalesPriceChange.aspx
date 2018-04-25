<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesPriceChange.aspx.cs" Inherits="UI.AEFPS.SalesPriceChange" %>

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
       
        $("[id*=txtSalesPrice]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                      
                    var salsPrice = parseFloat($(this).val());
                    
                    var stockQty = $("[id*=lblStockQty]", row).html();


                    if (  stockQty<1 || salsPrice <1) {
                       
                        $("[id*=txtSalesPrice]", row).val('0');

                            alert("Please Check Sales Price or Stock Qty");
                        
                    }
                    else {
                         
                    }

                }
            }
        });

       
</script>
    
 

   <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnTFare" runat="server" />
        
       <div class="tabs_container">Price Change From<hr /></div>
         <table>
       <tr>
           
            <td style="text-align:right;"><asp:Label ID="lblMrrNo" runat="server" CssClass="lbl" Text="MRR No"></asp:Label></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlMrrNo" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlMrrNo_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

           <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
           </td>
            
           
       </tr>
             
            
             </table>
        <table>
            
         <tr><td> 
            <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intItemID"><ItemTemplate>            
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intAutoID"><ItemTemplate>            
            <asp:Label ID="lblAutoID" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ItmMaster" Visible="false" SortExpression="intItemMasterID"><ItemTemplate>            
            <asp:Label ID="lblItemMaster" runat="server" Text='<%# Bind("intItemMasterID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                
               
            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="MRR Qty"   SortExpression="numReceiveQty"><ItemTemplate>            
            <asp:Label ID="lblMrrQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
                         
            <asp:TemplateField HeaderText="Mrr Rate" ItemStyle-HorizontalAlign="right" SortExpression="monFCRate" >
            <ItemTemplate><asp:Label ID="lblFCRatet" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFCRate"))) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="monFCTotal" >
            <ItemTemplate><asp:Label ID="lblTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFCTotal"))) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField> 
                
            <asp:TemplateField HeaderText="Remain" ItemStyle-HorizontalAlign="right" SortExpression="monRemaingQty" >
            <ItemTemplate><asp:Label ID="lblRemaingQty" runat="server"  DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monRemaingQty"))) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="Stock Qty" ItemStyle-HorizontalAlign="right" SortExpression="monSalesQty" >
            <ItemTemplate><asp:Label ID="lblStockQty" Width="60px"   runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monSalesQty"))) %>'></asp:Label></ItemTemplate>           
            <ItemStyle HorizontalAlign="Left" Width="10px" /> </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="Last Price" ItemStyle-HorizontalAlign="right" SortExpression="monSalesPrice" >
            <ItemTemplate><asp:Label ID="lblLastPrice" Width="60px"   runat="server"   Text='<%# (decimal.Parse(""+Eval("monSalesPrice"))) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sales Price" ItemStyle-HorizontalAlign="right" SortExpression="monSalesPrice" >
            <ItemTemplate><asp:TextBox ID="txtSalesPrice" Width="60px" CssClass="txtBox" runat="server"  Text="0"></asp:TextBox></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Expire Date" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="monPrtQty" >
            <ItemTemplate><asp:TextBox ID="txtExpireDate" runat="server" Width="100px"    CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtExpireDate">
            </cc1:CalendarExtender> </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" />
            </asp:TemplateField>     

            <asp:TemplateField HeaderText="Change"><ItemTemplate>
            <asp:Button ID="btnSave" runat="server" Text="Price Change" OnClientClick="funConfirmAll()" OnClick="btnSave_Click"  />
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        </table>
        </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>