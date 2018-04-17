<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.HR.Benifit.BonusAdviceToBank" Codebehind="BonusAdviceToBank.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Bonus Advice to bank</title>
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div id="divReportViewer" runat="server">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
            Width="100%" Height="100%">
        </rsweb:ReportViewer>
    </div>
        
    </form>
</body>
</html>