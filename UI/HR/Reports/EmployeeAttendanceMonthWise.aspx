<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Reports.EmployeeAttendanceMonthWise" Codebehind="EmployeeAttendanceMonthWise.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>Single Employee Attendance MonthWise</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" >
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>

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
                <div id="divControl" class="divPopUp2" style="width: 100%; height:auto; float: right;"> 
                <table style="width:auto;">
                <tr><td style="width: 150px; text-align: right;"><asp:Label runat="server" Text="Employee-Name :"></asp:Label></td>
                <td><asp:TextBox ID="txtEmployee" runat="server" Width="300px" BorderStyle="None" BackColor="White" ReadOnly="True" ForeColor="Black"></asp:TextBox></td>
                </tr>
                <tr><td style="text-align: right;"><asp:Label runat="server" Text="Job-Station :"></asp:Label></td>
                <td><asp:TextBox ID="txtJobStation" runat="server" Width="300px" BorderStyle="None" BackColor="White" ReadOnly="True" ForeColor="Black"></asp:TextBox></td>
                </tr>
                <tr><td style="text-align: right;" colspan="2">
                <asp:Button ID="btnShow" runat="server" Text="View-Attendance" Font-Bold="True" 
                        onclick="btnShow_Click"/>
                </td>
                </tr>
                 </table>
                </div>
            </asp:Panel>
            <div style="height: 90px;"></div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <%--=========================================Start My Code From Here======================================================--%>
            <div id="div1" runat="server">
                <rsweb:ReportViewer ID="MonthWiseAttendanceReportViewer" runat="server" Font-Names="Verdana"
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                    WaitMessageFont-Size="14pt" Width="1000px" Height="750px">
                </rsweb:ReportViewer>
            </div>
            <%--=========================================End My Code From Here========================================================--%>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
