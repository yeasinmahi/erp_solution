<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Attendance.OfficialHour" Codebehind="OfficialHour.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html >
<head runat="server">
<title>.: Employee Office Hour Assign :.</title>

<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<!--
<link href="../../Content/CSS/EmpRegStyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../../Content/CSS/jquery-ui-1.8.22.custom.css" rel="stylesheet" type="text/css"/>
    -->
<meta http-equiv="X-UA-Compatible" content="IE=edge" />

<asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
</asp:PlaceHolder>  
<!--
<script type="text/javascript" src="../../JQUERY/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../JQUERY/jquery-ui-1.8.22.custom.min.js"></script>  
    -->
<%--<script type="text/javascript">
    function KeySelected(source, eventArgs) {
        alert('kkkk');
        if (event.keyCode == '13') {
            var searchString = document.getElementById('txtSearchEmp').value;
            var word = searchString.split(",");
            document.getElementById('hdfEmpCode').value = word[1];
        }
    }
</script>--%>

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
                    url: "OfficialHour.aspx/GetAutoCompleteData",
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
<form id="frmEmpOfficeHourAssign" runat="server">
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

<div class="assignRegion">
<div id="teamRegionHeader">Employee Official Hour Assign :</div>
<div class="addRegion">

<table border="0px"; style="width: auto;">

<tr><td style="text-align:right;"><asp:Label ID="lblEmpSearch" CssClass="lbl" runat="server" Text="Search-Name : "></asp:Label></td>
<td><asp:TextBox ID="txtSearchEmp" runat="server" CssClass="txtBox"></asp:TextBox><asp:HiddenField ID="hdfEmpCode" runat="server" />
<asp:RequiredFieldValidator ID="rName" runat="server" ControlToValidate="txtSearchEmp" ErrorMessage="*" Font-Size="8pt" ForeColor="Red" 
ValidationGroup="vg"></asp:RequiredFieldValidator>
</td></tr>

<tr>
<td style="text-align:right;"><asp:Label ID="iblstart" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
<td><MKB:TimeSelector ID="txtStartTime" runat="server" SelectedTimeFormat="TwentyFour" CssClass="txtTime"></MKB:TimeSelector></td>
</tr>

<tr>
<td style="text-align:right;"><asp:Label ID="lblEnd" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
<td><MKB:TimeSelector ID="txtEndTime" runat="server" SelectedTimeFormat="TwentyFour" CssClass="txtTime"></MKB:TimeSelector></td>
</tr>

<tr><td style="text-align:right;"><asp:Label ID="lblReason" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
<td ><asp:TextBox runat="server" id="txtReason" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox>
<asp:RequiredFieldValidator ID="rReason" runat="server" ControlToValidate="txtReason" ErrorMessage="*" Font-Size="8pt" ForeColor="Red" 
ValidationGroup="vg"></asp:RequiredFieldValidator>
</td></tr>

<tr><td style="text-align:right;" colspan="2"><asp:Button id="btnAdd" runat="server" Text="Add-To-Cart" 
ValidationGroup="vg" onclick="btnAdd_Click" ></asp:Button></td></tr>
</table>

</div>
</div>

<%--=========================================End My Code From Here========================================================--%>
</ContentTemplate>
</asp:UpdatePanel>
</form></body>
</html>
