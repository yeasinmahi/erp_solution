<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depreciation_UI.aspx.cs" Inherits="UI.Asset.Depreciation_UI" %>

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

        function Validation() {  
            var dtefrom = document.getElementById("txtDteFrom").value; 
            var dteTo = document.getElementById("txtdteTo").value; 

            if ($.trim(dtefrom).length < 3 ||
                $.trim(dtefrom) == "" ||
                $.trim(dtefrom) == null ||
                $.trim(dtefrom) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Fill-Up From Date');
                return false
            }
            else if ($.trim(dteTo).length ==0 ||
                $.trim(dteTo) == "" ||
                $.trim(dteTo) == null ||
                $.trim(dteTo) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select To Date');
                return false
            } 
                else if ($.trim(dteTo)> $.trim(dteTo)||
                $.trim(dteTo) == "" ||
                $.trim(dteTo) == null ||
                $.trim(dteTo) == undefined) {
                document.getElementById("hdnPreConfirm").value = "0";
                alert('Please Select To Date');
                return false
            } 
            else {
                var confirmValue = document.createElement("INPUT");
                confirmValue.type = "hidden";
                confirmValue.name = "confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirmValue.value = "Yes";
                    document.getElementById("hdnPreConfirm").value = "1";
                } else {
                    confirmValue.value = "No";
                    document.getElementById("hdnPreConfirm").value = "0";
                    return false
                }
                return true
                
            }


      }

        </script>


   
            
 <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        
        }
        .ddList {}
        .txtBox {}
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
       <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            <div class="leaveApplication_container">
    <div class="tabs_container" align="Center" >Asset Depreciation</div>
   
                <table class="tblrowodd" >
                <tr>
                <td style="text-align:right;"> <asp:Label ID="Label3" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Unit-:"></asp:Label></td>
                <td style="text-align: left;"><asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged" ></asp:DropDownList> </td>
               
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Type"></asp:Label></td>
                    
                <td style="text-align: left;"> <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">                   
                <asp:ListItem Value="1">Single Asset</asp:ListItem> <asp:ListItem Value="2">Multiple Asset</asp:ListItem>  </asp:DropDownList> </td> 
                </tr>
                <tr>
                       
                <td style="text-align:right;"><asp:Label ID="LblAsset" runat="server" CssClass="lbl" Text="From Date"  Font-Bold="true"></asp:Label></td> 
                <td> <asp:TextBox ID="txtDteFrom" runat="server" Font-Bold="true" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderMonthly" runat="server" Format="yyyy-MMMM-dd" TargetControlID="txtDteFrom"></cc1:CalendarExtender> </td>
                            
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="To Date"  Font-Bold="true"></asp:Label></td> 
                <td> <asp:TextBox ID="txtdteTo" runat="server" Font-Bold="true" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtdteTo_TextChanged"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MMMM-dd" TargetControlID="txtdteTo"></cc1:CalendarExtender> </td>

                </tr>
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Asset ID"  Font-Bold="true"></asp:Label></td> 
               <td style="text-align:left;"> <asp:TextBox ID="txtAssetID" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"  ></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAssetID"
                 ServiceMethod="GetAssetTransaction" MinimumPrefixLength="1" CompletionSetCount="1"
                 CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                 CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"></cc1:AutoCompleteExtender></td>
                        
                <td colspan="2" style="text-align: right;"><asp:Button ID="btnDepSubmit" OnClientClick="return Validation(this);" runat="server" Text="Depreciation Charge" OnClick="btnDepSubmit_Click"  />
                <asp:Button ID="btnImpairment" runat="server" Text="Impirment" OnClientClick="return Validation(this);" OnClick="btnImpairment_Click"  /> 
                 <asp:Button ID="btnShow" runat="server" Text="View" OnClick="btnShow_Click" /></td>
                  
                </tr>
                </table>
        
               <table>
                <tr>
                
                <td><asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False"  ShowFooter="true"   BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <asp:TemplateField HeaderText="SL.N"> <HeaderTemplate> 
                <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox> </HeaderTemplate>
               
                <ItemTemplate>  <%# Container.DataItemIndex + 1 %> </ItemTemplate></asp:TemplateField>
              
                <asp:TemplateField HeaderText="Unit"><ItemTemplate>                
                <asp:Label ID="strunitID" runat="server" Text='<%# Eval("strUnit") %>'></asp:Label>
                </ItemTemplate> </asp:TemplateField> 
                <asp:BoundField DataField="strAssetID" HeaderText="AssetID" SortExpression="strAssetID"/>                    
               <asp:BoundField DataField="strAssetName" HeaderText="AssetName" SortExpression="strAssetName" />
                <asp:BoundField DataField="strAssetType" HeaderText="AssetType" SortExpression="strAssetType" />                  
                <asp:BoundField DataField="strMajorCategory" HeaderText="MajorCategory" SortExpression="strMajorCategory" />         
               
                <asp:BoundField DataField="monCostValue" HeaderText="CostValue" SortExpression="monCostValue" />                  
                <asp:BoundField DataField="monAccumulatedDep" HeaderText="AccumulatedDep" SortExpression="monAccumulatedDep" />
                <asp:BoundField DataField="monRateOfDep" HeaderText="RateOfDep%" SortExpression="monRateOfDep" />
                <asp:BoundField DataField="monDepChargeDuringPeriod" HeaderText="DepChargeDuringPeriod" SortExpression="monDepChargeDuringPeriod" />                
                </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
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
