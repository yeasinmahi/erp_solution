<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Reports.EmployeeProfile" Codebehind="EmployeeProfile.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html >
<head runat="server">
    <title>::. Employee Profile.::</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
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
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
           
           <table>
           <tr>
                <td> Job Station</td>
                <td>&nbsp</td>
                <td colspan="2">
                     <asp:DropDownList ID="ddlJobStation" runat="server" 
                         DataSourceID="odsJobStation" DataTextField="strJobStationName" 
                         DataValueField="intEmployeeJobStationId">
                        </asp:DropDownList>
                     <asp:ObjectDataSource ID="odsJobStation" runat="server" 
                         SelectMethod="GetAllJobStationByLoginId" TypeName="HR_BLL.Global.JobStation">
                         <SelectParameters>
                             <asp:SessionParameter Name="intLoginId" SessionField="sesUserID" Type="Int32" />
                         </SelectParameters>
                     </asp:ObjectDataSource>&nbsp
                    <%-- <%--<asp:ObjectDataSource ID="odsJobStation" runat="server" 
                         SelectMethod="GetAllJobStationByLoginId" TypeName="HR_BLL.Global.JobStation">
                         <SelectParameters>
                             <asp:SessionParameter Name="intLoginId" SessionField="sesUserID" Type="Int32" />
                         </SelectParameters>
                     </asp:ObjectDataSource>&nbsp--%> --%>


                        <asp:Button ID="btnSubmit" runat="server" Text="Show" 
                        onclick="btnSubmit_Click" />

                </td>
           </tr>
           
           </table>

           

        </div>
    </asp:Panel>
    <div style="height: 100px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>

    <asp:Panel  runat="server" ID="pnlReport" Height="400px" ScrollBars="Auto">
   <%--<div id="divReportViewer" runat="server" >--%>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="16pt"
                    Width="1050px" Height="766px" BackColor="#EEF1FB" EnableTheming="true">
                </rsweb:ReportViewer>
                
           <%-- </div>--%>
            </asp:Panel>
        
    </form>
</body>
</html>
