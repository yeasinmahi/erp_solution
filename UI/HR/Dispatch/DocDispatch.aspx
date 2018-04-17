<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocDispatch.aspx.cs" Inherits="UI.HR.Dispatch.DocDispatch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Dispatch Register </title>
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


</head>
<body>
    <form id="frmdispatch" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <div class="leaveApplication_container"><asp:HiddenField ID="hdnsearch" runat="server"/>        
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:green; text-align:center; font-size:18px"> Document Dispatch System </td></tr>
            
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblDispatchType" runat="server" CssClass="lbl" Text="Dispatch Type :"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDispathType" runat="server" CssClass="ddList">
        <asp:ListItem Selected="True" Value="1">Receive</asp:ListItem><asp:ListItem Value="2">Send</asp:ListItem>
        </asp:DropDownList></td>

        <td style="text-align:right;"><asp:Label ID="lblDeliveryType" runat="server" CssClass="lbl" Text="Delivery Type :"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlDeliveryType_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="2">Courier</asp:ListItem><asp:ListItem Value="1">Messenger</asp:ListItem>
        </asp:DropDownList></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblDocType" runat="server" CssClass="lbl" Text="Document Type :"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDocType" runat="server" CssClass="ddList">
        <asp:ListItem Selected="True" Value="1">Internal</asp:ListItem><asp:ListItem Value="2">External</asp:ListItem>
        </asp:DropDownList></td>

        <td style="text-align:right;"><asp:Label ID="lblDelThru" runat="server" CssClass="lbl" Text="Delivery Thru :"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDelThru" runat="server" CssClass="ddList"></asp:DropDownList></td>
        </tr>

        <tr>
        <td style="text-align:right;"><asp:Label ID="lblDocName" runat="server" CssClass="lbl" Text="Document Name :"></asp:Label></td>
        <td><asp:DropDownList ID="ddlDocName" runat="server" CssClass="ddList">
        <asp:ListItem Selected="True" Value="1">Document</asp:ListItem><asp:ListItem Value="2">Parcel</asp:ListItem>
        </asp:DropDownList></td>
        <td style="text-align:right"><asp:Label ID="lblSearch" runat="server" Text="Search :" CssClass="lbl"></asp:Label></td>
        <td><asp:TextBox ID="txtDelThru" runat="server" CssClass="txtBox" Width="130px"></asp:TextBox><asp:Button ID="btnSearch" runat="server" Text="Search" Width="80px" OnClick="btnSearch_Click" /></td>
        </tr>

        
            
        <tr class="tblroweven">
            <td colspan="4" style="color: indigo; text-align:center; font-size:18px">Documents Sender Information</td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFName" runat="server" Text="Name :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFName" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="Company Name :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFCompany" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFCompanyAdd" runat="server" Text="Company Address :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFCompanyAdd" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblFCompanyPhone" runat="server" Text="Company Phone :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFCompanyPhone" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFPhone" runat="server" Text="Mobile No :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFPhone" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblFMail" runat="server" Text="Mail Address :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtFMail" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr class="tblroweven">
            <td colspan="4" style="color: indigo; text-align:center; font-size:18px">Documents Receiver Information</td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblTName" runat="server" Text="Name :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTName" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblTCompany" runat="server" Text="Company Name :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTCompany" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblTCompanyAdd" runat="server" Text="Company Address :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTCompanyAdd" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblTCompanyPhone" runat="server" Text="Company Phone :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTCompanyPhone" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblTPhone" runat="server" Text="Mobile No :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTPhone" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblTMail" runat="server" Text="Mail Address :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtTMail" runat="server" CssClass="txtBox"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right;"><asp:Label ID="lblRemarks" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
            <td colspan="3" style="text-align:left;"><asp:TextBox ID="txtRemarks" runat="server" Width="540" CssClass="txtBox"></asp:TextBox></td>
        </tr>
                
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblDispatchID" runat="server" Text="Dispatch ID :" CssClass="lbl"></asp:Label></td>
        <td><asp:TextBox ID="txtDispatchID" runat="server" CssClass="txtBox" Font-Bold="true" ForeColor="Maroon"></asp:TextBox></td>
        <td colspan="2" style="text-align:right; font:bold;"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="210px" Font-Bold="true" OnClick="btnSubmit_Click" /></td>     
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUpload" runat="server" CssClass="lbl" Text="Upload:"></asp:Label></td>
            <td style='text-align: left;'><asp:FileUpload ID="FileUpload" runat="server" CssClass="txtBox" Width="210px"/></td>  
        </tr>        
        </table>            
        </div>
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>