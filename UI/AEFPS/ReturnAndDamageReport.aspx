<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnAndDamageReport.aspx.cs" Inherits="UI.AEFPS.ReturnAndDamageReport" %>

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
    <div class="tabs_container"> RETURN & DAMAGE REPORT <hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Report Type:"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="3">Sales Return</asp:ListItem><asp:ListItem Value="4">Purchase Return</asp:ListItem><asp:ListItem Value="5">Damage</asp:ListItem></asp:DropDownList></td>
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
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="4"><hr /></td></tr>
        
       </table>
    </div>
    <div>
        <table>
        <tr>
            <td colspan="2" style="text-align:center"><asp:Label ID="lblWHName" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:left"><asp:Label ID="lblReportName" runat="server"></asp:Label></td>
            <td style="text-align:right"><asp:Label ID="lblReportDate" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:GridView ID="dgvSalesReturn" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvSalesReturn_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="250px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="30px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="30px" /><FooterTemplate><asp:Label ID="lblTN" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity" SortExpression="numQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblQty" Width="40px" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Rate" SortExpression="monPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblRate" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monPrice", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTText" runat="server" Text="Total : "></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Value" SortExpression="TotalSales" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblTotalValue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("TotalSales", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTTValue" runat="server" Text='<%# totalamount %>'></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Return Date" SortExpression="dteDate" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblReceiveDate" Width="70px" runat="server" Text='<%# Eval("dteDate", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Enroll" SortExpression="intEmpEnroll" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblEnroll" Width="40px" runat="server" Text='<%# Bind("intEmpEnroll") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales Voucher" SortExpression="strSV" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblSalesVoucher" Width="60px" runat="server" Text='<%# Bind("strSV") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Return Voucher" SortExpression="strReturnSV" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblReturnVoucher" Width="60px" runat="server" Text='<%# Bind("strReturnSV") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /></asp:TemplateField>

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
