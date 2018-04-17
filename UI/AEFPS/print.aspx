<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="UI.AEFPS.print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head>
    <script>
        function printDiv(divName) {
            document.getElementById(divName).style.marginLeft = "0px";
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;
            document.body.innerHTML = printContents;

            window.print();
            window.self.closed();
            document.body.innerHTML = originalContents;
        }
    </script>
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=700,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }
    </script>
   
     <script> function CloseWindow() {
     window.close();
        }

    </script>
    <style type="text/css">
 
div#printhead {
 
display: block;
 
position: fixed; top: 0; left: 0; width: 100%; height: 2em;
 
padding-bottom: 1em;
 
margin-bottom: 10px;
margin-left: 0px;
}</style>

</head>
<body>
     <form id="frmprint" runat="server">

    <%--  <h1>Print me Akij Group</h1>--%>
    <table>
<tr><td>
 <div style="margin-left:-100px" id="printableArea">

    <table cellpadding="0" cellspacing="0" border="0"   width="98%" style="width:auto; float:left; "> 
        <tr><td colspan="3"  style="text-align:left;font-size:12px"><asp:Label ID="lblWHname" runat="server" Text="Wear House :"></asp:Label> <asp:Label ID="lblWH" runat="server"></asp:Label>
        </td></tr>  
         <tr><td  colspan="3" style="text-align:left;font-size:12px"><asp:Label ID="lblNames" runat="server" Text="Name :"></asp:Label> <asp:Label ID="lblName" runat="server"></asp:Label></td></tr> 
           <tr><td colspan="2" style="text-align:left;font-size:12px"><asp:Label ID="lblVoucherShow" runat="server" ></asp:Label></td>
                      
                <td   style="text-align:left;font-size:12px"><asp:Label ID="lbldate" runat="server" Text="Date :"></asp:Label> <asp:Label ID="lblGetDate" runat="server"></asp:Label> </td>
           </tr>    
          <tr><td colspan="3" style="text-align:justify;"><hr />
    <asp:GridView ID="dgvPrint"  runat="server" AutoGenerateColumns="False"  Font-Size="10px" BackColor="White" 
     Font-Names="Arial" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
    <Columns>
     
    <asp:TemplateField HeaderText="Item Description" SortExpression="ItemCode">
    <ItemTemplate><asp:Label ID="lblpnamn"  Width="154px" Font-Size="9px" runat="server" Text='<%# Bind("stritemname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>     
   
    <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
    <ItemTemplate><asp:Label ID="lblQuantity" Width="20px" Font-Size="9px" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>  
     
    <asp:TemplateField HeaderText="Price" SortExpression="Price">
    <ItemTemplate><asp:Label ID="lblPrice" Width="20px" Font-Size="9px" runat="server" Text='<%# Bind("monPrice") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>  
     
     <asp:TemplateField HeaderText="Total" SortExpression="Price">
    <ItemTemplate><asp:Label ID="lblTotal" Width="20px" Font-Size="9px" runat="server" Text='<%# Bind("monAmount") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"/></asp:TemplateField>  
                                 
    </Columns>
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle   CssClass="GridviewScrollHeader" BackColor="#333333" Font-Bold="True" ForeColor="White" /><PagerStyle CssClass="GridviewScrollPager" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333"  ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
    </td></tr>
    <tr><td style="text-align:left" colspan="3">------------------------------------------------</td></tr>
     <tr><td   style="text-align:left;font-size:12px" class="auto-style1"  ><asp:Label ID="Label11"  runat="server" Text="Sales Amount"></asp:Label>  </td>
         <td>:</td>
         <td style="font-size:12px">  <asp:Label ID="lblSalesAmounts" runat="server"></asp:Label> </td>
      </tr> 
          <tr><td   style="text-align:left;font-size:12px" class="auto-style1"  ><asp:Label ID="lblpay"  runat="server" Text="Pay Type"></asp:Label>  </td>
         <td >:</td>
         <td style="font-size:12px">  <asp:Label ID="lblPayType" runat="server"></asp:Label> </td>
      </tr> 
        <tr><td   style="text-align:left;font-size:12px" class="auto-style1"  ><asp:Label ID="Label14"  runat="server" Text="Total Credit"></asp:Label>  </td>
         <td>:</td>
         <td style="font-size:12px">  <asp:Label ID="lblTotalCredit" runat="server"></asp:Label> </td>
      </tr> 
          <tr><td   style="text-align:left;font-size:12px" class="auto-style1"  ><asp:Label ID="Label12"  runat="server" Text="Paid Amount"></asp:Label>  </td>
         <td>:</td>
         <td style="font-size:12px">  <asp:Label ID="lblPaidAmount" runat="server"></asp:Label> </td>
      </tr> 
         <tr><td   style="text-align:left;font-size:12px" class="auto-style1"  ><asp:Label ID="Label13"  runat="server" Text="Change Amount"></asp:Label>  </td>
         <td>:</td>
         <td style="font-size:12px">  <asp:Label ID="lblChangeAmount" runat="server"></asp:Label> </td>
      </tr> 
        <tr><td style="text-align:left" colspan="3" class="auto-style2">------------------------------------------------</td></tr>
       <tr><td style="text-align:left;font-size:14px" colspan="3">Thank you for shopping with us.-AEFPS.</td></tr>
     
    </table>
    
</div>
     
</td></tr>
        <tr><td>
       
     <table style="width:auto; float:left; "> 
        <tr><td style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a>
              <input type="button" onclick="printDiv('printableArea')" value="print a div!" />
        </td>  </tr>  
   </table>
   </td></tr>
 </table>


</form>
</body>

</html>

