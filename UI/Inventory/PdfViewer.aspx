<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfViewer.aspx.cs" Inherits="UI.Inventory.PdfViewer" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.717.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function openPdf(sender, args) {
            window.radopen("ftp://erp:erp123@ftp.akij.net/SupplierDoc/1_Cheque-Statement_1250__MICRChequecopy.pdf", "RadWindow1");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <div>
            <p>Frame</p>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                <Windows>
                    <telerik:RadWindow ID="RadWindow1" runat="server" Width="600px" Height="600px">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
            <telerik:RadSplitter ID="Radsplitter6" runat="server" Orientation="Horizontal">
                <telerik:RadPane ID="Radpane11" runat="server" Height="600" Width="850"  >       
                </telerik:RadPane> 
            </telerik:RadSplitter>
        </div>

    </form>
</body>
</html>
