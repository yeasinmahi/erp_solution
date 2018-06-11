<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaDaNoBike.aspx.cs" Inherits="UI.SAD.Sales.Report.RptRemoteSales.TaDaNoBike" %>
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

             $('#<%=grdvBikeCarUserDetaills.ClientID%>').gridviewScroll({
                 width: 725,
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
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlUserType" runat="server" DataTextField="strUser Type" DataValueField="intID" DataSourceID="odsUser"></asp:DropDownList>
                                      <asp:ObjectDataSource ID="odsUser" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRmtUserCatg" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAUserTypeTableAdapter">
                                        <InsertParameters>  <asp:Parameter Name="strUser_Type" Type="String" /> </InsertParameters> </asp:ObjectDataSource>
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
           
            
            
            
            <tr class="tblroweven"><td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server" DataSourceID="odsRept" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                                    
                                    <asp:ObjectDataSource ID="odsRept" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
                                        <InsertParameters>
                                            <asp:Parameter Name="strReportType" Type="String" />
                                        </InsertParameters>
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
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="25" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging">
                  <AlternatingRowStyle BackColor="#CCCCCC" />
                  <Columns>
                    
                      
                      <asp:BoundField DataField="id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="dtIns" HeaderText="Insertion" DataFormatString="{0:dd/MM/yyyy}" SortExpression="dtIns" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strNam" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strDesg" HeaderText="Designation" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="strFromaddr" HeaderText="From Address" SortExpression="strFromAdr" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strToadr" HeaderText="To Address" SortExpression="strAddr" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strmovmentspot" HeaderText="Movement Spots" SortExpression="strSupp" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decmovdur" HeaderText="MovDuraion" SortExpression="decMovDuraion" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="decfare" HeaderText="Bus" SortExpression="decBus" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="decrick" HeaderText="Rick" SortExpression="decRick" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="cng" HeaderText="CNG" SortExpression="decCNG" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="train" HeaderText="Train" SortExpression="decTrain" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="boat" HeaderText="Boat" SortExpression="decBoat" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="othevh" HeaderText="Anoth.Vh." SortExpression="decAnother" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strsuppor" HeaderText="Remarks" SortExpression="strRemarks" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decownda" HeaderText="OwnDA" SortExpression="decOwnDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decOtherda" HeaderText="Oth.DA" SortExpression="decOtherDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dechotel" HeaderText="Hotel" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="decOtherCostAmount" HeaderText="OtherCost " SortExpression="decOtherCostAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="decrowtotal" HeaderText="Total " SortExpression="decrowtotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strContac" HeaderText="Contact Person " SortExpression="strContac" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="strphone" HeaderText="Phone " SortExpression="strphone" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="strVisitorg" HeaderText="Organization " SortExpression="strVisitorg" ItemStyle-HorizontalAlign="Center" >
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
                   

         <tr class="tblrowOdd" >
             <td>
                 <asp:GridView ID="GridViewNonCarTopsheet" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GridViewNonCarTopsheet_PageIndexChanging">
                     <Columns>
                    
                       
                     
                       <asp:BoundField DataField="dteFromdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="From Date" SortExpression="dtFrom" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       

                      <asp:BoundField DataField="strNam" HeaderText="Employee  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="Movdur" HeaderText="MovDuraion" SortExpression="decMovDuraion" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        
                       <asp:BoundField DataField="Busfare" HeaderText="Bus" SortExpression="decBus" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                        <asp:BoundField DataField="rickf" HeaderText="Rick" SortExpression="decRick" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="cngf" HeaderText="CNG" SortExpression="decCNG" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="trainf" HeaderText="Train" SortExpression="decTrain" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="boatf" HeaderText="Boat" SortExpression="decBoat" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="othvh" HeaderText="Anoth.Vh." SortExpression="decAnother" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      

                      <asp:BoundField DataField="ownda" HeaderText="OwnDA" SortExpression="decOwnDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      <asp:BoundField DataField="otherda" HeaderText="Oth.DA" SortExpression="decOtherDA" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="hotel" HeaderText="Hotel" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="othercost" HeaderText="Other Cost" SortExpression="dechotel" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         

                      <asp:BoundField DataField="rowtoal" HeaderText="Total " SortExpression="decrowtotal" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                      




                     </Columns>


                     <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                     <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                     <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" ForeColor="#003399" />
                     <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                     <SortedAscendingCellStyle BackColor="#EDF6F6" />
                     <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                     <SortedDescendingCellStyle BackColor="#D6DFDF" />
                     <SortedDescendingHeaderStyle BackColor="#002876" />


                 </asp:GridView>


             </td>

         </tr>  
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
     <%--                    ,decSupplierCNG , decSupplierGas , decPersonalMilage,SupplierTotal, decMlgRate ,decPersonalTotalcost
	       ,PaymentType,strFuelStationaname--%>


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

            <tr class="tblrowodd">
                <td>
                   

                    <asp:GridView ID="grdvRptRemoteTADABikeCarUserTopsheet" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvRptRemoteTADABikeCarUserTopsheet_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="id" HeaderText="Sl" SortExpression="intSl" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="dteDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="MovementDate" SortExpression="dteMove" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      

                     
                       <asp:BoundField DataField="strNamTop" HeaderText="Employee Name" SortExpression="strNamTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       
                           <asp:BoundField DataField="decMovementDurationTop" HeaderText="MovDur." SortExpression="decMovementDurationTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decConsumedKmTop" HeaderText="ConSumedkm" SortExpression="decConsumedKmTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decQntPetrolTop" HeaderText="QntPetrol" SortExpression="decQntPetrolTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decCostPetrolTop" HeaderText="CostPetrol" SortExpression="decCostPetrolTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      <asp:BoundField DataField="decQntOctenTop" HeaderText="QntOct" SortExpression="decQntOctenTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="decCostOctenTop" HeaderText="CostOct" SortExpression="decCostOctenTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decQntCarbonNitGasTop" HeaderText="QntCNG" SortExpression="decQntCarbonNitGasTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decCostCarbonNitGasTop" HeaderText="CostCNG" SortExpression="decCostCarbonNitGasTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                            <asp:BoundField DataField="decQntLubricantTop" HeaderText="QntLubr" SortExpression="decQntLubricantTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decCostLubricant" HeaderText="CostLubr" SortExpression="decCostLubricant" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>




                             <asp:BoundField DataField="decFareBusAmountTop" HeaderText="BusFare" SortExpression="decFareBusAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decFareRickshawAmountTop" HeaderText="RickFare" SortExpression="decFareRickshawAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decFareCNGAmountTop" HeaderText="TaxiCab" SortExpression="decFareCNGAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decFareTrainAmountTop" HeaderText="TrainFare" SortExpression="decFareTrainAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      <asp:BoundField DataField="decFareAirPlaneTop" HeaderText="AirPlane" SortExpression="decFareAirPlaneTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="decFareOtherVheicleAmountTop" HeaderText="OtherVhc." SortExpression="decFareOtherVheicleAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decCostAmountMaintenaceTop" HeaderText="Mnt.Cost" SortExpression="decCostAmountMaintenaceTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decFeryTollCostTop" HeaderText="FeryToll" SortExpression="decFeryTollCostTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>



                      


                            <asp:BoundField DataField="decDAAmountTop" HeaderText="OwnDA" SortExpression="decDAAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                       <asp:BoundField DataField="decDriverDACostTop" HeaderText="DriveDA" SortExpression="decDriverDACostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decHotelBillAmountTop" HeaderText="OwnHotel" SortExpression="decHotelBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                      
                         <asp:BoundField DataField="decDriverHotelBillAmountTop" HeaderText="DriverHotel" SortExpression="decDriverHotelBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                      <asp:BoundField DataField="decPhotoCopyCostTop" HeaderText="Photocopy" SortExpression="decPhotoCopyCostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                    
                      <asp:BoundField DataField="decCourierCostTop" HeaderText="Courier" SortExpression="decCourierCostTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decOtherBillAmountTop" HeaderText="OtherBill" SortExpression="decOtherBillAmountTop" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decRowTotalTop" HeaderText="Total" SortExpression="decRowTotalTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                    

                           <asp:BoundField DataField="decFuelSupplierCNGBillTop" HeaderText="SupplierCNG" SortExpression="decFuelSupplierCNGBillTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                         <asp:BoundField DataField="decFuelSupplierGASBillTop" HeaderText="SupplierGas" SortExpression="decFuelSupplierGASBillTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decPersonalMilageQntTop" HeaderText="PersonalMilage" SortExpression="decPersonalMilageQntTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          

                          <asp:BoundField DataField="decPersonalUMillgRateTop" HeaderText="MlgRate" SortExpression="decPersonalUMillgRateTop" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersUMilTotCostTotal" HeaderText="PersonalTotalcost" SortExpression="decPersUMilTotCostTotal" ItemStyle-HorizontalAlign="Center" >
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
                 <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvEmployeevsSupervisorWithBillAmount" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvRptRemoteTADABikeCarUserTopsheet_PageIndexChanging" OnRowDataBound="grdvEmployeevsSupervisorWithBillAmount_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
  
             
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Si" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="intEmployeeid" HeaderText="Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strSupervisor"  HeaderText="Supervisor" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="LMAudit" HeaderText="LM Audit" SortExpression="LMAudit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                          <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
 
                    
                      <asp:BoundField DataField="CMSupervisor" HeaderText="CM Supervisor" SortExpression="CMSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                         
                      
                        
                     
                     <asp:BoundField DataField="decPersonaluseQnt" HeaderText="Qnt" SortExpression="decPersonaluseQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalCost" HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amount" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="CMHR" HeaderText="CM HR" SortExpression="CMHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="PayablebyHR"  HeaderText="Payableby HR" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decCMHRNegative"  HeaderText="Recieveble HR" SortExpression="decCMHRNegative" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="CMAudit"  HeaderText="CMAudit" SortExpression="CMAudit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strBankAccountNo"  HeaderText="AccountNo." SortExpression="strBankAccountNo" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strBankACName" HeaderText="Bank" SortExpression="strBankACName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strBranchName" HeaderText="BranchName" SortExpression="strBranchName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strRoutingNumber" HeaderText="RoutingNumber" SortExpression="strRoutingNumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
               

                         <asp:BoundField DataField="ysnSalaryhold"  HeaderText="Salaryhold" SortExpression="ysnSalaryhold" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strArea" HeaderText="strArea" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
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


                  <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvPaytocompany" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvPaytocompany_PageIndexChanging" OnRowDataBound="grdvPaytocompany_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Si" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="intEmployeeid" HeaderText="Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strSupervisor"  HeaderText="Supervisor" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="LMAudit" HeaderText="LM Audit" SortExpression="LMAudit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                          <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
 
                    
                      <asp:BoundField DataField="CMSupervisor" HeaderText="CM Supervisor" SortExpression="CMSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                         
                      
                        
                     
                     <asp:BoundField DataField="decPersonaluseQnt" HeaderText="Qnt" SortExpression="decPersonaluseQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalCost" HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amount" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="CMHR" HeaderText="CM HR" SortExpression="CMHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="PayablebyHR"  HeaderText="Payableby HR" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                          <asp:BoundField DataField="decCMHRNegative"  HeaderText="Receivble HR" SortExpression="decCMHRNegative" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strBankAccountNo"  HeaderText="AccountNo." SortExpression="strBankAccountNo" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strBankACName" HeaderText="Bank" SortExpression="strBankACName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strBranchName" HeaderText="BranchName" SortExpression="strBranchName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strRoutingNumber" HeaderText="RoutingNumber" SortExpression="strRoutingNumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                   

                         <asp:BoundField DataField="ysnSalaryhold"  HeaderText="Salaryhold" SortExpression="ysnSalaryhold" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strArea" HeaderText="strArea" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
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


                 <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvAllunitTADAExporttoExcel" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvPaytocompany_PageIndexChanging" OnRowDataBound="grdvAllunitTADAExporttoExcel_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <asp:BoundField DataField="Si" HeaderText="Sl" SortExpression="Si" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="intEmployeeid" HeaderText="Enrol" SortExpression="intEmployeeid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="strSupervisor"  HeaderText="Supervisor" SortExpression="strSupervisor" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="LMAudit" HeaderText="LM Audit" SortExpression="LMAudit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                          <asp:BoundField DataField="CMApplicant" HeaderText="CM Applicant" SortExpression="CMApplicant" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
 
                    
                      <asp:BoundField DataField="CMSupervisor" HeaderText="CM Supervisor" SortExpression="CMSupervisor" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                         
                      
                        
                     
                     <asp:BoundField DataField="decPersonaluseQnt" HeaderText="Qnt" SortExpression="decPersonaluseQnt" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decPersonalCost" HeaderText="Personal Cost" SortExpression="decPersonalCost" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decAdvanceAmount"  HeaderText="Advance Amount" SortExpression="decAdvanceAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="CMHR" HeaderText="CM HR" SortExpression="CMHR" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="PayablebyHR"  HeaderText="Payableby HR" SortExpression="PayablebyHR" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                         <asp:BoundField DataField="decCMHRNegative"  HeaderText="Receiveble HR" SortExpression="decCMHRNegative" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                         <asp:BoundField DataField="CMAudit"  HeaderText="CMAudit" SortExpression="CMAudit" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                          <asp:BoundField DataField="strBankAccountNo"  HeaderText="AccountNo." SortExpression="strBankAccountNo" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strBankACName" HeaderText="Bank" SortExpression="strBankACName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strBranchName" HeaderText="BranchName" SortExpression="strBranchName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strRoutingNumber" HeaderText="RoutingNumber" SortExpression="strRoutingNumber" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                  

                         <asp:BoundField DataField="ysnSalaryhold"  HeaderText="Salaryhold" SortExpression="ysnSalaryhold" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                          <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstation" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                     

                    
                      <asp:BoundField DataField="strArea" HeaderText="strArea" SortExpression="strArea" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="strunit" HeaderText="Unit" SortExpression="strunit" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
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

                  <tr class="tblrowodd">
                <td>
                  

                    <asp:GridView ID="grdvAdvanceSTATUS" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvAdvanceSTATUS_PageIndexChanging" OnRowDataBound="grdvAdvanceSTATUS_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                         
                         <%--<asp:BoundField DataField="SL" HeaderText="Sl" SortExpression="SL" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>--%>

                          <asp:BoundField DataField="strEmplName" HeaderText="Employee Name" SortExpression="strEmplName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                            <asp:BoundField DataField="intEnrol" HeaderText="Enrol" SortExpression="intEnrol" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="dteTourStartdate" DataFormatString="{0:dd/MM/yyyy}"  HeaderText="FromDate" SortExpression="dteTourStartdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                        
                         <asp:BoundField DataField="dteTourEndDate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Todate" SortExpression="dteTourEndDate" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                          <asp:BoundField DataField="intTotalday" HeaderText="Days" SortExpression="intTotalday" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                         
 
                    
                      <asp:BoundField DataField="strMoveSport" HeaderText="Movement" SortExpression="strMoveSport" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                     
                         
                      
                        
                     
                     <asp:BoundField DataField="strPurpouse" HeaderText="Purpouse" SortExpression="strPurpouse" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>

                          <asp:BoundField DataField="decAdvAmount" HeaderText="Advance" SortExpression="decAdvAmount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>


                       <asp:BoundField DataField="decApproveAmount"  HeaderText="SupApprove" SortExpression="decApproveAmount" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      
                          <asp:BoundField DataField="decAproveAmountByAccount" HeaderText="AccountsApprove" SortExpression="decAproveAmountByAccount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
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

<%--=========================================End My Code From Here=================================================--%>
       
    </form>
</body>
</html>