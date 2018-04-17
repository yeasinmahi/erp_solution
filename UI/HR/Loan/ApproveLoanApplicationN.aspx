<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveLoanApplicationN.aspx.cs" Inherits="UI.HR.Loan.ApproveLoanApplicationN" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Approve Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" />
    <link href="../../Content/CSS/CalendarComponemt.css" rel="stylesheet" />
    <link href="../../Content/CSS/Calender.css" rel="stylesheet" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
</head>
<body>
    <form id="frmApproveLoanApplication" runat="server">        
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
          
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px; min-width:700px;"> APPROVE LOAN APPLICATION<hr /></div>

        <table style="width:auto; float:left;">
        <tr><td><hr /></td></tr>
        <tr><td>   
            <asp:GridView ID="dgvLoan" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvLoan_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Application Id" SortExpression="intLoanApplicationId" Visible="false">
            <ItemTemplate><asp:Label ID="lblApplicationID" runat="server" Text='<%# Bind("intLoanApplicationId") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName">
            <ItemTemplate><asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("strEmployeeName") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation">
            <ItemTemplate><asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("strDesignation") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="Department" SortExpression="strDepatrment">
            <ItemTemplate><asp:Label ID="lblDept" runat="server" Text='<%# Bind("strDepatrment") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
                   
            <asp:TemplateField HeaderText="Unit" SortExpression="strUnit">
            <ItemTemplate><asp:Label ID="lblUnit" runat="server" Text='<%# Bind("strUnit") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="80px" /></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Job Station" SortExpression="strJobStationName">
            <ItemTemplate><asp:Label ID="lblJobStation" runat="server" Text='<%# Bind("strJobStationName") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
                            
            <asp:TemplateField HeaderText="Application Date" SortExpression="ApplicationDate">
            <ItemTemplate><asp:Label ID="lblApplicationDate" runat="server" Text='<%#Eval("ApplicationDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Loan Type" SortExpression="strLoanType">
            <ItemTemplate><asp:Label ID="lblLoanTypeID" runat="server" Text='<%# Bind("strLoanType") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="120px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                                
            <asp:TemplateField HeaderText="Loan Amount" SortExpression="intLoanAmount">
            <ItemTemplate><asp:Label ID="lblLoanAmountT" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("intLoanAmount") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Installment" SortExpression="intNumberOfInstallment">
            <ItemTemplate><asp:Label ID="lblInstallment" runat="server" Text='<%# Bind("intNumberOfInstallment") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Approve Amount" SortExpression="ApproveAmount" Visible="false">
            <ItemTemplate><asp:TextBox ID="txtAppAmount" runat="server" CssClass="txtBoxMoney" DataFormatString="{0:0.00}" Text='<%# Bind("ApproveAmount") %>' Width="70px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="70px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Approve Installment" SortExpression="ApproveInstallment" Visible="false">
            <ItemTemplate><asp:TextBox ID="txtAppInstall" runat="server" CssClass="txtBoxCenter" DataFormatString="{0:0.00}" Text='<%# Bind("ApproveInstallment") %>' Width="69px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="69px" /></asp:TemplateField>
                  
            <%--<asp:TemplateField HeaderText="Effective Date (YYYY-MM-DD)" SortExpression="EffectiveDate">
            <ItemTemplate><asp:TextBox ID="txtEffDate" runat="server" CssClass="txtBoxCenter" DataFormatString="{0:0.00}" Text='<%# Bind("EffectiveDate") %>' Width="90px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="90px" /></asp:TemplateField>--%>
                            
            <asp:TemplateField HeaderText="Effective Date (YYYY-MM-DD)" ItemStyle-HorizontalAlign="right">
            <ItemTemplate><asp:TextBox ID="txtEffDate" runat="server" CssClass="txtBoxCenter" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtEffDate">
            </cc1:CalendarExtender> </ItemTemplate>
            </asp:TemplateField>
                               
            <asp:TemplateField HeaderText="Approve" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnApprove" class="myButtonGrid" Font-Bold="true" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="A"  
            Text="Approve"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Reject" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnReject" class="myButtonGrid" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="R"  
            Text="Reject"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                       
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr>  
        </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>