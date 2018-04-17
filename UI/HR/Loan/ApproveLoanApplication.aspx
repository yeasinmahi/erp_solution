<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Loan.ApproveLoanApplication" EnableEventValidation="false" Codebehind="ApproveLoanApplication.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Approve Loan Application</title>
   
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
        function GetCurrentDate() {
            var today = new Date(); var dd = today.getDate(); var mm = today.getMonth() + 1; //January is 0! 
            var yyyy = today.getFullYear();
            if (dd < 10) {
                dd = '0' + dd
            }
            if (mm < 10) {
                mm = '0' + mm
            }
            var today = mm + '/' + dd + '/' + yyyy;

            return today;
        }

        function showDate() {
            //            if (sender._textbox.get_element().value == "") {
            //                var todayDate = new Date();
            //                sender._selectedDate = todayDate;
            //            }

            alert('ghj')
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
                                <b>Approve Loan Application</b>
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
                            <td>
                                <asp:GridView ID="dgvApproveLoanApplication" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    SkinID="sknGrid2" Width="750px" DataSourceID="odsUnApproveLoanApplicationForApproveByUserID"
                                    OnRowDataBound="dgvApproveLoanApplication_RowDataBound" OnRowCancelingEdit="dgvApproveLoanApplication_RowCancelingEdit"
                                    OnRowEditing="dgvApproveLoanApplication_RowEditing" 
                                    OnRowUpdated="dgvApproveLoanApplication_RowUpdated">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employeee Name" SortExpression="strEmployeeName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>'
                                                    Enabled="false"></asp:Label>
                                                <asp:HiddenField ID="hdnEmployeeID" runat="server" Value='<%# Bind("intEmployeeID") %>' />
                                                <asp:HiddenField ID="hdnApplicationId" runat="server" Value='<%# Bind("intLoanApplicationId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" ReadOnly="true"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="strDesignation"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strDepatrment" HeaderText="Depatrment" ReadOnly="true"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="strDepatrment"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteApplicationDate" HeaderText="Application Date" DataFormatString="{0:MM/dd/yyyy}"
                                            ReadOnly="true" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteApplicationDate"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intLoanAmount" HeaderText="Loan Amount" ReadOnly="true"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="intLoanAmount">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="intNumberOfInstallment" HeaderText="Installment" ReadOnly="true"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="intNumberOfInstallment">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Approve Amount" SortExpression="intLoanAmount">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtLoanAmount" runat="server" Text='<%# Bind("intLoanAmount") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7658" runat="server" ControlToValidate="txtLoanAmount"
                                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender222" runat="server"
                                                    FilterType="Custom, Numbers" TargetControlID="txtLoanAmount" ValidChars="123456789.">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("intLoanAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approve Installment" SortExpression="intNumberOfInstallment">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtNumberOfApproveAmount" runat="server" Text='<%# Bind("intNumberOfInstallment") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ControlToValidate="txtNumberOfApproveAmount"
                                                    ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2487" runat="server"
                                                    FilterType="Custom, Numbers" TargetControlID="txtNumberOfApproveAmount" ValidChars="123456789.">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("intNumberOfInstallment") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Effective Date" SortExpression="dteEffectiveDate">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEffectiveDate" runat="server" Text='<%# bind("dteEffectiveDate") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEffectiveDate2" runat="server" Text='<%# bind("dteEffectiveDate") %>'></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender26987" runat="server"
                                                    FilterType="Custom, Numbers" TargetControlID="txtEffectiveDate2" ValidChars="123456789-/">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" CssClass="cal_Theme1" Format="dd-MM-yyyy"
                                                    TargetControlID="txtEffectiveDate2">
                                                </ajaxToolkit:CalendarExtender>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtEffectiveDate2"
                                                    Display="Dynamic" ErrorMessage="Invalid Date" Operator="DataTypeCheck" Type="Date">
                                                </asp:CompareValidator>
                                                <ajaxToolkit:ValidatorCalloutExtender ID="CompareValidator1_ValidatorCalloutExtender"
                                                    runat="server" Enabled="True" TargetControlID="CompareValidator1">
                                                </ajaxToolkit:ValidatorCalloutExtender>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Approve" UpdateText="Approve"
                                            ValidationGroup="VG" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <tr style="background-color: Green;">
                                            <th scope="col" style="width: 100px">
                                                Employee Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Designation
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Depatrment
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Application Date
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Loan Amount
                                            </th>
                                            <th scope="col" style="width: 150px">
                                                Installment
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Approve Amount
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Approve Installment
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Effective Date
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Approve
                                            </th>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsUnApproveLoanApplicationForApproveByUserID" 
                                    runat="server" SelectMethod="GetAllUnApprovedLoanApplicationByUserID" 
                                    TypeName="HR_BLL.Loan.Loan" UpdateMethod="ApproveLoanApplicationData">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnUserID" Name="intUserID" 
                                            PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="strEmployeeName" Type="String" />
                                        <asp:Parameter Name="intEmployeeID" Type="Int32" />
                                        <asp:Parameter Name="intLoanApplicationId" Type="Int32" />
                                        <asp:Parameter Name="intLoanAmount" Type="Int32" />
                                        <asp:Parameter Name="intNumberOfInstallment" Type="Int32" />
                                        <asp:Parameter Name="dteEffectiveDate" Type="DateTime" />
                                        <asp:Parameter Name="userID" Type="Int32" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="dgvApproveLoanApplicationObjectDataSource" runat="server"
                                    SelectMethod="SprGetAllUnapproveLoanApplicationForApprove" TypeName="HR_BLL.Loan.Loan"
                                    OldValuesParameterFormatString="original_{0}" UpdateMethod="ApproveLoanApplicationData">
                                    <UpdateParameters>
                                        <asp:Parameter Name="strEmployeeName" Type="String" />
                                        <asp:Parameter Name="intEmployeeID" Type="Int32" />
                                        <asp:Parameter Name="intLoanApplicationId" Type="Int32" />
                                        <asp:Parameter Name="intLoanAmount" Type="Int32" />
                                        <asp:Parameter Name="intNumberOfInstallment" Type="Int32" />
                                        <asp:Parameter Name="dteEffectiveDate" Type="DateTime" />
                                        <asp:FormParameter Name="userID" Type="Int32" FormField="hdnUserID" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                                <asp:HiddenField ID="hdnUserID" runat="server" />
                                <asp:HiddenField ID="hdnDate" runat="server" />
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
