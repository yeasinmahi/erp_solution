<%@ Page Language="C#" AutoEventWireup="true"  Theme="Theme1" Inherits="UI.SAD.Sales.DOEntryOOP" Codebehind="DOEntryOOP.aspx.cs" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hide
        {            display: none;
        }
        .show
        {
            display: block;
        }
    </style>

    <script type="text/javascript">
        function SetPrice() {
        var price = parseFloat(document.getElementById('lblPrice').value);
             //var price = "5";
        var logGain = parseFloat(document.getElementById('lblLogisGain').value);
        var qnt = parseFloat(document.getElementById('txtQun').value);
        var tot=0;
        
        if(!isNaN((price+logGain)*qnt)){ tot = ((price+logGain)*qnt); }        
        document.getElementById('lblTotal').innerText = tot;     
    }
    </script>

    <script type="text/javascript">    
    function ValidateCompleteAdd(sender, args){                        
        
        var flag=Val(sender, args);
        
        if(document.getElementById("hdnProduct").value == '' && flag){
            alert('Product not be blank');
            NotExec(args);
            flag=false;
        }
        
        if(document.getElementById("ddlUOM").options.value == '' && flag){
            alert('UOM is blank');
            NotExec(args);
            flag=false;
        }
        
        if(document.getElementById("ddlCurrency").options.value == '' && flag){
            alert('Currency is blank');
            NotExec(args);
            flag=false;
        }
        
        if(document.getElementById("txtQun").value == '' && flag){
            alert('Quantity not be blank');
            NotExec(args);
            flag=false;
        }        
        
        if(isNaN(document.getElementById("txtQun").value) && flag){
            alert('Put a number value in Quantity');
            NotExec(args);
            flag=false;
        }
        
        if(isNaN(document.getElementById("lblPrice").value) && flag){
            alert('Put a number value in price');
            NotExec(args);
            flag=false;
        }
        if(parseFloat(document.getElementById("lblPrice").value)<=0 && flag){
            alert('Put a price');
            NotExec(args);
            flag=false;
        }
        /*if(flag){
            document.getElementById("hdnPrice").value =  document.getElementById("lblPrice").value;
            document.getElementById("hdnVhlPrice").value =  document.getElementById("lblVhkPr").value;
            document.getElementById("hdnChrgPrice").value =  document.getElementById("lblExtPr").value;
        }*/
    }    
    function ValidateComplete(sender, args){                
        
        var flag=Val(sender, args);
        
        if(document.getElementById("txtChallan") != null && flag){
            if(document.getElementById("txtChallan").value == ''){
                if(!confirm('Do you want to go without challan no?')){
                NotExec(args);
                flag=false;
                }
            }           
        }
        
        if(flag && !confirm('Do you want to save?')){
            NotExec(args);
            flag=false;
        }
    }
    
    function Val(sender, args){           
        var flag=true;
                
        if(document.getElementById("txtDate") != null){
            if(document.getElementById("txtDate").value == ''){
                alert('Date not be blank');
                NotExec(args);
                flag=false;
            }
        }
        
        if(document.getElementById("txtCus") != null){
            if(document.getElementById("txtCus").value == ''){
                alert('Customer not be blank');
                NotExec(args);
                flag=false;
            }
        }
        
        if(document.getElementById("txtDis") != null && flag){
            if(document.getElementById("txtDis").value == ''){
                alert('Distribution Point not be blank');
                NotExec(args);
                flag=false;
            }
        }
        
        if(document.getElementById("txtAddress") != null && flag){
            if(document.getElementById("txtAddress").value == ''){
                alert('Address not be blank');
                NotExec(args);
                flag=false;
            }
        }
        
        if(document.getElementById("txtVehicle") != null && flag){
            if(document.getElementById("txtVehicle").value == ''){
                alert('Please select a vehicle');
                NotExec(args);
                flag=false;
            } 
        }
        
        if(document.getElementById("txtSupplier") != null && flag){
            if(document.getElementById("txtSupplier").value == ''){
                alert('Please select a supplier');
                NotExec(args);
                flag=false;
            } 
        }
        
        
        return flag;
    }    
    function ValidateCancel(sender, args){
        if(!confirm('Do you want to cancel?')){
            NotExec(args)
        } 
    }
    function NotExec(args){
        args.IsValid = false;
        isProceed = false;        
    }
    </script>

    <script type="text/javascript">        
     function DDLChange(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndex").value = document.getElementById(ddlID).options.value;        
     }
     function DDLChangeV(ddlID)
     {     
        document.getElementById("hdnDDLChangedSelectedIndexV").value = document.getElementById(ddlID).options.value;        
     }     
     
    </script>

   
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
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
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 450px; float: right;">
                    <asp:HiddenField ID="hdnsalestype" runat="server" />
                    <asp:HiddenField ID="hdnvisibility" runat="server" />
                    <asp:HiddenField ID="hdnLogisBasedOnUom" runat="server" />
                    <asp:HiddenField ID="hdnCharBasedOnUom" runat="server" />
                    <asp:HiddenField ID="hdnIncenBasedOnUom" runat="server" />
                    <asp:HiddenField ID="hdnCreditSales" runat="server" />
                    <asp:HiddenField ID="hdnLm" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnBl" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnUnit" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnXFactoryVhl" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnXFactoryChr" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnPrice" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnLogisGain" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVhlPrice" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnChrgPrice" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVhlMerge" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnChrgMerge" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnSuppTax" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVat" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVatPrice" Value="0" runat="server" />
                    <table style="width: 850px; height: 150px; background-color: #E0E0E0;">
                        <tr>
                            <td>
                                Unit
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.UnitOOP">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td>
                                Ship Point
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                    DataTextField="strName" DataValueField="intShipPointId" 
                                    ondatabound="ddlShip_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetShipPoint"
                                    TypeName="SAD_BLL.Global.ShipPoint" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="userId" SessionField="sesUserID" Type="String" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>                            
                            <td align="right">
                                Sales Office
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
                        </tr>
                        <tr>
                            <td align="left">
                                Type
                            </td>
                            <td align="left">
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
                            <td align="right">
                                Date
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Customer
                            </td>
                            <td colspan="3">
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCus" runat="server" AutoCompleteType="Search" Width="355px" OnTextChanged="txtCus_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCus"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td align="right">
                                <asp:Panel ID="pnlChallan" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                Info
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChallan" runat="server" Width="150px" TextMode="MultiLine" Visible="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlClCb" runat="server">
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td style="background-color: Maroon; color: White;">
                                                Limit
                                            </td>
                                            <td style="background-color: Maroon; color: White;">
                                                <asp:Label ID="lblLM" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                            <td style="width: 30px;">
                                            </td>
                                            <td style="background-color: Maroon; color: White;">
                                                Balance
                                            </td>
                                            <td style="background-color: Maroon; color: White;">
                                                <asp:Label ID="lblBl" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlDis" runat="server">
                            <tr>
                                <td style="width: 100px;">
                                    Dis. Point
                                </td>
                                <td colspan="4">
                                    <asp:HiddenField ID="hdnDis" runat="server" />
                                    <asp:HiddenField ID="hdnDisText" runat="server" />
                                    <asp:TextBox ReadOnly="true" ID="txtDis" runat="server" AutoCompleteType="Search"
                                        AutoPostBack="true" OnTextChanged="txtDis_TextChanged" Width="355px"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtDis"
                                        ServiceMethod="GetDisPointList" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                    </cc1:AutoCompleteExtender>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td colspan="3">
                                <asp:TextBox ReadOnly="true" ID="txtAddress" runat="server" TextMode="MultiLine"
                                    Width="350px"></asp:TextBox>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                           Driver
                                        </td>
                                        <td>
                                            ContactNo
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtDriver" runat="server" Width="250px" Visible="true"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDriverContact" runat="server" Visible="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 850px; background-color: #D0D0D0;">
                        <tr>
                            <td style="padding-top: 10px; vertical-align: top; width: 200px; height: 180px;">
                                <asp:HiddenField ID="hdnPriceId" runat="server" />
                                <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                <b style="color: Black;">PRICE VARIABLE</b>
                                <asp:Panel ID="pnlMain" runat="server" Visible="true">
                                </asp:Panel>
                                <br />
                                <b style="color: Green;">LOCATION VARIABLE</b>
                                <asp:HiddenField ID="hdnPriceIdV" runat="server" />
                                <asp:HiddenField ID="hdnDDLChangedSelectedIndexV" runat="server" />
                                <asp:Panel ID="pnlVehicle" runat="server" Visible="true">
                                </asp:Panel>
                            </td>
                            <td style="width: 300px; vertical-align: top;">
                                <table style="width: 300px; vertical-align: top;">
                                    <tr>
                                        <td>
                                            <b style="color: Green;">LOGISTIC</b>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoNeedVehicle_SelectedIndexChanged"
                                                RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Value="true">Yes</asp:ListItem>
                                                <asp:ListItem Value="false">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="pnlVehicleMain" runat="server">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="rdoVhlCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                    OnSelectedIndexChanged="rdoVhlCompany_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="true">Company</asp:ListItem>
                                                    <asp:ListItem Value="false">3rd Party</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Vehicle
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" Width="200px"
                                                    AutoPostBack="true" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtVehicle"
                                                    ServiceMethod="GetVehicleList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <table>
                                    <tr style="color: Maroon;">
                                        <td>
                                            <b>Charge</b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlExtra" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
                                                DataTextField="strText" DataValueField="intID" OnDataBound="ddlExtra_DataBound"
                                                OnSelectedIndexChanged="ddlExtra_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExtraChargeList"
                                                TypeName="SAD_BLL.Global.ExtraCharge">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                                        Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                    <tr style="color: Blue;">
                                        <td>
                                            <b>Incentive</b>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlIncentive" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource2"
                                                DataTextField="strText" DataValueField="intID" OnDataBound="ddlIncentive_DataBound"
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
                                    </tr>
                                </table>
                            </td>
                            <td style="width: 300px;">
                                <asp:Panel ID="pnlVehicle3rd" Visible="false" runat="server">
                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                Supplier
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" Width="200px"
                                                    AutoPostBack="true"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtSupplier"
                                                    ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Charge To
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdo3rdPartyCharge" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                    <asp:ListItem Value="false">Company</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVhlType" runat="server" AutoPostBack="True" DataSourceID="odsVhlType"
                                                    DataTextField="strType" DataValueField="intTypeId" OnSelectedIndexChanged="ddlVhlType_SelectedIndexChanged"
                                                    OnDataBound="ddlVhlType_DataBound">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsVhlType" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetVhlType" TypeName="LOGIS_BLL.Vehicle">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                                            PropertyName="SelectedValue" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <%--<b>EXTRA CHARGES</b>
                        <table>
                            <tr>
                                <td>
                                    Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txtExtra" runat="server" Width="105px"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Cause
                                </td>
                                <td align="right">
                                    <asp:TextBox ID="txtCause" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Other Info
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOther" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>--%>
                    <table style="width: 850px; background-color: #C0C0C0;">
                        <tr>
                            <td>
                                <b style="">Product</b>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnProduct" runat="server" />
                                <asp:HiddenField ID="hdnProductText" runat="server" />
                                <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                    AutoPostBack="true" OnTextChanged="txtProduct_TextChanged" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td style="color: Blue;">
                                <b>INC</b>
                            </td>
                            <td style="color: Blue;">
                                <asp:Label ID="lblIncPr" runat="server" Text="0.00"></asp:Label>
                            </td>
                            <td style="color: Maroon;">
                                <b>CHRG</b>
                            </td>
                            <td style="color: Maroon;">
                                <asp:TextBox ID="lblExtPr" Width="40px" runat="server" Text="0.00"></asp:TextBox>
                            </td>
                            <td style="color: Green;">
                                <b>LOG</b>
                            </td>
                            <td style="color: Green;">
                                <asp:TextBox ID="lblVhkPr" Width="40px" runat="server" Text="0.00"></asp:TextBox>
                            </td>
                            <td>
                                CUR
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                                    DataTextField="strCurrency" DataValueField="intID" AutoPostBack="True" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged"
                                    OnDataBound="ddlCurrency_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                                    TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                                <asp:TextBox ID="txtConvRate" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td style="color: Olive;">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="RadioButtonList1_DataBound"
                                    RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
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
                            <td>
                                UOM
                            </td>
                            <td>
                                Price
                            </td>
                            <td>
                                Log. Gain
                            </td>
                            <td>
                                Commission
                            </td>
                            <td>
                                Quantity
                            </td>
                            <td>
                                Total
                            </td>
                            <%--<td>
                                G. Total
                            </td>--%>
                            <td>
                                &nbsp;
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
                                        <asp:ControlParameter ControlID="RadioButtonList1" Name="salesType" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="txtDate" Name="date" PropertyName="Text" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="lblPrice" runat="server" Width="50px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="lblLogisGain" runat="server" Width="50px"></asp:TextBox>
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
            <div style="height: 470px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table style="width: 850px;">
                <tr>
                    <td colspan="3">
                        <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                            AutoGenerateColumns="False" CaptionAlign="Top" Caption="Sales Entry" ShowFooter="true" 
                            OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Pid" HeaderText="Pid" Visible="false" SortExpression="Pid" />
                                <asp:BoundField DataField="PName" HeaderText="Product Name" SortExpression="PName" />
                                <asp:TemplateField HeaderText="Qnt" SortExpression="Qnt">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Qnt") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetGrandTotal(2) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Pr" HeaderText="Price" ItemStyle-HorizontalAlign="Right"
                                    SortExpression="Pr" Visible="false">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LogisGain" HeaderText="Log. Gain" ItemStyle-HorizontalAlign="Right"
                                    SortExpression="LogisGain" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label Visible="false" ID="Label3" runat="server" Text='<%# GetTotal(""+Eval("Pr"), ""+Eval("LogisGain"), ""+Eval("Qnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label Visible="false" ID="Label4" runat="server" Text='<%# GetGrandTotal(5) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incentive">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# GetTotal(""+Eval("IncPr"), ""+Eval("Qnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" ForeColor="Blue" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Charge">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# GetTotal(""+Eval("ExtPr"), ""+Eval("Qnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" ForeColor="Maroon" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Logistic">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# GetTotal(""+Eval("Logis"), ""+Eval("Qnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" ForeColor="Green" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label Visible="false" ID="Label8" runat="server" Text='<%# GetTotal(""+Eval("ExtPr"),""+Eval("Logis"), ""+Eval("Qnt"), ""+Eval("IncPr")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label Visible="false" ID="Label9" runat="server" Text='<%# GetGrandTotal(9) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Promo">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Prom") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comm">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("Comm") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="G. Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label Visible="false" ID="Label10" runat="server" Text='<%# GetFullTotal(""+Eval("Pr"), ""+Eval("LogisGain"), ""+Eval("Qnt"), ""+Eval("ExtPr"), ""+Eval("Logis"), ""+Eval("IncPr")  ) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label Visible="false" ID="Label11" runat="server" Text='<%# GetGrandTotal(12) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="">
                                        <img alt=""  src="../../Content/images/icons/Delete.png" style="border: 0px;" title="Delete"/>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UomTxt" HeaderText="UomTxt" ItemStyle-CssClass="hide"
                                    HeaderStyle-CssClass="hide" SortExpression="UomTxt" >
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="False" EnableViewState="False"
                            runat="server"></asp:XmlDataSource>
                    </td>
                </tr>
                <tr style="height: 50px; vertical-align: bottom;">
                    <td style="vertical-align: middle;">
                        Narration
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNarration" runat="server" Height="48px" TextMode="MultiLine"
                            Width="670px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 50px; vertical-align: bottom;">
                    <td>
                        <asp:Button ID="btnCancel" runat="server" ValidationGroup="valComCan" OnClick="btnCancel_Click"
                            Text="Cancel" />
                    </td>
                    <td align="right">
                    </td>
                    <td align="right">
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
