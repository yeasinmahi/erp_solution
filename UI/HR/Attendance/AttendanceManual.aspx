<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceManual.aspx.cs" Inherits="UI.HR.Attendance.AttendanceManual" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Manual Attendance Insertion :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/GetSearchEmployeeList") %>',
                        data: '{"searchKey":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });
    </script>
    </head>
<body>
    <form id="frmaclmanatt" runat="server">
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
        <div class="tabs_container"> Manual Attendance Information :<asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbljobtype" CssClass="lbl" runat="server" Text="Job-Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobtype" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr class="tblroweven">   
        <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbleffective" CssClass="lbl" runat="server" Text="Attendance-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtEffectiveDate', { 'dateFormat': 'Y-m-d' });</script></td>
        </tr>
        <tr><td colspan="4" style="text-align:right;"><asp:Button ID="btnSave" runat="server" class="nextclick" style="font-size:11px;" 
        Text="Submit" OnClick="btnSave_Click"/></td></tr>
        
        </table>



        </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
