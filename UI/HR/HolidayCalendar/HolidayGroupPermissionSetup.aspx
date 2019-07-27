<%@ Page Language="C#" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="UI.HR.HolidayCalendar.HolidayGroupPermissionSetup" Codebehind="HolidayGroupPermissionSetup.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Holiday setup</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

   
    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
                var control = document.getElementById(ControlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false
                }
            }
        }
        function showDetails() {
            window.showModalDialog('HolidaySetupPopup.aspx', null, 'status:no;dialogWidth:576px;dialogHeight:350px;dialogHide:true;help:no;scroll:auto');
            //window.open('HolidaySetupPopup.aspx', null, 'status:no;dialogWidth:576px;dialogHeight:350px;dialogHide:true;help:no;scroll:auto');
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Holiday Details:</legend>
                                <div style="width: 850px; height: 60px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 80px; text-align: right">
                                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Holiday Name"></asp:Label>
                                            </td>
                                            <td style="width: 168px">
                                                <asp:DropDownList ID="ddlHolidayName" CssClass="DropDown" runat="server" Width="168px"
                                                    DataSourceID="odsHoliday" DataTextField="strHolidayName" DataValueField="intHolidayID">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlHolidayName"
                                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" CssClass="button" runat="server" OnClientClick="showDetails()"
                                                    OnClick="LinkButton1_Click">New</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 80px; text-align: right">
                                                <asp:Label ID="Label9" runat="server" Text="From" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" Width="60px" autocomplete="off"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" CssClass="cal_Theme1" Format="MM/dd/yyyy"
                                                    TargetControlID="txtFromDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label12" runat="server" CssClass="label" Text="To"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" Width="60px" autocomplete="off"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                                    Format="MM/dd/yyyy" TargetControlID="txtToDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtToDate"
                                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Permission Setup:</legend>
                                <div style="width: 850px; height: 440px">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 320px;">
                                                <table>
                                                    <tr>
                                                        <td style="width: 270px;">
                                                            <fieldset>
                                                                <legend>Select Group:</legend>
                                                                <asp:Panel ID="panGroup" runat="server" Width="270px" Height="100px" ScrollBars="Horizontal">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkAllGroup" Width="100%" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllGroup_CheckedChanged"
                                                                                    Text="Select All" />
                                                                                <asp:CheckBoxList ID="chkGroupList" runat="server" Width="100%" DataSourceID="odsEmployeeGroup"
                                                                                    DataTextField="strGroupName" DataValueField="intGroupID" RepeatColumns="2" RepeatDirection="Horizontal"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="chkGroupList_SelectedIndexChanged">
                                                                                </asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 270px;">
                                                            <fieldset>
                                                                <legend>Select Religion:</legend>
                                                                <asp:Panel ID="panReligion" runat="server" Width="270px" Height="100px" ScrollBars="Horizontal">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkAllReligion" Width="100%" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="chkAllReligion_CheckedChanged" Text="Select All" />
                                                                                <asp:CheckBoxList ID="chkReligionList" runat="server" Width="100%" DataSourceID="odsReligion"
                                                                                    DataTextField="strReligionName" DataValueField="intReligionID" RepeatColumns="2"
                                                                                    AutoPostBack="True" OnSelectedIndexChanged="chkReligionList_SelectedIndexChanged">
                                                                                </asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 550px;">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <fieldset>
                                                                <legend>Select Job Station:</legend>
                                                                <asp:Panel ID="panJobStation" runat="server" Width="100%" Height="220px" ScrollBars="Horizontal">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkAllJobstation" Width="100%" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="chkAllJobstation_CheckedChanged" Text="Select All" />
                                                                                <asp:CheckBoxList ID="chkJobStationList" runat="server" Width="100%" RepeatColumns="2"
                                                                                    DataSourceID="odsJobStation" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"
                                                                                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="chkJobStationList_SelectedIndexChanged">
                                                                                </asp:CheckBoxList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </fieldset>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%;">
                                                <fieldset>
                                                    <legend>Select Jobtype:</legend>
                                                    <asp:Panel ID="panJobType" runat="server" Width="100%" Height="150px" ScrollBars="Horizontal">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkAllJobType" Width="100%" runat="server" AutoPostBack="True"
                                                                        Text="Select All" OnCheckedChanged="chkAllJobType_CheckedChanged" />
                                                                    <asp:CheckBoxList ID="chkJobtypeList" runat="server" Width="100%" RepeatColumns="6"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="chkJobtypeList_SelectedIndexChanged"
                                                                        DataSourceID="odsJobType" DataTextField="Text" DataValueField="Value">
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </fieldset>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 80px;">
                        </td>
                        <td style="width: 60px">
                            <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" Width="60px"
                                OnClick="btnAdd_Click" ValidationGroup="VG" />
                        </td>
                        <td style="width: 60px">
                            <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Update" Width="60px"
                                OnClick="btnEdit_Click" ValidationGroup="VG" />
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsEmployeeGroup" runat="server" SelectMethod="GetAllEmployeeGroup"
                                TypeName="HR_BLL.Global.EmployeeGroup"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsJobStation" runat="server" SelectMethod="GetAllJobStation"
                                TypeName="HR_BLL.Global.JobStation"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsReligion" runat="server" SelectMethod="GetAllReligion"
                                TypeName="HR_BLL.Global.Religion"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsHoliday" runat="server" SelectMethod="GetAllHoliday"
                                TypeName="HR_BLL.HolidayCalendar.HolidaySetup"></asp:ObjectDataSource>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px;">
                        </td>
                        <td style="width: 60px">
                        </td>
                        <td style="width: 60px">
                        </td>
                        <td style="width: 60px">
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsJobType" runat="server" SelectMethod="GetAllJobtypeForDropdown"
                                TypeName="HR_BLL.Global.JobType"></asp:ObjectDataSource>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnUserId" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvHolliday" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                DataKeyNames="intHolidayID" SkinID="sknGrid2" Width="750px" OnRowDataBound="dgvHolliday_RowDataBound"
                                AllowPaging="True" DataSourceID="odsHolidayGroupPermission">
                                <Columns>
                                    <asp:TemplateField HeaderText="Holiday Name" SortExpression="strHolidayName" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHolidayName" runat="server" Text='<%# Bind("strHolidayName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnHolidayID_Grid" runat="server" Value='<%# Bind("intHolidayID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" SortExpression="strGroupName" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("strGroupName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnGroupID_Grid" runat="server" Value='<%# Bind("intGroupID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jobstation Name" SortExpression="strJobStationName"
                                        Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobstationName" runat="server" Text='<%# Bind("strJobStationName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnJobStationID_Grid" runat="server" Value='<%# Bind("intJobStationID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="270px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Religion" SortExpression="strReligionName" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReligionName" runat="server" Text='<%# Bind("strReligionName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnReligionID_Grid" runat="server" Value='<%# Bind("intReligionId") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="dteFromDate" HeaderText="From Date" ItemStyle-HorizontalAlign="Center"
                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" SortExpression="dteFromDate">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dteToDate" HeaderText="To Date" ItemStyle-HorizontalAlign="Center"
                                        DataFormatString="{0:MM/dd/yyyy}" ItemStyle-Width="100px" SortExpression="dteToDate">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col" style="width: 100px">
                                            Holiday Name
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Group Name
                                        </th>
                                        <th scope="col" style="width: 270px">
                                            Jobstation Name
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Religion
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            From Date
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            To Date
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsHolidayGroupPermission" runat="server" SelectMethod="GetAllHolidayGroupPermission"
                                TypeName="HR_BLL.HolidayCalendar.HolidayGroupPermission"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
