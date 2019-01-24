<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DelivaryOrderDetPrint.aspx.cs" Inherits="UI.SAD.Order.DelivaryOrderDetPrint" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/Print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        
    function Print(){        
        Show();
        window.print();
        //div.Print();
        self.close();
    }
    function Show(){
        var dv = document.getElementById("print");
       
        dv.style.display = "block";
        
        dv = document.getElementById("btn");
        dv.style.display = "none"; 
    }     
    </script>
 
</head>




<body>
   
    <form id="form1" runat="server">
    
  <%--  <table id="btn" align="center" width="700px" style="background-color:#E0E0E0;">
        <tr>
            <td align="right" style="width:50%">
                <a href="#" onclick="printDiv()"><b>Print</b></a>
            </td>            
        </tr>
    </table>  --%>
       
    <div id="print">        
        <table style="width:700px; text-align:left; height:100px" align="center">
            <tr>
                <td rowspan="4" align="left">
                <%--<asp:Image ID="imgLogo" runat="server" ImageUrl="~/Content/images/img/533.png"/>--%>
                     <asp:Label ID="lblUnitName" runat="server" Visible="false" Font-Bold="true" ></asp:Label> <br/>
                    <asp:Label ID="lblag" runat="server" Visible="false" Text="(A Unit of Akij Group)" Font-Size="Small" ></asp:Label>
                </td>
                <td colspan="3"  style="text-align:center; font-size:17px; font-weight:bold;"></td>
                <td rowspan="2" align="right" style="  width:60px; "> <asp:PlaceHolder ID="Placeholder1"   runat="server"></asp:PlaceHolder> </td> 
               
            </tr>
            
            <tr>
                  <td colspan="3" style="text-align:left; font-size:11px;"> <asp:Label ID="lblHO" runat="server" Visible="false" Text="Head Office :" ></asp:Label> 
              
                      
                    <asp:Label ID="lblUnitAddr" runat="server" Visible="false" ></asp:Label>
                </td>

            </tr>
            <tr style="height:10px; align-content:center"  >
                <td colspan="3"> <asp:Label ID="lblMail" runat="server" Visible="false" Text="Email :" ></asp:Label> 
                      <asp:Label ID="lblEmail" runat="server" Visible="false" ></asp:Label>
                     
                    <asp:Label ID="lblwebsite" runat="server" Visible="false" Text="Website :" style="text-align:right; font-size:11px;" ></asp:Label>
                     <asp:Label ID="lblweb" runat="server" Visible="false" ></asp:Label>

                </td>
                <td colspan="2">
                    
                </td>
              

                </tr>
            <tr>
                   <td> </td>
                    <td colspan="2"> <asp:Label ID="lblFactoryAddress" runat="server" Visible="false" Text="Factory :" ></asp:Label>
                          <asp:Label ID="lblFactory" runat="server" Visible="false"></asp:Label>
                         <asp:Label ID="lblunitid" runat="server" Visible="false" ></asp:Label>
                    </td>
                <td colspan="2">
                  
                     <asp:Label ID="lblCustomerCopy" runat="server" Font-Bold="true" Visible="false" BorderColor="Black" Text=""></asp:Label>
               
                </td> 
                    <td></td>
                </tr>
           <%-- <tr>
                <td style="width:500px; font-size:17px;text-align:center; background-color:lightgrey; font-weight:bold;" colspan="7"> </td>
            </tr>--%>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td style="width:120px; font-size:12px; font-weight:bold;">
                                                                                Customer ID:</td>
                <td colspan="2" style="width:300px; font-size:12px; font-weight:bold;">
                    <asp:Label ID="lblCustid" runat="server" ></asp:Label>
                </td>               
                <td  style="text-align:center; font-size:11px;">
                   <asp:Label ID="lblFaxnAME" runat="server" Text="Office Fax:" Visible="false" ></asp:Label>
                </td>
                <td  style="text-align:center; font-size:11px;">
                   <asp:Label ID="lblFax" runat="server" Visible="false"  ></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                <td>
                                        Customer</td>
                <td colspan="2">
                    <asp:Label ID="lblCusName" runat="server" ></asp:Label>
                </td>
                
                <td>
                                       D.O Date</td>
                <td>
                    <asp:Label ID="lblDODate" runat="server" ></asp:Label></td>
            </tr>
            <tr style="font-size:10px; background-color:#F0F0FF;">
                <td>
                                       Customer Address</td>
                <td colspan="2">
                    <asp:Label ID="lblCusAddr" runat="server" ></asp:Label>
                </td>
                
                <td>
                                        D.O No.</td>
                <td>
                    <asp:Label ID="lblDONumber" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr style="font-size:10px; background-color:#E0E0E0;">
                      
                <td>
                                        Delivery Point</td>
                <td colspan="2">
                    <asp:Label ID="lblDelvpoint" runat="server" ></asp:Label></td>
                 <td>
                                        Customer Mobile</td>
                <td colspan="1">
                    <asp:Label ID="lblCustmobile" runat="server" ></asp:Label>
                </td>         
            </tr>
            <br />
          <%-- <tr>
               <td colspan="5">

               </td>
           </tr>--%>
            <tr>
               <td style="width:500px; font-size:15px;text-align:center; text font-weight:bold;" colspan="5">Product Detaills </td>      
            </tr>
        <%--    <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>--%>
             <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>
        </table>
       <div>
           <table  style="width:700px; text-align:left;" align="center">
               <tr>
                  
                   <td>
                      <asp:GridView ID="dgvdodtls" runat="server"  AllowPaging="true" PageSize="25" OnPageIndexChanging="dgvdodtls_PageIndexChanging" OnRowDataBound="dgvdodtls_RowDataBound" AutoGenerateColumns="false" CellPadding="5" ShowFooter="true">
                          
                    <Columns>
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                        <asp:HiddenField runat="server" ID="hdnhollogramnumber" Value='<%# Eval("strHallogramnumber") %>' />
                         </ItemTemplate></asp:TemplateField>
                       
                        <%--<asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intsl" ItemStyle-HorizontalAlign="Center" />--%>
                         <asp:BoundField DataField="intProductid" HeaderText="Product ID" HeaderStyle-HorizontalAlign="Center" SortExpression="intProductid" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="strProductName" HeaderStyle-HorizontalAlign="Center" HeaderText="Product Description" ItemStyle-Width="40%" ItemStyle-Wrap="false" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="strUOM" HeaderText="UOM" HeaderStyle-HorizontalAlign="Center" SortExpression="strUOM" ItemStyle-Width="20%" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="Quantity" HeaderText="Quantity (Bag)" HeaderStyle-HorizontalAlign="Center" SortExpression="Quantity" ItemStyle-Width="10%" ItemStyle-Wrap="false"  ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="decwgtton" HeaderText="Quantity (Ton)" HeaderStyle-HorizontalAlign="Center" SortExpression="decwgtton" ItemStyle-Width="10%" ItemStyle-Wrap="false"  ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="decwgtton" HeaderText="" Visible="false" HeaderStyle-HorizontalAlign="Center" SortExpression="decwgtton" ItemStyle-HorizontalAlign="Center" />
                        <%--<asp:TemplateField><ItemTemplate><asp:HiddenField runat="server" ID="hdnhollogramnumber" Value='<%# Eval("strHallogramnumber") %>' /></ItemTemplate></asp:TemplateField>--%>
                    
                    </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
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
        <div>
            <table style="width:700px; text-align:left;" align="center">
                <tr>
                    <td>

                         &nbsp;
                    </td>
                     <td>

                         &nbsp;
                    </td>
                     <td>

                         &nbsp;
                    </td>
                     <td>
                         <asp:Label ID="lblQuantity" runat="server" Text="Quantity in words : " ></asp:Label>
                          <asp:Label ID="lbldataQuantity" runat="server"></asp:Label>
                    </td>
                    <td>

                     
                    </td>
                </tr>
                <tr>
                    <td>

                         &nbsp;
                    </td>
                     <td>

                         &nbsp;
                    </td>
                     <td>

                         &nbsp;
                    </td>
                     <td>
                       <asp:Label ID="lblnb"  runat="server" Text="[N:B: Delivery should be taken within 15(Fifteen) days hereafter]"></asp:Label>   
                    </td>
                    <td>

                       
                    </td>
                </tr>

            </table>
        </div>
        <div id="divdistnace">
        <table style="width:700px;height:25px; text-align:left;" align="center">
            <tr>
                <td>
                    <asp:Label ID="lblcreatedistance" runat="server" Visible="false"></asp:Label>
                    
                </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Visible="false"></asp:Label>
                   
                </td>
            </tr>
        </table>
      
    </div>


        <div>
            <table style="width:700px;height:30px; text-align:left;" align="center">
            <tr><td>     &nbsp;    </td></tr>
                <tr>
                    <td >
                          <asp:Label ID="Label1" runat="server" Visible="false" Text="..................." ></asp:Label>
                          
                    </td>
                   
                    <td>
                          <asp:Label ID="Label2" runat="server" Visible="false" Text="...................." ></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label3" runat="server" Visible="false" Text="...................." ></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label4" runat="server" Visible="false" Text="....................." ></asp:Label>

                    </td>


                </tr>
                 <tr>
                    <td>
                          <asp:Label ID="Label5" runat="server" Visible="false" Text="Received By " ></asp:Label>
                          
                    </td>

                    <td>
                          <asp:Label ID="Label6" runat="server" Visible="false" Text="Prepared By" ></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label7" runat="server" Visible="false" Text="Checked By" ></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label8" runat="server" Visible="false" Text="Forward By" ></asp:Label>

                    </td>


                </tr>
            </table>

        </div>


    </div>    
   <div>

      <table style="width:200px;height:10px; text-align:left;" align="center" >

      </table>


   </div>
    </form>
      
</body>
</html>
