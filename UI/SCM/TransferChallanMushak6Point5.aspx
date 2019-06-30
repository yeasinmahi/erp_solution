<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferChallanMushak6Point5.aspx.cs" Inherits="UI.SCM.TransferChallanMushak6Point5" %>
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
        function M6Point5Pint(M65, VATPointID, VATYear) {
            window.open('../Vat/PrintMushak_6_5.aspx?M65=' + M65 + '&VATPointID=' + VATPointID + '&VATYear=' + VATYear, 'sub', "height=570, width=720, scrollbars=yes, left=50, top=45, resizable=no, title=Preview");
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
    <div class="leaveApplication_container"> 
    <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <div class="tabs_container"> PRINT TRANSFER CHALLAN MUSHAK 6.5 <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="From WH:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFromWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblToWH" runat="server" CssClass="lbl" Text="To WH:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlToWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true"></asp:DropDownList>                                                                                       
            </td>       
            
            <td style="text-align:right;"><asp:Label ID="lblTransferDate" runat="server" CssClass="lbl" Text="Transfer Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtTransferDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTransferDate"></cc1:CalendarExtender></td>  
            
            <td><asp:Button ID="btnShow" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show" OnClick="btnShow_Click" /></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtVehicleNo" runat="server" CssClass="txtBox" Width="190px"></asp:TextBox></td>

            <td style="text-align:right;"><asp:Label ID="lblItemList" runat="server" CssClass="lbl" Text="Item List :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlItemList" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td> 

            <td colspan="2"><asp:Button ID="btnAdd" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Add" OnClick="btnAdd_Click" /></td>
            
            <td style="text-align:left;"><asp:Button ID="btnTransferAction" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Transfer"  OnClientClick="ConfirmAll()" OnClick="btnTransferAction_Click" /></td>
        </tr>

        <tr><td colspan="6"> 
            <asp:GridView ID="dgvItemList" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="false" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  OnRowDeleting="dgvItemList_RowDeleting">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="intTransferID" Visible="false" SortExpression="intTransferID"><ItemTemplate>            
            <asp:Label ID="lblTransferID" runat="server" Text='<%# Bind("intTransferID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Item Name" SortExpression="ItemName"><ItemTemplate>            
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("numQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:TemplateField>
                         
            <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUOM" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("strUoM"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:TemplateField>
                     
            <asp:CommandField ShowDeleteButton="true" Visible="false" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

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
