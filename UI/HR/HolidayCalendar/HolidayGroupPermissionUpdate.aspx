<%@ Page Language="C#" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="UI.HR.HolidayCalendar.HolidayGroupPermissionUpdate" Codebehind="HolidayGroupPermissionUpdate.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Holiday Group Permission Update</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form runat="server">
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
                    &nbsp;
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
                                <legend>Searching Option:</legend>
                                <div style="width: 810px;">
                                    <asp:Panel ID="panSearch" runat="server">
                                        <table style="width:800px;">
                                            <tr>
                                                <td style="width:80px">
                                                    <asp:Label ID="Label1" runat="server" Text="Holiday" CssClass="label"></asp:Label>
                                                </td>
                                                <td style="width:150px">
                                                    <asp:DropDownList ID="ddlHoliday" runat="server" CssClass="DropDown" Width="150px"
                                                        AutoPostBack="True" DataSourceID="odsHoliday" DataTextField="Text" DataValueField="Value"
                                                        OnSelectedIndexChanged="ddlHoliday_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width:40px">
                                                    <asp:CheckBox ID="chkAllHoliday" runat="server" Text="All" CssClass="rdo" AutoPostBack="True"
                                                        OnCheckedChanged="chkAllHoliday_CheckedChanged" />
                                                </td>
                                                <td style="width:142px">
                                                    <asp:HiddenField ID="hdnHoliday" runat="server" />
                                                </td>
                                                <td style="width:142px">
                                                    <asp:ObjectDataSource ID="odsHoliday" runat="server" SelectMethod="LoadHolidayForDropdown"
                                                        TypeName="HR_BLL.Global.Holiday"></asp:ObjectDataSource>
                                                </td>
                                                <td style="width:145px">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:Button ID="btnBackToSetupPage" runat="server" Text="Back To Holiday Permission" Width="160px"
                                                        onclick="btnBackToSetupPage_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Group" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlGroupID" runat="server" CssClass="DropDown" Width="150px"
                                                        AutoPostBack="True" DataSourceID="odsGroup" DataTextField="strGroupName" DataValueField="intGroupID"
                                                        OnSelectedIndexChanged="ddlGroupID_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkAllGroup" runat="server" Text="All" CssClass="rdo" AutoPostBack="True"
                                                        OnCheckedChanged="chkAllGroup_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnGroupID" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:ObjectDataSource ID="odsGroup" runat="server" SelectMethod="GetAllEmployeeGroup"
                                                        TypeName="HR_BLL.Global.EmployeeGroup"></asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Jobstation" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlJobstation" runat="server" CssClass="DropDown" Width="150px"
                                                        AutoPostBack="True" DataSourceID="odsJobstation" DataTextField="strJobStationName"
                                                        DataValueField="intEmployeeJobStationId" OnSelectedIndexChanged="ddlJobstation_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkAllJobsation" runat="server" Text="All" CssClass="rdo" AutoPostBack="True"
                                                        OnCheckedChanged="chkAllJobsation_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnjobsationId" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:ObjectDataSource ID="odsJobstation" runat="server" SelectMethod="GetAllJobStation"
                                                        TypeName="HR_BLL.Global.JobStation"></asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Religion" CssClass="label"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="DropDown" Width="150px"
                                                        AutoPostBack="True" DataSourceID="odsReligion" DataTextField="strReligionName"
                                                        DataValueField="intReligionID" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkAllReligion" runat="server" Text="All" CssClass="rdo" AutoPostBack="True"
                                                        OnCheckedChanged="chkAllReligion_CheckedChanged" />
                                                </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnReligionId" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:ObjectDataSource ID="odsReligion" runat="server" SelectMethod="GetAllReligion"
                                                        TypeName="HR_BLL.Global.Religion"></asp:ObjectDataSource>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvHolliday" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                DataKeyNames="intHolidayID,intGroupID,intJobStationID,intReligionId,dteFromDate,dteToDate"
                                SkinID="sknGrid2" Width="750px" AllowPaging="True" DataSourceID="odsHolidayGroupPermission"
                                OnSelectedIndexChanged="dgvHolliday_SelectedIndexChanged" OnRowCancelingEdit="dgvHolliday_RowCancelingEdit"
                                OnRowEditing="dgvHolliday_RowEditing" OnRowUpdated="dgvHolliday_RowUpdated" OnRowDeleted="dgvHolliday_RowDeleted">
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
                                        <ItemStyle HorizontalAlign="Center" Width="220px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Religion" SortExpression="strReligionName" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReligionName" runat="server" Text='<%# Bind("strReligionName") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnReligionID_Grid" runat="server" Value='<%# Bind("intReligionId") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date" SortExpression="dteFromDate">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFromDate_Display" Enabled="false" runat="server" Text='<%# bind("dteFromDate") %>'
                                                Width="60px"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtFromDate" AutoPostBack="false" runat="server" Text='<%# bind("dteFromDate") %>'
                                                Width="60px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTExFromDate" runat="server" FilterType="Custom, Numbers"
                                                TargetControlID="txtFromDate" ValidChars="123456789-/">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CE_FromDate" runat="server" CssClass="cal_Theme1"
                                                Format="yyyy/MM/dd" TargetControlID="txtFromDate">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:CompareValidator ID="CVFromDate" runat="server" ControlToValidate="txtFromDate"
                                                Display="Dynamic" ErrorMessage="Invalid Date" Operator="DataTypeCheck" Type="Date">
                                            </asp:CompareValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="CVFromDate_ValidatorCalloutExtender" runat="server"
                                                Enabled="True" TargetControlID="CVFromDate">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date" SortExpression="dteToDate">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblFromDate" runat="server" Text='<%# bind("dteToDate") %>'></asp:Label>--%>
                                            <asp:TextBox ID="txtToDate_Display" runat="server" Text='<%# bind("dteToDate") %>'
                                                Width="60px" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtToDate" runat="server" Text='<%# bind("dteToDate") %>' Width="60px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTEx_ToDate" runat="server" FilterType="Custom, Numbers"
                                                TargetControlID="txtToDate" ValidChars="123456789-/">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <ajaxToolkit:CalendarExtender ID="CE_ToDate" runat="server" CssClass="cal_Theme1"
                                                Format="yyyy/MM/dd" TargetControlID="txtToDate">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:CompareValidator ID="CompareValidator_ToDate" runat="server" ControlToValidate="txtToDate"
                                                Display="Dynamic" ErrorMessage="Invalid Date" Operator="DataTypeCheck" Type="Date">
                                            </asp:CompareValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="CompareValidator_ToDate_ValidatorCalloutExtender"
                                                runat="server" Enabled="True" TargetControlID="CompareValidator_ToDate">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Update" UpdateText="Update"
                                        HeaderText="Update" HeaderStyle-ForeColor="RoyalBlue" ValidationGroup="VG" />
                                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" DeleteText="Delete"
                                        HeaderText="Delete" HeaderStyle-ForeColor="RoyalBlue" ValidationGroup="VG" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Lime;height:50px">
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            Holiday Name
                                        </th>
                                        <th scope="col" style="width: 95px;color:RoyalBlue">
                                            Group Name
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            Jobstation Name
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            Religion
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            From Date
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            To Date
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            Update
                                        </th>
                                        <th scope="col" style="width: 100px;color:RoyalBlue">
                                            Delete
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsHolidayGroupPermission" runat="server" SelectMethod="GetAllHolidayGroupPermissionForUpdateAndDelete"
                                TypeName="HR_BLL.HolidayCalendar.HolidayGroupPermission" DeleteMethod="DeleteHolidayGroupPermission"
                                OldValuesParameterFormatString="original_{0}" UpdateMethod="UpdateHolidayGroupPermission">
                                <DeleteParameters>
                                    <asp:ControlParameter ControlID="hdnUserID" Name="intUserID" PropertyName="Value"
                                        Type="Int32" />
                                    <asp:Parameter Name="original_intGroupID" Type="Int32" />
                                    <asp:Parameter Name="original_intJobStationID" Type="Int32" />
                                    <asp:Parameter Name="original_intHolidayID" Type="Int32" />
                                    <asp:Parameter Name="original_intReligionId" Type="Int32" />
                                    <asp:Parameter Name="original_dteFromDate" Type="DateTime" />
                                    <asp:Parameter Name="original_dteToDate" Type="DateTime" />
                                </DeleteParameters>
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnHoliday" Name="intHolidayID" PropertyName="Value"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="hdnGroupID" Name="intGroupID" PropertyName="Value"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="hdnjobsationId" Name="intJobStationID" PropertyName="Value"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="hdnReligionId" Name="intReligionId" PropertyName="Value"
                                        Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:ControlParameter ControlID="hdnUserID" Name="intUserID" PropertyName="Value"
                                        Type="Int32" />
                                    <asp:Parameter Name="original_intGroupID" Type="Int32" />
                                    <asp:Parameter Name="original_intJobStationID" Type="Int32" />
                                    <asp:Parameter Name="original_intHolidayID" Type="Int32" />
                                    <asp:Parameter Name="original_intReligionId" Type="Int32" />
                                    <asp:Parameter Name="dteFromDate" Type="DateTime" />
                                    <asp:Parameter Name="dteToDate" Type="DateTime" />
                                    <asp:Parameter Name="original_dteFromDate" Type="DateTime" />
                                    <asp:Parameter Name="original_dteToDate" Type="DateTime" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
