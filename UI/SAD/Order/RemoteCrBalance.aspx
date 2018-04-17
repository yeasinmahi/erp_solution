<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteCrBalance.aspx.cs" Inherits="UI.SAD.Order.RemoteCrBalance" %>


  <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    
    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css"/>   

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>

<%--=========================================Start My Code From Here===============================================--%>
         <div class="leaveApplication_container">     
<table style="width: 90%;background-color:#ede9e9;">
                        <tr>
                            <td>
                                Date
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                <asp:DropDownList ID="ddlTHour" runat="server">                                    
                                    <%--<asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                    <asp:ListItem>02 AM</asp:ListItem>
                                    <asp:ListItem>04 AM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>--%>
                                    <asp:ListItem>06 AM</asp:ListItem>
                                    <asp:ListItem>07 AM</asp:ListItem>
                                    <asp:ListItem>08 AM</asp:ListItem>
                                    <asp:ListItem>09 AM</asp:ListItem>
                                    <asp:ListItem>10 AM</asp:ListItem>
                                    <asp:ListItem>11 AM</asp:ListItem>
                                    <asp:ListItem>12 PM</asp:ListItem>
                                    <asp:ListItem>01 PM</asp:ListItem>
                                    <asp:ListItem>02 PM</asp:ListItem>
                                    <asp:ListItem>03 PM</asp:ListItem>
                                    <asp:ListItem>04 PM</asp:ListItem>
                                    <asp:ListItem>05 PM</asp:ListItem>
                                    <asp:ListItem>06 PM</asp:ListItem>
                                    <asp:ListItem>07 PM</asp:ListItem>
                                    <asp:ListItem>08 PM</asp:ListItem>
                                    <asp:ListItem>09 PM</asp:ListItem>
                                    <asp:ListItem>10 PM</asp:ListItem>
                                    <asp:ListItem>11 PM</asp:ListItem>
                                    <asp:ListItem>12 AM</asp:ListItem>
                                </asp:DropDownList>                      
                            </td>
                            <td>
                            Unit
                            </td>                            
                            <td colspan="2" align="right">
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
                            <td>
                                Sales Office
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intSalesOffId" OnDataBound="ddlSo_DataBound"
                                    OnSelectedIndexChanged="ddlSo_SelectedIndexChanged" Visible="true">
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
                            <td align="left">
<%--                                Type--%>
                            </td>
                            <td colspan="2" align="right">
                                <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                    OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged" Visible="false">
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
                           <%-- <td style="width: 100px;">
                                Customer
                            </td>
                            <td colspan="3">
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>--%>
                            <td align="right" colspan="4">
                                <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                 <td> <asp:Button ID="btnExportToExcel" runat="server" Text="Download" OnClick="btnExportToExcel_Click" /></td>
                            </td>
                        </tr>
    <tr><td colspan="5"><asp:GridView ID="GridView1" runat="server" AllowPaging="false" PageSize="100000000" OnRowDataBound="GridView1_RowDataBound"></asp:GridView></td></tr>
                    </table>

</div>
<%--=========================================End My Code From Here=================================================--%>
   
    </form>
</body>
</html>
