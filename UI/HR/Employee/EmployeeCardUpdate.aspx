<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCardUpdate.aspx.cs" Inherits="UI.HR.Employee.EmployeeCardUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Card Update</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


</head>
<body>
    <form id="frmEmpCard" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />

                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        Employee Card Update<hr />
                    </div>
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEnroll" runat="server" CssClass="lbl" Text="Enroll"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEnroll" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblEmpCard" runat="server" CssClass="lbl" Text="Employee Card"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEmpCard" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">
                                <asp:Button ID="btnUpdate" runat="server" class="myButtonNew" Text="Update" Width="100px" OnClick="btnUpdate_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblShowEnroll" runat="server" CssClass="lbl" Text="Enroll"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtShowEnroll" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">Card No</td>
                            <td>
                                <asp:TextBox ID="txtCardNo" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblCode" runat="server" Text="Code No." CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtCodeNo" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                           <%-- <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>--%>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">
                                <asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Width="100px" OnClick="btnShow_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">
                                <%-- <asp:Button ID="btnprint" runat="server" class="myButtonGrey" Text="Print" Width="100px" OnClientClick="PrintPage()" />
                                &nbsp&nbsp
                                <asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click" />
                                &nbsp&nbsp
                                <asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submnit" OnClick="btnSubmit_Click" />--%>
                            </td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
