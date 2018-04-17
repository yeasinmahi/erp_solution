<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.Reports.JobstationwiseCurrentShiftDetails" Codebehind="JobstationwiseCurrentShiftDetails.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Monthwise Salary Info</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Unit :" CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" Width="250px" AutoPostBack="True" DataSourceID="odsUnit"
                                DataTextField="strUnit" DataValueField="intUnitID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits"
                                    TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters><%-- DefaultValue="3587" --%>
                                        <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Job Station :" CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJobStation" runat="server" Width="250px" DataSourceID="odsJobstationByUnit"
                                    DataTextField="Text" DataValueField="Value">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="odsJobstationByUnit" runat="server" SelectMethod="GetJobStationIdAndNameByUnitID"
                                    TypeName="HR_BLL.Global.JobStation" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <%--DefaultValue="" --%>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:SessionParameter Name="intLoginId" SessionField="sesUserID" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Date :" CssClass="label"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CE1" runat="server" TargetControlID="txtDate">
                                </ajaxToolkit:CalendarExtender>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnShowReport" runat="server" CssClass="button" Text="Show Report"
                                    OnClick="btnShowReport_Click" />
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnUserId" runat="server" />
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
            <div id="divReportViewer" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="1050px" Height="766px">
                </rsweb:ReportViewer>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShowReport" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
