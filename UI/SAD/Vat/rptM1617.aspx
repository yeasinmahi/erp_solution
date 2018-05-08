<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptM1617.aspx.cs" Inherits="UI.SAD.Vat.rptM1617" %>
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
    <div class="tabs_container"> SUMMARY OF PURCHASE REGISTER <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Name </td>
        <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
        <td>Phone No</td>
        <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
    </tr> 
    <tr><td>Address </td>
        <td><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
        <td>Vat Registration No </td>
        <td><asp:Label ID="lblVatRegno" runat="server"></asp:Label></td>
     </tr> 
     <tr><td>From Date</td>
        <td><asp:TextBox ID="txtdtefdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtefdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
        ID="CalendarExtender2" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /><asp:TextBox ID="txtStime" runat="server" Enabled="false" Width="80px"  Height="22px"></asp:TextBox></td>
        <td>To Date</td>
        <td><asp:TextBox ID="txttodate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttodate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
        ID="CalendarExtender1" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /><asp:TextBox ID="txtEdate" runat="server" Enabled="false" Width="80px"  Height="22px"></asp:TextBox>  </td>
        <td></td>
     </tr>
     <tr><td>Report Type </td>
        <td><asp:DropDownList ID="ddlRpttype" CssClass="ddList" runat="server">
        <asp:ListItem Value="1">M16</asp:ListItem>
        <asp:ListItem Value="2">M17</asp:ListItem>
        </asp:DropDownList></td>
        <td colspan="2" style="text-align:right"><asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Summary" />  </td>
        <td></td>
     </tr> 
     <tr><td></td>
        <td></td>
        <td colspan="2" style="text-align:right"></td>
        <td></td>
     </tr> 
    <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td colspan="6" style="text-align:center"><asp:Label runat="server" ID="lblHeadline"></asp:Label></td>                                     
    <tr><td><hr /></td></tr> 
    <tr><td>
        <asp:GridView ID="dgvm16" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvm16_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strBandroll") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Opening Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblOpeningQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column2","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Opening Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblOpeningValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column3","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblPurchaseQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column4","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblPurchaseValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Issue Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblIssueQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Issue Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblIssueValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Closing Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblClosingQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column8","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Closing Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblClosingValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column9","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:GridView ID="dgv17" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvdgv17_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strBandroll") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Opening Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblOpeningQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column2","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblOpeningqtys" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalOpeningqty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Opening Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblOpeningValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column3","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblOpeningValues" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalOpeningValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblPurchaseQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column4","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblPurchaseqty" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalPurchaseQty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Purchase Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblPurchaseValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblPurchaseValue" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalPurchaseValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Issue Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblIssueQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblIssueQty" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalIssueQty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Issue Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblIssueValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblIssueValue" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalIssueValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Closing Qty" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblClosingQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column8","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblClosingQty" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalClosingQty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Closing Value" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblClosingValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column9","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblClosingValue" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalClosingValue %>" /></FooterTemplate></asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
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
