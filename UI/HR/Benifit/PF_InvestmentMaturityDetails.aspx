<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Benifit.PF_InvestmentMaturityDetails" Codebehind="PF_InvestmentMaturityDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Investment Maturity Details</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function GotoNextFocus(ControlName, e) {
            var unicode = e.keyCode ? e.keyCode : e.charCode
            if (unicode == 13) {
                var control = document.getElementById(ControlName);
                if (control != null) {
                    control.focus();
                    window.event.returnValue = false
                }
            }
        }
function ReloadParent() {
            window.opener.location = window.opener.location;
            self.close();
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 60px; float: right;
                    text-align: center; font-size: 16px">
                    <p>
                        <b>Investment Maturity Details</b></p>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                            <asp:Label ID="Label1" runat="server" CssClass="label" Text="Investment Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInvestmentDuration" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtInvestmentDuration"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                            <asp:Label ID="Label2" runat="server" CssClass="label" Text="Interest Rate"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInterestRate" runat="server" CssClass="txt" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtInterestRate"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                            <asp:Label ID="Label3" runat="server" CssClass="label" Text="Actual Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtActualDuration" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtActualDuration"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <ajaxToolkit:FilteredTextBoxExtender ID="ftbActualDuration" runat="server" TargetControlID="txtActualDuration"
                                FilterMode="ValidChars" FilterType="Custom , Numbers" ValidChars="1234567890.">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                            <asp:Label ID="Label4" runat="server" CssClass="label" Text="Actual Rate"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtActualRate" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtActualRate"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="txtActualRate" FilterMode="ValidChars" FilterType="Custom , Numbers"
                                ValidChars="1234567890.">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                            <asp:Label ID="Label5" runat="server" CssClass="label" Text="Actual Profit"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtActualProfit" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                ForeColor="Red" ControlToValidate="txtActualProfit"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                TargetControlID="txtActualProfit" FilterMode="ValidChars" FilterType="Custom , Numbers"
                                ValidChars="1234567890.">
                            </ajaxToolkit:FilteredTextBoxExtender>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;
                        </td>
                        <td style="width: 115px">
                        </td>
                        <td>
                            <asp:Button ID="btnMaturedInvestment" CssClass="button" runat="server" Text="Matured"
                                OnClick="btnMaturedInvestment_Click" />
                        </td>
                        <td>
                        </td>
                        <td>
                        <asp:HiddenField ID="hdnSoftwareLoginId" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 35px">
                            &nbsp;</td>
                        <td style="width: 115px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:HiddenField ID="hdnInvestmentID" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
