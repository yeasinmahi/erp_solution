<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1" Inherits="UI.Accounts.ChartOfAccount.ChartOfAccounts" Codebehind="ChartOfAccounts.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html  PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" >

<html>
<head runat="server">
    <title>Untitled Page</title>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>  
    <script type="text/javascript" src="animatedcollapse.js" ></script>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  

    <script type="text/jscript">

        animatedcollapse.addDiv('divPopUp', 'height=290px')
         animatedcollapse.init()    
           var curHeight= 4;
            var dv;
        function ShowDiv(parent,addEdit)
            {
            alert('himadri8888');
            /* var dv = document.getElementById("divPopUp");
              
            alert(tempX);
            alert(dv.offsetTop);  */
            
            if(addEdit==1)
            {
            
                alert('himadri');
                  document.getElementById("btnPopSubmit").value="Update";
                   var dv2 = document.getElementById("divPopUp");
                    dv2.style.display = "block";
                    dv2.style.top = window.event.clientY+document.documentElement.scrollTop+10;
	                dv2.style.left = window.event.clientX+ document.documentElement.scrollLeft;
                    var obj=document.getElementById('frmAddEditInfo');
                    obj.action='GetInfo.aspx?parentID='+parent+'&page=coaByUnit';
                    obj.submit();
            }
            else //add
            {
                alert('himadri777');
                document.getElementById("txtAcc").value='';
                document.getElementById("txtAcc").disabled=false;
                document.getElementById("txtCB").value='';
                document.getElementById("txtCB").disabled=false;
                document.getElementById("ChkModule").checked=false;
                document.getElementById("ddlModule").style.display="none";
                document.getElementById("txtChildCodeLength").value='';
//                document.getElementById("chkSLed").checked=false;//ysnSLedger;
//                document.getElementById("chkLed").checked=false;//ysnLedger;
               // document.getElementById("rdlLedgerSubLedger_0").checked=true;
                document.getElementById("chkLed").style.display="none";
                document.getElementById("ledgerLevel").style.display="none";
                document.getElementById("chkTrBal").style.display="none"//ysnTrBalance;
                document.getElementById("tbLevel").style.display="none"
                document.getElementById("chkIncSt").checked=false;//ysnIncomeSt;
                document.getElementById("chkBalSht").checked=false;//ysnBalanceSt;
                document.getElementById("btnPopSubmit").value="ADD";
                 dv = document.getElementById("divPopUp");
                //var clickedBtn=document.getElementById('btnAdd'+parent);
                //alert(clickedBtn.offsetHeight)
                // animatedcollapse.show('divPopUp');
                // dv.style.height="4px";
                  
                 dv.style.display = "block"; 
                  dv.style.top = window.event.clientY+document.documentElement.scrollTop+10;
	            dv.style.left = window.event.clientX+ document.documentElement.scrollLeft;
	            // AdjustSize();
                /* for(var i=0;i<75;i++)
                 {
                    
                   // curHeight=(curHeight+4);
                   // dv.style.height=curHeight+'px';
                    setTimeout('AdjustSize()',4000);
                 }*/
               
	           
               
                 
            } 
            
             document.getElementById("hdnParent").value = parent;
             document.getElementById("hdnAddOrEdit").value =addEdit;
        }
        
        function  AdjustSize()
        {
                    curHeight=(curHeight+4);
                    dv.style.height=curHeight+'px';
                    if(curHeight>=300)
                    {
                        curHeight=4;
                    }
                    else
                    {
                    setTimeout('AdjustSize()',1);
                    }
        }
        
        function GetEditInfo(strAccName,ysnModule,intModuleID,codeLength,ysnSLedger,ysnLedger,ysnTrBalance,ysnIncomeSt,ysnBalanceSt,currentBalance)
    {
        //alert('himadri')
       // alert(ysnModule)
        document.getElementById("txtAcc").value=strAccName;
        document.getElementById("chkTrBal").style.display="none"//ysnTrBalance;
                document.getElementById("tbLevel").style.display="none"
         document.getElementById("txtCB").value=currentBalance;
        document.getElementById("txtCB").disabled=true;
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
        /*document.getElementById("chkSLed").checked=Boolean(Number(ysnSLedger));//ysnSLedger;
        document.getElementById("chkLed").checked=Boolean(Number(ysnLedger));//ysnLedger;
        */
        if(Boolean(Number(ysnLedger))) // radio button val 1
        {
            
            document.getElementById("chkLed").checked=true;
            document.getElementById("chkLed").disabled=true;
        }
        else
        {
             document.getElementById("chkLed").checked=false;
            document.getElementById("chkLed").disabled=false;
        }
//        if(Boolean(Number(ysnSLedger))) //radio button val 2
//        {
//            document.getElementById("rdlLedgerSubLedger_1").checked=true;
//        }
//        else
//        {
//            document.getElementById("rdlLedgerSubLedger_1").checked=false;
//        }
        document.getElementById("chkTrBal").checked=Boolean(Number(ysnTrBalance));//ysnTrBalance;
        document.getElementById("chkIncSt").checked=Boolean(Number(ysnIncomeSt));//ysnIncomeSt;
        document.getElementById("chkBalSht").checked=Boolean(Number(ysnBalanceSt));//ysnBalanceSt;
        
        
       
      
        
    }
        
        function ShowDivAct(func,act)
        {
            var dv = document.getElementById("divInactive");
            dv.style.top = "10%";
            dv.style.display = "block";
            if(act == 'True')
            {
                document.getElementById("spnAct").innerText = "Do you want to inactive this function from this software?";
                document.getElementById("btnAct").value = "ACTIVATE";
            }
        else
            {
                document.getElementById("spnAct").innerText = "Do you want to active this function in this software?";
                document.getElementById("btnAct").value = "INACTIVATE";
            }
         
         document.getElementById("hdnYsnEnable").value=act;
         document.getElementById("hdnParent").value = func
            
        }
        
        function HideDiv(id)
        {
        var dv = document.getElementById(id);
        dv.style.display = "none";
        
        //document.getElementById("hdnParent").value = '';
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
     <iframe  height="0" id="addEdit" name="addEdit" src="" width="0">
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
            <br />
            <br />
            &nbsp &nbsp
            Unit <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" 
                DataSourceID="UnitObjectDataSource" DataTextField="strUnit" 
                DataValueField="intUnitID" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="UnitObjectDataSource" runat="server" 
                SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                <SelectParameters>
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </asp:Panel>
    <div style="height: 100px;">
      
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
    
    
               
    
    
    <div>
    <asp:UpdatePanel ID="updatePannel3" runat="server" UpdateMode="Always">
            <ContentTemplate>
            
                 <asp:TreeView ID="treeViewCOA" runat="server" NodeStyle-Height="5px" 
                                onselectednodechanged="treeViewCOA_SelectedNodeChanged" 
                     ExpandDepth="1">
                     <NodeStyle Height="5px" />
                </asp:TreeView> 
               
        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
          
           <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate> --%>     
                
                 <div id="divInactive" class="divPopUpItem" style="display:none" >
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
                    Uncheck this if you want to make action on all of childs.<br>
                    <br>
                    <br></br>
                    <br></br>
                    <br>
                    <asp:CheckBox ID="chkOnlyThis" runat="server" Checked="true" />
                    <br></br>
                    </br>
                    </br>
                    </td>
            </tr>
                        <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnAct" runat="server" Text="" onclick="btnAct_Click"/>
                </td>
            </tr>
                    </table> 
                </div>
                
               
                <div id="divPopUp" class="divPopUpItem" style="display:none "   >   
                
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>--%>
          
                <span>
                <table  style="width: 100%" class="tablekk">
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
                    <tr style="visibility:hidden">
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
                <td>
                    Current Balance</td>
                <td>
                    <asp:TextBox ID="txtCB" runat="server"></asp:TextBox>  
               </td>
            </tr>
                    <tr>
                        <td colspan="2">
                           <b> Enabled Feature</b></td>
                    </tr>
                    <tr>
                <td>
                    <asp:Label ID="ledgerLevel" runat="server" Text="Ledger"></asp:Label>   
                    </td>
                <td>
                    <%--<asp:RadioButtonList ID="rdlLedgerSubLedger" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Ledger" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="SubLedger" Value="2"></asp:ListItem> 
                    </asp:RadioButtonList>--%>
                    <asp:CheckBox ID="chkLed" runat="server" Checked="false" />
                </td>
            </tr>
                 <%--   <tr>
                <td>
                    Ledgure</td>
                <td>
                    <asp:CheckBox ID="chkLed" runat="server" Checked="false" /></td>
            </tr>--%>
                    <tr >
                <td>
                    <asp:Label ID="tbLevel" runat="server" Text="Trails Balance"></asp:Label></td>
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
                </span>
                
                  <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
                </div>
                
           
    </ContentTemplate>
        </asp:UpdatePanel>     
                
    </div>
    <asp:HiddenField ID="hdnParent" runat="server" /> 
    <asp:HiddenField ID="hdnAddOrEdit" runat="server" />
     <asp:HiddenField ID="hdnYsnEnable" runat="server" />
    </form>
    
    <form name="frmAddEditInfo" action="" id="frmAddEditInfo" method="post" target="addEdit" style="display: none">
    </form>
</body>
</html>
