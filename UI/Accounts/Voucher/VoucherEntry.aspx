<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.Voucher.VoucherEntry" Codebehind="VoucherEntry.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Welcome to Akij Group</title>
     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
    
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/voucherInsertCSS" />

    <!--
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/>
     <link href="../../Content/CSS/Calender.css" rel="stylesheet" type="text/css"/>
    <link href="../../Content/CSS/Grid.css" rel="stylesheet" type="text/css"/>
        -->
    <style type="text/css">
        .divPopUpItem
        {
            position: absolute;
            width: 500px;
            height: 500px;
            z-index: 1;
            left: 0px;
            top: 100px;
            background-color: #f0f0ff;
            border: 3px outset #00367B;
            overflow: scroll;
        }

    </style>

    <script type="text/javascript">
    function scrollPanel()
        {
            var panel = document.getElementById("pnlJSScroll");
            panel.scrollTop=panel.scrollHeight;
        }
    function ShowPopUp(url){        
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no;   
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=580,width=900,top=50,left=200');
        if (window.focus) {newwindow.focus()}
        }
        
    function ShowPopUpE(url){        
        var rand_no = Math.floor(11*Math.random());
        url = url + '&rnd='+rand_no; 
        newwindow = window.open(url,'sub','scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
        if (window.focus) {newwindow.focus()}
        }
        
    
    var type = 'acc';
    function ShowBank(type_){
        document.getElementById("divPopUp").style.display = "block";
        type = type_;
    }
    function SetParam(id, txt, divID){
        if(type == 'acc'){
        document.getElementById("hdnAccountID").value = id;
        document.getElementById("lblAccount").innerHTML = txt;
        document.getElementById("hdnAccountText").value = txt;
        }
        else if(type == 'pr'){
        //document.getElementById("hdnAccountIDPR").value = id;        
        document.getElementById("lblAccountPR").innerHTML = txt;                 
        }
        HideDiv(divID);
    }
    function HideDiv(id){
        document.getElementById(id).style.display = "none";   
    }
    function AddValidate( sender, args ){        
        var flag = true;
        
        if(flag && document.getElementById("ddlAccount") != null){            
            if(document.getElementById("ddlAccount").value == ''){
            alert('Please add a account no.');
            document.getElementById("txtAmount").focus();
            NotExecute(sender, args);
            flag = false;}
        }
        
        if(flag && document.getElementById("ddlConAccount") != null){            
            if(document.getElementById("ddlConAccount").value == document.getElementById("ddlAccount").value){
            alert('Account transfer to same account is not allowed');
            document.getElementById("txtAmount").focus();
            NotExecute(sender, args);
            flag = false;}
        }
        
        if(flag && document.getElementById("txtCOA") != null){
            if(document.getElementById("txtCOA").value == ''){
            alert('Please select an account head.');
            document.getElementById("txtCOA").focus();
            NotExecute(sender, args);
            flag = false;}
        }
        
        if(flag && document.getElementById("txtAmount") != null){
            if(document.getElementById("txtAmount").value == ''){
            alert('Please enter a number in amount field');
            document.getElementById("txtAmount").focus();
            NotExecute(sender, args);
            flag = false;}
        }
        
       if(flag && document.getElementById("txtAmount") != null){            
            /*if(isNaN(document.getElementById("txtAmount").value)){
            alert('Please enter a number in amount field');*/
             var reg = new RegExp("[^0-9.%+-]");              
            if(reg.test(document.getElementById("txtAmount").value)){
            alert('Please enter a number in amount field');
            document.getElementById("txtAmount").focus();
            NotExecute(sender, args);
            flag = false;}
            }
    }    
    function SaveValidate( sender, args ){
        var flag = true;
        
        if(flag && document.getElementById("txtPRPrint") != null){
            if(document.getElementById("txtPRPrint").value == ''){
                alert('Please enter paid / received by info.');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtChqDate") != null){
            if(document.getElementById("txtChqDate").value == ''){
                alert('Please enter cheque date');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtCheckNoR") != null){
            if(document.getElementById("txtCheckNoR").value == ''){
                alert('Please enter cheque no');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtChqDateR") != null){
            if(document.getElementById("txtChqDateR").value == ''){
                alert('Please enter cheque date');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("hdnGridCrAmount").value != document.getElementById("hdnGridDrAmount").value){            
            alert('Please make equal debit & credit amount');
            NotExecute(sender, args);
            flag = false;
       }
       
       if(flag && document.getElementById("txtCheckNo") != null){
            if(document.getElementById("txtCheckNo").value == ''){
                //ConfirmMessage('Do you want to save without cheque no?', sender, args);
                alert('Please enter cheque no');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtBank") != null){
            if(document.getElementById("txtBank").value == ''){
                alert('Please enter depositors bank name');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtBranch") != null){
            if(document.getElementById("txtBranch").value == ''){
                alert('Please enter depositors branch name');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtDrawn") != null){
            if(document.getElementById("txtDrawn").value == ''){
                alert('Please enter depositors drawn branch name');
                NotExecute(sender, args);
                flag = false;
            }
       }
       
       if(flag && document.getElementById("txtConPR") != null){
            if(document.getElementById("txtConPR").value == ''){
                if(!confirm('Do you want to save without name?')){
                    NotExecute(sender, args);
                    flag = false;
                }                
            }
       }
       
       if(flag){
            var txt = document.getElementById("txtVoucherDate").value;        
            if(txt==''){
                alert('Please select a voucher date');
                args.IsValid = false;
                isProceed = false;
            }
            else if(!confirm('Do you want to save this voucher at this date: ' + txt + ' ?')){
                args.IsValid = false;
                isProceed = false;
            }
       }
    }
    
    function CancelValidate( sender, args ){
        ConfirmMessage('Do you want to cancel?', sender, args);
    }
    
    function ConfirmMessage(msg, sender, args){
        if(!confirm(msg)){
            NotExecute(sender, args);
        }
    }
    function NotExecute(sender, args){
        args.IsValid = false;
        isProceed = false;
    }   
    
    function Validate(sender, args){
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
    function ChangeRdoTypeR(){
        var obj;
        var tmp='';
        
        for(var i=0;i<=6;i++){
            tmp='rdoTypeR_'+i;
            obj = document.getElementById(tmp);
            if(obj.checked){
            tmp=obj.value;
            break;
            }
        }
        
        if(tmp=="chq"){
        document.getElementById("txtCheckNoR").value = "";        
        }
        else if(tmp=="dd"){
        document.getElementById("txtCheckNoR").value = "";
        }
        else if(tmp=="po"){
        document.getElementById("txtCheckNoR").value = "";
        }
        else if(tmp=="ds"){
        document.getElementById("txtCheckNoR").value = "";
        }
        else if(tmp=="ad"){
        document.getElementById("txtCheckNoR").value = "Advice";
        }
        else if(tmp=="aj"){
        document.getElementById("txtCheckNoR").value = "Adjustment";
        }
        else if(tmp=="on"){
        document.getElementById("txtCheckNoR").value = "";
        }        
        document.getElementById("txtCheckNoR").focus();
    }
    </script>

    <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'UA-125570863-1');
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
     
     
             
   
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"  
        LoadScriptsBeforeUI="false">
      <CompositeScript>
          <Scripts>
              <asp:ScriptReference name="MicrosoftAjax.js"/>
	            <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	            <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit,Version=4.1.60919.0,Culture=neutral,PublicKeyToken=28f01b0e84b6d53e"/>
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
             <Triggers>
                    <asp:PostBackTrigger ControlID="btnSave"  />                    
             </Triggers>
           

        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
               
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <table width="100%">
                        <tr>
                            <td style="width: 120px">
                                <b><i>Voucher Type:</i></b>
                            </td>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <b>Debit Voucher</b>
                                        </td>
                                        <td style="width: 75px;">
                                        </td>
                                        <td>
                                            <b>Credit Voucher</b>
                                        </td>
                                        <td style="width: 75px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="right">
                                            Unit:
                                            <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                                DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                                OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rdoDrBnk" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Bank Pay
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdoCrBnk" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Bank Receive
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdoJr" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Journal
                                        </td>
                                        <td>
                                            <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                            <font color="#990000"><b>Voucher Date</b></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rdoDrCsh" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Cash Pay
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdoCrCsh" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Cash Receive
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdoCon" runat="server" GroupName="voucher" AutoPostBack="true"
                                                OnCheckedChanged="rdo_CheckedChanged" />Contra
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnVoucherID" runat="server" Value="" />
                                             <asp:HiddenField ID="HdnDocUplod" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnIsManualChqNo" runat="server" Value="false" />
                                            <asp:HiddenField ID="hdnRdo" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnXMLFilePath" runat="server" Value="" />
                                            <asp:TextBox ID="txtVoucherDate" Enabled="false" runat="server"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtVoucherDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_3"
                                                ID="CalendarExtender3" runat="server">
                                            </cc1:CalendarExtender>
                                            <img id="imgCal_3" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                    </tr>
                                  
                                </table>
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
                        <td style="vertical-align: top; padding-top: 7px;">
                            <asp:Panel ID="pnlMain" runat="server" Visible="false">
                                <table cellpadding="0" cellspacing="0" style="background-color: #E0E0E0; padding: 5px 5px 5px 5px;">
                                    
                                    <asp:Panel ID="pnlBank" runat="server" Visible="false">
                                        <tr>
                                            <td>
                                                Bank
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBank" runat="server" AutoPostBack="True" DataSourceID="odsBank"
                                                    DataTextField="strBankName" DataValueField="intBankID" OnDataBound="ddlBank_DataBound">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr style="width: 20px;">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                A/C No.
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAccount" runat="server" AutoPostBack="True" DataSourceID="odsAccount"
                                                    DataTextField="strAccountNo" DataValueField="intAccountID" OnDataBound="ddlAccount_DataBound"
                                                    OnSelectedIndexChanged="ddlAccount_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsAccount" runat="server" SelectMethod="GetActiveForDDL"
                                                    TypeName="BLL.Accounts.Bank.BankAccount" OldValuesParameterFormatString="original_{0}">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue"
                                                            Type="String" />
                                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                            Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                        <tr style="width: 20px;">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlCheque" runat="server" Visible="false">
                                            <tr>
                                                <td>
                                                    Type
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdoType" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="rdoType_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="chq">Cheque</asp:ListItem>
                                                        <asp:ListItem Value="ad">Advc</asp:ListItem>
                                                        <asp:ListItem Value="aj">Adjs</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    No.
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCheckNo" runat="server" Width="190px" ReadOnly="true"></asp:TextBox>
                                                    <asp:CheckBox ID="chkCheckNo" runat="server" Text="M" OnCheckedChanged="chkCheckNo_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtChqDate" runat="server" Width="150px" Enabled="false" ></asp:TextBox>
                                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtChqDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                                                        ID="CalendarExtender1" runat="server">
                                                    </cc1:CalendarExtender>
                                                    <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                        width: 34px; height: 23px; vertical-align: bottom;" />
                                                </td>
                                            </tr>
                                            <tr style="width: 20px;">
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlAccHead" runat="server">
                                       
                                        <tr style="background-color: #FFFFFF;">
                                            <td>
                                                Dr / Cr
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdoDrCr" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="Dr">Debit</asp:ListItem>
                                                    <asp:ListItem Value="Cr">Credit</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="width: 20px;">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <b>Account Sub Head</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:TextBox ID="txtCOA" runat="server" AutoCompleteType="Search" Width="255px" AutoPostBack="true"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCOA"
                                                    ServiceMethod="GetCOAList" MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="1"
                                                    FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlContra" runat="server">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdoDrCrContra" runat="server" RepeatDirection="Vertical"
                                                    OnSelectedIndexChanged="rdoDrCrContra_SelectedIndexChanged" AutoPostBack="true">
                                                    <asp:ListItem Selected="True" Value="0">Bank To Cash</asp:ListItem>
                                                    <asp:ListItem Value="1">Cash To Bank</asp:ListItem>
                                                    <asp:ListItem Value="2">Bank To Bank</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <asp:Panel ID="pnlCon" runat="server" Visible="false">
                                            <tr style="width: 20px;">
                                                <td colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr style="width: 20px;">
                                                <td colspan="2">
                                                    <asp:RadioButtonList ID="rdoContraDrCr" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Debit" Value="true" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Credit" Value="false"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Bank
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlConBank" runat="server" AutoPostBack="True" DataSourceID="odsBank"
                                                        DataTextField="strBankName" DataValueField="intBankID">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr style="width: 20px;">
                                                <td colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    A/C No:
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlConAccount" runat="server" DataSourceID="odsConAccount" DataTextField="strAccountNo"
                                                        DataValueField="intAccountID">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsConAccount" runat="server" SelectMethod="GetActiveForDDL"
                                                        TypeName="BLL.Accounts.Bank.BankAccount" OldValuesParameterFormatString="original_{0}">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="ddlConBank" Name="bankID" PropertyName="SelectedValue"
                                                                Type="String" />
                                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                                Type="String" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                    </asp:Panel>
                                    <tr style="width: 20px;">
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="width: 20px;">
                                        <td colspan="2">
                                            Cost Center:<br />
                                            <asp:DropDownList ID="ddlCCntr" runat="server" Width="250px" DataSourceID="odscstcntr" DataValueField="intCostCenterID" DataTextField="strCCName">
                                            </asp:DropDownList><asp:ObjectDataSource ID="odscstcntr" runat="server" SelectMethod="GetCostCenterList" TypeName="BLL.Accounts.Voucher.Budget">
                                            <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="unit" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr style="width: 20px;">
                                        <td colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Amount
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtAmount" runat="server" Width="260"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="pnlConPR" runat="server" Visible="false">
                                    <tr>
                                        <td colspan="2">
                                            Pay To
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtConPR" runat="server" Width="260"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" TargetControlID="txtConPR"
                                                ServiceMethod="GetDataForPayReceive" MinimumPrefixLength="3" CompletionSetCount="1"
                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false"
                                                CompletionListCssClass="autocomplete_completionListElementBig" CompletionListItemCssClass="autocomplete_listItem"
                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                            </cc1:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td colspan="2" style="padding-top: 10px">
                                            Narration
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtNarration" runat="server" TextMode="MultiLine" Width="260px"
                                                Height="70px" Text="Being the amount paid to "></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="add" />
                                            <asp:CustomValidator ID="cvtAdd" runat="server" ClientValidationFunction="AddValidate"
                                                ValidationGroup="add"></asp:CustomValidator>
                                            <asp:ObjectDataSource ID="odsBank" runat="server" OldValuesParameterFormatString="original_{0}"
                                                SelectMethod="GetActiveForDDL" TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnBankID" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnBankAccID" runat="server" />
                                            <asp:HiddenField ID="hdnChequeNo" runat="server" />
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td style="vertical-align: top;">
                            <asp:Panel ID="pnlGrid" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlReceive" runat="server">
                                                <table>
                                                    <tr style="vertical-align: top;">
                                                        <td style="background-color: #E0E0E0">
                                                            <table style="height: 142px;">
                                                                <tr>
                                                                    <td align="left" style="width: 300px;">
                                                                        <b>
                                                                            <asp:Label ID="lblPR" runat="server" Text=""></asp:Label></b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top;">
                                                                        <asp:TextBox ID="txtPRPrint" runat="server" Width="270"></asp:TextBox>
                                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtPRPrint"
                                                                            ServiceMethod="GetDataForPayReceive" MinimumPrefixLength="3" CompletionSetCount="1"
                                                                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false"
                                                                            CompletionListCssClass="autocomplete_completionListElementBig" CompletionListItemCssClass="autocomplete_listItem"
                                                                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                                        </cc1:AutoCompleteExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        Remarks
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRemarks" TextMode="MultiLine" Height="50px" Width="270px" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>
                                                            <asp:Panel ID="pnlBankR" runat="server" BackColor="#E0E0E0">
                                                                <table>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <b>Received Through</b>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Bank
                                                                        </td>
                                                                        <td style="vertical-align: top;">
                                                                            <asp:TextBox ID="txtBank" runat="server" Width="150px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="vertical-align: top;">
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtBank"
                                                                                ServiceMethod="GetDataForDepositorBank" MinimumPrefixLength="1" CompletionSetCount="1"
                                                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false"
                                                                                CompletionListCssClass="autocomplete_completionListElementBig" CompletionListItemCssClass="autocomplete_listItem"
                                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Branch
                                                                        </td>
                                                                        <td style="vertical-align: top;">
                                                                            <asp:TextBox ID="txtBranch" runat="server" Width="150px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="vertical-align: top;">
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtBranch"
                                                                                ServiceMethod="GetDataForDepositorBranch" MinimumPrefixLength="1" CompletionSetCount="1"
                                                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false"
                                                                                CompletionListCssClass="autocomplete_completionListElementBig" CompletionListItemCssClass="autocomplete_listItem"
                                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Drawn On
                                                                        </td>
                                                                        <td style="vertical-align: top;">
                                                                            <asp:TextBox ID="txtDrawn" runat="server" Width="150px"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left" style="vertical-align: top;">
                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtDrawn"
                                                                                ServiceMethod="GetDataForDepositorBranch" MinimumPrefixLength="1" CompletionSetCount="1"
                                                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false"
                                                                                CompletionListCssClass="autocomplete_completionListElementBig" CompletionListItemCssClass="autocomplete_listItem"
                                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                                            </cc1:AutoCompleteExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Type
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:RadioButtonList ID="rdoTypeR" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Selected="True" Value="chq">Cheque</asp:ListItem>
                                                                                <asp:ListItem Value="dd">DD</asp:ListItem>
                                                                                <asp:ListItem Value="po">PO</asp:ListItem>
                                                                                <asp:ListItem Value="ds">CDS</asp:ListItem>
                                                                                <asp:ListItem Value="on">Online</asp:ListItem>
                                                                                <asp:ListItem Value="ad">Advc</asp:ListItem>
                                                                                <asp:ListItem Value="aj">Adjs</asp:ListItem>
                                                                                
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="vertical-align: bottom;">
                                                                            No.
                                                                        </td>
                                                                        <td style="vertical-align: bottom;">
                                                                            <asp:TextBox ID="txtCheckNoR" runat="server" Width="130px"></asp:TextBox>
                                                                        </td>
                                                                        <td style="vertical-align: bottom;">
                                                                            <asp:TextBox ID="txtChqDateR" runat="server" Enabled="true"></asp:TextBox>
                                                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtChqDateR" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                                                                                ID="CalendarExtender2" runat="server">
                                                                            </cc1:CalendarExtender>
                                                                            <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                                                                width: 34px; height: 23px; vertical-align: bottom;" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlJSScroll" runat="server" Height="250px" ScrollBars="Vertical">
                                            <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                                                AutoGenerateColumns="False" CaptionAlign="Top" Caption="Voucher Details" OnDataBound="GridView1_DataBound"
                                                ShowFooter="True" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Account Head" SortExpression="Cat">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Acc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            Total
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Narration" SortExpression="Narr">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Narr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox2" TextMode="MultiLine" Width="300" Height="50" runat="server"
                                                                Text='<%# Eval("Narr") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="300" Height="50"></asp:TextBox>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Debit" SortExpression="Dr">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Dr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Dr") %>' Visible='<%# ""+Eval("Dr")==""?false:true %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Credit" SortExpression="Cr">
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Cr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Cr") %>' Visible='<%# ""+Eval("Cr")==""?false:true %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                                Text="">
                                                                <img alt=""  src="../../Content/images/Icons/Delete.png" style="border: 0px;" title="Delete"/>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowEditButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="false"  EnableViewState="false"
                                                runat="server"></asp:XmlDataSource>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Attachment
                                        </td>
                                    </tr>
                                 <tr>
                                <td>
                                      <asp:FileUpload ID="txtDocUpload" runat="server"/> 
                                </td>
                                </tr>                                 
                                     
                                    <tr>

                                        <td>
                                          
                                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="save"  />
                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                                ValidationGroup="cancel" />
                                            <asp:CustomValidator ID="cvtSave" runat="server" ClientValidationFunction="SaveValidate"
                                                ValidationGroup="save"></asp:CustomValidator>
                                            <asp:CustomValidator ID="cvtCancel" runat="server" ClientValidationFunction="CancelValidate"
                                                ValidationGroup="cancel"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                   
                </table>
                <asp:Panel ID="pnlAfterSave" runat="server" Visible="false">
                    <table style="width: 100%; vertical-align: bottom; padding-left: 10px;">
                        <tr style="background-color: #F0F0FF;">
                            <td colspan="9" style="text-align: center; font-size: 14px; font-weight: bold; color: Maroon;">
                                Saved Voucher Details
                            </td>
                        </tr>
                        <tr style="font-weight: bold; background-color: #F0F0FF;">
                            <td>
                                Voucher Code
                            </td>
                            <td>
                                Pay To /Receive From
                            </td>
                            <td>
                                Cheque No
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                Complete Date
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="background-color: #F0F0FF;">
                            <td>
                                <asp:Label ID="lblCVC" Font-Size="20px" Font-Bold="true" ForeColor="Maroon" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCPR" runat="server" Width="400px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCChq" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCEdit" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCDetails" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCVcrPrint" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCChqMr" runat="server"></asp:Label>
                            </td>
                            <td>
                                Complete Date: 
                                &nbsp;<asp:TextBox ID="txtCompleteDate" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtCompleteDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_4"
                                    ID="CalendarExtender4" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_4" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td>
                                <asp:Button ID="btnCComplete" ValidationGroup="val" runat="server" Text="Complete"
                                    OnClick="btnCComplete_Click" />
                                <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="Validate"
                                    ValidationGroup="val"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlErrorToSave" Visible="false" runat="server">
                    <asp:Label ID="Label50" Font-Size="20px" Font-Bold="true" ForeColor="Maroon" runat="server">Error: Voucher Not Saved</asp:Label>
                </asp:Panel>
                <asp:HiddenField ID="hdnGridDrAmount" runat="server" />
                <asp:HiddenField ID="hdnGridCrAmount" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnisexpenses" runat="server" />
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
