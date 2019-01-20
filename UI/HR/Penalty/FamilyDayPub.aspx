<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FamilyDayPub.aspx.cs" Inherits="UI.HR.Penalty.FamilyDayPub" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
<script>
    $(document).ready(function () {SearchText();});
    function Changed() {document.getElementById('hdnsearch').value = 'true';}
    function SearchText() {
        $("#txtEmployeeSearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    contentType: "application/json;",
                    url: "FamilyDayPub.aspx/GetAutoCompleteData",
                    data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);
                    },
                    error: function (result) {}//alert("Error");
                    
                });
            }
        });
    }
    function Validation() {
        document.getElementById("hdnconfirm").value = "0";
        var ctp = document.forms["frmpubfmlydy"]["ddlChild"].value;
        var cname = document.forms["frmpubfmlydy"]["txtChild"].value;
        var cdob = document.forms["frmpubfmlydy"]["txtCDOB"].value;
        document.getElementById("hdncdob").value = cdob;
        if ((ctp == "1") && (cname == null || cname == "")) { alert("Please fillup child information properly."); }
        else if ((ctp == "1") && (cdob == null || cdob == "")) {alert("Please fillup child DOB by valid formate (yyyy-MM-dd)");} 
        else {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want add child?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
    }
    function ConfirmAll() {
        document.getElementById("hdnconfirm").value = "0";
        var searemp = document.forms["frmpubfmlydy"]["txtEmployeeSearch"].value;
        var pnd = document.forms["frmpubfmlydy"]["ddlPnD"].value;
        var ptp = document.forms["frmpubfmlydy"]["ddlPtype"].value;
        var sname = document.forms["frmpubfmlydy"]["txtSpouse"].value;
        //var sdob = document.forms["frmpubfmlydy"]["txtSDOB"].value;
        //document.getElementById("hdnsdob").value = sdob;

        if (searemp == null || searemp == "") { alert("Please select a manpower."); }
        else if (pnd == "0") { alert("Please select pick and drop point."); }
        else if ((ptp == "1") && (sname == null || sname == "")) { alert("Please fillup spouse information properly."); }
        //else if ((ptp == "1") && (sdob == null || sdob == "")) { alert("Please fillup spouse DOB by valid formate (yyyy-MM-dd)."); }
        else {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
    }
    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
    }
</script>

</head>
<body>
    <form id="frmpubfmlydy" runat="server">
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
    <table style="width:auto; float:left; ">  
    <tr class="tblheader"><td colspan="4"> Akij Group Corporate Family Day' 2019:<asp:HiddenField ID="hdnsearch" runat="server"/>
    <asp:HiddenField ID="hdncode" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /></td></tr>
     
    <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblsrch" CssClass="lbl" runat="server" Text="Search : "></asp:Label></td>
    <td><asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbldeg" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
    <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lbldep" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
    <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblunt" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
    <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblpnt" CssClass="lbl" runat="server" Text="Jobstation : "></asp:Label></td>
    <td><asp:TextBox ID="txtJobstation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbljtp" CssClass="lbl" runat="server" Text="Jobtype : "></asp:Label></td>
    <td><asp:TextBox ID="txtJobtype" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
    </tr>
    
    <tr class="tblroweven">
    <td style="text-align:right;"><asp:Label ID="lbldoj" CssClass="lbl" runat="server" Font-Bold="true" Text="Pick & Drop Point : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlPnD" runat="server" CssClass="ddList" AutoPostBack="false"></asp:DropDownList></td>
    <td style="text-align:right;"><asp:Label ID="lblptp" CssClass="lbl" runat="server" Font-Bold="true" Text="Participate in Family Day : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlPtype" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlPtype_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="0">Self</asp:ListItem><asp:ListItem Value="1">With Family</asp:ListItem></asp:DropDownList></td>
    </tr>

    <tr class="tblheader"><td style="text-align:right;"><asp:Label ID="lblsps" CssClass="lbl" runat="server" Text="Spouse Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtSpouse" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbldob" CssClass="lbl" runat="server" Text="Date Of Birth : "></asp:Label></td>
    <td><asp:TextBox ID="txtSDOB" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdnsdob" runat="server"/>
    <cc1:CalendarExtender ID="CEB" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSDOB"></cc1:CalendarExtender></td>
    </tr>

    <tr class="tblheader">
    <td style="text-align:right;"><asp:Label ID="lblgender" CssClass="lbl" runat="server" Text="Gender : "></asp:Label></td>
    <td colspan="3"><asp:DropDownList ID="ddlSGender" runat="server" AutoPostBack="false" CssClass="dropdownList">
    <asp:ListItem Selected="True" Value="M">Male</asp:ListItem><asp:ListItem Value="F">Female</asp:ListItem></asp:DropDownList></td>
    </tr>

    <tr class="tblroweven">
    <td style="text-align:right;"><asp:Label ID="lblchld" CssClass="lbl" runat="server" Font-Bold="true" Text="Children : "></asp:Label></td>
    <td colspan="3"><asp:DropDownList ID="ddlChild" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlChild_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="0">No</asp:ListItem><asp:ListItem Value="1">Yes</asp:ListItem></asp:DropDownList></td>
    </tr>

    <tr class="tblheader"><td style="text-align:right;"><asp:Label ID="lblcld" CssClass="lbl" runat="server" Text="Child Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtChild" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblcdob" CssClass="lbl" runat="server" Text="Date Of Birth : "></asp:Label></td>
    <td><asp:TextBox ID="txtCDOB" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox><asp:HiddenField ID="hdncdob" runat="server"/>
    <cc1:CalendarExtender ID="cc1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtCDOB"></cc1:CalendarExtender></td>
    </tr>

    <tr class="tblheader">
    <td style="text-align:right;"><asp:Label ID="lblcgndr" CssClass="lbl" runat="server" Text="Gender : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlCGender" runat="server" AutoPostBack="false" CssClass="dropdownList">
    <asp:ListItem Selected="True" Value="S">Son</asp:ListItem><asp:ListItem Value="D">Daughter</asp:ListItem></asp:DropDownList></td>
    <td colspan="2" style="text-align:right;"><asp:Button id="btnAdd" runat="server" Text="Add-To-List" OnClientClick = "Validation()" onclick="btnAdd_Click"/>
    </td></tr>
    <tr class=""><td colspan="4" style="text-align:right;"><asp:GridView ID="dgvfml" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvfml_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Child Name" SortExpression="childnm">
        <ItemTemplate><asp:Label ID="lblchildnm" runat="server" Text='<%# Bind("childnm") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="330px" /></asp:TemplateField>
        <asp:TemplateField HeaderText="Gender" SortExpression="childgndr">
        <ItemTemplate><asp:Label ID="lblchildgndr" runat="server" Text='<%# Bind("childgndr") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>
        <asp:TemplateField HeaderText="Date Of Birth" SortExpression="childdob" >
        <ItemTemplate><asp:Label ID="lblchilddob" runat="server" Text='<%# Eval("childdob", "{0:dd-MM-yyyy}") %>' ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>
        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td></tr>
    <tr class="tblroweven"><td style="text-align:right;" colspan="4"><asp:Button id="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" OnClientClick = "ConfirmAll()"/></td></tr>
    
    <tr class=""><td style="text-align:right;" colspan="4">
    <asp:GridView ID="dgvList" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odssummary"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="Employee Name" SortExpression="empname">
    <ItemTemplate><asp:Label ID="lblempnm" runat="server" Text='<%# Bind("empname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Pick & Drop" SortExpression="pnd">
    <ItemTemplate><asp:Label ID="lblpnd" runat="server" Text='<%# Bind("pnd") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="285px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Participate" SortExpression="ptype" >
    <ItemTemplate><asp:Label ID="lblpart" runat="server" Text='<%# Bind("ptype") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Right" Width="75px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
    <ItemTemplate><asp:Button ID="btnCancel" class="button" runat="server" Font-Size="10px" ForeColor="Red" OnClick="Cancel_Click" OnClientClick="Confirm()" 
    CommandArgument='<%# Eval("mid") +"^"+ Eval("did") %>' Text="Cancel" /></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView><asp:ObjectDataSource ID="odssummary" runat="server" SelectMethod="Familydayinformation" TypeName="HR_BLL.Penalty.Penalty" OldValuesParameterFormatString="original_{0}">
    <SelectParameters><asp:Parameter DefaultValue="2" Name="type" Type="Int32" />
    <asp:ControlParameter ControlID="hdncode" Name="empcode" PropertyName="Value" Type="String" DefaultValue="" /><asp:Parameter DefaultValue="1" Name="pnd" Type="Int32" />
    <asp:Parameter DefaultValue="1" Name="ptype" Type="String" /><asp:Parameter DefaultValue="" Name="sname" Type="String" />
    <asp:Parameter Name="sgndr" Type="String" /><asp:Parameter Name="sdob" Type="String" /><asp:Parameter DefaultValue="1" Name="actionBy" Type="Int32" />
    <asp:Parameter DefaultValue="" Name="xmlstring" Type="String" /></SelectParameters></asp:ObjectDataSource>
    </td></tr>

    </table>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
