<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProductView.aspx.cs" Inherits="UI.SAD.ExcelChallan.frmProductView" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  <title></title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <script>
        function printDiv(divName) {
            document.getElementById(divName).style.marginLeft = "0px";
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;
            window.print();
          //  window.self.closed();
            document.body.innerHTML = originalContents;
        }
    </script>
    <script type="text/javascript">
        $("[id*=lblQuantity]").live("keyup", function () {
          if (!jQuery.trim($(this).val()) == '') {
              var sum = 0;
              if (!isNaN(parseFloat($(this).val()))) {
                  var row = $(this).closest("tr");
                  var free = parseFloat($("[id*=lblFQty]", row).html());
                  var UOM = parseFloat($("[id*=hdnUOMQty]", row).val());
                  var RQty = parseFloat($("[id*=lblQuantity]", row).val());
                  var qty = parseFloat($(this).val());
                  $("[id*=lblFreeQty]", row).html((free / UOM) * RQty);
                  $("[id*=lblTotalqty]", row).html(((free / UOM) * RQty) + RQty);
              }
          } else {
              $(this).val('');
          }
  
          var grandTotalqty = 0;
        

          $("[id*=lblTotalqty]").each(function () {
              grandTotalqty = grandTotalqty + parseFloat($(this).html());
          });
          $("[id*=lblPending]").html(parseFloat(grandTotalqty.toString()).toFixed(2));

      } ) ;
   </script>   
</head>
<body> 
    <form id="frmProductView" runat="server">
      <asp:HiddenField ID="hdnEnroll"  runat="server"/><asp:HiddenField ID="hdnVid"  runat="server"/>
      <input type="button" value="Print"  onclick="javascript: printDiv('printablediv'), Print()" />
      <div id="print"><div id="printablediv" style="width: 100%; height: 582px">
      <table  class="tbldecoration">
        <tr class="tblrowodd"><td>Distributor Name :</td> <td colspan="3"> <asp:Label ID="lblDist" runat="server"></asp:Label></td></tr>                       
        <tr class="tblrowodd"><td>Vehcile No :</td>
        <td><asp:TextBox ID="txtVehicleno" runat="server"></asp:TextBox></td>
        <td>Driver Name :</td>
        <td><asp:TextBox ID="txtDriverName" runat="server"></asp:TextBox></td>
        </tr>
        <tr class="tblrowodd">
        <td>Mobile No:</td><td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
        <td>Slip No:</td><td><asp:TextBox ID="txtSlipno" runat="server"></asp:TextBox>
        <asp:Button ID="btnSave" runat="server" Text="Save" Font-Bold="true" CssClass="btnbutton" OnClick="btnSave_Click" />   </td>                
        </tr>
        <tr class="tblrowodd"><td colspan="4">        
        <asp:GridView ID="dgvPending"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>

        <asp:TemplateField HeaderText="Productid" SortExpression="Productid"><ItemTemplate>
        <asp:Label ID="lblProductid" runat="server" Text='<%# Bind("pId") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
        </FooterTemplate></asp:TemplateField>
                        
        <asp:TemplateField HeaderText="strProductName" SortExpression="itemid"><ItemTemplate>
        <asp:HiddenField ID="hdnPid" runat="server" Value='<%# Eval("pId") %>' />
         <asp:HiddenField ID="hdnprice" runat="server" Value='<%# Eval("price") %>' />
        <asp:Label ID="lblstrProductName" runat="server" Text='<%# Bind("strProductName","{0:n0}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity"><ItemTemplate>
        <asp:HiddenField  ID="hdnFreeQty" runat="server" Value='<%# Bind("Free","{0:n2}") %>'></asp:HiddenField>
         <asp:HiddenField  ID="hdnUOMQty" runat="server" Value='<%# Bind("UOMqty","{0:n2}") %>'></asp:HiddenField>
        <asp:TextBox ID="lblQuantity" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("qty","{0:n0}") %>'   ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Total Free Qty" SortExpression="itemid"><ItemTemplate>
        <asp:Label ID="lblFQty" runat="server" Text='<%# Bind("Free","{0:n2}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

        <asp:TemplateField HeaderText="Free Qty" SortExpression="itemid"><ItemTemplate>
        <asp:Label ID="lblFreeQty" runat="server" Text='<%# Bind("TotalFree","{0:n2}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

        <asp:TemplateField HeaderText="Total Qty" SortExpression="Pending">
        <ItemTemplate><asp:Label ID="lblTotalqty" runat="server" Text='<%# (""+Eval("TotalQty","{0:n0}")) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# TotalQty %>' /></FooterTemplate>
        </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td>
       </tr>
     </table>
     </div>
     </div>
    </form>
</body>
</html>
