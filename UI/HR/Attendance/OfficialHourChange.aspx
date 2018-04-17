<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Attendance.OfficialHourChange" Codebehind="OfficialHourChange.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>::. Official Hour Change .::</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" /> 
    <script type="text/javascript">
        function CheckValidation() {
            var fromdate = document.forms["frmHourChange"]["txtFromDate"].value;
            var todate = document.forms["frmHourChange"]["txtToDate"].value;
            var reason = document.forms["frmHourChange"]["txtReason"].value;

            if (fromdate == null || fromdate == "") {
                alert("From date must be filled by valid formate (year-month-day).");
            }
            else if (todate == null || todate == "" || todate < fromdate) {
                alert("To date must be filled by valid formate (year-month-day).");
            }
            else if (reason == null || reason == "") {
                alert("Reason must be filled.");
            }
            else {
                document.getElementById("hdnAction").value = "1";
                __doPostBack();
            }
        }
    </script>

</head>
<body><form id="frmHourChange" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <CompositeScript>
        <Scripts>
            <asp:ScriptReference name="MicrosoftAjax.js"/>
		    <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		    <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts>
    </CompositeScript>
</asp:ScriptManager>
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
<%--=========================================Start My Code From Here======================================================--%>
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
                    DataSourceID="ODSJobStation" DataTextField="Text" DataValueField="value" OnSelectedIndexChanged="ddlJobStation_SelectedIndexChanged"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ODSJobStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                    TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue"
                    Type="Int32" /><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
             </tr>

             <tr>
                <td style="text-align:right;"><asp:Label ID="lblsftstatus" CssClass="lbl" runat="server" Text="Shift-Status : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlShiftStatus" runat="server" AutoPostBack="True" CssClass="dropdownList" OnSelectedIndexChanged="ddlShiftStatus_SelectedIndexChanged"
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
                 <td style="text-align:right;"><asp:Label ID="lblstart" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
                 <td><MKB:TimeSelector ID="tpkStart" runat="server" CssClass="txtBox" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
                 <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
                 <td><MKB:TimeSelector ID="tpkEnd" runat="server" CssClass="txtBox" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector></td>
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
                 <td style="text-align:right;"><asp:Label ID="lblreason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
                <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
                
                 <%--<asp:TextBox ID="txtContactsSearch" runat="server"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender"
                    runat="server" ServiceMethod="Getdata"  MinimumPrefixLength="1" CompletionInterval="1000"
                    EnableCaching="true" CompletionSetCount="1"
                    TargetControlID="txtContactsSearch" UseContextKey="True"</asp:AutoCompleteExtender>--%>
                    

                 <td >
                    <asp:Button ID="btnCancel" runat="server" CssClass="nextclick" Text="Cancel" OnClick="btnCancel_Click"/>
                    <a class="nextclick" onclick="CheckValidation()">Submit</a> 
                </td>
             </tr> 

           
         </table>
    </div>
    
<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>


</form></body>
</html>
