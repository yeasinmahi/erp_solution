<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTVehicleMovementReport.aspx.cs" Inherits="UI.Transport.InternalTVehicleMovementReport" %>
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
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />

    <script type="text/javascript">
        function TripDetails(reqsid) {
            window.open('InternalTVehicleMovementDetails.aspx?intID=' + reqsid, 'sub', "height=400, width=450, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> INTERNAL TRANSPORT ANALYSIS REPORT <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>                                                                         

            <%--<td style="text-align:right;"><asp:Label ID="lblSearchBuyerReff" runat="server" CssClass="lbl" Text="Trip SL No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchTripSLNo" runat="server" CssClass="txtBox"></asp:TextBox></td>              --%>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblReport" runat="server" CssClass="lbl" Text="Report:"></asp:Label></td>                
            <td>
                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="true" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Vehicle Movement Report</asp:ListItem><asp:ListItem Value="2">Vehicle Operation Report</asp:ListItem>                
                </asp:DropDownList>
            </td> 

            <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
        </tr>                      
        </table>
        </div>

        <div id="divExport">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Summary Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>

            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Vehicle No." SortExpression="strRegNo"><ItemTemplate>            
            <asp:Label ID="lblVNo" runat="server" Text='<%# Bind("strRegNo") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="170px"/></asp:TemplateField>
                            
            <asp:TemplateField HeaderText="Vehicle Type" SortExpression="Vtype"><ItemTemplate>            
            <asp:Label ID="lblVType" runat="server" Text='<%# Bind("Vtype") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Ship Point" SortExpression="strName"><ItemTemplate>            
            <asp:Label ID="lblSPoint" runat="server" Text='<%# Bind("strName") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Carring Qty" SortExpression="TotalQuantity"><ItemTemplate>            
            <asp:Label ID="lblTCarringQty" runat="server" Text='<%# Bind("TotalQuantity") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="150px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Trip" SortExpression="TripCount"><ItemTemplate>            
            <asp:Label ID="lblTripCount" runat="server" Text='<%# Bind("TripCount") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="150px"/></asp:TemplateField>
                
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Trip Details">
            <ItemTemplate><asp:Button ID="btnActionDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intVehicleid") %>' Text="Trip Details" OnClick="TripDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>            
       
            <tr><td> 
            <asp:GridView ID="dgvReport2" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Month" SortExpression="strMonth"><ItemTemplate>            
            <asp:Label ID="lblMonth" runat="server" Text='<%# Bind("strMonth") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Route Exp." SortExpression="TotalRouteExp"><ItemTemplate>            
            <asp:Label ID="lblTRouteExp" runat="server" Text='<%# Bind("TotalRouteExp") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Trip Fare" SortExpression="TotalTripFare"><ItemTemplate>            
            <asp:Label ID="lblTFare" runat="server" Text='<%# Bind("TotalTripFare") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Delivery Quantity" SortExpression="TotalDeliveryQty"><ItemTemplate>            
            <asp:Label ID="lblTDQuantity" runat="server" Text='<%# Bind("TotalDeliveryQty") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Delivery By Own Vehicle" SortExpression="DeliveryByOwnVehicle"><ItemTemplate>            
            <asp:Label ID="lblDOwnVehicle" runat="server" Text='<%# Bind("DeliveryByOwnVehicle") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Delivery By Hired Vehicle" SortExpression="DeliveryByHiredV"><ItemTemplate>            
            <asp:Label ID="lblDHiredVehicle" runat="server" Text='<%# Bind("DeliveryByHiredV") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="100px"/></asp:TemplateField>
                                            
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
