<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TripCost.aspx.cs" Inherits="UI.Transport.TripvsCost.TripCost" %>

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

             $('#<%=grdvTripVsTADA.ClientID%>').gridviewScroll({
                 width: 600,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
         function Registration(url) {
             window.open('TripCostDetaills.aspx?ID=' + url, '', "height=600, width=800, scrollbars=yes, left=200, top=100, resizable=yes, title=Preview");
         }
    </script>
      <script type="text/javascript">
         $(document).ready(function () {
             GridviewScroll();
         });
         function GridviewScroll() {

             $('#<%=grdvTripvsChallanDet.ClientID%>').gridviewScroll({
                 width: 1024,
                 height: 340,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
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
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd">
                            <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                         <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true" OnSelectedIndexChanged="drdlUnitName_SelectedIndexChanged1"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>


              <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server">
                      <asp:ListItem Value="1">Driver</asp:ListItem>
                     <asp:ListItem Value="2">Helper</asp:ListItem> 
                  <asp:ListItem Value="3">Trip vs Challan Detaills</asp:ListItem> 
                 <asp:ListItem Value="4">Vheicle Vs Trip (Top sheet)</asp:ListItem> 
                  <asp:ListItem Value="5">Vheicle Vs Trip (Detaills)</asp:ListItem> 
                   <asp:ListItem Value="6">Ship Point vs Route Cost (Detaills)</asp:ListItem> 
                     </asp:DropDownList>
                                 
                                    
                </td>
              </tr>
           
         <tr class="tblrowOdd">
                            <td style="text-align:right"><asp:Label ID="lblShipPointName" CssClass="lbl" runat="server" Text="Shipping Point Name:  "></asp:Label></td>
                         
                         <td colspan="3"><asp:DropDownList ID="drdlShippingpoint"  runat="server"></asp:DropDownList>
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
            <asp:GridView ID="grdvTripVsTADA" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdvTripVsTADA_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strname" HeaderText="Employee Name" SortExpression="strname" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="totaltrip" HeaderText="Total trip" SortExpression="totaltrip" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="da" HeaderText="Total Daily Allowance" SortExpression="da" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="ta" HeaderText="Total Trip Allowance" SortExpression="ta" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="total" HeaderText="Total TA DA" SortExpression="total" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
             <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("strname") %>' /></ItemTemplate>
             </asp:TemplateField>  
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
        
             
          <tr class="tblroweven"><td>
            <asp:GridView ID="grdvTripvsChallanDet" runat="server" ShowFooter="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="grdvTripvsChallanDet_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <%--strtripcode ,strchallan ,dteintime ,dteouttime ,decqntcft ,strdriver,strcontact ,strhelper--%>
            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strtripcode" HeaderText="strtripcode" SortExpression="strtripcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strchallan" HeaderText="strchallan" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dteintime" HeaderText="dteintime" SortExpression="dteintime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="dteouttime" HeaderText="dteouttime" SortExpression="dteouttime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="decqntcft" HeaderText="decqntcft" SortExpression="decqntcft" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strdriver" HeaderText="strdriver" SortExpression="strdriver" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
           <asp:BoundField DataField="strhelper" HeaderText="strhelper" SortExpression="strhelper" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strcontact" HeaderText="strcontact" SortExpression="strcontact" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            </Columns>
                <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView> </td>
            </tr>  
            </table>

            </div>

         <div class="leaveApplication_container"> 
             <table>
        
             
          <tr class="tblroweven"><td>
            <asp:GridView ID="grdvShipPointvsRouteCost" runat="server" ShowFooter="True" AutoGenerateColumns="False" CellPadding="3" OnRowDataBound="grdvTripvsChallanDet_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <%--strtripcode ,strchallan ,dteintime ,dteouttime ,decqntcft ,strdriver,strcontact ,strhelper--%>
            <asp:TemplateField HeaderText="Sl"> <ItemTemplate> <%#Container.DataItemIndex+1 %> </ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="strtripcode" HeaderText="strtripcode" SortExpression="strtripcode" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strchallan" HeaderText="strchallan" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="dteintime" HeaderText="dteintime" SortExpression="dteintime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="dteouttime" HeaderText="dteouttime" SortExpression="dteouttime"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
            <asp:BoundField DataField="decqntcft" HeaderText="decqntcft" SortExpression="decqntcft" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strdriver" HeaderText="strdriver" SortExpression="strdriver" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
           <asp:BoundField DataField="strhelper" HeaderText="strhelper" SortExpression="strhelper" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            <asp:BoundField DataField="strcontact" HeaderText="strcontact" SortExpression="strcontact" ItemStyle-HorizontalAlign="Center" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
            </asp:GridView> </td>
            </tr>  
            </table>

            </div>

       



<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>