<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.BankReconsile" Codebehind="BankReconsile.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
                    <table width="90%">
                        <tr>
                            <td align="left" class="PageHeader">
                                Auto Reconciled
                            </td>                            
                            <td>
                                From 
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td>
                                To 
                                <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_2" TargetControlID="txtTo">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
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
            <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Account Statement Reconciled"
                runat="server" DataSourceID="ObjectDataSource1" 
                AutoGenerateColumns="False" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="strCode" HeaderText="Voucher Code" SortExpression="strCode"
                        ItemStyle-Width="100"></asp:BoundField>
                    <asp:BoundField DataField="srtType" HeaderText="Type" SortExpression="srtType"
                        ReadOnly="True" />
                    <asp:BoundField DataField="dteChequeDate" HeaderText="Issue Date" SortExpression="dteChequeDate"
                        ReadOnly="True" />
                    <asp:BoundField DataField="strChequeNo" HeaderText="Ref. No" SortExpression="strChequeNo">
                    </asp:BoundField>
                    <asp:BoundField DataField="strParty" HeaderText="Particulars" SortExpression="strParty"
                        ReadOnly="True" />
                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                        </ItemTemplate>   
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>                     
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAccountStatementMatchedData"
                TypeName="BLL.Accounts.Banking.Reconcile" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlAccount" Name="bankAccountID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="txtFrom" Name="fromDate" PropertyName="Text" 
                        Type="String" />
                    <asp:ControlParameter ControlID="txtTo" Name="toDate" PropertyName="Text" 
                        Type="String" />
                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="text-align: center">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
            DisplayAfter="100">
            <ProgressTemplate>
                <img alt="" src="../../Content/images/img/loading.gif" style="border: 0px;"
                    title="Loading" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
</body>
</html>
