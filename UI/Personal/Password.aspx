<%@ Page Language="C#"  AutoEventWireup="true" Inherits="UI.Personal.Personal_Password" Codebehind="Password.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Password Change</title>

     <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript">
    function ValidateField(sender, args)
    {        
        if(document.getElementById("txtOld").value == '')
        {
            alert('Previous Password field could not be blank');
            args.IsValid = false;
        }
        else if(document.getElementById("txtNew").value == '')
        {
            alert('New Password field could not be blank');
            args.IsValid = false;
        }
        else if(document.getElementById("txtConf").value == '')
        {
            alert('Confirm Password field could not be blank');
            args.IsValid = false;
        }
        else if(document.getElementById("txtConf").value != document.getElementById("txtNew").value)
        {
            alert('New & Confirm Password must be same');
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    </script>
</head>
<body>
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
        </div>
        <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
            runat="server">
        </cc1:AlwaysVisibleControlExtender>
        
        <table width="100%" style="color:#A0A0A0;">
            <tr>
                <th colspan="2" style="color:#000000; font-size:15px;">
                Password Change
                </th>
            </tr>
            <tr>
                <td align="right">
                    Old Password</td>
                <td>
                    <asp:TextBox ID="txtOld" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    New Password</td>
                <td>
                    <asp:TextBox ID="txtNew" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="height: 21px" align="right">
                    Confirm Password</td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtConf" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Change Password" OnClick="btnSubmit_Click" ValidationGroup="submit" />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateField"
                        ValidationGroup="submit"></asp:CustomValidator></td>
            </tr>           
        </table>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <script type="text/javascript">            
                alert('<%# succ %>');            
            </script>
        </asp:Panel>
    </form>

</body>
</html>
