<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThanaRateChecking.aspx.cs" Inherits="UI.Transport.TripvsCost.ThanaRateChecking" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%:Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
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
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true" OnDataBound="drdlUnitName_DataBound"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>


              <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server">
                      <asp:ListItem Value="1">Detaills</asp:ListItem>
                     <asp:ListItem Value="2">Top Sheet</asp:ListItem> 
                 
                     </asp:DropDownList>
                                 
                                    
                </td>
              </tr>
           
         <tr class="tblrowOdd">
                              <td style="text-align:right;">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" DataSourceID="odsShippingpoint" DataTextField="strName" DataValueField="intShipPointId">
                                            </asp:DropDownList>
                                          
                                            <asp:ObjectDataSource ID="odsShippingpoint" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="drdlUnitName" Name="unitId" PropertyName="SelectedValue" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                          
                                        </td>


            
              </tr>
            
            
            
         
         
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click"/></td>
            </tr>
            </table>
            </div>
        
         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
            <asp:GridView ID="grdvThanratechecking" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <%--strThana ,moncompanyrate ,monthirdparty,intinsertby ,strinsertby ,strpoint ,intpointid ,dteinserttime ,dtefrom ,dteto ,strtype--%>


            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strThana" HeaderText="Thana" SortExpression="strThana" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="moncompanyrate" HeaderText="Companyrate" SortExpression="totaltrip" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="monthirdparty" HeaderText="thirdparty Rate" SortExpression="da" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="strinsertby" HeaderText="insertby" SortExpression="strinsertby" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strpoint" HeaderText="strpoint" SortExpression="strpoint" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            
            <asp:BoundField DataField="dteinserttime" HeaderText="dteinserttime" SortExpression="dteinserttime" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dtefrom" HeaderText="dtefrom" SortExpression="dtefrom" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="dteto" HeaderText="dteto" SortExpression="dteto" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strtype" HeaderText="Vehicle Type" SortExpression="strtype" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            





                 </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView> </td>
            </tr>  
            </table>

            </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          
            </table>

            </div>
       



<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>