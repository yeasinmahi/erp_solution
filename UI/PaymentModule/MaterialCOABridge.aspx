<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaterialCOABridge.aspx.cs" Inherits="UI.PaymentModule.MaterialCOABridge" %>
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

    <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
    </script>

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
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Bridge Item With COA" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">

            <tr>
                <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="110px" height="23px" AutoPostBack="true" ></asp:DropDownList>
                </td>                
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Category :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlCategory" CssClass="ddList" Font-Bold="False" runat="server" width="130px" height="23px" AutoPostBack="false"></asp:DropDownList>
                <span style="padding-left:30px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show All Item" Height="30px" OnClick="btnShow_Click"/></span>
                <span style="padding-left:30px"><asp:Button ID="btnCOABankItem" runat="server" class="myButton" Text="COA Blank Item" Height="30px" OnClick="btnCOABankItem_Click"/></span>
                <span style="padding-left:30px"><asp:Button ID="btnUpdateBridge" runat="server" class="myButton" Text="Update Bridge" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnUpdateBridge_Click"/></span>
                </td>
            </tr>

            <tr><td colspan="4"><hr /></td></tr>
            <tr><td colspan="4">   
                <asp:GridView ID="dgvItemList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Font-Size="10px"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="Item ID" SortExpression="intItemID">
                <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>' Width="50px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Item Name" SortExpression="strItem">
                <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Category" SortExpression="strReqItemCategory">
                <ItemTemplate><asp:Label ID="lblCategory" runat="server" Text='<%# Bind("strReqItemCategory") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Sub-Category" SortExpression="strSubCategory">
                <ItemTemplate><asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("strSubCategory") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Cluster" SortExpression="strCluster">
                <ItemTemplate><asp:Label ID="lblCluster" runat="server" Text='<%# Bind("strCluster") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Commodity" SortExpression="strComGroupName">
                <ItemTemplate><asp:Label ID="lblCommodity" runat="server" Text='<%# Bind("strComGroupName") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="New Category" SortExpression="strNewCategory">
                <ItemTemplate><asp:Label ID="lblNewCategory" runat="server" Text='<%# Bind("strNewCategory") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="110px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="COA ID" SortExpression="intCOAID" Visible="false">
                <ItemTemplate><asp:Label ID="lblCOAID" runat="server" Text='<%# Bind("intCOAID") %>' Width="70px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="70px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Account Name" ItemStyle-HorizontalAlign="right" SortExpression="strAccName" > 
                <ItemTemplate><asp:DropDownList ID="ddlAccountName" runat="server" CssClass="ddList" Width="300px" DataSourceID="odsItemCOA" DataTextField="strAccName" DataValueField="intAccID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsItemCOA" runat="server" SelectMethod="GetItemCOA" TypeName="SCM_BLL.Payment_All_Voucher_BLL">
                <SelectParameters><asp:ControlParameter ControlID="ddlUnit" Name="intUnitID" PropertyName="SelectedValue" Type="Int32" /></SelectParameters></asp:ObjectDataSource>
                <%--<asp:HiddenField ID="hdnCOAID" runat="server" Value='<%# Bind("intCOAID") %>' />--%>
                </ItemTemplate><ItemStyle HorizontalAlign="Right"/> </asp:TemplateField>

                <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkRow" runat="server" />
                </ItemTemplate></asp:TemplateField>
                      
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