<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Banking.Counter.ChqReceive" Codebehind="ChqDelivery.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script type="text/javascript">
    function ShowPopUp(url){     
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;   
        newwindow = window.open(url,'sign','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=no,top=0,left=0,fullscreen=yes,height=screen.height,width=screen.width');
        if (window.focus) {newwindow.focus()}
        }
        
    function Validate(sender, args){
        if(!confirm('Do you want to continue?')){
            args.IsValid = false;
            isProceed = false;
        }
    }
    
    function ValidateComplete(sender, args){
        /*var txt = document.getElementById("txtCompleteDate").value;
        if(txt==''){
            alert('Please select a complete date');
            args.IsValid = false;
            isProceed = false;
        }
        else */if(!confirm('Do you want to Issue this cheque to customer?')){
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
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
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
                       
                        <tr style="height: 50px;">
                            <td align="left" style="width: 50px;">
                                <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoType_SelectedIndexChanged"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="rd">Ready</asp:ListItem>
                                    <asp:ListItem Value="pn">Pending</asp:ListItem>
                                    <asp:ListItem Value="gv">Given</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:HiddenField ID="hdnReady" runat="server" Value="true" />
                                <asp:HiddenField ID="hdnPending" runat="server" Value="false" />
                                <asp:HiddenField ID="hdnGiven" runat="server" Value="false" />
                                <asp:HiddenField ID="hdnCus" runat="server" Value="false" />
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="odsBooth" runat="server" 
                                    SelectMethod="GetAllActiveBoothsByUnit" 
                                    TypeName="BLL.Accounts.Banking.Counter.Booth">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td colspan="4">
                                <asp:Panel ID="pnlDate" Visible="false" runat="server">
                                
                                <table align="center">
                                    <tr>
                                        <td>
                                            From
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnFrm" runat="server" />
                                            <asp:TextBox ID="txtFrom" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                                ID="CalendarExtender1" runat="server" EnableViewState="true">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td>
                                            &nbsp;&nbsp;To
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnTo" runat="server" />
                                            <asp:TextBox ID="txtTo" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                                                ID="CalendarExtender2" runat="server" EnableViewState="true">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </td>                            
                            <td align="right">
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                
                            </td>
                            <td align="right">
                                Booth:
                                <asp:DropDownList ID="ddlBooth" runat="server"
                                    DataSourceID="odsBooth" DataTextField="strDescritption" 
                                    DataValueField="intBoothId">
                                </asp:DropDownList>                                
                            </td>
                        </tr>
                        
                         <tr style="height: 50px;">
                            <td align="left" style="width: 250px;">
                                
                            </td>
                            <td align="left">
                                Cheque Bearer
                            </td>
                            <td align="left">
                                    <asp:TextBox ID="txtCOA" runat="server" AutoCompleteType="Search" Width="255px" AutoPostBack="True"
                                        OnTextChanged="txtCOA_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCOA"
                                    ServiceMethod="GetCOAList" MinimumPrefixLength="3" CompletionSetCount="1" CompletionInterval="1"
                                    FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td>
                                Cheque No
                            </td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                            <td align="right">
                                <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="Go" />
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
                        <td style="width:50%" align="right">                            
                            <asp:Image ID="imgSig" Width="400" Height="100" runat="server" BorderWidth="1" 
                                BorderColor="#F0F0F0" BorderStyle="Solid" ImageUrl="~/Images/white.png" />                            
                        </td>
                        <td style="width:50%" align="left">
                            <asp:Button ID="btnShowImage" runat="server" Text="Show Sign" 
                                onclick="btnShowImage_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <asp:Label ID="lblMsg" ForeColor="Maroon" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Cheque Issue List"
                                runat="server" DataSourceID="ObjectDataSource1" 
                                AutoGenerateColumns="False" DataKeyNames="intBankVoucherID"
                                OnDataBound="GridView1_DataBound" ShowFooter="True" 
                                onrowdatabound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="strCode" HeaderText="Code" SortExpression="strCode" />
                                    <asp:BoundField ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" DataField="intBankVoucherID"
                                        HeaderText="intBankVoucherID" SortExpression="intBankVoucherID" ReadOnly="True">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strAccountNo" HeaderText="Account No" SortExpression="strAccountNo"
                                        ReadOnly="True"></asp:BoundField>
                                    <asp:BoundField DataField="strBankName" HeaderText="Bank Name" SortExpression="strBankName" />
                                    <asp:BoundField DataField="strNarration" HeaderText="Narration" 
                                        SortExpression="strNarration" />
                                    <asp:TemplateField HeaderText="Voucher Date" SortExpression="dteVoucherDate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteVoucherDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque Date" SortExpression="dteChequeDate">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteChequeDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strType" HeaderText="Type" ReadOnly="True" SortExpression="strType" />
                                    <asp:BoundField DataField="strChequeNo" HeaderText="Cheque No" SortExpression="strChequeNo" />
                                    <asp:TemplateField HeaderText="Posting AT" SortExpression="dtePostingSubledger">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval(("dtePostingSubledger"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chq Issue AT" SortExpression="dteChqGivenTime">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval(("dteChqGivenTime"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chq Print AT" SortExpression="dteChqPrintTime">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval(("dteChqPrintTime"))) %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                   
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCompleted" ValidationGroup="valCom" runat="server" Text="Chq Issued"
                                                CommandArgument='<%# Eval("strCode")+"#"+ Eval("intBankVoucherID") %>' OnClick="btnCompleted_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                            
                                            <asp:Button ID="btnTakeSign" runat="server" Text="Take Sign" 
                                            CommandArgument='<%# Eval("strCode")+"#"+ Eval("intBankVoucherID") %>' OnClick="btnTakeSign_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                            
                                            <asp:Button ID="btnCancelSign" runat="server" Text="Cancel Sign" 
                                            CommandArgument='<%# Eval("strCode")+"#"+ Eval("intBankVoucherID") %>' OnClick="btnCancelSign_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>  
                                </Columns>
                            </asp:GridView>
                            <asp:HiddenField ID="hdnVid" runat="server" />
                            <asp:HiddenField ID="hdnSid" runat="server" />
                            
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBankVoucherListForChqSearch"
                                TypeName="BLL.Accounts.Banking.Counter.ChqDelivery" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="hdnFrm" Name="fromDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="hdnTo" Name="toDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="hdnCus" Name="customerCode" PropertyName="Value"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="txtCode" Name="chequeNo" PropertyName="Text" Type="String" />                                    
                                    <asp:ControlParameter ControlID="hdnReady" Name="isReady" PropertyName="Value" Type="Boolean" />
                                    <asp:ControlParameter ControlID="hdnPending" Name="isPending" PropertyName="Value"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="hdnGiven" Name="isGiven" PropertyName="Value" Type="Boolean" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
                <img alt="" src="../../../Content/images/img/loading.gif" style="border: 0px;"
                    title="Loading" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="Validate"
        ValidationGroup="val"></asp:CustomValidator>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>

       

    </form>
</body>
</html>
