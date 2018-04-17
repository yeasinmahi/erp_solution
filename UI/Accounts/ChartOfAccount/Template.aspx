<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.Accounts.ChartOfAccount.Template" Codebehind="Template.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >

<html >
<head runat="server">
    <title>Welcome to Akij Group</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
    <script src="../../Content/JS/Template.js" type="text/javascript"></script>
    
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" /> 
   <link href="../../Content/CSS/COATemplete.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
    function ShowDiv(parent,addEdit)
    {
        
        if(addEdit==1)
        {
            document.getElementById("btnPopSubmit").value="Update";
            var obj=document.getElementById("frmAddEditInfo");
            obj.action='GetInfo.aspx?parentID='+parent+'&page=coaTemplete';
            obj.submit();
            
        }
        else
        {
            document.getElementById("txtAcc").value='';
            document.getElementById("ChkModule").checked=false;
            document.getElementById("ddlModule").style.display="none";
            document.getElementById("txtChildCodeLength").value='';
            document.getElementById("chkSLed").checked=false;//ysnSLedger;
            document.getElementById("chkLed").checked=false;//ysnLedger;
            document.getElementById("chkTrBal").checked=false;//ysnTrBalance;
            document.getElementById("chkIncSt").checked=false;//ysnIncomeSt;
            document.getElementById("chkBalSht").checked=false;//ysnBalanceSt;
            document.getElementById("btnPopSubmit").value="ADD";
            var dv = document.getElementById("divPopUp");
             dv.style.display = "block";      
              
            
        }
        document.getElementById("hdnParent").value = parent;
        document.getElementById("hdnAddOrEdit").value =addEdit;
        
    }
    
    function GetEditInfo(strAccName,ysnModule,intModuleID,codeLength,ysnSLedger,ysnLedger,ysnTrBalance,ysnIncomeSt,ysnBalanceSt)
    {
        //alert('himadri')
       // alert(ysnModule)
        document.getElementById("txtAcc").value=strAccName;
        
        document.getElementById("ChkModule").checked=Boolean(Number(ysnModule));
        if(Boolean(Number(ysnModule)))
        {
            // show the dropDown
             document.getElementById("ddlModule").style.display="block";
             // make the textbox readOnly/deisable
             document.getElementById("txtAcc").disabled=true;
             
            // document.getElementById("txtAcc").setAttribute("readonly", "true"); 

            
        }
        else
        {
           // hide the dropDown
             document.getElementById("ddlModule").style.display="none";
             document.getElementById("txtAcc").disabled=false;
        }
        
        document.getElementById("txtChildCodeLength").value=codeLength;
        document.getElementById("chkSLed").checked=Boolean(Number(ysnSLedger));//ysnSLedger;
        document.getElementById("chkLed").checked=Boolean(Number(ysnLedger));//ysnLedger;
        document.getElementById("chkTrBal").checked=Boolean(Number(ysnTrBalance));//ysnTrBalance;
        document.getElementById("chkIncSt").checked=Boolean(Number(ysnIncomeSt));//ysnIncomeSt;
        document.getElementById("chkBalSht").checked=Boolean(Number(ysnBalanceSt));//ysnBalanceSt;
        
        
        var dv = document.getElementById("divPopUp");
        dv.style.display = "block"; 
    }
    function ShowDivAct(func,act,hasChild){
        var dv = document.getElementById("divInactive");
        dv.style.display = "block";
        if(act == 'True'){
            document.getElementById("spnAct").innerText = "Do you want to inactive this function from this software?";
            document.getElementById("btnAct").value = "INACTIVATE";
        }
        else{
            document.getElementById("spnAct").innerText = "Do you want to active this function in this software?";
            document.getElementById("btnAct").value = "ACTIVATE";
        }
        
        if(hasChild)document.getElementById("trChild").style.display = "block";
        else document.getElementById("trChild").style.display = "none";
        
        document.getElementById("hdnFunc").value = func;
        document.getElementById("hdnAct").value = act;  
        document.getElementById("chkOnlyThis").checked = true;
              
    }
    function HideDiv(id){
        var dv = document.getElementById(id);
        dv.style.display = "none";
        
        document.getElementById("hdnParent").value = '';
     }
     
     var preID;
          
     function ToggleDivInner(id,id2){
        
        if(preID != undefined && preID != id){
            var dv = document.getElementById(preID);
            dv.style.display = "none";
        }
        
        preID = id;
        
        var dv = document.getElementById(id);
        if(preID == id){            
            if(dv.style.display == "block"){
               dv.style.display = "none";
            }
            else{
                dv.style.display = "block";
            }   
        }
        else{
            dv.style.display = "block";
        }        
    }
    
    function ShowModule(checkbox)
    {
        if(checkbox.checked)
        {
            document.getElementById("ddlModule").style.display="block";
        }
        else
        {
            document.getElementById("ddlModule").style.display="none";
        }
    }
    
    </script>
</head>
<body>
    
    <iframe class="hiddenFrame" height="0" id="addEdit" name="addEdit" src="" width="0">
    </iframe>
    
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
        </div>
    </asp:Panel>
    <div style="height: 100px;">
        <asp:HiddenField ID="hdnFunc" runat="server" />
        <asp:HiddenField ID="hdnAct" runat="server" />
        <asp:HiddenField ID="hdnParent" runat="server" />
        <asp:HiddenField ID="hdnAddOrEdit" runat="server" />
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
     <div>    
    <div id="divInactive" class="divPopUpItem" style="display:none">
    <table width="100%">
            <tr>
                <td style="height:50px; vertical-align:top;" align="right">
                    <input id="Button1" type="button" value="X" onclick="HideDiv('divInactive')" />
                </td>
                <td align="right">                 
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height:100px; vertical-align:middle;" align="center">
                    <span id="spnAct"></span>
                </td>
            </tr>
            <tr id="trChild">
                <td colspan="2" style="height:100px; vertical-align:middle;" align="center">
                    Uncheck this if you want to make action on all of childs.<br/>
                    <asp:CheckBox ID="chkOnlyThis" runat="server" Checked="true"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAct" runat="server" Text="" onclick="btnAct_Click"/>
                </td>
            </tr>
    </table> 
    </div>
    <div id="divPopUp" class="divPopUpItem" style="display:none" >        
        <table style="width: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    &nbsp;
                    <input id="btnClosePopDiv" type="button" value="X" onclick="HideDiv('divPopUp')" /></td>
            </tr>
            <tr id="trText">
                <td class="style1">
                    Account Name
                </td>
                <td class="style1">
                    <asp:TextBox ID="txtAcc" runat="server"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <span id="msgBoxClass" style="font-size:9px; font-weight:bold;"></span></td>
            </tr>
            <tr>
                <td>
                    Module Name &nbsp <asp:CheckBox ID="ChkModule" runat="server" Checked="false" onclick="ShowModule(this);"   />
                </td>
                <td>
                    
                    <asp:DropDownList ID="ddlModule" runat="server" 
                        DataSourceID="ObjectDataSource1" DataTextField="strModuleName" 
                        DataValueField="intModuleID" CssClass="ddlStyle" >
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        SelectMethod="GetModuleData" TypeName="BLL.Accounts.Module.Module">
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Child Code Length
                </td>
                <td>
                    <asp:TextBox ID="txtChildCodeLength" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                   <b> Enabled Feature</b></td>
            </tr>
            <tr>
                <td>
                    Sub Ledgure</td>
                <td>
                    <asp:CheckBox ID="chkSLed" runat="server" Checked="false" /></td>
            </tr>
            <tr>
                <td>
                    Ledgure</td>
                <td>
                    <asp:CheckBox ID="chkLed" runat="server" Checked="false" /></td>
            </tr>
            <tr >
                <td>
                    Trails Balance</td>
                <td>
                    <asp:CheckBox ID="chkTrBal" runat="server" Checked="false" /></td>
            </tr>
            <tr >
                <td>
                    Income Statement</td>
                <td>
                    <asp:CheckBox ID="chkIncSt" runat="server" Checked="false" /></td>
            </tr>
             <tr >
                <td>
                    Balance Sheet</td>
                <td>
                    <asp:CheckBox ID="chkBalSht" runat="server" Checked="false" /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="right">
                    <asp:Button ID="btnPopSubmit" runat="server" Text="Add"  
                        onclick="btnPopSubmit_Click"/>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="Panel1" runat="server">
    <%# sb.ToString() %>
    </asp:Panel>
    </div>    
    </form>
    
    
    <form name="frmAddEditInfo" action="" id="frmAddEditInfo" method="post" target="addEdit" style="display: none">
    </form>
    
</body>
</html>
