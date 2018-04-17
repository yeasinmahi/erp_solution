<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptReceiveByDispatchDeptPopup.aspx.cs" Inherits="UI.HR.Dispatch.rptReceiveByDispatchDeptPopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Dispatch Register </title>
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
    <form id="frmdispatch" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>  
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnDispatchID" runat="server" />
    <div id="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <%--<tr><td style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>--%>
          
    <tr><td style="text-align:justify;"><hr />
    <asp:GridView ID="dgvAdd" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                
    <asp:TemplateField HeaderText="ItemId" Visible="false" ItemStyle-HorizontalAlign="right">
    <ItemTemplate><asp:Label ID="lblItemid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intItemID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                           
    <asp:TemplateField HeaderText="Item Name"><ItemTemplate>            
    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

    <asp:TemplateField HeaderText="Quantity"><ItemTemplate>            
    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>

    <asp:TemplateField HeaderText="Remarks"><ItemTemplate>            
    <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="175px"/></asp:TemplateField>
          
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    <tr class="tblroweven"><td style="text-align:right;"><asp:Button ID="btnApproveDT" runat="server" CssClass="button" Text="Receive" OnClientClick="ConfirmAll()" OnClick="btnApproveDT_Click" /></td></tr>
    </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>