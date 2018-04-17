<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppsRemoteOrderApporve.aspx.cs" Inherits="UI.SAD.AppsOrder.AppsRemoteOrderApporve" %>

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

    <script>    
    function DispatchSubmit() {
        document.getElementById("hdnconfirm").value = "0";
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
        else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        __doPostBack();        
    }
    </script>

</head>
<body>
    <form id="frmdispatch" runat="server">        
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
        <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <div class="leaveApplication_container">        
        <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:green; text-align:center; font-size:18px">Remote Order Approve</td></tr>
                      
            <tr>
            <td style=" text-align:start; vertical-align:top"><asp:GridView ID="dgvOrder" runat="server" AutoGenerateColumns="False"  Font-Size="12px"  BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Width="700px" CellPadding="1" ForeColor="Black" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL.N" >  <ItemTemplate> <%# Container.DataItemIndex + 1 %> 
            <asp:HiddenField  ID="hdnAutoID" runat="server" Value='<%# Bind("intAutoId") %>'></asp:HiddenField>
               
           
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="15px"/></asp:TemplateField> 
            <asp:TemplateField HeaderText="Customer" SortExpression="strName" ><ItemTemplate>       
            <asp:Label ID="lblCustomer" runat="server" CssClass="lbl" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>      
       
            <asp:TemplateField HeaderText="Order Date" SortExpression="strOrderCode" ><ItemTemplate>       
            <asp:Label ID="lblOrderDate" runat="server" CssClass="lbl" Text='<%# Bind("strOrderCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 
            <asp:TemplateField HeaderText="Order Qty" SortExpression="numTotalQty" ><ItemTemplate>       
            <asp:Label ID="lblOrderQty" runat="server" CssClass="lbl" Text='<%# Eval("numTotalQty","{0:N0}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField>   
                         
            <asp:TemplateField HeaderText="Complete"><ItemTemplate>
            <asp:Button ID="btnApprove" runat="server" Text="Detalis"  OnClick="btnApprove_Click" />
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td></tr>         

            
        </table>            
        </div>
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
