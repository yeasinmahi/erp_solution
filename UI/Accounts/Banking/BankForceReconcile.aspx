<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.BankForceReconcile" Codebehind="BankForceReconcile.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
      <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
     
    <script type="text/javascript">
    function Validate(sender, args){        
        var txt='';
        if(getCheckedRadio()=='false')txt='Do you want to reconcile this voucher?';
        else txt='Do you want to back this voucher from manual reconcile?';
        if(!confirm(txt)){
            args.IsValid = false;
            isProceed = false;
        }
    }
     function getCheckedRadio() {
      var radioButtons = document.getElementsByName("RadioButtonList1");
      for (var x = 0; x < radioButtons.length; x ++) {
        if (radioButtons[x].checked) {
          return radioButtons[x].value;
        }
      }
    }
    
     function ShowPopUpVr(url,alt){
        url = url + "?acc="+document.getElementById('ddlAccount').options.value;        
        url = url + "&to="+document.getElementById('txtTo').value;
        url = url + "&unt="+document.getElementById('ddlUnit').options.value;
        url = url + "&type="+document.getElementById('DropDownList1').options.value;
        url = url + "&com="+getCheckedRadio();
        url = url + "&alt="+alt;
        
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=580,width=900,top=50,left=200');
        //if (window.focus) {newwindow.focus()}
        }  
    </script>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 130px; float: right;">
                    <table width="90%">
                        <tr>
                            <td align="left" class="PageHeader">
                                Account Reconcile
                            </td>                            
                            <td colspan="2">
                                &nbsp;Date Up To&nbsp;
                                <asp:TextBox ID="txtTo" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" runat="server" 
                                    EnableViewState="true" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" 
                                    TargetControlID="txtTo">
                                </cc1:CalendarExtender>
                                <img ID="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
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
                        <tr style="height:40px;">
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
                        <tr style="height:30px;">
                            <td colspan="2">
                            Type:
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                    DataSourceID="odsType" DataTextField="value" DataValueField="key">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsType" runat="server" 
                                    SelectMethod="GetReconcileTypeForDDL" TypeName="BLL.Accounts.Banking.Reconcile" 
                                    OldValuesParameterFormatString="original_{0}">
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                
                                                
                                                </td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                        <tr style="height:30px;">
                            <td colspan="2">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="false">Not Completed</asp:ListItem>
                                    <asp:ListItem Value="true">Completed</asp:ListItem>
                                </asp:RadioButtonList></td>
                            <td>
                                
                            </td>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 150px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table>
            <tr>
            <td align="center" ><a href="#" onclick="ShowPopUpVr('BankForceReconcilePop.aspx',false)"
                                                class="link">Print</a></td>
            <td align="center" ><a href="#" onclick="ShowPopUpVr('BankForceReconcilePop.aspx',true)"
                                                class="link">Print</a></td>
            </tr>
            <tr>
            <td style="vertical-align:top; width:50%">
            <div style="overflow-y: scroll; height: 430px;" align="left">
            <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Account Statement Reconcile"
                runat="server" DataSourceID="ObjectDataSource1" 
                AutoGenerateColumns="False" ShowFooter="True" 
                ondatabound="GridView1_DataBound">
                <Columns>                    
                    <asp:BoundField DataField="strVoucherCode" HeaderText="Voucher Code" 
                        SortExpression="strVoucherCode" />
                    <asp:BoundField DataField="strType" HeaderText="Type" 
                        SortExpression="strType" />
                    <asp:BoundField DataField="strIssuDate" HeaderText="Issue Date" 
                        SortExpression="strIssuDate">
                    </asp:BoundField>
                    <asp:BoundField DataField="strChequeNo" HeaderText="Cheque No" 
                        SortExpression="strChequeNo" />
                    <asp:BoundField DataField="strParty" HeaderText="Party" 
                        SortExpression="strParty" />
                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                        </ItemTemplate>  
                        <FooterTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# GetTotal1(5) %>'></asp:Label>
                        </FooterTemplate> 
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>                     
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnChange" runat="server" ValidationGroup="val" CommandArgument='<%# Eval("strCat") +"#"+ Eval("intId") %>'
                             Text="Action" OnClick="btnChange_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            </td>
            <td  style="vertical-align:top; width:50%">
            <div style="overflow-y: scroll; height: 430px;" align="left">
            <asp:GridView ID="GridView2" SkinID="sknGrid1" CaptionAlign="Top" Caption="Account Statement Reconcile"
                runat="server" DataSourceID="ObjectDataSource5" 
                AutoGenerateColumns="False" ShowFooter="True" 
                ondatabound="GridView2_DataBound">
                <Columns>                    
                    <asp:BoundField DataField="strVoucherCode" HeaderText="Voucher Code" 
                        SortExpression="strVoucherCode" />
                    <asp:BoundField DataField="strType" HeaderText="Type" 
                        SortExpression="strType" />
                    <asp:BoundField DataField="strIssuDate" HeaderText="Issue Date" 
                        SortExpression="strIssuDate">
                    </asp:BoundField>
                    <asp:BoundField DataField="strChequeNo" HeaderText="Cheque No" 
                        SortExpression="strChequeNo" />
                    <asp:BoundField DataField="strParty" HeaderText="Party" 
                        SortExpression="strParty" />
                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                        </ItemTemplate>   
                        <FooterTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# GetTotal2(5) %>'></asp:Label>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>                     
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnChange" runat="server" ValidationGroup="val" CommandArgument='<%# Eval("strCat") +"#"+ Eval("intId") %>'
                             Text="Action" OnClick="btnChange_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            </td>
            </tr></table>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAccountStatementDataByType"
                TypeName="BLL.Accounts.Banking.Reconcile" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlAccount" Name="bankAccountID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="txtTo" Name="toDate" PropertyName="Text" 
                        Type="String" />
                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="DropDownList1" Name="type" PropertyName="SelectedValue" 
                        Type="String" />
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="isCompleted" 
                        PropertyName="SelectedValue" Type="Boolean" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetAccountStatementDataByTypeMatched"
                TypeName="BLL.Accounts.Banking.Reconcile" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlAccount" Name="bankAccountID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="txtTo" Name="toDate" PropertyName="Text" 
                        Type="String" />
                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="DropDownList1" Name="type" PropertyName="SelectedValue" 
                        Type="String" />
                    <asp:ControlParameter ControlID="RadioButtonList1" Name="isCompleted" 
                        PropertyName="SelectedValue" Type="Boolean" />
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
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="Validate"
        ValidationGroup="val"></asp:CustomValidator>
    </form>
</body>
</html>
