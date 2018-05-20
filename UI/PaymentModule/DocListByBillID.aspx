<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocListByBillID.aspx.cs" Inherits="UI.PaymentModule.DocListByBillID" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Document View</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script language="javascript">      

        function ViewBillDetailsPopup(Id) {
            window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>

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
        <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox" Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnBillID" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <table>
        <tr><td colspan="9" style="color:blue; font-weight:900;"><a id="btnprint" href="BillDetails.aspx" class="nextclick" style="cursor:pointer; text-align:right;">Back</a></td></tr> 
        </table>
        
        <%--<div class="leaveApplication_container"> 
        <table>
            <tr>
                <td colspan="5" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnBillDetails" runat="server" class="myButton" Text="Back" OnClick="btnBillDetails_Click" /></td>        
            </tr>
        </table>
        <div class="tabs_container"> Document View List<hr /></div>

        </div>--%>
    
   <%--=========================================End My Code From Here=================================================--%>
       
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>