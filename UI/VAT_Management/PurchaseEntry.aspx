<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseEntry.aspx.cs" Inherits="UI.VAT_Management.PurchaseEntry" %>
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
            <tr><td colspan="8" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Purchase Entry" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
               
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Material :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlRM" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="220px" DataSourceID="odsMaterial" DataTextField="strMaterialName" DataValueField="intMaterialID"></asp:DropDownList>                                                                                      
                <asp:ObjectDataSource ID="odsMaterial" runat="server" SelectMethod="GetVMaterialList" TypeName="SAD_BLL.Vat.VAT_BLL">
                <SelectParameters>
                <asp:ControlParameter ControlID="hdnUnit" Name="intUnitID" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="ddlVatAccount" Name="intVATAccountID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters></asp:ObjectDataSource>
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Supplier :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlSupplier" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="220px" DataSourceID="odsSupplier" DataTextField="strSupplierName" DataValueField="intSupplierID"></asp:DropDownList>
                <asp:ObjectDataSource ID="odsSupplier" runat="server" SelectMethod="GetSupplierList" TypeName="SAD_BLL.Vat.VAT_BLL">
                <SelectParameters>
                <asp:ControlParameter ControlID="hdnUnit" Name="intUnitID" PropertyName="Value" Type="Int32" />
                </SelectParameters></asp:ObjectDataSource>
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" runat="server" height="23px" Width="125px" AutoPostBack="false">
                <asp:ListItem Selected="True" Value="1">Local</asp:ListItem><asp:ListItem Value="2">Import</asp:ListItem>
                </asp:DropDownList></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Pur Date :" CssClass="lbl"></asp:Label></td>               
                <td><asp:TextBox ID="txtPurDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtPurDate"></cc1:CalendarExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblWastage" runat="server" Text="Challan :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtChallan" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                
                <td style="text-align:right; width:15px;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Cln Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtClnDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="120"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtClnDate"></cc1:CalendarExtender></td>                
            </tr>
            <tr> 
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Without SD/VAT :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtWithoutSDVAT" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="SD :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSD" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label10" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblQuantity" runat="server" Text="Qty :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox1" Width="120px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label15" runat="server" Text="VAT :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtVAT" runat="server" CssClass="txtBox1"></asp:TextBox></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label16" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" CssClass="lbl" Text="Exempted :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlExempted" CssClass="ddList" Font-Bold="False" runat="server" height="23px" AutoPostBack="false" width="220px">
                <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem><asp:ListItem Value="2">No</asp:ListItem>
                </asp:DropDownList></td>

                <td colspan="3" style="text-align:right; padding: 10px 0px 0px 0px;"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="ADD" Height="30px" OnClick="btnAdd_Click"/></td>
            </tr>
            <tr><td colspan="8"><hr /></td></tr> 
            <tr>
                <td colspan="8" style="text-align:right; padding: 10px 0px 15px 0px;"><asp:Button ID="btnSavePurchase" runat="server" class="myButton" Text="Save Purchase" Height="30px" OnClientClick = "ConfirmAll()" OnClick="btnSavePurchase_Click"/></td>
            </tr>
        </table>
        <table>
            <tr><td><hr /></td></tr>
            <tr><td>   
                <asp:GridView ID="dgvPurchaseEntry" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvPurchaseEntry_RowDeleting">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="MaterialID" SortExpression="mid" Visible="false">
                <ItemTemplate><asp:Label ID="lblMaterialID" runat="server" Text='<%# Bind("mid") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Material Name" SortExpression="mname">
                <ItemTemplate><asp:Label ID="lblMName" runat="server" Text='<%# Bind("mname") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Supplier ID" SortExpression="suppid" Visible="false">
                <ItemTemplate><asp:Label ID="lblSuppID" runat="server" Text='<%# Bind("suppid") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Challan No" SortExpression="challan">
                <ItemTemplate><asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("challan") %>' Width="150px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="150px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Challan Date" SortExpression="chdate">
                <ItemTemplate><asp:Label ID="lblChallanDate" runat="server" Text='<%# Bind("chdate") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Without SD & VAT" SortExpression="withsdvat">
                <ItemTemplate><asp:Label ID="lblSDAndVAT" runat="server" Text='<%# Bind("withsdvat") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="SD" SortExpression="sd">
                <ItemTemplate><asp:Label ID="lblSD" runat="server" Text='<%# Bind("sd") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="VAT" SortExpression="vat">
                <ItemTemplate><asp:Label ID="lblVAT" runat="server" Text='<%# Bind("vat") %>' Width="80px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Total" SortExpression="total">
                <ItemTemplate><asp:Label ID="lblTotal" runat="server" Text='<%# Bind("total") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Exempted" SortExpression="exempted">
                <ItemTemplate><asp:Label ID="lblExempted" runat="server" Text='<%# Bind("exempted") %>' Width="60px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px"/></asp:TemplateField>

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