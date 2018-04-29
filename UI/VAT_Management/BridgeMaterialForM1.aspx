﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BridgeMaterialForM1.aspx.cs" Inherits="UI.VAT_Management.BridgeMaterialForM1" %>
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
    <asp:HiddenField ID="hdnVatAccID" runat="server" />
          
    <div class="divbody" style="padding-right:10px;">
        
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="2"><hr /></td></tr> 
            <tr><td colspan="2" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="2" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Add Item to Mushok 1" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
                        
            <tr><td colspan="2"><hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="VAT Material :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVATMaterial" CssClass="ddList" Font-Bold="False" runat="server" width="500px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr>
                <td style="text-align:right; padding-top:15px;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Raw Material :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlRM" CssClass="ddList" Font-Bold="False" runat="server" height="23px" Width="500px" AutoPostBack="false"></asp:DropDownList>                                                                                      
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align:right; padding: 10px 0px 8px 0px"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="Add" Height="30px" OnClick="btnAdd_Click"/></td>
            </tr>
            <tr><td colspan="3">   
                <asp:GridView ID="dgvRM" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvRM_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="RM ID" SortExpression="rmid">
                <ItemTemplate><asp:Label ID="lblRMID" runat="server" Text='<%# Bind("rmid") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Material Name" SortExpression="rmname">
                <ItemTemplate><asp:Label ID="lblMaterialName" runat="server" Text='<%# Bind("rmname") %>' Width="400px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="400px" /></asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />                       
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
            </td></tr> 
            <tr>
                <td colspan="2" style="text-align:right; padding: 10px 0px 8px 0px;"><asp:Button ID="btnUpdateBridge" runat="server" class="myButton" Text="Update Bridge" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnUpdateBridge_Click"/></td>
            </tr>
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>