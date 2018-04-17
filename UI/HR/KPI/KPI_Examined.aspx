<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPI_Examined.aspx.cs" Inherits="UI.HR.KPI.KPI_Examined" %>

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
        
        function IssuePopUp(url) {
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=650,width=900,top=50,left=230, close=no');
            if (window.focus) { newwindow.focus() }
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
    <div class="tabs_container" align="Center" >Employee Performance Assessment Examine by Supervisor</div>
   
            <table class="tbldecoration">
              <tr>
                  <td>
               <asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False"  >
                   <Columns>
                    
                            
                             <asp:TemplateField HeaderText="SL.N">
                                 <HeaderTemplate>
                                       
                         <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>
                               
                                    
                                    </HeaderTemplate>
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>

                        
                              <asp:TemplateField HeaderText="EmpID">
                                  <ItemTemplate>
                                      <asp:Label ID="intEnrollment" runat="server" Text='<%# Eval("intEmployeeID") %>'></asp:Label>
                                  </ItemTemplate>
                        </asp:TemplateField>
                             
                    <asp:BoundField DataField="strEmployeeName" HeaderText="EmpName" SortExpression="strEmployeeName"/>
                     
                       <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                       <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" />
                       <asp:BoundField DataField="EmpStatus" HeaderText="Department" Visible="false" SortExpression="EmpStatus" />
                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" />
                               
                         
                             <asp:TemplateField HeaderText="Detalis">
                                 <ItemTemplate>
                                     <asp:Button ID="btnDetalis" runat="server" Text="Detalis" CommandName="Detalis" CommandArgument='<%#GetJSFunctionString( Eval("intEmployeeID"),Eval("EmpStatus")) %>' OnClick="btnDetalis_Click" />
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
