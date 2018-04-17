<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TA DA Bike Car User Gb.aspx.cs" Inherits="UI.SAD.Order.TA_DA_Bike_Car_User_Gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>
   
    <script>
        // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }
</script>

  <script>
      function sub() {
          var end = document.getElementById('txtEndTime').value;
          var start = document.getElementById('txtStarTime').value;
          var dur = document.getElementById('txtMovDuration').value;
          var subtract = parseFloat(end) + (-parseFloat(start));
          document.getElementById('txtMovDuration').value = subtract;
      }

      function personalMilagCal() {


          var pusedmilage = document.getElementById('txtPersMilage').value;
          var ppermilageRate = document.getElementById('txtPersMilage').value;
          var ppermilageRate = 5.50;
          var ptotalPmilageCost = document.getElementById('txtPmilagTotalRate').value;
          var totalpersonalcost = parseFloat(pusedmilage) * (parseFloat(ppermilageRate));

          if (pusedmilage == "")
              pusedmilage = 0;
          if (ppermilageRate == "")
              ppermilageRate = 0;

          if (ptotalPmilageCost == "")
              ptotalPmilageCost = 0;


          document.getElementById('txtPmilagTotalRate').value = totalpersonalcost;



      }

      function Confirm() {
          document.getElementById("hdnconfirm").value = "0";
          var today = new Date();
          var dd = today.getDate();
          var mm = today.getMonth() + 1; //January is 0!

          var yyyy = today.getFullYear();
          if (dd < 10) {
              dd = '0' + dd
          }
          if (mm < 10) {
              mm = '0' + mm
          }
          
          var today = yyyy + '-' + mm + '-' + dd;
          document.getElementById("DATE").value = today;

          var txtDteFrom = document.forms["frmpdv"]["txtFromDate"].value;
          var txtDteTo = document.getElementById("DATE").value;
         
           if (txtDteFrom == null || txtDteFrom == "") {
              alert("From date must be filled by valid formate (yyyy-MM-dd).");
              document.getElementById("txtDteFrom").focus();
          }
          
          else if (txtDteFrom > txtDteTo) {
              alert("Bill date can not greater then Current day");
              document.getElementById("txtFromDate").focus();
          }
        
          else {
              var confirm_value = document.createElement("INPUT");
              confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
              if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
              else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
          }
      }
    </script>

 <script>
     function CalculateMilage() {

         var value1 = document.getElementById('txtStartMilage').value;
         var value2 = document.getElementById('txtEndMilage').value;
         var value3 = document.getElementById('txtConsumed').value;
         var value2 = parseFloat(value1) + (parseFloat(value3));
         document.getElementById('txtEndMilage').value = value2;
     }

    </script>




    <script>
        function sum() {


            var txtPetrolCost = document.getElementById('txtPetrolCost').value;
            var txtOctenCost = document.getElementById('txtOctenCost').value;
            var txtCNGCost = document.getElementById('txtCNGCost').value;
            var txtMobilCost = document.getElementById('txtMobilCost').value;
            var txtBusFair = document.getElementById('txtBusFair').value;
            var txtRickshaw = document.getElementById('txtRickshaw').value;
            var txtCNG = document.getElementById('txtCNG').value;
            var txtTrain = document.getElementById('txtTrain').value;
            var txtAirPlane = document.getElementById('txtAirPlane').value;
            var txtOtherVh = document.getElementById('txtOtherVh').value;
            var txtMntVh = document.getElementById('txtMntVh').value;
            var txtFerryToll = document.getElementById('txtFerryToll').value;
            var txtOwnDA = document.getElementById('txtOwnDA').value;
            var txtDriverDA = document.getElementById('txtDriverDA').value;
            var txtOwnHotel = document.getElementById('txtOwnHotel').value;
            var txtDriverHotel = document.getElementById('txtDriverHotel').value;
            //var txtPhotocopy = document.getElementById('txtPhotocopy').value;
            var txtCourier = document.getElementById('txtCourier').value;
            var txtOtherCost = document.getElementById('txtOtherCost').value;

            var txtTotal = document.getElementById('txtTotal').value;




            if (txtPetrolCost == "")
                txtPetrolCost = 0;
            if (txtOctenCost == "")
                txtOctenCost = 0;

            if (txtCNGCost == "")
                txtCNGCost = 0;

            if (txtMobilCost == "")
                txtMobilCost = 0;


            if (txtBusFair == "")
                txtBusFair = 0;
            if (txtRickshaw == "")
                txtRickshaw = 0;
            if (txtCNG == "")
                txtCNG = 0;

            if (txtTrain == "")
                txtTrain = 0;
            if (txtAirPlane == "")
                txtAirPlane = 0;
            if (txtOtherVh == "")
                txtOtherVh = 0;

            if (txtMntVh == "")
                txtMntVh = 0;



            if (txtFerryToll == "")
                txtFerryToll = 0;
            if (txtOwnDA == "")
                txtOwnDA = 0;

            if (txtDriverDA == "")
                txtDriverDA = 0;


            if (txtOwnHotel == "")
                txtOwnHotel = 0;
            if (txtDriverHotel == "")
                txtDriverHotel = 0;


            if (txtCourier == "")
                txtCourier = 0;
            if (txtOtherCost == "")
                txtOtherCost = 0;
            var result = parseFloat(txtPetrolCost) + parseFloat(txtOctenCost) + parseFloat(txtCNGCost) + parseFloat(txtMobilCost)
                         + parseFloat(txtBusFair) + parseFloat(txtRickshaw) + parseFloat(txtCNG) + parseFloat(txtTrain)
                         + parseFloat(txtAirPlane) + parseFloat(txtOtherVh) + parseFloat(txtMntVh) + parseFloat(txtFerryToll)
                         + parseFloat(txtOwnDA) + parseFloat(txtDriverDA) + parseFloat(txtOwnHotel) + parseFloat(txtDriverHotel)
                          + parseFloat(txtCourier) + parseFloat(txtOtherCost)

            if (!isNaN(result)) {
                document.getElementById('txtTotal').value = result;
            }
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
    <div class="tabs_container"> TA - DA info input Form (For Bike and Car User). Plz submit the bill day to day basis. One month bill can not submit after the 5th day of next month   :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
                        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color:red">*</span></td>
                        <td><asp:TextBox ID="txtFromDate" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                        <td style="text-align:right"><asp:Label ID="lblStartTime" CssClass="lbl" runat="server" Text="StartTime"></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtStarTime" runat="server" onkeyup="sub();" Width="200px" onkeypress="javascript:return isNumber (event)"   CssClass="txtBox"></asp:TextBox></td>            

                        <td style="text-align:right"><asp:Label ID="lblEndTime" CssClass="lbl" runat="server" Text="EndTime"  ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtEndTime" runat="server" onkeyup="sub();" Width="200px" onkeypress="javascript:return isNumber (event)" CssClass="txtBox"></asp:TextBox></td>            
                        

                        <td style="text-align:right"><asp:Label ID="lblTotalMovementDuraion"  CssClass="lbl" runat="server" Text="Movement.D (Hour) "  ></asp:Label></td>
                        <td> <asp:TextBox ID="txtMovDuration"  AutoPostBack="false" onkeyup="sub();"  runat="server"  Width="200px" TextMode="Number" Enabled="false"  CssClass="txtBox"></asp:TextBox></td>      
                
        </tr>
         <tr class="tblrowOdd">
                        <td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="From Adr" ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtFromAddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right"><asp:Label ID="lblMovementArea" CssClass="lbl" runat="server" Text="Movement:" ></asp:Label><span style="color:red">*</span></td>   
                        <td> <asp:TextBox ID="txtMovementArea" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right"><asp:Label ID="lblToAddress" CssClass="lbl" runat="server" Text="To Addr:" ></asp:Label><span style="color:red">*</span></td>   
                        <td> <asp:TextBox ID="txtToaddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right"><asp:Label ID="lblNighStay" CssClass="lbl" runat="server" Text="Night Stay:  " ></asp:Label></td>   
                        <td> <asp:TextBox ID="txtNightStay" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
        
             
         </tr>

        <tr class="tblroweven">
                        <td style="text-align:right"><asp:Label ID="lblStartMilage" CssClass="lbl" runat="server" Text="Start Milage:  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtStartMilage" onkeyup="CalculateMilage();"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      
                         
                         <td style="text-align:right"><asp:Label ID="lblConsumed" CssClass="lbl" runat="server" Text="Consm.(Milage):  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtConsumed" onkeyup="CalculateMilage();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblEndMilage" CssClass="lbl" runat="server" Text="End Milage:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtEndMilage" onkeyup="CalculateMilage();"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number" Enabled="false" CssClass="txtBox"></asp:TextBox></td>      


                       <td><asp:Label ID="lblpaytype" runat="server" CssClass="lbl"  Text="Payment: "></asp:Label><span style="color:red">*</span></td>
                    <td><asp:RadioButtonList ID="rdbFuelStationList" runat="server" OnSelectedIndexChanged="rdbFuelStationList_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Cash" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Credit" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Both pay" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>  
                       

            </tr>
                

            <tr class="tblrowOdd" style="background-color:lightcyan">
                    
                    <td><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server" Text="CNG Credit1: "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drdlSupplierName" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="odsFuelstation" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>
                        <td style="text-align:right"><asp:Label ID="lblCNGSupplierbill" CssClass="lbl" runat="server" Text="CNG Credit1" ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtSupplierCNGCredit1" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblSupplierOilBill" CssClass="lbl" runat="server" Text="CNG Credit2:  " ></asp:Label></td>
                        <td>
                        <asp:DropDownList ID="drdlCNGStationNameCredit2" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>
                <td style="text-align:right"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="CNG Credit2" ></asp:Label><span style="color:red">*</span></td>
                <td> <asp:TextBox ID="txtSupplierCNGCredit2"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      
                </tr>





                <tr class="tblrowOdd" style="background-color:lightyellow">
                    <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Oil Credit Station :  " ></asp:Label></td>
                        <td>
                        <asp:DropDownList ID="drdlOilCreditStationName1" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>
                <td style="text-align:right"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Oil Credit" ></asp:Label><span style="color:red">*</span></td>
                <td> <asp:TextBox ID="txtOilCredit"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      




                     <td style="text-align:right"><asp:Label ID="lblPersonalUseMilage" CssClass="lbl" runat="server" Text="Personal(Milage):  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtPersMilage" onkeyup="personalMilagCal();" placeholder="Only Numeric Digit" runat="server" Width="200px" AutoPostBack="false"  CssClass="txtBox"></asp:TextBox></td>      

                 
                    <td style="text-align:right"><asp:Label ID="lblPMilTotal" CssClass="lbl" runat="server" Text="Total Price(P.Milage):  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtPmilagTotalRate" onkeyup="personalMilagCal();" placeholder="Only Numeric Digit" runat="server" Width="200px" AutoPostBack="false"  CssClass="txtBox"></asp:TextBox></td>    
                      
                </tr>
                <tr class="tblrowOdd">
                        <td style="text-align:right"><asp:Label ID="lblPetrolQnt" CssClass="lbl" runat="server" Text="PetrolQnt:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtPetrolQnt" placeholder="Only Numeric Digit" runat="server" Width="200px" AutoPostBack="false"  CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblPetrolCost"  CssClass="lbl" runat="server" Text="PetrolCost:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtPetrolCost" placeholder="Only Numeric Digit"  onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px"  CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblOctenQnt" CssClass="lbl" runat="server" Text="OctenQnt:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtOcten" placeholder="Only Numeric Digit"  runat="server" Width="200px"  CssClass="txtBox"  onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblOctenCost" CssClass="lbl" runat="server" Text="OctenCost:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtOctenCost" placeholder="Only Numeric Digit" onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px"  CssClass="txtBox"></asp:TextBox></td>      

                 </tr>

             <tr class="tblroweven">

                        <td style="text-align:right"><asp:Label ID="lblCarbonNitrogas" CssClass="lbl" runat="server" Text="CNG Qnt:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtCNGQnt" placeholder="Only Numeric Digit" runat="server" Width="200px"  CssClass="txtBox" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblCNGCost" CssClass="lbl" runat="server" Text="CNG  Cost:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtCNGCost" placeholder="Only Numeric Digit" onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblMobilQnt" CssClass="lbl" runat="server" Text="Lubricant Qnt:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtMobilQnt" placeholder="Only Numeric Digit" runat="server" Width="200px"  CssClass="txtBox" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblMobilCost" CssClass="lbl" runat="server" Text="Lubricant Cost:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtMobilCost" placeholder="Only Numeric Digit" onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      

             </tr>
             </div>  
         
             <div class="leaveApplication_container">
                 <tr class="tblrowOdd">
                 
                 <td style="text-align:right"> <asp:Label ID="lblBusFair" runat="server" CssClass="lbl" Text="Bus:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtBusFair" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox> </td>
                 <td style="text-align:right"> <asp:Label ID="lblRickshaw" runat="server" CssClass="lbl" Text="Rickshaw:  "></asp:Label> </td>
                 <td> <asp:TextBox ID="txtRickshaw" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblCNG" runat="server" CssClass="lbl" Text="Taxi-Cab:  "></asp:Label> </td>
                 <td> <asp:TextBox ID="txtCNG" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox" TextMode="Number" Width="200px"></asp:TextBox> </td>
                 <td style="text-align:right"> <asp:Label ID="lblTrain" runat="server" CssClass="lbl" Text="Train:  "></asp:Label> </td>
                 <td> <asp:TextBox ID="txtTrain" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox> </td>
                  </tr>
             <tr class="tblroweven">
                  <td style="text-align:right"> <asp:Label ID="lblAirPlane" runat="server" CssClass="lbl" Text="AirPlane Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtAirPlane" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px" ></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblAnOtherVh" runat="server" CssClass="lbl" Text="Other Vhc. :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtOtherVh" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblMaitenanceVh" runat="server" CssClass="lbl" Text="Mnt. Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtMntVh" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblFerryToll" runat="server" CssClass="lbl" Text="Ferry/Toll Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtFerryToll" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                


             </tr>
             <tr class="tblrowOdd">
                 <td style="text-align:right"><asp:Label ID="lblOwnDA" runat="server" CssClass="lbl" Text="Own D.A:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOwnDA" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblOtherDA" runat="server" CssClass="lbl" Text="Driver D.A:  "></asp:Label> </td>
                 <td> <asp:TextBox ID="txtDriverDA" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox" TextMode="Number" Width="200px"></asp:TextBox> </td>
                 <td style="text-align:right"><asp:Label ID="lblHotel" runat="server" CssClass="lbl" Text="Own Hotel :  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOwnHotel" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox> </td>
                 <td style="text-align:right"><asp:Label ID="lblDriverHotel" runat="server" CssClass="lbl" Text="Driver Hotel :  "></asp:Label></td>
                 <td><asp:TextBox ID="txtDriverHotel" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox> </td>
            
              </tr>
             
                <tr class="tblroweven">
                <td style="text-align:right"><asp:Label ID="lblSupporting" CssClass="lbl" runat="server" Text="Supporting:  " ></asp:Label></td>
                <td> <asp:TextBox ID="txtSupporting" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>      
               
                 <td style="text-align:right"> <asp:Label ID="lblCourier" runat="server" CssClass="lbl" Text="Courier Cost :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtCourier" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>

                 <td style="text-align:right"><asp:Label ID="lblOtherCost" runat="server" CssClass="lbl" Text="OtherCost:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOtherCost" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px"></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblTotal" runat="server" CssClass="lbl" Text="Total Cost :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtTotal" runat="server" onkeyup="sum();"  AutoPostBack="false" CssClass="txtBox" TextMode="Number" Enabled="false"  Width="200px"></asp:TextBox></td>
             </tr>
             
             <tr class="tblrowOdd">
                 <td>
                     <asp:Button ID="btnAddBikeCarUser" runat="server" OnClick="btnAddBikeCarUser_Click"  Text="Add" BackColor="#ffffcc" OnClientClick = "Confirm()" />
                 </td>
                 <td>
                     <asp:Button ID="btnSubmitBikeCar" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmitBikeCar_Click" OnClientClick = "Confirm()" />
                 </td>
             </tr>
             </table>


        


    </div>   

        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    
                    


                    <asp:GridView ID="GridviewBikeCarUserInputInfo" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="GridviewBikeCarUserInputInfo_SelectedIndexChanged" OnRowDeleting="GridviewBikeCarUserInputInfo_RowDeleting"  >
                        <Columns>
                             <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="starttime" HeaderText="Start" SortExpression="starttime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="endtime" HeaderText="End" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="MovDuration" HeaderText="Dur."  SortExpression="decDur" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="fromAddress" HeaderText="From Addr." SortExpression="strForm" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="movementAddress" HeaderText="Moved Area" SortExpression="strMove" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="toAddress" HeaderText="To Address" SortExpression="strToadr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            
                            <asp:BoundField DataField="nightstay" HeaderText="Night" SortExpression="nightstay" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="startmilage" HeaderText="Str Milg" SortExpression="startmilage" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="endmilage" HeaderText="End Milg" SortExpression="endmilage" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="consumed" HeaderText="Consumed" SortExpression="consumed" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="remarks" HeaderText="Supporting" SortExpression="remarks" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="petrolqnt" HeaderText="Pet Qnt" SortExpression="petrolqnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="petrolcost" HeaderText="Pet Cost" SortExpression="petrolcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="octenqnt" HeaderText="Oct Qnt." SortExpression="octenqnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="octencost" HeaderText="Oct Cost" SortExpression="octencost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="cngqnt" HeaderText="Cng Qnt" SortExpression="cngqnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="cngcost" HeaderText="CNG Cost" SortExpression="cngcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="lubricantqnt" HeaderText="Lubr Qnt" SortExpression="lubricantqnt" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="lubricantcost" HeaderText="Lubr Cost" SortExpression="lubricantcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            <asp:BoundField DataField="busfair" HeaderText="Bus" SortExpression="decBus" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           <asp:BoundField DataField="Rickfai" HeaderText="Rick." SortExpression="decRick" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           <asp:BoundField DataField="cngfair" HeaderText="CNG" SortExpression="decCNG" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           <asp:BoundField DataField="trainfair" HeaderText="Train" SortExpression="decTRAIN" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="Airplance" HeaderText="Plane" SortExpression="Airplance" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="othervhfair" HeaderText="OthVhc" SortExpression="decOther" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                             <asp:BoundField DataField="mntCost" HeaderText="Mnt Cost" SortExpression="mntCost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="ferrytoll" HeaderText="Ferry" SortExpression="ferrytoll" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                             <asp:BoundField DataField="ownda" HeaderText="Own DA" SortExpression="decOwnDa" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                             <asp:BoundField DataField="driverda" HeaderText="Driver DA" SortExpression="driverda" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100"/>
                             <asp:BoundField DataField="ownhotelfair" HeaderText="Own Hotel" SortExpression="ownhotelfair" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                            <asp:BoundField DataField="driverhotel" HeaderText="Driver Hotel" SortExpression="driverhotel" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             
                             <asp:BoundField DataField="photocoly" HeaderText="Photo Copy" SortExpression="photocoly" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                            <asp:BoundField DataField="courier" HeaderText="Courier" SortExpression="courier" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            <asp:BoundField DataField="OtherCost" HeaderText="OthCost" SortExpression="OtherCost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="totalcost" HeaderText="Total(Own)" SortExpression="decTotal" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                          

                             <asp:BoundField DataField="FuelpaymentTypeid" HeaderText="Station Pay" SortExpression="FuelpaymentTypeid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="Cngcredit1FuelSupplierstationid" HeaderText="stid" SortExpression="Cngcredit1FuelSupplierstationid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="CNGCredit1AmountcngFuelStationbill" HeaderText="Cred CNG" SortExpression="CNGCredit1AmountcngFuelStationbill" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="Cngcredit1FuelSupplierstationName" HeaderText="CNGSupplier" SortExpression="Cngcredit1FuelSupplierstationName" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="Cngcredit2FuelSupplierstationid" HeaderText="stid2" SortExpression="Cngcredit2FuelSupplierstationid" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="CNGCredit2AmountcngFuelStationbill" HeaderText="Cred CNG" SortExpression="CNGCredit2AmountcngFuelStationbill" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="Cngcredit2FuelSupplierstationName" HeaderText="CNGSupplier" SortExpression="Cngcredit2FuelSupplierstationName" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                          
                            
                             <asp:BoundField DataField="OilCredit1Supplierstationid" HeaderText="oil creditid" SortExpression="OilCredit1Supplierstationid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="oilCredit1Stationbill" HeaderText="oilCost" SortExpression="oilCredit1Stationbill" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="oilCredit1StationName" HeaderText="oilStationName" SortExpression="oilCredit1StationName" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>



                            <asp:BoundField DataField="personalusedMilageQnt" HeaderText="Pers MQnt" SortExpression="personalusedMilageQnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="personalUsedMilRate" HeaderText="Pers MRate" SortExpression="personalUsedMilRate" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="personalusemilageTotcost" HeaderText="Pers MCost" SortExpression="personalusemilageTotcost" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                             
                            <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("startmilage") %>' /></ItemTemplate></asp:TemplateField> 
                           

                            <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True"  />
                        



                        </Columns>




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