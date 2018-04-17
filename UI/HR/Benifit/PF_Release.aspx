<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.PF_Release" Codebehind="PF_Release.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Provident Fund Release</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  

    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
                var control = document.getElementById(ControlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false
                }
            }
        }
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("#txtSearchEmployee").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "PF_Release.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchEmployee').value + "'}",
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
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table>
                    <tr>
                        <td style="width: 645px;">
                            <fieldset>
                                <legend></legend>
                                <div>
                                    <table>
                                        <tr style="text-align: left">
                                            <td style="width: 150px">
                                                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search Employee"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSearchEmployee" AutoCompleteType="Search" runat="server" AutoPostBack="true"
                                                    Width="200px" Height="20px"></asp:TextBox>
                                                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchEmployee"
                                                    WatermarkText="Type Name / Code Here" WatermarkCssClass="watermarked" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnSearch" Width="30px" Height="30px" ImageUrl="../../Images/Search.jpg"  runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 320px;">
                            <fieldset>
                                <legend style="border-style: none; border-color: inherit; border-width: medium; font-weight: normal;
                                    font-size: 12px; color: #3b5871; font-family: Arial, Helvetica, sans-serif; text-decoration: none;
                                    margin-left: 0px;">Provident Fund Release Details</legend>
                                <div style="height: 130px">
                                    <table>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label9" runat="server" Text="Employee's Contribution" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmployeesContribution" runat="server" CssClass="txt" ReadOnly="true"
                                                    Width="125px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmployeesContribution"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                <asp:Label ID="Label16" runat="server" CssClass="label" Text="Employers's Contribution"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmployersContribution" runat="server" CssClass="txt" ReadOnly="true"
                                                    Width="125px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmployersContribution"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Profit"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtProfit" runat="server" CssClass="txt" Width="125px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProfit"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 120px">
                                                <asp:Label ID="Label10" runat="server" CssClass="label" Text="Total Payable"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalPayable" runat="server" CssClass="txt" ReadOnly="true" Width="125px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTotalPayable"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                        <td style="width: 320px;">
                            <fieldset>
                                <legend style="border-style: none; border-color: inherit; border-width: medium; font-weight: normal;
                                    font-size: 12px; color: #3b5871; font-family: Arial, Helvetica, sans-serif; text-decoration: none;
                                    margin-left: 0px;">Personal Information:</legend>
                                <div style="height: 130px">
                                    <table>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label5" runat="server" Text="Name" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label12" runat="server" Text="Unit" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtUnit" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label13" runat="server" Text="Department" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label14" runat="server" Text="Designation" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtDesignation" CssClass="txt" Width="200px" runat="server" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label15" runat="server" Text="Job Status" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtJobStatus" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="lblJoiningDate" runat="server" CssClass="label" Text="Joining Date"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtJoiningDate" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 645px;">
                            <fieldset>
                                <legend></legend>
                                <div>
                                    <table>
                                        <tr>
                                            <td style="width: 150px">
                                            </td>
                                            <td>
                                                <asp:Button ID="btnPay" runat="server" CssClass="button" Text="Pay" Width="60px"
                                                    ValidationGroup="VG" OnClick="btnPay_Click" />
                                                <asp:Label ID="lblPaidStatus" runat="server" CssClass="label" ForeColor="Red" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfEmpCode" runat="server" />
                            <asp:HiddenField ID="hdfPaid" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
