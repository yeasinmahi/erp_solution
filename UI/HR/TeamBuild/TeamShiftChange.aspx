<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamShiftChange.aspx.cs" Inherits="UI.HR.TeamBuild.TeamShiftChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>.: Employee Shift Change :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 

<script type="text/javascript">
    $(document).ready(function () {
        SearchText();
    });
    function SearchText() {
        $("#txtEmployeeSearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "TeamShiftChange.aspx/GetAutoCompleteData",
                    data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
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
    function Changed() {
        document.getElementById('hdfSearchBoxTextChange').value = 'true';
    }
    function CheckValidation() {

        var fromdate = document.forms["frmEmployeeShiftChange"]["txtFromDate"].value;
        var todate = document.forms["frmEmployeeShiftChange"]["txtToDate"].value;
        if (fromdate == null || fromdate == "") {
            alert("From date must be filled by valid formate (year-month-day).");
        }
        else if (todate == null || todate == "" || todate < fromdate) {
            alert("To date must be filled by valid formate (year-month-day).");
        }
        else {
            document.getElementById("hdnAction").value = "1";
            __doPostBack();
        }

    }
</script>
    
</head>

<body>
    <form id="frmEmployeeShiftChange" runat="server">
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
<%--=========================================Start My Code From Here====================DefaultValue="11754"===========================--%>
    <div class="divs_content_container">
    <table border="0px"; style="width:Auto"; align="center" >
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label></td>
        <td>
            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        </td>
        <td style="text-align:right;"><asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        </tr>
                
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblshiftstatus" CssClass="lbl" runat="server" Text="Shift-Status : "></asp:Label></td>
        <td><asp:TextBox ID="txtShiftStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblcurrentshift" CssClass="lbl" runat="server" Text="Current-Shift : "></asp:Label></td>
        <td><asp:TextBox ID="txtCurrentShift" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
        </tr>
    </table> 
    <div class="tabs_container"> Employee Shift Change :<hr /><asp:HiddenField ID="hdnAction" runat="server" /></div>
    <table border="0px"; style="width:Auto"; align="center" >

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" 
                    DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
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
            <td><asp:DropDownList ID="ddlShiftStatus" runat="server" AutoPostBack="True" CssClass="dropdownList"  DataSourceID="odsTeam" DataTextField="strTeamName" DataValueField="intTeamId"></asp:DropDownList>                                       
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
           <cc1:CalendarExtender ID="CEE" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender> 
           </td>
        </tr>

        <tr>
                 <td colspan="4">
                    <asp:Button ID="btnCancel" runat="server" CssClass="nextclick" Text="Cancel" OnClick="btnCancel_Click"/>
                    <a class="nextclick" onclick="CheckValidation()">Submit</a> 
                </td>
             </tr> 
        
    </table>
</div>

<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
