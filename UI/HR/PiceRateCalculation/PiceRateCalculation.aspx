<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"
    Inherits="UI.HR.PiceRateCalculation.PiceRateCalculation" Codebehind="PiceRateCalculation.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Pice Rate Calculation</title>
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
        function KeySelected(source, eventArgs) {
            if (event.keyCode == '13') {
                var searchString = document.getElementById('txtSearchByName').value;
                var word = searchString.split(",");
                document.getElementById('hdfEmpCode').value = word[1];
                //PageMethods.ClientMethodCalledByJavaScript(word[1]);
                //                alert(word[1]);
            }
        }
        function CalculateTotalPayableAmount() {
            var valProductionPerDay = document.getElementById('txtProductionPerDay').value;
            var valRatePerUnit = document.getElementById('txtRatePerUnit').value;
            var txtTotalPayablePerDay = document.getElementById('txtTotalPayablePerDay');
            if (valProductionPerDay != null && valRatePerUnit != null) {
                txtTotalPayablePerDay.value = (valProductionPerDay * valRatePerUnit).toFixed(2);
            }
            else {
                txtTotalPayablePerDay.value = '0';
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
                            </td>
                            <td>
                                <b>Pice Rate Calculation</b>
                            </td>
                            <td>
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
                    <tr style="text-align: left">
                        <td style="width: 8px">
                        </td>
                        <td style="width: 120px">
                            <asp:Label ID="Label6" runat="server" CssClass="label" Font-Size="Smaller" Text="Search By Name/Code"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchByName" AutoCompleteType="Search" runat="server" AutoPostBack="true"
                                Width="200px" Height="20px"></asp:TextBox>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchByName"
                                WatermarkText="Type Employee Name Here" WatermarkCssClass="watermarked" />
                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchByName"
                                OnClientItemSelected="KeySelected" ServiceMethod="GetAutoFillEmployeeListBySearchKey"
                                MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="1" FirstRowSelected="true"
                                EnableCaching="false" CompletionListCssClass="autocomplete_completionListElement"
                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                            </ajaxToolkit:AutoCompleteExtender>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 405px;">
                                        <fieldset>
                                            <legend>Calaculate Daily Payable</legend>
                                            <asp:Panel ID="Panel1" runat="server" ScrollBars="None">
                                                <div style="height: 85px">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 120px">
                                                                <asp:Label ID="Label16" runat="server" CssClass="label" Text="Production / Day"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtProductionPerDay" Width="100px" runat="server" CssClass="txt"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 5px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtProductionPerDay"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Rate / Unit"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtRatePerUnit" runat="server" CssClass="txt" Enabled="false" Width="50px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRatePerUnit"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 120px">
                                                                <asp:Label ID="Label17" runat="server" CssClass="label" Text="Total Payable / Day"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtTotalPayablePerDay" runat="server" Enabled="false" CssClass="txt"
                                                                    Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTotalPayablePerDay"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
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
                                                            <td colspan="7">
                                                                <table>
                                                                    <tr>
                                                                        <td style="width: 115px">
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
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 300px;">
                                        <fieldset>
                                            <legend>Personal Information:</legend>
                                            <asp:Panel ID="panPersonalDetails" runat="server" ScrollBars="None">
                                                <div style="height: 85px">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 115px">
                                                                <asp:Label ID="Label5" runat="server" Text="Name" CssClass="label"></asp:Label>
                                                            </td>
                                                            <td class="style7">
                                                                <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 115px">
                                                                <asp:Label ID="Label12" runat="server" Text="Unit" CssClass="label"></asp:Label>
                                                            </td>
                                                            <td class="style7">
                                                                <asp:TextBox ID="txtUnit" runat="server" CssClass="txt" Width="166px" ReadOnly="True"
                                                                    BorderStyle="None" Enabled="False" Height="18px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 115px">
                                                                <asp:Label ID="Label13" runat="server" Text="Department" CssClass="label"></asp:Label>
                                                            </td>
                                                            <td class="style7">
                                                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 115px">
                                                                <asp:Label ID="Label14" runat="server" Text="Designation" CssClass="label"></asp:Label>
                                                            </td>
                                                            <td class="style7">
                                                                <asp:TextBox ID="txtDesignation" CssClass="txt" Width="200px" runat="server" ReadOnly="True"
                                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <asp:GridView ID="dgvPiceRate" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            SkinID="sknGrid2" Width="736px" OnRowDataBound="dgvPiceRate_RowDataBound" 
                                            OnSelectedIndexChanged="dgvPiceRate_SelectedIndexChanged" 
                                            DataSourceID="odsPiceRate">
                                            <Columns>
                                                <asp:BoundField DataField="dteSalaryGenerateDate" HeaderText="Production Date" DataFormatString="{0:MM/dd/yyyy}"
                                                    ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px" SortExpression="dteSalaryGenerateDate"
                                                    Visible="true">
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Production/Unit" SortExpression="numProductionPerDay">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblnumProductionPerDay" runat="server" Text='<%# Bind("numProductionPerDay") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnEmployeeId" runat="server" Value='<%# Bind("intEmployeeId") %>' />
                                                        <asp:HiddenField ID="hdnProductPerDay" runat="server" Value='<%# Bind("numProductionPerDay") %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="numRatePerUnit" HeaderText="Rate/Unit" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="100px" SortExpression="numRatePerUnit" DataFormatString="{0:f2}">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="monPayableSalaryPerDay" HeaderText="Payable/Day" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="100px" SortExpression="monPayableSalaryPerDay" DataFormatString="{0:f2}">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="monWithdrawal" HeaderText="Withdrawal" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="100px" SortExpression="monWithdrawal" DataFormatString="{0:f2}">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="monRunningBalance" HeaderText="Running Balance" ItemStyle-HorizontalAlign="Center"
                                                    ItemStyle-Width="100px" SortExpression="monRunningBalance" DataFormatString="{0:f2}">
                                                    <ItemStyle Width="100px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <tr style="background-color: Green;">
                                                    <th scope="col" style="width: 100px">
                                                        Production Date
                                                    </th>
                                                    <th scope="col" style="width: 100px">
                                                        Production/Unit
                                                    </th>
                                                    <th scope="col" style="width: 100px">
                                                        Rate/Unit
                                                    </th>
                                                    <th scope="col" style="width: 100px">
                                                        Payable/Day
                                                    </th>
                                                    <th scope="col" style="width: 100px">
                                                        Withdrawal
                                                    </th>
                                                    <th scope="col" style="width: 100px">
                                                        Running Balance
                                                    </th>
                                                </tr>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="odsPiceRate" runat="server" 
                                            SelectMethod="GetPiceRateDetailsByEmployeeCode" 
                                            TypeName="HR_BLL.PiceRateCalculation.PiceRateCalculation_BLL">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="hdfEmpCode" Name="strEmployeeCode" 
                                                    PropertyName="Value" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                <td>
                                <asp:HiddenField ID="hdfEmpCode" runat="server" />
                                <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                                <asp:HiddenField ID="hdnPiceRateGenerateDate" runat="server" />
                                </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
