﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OvertimeEntry.aspx.cs" Inherits="UI.Inventory.OvertimeEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    <script src="../../../../Content/JS/datepickr.min.js"></script>




   <script>
       function GetTimeSpan() {
           var end = document.getElementById('txtend').value;
           var start = document.getElementById('txtstrt').value;
           var dur = document.getElementById('txtMovDuration').value;

           if (document.getElementById('r2').checked) {
             var  rate_value = document.getElementById('r2').value;
           }

           if (rate_value == 1) {
               document.getElementById("txtMovDuration").innerText = 0;
           }
           else {




               var subtract = parseFloat(end) + (-parseFloat(start));
               if (subtract > 0) {
                   var date1 = new Date();
                   var datediff = date1.getTime() / (1000 * 3600 * 24);

                   document.getElementById("txtMovDuration").innerText = subtract;
               }

               else {
                   document.getElementById("txtMovDuration").innerText = 24 + (-parseFloat(start)) + parseFloat(end);
               }
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
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "OvertimeEntry.aspx/GetAutoCompleteData",
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
    <div class="tabs_container"> Overtime entry (Driver & Office Assistants) :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="HiddenField3" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /><asp:HiddenField ID="hdnmiute" runat="server" />
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >   
              <tr class="tblroweven">
                   <td style="text-align:right;"><asp:Label ID="lblOvertimeType" CssClass="lbl" runat="server" BackColor="#ffcc00" Font-Bold="true" Text="OT Less than 1 Hour:  "></asp:Label><span style="color:red">*</span></td>
                   <td>
                      <%-- <asp:RadioButtonList ID="rdbOTType" runat="server" OnSelectedIndexChanged="rdbOTType_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="No"  Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                   checked="checked" 
                    </asp:RadioButtonList></td>--%>

                       <input type="radio" id="r1" name="rate" checked="checked"  value="0"> No

                       <input type="radio" id="r2" name="rate" value="1"> Yes

                       </td>
                   
                         <td style="text-align:right"><asp:Label ID="lblMinute"  CssClass="lbl" Visible="false" runat="server" Text="Minute "  ></asp:Label></td>
                    <td> <asp:TextBox ID="txtMinute"  AutoPostBack="false"  Visible="false"  runat="server"  TextMode="Number"    CssClass="txtBox" ></asp:TextBox></td>      

                     
              </tr>
             
             <tr class="tblroweven">
                        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color:red">*</span></td>
                        <td><asp:TextBox ID="txtFromDate" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                    <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
                    <td><asp:TextBox ID="txtstrt" runat="server" CssClass="txtBox" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtstrt').timepicker();</script></td>
                 </tr>
             <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
                    <td><asp:TextBox ID="txtend" runat="server" CssClass="txtBox" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtend').timepicker();</script></td> 
                    <td style="text-align:right"><asp:Label ID="lblTotalMovementDuraion"  CssClass="lbl" runat="server" Text="Movement.D (Hour) "  ></asp:Label></td>
                    <td> <asp:TextBox ID="txtMovDuration"  AutoPostBack="false"   runat="server"  TextMode="Number" Enabled="false"   CssClass="txtBox" ></asp:TextBox></td>      
              </tr>
                   <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name" AutoCompleteType="Search"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True"></asp:TextBox>
            <span style="color:red">*</span> </td>
            <td style="text-align:right;"><asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Code: "></asp:Label> </td>
            <td><asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
           </tr> 
           <tr class="tblroweven"> 
           <td style="text-align:right;"><asp:Label ID="lblEnrolNumber" CssClass="lbl" runat="server" Text="Enrol: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtAplicnEnrol" runat="server" Font-Bold="true" BackColor="#ffffcc"  CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td>
            <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation: "></asp:Label> </td>
            <td><asp:TextBox ID="txtDesignation" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
           
           </tr>
       
           
            
      


            <tr class="tblroweven">
            <td><asp:Label ID="lblPurpouse" CssClass="lbl" runat="server" Text="Purpouse: "></asp:Label></td>
            <td><asp:DropDownList ID="drdlPurpouse" CssClass="ddList" runat="server" AutoPostBack="True" DataSourceID="odsOvertimepurpouse" DataTextField="strPurpouse" DataValueField="intID" ></asp:DropDownList> 
                <asp:ObjectDataSource ID="odsOvertimepurpouse" runat="server" SelectMethod="getOvertimePurpouse" TypeName="HR_BLL.TourPlan.TourPlanning"></asp:ObjectDataSource>
                </td>
            <td style="text-align:right;"><asp:Label ID="lblRemarks" CssClass="lbl" runat="server" Text="Remarks: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtRemarks" runat="server" Font-Bold="true"   CssClass="txtBox" TextMode="MultiLine"></asp:TextBox> </td>
            <%--<td style="text-align:right;"><asp:Label ID="lblDepartment" CssClass="lbl" runat="server" Text="Department: "></asp:Label> </td>--%>
            <%--<td><asp:TextBox ID="txtDepartment" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
            <td style="text-align:right;"><asp:Label ID="lblUnitid" CssClass="lbl" runat="server" Text="Unitid: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtUnitid" runat="server" Font-Bold="true" BackColor="#ffffcc"   CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
            </tr>--%>
            <tr class="tblrowOdd">
            
            <td><asp:Button ID="btnAddBikeCarUser" runat="server" OnClick="btnAddBikeCarUser_Click" Text="Add" BackColor="#ffffcc" /></td>
            <td><asp:Button ID="btnSubmitBikeCar" runat="server" BackColor="#ffcccc" Font-Bold="true" Text="Submit" OnClick="btnSubmitBikeCar_Click"/> </td>
               
                 <%--<td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Jobstationid: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtJobstationid" runat="server" Font-Bold="true" BackColor="#ffffcc"   CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td>--%>
            </tr>
             </table>

      </table>
             </div>

         <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                <asp:GridView ID="grdvOvertimeEntry" runat="server" AutoGenerateColumns="false" RowStyle-Wrap="true" HeaderStyle-Wrap="true" OnSelectedIndexChanged="grdvOvertimeEntry_SelectedIndexChanged" OnRowDeleting="grdvOvertimeEntry_RowDeleting"  >
                <Columns>
                <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("BillDate") %>' /></ItemTemplate></asp:TemplateField> 
                <asp:BoundField DataField="BillDate" HeaderText="Bill Date" SortExpression="dteBillDate" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="txtstrtwihtHMS" HeaderText="StartTime" SortExpression="tmstartwihtHMS" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                <asp:BoundField DataField="tmendwithHMS" HeaderText="EndtTime" SortExpression="tmendwithHMS" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                <asp:BoundField DataField="tmdifferencewithHMS" HeaderText="Diffrence" SortExpression="tmdifferencewithHMS" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                    
                 <asp:BoundField DataField="starttime" HeaderText="Start" SortExpression="starttime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="endtime" HeaderText="End" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="MovDuration" HeaderText="Hour"  SortExpression="decDur" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="purpouse" HeaderText="Reason" SortExpression="purpouse" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                <asp:BoundField DataField="remarks" HeaderText="Remarks" SortExpression="remarks" ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="100"/>
                
                <asp:BoundField DataField="purpouseid" HeaderText="Purpouseid" SortExpression="purpouseid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="applicantenrol" HeaderText="Enrol" SortExpression="applicantenrol" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <%--<asp:BoundField DataField="unitid" HeaderText="Unitid" SortExpression="unitid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                <asp:BoundField DataField="jobstationid" HeaderText="Jobstationid" SortExpression="jobstationid" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />--%>
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