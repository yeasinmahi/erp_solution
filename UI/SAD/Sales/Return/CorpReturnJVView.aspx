<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpReturnJVView.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpReturnJVView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    
  <script>

    function CloseWindow() {
        window.close();
    }
    </script>
   
</head>
<body>
    <form id="frmRtnFTYUpdate" runat="server">
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
    <div class="leaveApplication_container"><b>Corporate Sales Return: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />
    <table style="width:Auto";>
   <tr><td colspan="2"><asp:Label ID="lblCustomer" runat="server"></asp:Label></td></tr>
    <tr><td><asp:Label ID="lblchallanno" runat="server" Text="Challan No: "></asp:Label><asp:Label ID="lblchalan" runat="server"></asp:Label></td>
    <td></td>
    </tr>
    <tr><td>
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" >
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>   
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Product Details" SortExpression="strProd"><ItemTemplate>
    <asp:Label ID="lblprod" runat="server" Text='<%# Bind("Description") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
    <asp:TemplateField HeaderText="Party Return" SortExpression="decrcv">
    <ItemTemplate><asp:Textbox ID="txtpartyrtn"  runat="server" ReadOnly="true" Text='<%# Bind("decReturnQty") %>'> </asp:Textbox></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td style="text-align:right;"><asp:Button ID="btnsubmit" runat="server" Text="Close" class="nextclick" style="cursor:pointer; font-size:11px;"  OnClick="btnsubmit_Click" /></td></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
