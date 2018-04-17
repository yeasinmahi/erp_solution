<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTVehicleMovementDetails.aspx.cs" Inherits="UI.Transport.InternalTVehicleMovementDetails" %>
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
<%--=========================================Start My Code From Here===============================================--%>
    <asp:TextBox ID="txtdgvFTTotal" runat="server" Width="0.1px" CssClass="txtBox" Height="0.1px" MaxLength="10" BackColor="White" ForeColor="White" ></asp:TextBox>        
        <div class="leaveApplication_container"> 
        <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />
      
        <div class="tabs_container"> VEHICLE MOVEMENT DETAILS<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">        
        
        
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4"> 
            <asp:GridView ID="dgvTripDetails" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Date" SortExpression="dteDate"><ItemTemplate>            
            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Trip SL No." SortExpression="strTripSLNo"><ItemTemplate>            
            <asp:Label ID="lblTripSL" runat="server" Text='<%# Bind("strTripSLNo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="200px"/></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Quantity" SortExpression="Quantity"><ItemTemplate>            
            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:TemplateField>--%>
                                                        
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