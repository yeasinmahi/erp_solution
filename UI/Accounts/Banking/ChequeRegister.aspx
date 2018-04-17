<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.ChequeRegister" Codebehind="ChequeRegister.aspx.cs" %>



<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html >
<head runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />   

    <script type="text/javascript">
    function ShowPopUpVr(url){  
        var rand_no = Math.floor(11*Math.random());
        var ids = document.getElementById("hdnIds").value; 
        var idsC = document.getElementById("hdnConIds").value; 
        var dte = document.getElementById("txtFrom").value;                  
        
        url = url+'?ids='+ids
        +'&unt='+document.getElementById("ddlUnit").value
        +'&dte='+dte
        +'&idsC='+idsC
        +'&rnd='+rand_no
        +'&acc='+document.getElementById("ddlAccNo").value
        +'&accN='+document.getElementById("ddlAccNo").options[document.getElementById("ddlAccNo").selectedIndex].text
        +'&bnkN='+document.getElementById("ddlBankName").options[document.getElementById("ddlBankName").selectedIndex].text;
        
        newwindow = window.open(url,'sub','toolbar=0,height=10,width=1050,top=50,left=200');
        if (window.focus) {newwindow.focus()}
        }
    function ValidateComplete(sender, args){        
        if(!confirm('Do you want to complete these cheque ?')){
            args.IsValid = false;
            isProceed = false;
        }
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
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

            </Scripts>
        </CompositeScript>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table style="width: 700px;">
                        <tr>
                            <td  colspan="3"></td>
                            <td> <asp:RadioButtonList ID="rdoPrint" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="true">Print</asp:ListItem>
                                    <asp:ListItem Value="false">View</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td align="right" colspan="2">
                                Unit:
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
                        <tr>                            
                            <td colspan="3">
                                <asp:Button ID="btnCompleted" ValidationGroup="valCom"  runat="server" Text="Print Completed" BackColor="Maroon" ForeColor="White" Width="222" OnClick="btnCompleted_Click" />
                            </td>
                            <td colspan="3" align="left">
                               
                            </td>                           
                        </tr>
                        <tr>
                            <td>
                                Bank</td>
                            <td>
                                 <asp:DropDownList ID="ddlBankName" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="strBankName" DataValueField="intBankID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDL"
                                    TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource></td>
                            <td align="right">
                                Branch</td>
                            <td align="left">
                                 <asp:DropDownList ID="ddlBranchName" runat="server" DataSourceID="ObjectDataSource3"
                                    DataTextField="strBranchName" DataValueField="intBranchID" 
                                     AutoPostBack="True" ondatabound="ddlBranchName_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveForDDL"
                                    TypeName="BLL.Accounts.Bank.BankBranch">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource></td>
                            <td align="right">
                                Account</td>
                            <td align="right">
                                 <asp:DropDownList ID="ddlAccNo" runat="server" DataSourceID="AcctypeDataSource"
                                    DataTextField="strAccountNo" DataValueField="intAccountID" 
                                     AutoPostBack="True" onselectedindexchanged="ddlAccNo_SelectedIndexChanged" 
                                     ondatabound="ddlAccNo_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="AcctypeDataSource" runat="server" SelectMethod="GetActiveForDDLByBranch"
                                    TypeName="BLL.Accounts.Bank.BankAccount">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBranchName" Name="branchID" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource></td>
                        </tr>
                        <tr>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" 
                                    EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" 
                                    TargetControlID="txtFrom">
                                </cc1:CalendarExtender>
                                <img ID="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Show" />
                            </td>
                            <td></td>
                            <td></td>
                            <td align="right">
                                <input ID="Button1" onclick="ShowPopUpVr('../Print/ChequeRegister.aspx')" 
                                    type="button" value="Print" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 140px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                SkinID="sknGrid1" CaptionAlign="Top" Caption="Cheque Register"
                DataKeyNames="intVoucherID" DataSourceID="ObjectDataSource1" 
                ondatabound="GridView1_DataBound">
                <Columns>
                    <asp:BoundField DataField="intVoucherID" HeaderText="ID" 
                        SortExpression="intVoucherID"/>
                    <asp:BoundField DataField="strCode" HeaderText="Code" 
                        SortExpression="strCode" />
                    <asp:BoundField DataField="dteVoucherDate" HeaderText="Voucher Date" 
                        ReadOnly="True" SortExpression="dteVoucherDate" />
                    <asp:BoundField DataField="dteChequeDate" HeaderText="Cheque Date" 
                        ReadOnly="True" SortExpression="dteChequeDate" />
                    <asp:BoundField DataField="strChequeNo" HeaderText="Cheque No" 
                        SortExpression="strChequeNo" />
                    <asp:BoundField DataField="strPayToPrint" HeaderText="Party" 
                        ReadOnly="True" SortExpression="strPayToPrint" />
                    <asp:BoundField DataField="monAmount" HeaderText="Amount" ReadOnly="True" 
                        SortExpression="monAmount" />
                </Columns>
            </asp:GridView>
            
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                SelectMethod="GetBankChequeRegisterPrint" 
                TypeName="BLL.Accounts.Banking.VoucherForChqPrint" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtFrom" Name="date" PropertyName="Text" 
                        Type="String" />
                    <asp:SessionParameter Name="userID" SessionField="sesUserId" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="ddlAccNo" Name="bankAccountId" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:Parameter Name="idList" Type="String" />
                    <asp:Parameter Name="idListContra" Type="String" />
                    <asp:ControlParameter ControlID="rdoPrint" Name="isPrinted" 
                        PropertyName="SelectedValue" Type="Boolean" />
                    <asp:Parameter Direction="InputOutput" Name="unitName" Type="String" />
                    <asp:Parameter Direction="InputOutput" Name="totalPreviuosData" Type="Object" />
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
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>    
    <asp:HiddenField ID="hdnIds" runat="server" />
    <asp:HiddenField ID="hdnConIds" runat="server" />
        
    </form>
</body>
</html>
