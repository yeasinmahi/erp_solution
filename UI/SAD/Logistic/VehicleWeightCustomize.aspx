<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleWeightCustomize.aspx.cs" Inherits="UI.SAD.Logistic.VehicleWeightCustomize" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title></title>

     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" /> 
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function ShowPopUpE(url) {
            var rand_no = Math.floor(11 * Math.random());
            url = url + '&rnd=' + rand_no;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=550,width=750,top=70,left=220');
            if (window.focus) { newwindow.focus() }
        }
        function ValidateCalculate(sender, args) {
            if (document.getElementById("txtWeight").value == '' 
                    || document.getElementById("txtWeight").value == '0'
                    || isNaN(document.getElementById("txtWeight").value)) {
                alert('Enter a valid weight');
                args.IsValid = false;
                isProceed = false;
            }
        }
        function ValidateComplete(sender, args) {
            if (document.getElementById("txtWeight").value == ''
                    || document.getElementById("txtWeight").value == '0'
                    || isNaN(document.getElementById("txtWeight").value)) {
                alert('Enter a valid weight');
                args.IsValid = false;
                isProceed = false;
            }
            else if (!confirm('Is this vehicle weight ' + document.getElementById("txtWeight").value + '?')) {
                args.IsValid = false;
                isProceed = false;
            }
        }

        function GetWeight(sender, args) {
            var x = new ActiveXObject("AcTry.MyActiveX");
            var obj = document.getElementById("txtWeight");

            var val = x.GetWeight();
            if (val == '') {
                alert('Weight Bridge is out of order');                            
            }
            else {                
                obj.value = val;
            }
            args.IsValid = true;
            isProceed = true;
        }

    </script>
</head>
<body>
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnTrip" runat="server" />
            <asp:HiddenField ID="hdnUn" runat="server" />
            <asp:HiddenField ID="hdnLd" runat="server" />
            <asp:HiddenField ID="hdnGd" runat="server" />
            <asp:HiddenField ID="hdnTw" runat="server" />
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 330px; float: right;">
                    <br />
                    <table align="center" style="width: 500px; vertical-align: top;">
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
                    <table align="center" style="width: 500px; vertical-align: top; background-color: #E0E0FF">
                        <tr>
                            <td colspan="2" align="center">
                                <b style="color: Navy; font-size: 20px;">WEIGHT MACHINE</b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 130px;">
                                <b style="color: Maroon">Vehicle No</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtVehicleOut" AutoPostBack="true" runat="server" AutoCompleteType="Search"
                                    Width="365px" OnTextChanged="txtVehicleOut_TextChanged"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtVehicleOut"
                                    ServiceMethod="GetVehicleOutList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b style="color: Maroon">Trip No</b>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTrip" runat="server" Width="365px" AutoPostBack="True" OnTextChanged="txtTrip_TextChanged"></asp:TextBox>
                                <asp:Label ID="lblChallan" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b style="color: Maroon">Driver</b>
                            </td>
                            <td style="background-color: #FFFFFF">
                                <asp:Label ID="lblDriver" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b style="color: Maroon">Healper</b>
                            </td>
                            <td style="background-color: #FFFFFF">
                                <asp:Label ID="lblHealper" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b style="color: Maroon">Status</b>
                            </td>
                            <td style="background-color: #FFFFFF">
                                <asp:Label ID="lblStat" Font-Size="20px" Font-Bold="true" ForeColor="Navy" runat="server"
                                    Text=""></asp:Label>
                                <asp:Panel ID="pnlStat" runat="server" Visible="false">
                                    <table style="width: 370px">
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
                                        <tr>
                                            <td style="color: Olive; font-weight: bold;">
                                                Signal
                                            </td>
                                            <td>
                                                <asp:Image ID="imgSignal" ImageUrl="" Width="70px" Height="70px" runat="server" />
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblRemarks" Font-Size="10px" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <asp:Panel ID="pnlButton" runat="server" Visible="false">
                            <tr>
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td style="width: 115px">
                                                <b style="color: Maroon">Weight</b>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtWeight" runat="server" Width="100px"></asp:TextBox>
                                                <%--<asp:Button ID="btnAxWgt" ValidationGroup="val" runat="server" Text="O" OnClick="btnAxWgt_Click"/>
                                                <asp:CustomValidator ID="cvt" runat="server" ClientValidationFunction="GetWeight"
                                                    ValidationGroup="val"></asp:CustomValidator>--%>
                                            </td>
                                            <td>
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
                                                <asp:Button ID="btnCal" ValidationGroup="valCal" runat="server" Text="Get Decision"
                                                    OnClick="btnCal_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnWeight" ValidationGroup="valCom" runat="server" Text="Take Weight"
                                                    OnClick="btnWeight_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                    <br />
                    <br />
                    <table align="center" style="width: 400px; vertical-align: top;">
                        <tr>
                            <td style="width: 100%;" align="center">
                                <asp:Label ID="lblError" Font-Bold="true" ForeColor="Red" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
            </asp:Panel>
            <div style="height: 350px;">
            </div>
            <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </cc1:AlwaysVisibleControlExtender>
            <table align="center" style="width: 800px; vertical-align: top;">
                <tr>
                    <td style="width: 100%;" align="center">
                        <asp:GridView ID="GridView1" SkinID="sknGrid1" runat="server" AutoGenerateColumns="False"
                            CaptionAlign="Top" Caption="Vehicle Calling List" DataKeyNames="intId" DataSourceID="ObjectDataSource3">
                            <Columns>
                                <asp:BoundField DataField="strCode" HeaderText="Code" SortExpression="strCode" />
                                <asp:BoundField DataField="strRegNo" HeaderText="Vehicle Reg No" SortExpression="strRegNo" />                                
                                <asp:BoundField DataField="strDriver" HeaderText="Driver" SortExpression="strDriver" />
                                <asp:BoundField DataField="strContact" HeaderText="Contact" SortExpression="strContact" />
                                <asp:BoundField DataField="strHelperName" HeaderText="Helper" SortExpression="strHelperName" />
                                <asp:BoundField DataField="dteInTime" HeaderText="Gate In Time" SortExpression="dteInTime" />
                            </Columns>
                            <RowStyle HorizontalAlign="Left" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetDataForWeightBridge"
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
            <asp:CustomValidator ID="cvtCal" runat="server" ClientValidationFunction="ValidateCalculate"
                ValidationGroup="valCal"></asp:CustomValidator>
            <asp:CustomValidator ID="cvtCom" runat="server" ClientValidationFunction="ValidateComplete"
                ValidationGroup="valCom"></asp:CustomValidator>
            <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick" />
        </ContentTemplate>
    </asp:UpdatePanel>       
        <cc2:ScriptReferenceProfiler ID="ScriptReferenceProfiler1" runat="server" />
    </form>     
    
    <%--<object id="compWgt" name="compWgt" classid="clsid:5511143C-FBF1-4BF4-8EE6-03ACBEAB9145"
            viewastext codebase="WeightBridge.ini">--%>

</body>
</html>