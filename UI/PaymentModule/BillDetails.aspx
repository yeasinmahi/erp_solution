<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillDetails.aspx.cs" Inherits="UI.PaymentModule.BillDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Registration </title>
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

    <script language="javascript">        
        
        function Registration(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
            if (window.focus) { newwindow.focus() }
        }

        function ViewDocumentPopup(Id) {
            window.open('DocListByBillID.aspx?ID=' + Id, 'sub', "height=600, width=500, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        function ViewMRRDetailsPopup(Id) {
            window.open('MRRDetailsView.aspx?ID=' + Id, 'sub', "height=600, width=1050, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        function ViewPriceListPopup(Id) {
            window.open('PreviousPrice.aspx?ID=' + Id, 'sub', "height=600, width=1050, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
        function ViewInDetailsPopup(Id) {
            window.open('IndentViewDetails.aspx?ID=' + Id, 'sub', "height=600, width=1050, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }        
    </script>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnPOID" runat="server" />
    <asp:HiddenField ID="hdnUnitID" runat="server" /><asp:HiddenField ID="hdnEntryType" runat="server" /> 
    <asp:HiddenField ID="hdnLevel" runat="server" />  
    
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL DETAILS<hr /></div>
        <table>
            <tr><td>        
                <table class="tbldecoration" style="width:auto; float:left;">
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="lblRegNo" runat="server" Text="Entry Registration No:" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtRegNo" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke" ForeColor="Blue"></asp:TextBox></td>
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="PO Number :" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtPONo" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="PO Date :" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtPODate" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Bill ID:" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtBillID" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Bill Amount:" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtBillAmount" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Net Pay :" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtNetPay" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="Party Name :" CssClass="lbl"></asp:Label></td>
                        <td colspan="4"><asp:TextBox ID="txtParty" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke" Width="555px"></asp:TextBox></td>                
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Net Amount :" CssClass="lbl"></asp:Label></td>
                        <td><asp:TextBox ID="txtNetAmount" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke" ForeColor="Red" ></asp:TextBox></td>
                    </tr>
                </table>
            </td></tr>
            <tr><td>        
                <table>
                    <tr><td><hr /></td></tr>
                    <tr>
                        <td>   
                        <asp:GridView ID="dgvBillReport" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Font-Size="10px"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                        ShowFooter="true"  HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvBillReport_RowDataBound"
                        OnRowCommand="dgvBillReport_RowCommand">
                        <AlternatingRowStyle BackColor="#CCCCCC" />    
                        <Columns>
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                        <asp:TemplateField HeaderText="ID" SortExpression="intItem">
                        <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItem") %>' Width="50px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                        <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>' Width="150px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" SortExpression="strDes">
                        <ItemTemplate><asp:Label ID="lblDiscription" runat="server" Text='<%# Bind("strDes") %>' Width="150px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/>
                        <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="UOM" SortExpression="strUom">
                        <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUom") %>' Width="40px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="center" Width="40px"/></asp:TemplateField>

                        <asp:TemplateField HeaderText="Indt. Qty." SortExpression="allIndent">
                        <ItemTemplate><asp:Label ID="lblIndtQty" runat="server" Text='<%# Bind("allIndent", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Indt. Rem." SortExpression="indRemain">
                        <ItemTemplate><asp:Label ID="lblIndtRem" runat="server" Text='<%# Bind("indRemain", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="PO Qty." SortExpression="poQty">
                        <ItemTemplate><asp:Label ID="lblPOQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("poQty", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Rate" SortExpression="monRate">
                        <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# Bind("monRate", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="VAT" SortExpression="monVat">
                        <ItemTemplate><asp:Label ID="lblVAT" runat="server"  Text='<%# Bind("monVat", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" />
                        <FooterTemplate><asp:Label ID="lblVATTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# vatgrandtotal %>" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="AIT" SortExpression="monAIT">
                        <ItemTemplate><asp:Label ID="lblAIT" runat="server" Text='<%# Bind("monAIT", "{0:n2}") %>' Width="50px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="50px" />
                        <FooterTemplate><asp:Label ID="lblAITTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# aitgrandtotal %>" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="G. Total" SortExpression="monTotal">
                        <ItemTemplate><asp:Label ID="lblGTotal" runat="server" Text='<%# Bind("monTotal", "{0:n2}") %>' Width="70px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="70px" />
                        <FooterTemplate><asp:Label ID="lblGTotalTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# ggrandtotal %>" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="PO Rem." SortExpression="PORemain">
                        <ItemTemplate><asp:Label ID="lblPORem" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("PORemain", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR Qty" SortExpression="mrrQty">
                        <ItemTemplate><asp:Label ID="lblMrrQty" runat="server"  Text='<%# Bind("mrrQty", "{0:n2}") %>' Width="60px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="60px" /></asp:TemplateField>
               
                        <asp:TemplateField HeaderText="Previous Price" ItemStyle-HorizontalAlign="Center" SortExpression="">
                        <ItemTemplate><asp:Button ID="btnShowPreviousPrice" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="PrePrice"  
                        Text="Pre.Price"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                        </td>
                    </tr> 
                </table>
            </td></tr>
            <tr><td>
                <table>
                    <tr>
                        <td style="vertical-align:top">
                            <table style="vertical-align:top">
                                <tr><td style="vertical-align:top">DOCUMENT LIST<hr /></td></tr>
                                <tr>
                                    <td>   
                                    <asp:GridView ID="dgvDocList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvDocList_RowCommand">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />    
                                    <Columns>
                                    <asp:TemplateField HeaderText="ID" SortExpression="intFileID">
                                    <ItemTemplate><asp:Label ID="lblDocID" runat="server" Text='<%# Bind("intFileID") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Document Type" SortExpression="strFileName">
                                    <ItemTemplate><asp:Label ID="lblDocumentType" runat="server" Text='<%# Bind("strFileName") %>' Width="70px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="FTP Path" SortExpression="strFtpPath">
                                    <ItemTemplate><asp:Label ID="lblFTPPath" runat="server" Text='<%# Bind("strFtpPath") %>' Width="150px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Doc View" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                    <ItemTemplate><asp:Button ID="btnShowDoc" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="DocS"  
                                    Text="Show"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                    </td>
                                </tr> 
                            </table>
                        </td>
                        <td style="vertical-align:top">        
                            <table >
                                <tr><td >CHALLAN LIST<hr /></td></tr>
                                <tr>
                                    <td>   
                                    <asp:GridView ID="dgvChallanList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    ShowFooter="true"  HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvChallanList_RowDataBound"
                                    OnRowCommand="dgvChallanList_RowCommand">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />    
                                    <Columns>
                                    <asp:TemplateField HeaderText="Challan" SortExpression="strChallanNo">
                                    <ItemTemplate><asp:Label ID="lblChallan" runat="server" Text='<%# Bind("strChallanNo") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="MRR" SortExpression="intMRRID">
                                    <ItemTemplate><asp:Label ID="lblMRR" runat="server" Text='<%# Bind("intMRRID") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
                                    <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="MRR TK" SortExpression="monAmount">
                                    <ItemTemplate><asp:Label ID="lblMRRTK" runat="server" Text='<%# Bind("monAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblMRRTKTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# mrrtkgrandtotal %>" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voucher" SortExpression="strVoucherCode">
                                    <ItemTemplate><asp:Label ID="lblVoucher" runat="server" Text='<%# Bind("strVoucherCode") %>' Width="100px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Voucher TK" SortExpression="monVoucherTK">
                                    <ItemTemplate><asp:Label ID="lblVoucherTK" runat="server" Text='<%# Bind("monVoucherTK", "{0:n2}") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                                    <FooterTemplate><asp:Label ID="lblVoucherTKTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# vouchertkgrandtotal %>" /></FooterTemplate></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                    <ItemTemplate><asp:Button ID="btnShowChallan" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="ChallanS"  
                                    Text="Show"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                    </td>
                                </tr> 
                            </table>
                        </td>
                        <td style="vertical-align:top">        
                            <table style="vertical-align:top">
                                <tr><td style="vertical-align:top">INDENT LIST<hr /></td></tr>
                                <tr>
                                    <td>   
                                    <asp:GridView ID="dgvIndentList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvIndentList_RowCommand">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />    
                                    <Columns>
                            
                                    <asp:TemplateField HeaderText="Indent" SortExpression="intIndentID">
                                    <ItemTemplate><asp:Label ID="lblIndent" runat="server" Text='<%# Bind("intIndentID") %>' Width="80px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                    <ItemTemplate><asp:Button ID="btnShowIndent" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="IndentS"  
                                    Text="Show"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                    </td>
                                </tr> 
                            </table>
                        </td>
                        <td style="vertical-align:top">        
                            <table style="vertical-align:top">
                                <tr><td style="vertical-align:top">VOUCHER LIST<hr /></td></tr>
                                <tr>
                                    <td>   
                                    <asp:GridView ID="dgvVoucherList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />    
                                    <Columns>
                            
                                    <asp:TemplateField HeaderText="Voucher" SortExpression="strVoucherCode">
                                    <ItemTemplate><asp:Label ID="lblVoucherS" runat="server" Text='<%# Bind("strVoucherCode") %>' Width="130px"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="130px"/></asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    </asp:GridView>
                                    </td>
                                </tr> 
                            </table>
                        </td>
                    </tr>
                </table>
            </td></tr>
        </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>