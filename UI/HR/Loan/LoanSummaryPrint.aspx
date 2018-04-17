<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanSummaryPrint.aspx.cs" Inherits="UI.HR.Loan.LoanSummaryPrint" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Complete </title>
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

    <script>
        function Print() {
            document.getElementById("btnprint").style.display = "none"; window.print(); self.close();
        }
    </script>
    
</head>
<body>
    <form id="frmLoanSummaryPrint" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>  
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnAppID" runat="server" />    
    <table>
        <tr><td colspan="5" style="text-align:right; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
    </table> 
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> LOAN SUMMARY REPORT<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">            
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblEName" runat="server" Text="Name :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtName" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblFCompany" runat="server" Text="Unit :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" Text="Designation :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
                <td style="text-align:right; width:15px;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="Job Station :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtJobStation" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Department :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDepartment" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                <td style="text-align:right; "><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Job Status :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtJobStatus" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>                
            </tr>
            <tr><td colspan="5"><hr /></td></tr>   
                
        </table> 
    </div>  
        
    <table>
        <tr><td><hr /></td></tr>        
        <tr><td>   
            <asp:GridView ID="dgvLoan" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvLoan_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Application Id" SortExpression="intLoanID">
            <ItemTemplate><asp:Label ID="lblApplicationID" runat="server" Text='<%# Bind("intLoanID") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Loan Type" SortExpression="strLoanType">
            <ItemTemplate><asp:Label ID="lblLoanTypeID" runat="server" Text='<%# Bind("strLoanType") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                                
            <asp:TemplateField HeaderText="Total Loan Amount" SortExpression="intLoanAmount">
            <ItemTemplate><asp:Label ID="lblLoanAmountT" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("intLoanAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblLoanAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalloanamountn %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Remaining Loan Amount" SortExpression="intRemainingLoan">
            <ItemTemplate><asp:Label ID="lblRemainLoanAmountT" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("intRemainingLoan") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblRemainLoanAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalremainloanamountn %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Installment" SortExpression="intInstallment">
            <ItemTemplate><asp:Label ID="lblInstallment" runat="server" Text='<%# Bind("intInstallment") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Remaining Installment" SortExpression="intRemainingInstallment">
            <ItemTemplate><asp:Label ID="lblRInstallment" runat="server" Text='<%# Bind("intRemainingInstallment") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Application Date" SortExpression="DateApplicationDate">
            <ItemTemplate><asp:Label ID="lblApplicationDate" runat="server" Text='<%#Eval("DateApplicationDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Approve Status" SortExpression="strApprove">
            <ItemTemplate><asp:Label ID="lblAppStatus" runat="server" Text='<%#Eval("strApprove") %>' Width="75px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="75px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Loan Installment Status" SortExpression="strInstallment">
            <ItemTemplate><asp:Label ID="lblInsStatus" runat="server" Text='<%#Eval("strInstallment") %>' Width="90px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="90px"/></asp:TemplateField>
                                   
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
