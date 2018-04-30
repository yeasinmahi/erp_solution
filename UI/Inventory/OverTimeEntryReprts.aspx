<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OverTimeEntryReprts.aspx.cs" Inherits="UI.Inventory.OverTimeEntryReprts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
       <script type="text/javascript" src="../../Content/JS/scriptEmployeeUpdate.js"></script>
  

     <script type="text/javascript">
         function pageLoad(sender, args) {
            $(document).ready(function () {
                SearchText();
                $('#txtstrt').timepicker();
                $('#txtend').timepicker();
            });
        }
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "OverTimeEntryReprts.aspx/GetAutoCompleteDataForTADA",
                         data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                     });
                 }
             });
         }


    </script>



    </head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>

<%--=========================================Start My Code From Here===============================================--%>
         <div class="leaveApplication_container"> 
         <div class="tabs_container"> Over Time Report Checking  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
       <asp:HiddenField ID="hdfEmpCode" runat="server"/>
              <hr /></div>
        <table border="0"; style="width:Auto"; >    
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" placeholder="Click  for date"  Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script><span style="color:red">*</span></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" placeholder="Click  for date" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>   
         
       </tr>
         <tr>
             <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Employee Name: "></asp:Label></td>
         <td><asp:TextBox ID="txtFullName" runat="server" Wrap="true" placeholder="Type  Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="false"></asp:TextBox><span style="color:red">*</span></td>
             <td style="text-align:right;"><asp:Label ID="lblDrdlReportType" CssClass="lbl" runat="server" Text="Report TYpe: "></asp:Label></td>
             <td><asp:DropDownList ID="drdlReportType" CssClass="drdl" runat="server" DataSourceID="odsreportty" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                 <asp:ObjectDataSource ID="odsreportty" runat="server" SelectMethod="getReportType" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource> </td>
             
         </tr>
            <tr> <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
             <td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
                 <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
            </td>
            <td style="text-align:right;"><asp:Label ID="lblArea" CssClass="lbl" runat="server" Text="Jobstation Name: "></asp:Label></td>
             <td><asp:DropDownList ID="drdlArea" CssClass="drdl" runat="server" DataSourceID="odsJobstationName" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
             

                 <asp:ObjectDataSource ID="odsJobstationName" runat="server" SelectMethod="getJobstationbyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
                     <SelectParameters>
                         <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
             

            </tr>
             <tr>
                <td> <asp:Button ID="btnShowReport" runat="server" Text="Show" BackColor="#ff9999" OnClick="btnShowReport_Click" /> </td>
            </tr>
            </table>
             </div>

        <div class="leaveApplication_container"> 
             <table>
          <tr class="tblroweven"><td>
               <asp:GridView ID="grdvOverTimeReports" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvOverTimeReports_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvOverTimeReports_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                       <asp:BoundField DataField="dtdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="BillDate" SortExpression="dtdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="starttime" DataFormatString="{0:HH:mm}" HeaderText="StartTime" SortExpression="starttime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="endtime" DataFormatString="{0:HH:mm}" HeaderText="EndTime" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="monsalary" HeaderText="salary" SortExpression="monsalary" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="dechour"  HeaderText="hour"  SortExpression="dechour" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      

                       <asp:BoundField DataField="Otcount" HeaderText="Otcount" SortExpression="Otcount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="monhramount" HeaderText="hramount" SortExpression="monhramount" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="mondailyamnt" HeaderText="mondailyamnt" SortExpression="mondailyamnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                  </Columns>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
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
               <asp:GridView ID="gdvJstopsheet" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnRowDataBound="gdvJstopsheet_RowDataBound1" ForeColor="Black" OnPageIndexChanging="gdvJstopsheet_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                             <asp:BoundField DataField="intSl" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmplname" HeaderText="Emplname" SortExpression="strEmplname" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="intEmplid" HeaderText="Emplid" SortExpression="intEmplid" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="strJobtype" HeaderText="Jobtype" SortExpression="strJobtype" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="strDesign" HeaderText="Design" SortExpression="strDesign" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="strDept" HeaderText="Dept." SortExpression="strDept" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="monsalary" HeaderText="salary" SortExpression="monsalary" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="dechour" HeaderText="hour" SortExpression="dechour" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="monhramount" HeaderText="hramount" SortExpression="monhramount" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="mondailyamnt" HeaderText="mondailyamnt" SortExpression="mondailyamnt" ItemStyle-HorizontalAlign="Center" >
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
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>