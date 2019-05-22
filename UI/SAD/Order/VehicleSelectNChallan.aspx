<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleSelectNChallan.aspx.cs" Inherits="UI.SAD.Order.VehicleSelectNChallan" %>

<%--<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/CommonStyle.css" rel="stylesheet" />

    <script type="text/javascript">
        function ValidateSet(sender, args) {
            if (document.getElementById("hdnVehicle").value == '') {
                alert('Please enter a vehicle');
                args.IsValid = false;
                isProceed = false;
            }
            else if (document.getElementById("hdnEdit").value != '') {
                alert('Please update.');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Do you want to set this vehicle?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
    <script type="text/javascript">
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'chln', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script>
        function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
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
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdnUnit" Value="0" runat="server" />
                <asp:HiddenField ID="hdnCustomer" runat="server" />
                <asp:HiddenField ID="hdnCustomerText" runat="server" />
                <asp:HiddenField ID="hdnLogVar" runat="server" />
                <asp:HiddenField ID="hdnPriceVar" runat="server" />
                <asp:HiddenField ID="hdnDate" runat="server" />
                <asp:HiddenField ID="hdnSOid" runat="server" />
                <asp:HiddenField ID="hdnCurrency" runat="server" />
                <asp:HiddenField ID="hdnAmount" runat="server" />
                <asp:HiddenField ID="hdnGain" runat="server" />
                <asp:HiddenField ID="hdnUom" runat="server" />
                <asp:HiddenField ID="hdnCharge" runat="server" />
                <asp:HiddenField ID="hdnIncentive" runat="server" />
                <asp:HiddenField ID="hdnShipPoint" runat="server" />
                <asp:HiddenField ID="hdnSalesType" runat="server" />
                <asp:HiddenField ID="hdnDoCode" runat="server" />
                <asp:HiddenField ID="hdnEdit" Value="" runat="server" />
                <asp:HiddenField ID="hdnoutstandingamount" runat="server" />
                <asp:HiddenField ID="hdnUndelvProductRate" runat="server" />
                <asp:HiddenField ID="hdnXFactoryVhl" Value="0" runat="server" />
                <asp:HiddenField ID="hdnSupplierName" runat="server" />
                <asp:HiddenField ID="hdnSuppliercoaid" runat="server" />
                
                   <asp:HiddenField ID="hdnLm" runat="server" />
                   <asp:HiddenField ID="hdnBl" runat="server" />
                  <asp:HiddenField ID="hdnCreditSales" runat="server" />
                <div class="container">
                    <td style="width: 300px;">

                        <table style="width: 850px; background-color: #D0D0D0;">
                            <tr>
                                <td style="padding-top: 10px; vertical-align: top; width: 200px; height: 180px;">
                                    <asp:HiddenField ID="hdnPriceId" runat="server" />
                                    <asp:HiddenField ID="hdnDDLChangedSelectedIndex" runat="server" />
                                    <b style="color: lime;">
                                        <asp:Label ID="lblcreatechallan" runat="server" Font-Bold="true" Text="Challan No:  "></asp:Label></b>
                                    <asp:Label ID="lblchallanval" runat="server" Font-Bold="true"></asp:Label>
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
                                            <td>Vehicle
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" Width="200px"
                                                    AutoPostBack="true" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicle"
                                                    ServiceMethod="GetVehicleList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td>Driver
                                            </td>
                                            <td>ContactNo
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
                                <td style="width: 300px;">

                                    <table style="width: 300px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblunit" runat="server" Text="Unit"></asp:Label>
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
                                            <td>
                                                <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" Width="200px"
                                                    AutoPostBack="true"></asp:TextBox>
                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSupplier"
                                                    ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                </cc1:AutoCompleteExtender>--%>

                                                <asp:DropDownList ID="ddlSupllier" runat="server" DataSourceID="odsUnitvsSupplier" DataTextField="strsupplier" DataValueField="intsupplierid"></asp:DropDownList>


                                                <asp:ObjectDataSource ID="odsUnitvsSupplier" runat="server" SelectMethod="getSupplierList" TypeName="SAD_BLL.Sales.VehicleSelect">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>


                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblchargeto" runat="server" Text="Charge To"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                    <asp:ListItem Value="false">Company</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                             <td>Type
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVhlType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVhlType_SelectedIndexChanged"
                                                    OnDataBound="ddlVhlType_DataBound" DataSourceID="odsvhcltyep" DataTextField="strType" DataValueField="intTypeId">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="odsvhcltyep" runat="server" SelectMethod="GetVhlType" TypeName="LOGIS_BLL.Vehicle">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="unitId" SessionField="sesUnit" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <%--<asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
                                                    SelectMethod="GetVhlType" TypeName="LOGIS_BLL.Vehicle">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlUnit" Name="unitId" 
                                                            PropertyName="SelectedValue" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>--%>
                                            </td>

                                           
                                        </tr>
                                        <tr>
                                            <td style="color: Red;">
                                                <b>L: </b>
                                            </td>
                                            <td align="right" style="color: Red;">
                                                <asp:Label ID="lblLM" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" style="color: Maroon;">
                                                <b>O: </b>
                                            </td>
                                            <td align="left" style="color: Maroon;">
                                                <asp:Label ID="lblBl" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" style="color: Navy;">
                                                <b>P: </b>
                                            </td>
                                            <td style="color: Navy;">
                                                <asp:Label ID="lblPN" runat="server" Text="0.0"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                        </table>



                    </td>
                    <table width="100%">
                        <tr>
                            <td style="vertical-align: top;">

                                <table style="width: 600px; vertical-align: top;">
                                    <tr>
                                        <td>
                                            <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                                                AutoGenerateColumns="False" CaptionAlign="Top" Caption="Delivery Order" ShowFooter="True"
                                                OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                                <Columns>
                                                    <%--<asp:BoundField DataField="Pid" HeaderText="Pid" Visible="true" SortExpression="Pid" />--%>
                                                    <asp:TemplateField HeaderText="Pid">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPid" runat="server" Text='<%# Eval("Pid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Product Name" SortExpression="PName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("PName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qnt" SortExpression="Qnt">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Qnt") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtQnty" Width="50px" runat="server" Text='<%# Bind("Qnt") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text="<%# GetGrandTotal(2) %>"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UOM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("UomTxt") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <%--       <asp:TemplateField HeaderText="Promotion Product" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# decimal.Parse(""+Eval("Prom"))==0?"":""+Eval("PromItem") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>--%>


                                                    <asp:TemplateField HeaderText="Specifications">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnstrTermsNCondition" runat="server" Value='<%# Eval("Narr") %>' />
                                                            <asp:Label ID="lblSpecifications" runat="server" Text='<%# Bind("Narr") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="P. Qnt" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# decimal.Parse(""+Eval("Prom"))==0?"":""+Eval("Prom") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text="<%# GetGrandTotal(5) %>"></asp:Label>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="P. UOM" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# decimal.Parse(""+Eval("Prom"))==0?"":""+Eval("PromUomText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

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
                                                    <asp:BoundField DataField="PromItemCOA" HeaderText="Pid" Visible="false" SortExpression="PromItemCOA" />


                                                </Columns>
                                            </asp:GridView>
                                            <asp:XmlDataSource ID="XmlDataSource1" EnableCaching="False" EnableViewState="False"
                                                runat="server"></asp:XmlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnSubmit" ValidationGroup="valOut" runat="server" Text="Assign Vehicle" 
                                                OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <%--    <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateSet" OnClientClick="showLoader()"
                            ValidationGroup="valOut"></asp:CustomValidator>--%>
                            </td>
                            <td style="vertical-align: top; background-color: #F6F6FF"></td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<cc2:ScriptReferenceProfiler ID="ScriptReferenceProfiler1" runat="server" />--%>
    </form>
</body>
</html>
