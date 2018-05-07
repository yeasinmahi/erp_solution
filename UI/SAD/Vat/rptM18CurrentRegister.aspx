<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptM18CurrentRegister.aspx.cs" Inherits="UI.SAD.Vat.rptM18CurrentRegister" %>
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
 
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
 
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
    <div class="tabs_container"> M11 Not Posted in M17 and M18 <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">  
    <tr><td style="text-align:center" colspan="6">Government Of Peoples Republic Of Bangladesh</td> </tr> 
    <tr> <td style="text-align:center" colspan="6">National Board Of Revenue, Dhaka</td></tr>
    <tr><td style="text-align:center" colspan="6">Account Current Register (SD)</td></tr>
    <tr><td style="text-align:center" colspan="6">[Described in Rule 22(1)]</td></tr>
    <tr><td>Name </td>
        <td><asp:Label ID="lblName" runat="server"></asp:Label></td>
        <td>Phone No</td>
        <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
    </tr> 
    <tr><td class="auto-style1">Address </td>
        <td class="auto-style1"><asp:Label ID="lblAddress" runat="server"></asp:Label></td>
        <td class="auto-style1">Vat Registration No </td>
        <td class="auto-style1"><asp:Label ID="lblVatRegno" runat="server"></asp:Label></td>
     </tr> 
     <tr><td>From Date</td>
        <td><asp:TextBox ID="txtdtefdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtefdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
        ID="CalendarExtender2" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td>To Date</td>
        <td><asp:TextBox ID="txttodate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttodate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
        ID="CalendarExtender1" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" />  </td>
        <td></td>
     </tr>
     <tr><td>Type</td>
        <td><asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True">
            <asp:ListItem Value="1">SD</asp:ListItem>
            <asp:ListItem Value="2">VAT</asp:ListItem>
            <asp:ListItem Value="0">Sur Charge</asp:ListItem>
            </asp:DropDownList></td>
        <td colspan="2" style="text-align:right"><asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show M18" />  </td>
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
                                    
    <tr><td><hr /></td></tr> 
    <tr><td>
        <asp:GridView ID="dgvRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Date" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lbldate" runat="server" Text='<%# Bind("intM11") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Transaction Description" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblYear" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("intYear","{0:n0}") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="30px" />
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Pur/Sales Reg Serial" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblSerial" runat="server" Text='<%# Bind("dteM11Date") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Pur/Sales Reg Date" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblPSDate" runat="server" Text='<%# Bind("strSV") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Treasury Deposit" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lbldteSVDate" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Rebate" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lbldteSVDate" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Other Adjustment" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblotherAdjustmetn" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Payable" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblPayable" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Closing Balance" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblClosing" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("dteSVDate") %>' Width="40px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40px" /></asp:TemplateField>



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
