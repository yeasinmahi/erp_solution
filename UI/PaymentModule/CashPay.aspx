<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashPay.aspx.cs" Inherits="UI.PaymentModule.CashPay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Cash Pay </title>
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
    </head>
<body>
    <form id="frmBankPay" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" /><asp:HiddenField ID="hdnysnPay" runat="server" /><asp:HiddenField ID="hdnysnDutyVoucher" runat="server" />
    <asp:HiddenField ID="hdnEmail" runat="server" />

    <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="CASH PAY" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">            
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblRegNo" runat="server" Text="ENTRY CODE" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtEntryCode" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="APPROVE AMOUNT :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtApproveAmount" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="PARTY" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtParty" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="VOUCHER ISSUED :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVoucherIssued" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>                
                <td style="text-align:right; width:15px;"><asp:Label ID="Label19" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="PREVIOUS ADVANCE :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPreAdvance" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr> 
            <tr><td colspan="5"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="DEBIT A/C"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlDebitAc" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Tk" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox1"></asp:TextBox></td>                         
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="NARRATION" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td colspan="4"><asp:TextBox ID="txtNarration" runat="server" CssClass="txtBox1" Width="590px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Text="PAY TO"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlPayTo" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnSaveCP" runat="server" class="myButton" OnClientClick = "ConfirmAll()"  Text="SAVE CP"/></td>        
            </tr>

        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>