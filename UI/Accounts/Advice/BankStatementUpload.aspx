<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankStatementUpload.aspx.cs" Inherits="UI.Accounts.Advice.BankStatementUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
   
</head>
<body>
    <form id="frmexcelexport" runat="server">
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnPOAmount" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />
        <div class="divbody" style="padding-right:10px;">
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td style="text-align:right"><asp:Label ID="lblUnit" runat="server" CssClass="label" Text="Unit :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlUnit" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList></td>
            <td style="text-align:right"><asp:Label ID="lblProgramType" runat="server" CssClass="label" Text="Program Type :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlProgramType" runat="server" CssClass="ddList" Width="225px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlProgramType_SelectedIndexChanged" ></asp:DropDownList></td>
            </tr>
            <tr>
            <td style="text-align:right"><asp:Label ID="lblSupplier" runat="server" CssClass="label" Text="Supplier :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlSupplier" runat="server" CssClass="ddList" Width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right"><asp:Label ID="lblImport" runat="server" CssClass="label" Text="Import Excel File:"></asp:Label></td>
                <td style="text-align:left"><asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload></td>
                <td><asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" style="height: 26px" /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvExcelFile" runat="server"  CellPadding="4" ForeColor="#333333" GridLines="None">   
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />   
                    <EditRowStyle BackColor="#999999" />   
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />   
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />   
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />   
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />   
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />   
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />   
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />   
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />   
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />   
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    
    </form>
</body>
</html>
