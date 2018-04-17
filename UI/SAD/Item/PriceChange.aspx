<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Item.PriceChange" Codebehind="PriceChange.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">        
     function DDLChange(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;        
     }
     function DDLChangeP(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndexP").value = document.getElementById(ddlID).options.value;        
     }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 160px; float: right;">
                    <table style="width: 100%;">
                        <tr style="background-color: #E0E0FF;">
                            <td colspan="3">
                                <table width="650px;">
                                    <tr>
                                        <td style="background-color: #F0F0F0;">
                                            <asp:RadioButtonList ID="rdoPrType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdoPrType_SelectedIndexChanged"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="pr">Product</asp:ListItem>
                                                <asp:ListItem Value="cs">Customer</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td style="background-color: #F0F0F0;">
                                            <asp:CheckBox ID="chkCus" runat="server" Text="Need Price Variable" Visible="false"
                                                AutoPostBack="True" OnCheckedChanged="chkCus_CheckedChanged" />
                                        </td>
                                        <td>
                                            <asp:HiddenField ID="hdnLevel" runat="server" Value="1" />
                                            <asp:HiddenField ID="hdnSubLevel" runat="server" Value="1" />
                                            <asp:HiddenField ID="hdnMode" runat="server" />
                                            <asp:HiddenField ID="hdnParent" runat="server" />
                                            <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                            <asp:HiddenField ID="hdnLevelP" runat="server" Value="1" />
                                            <asp:HiddenField ID="hdnSubLevelP" runat="server" Value="1" />
                                            <asp:HiddenField ID="hdnModeP" runat="server" />
                                            <asp:HiddenField ID="hdnParentP" runat="server" />
                                            <asp:HiddenField ID="hdnDDLChangedSelectedIndexP" runat="server" />
                                            <asp:HiddenField ID="hdnPriceId" runat="server" />
                                            Type
                                            <asp:DropDownList ID="ddlType" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strType"
                                                DataValueField="intID" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveItemType_FG"
                                                TypeName="SAD_BLL.Item.Item" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td>
                                            Unit:
                                            <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                                DataTextField="strUnit" DataValueField="intUnitID" 
                                                OnDataBound="ddlUnit_DataBound" 
                                                onselectedindexchanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top: 15px;">
                                <b>PRODUCT SELECTION</b>
                                <br />
                                <asp:Panel ID="pnlMain" runat="server">
                                </asp:Panel>
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Show Item List" />
                                <asp:HiddenField ID="hdnL1" runat="server" />
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <asp:HiddenField ID="hdnSub" runat="server" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 160px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="100%;" style="padding-top: 20px; margin: 0; padding-bottom: 20px; background-color: #F9F0F0;">
                <tr>
                    <td>
                        <asp:Panel ID="pnlPrice" runat="server" Visible="true">
                            <b>PRICE VARIABLE</b>
                            <br />
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="pnlCus" runat="server" Visible="false">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <b>CUSTOMER SELECTION</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Sales Office
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                            DataTextField="strName" DataValueField="intSalesOffId" 
                                            ondatabound="ddlSo_DataBound" 
                                            onselectedindexchanged="ddlSo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOffice"
                                            TypeName="SAD_BLL.Global.SalesOffice" 
                                            OldValuesParameterFormatString="original_{0}">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;Type
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                            DataTextField="strTypeName" DataValueField="intTypeID" 
                                            ondatabound="ddlCusType_DataBound" 
                                            onselectedindexchanged="ddlCusType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                            TypeName="SAD_BLL.Customer.CustomerType" 
                                            OldValuesParameterFormatString="original_{0}">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlSo" Name="soId" 
                                                    PropertyName="SelectedValue" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Customer
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="350px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                            ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                         <%-- Change By Konock --%>
                                        <asp:CheckBox ID="chkall" runat="server" AutoPostBack="true" Text="All" />

                                        <%-- EndChange --%>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <b>SATES TYPE</b>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            DataSourceID="ObjectDataSource5" DataTextField="strTypeName" 
                            DataValueField="intTypeID" ondatabound="RadioButtonList1_DataBound" 
                            RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                            SelectMethod="GetSalesTypeForDO" TypeName="SAD_BLL.Sales.SalesConfig">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
            <table width="650px;">
                <tr>
                    <td>
                        From
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnFrm" runat="server" />
                        <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
                            ID="CalendarExtender1" runat="server" EnableViewState="true">
                        </cc1:CalendarExtender>
                        <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                    <td>
                        &nbsp;&nbsp;To
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnTo" runat="server" />
                        <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
                            ID="CalendarExtender2" runat="server" EnableViewState="true">
                        </cc1:CalendarExtender>
                        <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                            width: 34px; height: 23px; vertical-align: bottom;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        UOM
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUOM" runat="server" DataSourceID="odsUOM" DataTextField="strUOM"
                            DataValueField="intID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsUOM" runat="server" SelectMethod="GetUOMList" TypeName="SAD_BLL.Item.ItemUnitOfMeasurement"
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        Currency
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                            DataTextField="strCurrency" DataValueField="intID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                            TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        Price
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server">0</asp:TextBox>
                    </td>                    
                    <td><asp:CheckBox ID="chkDiscount" runat="server" Text="Discount" />
                    </td>
                    <td align="left">
                        <asp:Button ID="btnPrice" runat="server" OnClick="btnPrice_Click" Text="Request Price Change" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left">
                        <asp:Label ID="lblError" runat="server" ForeColor="#CC0000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding-top: 20px;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2"
                            SkinID="sknGrid1" CaptionAlign="Top" Caption="Waiting Product Price Change List">
                            <Columns>
                                <asp:BoundField DataField="strProductName" HeaderText="Product Name" SortExpression="strProductName" />
                                <asp:TemplateField HeaderText="Price" SortExpression="monPrice">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Eval("monPrice")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date" SortExpression="startDate">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("startDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date" SortExpression="endDate">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("endDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetActiveItemsWithPrice"
                            TypeName="SAD_BLL.Item.ItemPrice">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnL1" Name="levelOneId" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnId" Name="idList" PropertyName="Value" Type="String" />
                                <asp:ControlParameter ControlID="hdnSub" Name="subLevelList" PropertyName="Value"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
