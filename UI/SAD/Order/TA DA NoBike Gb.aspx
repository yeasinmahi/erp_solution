<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TA DA NoBike Gb.aspx.cs" Inherits="UI.SAD.Order.TA_DA_NoBike_Gb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>

     <script>
       
         function isNumber(evt) {
             var iKeyCode = (evt.which) ? evt.which : evt.keyCode
             if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                 return false;

             return true;
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
             var txtTodateFromCalend = document.forms["frmpdv"]["txtToDate"].value;
             var txtMovDurationJS = document.forms["frmpdv"]["txtMovDuration"].value;
             var txtFromAddrJS = document.forms["frmpdv"]["txtFromAddr"].value;
             var txtMovementAreaJS = document.forms["frmpdv"]["txtMovementArea"].value;

             var txtContactPersonJS = document.forms["frmpdv"]["txtContactPerson"].value;
             var txtPhoneJS = document.forms["frmpdv"]["txtPhone"].value;
             var txtVisitedPlaceJS = document.forms["frmpdv"]["txtVisitedPlace"].value;


             var txtDteTo = document.getElementById("DATE").value;

             if (txtDteFrom == null || txtDteFrom == "") {
                 alert("From date must be filled by valid formate (yyyy-MM-dd).");
                 document.getElementById("txtDteFrom").focus();
             }
             else if (txtTodateFromCalend == null || txtTodateFromCalend == "") {
                 alert("To  date must be filled by valid formate (yyyy-MM-dd).");
                 document.getElementById("txtTodateFromCalend").focus();
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

        
        function RemoveRow(item) {
            var table = document.getElementById('GridView1');
    table.deleteRow(item.parentNode.parentNode.rowIndex);
    return false;
}



    </script>





   
  <script>
  function sum() {
       var txtBusFairv = document.getElementById('txtBusFair').value;
       var txtRickshawv = document.getElementById('txtRickshaw').value;
       var txtCNGv = document.getElementById('txtCNG').value;
     
       var txtTrainv = document.getElementById('txtTrain').value;
       var txtBoatv = document.getElementById('txtBoat').value;
       var txtOtherVhv = document.getElementById('txtOtherVh').value;

       var txtOwnDAv = document.getElementById('txtOwnDA').value;
       var txtOtherDAv = document.getElementById('txtOtherDA').value;
       var txtHotelv = document.getElementById('txtHotel').value;
       var txtOtherCostv = document.getElementById('txtOtherCost').value;


       if (txtBusFairv == "" )
           txtBusFairv = 0;
       if (txtRickshawv == "")
           txtRickshawv = 0;

       if (txtCNGv == "")
           txtCNGv = 0;


       if (txtTrainv == "")
           txtTrainv = 0;
       if (txtBoatv == "")
           txtBoatv = 0;
       if (txtOtherVhv == "")
           txtOtherVhv = 0;

       if (txtOwnDAv == "")
           txtOwnDAv = 0;
       if (txtOtherDAv == "")
           txtOtherDAv = 0;
       if (txtHotelv == "")
           txtHotelv = 0;

       if (txtOtherCostv == "")
           txtOtherCostv = 0;


       var result = parseInt(txtBusFairv) + parseInt(txtRickshawv) + parseInt(txtCNGv) + parseInt(txtTrainv) + parseInt(txtBoatv) + parseInt(txtOtherVhv) + parseInt(txtOwnDAv) + parseInt(txtOtherDAv) + parseInt(txtHotelv) + parseInt(txtOtherCostv);
       if (!isNaN(result)) {
           document.getElementById('txtTotal').value = result;
       }
   }
    </script>
    <script type="text/javascript">

        $('input.required').each(function(){

            $(this).prev('label').after('*');

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
    <div class="tabs_container"> TA - DA information input (None Bike User).Plz submit the bill day to day basis. One month bill can not submit after the 5th day of next month   :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/> <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate"  placeholder="Click for date" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox> <span style="color:red">*</span>
        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate"  placeholder="Click For date" runat="server" CssClass="txtBox" AutoPostBack="false" Enabled="true" autocomplete="off"></asp:TextBox> <span style="color:red">*</span>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>       
         
         <td style="text-align:right"><asp:Label ID="lblTotalMovementDuraion" CssClass="required"  runat="server" Text="Movement Duration(Hour) "  ></asp:Label> </td>
                          
        
            <td> <asp:TextBox ID="txtMovDuration" runat="server" Width="200px" TextMode="Number" placeholder="Fill by digit" onkeypress="javascript:return isNumber (event)"   CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>      
                
        </tr>
         <tr class="tblrowOdd"><td style="text-align:right"><asp:Label ID="lblCategory" CssClass="lbl" runat="server" Text="From Address:  " ></asp:Label></td>
                                <td> <asp:TextBox ID="txtFromAddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
                                 <td style="text-align:right"><asp:Label ID="lblMovementArea" CssClass="lbl" runat="server" Text="Movement Area:  " ></asp:Label></td>   
                                    <td> <asp:TextBox ID="txtMovementArea" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox><span style="color:red">*</span></td>
                                    <td style="text-align:right"><asp:Label ID="lblToAddress" CssClass="lbl" runat="server" Text="To Address:  " ></asp:Label></td>   
                                    <td> <asp:TextBox ID="txtToaddr" runat="server" Width="200px" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
                                     </td>
        
             
         </tr>
           </div>  
           
            <div class="leaveApplication_container">

                

            
           
             <tr class="tblroweven">
                 
                 <td style="text-align:right">
                     <asp:Label ID="lblBusFair" runat="server" CssClass="lbl" Text="Bus:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtBusFair" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblRickshaw" runat="server" CssClass="lbl" Text="Rickshaw:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtRickshaw" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblCNG" runat="server" CssClass="lbl" Text="C.N.G:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtCNG" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox" TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                 </td>
             </tr>
             <tr class="tblrowOdd">
                 <td style="text-align:right">
                     <asp:Label ID="lblTrain" runat="server" CssClass="lbl" Text="Train:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtTrain" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)"></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblBoat" runat="server" CssClass="lbl" Text="Boat:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtBoat" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox" TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblAnOtherVh" runat="server" CssClass="lbl" Text="Another Transport:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtOtherVh" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
             </tr>
             <tr class="tblroweven">
                 <td style="text-align:right">
                     <asp:Label ID="lblOwnDA" runat="server" CssClass="lbl" Text="Own D.A:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtOwnDA" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblOtherDA" runat="server" CssClass="lbl" Text="Othe D.A:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtOtherDA" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox" TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblHotel" runat="server" CssClass="lbl" Text="Hotel :  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtHotel" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
             </tr>
             <tr class="tblrowOdd">
                 <td style="text-align:right">
                     <asp:Label ID="lblOtherCost" runat="server" CssClass="lbl" Text="OtherCost:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtOtherCost" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblRemarks" runat="server" CssClass="lbl" Text="Remarks:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="200px"></asp:TextBox>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblTotal" runat="server" CssClass="lbl" Text="Total Cost :  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtTotal" runat="server" onkeyup="sum();" AutoPostBack="false" CssClass="txtBox"  TextMode="Number" Width="200px" onkeypress="javascript:return isNumber (event)" ></asp:TextBox>
                 </td>
             </tr>
             <tr class="tblroweven">
                 <td style="text-align:right">
                     <asp:Label ID="lblContactPerson" runat="server"  CssClass="lbl" Text="Contact Person:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtContactPerson" placeholder="Name" runat="server" CssClass="txtBox" TextMode="SingleLine" Width="200px"></asp:TextBox>
                     <span style="color:red">*</span>
                 </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblContactPersonPhone" runat="server"  CssClass="lbl" Text="Phone:  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtPhone" placeholder="Number" runat="server" CssClass="txtBox" onkeypress="javascript:return isNumber (event)" TextMode="SingleLine" Width="200px"></asp:TextBox>
                 <span style="color:red">*</span>
                      </td>
                 <td style="text-align:right">
                     <asp:Label ID="lblVisitedOrganziation" runat="server" CssClass="lbl" Text="Visited Place  :  "></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox ID="txtVisitedPlace" runat="server" placeholder="Address" CssClass="txtBox" TextMode="MultiLine" Width="200px"></asp:TextBox>
                  <span style="color:red">*</span>
                 </td>
             </tr>
             <tr class="tblrowOdd">
                 <td>
                     <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" OnClientClick = "Confirm()" Text="Add" />
                 </td>
                 <td>
                     <asp:Button ID="btnSubmit" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmit_Click1" OnClientClick = "Confirm()"/>
                 </td>
             </tr>
             </table>


           


    </div>   
        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    



                   
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                        
                    <Columns>
                    <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="MovDuration" HeaderText="Dur." SortExpression="decDur" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="fromAddress" HeaderText="From Addr." SortExpression="strForm" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    <asp:BoundField DataField="movementAddress" HeaderText="Moved Area" SortExpression="strMove" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="toAddress" HeaderText="To Address" SortExpression="strToadr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                         
                    <asp:TemplateField HeaderText="busfair" HeaderStyle-HorizontalAlign="Center" SortExpression="busfair">
                    <ItemTemplate><asp:Label ID="lblbusfair" runat="server" Text='<%# (""+Eval("busfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblbusfair1" runat="server" Font-Bold="true"  Text='<%# busfairTotal %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Rickfai" HeaderStyle-HorizontalAlign="Center" SortExpression="Rickfai">
                    <ItemTemplate><asp:Label ID="lblRickfai" runat="server" Text='<%# (""+Eval("Rickfai")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblRickfai1" runat="server" Font-Bold="true"  Text='<%# RickfaiTotal %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="cngfair" HeaderStyle-HorizontalAlign="Center" SortExpression="cngfair">
                    <ItemTemplate><asp:Label ID="lblcngfair" runat="server" Text='<%# (""+Eval("cngfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblcngfair1" runat="server" Font-Bold="true" Text='<%# cngfairTotal %>' /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="trainfair" HeaderStyle-HorizontalAlign="Center" SortExpression="trainfair">
                    <ItemTemplate><asp:Label ID="lbltrainfair" runat="server" Text='<%# (""+Eval("trainfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblboatfair1" runat="server" Font-Bold="true"   Text='<%# trainfairTotal %>'/></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="boatfair" HeaderStyle-HorizontalAlign="Center" SortExpression="boatfair">
                    <ItemTemplate><asp:Label ID="lblboatfair" runat="server" Text='<%# (""+Eval("boatfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblboatfair1" runat="server" Font-Bold="true"  Text='<%# boatfairTotal %>' /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="othervhfair" HeaderStyle-HorizontalAlign="Center" SortExpression="othervhfair">
                    <ItemTemplate><asp:Label ID="lblothervhfair" runat="server" Text='<%# (""+Eval("othervhfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblothervhfair1" runat="server" Font-Bold="true" Text='<%# othervhfairTotal %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="ownda" HeaderStyle-HorizontalAlign="Center" SortExpression="ownda">
                    <ItemTemplate><asp:Label ID="lblownda" runat="server" Text='<%# (""+Eval("ownda")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblownda1" runat="server" Font-Bold="true"  Text='<%# owndaTotal %>' /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="otherpersonda" HeaderStyle-HorizontalAlign="Center" SortExpression="otherpersonda">
                    <ItemTemplate><asp:Label ID="lblotherpersonda" runat="server" Text='<%# (""+Eval("otherpersonda")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblotherpersonda1" runat="server" Font-Bold="true"  Text='<%# otherpersondaTotal %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="hotelfair" HeaderStyle-HorizontalAlign="Center" SortExpression="hotelfair">
                    <ItemTemplate><asp:Label ID="lblhotelfair" runat="server" Text='<%# (""+Eval("hotelfair")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblhotelfair1" runat="server" Font-Bold="true" Text='<%# hotelfairTotal %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="OtherCost" HeaderStyle-HorizontalAlign="Center" SortExpression="OtherCost">
                    <ItemTemplate><asp:Label ID="lblOtherCost" runat="server" Text='<%# (""+Eval("OtherCost")) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblOtherCost1" runat="server" Font-Bold="true" Text='<%# Grndothercost %>'  /></FooterTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="remarks" SortExpression="remarks"><ItemTemplate><asp:Label ID="lblremarkst" runat="server" Text='<%# Bind("remarks") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="500px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="Grand-Total :" /></div>
                    </FooterTemplate></asp:TemplateField>     
                    <asp:TemplateField HeaderText="totalcost" ItemStyle-HorizontalAlign="right" SortExpression="totalcost" >
                    <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("totalcost"))) %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="right" Width="90px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandtotal %>' /></FooterTemplate></asp:TemplateField>
                                   
                    <asp:BoundField DataField="contactperson" HeaderText="Contact P" SortExpression="strcon" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="phone" HeaderText="Phone" SortExpression="strPhone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:BoundField DataField="vistOrganization" HeaderText="Organization" SortExpression="strOrg" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                    <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("fromAddress") %>' /></ItemTemplate></asp:TemplateField> 

                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

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