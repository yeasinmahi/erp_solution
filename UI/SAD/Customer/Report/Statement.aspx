<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Customer.Report.Statement" CodeBehind="Statement.aspx.cs" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <%--<webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />--%>
    <link href="../../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <style>
        .container{
            border: 1px solid #ccc;
            padding: 5px;
            width: Auto;
            border-radius: 5px 5px 0 0;
            background-color: #eeeeee;
            -moz-border-radius: 5px 5px 0 0;
            -webkit-border-top-left-radius: 5px;
            float: left;
            -webkit-border-top-right-radius: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div class="container">
                    <table style="width: 800px;">
                        <tr>
                            <td>From
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" runat="server" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td style="width: 30px">
                                <asp:DropDownList ID="ddlFHour" runat="server">
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
                            <td>To
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server" autocomplete="off"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td style="width: 30px">
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
                            <td>Sales Office
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
                            <td></td>
                            <td align="left">Type
                            </td>
                            <td colspan="3" align="left">
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
                            <td style="width: 100px;">Customer
                            </td>
                            <td colspan="4">
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td colspan="2" align="right">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">General</asp:ListItem>
                                                <asp:ListItem>Debit Credit</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>

                <div id="divReportViewer" runat="server">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                        Width="1050" Height="750" BackColor="#EEF1FB" EnableTheming="true">
                    </rsweb:ReportViewer>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
