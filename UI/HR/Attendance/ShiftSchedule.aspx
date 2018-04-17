<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Attendance.ShiftSchedule" Codebehind="ShiftSchedule.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html >
<head runat="server">
    <title>.: Shift Active-Inactive :.</title>
   <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
</head>
<body>
    <form id="frmSOC" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;"><b><br /><br /><br />Shift Active-Inactive Schedule Information</b></div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here======================================================--%>

    <div style="height: auto; width:500px; border: 2px solid #000; padding-top:10px;">
        <table border="0px" style="width: 500px; text-align:justify;">
    <tr><td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Unit-Name : "></asp:Label></td>
    <td  colspan="3">
    <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropDown" DataSourceID="ODSUnit" DataTextField="strUnit" DataValueField="intUnitID">
    </asp:DropDownList><asp:ObjectDataSource ID="ODSUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit"
    OldValuesParameterFormatString="original_{0}"><SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
    </SelectParameters></asp:ObjectDataSource>
    </td></tr>

    <tr><td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text="JobStation : "></asp:Label></td>
    <td colspan="3"><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="dropDown"
    DataSourceID="ODSJobStation" DataTextField="Text" DataValueField="value"></asp:DropDownList>
    <asp:ObjectDataSource ID="ODSJobStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
    TypeName="HR_BLL.Global.JobStation" OldValuesParameterFormatString="original_{0}"><SelectParameters>
    <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
    <asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32" /></SelectParameters>
    </asp:ObjectDataSource>
    </td></tr>

    <tr><td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Shift : "></asp:Label></td>
    <td colspan="3"><asp:DropDownList ID="ddlPresentShift" runat="server" AutoPostBack="True" CssClass="dropDown" DataSourceID="ODSShift" DataTextField="strShiftName" DataValueField="intShiftID">
    </asp:DropDownList><asp:ObjectDataSource ID="ODSShift" runat="server" SelectMethod="GetAllShiftByJobStationId" TypeName="HR_BLL.Global.Shift" OldValuesParameterFormatString="original_{0}">
    <SelectParameters><asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters></asp:ObjectDataSource>
    </td>    
    </tr>
    
    <tr><td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="From-Date : "></asp:Label></td>
    <td colspan="3">
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="yyyy/MM/dd" 
    PopupButtonID="img133" TargetControlID="txtFromDate"></cc1:CalendarExtender>
    <asp:TextBox ID="txtFromDate" runat="server" Width="215px" BackColor="White"></asp:TextBox>
    <img ID="img133" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 22px; 
    height: 23px;vertical-align: bottom;" />
        <asp:RequiredFieldValidator ID="rField" runat="server" 
            ControlToValidate="txtFromDate" ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="vg"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr><td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="To-Date : "></asp:Label></td>
    <td colspan="3">
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" EnableViewState="true" Format="yyyy/MM/dd" 
    PopupButtonID="img1" TargetControlID="txtToDate"></cc1:CalendarExtender>
    <asp:TextBox ID="txtToDate" runat="server" Width="215px" BackColor="White"></asp:TextBox>
    <img ID="img1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 22px; 
    height: 23px;vertical-align: bottom;" />
        <asp:RequiredFieldValidator ID="rField0" runat="server" 
            ControlToValidate="txtToDate" ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="vg"></asp:RequiredFieldValidator>
        </td>
    </tr>

    <tr><td></td><td colspan="2" style="text-align:left;">
    <asp:RadioButton ID="rdoClose" runat="server" GroupName="grpActive" Text="Inactive" />
    <asp:RadioButton ID="rdoOpen" runat="server" GroupName="grpActive" Text="Active" ValidationGroup="grpActive" />
    <asp:Button ID="btnSave" runat="server" Text="Save" Font-Bold="True" 
            onclick="btnSave_Click" ValidationGroup="vg"/></td><td width="50px";></td></tr>

</table>
    </div>    

<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
