<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankPay.aspx.cs" Inherits="UI.PaymentModule.BankPay" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bank Pay </title>
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

    <script>
        function CloseWindow() {
            window.close();
        }
    </script>

    </head>
<body>
    <form id="frmBankPay" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnAccHead" runat="server" /><asp:HiddenField ID="hdnBillID" runat="server" /><asp:HiddenField ID="hdnBillUnitID" runat="server" />
    <asp:HiddenField ID="hdnAccID" runat="server" /><asp:HiddenField ID="hdnBank" runat="server" /><asp:HiddenField ID="hdnBankAcc" runat="server" />
    <asp:HiddenField ID="hdnInstrument" runat="server" /><asp:HiddenField ID="hdnBillType" runat="server" />

    <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="BANK PAY" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">            
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblRegNo" runat="server" Text="ENTRY CODE" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtEntryCode" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label15" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="APPROVE AMOUNT :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtApproveAmount" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="PARTY" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtParty" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label17" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="VOUCHER ISSUED :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVoucherIssued" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>                
                <td style="text-align:right; width:15px;"><asp:Label ID="Label19" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="PREVIOUS ADVANCE :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPreAdvance" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr> 
            <tr><td colspan="5"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Bank"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlBank" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="A/C No"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlACNumber" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>  
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Instrument"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlInstrument" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstrument_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Cheque</asp:ListItem><asp:ListItem Value="2">Advice</asp:ListItem>
                <asp:ListItem Value="3">Adjustment</asp:ListItem></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="NO :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtNo" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
                <td style="text-align:right; "><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Tk" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="DEBIT A/C"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                    <%--<asp:DropDownList ID="ddlDebitAc" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>--%>
                    <asp:TextBox ID="txtCOA" runat="server" AutoCompleteType="Search" CssClass="txtBox1" Width="350px" AutoPostBack="true"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCOA"
                    ServiceMethod="GetCOAList" MinimumPrefixLength="1" CompletionSetCount="1" CompletionInterval="1"
                    FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                    </cc1:AutoCompleteExtender>
                </td>
                <td style="text-align:right; "><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" CssClass="lbl" Text="COST CENTER"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlCostCenter" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>                           
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="NARRATION" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td colspan="4"><asp:TextBox ID="txtNarration" runat="server" CssClass="txtBox1" Width="590px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="ADD" Height="30px" OnClick="btnAdd_Click"/></td>        
            </tr>

            <tr><td colspan="5"><hr /></td></tr>
            <tr><td colspan="6">   
                <asp:GridView ID="dgvReportForPaymentV" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                ShowFooter="true"  HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" 
                FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvReportForPaymentV_RowDataBound" OnRowDeleting="dgvReportForPaymentV_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="A/C ID" SortExpression="accid">
                <ItemTemplate><asp:Label ID="lblACID" runat="server" Text='<%# Bind("accid") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="ACCOUNT NAME" SortExpression="accname">
                <ItemTemplate><asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("accname") %>' Width="200px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="200px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="NARRATION" SortExpression="narration">
                <ItemTemplate><asp:Label ID="lblNarration" runat="server" Text='<%# Bind("narration") %>' Width="300px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="300px"/>
                <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="DEBIT" SortExpression="debit">
                <ItemTemplate><asp:Label ID="lblDebit" runat="server" Text='<%# Bind("debit", "{0:n2}") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/>
                <FooterTemplate><asp:Label ID="lblDebitTKTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# debitgrandtotal %>" /></FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CREDIT" SortExpression="credit">
                <ItemTemplate><asp:Label ID="lblCredit" runat="server" Text='<%# Bind("credit", "{0:n2}") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
                <FooterTemplate><asp:Label ID="lblCreditTKTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# creditgrandtotal %>" /></FooterTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" CssClass="lbl" Text="PAY TO"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlPayTo" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnSaveBP" runat="server" class="myButton" OnClientClick = "ConfirmAll()" Height="30px" Text="SAVE BP" OnClick="btnSaveBP_Click"/></td>        
            </tr>

        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>