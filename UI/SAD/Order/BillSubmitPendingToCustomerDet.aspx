<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillSubmitPendingToCustomerDet.aspx.cs" Inherits="UI.SAD.Order.BillSubmitPendingToCustomerDet" %>

<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/Print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">        
 function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("btn");
            dv.style.display = "none";
        }   
    </script>
 
</head>




<body>
   
    <form id="form1" runat="server">
    
        <div>
            <table>
                <tr>
                    <td>
                           &nbsp;     <td align="center" style="width: 33%;">
                <a href="#" onclick="Print()"><b>Print</b></a>
            </td>
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    <td>
                           &nbsp; 
                    </td>

                </tr>
                <tr>
                    

                    <td>
                          <asp:Label ID="lbldt" runat="server" Text="DATE:         "></asp:Label>
                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblcustomername" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblcustmainadr" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblDrsir" runat="server" Text="Dear Sir,"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblpleased" runat="server" Text="We are pleased to issue a bill in favour of our supply as per purchase order"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <asp:Label ID="lblPo" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
       
   
       
       <div>
           <table  style="width:1024px; text-align:left;" align="left">
               <tr>
                  
                   <td>
                      <asp:GridView ID="dgbCustomerprintcopy" runat="server"  AllowPaging="true" PageSize="25" OnPageIndexChanging="dgbCustomerprintcopy_PageIndexChanging" OnRowDataBound="dgbCustomerprintcopy_RowDataBound" AutoGenerateColumns="false" CellPadding="5" ShowFooter="true">
                          
                    <Columns>
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %>
                      
                         </ItemTemplate></asp:TemplateField>
                   
                           
                        <asp:BoundField DataField="strcustname" HeaderText="CustName" SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strDONumber" HeaderText="D.O Number" SortExpression="strDONumber" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="challanadr" HeaderText="Destination Address" SortExpression="strDONumber" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="strchalallanumber" HeaderText="Challan Number" SortExpression="strchalallanumber" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="strItmname" HeaderText="Item Name" SortExpression="strItmname" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="challanqntprimary" HeaderText="PrimaryChallanQnt" SortExpression="challanqntprimary" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="challanamoutnprim" HeaderText="ChallanAmountPrimary" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                       
                        <asp:BoundField DataField="billqnt" HeaderText="BillqntNet" SortExpression="challanamoutnprim" ItemStyle-HorizontalAlign="Center" >
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                       

                         <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="right" SortExpression="Qty" >
                       <ItemTemplate><asp:Label ID="lblCrGrandTotal" runat="server"  DataFormatString="{0:n0}" Text='<%# (decimal.Parse(""+Eval("billamount","{0:n0}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="right"  Width="80px"/><FooterTemplate><asp:Label ID="lblfdm"   runat="server" DataFormatString="{0:n0}" Text ='<%# Crgrandtotal %>' /></FooterTemplate></asp:TemplateField>



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
            <table  style="width:1000px; text-align:left;">
                <tr>
                    <td>
                      <asp:Label ID="lblQuantity" runat="server" Text="Quantity in words : " ></asp:Label>
                         <asp:Label ID="lbldataQuantity" runat="server"></asp:Label>
                    </td>
                     <td>
                     
                    </td>
                     <td>

                     
                    </td>
                     <td>
                        
                          
                    </td>
                    <td>

                         &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbhalf" runat="server" Text="On behalf of Akij Cement Company Ltd."></asp:Label>
                    </td>
                </tr>
            </table>
        </div>



        <div>
            <table style="width:1000px;height:30px; text-align:left;">
            <tr><td>     &nbsp;    </td></tr>
                <tr>
                    <td >
                          <asp:Label ID="Label1" runat="server" Visible="true" Text=".............................."></asp:Label>
                          
                    </td>
                   
                    <td>
                          <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label3" runat="server" Visible="false" ></asp:Label>

                    </td>
                    <td>
                          <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>

                    </td>


                </tr>
                 <tr>
                    <td>
                          <asp:Label ID="lblSubmittedby" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label></br>
                           <asp:Label ID="lblsubmittedDesg" runat="server" ></asp:Label>
                    </td>
                     </tr>
                <tr>
                   <td>
                           &nbsp;
                    </td>


                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblEnclosed" runat="server" Text="Enclosed" Font-Bold="true" Font-Underline="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhotocopy" runat="server" Text="1. Photocopy of delivery Challan" Font-Bold="true" Font-Underline="false"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>


   
   <div>

      <table style="width:200px;height:10px; text-align:left;" align="center" >

      </table>


   </div>
    </form>
      
</body>
</html>
