<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePunishment.aspx.cs" Inherits="UI.HR.Penalty.EmployeePunishment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:: Employee Punishment ::.</title>
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
                        url: "EmployeePunishment.aspx/GetAutoCompleteData",
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
            var empcode = document.forms["frmemployeepunishment"]["txtEmployeeSearch"].value;
            var txtEffectiveDate = document.forms["frmemployeepunishment"]["txtEffectiveDate"].value;
            var txtAmount = document.forms["frmemployeepunishment"]["txtAmount"].value;
            var reason = document.forms["frmemployeepunishment"]["txtReason"].value;

            if (empcode == null || empcode == "") {
                alert("Employee must be filled by valid code.");
            }
            else if (txtEffectiveDate == null || txtEffectiveDate == "") {
                alert("Effective date must be filled by valid formate (year-month-day).");
            }
            else if (txtAmount == null || txtAmount == "" || isNaN(txtAmount)) {
                alert("Amount must be filled by valid numeric value.");
            }
            else if (reason == null || reason == "") {
                alert("Reason must be filled by valid reason.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function ConfirmAll() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }


    </script>
</head>
<body>
    <form id="frmemployeepunishment" runat="server">
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
    <div class="tabs_container">Disciplinary Punishment :<hr /><asp:HiddenField ID="hdnconfirm" runat="server"/></div>
        <table border="0";>         

         <tr>         
         <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label></td>
         <td>
            <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
         </td>
         
         <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
         <td><asp:DropDownList ID="ddlPType" runat="server" AutoPostBack="false" CssClass="dropdownList">
         <asp:ListItem Selected="True" Value="1">Leave Withoutpay</asp:ListItem><asp:ListItem Value="2">Vehicle Punishment</asp:ListItem>
         <asp:ListItem Value="3">Misconduct</asp:ListItem><asp:ListItem Value="4">Other's</asp:ListItem></asp:DropDownList>
         </td>  
         </tr>    

         <tr>
         <td style="text-align:right;"><asp:Label ID="lblfdate" CssClass="lbl" runat="server" Text="Effective Date : "></asp:Label></td>
         <td><asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
         <cc1:CalendarExtender ID="CFD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEffectiveDate"></cc1:CalendarExtender>                                                        
         </td>
         <td style="text-align:right;"><asp:Label ID="lbltdate" CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
         <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" TextMode="Number"></asp:TextBox></td>
         </tr>

         <tr>
         <td style="text-align:right;"><asp:Label ID="lblreason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
         <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
         <td colspan="2" style="text-align:right;">
         <asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" style="font-size:11px;" Text="Submit" OnClientClick="Confirm()" OnClick="btnSubmit_Click"/>
         
         </td>
         </tr>  

        <tr><td colspan="4"><asp:GridView ID="dgvSummary" runat="server" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" BackColor="White" DataSourceID="odspun">
        <Columns>
        <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="35px"/></asp:TemplateField>
        <asp:TemplateField HeaderText="Date" SortExpression="Dates">
        <ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Eval("Dates") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Reason" SortExpression="Reason" >
        <ItemTemplate><asp:Label ID="lblReason" runat="server" Text='<%# Bind("Reason") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" >
        <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%# Math.Abs(decimal.Parse(""+Eval("Amount", "{0:0.00}"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="90px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
        <ItemTemplate><asp:Button ID="btnCancel" runat="server" Font-Size="10px" ForeColor="Red" OnClick="Cancel_Click" OnClientClick="ConfirmAll()" 
        CommandArgument='<%# Eval("ID") %>' Text="Cancel" /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>
        </Columns></asp:GridView>
        <asp:ObjectDataSource ID="odspun" runat="server" SelectMethod="GetAllPunishment" TypeName="HR_BLL.Penalty.Penalty"><SelectParameters><asp:ControlParameter ControlID="hdfEmpCode" 
        Name="empCode" PropertyName="Value" Type="String" /></SelectParameters></asp:ObjectDataSource></td></tr>

        </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
