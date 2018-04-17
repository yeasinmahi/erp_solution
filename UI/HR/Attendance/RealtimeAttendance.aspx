<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealtimeAttendance.aspx.cs" Inherits="UI.HR.Attendance.RealtimeAttendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Real Time Attendance </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="frmrealtimeattendance" runat="server">
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
   
    <div class="leaveApplication_container"> 
        <div class="tabs_container"> Real Time Attendance <hr /><asp:HiddenField ID="hdnAction" runat="server" /></div>
        <table border="0px"; style="width:Auto;"; align="center" >

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
                <td><asp:DropDownList ID="ddlShiftStatus" runat="server" AutoPostBack="True" CssClass="dropdownList"
                    DataSourceID="odsTeam" DataTextField="strTeamName" DataValueField="intTeamId"></asp:DropDownList>                                       
                    <asp:ObjectDataSource ID="odsTeam" runat="server" SelectMethod="GetAllTeamByStationId" 
                    TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation"><SelectParameters>
                    <asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>                                       
                </td>

                <td style="text-align:right;"><asp:Label ID="lblshift" CssClass="lbl" runat="server" Text="Shift : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlPresentShift" runat="server" CssClass="dropdownList" DataSourceID="odsShift" DataTextField="strShiftName" 
                    DataValueField="intShiftId"></asp:DropDownList> <asp:ObjectDataSource ID="odsShift" runat="server" 
                    SelectMethod="GetShiftInformationByTeamId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
                    <SelectParameters><asp:ControlParameter ControlID="ddlShiftStatus" Name="intTeamId" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters></asp:ObjectDataSource>
                </td>
            </tr>

            <tr>
                <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
                <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" CssClass="dropdownList">
                    <asp:ListItem Selected="True" Value="P">Present</asp:ListItem><asp:ListItem Value="A">Absent</asp:ListItem>
                    </asp:DropDownList>
                </td>

                <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
                <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                  <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>                                                        
                </td>
            </tr>

            <tr>                
                <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" class="nextclick" style="font-size:11px;" Text="Show" OnClick="Show_Click"/></td>
            </tr>

            <tr><td colspan="4">
            <asp:GridView ID="dgvRealtimeSummary" runat="server" PageSize="13" AutoGenerateColumns="False" AllowPaging="True" CaptionAlign="Top" Caption="Realtime Punch Summary"
              EmptyDataText="There are no data records to display." SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsrealtimeSummary" BackColor="White">
              <Columns>
                <asp:BoundField DataField="Enroll" HeaderText="Enroll" ItemStyle-HorizontalAlign="Center" SortExpression="Enroll">
                <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:BoundField>
                
                <asp:BoundField DataField="Code" HeaderText="Employee-Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
                <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
                
                <asp:BoundField DataField="Name" HeaderText="Employee-Name" ItemStyle-HorizontalAlign="Center" SortExpression="Name">
                <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:BoundField>
                
                <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="Department">
                <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
                
                <asp:BoundField DataField="Designation" HeaderText="Designation" ItemStyle-HorizontalAlign="Center" SortExpression="Designation">
                <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
                
                <asp:BoundField DataField="Punchtime" HeaderText="Punchtime" ItemStyle-HorizontalAlign="Center" SortExpression="Punchtime">
                <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:BoundField>
                                 
              </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsrealtimeSummary" runat="server" SelectMethod="GetRealtimeAttendance" TypeName="HR_BLL.Attendance.EmployeeAttendance" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlUnit" DefaultValue="" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlJobStation" DefaultValue="" Name="station" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlPresentShift" DefaultValue="" Name="shift" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="txtDate" DefaultValue="" Name="showdate" PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="ddlType" DefaultValue="" Name="showtype" PropertyName="SelectedValue" Type="String" />
            </SelectParameters></asp:ObjectDataSource>
            </td></tr>
        </table>

    </div> 
 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
