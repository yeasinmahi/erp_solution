<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentVoucher.aspx.cs" Inherits="UI.PaymentModule.PaymentVoucher" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Payment Voucher </title>
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
         function ViewPrepareVoucher(unitid, billid, entrycode, party, bank, bankacc, instrument, billtypeid, vdate) {
             window.open('BankPay.aspx?unitid=' + unitid + '&billid=' + billid + '&entrycode=' + entrycode + '&party=' + party + '&bank=' + bank + '&bankacc=' + bankacc + '&instrument=' + instrument + '&billtypeid=' + billtypeid + '&vdate=' + vdate, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
         }

         function ViewPrepareVoucherCP(unitid, billid, entrycode, party, bank, bankacc, instrument, billtypeid) {
             window.open('CashPay.aspx?unitid=' + unitid + '&billid=' + billid + '&entrycode=' + entrycode + '&party=' + party + '&bank=' + bank + '&bankacc=' + bankacc + '&instrument=' + instrument + '&billtypeid=' + billtypeid, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
         }

         function ViewBillDetailsPopup(Id) {
             window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
         }
    </script>

    </head>
<body>
    <form id="frmPaymentVoucher" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" /><asp:HiddenField ID="hdnysnPay" runat="server" /><asp:HiddenField ID="hdnysnDutyVoucher" runat="server" />
    <asp:HiddenField ID="hdnEmail" runat="server" />

    <table>
        <tr><td> 
            <div class="divbody" style="padding-right:10px;">
                <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="FINAL PAYMENT" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                <table class="tbldecoration" style="width:auto; float:left;">
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                        <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Type"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>  
                    </tr>
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
                        <asp:DropDownList ID="ddlInstrument" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false">
                        <asp:ListItem Selected="True" Value="1">Cheque</asp:ListItem><asp:ListItem Value="2">Advice</asp:ListItem>
                        <asp:ListItem Value="3">Adjustment</asp:ListItem></asp:DropDownList></td>
                        <td style="text-align:right; "><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>                
                        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                        <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></td>        
                    </tr>
                    <tr><td colspan="5"><hr /></td></tr> 
                </table>        
            </div>
        </td></tr>
        <tr><td>
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
            
                    <asp:TemplateField HeaderText="ID" SortExpression="intBillID">
                    <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intBillID") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Registration Code" SortExpression="strBillRegCode">
                    <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strBillRegCode") %>' Width="150px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Party ID" SortExpression="intPartyID">
                    <ItemTemplate><asp:Label ID="lblPartyID" runat="server" Text='<%# Bind("intPartyID") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Party Name" SortExpression="strPartyName">
                    <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strPartyName") %>' Width="300px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="300px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bill Amount" SortExpression="monApproveAmount">
                    <ItemTemplate><asp:Label ID="lblBillAmount" runat="server" Text='<%# Bind("monApporveAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="V. BP" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnPrepareVoucher" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="PV"  
                    Text="BP"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="V. CP" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnCP" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="CP"  
                    Text="CP"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Show Detail" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnShowDetail" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="View"  
                    Text="View"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td></tr> 
            </table>
        </td></tr></table>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>