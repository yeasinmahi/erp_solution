<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoodMRRAMFL.aspx.cs" Inherits="UI.WoodPurchase.WoodMRRAMFL" %>

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
    
    <script language="javascript" type="text/javascript">        

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function roundup(num, dec) {
            dec = dec || 0;
            var s = String(num);
            if (num % 1) s = s.replace(/5$/, '6');
            return Number((+s).toFixed(dec));
        }
        function CalculateInstallmentAmount() {
            var Length = document.getElementById('txtLength').value;
            if (isNaN(Length) == true) { Length = 0; }
            var Circum = document.getElementById('txtCircum').value;
            if (isNaN(Circum) == true) { Circum = 0; }
            var CFT = (Length * Math.pow(Circum,2)) / 2304;
            document.getElementById('txtCFT').value = roundup(CFT, 3);
                        
        }
        
    </script>
    
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnDate" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Wood Receive<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4" style="text-align:center"><asp:Label ID="lblWH" runat="server" CssClass="label" Text="Weare House :"></asp:Label>
            <asp:DropDownList ID="ddlWHList" runat="server" CssClass="ddList" width="220px" height="23px" BackColor="WhiteSmoke" AutoPostBack="true" OnSelectedIndexChanged="ddlWHList_SelectedIndexChanged"></asp:DropDownList></td></tr>
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Supplier/PO :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlPOList" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White" AutoPostBack="true" OnSelectedIndexChanged="ddlPOList_SelectedIndexChanged"></asp:DropDownList></td>
                
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="Challan :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlChallan" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White" AutoPostBack="true" OnSelectedIndexChanged="ddlChallan_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblLength" runat="server" Text="Transport Advance :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                
                <td style="text-align:right;"><asp:Label ID="lblRate" runat="server" Text="Loan Installment :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtLoan" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Total PO Quantity :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPOQty" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Total Pre-Receive :" CssClass="lbl" ></asp:Label></td>
                <td><asp:TextBox ID="txtPrereceive" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtReceiveAmountCheck" runat="server" Visible="false"></asp:TextBox><asp:TextBox ID="txtReceiveQty" runat="server" Visible="false"></asp:TextBox></td>
                <td style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnAdd" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>
            
                <td colspan="2" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClick="btnSubmit_Click"/></td>        
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td colspan="4">
            <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true">
            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Item Name" SortExpression="ItemName">
            <ItemTemplate><asp:Label ID="lblName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>    
                                
            <asp:TemplateField HeaderText="Total Pcs" SortExpression="TotalPcs" Visible="true">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("TotalPcs") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Total CFT" SortExpression="TotalCFT" Visible="true">
            <ItemTemplate><asp:Label ID="lblCFT" runat="server" Text='<%# Bind("TotalCFT") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" SortExpression="monReceRate" Visible="true">
            <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# Bind("monReceRate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
            <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%# Bind("TotalAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID">
            <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="PO Qty" SortExpression="POQtyItemWise" Visible="true">
            <ItemTemplate><asp:Label ID="lblPOQty" runat="server" Text='<%# Bind("POQtyItemWise") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>
            
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