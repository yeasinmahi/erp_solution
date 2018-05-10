<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateItemAndMaterial.aspx.cs" Inherits="UI.VAT_Management.CreateItemAndMaterial" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Create Item And Material </title>
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
    <form id="frmLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnVATAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" /><asp:HiddenField ID="hdnconfirmTax" runat="server" />
          
    <div class="divbody" style="padding-right:10px;">
        
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr><td colspan="5" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="5" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Create Item and Material as par Mushok 1" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
                        
            <tr><td colspan="5">Create New Item<hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Product :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlProduct" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="UOM :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlUOM" CssClass="ddList" Font-Bold="False" runat="server" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                      
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblEName" runat="server" Text="HS Code :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtHSCode" runat="server" CssClass="txtBox1" ></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right;"><asp:CheckBox ID="cbTax" runat="server" Text=" Tax Exempted" OnCheckedChanged="cbTax_CheckedChanged" /></td>
            </tr>
            <tr>                
                <td colspan="2" style="text-align:right; padding-top:15px;"><asp:Button ID="btnUpdateUOM" runat="server" class="myButton" Text="Udate UOM" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnUpdateUOM_Click"/></td>
                <td colspan="3" style="text-align:right;  padding-top:15px"><asp:Button ID="btnCreateItem" runat="server" class="myButton" Text="Create Item" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnCreateItem_Click"/></td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr><td colspan="5">Create New Material<hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Material :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlMaterial" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="UOM :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlUOMM" CssClass="ddList" Font-Bold="False" runat="server" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                      
                </td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                      
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right;"><asp:CheckBox ID="cbTaxM" runat="server" Text=" Tax Exempted" /></td>
            </tr>
            <tr>
                <td colspan="5" style="text-align:right; padding: 15px 0px 10px 0px;"><asp:Button ID="btnCreateMaterial" runat="server" class="myButton" Text="Create Material" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnCreateMaterial_Click"/></td>
            </tr>
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>