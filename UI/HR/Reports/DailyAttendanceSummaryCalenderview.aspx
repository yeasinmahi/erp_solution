<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Reports.DailyAttendanceSummaryCalenderview" Codebehind="DailyAttendanceSummaryCalenderview.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Attendance Summary Calenderview</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
                    &nbsp;
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <%--<div id="divMain" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Select Month :" CssClass="label"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMonth" runat="server" Width="80px">
                            <asp:ListItem Text = "January" Value="1"></asp:ListItem>
                            <asp:ListItem Text = "February" Value="2"></asp:ListItem>
                            <asp:ListItem Text = "March" Value="3"></asp:ListItem>
                            <asp:ListItem Text = "April" Value="4"></asp:ListItem>
                            <asp:ListItem Text = "May" Value="5"></asp:ListItem>
                            <asp:ListItem Text = "June" Value="6"></asp:ListItem>
                            <asp:ListItem Text = "July" Value="7"></asp:ListItem>
                            <asp:ListItem Text = "August" Value="8"></asp:ListItem>
                            <asp:ListItem Text = "September" Value="9"></asp:ListItem>
                            <asp:ListItem Text = "October" Value="10"></asp:ListItem>
                            <asp:ListItem Text = "November" Value="11"></asp:ListItem>
                            <asp:ListItem Text = "December" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMonth"
                                ErrorMessage="*" ForeColor="#FF5050" ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Select Year :" CssClass="label"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlYear" runat="server" DataTextField="Text" DataValueField="Value" Width="50px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="ddlYear" ErrorMessage="*" ForeColor="#FF5050" 
                                ValidationGroup="VG"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnShowReport" runat="server" CssClass="button" Text="Show Report"
                                OnClick="btnShowReport_Click" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>--%>
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                        <asp:HiddenField ID="hdnUserID" runat="server" />
                        <asp:HiddenField ID="hdfEmpCode" runat="server" />
                        <asp:HiddenField ID="hdnName" runat="server" />
                        <asp:HiddenField ID="hdnUnitName" runat="server" />
                        <asp:HiddenField ID="hdnDepartmentName" runat="server" />
                        <asp:HiddenField ID="hdnDesignation" runat="server" />
                    </td>
                </tr>
            </table>
            <div id="divReportViewer" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1050px" Height="766px">
                </rsweb:ReportViewer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
