<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeAllowance.aspx.cs" Inherits="UI.HR.Loan.EmployeeAllowance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Allowance Insertion :.</title>
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
                        data: '{"enroll":"' + $("#hdnenroll").val() + '","station":"' + $("#hdnstation").val() + '","searchKey":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) {},
                        failure: function (response) {}
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });


        function Confirm() {
            document.getElementById("hdnconfirm").value = "0";
            var txtEffectiveDate = document.forms["frmallownace"]["txtEffectiveDate"].value;
            var monAmount = document.forms["frmallownace"]["txtAmount"].value;

            if (txtEffectiveDate == null || txtEffectiveDate == "") {
                alert("Effective date must be filled by valid formate (year-month-day).");
            }
            else if (monAmount == null || monAmount == "" || isNaN(monAmount)) {
                alert("Allowance amount must be required.");
            }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }

        }
        function ConfirmDelete() {
            document.getElementById("hdndelete").value = "0";
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdndelete").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdndelete").value = "0"; }
        }
    </script>
</head>
<body>
    <form id="frmallownace" runat="server">
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
        <div class="tabs_container"> Employee Allowance Information :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" Text="Employee-Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtFullName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbljobtype" CssClass="lbl" runat="server" Text="Job-Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobtype" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr class="tblroweven">   
        <td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbldepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
        <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr class="tblroweven">   
        <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbleffective" CssClass="lbl" runat="server" Text="Effective-Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtEffectiveDate', { 'dateFormat': 'Y-m-d' });</script></td>
        </tr>
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblallowance" CssClass="lbl" runat="server" Text="Allowance : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlAllowance" runat="server" CssClass="dropdownList" DataSourceID="odsallowancelist" DataTextField="strAllowance"
        DataValueField="intAllowanceTypeId"></asp:DropDownList><asp:ObjectDataSource ID="odsallowancelist" runat="server" SelectMethod="GetAllowanceTypeList" 
        TypeName="HR_BLL.Loan.Loan"></asp:ObjectDataSource></td>
        <td style="text-align:right;"><asp:Label ID="lblamount" CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
        <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr><td colspan="4" style="text-align:right;"><asp:Button ID="btnSave" runat="server" class="nextclick" style="font-size:11px;" 
        Text="SAVE" OnClick="btnSave_Click"  OnClientClick = "Confirm()"/> <asp:HiddenField ID="hdnconfirm" runat="server"/></td></tr>
        <tr><td colspan="4"><asp:HiddenField ID="hdnallowanceid" runat="server"/>
        <asp:GridView ID="dgvallowance" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odsallwsummary"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="EffectiveMonth" HeaderText="Effective Month" ItemStyle-HorizontalAlign="Center" SortExpression="EffectiveMonth">
        <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:BoundField> 
        <asp:BoundField DataField="strAllowance" HeaderText="Allowance Type" ItemStyle-HorizontalAlign="Center" SortExpression="strAllowance">
        <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:BoundField>
        <asp:BoundField DataField="monAmount"  HeaderText="Amount" ItemStyle-HorizontalAlign="Center" SortExpression="monAmount" DataFormatString="{0:0.00}">
        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" >
        <ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
        CommandArgument='<%# Eval("intAllowanceId") +","+ Eval("intAllowanceTypeId") +","+ Eval("monAmount") %>' Text="Delete" OnClick="Action_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsallwsummary" runat="server" SelectMethod="GetAllowanceDetails" TypeName="HR_BLL.Loan.Loan">
        <SelectParameters><asp:ControlParameter ControlID="hdnsearch" Name="empcode" PropertyName="Value" Type="String" /></SelectParameters>
        </asp:ObjectDataSource>
        </td></tr>
        </table>



        </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
