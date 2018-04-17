<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTransportRouteExpIn.aspx.cs" Inherits="UI.Transport.InternalTransportRouteExpIn" %>
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
        
        <div class="tabs_container"> VEHICLE TRIP COST ENTRY FORM<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>                        
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblReport" runat="server" CssClass="lbl" Text="Report Type :"></asp:Label></td>                
            <td>
                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="true" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Report For Out Entry</asp:ListItem><asp:ListItem Value="2">Report For In Entry</asp:ListItem></asp:DropDownList>
            </td>  
            
            <td style="text-align:right;"><asp:Label ID="lblSearchBuyerReff" runat="server" CssClass="lbl" Text="Trip SL No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchTripSLNo" runat="server" CssClass="txtBox"></asp:TextBox></td>                                       
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblBill" CssClass="lbl" runat="server" Text="Vehicle : "></asp:Label></td>
            <td><asp:RadioButton ID="rdoWon" runat="server" Checked="true" Text="Own" OnCheckedChanged="rdoWon_CheckedChanged" AutoPostBack="true" />
            <asp:RadioButton ID="rdoRented" runat="server" Text="Rented" OnCheckedChanged="rdoRented_CheckedChanged"  AutoPostBack="true"  /></td>
        </tr>
                   
        <tr>
            <td colspan="2" style="text-align:left;"><asp:Button ID="btnSearchTripList" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnSearchTripList_Click"/></td>
            <td colspan="2" style="text-align:left;"><asp:Button ID="btnSearchTripWise" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Search Trip Wise" OnClick="btnSearchTripWise_Click"/></td>
        </tr>
            
        </table>
        </div>

        <div >  
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="20px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                            
            <asp:TemplateField HeaderText="intid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intid" >
            <ItemTemplate><asp:Label ID="lblTripID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="dteDate" HeaderText="Out Date" ItemStyle-HorizontalAlign="Center"  SortExpression="dteDate">
            <ItemStyle HorizontalAlign="center" Width="72px"/></asp:BoundField>
                        
            <asp:BoundField DataField="strTripSLNo" HeaderText="Trip SL No." ItemStyle-HorizontalAlign="Center" SortExpression="strTripSLNo">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strRegNo" HeaderText="Vehicle Reg. No." ItemStyle-HorizontalAlign="Center" SortExpression="strRegNo">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strName" HeaderText="Customer Name" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
            <ItemStyle HorizontalAlign="left" Width="250px"/></asp:BoundField>
                                        
            <asp:BoundField DataField="intMillage" HeaderText="Distance KM" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="intMillage">
            <ItemStyle HorizontalAlign="center" Width="35px"/></asp:BoundField>

            <asp:BoundField DataField="strUOM" HeaderText="UOM" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="strUOM">
            <ItemStyle HorizontalAlign="Left" Width="40px"/></asp:BoundField>

            <asp:BoundField DataField="intQuantity" HeaderText="Quantity" Visible="false" ItemStyle-HorizontalAlign="Center" SortExpression="intQuantity">
            <ItemStyle HorizontalAlign="center" Width="40px"/></asp:BoundField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Trip Details" >
            <ItemTemplate><asp:Button ID="btnActionDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="Trip Details" OnClick="TripDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Estimated Expense" >
            <ItemTemplate><asp:Button ID="btnActionFuelC" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="Estimated Exp." OnClick="btnActionFuelC_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="For In Postint" >
            <ItemTemplate><asp:Button ID="btnAction" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="In Posting" OnClick="Action_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Trip Close" >
            <ItemTemplate><asp:Button ID="btnVendorV" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="Trip Close" OnClientClick="ConfirmAll()" OnClick="btnVendorV_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Trip Complete" >
            <ItemTemplate><asp:Button ID="btnVTripComplete" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="Trip Complete" OnClick="btnVTripComplete_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Customer Bridge" >
            <ItemTemplate><asp:Button ID="btnCustBridge" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intid") %>' Text="Customer Bridge" OnClientClick="ConfirmAll()" OnClick="btnCustBridge_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                                
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>

         </table>     
    </div>




<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
