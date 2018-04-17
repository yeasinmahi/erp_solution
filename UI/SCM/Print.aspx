<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="UI.SCM.Print" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
      <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />

    

    <script type="text/javascript">
        $("[id*=txtTransferQty]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr"); 
                    var IssueQty = parseFloat($(this).val())
                    var StockQty = parseFloat($("[id*=lblStockQty]", row).html()); 
                    if (StockQty >= IssueQty) {

                    }
                    else {
                        $("[id*=txtTransferQty]", row).val('0');
                        alert("Please Check Issue Quantity");
                    }

                }
            }
        });

        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; }
        }
 </script>
   
      

    
     <script type="text/javascript">
         
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
</script>  

    <style type="text/css">
        .GridviewScrollHeader TH, .GridviewScrollHeader TD 
{ 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #EFEFEF; 
    text-align: left; 
    vertical-align: bottom; 
} 
.GridviewScrollItem TD 
{ 
    padding: 5px; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager  
{ 
    border-top: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager TD 
{ 
    padding-top: 3px; 
    font-size: 14px; 
    padding-left: 5px; 
    padding-right: 5px; 
} 
.GridviewScrollPager A 
{ 
    color: #666666; 
}
.GridviewScrollPager SPAN

{

    font-size: 16px;

    font-weight: bold;

}
    </style>
    
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
            background: white;
        }
        .ddList {}
        .txtBox {}
        </style> 
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
  
               <div class="tabs_container" align="left" >WH Location Transfer </div>
                <table>
                <tr>
                <td style="text-align:left;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server"  AutoPostBack="True"     ></asp:DropDownList></td>                                                                                      
             
                <td><asp:RadioButton ID="radItem" runat="server" GroupName="Location"  AutoPostBack="true" Text="Item"    /></td>
                <td><asp:RadioButton ID="radLocation" runat="server" GroupName="Location" AutoPostBack="true" Text="Location"    /></td>
                </td>   
                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>            
                <td style="text-align:left;"  ><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px"   ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
                ServiceMethod="GetItemSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender> 
                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="true"     CssClass="ddList"  Width="300px"  Font-Bold="False"  >
                </asp:DropDownList> </td>
               
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server"   Text="Location List : "></asp:Label></td>            
                <td><asp:DropDownList ID="ddlLocation2" runat="server" AutoPostBack="false"    Width="300px"  Font-Bold="False" >
                </asp:DropDownList> </td>
                </tr>
                <tr>
                <td colspan="4" style="text-align:right;"><asp:Button ID="Show" runat="server" Text="Show"  AutoPostBack="true" OnClick="Show_Click"        />
                <asp:Button ID="btnSubmit" runat="server" Text="Transfer"       />
                </td>
                </tr>
                </table> 
               <table>
                 
               <asp:GridView ID="dgvWHLocation" runat="server" AutoGenerateColumns="False"    Width="100%" GridLines="None"> 
                <Columns>

                   <%-- <asp:BoundField HeaderText="ProductID" DataField="intLocation" ItemStyle-BackColor="#EFEFEF" /> 
        <asp:BoundField HeaderText="Name" DataField="strLocationName" ItemStyle-BackColor="#EFEFEF" /> 
        <asp:BoundField HeaderText="ProductNumber" DataField="intItem" /> 
        <asp:BoundField HeaderText="SafetyStockLevel" DataField="strItem" /> 
        <asp:BoundField HeaderText="ReorderPoint" DataField="strUoM" /> 
        <asp:BoundField HeaderText="StandardCost" DataField="strItem" /> 
        <asp:BoundField HeaderText="ListPrice" DataField="strItem" /> 
        <asp:BoundField HeaderText="Weight" DataField="strItem" /> 
        <asp:BoundField HeaderText="SellStartDate" DataField="strItem" /> --%>
                <asp:TemplateField HeaderText="SL">        
                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="Location Id" Visible="false">
                <ItemTemplate><asp:Label ID="lblLocId" runat="server" Text='<%# Bind("intLocation") %>'></asp:Label> </ItemTemplate>
                </asp:TemplateField>                         
                <asp:TemplateField HeaderText="Location Name" Visible="true"> 
                <ItemTemplate><asp:Label ID="lblLocName"  Width="200px" runat="server" Text='<%# Bind("strLocationName") %>'></asp:Label> </ItemTemplate>
                </asp:TemplateField>  
         
                <asp:TemplateField HeaderText="Item Id" Visible="true">
                <ItemTemplate><asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItem") %>'></asp:Label> </ItemTemplate>
                </asp:TemplateField>                         
                <asp:TemplateField HeaderText="ItemName" Visible="true">
                <ItemTemplate><asp:Label ID="lblItemName"   runat="server" Text='<%# Bind("strItem") %>'></asp:Label> </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="UOM" Visible="true">
                <ItemTemplate><asp:Label ID="lblUom"   runat="server" Text='<%# Bind("strUoM") %>'></asp:Label> </ItemTemplate>
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Stock Qty" Visible="true">
                <ItemTemplate><asp:Label ID="lblStockQty" runat="server" Text='<%# Bind("monStock") %>' DataFormatString="{0:N2}"></asp:Label> </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Stock Value"  >
                <ItemTemplate><asp:Label ID="lblStockValue" runat="server" Text='<%# Bind("monValue") %>' DataFormatString="{0:N2}"></asp:Label> </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Transfer Qty" Visible="true">
                <ItemTemplate><asp:TextBox ID="txtTransferQty" Width="100" runat="server" CssClass="txtBox" Text='<%# Bind("transferQty") %>' DataFormatString="{0:N2}"></asp:TextBox> </ItemTemplate>
                </asp:TemplateField> 
          
                <asp:TemplateField HeaderText="Checked"> <ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate>
                </asp:TemplateField>

                </Columns>
                    <HeaderStyle CssClass="GridviewScrollHeader" /> 
                     <RowStyle CssClass="GridviewScrollItem" /> 
                  <PagerStyle CssClass="GridviewScrollPager" /> 
                </asp:GridView>  
                
           
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script> 
   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script> 
  <script src="../Content/JS/gridviewscroll.min.js"></script>
  
           <script type="text/javascript"> 

               $(document).ready(function () {
                   gridviewScroll();
               });

               function gridviewScroll() {
                   $('#<%=dgvWHLocation.ClientID%>').gridviewScroll({
                       width: 1200,
                       height: 200,
                       freezesize: 2
                   });
               } 
</script>
            </table>
<%--=========================================End My Code From Here=================================================--%>
      
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>
   
</body>

</html>

