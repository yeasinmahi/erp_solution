<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Logistic.LogisGainGroupByCust" Codebehind="LogisGainGroupByCust.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
            z-index: 1; position: absolute;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
        </div>
        <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
            <table style="width: 750px;">
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        
                    </td>
                    <td>
                        Unit
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                            DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                            OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>Sales Office</td>
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
                    <td align="left">
                        Type
                    </td>
                    <td  align="right">
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
                    <td style="width: 100px;">
                        Customer
                    </td>
                    <td>
                        <asp:HiddenField ID="hdnCustomer" runat="server" />
                        <asp:HiddenField ID="hdnCustomerText" runat="server" />
                        <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" 
                            AutoPostBack="True" ontextchanged="txtCus_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                            ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                        </cc1:AutoCompleteExtender>
                    </td>
                    <td></td>
                    <td align="right"> 
                                            
                    </td>
                </tr>
                <tr>
                    <td>Group</td>
                    <td>
                        <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="true" DataSourceID="ObjectDataSource2" 
                                DataTextField="strName" DataValueField="intGroupId">
                            </asp:DropDownList>
                           <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                SelectMethod="GetGroupByUnit" TypeName="LOGIS_BLL.VehicleVarLogisGainGroup">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unit" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>   
                    </td>
                    <td><asp:Button ID="btnSubmit" runat="server" Text="Set Customer To This Group" 
                            onclick="btnSubmit_Click" /></td>
                    <td>
                        <asp:Button ID="btnRemove" runat="server" Text="Remove Customer From Group" onclick="btnRemove_Click" 
                            />
                    </td>
                </tr>
            </table>            
        </div>
    </asp:Panel>
    <div style="height: 120px;">
    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
        runat="server">
    </cc1:AlwaysVisibleControlExtender>       
    <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" Caption="Customer List" runat="server"
                            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
                            <Columns>
                                <%--<asp:BoundField DataField="intCusId" HeaderText="intCusId" 
                                    SortExpression="intCusId" />--%>
                                <asp:BoundField DataField="strName" HeaderText="Customer Name" 
                                    SortExpression="strName" /> 
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetCustomerByGroup"
                            TypeName="LOGIS_BLL.VehicleVarLogisGainGroup" 
                            OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlUnit" Name="unit" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlSo" Name="salesOffId" PropertyName="SelectedValue"
                                    Type="String" />
                                <asp:ControlParameter ControlID="ddlCusType" Name="CusType" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlGroup" Name="groupId" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:Parameter DefaultValue="false" Name="isInsert" Type="Boolean" />
                                <asp:Parameter DefaultValue="false" Name="isRemove" Type="Boolean" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>