<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocViewForHoldAndFeedback.aspx.cs" Inherits="UI.CreativeSupportModule.DocViewForHoldAndFeedback" %>
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
        <div id="divcontentholder">
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4"> Document List :<asp:HiddenField ID="hdnSeprationID" runat="server" /></td></tr>

            <tr><td colspan="4">
            <asp:GridView ID="dgvDocPath" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
             
            <asp:BoundField DataField="strFilePath" HeaderText="File Path" ItemStyle-HorizontalAlign="Center" SortExpression="strFilePath">
            <ItemStyle HorizontalAlign="left" Width="500px"/></asp:BoundField>

            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDocDownload" class="myButtonGrid" runat="server" Font-Size="9px" OnClick="btnDocDownload_Click"
            CommandArgument='<%# Eval("strFilePath") %>' Text="Download Document" /></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50px" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr>
            <tr><td colspan="6"><hr /></td></tr>

        </table>       
    </div>
        

    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>