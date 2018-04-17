<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceiveReport.aspx.cs" Inherits="UI.AEFPS.ReceiveReport" %>
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
    <div class="tabs_container"> RECEIVE REPORT <hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="dteFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="dteTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
        </tr>       
        <tr>
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="4"><hr /></td></tr>
        
        <%--</table>

        <table>--%>
        <tr>
            <td colspan="4" style="text-align:center;">
                <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvReceive_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    
                        <asp:TemplateField HeaderText="Date" SortExpression="dteReceiveDate" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("dteReceiveDate", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="180px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="180px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR No" SortExpression="intMRRID" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblMRRNo" Width="40px" runat="server" Text='<%# Bind("intMRRID") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="30px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR Qty" SortExpression="numActualMRRQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblMRRQty" Width="40px" runat="server" Text='<%# Bind("numActualMRRQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR Price" SortExpression="numMRRPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblMRRPrice" Width="40px" runat="server" Text='<%# Bind("numMRRPrice") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /><FooterTemplate><asp:Label ID="lblTTText" runat="server" Text="Total :"></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR Value" SortExpression="MRRValue" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblMRRValue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("MRRValue", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTMRRValue" runat="server" Text='<%# mrrtvalue %>'></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Receive Qty" SortExpression="numReceiveQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblRecQty" Width="40px" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales Price" SortExpression="numSPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblSalesPrice" Width="30px" runat="server" Text='<%# Bind("numSPrice") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales Value" SortExpression="ReceiveValue" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblSalesValue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("ReceiveValue", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTSalesValue" runat="server" Text='<%# salesvalue %>'></asp:Label></FooterTemplate></asp:TemplateField>

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
