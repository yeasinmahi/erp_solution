<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardReport.aspx.cs" Inherits="UI.CreativeSupportModule.DashboardReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. CUSTOMERS VIEW </title>
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
        
        function ViewCustomerView(Id) {
            window.open('CustomerView.aspx?ID=' + Id, 'sub', "height=650, width=970, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
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
    <asp:HiddenField ID="hdnLoanID" runat="server" />            
    <div style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="5"><img src="img/Banner.png" width="100%"; height="120px" /></td></tr> 
         </table>
    </div>
        
    <div class="divbody" style="margin-left:5px; margin-top:20px; padding-left:15px; text-align:center;">
        <div style="text-align:center; padding-top:5px;"> <span style="font-size:20px; text-align:center; font-weight:bold;"> Creative Support Display Board </span></div>
        <table class="tbldecoration" style="width:auto; text-align:center; ">
            <tr><td><hr /></td></tr>
            <tr><td>   
            <asp:GridView ID="dgvDashboardReport" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvDashboardReport_RowCommand" OnDataBound="dgvDashboardReport_DataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="JobID" SortExpression="intJobID" Visible="false">
            <ItemTemplate><asp:Label ID="lblJID" runat="server" Text='<%# Bind("intJobID") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Job Code" SortExpression="strJobCode">
            <ItemTemplate><asp:Label ID="lblJobCode" runat="server" Text='<%# Bind("strJobCode") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Apply Date & Time" SortExpression="ReqDate">
            <ItemTemplate><asp:Label ID="lblApplydDate" runat="server" Text='<%# Bind("ReqDate") %>' Width="120px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="120px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Required Date" SortExpression="dteRequiredDate">
            <ItemTemplate><asp:Label ID="lblRequiredDate" runat="server" Text='<%# Bind("dteRequiredDate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Required Time" SortExpression="tmRequiredTime">
            <ItemTemplate><asp:Label ID="lblRequiredTime" runat="server" Text='<%# Bind("tmRequiredTime") %>' Width="70px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Assign By" SortExpression="strEmployeeName">
            <ItemTemplate><asp:Label ID="lblAssignBy" runat="server" Text='<%# Bind("strEmployeeName") %>' Width="130px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="130px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Special Assign To" SortExpression="strEmployeeName1">
            <ItemTemplate><asp:Label ID="lblAssignTo" runat="server" Text='<%# Bind("strEmployeeName1") %>' Width="130px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="130px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receiver" SortExpression="strEmployeeName2">
            <ItemTemplate><asp:Label ID="lblReceiver" runat="server" Text='<%# Bind("strEmployeeName2") %>' Width="130px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="130px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="right" SortExpression="strApproveType"> 
            <ItemTemplate><asp:DropDownList ID="ddlJStatus" runat="server" CssClass="ddList" Width="90px" DataSourceID="odsJStatus" DataTextField="strCreativeSupportStatus" DataValueField="intStatusID"></asp:DropDownList> 
            <asp:HiddenField ID="hdnStatusID" runat="server" Value='<%# Bind("intJobStatusID") %>' />
            <asp:ObjectDataSource ID="odsJStatus" runat="server" SelectMethod="GetStatusList" TypeName="HR_BLL.CreativeSupport.CreativeS_BLL"></asp:ObjectDataSource>
            </ItemTemplate><ItemStyle HorizontalAlign="Right"/> </asp:TemplateField>

            <asp:TemplateField HeaderText="Job Details" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnJobDetails" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="View"  
            Text="View"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

            </Columns>
            <FooterStyle Font-Size="11px" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr> 
        </table>
    </div>

    <div id="Footer" class="footer">
        <img height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" /> 
    </div>

    

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>