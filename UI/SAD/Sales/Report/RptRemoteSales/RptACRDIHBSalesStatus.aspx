<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptACRDIHBSalesStatus.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RptACRDIHBSalesStatus" %>

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
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
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
                                    <asp:ListItem Text="ACRD credit" Value="1" Enabled="true"></asp:ListItem>
                                     <asp:ListItem Text="ACRD CASH" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Prime seller CASH" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="Prime seller credit" Value="4"></asp:ListItem>
                                     <asp:ListItem Text="Shop List" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Retailler Commission" Value="6"></asp:ListItem>
                                     <asp:ListItem Text="Manpower Achievement" Value="7"></asp:ListItem>
                                     <asp:ListItem Text="Manpower Achievement Topsheet" Value="8"></asp:ListItem>
                                    </asp:DropDownList>
                                    
                                   
                                    
                </td>
              </tr>
              <tr class="tblrowodd">
                 <td><asp:Label ID="lblShipPoint" runat="server"  Text="Shipping Point"></asp:Label></td> 
                <td>
                                            <asp:DropDownList ID="ddlShip" runat="server"  AutoPostBack="True" onselectedindexchanged="ddlShip_SelectedIndexChanged" DataSourceID="odshippingpoint" DataTextField="strName" DataValueField="intShipPointId">
                                            </asp:DropDownList>
                                           
                                            <asp:ObjectDataSource ID="odshippingpoint" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                           
                                        </td>

                  <td><asp:Label ID="lblSalesoffice" runat="server" Text="SalesOffice"></asp:Label> </td>
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
                 
              </tr>
           
            
            
            
         
         
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>
            </tr>
            </table>
            </div>
        
         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvACRDSales" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"   BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvACRDSales_RowDataBound">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                 <%--   strcustname ,strterriatroy ,decdelvqnt,
				cashsalescomrate ,cashsalestotal ,salescomrate ,salescomtotal ,flatcomrate ,flattotal ,boostuprate ,boostuptotal ,grandtotalcomm
                   --%>
                      <asp:TemplateField HeaderText="Sl">
                          <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                      </asp:TemplateField>

                       <asp:BoundField DataField="strcustname"  HeaderText="Customer" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                   
                       
                      <asp:BoundField DataField="strterriatroy" HeaderText="Terriatroy" SortExpression="strCode" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decdelvqnt" HeaderText="Delv. Qnt" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       
                       <asp:BoundField DataField="cashsalescomrate" HeaderText="cashsalescomrate" SortExpression="intCustomerId" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="cashsalestotal" HeaderText="cashsalestotal" SortExpression="cashsalestotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="salescomrate" HeaderText="salescomrate" SortExpression="salescomrate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="salescomtotal" HeaderText="salescomtotal" SortExpression="salescomtotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="flatcomrate" HeaderText="flatcomrate" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="flattotal" HeaderText="flattotal" SortExpression="flattotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="boostuprate" HeaderText="boostuprate" SortExpression="boostuprate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="boostuptotal" HeaderText="boostuptotal" SortExpression="boostuptotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                       <asp:BoundField DataField="grandtotalcomm" HeaderText="grandtotalcomm" SortExpression="grandtotalcomm" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                   </Columns>
                  <FooterStyle BackColor="#CCCCCC"  />
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
              <asp:GridView ID="grdvShopList" runat="server" ShowFooter="True" AutoGenerateColumns="False"   BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowDataBound="grdvACRDSales_RowDataBound">
                  <AlternatingRowStyle BackColor="#DCDCDC" />
                  <Columns>
                <%--shopid , shopname ,shopadr,custid  ,strcustname ,strterriatroy ,area , region ,salesoffice ,shopphone ,thananame ,propitor--%>
                      <asp:TemplateField HeaderText="Sl">
                          <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                      </asp:TemplateField>

                       <asp:BoundField DataField="shopid"  HeaderText="Shopid" SortExpression="shopid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="shopname"  HeaderText="shopname" SortExpression="shopname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                      <asp:BoundField DataField="shopadr" HeaderText="Shop Addr." SortExpression="shopadr" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strcustname" HeaderText="Distributor" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       
                       <asp:BoundField DataField="strterriatroy" HeaderText="strterriatroy" SortExpression="strterriatroy" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="area" HeaderText="area" SortExpression="area" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="region" HeaderText="region" SortExpression="region" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="salesoffice" HeaderText="Salesoffice" SortExpression="salesoffice" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="shopphone" HeaderText="Shop Phone" SortExpression="shopphone" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="thananame" HeaderText="Thananame" SortExpression="thananame" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="propitor" HeaderText="Propitor" SortExpression="propitor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                     
                   </Columns>
                  <FooterStyle BackColor="#CCCCCC" ForeColor="Black"  />
                  <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
              <asp:GridView ID="grdvRetaillerCommission" runat="server" ShowFooter="True" AutoGenerateColumns="False"   BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" OnRowDataBound="grdvACRDSales_RowDataBound" BorderStyle="None">
                  <Columns>
                      <asp:TemplateField HeaderText="Sl">
                          <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                      </asp:TemplateField>

                       <asp:BoundField DataField="shopid"  HeaderText="Shopid" SortExpression="shopid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="shopname"  HeaderText="shopname" SortExpression="shopname" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                      <asp:BoundField DataField="strcustname" HeaderText="Distributor" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="shopsales" HeaderText="shopsales" SortExpression="shopsales" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="shopcommission" HeaderText="shopcommission" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       
                       <asp:BoundField DataField="strterriatroy" HeaderText="strterriatroy" SortExpression="strterriatroy" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="area" HeaderText="area" SortExpression="area" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="region" HeaderText="region" SortExpression="region" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                        
                       
                   </Columns>
                  <FooterStyle BackColor="White" ForeColor="#000066"  />
                  <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                  <RowStyle ForeColor="#000066" />
                  <SelectedRowStyle BackColor="#669999" ForeColor="White" Font-Bold="True" />
                  <SortedAscendingCellStyle BackColor="#F1F1F1" />
                  <SortedAscendingHeaderStyle BackColor="#007DBB" />
                  <SortedDescendingCellStyle BackColor="#CAC9C9" />
                  <SortedDescendingHeaderStyle BackColor="#00547E" />
              </asp:GridView> </td>
         </tr>  
        </table>

         </div>
         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
              <asp:GridView ID="grdvManpowerAchv" runat="server" ShowFooter="True" AutoGenerateColumns="False"   BackColor="#CCCCCC" BorderColor="#999999" BorderWidth="3px" CellPadding="4" OnRowDataBound="grdvACRDSales_RowDataBound" BorderStyle="Solid" CellSpacing="2" ForeColor="Black">
                  <Columns>
                      <asp:TemplateField HeaderText="Sl">
                          <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                      </asp:TemplateField>
                      <%--strterritory,terEntpsales ,terAcrdsales ,terIhbsales ,strmail ,strarea,strregion ,decdelv ,ttarget,achvment,areamanagmail,regionemail--%>
                       <asp:BoundField DataField="strterritory"  HeaderText="Territory" SortExpression="strterritory" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strmail"  HeaderText="TSO Mail" SortExpression="strmail" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                     <asp:BoundField DataField="terEntpsales"  HeaderText="Entpsales" SortExpression="terEntpsales" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                      <asp:BoundField DataField="terAcrdsales" HeaderText="Acrdsales" SortExpression="terAcrdsales" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="terIhbsales" HeaderText="Ihbsales" SortExpression="terIhbsales" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                   
                       
                       
                       <asp:BoundField DataField="decdelv" HeaderText="TotalDelv" SortExpression="decdelv" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="ttarget" HeaderText="TotalTarget" SortExpression="ttarget" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="achvment" HeaderText="Achvment" SortExpression="achvment" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                             <asp:BoundField DataField="strarea"  HeaderText="Area" SortExpression="strarea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                              <asp:BoundField DataField="strregion"  HeaderText="Region" SortExpression="strregion" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                   </Columns>
                  <FooterStyle BackColor="#CCCCCC"  />
                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                  <RowStyle BackColor="White" />
                  <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
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