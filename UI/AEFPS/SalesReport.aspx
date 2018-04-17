<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="UI.AEFPS.SalesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        
</script>
       
</head>
<body>
    <form id="frmSalesReturn" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> SALES REPORT <hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td colspan="4" style="text-align:center;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label>
                <asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
        </tr>       
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblEnroll" runat="server" CssClass="lbl" Text="Enroll :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="4"><hr /></td></tr>
        
       </table>
    </div>
    <div>
        <table>
        <tr>
            <td style="text-align:center;">
                <asp:GridView ID="dgvSales" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvSales_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                          
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Voucher" SortExpression="strSV" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblVoucher" Width="60px" runat="server" Text='<%# Bind("strSV") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTV" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Enroll" SortExpression="intEmpEnroll" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblEnroll" Width="40px" runat="server" Text='<%# Bind("intEmpEnroll") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /><FooterTemplate><asp:Label ID="lblTE" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="250px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="250px" /><FooterTemplate><asp:Label ID="lblTN" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity" SortExpression="numQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblQty" Width="40px" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /><FooterTemplate><asp:Label ID="lblTQ" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Rate" SortExpression="monPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblRate" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monPrice", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total :" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Cash Sales" SortExpression="CashSales" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblCashSales" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("CashSales", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblCashT" runat="server" Text ='<%# totalcash %>' /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Credit Sales" SortExpression="CreditSales" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblCreditSales" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("CreditSales", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblCreditT" runat="server" Text ='<%# totalcredit %>' /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Sales" SortExpression="TotalSales" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblTotalSales" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalSales", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblAmountT" runat="server" Text ='<%# totalamount %>' /></FooterTemplate></asp:TemplateField>

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
            </td>
        </tr>

       </table>
       </div>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
