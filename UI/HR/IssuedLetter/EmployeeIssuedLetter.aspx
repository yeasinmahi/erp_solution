<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.IssuedLetter.EmployeeIssuedLetter" Codebehind="EmployeeIssuedLetter.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
 <title>::. Employee Issued Letter</title>

 <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
 <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
 <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<script type="text/javascript">
    function PopupZone(empId, ltrId) {
        window.open('EmployeeIssuedLetterView.aspx?intEmployeeID=' + empId + '&intLetterId=' + ltrId, 'Konock', 'resizable= no, scrollbars=no, toolbar=no,location=no,menubar=no', true);
       
    }
</script>

</head>
<body>
<form id="frmIssuedLetter" runat="server">
<cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</cc1:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>

<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
<div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
<marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
scrolldelay="-1" width="100%">
<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
</marquee></div>
<div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
</asp:Panel>

<div style="height: 100px;"></div>
<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
runat="server"></cc1:AlwaysVisibleControlExtender>

<%--============FROM HERE START MY CODE===============--%>

<table style="width: 100%"><tr><td>
<asp:GridView runat="server" id="dgvIssuedLetter" AutoGenerateColumns="False" DataSourceID="ODSGetEmployeeIssuedAllLetter"><Columns>
<asp:BoundField HeaderText="EmployeeName" DataField="strEmployeeName" SortExpression="strEmployeeName"><ItemStyle Width="250px" /></asp:BoundField>
<asp:BoundField HeaderText="LetterName" DataField="strLetterName" SortExpression="strLetterName"><ItemStyle Width="150px" /></asp:BoundField>
<asp:BoundField HeaderText="IssueDate" DataField="dteIssueDate" SortExpression="dteIssueDate"><ItemStyle Width="100px" /></asp:BoundField>

 <asp:TemplateField HeaderText="Action"><ItemTemplate>
<asp:Button ID="btnAction" OnCommand="btnAction_OnCommand" runat="server" CommandName="PRINTPREVIEW"
CommandArgument='<%#ReturnFrmdate( Eval("intEmployeeID"),Eval("intLetterId")) %>' Text="Print Preview" />
</ItemTemplate></asp:TemplateField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource ID="ODSGetEmployeeIssuedAllLetter" runat="server" SelectMethod="GetEmployeeIssuedAllLetter" 
TypeName="HR_BLL.IssuedLetter.EmployeeIssuedLetter"></asp:ObjectDataSource>

</td></tr></table>

<%--============FROM HERE END MY CODE===============--%>

</ContentTemplate></asp:UpdatePanel>
</form></body></html>

