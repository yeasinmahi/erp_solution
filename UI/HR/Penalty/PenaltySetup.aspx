<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Penalty.PenaltySetup" EnableEventValidation="false" Codebehind="PenaltySetup.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html >
<html >
<head runat="server">
    <title>Penalty Amount</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script src="../../Content/JS/JavaScriptSpellCheck/include.js" type="text/javascript"></script>
    <script type='text/javascript'>
        $Spelling.SpellCheckAsYouType('all')
        function validateFormSpelling() {
            if ($Spelling.BinSpellCheckFields('txtDescription')) {
            return true
        } 
        else {
                alert("Spell Check Errors - Spelling Will Be Checked Before Submitting The Form.")
                $Spelling.SubmitFormById = 'form1';
                return false;
            }
        }
</script>

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
            }
        }
       
    </script>
</head>
<body>
    <form id="form1" runat="server" action="" onsubmit="return validateFormSpelling();">
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
                                <b>Penalty Amount Setup</b>
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
                        <td style="width: 95px">
                            &nbsp;
                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSearchByName" AutoCompleteType="Search" runat="server" AutoPostBack="true"
                                Width="200px" Height="20px"></asp:TextBox>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchByName"
                                WatermarkText="Type Employee Name/Code Here" WatermarkCssClass="watermarked" />
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
                
                <table style="height: 150px">
                    <tr>
                        <td style="width: 400px; height: 150px">
                            <fieldset>
                                <legend>Penalty Details</legend>
                                <table style="height: 115px;">
                                    <tr>
                                        <td style="width: 95px">
                                            <asp:Label ID="Label16" runat="server" CssClass="label" Text="Penalty Amount"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPenaltyAmount" runat="server" CssClass="txt"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE6" runat="server" FilterType="Custom, Numbers"
                                                TargetControlID="txtPenaltyAmount" ValidChars="123456789.">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPenaltyAmount"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            <asp:Label ID="Label9" runat="server" CssClass="label" Text="Effected Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEffectedDate" runat="server" CssClass="txt"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtEffectedDate_CalendarExtender" runat="server"
                                                TargetControlID="txtEffectedDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEffectedDate"
                                                ErrorMessage="*" ForeColor="Red" ValidationGroup="VG" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:CompareValidator ID="dateValidator" runat="server" ForeColor="Red" Type="Date" Operator="DataTypeCheck"
                                                ControlToValidate="txtEffectedDate" ErrorMessage="*">
                                            </asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 95px">
                                            <asp:Label ID="Label11" runat="server" CssClass="label" Text="Description"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txt" TextMode="MultiLine"
                                                Width="257px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDescription"
                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="VG"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table>
                                                <tr>
                                                    <td style="width: 83px">
                                                    </td>
                                                    <td style="width: 60px">
                                                        <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" Width="60px"
                                                            OnClick="btnAdd_Click" ValidationGroup="VG" OnClientClick="return validateFormSpelling();"/>
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
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td style="width: 350px; height: 150px;">
                            <fieldset>
                                <legend>Personal Information:</legend>
                                <table style="height: 115px;">
                                    <tr>
                                        <td style="width: 115px">
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
                                        <td style="width: 115px">
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
                                        <td style="width: 115px">
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
                                        <td style="width: 115px">
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
                                        <td style="width: 115px">
                                            <asp:Label ID="Label15" runat="server" Text="Job Status" CssClass="label"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:TextBox ID="txtJobStatus" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                BorderStyle="None" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="dgvPenaltyAmount" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" DataKeyNames="intEmployeeId" SkinID="sknGrid2" Width="750px"
                                OnRowDataBound="dgvPenaltyAmount_RowDataBound"
                                OnSelectedIndexChanged="dgvPenaltyAmount_SelectedIndexChanged" 
                                DataSourceID="odsPenalty">
                                <Columns>
                                    <asp:BoundField DataField="monPenaltyAmount" HeaderText="Penalty Amount" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:0.00}"
                                        ItemStyle-Width="100px" SortExpression="intId" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Month" SortExpression="strMonthName">
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
                                    <asp:BoundField DataField="strDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center"
                                        ItemStyle-Width="335px" SortExpression="strDescription">
                                        <ItemStyle Width="335px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Status" SortExpression="ysnPunishmentStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("ysnPunishmentStatus") %>'></asp:Label>
                                            <asp:HiddenField ID="hdnEditable" runat="server" Value='<%# Bind("ysnEditable") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <tr style="background-color: Green;">
                                        <th scope="col" style="width: 100px">
                                            Penalty Amount
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Month
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Year
                                        </th>
                                        <th scope="col" style="width: 335px">
                                            Description
                                        </th>
                                        <th scope="col" style="width: 100px">
                                            Status
                                        </th>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="odsPenalty" runat="server" 
                                SelectMethod="GetAllPunishmentData" TypeName="HR_BLL.Penalty.Penalty">
                                <SelectParameters>
                                    <asp:Parameter Name="intUserID" Type="Int32" DefaultValue=""/>
                                    <asp:ControlParameter ControlID="hdfEmpCode" Name="empCode" 
                                        PropertyName="Value" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnUserID" runat="server" />
                        </td>
                        <td>
                            <asp:HiddenField ID="hdfEmpCode" runat="server" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
