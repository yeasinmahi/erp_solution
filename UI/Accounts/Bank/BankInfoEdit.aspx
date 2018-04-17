<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1"
    Inherits="UI.Accounts.Bank.BankInfoEdit" Codebehind="BankInfoEdit.aspx.cs" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html >
<head runat="server">
    <title>Bank Info Edit</title>
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
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 140px; float: right;">
            <table width="100%">
                <tr>
                    <td>
                        Bank :
                        <asp:DropDownList ID="ddlBankName" runat="server" DataSourceID="ObjectDataSource2"
                            DataTextField="strBankName" DataValueField="intBankID" AutoPostBack="True" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDL"
                            TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DetailsView ID="DetailsView1" runat="server" Width="100%" AutoGenerateRows="False"
                            DataKeyNames="intBankID" SkinID="sknDetailView" DataSourceID="ODataSourceBankInfo">
                            <Fields>
                                <asp:TemplateField HeaderText="Bank ID" InsertVisible="False" SortExpression="intBankID">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("intBankID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("intBankID") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Code" SortExpression="strBankCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("strBankCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("strBankCode") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="TextBox1" ErrorMessage="* cannot be Empty"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("strBankCode") %>'></asp:TextBox>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bank Name" SortExpression="strBankName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("strBankName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strBankName") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="TextBox2" ErrorMessage="* Cannot Be Empty"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strBankName") %>'></asp:TextBox>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("strDescription") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("strDescription") %>'></asp:TextBox>
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enable" SortExpression="ysnEnable">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' Enabled="false" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' />
                                    </EditItemTemplate>
                                    <InsertItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' />
                                    </InsertItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" />
                            </Fields>
                        </asp:DetailsView>
                        <asp:ObjectDataSource ID="ODataSourceBankInfo" runat="server" SelectMethod="GetBankInfoByID"
                            TypeName="BLL.Accounts.Bank.BankInfo" UpdateMethod="BankInfoEdit">
                            <UpdateParameters>
                                <asp:Parameter Name="bankID" Type="Int32" />
                                <asp:Parameter Name="strBankCode" Type="String" />
                                <asp:Parameter Name="strBankName" Type="String" />
                                <asp:Parameter Name="strDescription" Type="String" />
                                <asp:Parameter Name="ysnEnable" Type="Boolean" />
                                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                <asp:Parameter Name="intBankID" Type="Int32" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div style="height: 180px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <table width="100%">
        <tr>
            <td valign="top">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="intBranchID"
                    SkinID="sknGrid1" DataSourceID="ODataSourceBranch">
                    <Columns>
                        <asp:TemplateField HeaderText="Branch Code" SortExpression="strBranchCode">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("strBranchCode") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("strBranchCode") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TextBox1" ErrorMessage="* Cannot Be Empty"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch Name" SortExpression="strBranchName">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("strBranchName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strBranchName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="TextBox2" ErrorMessage="* Cannot be Empty"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("strDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enable" SortExpression="ysnEnable">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' Enabled="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ODataSourceBranch" runat="server" SelectMethod="GetBranchDataByBankID"
                    TypeName="BLL.Accounts.Bank.BankBranch" UpdateMethod="EditBranchInfo" OldValuesParameterFormatString="original_{0}">
                    <UpdateParameters>
                        <asp:Parameter Name="bankID" Type="Int32" />
                        <asp:Parameter Name="strBranchCode" Type="String" />
                        <asp:Parameter Name="strBranchName" Type="String" />
                        <asp:Parameter Name="strDescription" Type="String" />
                        <asp:Parameter Name="ysnEnable" Type="Boolean" />
                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                        <asp:Parameter Name="original_intBranchID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr><td style="height:20px;"></td></tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" SkinID="sknGrid1" AutoGenerateColumns="False"
                    DataKeyNames="intAccountTypeID" DataSourceID="OtDataSourceAccType">
                    <Columns>
                        <asp:TemplateField HeaderText="Account Type" SortExpression="strAccType">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("strAccType") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("strAccType") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="TextBox1" ErrorMessage="* Cannot Be Empty"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("strDescription") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enable" SortExpression="ysnEnable">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' Enabled="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="OtDataSourceAccType" runat="server" SelectMethod="GetAccountTypeData"
                    TypeName="BLL.Accounts.Bank.BankAccountType" UpdateMethod="EditAccountType" OldValuesParameterFormatString="original_{0}">
                    <UpdateParameters>
                        <asp:Parameter Name="bankid" Type="Int32" />
                        <asp:Parameter Name="strAccType" Type="String" />
                        <asp:Parameter Name="strDescription" Type="String" />
                        <asp:Parameter Name="ysnEnable" Type="Boolean" />
                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                        <asp:Parameter Name="original_intAccountTypeID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
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
