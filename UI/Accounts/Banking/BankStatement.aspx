<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.BankStatement" Codebehind="BankStatement.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <script type="text/javascript">
        function RemoveRecon(sender, args) {
            if (!confirm('Do you want to cancel this auto reconcile?')) {
                args.IsValid = false;
                isProceed = false;
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
            z-index: 1; position: absolute;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
        </div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
            <table width="90%">
                <tr>
                    <td align="left" class="PageHeader">
                        Bank Statement
                    </td>
                    <td colspan="2">
                        Date
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server"
                            EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td align="right">
                        Unit
                        <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                            DataValueField="intUnitID" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr style="height: 70px;">
                    <td>
                        Bank
                        <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                            DataTextField="strBankName" DataValueField="intBankID" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDLWithAll"
                            TypeName="BLL.Accounts.Bank.BankInfo" OldValuesParameterFormatString="original_{0}">
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        Branch
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource3"
                            DataTextField="strBranchName" DataValueField="intBranchID" OnDataBound="ddlBranch_DataBound"
                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveForDDL"
                            TypeName="BLL.Accounts.Bank.BankBranch" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        A/C No.
                        <asp:DropDownList ID="ddlAccount" runat="server" DataSourceID="ObjectDataSource4"
                            DataTextField="strAccountNo" DataValueField="intAccountID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetActiveForDDLByBranch"
                            TypeName="BLL.Accounts.Bank.BankAccount" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="branchID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSubmit" runat="server" Text="Show" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div style="height: 120px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Bank Statement By Aggregator"
        runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" DataKeyNames="intID"
        ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="intID" HeaderText="intID" SortExpression="intID" ItemStyle-Width="100"
                InsertVisible="False" ReadOnly="True" Visible="false">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Tr Date" SortExpression="dteDate">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteDate")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="strParticulars" HeaderText="Particulars" SortExpression="strParticulars"
                ReadOnly="True" />
            <asp:BoundField DataField="strChequeNo" HeaderText="Instrument No" SortExpression="strChequeNo"
                ReadOnly="True" />
            <asp:TemplateField HeaderText="Dr Amount" SortExpression="monDrAmount">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("monDrAmount") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("monDrAmount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cr Amount" SortExpression="monCrAmount">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("monCrAmount") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("monCrAmount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Balance" SortExpression="monRunningBalance">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("monRunningBalance") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("monRunningBalance") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manual Reconciled" SortExpression="dteCompleteDate">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteCompleteDate")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Auto Reconciled" SortExpression="dteAutoReconciled">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteAutoReconciled")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRemove" ValidationGroup="val" CommandArgument='<%# Eval("intID") %>' runat="server" Text="Cancel Auto reconcile" OnClick="btnRemove_Click" Visible='<%# (""+Eval("dteAutoReconciled"))==""?false:true  %>'  />
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="dteInsertionTime" HeaderText="Insertion Time" SortExpression="dteInsertionTime"
                ReadOnly="True" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetStatementData"
        TypeName="BLL.Accounts.Banking.BankStatement" OldValuesParameterFormatString="original_{0}"
        UpdateMethod="UpdateStatement">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlAccount" Name="accountId" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="txtFrom" Name="date" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="dteDate" Type="DateTime" />
            <asp:Parameter Name="strParticulars" Type="String" />
            <asp:Parameter Name="strChequeNo" Type="String" />
            <asp:Parameter Name="monAmount" Type="Decimal" />
            <asp:Parameter Name="monRunningBalance" Type="Decimal" />
            <asp:Parameter Name="dteInsertionTime" Type="DateTime" />
            <asp:Parameter Name="dteCompleteDate" Type="DateTime" />
            <asp:Parameter Name="dteAutoReconciled" Type="DateTime" />
            <asp:Parameter Name="original_intID" Type="Int32" />
            <asp:Parameter Name="monDrAmount" Type="Decimal" />
            <asp:Parameter Name="monCrAmount" Type="Decimal" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="RemoveRecon"
        ValidationGroup="val"></asp:CustomValidator>
    </form>
</body>
</html>
