<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Maintenance_Bill.aspx.cs" Inherits="UI.Asset.Vehicle_Maintenance_Bill" %>



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
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       

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
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   
     <script>
         

         function ReportDetalis(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }
        
         </script> 

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
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
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="Center" >Asset Maintenance Service</div>
   
                <table>
                <div class="tabs_container">Billing Report :</div> 
                   
              
               <tr>
             <td>
                 
          <asp:GridView ID="dgview" runat="server" AutoGenerateColumns="False">
              <Columns>
                   
                   <asp:TemplateField HeaderText="Sl.N"> <ItemTemplate>   <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                                     
                                    
                                
                   <asp:BoundField DataField="intMaintenanceNo" HeaderText="WO.No" SortExpression="intMaintenanceNo" />
                  <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
                  <asp:BoundField DataField="strNameOfAsset" HeaderText="Name" SortExpression="strNameOfAsset" />
                  <asp:BoundField DataField="strServiceName" HeaderText="ServiceName" SortExpression="strServiceName" />
                  <asp:BoundField DataField="Assignto" HeaderText="Assign To" SortExpression="Assignto" />
                  <asp:BoundField DataField="ServiceType" HeaderText="ServiceType" SortExpression="ServiceType" />
                  <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
                   <asp:BoundField DataField="dteStartDate" HeaderText="StartDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteStartDate" />
                   <asp:BoundField DataField="dteEndDate" HeaderText="EndDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteEndDate" />
                   <asp:TemplateField HeaderText="Detalis">
                       <ItemTemplate>
                           <asp:Button ID="BtnMDetalis" CommandName="Detalis" CommandArgument='<%# Eval("intMaintenanceNo") %>' runat="server" Text="Detalis" OnClick="BtnMDetalis_Click" />
                       </ItemTemplate>
                   </asp:TemplateField>
              </Columns>
                 </asp:GridView>
                 
             </td>
          
          
         
          
         
       
                  
                </div>
                </table>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
