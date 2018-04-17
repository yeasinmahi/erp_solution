<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.TeamBuild.EmployeeAssign" Codebehind="EmployeeAssign.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head runat="server">
<title>.: Employee Shift Assign :.</title>

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
            $("#txtSearchEmp").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "EmployeeAssign.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchEmp').value + "'}",
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


    </script>

</head>
<body>
<form id="frmEmployeeAssign" runat="server">
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
<%--=========================================Start My Code From Here====================DefaultValue="11754"  ===========================--%>

<div class="assignRegion">
<div id="teamRegionHeader">Employee Shift Assign in Team :</div>
<div class="addRegion">

<table border="0px"; style="width: auto;">

<tr>
<td style="text-align:right;"><asp:Label ID="lblStation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
<td><asp:DropDownList ID="ddlJobStation" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsJobStation" 
 DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>

<asp:ObjectDataSource ID="odsJobStation" runat="server" SelectMethod="GetAllJobStationByLoginId" TypeName="HR_BLL.Global.JobStation">
<SelectParameters><asp:SessionParameter Name="intLoginId" SessionField="sesUserId" Type="Int32"/></SelectParameters>
</asp:ObjectDataSource>

</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblTeam" CssClass="lbl" runat="server" Text="Team-Name : "></asp:Label></td>
<td><asp:DropDownList ID="ddlTeam" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsTeam" DataTextField="strTeamName" 
DataValueField="intTeamId"></asp:DropDownList>
<asp:ObjectDataSource ID="odsTeam" runat="server" SelectMethod="GetAllTeamByStationId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
<SelectParameters><asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>


</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblShift" CssClass="lbl" runat="server" Text="Shift-Name : "></asp:Label></td>
<td><asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="True" CssClass="ddList" DataSourceID="odsShift" DataTextField="strShiftName" 
DataValueField="intShiftId"></asp:DropDownList>
<asp:ObjectDataSource ID="odsShift" runat="server" SelectMethod="GetAllShiftByTeamId" TypeName="HR_BLL.TeamBuild.TeamAndShiftInformation">
<SelectParameters><asp:ControlParameter ControlID="ddlTeam" Name="intTeamId" PropertyName="SelectedValue" Type="Int32" />
<asp:ControlParameter ControlID="ddlJobStation" Name="intJobStationId" PropertyName="SelectedValue" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblEmpSearch" CssClass="lbl" runat="server" Text="Search-Name : "></asp:Label></td>
<td><asp:TextBox ID="txtSearchEmp" AutoPostBack="true" runat="server" CssClass="txtBox"></asp:TextBox>
<asp:RequiredFieldValidator ID="rName" runat="server" ControlToValidate="txtSearchEmp" ErrorMessage="*" Font-Size="8pt" ForeColor="Red" 
ValidationGroup="vg"></asp:RequiredFieldValidator></td></tr>

<tr>
<td style="text-align:right;" colspan="2"><asp:Button id="btnAdd" runat="server" Text="Add-To-Cart" 
onclick="btnAdd_Click" ValidationGroup="vg" ></asp:Button></td></tr>


</table>

</div>

<%--==========================================--%>

<div class="grdRegion">
<asp:GridView ID="dgvAssignedEmployee" runat="server" AutoGenerateColumns="False" onrowdeleting="dgvAssignedEmployee_RowDeleting" SkinID="sknGrid2">
<Columns><asp:TemplateField HeaderText="Employee" SortExpression="empName">
<ItemTemplate><asp:Label ID="lblEmp" runat="server" Text='<%# Bind("empName") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="300px" /></asp:TemplateField>
<asp:TemplateField HeaderText="Code" SortExpression="empCode">
<ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%# Bind("empCode") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="120px" /></asp:TemplateField>
<asp:TemplateField HeaderText="Shift" SortExpression="shift">
<ItemTemplate><asp:Label ID="lblEnd" runat="server" Text='<%# Bind("sftName") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>
<asp:TemplateField HeaderText="Team" SortExpression="team">
<ItemTemplate><asp:Label ID="lblTeam" runat="server" Text='<%# Bind("team") %>'></asp:Label></ItemTemplate>
<ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>
<asp:CommandField ShowDeleteButton="true" />
</Columns>
</asp:GridView>

</div>

</div>

<div id="addtoDB"><asp:Button id="btnAddtoDB" runat="server" Text="Submit-Assigned-Information" onclick="btnAddtoDB_Click"></asp:Button></div>


<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
