<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpReturnFTYView.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpReturnFTYView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
 <script>
function Registration(url) {newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=400,width=480,top=50,left=150, close=no');
if (window.focus) { newwindow.focus() }}
</script>
   
</head>
<body>
    <form id="frmRtnFTYView" runat="server">
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
    <div class="leaveApplication_container"><b>Corporate Sales Return Factory Receive: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnenroll" runat="server" /><hr />
    <table style="width:auto";>
   <tr><td style="text-align:center"><asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" /></td></tr>
    <tr><td>
    <asp:GridView ID="dgvrptrtnfty" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" >
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>   
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %>
     <asp:HiddenField id="hdncustid" Value='<%# Bind("intcustid")%>' runat="server" />
     <asp:HiddenField id="hdnwhrdt" Value='<%# Bind("dteWhR")%>' runat="server" />
     <asp:HiddenField id="hdnchallanno" Value='<%# Bind("strchallanno")%>' runat="server" />
     </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Name" SortExpression="strCustName"><ItemTemplate>
    <asp:Label ID="lblcust" runat="server" Text='<%# Bind("Customer") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px" Wrap="true"/></asp:TemplateField>
    <asp:TemplateField HeaderText="RTV No" SortExpression="strchallan">
    <ItemTemplate><asp:Label ID="lblchallan" runat="server" Text='<%# Bind("strchallanno") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="65px" /></asp:TemplateField>
     <asp:TemplateField HeaderText="Desctiption" SortExpression="strdesc">
    <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Descrip") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="265px" Wrap="true" /></asp:TemplateField>
     <asp:TemplateField HeaderText="Details"><ItemTemplate><asp:Button ID="Select" runat="server" Text="Show"  CommandArgument='<%#Eval("intCustId") + "," +Eval("strChallanNo")%>' OnClick="Select_Click" /></ItemTemplate></asp:TemplateField>  
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td style="text-align:right;"></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>