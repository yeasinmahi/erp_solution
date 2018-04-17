<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleInOutCustomize.aspx.cs" Inherits="UI.SAD.Logistic.VehicleInOutCustomize" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title></title>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ValidateIn(sender, args) {
            if (document.getElementById("txtVehicle").value == '') {
                alert('Please enter a vehicle');
                args.IsValid = false;
                isProceed = false;
            }
            else if (document.getElementById("txtSupplier") != null && document.getElementById("hdnSpCs").value == '') {
                alert('Please enter supplier / customer');
                args.IsValid = false;
                isProceed = false;
            }
            else if (document.getElementById("txtDO").value != '' && document.getElementById("hdnDo").value == '') {
                alert('Please check the DO');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Is this vehicle checked In?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }

        function ValidateOut(sender, args) {
            if (!confirm('Is this vehicle checked out?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
            <br /><br />
            <table align="center" style="width: 650px; vertical-align: top;">
                <tr>
                    <td align="left">
                        Unit
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
                    <td align="right">
                        Ship Point
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
                </tr>
            </table>
            <br />
            <table align="center" style="width: 650px; height: 200px; vertical-align: top; background-color: #E0E0FF">
                <tr>
                    <td colspan="4" align="center">
                        <b style="color: Navy; font-size: 20px;">I N</b>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px;" align="left">
                        <b style="color: Green;">LOGISTIC BY</b>
                    </td>
                    <td style="width: 270px;" colspan="3">
                        <b style="color: Green;">
                            <asp:RadioButtonList ID="rdoVhlCompany" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                OnSelectedIndexChanged="rdoVhlCompany_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="c">Company</asp:ListItem>
                                <asp:ListItem Value="p">Rented</asp:ListItem>
                                <asp:ListItem Value="s">Customer</asp:ListItem>
                            </asp:RadioButtonList>
                        </b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Vehicle No</b>
                    </td>
                    <td colspan="2">
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
                    <td>
                        <asp:Button ID="btnIn" Visible="false" runat="server" ValidationGroup="valIn" OnClick="btnIn_Click"
                            Text="Check In" Height="30px" Width="200px" BackColor="Green" ForeColor="White"
                            Font-Size="17px" Font-Bold="true" />
                    </td>
                </tr>                
                <tr>
                    <td><b style="color: Maroon">DO No.</b></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hdnDo" runat="server" Value="" />
                                <asp:TextBox ID="txtDO" runat="server" Width="100px"></asp:TextBox>
                                <asp:LinkButton ID="lnkChk" runat="server" onclick="lnkChk_Click">Check</asp:LinkButton>
                                &nbsp;&nbsp;<asp:Image ID="imgChk" Visible="false" Width="16px" Height="16px" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <b style="color: Maroon">Driver</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDriver" runat="server" Width="200px"></asp:TextBox>
                    </td>                   
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Driver Lisence</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLisence" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <b style="color: Maroon">Healper</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHelper" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Driver N.ID</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNid" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <b style="color: Maroon">Contact No.</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContact" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <asp:Panel ID="pnlKM" runat="server">
                    <tr>
                        <td>
                            <b style="color: Maroon">Meter Reading</b>
                        </td>
                        <td>
                            <asp:TextBox ID="txtkm" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
                <asp:Panel ID="pnlVehicle3rd" Visible="false" runat="server">
                    <tr>
                        <td>
                            <asp:Label ID="lblSupp" Font-Bold="true" ForeColor="Maroon" runat="server" Text="Supplier"></asp:Label>
                        </td>
                        <td>
                            <asp:HiddenField ID="hdnSpCs" Value="" runat="server" />
                            <asp:HiddenField ID="hdnSpCsText" runat="server" />
                            <asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" Width="200px"
                                AutoPostBack="true" OnTextChanged="txtSupplier_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtSupplier"
                                ServiceMethod="GetSupplierList" MinimumPrefixLength="1" CompletionSetCount="1"
                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                            </cc1:AutoCompleteExtender>
                        </td>
                        <td>
                            <b style="color: Maroon">Type</b>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVhlType" ForeColor="Maroon" Font-Bold="true" runat="server"
                                DataSourceID="odsVhlType" DataTextField="strType" 
                                DataValueField="intTypeId">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsVhlType" runat="server" OldValuesParameterFormatString="original_{0}"
                                SelectMethod="GetVhlType" TypeName="LOGIS_BLL.Vehicle">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                        Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td>
                        <b style="color: Maroon">Loading Capacity</b>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCapacity" runat="server" Width="80px"></asp:TextBox>
                        <asp:DropDownList ID="ddlUOMWgt" runat="server" DataSourceID="ObjectDataSource1"
                            DataTextField="strUOM" DataValueField="intID">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetWeightUOM"
                            TypeName="SAD_BLL.Item.ItemUnitOfMeasurement">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlUnit" Name="unitId" PropertyName="SelectedValue"
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <b style="color: #FF0000">Message</b>
                    </td>
                    <td>
                        <asp:Label ID="lblCode" ForeColor="#FF0000" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:CustomValidator ID="cvtIn" runat="server" ClientValidationFunction="ValidateIn"
                ValidationGroup="valIn"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <table align="center" style="width: 650px; vertical-align: top; background-color: #B0B0BB">
                <tr>
                    <td colspan="3" align="center">
                        <b style="color: Navy; font-size: 20px;">O U T</b>
                    </td>
                </tr>
                <tr>
                    <td style="width: 160px;">
                        <b style="color: Maroon">Search By Vehicle</b>
                        <td>
                            <asp:TextBox ID="txtVehicleOut" AutoPostBack="true" runat="server"
                                Width="200px" OnTextChanged="txtVehicleOut_TextChanged"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicleOut"
                                ServiceMethod="GetVehicleOutList" MinimumPrefixLength="1" CompletionSetCount="1"
                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                            </cc1:AutoCompleteExtender>
                        </td>
                        <td style="vertical-align: top">
                            <asp:Button ID="btnOut" Visible="false" runat="server" Text="Check Out" OnClick="btnOut_Click"
                                Height="30px" Width="200px" ValidationGroup="valOut" BackColor="Maroon" ForeColor="White"
                                Font-Size="17px" Font-Bold="true" />
                        </td>
                </tr>
                <tr>
                    <td style="width: 130px;">
                        <b style="color: Maroon">Trip No</b>
                        <td>
                            <asp:HiddenField ID="hdnTrip" runat="server" />
                            <asp:TextBox ID="txtTrip" runat="server" Width="200px"></asp:TextBox>
                            <asp:Button ID="btnGo" runat="server" OnClick="btnGo_Click" Text="GO" />
                        </td>
                        <td>
                        </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Driver</b>
                    </td>
                    <td style="background-color: #FFFFFF" colspan="2">
                        <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b style="color: Maroon">Healper</b>
                    </td>
                    <td style="background-color: #FFFFFF" colspan="2">
                        <asp:Label ID="lblHealper" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <b style="color: Maroon">Brand Issue Number</b>
                    </td>
                    <td style="background-color: #FFFFFF" colspan="2">
                       <asp:HiddenField ID="hdnBrnadIssueNumber" runat="server" />
                            <asp:TextBox ID="txtBrandIssue" BackColor="#ffffcc" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td style="width: 130px;">
                        <b style="color: Maroon">Status</b>
                    </td>
                    <td style="background-color: #FFFFFF" colspan="2">
                        <asp:Panel ID="pnlStat" runat="server" Visible="false">
                            <asp:Label ID="lblError" Font-Bold="true" Font-Size="13px" ForeColor="Red" runat="server"
                                Text=""></asp:Label>
                            <table style="width: 470px">
                                <tr>
                                    <td colspan="4" style="color: Olive; font-weight: bold; background-color: #E0E0E0;
                                        text-align: center;">
                                        W E I G H T
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="background-color: #E0E0E0">
                                        Unloaded
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        Goods
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        Loaded
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        Diffarence
                                    </td>
                                    <td rowspan="2">
                                        <asp:Image ID="imgSignal" ImageUrl="" Width="70px" Height="70px" runat="server" />
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="background-color: #E0E0E0">
                                        <asp:Label ID="lblUnLoad" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        <asp:Label ID="lblGoods" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        <asp:Label ID="lblLoad" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="background-color: #E0E0E0">
                                        <asp:Label ID="lblDiff" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                               
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

                 <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="grdvchallanchecking" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="d" HeaderText="Challan" SortExpression="d" />
                                            <asp:BoundField DataField="f" HeaderText="Count" SortExpression="f" />
                                            <asp:BoundField DataField="e" HeaderText="Qnt" SortExpression="e" />
                                         </Columns>
                                        </asp:GridView>
                                    </td>
                                    
                                </tr>


            </table>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateOut"
                ValidationGroup="valOut"></asp:CustomValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
