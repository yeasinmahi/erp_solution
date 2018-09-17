<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramBillInfo.aspx.cs" Inherits="UI.HR.TourPlan.ProgramBillInfo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

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

     <script>
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtProgramNo = document.forms["frmdtls"]["txtProgramNo"].value;
            var txtAddress = document.forms["frmdtls"]["txtAddress"].value;
            var txtparticipantnumber = document.forms["frmdtls"]["txtparticipantnumber"].value;

            var txtfoodcost = document.forms["frmdtls"]["txtfoodcost"].value;
            var txtMojoCost = document.forms["frmdtls"]["txtMojoCost"].value;
            var txtOthercost = document.forms["frmdtls"]["txtOthercost"].value;


            if (txtProgramNo == null || txtProgramNo == "") { alert("Please enter Program No ."); }
            else if (txtAddress == null || txtAddress == "") { alert("Please enter Address."); }
            else if (txtparticipantnumber == null || txtparticipantnumber == "") { alert("Please enter Number of Participant."); }
            else if (txtfoodcost == null || txtfoodcost == "") { alert("Please enter Food Cost."); }
            else if (txtMojoCost == null || txtMojoCost == "") { alert("Please enter Mojo Cost"); }




            else { document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
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
        function sum() {


            var txtFOODCost = document.getElementById('txtfoodcost').value;
            var txtMOJOCost = document.getElementById('txtMojoCost').value;
            var txtOTHERCost = document.getElementById('txtOthercost').value;
            var txtTOTPARTICIPtnumber=document.getElementById('txtparticipantnumber').value;
            var txtTotal = document.getElementById('txtTotalCost').value;
            if (txtFOODCost == "")
                txtFOODCost = 0;
            if (txtMOJOCost == "")
                txtMOJOCost = 0;

            if (txtOTHERCost == "")
                txtOTHERCost = 0;

            if (txtTotal == "")
                txtTotal = 0;

            
            
            var result = parseFloat(txtFOODCost)*parseFloat(txtTOTPARTICIPtnumber) + parseFloat(txtMOJOCost)*parseFloat(txtTOTPARTICIPtnumber) + parseFloat(txtOTHERCost)*parseFloat(txtTOTPARTICIPtnumber) 

            if (!isNaN(result)) {
                document.getElementById('txtTotalCost').value = result;
            }
        }
    </script>
</head>
<body>
    <form id="frmdtls" runat="server">
  

<%--=========================================Start My Code From Here===============================================--%>

        <div class="leaveApplication_container"> 
    <div class="tabs_container"> Program Bill Input  :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnofficeEmail" runat="server"/>
      
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >   
            
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Program Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
                <td><asp:Label ID="lblProgramName"  runat="server"  Text="Program Name"></asp:Label></td>
               <td><asp:DropDownList ID="drdlprgname" runat="server" DataSourceID="odsProgramName" DataTextField="strProgramName" DataValueField="intProgramID"></asp:DropDownList>
                  
                   <asp:ObjectDataSource ID="odsProgramName" runat="server" SelectMethod="getProgramName" TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                  
                   </td>
        </tr>
          
            <tr class="tblroweven">
                <td><asp:Label ID="lblProgramNo" runat="server" Text="ProgramNo"></asp:Label></td>
                <td ><asp:TextBox ID="txtProgramNo"  BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblAddress" runat="server" Text="Address" ></asp:Label></td>
                <td><asp:TextBox ID="txtAddress"  BackColor="#ffffcc"  runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr class="tblrowodd">
                    <td>Participant Type</td>
               <td><asp:DropDownList ID="drdlCosttype" runat="server" AutoPostBack="True" DataSourceID="odsProgramType" DataTextField="strProgramAttendance" DataValueField="intID"></asp:DropDownList>
                   <asp:ObjectDataSource ID="odsProgramType" runat="server" SelectMethod="getManpowerType"  TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                   
                    </td>
                <td><asp:Label ID="lblParticipantNumber" runat="server" Text="Participant Number"></asp:Label></td>
                <td><asp:TextBox ID="txtparticipantnumber"  BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                
                     
                </tr>
            <tr>
                <td><asp:Label ID="lblFoodcostPer" runat="server" Text="Food cost/Per Person"></asp:Label></td>
                <td ><asp:TextBox ID="txtfoodcost"  BackColor="#ffffcc" runat="server" onkeyup="sum();" AutoPostBack="false"></asp:TextBox></td>
                 <td><asp:Label ID="lblMojoCost" runat="server" Text="MojoCost/Per Person"></asp:Label></td>
                <td ><asp:TextBox ID="txtMojoCost"  BackColor="#ffffcc" runat="server" onkeyup="sum();" AutoPostBack="false"></asp:TextBox></td>

            </tr>

              <tr>
                <td><asp:Label ID="lblOthercost" runat="server" Text="Othercost/Per Person"></asp:Label></td>
                <td ><asp:TextBox ID="txtOthercost"  BackColor="#ffffcc" runat="server" onkeyup="sum();" AutoPostBack="false"></asp:TextBox></td>
                <td><asp:Label ID="lblTotalCost" runat="server" Text="Total Cost"></asp:Label></td>
                <td ><asp:TextBox ID="txtTotalCost"  runat="server" onkeyup="sum();"  AutoPostBack="false" CssClass="txtBox" TextMode="Number"   Width="200px" BackColor="#ffffcc"></asp:TextBox></td>

            </tr>

               
             <tr class="tblrowodd">
                 
                  <td>
                      <asp:Label ID="lblTerritory" runat="server" Text="Territory"></asp:Label>

                  </td>
                 <td>
                     <asp:DropDownList ID="drdlRegionName" runat="server" DataSourceID="odsTourRegionforHotel" DataTextField="strRegionName" DataValueField="intRegionid"></asp:DropDownList>
                     <asp:ObjectDataSource ID="odsTourRegionforHotel" runat="server" SelectMethod="getRegionName" TypeName="HR_BLL.TourPlan.TourPlanning">
                         <SelectParameters>
                             <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                             <asp:SessionParameter Name="strOfficeEmail" SessionField="sesEmail" Type="String" />
                         </SelectParameters>
                     </asp:ObjectDataSource>
                 </td>

                
<%--OnClientClick="Confirm()" --%>
                 <td>
                     <asp:Button ID="btnProgramBill" runat="server" Text="Add" Font-Bold="true"   OnClick="btnProgramBill_Click" OnClientClick = "Confirm()"/>
                     <asp:HiddenField ID="hdnconfirm" runat="server" />
                 </td>
                  <td>
                     <asp:Button ID="btnProgramBillSubmit" runat="server" Text="Submit" OnClick="btnProgramBillSubmit_Click" />
                 </td>
             </tr>


            </table>
            </div>
         <div>
            <table>
                <tr class="tblroweven">
                    <td>
                          <asp:GridView ID="grdvProgrambillinfo" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvProgrambillinfo_SelectedIndexChanged" OnRowDeleting="grdvProgrambillinfo_RowDeleting" >
                        <Columns>
                               <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdntotalcostperh" runat="server" Value='<%# Bind("totalcostperh") %>' />
                                   <asp:HiddenField ID="hdnprgid" runat="server" Value='<%# Bind("programid") %>' />
                                   <asp:HiddenField ID="hdnparticipcatgid" runat="server" Value='<%# Bind("participantcatgid") %>' />
                                                                   </ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="programdate" HeaderText="Program Date" SortExpression="programdate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="programName" HeaderText="ProgramName" SortExpression="address" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="programid" HeaderText="ProgramID" SortExpression="programid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="programno" HeaderText="programNo" SortExpression="programno" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="adr" HeaderText="Adress" SortExpression="adr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="participantcatgid" HeaderText="ParticipantCatgid" SortExpression="participantcatgid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="participantcatgname" HeaderText="participantcatgname" SortExpression="remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="participantnumber" HeaderText="Participantnumber" SortExpression="participantnumber" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                             <asp:BoundField DataField="foodperh" HeaderText="FoodcostPerhead" SortExpression="foodperh" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="mojoperh" HeaderText="MojocostPerhead" SortExpression="mojoperh" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="otherperh" HeaderText="OthercostPerhead" SortExpression="otherperh" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                             <asp:BoundField DataField="totalcostperh" HeaderText="TotalcostPerhead" SortExpression="totalcostperh" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                           
                            
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
