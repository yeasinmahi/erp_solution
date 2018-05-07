<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillApproval.aspx.cs" Inherits="UI.PaymentModule.BillApproval" %>
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

        function ViewBillDetailsPopup(Id) {
            window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }

        function ViewApproveActionPopup(Id) {
            window.open('ApproveSingle.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>

    <script language="javascript" type="text/javascript">
        
        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }

</script>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" />    
    <table>
        <tr><td>
            <div class="divbody" style="padding-right:10px;">
                <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="BILL APPROVAL" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                
                <table class="tbldecoration" style="width:auto; float:left;">
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                        <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Action"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlAction" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false">
                        <asp:ListItem Selected="True" Value="1">Pending</asp:ListItem><asp:ListItem Value="2">Approve</asp:ListItem>
                        <asp:ListItem Value="3">Reject</asp:ListItem><asp:ListItem Value="4">Market V</asp:ListItem>
                        <asp:ListItem Value="5">Paid</asp:ListItem>
                        </asp:DropDownList></td>                
                    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                        <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                        <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="To Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                        <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
                    </tr>
                    <tr>
                        <td colspan="5" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" OnClick="btnShow_Click"/></td>        
                    </tr>
                    <tr><td colspan="5"><hr /></td></tr> 
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Bill Reg. No." CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td><asp:TextBox ID="txtBillRegNo" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                        <td style="text-align:right; width:15px;"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right; padding: 0px 0px 10px 0px"><asp:Button ID="btnGo" runat="server" class="myButton" Text="Go" OnClick="btnGo_Click"/></td>                       
                        <td style="text-align:right; padding: 0px 0px 10px 0px"><asp:Button ID="btnApproveAll" runat="server" class="myButton" Text="Approve All" OnClientClick = "ConfirmAll()" OnClick="btnApproveAll_Click"/></td>  
                    </tr>
                    <tr><td colspan="5"><hr /></td></tr>
                </table>
             </div>
        </td></tr>
        <tr><td>
            <table>
                <tr><td><hr /></td></tr>
                    <tr><td>   
                    <asp:GridView ID="dgvBillReport" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Font-Size="10px"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvBillReport_RowCommand">
                    <AlternatingRowStyle BackColor="#CCCCCC" />    
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                    <asp:TemplateField HeaderText="ID" SortExpression="intBill">
                    <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intBill") %>' Width="50px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Reg No" SortExpression="strBill">
                    <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strBill") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Reg No" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strBill" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
                    <HeaderTemplate>
                    <asp:Label ID="lblRegNoL" runat="server" CssClass="lbl" Text="Reg No"></asp:Label>
                    <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Any Text" runat="server"  width="125" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvBillReport')"></asp:TextBox></HeaderTemplate>
                    <ItemTemplate><asp:Label ID="lblRegNo" runat="server" Width="125px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strBill")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

                    <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
                    <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Font-Bold="true" Text='<%# Bind("strParty") %>' Width="180px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="180px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Description" SortExpression="strItem">
                    <ItemTemplate><asp:Label ID="lblDiscription" runat="server" Text='<%# Bind("strItem") %>' Width="180px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="180px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Last Price" SortExpression="monLastPtice">
                    <ItemTemplate><asp:Label ID="lblLastPrice" runat="server" Text='<%# Bind("monLastPtice") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Reff" SortExpression="strReff">
                    <ItemTemplate><asp:Label ID="lblReff" runat="server" Text='<%# Bind("strReff") %>' Width="70px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Rcv Date" SortExpression="dteBillRcvDate">
                    <ItemTemplate><asp:Label ID="lblRcvDate" runat="server" Text='<%#Eval("dteBillRcvDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="MRR" SortExpression="strMRR">
                    <ItemTemplate><asp:Label ID="lblMRRID" runat="server" Text='<%# Bind("strMRR") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>                
            
                    <asp:TemplateField HeaderText="Bill Amount" SortExpression="monbillAmount">
                    <ItemTemplate><asp:Label ID="lblBillAmount" runat="server" ForeColor="Blue" Text='<%# Bind("monbillAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Net Amount" SortExpression="monNetAmount">
                    <ItemTemplate><asp:Label ID="lblNetAmount" runat="server" ForeColor="Blue" Text='<%# Bind("monNetAmount", "{0:n2}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="right" SortExpression="strApproveType" > 
                    <ItemTemplate><asp:DropDownList ID="ddlActionStatus" runat="server" CssClass="ddList" Width="72px" DataSourceID="odsApproveType" DataTextField="strApproveType" DataValueField="intID"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsApproveType" runat="server" SelectMethod="GetApproveType" TypeName="SCM_BLL.Billing_BLL"></asp:ObjectDataSource>
                    </ItemTemplate><ItemStyle HorizontalAlign="Right"/> </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action Date" SortExpression="dteApproveDate">
                    <ItemTemplate><asp:Label ID="lblActionDate" runat="server" Text='<%#Eval("dteApproveDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Approve Amount L1" SortExpression="monApproveL1">
                    <ItemTemplate><asp:Label ID="lblApproveAmountL1" runat="server" Text='<%# Bind("monApproveL1", "{0:n2}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Approve Amount L2" SortExpression="monApproveL2">
                    <ItemTemplate><asp:Label ID="lblApproveAmountL2" runat="server" Text='<%# Bind("monApproveL2", "{0:n2}") %>' Width="80px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>
                                                    
                    <asp:TemplateField HeaderText="Show PO" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnShowPO" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="S"  
                    Text="PO"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Show Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnShowDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="SD"  
                    Text="Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Approve Action" ItemStyle-HorizontalAlign="Center" SortExpression="">
                    <ItemTemplate><asp:Button ID="btnApproveAction" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="A"  
                    Text="Action"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                    </Columns>
                    <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td></tr> 
            </table>
        </td></tr>
    </table>




    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>