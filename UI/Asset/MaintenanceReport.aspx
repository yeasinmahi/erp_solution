<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceReport.aspx.cs" Inherits="UI.Asset.MaintenanceReport" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
     <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" /> 

    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url);
                return false;
            }
            return true;
        }
         function ReportDetalis(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=700,top=150,left=350');
             if (window.focus) { newwindow.focus() }
         }
         </script> 

    <script type="text/javascript">
        function Search_dgview(strKey, strGV) { 
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

         function Search_dgvServiceCost(strKey, strGV) { 
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

        function Search_dgvMaterial(strKey, strGV) { 
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

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 30px;
        }
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
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center">Maintenance Report</div>
      
          <table>
            <tr>
            <td   style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Jobstation"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlJobStation" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"></asp:DropDownList></td> 
             
            <td   style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Report Type"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
            <asp:ListItem Value="1" Text="Top Sheet"></asp:ListItem>
            <asp:ListItem Value="2" Text="Material Cost"></asp:ListItem>
            <asp:ListItem Value="3" Text="Service Cost"></asp:ListItem>
            </asp:DropDownList></td> 
            </tr> 
            <tr>                 
            <td style="text-align:right;"><asp:Label ID="LblFromDte" runat="server" CssClass="lbl" Text="From Date:"></asp:Label> </td> 
            <td> <asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDteJobEntranc" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender></td>                      
            <td style="text-align:right;">  <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date:"></asp:Label>  </td>
                        
            <td> <asp:TextBox ID="TxtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteTo">
            </cc1:CalendarExtender> </td> 
            <td><asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click" /></td>  
            </tr>
          </table>
         <table>
            <tr> 
            <td><asp:GridView ID="dgview" runat="server" AutoGenerateColumns="False" ShowFooter="true" AllowPaging="false" PageSize="8"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" Font-Size="Smaller" PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="Sl.N">
            <HeaderTemplate>
            <asp:TextBox ID="TextBox2" Width="75"   onkeyup="Search_dgview(this, 'dgview')" PlaceHolder="Search" runat="server"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Job Card"  Visible="true" SortExpression="intMaintenanceNo" > 
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lblJobCardOne" Text='<%# Bind("intMaintenanceNo") %>' OnClick="lblJobCardOne_Click"></asp:LinkButton>
                        </ItemTemplate>                         
            </asp:TemplateField>
            <%--<asp:BoundField DataField="intMaintenanceNo" HeaderText="Job Card" SortExpression="intMaintenanceNo" />--%>
            <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfAsset" SortExpression="strNameOfAsset" />
                <asp:BoundField DataField="strBilUnit" HeaderText="Bill Unit" SortExpression="strBilUnit" /> 
            <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" /> 
             <asp:BoundField DataField="strRepairType" HeaderText="RepairType" SortExpression="strRepairType" />  
            <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
            <asp:BoundField DataField="dteStart" HeaderText="StartDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteStart" />
            <asp:BoundField DataField="dteEnd" HeaderText="EndDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteEnd" />
            <asp:BoundField DataField="monMaterial" HeaderText="Material" SortExpression="monMaterial" />
            <asp:BoundField DataField="monService" HeaderText="Service" SortExpression="monService" />
            <asp:BoundField DataField="monTotal" HeaderText="Total" SortExpression="monTotal" />
             <asp:TemplateField HeaderText="Detalis">
              <ItemTemplate>
                <asp:Button ID="BtnMDetalis" CommandName="Detalis" CommandArgument='<%# Eval("intMaintenanceNo") %>' runat="server" Text="Detalis" OnClick="BtnMDetalis_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
                <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>

            <tr> 
            <td><asp:GridView ID="dgvMaterial" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" 
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" Font-Size="Smaller"  PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="Sl.N">
                 <HeaderTemplate>
            <asp:TextBox ID="TextBox4" Width="75"   onkeyup="Search_dgvMaterial(this, 'dgvMaterial')" PlaceHolder="Search" runat="server"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Job Card" Visible="true" SortExpression="intMaintenanceNo" > 
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lblJobCardTwo" Text='<%# Bind("intMaintenanceNo") %>' OnClick="lblJobCardTwo_Click"></asp:LinkButton>
                        </ItemTemplate>                         
            </asp:TemplateField>
             <%--<asp:BoundField DataField="intMaintenanceNo" HeaderText="Job Card" SortExpression="intMaintenanceNo" />--%>
            <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfAsset" SortExpression="strNameOfAsset" />
             <asp:BoundField DataField="strBilUnit" HeaderText="Bill Unit" SortExpression="strBilUnit" />
            <asp:BoundField DataField="strServiceName" HeaderText="ServiceName" SortExpression="strServiceName" /> 
            <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" /> 
             <asp:BoundField DataField="strRepairType" HeaderText="RepairType" SortExpression="strRepairType" />  
            <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
            <asp:BoundField DataField="dteStart" HeaderText="StartDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteStart" />
            <asp:BoundField DataField="dteEnd" HeaderText="EndDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteEnd" />
            <asp:BoundField DataField="strSpareParts" HeaderText="Spare Parts" SortExpression="strSpareParts" />
           <asp:BoundField DataField="numQty" HeaderText="Quantity" SortExpression="numQty" />
            <asp:BoundField DataField="monMaterial" HeaderText="Material Cost" SortExpression="monMaterial" />
             
            </Columns>
                <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>

        <tr> 
            <td><asp:GridView ID="dgvServiceCost" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt"  Font-Size="Smaller"  PagerStyle-CssClass="pgr"
                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Vertical"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="Sl.N">
            <HeaderTemplate>
            <asp:TextBox ID="TextBox3" Width="75"   onkeyup="Search_dgvServiceCost(this, 'dgvServiceCost')" PlaceHolder="Search" runat="server"></asp:TextBox>
            </HeaderTemplate>
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Job Card"  Visible="true" SortExpression="intMaintenanceNo" > 
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lblJobCardThree" Text='<%# Bind("intMaintenanceNo") %>' OnClick="lblJobCardThree_Click"></asp:LinkButton>
                        </ItemTemplate>                         
            </asp:TemplateField>
           <%--<asp:BoundField DataField="intMaintenanceNo" HeaderText="Job Card" SortExpression="intMaintenanceNo" />--%>
            <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfAsset" SortExpression="strNameOfAsset" /> 
            <asp:BoundField DataField="strBilUnit" HeaderText="Bill Unit" SortExpression="strBilUnit" />
            <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" /> 
             <asp:BoundField DataField="strRepairType" HeaderText="RepairType" SortExpression="strRepairType" />  
            <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
            <asp:BoundField DataField="dteStart" HeaderText="StartDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteStart" />
            <asp:BoundField DataField="dteEnd" HeaderText="EndDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteEnd" />
             <asp:BoundField DataField="strServiceName" HeaderText="ServiceName" SortExpression="strServiceName" />  
            <asp:BoundField DataField="monService" HeaderText="Service Cost" SortExpression="monService" />
            
            </Columns>
                <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>
         </table>
    
  </table> 
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>