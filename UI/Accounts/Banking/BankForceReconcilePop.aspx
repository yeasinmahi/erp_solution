<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1"
    Inherits="UI.Accounts.Banking.BankForceReconcilePop" Codebehind="BankForceReconcilePop.aspx.cs" %>

<!DOCTYPE html >
<html >
<head runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Account Statement Reconcile"
            runat="server"
            AutoGenerateColumns="False" ShowFooter="True" ondatabound="GridView1_DataBound">
            <Columns>
                <asp:BoundField DataField="strVoucherCode" HeaderText="Voucher Code" SortExpression="strVoucherCode" />
                <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strType" />
                <asp:BoundField DataField="strIssuDate" HeaderText="Issue Date" SortExpression="strIssuDate">
                </asp:BoundField>
                <asp:BoundField DataField="strChequeNo" HeaderText="Cheque No" SortExpression="strChequeNo" />
                <asp:BoundField DataField="strParty" HeaderText="Party" SortExpression="strParty" />
                <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                    </ItemTemplate>   
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>                     
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAccountStatementDataByType"
            TypeName="BLL.Accounts.Banking.Reconcile" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="bankAccountID" QueryStringField="acc" Type="String" />
                <asp:QueryStringParameter Name="toDate" QueryStringField="to" Type="String" />
                <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                <asp:QueryStringParameter Name="unitID" QueryStringField="unt" Type="String" />
                <asp:QueryStringParameter Name="type" QueryStringField="type" Type="String" />
                <asp:QueryStringParameter Name="isCompleted" QueryStringField="com" 
                    Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAccountStatementDataByTypeMatched"
            TypeName="BLL.Accounts.Banking.Reconcile" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:QueryStringParameter Name="bankAccountID" QueryStringField="acc" Type="String" />
                <asp:QueryStringParameter Name="toDate" QueryStringField="to" Type="String" />
                <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                <asp:QueryStringParameter Name="unitID" QueryStringField="unt" Type="String" />
                <asp:QueryStringParameter Name="type" QueryStringField="type" Type="String" />
                <asp:QueryStringParameter Name="isCompleted" QueryStringField="com" 
                    Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
    <script type="text/javascript">        
    window.print();
    self.close();    
    </script>
</body>
</html>
