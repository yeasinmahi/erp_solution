<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TA DA Station Vhc.aspx.cs" Inherits="UI.SAD.Order.TA_DA_Station_Vhc" %>

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

      

    </script>

 <script>
     function CalculateMilage() {
         //parseFloat(end) + (-parseFloat(start));
         var value1 = document.getElementById('txtStartMilage').value;
         var value2 = document.getElementById('txtEndMilage').value;
         //var value3 = document.getElementById('txtConsumed').value;
         var value3 = parseFloat(value2) +(-parseFloat(value1));
         document.getElementById('txtConsumed').value = value3;
     }

    </script>




    <script>
        function sum() {
            var txtoilcash = document.getElementById('txtoilcash').value;
            var txtCNGCash = document.getElementById('txtCNGCash').value;
            var txtMntVh = document.getElementById('txtMntVh').value;
            var txtOwnDA = document.getElementById('txtOwnDA').value;
            var txtOwnHotel = document.getElementById('txtOwnHotel').value;
            var txtOtherCost = document.getElementById('txtOtherCost').value;
            var txtOilCredit = document.getElementById('txtOilCredit').value;
            var txtCNGCredit = document.getElementById('txtCNGCredit').value;
            var txtTotal = document.getElementById('txtTotal').value;

            if (txtoilcash == "")
                txtoilcash = 0;
            if (txtCNGCash == "")
                txtCNGCash = 0;
           if (txtMntVh == "")
                txtMntVh = 0;
            if (txtOwnDA == "")
                txtOwnDA = 0;
            if (txtOwnHotel == "")
                txtOwnHotel = 0;
            if (txtOtherCost == "")
                txtOtherCost = 0;
            if (txtOilCredit == "")
                txtOilCredit = 0;
            if (txtCNGCredit == "")
                txtCNGCredit = 0;


            if (txtTotal == "")
                txtTotal = 0;

            //+ parseFloat(txtOilCredit) + parseFloat(txtCNGCredit)
            var result = parseFloat(txtoilcash) + parseFloat(txtCNGCash) + parseFloat(txtMntVh) + parseFloat(txtOwnDA)
                         + parseFloat(txtOwnHotel) + parseFloat(txtOtherCost) ;

            if (!isNaN(result)) {
                document.getElementById('txtTotal').value = result;
            }
        }
    </script>
     <script type="text/javascript">
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         //GetAutoCompleteDataForTADA
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "TA DA Station Vhc.aspx/GetstationvhclDriverList",
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

   

    <script type="text/javascript">
    $(document).ready(function () {    
    SearchTextVheicleList();
});
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchTextVheicleList() {
    $("#txtVheicleName").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "TA DA Station Vhc.aspx/Getstationvhcllist",
                data: "{'strSearchKey':'" + document.getElementById('txtVheicleName').value + "'}",
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


<%--=========================================Start My Code From Here===============================================--%>

     <div class="leaveApplication_container"> 
    <div class="tabs_container"> Stand vehicle Fuel Detaills  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
         <asp:HiddenField ID="hdfSerachBoxForVheicleName" runat="server"/><asp:HiddenField ID="HiddenField4" runat="server"/>

        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
        <asp:HiddenField ID="hdnJobstationid" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
                        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color:red">*</span></td>
                        <td><asp:TextBox ID="txtFromDate" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name" AutoCompleteType="Search"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True"></asp:TextBox>
                <span style="color:red">*</span>
                            


                 
            </td>
            <td style="text-align:right;"><asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Employee Code: "></asp:Label> </td>
            <td><asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
            
            <td style="text-align:right;"><asp:Label ID="lblVhcName" CssClass="lbl" runat="server" Text="Vehicle Name: "></asp:Label> </td>
            <%--<td>
                       <asp:TextBox ID="txtVheicleName" runat="server"  placeholder="Type  Name" AutoCompleteType="Search"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVheicleName"
                                     ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                 </td> --%>
           <td><asp:TextBox ID="txtVheicleName" runat="server" BackColor="#ffff99"  AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td> 
            
        </tr>
         <tr class="tblrowOdd">
                        <td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="From Address:  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtFromAddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right"><asp:Label ID="lblMovementArea" CssClass="lbl" runat="server" Text="Movement Area:  " ></asp:Label><span style="color:red">*</span></td>   
                        <td> <asp:TextBox ID="txtMovementArea" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        <td style="text-align:right"><asp:Label ID="lblToAddress" CssClass="lbl" runat="server" Text="To Address:  " ></asp:Label><span style="color:red">*</span></td>   
                        <td> <asp:TextBox ID="txtToaddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                        
             <td style="text-align:right"><asp:Label ID="lblSupporting" CssClass="lbl" runat="server" Text="Supporting:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtSupporting" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>     
         </tr>

        <tr class="tblroweven">
                        <td style="text-align:right"><asp:Label ID="lblStartMilage" CssClass="lbl" runat="server" Text="Start Milage:  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtStartMilage" onkeyup="CalculateMilage();"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox" onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>      
                         
                        <td style="text-align:right"><asp:Label ID="lblEndMilage" CssClass="lbl" runat="server" Text="End Milage:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtEndMilage" onkeyup="CalculateMilage();"  AutoPostBack="false" runat="server" Width="200px" TextMode="Number"  CssClass="txtBox"  onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>      

                         <td style="text-align:right"><asp:Label ID="lblConsumed" CssClass="lbl" runat="server" Text="Consm.(Milage):  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtConsumed" onkeyup="CalculateMilage();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox" Enabled="false" onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>      

                        
                        <td style="text-align:right"><asp:Label ID="lbloILlTR" CssClass="lbl" runat="server" Text="Oil Ltr:  " ></asp:Label></td>   
                        <td> <asp:TextBox ID="txtOilLtr" runat="server" Width="200px" TextMode="SingleLine" CssClass="txtBox"></asp:TextBox></td>
        
                       
                         

            </tr>
                <tr class="tblrowOdd" style="background-color:lightcyan">
                    <td><asp:Label ID="lblpaytype" runat="server" CssClass="lbl"  Text="Oil station Payment: "></asp:Label><span style="color:red">*</span></td>
                    <td><asp:RadioButtonList ID="rdbOilstationpay" CssClass="lbl" runat="server" OnSelectedIndexChanged="rdbOilstationpay_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem  Text="Cash Oil" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Credit Oil" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Both Type" Value="2"></asp:ListItem>
                   
                    </asp:RadioButtonList>
                    </td>  
                    <td><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server" Text="Oil station: "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="drdlSupplierName" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="odsFuelstation" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>
                        <td style="text-align:right"><asp:Label ID="lblCNGSupplierbill" CssClass="lbl" runat="server" Text="Supplier OIL Cash:  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtoilcash" onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="lblSupplierOilBill" CssClass="lbl" runat="server" Text="Supplier Oil Credit:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtOilCredit"   AutoPostBack="false"  runat="server" Width="200px" TextMode="Number" CssClass="txtBox"></asp:TextBox></td>      
                </tr>
          
                <tr class="tblrowOdd" style="background-color:lightsteelblue">
                    <td><asp:Label ID="Label1" runat="server" CssClass="lbl"  Text="CNG station Payment: "></asp:Label><span style="color:red">*</span></td>
                    <td><asp:RadioButtonList ID="rdbCNGSupplierpay" runat="server" CssClass="lbl" OnSelectedIndexChanged="rdbCNGSupplierpay_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Cash CNG"  Value="0"></asp:ListItem>
                    <asp:ListItem Text="Credit CNG" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Both Type" Value="2"></asp:ListItem>
                   
                    </asp:RadioButtonList>
                    </td>  
                    <td><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="CNG station: "></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsFuelstation" DataTextField="strFuelStationName" DataValueField="intFuelStationID"></asp:DropDownList>
                        
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getFuelStationList" TypeName="SAD_BLL.Customer.Report.StatementC">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unit" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        
                    </td>
                        <td style="text-align:right"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Supplier CNG Cash:  " ></asp:Label><span style="color:red">*</span></td>
                        <td> <asp:TextBox ID="txtCNGCash" onkeyup="sum();" AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"  onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>      

                        <td style="text-align:right"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Supplier CNG Credit:  " ></asp:Label></td>
                        <td> <asp:TextBox ID="txtCNGCredit"   AutoPostBack="false" runat="server" Width="200px" TextMode="Number" CssClass="txtBox"  onkeypress="javascript:return isNumber (event)"></asp:TextBox></td>      
                </tr>




          

          

        

             </div>  
         
             <div class="leaveApplication_container">
                
             <tr class="tblroweven">
                 <td style="text-align:right"> <asp:Label ID="lblRunbyOilkm" runat="server" CssClass="lbl" Text="Run by Oil km:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtOilKm" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblMaitenanceVh" runat="server" CssClass="lbl" Text="Mnt. Cost:  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtMntVh" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
                 
                 <td style="text-align:right"><asp:Label ID="lblOwnDA" runat="server" CssClass="lbl" Text="Own D.A:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOwnDA" onkeyup="sum();" AutoPostBack="false" runat="server"  CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
                  
                 <td style="text-align:right"><asp:Label ID="lblHotel" runat="server" CssClass="lbl" Text="Own Hotel :  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOwnHotel" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox> </td>

             </tr>

             
                <tr class="tblroweven">
                    <td style="text-align:right"><asp:Label ID="lblPMilTotal" CssClass="lbl" runat="server" Text="Personal Use Tk:  " ></asp:Label></td>
                <td> <asp:TextBox ID="txtPmilagTotalCost"  placeholder="Only Numeric Digit" runat="server" Width="200px" AutoPostBack="false"  CssClass="txtBox" onkeypress="javascript:return isNumber (event)"  ></asp:TextBox></td>    

                 <td style="text-align:right"><asp:Label ID="lblPersonalUseMilage" CssClass="lbl" runat="server" Text="Personal used (KM):  " ></asp:Label></td>
                <td> <asp:TextBox ID="txtPersMilagekm"  placeholder="Only Numeric Digit" runat="server" Width="200px" AutoPostBack="false"  CssClass="txtBox" onkeypress="javascript:return isNumber (event)"  ></asp:TextBox></td>      
                

                 <td style="text-align:right"><asp:Label ID="lblOtherCost" runat="server" CssClass="lbl" Text="OtherCost:  "></asp:Label></td>
                 <td><asp:TextBox ID="txtOtherCost" onkeyup="sum();" AutoPostBack="false" runat="server"   CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
                 <td style="text-align:right"> <asp:Label ID="lblTotal" runat="server" CssClass="lbl" Text="Total Cost :  "></asp:Label> </td>
                 <td><asp:TextBox ID="txtTotal" runat="server" onkeyup="sum();"  AutoPostBack="false" CssClass="txtBox" TextMode="Number" Enabled="false"  Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox></td>
             </tr>
                     
             
             <tr class="tblrowOdd">
                 <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
                 <td>
                     <asp:Button ID="btnAddBikeCarUser" runat="server" OnClick="btnAddBikeCarUser_Click" Text="Add" BackColor="#ffffcc" />
                 </td>
                 <td>
                     <asp:Button ID="btnSubmitBikeCar" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmitBikeCar_Click"/>
                 </td>
             </tr>
             </table>


        


    </div>   

        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
      
                    


                    <asp:GridView ID="grdvForStandByVehicle" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvForStandByVehicle_SelectedIndexChanged" OnRowDeleting="grdvForStandByVehicle_RowDeleting"  >
                        <Columns>
                             <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="enrol" HeaderText="Emlployee id" SortExpression="enrol" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="vhehiclename" HeaderText="Vhehicle Name" SortExpression="vhehiclename" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="vhechleid" HeaderText="Vhechile id"  SortExpression="vhechleid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="fromAddress" HeaderText="From Addr." SortExpression="fromAddress" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="movementAddress" HeaderText="Moved Area" SortExpression="movementAddress" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="toAddress" HeaderText="To Address" SortExpression="toAddress" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="startmilage" HeaderText="Str Milg" SortExpression="startmilage" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="endmilage" HeaderText="End Milg" SortExpression="endmilage" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="consumed" HeaderText="Consumed" SortExpression="consumed" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="totoilltr" HeaderText="Total Oil Ltr" SortExpression="totoilltr" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="oilPaymentTypeid" HeaderText="Oil Pay id" SortExpression="oilPaymentTypeid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="oilSupplierID" HeaderText="Oil Supplier ID" SortExpression="oilSupplierID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="OilCashAmount" HeaderText="Oil Cash" SortExpression="OilCashAmount" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="OilcreditAmount" HeaderText="Oil Credit" SortExpression="OilcreditAmount" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="cngPaymentTypeid" HeaderText="Cng Qnt" SortExpression="cngPaymentTypeid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="CNGSupplierID" HeaderText="CNG Supplier ID" SortExpression="CNGSupplierID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="CNGCashAmount" HeaderText="CNG Cash" SortExpression="CNGCashAmount" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="CNGCreditAmount" HeaderText="CNG Credit" SortExpression="CNGCreditAmount" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            <asp:BoundField DataField="TotalGas" HeaderText="Total Gas Ltr" SortExpression="TotalGas" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="mntCost" HeaderText="Mnt Cost" SortExpression="mntCost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ownda" HeaderText="Own DA" SortExpression="decOwnDa" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                           <asp:BoundField DataField="ownhotelfair" HeaderText="Own Hotel" SortExpression="ownhotelfair" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />

                            <asp:BoundField DataField="personalusedMilageQnt" HeaderText="Pers MQnt" SortExpression="personalusedMilageQnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="personalusemilageTotcost" HeaderText="Pers MCost" SortExpression="personalusemilageTotcost" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="OtherCost" HeaderText="OthCost" SortExpression="OtherCost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="totalcost" HeaderText="Total(Tk.)" SortExpression="totalcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("fromAddress") %>' /></ItemTemplate></asp:TemplateField> 

                            
                            

                            <asp:CommandField ControlStyle-BackColor="#ff9900" ShowDeleteButton="True"  />
                        



                        </Columns>




                    </asp:GridView>



                </td>


            </tr>
            </table>


        </div>




         <%--=========================================End My Code From Here=================================================--%>
  
    </form>
</body>
</html>