<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Inventory.aspx.cs" Inherits="UI.Dairy.Milk_Inventory" %>
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
          
        <div class="tabs_container"> MILK INVENTORY REPORT <hr /></div>

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
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 

            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td> 
        </tr>
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>            
        </tr>

        </table>
    </div>


      <div id="divInventory">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvInventory" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvInventory_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                      
            <%--<asp:TemplateField HeaderText="Date" SortExpression="dteTransactionDate"><ItemTemplate>            
            <asp:Label ID="lbldteTransactionDate" runat="server" Text='<%# Bind("dteTransactionDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Date" SortExpression="dteDate"><ItemTemplate>            
            <asp:Label ID="lbldteTransactionDate" runat="server" Text='<%# Bind("dteDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
              
              
            <asp:BoundField DataField="OpeQty" HeaderText="Opening Qty." ItemStyle-HorizontalAlign="Center" SortExpression="OpeQty">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Opening Qty" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblOpeQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# topeqty %>' /></FooterTemplate></asp:TemplateField>--%>
            
            <asp:BoundField DataField="OpeValue" HeaderText="Opening Value" ItemStyle-HorizontalAlign="Center" SortExpression="rate">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Opening Value" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblOpeVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# topeval %>' /></FooterTemplate></asp:TemplateField>--%>
            
            <asp:TemplateField HeaderText="Receive Qty." ItemStyle-HorizontalAlign="right" SortExpression="intReceQty" >
            <ItemTemplate><asp:Label ID="lblRQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intReceQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# trqty %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Receive Value" ItemStyle-HorizontalAlign="right" SortExpression="monRValue" >
            <ItemTemplate><asp:Label ID="lblRVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monRValue"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# trval %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="TotalQty" HeaderText="Total Qty." ItemStyle-HorizontalAlign="Center" SortExpression="TotalQty">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Total Qty" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblTQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttqty %>' /></FooterTemplate></asp:TemplateField>--%>
            
            <asp:BoundField DataField="TotalVal" HeaderText="Total Value" ItemStyle-HorizontalAlign="Center" SortExpression="TotalVal">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Total Value" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblTValue" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# ttval %>' /></FooterTemplate></asp:TemplateField>--%>
            
            <asp:TemplateField HeaderText="Issue Qty." ItemStyle-HorizontalAlign="right" SortExpression="intOutQty" >
            <ItemTemplate><asp:Label ID="lblIssQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intOutQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tissqty %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Issue Value" ItemStyle-HorizontalAlign="right" SortExpression="monIssValue" >
            <ItemTemplate><asp:Label ID="lblIssVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monIssValue"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tissval %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="Closqty" HeaderText="Closing Qty." ItemStyle-HorizontalAlign="Center" SortExpression="Closqty">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Closing Qty" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblCQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tcqty %>' /></FooterTemplate></asp:TemplateField>--%>
            
            <asp:BoundField DataField="ClosValue" HeaderText="Closing Value" ItemStyle-HorizontalAlign="Center" SortExpression="ClosValue">
            <ItemStyle HorizontalAlign="Right" Width="40px"/></asp:BoundField>

            <%--<asp:TemplateField HeaderText="Closing Value" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblCVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tcval %>' /></FooterTemplate></asp:TemplateField>--%>
                            
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
