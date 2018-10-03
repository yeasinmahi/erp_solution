<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptSalesOrderSummery.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RptSalesOrderSummery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <%--<script src="../../../../Content/JS/datepickr.min.js"></script>--%>

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

             $('#<%=grdvDOSummeryReport.ClientID%>').gridviewScroll({
                 width: 725,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>

    <script type="text/javascript">
         function Search_dgvservice(strKey, strGV) {

             var strData = strKey.value.toLowerCase().split(" ");
             var tblData = document.getElementById(strGV);
             var rowData;
             for (var i = 1; i < tblData.rows.length; i++) {
                 rowData = tblData.rows[i].innerHTML;
                 var styleDisplay = 'none';
                 for (var j = 0; j < strData.length; j++) {
                     if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                         styleDisplay = '';
                     else {
                         styleDisplay = 'none';
                         break;
                     }
                 }
                 tblData.rows[i].style.display = styleDisplay;
             }

         }
        </script>
      
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>

          <div class="leaveApplication_container"> 
                   <table>
    <div class="tabs_container"> 
        <caption>
           Report Cheking :<asp:HiddenField ID="hdnenroll" runat="server" />
            <asp:HiddenField ID="hdnstation" runat="server" />
            <asp:HiddenField ID="hdnsearch" runat="server" />
            
            <asp:HiddenField ID="hdnDepartment" runat="server" />
            <hr />
        </caption>
                       </div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd">
                            <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" AutoPostBack="true" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>


              <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                                    <asp:ListItem Text="D.O Detaills" Value="1" Enabled="true"></asp:ListItem>
                                     <asp:ListItem Text="Challan Top Sheet" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Item vs Specific ship point" Value="5" Enabled="true"></asp:ListItem>
                                     <asp:ListItem Text="Item vs All ship point" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Item vs Specific sales office" Value="7" Enabled="true"></asp:ListItem>
                                     <asp:ListItem Text="Item vs All sales office" Value="8"></asp:ListItem>
                                    
                                  <asp:ListItem  Text="D.O Summery(Specific Point)" Value="20"></asp:ListItem>
                                 <asp:ListItem  Text="D.O Summery(Specific Sales Office)" Value="21"></asp:ListItem>
                                  <asp:ListItem  Text="D.O Summery (All)" Value="22"></asp:ListItem>
                                     <asp:ListItem  Text="Only D.O Qnt(Specific Point)" Value="23"></asp:ListItem>
                                 <asp:ListItem  Text="Only D.O Qnt(Specific Sales Office)" Value="24"></asp:ListItem>
                                  <asp:ListItem  Text="Only D.O Qnt(All)" Value="25"></asp:ListItem>
                                     <asp:ListItem Text="Item vs Pending(Specific Point)" Value="26"></asp:ListItem>
                                      <asp:ListItem Text="Item vs Pending(Specific SalesOffice)" Value="27"></asp:ListItem>
                                     <asp:ListItem Text="Item vs Pending(ALL)" Value="28"></asp:ListItem>
                                     <asp:ListItem Text="Sales office Base (Topsheet)" Value="29"></asp:ListItem>
                                     <asp:ListItem Text="Missing Challan" Value="30"></asp:ListItem>

                                    <asp:ListItem Text="All Point vs All Sales office" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="Point vs Party Total" Value="32"></asp:ListItem>
                                     <asp:ListItem Text="Point vs Vheicle" Value="33"></asp:ListItem>
                                     <asp:ListItem Text="All Point Summery" Value="34"></asp:ListItem>





                                    </asp:DropDownList>
                                    
                                   
                                    
                </td>
              </tr>
              <tr class="tblrowodd">
                 <td><asp:Label ID="lblShipPoint" runat="server" Text="Shipping Point"></asp:Label></td> 
                <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" onselectedindexchanged="ddlShip_SelectedIndexChanged" DataSourceID="odshippingpoint" DataTextField="strName" DataValueField="intShipPointId">
                                            </asp:DropDownList>
                                           
                                            <asp:ObjectDataSource ID="odshippingpoint" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                           
                                        </td>

                  <td>
                      <asp:Label ID="lblSalesoffice" runat="server" Text="SalesOffice"></asp:Label>
                      <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intSalesOfficeId">
                                </asp:DropDownList>
                                
                                <asp:ObjectDataSource ID="odsSalesOffice" runat="server" SelectMethod="GetSalesOfficeByShipPoint" TypeName="SAD_BLL.Global.SalesOffice">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlShip" Name="shipPoint" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                
                            </td>
                  </td>
              </tr>
           
            
            
            
         
         
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>
            </tr>
            </table>
            </div>
        
         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvDOSummeryReport" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvDOSummeryReport_RowDataBound">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                    
                      <asp:BoundField DataField="insl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="dteDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="dteInsertionTime" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                      <asp:BoundField DataField="strCode" HeaderText="D.O" SortExpression="strCode" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strCustName" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       
                       <asp:BoundField DataField="intCustomerId" HeaderText="CustId" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strContactAt" HeaderText="Propitor" SortExpression="strContactAt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strPhone" HeaderText="Phone" SortExpression="strPhone" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="strName" HeaderText="Sales office" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="strNarration" HeaderText="Narration" SortExpression="strNarration" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                       <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="remainingqnt" HeaderText="Remaing Qnt." SortExpression="numRestPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="monTotalAmount" HeaderText="TotalAmount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="ysnLogistic" HeaderText="Logistic" SortExpression="ysnLogistic" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    

                      <asp:BoundField DataField="ysnChallanCompleted" HeaderText="Challan status" SortExpression="ysnChallanCompleted" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    

                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvpriceCompare" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvpriceCompare_RowDataBound">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                      <%--insl,strCustName,dteDate,strCode,strchallan,numPieces,rate,monTotalAmount,challanqnt,strProductName,strName--%>
                <asp:BoundField DataField="insl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="dteDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
              
                <asp:BoundField DataField="strCode" HeaderText="D.O Number" SortExpression="strCode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                 
                      <asp:BoundField DataField="strchallan" HeaderText="Challan Number" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                  <asp:BoundField DataField="strCustName" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="strProductName" HeaderText="ProductName" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt" SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="rate" HeaderText="Rate" SortExpression="rate" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                <asp:BoundField DataField="monTotalAmount" HeaderText="TotalAmount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                 <asp:BoundField DataField="strvheicle" HeaderText="Vheicle Name" SortExpression="strvheicle" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
               
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvitemvsSalesOfficeandShipp" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvitemvsSalesOfficeandShipp_RowDataBound" ForeColor="Black" GridLines="Vertical">
                  <AlternatingRowStyle BackColor="White" />
                  <Columns>
                    
                      <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>
                       
                      
                       <asp:BoundField DataField="intproductid" HeaderText="Item ID" SortExpression="intproductid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="detectionofcode" HeaderText="Item Code" SortExpression="detectionofcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                       <asp:BoundField DataField="strProductName" HeaderText="Item Name" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      
                    

                  </Columns>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
                  <RowStyle BackColor="#F7F7DE" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>
      
         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvDOSummeryall" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"  ForeColor="Black" GridLines="Vertical">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                     <asp:BoundField DataField="insl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <%-- <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'grdvDOSummeryall')"></asp:TextBox></HeaderTemplate>
                                
                         
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate> <ItemStyle HorizontalAlign="Left" Width="10px"/></asp:TemplateField>    --%>        
      
 
                      
                       <asp:BoundField DataField="dteDate" HeaderText="Date" ItemStyle-Width="50px" SortExpression="dteDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strCode" HeaderText="D.O Number" SortExpression="strCode"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="intCustomerId" HeaderText="Customer ID" SortExpression="intCustomerId"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strCustName" HeaderText="Customer Name" SortExpression="strCustName"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strAddress" HeaderText="Customer Adress" SortExpression="strCustName"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                       <asp:BoundField DataField="intproductid" HeaderText="Item ID" SortExpression="intproductid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="detectionofcode" HeaderText="Item Code" SortExpression="detectionofcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                       <asp:BoundField DataField="strProductName" HeaderText="Item Name" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="challanamount" HeaderText="Challan Amount" SortExpression="challanamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="numRestPieces" HeaderText="Pending Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pending Amount" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                       <asp:BoundField DataField="strshippingpointname" HeaderText="Shipping point" SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="strName" HeaderText="Sales Office" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvCustomerVsDOQnt" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" OnRowDataBound="grdvCustomerVsDOQnt_RowDataBound" ForeColor="Black" CellSpacing="2">
                  <Columns>
                    
                     <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'grdvCustomerVsDOQnt')"></asp:TextBox></HeaderTemplate>
                                
                         
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate> <ItemStyle HorizontalAlign="Left" Width="10px"/></asp:TemplateField>            
      
 
                      
                       
                       <asp:BoundField DataField="intCustomerId" HeaderText="Customer ID" SortExpression="intCustomerId"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strCustName" HeaderText="Customer Name" SortExpression="strCustName"  ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                 
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
                  <RowStyle BackColor="White" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvItemvsPendingqntspecific" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="grdvItemvsPendingqntspecific_RowDataBound">
                  <AlternatingRowStyle BackColor="#DCDCDC" />
                  <Columns>
                     <asp:BoundField DataField="insl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strProductName" HeaderText="Item Name" SortExpression="strProductName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                       <asp:BoundField DataField="intproductid" HeaderText="Item ID" SortExpression="intproductid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="detectionofcode" HeaderText="Item Code" SortExpression="detectionofcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                       



                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="challanamount" HeaderText="Challan Amount" SortExpression="challanamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="numRestPieces" HeaderText="Pending Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pending Amount" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                       <asp:BoundField DataField="strshippingpointname" HeaderText="Shipping point" SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="strName" HeaderText="Sales Office" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                  <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                  <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                  <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#0000A9" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#000065" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>


         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvSalesOfficeBaseTopsheet" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvSalesOfficeBaseTopsheet_RowDataBound">
                  <Columns>
                     <asp:BoundField DataField="insl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strName" HeaderText="Sales Office" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                      <asp:BoundField DataField="numPieces" HeaderText="D.O Qnt." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="monTotalAmount" HeaderText="D.O Amount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="challanqnt" HeaderText="Challan Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="challanamount" HeaderText="Challan Amount" SortExpression="challanamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="numRestPieces" HeaderText="Pending Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="pendingqntpricevalue" HeaderText="Pending Amount" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                       <asp:BoundField DataField="grandtotalpendingqnt" HeaderText=" Grand Pending Qnt." SortExpression="challanqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="grandtotalpendingvalue" HeaderText="Grand Pending Amount" SortExpression="pendingqntpricevalue" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      
                     
                  </Columns>
                  <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                  <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                  <PagerStyle ForeColor="#330099" HorizontalAlign="Center" BackColor="#FFFFCC" />
                  <RowStyle BackColor="White" ForeColor="#330099" />
                  <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                  <SortedAscendingCellStyle BackColor="#FEFCEB" />
                  <SortedAscendingHeaderStyle BackColor="#AF0101" />
                  <SortedDescendingCellStyle BackColor="#F6F0C0" />
                  <SortedDescendingHeaderStyle BackColor="#7E0000" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
        <%--intsl,strcustname ,strdonumber,strchallannumber ,strnarration ,dteinserttime,shippingpoint--%>
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvMissingChallan" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" OnRowDataBound="grdvSalesOfficeBaseTopsheet_RowDataBound" CellSpacing="2" ForeColor="Black">
                  <Columns>
                     <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="strcustname" HeaderText="Customer Name" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                      <asp:BoundField DataField="strdonumber" HeaderText="D.O Number." SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="strchallannumber" HeaderText="Challan Number" SortExpression="strchallannumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strnarration" HeaderText="Narration" SortExpression="strnarration" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                      <asp:BoundField DataField="dteinserttime" HeaderText="Insert Date" SortExpression="dteinserttime" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="shippingpoint" HeaderText="Shipping Point" SortExpression="shippingpoint" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                      
                    
                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
                  <RowStyle BackColor="White" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>

         <div class="leaveApplication_container"> 
             <table>
     <%-- strName,strCode,dteDate,strsalesoffice, numPieces, monTotalAmount

strVehicleRegNo,strpointname,
sisterconcerqnt ,isterconcernamount,corporateqnt ,corporateamount ,mktsalesqnt ,mktamount --%>


             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvPointtopsheet" runat="server" ShowFooter="True" AutoGenerateColumns="False"  BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" OnRowDataBound="grdvSalesOfficeBaseTopsheet_RowDataBound" CellSpacing="2" ForeColor="Black">
                  <Columns>
               <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strName" HeaderText="Customer Name" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strCode" HeaderText="Challan Number" SortExpression="strchallannumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        <asp:BoundField DataField="dteDate" HeaderText="Date" SortExpression="dteDate" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strsalesoffice" HeaderText="strsalesoffice" SortExpression="strsalesoffice" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strpointname" HeaderText="Point" SortExpression="strpointname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        <asp:BoundField DataField="strVehicleRegNo" HeaderText="Vheicle" SortExpression="strVehicleRegNo" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                      <asp:BoundField DataField="numPieces" HeaderText="numPieces" SortExpression="numPieces" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="monTotalAmount" HeaderText="monTotalAmount" SortExpression="monTotalAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="sisterconcerqnt" HeaderText="sisterconcerqnt" SortExpression="sisterconcerqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="sisterconcernamount" HeaderText="sisterconcernamount" SortExpression="sterconcernamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                       <asp:BoundField DataField="corporateqnt" HeaderText="corporateqnt" SortExpression="corporateqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="corporateamount" HeaderText="corporateamount" SortExpression="corporateamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                      <asp:BoundField DataField="mktsalesqnt" HeaderText="mktsalesqnt" SortExpression="mktsalesqnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="mktamount" HeaderText="mktamount" SortExpression="mktamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                     



                  </Columns>
                  <FooterStyle BackColor="#CCCCCC" />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle ForeColor="Black" HorizontalAlign="Left" BackColor="#CCCCCC" />
                  <RowStyle BackColor="White" />
                  <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#808080" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#383838" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>



<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>