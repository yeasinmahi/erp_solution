<%@ Page Language="C#" AutoEventWireup="true" Inherits="UI.SAD.Transfer.FGTransfer" Codebehind="FGTransfer.aspx.cs" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head id="Head1" runat="server">
    <title>Untitled Page</title>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
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
        .hide
        {
            display: none;
        }
    </style>
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
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>                
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 210px; float: right;">
                    
                    <asp:HiddenField ID="hdnUnit" Value="0" runat="server" />
                    <asp:HiddenField ID="hdnDDLChangedSelectedIndexV" Value="" runat="server" />

                    <table style="width: 850px; background-color: #E0E0E0;">
                        <tr>
                            <td style="width: 80px;">
                                Unit
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
                            <td align="right">
                                From
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShip" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource4"
                                    DataTextField="strName" DataValueField="intShipPointId" 
                                    OnDataBound="ddlShip_DataBound">
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
                            <td align="right">
                                To
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShipOther" runat="server" AutoPostBack="True" DataSourceID="ods2"
                                    DataTextField="strName" DataValueField="intId" OnDataBound="ddlShipOther_DataBound"
                                    OnSelectedIndexChanged="ddlShipOther_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ods2" runat="server" SelectMethod="GetShipPointExceptThis"
                                    TypeName="SAD_BLL.Global.ShipPoint" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                            Type="String" />
                                        <asp:ControlParameter ControlID="ddlShip" Name="shipPointId" 
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>                           
                        </tr>
                    </table>
                    <table style="width: 850px; height: 40px; background-color: #FFF0F0;">
                        <tr>
                            <td style="width: 80px;">
                                Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" Enabled="false" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender2" runat="server">
                                </cc1:CalendarExtender>
                                <img runat="server" id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td align="right" style="width: 200px;">
                                Requested Delivery Time
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
                             <td>
                                Contact At
                            </td>
                            <td>
                                <asp:TextBox ID="txtContact" runat="server" Width="350px"></asp:TextBox>
                            </td>
                            <td>
                                Phone
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtPhone" runat="server"  Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"
                                    Width="350px"></asp:TextBox>
                            </td>
                            <td>
                                Remarks
                            </td>
                            <td align="right">
                                <asp:TextBox ID="txtOther" runat="server" Width="250px" TextMode="MultiLine"></asp:TextBox>
                            </td>
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
                                    AutoPostBack="true" OnTextChanged="txtProduct_TextChanged" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
                                    ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>                                                                                   
                            <td>
                                CUR
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCurrency" runat="server" DataSourceID="ObjectDataSource3"
                                    DataTextField="strCurrency" DataValueField="intID"
                                    OnDataBound="ddlCurrency_DataBound">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetCurrencyInfo"
                                    TypeName="SAD_BLL.Item.Currency"></asp:ObjectDataSource>
                            </td>                           
                        </tr>
                    </table>
                    <table style="width: 850px;">
                        <tr style="background-color: #B0B0B0; text-align: center;">
                            <td>
                                UOM
                            </td>                            
                            <td>
                                Quantity
                            </td>                                                 
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="background-color: #B0B0B0;">
                            <td>
                                <asp:HiddenField ID="hdnUOM" runat="server" />
                                <asp:DropDownList ID="ddlUOM" runat="server" DataSourceID="odsUOM" 
                                    DataTextField="strUOMShow" DataValueField="intSellingUOM">
                                </asp:DropDownList>                               
                                <asp:ObjectDataSource ID="odsUOM" runat="server" SelectMethod="GetItemUOM" 
                                    TypeName="SAD_BLL.Item.ItemUnitOfMeasurement">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="hdnProduct" Name="itemId" PropertyName="Value" 
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>                            
                            <td align="center" style="vertical-align: middle;">
                                <asp:TextBox ID="txtQun" runat="server" Width="60px"></asp:TextBox>
                                &nbsp;
                            </td>  
                            <td>
                            <asp:RadioButtonList ID="rdoSalesType" runat="server" DataSourceID="ObjectDataSource5"
                                    DataTextField="strTypeName" DataValueField="intTypeID" OnDataBound="rdoSalesType_DataBound"
                                    AutoPostBack="true"
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
                            <td align="right">
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="valComAdd" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 230px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table style="width: 850px;">
                <tr>
                    <td colspan="3">
                        <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                            AutoGenerateColumns="False" CaptionAlign="Top" Caption="Product Transfer" ShowFooter="True"
                            OnRowDeleting="GridView1_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Pid" HeaderText="Pid" Visible="false" SortExpression="Pid" />
                                <asp:TemplateField HeaderText="Product Name" SortExpression="PName" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("PName") %>'></asp:Label>
                                    </ItemTemplate>                                                                        
                                </asp:TemplateField>                                 
                                <asp:TemplateField HeaderText="UOM" SortExpression="UomTxt" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("UomTxt") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Qnt" SortExpression="ApprQnt" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ApprQnt") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQnty" runat="server" Text='<%# Bind("ApprQnt") %>'></asp:TextBox>
                                    </EditItemTemplate>   
                                    <FooterTemplate>
                                        <asp:Label ID="Label4" runat="server" Text="<%# GetGrandTotal(3) %>"></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />              
                                </asp:TemplateField>                                                                                         
                                <asp:TemplateField ShowHeader="False">                                   
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                            Text="">
                                        <img alt=""  src="../../App_Themes/<%# this.Theme %>/Icons/Delete.png" style="border: 0px;" title="Delete"/>
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