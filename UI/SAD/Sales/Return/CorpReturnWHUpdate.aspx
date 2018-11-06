<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorpReturnWHUpdate.aspx.cs" Inherits="UI.SAD.Sales.Return.CorpReturnWHUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> <%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>
<!DOCTYPE html>

<html><head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    
  <script>
    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";        
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to submit?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }

    }



    </script>

    <script> function CloseWindow() {
     window.close();      
 } </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>
   
</head>
<body>
    <form id="frmRtnFTYUpdate" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
  <%--  <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"><b>Corporate Sales Return Review Edit: </b><asp:HiddenField ID="hdnconfirm" runat="server" /><hr />
    <table style="width:Auto";>
   <tr><td colspan="2"><asp:Label ID="Label1" runat="server" Text="Customer Name : "></asp:Label><asp:Label ID="lblCustomer" runat="server"></asp:Label></td></tr>
    <tr><td><asp:Label ID="lblchallanno" runat="server" Text="Challan No: "></asp:Label><asp:Label ID="lblchalan" runat="server"></asp:Label></td>
    <td></td>
    </tr>
    <tr><td>
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" 
    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" >
    <AlternatingRowStyle BackColor="#CCCCCC"/>
    <Columns>   
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %>
        <asp:HiddenField id="hdfk" Value='<%# Bind("intFK")%>' runat="server" />
        <asp:HiddenField id="hdprodid" Value='<%# Bind("intProdId")%>' runat="server" />
      </ItemTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Return Type" SortExpression="strReturnType"><ItemTemplate>
    <asp:Label ID="lblreportType" runat="server" Text='<%# Bind("strReturnType") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
    <asp:TemplateField HeaderText="Product Details" SortExpression="Description"><ItemTemplate>
    <asp:Label ID="lblprod" runat="server" Text='<%# Bind("Description") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
         <asp:TemplateField HeaderText="Location/Point Name" SortExpression="strLocation"><ItemTemplate>
    <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strLocation") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Return Quantity (Pcs)" SortExpression="decrcv">
    <ItemTemplate><asp:Textbox ID="txtpartyrtn" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" runat="server" Text='<%# Bind("decReturnQty") %>'> </asp:Textbox></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="35px" /></asp:TemplateField>
    <asp:TemplateField HeaderText="Warehouse Recieved Quantity (Pcs)" SortExpression="decrcv">
    <ItemTemplate><asp:Textbox ID="txtwhcv" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" runat="server" Text='<%# Bind("decWHReturnCountQty") %>'> </asp:Textbox></ItemTemplate>
    <ItemStyle HorizontalAlign="Center" Width="35px" /></asp:TemplateField>
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"/>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td style="text-align:right;"><asp:Button ID="btnsubmit" runat="server" Text="Submit" class="nextclick" style="cursor:pointer; font-size:11px;" OnClientClick="Confirm()" OnClick="btnsubmit_Click" /></td></tr>
    </table>
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
