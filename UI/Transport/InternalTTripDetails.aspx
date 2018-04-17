<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTTripDetails.aspx.cs" Inherits="UI.Transport.InternalTTripDetails" %>
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

</head>
<body>
    <form id="frmselfresign" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox" Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />
      
        <div class="tabs_container"> TRIP DETAILS<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">        
        
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblTrip" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Trip Sl No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblTripNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>

            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicle" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle No. :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>                        
        </tr>
        <tr>
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblCustN" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Final Destination :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblCustName" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
            
            <td style="font-weight:bold; text-align:right; color:#0b6016;"><asp:Label ID="lblVehicleT" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Vehicle Type :"></asp:Label></td>
            <td style="font-weight:bold; text-align:left; color:#0b6016;"><asp:Label ID="lblVehicleType" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px"></asp:Label></td>            
        </tr>
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvTripDetails" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Challan No." SortExpression="strChallanNo"><ItemTemplate>            
            <asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("strChallanNo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Challan Date" SortExpression="dteChallanDate"><ItemTemplate>            
            <asp:Label ID="lblChallanDate" runat="server" Text='<%# Bind("dteChallanDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="90px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Customer Name" SortExpression="strName"><ItemTemplate>            
            <asp:Label ID="lblCustName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="285px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Millage" SortExpression="intMillage"><ItemTemplate>            
            <asp:Label ID="lblMillage" runat="server" Text='<%# Bind("intMillage") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="90px"/></asp:TemplateField>
                            
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