<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADAEntryByAnotherRpt.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.TADAEntryByAnotherRpt" %>

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
</script> <script>
              $(document).ready(function () {
                  SearchText();
              });
              function Changed() {
                  document.getElementById('hdfSearchBoxTextChange').value = 'true';
              }
              function SearchText() {
                  $("#txtFullName").autocomplete({
                      source: function (request, response) {
                          $.ajax({
                              type: "POST",
                              contentType: "application/json;",
                              url: "TADAEntryByAnotherRpt.aspx/GetAutoCompleteData",
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
         <div class="tabs_container"> TA DA Report Checking (Entry By Another ) :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
       <asp:HiddenField ID="hdnAction" runat="server"/>
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
         <td><asp:TextBox ID="txtFullName" runat="server" AutoPostBack="true" CssClass="txtBox"  ></asp:TextBox> <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><span style="color:red">*</span></td>
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
                <td> <asp:Button ID="btnShowReport" runat="server" Text="Show" BackColor="#ff9999" OnClick="btnShowReport_Click" /> </td>
            </tr>
           
       </table>
            </div>

        <div>
            <table>
                
                  <tr class="tblroweven">
                <td>
                 


                    <asp:GridView ID="grdvBikeCarUserDetaills" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" OnRowDataBound="grdvBikeCarUserDetaills_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvBikeCarUserDetaills_PageIndexChanging">
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
                      
                     


                       <asp:BoundField DataField="decStartTimeT" HeaderText="StartT." SortExpression="decStartTimeT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndHourT" HeaderText="EndHour" SortExpression="decEndHourT" ItemStyle-HorizontalAlign="Center" >
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

                      <asp:BoundField DataField="strNightStayT" HeaderText="Night Stay" SortExpression="strNightStayT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       
                      <asp:BoundField DataField="decStartMilageT" HeaderText="Start Milage" SortExpression="decStartMilageT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decEndMilageT" HeaderText="End Milage" SortExpression="decEndMilageT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decConsumedKmT" HeaderText="Cons.KM" SortExpression="decConsumedKmT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strSupportingNoT" HeaderText="Supporting" SortExpression="strSupportingNoT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntPetrolT" HeaderText=" Qnt.Petr" SortExpression="decQntPetrolT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decCostPetrolT" HeaderText="CostPet" SortExpression="decCostPetrolT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decQntOctenT" HeaderText="QntOct" SortExpression="decQntOctenT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                  
                          <asp:BoundField DataField="decCostOctenT" HeaderText="CostOct" SortExpression="decCostOctenT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decQntCarbonNitGasT" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostCarbonNitGasT" HeaderText="CostCNG" SortExpression="decCostCarbonNitGasT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decLubricantQnt" HeaderText="QntLubricant" SortExpression="decLubricantQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>  
                         
                       <asp:BoundField DataField="lubricantcost" HeaderText="CostLubricant" SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" >
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

                       <asp:BoundField DataField="decFareAirPlaneT" HeaderText="AirPlane" SortExpression="decFareAirPlaneT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decFareOtherVheicleAmountT" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCostAmountMaintenaceT" HeaderText="Mnt.Cost" SortExpression="decCostAmountMaintenaceT.A" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decFeryTollCostT" HeaderText="FerryToll" SortExpression="decFeryTollCostT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decDAAmountT" HeaderText="OwnDa" SortExpression="decDAAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                         <asp:BoundField DataField="decDriverDACostT" HeaderText="DriverDA" SortExpression="decDriverDACostT" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decHotelBillAmountT" HeaderText="OwnHotelB" SortExpression="decHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decDriverHotelBillAmountT" HeaderText="DrvHotelB" SortExpression="decDriverHotelBillAmountT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decPhotoCopyCostT" HeaderText="PhtCopy" SortExpression="decPhotoCopyCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decCourierCostT" HeaderText="Courier" SortExpression="decCourierCostT" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="decOtherBillAmountT" HeaderText="Oth.Bill" SortExpression="decOtherBillAmountT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decRowTotalT" HeaderText="Total" SortExpression="decRowTotalT" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                    
                          <asp:BoundField DataField="decSupplierCNG" HeaderText="SupplierCNG" SortExpression="decSupplierCNG" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="decSupplierGas" HeaderText="SupplierGas" SortExpression="decSupplierGas" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decPersonalMilage" HeaderText="PersonalMilage" SortExpression="decPersonalMilage" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="SupplierTotal" HeaderText="SupplierTotal" SortExpression="SupplierTotal" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decMlgRate" HeaderText="MlgRate" SortExpression="decMlgRate" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalTotalcost" HeaderText="PersonalTotalcost" SortExpression="decPersonalTotalcost" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" SortExpression="PaymentType" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="strFuelStationaname" HeaderText="FuelStationaname" SortExpression="strFuelStationaname" ItemStyle-HorizontalAlign="Center" >
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

                           <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                 </asp:GridView>



                </td>


            </tr>







            </table>
        </div>


         <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>