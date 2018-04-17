<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptOwnerReceivePopup.aspx.cs" Inherits="UI.HR.Dispatch.rptOwnerReceivePopup" %>
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

     
    <script type="text/javascript">     
    function ReceiveByOwner() {
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "5"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();
    }
    </script>

    <script> function CloseWindow() {
     window.close();      
 } </script>
 
   
</head>
<body>
    <form id="frmdispatch" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>  
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnDispatchID" runat="server" /><asp:HiddenField ID="hdnJobStationID" runat="server" />
    
    <div id="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <%--<tr><td colspan="4" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>--%>
    
    <tr>      
    <td style="font-weight:bold; text-align:right; "><asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Employee Card No.:"></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtEmployeeCardNo" AutoPostBack="true" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" OnTextChanged="txtChanged_Click"></asp:TextBox></td> 

    <td style="font-weight:bold; text-align:right; "><asp:Label ID="lblEnroll" runat="server" CssClass="lbl" Font-Bold="true" Font-Size="11px" Text="Enroll :"></asp:Label></td>
    <td style="text-align:left;"><asp:TextBox ID="txtEnrollByReceiver" AutoPostBack="false" runat="server" Width="210px" CssClass="txtBox" Font-Bold="false" ForeColor="Black" Font-Size="11px" OnTextChanged="txtEnrollR_Click"></asp:TextBox></td> 
    </tr>

    <tr><td colspan="6" style="text-align:justify;"><hr />
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
    <tr class="tblroweven"><td style="text-align:right;"><asp:Button ID="btnApproveDT" runat="server" CssClass="button" Text="Receive" OnClientClick="ReceiveByOwner()" OnClick="btnApproveDT_Click"/></td></tr>
    </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>