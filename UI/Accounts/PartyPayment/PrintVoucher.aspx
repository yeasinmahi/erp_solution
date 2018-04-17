<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintVoucher.aspx.cs" Inherits="UI.Accounts.PartyPayment.PrintVoucher" %>

<!DOCTYPE html>

<html >
<head id="Head1" runat="server">
    <title>Print Voucher</title>

       <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/printCSS" /> 
       <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <script type="text/javascript">
        function Print() {
            Show();
            window.print();
            self.close();
        }
        function Show() {
            var dv = document.getElementById("print");
            dv.style.display = "block";

            dv = document.getElementById("btn");
            dv.style.display = "none";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="btn" style="text-align:center;">
        <a href="#" onclick="Print()"><b>Print</b></a>
    </div>
    <div  id="print" style="overflow:auto;">
        <table style="width: 100%">
        <tr>
        <td style="text-align: center"  valign="top" width="20%">
            <asp:Image ID="Image2" runat="server" />
        &nbsp;
        </td>
         <td style="text-align: center"  valign="top" width="60%">
        <%--<span class="">--%>
            <asp:Label ID="lblUnitName" CssClass="HeaderStyle" runat="server" Text="Label" 
                 ></asp:Label>
        <%--</span>--%><br />
        <%--<span class="HeaderStyle2">--%>
        <asp:Label ID="lblUnitAddress" CssClass="HeaderStyle2" runat="server" Text="Label"></asp:Label>
        <%--for (int i = 0; i < addressLines.Length; i++)
        {
            headerRow.Append(addressLines[i]);
            <br />

        }--%>

        <%--</span>--%><br />
        <%--<span class="VoucherStyle">
        headerRow.Append(voucherTypeString);
        </span>--%>
        <asp:Label ID="lblVoucherType" CssClass="VoucherStyle" runat="server" Text="Label"></asp:Label>
        </td>
        <td style="text-align:right"  valign="top" width="20%" >
            <asp:Image ID="Image1" runat="server" />
        </td>
        </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <table border="0" style="width: 100%; border:0px solid red">
            <tr>
            <td style="text-align:left"  valign="top" width="20%" ><asp:Image ID="imgprepared" runat="server" />
                <asp:Label ID="lblpreparedby" runat="server" Text=""></asp:Label>
            </td>
            <td style="text-align:left"  valign="top" width="20%" ><asp:Image ID="imgchecked" runat="server" />
                <asp:Label ID="lblCheckedby" runat="server" Text=""></asp:Label>
            </td>
            <td style="text-align:left"  valign="top" width="20%" ><asp:Image ID="imgapproved" runat="server" />
                <asp:Label ID="lblApprovedby" runat="server" Text=""></asp:Label>
            </td>
            <td style="text-align:left"  valign="top" width="20%" ><asp:Image ID="imgfinalapproved" runat="server" />
                <asp:Label ID="lblFinalApproved" runat="server" Text=""></asp:Label>
            </td>
            </tr>
        </table>
    </div>   
    </form>
</body>
</html>

