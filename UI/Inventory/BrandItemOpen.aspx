<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemOpen.aspx.cs" Inherits="UI.Inventory.BrandItemOpen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

  <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    
     <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=dgv.ClientID%>').gridviewScroll({
                 width: 800,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>

    
     <script type="text/javascript">
         $(document).ready(function () {
             SearchItemText();
         });
         function Changed() {
             document.getElementById('hdfItemSearchBoxTextChange').value = 'true';
         }
         function SearchItemText() {
             $("#txtItem").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "BrandItemAllotmentToSupplier.aspx/GetAutoCompleteBrandItemName",
                         data: "{'prefix':'" + document.getElementById('txtItem').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                         
                     });
                 }
             });
         }

         $(document).ready(function () {
             SearchSupplierlistText();
         });
         function Changed() {
             document.getElementById('hdfSupplierNameserachboxchange').value = 'true';
         }
         function SearchSupplierlistText() {
             $("#txtSupplierName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "BrandItemStockEntry.aspx/GetAutoCompleteSupplierName",
                         data: "{'prefix':'" + document.getElementById('txtSupplierName').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                     });
                 }
             });
         }

  </script>
    <script type="text/javascript">
        function ConfirmAll() {
            document.getElementById("hdnconfirm").value = "0";
         
            var txtItemName = document.forms["frmpdv"]["txtItem"].value;
            var supplierNAME = document.forms["frmpdv"]["txtSupplierName"].value;
            if (txtItemName.length <= 0 || txtItemName == "") { alert("Please enter valid Product name ."); }
            else if (supplierNAME.length <= 0 || supplierNAME == "") { alert("Please enter valid Supllier name ."); }
            else { document.getElementById("hdnconfirm").value = "1"; }
        }
       
  </script>
    <script>

        function Calculate() {




            var i;
        var grid = document.getElementById("<%= dgv.ClientID%>");
        for ( i = 0; i < grid.rows.length - 1; i++) {
            var quantity = $("input[id*=txtQuantity]")
            var chk = $("input[id*=txtQuantity]")
        var testvalue = quantity[i].value;
        var tv = parseFloat(testvalue);
        
             //$('input[type="checkbox"]').attr("checked", "checked");
        if (tv > 0) {
           
            $('input[type="checkbox"]').attr("checked", "checked");

                }
            }

        }
      

              

</script> 

     
</head>
<body>
     <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   
<%--=========================================Start My Code From Here===============================================--%>


         <div class="leaveApplication_container"> <div class="tabs_container"> Brand Item allotment send to supplier : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnunitid" runat="server"/><hr /></div>
       <div>
              <table border="0"; style="width:Auto"; >
             
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                 <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                        DataValueField="intUnitID">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td> 
               
       
                <td style="text-align:right;"><asp:Label ID="lblItemName" CssClass="lbl" runat="server"  Text="Item Name: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtItemName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>
                  <tr>
                      <td>
                          <asp:Label ID="lblUOM" runat="server" Text="UOM"></asp:Label>
                      </td>
                    <td>
                                <asp:HiddenField ID="hdnUOM" runat="server" />
                                <asp:DropDownList ID="ddlUOM" runat="server"  AutoPostBack="True" OnDataBound="ddlUOM_DataBound" OnSelectedIndexChanged="ddlUOM_SelectedIndexChanged" DataSourceID="odsuomrl" DataTextField="strUOM" DataValueField="intID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsuomrl" runat="server" SelectMethod="GetUOMRelationBrand" TypeName="HR_BLL.TourPlan.TourPlanning">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnProduct" DefaultValue="233" Name="productId" PropertyName="Value" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                           
                            </td>

                      <td>
                          <asp:Label ID="lblReport" runat="server" Text="Catg."></asp:Label>
                      </td>
                       <td>
                          <asp:DropDownList ID="ddlrpttype" runat="server" CssClass="ddl">
                              <asp:ListItem Selected="True" Text="Submit" Value="1"></asp:ListItem>
                              <asp:ListItem Text=" Report" Value="2"></asp:ListItem>
                          </asp:DropDownList>
                           <asp:HiddenField ID="hdnunit" runat="server" />
                           <asp:HiddenField ID="hdnAction" runat="server" />
                      </td>
                  </tr>
                
                     
             

           <tr class='tblroweven'>
       
    <td style="text-align:right;" colspan="3"><asp:Button ID="btnAdd" runat="server" Text="ADD" Font-Bold="true"
    OnClientClick = "Confirm()" OnClick="btnAdd_Click"></asp:Button></td>
        <td  style="text-align:right;"><asp:Button ID="btnSubmit" BackColor="#ffffcc" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click" /></td>
    </tr>
                 

            </table>
  </div>

             <div>
                 <div>
       <table>
    <tr class=""><td style="text-align:justify;">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnitemname" runat="server" Value='<%# Bind("itemname") %>' /></ItemTemplate></asp:TemplateField> 
   

    
             
    <asp:TemplateField HeaderText="Item Name" SortExpression="item">
    <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("itemname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="UOM" SortExpression="uom">
    <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

      
        

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
        <ControlStyle Font-Bold="True" ForeColor="Red" />
        </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    </td></tr>
    </table></div>
             </div>


<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>
