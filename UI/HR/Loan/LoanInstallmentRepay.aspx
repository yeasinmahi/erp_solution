<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Loan.LoanInstallmentRepay" Codebehind="LoanInstallmentRepay.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Update Loan Schedule</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
    
    
   <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  

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
                        url: "LoanInstallmentRepay.aspx/GetAutoCompleteData",
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>Repay Loan Installment</b>
                            </td>
                        </tr>
                    </table>
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
                            <div>
                                <table>
                                    <tr style="text-align: left">
                                        <td style="width: 100px">
                                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search Employee"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearchEmployee"  runat="server" AutoPostBack="true"
                                                Width="250px" Height="20px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnSearch" Width="30px" Height="30px" ImageUrl="../../Images/Search.jpg"
                                                runat="server" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                    <tr style="text-align: left">
                                        <td style="width: 100px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr style="text-align: left">
                                        <td style="width: 100px">
                                            <asp:Label ID="Label16" runat="server" CssClass="label" Text="Repay Amount"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRepayLoanAmount" runat="server" CssClass="txt" 
                                                Width="250px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvtxtRepayLoanAmount" runat="server" ControlToValidate="txtRepayLoanAmount"
                                                ForeColor="Red" Text="*" ValidationGroup="validaiton" />
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtRepayLoanAmount" runat="server" FilterType="Custom, Numbers"
                                                TargetControlID="txtRepayLoanAmount" ValidChars="123456789.">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                            <asp:Button ID="btnRepay" runat="server" CssClass="button" OnClick="btnRepay_Click"
                                                Text="Repay" ValidationGroup="validaiton" Width="60px" />
                                        </td>
                                    </tr>
                                    <tr style="text-align: left">
                                        <td style="width: 100px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 480px; vertical-align: top">
                            <div style="text-align: center">
                                <table width="650px">
                                    <tr style="text-align: center">
                                        <td>
                                            <asp:GridView ID="dgvLoanScheduleDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                Width="630px" SkinID="sknGrid2" DataSourceID="dgvLoanScheduleDetailsObjectDataSource">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Schedule Number" SortExpression="intScheduleId">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label61" runat="server" Text='<%# Bind("intScheduleId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Month" SortExpression="intMonth">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label71" runat="server" Text='<%# Bind("intMonth") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Year" SortExpression="intYear">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label18" runat="server" Text='<%# Bind("intYear") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Amount" SortExpression="intInstallmentAmount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label51" runat="server" Text='<%# Bind("intInstallmentAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="250px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment Status" SortExpression="strInstallmentStatus">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("strInstallmentStatus") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="250px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 320px; vertical-align: top">
                            <fieldset>
                                <legend>Personal Information:</legend>
                                <div>
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
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblTotalRemaining" runat="server" CssClass="label"></asp:Label>
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
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfEmpCode" runat="server" />
                            <asp:ObjectDataSource ID="dgvLoanScheduleDetailsObjectDataSource" runat="server"
                                SelectMethod="GetLoanScheduleDetailsByLoanApplicationID" TypeName="HR_BLL.Loan.Loan"
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnLoanApplicationId" Name="intLoanApplicationId"
                                        PropertyName="Value" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdnLoanApplicationId" runat="server" />
                            <asp:HiddenField ID="hdfTotalLoanScheduleAmount" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
