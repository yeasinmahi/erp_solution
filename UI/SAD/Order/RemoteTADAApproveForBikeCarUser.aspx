<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADAApproveForBikeCarUser.aspx.cs" Inherits="UI.SAD.Order.RemoteTADAApproveForBikeCarUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />



    <script src="../../../../Content/JS/datepickr.min.js"></script>

    

      
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getApplicantListForBikeAndCarUserBillApprove") %>',
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
    <div class="tabs_container"> TA - DA information approve for Bike and Car User  :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>  <asp:HiddenField ID="hdnUnitid" runat="server"/>
        <hr />

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
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="Employee Name:  "></asp:Label></td>
                                <td> <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                                    
                                   
             </td>
        
             
              </tr>
           
            
            
            
            <tr class="tblroweven"><td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                                <td><asp:DropDownList ID="ddlReportType" runat="server" DataTextField="strReportType" DataValueField="intID" DataSourceID="odsReportTypetadaApr"></asp:DropDownList>
                                    
                                   
                                    
                                    <asp:ObjectDataSource ID="odsReportTypetadaApr" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
                                        <InsertParameters>
                                            <asp:Parameter Name="strReportType" Type="String" />
                                        </InsertParameters>
                                    </asp:ObjectDataSource>
                                    
                                   
                                    
                </td>
         </tr>

        <tr class="tblrowOdd"><td style="text-align:right" colspan="4"> <asp:Button ID="btnApprTADAFoBikeCarUser" runat="server" Text="Show Bill Info" OnClick="btnApprTADAFoBikeCarUser_Click"/></td> 
           
            

             <td style="text-align:right" ><asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" BackColor="#ffcc99" Font-Bold="true" /> </td>
        </tr>
            </table>
            

           </div>
             <div class="leaveApplication_container"> 
                 <table>
              
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          
         <tr class="tblrowOdd" >
             <td colspan="4">
                 <asp:GridView ID="grdvForApproveTADABikeCarUser" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="3000" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HeaderStyle-Wrap="true">
                     <Columns>
                       
                   

                         <asp:BoundField DataField="Id" HeaderText="Sl" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

  <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdBillDate"   runat="server" Value='<%# Bind("dteFromdate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteFromdateNoBikeDet"   CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dteFromdate") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Inst. Date" SortExpression="dteToDate">
                    <ItemTemplate>
                     <asp:HiddenField   ID="hdInsdate"   runat="server" Value='<%# Bind("dtIns", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="dteInsdateNoBikeDet"  CssClass="txtBox" runat="server" Width="75px" TextMode="Date"  Text='<%# Bind("dtIns") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
 <asp:TemplateField HeaderText="Employee  Name" SortExpression="strEmplName">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEmpName" runat="server"  Value='<%# Bind("strNam", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strNamNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNam") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdDesignation" runat="server"  Value='<%# Bind("strDesg", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="strDesgNoBikeDet" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strDesg") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="decStartTimeT" SortExpression="decstartt">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdstarttime" runat="server"  Value='<%# Bind("decStartTimeT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtStarTime" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartTimeT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="decEndHourT" SortExpression="decdecEndHourT">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndHour" runat="server"  Value='<%# Bind("decEndHourT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndHourT" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndHourT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Movement duration " SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovedur" runat="server"  Value='<%# Bind("decMovementDurationT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decMovementDurationT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="FromAddress" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFromAddressT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strFromAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Movementspots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strMovementAreaT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrMovementAreaT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strMovementAreaT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>




 <asp:TemplateField HeaderText="To Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrToAddressT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strToAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="NightStay" SortExpression="strNight">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdNightstay" runat="server"  Value='<%# Bind("strNightStayT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrNightStayT" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("strNightStayT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="startMilage" SortExpression="decstarmil">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="EndMilage" SortExpression="decEndmil">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="Consumedkm" SortExpression="consumedkm">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdConsumedkm" runat="server" Value='<%# Bind("decConsumedKmT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecConsumedKmT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decConsumedKmT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="Supporting" SortExpression="strsuppor">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdstrsuppor" runat="server" Value='<%# Bind("strSupportingNoT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrSupportingNoT"  CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strSupportingNoT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="QntPetrol" SortExpression="decpet">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntPetrolT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="CostPetrol" SortExpression="costpet">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostPetrolT"  OnTextChanged="txtdecCostPetrolT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntOcten" SortExpression="decQntOcten">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntOctenT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="CostOcten" SortExpression="decCostOcten">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostOctenT" OnTextChanged="txtdecCostOctenT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="QntCNG" SortExpression="decQntCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntCarbonNitGasT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CostCNG." SortExpression="CostCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostCarbonNitGasT" OnTextChanged="txtdecCostCarbonNitGasT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntLubricant" SortExpression="decQntLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntLubricant"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CostLubricant." SortExpression="decCostLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostLubricant" OnTextChanged="txtdecCostLubricant_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("lubricantcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                   <asp:TemplateField HeaderText="Bus" SortExpression="decBus">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBusAmountT" OnTextChanged="txtdecFareBusAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareBusAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="Rick" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareRickshawAmountT" OnTextChanged="txtdecFareRickshawAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareRickshawAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="TaxiCab" SortExpression="decTaxiCab">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareCNGAmountT" OnTextChanged="txtdecFareCNGAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareCNGAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Train" SortExpression="decTrain">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("decFareTrainAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareTrainAmountT"  OnTextChanged="txtdecFareTrainAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareTrainAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="AirPlane" SortExpression="decAirPlane">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPlane" runat="server" Value='<%# Bind("decFareAirPlaneT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareAirPlaneT" OnTextChanged="txtdecFareAirPlaneT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareAirPlaneT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OtherVhc." SortExpression="decOtherVhc">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareOtherVheicleAmountT" OnTextChanged="txtdecFareOtherVheicleAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFareOtherVheicleAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                  
           
            <asp:TemplateField HeaderText="Mnt.Cost" SortExpression="decMnt">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostAmountMaintenaceT" OnTextChanged="txtdecCostAmountMaintenaceT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCostAmountMaintenaceT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="FerryToll." SortExpression="ferytol">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFeryTollCostT" OnTextChanged="txtdecFeryTollCostT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decFeryTollCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
              
                         
                         
                                   

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDAAmountT" OnTextChanged="txtdecDAAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDAAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Driver DA." SortExpression="decDriver">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverDACostT" OnTextChanged="txtdecDriverDACostT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDriverDACostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Own Hotel" SortExpression="decownhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecHotelBillAmountT" OnTextChanged="txtdecHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Driver Hotel" SortExpression="decdrivhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverHotelBillAmountT" OnTextChanged="txtdecDriverHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decDriverHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Photocopy" SortExpression="decPhotocopy">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPhotoCopyCostT" OnTextChanged="txtdecPhotoCopyCostT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPhotoCopyCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Courier" SortExpression="decCourier">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCourierCostT" OnTextChanged="txtdecCourierCostT_TextChanged"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decCourierCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherBillAmountT" OnTextChanged="txtdecOtherBillAmountT_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decOtherBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                       <asp:TemplateField HeaderText="Row Total" SortExpression="decrowtotal">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecrowtotal" runat="server" Value='<%# Bind("decRowTotalT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecRowTotalT" OnTextChanged="txtdecRowTotalT_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decRowTotalT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                        <asp:TemplateField HeaderText="Supplier CNG" SortExpression="decSupplierCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierCNG" runat="server" Value='<%# Bind("decSupplierCNG", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierCNG" OnTextChanged="txtdecSupplierCNG_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decSupplierCNG") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                   <asp:TemplateField HeaderText="Supplier Gas" SortExpression="decSupplierGas">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecSupplierGas" runat="server" Value='<%# Bind("decSupplierGas", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecSupplierGas" OnTextChanged="txtdecSupplierGas_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decSupplierGas") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                   <asp:TemplateField HeaderText="Personal Milage" SortExpression="decPersonalMilage">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalMilage" runat="server" Value='<%# Bind("decPersonalMilage", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalMilage" OnTextChanged="txtdecPersonalMilage_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPersonalMilage") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                         

                  <asp:TemplateField HeaderText="Milage Rate" SortExpression="decMlgRate">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecMlgRate" runat="server" Value='<%# Bind("decMlgRate", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecMlgRate" OnTextChanged="txtdecMlgRate_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decMlgRate") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                         
                    


                         <asp:TemplateField HeaderText="P Mlag Total" SortExpression="decPersonalTotalcost">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalTotalcost" runat="server" Value='<%# Bind("decPersonalTotalcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalTotalcost" OnTextChanged="txtdecPersonalTotalcost_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPersonalTotalcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="PaymentType" SortExpression="PaymentType">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnPaymentType" runat="server" Value='<%# Bind("PaymentType", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtPaymentType" OnTextChanged="txtPaymentType_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="SingleLine" Text='<%# Bind("PaymentType") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                     
                          <asp:TemplateField HeaderText="Fuel Station" SortExpression="strFuelStationaname">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnstrFuelStationaname" runat="server" Value='<%# Bind("strFuelStationaname", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFuelStationaname" OnTextChanged="txtstrFuelStationaname_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strFuelStationaname") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>



                     </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                     <RowStyle BackColor="White" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>
             </td>
             
         </tr>  

       



        </table>

<%-- <caption >
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  Grand Total: 
                         <asp:Label ID="lblGrandTotal" runat="server" Text="0" Font-Bold="true"></asp:Label>
                     </caption>--%>

    </div>

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>