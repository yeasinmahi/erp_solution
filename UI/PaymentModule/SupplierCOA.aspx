<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierCOA.aspx.cs" Inherits="UI.PaymentModule.SupplierCOA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Supplier COA </title>
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

    </head>
<body>
    <form id="frmSupplierCOA" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" /><asp:HiddenField ID="hdnysnPay" runat="server" /><asp:HiddenField ID="hdnysnDutyVoucher" runat="server" />
    <asp:HiddenField ID="hdnEmail" runat="server" />

    <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Add Supplier to Chart of Account" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
                <span style="padding-left:30px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></span>
                </td>
            </tr>
            <tr><td colspan="2"><hr /></td></tr>
            <tr><td colspan="2">   
                <asp:GridView ID="dgvSupplierList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Font-Size="10px"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvSupplierList_RowCommand" OnDataBound="dgvSupplierList_DataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="ID" SortExpression="intSupplierID">
                <ItemTemplate><asp:Label ID="lblSupplierID" runat="server" Text='<%# Bind("intSupplierID") %>' Width="50px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
                <ItemTemplate><asp:Label ID="lblSupplierName" runat="server" Text='<%# Bind("strSupplierName") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Department" SortExpression="strSupplierType">
                <ItemTemplate><asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("strSupplierType") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="COA ID" SortExpression="intCOAID">
                <ItemTemplate><asp:Label ID="lblCOAID" runat="server" Text='<%# Bind("intCOAID") %>' Width="60px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="60px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="COA Code" SortExpression="strCode">
                <ItemTemplate><asp:Label ID="lblCOACode" runat="server" Text='<%# Bind("strCode") %>' Width="120px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="120px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Account Name" ItemStyle-HorizontalAlign="right" SortExpression="strAccName" > 
                <ItemTemplate><asp:DropDownList ID="ddlAccountName" runat="server" CssClass="ddList" Width="300px" DataSourceID="odsCOA" DataTextField="strAccName" DataValueField="intAccID"></asp:DropDownList>
                <asp:HiddenField ID="hdnCOAID" runat="server" Value='<%# Bind("intCOAID") %>' />
                <asp:ObjectDataSource ID="odsCOA" runat="server" SelectMethod="GetAccountHeadForSupplierBridgeCOA" TypeName="SCM_BLL.Payment_All_Voucher_BLL">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                </ItemTemplate><ItemStyle HorizontalAlign="Right"/> </asp:TemplateField>
                              
                <asp:TemplateField HeaderText="Update COA" ItemStyle-HorizontalAlign="Center" SortExpression="">
                <ItemTemplate><asp:Button ID="btnUpdateCOA" class="myButtonGrid" Font-Bold="true" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Update"  
                Text="Update"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Add To COA" ItemStyle-HorizontalAlign="Center" SortExpression="">
                <ItemTemplate><asp:Button ID="btnAddToCOA" class="myButtonGrid" Font-Bold="true" OnClientClick = "ConfirmAll()" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Add"  
                Text="Add"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>

                </Columns>
                <FooterStyle Font-Size="11px" />
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