<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NBR_Sales_New.aspx.cs" Inherits="UI.SAD.Sales.Report.NBR_Sales_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxTimer.js" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.DateTime.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Compat.Timer.Timer.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.Animations.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="ExtenderBase.BaseScripts.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Animation.AnimationBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="PopupExtender.PopupBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Common.Threading.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="Calendar.CalendarBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AutoComplete.AutoCompleteBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top; z-index: 1; position: absolute;">
                            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                                scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                        </div>
                    </asp:Panel>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 130px; float: right;">
                        <table style="width: 90%;">
                            <tr>
                                <td>From
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnFrm" runat="server" />
                                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                        PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                    </cc1:CalendarExtender>
                                    <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                    <asp:DropDownList ID="ddlFHour" runat="server">
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
                                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                        PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                    </cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                    <asp:DropDownList ID="ddlTHour" runat="server">
                                        <asp:ListItem>06 AM</asp:ListItem>
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
                                        <asp:ListItem>04 PM</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right">Unit
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
                                    <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeWithAll" TypeName="SAD_BLL.Global.SalesOffice"
                                        OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="left">Type
                                </td>
                                <td colspan="2" align="left">
                                    <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="true" DataSourceID="ods3"
                                        DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                        OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ods3" runat="server" SelectMethod="GetCustomerTypeBySOForDOWithAll"
                                        TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitId"
                                                PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>Product
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnProduct" runat="server" />
                                    <asp:HiddenField ID="hdnProductText" runat="server" />
                                    <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="350px"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                        ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                </td>
                                <td colspan="2" rowspan="2">
                                    <table>
                                        <tr style="background: #E0E0E0">
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdoType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">General</asp:ListItem>
                                                    <asp:ListItem>Product</asp:ListItem>
                                                    <asp:ListItem>Summery</asp:ListItem>
                                                    <asp:ListItem>Gross</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr style="background: #D0D0D0">
                                            <td>Including Promotion
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdoPromo" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Text="Yes" Value="true"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="false"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="width: 100px;">Customer
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnCustomer" runat="server" />
                                    <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                    <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="350px"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                        ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                    runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 150px;">
                </div>
                
            </ContentTemplate>
            
        </asp:UpdatePanel>
        <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1000px; border:0px solid red;"></iframe>
    </form>

</body>
</html>

