<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTresuaryForcust.aspx.cs" Inherits="UI.SAD.Vat.frmTresuaryForcust" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
  
</head>
<body>
    <form id="frmPurchase" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnCustname" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> Treasury Deposit Forecast<hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
   
    <tr><td style="text-align:right"><asp:GridView ID="dgvm16" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvm16_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Deposit For" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblDeposit" runat="server" Text='<%# Bind("strType") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>
 
        <asp:TemplateField HeaderText="Day-7" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblDay7" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblDay7s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay7 %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Day-6" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblDay6" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblDay6s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay6 %>" /></FooterTemplate> </asp:TemplateField>

        <asp:TemplateField HeaderText="Day-5" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblDay5" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblDays" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay5 %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Day-4" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblDay4" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_4","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblDay4s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay4 %>" /></FooterTemplate></asp:TemplateField>

       <asp:TemplateField HeaderText="Day-3" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblday3" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_3","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblday3s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay3 %>" /></FooterTemplate></asp:TemplateField>


        <asp:TemplateField HeaderText="Day-2" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblday2" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_2","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblday2s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay2 %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Day-1" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblday1" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_1","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblday1s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay1 %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Day-0 (Forecasted Pay)" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblday0" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("day_0","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblday0s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalDay0 %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Current Balance" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblcurrebalance" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monCurrentBalance","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblcurrebalances" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalCurrentBalance %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Net Pay" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblColumn1" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column1") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblColumn1s" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalNetPay %>" /></FooterTemplate></asp:TemplateField>

      

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>       
    </tr>
    <tr><td><hr /></td></tr>                             
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
    <tr><td><hr /></td></tr> 
    <tr><td>
       

        

        </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
