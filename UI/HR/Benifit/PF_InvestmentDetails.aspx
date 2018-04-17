<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Benifit.PF_InvestmentDetails" Codebehind="PF_InvestmentDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Provident Fund Investment Details</title>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>Investment</b>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <asp:Panel ID="panDetails" runat="server" ScrollBars="None" Width="305px" Height="231px">
                <div>
                    <table style="border: 2px solid black">
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Bank Name"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlNankName" runat="server" CssClass="DropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNankName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="VG"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Brance Name" CssClass="label"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="DropDown">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                    ControlToValidate="ddlBranchName" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Capital" CssClass="label"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtInvestmentAmount" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                    ControlToValidate="txtInvestmentAmount" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Interest Rate" CssClass="label"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtInterestRate" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                    ControlToValidate="txtInterestRate" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Duration" CssClass="label"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDuration" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                    ControlToValidate="txtDuration" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Effected Date" CssClass="label"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtEffectedDate" runat="server" Width="100px" CssClass="txt"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CDX" runat="server" TargetControlID="txtEffectedDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                    ControlToValidate="txtEffectedDate" ValidationGroup="VG" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEffectedDate"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9m]{1,2}/[0-9d]{1,2}/[0-9y]{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="2">
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 55px">
                                <asp:Button ID="btnInvest" runat="server" Width="55px" CssClass="button" Text="Invest"
                                    OnClick="btnInvest_Click" />
                            </td>
                            <td style="width: 105px">
                                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
