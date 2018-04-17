<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSales.aspx.cs" Inherits="UI.AEFPS.OrderSales" %>

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
       
        $("[id*=txtSalesQty]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr"); 
                    var SalsQty = parseFloat($(this).val());                     
                    var stockQty = $("[id*=lblStockQty]", row).html(); 
                    if (stockQty >= SalsQty) { }
                      
                    else {
                        $("[id*=txtSalesQty]", row).val('0');

                        alert("Please Check Stock Qty");
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

        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
            
        }

        function ClosehdnDivision() {

            $("#hdnDivision").fadeOut("slow");
        }

 </script>

   <script>
        function CloseMyDialog() {
            $("#myDialog").dialog("close");
        }
        function OpenMyDialog() {
            //$("#openDialog").click(function () { $("#myDialog").dialog('open') });
            $("#myDialog").dialog('open');
            document.getElementById('hdnDivision').style.visibility = 'visible';
            $("#myDialog").dialog({
                modal: true,
                autoOpen: true,
                width: ($(window).width() * .9),
                height: ($(window).height() * .9),
                title: "Menu Order",
                draggable: true,
                resizable: false,

                buttons: {
                    Ok: function () { $("#openDialog").click(function () { $("#myDialog").dialog('close') }); }
                }
            });
        };
        </script>

    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px;           
        -moz-border-colors:25px;
        border-radius:25px;
        } 
        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left:40px;  margin-top:100px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>

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
    <div style="height: 50px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnConfirm" runat="server" /> 
        
       <div class="tabs_container">Online Order From<hr /></div>
         <table>
       <tr>
       <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
       <td style="text-align:left;">
       <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"  ></asp:DropDownList>                                                                                       
       </td> 
       </tr>
             
         <tr><td colspan="2"> 
            <asp:GridView ID="dgvOrder" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id"><ItemTemplate>            
            <asp:Label ID="lblOrderId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="OrderNumber" Visible="true" SortExpression="strOrderNumber"><ItemTemplate>            
            <asp:Label ID="lblOrderCode" runat="server" Text='<%# Bind("strOrderNumber") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="OrderDate" Visible="false" SortExpression="dteDate"><ItemTemplate>            
            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
            <asp:TemplateField HeaderText="OrderByEnroll" Visible="false" SortExpression="intEnroll"><ItemTemplate>            
            <asp:Label ID="lblOrderByEnroll" runat="server" Text='<%# Bind("intEnroll") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="OrderBy" Visible="true" SortExpression="strName"><ItemTemplate>            
            <asp:Label ID="lblOrderBy" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
               
                        
            <asp:TemplateField HeaderText="Order Qty"   SortExpression="TotalQty"><ItemTemplate>            
            <asp:Label ID="lblTotalQty" runat="server" Text='<%# Bind("TotalQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Detalis"  ><ItemTemplate>            
            <asp:Button ID="btnDetalis" runat="server" OnClick="btnDetalis_Click" Text='Detalis'></asp:Button></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField> 
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr> 
        </table>
        </div>
         <div id="myDialog"  >
            
             <%--class="hdnDivision"--%>
         <div id="hdnDivision"   class="hdnDivision"  title="Online Order" style="width:auto;  height:500px;">
          <table>       
           <tr>
               <td style="text-align:right"> <asp:Button ID="btnSubmit" runat="server" Text='Submit' OnClientClick="funConfirmAll()" OnClick="btnSubmit_Click"></asp:Button> 
               <asp:Button ID="btnClose" runat="server" Text='Close'   OnClick="btnClose_Click"></asp:Button></td>

           </tr>  
         <tr><td> 
            <asp:GridView ID="dgvDetalis" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id"><ItemTemplate>            
            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="OrderNumber" Visible="true" SortExpression="strOrderNumber"><ItemTemplate>            
            <asp:Label ID="lblOrderCode" runat="server" Text='<%# Bind("strOrderNumber") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="OrderDate" Visible="false" SortExpression="dteDate"><ItemTemplate>            
            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ItemName" Visible="true" SortExpression="strName"><ItemTemplate>            
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intItemId"><ItemTemplate>            
            <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Order Qty"   SortExpression="orderQty"><ItemTemplate>            
            <asp:Label ID="lblOrderQty" runat="server" Text='<%# Bind("orderQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
           
            <asp:TemplateField HeaderText="StockQty"   SortExpression="stockQty"><ItemTemplate>            
            <asp:Label ID="lblStockQty" runat="server" Text='<%# Bind("stockQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Price"   SortExpression="salesPrice"><ItemTemplate>            
            <asp:Label ID="lblSalesPrice" runat="server" Text='<%# Bind("salesPrice") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="SalesQty"   SortExpression="salesQty"><ItemTemplate>            
            <asp:TextBox ID="txtSalesQty" runat="server" Text='<%# Bind("salesQty") %>'></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

           
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
