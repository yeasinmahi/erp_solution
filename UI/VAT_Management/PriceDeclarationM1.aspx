<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriceDeclarationM1.aspx.cs" Inherits="UI.VAT_Management.PriceDeclarationM1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Purchase Entry </title>
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
    <form id="frmProductionEntry" runat="server">        
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
    <asp:HiddenField ID="hdnVatAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" />
          
    <div class="divbody" style="padding-right:10px;">
        
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="8"><hr /></td></tr> 
            <tr><td colspan="8" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="8" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Price Declaration" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
               
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Product Name :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlProductName" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="220px" DataSourceID="odsVatItemL" DataTextField="strVatProductName" DataValueField="intID" OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsVatItemL" runat="server" SelectMethod="GetVatItemListForPriceDec" TypeName="SAD_BLL.Vat.VAT_BLL" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                <asp:ControlParameter ControlID="hdnUnit" Name="intUnitID" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="ddlVatAccount" Name="intVATAccountID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters></asp:ObjectDataSource>                
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="220px">
                <asp:ListItem Selected="True" Value="1">Musok-1</asp:ListItem><asp:ListItem Value="2">Musok 1(Ka)</asp:ListItem>
                <asp:ListItem Value="2">Musok 1(Ga)</asp:ListItem></asp:DropDownList></td>              
                <td style="text-align:right; width:15px;"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Valid From :" CssClass="lbl"></asp:Label></td>               
                <td><asp:TextBox ID="txtValidFromDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtValidFromDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:right; padding: 3px 0px 0px 0px;"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show Last M1" Height="30px" Width="150px" OnClick="btnShow_Click"/></td>
            </tr>
            <tr><td colspan="8"><hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="SD Chargeable :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSDChargeable" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="SD :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSD" runat="server" CssClass="txtBox1" Width="160px"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="VAT :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text="SurCharge(%) :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSurChargePercentage" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label14" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="Whole Sale :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtWholeSale" runat="server" CssClass="txtBox1" Width="160px"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="MRP :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMRP" runat="server" CssClass="txtBox1"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="8" style="text-align:right; padding: 10px 0px 0px 0px;"><asp:Button ID="btnSaveM1" runat="server" class="myButton" Text="Save M1" Height="30px" Width="150px" OnClientClick = "ConfirmAll()" OnClick="btnSaveM1_Click"/></td>
            </tr>
            <tr><td colspan="8"><hr /></td></tr> 
        </table>
        <table>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" CssClass="lbl" Text="Material :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlMaterial" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="220px"></asp:DropDownList>
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label18" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Total Qty :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtTotalQty" runat="server" CssClass="txtBox1" Width="90px"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label20" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="Wastage :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtWastage" runat="server" CssClass="txtBox1" Width="90px"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label22" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label23" runat="server" Text="Rate :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox1" Width="90px"></asp:TextBox></td>
                <td style="text-align:right; padding: 0px 0px 0px 0px;"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="ADD" Height="30px" Width="80px" OnClick="btnAdd_Click"/></td>
            </tr>
            <tr><td colspan="16" ><hr /></td></tr>
            <tr><td colspan="16">   
                <asp:GridView ID="dgvPriceDeclaration" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true" RowStyle-Height="30px"
                ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvPriceDeclaration_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="MaterialID" SortExpression="itemid" Visible="false">
                <ItemTemplate><asp:Label ID="lblMaterialID" runat="server" Text='<%# Bind("itemid") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
                <ItemTemplate><asp:Label ID="lblMName" runat="server" Text='<%# Bind("itemname") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="360px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="UOM" SortExpression="uom">
                <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Wastage" SortExpression="wastage">
                <ItemTemplate><asp:Label ID="lblWastage" runat="server" Text='<%# Bind("wastage", "{0:n4}") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Rate (TK)" SortExpression="rate">
                <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# Bind("rate", "{0:n2}") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Total (TK)" SortExpression="amount">
                <ItemTemplate><asp:Label ID="lblTotalTK" runat="server" Text='<%# Bind("amount", "{0:n4}") %>' Width="110px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="110px"/></asp:TemplateField>
                    
                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

                </Columns>
                <FooterStyle Font-Size="11px" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr> 
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>