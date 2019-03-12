<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTRouteCostUpdate.aspx.cs" Inherits="UI.Transport.InternalTRouteCostUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

    <script>
        function InEntry(reqsid) {
            window.open('InternalTransportRouteExpInEntry.aspx?intID=' + reqsid, 'sub', "height=600, width=800, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
        }
        function FuelCostOut(reqsid) {
            window.open('InternalTransportExtimatedExp.aspx?intID=' + reqsid, 'sub', "height=600, width=800, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
        }
        function TripDetails(reqsid) {
            window.open('InternalTTripDetails.aspx?intID=' + reqsid, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
        }
        function TripComplete(reqsid) {
            window.open('VendorTTripCompleteEntry.aspx?intID=' + reqsid, 'sub', "height=570, width=720, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> CUSTOMER AND SHIPPOINT WISE ROUTE COST UPDATE FORM<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server"></asp:DropDownList>                                                                       
            </td>                        
        </tr>

        </table>

        </div>

        <div>
            <table class="tbldecoration" style="width:auto; float:left;">
                <tr><td> <hr /></td></tr>
                <tr><td style="font-weight:bold; font-size:11px; color:#3369ff;">REPORT FOR UPDATE<hr /></td></tr>
                <tr>
                    <td><asp:GridView ID="dgvTripWiseCustomer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="costid" SortExpression="reffid" Visible="false"><ItemTemplate>
                    <asp:Label ID="lblReffIDG" runat="server" Text='<%# Bind("intID") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                          








                    <asp:TemplateField HeaderText="custid" SortExpression="intCustomerID" Visible="false"><ItemTemplate>
                    <asp:Label ID="lblCustIDG" runat="server" Text='<%# Bind("intCustomerID") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Customer Name" SortExpression="strName"><ItemTemplate>
                    <asp:Label ID="lblCustNameG" runat="server" Text='<%# Bind("strName") %>' Width="200px"></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>
                        
                    <asp:TemplateField HeaderText="Millage" SortExpression="intMillage"><ItemTemplate>
                    <asp:TextBox ID="txtMillageG" runat="server" CssClass="txtBox" Text='<%# Bind("intDistanceKMOneWay") %>' TextMode="Number" Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare" SortExpression="monTripFare"><ItemTemplate>
                    <asp:TextBox ID="txtTripFareG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Open Truck" SortExpression="monTripFareOpenTruck"><ItemTemplate>
                    <asp:TextBox ID="txtTFOpentruckG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFareOpenTruck") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Covered Van" SortExpression="monTripFareCoveredVan"><ItemTemplate>
                    <asp:TextBox ID="txtTFCoveredVanG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFareCoveredVan") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare Pickup" SortExpression="monTripFarePickup"><ItemTemplate>
                    <asp:TextBox ID="txtTFPickupG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFarePickup") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Trip Fare 10 Ton" SortExpression="monTripFare10Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF10TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare10Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 7 Ton" SortExpression="monTripFare7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare7Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 5 Ton" SortExpression="monTripFare5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare5Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 3 Ton" SortExpression="monTripFare3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtTF3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare3Tone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Trip Fare 1.5 Ton" SortExpression="monTripFare1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtTF1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monTripFare1AndHalfTone") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll" SortExpression="monBridgeAndRoadToll"><ItemTemplate>
                    <asp:TextBox ID="txtBridgeTollG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeAndRoadToll") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 20 Ton" SortExpression="monBridgeToll20Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll20TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll20Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 10 Ton" SortExpression="monBridgeToll10Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll10TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll10Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 7 Ton" SortExpression="monBridgeToll7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll7Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge & Road Toll 5 Ton" SortExpression="monBridgeToll5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll5Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 3 Ton" SortExpression="monBridgeToll3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll3Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bridge & Road Toll 2 Ton" SortExpression="monBridgeToll2Ton"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll2TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll2Ton") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Bridge &amp; Road Toll 1 &amp; Half Ton" SortExpression="monBridgeToll1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtBnRToll1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monBridgeToll1AndHalfTone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll" SortExpression="monFerryEXP"><ItemTemplate>
                    <asp:TextBox ID="txtFerryTollG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryEXP") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 20 Ton" SortExpression="monFerryToll20Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT20TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll20Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 7 Ton" SortExpression="monFerryToll7Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT7TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll7Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 5 Ton" SortExpression="monFerryToll5Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT5TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll5Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Ferry Toll 3 Ton" SortExpression="monFerryToll3Tone"><ItemTemplate>
                    <asp:TextBox ID="txtFT3TonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFerryToll3Tone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Ferry Toll 1 & Half Ton" SortExpression="monFarryToll1AndHalfTone"><ItemTemplate>
                    <asp:TextBox ID="txtFT1AndHalfTonG" runat="server" CssClass="txtBox" Text='<%# Bind("monFarryToll1AndHalfTone") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr style="background-color:lightgray">
                    <td><asp:Button ID="btnUpdate" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" Text="Update" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click" /></td>
                </tr>
            </table>
        </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
