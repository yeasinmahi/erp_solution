<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportsTourPlan.aspx.cs" Inherits="UI.HR.TourPlan.ReportsTourPlan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui-1.8.13.js"></script>
   <script type="text/javascript" src="../../Content/JS/scriptEmployeeUpdate.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
   

    </head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager" EnablePageMethods="true" runat="server"></asp:ScriptManager>
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
         <div class="tabs_container"> Tour Plan Report Checking  :<asp:HiddenField ID="hdnenroll" runat="server"/>
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
             <td><asp:DropDownList ID="drdlUnitName" CssClass="drdl" runat="server" DataSourceID="odsUnitName" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsUnitName" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
            <td style="text-align:right;"><asp:Label ID="lblArea" CssClass="lbl" runat="server" Text="Area Name: "></asp:Label></td>
             <td><asp:DropDownList ID="drdlArea" CssClass="drdl" runat="server" DataSourceID="odsArea" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>
             <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="getEmployeeVsAraPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                     <SelectParameters> <asp:SessionParameter Name="enrol" SessionField="sesUserID" Type="String" /></SelectParameters>
                 </asp:ObjectDataSource> </td>

            </tr>
            <tr>
                <td> <asp:Button ID="btnShowReport" runat="server" Text="Show" BackColor="#ff9999" OnClick="btnShowReport_Click" /> </td>
            </tr>
       </table>
            </div>

         <div class="leaveApplication_container"> 
            
             <table>
     
                 <%--RowId ,strEmployeename,intEnrol ,strDesignation ,strAreaName ,dteFromdate ,dteTodate ,tmtStartTime ,tmtEndTime ,strNightstay ,strVisitedarea ,strVisitPurpouse--%> 

          <tr class="tblroweven"><td colspan="4">
               <asp:GridView ID="grdvTourPlanReports" runat="server" AutoGenerateColumns="False"  BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvTourPlanReports_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvTourPlanReports_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                      <asp:BoundField DataField="RowId" HeaderText="Sl" SortExpression="RowId" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmployeename" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  /> </asp:BoundField>

                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="StartDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     
                      <asp:BoundField DataField="dteTodate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="EndDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                       <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="tmtStartTime" HeaderText="StartTime" SortExpression="StartTime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="tmtEndTime" HeaderText="EndTime" SortExpression="tmtEndTime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strNightstay" HeaderText="NightStay" SortExpression="strNightstay" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strVisitedarea" HeaderText="VisitArea" SortExpression="strVisitedarea" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strVisitPurpouse" HeaderText="Purpose" SortExpression="strVisitPurpouse" ItemStyle-HorizontalAlign="Center" >
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


  <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>