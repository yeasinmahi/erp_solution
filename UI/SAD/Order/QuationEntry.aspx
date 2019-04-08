<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuationEntry.aspx.cs" Inherits="UI.SAD.Order.QuationEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html>
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function SetPrice() {
            var price = parseFloat(document.getElementById('lblPrice').value);
            //var logGain = parseFloat(document.getElementById('lblLogisGain').value);
            var qnt = parseFloat(document.getElementById('txtQun').value);
            var tot = 0;

            if (!isNaN(price * qnt)) {
                tot = (price * qnt);
            }

            document.getElementById('lblTotal').innerText = tot;
        }
    </script>
    <script type="text/javascript">
        function ValidateCompleteAdd(sender, args) {

            var flag = Val(sender, args);

            if (document.getElementById("hdnProduct").value == '' && flag) {
                alert('Product not be blank');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("ddlUOM").options.value == '' && flag) {
                alert('UOM is blank');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("ddlCurrency").options.value == '' && flag) {
                alert('Currency is blank');
                NotExec(args);
                flag = false;
            }

            if (document.getElementById("txtQun").value == '' && flag) {
                alert('Quantity not be blank');
                NotExec(args);
                flag = false;
            }

            if (isNaN(document.getElementById("txtQun").value) && flag) {
                alert('Put a number value in Quantity');
                NotExec(args);
                flag = false;
            }

            if (isNaN(document.getElementById("lblPrice").value) && flag) {
                alert('Put a number value in price');
                NotExec(args);
                flag = false;
            }
            if (parseFloat(document.getElementById("lblPrice").value) <= 0 && flag) {
                alert('Put a price');
                NotExec(args);
                flag = false;
            }
            /*if(flag){
            document.getElementById("hdnPrice").value =  document.getElementById("lblPrice").value;
            document.getElementById("hdnVhlPrice").value =  document.getElementById("lblVhkPr").value;
            document.getElementById("hdnChrgPrice").value =  document.getElementById("lblExtPr").value;
            }*/
        }
        function ValidateComplete(sender, args) {

            var flag = Val(sender, args);

            if (document.getElementById("txtChallan") != null && flag) {
                if (document.getElementById("txtChallan").value == '') {
                    if (!confirm('Do you want to go without challan no?')) {
                        NotExec(args);
                        flag = false;
                    }
                }
            }

            if (flag && !confirm('Do you want to save?')) {
                NotExec(args);
                flag = false;
            }
        }

        function Val(sender, args) {
            var flag = true;

            if (document.getElementById("txtDate") != null) {
                if (document.getElementById("txtDate").value == '') {
                    alert('Date not be blank');
                    NotExec(args);
                    flag = false;
                }
            }

            if (document.getElementById("txtCus") != null) {
                if (document.getElementById("txtCus").value == '') {
                    alert('Customer not be blank');
                    NotExec(args);
                    flag = false;
                }
            }

            if (document.getElementById("txtDis") != null && flag) {
                if (document.getElementById("txtDis").value == '') {
                    alert('Distribution Point not be blank');
                    NotExec(args);
                    flag = false;
                }
            }

            if (document.getElementById("txtAddress") != null && flag) {
                if (document.getElementById("txtAddress").value == '') {
                    alert('Address not be blank');
                    NotExec(args);
                    flag = false;
                }
            }

            if (document.getElementById("txtVehicle") != null && flag) {
                if (document.getElementById("txtVehicle").value == '') {
                    alert('Please select a vehicle');
                    NotExec(args);
                    flag = false;
                }
            }

            if (document.getElementById("txtSupplier") != null && flag) {
                if (document.getElementById("txtSupplier").value == '') {
                    alert('Please select a supplier');
                    NotExec(args);
                    flag = false;
                }
            }


            return flag;
        }
        function ValidateCancel(sender, args) {
            if (!confirm('Do you want to cancel?')) {
                NotExec(args)
            }
        }
        function NotExec(args) {
            args.IsValid = false;
            isProceed = false;
        }
    </script>
    <script type="text/javascript">
        function DDLChange(ddlID) {
            document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;
        }
        function DDLChangeV(ddlID) {
            document.getElementById("hdnDDLChangedSelectedIndexV").value = document.getElementById(ddlID).options.value;
        }

    </script>
    <style type="text/css">
        .hide {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
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
                        <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                                scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                        </div>
                    </asp:Panel>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 410px; float: right;">

                        <asp:HiddenField ID="hdnCharBasedOnUom" runat="server" />
                        <asp:HiddenField ID="hdnIncenBasedOnUom" runat="server" />
                        <asp:HiddenField ID="hdnCreditSales" runat="server" />
                        <%--<asp:HiddenField ID="hdnLm" Value="0" runat="server" />--%>
                        <asp:HiddenField ID="hdnBl" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnPN" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnUnit" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnXFactoryVhl" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnXFactoryChr" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnEditPr" runat="server" />
                        <asp:HiddenField ID="hdnPrice" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnChrgMerge" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnSuppTax" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnVat" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnVatPrice" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnCredit" Value="" runat="server" />
                        <%-- <asp:HiddenField ID="hdnCrFixed" Value="" runat="server" />
                    <asp:HiddenField ID="hdnCrPeriod" Value="" runat="server" />--%>
                        <asp:HiddenField ID="hdnItemSpecification" Value="0" runat="server" />


                        <table style="width: 850px; background-color: #E0E0E0;">
                            <tr>
                                <td style="width: 80px;">Unit
                                </td>
                                <td>
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
                                <td align="right">Ship Point
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                        DataTextField="strName" DataValueField="intShipPointId"
                                        OnDataBound="ddlShip_DataBound"
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
                                <td align="right">Sales Office
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
                                <td align="right">Type
                                </td>
                                <td align="right">
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
                        </table>
                        <table style="width: 850px; height: 40px; background-color: #FFF0F0;">
                            <tr>
                                <td style="width: 80px;">Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" Enabled="false" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                        PopupButtonID="imgCal_1" ID="CalendarExtender2" runat="server">
                                    </cc1:CalendarExtender>
                                    <img runat="server" id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                                <td align="right" style="width: 200px;">Requested Delivery Time
                                </td>
                                <td align="right" style="width: 170px;">
                                    <asp:TextBox ID="txtDelDate" Enabled="false" runat="server" AutoPostBack="True"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDelDate" Format="dd/MM/yyyy"
                                        PopupButtonID="imgCal_2" ID="CalendarExtender1" runat="server">
                                    </cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../Content/images/img/calbtn.gif"
                                        style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                                <td align="right" style="width: 20px;">
                                    <asp:DropDownList ID="ddlHour" runat="server">
                                        <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                        <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                        <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                        <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                        <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                        <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                        <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                        <asp:ListItem Text="08" Value="08" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="width: 20px;">
                                    <asp:DropDownList ID="ddlAP" runat="server">
                                        <asp:ListItem Text="AM" Value="am" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="PM" Value="pm"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 850px; background-color: #F0F0F0;">
                            <tr>
                                <td>Customer
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnCustomer" runat="server" />
                                    <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                    <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" OnTextChanged="txtCus_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                        ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                    <asp:Label ID="lblCust" Visible="false" runat="server"></asp:Label>
                                </td>
                                <td colspan="2" rowspan="2">
                                    <asp:Panel ID="pnlClCb" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td style="color: Red;">
                                                    <b></b>
                                                </td>
                                                <td align="left" style="color: Red;">
                                                    <asp:Label ID="lblLM" runat="server" Visible="false" Text="0.0"></asp:Label>
                                                </td>
                                                <td align="right" style="color: Maroon;">
                                                    <b></b>
                                                </td>
                                                <td align="left" style="color: Maroon;">
                                                    <asp:Label ID="lblBl" runat="server" Visible="false" Text="0.0"></asp:Label>
                                                </td>
                                                <td align="right" style="color: Navy;">
                                                    <b></b>
                                                </td>
                                                <td style="color: Navy;">
                                                    <asp:Label ID="lblPN" runat="server" Visible="false" Text="0.0"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="color: Blue;">
                                                    <b style="color: Blue;"></b>&nbsp;
                                                <asp:Label ID="lblGroup" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <asp:Panel ID="pnlDis" runat="server">
                                    <td style="width: 80px;">Del. Point
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnDis" runat="server" />
                                        <asp:HiddenField ID="hdnDisText" runat="server" />
                                        <asp:TextBox ID="txtDis" runat="server" AutoCompleteType="Search"
                                            AutoPostBack="true" OnTextChanged="txtDis_TextChanged" Width="350px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtDis"
                                            ServiceMethod="GetDisPointList" MinimumPrefixLength="1" CompletionSetCount="1"
                                            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                                    </td>
                                </asp:Panel>
                            </tr>
                            <tr>
                                <td>Contact At
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContact" runat="server" Width="350px"></asp:TextBox>
                                </td>
                                <td>Phone
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtPhone" runat="server" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Address
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"
                                        Width="350px"></asp:TextBox>
                                </td>
                                <td>Remarks
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtOther" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 850px; background-color: #D0D0D0;">
                            <tr>
                                <td style="vertical-align: top;">
                                    <asp:HiddenField ID="hdnPriceId" runat="server" />
                                    <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                    <b style="color: Navy;">
                                        <asp:Label ID="privevariable" runat="server" Text=" Price Variable" Visible="false"></asp:Label></b>
                                    <asp:Panel ID="pnlMain" runat="server" Visible="true">
                                    </asp:Panel>
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:HiddenField ID="hdnPriceIdV" runat="server" />
                                    <asp:HiddenField ID="hdnDDLChangedSelectedIndexV" runat="server" />
                                    <b style="color: Navy;">
                                        <asp:Label ID="lblLocationvariable" runat="server" Text=" Location Variable" Visible="false"></asp:Label></b>
                                    <asp:Panel ID="pnlVehicle" runat="server" Visible="true">
                                    </asp:Panel>
                                </td>

                                <td>
                                    <asp:Button ID="btnitmspecification" runat="server" Text="Speci." OnClick="btnitmspecification_Click" BackColor="#ffff99" />
                                </td>

                            </tr>
                        </table>
                        <table style="width: 850px; background-color: #F0F0F0;">
                            <tr>
                                <td style="width: 80px;">
                                    <b style="color: Green;">
                                        <asp:Label ID="lbllogvariable" runat="server" Visible="false"></asp:Label></b>
                                </td>
                                <td style="width: 100px;">
                                    <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" Visible="false"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="true">Yes</asp:ListItem>
                                        <asp:ListItem Value="false">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right" style="color: Blue;">
                                    <b>
                                        <asp:Label ID="lblIncentive" runat="server" Visible="false"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIncentive" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                                        DataTextField="strText" DataValueField="intID" OnDataBound="ddlIncentive_DataBound" Visible="false"
                                        OnSelectedIndexChanged="ddlIncentive_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetIncentiveList"
                                        TypeName="SAD_BLL.Global.Incentive">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="right" style="color: Maroon;">
                                    <b>
                                        <asp:Label ID="lblExtrachar" runat="server" Visible="false"></asp:Label></b>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlExtra" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                        DataTextField="strText" DataValueField="intID" OnDataBound="ddlExtra_DataBound" Visible="false"
                                        OnSelectedIndexChanged="ddlExtra_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExtraChargeList"
                                        TypeName="SAD_BLL.Global.ExtraCharge">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>

                                    <asp:CheckBox ID="sdv" runat="server" Text="Site Delivery" TextAlign="Left" Visible="false" />



                                </td>
                            </tr>
                        </table>

                        <table style="width: 850px; background-color: #F0F0F0;">
                            <tr>
                                <td style="width: 80px;"></td>
                                <td style="width: 100px;">
                                    <asp:GridView ID="grdvtexbox" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="Both" Font-Size="12px">
                                        <Columns>
                                            <asp:BoundField DataField="strattr" HeaderText="Attribute" SortExpression="strName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Value" HeaderStyle-HorizontalAlign="Center" SortExpression="Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtquantity" runat="server" onblur="" CssClass="txtBox" Width="75px" TextMode="Number" Text='<%# Bind("numqnt", "{0:0}") %>' AutoPostBack="false"></asp:TextBox>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:BoundField DataField="intattrid" HeaderText="ID" SortExpression="strName" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>

                                        </Columns>

                                    </asp:GridView>
                                    <asp:GridView ID="gridView" runat="server">

                                    </asp:GridView>
                                </td>
                                <td align="right" style="color: Blue;"></td>
                                <td style="width: 20px;">
                                    <asp:Label ID="ddlSide" runat="server" Text="Side"></asp:Label>

                                </td>
                                <td style="width: 30px;">
                                    <asp:DropDownList ID="ddldrop" runat="server" DataTextField="strattr" DataValueField="intattrid"></asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                        </table>




                        <table style="width: 850px; background-color: #C0C0C0;">
                            <tr>
                                <td>
                                    <b style="">Product</b>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnProduct" runat="server" />
                                    <asp:HiddenField ID="hdnProductText" runat="server" />
                                    <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                        AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                        ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                </td>
                                <td style="color: Blue;">
                                    <b></b>
                                </td>
                                <td style="color: Blue;">
                                    <asp:TextBox ID="txtIncPr" Width="40px" runat="server" Text="0.00" Visible="false"></asp:TextBox>
                                </td>
                                <td style="color: Maroon;">
                                    <b></b>
                                </td>
                                <td style="color: Maroon;">
                                    <asp:TextBox ID="lblExtPr" Width="40px" runat="server" Text="0.00" Visible="false"></asp:TextBox>
                                </td>
                                <td></td>
                                <td>
                                    <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                                        DataTextField="strCurrency" DataValueField="intID"
                                        OnDataBound="ddlCurrency_DataBound">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                                        TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                                    <asp:TextBox ID="txtConvRate" runat="server" Width="70px"></asp:TextBox>
                                </td>
                                <td style="color: Olive;">
                                    <asp:RadioButtonList ID="rdoSalesType" runat="server" DataSourceID="ObjectDataSource5"
                                        DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="rdoSalesType_DataBound"
                                        OnSelectedIndexChanged="rdoSalesType_SelectedIndexChanged" AutoPostBack="true"
                                        RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetSalesTypeForDO"
                                        TypeName="SAD_BLL.Sales.SalesConfig">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="ddlUnit" Name="unitID" PropertyName="SelectedValue"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 850px;">
                            <tr style="background-color: #B0B0B0; text-align: center;">
                                <td>UOM
                                </td>
                                <td>Price
                                </td>
                                <td>Commission
                                </td>
                                <td>Quantity
                                </td>
                                <td>Total
                                </td>
                                <%--<td>
                                G. Total
                            </td>--%>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr style="background-color: #B0B0B0;">
                                <td>
                                    <asp:HiddenField ID="hdnUOM" runat="server" />
                                    <asp:DropDownList ID="ddlUOM" runat="server" DataSourceID="odsUOM" DataTextField="strUOM"
                                        DataValueField="intID" AutoPostBack="True" OnDataBound="ddlUOM_DataBound" OnSelectedIndexChanged="ddlUOM_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUOM" runat="server" SelectMethod="GetUOMRelationByPrice"
                                        TypeName="SAD_BLL.Item.ItemUnitOfMeasurement" OldValuesParameterFormatString="original_{0}">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="hdnProduct" Name="productId" PropertyName="Value"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="hdnCustomer" Name="customerId" PropertyName="Value"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="hdnPriceId" Name="priceVariable" PropertyName="Value"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="rdoSalesType" Name="salesType" PropertyName="SelectedValue"
                                                Type="String" />
                                            <asp:ControlParameter ControlID="txtDate" Name="date" PropertyName="Text" Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="lblPrice" runat="server" Width="50px"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblComm" runat="server"></asp:Label>
                                </td>
                                <td align="center" style="vertical-align: middle;">
                                    <asp:TextBox ID="txtQun" runat="server" Width="60px"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td align="center" style="text-align: right;">
                                    <asp:Label ID="lblTotal" Text="0" runat="server"></asp:Label>
                                </td>
                                <%--<td align="center">
                                <asp:Label ID="lblGT" runat="server" Text="0.0"></asp:Label>
                            </td>--%>
                                <td align="right">
                                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="valComAdd" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <div style="height: 425px;">
                </div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                    runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <table style="width: 850px;">
                    <tr>
                        <td colspan="3">
                            <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                                AutoGenerateColumns="False" CaptionAlign="Top" Caption="" ShowFooter="True"
                                OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting"
                                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                <Columns>
                                    <asp:BoundField DataField="Pid" HeaderText="Pid" Visible="false" SortExpression="Pid" />
                                    <asp:TemplateField HeaderText="Product Name" SortExpression="PName">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qnt" SortExpression="ApprQnt">
                                        <ItemTemplate>
                                            <asp:Label ID="Label16" runat="server" Text='<%# Bind("ApprQnt") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtQnty" runat="server" Text='<%# Bind("ApprQnt") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Price" SortExpression="Pr">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Pr") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server"
                                                Text='<%# GetTotal(""+Eval("Pr"), ""+Eval("ApprQnt")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="Label7" runat="server" Text="<%# GetGrandTotal(4) %>"></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>






                                    <asp:BoundField DataField="UomTxt" HeaderText="UomTxt" ItemStyle-CssClass="hide"
                                        HeaderStyle-CssClass="hide" SortExpression="UomTxt">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="">
                                            <img alt=""  src="../../Content/images/icons/Save.png" style="border: 0px;"
                                                                title="Update" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Cancel"
                                                Text="">
                                            <img alt="" height="20px" width="20px" src="../../Content/images/icons/132.png" style="border: 0px;"
                                                                title="Cancel" />
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                                Text="">
                                        <img alt=""  src="../../Content/images/icons/Delete.png" style="border: 0px;" title="Delete"/>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit"
                                                Text="">
                                            <img alt="" src="../../Content/images/icons/edit.gif" style="border: 0px;"
                                                                title="Edit" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="False" EnableViewState="False"
                                runat="server"></asp:XmlDataSource>
                        </td>
                    </tr>
                    <%--<tr style="height: 50px; vertical-align: bottom;">
                    <td style="vertical-align: middle;">
                        Narration
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNarration" runat="server" Height="48px" TextMode="MultiLine"
                            Width="670px"></asp:TextBox>
                    </td>
                </tr>--%>
                    <tr style="height: 50px; vertical-align: bottom;">
                        <td>
                            <asp:Button ID="btnCancel" runat="server" ValidationGroup="valComCan" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSubmit" ValidationGroup="valCom" runat="server" Text="Save Sales"
                                OnClick="btnSubmit_Click" />
                            <asp:Label ID="lblError" runat="server" ForeColor="Maroon"></asp:Label>
                        </td>
                    </tr>
                </table>
                </div>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
                ValidationGroup="valCom"></asp:CustomValidator>
                <asp:CustomValidator ID="cvtVal" runat="server" ClientValidationFunction="Val" ValidationGroup="valNP"></asp:CustomValidator>
                <asp:CustomValidator ID="cvtComAdd" runat="server" ClientValidationFunction="ValidateCompleteAdd"
                    ValidationGroup="valComAdd"></asp:CustomValidator>
                <asp:CustomValidator ID="cvtComCan" runat="server" ClientValidationFunction="ValidateCancel"
                    ValidationGroup="valComCan"></asp:CustomValidator>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
