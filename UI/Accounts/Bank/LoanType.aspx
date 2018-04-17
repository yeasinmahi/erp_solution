<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Bank.LoanType" Codebehind="LoanType.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <script type="text/javascript">
    function HideDiv(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "none";
        
        //document.getElementById("hdnParent").value = '';
     }
     function HideDiv2(id)
        {
        var dv = document.getElementById(id);
        dv.style.visibility = "hidden";
        
        //document.getElementById("hdnParent").value = '';
     }
     function ShowDiv2(id)
        {
        var dv = document.getElementById(id);
        dv.style.visibility = "visible";
        
        //document.getElementById("hdnParent").value = '';
     }
     function ShowDiv(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "block";
        
        //document.getElementById("hdnParent").value = '';
     }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
        </div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
             <table>
        <tr>
            <td>Unit</td>
            <td>
                <asp:DropDownList ID="ddlUnit" runat="server" 
                    DataSourceID="ObjectDataSource1" DataTextField="strUnit" 
                    DataValueField="intUnitID" AutoPostBack="True" 
                    onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                    <SelectParameters>
                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>Loan Type</td>
            <td>
                
                <asp:DropDownList ID="ddlloanType" runat="server" AutoPostBack="True" 
                    DataSourceID="ObjectDataSource2" DataTextField="strLoanTypeName" 
                    DataValueField="intLoanTypeID" ondatabound="ddlloanType_DataBound">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    SelectMethod="GetLoanTypeByUnit" TypeName="BLL.Accounts.Bank.LoanType">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <a href="#" onclick="ShowDiv('newLoanType')">new</a>
            </td>
        </tr>
    </table>
        </div>
    </asp:Panel>
    <div style="height: 100px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>

    
    
    
    <div>
    
    
    <table width="100%">
    <tr>
        <td>
            <asp:GridView ID="GridLoanType" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="intLoanTypeID" DataSourceID="ObjectDataSource3">
                <Columns>
                    <asp:TemplateField HeaderText="Loan Type" SortExpression="strLoanTypeName">
                        <EditItemTemplate>
                            <asp:Label ID="Label1r" runat="server" Text='<%# Bind("strLoanTypeName") %>'></asp:Label>
                            
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("strLoanTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Limit" SortExpression="monLoanLimit">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("monLoanLimit") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("monLoanLimit") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                CommandName="Edit" Text="Edit"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                SelectMethod="GetLoanTypeByID" TypeName="BLL.Accounts.Bank.LoanType" 
                UpdateMethod="EditLoanType">
                <UpdateParameters>
                    <asp:Parameter Name="strLoanTypeName" Type="String" />
                    <asp:Parameter Name="monLoanLimit" Type="Decimal" />
                    <asp:Parameter Name="intLoanTypeID" Type="Int32" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlloanType" Name="loanTypeID" 
                        PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp
        </td>
    </tr>
     <tr>
        <td>
            <a href="#" onclick="ShowDiv('typeDetailsAdd')">
    <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Account" />
    </a>
        </td>
    </tr>
    <tr>
        <td>
             <asp:GridView ID="GridLoanTypeDetails" SkinID="sknGrid1" runat="server" 
                 AutoGenerateColumns="False" DataSourceID="ObjectDataSource4">
                 <Columns>
                     <asp:BoundField DataField="strBankName" HeaderText="strBankName" 
                         SortExpression="strBankName" />
                     <asp:BoundField DataField="strDescription" HeaderText="strDescription" 
                         SortExpression="strDescription" />
                     <asp:BoundField DataField="strAccType" HeaderText="strAccType" 
                         SortExpression="strAccType" />
                 </Columns>
        </asp:GridView>
    
             <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                 SelectMethod="GetLoanTypeDetailsByID" TypeName="BLL.Accounts.Bank.LoanType">
                 <SelectParameters>
                     <asp:ControlParameter ControlID="ddlloanType" Name="loanTypeID" 
                         PropertyName="SelectedValue" Type="String" />
                 </SelectParameters>
             </asp:ObjectDataSource>
    
        </td>
    </tr>
    </table>
    </div>
    
    <div id="newLoanType" class="divPopUpItemLoanType">
    
    <table width="100%">
    <tr>
        <td colspan="2" style="height: 50px; vertical-align: top;" align="right">
             <input id="Button1" type="button" value="X" onclick="HideDiv('newLoanType')" />
        </td>
    </tr>
              <tr>
                <td colspan="2">&nbsp</td>
   </tr>
    <tr>
        <td>Name</td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
    </tr>
       <tr>
        <td>Loan Limit</td>
        <td>
            <asp:TextBox ID="txtLoanLimit" runat="server"></asp:TextBox></td>
    </tr>
   
              <tr>
                <td colspan="2">&nbsp</td>
   </tr>
  
    <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnLoanTypeAdd" runat="server" Text="ADD" 
                        onclick="btnLoanTypeAdd_Click" />
                </td>
   </tr>
    </table>
    </div>
    
    <div id="typeDetailsAdd" class="divPopUpItemLoanTypeDetails" >
    
    <table width="100%">
    <tr>
        <td colspan="2" style="height: 50px; vertical-align: top;" align="right">
             <input id="Button2" type="button" value="X" onclick="HideDiv('typeDetailsAdd')" />
        </td>
    </tr>
              <tr>
                <td colspan="2">&nbsp</td>
   </tr>
    <tr>
        <td>Bank</td>
        <td>
            <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" 
                DataSourceID="ObjectDataSource5" DataTextField="strBankName" 
                DataValueField="intBankID" 
                onselectedindexchanged="ddlBank_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                SelectMethod="GetActiveForDDL" TypeName="BLL.Accounts.Bank.BankInfo">
            </asp:ObjectDataSource>
        </td>
            
    </tr>
       <tr>
        <td>Account Type</td>
        <td>
            <asp:DropDownList ID="ddlAccountType" runat="server" 
                DataSourceID="ObjectDataSource6" DataTextField="strAccType" 
                DataValueField="intAccountTypeID" ondatabound="ddlAccountType_DataBound">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                SelectMethod="GetAccountTypeData" TypeName="BLL.Accounts.Bank.BankAccountType">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlBank" Name="bankID" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
    </tr>
   
              <tr>
                <td colspan="2">&nbsp</td>
   </tr>
  
    <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAcctypeAdd" runat="server" Text="ADD" onclick="btnAcctypeAdd_Click" 
                       />
                </td>
   </tr>
    </table>
    
    
    </div>
    
    <asp:Panel ID="Panel1" runat="server" Visible="false">
    <script type="text/javascript">
        ShowDiv('typeDetailsAdd')
    </script>
    
    </asp:Panel>
    
    </form>
</body>
</html>
