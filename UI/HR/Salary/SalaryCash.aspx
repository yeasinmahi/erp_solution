<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalaryCash.aspx.cs" Inherits="UI.HR.Salary.SalaryCash" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server"> <title>.: Cash Salary Profile :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"> <%: Scripts.Render("~/Content/Bundle/jqueryJS") %> </asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
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
                        url: "SalaryCash.aspx/GetAutoCompleteData",
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
            document.getElementById("hdnAction").value = "";
            var txtAccholdr = document.forms["frmcash"]["txtAccholdr"].value;
            var txtAccountNo = document.forms["frmcash"]["txtAccountNo"].value;
            var txtAmount = document.forms["frmcash"]["txtAmount"].value;

            if (txtAccholdr.length <= 0 || txtAccholdr == "" || txtAccholdr == null)
            { alert("Please enter valid account holder ."); }
            else if (txtAccountNo.length <= 0 || txtAccountNo == "" || txtAccountNo == null)
            { alert("Please enter valid account no."); }
            else if (!isDecimal(txtAmount) || txtAmount.length <= 0)
            { alert("Please enter valid amount ."); }
            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnAction").value = "0"; }
                else { confirm_value.value = "No"; document.getElementById("hdnAction").value = ""; }
                __doPostBack();
            }
        }
        function isDecimal(value) {return parseFloat(value) == value;} // Check Intiger values by value % 1 === 0;        
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
    <form id="frmcash" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
    <CompositeScript>
        <Scripts>
            <asp:ScriptReference name="MicrosoftAjax.js"/>
		    <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		    <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		    <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts>
    </CompositeScript>
    </asp:ScriptManager>
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
<%--=========================================Start My Code From Here===============================================--%>
    <div class="divs_content_container">
     <div class="tabs_container"> Employee Cash Salary :<asp:HiddenField ID="hdnAction" runat="server" /><hr /></div>

    <table style="width:Auto;">
    <tr><td style="text-align:right;"><asp:Label ID="lblemployeesearch" CssClass="lbl" runat="server" Text="Employee-Search : "></asp:Label></td><td>
    <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>
    <td style="text-align:right;"><asp:Label ID="lbljobstatus" CssClass="lbl" runat="server" Text="Job-Status : "></asp:Label></td>
    <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    </tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit-Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblstation" CssClass="lbl" runat="server" Text="Job-Station : "></asp:Label></td>
    <td><asp:TextBox ID="txtStation" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    </tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lbldepartment" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
    <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
    <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    </tr>
                
    <tr>
    <td style="text-align:right;"><asp:Label ID="lblgross" CssClass="lbl" runat="server" Text="Gross Salary : "></asp:Label></td>
    <td><asp:TextBox ID="txtGross" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblbasic" CssClass="lbl" runat="server" Text="Basic Salary : "></asp:Label></td>
    <td><asp:TextBox ID="txtBasic" runat="server" CssClass="txtBox" ReadOnly="true"></asp:TextBox></td>
    </tr>

    <tr><td colspan="4" style="text-align:left;"><hr /></td></tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblacchldr" CssClass="lbl" runat="server" Text="Acc. Holder : "></asp:Label></td>
    <td><asp:TextBox ID="txtAccholdr" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lblacc" CssClass="lbl" runat="server" Text="Account No : "></asp:Label></td>
    <td><asp:TextBox ID="txtAccountNo" runat="server" CssClass="txtBox"></asp:TextBox></td>              
    </tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblbank" CssClass="lbl" runat="server" Text="Bank List : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlBank" runat="server" CssClass="dropdownList" DataSourceID="odsbnk" DataTextField="strBankName" DataValueField="intID" ></asp:DropDownList>
    <asp:ObjectDataSource ID="odsbnk" runat="server" SelectMethod="GetAllBankList" TypeName="HR_BLL.Global.District" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    </td>
    <td style="text-align:right;"><asp:Label ID="lbldistrict" CssClass="lbl" runat="server" Text="District List : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="dropdownList" AutoPostBack="True" DataSourceID="odsdist" DataValueField="intDistrictID" DataTextField="strDistrict"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsdist" runat="server" SelectMethod="GetAllDistrictList" TypeName="HR_BLL.Global.District" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
    </td>
    </tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblbranch" CssClass="lbl" runat="server" Text="Branch List : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropdownList" DataSourceID="odsbranch" 
    DataTextField="strBankBranchName" DataValueField="intBranchID"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsbranch" runat="server" SelectMethod="GetBankBranchList" TypeName="HR_BLL.Global.District" OldValuesParameterFormatString="original_{0}">
    <SelectParameters><asp:ControlParameter ControlID="ddlBank" Name="bankid" PropertyName="SelectedValue" Type="Int32" />
    <asp:ControlParameter ControlID="ddlDistrict" Name="distid" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
    </asp:ObjectDataSource>
    </td>
    <td style="text-align:right;"><asp:Label ID="lblamnt" CssClass="lbl" runat="server" Text="Amount : "></asp:Label></td>
    <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Text="0.00"></asp:TextBox></td>
    </tr>

    <tr><td style="text-align:right;"><asp:Label ID="lblappointment" CssClass="lbl" runat="server" Text="Effective Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtEDate" runat="server" CssClass="txtBox"></asp:TextBox><cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEDate"></cc1:CalendarExtender> </td>
    <td colspan="2" style="text-align:right;"><a class="nextclick" onclick="Confirm()">Submit</a></td></tr>
    </table><br /></div>
    <asp:GridView ID="dgvcash" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderStyle="Solid" 
    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" DataSourceID="odscl"><AlternatingRowStyle BackColor="#CCCCCC" Font-Bold="true" />
    <Columns><asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField> 
    <asp:BoundField DataField="Effected" HeaderText="Effected" ItemStyle-HorizontalAlign="Center" SortExpression="Effected">
    <ItemStyle HorizontalAlign="Left" Width="60px" /></asp:BoundField>
    <asp:BoundField DataField="strAccountHolder" HeaderText="Account Holder" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountHolder">
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
    <asp:BoundField DataField="strAccountNo" HeaderText="AccountNo" ItemStyle-HorizontalAlign="Center" SortExpression="strAccountNo">
    <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField>
    <asp:BoundField DataField="strBankName" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName">
    <ItemStyle HorizontalAlign="Left" Width="190px" /></asp:BoundField>
    <asp:BoundField DataField="strBankBranchName" HeaderText="Branch Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankBranchName">
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
    <asp:BoundField DataField="strDistrict" HeaderText="District" ItemStyle-HorizontalAlign="Center" SortExpression="strDistrict">
    <ItemStyle HorizontalAlign="Left" Width="100px" /></asp:BoundField>
    <asp:BoundField DataField="monAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Center" SortExpression="monAmount" DataFormatString="{0:0.00}">
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField>
    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ><ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:8px;" 
    CommandArgument='<%# Eval("intAllowanceId")+"^"+ Eval("CashId")%>' Text="Delete" ForeColor="Red" OnClientClick="ConfirmDelete()" OnClick="Action_Click"/>
    </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>  
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    <asp:ObjectDataSource ID="odscl" runat="server" SelectMethod="GetCashSalary" TypeName="HR_BLL.Salary.SalaryInfo">
    <SelectParameters><asp:ControlParameter ControlID="hdfEmpCode" Name="empcode" PropertyName="Value" Type="String" /></SelectParameters></asp:ObjectDataSource>
    <asp:HiddenField ID="hdndelete" runat="server" />

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
