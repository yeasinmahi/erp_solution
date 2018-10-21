<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocView.aspx.cs" Inherits="UI.CreativeSupportModule.DocView" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>

    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
    </style>
    
</head>
<body>
    <form id="frmDocumentView" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnBillID" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnJobID" runat="server" />
        
        <%--<table>
        <tr><td colspan="9" style="color:blue; font-weight:900;"><a id="btnprint" href="BillDetails.aspx" class="nextclick" style="cursor:pointer; text-align:right;">Back</a></td></tr> 
        </table>--%>
        

    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>