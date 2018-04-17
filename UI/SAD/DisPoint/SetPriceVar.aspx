<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.DisPoint.SetPriceVar" Codebehind="SetPriceVar.aspx.cs" %>

<!DOCTYPE html>
<html >
<head runat="server">
    <title></title>   
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <script type="text/javascript">
        function DDLChange(ddlID) {
            document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;
        }    
     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
        <td>     
        <asp:HiddenField ID="hdnPriceId" runat="server" />
        <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
        <b style="color: Navy;">PRICE VARIABLE</b>
        <asp:Panel ID="pnlMain" runat="server" Visible="true">
        </asp:Panel>
        </td>
        </tr>
        <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" /></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
