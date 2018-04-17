<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QRCodePrint.aspx.cs" Inherits="UI.Accounts.PartyPayment.QRCodePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
       function Print() {    
    var dv = document.getElementById("hdnDivision");
    document.getElementById('hdnDivision').style.display = "block";
        dv.getElementsByID
        dv.style.display = "block";
        dv = document.getElementById("btnprint");
        dv.style.display = "none";
        window.print();
        self.close();
    }         
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="hdnDivision" class="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">   
            
        <tr class="tblrowodd"  > 
            <td ><asp:PlaceHolder ID="plhQRCode" runat="server"></asp:PlaceHolder> </td>
        </tr>
        <tr>
        <td style="width:5px;"><a id="btnprint" href="#" style="cursor:pointer" onclick="Print()">Print</a></td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblReffNo" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label14" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Bill Reg No.:"></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label17" runat="server" CssClass="lbl" Text="Bill Reg No."></asp:Label></td>
        </tr>
            
    </table>
    </div>
    </form>
</body>
</html>
