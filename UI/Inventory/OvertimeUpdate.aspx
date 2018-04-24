<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OvertimeUpdate.aspx.cs" Inherits="UI.Inventory.OvertimeUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<script>
    function GetTimeSpan() {
        var defaultDate = "1/1/1970 ";
        var end = document.getElementById('txtend').value;
        var start = document.getElementById('txtstrt').value;
        console.log("start " + start);
        console.log("End " + end);
        var difference = new Date(new Date(defaultDate + end) - new Date(defaultDate + start)).toUTCString().split(" ")[4];
        console.log("Diff " + difference);
        document.getElementById("txtMovDuration").innerText = difference;
        $('#txtMovDuration').val(difference);
    }
    </script>
     <script type="text/javascript">
         function pageLoad(sender, args) {
            $(document).ready(function () {
                SearchText();
                $('#txtstrt').timepicker();
                $('#txtend').timepicker();
                console.log("dom Ready");
            });
        }
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "OvertimeUpdate.aspx/GetAutoCompleteData",
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
   <script>
       function Confirm() {
           document.getElementById("hdnconfirm").value = "0";
           var txtEmployeeSearch = document.forms["frmpdv"]["txtFullName"].value;
           var txtDteFrom = document.forms["frmpdv"]["txtFromDate"].value;
           //    if (txtDteFrom == null || txtDteFrom == "") {
           //        alert("From date must be filled by valid formate (yyyy-MM-dd).");
           //        //document.getElementById("txtDteFrom").focus();
           //    }
           //else if (txtEmployeeSearch == null || txtEmployeeSearch == "") {
           //        alert("Please select a valid employee.");
           //        //document.getElementById("txtEmployeeSearch").focus();
           //    }


           //    else {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
           if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
           else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
           //}
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
    <div class="tabs_container"> Overtime entry (Driver & Office Assistants) :<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="HiddenField3" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >    
             <tr class="tblroweven">
                        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Date:  "></asp:Label><span style="color:red">*</span></td>
                        <td><asp:TextBox ID="txtFromDate" placeholder="Click for date selection" Width="300px" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                  <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
                    <td><asp:TextBox ID="txtstrt" runat="server" CssClass="txtBox" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtstrt').timepicker();</script></td>
                 </tr>
             <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
                    <td><asp:TextBox ID="txtend" runat="server" CssClass="txtBox" Width="300px" onchange="GetTimeSpan()"></asp:TextBox><script>$('#txtend').timepicker();</script></td> 
                    <td style="text-align:right"><asp:Label ID="lblTotalMovementDuraion"  CssClass="lbl" runat="server" Text="Movement.D (Hour) "  ></asp:Label></td>
                    <td> <asp:TextBox ID="txtMovDuration"  AutoPostBack="false"   runat="server"  Enabled="false"   CssClass="txtBox" ></asp:TextBox></td>      
              </tr>
                   <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name" AutoCompleteType="Search"  Font-Bold="true" CssClass="txtBox" Width="300px" AutoPostBack="True"></asp:TextBox>
            <span style="color:red">*</span> </td>
            <td style="text-align:right;"><asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Code: "></asp:Label> </td>
            <td><asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
           </tr> 
            <tr class="tblroweven"> 
           <td style="text-align:right;"><asp:Label ID="lblEnrolNumber" CssClass="lbl" runat="server" Text="Enrol: "></asp:Label> </td>
            <td ><asp:TextBox ID="txtAplicnEnrol" runat="server" Font-Bold="true" BackColor="#ffffcc" Width="300px" CssClass="txtBox" ReadOnly="true"></asp:TextBox> </td>
            <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation: "></asp:Label> </td>
            <td><asp:TextBox ID="txtDesignation" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
           
           </tr>
             <tr class="tblrowOdd">
            
            <td style="text-align:right;" colspan="4">
                <asp:Button ID="btnShow" runat="server" class="nextclick" Text="Prev. Data" OnClientClick = "Confirm()" OnClick="btnShow_Click" BackColor="#ffffcc" />
            <asp:Button ID="btnUpdate" runat="server" BackColor="#ffcccc" class="nextclick"  Font-Bold="true" Text="Update"   OnClick="btnUpdate_Click" /> 
             </td>
             </tr>
             </table>
             </div>

         <div class="leaveApplication_container"> 
             <table>



          <tr class="tblroweven"><td>
               <asp:GridView ID="grdvOvertimePreviousData" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" OnRowDataBound="grdvOvertimePreviousData_RowDataBound" ForeColor="Black" OnPageIndexChanging="grdvOvertimePreviousData_PageIndexChanging" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                     

                       <asp:BoundField DataField="dtdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="BillDate" SortExpression="dtdate" ItemStyle-HorizontalAlign="Center"  >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="starttime" DataFormatString="{0:HH:mm}" HeaderText="StartTime" SortExpression="starttime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="endtime" DataFormatString="{0:HH:mm}" HeaderText="EndTime" SortExpression="endtime" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="monsalary" HeaderText="salary" SortExpression="monsalary" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center"  />
                      </asp:BoundField>
                       <asp:BoundField DataField="dechour"  HeaderText="hour"  SortExpression="dechour" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                      

                       <asp:BoundField DataField="Otcount" HeaderText="Otcount" SortExpression="Otcount" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="monhramount" HeaderText="hramount" SortExpression="monhramount" ItemStyle-HorizontalAlign="Center" >
                      <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>

                       <asp:BoundField DataField="mondailyamnt" HeaderText="mondailyamnt" SortExpression="mondailyamnt" ItemStyle-HorizontalAlign="Center" >
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
     </table>
            </div>
 <%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
