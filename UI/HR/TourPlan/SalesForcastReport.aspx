<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesForcastReport.aspx.cs" Inherits="UI.HR.TourPlan.SalesForcastReport" %>

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

   <%--  <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=grdvBikeCarUserDetaills.ClientID%>').gridviewScroll({
                 width: 725,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>--%>
      
</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>
          <div class="leaveApplication_container"> 
                   <table>
    <div class="tabs_container"> 
        <caption>
          Sales Report :<asp:HiddenField ID="hdnenroll" runat="server" />
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
            <%-- <td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlUserType" runat="server" DataTextField="strUser Type" DataValueField="intID" DataSourceID="odsUser"></asp:DropDownList>
                                      <asp:ObjectDataSource ID="odsUser" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRmtUserCatg" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAUserTypeTableAdapter">
                                        <InsertParameters>  <asp:Parameter Name="strUser_Type" Type="String" /> </InsertParameters> </asp:ObjectDataSource>
                                  </td>--%>
             <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server" DataSourceID="odsRemoteSalesMktReportType" DataTextField="strName" DataValueField="intID"></asp:DropDownList>
                                    
                                    <asp:ObjectDataSource ID="odsRemoteSalesMktReportType" runat="server" SelectMethod="GetRemoteSalesMktReportType" TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                                    
                </td>
                            <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
              </tr>
           
            
            
            
          <%--  <tr class="tblroweven">
         </tr>--%>
            <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
                <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>
            </tr>
            </table>
                        </table>
            </div>
         <div class="leaveApplication_container"> 
             <table>
                 <tr class="tblroweven"><td>
              <asp:GridView ID="grdvSalesForCast" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvSalesForCast_PageIndexChanging" OnRowDataBound="grdvSalesForCast_RowDataBound">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                    <%--strName ,strTerritory ,strArea ,strRegion ,intTerritoryID ,decDeliverQnt ,decTargetQnt ,decTargetQnt100percent ,decTargetQnt110percent ,decTargetQnt125percent--%> 
                     
                      
                       <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
                      <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decDeliverQnt" HeaderText="DeliverQnt" SortExpression="decDeliverQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decTargetQnt" HeaderText="TargetQnt" SortExpression="decTargetQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decTargetQnt100percent" HeaderText="TQ100%" SortExpression="decTargetQnt100percent" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="decTargetQnt110percent" HeaderText="TQ110%" SortExpression="decTargetQnt110percent" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decTargetQnt125percent" HeaderText="TQ125%" SortExpression="decTargetQnt125percent" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strTerritory" HeaderText="Territory" SortExpression="strTerritory" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strArea" HeaderText="Area" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="strRegion" HeaderText="Region" SortExpression="strRegion" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:TemplateField HeaderText="Status" Visible="false" ControlStyle-Width="75px" >
                        <ItemTemplate><asp:Label ID="Labelterritoryid" runat="server" Text='<%# Eval("intTerritoryID") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                      <asp:BoundField DataField="intTerritoryID" HeaderText="TerritoryID" Visible="false" SortExpression="intTerritoryID" ItemStyle-HorizontalAlign="Center" >
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



<%--=========================================End My Code From Here=================================================--%>
       
    </form>
</body>
</html>