<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VheicleMonitoring.aspx.cs" Inherits="UI.Transport.TripvsCost.VheicleMonitoring" %>

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
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd">
                            <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>


              <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server">
                      <asp:ListItem Value="1">Trip Status Detaills</asp:ListItem>
                     <asp:ListItem Value="2">Trip Status TopSheet</asp:ListItem> 
                  
                 
                     </asp:DropDownList>
                                 
                                    
                </td>
              </tr>
           
         <tr class="tblrowOdd">
                            <td style="text-align:right"><asp:Label ID="lblShipPointName" CssClass="lbl" runat="server" Text="Shipping Point Name:  "></asp:Label></td>
                         
                         <td colspan="3"><asp:DropDownList ID="drdlShippingpoint"  runat="server" DataSourceID="odsShippingp" DataTextField="strName" DataValueField="intShipPointId"></asp:DropDownList>
                            
                             <asp:ObjectDataSource ID="odsShippingp" runat="server" SelectMethod="GetShipPoint" TypeName="SAD_BLL.Global.ShipPoint">
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
            <asp:GridView ID="grdvVhclMonitoring" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvVhclMonitoring_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <%--strRegNo ,strcode ,strCustomerName ,strNarration , numQuantity  ,dteInTime ,dteEmptyWgtTime ,dteLoadedWgtTime ,dteOutTime , duration ,strEmployeeName--%>

            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strRegNo" HeaderText="Vheicle No." SortExpression="strname" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strcode" HeaderText="Trip No." SortExpression="totaltrip" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strCustomerName" HeaderText="Customer" SortExpression="strCustomerName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="strNarration" HeaderText="Narration" SortExpression="ta" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="numQuantity" HeaderText="Quantity" SortExpression="total" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            
              
            <asp:BoundField DataField="dteInTime" HeaderText="MainGate In   Time" ItemStyle-Width="80px" SortExpression="dteInTime" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd-MM-yyyy hh:mm:ss tt}" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dteEmptyWgtTime" HeaderText="EmptyWeight Time" ItemStyle-Width="80px" SortExpression="dteEmptyWgtTime" DataFormatString="{0:dd-MM-yyyy hh:mm:ss tt}" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dteLoadedWgtTime" HeaderText="LoadedWeight Time" ItemStyle-Width="80px" SortExpression="dteLoadedWgtTime" DataFormatString="{0:dd-MM-yyyy hh:mm:ss tt}" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="dteOutTime" HeaderText="MainGate Out Time" ItemStyle-Width="80px" SortExpression="dteOutTime" DataFormatString="{0:dd-MM-yyyy hh:mm:ss tt}" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="duration" HeaderText="Duration   (Hour)" SortExpression="duration" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strEmployeeName" HeaderText="EmployeeName" SortExpression="strEmployeeName" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
          







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

       

       



<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>
