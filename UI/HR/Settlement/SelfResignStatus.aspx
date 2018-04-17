<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfResignStatus.aspx.cs" Inherits="UI.HR.Settlement.SelfResignStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
</head>
<body>
   <form id="frminformation" runat="server">
     <asp:Panel ID="pnlselfResignstatus1" runat="server"><%# strselfresignstatus1 %></asp:Panel><br /> 
     <asp:Panel ID="pnlselfResignstatus2" runat="server"><%# strselfresignstatus2 %></asp:Panel><br /> 
    </form>
</body>
</html>
