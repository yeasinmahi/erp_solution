<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptBandrollSummary.aspx.cs" Inherits="UI.SAD.Vat.rptBandrollSummary" %>
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
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var ChallanDate = document.forms["frmPurchase"]["txtChallandate"].value;
            var Dpositdate = document.forms["frmPurchase"]["txtDepositdate"].value;
          

            if (ChallanDate == null || ChallanDate == "") {
                alert("Please Fill-up Challan Date!");
            }

            else if (Installmentdate == null || Installmentdate == "") {
                alert("Please Fill-up Installment date!");
            }
          
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }
    </script>
   
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
    <div class="tabs_container"> BANDROLL SUMMARY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                              
     <tr><td>Report Type</td>
        <td><asp:DropDownList ID="ddlShorby" CssClass="ddList" runat="server">
        <asp:ListItem Value="1">Day</asp:ListItem>          
        <asp:ListItem Value="2">Material</asp:ListItem>
        <asp:ListItem Value="3">Material Total</asp:ListItem>
        </asp:DropDownList></td>
        <td>Bandroll Name</td>
        <td><asp:DropDownList ID="ddlBandroll" CssClass="ddList" runat="server">
        </asp:DropDownList></td>
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
        <td> <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="Show Summary" />  </td>
     </tr>

    <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td</tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
   
    <tr><td style="text-align:right"></td>                                     
     <tr><td><hr /></td></tr> 
     <tr><td>
        <asp:GridView ID="dgvPurChaseRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        
        <asp:TemplateField HeaderText="Bandroll Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strBandroll") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Opening Balance" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblOpening" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numOpening","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblOpenings" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalOpening %>" /></FooterTemplate></asp:TemplateField>


        <asp:TemplateField HeaderText="Receive" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblReceive" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numReceive","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblReceives" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalReceive %>" /></FooterTemplate></asp:TemplateField>

         <asp:TemplateField HeaderText="Use To Production" SortExpression="value">
        <ItemTemplate><asp:Label ID="lbluseto" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numIssue","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# Totaluse %>" /></FooterTemplate></asp:TemplateField>

         <asp:TemplateField HeaderText="Wastage" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblWastage" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numWastage","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblWastage" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalWastage %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Reject" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblReject" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numReject","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblReject" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalReject %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Closing" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblnumClosing" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("numClosing","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblnumClosingReject" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalnumClosing %>" /></FooterTemplate></asp:TemplateField>

        
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
