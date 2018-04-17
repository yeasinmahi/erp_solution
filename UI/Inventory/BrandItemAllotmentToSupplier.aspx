<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemAllotmentToSupplier.aspx.cs" Inherits="UI.Inventory.BrandItemAllotmentToSupplier" %>

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

             $('#<%=dgvAllotmentToSupplier.ClientID%>').gridviewScroll({
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
        var grid = document.getElementById("<%= dgvAllotmentToSupplier.ClientID%>");
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

     <script type="text/javascript">
         //function enable_cb(textbox) {
         //    if ($(textbox).val() != "") {
         //        $("checked").removeAttr("disabled");
         //    }
         //    else {
         //        $("checked").attr("disabled", true);
         //    }
         //}
         //function enable() {
         //    document.getElementById("checked").disabled = false;

         //}

         //function disable() {
         //    document.getElementById("checked").disabled = true;
         //}
         //var qnt = document.getElementById('txtQuantity').value;
         //if (qnt > 0) { document.getElementById("checked").disabled = false; }
         //else { document.getElementById("checked").disabled = true; }

     
    //function changeTextValue(chk) {
    //    //var currentTextID = $(chk).parents('tr').find('input[type="text"][id$="txtQuantity"]');
       
    //    //if (currentTextID.length > 1)

    //    //    chk.checked == true;
    //    //else
    //    //    chk.checked == false;

    //    $('input[type="text"]').keypress(function () {
    //        $('input[type="checkbox"]').attr("checked", "checked");
    //    });

    //}



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
                <td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtDueDate', { 'dateFormat': 'Y-m-d' });</script></td>
  
               
       
                <td style="text-align:right;"><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server"  Text="Supplier Name: "></asp:Label></td>
                <td>
                <asp:TextBox ID="txtSupplierName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
                </td>
                </tr>
             <tr>
                  <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Item List : "></asp:Label></td>
                   <td><asp:HiddenField ID="hdnAction" runat="server"/><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox></td>
                 <td style="text-align:right;"><asp:Label ID="lblProgramNameList" CssClass="lbl" runat="server" Text="Program Name: "></asp:Label></td>
                <td><asp:DropDownList ID="drdlProgramName" runat="server" DataSourceID="odsBrandMktProgramName" DataTextField="strProgramName" DataValueField="intID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsBrandMktProgramName" runat="server" SelectMethod="GetBrandMktProgramList" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                  </td>
             </tr>
                  <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
    <td colspan="3"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox"  Width="600" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
              <tr class="tblrowodd"><td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click1"/></td>
    </tr>

            </table>
  </div>
        <div>
            <table>
                 <tr><td>
        <asp:GridView ID="dgvAllotmentToSupplier" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odsAclPoint" OnRowDataBound="dgvAllotmentToSupplier_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
              <Columns>
                   <asp:BoundField DataField="sl" HeaderText="Serial No." SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
       
                   <asp:TemplateField HeaderText="All Direct Point  Name" SortExpression="ItemName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
        <asp:HiddenField ID="POINT" runat="server" Value='<%# Eval("pointname") %>' />  <asp:HiddenField ID="POINTID" runat="server" Value='<%# Eval("pointid") %>' />
        <asp:Label ID="lblPointName" runat="server" Text='<%# Bind("pointname") %>'></asp:Label></ItemTemplate>

        <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>        
       <%-- <asp:TemplateField HeaderText=" Quantity" HeaderStyle-HorizontalAlign="Center">
        <ItemTemplate><asp:TextBox ID="txtQuantity" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>--%>
       
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
        <ItemTemplate><asp:TextBox ID="txtQuantity" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("Quantity") %>' AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        <asp:TemplateField HeaderText="Active / Inactive Option">
        <EditItemTemplate><asp:checkbox ID="chkbx" class="day" Width="50px" runat="server"/></EditItemTemplate>
        <ItemTemplate><asp:checkbox ID="chkbx" class="day" runat="server"/><asp:HiddenField ID="hdnPointid" runat="server" Value='<%# Eval("pointid") %>'/>
        </ItemTemplate></asp:TemplateField>



          <%--<asp:TemplateField  HeaderText="Option" HeaderStyle-HorizontalAlign="Center">
            <EditItemTemplate><asp:CheckBox ID="chkbx" Width="50px"  runat="server"/></EditItemTemplate>
            <ItemTemplate><asp:CheckBox ID="chkbx" ClientIDMode="Static"  runat="server"/>
            <asp:HiddenField ID="hdnPointid" runat="server" Value='<%# Eval("pointid") %>'/>
            </ItemTemplate></asp:TemplateField>   --%>

                  
          

        </Columns>
         <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
        </asp:GridView>
                     
                     <asp:ObjectDataSource ID="odsAclPoint" runat="server" SelectMethod="GetAclDirectPointList"  TypeName="HR_BLL.TourPlan.TourPlanning" OldValuesParameterFormatString="original_{0}">
                         <SelectParameters>
                             <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                         </SelectParameters>
                     </asp:ObjectDataSource>
                     
    
    </td></tr>
    

            </table>
        </div>


<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>
