<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true"
    Inherits="UI.Accounts.Bank.ChequeBook" Codebehind="ChequeBook.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html >
<html>
<head runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 

    <script type="text/javascript">
        function Write(){        
        document.getElementById("txtEnd").value = document.getElementById("txtStart").value;
        } 
        function ShowDiv(id,txt){
            document.getElementById("newAccTypeDiv").style.display = "block";
            document.getElementById("hdnChq").value = id;            
            document.getElementById("txtCancel").value = txt;            
        }
        function Hide(){
            document.getElementById("newAccTypeDiv").style.display = "none";
            document.getElementById("hdnChq").value = '';
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
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
            <div id="newAccTypeDiv" class="divPopAcccountType" style="top: 190px; width: 300px;
                height: 160px; padding-top: 5px;">
                <table align="center">
                    <tr>
                        <td colspan="2" align="left">
                            <input id="Button1" type="button" onclick="Hide()" value="x" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Cancel Cheque No.</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCancel" runat="server"></asp:TextBox>
                        </td>
                    </tr>                    
                    <tr>
                        <%--<td colspan="2">
                            <asp:RadioButtonList ID="rdoManual" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Cancel" Value="false" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Manualy Entered" Value="true"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>--%>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtNote" TextMode="MultiLine" Width="250" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel Check No" />
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnChq" runat="server" />
            </div>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 130px; float: right;">
                    <table>
                        <tr>
                            <td>
                                Unit
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetUnits"
                                    TypeName="HR_BLL.Global.Unit"></asp:ObjectDataSource>
                            </td>
                            <td style="width: 20px;">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                <b>Add Cheque No.</b>
                            </td>
                            <td style="width: 20px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bank
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                                    DataTextField="strBankName" DataValueField="intBankID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDL"
                                    TypeName="BLL.Accounts.Bank.BankInfo" OldValuesParameterFormatString="original_{0}">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Start
                            </td>
                            <td>
                                <asp:TextBox ID="txtStart" runat="server" Width="210px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Branch
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource3"
                                    DataTextField="strBranchName" DataValueField="intBranchID" OnDataBound="ddlBranch_DataBound">
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
                                &nbsp;
                            </td>
                            <td>
                                End
                            </td>
                            <td>
                                <asp:TextBox ID="txtEnd" runat="server" Width="209px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                A/C No.
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="true" DataSourceID="ObjectDataSource4"
                                    DataTextField="strAccountNo" DataValueField="intAccountID" OnDataBound="ddlAccount_DataBound">
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
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add Check Book" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 150px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <div>
                <asp:RadioButtonList ID="rdoActive" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="rdoActive_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="a">Active</asp:ListItem>
                    <asp:ListItem Value="i">Inactive</asp:ListItem>
                    <asp:ListItem Value="c">Completed</asp:ListItem>
                </asp:RadioButtonList>
                <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False"
                    CaptionAlign="Top" Caption="Check Book List" DataKeyNames="intCheckBookID" DataSourceID="ObjectDataSource5">
                    <Columns>
                        <asp:BoundField DataField="strStart" HeaderText="Start Check No." SortExpression="strStart" />
                        <asp:BoundField DataField="strEnd" HeaderText="End Check No." SortExpression="strEnd" />
                        <asp:TemplateField HeaderText="Last Cheque No." SortExpression="strLeftPart">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# GetLastUsedChequeNo(Eval("strLeftPart"), Eval("intLastUsedNumber"), Eval("intEndUsedNumber")) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cancelled Check No. List" SortExpression="strCancelledCheckNo">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("strCancelledCheckNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="ysnEnable" HeaderText="Enabled" SortExpression="ysnEnable" />
                        <asp:TemplateField HeaderText="Cancel This Cheque">
                            <ItemTemplate>
                                <a href="#" onclick="ShowDiv('<%# Eval("intCheckBookID") %>','<%# Eval("strStart") %>')">Cheque Cancel</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetCheckBookList"
                    TypeName="BLL.Accounts.Bank.BankCheck" UpdateMethod="CheckBookUpdate">
                    <UpdateParameters>
                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                        <asp:Parameter Name="strStart" Type="String" />
                        <asp:Parameter Name="strEnd" Type="String" />
                        <asp:Parameter Name="strCancelledCheckNo" Type="String" />
                        <asp:Parameter Name="ysnEnable" Type="Boolean" />
                        <asp:Parameter Name="intCheckBookID" Type="Int32" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlAccount" Name="accountID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="rdoActive" Name="type" PropertyName="SelectedValue"
                            Type="Char" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
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
