<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.PF_Investment"
    EnableEventValidation="false" Codebehind="PF_Investment.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Provident Fund Investment</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function GotoNextFocus(controlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode;
            if (unicode == 13) {
                var control = document.getElementById(controlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false;
                }
            }
        }

        function ShowInvestmentDetailsArea() {
            document.getElementById("divInvestmentDetails").style.display = "block";
            document.getElementById("divInvestment").style.display = "none";
        }
        function HideInvestmentDetailsArea() {
            document.getElementById("divInvestmentDetails").style.display = "none";
            document.getElementById("divInvestment").style.display = "block";

        }
 
    </script>
    <style type="text/css">
      #divInvestmentDetails
        {
            width: 350px;
            position: absolute;
            height: 230px;
            top: 100px;
            border: 1px inset #000;
            display: none;
            padding: 3px;
            z-index: 220;
            float: left;
            color: White;
        }
       #divInvestment
        {
            width: 350px;
            position: absolute;
            top: 100px;
            border: 1px inset #000;
            display: block;
            padding: 3px;
            float: left;
            color: White;
        }
    </style>
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
                                <b>Investment</b>
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
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None" Width="380px">
                <div id="divInvestment">
                    <table>
                        <tr>
                            <td colspan="5"><%--style="border: 2px solid black"--%>
                                <asp:GridView ID="dgvPF_Investment" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    DataKeyNames="intPfUnitId" DataSourceID="odsInvestmentDetails" OnRowDataBound="dgvPF_Investment_RowDataBound"
                                    SkinID="sknGrid2" Width="359px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Unit Id" SortExpression="intPfUnitId" Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%# Bind("intPfUnitId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField SortExpression="ysnChecked">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                            </ItemTemplate>
                                            <ControlStyle Width="25px" />
                                            <ItemStyle HorizontalAlign="Left" Width="25px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="totalPFAmountPerMonth" HeaderText="Amount" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="totalPFAmountPerMonth" Visible="true" DataFormatString="{0:0.00}">
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Month Name" SortExpression="strMonthName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMonthName" runat="server" Text='<%# Bind("strMonthName") %>'></asp:Label>
                                                <asp:HiddenField ID="hdnMonthID" runat="server" Value='<%# Bind("intMonthId") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intYearId" HeaderText="Year" ItemStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="100px" SortExpression="intYearId">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <tr style="background-color: Green;">
                                            <th scope="col" style="width: 100px">
                                                Select
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Amount
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Month Name
                                            </th>
                                            <th scope="col" style="width: 100px">
                                                Year
                                            </th>
                                        </tr>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsInvestmentDetails" runat="server" 
                                    SelectMethod="GetAllNonInvestedRecievedPfTransaction" 
                                    TypeName="HR_BLL.Benifit.PF_Investment_BLL">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnSoftwareLoginUserId" 
                                            Name="intSoftwareLoginUserID" PropertyName="Value" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
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
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnInvestment" runat="server" Text="Investment" 
                                    CssClass="button" onclick="btnInvestment_Click"/>
                            </td>
                            <td>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="lblTotalSelectedAmount" runat="server" Text="" CssClass="label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hdnSoftwareLoginUserId" runat="server" />
                <asp:HiddenField ID="hdnIntPfUnitId" runat="server" />
            </asp:Panel>
            <div id="divInvestmentDetails">
                <table>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="label" Text="PF Bank Account"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlPfBankAccount" runat="server" CssClass="DropDown" Width="220px"
                                DataSourceID="odsPfBankAccount" DataTextField="Text" 
                                DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPfBankAccount"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsPfBankAccount" runat="server" 
                                SelectMethod="GetBankAccountNoBy_PfUnitIdAndSearchKey" 
                                TypeName="HR_BLL.Benifit.PfBankAccountDetails_BLL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnIntPfUnitId" Name="intPfUnitId" 
                                        PropertyName="Value" Type="Int32" />
                                    <asp:Parameter DefaultValue="PFBankAccount" Name="strSearchKey" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="label" Text="Invesetment Account"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlPfInvestmentAccount" runat="server" 
                                CssClass="DropDown" Width="220px" DataSourceID="odsPfInvestmentAccountNo" 
                                DataTextField="Text" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                ControlToValidate="ddlPfInvestmentAccount" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsPfInvestmentAccountNo" runat="server" 
                                SelectMethod="GetBankAccountNoBy_PfUnitIdAndSearchKey" 
                                TypeName="HR_BLL.Benifit.PfBankAccountDetails_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnIntPfUnitId" Name="intPfUnitId" 
                                        PropertyName="Value" Type="Int32" />
                                    <asp:Parameter DefaultValue="InvestmentAccount" Name="strSearchKey" 
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="label" Text="Investment Type"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlInvestmentType" runat="server" 
                                CssClass="DropDown" 
                                Width="220px" DataSourceID="odsInvestmentType" DataTextField="Text" 
                                DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ControlToValidate="ddlInvestmentType" ErrorMessage="*" ForeColor="Red" 
                                ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsInvestmentType" runat="server" 
                                SelectMethod="GetInvestmentType" 
                                TypeName="HR_BLL.Benifit.PF_Investment_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Capital" CssClass="label"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtInvestmentAmount" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender runat="server" ID="FTE_Investment" FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890." TargetControlID="txtInvestmentAmount"></ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                ControlToValidate="txtInvestmentAmount" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Interest Rate" CssClass="label"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtInterestRate" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender1" FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890." TargetControlID="txtInterestRate"></ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                ControlToValidate="txtInterestRate" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Duration" CssClass="label"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtDuration" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender runat="server" ID="FilteredTextBoxExtender2" FilterMode="ValidChars" FilterType="Custom" ValidChars="1234567890." TargetControlID="txtDuration"></ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                ControlToValidate="txtDuration" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Effected Date" CssClass="label"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="txtEffectedDate" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CDX" runat="server" TargetControlID="txtEffectedDate">
                            </ajaxToolkit:CalendarExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                ControlToValidate="txtEffectedDate" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEffectedDate"
                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 55px">
                            <asp:Button ID="btnInvest" runat="server" Width="55px" CssClass="button" ValidationGroup="VG" Text="Invest"
                                OnClick="btnInvest_Click" />
                        </td>
                        <td style="width: 165px">
                            <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClientClick="HideInvestmentDetailsArea();" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
