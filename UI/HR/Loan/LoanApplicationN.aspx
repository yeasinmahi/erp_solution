<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanApplicationN.aspx.cs" Inherits="UI.HR.Loan.LoanApplicationN" %>
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
        function CalculateInstallmentAmount() {
            var loanAmount = document.getElementById('txtLoanAmount').value;
            if (isNaN(loanAmount) == true) { loanAmount = 0; }
            var numberOfInstallment = document.getElementById('txtNumberOfInstallment').value;
            if (isNaN(numberOfInstallment) == true) { numberOfInstallment = 0; }
            var remainder = (loanAmount % numberOfInstallment);
            var installmentAmount = parseInt(loanAmount / numberOfInstallment);
            if (isNaN(installmentAmount) == true) { installmentAmount = 0; }
            document.getElementById('txtInstallmentAmount').value = installmentAmount;
            var lastInstallment = installmentAmount + remainder;
            var message = 'You have to pay ' + lastInstallment + ' Tk. in your last installment';
            if (remainder > 0) {
                document.getElementById('lblRemenderMessage').innerHTML = message;
            }
            else {
                document.getElementById('lblRemenderMessage').innerHTML = "";
            }
        }
        function CalculateInstallmentNo() {
            var loanAmount = document.getElementById('txtLoanAmount').value;
            if (isNaN(loanAmount) == true) { loanAmount = 0; }
            var installAmount = document.getElementById('txtInstallmentAmount').value;
            if (isNaN(installAmount) == true) { installAmount = 0; }            
            var remainder = (loanAmount % installAmount);
            var installmentNo = parseInt(loanAmount / installAmount);
            if (isNaN(installmentNo) == true) { installmentNo = 0; }
            document.getElementById('txtNumberOfInstallment').value = installmentNo;
            
            var loanAmount = 0; var numberOfInstallment = 0;
            var loanAmount = document.getElementById('txtLoanAmount').value;
            if (isNaN(loanAmount) == true) { loanAmount = 0; }
            var numberOfInstallment = document.getElementById('txtNumberOfInstallment').value;
            if (isNaN(numberOfInstallment) == true) { numberOfInstallment = 0; }   
            if (isNaN(installAmount) == true) { installmentAmount = 0; }

            var amount = document.getElementById('txtInstallmentAmount').value;
            var monAmount = (parseInt(amount) + (loanAmount - (installAmount * installmentNo))).toString();

            var remainder = (monAmount - amount);
            var lastInstallment = monAmount;
            var message = 'You have to pay ' + lastInstallment + ' Tk. in your last installment';
            if (remainder > 0) {
                document.getElementById('lblRemenderMessage').innerHTML = message;
            }
            else {
                document.getElementById('lblRemenderMessage').innerHTML = "";
            }
        }

        function ViewDispatchPopup(Id) {
            window.open('LoanScheduleDetailsN.aspx?ID=' + Id, 'sub', "height=500, width=750, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> LOAN APPLICATION<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Search Employee" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchEmp" runat="server" AutoPostBack="true"  CssClass="txtBox1" OnTextChanged="txtSearchEmp_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchEmp"
                ServiceMethod="AutoSearchEmpListGlobal" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Loan Type"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlLoanType" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
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
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Loan Amount" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtLoanAmount" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();" onKeyUp="javascript:CalculateInstallmentAmount();"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Number of Installment" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtNumberOfInstallment" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();" onKeyUp="javascript:CalculateInstallmentAmount();"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Installment Amount" CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtInstallmentAmount" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();" onKeyUp="javascript:CalculateInstallmentNo();" ></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right;"><asp:Label ID="lblRemenderMessage" runat="server" CssClass="label_NoteMessage"></asp:Label></td>                            
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr>
                <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnAdd" runat="server" class="myButtonGrey" Text="ADD" Width="100px" OnClientClick = "ConfirmAll()" OnClick="btnAdd_Click"/></td>        
            </tr>            
        </table>
    </div>
  
    <table>
        <tr><td><hr /></td></tr>
        <tr><td>   
            <asp:GridView ID="dgvLoan" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvLoan_RowDataBound" OnRowCommand="dgvLoan_RowCommand">
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

            <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="D"  
            Text="Details"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnDelete" class="myButtonGrid" Font-Bold="true" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Y"  
            Text="Delete"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                       
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