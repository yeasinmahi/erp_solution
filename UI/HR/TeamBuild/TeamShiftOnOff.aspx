<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.TeamBuild.TeamShiftOnOff" EnableEventValidation="false" Codebehind="TeamShiftOnOff.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 
<html >
<head runat="server">
<title>.: Team Or Shift On-Off :.</title>
   <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder> 
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
</head>
<body>
<form id="frmTeamShiftInfo" runat="server">
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
<%--=========================================Start My Code From Here======================================================--%>


<div class="shiftRegion">
<div id="teamRegionHeader">Team & Shift Information :</div>
<table border="0px"; style="width: auto;">

<tr>
<td style="text-align:right;"><asp:Label ID="lblTeam" CssClass="lbl" runat="server" Text="Team-List : "></asp:Label></td>
<td colspan="3"><asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsTeamList" 
DataTextField="strTeamName" onselectedindexchanged="ddlTeam_SelectedIndexChanged" DataValueField="intTeamId"></asp:DropDownList>
<asp:ObjectDataSource ID="odsTeamList" runat="server" SelectMethod="GetAllTeamByStationId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
<SelectParameters><asp:SessionParameter Name="intJobStationId" SessionField="Session[SessionParams.JOBSTATION_ID]" Type="Int32" />
</SelectParameters></asp:ObjectDataSource>
<asp:HiddenField ID="hdnTeamStatus" runat="server" />
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
<td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" BackColor="White" Enabled="False" ForeColor="Black"></asp:TextBox></td>
<td style="text-align:right;"><asp:Label ID="lblStation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
<td><asp:TextBox ID="txtStation" runat="server" CssClass="txtBox" BackColor="White" Enabled="False" ForeColor="Black"></asp:TextBox></td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblStatus" CssClass="lbl" runat="server" Text="Status : "></asp:Label></td>
<td><asp:TextBox ID="txtStatus" runat="server" CssClass="txtBox" BackColor="White" Enabled="False" ForeColor="Black"></asp:TextBox></td>
<td colspan="2"><asp:CheckBox ID="chkOnOff" runat="server" Text="Team Active / Inactive"></asp:CheckBox></td>
</tr>

<tr><td style="text-align:right;" colspan="4"><asp:Button id="btnChange" runat="server" Text="Save-Change" ValidationGroup="vg" 
onclick="btnChange_Click" ></asp:Button></td></tr>

<%--==================Load Shift Information By TeamId============--%>

<tr><td style="text-align:justify;" colspan="4">

<asp:GridView ID="dgvShiftInfo" runat="server" AutoGenerateColumns="False" onrowdeleting="dgvShiftInfo_RowDeleting" onrowediting="dgvShiftInfo_RowEditing"
onrowupdating="dgvShiftInfo_RowUpdating" onrowcancelingedit="dgvShiftInfo_RowCancelingEdit" SkinID="sknGrid2" DataSourceID="odsShiftInfo" DataKeyNames="intShiftId">

<Columns>

 <asp:TemplateField HeaderText="intShiftId" InsertVisible="False" SortExpression="intShiftId" Visible="False">
<EditItemTemplate><asp:Label ID="intShiftId" runat="server" Text='<%# Eval("intShiftId") %>'></asp:Label></EditItemTemplate>
<ItemTemplate><asp:Label ID="lblSft" runat="server" Text='<%# Bind("intShiftId") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
 
 <asp:TemplateField HeaderText="Shift-Name" SortExpression="strShiftName">
 <EditItemTemplate><asp:TextBox ID="txtShiftName" Width="130px" runat="server" Text='<%# Bind("strShiftName") %>'></asp:TextBox></EditItemTemplate>
 <ItemTemplate><asp:Label ID="lblShift" runat="server" Text='<%# Bind("strShiftName") %>'></asp:Label></ItemTemplate>
 <ItemStyle HorizontalAlign="Center" Width="130px" /></asp:TemplateField>

 <asp:TemplateField HeaderText="Shift-Start" SortExpression="tmShiftStart">
<EditItemTemplate><asp:TextBox ID="txtShiftStart" Width="65px" runat="server" Text='<%# Bind("tmShiftStart") %>'></asp:TextBox></EditItemTemplate>
<ItemTemplate><asp:Label ID="lblSftStart" runat="server" Text='<%# Bind("tmShiftStart") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>

 <asp:TemplateField HeaderText="Shift-End" SortExpression="tmShiftEnd">
<EditItemTemplate><asp:TextBox ID="txtShiftEnd" Width="75px" runat="server" Text='<%# Bind("tmShiftEnd") %>'></asp:TextBox></EditItemTemplate>
<ItemTemplate><asp:Label ID="lblSftEnd" runat="server" Text='<%# Bind("tmShiftEnd") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="75px" /></asp:TemplateField>

 <asp:TemplateField HeaderText="Roster" SortExpression="ysnRoster">
<EditItemTemplate><asp:CheckBox ID="chkRosterEnable" Width="50px" runat="server" Checked='<%# Bind("ysnRoster") %>' /></EditItemTemplate>
<ItemTemplate><asp:CheckBox ID="chkRoster" runat="server" Checked='<%# Bind("ysnRoster") %>' Enabled="false" /> </ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="50px" /></asp:TemplateField>
 
 <asp:TemplateField HeaderText="Shift-Active" SortExpression="ysnActive">
<EditItemTemplate><asp:CheckBox ID="chkActive" Width="75px" runat="server" Checked='<%# Bind("ysnActive") %>' /></EditItemTemplate>
<ItemTemplate><asp:CheckBox ID="chkActive" runat="server" Checked='<%# Bind("ysnActive") %>' Enabled="false" /> </ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="75px" /></asp:TemplateField>
 
       
 <asp:CommandField ShowEditButton="true" />
 <%--<asp:CommandField ShowDeleteButton="true" /> --%>
 
</Columns>

</asp:GridView>

<asp:ObjectDataSource ID="odsShiftInfo" runat="server" SelectMethod="GetShiftInformationByTeamId" 
TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation" OldValuesParameterFormatString="original_{0}" 
UpdateMethod="UpdateTeamShiftInformationByShiftId" DeleteMethod="DeleteTeamShiftInformationByShiftId">
<SelectParameters><asp:ControlParameter ControlID="ddlTeam" Name="intTeamId" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
<UpdateParameters>
        <asp:Parameter Name="intShiftId" Type="Int32" />
        <asp:Parameter Name="strShiftName" Type="String" />
        <asp:Parameter Name="tmShiftStart" Type="String" />
        <asp:Parameter Name="tmShiftEnd" Type="String" />
        <asp:Parameter Name="ysnRoster" Type="Int32" />
        <asp:Parameter Name="ysnActive" Type="Int32" />
 </UpdateParameters>

<DeleteParameters><asp:Parameter Name="intShiftId" Type="Int32" /></DeleteParameters>
</asp:ObjectDataSource>

</td>
</tr>

</table>
</div>


<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form></body>
</html>
