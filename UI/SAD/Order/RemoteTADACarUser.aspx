<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADACarUser.aspx.cs" Inherits="UI.SAD.Order.RemoteTADACarUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   
    







  


  <%--<script src="../../Content/JS/datepickr.min.js"></script>--%>
    <script src="../../Content/JS/datepickr.min.js"></script>
  
    <script type="text/javascript">
        //$(document).ready(function () {
        //        $("[id$=txtDate]").datepicker();
        //});


        function ValidateCompleteAdd(sender, args) {

            var flag = Val(sender, args);

            if (document.getElementById("txtEndMilage").value == '' && flag) {
                alert('End milage can not be blank');
                NotExec(args);
                flag = false;
            }



            if (document.getElementById("txtStartMilage").value == '' && flag) {
                alert('Start milage can not be blank');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("txtEndTime").options.value == '' && flag) {
                alert('End time can not be blank');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("txtToAddress").options.value == '' && flag) {
                alert('To address must be fill');
                NotExec(args);
                flag = false;
            }




            if (document.getElementById("txtFromAddress").options.value == '' && flag) {
                alert('From address must be fill');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("txtStartTime").value == '' && flag) {
                alert('Start time must be filled');
                NotExec(args);
                flag = false;
            }
        }
         </script>

 <script type="text/javascript">
     function Getdates() { alert('I am here'); }// new datepickr('txtDate', { 'dateFormat': 'Y-m-d' }); }
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
    <div class="tabs_container"> TA - DA information input (Bike & Car User)  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >    


        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>

        <tr><td style="text-align:right" colspan="2"> <asp:Button ID="btnShowInputForm" runat="server" Text="Show" OnClick="btnShowInputForm_Click"  /></td>
            <td style="text-align:right" colspan="2"><asp:Button ID="btnSubmit" runat="server" Text="Submit"  OnClick="btnSubmit_Click" /></td>

        </tr>
             
        <tr class="tblrowodd">
             <td colspan="4">
                 <asp:GridView ID="grvTADACarBikeUser" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDeleting="grvTADACarBikeUser_RowDeleting"  OnSelectedIndexChanged="grvTADACarBikeUser_SelectedIndexChanged" ShowFooter="True"  >
                         <Columns>
                             <asp:BoundField DataField="RowNumber" HeaderText="SNo" SortExpression="intSn" />
                             <asp:TemplateField HeaderText=" Date * " SortExpression="dteDate" HeaderStyle-ForeColor="#ff0000">
                                  <ItemTemplate>
                                      <asp:TextBox ID="txtDate" runat="server" /></asp:TextBox>
                                      </ItemTemplate>                          
                                

                             </asp:TemplateField>

                             <asp:TemplateField HeaderText=" Start   Time(Hour)* " HeaderStyle-ForeColor="#ff0000" SortExpression="dteStartTime" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtStartTime" runat="server"  Width="50px"  CssClass="txtBox" Enabled="true" ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             
              
                             <asp:TemplateField HeaderText=" From Address* " HeaderStyle-ForeColor="#ff0000" SortExpression="strFromadr">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFromAddress" runat="server" TextMode="MultiLine"   CssClass="txtBox" Enabled="true" ></asp:TextBox>

                                            

                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" Movement Spots* " HeaderStyle-ForeColor="#ff0000" SortExpression="strMovementSpots">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtMovementSpots" runat="server" TextMode="MultiLine" Width="300px"  CssClass="txtBox" Enabled="true"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" End   Time(Hour)* " HeaderStyle-ForeColor="#ff0000" SortExpression="dteEndtime">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtEndTime" runat="server"   Width="50px"  CssClass="txtBox" Enabled="true"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>


                             <asp:TemplateField HeaderText=" TO Address* " HeaderStyle-ForeColor="#ff0000" SortExpression="strToadr">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtToAddress" runat="server" TextMode="MultiLine"  CssClass="txtBox" Enabled="true"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText=" Move. Duration " SortExpression="decMovDuration" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDuration" runat="server"   Width="50px" Enabled="false" CssClass="txtBox"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" NightStay " SortExpression="strNightStay">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtNightStay" CssClass="txtBox" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" Start   Milage* " HeaderStyle-ForeColor="#ff0000" SortExpression="decStartMilage">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtStartMilage" runat="server" CssClass="txtBox"   Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" End    Milage* " HeaderStyle-ForeColor="#ff0000" SortExpression="decEndMilage">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtEndMilage" runat="server" CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>


                              <asp:TemplateField HeaderText=" Consumed   KM " SortExpression="decConsumedKM" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtConsumedkm" runat="server" Enabled="false" Width="50px" CssClass="txtBox"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Fuel Type*"  HeaderStyle-ForeColor="#ff0000" SortExpression="strFuelType">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="drdlFuelType" runat="server" Width="55px" CssClass="txtBox">
                                         <asp:ListItem Value="Petrol"> Petrol </asp:ListItem>
                                         <asp:ListItem Value="Mobil"> Mobil </asp:ListItem>
                                         <asp:ListItem Value="CNG"> C.N.G </asp:ListItem>
                                         <asp:ListItem Value="Octen"> Octen </asp:ListItem>
                                         <asp:ListItem Value="OctenCng"> Octen & C.N.G </asp:ListItem>
                                         <asp:ListItem Value="None"> None </asp:ListItem>
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>


                             <asp:TemplateField HeaderText=" FuelQnt. " SortExpression="decFuelQnt">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFuelQnt" runat="server"   Width="50px" CssClass="txtBox"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText=" FuelCost " SortExpression="decFuelCost">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFuelCost" runat="server" CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText="Transport Mode*" HeaderStyle-ForeColor="#ff0000" SortExpression="strTransport">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="drpTransportMode" runat="server" CssClass="txtBox" Width="55px">
                                         <asp:ListItem Value="RICK"> Rickshaw </asp:ListItem>
                                         <asp:ListItem Value="BUS"> Bus </asp:ListItem>
                                         <asp:ListItem Value="CNG"> C.N.G </asp:ListItem>
                                         <asp:ListItem Value="train"> Train </asp:ListItem>
                                         <asp:ListItem Value="Air"> By Air </asp:ListItem>
                                         <asp:ListItem Value="texi"> Texi-Cab </asp:ListItem>
                                         <asp:ListItem Value="Boat"> Boat </asp:ListItem>
                                         <asp:ListItem Value="None"> None </asp:ListItem>
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText=" Fare Cost (Tk.) " SortExpression="monFaretk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFare" runat="server"  CssClass="txtBox" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText=" Remarks " SortExpression="strSupportno">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtSupportingNo" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="250px"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 
                                 
                              <asp:TemplateField HeaderText=" Pht.Copy " SortExpression="decPhotocopy">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtPhotoCopy" runat="server" CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" Courier " SortExpression="decCourier">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtCourier" runat="server"  CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             

                               <asp:TemplateField HeaderText="Mnt. Category" SortExpression="strMntCategory">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="drpMntCategory" CssClass="txtBox" runat="server">
                                         <asp:ListItem Value="Heavy"> Heavy Mnt. </asp:ListItem>
                                         <asp:ListItem Value="lightmnt"> LightMnt </asp:ListItem>
                                         <asp:ListItem Value="None"> None </asp:ListItem>
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" Mnt.Cost " SortExpression="decMntCost">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtMntCost" runat="server" CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>

                              <asp:TemplateField HeaderText=" Ferry-Toll " SortExpression="decFerryToll">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtFerrytoll" runat="server" CssClass="txtBox"  Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>



                                  <asp:TemplateField HeaderText=" Own(DA)" SortExpression="monOwnDATk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtOwnDA" runat="server" CssClass="txtBox" Width="50px" ></asp:TextBox>
                                 </ItemTemplate>
                                  </asp:TemplateField>
                                 
                              <asp:TemplateField HeaderText=" Driver(DA) " SortExpression="monDriverDA">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDriverDA" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                  </asp:TemplateField>
                                 




                                 <asp:TemplateField HeaderText=" Own  HotelBill " SortExpression="monOwnHotel">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtOwnHotel" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>

                             <asp:TemplateField HeaderText=" Driver   HotelBill " SortExpression="monDriverHotel">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDriverhotel" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>



                                 <asp:TemplateField HeaderText=" Others (Tk.) " SortExpression="monOthertk">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtOthers" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                  </asp:TemplateField>
                             <asp:TemplateField HeaderText=" D. Total (Tk.) " SortExpression="monTotaltk" >
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtDTotal" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox>
                                 </ItemTemplate>




                                 
                                  <FooterStyle HorizontalAlign="Right" />
                                 <FooterTemplate>
                                     <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Row" Font-Bold="true" BackColor="#66ff99" />
                                 </FooterTemplate>
                             </asp:TemplateField>
                             <asp:CommandField ControlStyle-BackColor="#ff99ff" ShowDeleteButton="True" >
                             <ControlStyle BackColor="YellowGreen" />
                             </asp:CommandField>
                         </Columns>
                         <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                         <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                         <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                         <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                         <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#FFF1D4" />
                         <SortedAscendingHeaderStyle BackColor="#B95C30" />
                         <SortedDescendingCellStyle BackColor="#F1E5CE" />
                         <SortedDescendingHeaderStyle BackColor="#93451F" />
                     </asp:GridView>
                  

             </td>
                 


              </tr>

           

            





        </table>

 <caption >
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  Grand Total: 
                         <asp:Label ID="lblGrandTotal" runat="server" Text="0" Font-Bold="true" BackColor="#ccffcc"></asp:Label>
                     </caption>

    </div>

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
