<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Order.SalesOrder" Codebehind="SalesOrder.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    function SetPriceJS(){
        var price = parseFloat(document.getElementById('txtPrice').value);        
        var qnt = parseFloat(document.getElementById('txtQun').value);
        var tot=0;
        
        if(!isNaN(price*qnt)){
            tot = (price*qnt);
        }
        
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
        
        if(isNaN(document.getElementById("txtPrice").value) && flag){
            alert('Put a number value in price');
            NotExec(args);
            flag=false;
        }
        if(parseFloat(document.getElementById("txtPrice").value)<=0&& flag){
            alert('Put a price');
            NotExec(args);
            flag=false;
        }
        /*if(flag){
            document.getElementById("hdnPrice").value =  document.getElementById("txtPrice").value;
            document.getElementById("hdnVhlPrice").value =  document.getElementById("lblVhkPr").value;
            document.getElementById("hdnChrgPrice").value =  document.getElementById("txtCharge").value;
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

    <style type="text/css">
        .hide
        {
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
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 340px; float: right;">
                    <asp:HiddenField ID="hdnPriceVariable" runat="server" />
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
                    <table style="width: 900px;">
                        <tr>
                            <td>
                                <table width="100%" style="background-color: #F0F0FF">
                                    <tr>
                                        <td style="width: 80px;">
                                            Unit
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                                DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                                OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" 
                                                TypeName="HR_BLL.Global.Unit" OldValuesParameterFormatString="original_{0}">
                                                <SelectParameters>
                                                    <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                        <td style="width: 100px; text-align: right;">
                                            Ship Point
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                                DataTextField="strName" DataValueField="intShipPointId">
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
                                        <td style="width: 100px; text-align: right;">
                                            Sales Office
                                        </td>
                                        <td align="right">
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
                                        <td style="width: 100px; text-align: right;">
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
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 75px;" valign="bottom">
                                <table width="100%" style="background-color: #E0E0EE">
                                    <asp:Panel ID="pnlDisPoint" runat="server" Visible="false">                                    
                                        <tr>
                                            <td style="width: 80px;">
                                                Del. Point
                                            </td>
                                            <td colspan="5">
                                                <asp:HiddenField ID="hdnDis" runat="server" />
                                                <asp:HiddenField ID="hdnDisText" runat="server" />
                                                <asp:TextBox ID="txtDis" runat="server" AutoCompleteType="Search" AutoPostBack="true"
                                                    OnTextChanged="txtDis_TextChanged" Width="355px"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtDis"
                                                    ServiceMethod="GetDisPointList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td style="width: 80px;">
                                            Customer
                                        </td>
                                        <td style="width: 350px;">
                                            
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
                                        <asp:Panel runat="server" ID="pnlCr">
                                            <td style="color: Red;">
                                                <b>Limit:</b>
                                            </td>
                                            <td style="color: Red;">
                                                <asp:Label ID="lblLM" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                            <td align="right" style="color: Maroon;">
                                                <b>Balance:</b>
                                            </td>
                                            <td style="color: Maroon;">
                                                <asp:Label ID="lblBl" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                            <td align="right" style="color: Navy;">
                                                <b>Pending:</b>
                                            </td>
                                            <td style="color: Navy;">
                                                <asp:Label ID="lblPN" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <td>
                                            Location
                                        </td>
                                        <td>
                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                        </td>
                                        <asp:Panel runat="server" ID="pnlCrGrp">
                                            <td>
                                                <b style="color: Blue;">Group: </b>
                                            </td>
                                            <td colspan="5" style="color: Blue;">
                                                <asp:Label ID="lblGroup" runat="server"></asp:Label>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 60px;" valign="bottom">
                                <table width="100%" style="background-color: #E0E0E0">
                                    <tr>
                                        <td style="width: 80px;">
                                            Address
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="250px" Height="40px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
                                                        Contact Person
                                                    </td>
                                                    <td>
                                                        Phone
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtContact" runat="server" Width="250px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;" valign="middle">
                                <table width="100%" style="background-color: #E0E0EE">
                                    <tr>
                                        <td style="width: 80px;">
                                            Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                                PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server">
                                            </cc1:CalendarExtender>
                                            <img runat="server" id="imgCal_1" src="../../Content/images/img/calbtn.gif"
                                                style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td style="width: 200px; text-align: right;">
                                            Appr. Delivery Time
                                        </td>
                                        <td style="width:170px;">
                                            <asp:TextBox ID="txtDelDate" runat="server" AutoPostBack="True" autocomplete="off"></asp:TextBox>
                                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDelDate" Format="dd/MM/yyyy"
                                                PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server">
                                            </cc1:CalendarExtender>
                                            <img runat="server" id="imgCal_2" src="../../Content/images/img/calbtn.gif"
                                                style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                        </td>
                                        <td style="width:30px;">
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
                                        <td>
                                            <asp:DropDownList ID="ddlAP" runat="server">
                                                <asp:ListItem Text="AM" Value="am" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="PM" Value="pm"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="900px" style="background-color: #E0E0E0">
                        <tr>
                            <td style="width: 80px;">
                                <b style="color: Green;">LOGISTIC</b>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="true">Yes</asp:ListItem>
                                    <asp:ListItem Value="false">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 70px; text-align: right;">
                                <b style="color: Green;">Currency</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                                    DataTextField="strCurrency" DataValueField="intID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                                    TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                                <asp:TextBox ID="txtConvRate" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td style="width: 90px; text-align: right;">
                                <b style="color: Green;">Sales Type</b>
                            </td>
                            <td style="color: Olive;">
                                <asp:RadioButtonList ID="rdoSalesType" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="strTypeName" DataValueField="intTypeID" RepeatDirection="Horizontal"
                                    OnDataBound="rdoSalesType_DataBound">
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
                        <tr>
                            <td style="width: 80px;">
                                <b style="color: Green;">Charge</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCharge" runat="server" DataSourceID="ObjectDataSource1"
                                    DataTextField="strText" DataValueField="intID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExtraChargeList"
                                    TypeName="SAD_BLL.Global.ExtraCharge">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td style="width: 70px; text-align: right;">
                                <b style="color: Green;">Incentive</b>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIncentive" runat="server" DataSourceID="ObjectDataSource2"
                                    DataTextField="strText" DataValueField="intID">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetIncentiveList"
                                    TypeName="SAD_BLL.Global.Incentive">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            <td style="width: 70px; text-align: right;">
                                <b style="color: Green;">Promotion</b>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblPromo"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table style="width: 900px; background-color: #D0D0D0;">
                                <tr>
                                    <td>
                                       Product
                                    </td>                                    
                                    <td>
                                        UOM
                                    </td>
                                    <td>
                                        Charge
                                    </td>
                                     <td>
                                        Incentive
                                    </td>
                                     <td>
                                        Commission
                                    </td>
                                    <td>
                                        Price
                                    </td>
                                    <td>
                                        Quantity
                                    </td>
                                    <td>
                                        Total
                                    </td>
                                </tr>
                                <tr>
                                    
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
                                                <asp:ControlParameter ControlID="hdnPriceVariable" Name="priceVariable" PropertyName="Value"
                                                    Type="String" />
                                                <asp:ControlParameter ControlID="rdoSalesType" Name="salesType" PropertyName="SelectedValue"
                                                    Type="String" />
                                                <asp:ControlParameter ControlID="txtDate" Name="date" PropertyName="Text" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtCharge" Width="40px" runat="server" Text="0.00"></asp:TextBox>
                                    </td>
                                   
                                    <td>
                                        <asp:TextBox ID="txtIncPr" Width="40px" runat="server" Text="0.00"></asp:TextBox>
                                    </td>
                                   
                                    <td>
                                        <asp:TextBox ID="txtCommission" Width="40px" runat="server" Text="0.00"></asp:TextBox>
                                    </td>
                                    
                                    <td align="center">
                                        <asp:TextBox ID="txtPrice" runat="server" Width="50px"></asp:TextBox>
                                    </td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtQun" runat="server" Width="62px"></asp:TextBox>
                                    </td>                                    
                                    <td align="center" style="text-align: right;">
                                        <asp:Label ID="lblTotal" Text="0" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </asp:Panel>
            <div style="height: 3600px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table style="width: 850px;">
                <tr>
                    <td colspan="3">
                       <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                            AutoGenerateColumns="False" CaptionAlign="Top" Caption="Sales Entry" ShowFooter="True" 
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
                                    SortExpression="Pr" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LogisGain" HeaderText="Log. Gain" ItemStyle-HorizontalAlign="Right"
                                    SortExpression="LogisGain" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# GetTotal(""+Eval("Pr"), ""+Eval("LogisGain"), ""+Eval("Qnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# GetGrandTotal(5) %>'></asp:Label>
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
                                        <asp:Label ID="Label8" runat="server" Text='<%# GetTotal(""+Eval("ExtPr"),""+Eval("Logis"), ""+Eval("Qnt"), ""+Eval("IncPr")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# GetGrandTotal(9) %>'></asp:Label>
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
                                        <asp:Label ID="Label10" runat="server" Text='<%# GetFullTotal(""+Eval("Pr"), ""+Eval("LogisGain"), ""+Eval("Qnt"), ""+Eval("ExtPr"), ""+Eval("Logis"), ""+Eval("IncPr")  ) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# GetGrandTotal(12) %>'></asp:Label>
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
