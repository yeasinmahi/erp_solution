<%@ Page Language="C#" Theme="Theme1" AutoEventWireup="true" Inherits="UI.SAD.Order.VehicleSelect" Codebehind="VehicleSelect.aspx.cs" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title></title>
    
      <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="~/Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />

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
            <table width="100%">
                <tr>
                    <td style="vertical-align: top;">
                        <table>
                            <tr>
                                <td style="height: 100px; vertical-align: top;">
                                    <table style="width: 600px; vertical-align: middle;">
                                        <tr style="height: 30px; vertical-align: top;">
                                            <td style="width: 50px;" align="left">
                                                <b style="color: Green;">BY</b>
                                            </td>
                                            <td style="width: 300px;">
                                                <asp:RadioButtonList ID="rdoVhlCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                    OnSelectedIndexChanged="rdoVhlCompany_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True" Value="c">Company</asp:ListItem>
                                                    <asp:ListItem Value="p">Rented</asp:ListItem>
                                                    <asp:ListItem Value="s">Customer</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <b style="color: Blue;">O.Balance: </b> &nbsp;
                                                <asp:label id="lblundelvvalue" runat="server" Text="0.0" ></asp:label>&nbsp;&nbsp;
                                                 <b style="color: Blue;">Status: </b> &nbsp;
                                                <asp:label id="lblmsg" runat="server" ></asp:label>
                                            </td>
                                            <td style="width: 50px;">
                                                <b style="color: Green">Vehicle</b>
                                            </td>
                                            <td style="width: 200px;">
                                                <table style=" font-size:10px; color:Green">
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:HiddenField ID="hdnVehicle" runat="server" />
                                                            <asp:HiddenField ID="hdnVehicleText" runat="server" />
                                                            <asp:TextBox ID="txtVehicle" runat="server" AutoCompleteType="Search" Width="220px"
                                                                AutoPostBack="true" OnTextChanged="txtVehicle_TextChanged"></asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtVehicle"
                                                                ServiceMethod="GetVehicleList" MinimumPrefixLength="1" CompletionSetCount="1"
                                                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                                            </cc1:AutoCompleteExtender>
                                                        </td>
                                                    </tr>
                                                    <tr style="background-color:#F0F0FF">
                                                        <td>Capacity</td>
                                                        <td><asp:Label ID="lblC" runat="server" Text=""></asp:Label></td>                                                        
                                                    </tr>
                                                    <tr>
                                                        <td>Loaded</td>
                                                        <td>
                                                            <asp:Label ID="lblL" runat="server" Text=""></asp:Label></td>
                                                        <td>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td>WB In</td>
                                                        <td>
                                                            <asp:Label ID="lblWb" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2"><asp:Label ID="lblChallan" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 30px; vertical-align: middle;">
                                            <td colspan="2">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <b style="color: Maroon">Charge</b>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlExtra" runat="server" DataSourceID="ObjectDataSource1" DataTextField="strText"
                                                                DataValueField="intID" OnDataBound="ddlExtra_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetExtraChargeList"
                                                                TypeName="SAD_BLL.Global.ExtraCharge">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdnUnit" Name="unitId" PropertyName="Value" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                        <td>
                                                            <b style="color: Maroon">Incentive</b>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlIncentive" runat="server" DataSourceID="ObjectDataSource3"
                                                                DataTextField="strText" DataValueField="intID" OnDataBound="ddlIncentive_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetIncentiveList"
                                                                TypeName="SAD_BLL.Global.Incentive">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="hdnUnit" Name="unitId" PropertyName="Value" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <asp:Panel ID="pnlVehicle3rd" Visible="false" runat="server">
                                                <td>
                                                    <b style="color: Maroon">To</b>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdo3rdPartyCharge" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Value="true">3rd Party</asp:ListItem>
                                                        <asp:ListItem Value="false">Company</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </asp:Panel>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 600px; vertical-align: top;">
                            <tr>
                                <td>
                                    <asp:GridView SkinID="sknGrid1" ID="GridView1" runat="server" DataSourceID="XmlDataSource1"
                                        AutoGenerateColumns="False" CaptionAlign="Top" Caption="Delivery Order" ShowFooter="True"
                                        OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                                        <Columns>
                                            <asp:BoundField DataField="Pid" HeaderText="Pid" Visible="false" SortExpression="Pid" />
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
                                              
                                            <%--<asp:TemplateField HeaderText="Price" SortExpression="Pr">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Pr") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# GetTotal(""+Eval("Pr"), ""+Eval("ApprQnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label7" runat="server" Text="<%# GetGrandTotal(4) %>"></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Incentive">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# GetTotal(""+Eval("IncPr"), ""+Eval("ApprQnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" ForeColor="Blue" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Charge">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# GetTotal(""+Eval("ExtPr"), ""+Eval("ApprQnt")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" ForeColor="Maroon" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# GetTotal(""+Eval("ExtPr"), ""+Eval("ApprQnt"), ""+Eval("IncPr")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# GetGrandTotal(7) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Promotion Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# decimal.Parse(""+Eval("Prom"))==0?"":""+Eval("PromItem") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="P. Qnt">
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
                                            <asp:TemplateField HeaderText="P. UOM">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label9" runat="server" Text='<%# decimal.Parse(""+Eval("Prom"))==0?"":""+Eval("PromUomText") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Comm">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("Comm") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="G. Total">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# GetFullTotal(""+Eval("Pr"), ""+Eval("ApprQnt"), ""+Eval("ExtPr"),  ""+Eval("IncPr")  ) %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# GetGrandTotal(10) %>'></asp:Label>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </asp:TemplateField
                               
                                <asp:BoundField DataField="UomTxt" HeaderText="UomTxt" ItemStyle-CssClass="hide"
                                    HeaderStyle-CssClass="hide" SortExpression="UomTxt">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>>--%>
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
                            <tr>
                                <td align="right">
                                    <asp:Button ID="btnSubmit" ValidationGroup="valOut" runat="server" Text="Assign Vehicle"
                                        OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateSet"
                            ValidationGroup="valOut"></asp:CustomValidator>
                    </td>
                    <td style="vertical-align: top; background-color: #F6F6FF">
                        <table width="100%" align="center" style="background-color: #505050;">
                            <tr>
                                <td style="font-size: 12px; color: #FFFFFF;">
                                    <b>Priority Legent</b>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" BackColor="YellowGreen" ForeColor="Black" Height="13px"
                                        HorizontalAlign="Center" Width="50px">
                                        High
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" BackColor="Yellow" ForeColor="Black" Height="13px"
                                        HorizontalAlign="Center" Width="50px">
                                        Mid
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" BackColor="LightPink" ForeColor="Black" Height="13px"
                                        HorizontalAlign="Center" Width="50px">
                                        Low
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel4" runat="server" BackColor="Red" ForeColor="Black" Height="13px"
                                        HorizontalAlign="Center" Width="50px">
                                        No
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 500px; overflow: auto;">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Caption="Vehicle List"
                                CaptionAlign="Top" DataSourceID="ObjectDataSource2" OnRowDataBound="GridView2_RowDataBound"
                                SkinID="sknGrid1">
                                <Columns>
                                    <asp:BoundField DataField="intTripId" HeaderText="intTripId" SortExpression="intTripId"
                                        Visible="false" />
                                    <asp:BoundField DataField="intVehicleId" HeaderText="intVehicleId" SortExpression="intVehicleId"
                                        Visible="false" />
                                    <asp:TemplateField HeaderText="Reg. No" SortExpression="strRegNo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtn" runat="server" CommandArgument='<%# Eval("strRegNo")+" ["+Eval("intVehicleId")+"]" %>'
                                                ForeColor="Black" OnClick="lnkBtn_Click" Text='<%# Eval("strRegNo") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="numCapacity" HeaderText="Capacity" ItemStyle-HorizontalAlign="Right"
                                        SortExpression="numCapacity" />
                                    <asp:BoundField DataField="numLoaded" HeaderText="Loaded" ItemStyle-HorizontalAlign="Right"
                                        SortExpression="numLoaded" />
                                    <asp:BoundField DataField="intPriority" HeaderStyle-CssClass="hide" HeaderText="intPriority"
                                        ItemStyle-CssClass="hide" SortExpression="intPriority"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetTripAssignVehicleList" TypeName="LOGIS_BLL.Trip.TripCall">
                                <SelectParameters>
                                    <asp:SessionParameter Name="xml" SessionField="sesXML" Type="String" />
                                    <asp:ControlParameter ControlID="hdnUnit" Name="unitID" PropertyName="Value" Type="String" />
                                    <asp:ControlParameter ControlID="hdnShipPoint" Name="shipPointId" PropertyName="Value"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="hdnSOid" Name="salesOrderId" PropertyName="Value"
                                        Type="String" />
                                    <asp:ControlParameter ControlID="rdoVhlCompany" Name="type" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
        <cc2:ScriptReferenceProfiler ID="ScriptReferenceProfiler1" runat="server" />
    </form>
</body>
</html>
