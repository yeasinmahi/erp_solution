<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HallBookingEntry.aspx.cs" Inherits="UI.HR.TourPlan.HallBookingEntry" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtParticipantinput = document.forms["frmprilv"]["txtParticipant"].value;
            //var txtParticipantcapacity = document.getElementById('lblCapacitytotal').textContent;
            var txtParticipantcapacity = parseFloat(document.getElementById('lblCapacitytotal').textContent);
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

            var txtDteFrom = document.forms["frmprilv"]["txtDteFrom"].value;
            var txtDteTo = document.getElementById("DATE").value;
            if (txtParticipantinput == null || txtParticipantinput == "") {
                alert("Please Input number of participants");
                document.getElementById("txtParticipant").focus();
            }
           
           
            else if (txtDteFrom < txtDteTo) {
                alert("Booking date can not less than Current Day");
                document.getElementById("txtDteFrom").focus();
            }



            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
      
        
    </script>
    <script type="text/javascript">

    function ShowModalPopup() {
        $find("ModalBehaviour").show();
    }

    function HideModalPopup() {
        $find("ModalBehaviour").hide();
    }

</script>
     <style type="text/css">
	
     .tooltip {
        position: absolute;
        margin-left: -1050px;
        margin-top: -100px;
        z-index: 3;
        display: none;
        background: #A4D162;
        border:dotted;
        padding:5px;
        font-size:8pt;
        font-family:Verdana, Geneva, Tahoma, sans-serif;
        font-size:larger
     }

    td
    {
        cursor:pointer;
        /*background-color:darkgoldenrod;*/
        
    }
</style>
</head>
<body>
    <form id="frmprilv" runat="server">
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
    <div class="leaveApplication_container"><b>Meeting Hall Room Booking Entry: </b><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnAppId" runat="server" /><asp:HiddenField ID="hdncontact" runat="server" />
          <asp:HiddenField ID="hdnEmployeeID" runat="server" />
        <asp:HiddenField ID="hdnUserID" runat="server" /> <asp:HiddenField ID="hdfEmpCode" runat="server" /> <asp:HiddenField ID="hdnName" runat="server" /><asp:HiddenField ID="hdnUnitName" runat="server" />
       <asp:HiddenField ID="hdnDepartmentName" runat="server" /><asp:HiddenField ID="hdnDesignation" runat="server" />
        <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
    <table style="width:Auto";>
        <tr class="tblroweven">
         <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox" OnTextChanged="txtDteFrom_TextChanged"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender></td>   
       
         <td style="text-align:right;" colspan="2"><asp:Label ID="lblLevelNo" CssClass="lbl" runat="server" Text="Level : "></asp:Label>
        <asp:Label ID="lblLevelnumber" Font-Bold="true" Width="20px" Height="20px"  CssClass="lbl"  runat="server"></asp:Label>
        <asp:Label ID="lblCapacity"  CssClass="lbl" runat="server" Text=", Capacity : "></asp:Label>
        <asp:Label ID="lblCapacitytotal" Font-Bold="true"  Width="20px" Height="20px" CssClass="lbl" runat="server"></asp:Label>
        <asp:Label ID="lblprojectorystatus"  CssClass="lbl" runat="server" Text=" ,Projector: "></asp:Label>
        <asp:Label ID="lblProjector" Font-Bold="true"  Width="20px" Height="20px" CssClass="lbl" runat="server"></asp:Label>
        <asp:Label ID="Label1"  CssClass="lbl" runat="server" Text=" , Booking: "></asp:Label>
         <asp:Image ID="imgSignal" ImageUrl="" Width="20px" Height="20px" runat="server" />

         </td></tr>
        <tr  class="tblrowOdd">
           <td style="text-align:right;"><asp:Label ID="lblLocation" CssClass="lbl" runat="server" Text="Location : "></asp:Label></td>

             <td><asp:DropDownList ID="ddlLocation" AutoPostBack="True" runat="server" CssClass="ddList" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"></asp:DropDownList>
       </td>

        <td style="text-align:right;"><asp:Label ID="lblDepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
        <td><asp:DropDownList ID="drdlDepartment" AutoPostBack="true" runat="server" CssClass="ddList" DataSourceID="odsdepartment" DataTextField="strDepatrment" DataValueField="intDepartmentID"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsdepartment" runat="server" SelectMethod="GetAllDepartment" TypeName="HR_BLL.Global.Department"></asp:ObjectDataSource> 
          
            </td></tr>
        <tr class="tblroweven">
             <td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
        <td><asp:DropDownList ID="drdlUnit" runat="server" CssClass="ddList" DataSourceID="odsunitpermissionbyenrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsunitpermissionbyenrol" runat="server" SelectMethod="GetUnitpermissionbaseemployeeid" TypeName="HR_BLL.TourPlan.TourPlanning">
        <SelectParameters>
        <asp:SessionParameter Name="enrol" SessionField="sesUserID" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td>
        <td style="text-align:right;"><asp:Label ID="lblParticapants" CssClass="lbl" runat="server" Text="Total Participants : "></asp:Label></td>
        <td><asp:TextBox ID="txtParticipant" runat="server" CssClass="txtBox"></asp:TextBox></td>
          
        </tr>
        <tr  class="tblrowOdd">
        <td style="text-align:right;"><asp:Label ID="lblstrt" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmStart" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
        <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmEnd" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td></tr>
     



         <tr class="tblroweven">
        <td style="text-align:right;" colspan="4">
            <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit"  OnClientClick = "Confirm()" OnClick="btnSubmit_Click" /> </td>
                     
        </tr>
       </table>
        <table>
    
         <tr class="tblrowOdd">
        <td style="text-align:right;">
             <asp:Label ID="lblMonthName" Font-Size="Larger" BackColor="SandyBrown"  CssClass="lbl"  runat="server" Text="Month  : "></asp:Label>
        </td>
              <td style="text-align:right;">
             <asp:Label ID="lblSelectMonth" Font-Size="Larger" BackColor="SandyBrown"  CssClass="lbl"  runat="server"></asp:Label>
        </td>        
        </tr>

       </table>
    
          
       
        <table>
        <tr>
        <td><asp:Calendar ID="Calendar1" runat="server" ShowGridLines="true"  ShowTitle="true" ShowNextPrevMonth="true" DayNameFormat="Full" SelectedDate="<%# DateTime.Today %>"  FirstDayOfWeek="Sunday" TitleStyle-Wrap="true" Font-Size="15px" Font-Bold="true" ForeColor="#000000" >
        <TodayDayStyle Font-Bold="True"  ForeColor="000" BackColor="#EAEAEA"></TodayDayStyle>
        <DayStyle   BorderWidth="1px" Font-Size="11px" HorizontalAlign="Left" Width="500px" ForeColor="#000" BorderStyle="Solid" BorderColor="Pink" BackColor="#EAEAEA"></DayStyle>
        <DayHeaderStyle ForeColor="#000"></DayHeaderStyle><SelectedDayStyle Font-Bold="True" ForeColor="#333333"
        BackColor="#EAEAEA"></SelectedDayStyle>
        <WeekendDayStyle ForeColor="Black" BackColor="#EAEAEA"></WeekendDayStyle>
        <OtherMonthDayStyle ForeColor="#EAEAEA" BackColor="#EAEAEA" Font-Size="0px" Width="0px" Height="0px" ></OtherMonthDayStyle>
        </asp:Calendar>
        

        </div><br />
        <div id="btn" style="text-align:center;"><a class="nextclick" style="cursor:pointer; font-size:10px;" href="#" onclick="Print()">Print</a></div>
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