<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubMovement.aspx.cs" Inherits="UI.HR.OfficialMovement.PubMovement" %>
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
                        url: "PubMovement.aspx/GetAutoCompleteData",
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
            var txtEmployeeSearch = document.forms["frmpubmvmnt"]["txtEmployeeSearch"].value;
            var txtDteFrom = document.forms["frmpubmvmnt"]["txtDteFrom"].value;
            var txtDteTo = document.forms["frmpubmvmnt"]["txtDteTo"].value;
            var txtDescription = document.forms["frmpubmvmnt"]["txtDescription"].value;
            var txtAddress = document.forms["frmpubmvmnt"]["txtAddress"].value;

            if (txtEmployeeSearch == null || txtEmployeeSearch == "") {
                alert("Please select a valid employee.");
                document.getElementById("txtEmployeeSearch").focus();
            }
            else if ( txtDteFrom == null || txtDteFrom == "") {
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
            if (ControlName.value == 3) {
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
    <form id="frmpubmvmnt" runat="server">
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
    <div class="divs_content_container"><b>Employee Official Movement: </b><asp:HiddenField ID="hdnconfirm" runat="server" /> 
    <asp:HiddenField ID="hdnappid" runat="server" /><hr />
    <table border="0" style="width:Auto";>
        <tr><td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
        <td><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /><asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Type : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlMovement" runat="server" CssClass="ddList" AutoPostBack="false" onchange="IndexChange(this);" DataSourceID="odstype" DataTextField="strMoveType" DataValueField="intMoveTypeID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odstype" runat="server" SelectMethod="GetMvTypeList" TypeName="HR_BLL.OfficialMovement.OfficialMovement"></asp:ObjectDataSource></td>
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
        <td style="text-align:right;"><asp:Label ID="lbljstation" CssClass="lbl" runat="server" Text="Country : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odscountry" DataTextField="strCountry" DataValueField="intCountryID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odscountry" runat="server" SelectMethod="GetAllCountry" TypeName="HR_BLL.Global.Country" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        </td>
        <td style="text-align:right;"><asp:Label ID="lbljstatus" CssClass="lbl" runat="server" Text="District : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsdistrict" DataTextField="Text" DataValueField="Value"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsdistrict" runat="server" SelectMethod="GetDistrictList" TypeName="HR_BLL.Global.District"></asp:ObjectDataSource>
        </td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lbldteFrom" CssClass="lbl" runat="server" Text="From-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender>                                                        
        </td>
        <td style="text-align:right;"><asp:Label ID="lbldteto" CssClass="lbl" runat="server" Text="To-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDteTo" runat="server" CssClass="txtBox" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
        </td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblperadd" CssClass="lbl" runat="server" Text="Reason : "></asp:Label></td>
        <td><asp:TextBox ID="txtDescription" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblpreadd" CssClass="lbl" runat="server" Text="Address : "></asp:Label></td>
        <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" TextMode="MultiLine"></asp:TextBox></td>
        </tr>

        <tr>
        <td style="text-align:right;" colspan="4">
        <asp:Button ID="btnDelete" runat="server" class="nextclick" style="font-size:11px;" Text="Delete" OnClick="btnDelete_Click"  OnClientClick = "Confirm()"/>
        <asp:Button ID="btnSubmit" runat="server" class="nextclick" style="font-size:11px;" Text="Submit" OnClick="btnSubmit_Click"  OnClientClick = "Confirm()"/>        
        </td>
        </tr>

    </table>
    </div>
    <asp:GridView ID="dgvApplicationSummary" runat="server" PageSize="15" AutoGenerateColumns="False" AllowPaging="True" SkinID="sknGrid2" Font-Size="10px" DataSourceID="odsApplicationSummary" BackColor="White">
              <Columns>
                <asp:BoundField DataField="intId" HeaderText="Serial" ItemStyle-HorizontalAlign="Center" SortExpression="intId">
                <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:BoundField>
                <asp:BoundField DataField="strMoveType" HeaderText="Movement-Type" ItemStyle-HorizontalAlign="Center" SortExpression="strMoveType">
                <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
                <asp:BoundField DataField="dteAppliedTime" HeaderText="Submited-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteAppliedTime" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="100px"/></asp:BoundField>
                <asp:BoundField DataField="dteStartTime" HeaderText="From-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteStartTime" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="90px" /></asp:BoundField>
                <asp:BoundField DataField="dteEndTime" HeaderText="To-Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteEndTime" DataFormatString="{0:yyyy-MM-dd}">
                <ItemStyle Width="90px" /></asp:BoundField>
                <asp:BoundField DataField="strReason" HeaderText="Reason" ItemStyle-HorizontalAlign="Center" SortExpression="strReason">
                <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:BoundField>
                <asp:BoundField DataField="strAddress" HeaderText="Due to Address" ItemStyle-HorizontalAlign="Center" SortExpression="strAddress">
                <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:BoundField>
                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="srtStatus">
                <ItemTemplate>
                   <asp:Button ID="btnAction" class="nextclick" OnCommand="btnAction_OnCommand" runat="server" Font-Size="9px" 
                   CommandArgument='<%#GetJSFunctionString( Eval("srtStatus"),Eval("intId"),Eval("intCountryID"),Eval("intDistrictID"),Eval("dteStartTime"),Eval("dteEndTime"),Eval("strReason"),Eval("strAddress")) %>'
                   Text='<%# Bind("srtStatus") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>
              </Columns>
            </asp:GridView>
    <asp:ObjectDataSource ID="odsApplicationSummary" runat="server" SelectMethod="GetApplicationSummary" TypeName="HR_BLL.OfficialMovement.OfficialMovement" OldValuesParameterFormatString="original_{0}">
    <SelectParameters><asp:ControlParameter ControlID="hdfEmpCode" Name="strEmployeeCode" PropertyName="Value" Type="String" />
    <asp:Parameter Name="employeeid" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
    


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
