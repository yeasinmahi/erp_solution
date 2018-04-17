﻿<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.BankChequeConfirm" Codebehind="BankChequeConfirm.aspx.cs" %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 


    <script type="text/javascript">
    function ShowPopUp(url){        
        newwindow = window.open(url,'sub','toolbar=0,height=430,width=800,top=250,left=200');
        if (window.focus) {newwindow.focus()}
        }
        
    function ShowPopUpE(url){        
        newwindow = window.open(url,'sub','toolbar=0,height=550,width=1000,top=70,left=220');
        if (window.focus) {newwindow.focus()}
        }
        
    function Validate(sender, args){
        if(!confirm('Do you want to continue?')){
            args.IsValid = false;
            isProceed = false;
        }
    }
       
    </script>

    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table style="width: 100%;">
                        <tr style="height:50px;">
                            <td align="left" style="width:50px;">
                                Voucher Type:
                                <asp:DropDownList ID="ddlDrCr" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDrCr_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="true">Bank Pay</asp:ListItem>
                                    <asp:ListItem Value="false">Bank Receive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="left">
                                
                            </td>
                            <td align="right">
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td align="left">                                
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table>
                                    
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoType_SelectedIndexChanged"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="act">Not Completed</asp:ListItem>
                                                <asp:ListItem Value="com">Completed</asp:ListItem>
                                                <asp:ListItem Value="cnd">Cancelled</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:HiddenField ID="hdnEnable" runat="server" Value="true" />
                                            <asp:HiddenField ID="hdnCompleted" runat="server" Value="false" />
                                            <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 50px;">
                                        </td>
                                        <td>
                                            From
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnFrm" runat="server" />
                                            <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                                ID="CalendarExtender1" runat="server" EnableViewState="true">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;To
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnTo" runat="server" />
                                            <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                                                ID="CalendarExtender2" runat="server" EnableViewState="true">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td style="width: 20px;">
                                        </td>
                                        <td>
                                            Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Go" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td style="width: 50px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            Date By
                                        </td>
                                        <td colspan="3">
                                            <asp:RadioButtonList ID="rdoByDate" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                OnSelectedIndexChanged="rdoByDate_SelectedIndexChanged">
                                                <asp:ListItem Value="true" Selected="True">Cheque</asp:ListItem>
                                                <asp:ListItem Value="false">Voucher</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
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
            <div>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Bank Voucher List"
                                runat="server" DataSourceID="ObjectDataSource1" 
                                AutoGenerateColumns="False" DataKeyNames="intBankVoucherID"
                                OnDataBound="GridView1_DataBound" onrowdatabound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="strCode" HeaderText="Voucher Code" SortExpression="strCode" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="strBankName" HeaderText="Bank Name" SortExpression="strBankName" />
                                    <asp:BoundField DataField="strAccountNo" HeaderText="Account No" SortExpression="strAccountNo"
                                        ReadOnly="True" />
                                    <asp:TemplateField HeaderText="Cheque Date" SortExpression="dteChequeDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteChequeDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Voucher Date" SortExpression="dteVoucherDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteVoucherDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="intVoucherPrintCount" HeaderText="Voucher Print Attempt"
                                        SortExpression="intVoucherPrintCount">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strUsedChequeNoList" HeaderText="Used Cheque No. List"
                                        SortExpression="strUsedChequeNoList" />
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# GetEditLink(Eval("intBankVoucherID")) %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUp('VoucherDetails.aspx?id=<%# Eval("intBankVoucherID") %>&type=bn&isDr=<%# ddlDrCr.SelectedValue %>')"
                                                class="link">Details</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUp('../Print/PrintVoucher.aspx?id=<%# Eval("intBankVoucherID") %>&type=bn&isDr=<%# ddlDrCr.SelectedValue %>')"
                                                class="link">Voucher Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUp('../Print/PrintCheck.aspx?id=<%# Eval("intBankVoucherID") %>')"
                                                class="link">Cheque Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUp('../Print/PrintMR.aspx?id=<%# Eval("intBankVoucherID") %>&type=bn')"
                                                class="link">MR Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCancel" runat="server" ValidationGroup="val" CommandArgument='<%# Eval("intBankVoucherID") %>'
                                                Text="Cancel" OnClick="btnCancel_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:CheckBoxField DataField="ysnEnable" HeaderText="Active" ItemStyle-CssClass="hide"
                                        HeaderStyle-CssClass="hide" SortExpression="ysnEnable">
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                    </asp:CheckBoxField>
                                    <asp:CheckBoxField DataField="ysnCompleted" HeaderText="Completed" ItemStyle-CssClass="hide"
                                        HeaderStyle-CssClass="hide" SortExpression="ysnCompleted">
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                    </asp:CheckBoxField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnChange" runat="server" ValidationGroup="val" CommandArgument='<%# Eval("intBankVoucherID") %>'
                                                Text="Change Cheque" OnClick="btnChange_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCompleted" ValidationGroup="val" runat="server" Text="Completed"
                                                CommandArgument='<%# Eval("intBankVoucherID") %>' OnClick="btnCompleted_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strType" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBankVoucherList"
                                TypeName="BLL.Accounts.Voucher.BankVoucher" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="hdnCompleted" Name="completed" PropertyName="Value"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="hdnEnable" Name="active" PropertyName="Value" Type="Boolean" />
                                    <asp:ControlParameter ControlID="ddlDrCr" Name="isDrVoucher" PropertyName="SelectedValue"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="hdnFrm" Name="fromDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="hdnTo" Name="toDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="rdoByDate" Name="isChequeDate" PropertyName="SelectedValue"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="txtCode" Name="code" PropertyName="Text" Type="String" />
                                    <asp:ControlParameter ControlID="hdnIsByCode" Name="isByCode" 
                                        PropertyName="Value" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:HiddenField ID="hdnIsByCode" runat="server" Value="false" />
                        </td>
                    </tr>
                </table>
                <br />
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
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="Validate"
        ValidationGroup="val"></asp:CustomValidator>
    </form>
</body>
</html>
