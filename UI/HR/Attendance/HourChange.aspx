<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HourChange.aspx.cs" Inherits="UI.HR.Attendance.HourChange" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Official Hour Change .::</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function ValidationnSubmit() {

            var frmDt = document.forms["frmHourChange"]["txtFromDate"].value;
            var toDt = document.forms["frmHourChange"]["txtToDate"].value;
            var reason = document.forms["frmHourChange"]["txtReason"].value;

            if (frmDt == null || frmDt == "") { 
                alert("From date must be filled by valid formate (year-month-day).");
            }
            else if (toDt == null || toDt == "") {
                alert("To date must be filled by valid formate (year-month-day).");
            }
            else if (toDt < frmDt) {
                alert("To date must be greater than from date by valid formate (year-month-day).");
            }
            else if (reason.length <= 0 || reason.length > 100) {
                alert("Reason must be filled and max length is 100.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to processed this submition?")) {
                    confirm_value.value = "Yes";
                    document.getElementById("hdnAction").value = "1";
                    __doPostBack();
                }
                else {
                    confirm_value.value = "No";
                }
            }
        }

        function Exit() {
            document.getElementById("hdnAction").value = "2";
            __doPostBack();
        }
    </script>




</head>
<body>
    <form id="frmHourChange" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
     <div class="divs_content_container"> 
        <div class="tabs_container"> Official Hour Change :<hr /><asp:HiddenField ID="hdnAction" runat="server" /></div>
         <table border="0px"; style="width:Auto"; align="center" >
             <tr>
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
                    DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
                    OldValuesParameterFormatString="original_{0}"><SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/>
                    </SelectParameters></asp:ObjectDataSource>
                </td>

                <td style="text-align:right;"><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="dropdownList"
                    DataSourceID="ODSJobStation" DataTextField="Text" DataValueField="value"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSJobStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                    TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                    Type="Int32" /><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
             </tr>

             <tr>
                <td style="text-align:right;"><asp:Label ID="lblsftstatus" CssClass="lbl" runat="server" Text="Shift-Status : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlShiftStatus" runat="server" AutoPostBack="True" CssClass="dropdownList"
                    DataSourceID="odsTeam" DataTextField="strTeamName" DataValueField="intTeamId"></asp:DropDownList>                                       
                    <asp:ObjectDataSource ID="odsTeam" runat="server" SelectMethod="GetAllTeamByStationId" 
                    TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation"><SelectParameters>
                    <asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>                                       
                </td>

                <td style="text-align:right;"><asp:Label ID="lblshift" CssClass="lbl" runat="server" Text="Present-Shift : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlPresentShift" runat="server" CssClass="dropdownList" DataSourceID="odsShift" DataTextField="strShiftName" 
                    DataValueField="intShiftId"></asp:DropDownList> <asp:ObjectDataSource ID="odsShift" runat="server" 
                    SelectMethod="GetShiftInformationByTeamId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
                    <SelectParameters><asp:ControlParameter ControlID="ddlShiftStatus" Name="intTeamId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
                </tr>

             <tr>
                <td style="text-align:right;"><asp:Label ID="lblfromdate" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CES" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>                                                        
                </td>

                <td style="text-align:right;"><asp:Label ID="lbltodate" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CEE" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate">
                    </cc1:CalendarExtender> 
                </td>
             </tr>

             <tr>
                 <td style="text-align:right;"><asp:Label ID="lblstart" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
                 <td><MKB:TimeSelector ID="tpkStart" runat="server" CssClass="txtBox" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
                 <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
                 <td><MKB:TimeSelector ID="tpkEnd" runat="server" CssClass="txtBox" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
             </tr>

             <tr>
                 <td style="text-align:right;"><asp:Label ID="lblreason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
                <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
                
                 <td style="text-align:right;" colspan="2">
                     <a class="nextclick" onclick="ValidationnSubmit()">Submit</a>                     
                     <a class="nextclick" onclick="Exit()">Cancel</a>  
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
