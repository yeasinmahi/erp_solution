<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="UI.PaymentModule.Supplier" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <script type="text/javascript">
         function PrintPanel() {

        var gridData = document.getElementById('<%#printPanel.ClientID %>');

        var prtWindow = window.open('', '', 'left=100,top=100,right=100,bottom=100,width=1200,height=500,tollbar=0,scrollbars=1,status=0,resizable=1')
        prtWindow.document.write('<html><head></head>');
        prtWindow.document.write('<body style="background:none !important">');
        prtWindow.document.write(gridData.outerHTML);
        prtWindow.document.write('</body></html>');
        prtWindow.document.close();
        prtWindow.focus();
        prtWindow.print();
        prtWindow.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                 <div class="leaveApplication_container">
                   <%-- <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />--%>

                    <div class="tabs_container" style="text-align: left">Supplier<hr />
                    </div>
                    <table>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="PO No:"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtPoNo" runat="server" CssClass="txtBox"></asp:TextBox>
                            </td><td></td>
                            
                            <td style="text-align: right;">
                                <asp:Label ID="lblparty" runat="server" CssClass="lbl" Text="Supplier:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" placeholder="Search Supplier" CssClass="txtBox" AutoPostBack="true" Width="200px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSupplier"
                                    ServiceMethod="GetMasterSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender></td>

                        </tr> 
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtdteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="dteFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteFrom"></cc1:CalendarExtender>
                            </td>
                            <td></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteTo"></cc1:CalendarExtender>
                            </td>
                            <td></td>
                            <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btnButton" OnClick="btnShow_Click" /></td>
                            <td><asp:Button ID="btnPrint" runat="server" Text="Print" Width="70" OnClientClick="return PrintPanel();" /></td>
                        </tr>
                        <tr><td style="height:40px;" colspan="11"></td></tr>
                    </table>
                    <asp:Panel ID="printPanel" runat="server">
                     <table>
                         
                         <tr><td>
                             <asp:Label ID="lblhead" runat="server" Text="Supplier Report: " Font-Bold="True" ForeColor="Black"></asp:Label></td></tr>
                         <tr>
                            <td>
                                <asp:GridView ID="GVList" runat="server" Font-Size="12px" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GVList_RowDataBound" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                                <ItemStyle HorizontalAlign="center" />
                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill No" SortExpression="intBill">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("intBill") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Code" SortExpression="strBillCode">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" Width="110px" runat="server" Text='<%# Bind("strBillCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit" SortExpression="strUnit">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Party" SortExpression="strParty">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" Width="110px" runat="server" Text='<%# Bind("strParty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill" SortExpression="strBill">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" Width="70px" runat="server" Text='<%# Bind("strBill") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Date" SortExpression="dtrBillDate">
                                          
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" Width="70px" runat="server" Text='<%# Bind("dtrBillDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Receive Date" SortExpression="dteRcvDate" FooterText="Total">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" Width="70px" runat="server" Text='<%# Bind("dteRcvDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterStyle Font-Bold="True" ForeColor="Black" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bill Amount" SortExpression="monBillAmount">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" Width="70px" runat="server" Text='<%# Bind("monBillAmount","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                       		                    <asp:Label ID="lblmonBillAmount" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                          </FooterTemplate>
                                          <ItemStyle HorizontalAlign="right"/><FooterStyle HorizontalAlign="right" ForeColor="Red" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Audit Status" SortExpression="strAuditStatus">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("strAuditStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Audit Date" SortExpression="dteAuditDate">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" Width="70px" runat="server" Text='<%# Bind("dteAuditDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approve Amount" SortExpression="monApproveAmount">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" Width="70px" runat="server" Text='<%# Bind("monApproveAmount","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                       		                    <asp:Label ID="lblmonApproveAmount" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                          </FooterTemplate>
                                          <ItemStyle HorizontalAlign="right"/><FooterStyle HorizontalAlign="right" ForeColor="Red" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pay Date" SortExpression="dtePayDate">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" Width="70px" runat="server" Text='<%# Bind("dtePayDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PO No" SortExpression="intPO">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%# Bind("intPO") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Voucher" SortExpression="strVoucher">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%# Bind("strVoucher") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>

                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />

                                </asp:GridView>
                            </td>
                        </tr>
                     </table></asp:Panel>
                </div>
                 <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
