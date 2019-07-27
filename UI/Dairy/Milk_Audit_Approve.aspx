<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Audit_Approve.aspx.cs" Inherits="UI.Dairy.Milk_Audit_Approve" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Transfer Out </title>
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
    function DocListView(reqsid) {
        window.open('Milk_Audit_R_Details.aspx?intID=' + reqsid, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=40, resizable=no, title=Preview");
    }
</script>         
      +
</head>
<body>
    <form id="frmTransferOut" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <table>
        <tr>
            <td>        
                <div class="divbody" style="padding-right:10px;">
                    <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> MILK MRR<hr /></div>
                    <table class="tbldecoration" style="width:auto; float:left;">
                        <tr>                
                            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
                            <td style="text-align:left;"><asp:DropDownList ID="ddlChillingCenter" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                            <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>                                          
                        </tr>
                        <tr>  
                            <td style="text-align:right;"><asp:Label ID="dteFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
                            <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox1" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>
                            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>              
                            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
                            <td style="text-align:left"><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox1" autocomplete="off"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
                
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:right; padding: 7px 0px 0px 0px"><asp:Button ID="btnApprove" runat="server" class="myButtonGrey" Text="Bill Complete" OnClick="btnApprove_Click" /></td>
                            <td colspan="3" style="text-align:right; padding: 7px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click" /></td>
                        </tr>
                    </table>

                </div>
            </td>
        </tr>
        <tr>
            <td>        
                <table>
                    <tr><td><hr /></td></tr>
                    <%--===========Summary Report============--%>
                    <tr style="background-color:lightgray;"><td style='text-align: center; background-color:lightgray;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
                    <tr class="tblheader"><td style='text-align: center;' class="auto-style1"><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
                    <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
                    <tr><td>   
                        <asp:GridView ID="dgvAuditApprove" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
                        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" 
                        ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvAuditApprove_RowDataBound" OnRowCommand="dgvAuditApprove_RowCommand">
                        <AlternatingRowStyle BackColor="#CCCCCC" />    
                        <Columns>
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                        <asp:TemplateField HeaderText="Chilling Center Name" SortExpression="strChillingCenterName">
                        <ItemTemplate><asp:Label ID="lblChillingCenter" runat="server" Text='<%# Bind("strChillingCenterName") %>' Width="150px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR No" SortExpression="intMRRNo">
                        <ItemTemplate><asp:Label ID="lblMRRNo" runat="server" Text='<%# Bind("intMRRNo") %>' Width="100px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="MRR Date" SortExpression="dteMRRReceivedDate">
                        <ItemTemplate><asp:Label ID="lblMRRDate" runat="server" Text='<%#Eval("dteMRRReceivedDate", "{0:yyyy-MM-dd}") %>' Width="100px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/>            
                        <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                        <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("Quantity", "{0:n}") %>' Width="80px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                        <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalqty %>" /></FooterTemplate></asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="MRR Amount" SortExpression="MRRAmount">
                        <ItemTemplate><asp:Label ID="lblMRRAmount" runat="server" Text='<%# Bind("MRRAmount", "{0:n}") %>' Width="80px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                        <FooterTemplate><asp:Label ID="lblMRRAmountTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalmrramou %>" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Bonus Amount" SortExpression="BonusAmount">
                        <ItemTemplate><asp:Label ID="lblBonusAmount" runat="server" Text='<%# Bind("BonusAmount", "{0:n}") %>' Width="80px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                        <FooterTemplate><asp:Label ID="lblBonusAmountTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalbonusamou %>" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Payable Amount" SortExpression="Payable Amount">
                        <ItemTemplate><asp:Label ID="lblPayableAmount" runat="server" Text='<%# Bind("PayableAmount", "{0:n}") %>' Width="80px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                        <FooterTemplate><asp:Label ID="lblPayableAmountTotal" runat="server" DataFormatString="{0:n}" Text="<%# totalpayableamou %>" /></FooterTemplate></asp:TemplateField>
                
                        <asp:TemplateField HeaderText="CCID" SortExpression="intChillingCenterID" Visible="false">
                        <ItemTemplate><asp:Label ID="lblCCID" runat="server" Text='<%# Bind("intChillingCenterID") %>' Width="150px"></asp:Label>
                        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                        <ItemTemplate><asp:Button ID="btnDetails" class="myButtonGrid" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="D"  
                        Text="Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                                                
                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td></tr>         
                </table> 
            </td>
       </tr>
    </table> 
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>