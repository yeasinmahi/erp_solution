<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmProductionEntry.aspx.cs" Inherits="UI.SAD.Vat.frmProductionEntry" %>
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
    <form id="frmProduction" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> PRODUCTION ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                            
       <tr><td>Production Date</td>
            <td><asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr>           
        <tr><td>Product Name</td>
        <td><asp:TextBox ID="txtItemMatrial" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemMatrial"
        ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender></td>
        <td>Production Time</td>
        <td><asp:DropDownList ID="ddlUom" runat="server">
        <asp:ListItem Value="0">12:00 AM</asp:ListItem>
        <asp:ListItem Value="1">1:00 AM</asp:ListItem>
        <asp:ListItem Value="2">2:00 AM</asp:ListItem>
        <asp:ListItem Value="3">3:00 AM</asp:ListItem>
        <asp:ListItem Value="4">4:00 AM</asp:ListItem>
        <asp:ListItem Value="5">5:00 AM</asp:ListItem>
        <asp:ListItem Value="6">6:00 AM</asp:ListItem>
        <asp:ListItem Value="7">7:00 AM</asp:ListItem>
        <asp:ListItem Value="8">8:00 AM</asp:ListItem>
        <asp:ListItem Value="9">9:00 AM</asp:ListItem>
        <asp:ListItem Value="10">10:00 AM</asp:ListItem>
        <asp:ListItem Value="11">11:00 AM</asp:ListItem>
        <asp:ListItem Value="12">12:00 PM</asp:ListItem>
        <asp:ListItem Value="13">1:00 PM</asp:ListItem>
        <asp:ListItem Value="14">2:00 PM</asp:ListItem>
        <asp:ListItem Value="15">3:00 PM</asp:ListItem>
        <asp:ListItem Value="16">4:00 PM</asp:ListItem>
        <asp:ListItem Value="17">5:00 PM</asp:ListItem>
        <asp:ListItem Value="18">6:00 PM</asp:ListItem>
        <asp:ListItem Value="19">7:00 PM</asp:ListItem>
        <asp:ListItem Value="20">8:00 PM</asp:ListItem>
        <asp:ListItem Value="21">9:00 PM</asp:ListItem>
        <asp:ListItem Value="22">10:00 PM</asp:ListItem>
        <asp:ListItem Value="23">11:00 PM</asp:ListItem>
        </asp:DropDownList></td><td></td>
        </tr> 
        <tr><td>Matrial Issue Type</td>
        <td><asp:DropDownList ID="ddlMType" runat="server" OnSelectedIndexChanged="ddlMType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
        <td>Quantity</td>
        <td colspan="2"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>
        </tr> 
        <tr><td><asp:Label ID="lblbandroll" runat="server">Bandroll Used</asp:Label></td> <td><asp:DropDownList ID="ddlBanroll" runat="server"></asp:DropDownList></td>
        <td>Wastage</td>
        <td colspan="2"><asp:TextBox ID="txtWastage" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox> </td>                   
        </tr>
        <tr><td colspan="5" style="text-align:right"><asp:Button ID="btnSaves" runat="server" Text="Save" OnClick="btnSave_Click" /></td>                                     
        <tr><td colspan="5"><hr /></td></tr>          
        </tr>             
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
        <tr><td colspan="5" class="auto-style1">PRODUCTION REPORT</td>   
        <tr><td>Production Date</td>
            <td><asp:TextBox ID="txtfdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtfdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
            <td><asp:TextBox ID="txttdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
            ID="CalendarExtender3" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr> 
                                      
        <tr><td>Short By</td>
            <td><asp:DropDownList ID="ddlShorby" runat="server">
                <asp:ListItem Value="1">Day</asp:ListItem>
                <asp:ListItem Value="2">Product</asp:ListItem>
                <asp:ListItem Value="3">Product Total</asp:ListItem>
                </asp:DropDownList> </td>
            <td style="text-align:left"><asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" /></td>
            
        </tr> 
        <tr><td colspan="5" style="text-align:right"></td>                                     
        <tr><td colspan="5"><hr /></td></tr> 
        <tr><td colspan="5"><asp:GridView ID="dgvProductRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
            >
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
            <asp:TemplateField HeaderText="Date" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("dtedate","{0:d}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
            <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strVatProductName") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Production ID" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblItemid" runat="server" Text='<%# Bind("intID") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numQuantity","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalQty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Amount" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monProductionValue","{0:n0}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
            <asp:Button ID="btndelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intID")%>' />
            </ItemTemplate> </asp:TemplateField>

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
