<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubLeave.aspx.cs" Inherits="UI.HR.Leave.PubLeave" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() { document.getElementById('hdfSearchBoxTextChange').value = 'true'; }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "PubLeave.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            //alert("Error");
                        }
                    });
                }
            });
        }
        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtEmployeeSearch = document.forms["frmpublv"]["txtEmployeeSearch"].value;
            var txtDteFrom = document.forms["frmpublv"]["txtDteFrom"].value;
            var txtDteTo = document.forms["frmpublv"]["txtDteTo"].value;
            var txtDescription = document.forms["frmpublv"]["txtReason"].value;
            var txtAddress = document.forms["frmpublv"]["txtAddress"].value;

            if (txtEmployeeSearch == null || txtEmployeeSearch == "") {
                alert("Please select a valid employee.");
                document.getElementById("txtEmployeeSearch").focus();
            }
            else if (txtDteFrom == null || txtDteFrom == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtDteFrom").focus();
            }
            else if (txtDteTo == null || txtDteTo == "") {
                alert("To date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtDteTo").focus();
            }
            else if (txtDteFrom > txtDteTo) {
                alert("To date must be greater than from date.");
                document.getElementById("txtDteTo").focus();
            }
            else if (txtDescription == null || txtDescription == "") {
                alert("Reason must be filled.");
                document.getElementById("txtDescription").focus();
            }
            else if (txtAddress == null || txtAddress == "") {
                alert("Address must be filled.");
                document.getElementById("txtAddress").focus();
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
        function UpdateControls(fromDate, toDate, reason, address) {

            var dd, mm, yyyy;
            var frmDate = new Date(fromDate);
            dd = frmDate.getDate(); mm = (frmDate.getMonth() + 1); yyyy = frmDate.getFullYear();
            if (dd < 10) { dd = "0" + dd; }
            if (mm < 10) { mm = "0" + mm; }
            fromDate = yyyy + "-" + mm + "-" + dd;
            document.getElementById("txtDteFrom").innerText = fromDate;

            var tDate = new Date(toDate);
            dd = tDate.getDate(); mm = (tDate.getMonth() + 1); yyyy = tDate.getFullYear();
            if (dd < 10) { dd = "0" + dd; }
            if (mm < 10) { mm = "0" + mm; }
            toDate = yyyy + "-" + mm + "-" + dd;
            document.getElementById("txtDteTo").innerText = toDate;

            document.getElementById("txtDescription").innerText = reason;
            document.getElementById("txtAddress").innerText = address;
        }
        function IndexChange(value) {
            var ControlName = document.getElementById(value.id);
            if (ControlName.value == 8) {
                document.getElementById('txtDteFrom').disabled = true;
                document.getElementById('txtDteTo').disabled = true;
            }
            else {
                document.getElementById('txtDteFrom').disabled = false;
                document.getElementById('txtDteTo').disabled = false;
            }
        }
    </script>
</head>
<body>
    <form id="frmpublv" runat="server">
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
    <div class="leaveApplication_container"><b>Employee Leave Entry: </b><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnAppId" runat="server" /><asp:HiddenField ID="hdncontact" runat="server" /><hr />
    <table style="width:Auto; ";>
        <tr><td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
        <td><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /><asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlLvType" runat="server" CssClass="ddList" AutoPostBack="false" onchange="IndexChange(this);" DataSourceID="odsleavetype" DataTextField="strLeaveType" DataValueField="intLeaveTypeID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsleavetype" runat="server" SelectMethod="GetLeaveType" TypeName="HR_BLL.Leave.LeaveApplicationProcess" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:SessionParameter Name="strEmployeeCode" SessionField="sesUserCode" Type="String" /></SelectParameters></asp:ObjectDataSource></td>
        </tr>

        <tr><td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Details : "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtDetails" runat="server" CssClass="txtBox" ReadOnly="true" Width="451px"></asp:TextBox></td></tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblstrt" CssClass="lbl" runat="server" Text="Start-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmStart" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
        <td style="text-align:right;"><asp:Label ID="lblend" CssClass="lbl" runat="server" Text="End-Time : "></asp:Label></td>
        <td><MKB:TimeSelector ID="tmEnd" runat="server" SelectedTimeFormat="Twelve"></MKB:TimeSelector></td>
        </tr>
        
        <tr>
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblperadd" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
        <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblpreadd" CssClass="lbl" runat="server" Text="Address : "></asp:Label></td>
        <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnDelete" runat="server" class="nextclick" style="font-size:11px;" Text="Delete" OnClick="btnDelete_Click"  OnClientClick = "Confirm()"/>
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClick="btnSubmit_Click"  OnClientClick = "Confirm()"/>        
        </td>
        </tr>

        <tr><td colspan="4"><asp:GridView ID="dgvApplicationSummary" runat="server" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsApplicationSummary" BackColor="White">
        <Columns>
        <asp:BoundField DataField="intApplicationId" HeaderText="Serial" ItemStyle-HorizontalAlign="Center" SortExpression="intApplicationId">
        <ItemStyle HorizontalAlign="Left" Width="47px"/></asp:BoundField>
        <asp:BoundField DataField="strLeaveType" HeaderText="Leave-Type" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
        <ItemStyle HorizontalAlign="Left" Width="75px"/></asp:BoundField>
        <asp:BoundField DataField="dateApplicationDate" HeaderText="Submit" ItemStyle-HorizontalAlign="Center" SortExpression="dateApplicationDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="65px"/></asp:BoundField>
        <asp:BoundField DataField="dateAppliedFromDate" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedFromDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle Width="65px" /></asp:BoundField>
        <asp:BoundField DataField="dateAppliedToDate" HeaderText="To-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dateAppliedToDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="65px" /></asp:BoundField>
        <asp:BoundField DataField="strLeaveReason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveReason">
        <ItemStyle HorizontalAlign="Left" Width="145px" /></asp:BoundField>
        <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="srtApprovedStatus">
        <ItemTemplate><asp:Button ID="btnAction" class="nextclick" OnCommand="btnAction_OnCommand" runat="server" CommandName="PROCESS" Font-Size="9px" 
        CommandArgument='<%#GetJSFunctionString( Eval("srtApprovedStatus"),Eval("intLeaveTypeID"),Eval("intApplicationId"),Eval("dateAppliedFromDate"),Eval("dateAppliedToDate"),Eval("strLeaveReason"),Eval("strAddressDuetoLeave")) %>'
        Text='<%# Bind("srtApprovedStatus") %>' /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="odsApplicationSummary" runat="server" SelectMethod="GetApplicationSummary" TypeName="HR_BLL.Leave.LeaveApplicationProcess" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:ControlParameter ControlID="hdfEmpCode" Name="strEmployeeCode" PropertyName="Value" Type="String" />
        <asp:Parameter Name="employeeid" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td></tr>

        </table>
        </div>
    
    
    <div class="leaveSummary_container"> 
        <div class="tabs_container">Leave Summary :<hr /></div>
        <asp:GridView ID="dgvLeaveSummary" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsLeaveSummary" BackColor="White">
          <Columns><asp:BoundField DataField="strLeaveType" HeaderText="Leave-Type" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
            <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
            <asp:BoundField DataField="intLeaveTakenDays" HeaderText="Taken" ItemStyle-HorizontalAlign="Center" SortExpression="intLeaveTakenDays">
            <ItemStyle Width="45px"/></asp:BoundField>
            <asp:BoundField DataField="intRemainingDays" HeaderText="Blance" ItemStyle-HorizontalAlign="Center" SortExpression="intRemainingDays">
            <ItemStyle Width="45px" /></asp:BoundField>
            <asp:BoundField DataField="strRemarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" SortExpression="strLeaveType">
            <ItemStyle HorizontalAlign="Left" Width="270px" /></asp:BoundField>
          </Columns></asp:GridView>
        <asp:ObjectDataSource ID="odsLeaveSummary" runat="server" SelectMethod="GetLeaveSummary" TypeName="HR_BLL.Leave.LeaveApplicationProcess" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdfEmpCode" Name="employeecode" PropertyName="Value" Type="String" />
                <asp:Parameter Name="employeeid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
