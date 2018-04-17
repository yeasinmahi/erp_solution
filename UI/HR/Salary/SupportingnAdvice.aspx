<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportingnAdvice.aspx.cs" Inherits="UI.HR.Salary.SupportingnAdvice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>.:: Salary Advice and Supporting ::.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "SupportingnAdvice.aspx/GetAutoCompleteData",
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
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var dte = document.forms["frmsalaryadviceandsupporting"]["txtDate"].value;
            if (dte == null || dte == "") {
                alert("Date must be filled by valid formate (year-month-day).");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
                document.forms[0].appendChild(confirm_value);
            }
        }
        function SupportingForPrint(unit, station, date, vwtype) {
            window.open('ShowSupporting.aspx?UNITID=' + unit + '&STATIONID=' + station + '&DATE=' + date + '&VTP=' + vwtype, '', "height=auto, width=auto, scrollbars=yes, left=250, top=100, resizable=yes, title=Preview");
        }

    </script>
</head>
<body>
<form id="frmsalaryadviceandsupporting" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        <CompositeScript><Scripts>
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
        </Scripts></CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

    <div class="divs_content_container">
    <div class="tabs_container">Salary Advice and Supporting :<hr /><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnField" runat="server" /></div>
        <table border="0";>
         <tr>
         <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
         <td><asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsunit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
         <asp:ObjectDataSource ID="odsunit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
         <SelectParameters><asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" /></SelectParameters>
         </asp:ObjectDataSource>
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
         <td style="text-align:right;"><asp:Label ID="lbldate" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
         <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
         <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>                                                        
         </td>
         <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label></td>
         <td>
            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
         </td>
         </tr>   
         
         <tr>
         <td colspan="4" style="text-align:right;">
         <asp:Button ID="btnExport" runat="server" CssClass="nextclick" style="font-size:11px;" Text="Download" OnClick="btnExport_Click" />
         <asp:Button ID="btnPrint" runat="server" CssClass="nextclick" style="font-size:11px;" Text="Print" OnClick="btnPrint_Click"/>
         <asp:Button ID="btnAdvice" runat="server" CssClass="nextclick" style="font-size:11px;" Text="AdviceGenerate" OnClientClick="Confirm()" OnClick="btnAdvice_Click"/>
         <asp:Button ID="btnShow" runat="server" CssClass="nextclick" style="font-size:11px;" Text="Show Report" OnClientClick="Confirm()" OnClick="btnShow_Click"/>
         
         </td>
         </tr>  
        </table>
    </div>


    <asp:GridView ID="dgvSupporting" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="10px" BackColor="White">
        <Columns>
         <asp:BoundField DataField="strEmployeeCode" HeaderText="EmployeeCode" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeCode">
         <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
                
         <asp:BoundField DataField="strEmployeeName" HeaderText="Employee-Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
         <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:BoundField>
                
         <asp:BoundField DataField="strDepatrment" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="strDepatrment">
         <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
                
         <asp:BoundField DataField="strBankName" HeaderText="BankName" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName">
         <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
                
         <asp:BoundField DataField="strBranchName" HeaderText="BranchName" ItemStyle-HorizontalAlign="Center" SortExpression="strBranchName">
         <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>

         <asp:BoundField DataField="strBankAccountNo" HeaderText="AccountNo" ItemStyle-HorizontalAlign="Center" SortExpression="strBankAccountNo">
         <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>

         <asp:BoundField DataField="monTotalPayableSalary" HeaderText="PayableSalary" ItemStyle-HorizontalAlign="Center" SortExpression="monTotalPayableSalary" DataFormatString="{0:0,000.00}">
         <ItemStyle HorizontalAlign="Right" Width="100px" /></asp:BoundField>                
         </Columns>
        </asp:GridView>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
