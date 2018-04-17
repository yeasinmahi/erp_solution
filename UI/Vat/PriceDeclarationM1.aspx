<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PriceDeclarationM1.aspx.cs" Inherits="UI.Vat.PriceDeclarationM1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Price Declaration ::.</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="tabs_container">Price Declaration: <asp:HiddenField ID="hdnvtacc" runat="server" /><hr />

        <table>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblvatacc" CssClass="lbl" runat="server" Text="Vat-Account : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlVatAcc" runat="server" AutoPostBack="True" CssClass="dropdownList" DataTextField="strVatAccountName" DataValueField="intVatAccountID"
        DataSourceID="odsvatacc" OnSelectedIndexChanged="ddlVatAcc_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsvatacc" runat="server" SelectMethod="GetVatAccountList" TypeName="BLL.Accounts.PartyPayment.PartyBill">
        <SelectParameters><asp:SessionParameter Name="userid" SessionField="sesUserID" Type="Int32" />
        <asp:SessionParameter Name="unitid" SessionField="sesUnit" Type="Int32" /></SelectParameters></asp:ObjectDataSource>        
        </td>
        <td style="text-align:right;"><asp:Label ID="lblproduct" runat="server" CssClass="lbl" Text="Vat-Product : "></asp:Label></td>
        <td><asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" CssClass="dropdownList" DataSourceID="odsproductlist" 
         DataTextField="strVatProductName" DataValueField="intID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsproductlist" runat="server" SelectMethod="GetVatItemList" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
        <SelectParameters><asp:ControlParameter ControlID="ddlVatAcc" Name="vatacc" PropertyName="SelectedValue" Type="Int32" /></SelectParameters>
        </asp:ObjectDataSource>
        </td>      
        </tr></table> </div>

        <asp:GridView ID="dgvpricedeclaration" runat="server" AutoGenerateColumns="False" SkinID="sknGrid2" Font-Size="11px" BackColor="White" DataSourceID="odsdeclaredproductBOM">
        <Columns>
        <asp:TemplateField HeaderText="SL."><ItemStyle HorizontalAlign="Left" Width="25px"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("SL") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="HSCode"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("HSCode") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ProductName"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UOM"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("UOM") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        

        <asp:TemplateField HeaderText="Raw&Packing"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("RawandPacking") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Raw&PackingQty"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("RawandPackingQty") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Raw&PackingValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("RawandPackingValue") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ValueAddMaterial"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("ValueAddMaterial") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ValueAddMaterialValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("ValueAddMaterialValue") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CurrentPriceWithoutVatSD"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("CurrentPriceWithoutVatSD") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NewPriceWithoutVatSD"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("NewPriceWithoutVatSD") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SDValue"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("SDValue") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        <asp:TemplateField HeaderText="CurrentVatablePrice"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblsl" runat="server" Text='<%# Bind("CurrentVatablePrice") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NewVatablePrice"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblproduct" runat="server" Text='<%# Bind("NewVatablePrice") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TotalPriceHolesale"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("TotalPriceHolesale") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TotalPriceRetail"><ItemStyle HorizontalAlign="Left"/>
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("TotalPriceRetail") %>'></asp:Label></ItemTemplate>   
        </asp:TemplateField>

        </Columns>
        </asp:GridView>

        <asp:ObjectDataSource ID="odsdeclaredproductBOM" runat="server" SelectMethod="GetDeclaredProductBOM" TypeName="BLL.Accounts.PartyPayment.PartyBill" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlProduct" Name="itemid" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
