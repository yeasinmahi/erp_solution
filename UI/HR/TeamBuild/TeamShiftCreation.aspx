<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.TeamBuild.TeamShiftCreation"  EnableEventValidation="true" Codebehind="TeamShiftCreation.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Team and Shift Creation</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
   <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

</head>
<body>
<form id="frmShiftCreate" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
<%--=========================================Start My Code From Here=====================DefaultValue="11754" =================================--%>

<div class="teamRegion">
<div id="teamRegionHeader">Team Create :</div>
<table border="0px"; style="width: auto;">
<tr>
<td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
<td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsUnit" DataTextField="strUnit" 
DataValueField="intUnitID"></asp:DropDownList>
<asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
<SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String"/> </SelectParameters>
</asp:ObjectDataSource>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblStation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
<td><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsStation" DataTextField="Text" 
    DataValueField="Value"></asp:DropDownList>
<asp:ObjectDataSource ID="odsStation" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID" TypeName="HR_BLL.Global.JobStation">
<SelectParameters>
<asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
<asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="String"  />
</SelectParameters>
</asp:ObjectDataSource>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblTeam" CssClass="lbl" runat="server" Text="Team-Name : "></asp:Label></td>
<td><asp:TextBox ID="txtTeam" runat="server" CssClass="txtBox"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rTeam" runat="server" ControlToValidate="txtTeam" ErrorMessage="Required" Font-Size="8pt" 
        ForeColor="Red" ValidationGroup="fvg"></asp:RequiredFieldValidator>
    </td>
</tr>
</table>
</div>

<div class="shiftRegion">

<div class="leftRegion">
<div id="shiftRegionHeader">Shift Create :</div>

<table border="0px">
<tr>
<td style="text-align:right;"><asp:Label ID="lblShift" CssClass="lbl" runat="server" Text="Shift : "></asp:Label></td>
<td><asp:TextBox ID="txtShift" runat="server" CssClass="txtSft"></asp:TextBox>
<asp:RequiredFieldValidator ID="rShift" runat="server" ControlToValidate="txtShift" ErrorMessage="*" Font-Size="8pt" 
ForeColor="Red" ValidationGroup="vg"></asp:RequiredFieldValidator>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="iblstart" CssClass="lbl" runat="server" Text="Start : "></asp:Label></td>
<td><MKB:TimeSelector ID="txtStartTime" runat="server" SelectedTimeFormat="TwentyFour" CssClass="txtTime"></MKB:TimeSelector></td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblEnd" CssClass="lbl" runat="server" Text="End : "></asp:Label></td>
<td><MKB:TimeSelector ID="txtEndTime" runat="server" SelectedTimeFormat="TwentyFour" CssClass="txtTime"></MKB:TimeSelector></td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblShiftType" CssClass="lbl" runat="server" Text="ShiftType : "></asp:Label></td>
<td><asp:DropDownList ID="ddlShiftType" runat="server" AutoPostBack="True"  Width="100px">
<asp:ListItem Value="0" Text="Day-Shift" /><asp:ListItem Value="1" Text="Night-Shift" />
</asp:DropDownList>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblSequence" CssClass="lbl" runat="server" Text="Sequence : "></asp:Label></td>
<td><asp:DropDownList ID="ddlSequence" runat="server" AutoPostBack="True"  Width="100px" DataSourceID="odsSequence" DataTextField="strSequenceName" 
 DataValueField="intSequenceId" ></asp:DropDownList>
    <asp:ObjectDataSource ID="odsSequence" runat="server" SelectMethod="GetAllShiftSequence" 
        TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation"></asp:ObjectDataSource>
    </td>
</tr>

<tr>
<td style="text-align:right;" colspan="2"><asp:CheckBox ID="chkRosterEnable" runat="server" Text="Roster Enable"></asp:CheckBox></td>
</tr>

<tr>
<td style="text-align:center;" colspan="2"><asp:Button id="btnAdd" runat="server" Text="Add-To-Cart" 
onclick="btnAdd_Click" ValidationGroup="vg" ></asp:Button></td>
</tr>
</table>

</div>

<%--==========================================--%>

<div class="rightRegion">
<div id="shiftInformationHeader">Shift Information :</div>

<table border="0px">
<tr><td> 

<asp:GridView ID="dgvShiftInfo" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" onrowdeleting="dgvShiftInfo_RowDeleting" 
 onrowediting="dgvShiftInfo_RowEditing" onrowupdating="dgvShiftInfo_RowUpdating" onrowcancelingedit="dgvShiftInfo_RowCancelingEdit">
<Columns>

    <asp:TemplateField HeaderText="Shift" SortExpression="sftName">
        <ItemTemplate><asp:Label ID="lblShift" runat="server" Text='<%# Bind("sftName") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtShift" Width="75px" runat="server" Text='<%# Bind("sftName") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="150px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Start" SortExpression="startTime">
        <ItemTemplate><asp:Label ID="lblStart" runat="server" Text='<%# Bind("startTime") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtStartTime" Width="75px" runat="server" Text='<%# Bind("startTime") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="100px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="End" SortExpression="endTime">
        <ItemTemplate><asp:Label ID="lblEnd" runat="server" Text='<%# Bind("endTime") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtEndTime" Width="75px" runat="server" Text='<%# Bind("endTime") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="100px" />
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Roster" SortExpression="rosterEnable">
        <ItemTemplate><asp:Label ID="lblRoster" runat="server" Text='<%# Bind("rosterEnable") %>'></asp:Label></ItemTemplate>
        <EditItemTemplate><asp:TextBox ID="txtRoster" Width="50px" runat="server" Text='<%# Bind("rosterEnable") %>'></asp:TextBox></EditItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="90px" />
    </asp:TemplateField>

<asp:CommandField ShowEditButton="true" />
<asp:CommandField ShowDeleteButton="true" /> 

</Columns>
</asp:GridView>

</td></tr>
</table>
</div>

</div>

<div id="addtoDB"><asp:Button id="btnAddtoDB" runat="server" Text="Add-Team and Shift" ValidationGroup="fvg" onclick="btnAddtoDB_Click">
</asp:Button></div>
<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form></body>
</html>
