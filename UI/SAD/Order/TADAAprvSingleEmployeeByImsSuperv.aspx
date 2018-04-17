<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADAAprvSingleEmployeeByImsSuperv.aspx.cs" Inherits="UI.SAD.Order.TADAAprvSingleEmployeeByImsSuperv" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <script src="../../../../Content/JS/datepickr.min.js"></script>

    <script>
        function Registration(url) {
            window.open('AttachmentCheckingBySupervisor.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
            return false;
        }
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
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
          <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Employee base Detaills :<asp:HiddenField ID="hdnSeprationID" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" /></td></tr>
            <tr class="tblroweven">
                <td><asp:Label ID="lblName" runat="server" Text="Name"></asp:Label></td>
                <td ><asp:TextBox ID="txtName" BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="dsg" runat="server" Text="Designation"></asp:Label></td>
                <td><asp:TextBox ID="textDesg" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblDepartment" runat="server" Text="Dept."></asp:Label></td>
                <td><asp:TextBox ID="txtDept" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lbLastMonthAudit" runat="server" Text="LM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtLMbILL" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblCMBill" runat="server" Text="CM Bill"></asp:Label></td>
                <td><asp:TextBox ID="txtcmbill" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblIdealMilage" runat="server" Text="Ideal Milage"></asp:Label></td>
                <td><asp:TextBox ID="txtIdealMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblConsMilage" runat="server" Text="Cons Milge"></asp:Label></td>
                <td><asp:TextBox ID="txtConsMilage" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblQnt" runat="server" Text="Qnt"></asp:Label></td>
                <td><asp:TextBox ID="txtQnt" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
             </tr>
             <tr class="tblrowodd">
                
                
                <td><asp:Label ID="lblRatio" runat="server" Text="Cons Ratio"></asp:Label></td>
                <td><asp:TextBox ID="txtRation" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblPresentDay" runat="server" Text="Present"></asp:Label></td>
                <td><asp:TextBox ID="txtPresent" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblBillday" runat="server" Text="Bill day"></asp:Label></td>
                <td><asp:TextBox ID="txtBillday" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblEnrol" runat="server" Text="Enrol"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrol" BackColor="#ffffcc" ReadOnly="true"  runat="server"></asp:TextBox></td>
               
                  <td><asp:Label ID="lblJobstation" runat="server" Text="Jobstationid"></asp:Label></td>
                 <td><asp:TextBox ID="txtJobstation" BackColor="#ffffcc" ReadOnly="true"  runat="server"></asp:TextBox></td>

                  <td><asp:Label ID="lblUnit" runat="server" Text="Unitid"></asp:Label></td>
                <td><asp:TextBox ID="txtUnitID" BackColor="#ffffcc"  ReadOnly="true" runat="server"></asp:TextBox></td>

                <td><asp:Button ID="btnSubmitSingleEmployee" runat="server" Text="Approve" BackColor="#ffcc99" OnClientClick = "Confirm()" OnClick="btnSubmitSingleEmployee_Click" /></td>
            </tr>
                
            
            
            </div>
        
        
        
        
        
        
          <div class="leaveApplication_container"> 
                 <table>
              
          <tr class="tblroweven"><td colspan="4">
              </td>
         </tr>          
        
            <tr class="tblrowOdd" >
             <td colspan="4">
                 <asp:GridView ID="grdvForApproveTADAByImmdediatesupervisor" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="3000" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HeaderStyle-Wrap="true">
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


 <asp:TemplateField HeaderText="Start Time" SortExpression="decstartt">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdstarttime" runat="server"  Value='<%# Bind("decStartTimeT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtStarTime" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decStartTimeT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="End Time" SortExpression="decdecEndHourT">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndHour" runat="server"  Value='<%# Bind("decEndHourT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndHourT" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decEndHourT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="Duration" SortExpression="decMov">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovedur" runat="server"  Value='<%# Bind("decMovementDurationT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecmovdur" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decMovementDurationT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

 <asp:TemplateField HeaderText="From  Address" SortExpression="strFromAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdfromadr" runat="server"  Value='<%# Bind("strFromAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFromAddressT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strFromAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Movem spots" SortExpression="strmovmentspot">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdMovementspots" runat="server"  Value='<%# Bind("strMovementAreaT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrMovementAreaT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strMovementAreaT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>




 <asp:TemplateField HeaderText="To      Address" SortExpression="strToAdr">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdToAdr" runat="server"  Value='<%# Bind("strToAddressT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrToAddressT" CssClass="txtBox" runat="server" Width="100px" TextMode="SingleLine" Text='<%# Bind("strToAddressT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                     </asp:TemplateField>

<asp:TemplateField HeaderText="Night    Stay" SortExpression="strNight">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdNightstay" runat="server"  Value='<%# Bind("strNightStayT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrNightStayT" CssClass="txtBox" runat="server" Width="50px" TextMode="SingleLine" Text='<%# Bind("strNightStayT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


 <asp:TemplateField HeaderText="start  Milage" SortExpression="decstarmil">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdstartmilage"  runat="server" Value='<%# Bind("decStartMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecStartMilageT"  CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decStartMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="End  Milage" SortExpression="decEndmil">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdEndmilage" runat="server" Value='<%# Bind("decEndMilageT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecEndMilageT"   CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decEndMilageT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="Consumed  km" SortExpression="consumedkm">
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


 <asp:TemplateField HeaderText="QntPet" SortExpression="decpet">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdQpetr"  runat="server" Value='<%# Bind("decQntPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntPetrolT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="CostPet" SortExpression="costpet">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnCostpetr" runat="server" Value='<%# Bind("decCostPetrolT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostPetrolT"  OnTextChanged="txtdecCostPetrolT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostPetrolT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntOct" SortExpression="decQntOcten">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdQntOcten" runat="server" Value='<%# Bind("decQntOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntOctenT"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="CosOct" SortExpression="decCostOcten">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdCostocte" runat="server" Value='<%# Bind("decCostOctenT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostOctenT" OnTextChanged="txtdecCostOctenT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostOctenT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

   
                      <asp:TemplateField HeaderText="QntCNG" SortExpression="decQntCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQCNG" runat="server" Value='<%# Bind("decQntCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntCarbonNitGasT"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decQntCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CosCNG." SortExpression="CostCNG">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostcng" runat="server" Value='<%# Bind("decCostCarbonNitGasT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostCarbonNitGasT" OnTextChanged="txtdecCostCarbonNitGasT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostCarbonNitGasT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="QntLub" SortExpression="decQntLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdQlubricantt" runat="server" Value='<%# Bind("decLubricantQnt", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecQntLubricant"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decLubricantQnt") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="CosLub" SortExpression="decCostLubricant">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdCostLubricant" runat="server" Value='<%# Bind("lubricantcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostLubricant" OnTextChanged="txtdecCostLubricant_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("lubricantcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
                   <asp:TemplateField HeaderText="BusFar" SortExpression="decBus">
                    <ItemTemplate>

                     <asp:HiddenField  ID="hdBus"  runat="server" Value='<%# Bind("decFareBusAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBusAmountT" OnTextChanged="txtdecFareBusAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareBusAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
                      
                          <asp:TemplateField HeaderText="RickFa" SortExpression="decRick">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdnRick" runat="server" Value='<%# Bind("decFareRickshawAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareRickshawAmountT" OnTextChanged="txtdecFareRickshawAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareRickshawAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="TaxiCab" SortExpression="decTaxiCab">
                    <ItemTemplate>
                     <asp:HiddenField  ID="hdtaxicab" runat="server" Value='<%# Bind("decFareCNGAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareCNGAmountT" OnTextChanged="txtdecFareCNGAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareCNGAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="TrainF" SortExpression="decTrain">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdTrain" runat="server" Value='<%# Bind("decFareTrainAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareTrainAmountT"  OnTextChanged="txtdecFareTrainAmountT_TextChanged"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareTrainAmountT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="BoatF" SortExpression="decFareBoatT">
                     <ItemTemplate>
                     <asp:HiddenField  ID="hdBoat" runat="server" Value='<%# Bind("decFareBoatT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareBoatT"  OnTextChanged="txtdecFareBoatT_TextChanged"   CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareBoatT") %>' AutoPostBack="true"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>




                      <asp:TemplateField HeaderText="AirPla" SortExpression="decAirPlane">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPlane" runat="server" Value='<%# Bind("decFareAirPlaneT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareAirPlaneT" OnTextChanged="txtdecFareAirPlaneT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareAirPlaneT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="OthVh." SortExpression="decOtherVhc">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdothevh" runat="server" Value='<%# Bind("decFareOtherVheicleAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFareOtherVheicleAmountT" OnTextChanged="txtdecFareOtherVheicleAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFareOtherVheicleAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                  
           
            <asp:TemplateField HeaderText="MntCos" SortExpression="decMnt">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdMntcost" runat="server" Value='<%# Bind("decCostAmountMaintenaceT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCostAmountMaintenaceT" OnTextChanged="txtdecCostAmountMaintenaceT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCostAmountMaintenaceT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                        <asp:TemplateField HeaderText="FerryToll." SortExpression="ferytol">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdoFerrytoll" runat="server" Value='<%# Bind("decFeryTollCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecFeryTollCostT" OnTextChanged="txtdecFeryTollCostT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decFeryTollCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
              
                         
                         
                                   

                      <asp:TemplateField HeaderText="OwnDA." SortExpression="decownda">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecownda" runat="server" Value='<%# Bind("decDAAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDAAmountT" OnTextChanged="txtdecDAAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDAAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


                       <asp:TemplateField HeaderText="Driver DA." SortExpression="decDriver">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherda" runat="server" Value='<%# Bind("decDriverDACostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverDACostT" OnTextChanged="txtdecDriverDACostT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDriverDACostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                       <asp:TemplateField HeaderText="Own Hotel" SortExpression="decownhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddechotel" runat="server" Value='<%# Bind("decHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecHotelBillAmountT" OnTextChanged="txtdecHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Driver Hotel" SortExpression="decdrivhotel">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddrivehote" runat="server" Value='<%# Bind("decDriverHotelBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecDriverHotelBillAmountT" OnTextChanged="txtdecDriverHotelBillAmountT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decDriverHotelBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                   
                    <asp:TemplateField HeaderText="Photocopy" SortExpression="decPhotocopy">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdPhotocpy" runat="server" Value='<%# Bind("decPhotoCopyCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPhotoCopyCostT" OnTextChanged="txtdecPhotoCopyCostT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decPhotoCopyCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>

                         <asp:TemplateField HeaderText="Courier" SortExpression="decCourier">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddCourier" runat="server" Value='<%# Bind("decCourierCostT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecCourierCostT" OnTextChanged="txtdecCourierCostT_TextChanged"  CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decCourierCostT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>


                     
                      <asp:TemplateField HeaderText="OtherCost" SortExpression="decOtherCostAmount">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hddecOtherCostAmount" runat="server" Value='<%# Bind("decOtherBillAmountT", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecOtherBillAmountT" OnTextChanged="txtdecOtherBillAmountT_TextChanged" CssClass="txtBox" runat="server" Width="50px" TextMode="Number" Text='<%# Bind("decOtherBillAmountT") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
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

                         
                    


                         <asp:TemplateField HeaderText="PMlag Total" SortExpression="decPersonalTotalcost">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdndecPersonalTotalcost" runat="server" Value='<%# Bind("decPersonalTotalcost", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtdecPersonalTotalcost" OnTextChanged="txtdecPersonalTotalcost_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="Number" Text='<%# Bind("decPersonalTotalcost") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="PayType" SortExpression="PaymentType">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnPaymentType" runat="server" Value='<%# Bind("PaymentType", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtPaymentType" OnTextChanged="txtPaymentType_TextChanged" CssClass="txtBox" runat="server" Width="50px" TextMode="SingleLine" Text='<%# Bind("PaymentType") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                     </asp:TemplateField>
                          <asp:TemplateField HeaderText="Det.">
             <ItemTemplate>
             <asp:Button ID="CompleteAttachment" runat="server" Text="Attachment" class="button" CommandName="complete" OnClick="CompleteAttachment_Click"  CommandArgument='<%# Eval("intApplicantEnrol")+","+Eval("dteFromdate")+","+Eval("intApplicantUnit")%>' /></ItemTemplate>
             </asp:TemplateField>  
                     
                          <asp:TemplateField HeaderText="Fuel Station" SortExpression="strFuelStationaname">

                              <ItemTemplate>
                     <asp:HiddenField  ID="hdnstrFuelStationaname" runat="server" Value='<%# Bind("strFuelStationaname", "{0:0.0}") %>'></asp:HiddenField>
                    <asp:TextBox ID="txtstrFuelStationaname" OnTextChanged="txtstrFuelStationaname_TextChanged" CssClass="txtBox" runat="server" Width="75px" TextMode="MultiLine" Text='<%# Bind("strFuelStationaname") %>' AutoPostBack="true" ></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                     </asp:TemplateField>
                         <asp:BoundField DataField="intApplicantEnrol" HeaderText="Enrol" SortExpression="intApplicantEnrol" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                <asp:BoundField DataField="intApplicantUnit" HeaderText="unit" SortExpression="intApplicantUnit" ItemStyle-HorizontalAlign="Center" >
                    <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>
                         
                 

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
            
            