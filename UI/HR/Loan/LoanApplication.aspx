<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Loan.LoanApplication" EnableEventValidation="false" Codebehind="LoanApplication.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Loan Application</title>
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

        function CalculateInstallmentAmount() {
            var loanAmount = document.getElementById('txtLoanAmount').value;
            var numberOfInstallment = document.getElementById('txtNumberOfInstallment').value;
            var remainder = (loanAmount % numberOfInstallment);
            var installmentAmount = parseInt(loanAmount / numberOfInstallment);
            document.getElementById('txtInstallmentAmount').value = installmentAmount;
            var lastInstallment = installmentAmount + remainder;
            var message = 'You have to pay ' + lastInstallment + ' Tk. in your last installment';
            if (remainder > 0) {
                document.getElementById('lblRemenderMessage').innerHTML = message;
            }

        }

        function launchModal(intLoanApplicationId) {
            window.showModalDialog('LoanScheduleDetails.aspx?intLoanApplicationId=' + intLoanApplicationId, null, 'status:no;dialogWidth:650px;dialogHeight:400px;dialogHide:true;help:no;scroll:no');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="FilteredTextBox.FilteredTextBoxBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>


            </Scripts>
        </CompositeScript>
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
                                <b>Loan Application</b>
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
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None" Width="100%">
                <div>
                    <table>
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="Label7" runat="server" Text="Loan Amount" CssClass="label"></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTE6" runat="server" FilterType="Custom, Numbers"
                                    TargetControlID="txtLoanAmount" ValidChars="123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td style="width: 10px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLoanAmount"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                                <asp:Label ID="Label1" runat="server" Text="Number of installment" CssClass="label"></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtNumberOfInstallment" runat="server" CssClass="txt" Width="100px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtNumberOfInstallment" ValidChars="123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td style="width: 10px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumberOfInstallment"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 125px">
                                <asp:Label ID="Label2" runat="server" Text="Installment Amount" CssClass="label"></asp:Label>
                            </td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtInstallmentAmount" runat="server" CssClass="txt" Enabled="false"
                                    Width="100px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    FilterType="Custom, Numbers" TargetControlID="txtInstallmentAmount" ValidChars="123456789.">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </td>
                            <td style="width: 10px">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInstallmentAmount"
                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Label ID="lblRemenderMessage" runat="server" CssClass="label_NoteMessage"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 10px">
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnUserId" runat="server" />
                                <asp:HiddenField ID="hdnApplicationId" runat="server" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="width: 130px">
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" Width="60px"
                                    OnClick="btnAdd_Click" ValidationGroup="VG" />
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnEdit" runat="server" CssClass="button" Text="Edit" Width="60px"
                                    OnClick="btnEdit_Click" ValidationGroup="VG" />
                            </td>
                            <td style="width: 60px">
                                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" Width="60px"
                                    OnClick="btnDelete_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvLoanApplication" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="intLoanApplicationId" SkinID="sknGrid2" Width="750px" OnRowDataBound="dgvLoanApplication_RowDataBound"
                                    OnSelectedIndexChanged="dgvLoanApplication_SelectedIndexChanged" DataSourceID="dgvLoanApplicationObjectDataSource">
                                    <Columns>
                                        <asp:BoundField DataField="intLoanApplicationId" HeaderText="Application Id" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="intLoanApplicationId" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intLoanAmount" HeaderText="Loan Amount" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="intLoanAmount" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intNumberOfInstallment" HeaderText="Installment" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="intNumberOfInstallment" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteApplicationDate" HeaderText="Application Date" DataFormatString="{0:MM/dd/yyyy}"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteApplicationDate"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Approve Status" SortExpression="ApproveStatus">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApproveStatus" runat="server" Text='<%# Bind("ApproveStatus") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnYsnApprove" runat="server" Value='<%# Bind("ysnApprove") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Loan Installment Status" SortExpression="LoanInstallmentStatus">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanInstallmentStatus" runat="server" Text='<%# Bind("LoanInstallmentStatus") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnYsnLoanStatus" runat="server" Value='<%# Bind("ysnLoanStatus") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <tr style="background-color: Green;">
                                            <th scope="col" style="width: 100px">
                                                Application Id
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Loan Amount
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Installment
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Application Date
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Approve Status
                                            </th>
                                            <th scope="col" style="width: 150px">
                                                Loan Installment Status
                                            </th>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="dgvLoanApplicationObjectDataSource" runat="server" SelectMethod="GetAllLoanApplicationByUserID"
                                    TypeName="HR_BLL.Loan.Loan" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnUserId" Name="intUserID" PropertyName="Value"
                                            Type="Int32" />
                                        <asp:Parameter Name="empCode" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
