<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Customer.SetLogisVar" Codebehind="SetLogisVar.aspx.cs" %>

<!DOCTYPE html> 
<html >
<head runat="server">
    <title></title>    
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script type="text/javascript">       
        function DDLChangeV(ddlID) {
            document.getElementById("hdnDDLChangedSelectedIndexV").value = document.getElementById(ddlID).options.value;
        }     
     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
        <tr>
        <td>        
        <asp:HiddenField ID="hdnPriceIdV" runat="server" />
        <asp:HiddenField ID="hdnDDLChangedSelectedIndexV" runat="server" />
        <b style="color: Navy;">LOCATION VARIABLE</b>
        <asp:Panel ID="pnlVehicle" runat="server" Visible="true">
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
