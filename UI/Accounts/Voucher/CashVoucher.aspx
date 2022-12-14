<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Voucher.CashVoucher" Codebehind="CashVoucher.aspx.cs" %>



<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html>
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script type="text/javascript">
    function ShowPopUpVr(url){        
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=580,width=900,top=50,left=200');
        if (window.focus) {newwindow.focus()}
        }
    function ShowPopUpMr(url){ 
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;       
        newwindow = window.open(url,'sub','toolbar=0,height=330,width=750,top=200,left=200');
        if (window.focus) {newwindow.focus()}
        }
    function ShowPopUpE(url){        
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
        if (window.focus) {newwindow.focus()}
        }
        
    function Validate(sender, args){
        if(!confirm('Do you want to continue?')){
            args.IsValid = false;
            isProceed = false;
        }
    }
    
    function ValidateComplete(sender, args){
        var txt = document.getElementById("txtCompleteDate").value;
        
        if(txt==''){
            alert('Please select a complete date');
            args.IsValid = false;
            isProceed = false;
        }
        else if(!confirm('Do you want to complete this voucher at this date: ' + txt + ' ?')){
            args.IsValid = false;
            isProceed = false;
        }
    }
    
    function ValidateCompleteAll(sender, args){
        var txt = document.getElementById("txtCompleteDate").value;
        
        if(txt==''){
            alert('Please select a complete date');
            args.IsValid = false;
            isProceed = false;
        }
        else if(!confirm('Do you want to complete this voucher at this date: ' + txt + ' ?')){
            args.IsValid = false;
            isProceed = false;
        }
    }
    </script>
     <script>
         function DocViewData(url) {
             newwindow = window.open(url, 'sub', 'height=450, width=550, scrollbars=yes, left=300, top=150, resizable=yes, title=Preview');
             if (window.focus) { newwindow.focus() }
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
                    <table style="width: 100%;">
                        <tr>
                            <td align="right">
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Voucher Type:
                                <asp:DropDownList ID="ddlDrCr" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDrCr_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="true">Cash Pay</asp:ListItem>
                                    <asp:ListItem Value="false">Cash Receive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoType_SelectedIndexChanged"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="act">Not Completed</asp:ListItem>
                                                <asp:ListItem Value="com">Completed</asp:ListItem>
                                                <asp:ListItem Value="cnd">Deleted</asp:ListItem>
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
                                            <asp:HiddenField ID="hdnFrm" runat="server"/>
                                            <asp:TextBox ID="txtFrom" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                                ID="CalendarExtender1" runat="server" EnableViewState="true">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td>
                                            To
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnTo" runat="server"/>
                                            <asp:TextBox ID="txtTo" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
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
                        <td align="right" style="color:Green;">
                            <asp:Button ID="btnCheckAll" runat="server" onclick="btnCheckAll_Click" 
                                Text="Check All" />
                            <asp:Button ID="btnCompleteAll" runat="server" onclick="btnCompleteAll_Click" 
                                Text="Complete selected" ValidationGroup="valComAll" />
                        Complete Date: 
                        &nbsp;<asp:TextBox ID="txtCompleteDate" runat="server" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtCompleteDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_3"
                            ID="CalendarExtender3" runat="server" EnableViewState="true">
                        </cc1:CalendarExtender>
                        <img id="imgCal_3" src="../../App_Themes/Default/images/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="intCashVoucherID"
                                SkinID="sknGrid1" CaptionAlign="Top" Caption="Cash Voucher List" 
                                DataSourceID="ObjectDataSource1" onrowdatabound="GridView1_RowDataBound" 
                                ShowFooter="True" ondatabound="GridView1_DataBound">
                                <Columns>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                            <asp:HiddenField ID="HiddenField1" runat="server" 
                                                Value='<%# Eval("intCashVoucherID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strCode" HeaderText="Code" SortExpression="strCode"  
                                        ItemStyle-Width="100" >
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strNarration" HeaderText="Narration" 
                                        FooterText="Total: " FooterStyle-HorizontalAlign="Right" 
                                        SortExpression="strNarration" >
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="Label3F" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(totAmount)) %>'></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        <FooterStyle HorizontalAlign="Right"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                        
                                        <ItemTemplate>                                           
                                          <%# GetPayToReceiveFromString(""+Eval("strPayToPrint"), ""+Eval("strReceiveFromPrint") ) %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Voucher/Complete Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label14567" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteVoucherDate")) %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label1111" runat="server" ForeColor="Red" Text='<%#  GetCompleteDateString("" + Eval("dtePostingSubledger")) %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%# GetEditLink(Eval("intCashVoucherID"))%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUpVr('VoucherDetails.aspx?id=<%# Eval("intCashVoucherID") %>&type=ch&isDr=<%# ddlDrCr.SelectedValue %>')"
                                                class="link">Details</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUpVr('../Print/PrintVoucher.aspx?id=<%# Eval("intCashVoucherID") %>&type=ch&isDr=<%# ddlDrCr.SelectedValue %>')"
                                                class="link">Voucher Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="#" onclick="ShowPopUpMr('../Print/PrintMR.aspx?id=<%# Eval("intCashVoucherID") %>&type=ch')"
                                                class="link">MR Print</a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCancel" runat="server" ValidationGroup="val" CommandArgument='<%# Eval("intCashVoucherID") %>'
                                                Text="Delete" OnClick="btnCancel_Click" />
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
                                            <asp:Button ID="btnCompleted" runat="server" ValidationGroup="valCom" Text="Completed" CommandArgument='<%# Eval("intCashVoucherID") %>'
                                                OnClick="btnCompleted_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Download">
                                  <ItemTemplate>
                                    <asp:Button ID="BtnDetalisdownload" runat="server" Text='<%# Bind("download") %>'  CommandArgument='<%# Eval("strFilePath") %>'  OnClick="BtnDetalisdownload_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCashVoucherList"
                                TypeName="BLL.Accounts.Voucher.CashVoucher" OldValuesParameterFormatString="original_{0}">
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
    <asp:CustomValidator ID="cvt" runat="server" 
    ClientValidationFunction="Validate" ValidationGroup="val"></asp:CustomValidator>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>
     <asp:CustomValidator ID="cvtCom2" runat="server" ClientValidationFunction="ValidateCompleteAll"
        ValidationGroup="valComAll"></asp:CustomValidator>
        
    </form>
</body>
</html>
