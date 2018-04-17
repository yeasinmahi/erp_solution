<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemReceiveFromSupplierPointEnd.aspx.cs" Inherits="UI.Inventory.BrandItemReceiveFromSupplierPointEnd" %>

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
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />

    
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
                         url: "BrandItemReceiveFromSupplierPointEnd.aspx/GetAutoCompleteBrandItemName",
                         data: "{'prefix':'" + document.getElementById('txtItem').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                         //GetAutoCompleteBrandItemName
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
                         url: "BrandItemReceiveFromSupplierPointEnd.aspx/GetAutoCompleteSupplierName",
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
           function Confirm() {
               document.getElementById("hdnconfirm").value = "0";
               var txtItem = document.forms["frmpdv"]["txtItem"].value;

               var txtChallanNumber = document.forms["frmpdv"]["txtChallan"].value;
               var txtQuantity = document.forms["frmpdv"]["txtQuantity"].value;
               var txtSupplierName = document.forms["frmpdv"]["txtSupplierName"].value;
               if (txtChallanNumber == null || txtChallanNumber == "") { alert("Please enter valid Challan ."); }
               else if (txtItem == null || txtItem == "") { alert("Please select item list ."); }
               else if (txtSupplierName == null || txtSupplierName == "") { alert("Please select Supplier Name ."); }
               else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00") { alert("Please enter valid quantity ."); }
               else { document.getElementById("hdnconfirm").value = "1"; }
           }
           function isDecimal(value) {
               return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
           }



           function Viewdetails(id) {
               window.open('BradndItemRequisitonDetaills.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
           }
</script>


</head>
<body>
     <form id="frmpdv" runat="server">
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


         <div class="leaveApplication_container"> <div class="tabs_container"> Brand Item Receive Information by Point : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnunitid" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >
             
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtDueDate', { 'dateFormat': 'Y-m-d' });</script></td>
  
                <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Item List : "></asp:Label></td>
                <td colspan="1"><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfItemSearchBoxTextChange" runat="server" /><asp:HiddenField ID="hdfSupplierNameserachboxchange" runat="server" />
               <asp:HiddenField ID="hdnstation" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnAction" runat="server"/><asp:HiddenField ID="hdnunit" runat="server"/><asp:HiddenField ID="hdnwh" runat="server"/>
                     </td>
                </tr>
          
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
                <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" Text="0.00"></asp:TextBox></td>
       
                <td style="text-align:right;"><asp:Label ID="lblpo" CssClass="lbl" runat="server"  Text="P.O Number: "></asp:Label></td>
                <td><asp:TextBox ID="txtpo" runat="server" CssClass="txtBox"></asp:TextBox>
    
                </td>
                </tr>
                <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lblChallan" CssClass="lbl" runat="server"  Text="Challan No. : "></asp:Label></td>
                <td><asp:TextBox ID="txtChallan" runat="server" CssClass="txtBox"></asp:TextBox>
       
                <td style="text-align:right;"><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server"  Text="Supplier Name: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtSupplierName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>

               <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Ship Point: "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
                <td colspan="3"><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="True" CssClass="ddList"  OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" DataTextField="pointname" DataValueField="pointID" DataSourceID="odsDirectPointList"></asp:DropDownList>
               
               
                    <asp:ObjectDataSource ID="odsDirectPointList" runat="server" SelectMethod="GetAclDirectPointList" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
               
               
               
         
               
                </td>
                   

               </tr>
               

                <tr class='tblroweven'>
       
                <td style="text-align:right;" colspan="3"><asp:Button ID="btnAdd" runat="server" Text="ADD" Font-Bold="true"
                OnClientClick = "Confirm()" OnClick="btnAdd_Click"></asp:Button><asp:HiddenField ID="HiddenField1" runat="server" /></td>
                <td  style="text-align:right;"><asp:Button ID="btnSubmit" BackColor="#ffffcc" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click1" /></td>
                </tr>
 
            </table>
  </div>
 <div>
       <table>
    <tr class=""><td style="text-align:justify;">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnitmid" runat="server" Value='<%# Bind("itemid") %>' /></ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="Due Date" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lbldudt" runat="server" Text='<%# Bind("dudt") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

    
             
    <asp:TemplateField HeaderText="Item" SortExpression="item">
    <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

     

    <asp:TemplateField HeaderText="Quantity" SortExpression="quantity">
    <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("quantity") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        <asp:TemplateField HeaderText="Challan" SortExpression="challan">
    <ItemTemplate><asp:Label ID="lblchallan" runat="server" Text='<%# Bind("challan") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="suppliername" SortExpression="suppliername">
    <ItemTemplate><asp:Label ID="lblsuppliername" runat="server" Text='<%# Bind("suppliername") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
    

        <asp:TemplateField HeaderText="Itemid" SortExpression="itemid">
    <ItemTemplate><asp:Label ID="lblitemid" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        <asp:TemplateField HeaderText="PO" SortExpression="po">
    <ItemTemplate><asp:Label ID="lblpo" runat="server" Text='<%# Bind("po") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    
    <asp:TemplateField HeaderText="SupplierID" SortExpression="supplierid">
    <ItemTemplate><asp:Label ID="lblsupplierid" runat="server" Text='<%# Bind("supplierid") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
     
       
        <asp:TemplateField HeaderText="whid" SortExpression="whid">
    <ItemTemplate><asp:Label ID="lblwhid" runat="server" Text='<%# Bind("whid") %>'></asp:Label></ItemTemplate>
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

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
