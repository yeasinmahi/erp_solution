<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TourPlanEntry.aspx.cs" Inherits="UI.HR.TourPlan.TourPlanEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>

   <script type="text/javascript">
           function myfunction() {
           return true;
       }
</script>
     <script>
         function Registration(url) {
            
             window.open('NewHotelEntry.aspx?ID=' + url, '', "height=375, width=630, scrollbars=yes, left=350, top=200, resizable=no, title=Preview");
         }


</script>
    <script>
        function Viewdetails(id) {
            window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
        }

    </script>

</head>
<body>
    <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
   

<%--=========================================Start My Code From Here===============================================--%>

     <div class="leaveApplication_container"> 
    <div class="tabs_container"> Personal Information :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnofficeEmail" runat="server"/>
      
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
            <tr class="tblroweven">
                <td><asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label></td>
                <td ><asp:TextBox ID="txtUnitName" ReadOnly="true" BackColor="#ffffcc" runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lbName" runat="server" Text="Name"></asp:Label></td>
                <td><asp:TextBox ID="txtName" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblDesg" runat="server" Text="Designation"></asp:Label></td>
                <td><asp:TextBox ID="txtDesignation" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblEnrol"  runat="server"  Text="Enrol"></asp:Label></td>
                <td><asp:TextBox ID="txtEnrol" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblLunchBreak" runat="server" Text="Lunch Break"></asp:Label></td>
                <td><asp:TextBox ID="txtLunchBreak1" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblPrayerBreak1" runat="server" Text="Preayer Break1"></asp:Label></td>
                <td><asp:TextBox ID="txtPrayerBreak1" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
                <td><asp:Label ID="lblPrayerBreak2" runat="server" Text="Preayer Break2"></asp:Label></td>
                <td><asp:TextBox ID="txtPrayerBreak2" ReadOnly="true" BackColor="#ffffcc"  runat="server"></asp:TextBox></td>
             </tr>

            <tr class="tblrowodd">
                <td><asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label></td>
                <td ><asp:DropDownList ID="drdlRegion" runat="server" DataSourceID="odsTourRegionName" DataTextField="strRegionName" DataValueField="intRegionid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsTourRegionName" runat="server" SelectMethod="getRegionName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                            <asp:SessionParameter Name="strOfficeEmail" SessionField="sesEmail" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                
                <td><asp:Label ID="lblArea" runat="server" Text="Area"></asp:Label></td>
                <td><asp:DropDownList ID="drdlArea" runat="server" DataSourceID="odsAreaName" DataTextField="strAreaName" DataValueField="intAreaid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsAreaName" runat="server" SelectMethod="getTourAreaName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlRegion" Name="RegionId" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td><asp:Label ID="lblTerritory" runat="server" Text="Territory"></asp:Label></td>
                <td><asp:DropDownList ID="drdlTerritory" runat="server" DataSourceID="odsTourTerritoryName" DataTextField="strTerritoryName" DataValueField="intTerritoryid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsTourTerritoryName" runat="server" SelectMethod="getTourTerritoryName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlArea" Name="Areaid" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td><asp:Label ID="lblPoint"  runat="server"  Text="Point"></asp:Label></td>
                <td><asp:DropDownList ID="drdlPoint" runat="server"></asp:DropDownList></td>
                

                 <td><asp:Label ID="lblRoute" runat="server" Text="Route"></asp:Label></td>
                <td><asp:DropDownList ID="drdlRoute" runat="server"></asp:DropDownList></td>
                <td><asp:Label ID="lblZone" runat="server" Text="Zone"></asp:Label></td>
                <td><asp:DropDownList ID="drdlZone" runat="server"></asp:DropDownList></td>
                
             </tr>

           </table>
    </div>

        <div class="leaveApplication_container"> 
    <div class="tabs_container"> Tour Plan Detaills :<asp:HiddenField ID="HiddenField1" runat="server"/>
        <asp:HiddenField ID="HiddenField2" runat="server"/><asp:HiddenField ID="HiddenField3" runat="server"/>
        
        <asp:HiddenField ID="HiddenField4" runat="server"/>
       
        <hr /></div>
              <table border="0"; style="width:Auto"; >    
                   <tr class="tblroweven">
                     <td style="text-align:right;"><asp:Label ID="lblTourType" CssClass="lbl" runat="server" Text="Tour Type : "></asp:Label></td>
                     <td><asp:RadioButtonList ID="rdbTourType" runat="server" OnSelectedIndexChanged="rdbTourType_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="HQ" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Out-Station" Selected="True" Value="1"></asp:ListItem>
                    
                    </asp:RadioButtonList>
                    </td>  
                    <td style="text-align:right;"><asp:Label ID="lblNightStay" CssClass="lbl" runat="server" Text="Night Stay : "></asp:Label></td>
                    <td colspan="2">
                      
                        <asp:DropDownList ID="drdlNightStay" runat="server" DataSourceID="odsTourHotelList" DataTextField="strHotelName" DataValueField="intId"></asp:DropDownList>
                        <asp:ObjectDataSource ID="odsTourHotelList" runat="server" SelectMethod="getTourHotelName" TypeName="HR_BLL.TourPlan.TourPlanning">
                            <SelectParameters>
                                <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                


                    </td>
                       <td>
                 <asp:Button ID="Complete" runat="server" Text="+" class="button" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("intEmployeeid") %>' />
               
                       </td>

                  </tr>
            <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label><span style="color:red">*</span></td>
                        <td><asp:TextBox ID="txtFromDate"  runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtToDate"   runat="server" CssClass="txtBox" AutoPostBack="false" Enabled="true"></asp:TextBox> <span style="color:red">*</span>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>       
                </tr>
                  <tr class="tblroweven">
                 <td style="text-align:right;"><asp:Label ID="lblstrt" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmStart" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
        <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmEnd" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
        <td style="text-align:right;"><asp:Label ID="lblOtherReason" CssClass="lbl" runat="server" Text="Other Reason for visit: "></asp:Label></td>
        <td><asp:TextBox ID="txtOtherReason" BackColor="#ffffcc" runat="server" TextMode="MultiLine" Width="400"></asp:TextBox></td>    
             </tr>
             <tr class="tblrowodd">
                <td><asp:Label ID="lblVisitedArea" runat="server" Text="Location to be visited"></asp:Label></td>
                <td ><asp:TextBox ID="txtVisitedArea" BackColor="#ffffcc" runat="server" TextMode="MultiLine" Width="200"></asp:TextBox></td>
                 

                <td>
                  
                     <asp:Label ID="lblReasons" runat="server" Text="Reason"></asp:Label>
                    </td>
                    
                   
                <td colspan="3">
                     <asp:CheckBoxList ID="uxVisibilityScopeCheckBoxList" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="uxVisibilityScopeCheckBoxList_SelectedIndexChanged" >
                     <asp:ListItem Value="1">Mkt. visit</asp:ListItem>
                     <asp:ListItem Value="2">Sales Meeting</asp:ListItem>
                    <asp:ListItem Value="3">Customer visit</asp:ListItem>
                    <asp:ListItem Value="4">Accompainment</asp:ListItem>
                    <asp:ListItem Value="5">Coverage expansion</asp:ListItem>
                    <asp:ListItem Value="6">Sales Monitoring</asp:ListItem>  
                         
                     </asp:CheckBoxList>
                </td>
                </tr>
                 
                 

                  <tr class="tblroweven">
                      <td><asp:Button ID="btnAdd" runat="server"  Text="Add" BackColor="#ffffcc" Font-Bold="true" UseSubmitBehavior="false"  OnClick="btnAdd_Click" OnClientClick="myfunction();"/></td>
                      <td><asp:Button ID="btnSubmitTourPlan" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmitTourPlan_Click" /></td>
                      <td colspan="4" style="font:bold 12px verdana; background-color:aliceblue; text-align:left; padding-left:25px;">
                            <asp:HiddenField ID="Hidden1" runat="server" />    
                          <asp:Label ID="lblrcd" runat="server"></asp:Label></td>
                      
             </tr>


         </table>
        </div>
        <div>
            <table>
                <tr class="tblroweven">
                    <td>
                          <asp:GridView ID="grdvTourPlanEntry" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvTourPlanEntry_SelectedIndexChanged" OnRowDeleting="grdvTourPlanEntry_RowDeleting" >
                        <Columns>
                           
                             <asp:BoundField DataField="tourTypeid" HeaderText="TourTypeid" SortExpression="tourTypeid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" Visible="false" />
                             <asp:BoundField DataField="nightstay" HeaderText="NightStay" SortExpression="nightstay" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="fromdate" HeaderText="FromDate" SortExpression="fromdate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="todate" HeaderText="ToDate"  SortExpression="todate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="starttime" HeaderText="StartTime" SortExpression="starttime" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                            <asp:BoundField DataField="endtime" HeaderText="EndTime" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="visitedarea" HeaderText="VisitedArea" SortExpression="visitedarea" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="reasons" HeaderText="Reasons" SortExpression="reasons" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="TourTypename" HeaderText="TourType" SortExpression="TourTypename" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="OtherReasons" HeaderText="OtherReason" SortExpression="OtherReasons" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="TerritoryName" HeaderText="Territory" SortExpression="TerritoryName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="300" />
                            <asp:BoundField DataField="Point" HeaderText="Point" SortExpression="Point" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            <asp:BoundField DataField="Route" HeaderText="Route" SortExpression="Route" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                             <asp:BoundField DataField="Zone" HeaderText="Zone" SortExpression="Zone" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="75" />
                            
                            
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