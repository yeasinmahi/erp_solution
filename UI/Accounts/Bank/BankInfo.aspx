<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1"
    Inherits="UI.Accounts.Bank.BankInfo" Codebehind="BankInfo.aspx.cs" %>


<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Akij Group</title>
    
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />   
  
    <link href="~/Content/CSS/Bank.css" rel="stylesheet" type="text/css" />
 


    <script type="text/javascript">
    function ShowDDL(checkbox)
    {
        //alert('GG');
       if(checkbox.checked)
       {
         document.getElementById('ddlLoanType').style.display = "block";
       }
       else
       {
         document.getElementById('ddlLoanType').style.display = "none";
       }
    }
    
    function ShowHidePreiod(checkbox)
    {
       if(checkbox.checked)
       {
         document.getElementById('lblComPeriod').style.display = "block";
         document.getElementById('txtPeriod').style.display = "block";
       }
       else
       {
         document.getElementById('lblComPeriod').style.display = "none";
         document.getElementById('txtPeriod').style.display = "none";
       }
    }
    
    function ShowDiv(id,shortName)
    {
        document.getElementById(id).style.display = "block";
        if(shortName=='branch')
        {
            var e=document.getElementById('ddlBankName');
            //alert(e);
            var bankName=e.options[e.selectedIndex].text;
           
            document.getElementById('lblBankName').innerHTML=bankName;
        }
        else if(shortName=='account')
                {
                    var loanTypeID= document.getElementById('hdnAccTypeID').value;
                    
                    if(loanTypeID=="1")
                      {
                     
                        document.getElementById('loanTypeDiv').style.display = "block";
                        document.getElementById('loanTypeSH').style.display = "block";
                        document.getElementById('loanTypeLG').style.display = "none";
                      }
                     else if(loanTypeID=="2")
                            {
                                 document.getElementById('loanTypeDiv').style.display = "block";
                                 document.getElementById('loanTypeSH').style.display = "none";
                                 document.getElementById('loanTypeLG').style.display = "block";
                            }
                          else 
                          {
                            document.getElementById('loanTypeDiv').style.display = "none";
                            document.getElementById('loanTypeSH').style.display = "none";
                            document.getElementById('loanTypeLG').style.display = "none";
                          }
                    
                    var bankName,branchName, unitName,accountName;
                     var e=document.getElementById('ddlBankName');
                     if(e.selectedIndex>=0)
                     {
                        bankName=e.options[e.selectedIndex].text;
                     }
                     else
                     {
                         bankName='';
                     }
                     var e2=document.getElementById('ddlBranchName');
                     if(e2.selectedIndex>=0)
                     {
                        branchName=e2.options[e2.selectedIndex].text;
                     }
                     else
                     {
                        branchName='';
                     }
                     var e3=document.getElementById('ddlUnit');
                     if(e3.selectedIndex>=0)
                     {
                       unitName=e3.options[e3.selectedIndex].text;
                     }
                     else
                     {
                        unitName='';
                     }
                     var e4=document.getElementById('ddlAccType');
                     if(e4.selectedIndex>=0)
                     {
                        accountName=e4.options[e4.selectedIndex].text;
                     }
                     else
                     {
                        accountName='';
                     }
                     document.getElementById('lblAccBankName').innerHTML=bankName;
                     document.getElementById('lblUnitName').innerHTML=unitName;
                     document.getElementById('lblAccBranchName').innerHTML=branchName;
                     document.getElementById('lblAccount').innerHTML=accountName;
                     
                }
        else if(shortName=='accType')
                {
                     var e=document.getElementById('ddlBankName');
                     var bankName=e.options[e.selectedIndex].text;
                     document.getElementById('lblBNameForAccType').innerHTML=bankName;
                }        
        
      
    }
    function HideDiv(id,shortName)
    {
        document.getElementById(id).style.display = "none";
        if(shortName=='branch')
        {
            document.getElementById('lblBranchAddNoti').innerHTML='';
        }
        else if(shortName=='bank')
                {
                   document.getElementById('lblBankAddNoti').innerHTML=''; 
                }
             else if(shortName=='account')
                    {
                   
                       document.getElementById('lblAccountAddNoti').innerHTML=''; 
                    }
                  else if(shortName=='accType')
                        {
                           
                         document.getElementById('lblAccTypeNoti').innerHTML='';
                        }  
         
         
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false" AsyncPostBackTimeout="300">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right; ">
                    <table style="width: 100%; ">
                        <tr>
                            <td style="text-align: left; width: 120px;">
                                Unit
                            </td>
                            <td>
                               
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                                    DataValueField="intUnitID" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                Bank
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBankName" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="strBankName" DataValueField="intBankID" AutoPostBack="True" OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveForDDL"
                                    TypeName="BLL.Accounts.Bank.BankInfo"></asp:ObjectDataSource>
                                &nbsp;<a href="#" onclick="ShowDiv('newBankDiv','bank')"> New </a>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                Branch
                            </td>
                            <td>
                            
                                <asp:DropDownList ID="ddlBranchName" runat="server" DataSourceID="ObjectDataSource3"
                                    DataTextField="strBranchName" DataValueField="intBranchID" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveForDDL"
                                    TypeName="BLL.Accounts.Bank.BankBranch">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                &nbsp;<a href="#" onclick="ShowDiv('newBranchDiv','branch')"> New </a>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                Acccount Type
                            </td>
                            <td>
                               
                                <asp:DropDownList ID="ddlAccType" runat="server" DataSourceID="AcctypeDataSource"
                                    DataTextField="strAccType" DataValueField="intAccountTypeID" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="ddlAccType_SelectedIndexChanged" 
                                    ondatabound="ddlAccType_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="AcctypeDataSource" runat="server" SelectMethod="GetAccountTypeData"
                                    TypeName="BLL.Accounts.Bank.BankAccountType">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlBankName" Name="bankID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                &nbsp;<a href="#" onclick="ShowDiv('newAccTypeDiv','accType')"> New </a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 130px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
         
             <div id="newBankDiv" class="divPopUpBank">
                <!-- Header Table -->
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                            ADD Bank info
                        </td>
                        <td style="text-align: right">
                            <a href="#" onclick="HideDiv('newBankDiv','bank')">
                                <img alt="" src="../../Content/images/img/out.png" style="border: 0px;" title="Close" />
                            </a>
                        </td>
                    </tr>
                </table>
                <!-- Data Table -->
                <table style="width: 100%">
                    <tr>
                        <td colspan="4">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblBankAddNoti" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bank Name : &nbsp
                            <asp:TextBox ID="txtBName" ValidationGroup="validateBankNew" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator  ValidationGroup="validateBankNew" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBName"
                                ErrorMessage="Name Cannot Be Empty"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                    Code : &nbsp
                    <asp:TextBox ID="txtBankCode" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtBankCode" ErrorMessage="Code Cannot be Empty"></asp:RequiredFieldValidator>
                </td>
                        <td>
                            Description : &nbsp
                            <asp:TextBox ID="txtBDescription" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnBankAdd" runat="server" Text="Add" ValidationGroup="validateBankNew" OnClick="btnBankAdd_Click" />
                            
                        </td>
                    </tr>
                </table>
            </div>
            <div id="newBranchDiv" class="divPopUpBranch">
                <!-- Header Table -->
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                            ADD Branch info
                        </td>
                        <td style="text-align: right">
                            <a href="#" onclick="HideDiv('newBranchDiv','branch')">
                                <img alt="" src="../../Content/images/img/out.png" style="border: 0px;" title="Close" />
                            </a>
                        </td>
                    </tr>
                </table>
                <!-- Data Table -->
                <table style="width: 100%">
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bank Name :
                            <asp:Label ID="lblBankName" runat="server" Font-Bold="True" ForeColor="#990000"></asp:Label>
                        </td>
                        <td align="right" colspan="3">
                            <asp:Label ID="lblBranchAddNoti" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                    <tr align="right">
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Branch Name : &nbsp
                            <asp:TextBox ID="txtBanchName" ValidationGroup="validateBranchAdd" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="validateBranchAdd" runat="server" ControlToValidate="txtBanchName"
                                ErrorMessage="Name Canot Be Empty"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                    Code : &nbsp
                    <asp:TextBox ID="txtBranchCode" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtBranchCode" ErrorMessage="Code Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>
                        <td>
                            Description : &nbsp
                            <asp:TextBox ID="txtBranchDes" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="txtBranchAdd" ValidationGroup="validateBranchAdd" runat="server" Text="Add" OnClick="txtBranchAdd_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="newAccountDiv" class="divPopUpAccount">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                            ADD Account
                        </td>
                        <td style="text-align: right">
                            <a href="#" onclick="HideDiv('newAccountDiv','account')">
                                <img alt="" src="../../Content/images/img/out.png" style="border: 0px;" title="Close" />
                            </a>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblAccountAddNoti" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <b>Unit</b>
                        </td>
                        <td style="text-align: center">
                            <b>Bank</b>
                        </td>
                        <td style="text-align: center">
                            <b>Branch</b>
                        </td>
                        <td style="text-align: center">
                            <b>Account Type</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Label ID="lblUnitName" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblAccBankName" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblAccBranchName" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                        <td style="text-align: center">
                            <asp:Label ID="lblAccount" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="txtAccNo" ErrorMessage="Number Cannot Be Empty" 
                                ValidationGroup="ValidateAccountAdd"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="txtAccName" ErrorMessage="Name Cannot be Empty" 
                                ValidationGroup="ValidateAccountAdd"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <b>Account Number</b>
                        </td>
                        <td style="text-align: center">
                            <b>Account Name</b>
                        </td>
                        <%--<td style="text-align: center">
                    <b>Account Code</b>
                </td>--%>
                        <td style="text-align: center">
                            
                            <b>Loan Limit</b></td>
                        <td style="text-align: center">
                            <b>Description</b></td>
                    </tr>
                    <tr>
                        <td style="text-align: center" valign="top">
                            <asp:TextBox ID="txtAccNo" ValidationGroup="ValidateAccountAdd" runat="server"></asp:TextBox>
                            <br />
                        </td>
                        <td style="text-align: center" valign="top">
                            <asp:TextBox ID="txtAccName" ValidationGroup="ValidateAccountAdd" runat="server"></asp:TextBox>
                            <br />
                        </td>
                        <%--<td style="text-align: center" valign="top">
                   <asp:TextBox ID="txtAccountCode" runat="server" ></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtAccountCode" ErrorMessage="Code Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>--%>
                        <td style=" vertical-align:top;">
                        
                            <asp:TextBox ID="txtLoan" runat="server">0</asp:TextBox>
                        
                        </td>
                        <td rowspan="3" style="text-align: center" valign="top">
                            <asp:TextBox ID="txtAccDes" runat="server" Height="92px" TextMode="MultiLine" Width="199px"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                   
                    
                    <tr>
                    <td colspan="3" >
                        <div id="loanTypeDiv" style="border:0px" > 
                           <table border="0" cellpadding="0" cellspacing="0" width="100%">
                           <%--<tr>
                           <td colspan="4">
                                Loan Type Details
                           </td>
                           </tr>--%>
                           <tr>
                           <td style="text-align:center; width:33%" valign="top">
                           <b>Loan Amount</b>
                           </td>
                            <td style="text-align: center; width:33%" valign="top">
                           <b>Loan Rate</b>
                           </td>
                            <td style="text-align: center; width:33%" valign="top">
                           <b>Loan Date</b>
                           </td>
                           </tr>
                           <tr>
                           <td style="text-align:left" valign="top">&nbsp&nbsp
                               <asp:TextBox ID="txtLoanAmount" runat="server"></asp:TextBox></td>
                           <td style="text-align: center" valign="top">
                               <asp:TextBox ID="txtLoanRate" runat="server"></asp:TextBox></td>
                           <td style="text-align: center" valign="top">
                               <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                               <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" EnableViewState="true"
                                    Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtDate">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                           </td>
                           </tr>
                           </table>
                        </div>  
                    </td>
                    </tr>
                    <tr>
                    <td colspan="3">
                    <div id="loanTypeSH"> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td  style="vertical-align:middle" align="center" width="50%">
                                <asp:CheckBox ID="ChkCom" runat="server" onClick="ShowHidePreiod(this)" /> Is Commulative &nbsp;&nbsp;
                                
                                
                            </td>
                            <td style="vertical-align:middle" align="right" width="10%">
                            <asp:Label ID="lblComPeriod"  runat="server" Text="Period" style="display:none"></asp:Label>
                            
                            </td>
                            <td style="vertical-align:middle" align="left" width="40%">
                            <asp:TextBox ID="txtPeriod" runat="server" style="display:none"></asp:TextBox>
                            
                            </td>
                            
                        </tr>
                    </table>
                    </div>
                    </td>
                    
                    </tr>
                     <tr>
                    <td colspan="3">
                    <div id="loanTypeLG">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                        <td style="vertical-align:middle" align="center"> <b>Grace Period</b> 
                            <asp:TextBox ID="txtGracePeriod" runat="server"></asp:TextBox>(in Days)</td>
                        <td style="vertical-align:middle" align="center"> <b>Grace Rate</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
                            <asp:TextBox ID="txtGraceRate" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                        <td colspan="3">&nbsp</td>
                        </tr>
                        <tr>
                        <td style="vertical-align:middle" align="center"> <b>Loan Period</b>&nbsp 
                            <asp:TextBox ID="txtLoanPeriod" runat="server">(in Year)</asp:TextBox></td>
                        <td style="vertical-align:middle" align="center"> <b>Intallment Yearly</b> 
                            <asp:TextBox ID="txtInstallmentYearly" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                    </div>
                    </td>
                    
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: right">
                            <asp:Button ID="btnAccountAdd" ValidationGroup="ValidateAccountAdd" runat="server" Text="Add" OnClick="btnAccountAdd_Click" />
                            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        </td>
                    </tr>
                </table>
            </div>
            <div id="newAccTypeDiv" class="divPopAcccountType">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 200px">
                            ADD Account Type
                        </td>
                        <td style="text-align: right">
                            <a href="#" onclick="HideDiv('newAccTypeDiv','accType')">
                                <img alt="" src="../../Content/images/img/out.png" style="border: 0px;" title="Close" />
                            </a>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblAccTypeNoti" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            Bank name : &nbsp
                            <asp:Label ID="lblBNameForAccType" runat="server" ForeColor="#990000"></asp:Label>
                        </td>
                        <td style="text-align: left" colspan="2">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            Account Type :&nbsp
                            <asp:TextBox ID="txtAccType" ValidationGroup="ValidateAccType" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ValidateAccType" runat="server" ControlToValidate="txtAccType"
                                ErrorMessage="Name Cannot be Empty"></asp:RequiredFieldValidator>
                        </td>
                        <td style="text-align: left">
                            Description :&nbsp
                            <asp:TextBox ID="txtDesAcctype" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        
                        <td style="text-align: left">
                            Short Name :&nbsp
                            <asp:TextBox ID="txtAccTypeShortCode" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <table>
                            <tr>
                            <td><asp:CheckBox ID="CheckBox2" runat="server" onclick="ShowDDL(this);"    /> Loan Type<asp:HiddenField 
                                    ID="hdnAccTypeID" runat="server" />
                                </td>
                            <td>
                            <asp:DropDownList ID="ddlLoanType" runat="server" style="display:none" 
                                DataSourceID="ObjectDataSource1" DataTextField="strLoanType" 
                                DataValueField="intLoanTypeID" >
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="GetLoanTypes" TypeName="BLL.Accounts.Bank.LoanType">
                            </asp:ObjectDataSource>
                            </td>
                            </tr>
                            </table>
                            
                            
                        </td>
                    </tr>
                    
                    <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAcctypeAdd" runat="server" ValidationGroup="ValidateAccType" Text="ADD" OnClick="btnAcctypeAdd_Click" />
                    </td>
                    </tr>
                </table>
            </div>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server"   >
        <ContentTemplate >

            <table style="width: 100%;">
                <tr>
                    <td colspan="2">
                        <a href="BankInfoEdit.aspx" class="link">Edit Bank Information</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <a href="#" onclick="ShowDiv('newAccountDiv','account')">
                            <img alt="" src="../../Content/images/icons/Add.ico" style="border: 0px;" title="Add Account" />
                        </a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="intAccountID,strAccountNo" CaptionAlign="Top" Caption="Bank Account Information"
                            DataSourceID="DataSourceBankAccountDetails">
                            <Columns>
                                <asp:TemplateField HeaderText="Account No" SortExpression="strAccountNo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("strAccountNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Name" SortExpression="strAccountName">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("strAccountName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account Type" SortExpression="strAccType">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2444" runat="server" Text='<%# Bind("strAccType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loan Limit" SortExpression="monLoanLimit">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("monLoanLimit") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Eval("monLoanLimit")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("strDescription") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enabled" SortExpression="ysnEnable">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("ysnEnable") %>' Enabled="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="DataSourceBankAccountDetails" runat="server" SelectMethod="GetAccountInfo"
                            TypeName="BLL.Accounts.Bank.BankAccount" UpdateMethod="BankAccountEdit">
                            <UpdateParameters>
                                <asp:Parameter Name="strAccountName" Type="String" />
                                <asp:Parameter Name="strDescription" Type="String" />
                                <asp:Parameter Name="ysnEnable" Type="Boolean" />
                                <asp:Parameter Name="strAccType" Type="String" />
                                <asp:Parameter Name="strAccountNo" Type="String" />                                
                                <asp:Parameter Name="intAccountID" Type="Int32" />                                
                                <asp:Parameter Name="monLoanLimit" Type="Decimal" />                                
                                <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />                              
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranchName" Name="branchID" PropertyName="SelectedValue"
                                    Type="Int32" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
             

           
            <asp:Panel ID="pnlScript" runat="server" Visible="false">
                <script type="text/javascript">
                // bind the C# variable here
                <%# jsString %>        
                </script>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
       
    <%--<td style="text-align: center" valign="top">
                   <asp:TextBox ID="txtAccountCode" runat="server" ></asp:TextBox> 
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtAccountCode" ErrorMessage="Code Cannot Be Empty"></asp:RequiredFieldValidator>
                </td>--%>
        
    </form>
</body>
</html>
