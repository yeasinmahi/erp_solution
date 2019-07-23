<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Banking.BankChequePrint" Codebehind="BankChequePrint.aspx.cs" %>





<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
      <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 

    <script type="text/javascript">
    function ShowPopUp(url){     
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;   
        newwindow = window.open(url,'sub','toolbar=0,height=290,width=1000,top=50,left=200');
        if (window.focus) {newwindow.focus()}
        }
        
    function ShowPopUpE(url){ 
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;       
        newwindow = window.open(url,'sub','toolbar=0,height=550,width=1000,top=70,left=220');
        if (window.focus) {newwindow.focus()}
        }

        function Validate(sender, args) {
            if (!confirm('Do you want to continue?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }

        function ValidateCh(sender, args) {
            if (document.getElementById('txtCode1').value == '' || document.getElementById('txtCode2').value == '') {
                alert('Please enter voucher code');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Do you want to continue?')) {
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
                    <table>
                        <tr>
                            <td>
                                Unit:
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td style="background-color:#D0D0D0;"> 
                                Cheque No Interchange                               
                            </td>
                            <td style="background-color:#D0D0D0;">    
                                Voucher Code: <asp:TextBox ID="txtCode1" runat="server"></asp:TextBox>                            
                                <asp:TextBox ID="txtCode2" runat="server"></asp:TextBox>
                            </td>
                            <td style="background-color:#D0D0D0;">      
                                <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                            </td>
                            <td style="background-color:#D0D0D0;"> 
                                <asp:Button ID="btnChange" runat="server" Text="Make Change" 
                                    onclick="btnChange_Click" ValidationGroup="valCh"/>                               
                            </td>                                                                                   
                        </tr>
                        <tr>
                            <td colspan="5" style=" padding-top:20px">
                                <table>
                                    
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoType_SelectedIndexChanged"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="false">Not Printed</asp:ListItem>
                                                <asp:ListItem Value="true">Printed</asp:ListItem>                                                
                                            </asp:RadioButtonList>
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
                                            <asp:TextBox ID="txtFrom" runat="server" Enabled="false" autocomplete="off"></asp:TextBox>
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
                            <asp:GridView ID="GridView1" SkinID="sknGrid1" CaptionAlign="Top" Caption="Cheque Print"
                                runat="server" DataSourceID="ObjectDataSource1" 
                                AutoGenerateColumns="False" DataKeyNames="intBankVoucherID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Voucher Code" SortExpression="strCode">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bank Name" SortExpression="strBankName">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("strBankName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account No" SortExpression="strAccountNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("strAccountNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque Date" SortExpression="dteChequeDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteChequeDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Voucher Date" SortExpression="dteVoucherDate" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteVoucherDate")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" SortExpression="monAmount" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Math.Abs(double.Parse(""+Eval("monAmount")))) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Used Cheque No. List" 
                                        SortExpression="strUsedChequeNoList">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("strUsedChequeNoList") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pay To" SortExpression="strPayToPrint">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" Width="200" runat="server" Text='<%# Bind("strPayToPrint") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("strPayToPrint") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# LinkString(Eval("intBankVoucherID"), Eval("strCode"), "ShowPopUpE", "../Voucher/VoucherDetails.aspx","Details")%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>                                            
                                            <%# LinkString(Eval("intBankVoucherID"), Eval("strCode"), "ShowPopUp", "../Print/PrintCheck.aspx", "Cheque Print")%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>                                    
                                    <asp:TemplateField HeaderText="Type" SortExpression="strType">
                                        <ItemTemplate>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("strType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCompleted" ValidationGroup="val" runat="server" Text="Printed"
                                                CommandArgument='<%# Eval("intBankVoucherID")+"#"+Eval("strCode") %>' OnClick="btnCompleted_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>                                    
                                    <asp:CommandField ShowEditButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBankVoucherList"
                                TypeName="BLL.Accounts.Banking.VoucherForChqPrint"                                                                
                                UpdateMethod="UpdateBankVoucherPayTo">                               
                                <UpdateParameters>
                                    <asp:Parameter Name="unitID" Type="Int32" />
                                    <asp:Parameter Name="fromDate" Type="String" />
                                    <asp:Parameter Name="toDate" Type="String" />
                                    <asp:Parameter Name="isChequeDate" Type="Boolean" />
                                    <asp:Parameter Name="isChqPrinted" Type="Boolean" />
                                    <asp:Parameter Name="code" Type="String" />
                                    <asp:Parameter Name="isByCode" Type="Boolean" />
                                    <asp:Parameter Name="strCode" Type="String" />
                                    <asp:Parameter Name="strBankName" Type="String" />
                                    <asp:Parameter Name="strAccountNo" Type="String" />
                                    <asp:Parameter Name="strUsedChequeNoList" Type="String" />
                                    <asp:Parameter Name="strPayToPrint" Type="String" />
                                    <asp:Parameter Name="strType" Type="String" />
                                    <asp:Parameter Name="intBankVoucherID" Type="Int64" />                                    
                                    <asp:SessionParameter Name="userID" Type="String" SessionField="sesUserID" />
                                </UpdateParameters>
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="hdnFrm" Name="fromDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="hdnTo" Name="toDate" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="rdoByDate" Name="isChequeDate" PropertyName="SelectedValue"
                                        Type="Boolean" />
                                    <asp:ControlParameter ControlID="rdoType" Name="isChqPrinted" PropertyName="SelectedValue"
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
     <asp:CustomValidator ID="cvt2" runat="server" ClientValidationFunction="ValidateCh"
        ValidationGroup="valCh"></asp:CustomValidator>

        

    </form>
</body>
</html>
