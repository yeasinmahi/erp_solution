<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTDriverLedgerBalance.aspx.cs" Inherits="UI.Transport.InternalTDriverLedgerBalance" %>
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

    <script type="text/javascript">
        function hideGrid1()
        {
            document.getElementById("divDriverLadgerBalance").style.display = "none";           
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> DRIVER LADGER BALANCE <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>                                                                         

            <%--<td style="text-align:right;"><asp:Label ID="lblSearchBuyerReff" runat="server" CssClass="lbl" Text="Trip SL No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchTripSLNo" runat="server" CssClass="txtBox"></asp:TextBox></td>              --%>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        <tr>
            <%--<td style="text-align:right;"><asp:Label ID="lblSearchDriverEnroll" runat="server" CssClass="lbl" Text="Driver Enroll :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchDriverEnroll" runat="server" CssClass="txtBox"></asp:TextBox></td>--%>  
            
            <td style="text-align:right;"><asp:Label ID="lblDriver" runat="server" CssClass="lbl" Text="Driver List :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlDriverName" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlDriverName_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>                                    

            <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
        </tr>                               
                  
    </table>
    </div>

     <div id="divDriverLadgerBalance">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Fuel Station Wise Details Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label1" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label2" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label3" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvDriverLadgerBalance" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:BoundField DataField="DriverName" HeaderText="Driver Name" ItemStyle-HorizontalAlign="Center" SortExpression="DriverName">
            <ItemStyle HorizontalAlign="left" Width="300px"/></asp:BoundField>

            <asp:BoundField DataField="Debit" HeaderText="Debit" ItemStyle-HorizontalAlign="Center" SortExpression="Debit">
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:BoundField>

            <asp:BoundField DataField="Advance" HeaderText="Advance" ItemStyle-HorizontalAlign="Center" SortExpression="Advance">
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:BoundField>

            <asp:BoundField DataField="FuelCredit" HeaderText="Fuel Credit" ItemStyle-HorizontalAlign="Center" SortExpression="FuelCredit">
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:BoundField>

            <asp:BoundField DataField="Credit" HeaderText="Total Credit" ItemStyle-HorizontalAlign="Center" SortExpression="Credit">
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:BoundField>

            <asp:BoundField DataField="Balance" HeaderText="Balance" ItemStyle-HorizontalAlign="Center" SortExpression="Balance">
            <ItemStyle HorizontalAlign="right" Width="90px"/></asp:BoundField>

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
