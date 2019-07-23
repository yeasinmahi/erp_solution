<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Banking.Report.DepositSlip" Codebehind="DepositSlip.aspx.cs" %>



<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Welcome to Akij Group</title>

         <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 

    <script type="text/javascript">
        function ShowPopUp(url,divID,val){          
        
        var count = document.getElementById("txtSolo").value;        
        if(count==''){
            alert('Please enter starting number');
        }
        else if(isNaN(count)){
            alert('Please enter a number');
        }
        else
        {
            var i;            
            if(document.getElementById("rdoAll").checked){
                i = parseInt(count) + val;
            }
            else{
                i = parseInt(count);
            }
            document.getElementById("spn0"+val).innerText = i;
            document.getElementById("spn1"+val).innerText = i;
            
            i = i+1;
            val = val+1;
            
            if(document.getElementById("spn0"+val)!= null){
                document.getElementById("spn0"+val).innerText = i;
                document.getElementById("spn1"+val).innerText = i;
            }
            newwindow = window.open('','sub','toolbar=0,height=1,width=1,top=0,left=0');
            newwindow.document.write("<body style=\"font-family:Verdana; font-size:12px;\">");
            newwindow.document.write(document.getElementById(divID).innerHTML);
            newwindow.document.write("</body>");
            newwindow.document.close();
            newwindow.print();
            newwindow.close();
            
        }
        /*
        var inPut = prompt("Enter CDZ serial starting number", "");
        if (inPut == null || inPut == ""){
            alert("Please enter starting number");            
        }
        else{
            if(isNaN(inPut)){
                alert("Please enter a numeric value.");
            }
            else
            {
            url = url+'?'
                +'unt='+document.getElementById("ddlUnit").value
                +'&frm='+document.getElementById("txtFrom").value
                +'&to='+document.getElementById("txtTo").value
                +'&bnkID='+document.getElementById("ddlBank").value
                +'&bnk='+document.getElementById("ddlBank").options[document.getElementById("ddlBank").selectedIndex].text
                +'&brnID='+document.getElementById("ddlBranch").value
                +'&brn='+document.getElementById("ddlBranch").options[document.getElementById("ddlBranch").selectedIndex].innerText
                +'&accID='+document.getElementById("ddlAccount").value
                +'&acc='+document.getElementById("ddlAccount").options[document.getElementById("ddlAccount").selectedIndex].innerText
                +'&isChq='+document.getElementById("chkChq").checked
                +'&isDD='+document.getElementById("chkDD").checked
                +'&isPO='+document.getElementById("chkPO").checked
                +'&isDS='+document.getElementById("chkDS").checked
                +'&isAdv='+document.getElementById("chkAdv").checked
                +'&isAdj='+document.getElementById("chkAdj").checked
                +'&sl='+inPut
                ;
                
                newwindow = window.open(url,'sub');
                if (window.focus) {newwindow.focus()}
            }
         }*/
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
	                <asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
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
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top; z-index:1; position:absolute;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
        </div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
            <table>
                <tr>
                    <td align="left" class="PageHeader">
                        Deposit Slip
                    </td>
                    <td align="left">
                        From
                        <asp:TextBox ID="txtFrom" runat="server" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender1" runat="server" EnableViewState="true"
                            Format="dd/MM/yyyy" PopupButtonID="imgCal_1" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td>
                        To
                        <asp:TextBox ID="txtTo" runat="server" autocomplete="off"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" ID="CalendarExtender2" runat="server" EnableViewState="true"
                            Format="dd/MM/yyyy" PopupButtonID="imgCal_2" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                        <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td>
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
                <tr style="height: 35px;">
                    <td align="right" colspan="4">
                        <asp:CheckBox ID="chkChq" runat="server" Text="Cheque" Checked="true" ForeColor="Green" />
                        &nbsp;&nbsp;<asp:CheckBox ID="chkDD" runat="server" Text="Demand Draft" Checked="true" />
                        &nbsp;&nbsp;<asp:CheckBox ID="chkPO" runat="server" Text="Pay Order" Checked="true" />
                        &nbsp;&nbsp;<asp:CheckBox ID="chkDS" runat="server" Text="Cash Deposit Slip" />
                        &nbsp;&nbsp;<asp:CheckBox ID="chkAdv" runat="server" Text="Advice" />
                        &nbsp;&nbsp;<asp:CheckBox ID="chkAdj" runat="server" Text="Adjustment" />
                    </td>
                </tr>
                <tr style="height: 35px;">
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
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetActiveForDDLWithAll"
                            TypeName="BLL.Accounts.Bank.BankBranch" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBank" Name="bankID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        A/C No.
                        <asp:DropDownList ID="ddlAccount" runat="server" DataSourceID="ObjectDataSource1"
                            DataTextField="strAccountNoOriginal" DataValueField="intAccountID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveForDDLByBranchWithAll"
                            TypeName="BLL.Accounts.Bank.BankAccount">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBranch" Name="branchID" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Consolidated Slip" OnClick="btnSubmit_Click" />
                       <%-- <asp:Button ID="btnSolo" runat="server" OnClick="btnSolo_Click" Text="Solo Slip" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div style="height: 120px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>
    
        <asp:Panel ID="pnlSolo" runat="server" EnableViewState="false" Visible="false" HorizontalAlign="Center">
            <br />
            <br />
            <asp:RadioButton ID="rdoAll" runat="server" Text="All" Checked="true" GroupName="rdo" />
            <asp:RadioButton ID="rdoThis" runat="server" Text="Only This Page" GroupName="rdo" />
            <br />
            <br />
            Starting CDZ Number
            <asp:TextBox ID="txtSolo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblSolo" runat="server"></asp:Label>
            <div style="display: none; height: 5px;">
                <asp:Label ID="lblSoloDiv" runat="server"></asp:Label>
            </div>
        </asp:Panel>
      
    <div id="divReportViewer" runat="server" >
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="100%" Height="100%" BackColor="#EEF1FB" EnableTheming="true">
                </rsweb:ReportViewer>
                
            </div>
       
    </form>
</body>
</html>
