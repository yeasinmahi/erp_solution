<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RmtTADARptNoEmailEmployee.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.RmtTADARptNoEmailEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../../../Content/JS/datepickr.min.js"></script>
       <script type="text/javascript" src="../../Content/JS/scriptEmployeeUpdate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getNoOfficeEmailEmployeeList") %>',
                        data: '{"ApproverEnrol":"' + $("#hdnAreamanagerEnrol").val() + '","prefix":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });
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
         <div class="tabs_container"> TA DA Report Checking (Employees whom have no official Email address ) :<asp:HiddenField ID="hdnenroll" runat="server"/>
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
             <%--<td><asp:DropDownList ID="drdlUnitName"  runat="server" DataSourceID="odsUnitName" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsUnitName" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
            </td>--%>
                 
                  <td style="text-align:right"> <asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList"  AutoPostBack="True" OnSelectedIndexChanged="drdlUnit_SelectedIndexChanged" DataSourceID="odsunitpermissionhr" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
  <asp:ObjectDataSource ID="odsunitpermissionhr" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                  <SelectParameters>
                      <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                  </SelectParameters>
           </asp:ObjectDataSource>
    
   </td>


                 <td style="text-align:right;"><asp:Label ID="lblArea" CssClass="lbl" runat="server" Text="Area Name: "></asp:Label></td>
             <td>
             <%--    <asp:DropDownList ID="drdlArea" CssClass="drdl" runat="server" DataSourceID="odsArea" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>
             <asp:ObjectDataSource ID="odsArea" runat="server" SelectMethod="getEmployeeVsAraPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                     <SelectParameters> <asp:SessionParameter Name="enrol" SessionField="sesUserID" Type="String" /></SelectParameters>
                 </asp:ObjectDataSource>--%> 

                     <asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsgetarea" DataTextField="strAreaName" DataValueField="intAreaId"></asp:DropDownList>  
    
    <asp:ObjectDataSource ID="odsgetarea" runat="server" SelectMethod="getAreafromUnit" TypeName="SAD_BLL.Customer.Report.StatementC">
        <SelectParameters>
            <asp:ControlParameter ControlID="drdlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

             </td>

            </tr>
             <tr>
                 <td><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server" Text="Oil station: "></asp:Label></td>
                 <td colspan="3">
                        <asp:DropDownList ID="drdlSupplierName" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="odsFuelstation" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>

            </tr>
            <tr>
                <td> <asp:Button ID="btnShowReport" runat="server" Text="Show" BackColor="#ff9999" OnClick="btnShowReport_Click" /> </td>
            </tr>
           
       </table>
            </div>
        <div class="leaveApplication_container"> 
             <table>
     
          <tr class="tblroweven"><td colspan="4">
               <asp:GridView ID="grdvForNoofficeEmailDetaills" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="15000" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="grdvForNoofficeEmailDetaills_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvForNoofficeEmailDetaills_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                      <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="BillDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="dtIns" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Insertion date" SortExpression="dtIns" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strNam" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decMovementDurationT" HeaderText="Dur." SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strFromAddressT" HeaderText="FromAdr" SortExpression="strFromAddressT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strMovementAreaT" HeaderText="MovementArea" SortExpression="strMovementAreaT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strToAddressT" HeaderText="To Addr." SortExpression="strToAddressT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strSupportingNoT" HeaderText="Supporting" SortExpression="strSupportingNoT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decFareBusAmountT" HeaderText="BusFare" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareRickshawAmountT" HeaderText="RickFare" SortExpression="decFareRickshawAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decFareCNGAmountT" HeaderText="TaxiCab" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountT" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareBoat" HeaderText="Boat" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decDAAmountT" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="decDriverDACostT" HeaderText="Entertainment" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountT" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strJobstationName" HeaderText="Jobstation" SortExpression="strJobstationName" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalT" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
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
          <div> 
             <table>
     
          <tr class="tblroweven"><td colspan="4">
               <asp:GridView ID="grdvTopsheetallEmploye" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnRowDataBound="grdvTopsheetallEmploye_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvTopsheetallEmploye_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="BillDate" SortExpression="dteFromdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strNamTop" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                       <asp:BoundField DataField="decMovementDurationTop" HeaderText="Dur." SortExpression="decMovementDurationT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="decFareBusAmountTop" HeaderText="BusFare" SortExpression="decFareBusAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareRickshawAmountTop" HeaderText="RickFare" SortExpression="decFareRickshawAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decFareCNGAmountTop" HeaderText="TaxiCab" SortExpression="decFareCNGAmountT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareTrainAmountTop" HeaderText="Train" SortExpression="decFareTrainAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decfareBoatTop" HeaderText="Boat" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountTop" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDAAmountTop" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     <asp:BoundField DataField="decDriverDACostTop" HeaderText="Entertainment" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountTop" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="decOtherBillAmountTop" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstationName" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalTop" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
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

         <div> 
             <table>
     
          <tr class="tblroweven"><td colspan="4">
               <asp:GridView ID="grdvNameVsTotalBillforNOemailemployee" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" CellPadding="4" OnRowDataBound="grdvNameVsTotalBillforNOemailemployee_RowDataBound" ForeColor="#333333" OnPageIndexChanging="grdvNameVsTotalBillforNOemailemployee_PageIndexChanging" GridLines="None">
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         
                         <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      <asp:BoundField DataField="strnam" HeaderText="Employee Name" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="intEnrol" HeaderText="Enrol" SortExpression="strNam" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       
                          <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="strJobty" HeaderText="JobType" SortExpression="strJobty" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
                          <asp:BoundField DataField="strJobstat" HeaderText="Jobstation" SortExpression="strJobstat" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="intWorkingday" HeaderText="Working Day" SortExpression="intWorkingday" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decGrand" HeaderText="Total" SortExpression="decGrand" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
            
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
              </asp:GridView> </td>
         </tr>    
     </table>
            </div>

        <div> 
             <table>
     
          <tr class="tblrowodd">
                <td>
                  
              

                    <asp:GridView ID="grdvRptStandVheicleDayBasis" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvRptStandVheicleDayBasis_PageIndexChanging1" OnRowDataBound="grdvRptStandVheicleDayBasis_RowDataBound1">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="intsl" HeaderText="Sl" SortExpression="intsl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="dteBildate" HeaderText="Date" SortExpression="dteBildate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="strVheiclename" HeaderText="Vheicle Name" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="dteInsertdate" HeaderText="Insertion Date" SortExpression="dteInsertdate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmployeename" HeaderText="EmployeeName" SortExpression="strEmployeename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strOilpaymenttype" HeaderText="OilPay" SortExpression="strOilpaymenttype" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decRunbyoilkm"  HeaderText="RunbyOil" SortExpression="decRunbyoilkm" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="strOilStationanem"  HeaderText="OilStationName" SortExpression="strOilStationanem" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                     


                          <asp:BoundField DataField="decOilcash" HeaderText="OilCash" SortExpression="decOilcash" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decOilCredit" HeaderText="OilCredit" SortExpression="decOilCredit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strPaytype" HeaderText="oilPay" SortExpression="strPaytype" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="strGashstationName" HeaderText="GasStation" SortExpression="strGashstationName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decGashCashamount" HeaderText="GashCash" SortExpression="decGashCashamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decGashCreditAmount"  HeaderText="GashCredit" SortExpression="decGashCreditAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decStartmlg"  HeaderText="startMlag" SortExpression="decStartmlg" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

                         <asp:BoundField DataField="decEndMilage" HeaderText="EndMlg" SortExpression="decEndMilage" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decConsumed" HeaderText="Consumed" SortExpression="decConsumed" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strSupporting" HeaderText="Supporting" SortExpression="strSupporting" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="decCostamntMnt" HeaderText="MntCost" SortExpression="decCostamntMnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decDaamount" HeaderText="DA" SortExpression="decDaamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decHotel"  HeaderText="Hotel" SortExpression="decHotel" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decOther"  HeaderText="Other" SortExpression="decOther" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decRowTotal"  HeaderText="Rowtotal" SortExpression="decRowTotal" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView>



                </td>


            </tr>
                 </table>
                </div>
                <div> 
                <table>
                  <tr class="tblrowodd">
                <td>
                  
           
                    <asp:GridView ID="grdvRptStandVheicleSummery" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvRptStandVheicleSummery_PageIndexChanging" OnRowDataBound="grdvRptStandVheicleSummery_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         <asp:BoundField DataField="SL" HeaderText="SL" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="strVheiclename" HeaderText="VheicleName" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="decConsumed" HeaderText="Consumed" SortExpression="decConsumed" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="decGashCashamount" HeaderText="GashCashamount" SortExpression="decGashCashamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decGashCreditAmount" HeaderText="GashCreditAmount" SortExpression="decGashCreditAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="GasTotal" HeaderText="GasTotal" SortExpression="GasTotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="runbycng" HeaderText="runbycng" SortExpression="runbycng" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decOilcash" HeaderText="Oilcash" SortExpression="decOilcash" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decOilCredit"  HeaderText="OilCredit" SortExpression="decOilCredit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decOilTotal"  HeaderText="OilTotal" SortExpression="decOilTotal" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decConsumed" HeaderText="Consumed" SortExpression="decConsumed" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decRunbyoilkm" HeaderText="RunByOIL" SortExpression="strSupporting" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                         
                     <asp:BoundField DataField="decOilLtr" HeaderText="OilLtr" SortExpression="decOilLtr" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      <asp:BoundField DataField="decCostamntMnt" HeaderText="MntCost" SortExpression="decCostamntMnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decDaamount" HeaderText="DA" SortExpression="decDaamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decHotel"  HeaderText="Hotel" SortExpression="decHotel" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decOther"  HeaderText="Other" SortExpression="decOther" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decRowTotal"  HeaderText="Rowtotal" SortExpression="decRowTotal" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView>



                </td>


            </tr>
                    </table>
                    </div>

                    <div> 
             <table>
                   <tr class="tblrowodd">
                <td>
                  
            
                    <asp:GridView ID="grdvOnlyOilReport" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvOnlyOilReport_PageIndexChanging" OnRowDataBound="grdvOnlyOilReport_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                          <asp:BoundField DataField="SL" HeaderText="SL" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="strVheiclename" HeaderText="VheicleName" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="decConsumed" HeaderText="Consumed" SortExpression="decConsumed" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     

                          <asp:BoundField DataField="decOilcash" HeaderText="Oilcash" SortExpression="decOilcash" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decOilCredit"  HeaderText="OilCredit" SortExpression="decOilCredit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decOilTotal"  HeaderText="OilTotal" SortExpression="decOilTotal" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView>



                </td>


            </tr>


     </table>
            </div>

         <div> 
             <table>
                   <tr class="tblrowodd">
                <td>
                  
            
                    <asp:GridView ID="grdvRptOnlyCNG" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnPageIndexChanging="grdvRptOnlyCNG_PageIndexChanging" OnRowDataBound="grdvRptOnlyCNG_RowDataBound">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                     <Columns>
                         
                          <asp:BoundField DataField="SL" HeaderText="SL" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="strVheiclename" HeaderText="VheicleName" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="decConsumed" HeaderText="Consumed" SortExpression="decConsumed" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     

                          <asp:BoundField DataField="decGashCashamount" HeaderText="GashCashamount" SortExpression="decGashCashamount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decGashCreditAmount"  HeaderText="GashCreditAmount" SortExpression="decGashCreditAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="GasTotal"  HeaderText="GasTotal" SortExpression="GasTotal" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="runbycng"  HeaderText="runbycng" SortExpression="runbycng" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        

                    
                     
                 </Columns>


                     <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                     <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                     <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                     <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                     <SortedAscendingCellStyle BackColor="#F4F4FD" />
                     <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                     <SortedDescendingCellStyle BackColor="#D8D8F0" />
                     <SortedDescendingHeaderStyle BackColor="#3E3277" />


                 </asp:GridView>



                </td>


            </tr>


     </table>
            </div>

         <div class="leaveApplication_container"> 
             <table>
                   <tr class="tblrowodd">
                <td>
                 
            
                    <asp:GridView ID="grdvCreditStationBillWithoutStandVheicle" ShowFooter="true" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="grdvCreditStationBillWithoutStandVheicle_PageIndexChanging" OnRowDataBound="grdvCreditStationBillWithoutStandVheicle_RowDataBound">
                        <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         
                          <asp:BoundField DataField="SL" HeaderText="SL" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="strEmploye" HeaderText="Employe Name" SortExpression="strEmploye" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="intEnrol" HeaderText="Enrol Number" SortExpression="intEnrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     

                          <asp:BoundField DataField="strDesignation" HeaderText="Employee Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="strJobstation"  HeaderText="Jobstation" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="strUnit"  HeaderText="Unit" SortExpression="strUnit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="strFuelStationName"  HeaderText="Fuel Station Name" SortExpression="strFuelStationName" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="decTotal"  HeaderText="Total" SortExpression="decTotal" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                     
                 </Columns>


                        <EditRowStyle BackColor="#7C6F57" />


                     <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
                        <RowStyle BackColor="#E3EAEB" />
                     <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F8FAFA" />
                     <SortedAscendingHeaderStyle BackColor="#246B61" />
                     <SortedDescendingCellStyle BackColor="#D4DFE1" />
                     <SortedDescendingHeaderStyle BackColor="#15524A" />


                 </asp:GridView>



                </td>


            </tr>


     </table>
            </div>


         <div class="leaveApplication_container"> 
             <table>
                   <tr class="tblrowodd">
                <td>
               
            
                    <asp:GridView ID="grdvFuelCreditStationbillvsEmployee" ShowFooter="true" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvFuelCreditStationbillvsEmployee_PageIndexChanging" OnRowDataBound="grdvFuelCreditStationbillvsEmployee_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         <%--strstationname ,instationid ,decbill ,intenrol ,months ,sl ,emplname ,desg ,dept ,jobstation ,unit--%> 
                        <asp:TemplateField HeaderText="Sl.">
                <ItemTemplate>
                <%#((GridViewRow)Container).RowIndex +1 %>
                </ItemTemplate>
                </asp:TemplateField>


                         <asp:BoundField DataField="emplname" HeaderText="Employe Name" SortExpression="strEmploye" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         

                      <asp:BoundField DataField="intenrol" HeaderText="Enrol Number" SortExpression="intenrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                     

                          <asp:BoundField DataField="desg" HeaderText="Employee Designation" SortExpression="strDesignation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                           <asp:BoundField DataField="months"  HeaderText="Months" SortExpression="months" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="strstationname"  HeaderText="Station name" SortExpression="strstationname" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                      <asp:BoundField DataField="decbill"  HeaderText="Bill" SortExpression="decbill" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="jobstation"  HeaderText="Jobstation" SortExpression="jobstation" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="unit"  HeaderText="Unit" SortExpression="unit" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView>



                </td>


            </tr>


     </table>
            </div>

         <div class="leaveApplication_container"> 
             <table>
                   <tr class="tblrowodd">
                <td>
               
            
                    <asp:GridView ID="grdvOnlyCreditStationBill" runat="server" ShowFooter="true" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvOnlyCreditStationBill_PageIndexChanging" OnRowDataBound="grdvOnlyCreditStationBill_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                          <asp:BoundField DataField="Sl" HeaderText="SL" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="strCNGOILStation" HeaderText="Station Name" SortExpression="strCNGOILStation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="decCNGOILAmount" HeaderText="Bill Amount" SortExpression="decCNGOILAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         <asp:BoundField DataField="strJobstation" HeaderText="Job Station" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         <asp:BoundField DataField="strUnit"  HeaderText="Unit Name" SortExpression="strUnit" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView></td> </tr>

             </table>
            </div>

        <div> 
             <table>
                   <tr class="tblrowodd">
                <td>
              
            
                    <asp:GridView ID="grdvCreditstationbillEmployeebase" ShowFooter="true" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvCreditstationbillEmployeebase_PageIndexChanging" OnRowDataBound="grdvCreditstationbillEmployeebase_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                          <asp:BoundField DataField="Sl" HeaderText="SL" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="strEmployeeName" HeaderText="EmployeeName" SortExpression="strEmployeeName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="intenrol" HeaderText="Enrol" SortExpression="intenrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="dtedate" HeaderText="Bill Date" DataFormatString="{0:MM/dd/yyyy}" SortExpression="dtedate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="totalcngcredit1" HeaderText="Bill Amount" SortExpression="totalcngcredit1" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                           <asp:BoundField DataField="strFuelStationName" HeaderText="FuelStationName" SortExpression="strFuelStationName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                         <asp:BoundField DataField="strJobStationName" HeaderText="Job Station" SortExpression="strJobStationName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         <asp:BoundField DataField="strUnit"  HeaderText="Unit Name" SortExpression="strUnit" ItemStyle-HorizontalAlign="Center"  >
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


                 </asp:GridView></td> </tr>

             </table>
            </div>
        
       



         <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>