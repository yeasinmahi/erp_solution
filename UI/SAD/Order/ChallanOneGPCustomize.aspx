<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChallanOneGPCustomize.aspx.cs" Inherits="UI.SAD.Order.ChallanOneGPCustomize" %>

<!DOCTYPE html >
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
        function IsLoadSlip() {
            var dv = document.getElementById("loadslip").style.display;
            if (dv == "block" || dv == "") document.getElementById("loadslip").style.display = "none";
            else document.getElementById("loadslip").style.display = "block";
        }
        function IsChallan() {
            var dv = document.getElementById("challan").style.display;
            if (dv == "block" || dv == "") document.getElementById("challan").style.display = "none";
            else document.getElementById("challan").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table id="btn" align="center" width="700px" style="background-color: #E0E0E0;">
        <tr>
            <td align="center" style="width: 33%;">
                <a href="#" onclick="Print()"><b>Print</b></a>
            </td>
            <td align="center" style="color: Blue; font-weight: bold; width: 33%;">
                <input id="Checkbox2" type="checkbox" onclick="IsLoadSlip()" checked="checked" />
                Loading Slip
            </td>
             <td align="center" style="color: Blue; font-weight: bold; width: 33%;">
                <input id="Checkbox1" type="checkbox" onclick="IsChallan()" checked="checked" />
                Challan
            </td>
            <%--<td>
                 <td align="center" style="color: Blue; font-weight: bold; width: 33%;">
                <input id="chkbPendingqnt" type="checkbox" onclick="IsP()" checked="checked" />
                Loading Slip
            </td>
            </td>--%>

        </tr>
    </table>
    <div id="challan">
        <asp:Panel ID="pnlChallan" runat="server">
            <%# mainD.ToString() %>
        </asp:Panel>
    </div>
    <div id="loadslip" style="page-break-before: always;">
        <asp:Panel ID="pnlGate" runat="server">
            <%# mainG.ToString() %>
        </asp:Panel>
    </div>

 <div id="print">        
        <table style="width:700px; text-align:left; height:100px" align="center">

           
            <tr>
               <td style="width:500px; font-size:15px;text-align:center; text font-weight:bold;" colspan="5"> </td>      
            </tr>
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
                   
            </tr>
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
                      <asp:GridView ID="dgvCustomerVSPendingQnt" runat="server"  AllowPaging="false" PageSize="1111" AutoGenerateColumns="false" CellPadding="5" ShowFooter="true">
                          
                    <Columns>
                       <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                         <asp:BoundField DataField="strCustName" HeaderText="Customer Name" ItemStyle-Width="30%"  SortExpression="strCustName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="strCode" HeaderText="D.O Number" ItemStyle-Width="30%" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="dteDate" HeaderText="CreationDate" ItemStyle-Width="60%" SortExpression="dteDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                         <asp:BoundField DataField="strProductName" HeaderText="Product Name" ItemStyle-Width="30%" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="rate" HeaderText="Rate" ItemStyle-Width="30%" SortExpression="rate" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="numRestPieces" HeaderText="Quantity (Piece)" ItemStyle-Width="30%" SortExpression="numRestPieces" ItemStyle-HorizontalAlign="Center" />
                       
                        <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Amount (Taka)" ItemStyle-Width="30%" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" />
                       
                    
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

                         &nbsp;
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