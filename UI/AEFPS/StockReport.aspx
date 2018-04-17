<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="UI.AEFPS.StockReport" %>
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
   
    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        
</script>

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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> STOCK REPORT <hr /></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
        </tr>
        
        <tr>
            <td colspan="2" style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        
        </table>
    </div>
    <div>
        <table class="tbldecoration" style="width:auto; float:left;"> 
        <tr>
            <td colspan="2" style="text-align:center;">
                <asp:GridView ID="dgvStock" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvReceive_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>

                        <asp:TemplateField HeaderText="SL.NO."><HeaderTemplate>
                        <asp:TextBox ID="TxtServiceConfg" runat="server"  width="50"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvStock')"></asp:TextBox></HeaderTemplate>
                        <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
                    
                        <asp:TemplateField HeaderText="Item Name" SortExpression="strItemMasterName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="250px" runat="server" Text='<%# Bind("strItemMasterName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM" SortExpression="strUOM" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUOM" Width="50px" runat="server" Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Stock Qty" SortExpression="numStockQty" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblStockQty" Width="60px" runat="server" Text='<%# Bind("numStockQty") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /></asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Buy Price" SortExpression="numMRRPrice" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblBuyPrice" Width="60px" runat="server" Text='<%# Bind("numMRRPrice") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTTex" runat="server" Text="Total :"></asp:Label></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Value" SortExpression="TotalValue" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblTotalValue" Width="60px" runat="server" Text='<%# Bind("TotalValue") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /><FooterTemplate><asp:Label ID="lblTTTotalValue" runat="server" Text='<%# totalvalue %>'></asp:Label></FooterTemplate></asp:TemplateField>

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
