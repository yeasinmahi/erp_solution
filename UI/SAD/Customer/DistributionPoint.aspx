<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.SAD.Customer.DistributionPoint" Codebehind="DistributionPoint.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .divPopUpGeoCss
        {
            position: absolute;
            width: 400px;
            z-index: 5;
            left: 50px;
            top: 170px;
            background-color: #f0f0ff;
            border: 3px outset #00367B;
            display: none;
        }
    </style>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 120px; float: right;">
                    <table>
                        <tr>
                            <td style="width: 120px;">
                                Unit
                            </td>
                            <td style="width: 300px;">
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="ods1"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods1" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sales Office
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" OnDataBound="ddlSo_DataBound"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOffice" TypeName="SAD_BLL.Global.SalesOffice"
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Type
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                    TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" Width="355px" AutoPostBack="True" OnTextChanged="txtCus_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:RadioButtonList ID="rdoActive" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="true">Active</asp:ListItem>
                                    <asp:ListItem Value="false">Inactive</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="left" style="padding-top: 20px;">
                                <a href="#" onclick="ShowDivCus('customerAdd')">
                                    <img alt="" src="../../App_Themes/Default/icons/Add.ico" style="border: 0px;" title="Add Account" />
                                </a>
                            </td>
                        </tr>--%>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 150px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" Caption="Distribution Point List" runat="server"
                            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                            <Columns>
                                <asp:BoundField DataField="intDisPointId" HeaderText="ID" SortExpression="intDisPointId" />                                
                                <asp:BoundField DataField="strDisPointName" HeaderText="Name" SortExpression="strDisPointName" />
                                <asp:BoundField DataField="strAddress" HeaderText="Address" SortExpression="strAddress" />
                                <asp:BoundField DataField="strContactPerson" HeaderText="Contact Person" SortExpression="strContactPerson" />
                                <asp:BoundField DataField="strContactNo" HeaderText="Contact No" SortExpression="strContactNo" />
                                <asp:BoundField DataField="intPriceCatagory" HeaderText="intPriceCatagory" SortExpression="intPriceCatagory" />
                                <asp:BoundField DataField="intLogisticCatagory" HeaderText="intLogisticCatagory"
                                    SortExpression="intLogisticCatagory" />
                                <asp:CheckBoxField DataField="ysnEnable" HeaderText="ysnEnable" SortExpression="ysnEnable" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataByCustomer"
                            TypeName="SAD_BLL.Customer.DistributionPoint" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value"
                                    Type="String" />
                                <asp:ControlParameter ControlID="rdoActive" Name="isActive" PropertyName="SelectedValue"
                                    Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
        ValidationGroup="valCom"></asp:CustomValidator>
    <asp:CustomValidator ID="cvtComPop" runat="server" ClientValidationFunction="ValidateCompletePop"
        ValidationGroup="valComPop"></asp:CustomValidator>
    </form>
</body>
</html>
