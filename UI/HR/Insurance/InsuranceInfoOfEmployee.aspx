<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceInfoOfEmployee.aspx.cs" Inherits="UI.HR.Insurance.InsuranceInfoOfEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
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
                        url: "InsuranceInfoOfEmployee.aspx/GetAutoCompleteData",
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
    </script>
    <%--  <script type="text/javascript">
    window.onload = function() {
  var c = document.getElementById('platypus')
  c.onchange = function() {
    if (c.checked == true) {document.getElementById('answer').style.display = 'inline';}
    else {document.getElementById('answer').style.display = '';
    }
  }
}
</script>
     <style type="text/css">
        #answer {display:none;}
</style>--%>

    <style type="text/css">
        .auto-style1 {
            height: 24px;
        }
    </style>

</head>
<body>
    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>

                <div id="divcontentholder" class="leaveApplication_container">
                    <asp:HiddenField ID="hdnEnrollUnit" runat="server" />

                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr class="tblheader">
                            <td colspan="4">INSURANCE INFORMATION OF EMPLOYEE</td>
                        </tr>

                        <tr class="tblroweven">

                            <td style="text-align: right;" class="auto-style1">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Employee-Search : "></asp:Label></td>
                            <td style="text-align: left;" class="auto-style1">
                                <asp:TextBox ID="txtEmployeeSearch" runat="server" AutoPostBack="true" CssClass="txtBox" Width="210px" OnTextChanged="txtEmployeeSearch_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtEmployeeSearch"
                                    ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                            <td style="text-align: right;" class="auto-style1">
                                <asp:Label ID="Label6" Font-Size="small" runat="server" CssClass="lbl" Text=""></asp:Label></td>
                            <td style="text-align: left;" class="auto-style1">
                                <asp:CheckBox ID="chkGroup" runat="server" Text=" Group" AutoPostBack="true" OnCheckedChanged="chkGroup_CheckedChanged" />
                                <asp:CheckBox ID="chkMedical" runat="server" Text=" Medical" AutoPostBack="true" OnCheckedChanged="chkMedical_CheckedChanged" />
                            </td>

                        </tr>
                        <tr>
                            <td>Insurance Type</td>
                            <td colspan="2">
                                <asp:DropDownList ID="drdlInsuranceType" runat="server" AutoPostBack="true" CssClass="ddList">
                                    <asp:ListItem Selected="True" Value="0">0 k</asp:ListItem>

                                </asp:DropDownList>

                                <asp:DropDownList ID="drdlInsuranceType2" runat="server" AutoPostBack="true" CssClass="ddList">
                                    <asp:ListItem Selected="True" Value="0">0 k</asp:ListItem>
                                    <asp:ListItem Value="1">200 k</asp:ListItem>
                                    <asp:ListItem Value="2">150 k</asp:ListItem>
                                    <asp:ListItem Value="3">100 k</asp:ListItem>
                                    <asp:ListItem Value="4">75 k</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="1">
                                <asp:Button ID="btnCancel" runat="server" CssClass="nextclick" Text="Cancel" OnClientClick="ConfirmAll()" OnClick="btnCancel_Click" /></td>

                        </tr>



                        </tr>
   <%--     <tr>
            <td colspan="2">
                <label for="platypus">Medical?</label>
<input id="platypus" type="checkbox" name="monotreme" value="platypus" />
  <select name="answer" id="answer">
    <option value="1">200 k</option>
    <option value="2">150 k</option>
       <option value="3">100 k</option>
       <option value="4">75 k</option>
  </select>
            </td>
        </tr>--%>

                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr class="tblheader">
                            <td colspan="4">Employee Information :</td>
                        </tr>

                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblEmpCode" CssClass="lbl" runat="server" Text="Employee Code : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEmpCode" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtUnit" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <%--<td style="text-align:right;"><asp:Label ID="lblSupervisorDesignation" CssClass="lbl" runat="server" Text="Supervisor Designation : "></asp:Label></td>
        <td><asp:TextBox ID="txtSupervisorDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" Enabled="true" ReadOnly="true" ></asp:TextBox></td>--%>
                        </tr>

                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblEmpEnroll" CssClass="lbl" runat="server" Text="Enroll : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEmpEnroll" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtJobStation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>
                        </tr>

                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblJobType" CssClass="lbl" runat="server" Text="Job Type : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtJobType" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                        </tr>

                        <tr class="tblroweven">

                            <td style="text-align: right;">
                                <asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDesignation" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Contact No. : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtContact" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                        </tr>

                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDept" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblJoiningDate" CssClass="lbl" runat="server" Text="Joining Date : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtJoiningDate" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                        </tr>

                        <tr class="tblroweven">
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Supervisor Name : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSupervisorName" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label3" Font-Bold="true" ForeColor="Green" CssClass="lbl" runat="server" Text="Date Of Birth : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDateOfB" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateOfB"></cc1:CalendarExtender>
                            </td>

                            <%--<td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name : "></asp:Label></td>
        <td><asp:TextBox ID="txtUnit" BackColor="LightGray" runat="server" CssClass="txtBox" ReadOnly="true" Enabled="true" ></asp:TextBox></td>--%>
                        </tr>


                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr class="tblheader">
                            <td colspan="4">Dependant Information :</td>
                        </tr>
                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblDependantName" CssClass="lbl" runat="server" Text="Dependant Name : "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDependantName" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>

                            <td style="text-align: right;">
                                <asp:Label ID="lblRelationType" CssClass="lbl" runat="server" Text="Relation : "></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlRelationType" runat="server" AutoPostBack="true" CssClass="ddList">
                                    <asp:ListItem Selected="True" Value="1">Spouse</asp:ListItem>
                                    <asp:ListItem Value="2">Daughter</asp:ListItem>
                                    <asp:ListItem Value="3">Son</asp:ListItem>
                                </asp:DropDownList>
                            </td>

                        </tr>

                        <tr class="tblrowodd">
                            <td style="text-align: right;">
                                <asp:Label ID="lblInDate" runat="server" CssClass="lbl" Text="Date Of Birth :"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDateOfBirthD" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
                                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDateOfBirthD"></cc1:CalendarExtender>
                            </td>


                            <td colspan="2">
                                <asp:HiddenField ID="hdnconfirm" runat="server" />
                                <asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" Text="Add" OnClick="btnSubmit_Click" /></td>
                        </tr>

                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="dgvDependant" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDTFareCash_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="15px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Dependant Name" SortExpression="dependantn">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldependantn" runat="server" Text='<%# Bind("dependantn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="320px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Relation" SortExpression="relation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrelation" runat="server" Text='<%# Bind("relation") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="105px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Date Of Birth" SortExpression="dateofbirthd">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldateofbirthd" runat="server" Text='<%# Bind("dateofbirthd") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                        <%--  <asp:TemplateField HeaderText="Type" SortExpression="dateofbirthd"><ItemTemplate>            
        <asp:Label ID="lblmedicaltyepe" runat="server" Text='<%# Bind("medicaltyepe") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>--%>



                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>


                        <tr class="tblroweven">
                            <td colspan="4">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click1" /></td>
                        </tr>

                    </table>

                </div>



                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
