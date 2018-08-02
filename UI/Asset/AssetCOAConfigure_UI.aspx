<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetCOAConfigure_UI.aspx.cs" Inherits="UI.Asset.AssetCOAConfigure_UI" %>

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

     <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
             }
         });
</script>
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   
    

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        .auto-style3 {
            width: 166px;
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" /></div>
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="left"  >Asset Global COA Configuration</div>
   
                <table  class="tblrowodd" >
                <tr>
                <td style="text-align:right;"><asp:Label ID="LblContryOrigin"  Font-Size="Small" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="DdlBillUnit"  runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="DdlBillUnit_SelectedIndexChanged"></asp:DropDownList> </td>
              </tr>
          <tr>
               <td style="text-align:left;"><asp:Label ID="Label2" CssClass="lbl"  Font-Size="Small" runat="server" Text="JobStation : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlJobstation" runat="server"   CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="DdlJobstation_SelectedIndexChanged"></asp:DropDownList> </td>

                 </tr>
                  
                
                    <tr>
                <td style="text-align:right;"><asp:Label ID="Label1"  Font-Size="Small" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td class="auto-style3"><asp:DropDownList ID="ddlType"  runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
                    
                                </asp:DropDownList> </td>
                     </tr>
                   
                    
                      <tr>
                
             <td style="text-align:right"> <asp:Button ID="BtnView" runat="server" Text="View" OnClick="BtnView_Click" /></td>
                     
                        <td>   <asp:Button ID="BtnUpdate" runat="server" Text="Update on selection" OnClick="BtnUpdate_Click"  />
                        
                     </td>
                </tr>
      
                
                 <tr>
                     <td></td>
                     
                 </tr>
          
                </table>
      
      
          <table>

              <tr>
                 
                  <td>
               <asp:GridView ID="dgvGridView" runat="server"  Font-Bold="False" AutoGenerateColumns="False"   OnRowDeleting="dgvGridView_RowDeleting"
                AllowPaging="true"  OnPageIndexChanging="OnPageIndexChanging" PageSize="100">
                   <Columns>
                    <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox></HeaderTemplate>


                        <ItemTemplate><%# Container.DataItemIndex + 1 %>  </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="AssetID">
                           <ItemTemplate>
                               <asp:Label ID="strAssetCode" runat="server" Text='<%# Eval("strAssetID") %>'></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                           
                      <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfAsset" SortExpression="strNameOfAsset"/>
                       <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                       <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />

                    <asp:BoundField DataField="strAssetTypeName" HeaderText="AssetClass" SortExpression="strAssetTypeName" />
                    <asp:BoundField DataField="strCategoryName" HeaderText="AssetSubClass" Visible="false" SortExpression="strCategoryName" />                    
                    <asp:TemplateField HeaderText="CostCenter"> <ItemTemplate>                                
                    <asp:DropDownList ID="ddlCostcenter" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="ID" SelectedValue='<%#Bind("intCostcenterID") %>'    >
                    <asp:ListItem   Value="2">Select</asp:ListItem></asp:DropDownList>                        
                                     
                     <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="CostCenterUnitByGetData" TypeName="Purchase_DAL.Asset.AssetMaintenanceTDSTableAdapters.TblUnitNameTableAdapter">
                                         
                     <SelectParameters> <asp:ControlParameter ControlID="DdlBillUnit" DefaultValue="ID" Name="unit" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters> </asp:ObjectDataSource></ItemTemplate> </asp:TemplateField>  
                            
                    <asp:TemplateField HeaderText="GL.Code">
                                 <ItemTemplate>
                                   <asp:DropDownList ID="ddlCOA" runat="server" DataSourceID="OdsGlobalCOA" DataTextField="strCOAName" DataValueField="intGlobalCOA" SelectedValue='<%#Bind("intGlobalCOA") %>'></asp:DropDownList>
                                     <asp:ObjectDataSource ID="OdsGlobalCOA" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="DepreciationConfigGetData" TypeName="Purchase_DAL.Asset.AssetMaintenanceTDSTableAdapters.SprDepreciationConfigTableAdapter">
                                         <SelectParameters>
                                             <asp:Parameter Name="intType" DefaultValue="3" Type="Int32" />
                                             <asp:Parameter Name="XMLDEP" Type="Object" DefaultValue="" />
                                             <asp:Parameter Name="dtefrom" Type="DateTime" />
                                             <asp:Parameter Name="dteenddate" Type="DateTime" />
                                             <asp:ControlParameter ControlID="DdlBillUnit" Name="unitid" PropertyName="SelectedValue" Type="Int32" />
                                             <asp:Parameter Name="enroll" Type="Int32" />
                                         </SelectParameters>
                                     </asp:ObjectDataSource>
                                 </ItemTemplate>
                             </asp:TemplateField>
                            <asp:TemplateField HeaderText="AcusitionDate">
                                 <ItemTemplate>
                                  <asp:TextBox ID="TxtdteAcusition" runat="server" CssClass="txtBox" Text='<%# Bind("dtrAcusition") %>'></asp:TextBox>
                             <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteAcusition"></cc1:CalendarExtender> 
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="AcusitionValue" Visible="false">
                                 <ItemTemplate>
                                     <asp:TextBox ID="TxtAcusitionValue" runat="server" Text='<%# Bind("monLandedCost") %>'></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                        <asp:TemplateField HeaderText="TotalAcumulatedCost">
                                 <ItemTemplate>
                                     <asp:TextBox ID="TxtTotalAcumulatedCost" runat="server" Text='<%# Bind("monTAccumulatedCost") %>'></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                                                
                  <asp:TemplateField HeaderText="AccumulatedDep"> <ItemTemplate>                         
                  <asp:TextBox ID="TxtAccumulatedDep" runat="server" Text='<%# Bind("monAccumulatedDepeciation") %>'></asp:TextBox>
                  </ItemTemplate> </asp:TemplateField>
               <asp:TemplateField HeaderText="DepRate"> <ItemTemplate>                         
                <asp:TextBox ID="txtDepRate" runat="server" Text='<%# Bind("monRateOfDepeciation") %>'></asp:TextBox>
                </ItemTemplate> </asp:TemplateField>
                            
          <asp:CommandField DeleteText="Update" ShowDeleteButton="True" HeaderText="Update" />
                       <asp:TemplateField>
                           <HeaderTemplate>
                               <asp:CheckBox ID="chkHeader" runat="server" />
                           </HeaderTemplate>
                           <ItemTemplate>
                               <asp:CheckBox ID="chkRow" runat="server" />
                           </ItemTemplate>
                       </asp:TemplateField>
           </Columns>
           </asp:GridView>
           </td>
                  
                  
              </tr>
          </table>
        </div>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
