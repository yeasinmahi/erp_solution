<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemReceive.aspx.cs" Inherits="UI.Wastage.ItemReceive" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Item Receive </title>
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
    <form id="frmItemReceive" runat="server">        
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
    <asp:HiddenField ID="hdnReffid" runat="server" /><asp:HiddenField ID="hdnRate" runat="server" /><asp:HiddenField ID="hdnuom" runat="server" /><asp:HiddenField ID="hdnuomId" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
    <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> ITEM RECEIVE<hr /></div>
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="WH Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
            </td>
            <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Receive Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
            <td><asp:TextBox ID="txtRecDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtRecDate"></cc1:CalendarExtender></td>
        </tr>
        <tr>
            <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Item Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;" class="auto-style1">
            <asp:DropDownList ID="ddlItem" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList></td>
            <td style="text-align:right; " class="auto-style2"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;" class="auto-style1"><asp:Label ID="Label7" runat="server" Text="Quantity" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td class="auto-style1"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();"></asp:TextBox></td>                 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="UOM :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            <td style="text-align:right; width:15px;"><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Rate" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();"></asp:TextBox></td>                
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="30px"></asp:TextBox></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Value :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtValue" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Weight ID No :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtWeightID" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="30px"></asp:TextBox></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
            <td colspan="2" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click"/></td>        
        </tr>
    </table>
     </div>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>