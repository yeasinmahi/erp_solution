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

    <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
    </script>

<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
</head>
<body>
    <form id="frmVoucherForAdvice" runat="server">        
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
                <td style="text-align:right; "><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></td> 
                <td style="text-align:right; "><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Pay Date :" Width="70px"></asp:Label></td>                
                <td colspan="6"><asp:TextBox ID="txtAllPayDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtAllPayDate"></cc1:CalendarExtender>
                <span style="padding-left:15px"><asp:Button ID="btnPrepareAllVoucher" runat="server" class="myButton" Height="30px" Width="190px" Text="Prepare All Voucher"  OnClientClick = "ConfirmAll()" OnClick="btnPrepareAllVoucher_Click"/></span>
                </td>
               
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
            <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intBill") %>' Width="50px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Registration Code" SortExpression="strBill">
            <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strBill") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="PO ID" SortExpression="strReff">
            <ItemTemplate><asp:Label ID="lblPOID" runat="server" Text='<%# Bind("strReff") %>' Width="50px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Pay Date" SortExpression="dtePayDate">
            <ItemTemplate><asp:Label ID="lblPayDate" runat="server" Text='<%#Eval("dtePayDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Pay Date" ItemStyle-HorizontalAlign="right">
            <ItemTemplate><asp:TextBox ID="txtPayDate" runat="server" CssClass="txtBoxCenter" Width="80px" Text='<%#Eval("dtePayDate", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtPayDate">
            </cc1:CalendarExtender> </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Party ID" SortExpression="intParty">
            <ItemTemplate><asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intParty") %>' Width="50px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
            <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strParty") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bank Account" SortExpression="strAccount">
            <ItemTemplate><asp:Label ID="lblBankAccount" runat="server" Text='<%# Bind("strAccount") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="COA" SortExpression="intCOA">
            <ItemTemplate><asp:Label ID="lblCOA" runat="server" Text='<%# Bind("intCOA") %>' Width="50px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Book Value" SortExpression="Bookval">
            <ItemTemplate><asp:Label ID="lblBookValue" runat="server" Text='<%# Bind("Bookval", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Ledger Balance" SortExpression="Leadgerbal">
            <ItemTemplate><asp:Label ID="lblLBalance" runat="server" Text='<%# Bind("Leadgerbal", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill Amount" SortExpression="BillAmount">
            <ItemTemplate><asp:Label ID="lblBillAmount" runat="server" Text='<%# Bind("BillAmount", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Previous Advance" SortExpression="Preadv">
            <ItemTemplate><asp:Label ID="lblPreAdv" runat="server" Text='<%# Bind("Preadv", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="TDS" SortExpression="TDSval">
            <ItemTemplate><asp:Label ID="lblTDS" runat="server" Text='<%# Bind("TDSval", "{0:n2}") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px"/></asp:TemplateField>
                        
            <asp:TemplateField HeaderText="Approve Amount" SortExpression="monAppAmount">
            <ItemTemplate><asp:Label ID="lblApproveAmount" runat="server" Text='<%# Bind("monAppAmount", "{0:n2}") %>' ForeColor="blue" Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Show Details" ItemStyle-HorizontalAlign="Center" Visible="false" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="SD"  
            Text="Show Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>--%>
                        
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr> 
    </table>

<%--    <div class="loading" align="center">
        <img src="../Content/images/gicon/Final-Product-2.GIF" />
    </div>--%>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>