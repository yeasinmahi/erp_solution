<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.HR.PaySlip.ALLPaySlipByUnitAndJobSation" Codebehind="ALLPaySlipByUnitAndJobSation.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Pay Slip By Unit And Jobsation</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("divAllPayslipPrint");
            dv.style.display = "block";

            dv = document.getElementById("btnPrint");
            dv.style.display = "none";
        }   

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="border: Solid 0px #D55500; width: 563px; height: 05px" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print" OnClientClick="Print()" />
                        
                    </td>
                </tr>
            </table>
            <div id="divAllPayslipPrint" runat="server" style="width: 563px">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
