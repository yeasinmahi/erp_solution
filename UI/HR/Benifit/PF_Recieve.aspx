<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.PF_Recieve" EnableEventValidation="false" Codebehind="PF_Recieve.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>PF Bank Recieve</title>
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
                                <b>PF Recieve</b>
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
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="label" Text="Unit"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlUnit" runat="server" CssClass="DropDown" DataSourceID="odsPfUnit"
                                DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlUnit"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsPfUnit" runat="server" 
                                SelectMethod="GetAllPfUnitIdAndNameByLoginUserId" TypeName="HR_BLL.Global.Unit"
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnLoginUserId" Name="intLoginUserId" PropertyName="Value"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="label" Text="Account No."></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlAccountNo" runat="server" CssClass="DropDown" DataSourceID="odsPfAccount"
                                DataTextField="Text" DataValueField="Value">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAccountNo"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsPfAccount" runat="server" SelectMethod="GetPfAccountByUint"
                                TypeName="HR_BLL.Benifit.PF_Recieve_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="intUnit" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="label" Text="Vouchar No."></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlVoucharNo" runat="server" CssClass="DropDown" 
                                DataSourceID="odsVoucharNo" DataTextField="Text" DataValueField="Value" 
                                onselectedindexchanged="ddlVoucharNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlVoucharNo"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsVoucharNo" runat="server" 
                                SelectMethod="GetVoucharCodeByUnitId" 
                                TypeName="HR_BLL.Benifit.PF_Recieve_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="intPfUnitId" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="label" Text="Cheque No."></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtChequeNo" runat="server" Width="235px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtChequeNo"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="label" Text="Amount"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtAmount" runat="server" Width="157px" ReadOnly="True"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtAmount" runat="server" FilterMode="ValidChars"
                                FilterType="Custom" TargetControlID="txtAmount" ValidChars="1234567890.">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAmount"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Particulars"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtParticulars" runat="server" TextMode="MultiLine" Width="235px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtParticulars"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="3">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 60px">
                            <asp:Button ID="btnRecieve" runat="server" CssClass="button" Text="Recieve" Width="70px"
                                OnClick="btnRecieve_Click" ValidationGroup="VG" />
                        </td>
                        <td style="width: 60px">
                            &nbsp;</td>
                        <td style="width: 115px">
                            &nbsp;</td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvPF_BankRecieve" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                SkinID="sknGrid2" Width="760px" DataKeyNames="intPF_RecieveID" DataSourceID="odsPF_BankRecieve"
                                OnRowDataBound="dgvPF_BankRecieve_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Unit" SortExpression="intUnitId" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnUnitId" runat="server" Value='<%# Bind("intPfUnitId") %>' />
                                            <asp:HiddenField ID="hdnPF_RecieveID" runat="server" Value='<%# Bind("intPF_RecieveID") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                     <asp:BoundField DataField="dteRecieveDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Entry Date"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px" SortExpression="dteRecieveDate"
                                        Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Account No." SortExpression="strAccountNo" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAccountNo" runat="server" Text='<%# Bind("strAccountNo") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnAccountID" runat="server" Value='<%# Bind("intAccountNo") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vouchar No." SortExpression="strVoucharCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVoucharCode" runat="server" Text='<%# Bind("strVoucharCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque No." SortExpression="strCheckNo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChequeNo" runat="server" Text='<%# Bind("strCheckNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Perticulars" SortExpression="strPerticulars">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPerticulars" runat="server" Text='<%# Bind("strPerticulars") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="monAmount" DataFormatString="{0:0.00}" HeaderText="Amount"
                                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="monAmount"
                                        Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col" style="width: 100px">
                                            Unit
                                        </th>
                                        <th scope="col" style="width: 60px">
                                            Entry Date
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Account No.
                                        </th>
                                        <th scope="col" style="width: 150px">
                                            Vouchar No.
                                        </th>
                                        <th scope="col" style="width: 150px">
                                            Cheque No.
                                        </th>
                                        <th scope="col" style="width: 180px">
                                            Perticulars
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Amount
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField runat="server" ID="hdnBankRecieveID" />
                            <asp:HiddenField runat="server" ID="hdnLoginUserId" />
                            <asp:ObjectDataSource ID="odsPF_BankRecieve" runat="server" SelectMethod="GetPfRecieveDetails"
                                TypeName="HR_BLL.Benifit.PF_Recieve_BLL" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="intPfUnitId" PropertyName="SelectedValue"
                                        Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlAccountNo" Name="intAccountNo" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
