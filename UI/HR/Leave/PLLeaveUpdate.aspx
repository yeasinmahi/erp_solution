<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PLLeaveUpdate.aspx.cs" Inherits="UI.HR.Leave.PLLeaveUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
</head>
<body>
    <form id="frmPLLeaveUpdate" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server">
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

                <div class="leaveApplication_container">
                    <div class="tabs_container">
                        <center>PL Leave Date Update</center>
                        <hr />
                        <div>
                            <asp:Label runat="server" ID="lblApplicationId" Text="Application ID : "></asp:Label>
                            <asp:Label runat="server" ID="txtApplicationId" ></asp:Label>
                        </div>
                        <fieldset>
                            <legend>Old PL Leave Date</legend>
                            <table>
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="From Date : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOldPLFromDate" runat="server" CssClass="txtBox" ReadOnly="true" style="height:27px;border-radius:5px;font-size:11pt;padding-left:5px"></asp:TextBox>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="To Date : "></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOldPLToDate" runat="server" CssClass="txtBox" ReadOnly="true" style="height:27px;border-radius:5px;font-size:11pt;padding-left:5px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <fieldset style="margin-top:2%">
                            <legend>New PL Leave Date</legend>
                            <table>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="From Date : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewFromDate" runat="server" CssClass="txtBox" style="height:27px;border-radius:5px;font-size:11pt;padding-left:5px"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" TargetControlID="txtNewFromDate" Format="dd/MM/yyyy" />
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label7" CssClass="lbl" runat="server" Text="To Date : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewToDate" runat="server" CssClass="txtBox" style="height:27px;border-radius:5px;font-size:11pt;padding-left:5px"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" TargetControlID="txtNewToDate" Format="dd/MM/yyyy" />
                                </td>
                            </table>
                        </fieldset>
                    </div>
                    <div style="margin-top:5px;text-align:right">
                        <asp:HiddenField runat="server" ID="hfApplicationId" />
                        <asp:HiddenField runat="server" ID="hfEnroll" />
                        <asp:HiddenField runat="server" ID="HiddenField2" />
                        <asp:Button runat="server" ID="btnChangePLLeave" CssClass="btn btn-primary" style="height:30px;background:#0094ff;font-weight:bold; color:#ffffff"  Text="Change PL Date" OnClick="btnChangePLLeave_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
