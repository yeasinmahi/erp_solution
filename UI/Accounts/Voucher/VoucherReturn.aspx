<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.Accounts.Voucher.VoucherReturn" Codebehind="VoucherReturn.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>




<html>
<head runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <script type="text/javascript">
    function Validate(sender, args){
        if(document.getElementById("txtRemark").value == ''){
            alert('Please enter remark');
            args.IsValid = false;
            isProceed = false;
        }
        else if( document.getElementById("txtPass").value==''){
            alert('Please enter your password');
            args.IsValid = false;
            isProceed = false;
        }
        else if(!confirm('Do you want to continue?')){
            args.IsValid = false;
            isProceed = false;
        }
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
	            <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	            <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	            <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	            <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	            <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
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
                <table width="400" align="center">
                        <tr>
                            <td align="right">
                                <img src="~/Content/images/img/Delete.png" />
                            </td>
                            <td align="center" class="PageHeader">
                                Voucher Rollback After Ledger Entry
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
            
            <table width="400px" align="center">
            <tr>
                <td>Unit</td>     
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit"
                        DataValueField="intUnitID">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td> 
                <td></td>    
            </tr>
            <tr>
                <td>Voucher Code</td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnGo" runat="server" Text="Search" onclick="btnGo_Click" /></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblResult" ForeColor="Red" runat="server" Text=""></asp:Label></td>
            </tr>
                <tr>
                    <td>Remarks</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </td>
                </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="txtPass" Enabled="false" TextMode="Password" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnAction" ValidationGroup="val"  Enabled="false" runat="server" Text="Rollback Voucher" 
                        onclick="btnAction_Click" />
                    <asp:HiddenField ID="hdnID" runat="server" />
                    <asp:HiddenField ID="hdnType" runat="server" />
                </td>
            </tr>
            </table>            
      </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="Validate"
        ValidationGroup="val"></asp:CustomValidator>
     
    </form>
</body>
</html>
