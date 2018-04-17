<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskComplete.aspx.cs" Inherits="UI.Dairy.TaskComplete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   

<script language="javascript" type="text/javascript">
    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }

</script>

<script> function CloseWindow() {
     window.close();
 } </script>

          
</head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />

    <div class="leaveApplication_container" runat="server" id="DeadlineChangeDiv"> <asp:HiddenField ID="hdnEnroll" runat="server" />
        
         <table class="tbldecoration" style="width:auto; float:left;">
         <tr><td colspan="6" style="font-weight:bold; font-size:13px; color:black;">TASK COMPLETE <hr /></td></tr>     
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Proposed Marks:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtPropostM" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" MaxLength="3" Width="110px"></asp:TextBox></td>
            <td style="width:5px;"></td>
            <td style="text-align:right;"><asp:Label ID="lblAppmarks" runat="server" CssClass="lbl" Text="Approve Marks:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtAppMarks" runat="server" CssClass="txtBox" onkeypress="return onlyNumbers();" MaxLength="3" Width="110px"></asp:TextBox></td>
            <td style="width:5px;"></td>
            <td><asp:Button ID="btnSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Complete"  OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>        
        </tr>                                 
        

 </table>
</div>

        

 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
