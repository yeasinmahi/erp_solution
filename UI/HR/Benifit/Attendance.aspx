<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="UI.HR.Benifit.Attendance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/datepickr.min.js"></script>
<script type="text/javascript">
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
                    url: "Attendance.aspx/GetAutoCompleteData",
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
        var fullname = document.forms["frmattbnft"]["txtEmployeeSearch"].value;
        var monAmount = document.forms["frmattbnft"]["txtAmount"].value;
        if (fullname.length <= 0 || fullname == "" || fullname == null)
        { alert("Please enter valid employee ."); }
        else if (!isDecimal(monAmount) || monAmount.length <= 0 || monAmount == "0" || monAmount == "0.00")
        { alert("Please enter valid amount ."); }        
        else {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
    }
    function isDecimal(value) { return parseFloat(value) == value;}
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
    <form id="frmattbnft" runat="server">
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
        <div class="tabs_container"> Employee Attendance Benifit :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/><hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
        <td><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lbljobtype" CssClass="lbl" runat="server" Text="Job-Type : "></asp:Label></td>
        <td><asp:TextBox ID="txtJobtype" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr class="tblroweven">   
        <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
        <td style="text-align:right;"><asp:Label ID="lblamount" CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
        <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Text="0.00" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Benifit : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlBType" runat="server" CssClass="dropdownList" DataSourceID="odsblst" DataTextField="strBenifit" DataValueField="intBenifit"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsblst" runat="server" SelectMethod="GetBenifitList" TypeName="HR_BLL.Benifit.Bonus_BLL"></asp:ObjectDataSource></td>
        <td colspan="2" style="text-align:right;"><asp:Button ID="btnSave" runat="server" class="nextclick" style="font-size:11px;" 
        Text="SAVE" OnClick="btnSave_Click"  OnClientClick = "Confirm()"/> <asp:HiddenField ID="hdnconfirm" runat="server"/></td></tr>
        
        <tr><td colspan="4"><asp:GridView ID="dgvBenifit" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odsbnft"><AlternatingRowStyle BackColor="#CCCCCC" Font-Bold="true" />
        <Columns><asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField> 
        <asp:BoundField DataField="Descriptions" HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="Descriptions">
        <ItemStyle HorizontalAlign="Left" Width="650px" /></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ><ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:8px;" 
        CommandArgument='<%# Eval("intRow") %>' Text="Delete" ForeColor="Red" OnClientClick="ConfirmDelete()" OnClick="Action_Click"/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
        <asp:ObjectDataSource ID="odsbnft" runat="server" SelectMethod="GetAttendanceBenifitList" TypeName="HR_BLL.Benifit.Bonus_BLL">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" /></SelectParameters>
        </asp:ObjectDataSource><asp:HiddenField ID="hdndelete" runat="server" /></td></tr>
        </table>



        </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
