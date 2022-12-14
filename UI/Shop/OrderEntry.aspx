<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderEntry.aspx.cs" Inherits="UI.Shop.OrderEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>
    </head>
<body>
    <form id="frmaccountsrealize" runat="server">
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Left" >AEFPS Employee Order Form</div>
   
        <table style="  outline-color:blue;table-layout:auto;vertical-align: top; background-color: #808080;" class="tblrowodd" >          
        <tr  class="tblrowodd">
        <td style="text-align:right;"> <asp:Label ID="lblOrderType" font-size="small" runat="server" CssClass="lbl" Text="Type:"></asp:Label></td>
        <td style="text-align:left;"> <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="txtBox"  Font-Bold="True" OnSelectedIndexChanged="ddlOrderType_SelectedIndexChanged" >
        <asp:ListItem Text="Order" Value="1"></asp:ListItem> <asp:ListItem Text="View" Value="2"></asp:ListItem></asp:DropDownList> </td>          
        <td><asp:Button ID="btnSubmits" runat="server" Text="Submit" OnClick="btnSubmits_Click" /></td> </tr>          
           
        </table> 
          <table>
              <tr>
             <td>
                 <asp:GridView ID="dgvOrder" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
           
            <asp:TemplateField HeaderText="ItemID" Visible="false">
            <ItemTemplate> <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>                           
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ItemName"> <ItemTemplate> <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>  </asp:TemplateField>
            <asp:TemplateField HeaderText="UOM"> <ItemTemplate> <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Price"> <ItemTemplate> <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("monPrice") %>'></asp:Label></ItemTemplate>  </asp:TemplateField>
            <asp:TemplateField HeaderText="Order Qty"> <ItemTemplate> <asp:TextBox ID="txtQty" runat="server"></asp:TextBox></ItemTemplate>  </asp:TemplateField>
                                     
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>

             </td>
              </tr>
          </table>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
