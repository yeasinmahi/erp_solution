<%@ Page Language="C#" AutoEventWireup="true" Theme="Theme1"
    Inherits="UI.SAD.Order.VehicleSelectView" Codebehind="VehicleSelectView.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html >

<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopUpC(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,scroll=1,height=1000,width=1000,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=1000,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateComplete(sender, args) {
            if (!confirm('Do you want to complete this voucher?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
    <style type="text/css">
        .hide
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">  
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 100px; float: right;">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="7">
                                <table width="100%" style="background-color: #C0C0C0">
                                    <tr>
                                        <td>
                                            Unit
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="ObjectDataSource2" DataTextField="strUnit"
                                                DataValueField="intUnitID" AutoPostBack="True" OnDataBound="ddlUnit_DataBound"
                                                OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetUnits"
                                                TypeName="HR_BLL.Global.Unit">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align: right;">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                                DataTextField="strName" DataValueField="intShipPointId" OnDataBound="ddlShip_DataBound"
                                                OnSelectedIndexChanged="ddlShip_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                                                TypeName="SAD_BLL.Global.ShipPoint" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align: right;">
                                            Sales Office
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSo" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                                DataTextField="strName" DataValueField="intSalesOfficeId" OnDataBound="ddlSo_DataBound"
                                                OnSelectedIndexChanged="ddlSo_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetSalesOfficeByShipPoint"
                                                TypeName="SAD_BLL.Global.SalesOffice" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlShip" Name="shipPoint" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 30px;">
                                        </td>
                                        <td style="text-align: right;">
                                            Type
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCusType" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource7"
                                                DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="ddlCusType_DataBound"
                                                OnSelectedIndexChanged="ddlCusType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetCustomerTypeBySOForDO"
                                                TypeName="SAD_BLL.Customer.CustomerType" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlSo" Name="soId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" OnTextChanged="txtCus_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>                            
                            <td align="right">
                                From
                            </td>
                            <td>
                                <asp:TextBox ID="txtFrom" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right">
                                To
                            </td>
                            <td>
                                <asp:TextBox ID="txtTo" runat="server" Enabled="false"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td>
                                DO No
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" Style="height: 26px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" align="center">
                                <asp:RadioButtonList ID="rdoComplete" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="false">Not Delivered</asp:ListItem>
                                    <asp:ListItem Value="true">Delivered</asp:ListItem>
                                </asp:RadioButtonList>
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
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table align="center" style="width: 600px; vertical-align: top;">
                        <tr>
                            <td style="width: 100%;">
                                <asp:GridView ID="GridView2" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Top" Caption="Vehicle In With DO" DataSourceID="ObjectDataSource1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="DO Code" SortExpression="strDoCode">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDO" OnClick="lnkDO_Click" CssClass="link" CommandArgument='<%# Eval("strDoCode") %>'
                                                    runat="server"><%# Eval("strDoCode") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strRegNo" HeaderText="Vehicle Reg. No" SortExpression="strRegNo"
                                            ReadOnly="True" />
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataForVehicleAssign"
                                    TypeName="LOGIS_BLL.Trip.TripCall" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlShip" Name="shipPointId" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>
                    <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:HiddenField ID="hdnFrom" runat="server" />
            <asp:HiddenField ID="hdnTo" runat="server" />
            <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False"
                CaptionAlign="Top" Caption="Pending Delevary Order List" DataKeyNames="intId"
                DataSourceID="ObjectDataSource3" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True"
                OnDataBound="GridView1_DataBound" AllowPaging="True" PageSize="20">
                <Columns>
                    <asp:TemplateField HeaderText="DO No" SortExpression="strCode">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Manual Challan No" SortExpression="strChallanNo">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("strChallanNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Date" SortExpression="dteDate">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetShortDateAtLocalDateFormat(Eval("dteDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Del. Point" SortExpression="strDisPointName">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("strDisPointName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer" SortExpression="strName">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Narration" SortExpression="strNarration">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("strNarration") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rest Qnt." SortExpression="numRestPieces">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Eval("numRestPieces")) %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%# UI.ClassFiles.CommonClass.GetFormettingNumber(totPieces) %>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Appr. Qnt." SortExpression="numApprPieces">
                        <ItemTemplate>
                            <asp:Label ID="Label16" runat="server" Text='<%# UI.ClassFiles.CommonClass.GetFormettingNumber(Eval("numApprPieces")) %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%# UI.ClassFiles.CommonClass.GetFormettingNumber(aprPieces)%>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Amount" SortExpression="monTotalAmount">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%# CommonClass.GetFormettingNumber(Eval("monTotalAmount")) %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%# CommonClass.GetFormettingNumber(totAmount) %>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        <FooterStyle HorizontalAlign="Right" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# GetEditLink(Eval("intId"), Eval("ysnChallanCompleted"))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCompleted" ValidationGroup="valCom" runat="server" Text="Delivered"
                                CommandArgument='<%# Eval("intId") +"#"+ Eval("dteDate") %>' OnClick="btnCompleted_Click" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>  
                     <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCancel" ValidationGroup="valCom" runat="server" Text="Cancel"
                                CommandArgument='<%# Eval("intId") %>' OnClick="btnCancel_Click" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# GetEditLink(Eval("intId"))%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnCompleted" ValidationGroup="valCom" runat="server" Text="Completed"
                                CommandArgument='<%# Eval("intId") %>' OnClick="btnCompleted_Click" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="ysnHOCheckCompleted" HeaderText="" ItemStyle-CssClass="hide"
                        HeaderStyle-CssClass="hide" SortExpression="ysnHOCheckCompleted">
                        <HeaderStyle CssClass="hide"></HeaderStyle>
                        <ItemStyle CssClass="hide"></ItemStyle>
                    </asp:CheckBoxField>
                    <asp:CheckBoxField DataField="ysnByHO" HeaderText="" ItemStyle-CssClass="hide"
                        HeaderStyle-CssClass="hide" SortExpression="ysnByHO">
                        <HeaderStyle CssClass="hide"></HeaderStyle>
                        <ItemStyle CssClass="hide"></ItemStyle>
                    </asp:CheckBoxField> --%>
                    <asp:CheckBoxField DataField="ysnChallanCompleted" HeaderText="" ItemStyle-CssClass="hide"
                        HeaderStyle-CssClass="hide" SortExpression="ysnChallanCompleted">
                        <HeaderStyle CssClass="hide"></HeaderStyle>
                        <ItemStyle CssClass="hide"></ItemStyle>
                    </asp:CheckBoxField>
                    
                    <asp:BoundField DataField="intCustomerId" ItemStyle-CssClass="hide" 
                        HeaderStyle-CssClass="hide" FooterStyle-CssClass="hide" >
                    
                        <FooterStyle CssClass="hide" />
                        <HeaderStyle CssClass="hide" />
                        <ItemStyle CssClass="hide" />
                    </asp:BoundField>
                    
                </Columns>
                <PagerStyle BackColor="#CCCCCC" HorizontalAlign="Center" />
            </asp:GridView>            
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetDelivaryOrder"
                TypeName="SAD_BLL.Sales.VehicleSelectView" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdnFrom" Name="fromDate" PropertyName="Value" Type="DateTime" />
                    <asp:ControlParameter ControlID="hdnTo" Name="toDate" PropertyName="Value" Type="DateTime" />
                    <asp:ControlParameter ControlID="txtCode" Name="code" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:SessionParameter Name="userID" SessionField="sesUserID" Type="String" />
                    <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value"
                        Type="String" />
                    <asp:ControlParameter ControlID="ddlCusType" Name="customerType" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="rdoComplete" Name="isCompleted" PropertyName="SelectedValue"
                        Type="Boolean" />
                    <asp:ControlParameter ControlID="ddlShip" Name="shippingPoint" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="ddlSo" Name="salesOffice" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
                ValidationGroup="valCom"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>
