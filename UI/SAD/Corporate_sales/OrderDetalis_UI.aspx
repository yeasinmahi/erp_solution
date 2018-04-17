<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetalis_UI.aspx.cs" Inherits="UI.SAD.Corporate_sales.OrderDetalis_UI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script type="text/javascript">
   
    

    function Confirm() {
        document.getElementById("hdnconfirm").value = "0";
        var txtSection = document.forms["frmreq"]["txtSection"].value;
        var txtQuantity = document.forms["frmreq"]["txtQuantity"].value;
        if (txtSection == null || txtSection == "") { alert("Please enter valid section ."); }
        else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00") { alert("Please enter valid quantity ."); }
        else { document.getElementById("hdnconfirm").value = "1"; }
    }
    function isDecimal(value) {
        return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
    }



    function Viewdetails(id) {
        window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
    }
</script>


</head>
<body>
    <form id="frmreq" runat="server">
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
    <div class="leaveApplication_container"><table border="0"; style="width:500PX"; >
    <tr><td colspan="2" class="tblheader">Order Input From:<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
     <asp:HiddenField ID="hdnBlance" runat="server" /> <asp:HiddenField ID="hdncredit" runat="server" /> 
         <asp:HiddenField ID="hdnTotal" runat="server" />
        </td></tr>
        <caption>
           <tr class="">
                <td colspan="2" style="text-align:justify;">
                    <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" ShowFooter="true"  BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" Font-Size="10px" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="dgv_SelectedIndexChanged" >
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="SL.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="strUnit" HeaderText="Unit" NullDisplayText="strUnit" />
                            <asp:BoundField DataField="strName" HeaderText="CustomerName" SortExpression="strName" />
                            <asp:BoundField DataField="shippingName" HeaderText="ShippingPoint" SortExpression="shippingName" />
                            <asp:BoundField DataField="strProductName" HeaderText="Product Nmae" SortExpression="strBrand" />
                            <asp:BoundField DataField="numQuantity" HeaderText="Qty" SortExpression="numQuantity" />
                            <asp:BoundField DataField="monPrice" HeaderText="Price" SortExpression="monPrice" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Price" SortExpression="TotalAmount" />
                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
            
        </caption>

   </table></div>

 
  








<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
