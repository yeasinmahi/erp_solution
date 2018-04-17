<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LegalDeptRealizeDetails.aspx.cs" Inherits="UI.HR.Settlement.LegalDeptRealizeDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
</head>
<body>
    <form id="frmhrClearance" runat="server">
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
        <div id="divcontentholder"> <asp:HiddenField ID="hdnconfirm" runat="server" />
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4"> Legal Department Realize :</td></tr>
         
        <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblAdjustAmount" CssClass="lbl" runat="server" Text="Adjust Amount : "></asp:Label></td>
            <td><asp:TextBox ID="txtAdjustAmount" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>                                                             

            <td style="text-align:right;"><asp:Label ID="lblCommentsByLegalDept" CssClass="lbl" runat="server" Text="Comments By Legal Dept : "></asp:Label></td>
             <td><asp:TextBox ID="txtCommentsByLegalDept" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>                                                                             
        </tr>
        <tr class="tblroweven">  
            <td colspan="3"> 
                <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close"/></td>             
            <td  colspan="4">    
            <asp:Button ID="btnRealize" runat="server" CssClass="button" Text="Realize"  OnClientClick="ConfirmAll()"/></td>                       
        </tr>
        
    </table>
    </div>

    <div id="divcontentholder">
        <asp:Panel ID="pnllegaldeptrealizedetails1" runat="server"><%# legaldeptrealizedetails1 %></asp:Panel><br /> 
        <asp:Panel ID="pnllegaldeptrealizedetails2" runat="server"><%# legaldeptrealizedetails2 %></asp:Panel><br /> 
    </div>            
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
