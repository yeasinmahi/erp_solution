﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MRDetailsReport.aspx.cs" Inherits="UI.WoodPurchase.MRDetailsReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnPOAmount" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Wood MR Details Report<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4" style="text-align:center"><asp:Label ID="lblWH" runat="server" CssClass="label" Text="Weare House :"></asp:Label>
            <asp:DropDownList ID="ddlWHList" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWHList_SelectedIndexChanged"></asp:DropDownList></td></tr>
            
            
            <tr>
                
                <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
            
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>        
            </tr>
            <tr>
            <td colspan="4">
                <asp:GridView ID="dgvMRDetails" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvMRDetails_RowDataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
            <ItemTemplate><asp:Label ID="lbl" runat="server" Text='<%# Bind("strSupplierName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /><FooterTemplate><asp:Label ID="lblTSN" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>    
                                
            <asp:TemplateField HeaderText="PO No" SortExpression="intPOID" Visible="true">
            <ItemTemplate><asp:Label ID="lblPONo" runat="server" Text='<%# Bind("intPOID") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" /><FooterTemplate><asp:Label ID="lblTPO" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="MRR Date" SortExpression="dteTransactionDate" Visible="true">
            <ItemTemplate><asp:Label ID="lblMRRDate" runat="server" Text='<%#Eval("dteTransactionDate", "{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblTTD" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="MRR NO" SortExpression="intMRRNo">
            <ItemTemplate><asp:Label ID="lblMRRNo" runat="server" Text='<%# Bind("intMRRNo") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Center" /><FooterTemplate><asp:Label ID="lblTMRR" runat="server" Text ="" /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Challan No" SortExpression="strChallan">
            <ItemTemplate><asp:Label ID="lblChallan" runat="server" Text='<%# Bind("strChallan") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" /><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total :" /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Weight" SortExpression="numTotalWeight">
            <ItemTemplate><asp:Label ID="lblTWeight" runat="server" Text='<%# (decimal.Parse(""+Eval("numTotalWeight", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" /><FooterTemplate><asp:Label ID="lblTTW" runat="server" Text ='<%# totalweight %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Deduction" SortExpression="numDeduction">
            <ItemTemplate><asp:Label ID="lblDeduction" runat="server" Text='<%# (decimal.Parse(""+Eval("numDeduction", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right"/><FooterTemplate><asp:Label ID="lblTD" runat="server" Text ='<%# deduction %>' /></FooterTemplate>
            </asp:TemplateField>            

            <asp:TemplateField HeaderText="Net Weight" SortExpression="numNetWeight">
            <ItemTemplate><asp:Label ID="lblNetWeight" runat="server" Text='<%# (decimal.Parse(""+Eval("numNetWeight", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" /><FooterTemplate><asp:Label ID="lblTNW" runat="server" Text ='<%# netweight %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Amount" SortExpression="monReceAmount">
            <ItemTemplate><asp:Label ID="lblTAmount" runat="server" Text='<%# (decimal.Parse(""+Eval("monReceAmount", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right"/><FooterTemplate><asp:Label ID="lblTTA" runat="server" Text ='<%# totalamount %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Unloading Bill" SortExpression="monUnLoadingBill">
            <ItemTemplate><asp:Label ID="lblUnloading" runat="server" Text='<%# (decimal.Parse(""+Eval("monUnLoadingBill", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right"/><FooterTemplate><asp:Label ID="lblTUB" runat="server" Text ='<%# unloadingbill %>' /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Net Payble" SortExpression="monNetPayable">
            <ItemTemplate><asp:Label ID="lblNetPayable" runat="server" Text='<%# (decimal.Parse(""+Eval("monNetPayable", "{0:n}"))) %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right"/><FooterTemplate><asp:Label ID="lblTNP" runat="server" Text ='<%# netpayable %>' /></FooterTemplate>
            </asp:TemplateField>
            
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>           
        </table>
    </div>
  
        
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>