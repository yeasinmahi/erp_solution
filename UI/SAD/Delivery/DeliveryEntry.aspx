<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryEntry.aspx.cs" Inherits="UI.SAD.Delivery.DeliveryEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <style type="text/css">
        .ajax__calendar_inactive {
            color: #dddddd;
        }

        .txtBox {
        }

        .auto-style1 {
            width: 814px;
        }

        .auto-style2 {
            width: 820px;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;
            if ((charCode > 57))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        function SetPrice(txt) {
            var price = parseFloat(document.getElementById('txtPrice').value);

            var qnt = parseFloat(document.getElementById('txtQun').value);
            var invStock = parseFloat(document.getElementById('hdnInventoryStock').value);
            var rdoDeliveryType = document.getElementById("rdoDeliveryType");
            var type = rdoDeliveryType.SelectedValue; 

            var tot = 0;
            if (qnt <= invStock && type=='2') {
                alert('Pleae Check Inventory Stock')
            }
            if (!isNaN((price) * qnt)) { tot = ((price) * qnt); }
            document.getElementById('lblTotal').innerText = tot;
        }

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
    </script>
    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
            } else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }
        }
        function autoCompleteEx_ItemSelected(sender, args) {
            document.getElementById("hdnItemSeleced").value = "Selected";
        }
    </script>


</head>

<body>

    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>

                <div style="height: 30px;"></div>

                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnDA" runat="server" />
                    <asp:HiddenField ID="hdnsalestype" runat="server" />
                    <asp:HiddenField ID="hdnvisibility" runat="server" />
                    <asp:HiddenField ID="hdnLogisBasedOnUom" runat="server" />
                    <asp:HiddenField ID="hdnCharBasedOnUom" runat="server" />
                    <asp:HiddenField ID="hdnWHId"  Value="0" runat="server" />
                    <asp:HiddenField ID="hdnCreditSales" runat="server" />
                    <asp:HiddenField ID="hdnWHName" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnBl" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnInventoryStock" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnInvItemId" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnnarration" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnPrice" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnLogisGain" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVhlPrice" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnDoId" Value="0" runat="server" />
                     
                    <asp:HiddenField ID="hdnSuppTax" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVat" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnVatPrice" Value="0" runat="server" />
                    <div class="tabs_container">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdoDeliveryType" ForeColor="maroon" Font-Bold="True" runat="server" Width="200px" AutoPostBack="True"
                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoDeliveryType_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="1">DO</asp:ListItem>
                                        <asp:ListItem Value="2">Picking</asp:ListItem>
                                        <asp:ListItem Value="3">Delivery</asp:ListItem>
                                        <asp:ListItem Value="4">Return</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                    <asp:Label runat="server" ID="lblDoCustId" Visible="False" Text="DO/Customer"></asp:Label></td>
                                <td>
                                    <asp:TextBox runat="server" ForeColor="Red" Visible="False" ID="txtDoNumber" AutoPostBack="true" OnTextChanged="txtDoNumber_TextChanged"></asp:TextBox></td>
                                <td>
                                    <asp:Label runat="server" ID="lblCodeText" Visible="False" Text="Code: "></asp:Label></td>
                                <td>
                                    <asp:Label runat="server" ID="lblCode"></asp:Label></td>
                                <td>
                                    <asp:Label runat="server" ID="lblOrderIDText" Visible="False" Text="Order ID: "></asp:Label></td>
                                <td>
                                    <asp:Label runat="server" ID="lblOrderId"></asp:Label></td>
                            </tr>
                        </table>

                        <hr />
                    </div>
                    <table style="width: 850px">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblUnitName" runat="server" CssClass="lbl" Text="Unit Name:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>



                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" Font-Bold="False" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblSalesOffice" runat="server" CssClass="lbl" Text="Sales Office:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlSalesOffice" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSalesOffice_SelectedIndexChanged"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Customer Type:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCustomerType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged"></asp:DropDownList>

                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Date:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtBox" EnableCaching="false" autocomplete="off" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="text-align: left;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Due Date:"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox" autocomplete="off" EnableCaching="false" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" StartDate="<%# DateTime.Today %>" EndDate="<%# DateTime.Now.AddYears(1) %>" Format="yyyy-MM-dd" TargetControlID="txtDueDate">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Customer: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:HiddenField ID="hdnCustomer" runat="server" />
                                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                                <asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtCustomer_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCustomer" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Ship To Party: "></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:HiddenField ID="hdnShipToPartyId" runat="server" />
                                <asp:HiddenField ID="hdnShipToPartyText" runat="server" />
                                <asp:TextBox ID="txtShipToParty" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtShipToParty_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtShipToParty" OnClientItemSelected="autoCompleteEx_ItemSelected"
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <%-- <td style="text-align: right;">
                                        <asp:Label ID="lblReffInfo" CssClass="lbl" runat="server" Text="Reff Info: "></asp:Label> 
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:TextBox ID="TextBox2" runat="server"   CssClass="txtBox"   ></asp:TextBox>
                                    </td>--%>
                        </tr>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Address: "></asp:Label>
                            </td>
                            <td style="text-align: left;" colspan="1">
                                <asp:TextBox ID="txtCustomerAddress" runat="server" TextMode="MultiLine" EnableCaching="false" CssClass="txtBox" Width="300px"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Address: "></asp:Label>
                            </td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtShipToPartyAddress" TextMode="MultiLine" runat="server" EnableCaching="false" CssClass="txtBox" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <hr />
                    <asp:Panel ID="pnlLogistic" runat="server" Visible="True">

                        <table style="width: 400px; vertical-align: top;">
                            <tr>

                                <td>
                                    <b style="color: Green;">LOGISTIC</b>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdoNeedVehicle" runat="server" Width="120px" AutoPostBack="True"
                                        RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoNeedVehicle_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="2">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                        </table>

                        <table>
                            <tr>
                                 <td colspan="2">
                                                    <asp:RadioButtonList ID="rdoVehicleCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoVehicleCompany_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="1">Company</asp:ListItem>
                                                        <asp:ListItem Value="2">Rent</asp:ListItem>
                                                        <asp:ListItem Value="3">Customer</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                            </tr>
                            <tr>
                                <td style="width: 300px; vertical-align: top;">
                                    <asp:HiddenField ID="hdnPriceId" runat="server" />
                                    <asp:Panel ID="pnlVehicleMain" runat="server" Visible="True">
                                        <table style="width: 500px;"> 
                                            <tr>
                                                <td style="text-align: right">Vehicle </td>
                                                <td>
                                                    <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                    <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                    <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" AutoPostBack="true" CssClass="txtBox" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetVehicleList" TargetControlID="txtVehicle">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                                  <td>Supplier </td>
                                                <td>
                                                    <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" AutoPostBack="true" Width="200px"></asp:TextBox>
                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetSupplierList" TargetControlID="txtSupplier">
                                                    </cc1:AutoCompleteExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">Driver </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtDriver" runat="server" CssClass="txtBox" Visible="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">ContactNo </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtDriverContact" runat="server" CssClass="txtBox"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="pnlVehicle3rd" runat="server" Visible="False">
                                        <table style="width: 300px;">


                                        </table>
                                    </asp:Panel>
                                </td>



                            </tr>
                        </table>

                    </asp:Panel>

                    <hr />
                    <table>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="color: maroon">CUR
                            </td>
                            <td style="color: green;">
                                <asp:DropDownList ID="ddlCurrency" runat="server">
                                </asp:DropDownList>

                                <asp:TextBox ID="txtConvRate" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td style="color: Olive;">
                                <asp:RadioButtonList ID="rdoSalesType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdoSalesType_SelectedIndexChanged">
                                </asp:RadioButtonList>
                            </td>
                            <td>Reff No
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtReffNo"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnProductAddAll" runat="server" Text="Add-All" ValidationGroup="valComAdd" OnClick="btnProductAddAll_Click" />

                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" ValidationGroup="valCom" runat="server" Text="Save Sales"
                                    OnClick="btnSubmit_Click" OnClientClick="return funConfirmAll()"/>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr style="background-color: #B0B0B0; text-align: center;">
                            <td style="color: Green;">Product</td>
                            <td>UOM</td>
                            <td>Price</td>
                            <td id="location" runat="server">Location</td>
                            <td>Commission</td>
                            <td style="color: Red;">Quantity</td>
                            <td>Total</td>
                            <td style="color: Green;">Action</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdnProduct" runat="server" />
                                <asp:HiddenField ID="hdnProductText" runat="server" />
                                <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" Width="250px"
                                    AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnUOM" runat="server" />
                                <asp:DropDownList ID="ddlUOM" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUOM_SelectedIndexChanged">
                                </asp:DropDownList>

                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtPrice" runat="server" Width="50px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblComm" runat="server"></asp:Label>
                            </td>
                            <td align="center" style="vertical-align: middle;">
                                <asp:TextBox ID="txtQun" runat="server" AutoPostBack="False" onkeyup="SetPrice(this);" Width="60px" OnTextChanged="txtQun_TextChanged"></asp:TextBox>
                                &nbsp;
                            </td>
                            <td align="center" style="text-align: right;">
                                <asp:Label ID="lblTotal" Text="0" runat="server"></asp:Label>
                            </td>

                            <td align="right">
                                <asp:Button ID="btnProductAdd" runat="server" Text="Add" AutoPostBack="false" OnClick="btnProductAdd_Click" OnClientClick="return ProductValidation()" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvSales" CssClass="GridWithPrint" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" OnRowDeleting="dgvGridView_RowDeleting"
                                    OnRowCancelingEdit="dgvSales_RowCancelingEdit" OnRowEditing="dgvSales_RowEditing" OnRowUpdating="dgvSales_RowUpdating"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="25px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product ID" SortExpression="productId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdutId" runat="server" Text='<%# Bind("productId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="productName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("productName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="uomName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUoM" runat="server" Text='<%# Bind("uomName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="UomId" ItemStyle-HorizontalAlign="right" Visible="false" SortExpression="uomId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUomId" runat="server" Text='<%# Bind("uomId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commision" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="commision">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCommision" runat="server" Text='<%# Bind("commision") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        
                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqty" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQtyEdit" runat="server" Text='<%# Bind("quantity") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="priceTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# GetPriceTotal(""+Eval("rate"), ""+Eval("quantity")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Total Discount" ItemStyle-HorizontalAlign="right" SortExpression="discountTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("discountTotal","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grand Total" ItemStyle-HorizontalAlign="right" SortExpression="discountTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandtoal" runat="server" DataFormatString="{0:0.00}" Text='<%# GetTotal(""+Eval("priceTotal"), ""+Eval("discountTotal")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Update"
                                                    Text="">
                                                    <img alt=""  src="../../Content/images/icons/Save.png" style="border: 0px;"
                                                         title="Update" />
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel"
                                                    Text="">
                                                    <img alt="" height="20px" width="20px" src="../../Content/images/icons/132.png" style="border: 0px;"
                                                         title="Cancel" />
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Edit"
                                                    Text="">
                                                    <img alt="" src="../../Content/images/icons/edit.gif" style="border: 0px;"
                                                         title="Edit" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                            <ControlStyle Font-Bold="True" ForeColor="Red" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>

                                <%--  <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="False" EnableViewState="False"
                      runat="server"></asp:XmlDataSource>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvSalesPicking" CssClass="GridWithPrint" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" OnRowDeleting="dgvSalesPicking_RowDeleting"
                                    OnRowCancelingEdit="dgvSalesPicking_RowCancelingEdit" OnRowEditing="dgvSalesPicking_RowEditing" OnRowUpdating="dgvSalesPicking_RowUpdating"
                                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">

                                    <AlternatingRowStyle BackColor="#CCCCCC" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="25px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Product ID" SortExpression="productId">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdutId" runat="server" Text='<%# Bind("productId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="productName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProductName" runat="server" Text='<%# Bind("productName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Narration" SortExpression="naration" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnaration" runat="server" Text='<%# Bind("naration") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="uomName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUoM" runat="server" Text='<%# Bind("uomName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="right" SortExpression="rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("rate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Currency" SortExpression="currency" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcurrency" runat="server" Text='<%# Bind("currency") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commision" SortExpression="commision" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcommision" runat="server" Text='<%# Bind("commision") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Commision Total" SortExpression="commisionTotal" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcommisionTotal" runat="server" Text='<%# Bind("commisionTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Discount" SortExpression="discount" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscount" runat="server" Text='<%# Bind("discount") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>


                                          <asp:TemplateField HeaderText="DiscountTotal" SortExpression="discountTotal" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldiscountTotal" runat="server" Text='<%# Bind("discountTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Price Total" SortExpression="priceTotal" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpriceTotal" runat="server" Text='<%# Bind("priceTotal") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Supplier Tax" SortExpression="supplierTax" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsupplierTax" runat="server" Text='<%# Bind("supplierTax") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vat" SortExpression="vat" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvat" runat="server" Text='<%# Bind("vat") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vat Price" SortExpression="vatPrice" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvatPrice" runat="server" Text='<%# Bind("vatPrice") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion ItemId" SortExpression="promtionItemId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionItemId" runat="server" Text='<%# Bind("promtionItemId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion Item" SortExpression="promtionItem" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionItem" runat="server" Text='<%# Bind("promtionItem") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion Uom" SortExpression="promtionUom" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionUom" runat="server" Text='<%# Bind("promtionUom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion ItemCoaId" SortExpression="promtionItemCoaId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionItemCoaId" runat="server" Text='<%# Bind("promtionItemCoaId") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion Qnty" SortExpression="promtionQnty" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionQnty" runat="server" Text='<%# Bind("promtionQnty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Promtion ItemUom" SortExpression="promtionItemUom" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpromtionItemUom" runat="server" Text='<%# Bind("promtionItemUom") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="narr" SortExpression="narr" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblnarr" runat="server" Text='<%# Bind("narr") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="center" SortExpression="Location">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("location") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlLocations" runat="server" AutoPostBack="True"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqty" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQtyEdit" runat="server" Text='<%# Bind("quantity") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="priceTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotal" runat="server" Text='<%# GetPriceTotal(""+Eval("rate"), ""+Eval("quantity")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Total Discount" ItemStyle-HorizontalAlign="right" SortExpression="discountTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("discountTotal","{0:n2}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grand Total" ItemStyle-HorizontalAlign="right" SortExpression="discountTotal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblGrandtoal" runat="server" DataFormatString="{0:0.00}" Text='<%# GetTotal(""+Eval("priceTotal"), ""+Eval("discountTotal")) %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Update"
                                                    Text="">
                                                    <img alt=""  src="../../Content/images/icons/Save.png" style="border: 0px;"
                                                         title="Update" />
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel"
                                                    Text="">
                                                    <img alt="" height="20px" width="20px" src="../../Content/images/icons/132.png" style="border: 0px;"
                                                         title="Cancel" />
                                                </asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit"
                                                    Text="">
                                                    <img alt="" src="../../Content/images/icons/edit.gif" style="border: 0px;"
                                                         title="Edit" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true">
                                            <ControlStyle Font-Bold="True" ForeColor="Red" />
                                        </asp:CommandField>
                                    </Columns>
                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>

                                <%--  <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="False" EnableViewState="False"
                      runat="server"></asp:XmlDataSource>--%>
                            </td>
                        </tr>

                    </table>

                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnProductAdd" EventName="Click" />
                <%--<asp:PostBackTrigger ControlID="btnEdit" />--%>
                 <%--<asp:PostBackTrigger ControlID="btnUpdateFinal" />--%>
            </Triggers>
        </asp:UpdatePanel>
    </form>


    <script type="text/javascript">
        //debugger;
        //$(document).ready(function () {
        //    radioChange();
        //    $('#rdoDeliveryType input').change(function () {
        //        radioChange();
        //    });
        //});
        //function radioChange() {
        //    var radioValue = $('#rdoDeliveryType input:checked');
        //    var gridPiking = $('#dgvSalesNew');
        //    var location = document.getElementById("location").value;
        //    var locationValue = document.getElementById("ddlLocation").value;

        //    if (radioValue.val() == 2) {
        //        gridPiking.show();
        //        location.show();
        //        locationValue.show();

        //    } else {
        //        gridPiking.hide();
        //        location.hide();
        //        locationValue.hide();
        //    }

        //}
        function ProductValidation() {
            debugger;
            var customer = document.getElementById("txtCustomer").value;
            var currency = document.getElementById("ddlCurrency").value;
            var currencyRate = document.getElementById("txtConvRate").value;
            var product = document.getElementById("txtProduct").value;
            var price = document.getElementById("txtPrice").value;
            var quantity = document.getElementById("txtQun").value;
            if (customer === null || customer === "") {
                ShowNotification('Enter Customer', 'DeliveryEntry', 'warning');
                return false;
            }
            else if (product === null || product === "") {
                ShowNotification('Enter Product', 'DeliveryEntry', 'warning');
                return false;
            }
            else if (price === null || price === "") {
                ShowNotification('Enter Price', 'DeliveryEntry', 'warning');
                return false;
            }
            else if (quantity === null || quantity === "") {
                ShowNotification('Enter quantity', 'DeliveryEntry', 'warning');
                return false;
            }
            else if (currency === null || currency === "") {
                ShowNotification('Enter Currency', 'DeliveryEntry', 'warning');
                return false;
            }
            else if (currencyRate === null || currencyRate === "") {
                ShowNotification('Enter Currency Rate', 'DeliveryEntry', 'warning');
                return false;
            }
            return true;
        }

    </script>
</body>
</html>
