<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WoodReceiveDetails.aspx.cs" Inherits="UI.WoodPurchase.WoodReceiveDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    <script language="javascript" type="text/javascript">        

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function roundup(num, dec) {
            dec = dec || 0;
            var s = String(num);
            if (num % 1) s = s.replace(/5$/, '6');
            return Number((+s).toFixed(dec));
        }
        function CalculateInstallmentAmount() {
            var Length = document.getElementById('txtLength').value;
            if (isNaN(Length) == true) { Length = 0; }
            var Circum = document.getElementById('txtCircum').value;
            if (isNaN(Circum) == true) { Circum = 0; }
            var CFT = (Length * Math.pow(Circum,2)) / 2304;
            document.getElementById('txtCFT').value = roundup(CFT, 3);
                        
        }
        
    </script>
    
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
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
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnPOAmount" runat="server" />
    <asp:HiddenField ID="hdnSupplierID" runat="server" /> <asp:HiddenField ID="hdnJobStaion" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Wood Receive<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="4"><hr /></td></tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Supplier/PO :" CssClass="lbl"></asp:Label></td>
                <td><asp:DropDownList ID="ddlPOList" runat="server" CssClass="ddList"  width="220px" height="23px" BackColor="White" OnSelectedIndexChanged="ddlPOList_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="lblReceiveDate" runat="server" CssClass="lbl" Text="Receive Date :"></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtReceiveDate" runat="server" CssClass="txtBox1" BackColor="White" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReceiveDate"></cc1:CalendarExtender></td>
            </tr>
            
            
            <tr>
                <td colspan="4" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>  
            </tr>
            <tr><td colspan="4"><hr /></td></tr>
        </table>
        <table>
            <tr>
                <td colspan="4">
            <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true">
            <AlternatingRowStyle BackColor="#CCCCCC" />

            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Date" SortExpression="dteTransactionDate">
            <ItemTemplate><asp:Label ID="lblReceiveDate" runat="server" Text='<%#Eval("dteTransactionDate", "{0:yyyy-MM-dd}") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Gete Entry No" SortExpression="intGateEntryNo">
            <ItemTemplate><asp:Label ID="lblGateEntry" runat="server" Text='<%# Bind("intGateEntryNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Vehicle No" SortExpression="strVehicleNo">
            <ItemTemplate><asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strVehicleNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="120px" /></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Zone Name" SortExpression="strZoneName">
            <ItemTemplate><asp:Label ID="lblZone" runat="server" Text='<%# Bind("strZoneName") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>   

            <asp:TemplateField HeaderText="Tag No" SortExpression="strTagNo">
            <ItemTemplate><asp:Label ID="lblTagNo" runat="server" Text='<%# Bind("strTagNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Wood Type" SortExpression="strWoodType">
            <ItemTemplate><asp:Label ID="lblType" runat="server" Text='<%# Bind("strWoodType") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="ItemName">
            <ItemTemplate><asp:Label ID="lblName" runat="server" Text='<%# Bind("ItemName") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="120px" /></asp:TemplateField> 
                                
            <asp:TemplateField HeaderText="Length" SortExpression="numLength" Visible="true">
            <ItemTemplate><asp:Label ID="lblLength" runat="server" Text='<%# Bind("numLength") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="35px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Circum ference" SortExpression="numCircumference" Visible="true">
            <ItemTemplate><asp:Label ID="lblCircum" runat="server" Text='<%# Bind("numCircumference") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Total CFT" SortExpression="numCFT">
            <ItemTemplate><asp:Label ID="lblCFT" runat="server" Text='<%# Bind("numCFT") %>' Width="40px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="80px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Rate" SortExpression="monReceRate">
            <ItemTemplate><asp:Label ID="lblRate" runat="server" Text='<%# Bind("monReceRate") %>'></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="40px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Amount" SortExpression="monReceAmount">
            <ItemTemplate><asp:Label ID="lblReceiveAmount" runat="server" Text='<%# Bind("monReceAmount") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField> 

            <asp:TemplateField HeaderText="Receive ID" SortExpression="intReceivedID" Visible="false">
            <ItemTemplate><asp:Label ID="lblReceiveID" runat="server" Text='<%# Bind("intReceivedID") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="60px" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="">
            <ItemTemplate><asp:Button ID="btnUpdate" runat="server" class="myButtonGrey" style="cursor:pointer; font-size:11px;"  Width="90px"
            CommandArgument='<%# Eval("intReceivedID") %>'    Text="Remove" OnClick="btnUpdate_Click"/></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="90Px"/></asp:TemplateField>

            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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