<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryReport.aspx.cs" Inherits="UI.AEFPS.InventoryReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
       <script type="text/javascript">
      function Search_dgvservice(strKey, strGV) {

          var strData = strKey.value.toLowerCase().split(" ");
          var tblData = document.getElementById(strGV);
          var rowData;
          for (var i = 1; i < tblData.rows.length; i++) {
              rowData = tblData.rows[i].innerHTML;
              var styleDisplay = 'none';
              for (var j = 0; j < strData.length; j++) {
                  if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                      styleDisplay = '';
                  else {
                      styleDisplay = 'none';
                      break;
                  }
              }
              tblData.rows[i].style.display = styleDisplay;
          }

      }
        </script>
</head>
<body>
    <form id="frmSalesReturn" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnDA" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnTFare" runat="server" />
 
    <div class="tabs_container"> INVENTORY REPORT <hr /></div>        
        <div>
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox" Width="120px"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtTo" runat="server" CssClass="txtBox" Width="120px"></asp:TextBox>
            <cc1:CalendarExtender ID="dtpTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
          </tr>
          <tr>  
   
            <td colspan="6" style="text-align:right;"><asp:Button ID="btnShow" runat="server" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>
        </tr>
        <tr><td colspan="6"><hr /></td></tr>
        
      
        <tr>
            <td colspan="6" style="text-align:center;">
                <asp:GridView ID="dgvInventory" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                         <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="50"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvInventory')"></asp:TextBox></HeaderTemplate>
                     <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Item ID" SortExpression="intMasterID" HeaderStyle-HorizontalAlign="Center" Visible="false"><ItemTemplate>
                        <asp:Label ID="lblID" Width="40px" runat="server" Text='<%# Bind("intMasterID") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Code" SortExpression="strCode" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblCode" Width="40px" runat="server" Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Item Name" SortExpression="strName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left"><ItemTemplate>
                        <asp:Label ID="lblName" Width="200px" runat="server" Text='<%# Bind("strName") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        
                        <%--<asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="40px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="40px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Opening" SortExpression="numOpening" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblOpening" Width="40px" runat="server" Text='<%# Bind("numOpening") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="Receive" SortExpression="numReceiveQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblReceive" Width="40px" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Transfer In" SortExpression="numInQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblIn" Width="40px" runat="server" Text='<%# Bind("numInQty") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sales" SortExpression="numSalesQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblSales" Width="40px" runat="server" Text='<%# Bind("numSalesQty") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Transfer Out" SortExpression="numOutQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblOut" Width="40px" runat="server" Text='<%# Bind("numOutQty") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Closing" SortExpression="ClosingStock" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblClosing" Width="40px" runat="server" Text='<%# Bind("ClosingStock") %>'></asp:Label></ItemTemplate>
                        </asp:TemplateField>

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
            </td>
        </tr>
 

       </table>
     </div>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
