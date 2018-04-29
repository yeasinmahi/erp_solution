<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoucherForAdvice.aspx.cs" Inherits="UI.PaymentModule.VoucherForAdvice" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Voucher For Advice </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnEmail" runat="server" /> <asp:HiddenField ID="hdnCount" runat="server" />    
    
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> VOUCHER FOR ADVICE<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Bank"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlBank" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="A/C"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>                
            </tr>
            <tr>
                <td colspan="8" style="text-align:right; padding: 15px 0px 10px 0px"><asp:Button ID="btnPrepareAllVoucher" runat="server" class="myButton" Height="30px" Width="190px" Text="Prepare All Voucher"  OnClientClick = "ConfirmAll()" OnClick="btnPrepareAllVoucher_Click"/></td>  
            </tr>
        </table>
    </div>

    <table>
        <tr><td><hr /></td></tr>
            <tr><td>   
            <asp:GridView ID="dgvReportForPaymentV" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvReportForPaymentV_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="ID" SortExpression="intBill">
            <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intBill") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Registration Code" SortExpression="strBill">
            <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strBill") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="PO ID" SortExpression="strReff">
            <ItemTemplate><asp:Label ID="lblPOID" runat="server" Text='<%# Bind("strReff") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Pay Date" SortExpression="dtePayDate">
            <ItemTemplate><asp:Label ID="lblPayDate" runat="server" Text='<%#Eval("dtePayDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Party ID" SortExpression="intParty">
            <ItemTemplate><asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intBill") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
            <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strParty") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bank Account" SortExpression="strAccount">
            <ItemTemplate><asp:Label ID="lblBankAccount" runat="server" Text='<%# Bind("strAccount") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="COA" SortExpression="intCOA">
            <ItemTemplate><asp:Label ID="lblCOA" runat="server" Text='<%# Bind("intCOA") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Book Value" SortExpression="Bookval">
            <ItemTemplate><asp:Label ID="lblBookValue" runat="server" Text='<%# Bind("Bookval") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Ledger Balance" SortExpression="Leadgerbal">
            <ItemTemplate><asp:Label ID="lblLBalance" runat="server" Text='<%# Bind("Leadgerbal") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill Amount" SortExpression="BillAmount">
            <ItemTemplate><asp:Label ID="lblBillAmount" runat="server" Text='<%# Bind("BillAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Previous Advance" SortExpression="Preadv">
            <ItemTemplate><asp:Label ID="lblPreAdv" runat="server" Text='<%# Bind("Preadv") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="TDS" SortExpression="TDSval">
            <ItemTemplate><asp:Label ID="lblTDS" runat="server" Text='<%# Bind("TDSval") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Approve Amount" SortExpression="monAppAmount">
            <ItemTemplate><asp:Label ID="lblApproveAmount" runat="server" Text='<%# Bind("monAppAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Show Details" ItemStyle-HorizontalAlign="Center" Visible="false" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="SD"  
            Text="Show Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                        
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr> 
    </table>





    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>