<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Supplier_Profile.aspx.cs" Inherits="UI.Dairy.Milk_Supplier_Profile" %>
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
          
        <div class="tabs_container"> MILK SUPPLIER PROFILE <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlChillingCenter" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlChillingCenter_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 
        </tr>
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>            
        </tr>

    
        </table>
    </div>


      <div id="divInventory">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvSupplierProfile" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                      
            <asp:BoundField DataField="strSupplierCode" HeaderText="Supplier Code" ItemStyle-HorizontalAlign="Center" SortExpression="strSupplierCode">
            <ItemStyle HorizontalAlign="center" Width="80px"/></asp:BoundField>

            <asp:BoundField DataField="strSupplierName" HeaderText="Supplier Name" ItemStyle-HorizontalAlign="Center" SortExpression="strSupplierName">
            <ItemStyle HorizontalAlign="left" Width="180px"/></asp:BoundField>

            <asp:BoundField DataField="strOrgAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgAddress">
            <ItemStyle HorizontalAlign="left" Width="210px"/></asp:BoundField>

            <asp:BoundField DataField="strBankAccountNo" HeaderText="Account No." ItemStyle-HorizontalAlign="Center" SortExpression="strBankAccountNo">
            <ItemStyle HorizontalAlign="center" Width="110px"/></asp:BoundField>

            <asp:BoundField DataField="strBankName" HeaderText="Bank Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankName">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strBankBranchName" HeaderText="Branch Name" ItemStyle-HorizontalAlign="Center" SortExpression="strBankBranchName">
            <ItemStyle HorizontalAlign="left" Width="150px"/></asp:BoundField>

            <asp:BoundField DataField="strDistrict" HeaderText="District Name" ItemStyle-HorizontalAlign="Center" SortExpression="strDistrict">
            <ItemStyle HorizontalAlign="left" Width="110px"/></asp:BoundField>

            <asp:BoundField DataField="strOrgContactNo" HeaderText="Mobile No." ItemStyle-HorizontalAlign="Center" SortExpression="strOrgContactNo">
            <ItemStyle HorizontalAlign="center" Width="110px"/></asp:BoundField>

            <asp:BoundField DataField="strNationalIDNo" HeaderText="National ID No." ItemStyle-HorizontalAlign="Center" SortExpression="strNationalIDNo">
            <ItemStyle HorizontalAlign="center" Width="110px"/></asp:BoundField>

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
