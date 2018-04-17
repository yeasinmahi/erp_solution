<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HolidayCalendar.aspx.cs" Inherits="UI.HR.HolidayCalendar.HolidayCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Holiday Insertion :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript" src="../../Content/JS/scriptHoliday.js"></script>
  
</head>
<body>
    <form id="frmholiday" runat="server">
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
        <div class="tabs_container"> Holyday Setup :<hr /></div>
        <table border="0"; style="width:Auto;";>

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
            <td style="text-align:right;"><asp:Label ID="lblgroup" CssClass="lbl" runat="server" Text="Employee-Group : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdownList" AutoPostBack="false"
                DataSourceID="ODSEmpGroup" DataTextField="strGroupName" DataValueField="intGroupID"></asp:DropDownList>
                <asp:ObjectDataSource ID="ODSEmpGroup" runat="server" SelectMethod="GetAllEmployeeGroup"
                TypeName="HR_BLL.Global.EmployeeGroup"></asp:ObjectDataSource>
            </td>
            <td style="text-align:right;"><asp:Label ID="lblstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlJobStatus" runat="server" AutoPostBack="True" CssClass="dropdownList"
                    DataSourceID="ODSJobType" DataTextField="strJobType" DataValueField="intJobTypeID"></asp:DropDownList>
                <asp:ObjectDataSource ID="ODSJobType" runat="server" SelectMethod="GetJobTypeByUnit"
                TypeName="HR_BLL.Global.JobType" OldValuesParameterFormatString="original_{0}">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                Type="Int32" /></SelectParameters></asp:ObjectDataSource>
            </td>
            </tr>

            <tr>
            <td style="text-align:right;"><asp:Label ID="lblholiday" CssClass="lbl" runat="server" Text="Holiday List : "></asp:Label></td>
            <td><asp:DropDownList ID="ddlHoliday" runat="server" CssClass="dropdownList" DataSourceID="odsholidaylist" 
            DataValueField="intHolidayID" DataTextField="strHolidayName"></asp:DropDownList><asp:ObjectDataSource ID="odsholidaylist" 
            runat="server" SelectMethod="GetHolidayList" TypeName="HR_BLL.Global.Holiday"></asp:ObjectDataSource></td>
            <td style="text-align:right;"><asp:Label ID="lblfrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
            <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="FRMDT" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate">
            </cc1:CalendarExtender> 
            </td>
            </tr>
            
            <tr><td style="text-align:right;"><asp:Label ID="ibltodate" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
            <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <cc1:CalendarExtender ID="TODT" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender> 
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnAdd" runat="server" class="nextclick" style="font-size:11px;" 
            Text="ADD" OnClick="btnAdd_Click"  OnClientClick = "Confirm()"/> <asp:HiddenField ID="hdnconfirm" runat="server"/></td>
            </tr>

            <tr><td colspan="4" style="text-align:justify">
            <asp:GridView ID="dgvholiday" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" BorderColor="#999999" 
            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate><asp:HiddenField ID="hdnstation" runat="server" Value='<%# Eval("stationid") %>' />
            <asp:HiddenField ID="hdngroup" runat="server" Value='<%# Eval("groupid") %>'/>
            <asp:HiddenField ID="hdnjtype" runat="server" Value='<%# Eval("jtypeid") %>'/></ItemTemplate></asp:TemplateField> 

            <asp:BoundField DataField="station" HeaderText="Station" ItemStyle-HorizontalAlign="Center" SortExpression="station">
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:BoundField>
            <asp:BoundField DataField="group" HeaderText="Group" ItemStyle-HorizontalAlign="Center" SortExpression="group">
            <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:BoundField>
             <asp:BoundField DataField="jtype" HeaderText="Job-Type" ItemStyle-HorizontalAlign="Center" SortExpression="jtype">
            <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>            
            <asp:BoundField DataField="fromdte" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="fromdte" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
            <asp:BoundField DataField="todte" HeaderText="To-Date" ItemStyle-HorizontalAlign="Center" SortExpression="todte" DataFormatString="{0:yyyy-MM-dd}">
            <ItemStyle HorizontalAlign="Left"  Width="90px" /></asp:BoundField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Action" >
            <ItemTemplate><asp:Button ID="btnSave" runat="server" class="nextclick" style="cursor:pointer; font-size:10px;" CommandArgument='<%# Container.DataItemIndex %>'
            Text="Delete" OnClick="Delete_Click"/></ItemTemplate> <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr>

            <tr><td style="text-align:right;" colspan="4"><asp:Button ID="btnSubmit" runat="server" 
            class="nextclick" style="font-size:11px;" Text="SUBMIT" OnClick="btnSubmit_Click"/></td>
            </tr>

        </table>
        </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
