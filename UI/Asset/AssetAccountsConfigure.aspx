<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAccountsConfigure.aspx.cs" Inherits="UI.Asset.AssetAccountsConfigure" %>

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
            $(document).ready(function () {
                SearchText();
            });
            function Changed() {
                document.getElementById('hdfSearchBoxTextChange').value = 'true';
            }
            function SearchText() {
                $("#txtJobstationName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "AssetAccountsConfigure.aspx/GetAutoSearchingJobStationName",
                            data: "{'strSearchKey':'" + document.getElementById('txtJobstationName').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    }
                });
            }


    </script>

       <script type="text/javascript">
            $(document).ready(function () {
                SearchTextusejobstation();
            });
            function Changed() {
                document.getElementById('hdfSearchBoxTextChange').value = 'true';
            }
            function SearchTextusejobstation() {
                $("#txtUseJobstationName").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "AssetAccountsConfigure.aspx/GetAutoSearchingUseJobStation",
                            data: "{'strSearchKey':'" + document.getElementById('txtUseJobstationName').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    }
                });
            }


    </script>
       <script type="text/javascript">
            $(document).ready(function () {
                SearchTextBRTAVheicletype();
            });
            function Changed() {
                document.getElementById('hdfSearchBoxTextChange').value = 'true';
            }
            function SearchTextBRTAVheicletype() {
                $("#txtVheicleType").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            type: "POST",
                            contentType: "application/json;",
                            url: "AssetAccountsConfigure.aspx/GetAutoSearchingBRTAVheicleType",
                            data: "{'strSearchKey':'" + document.getElementById('txtVheicleType').value + "'}",
                            dataType: "json",
                            success: function (data) {
                                response(data.d);
                            },
                            error: function (result) {
                                alert("Error");
                            }
                        });
                    }
                });
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="Center" >Vehicle Information Update</div>
   
                <table class="tblrowodd" >
                <tr>
                <td style="text-align:right;"><asp:Label ID="LblContryOrigin" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlBillUnit" runat="server"  CssClass="ddList" AutoPostBack="True" OnSelectedIndexChanged="DdlBillUnit_SelectedIndexChanged"></asp:DropDownList> </td>

                </tr>
                  <%--  <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="JobStation : "></asp:Label></td>
                <td><asp:DropDownList ID="DdlJobstation" runat="server"  CssClass="ddList" AutoPostBack="True"></asp:DropDownList> </td>

                </tr>--%>
                    <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="JobStation : "></asp:Label></td>
                <%--<td><asp:DropDownList ID="DdlJobstation" runat="server"  CssClass="ddList" AutoPostBack="True"></asp:DropDownList> </td>--%>
                <td><asp:TextBox ID="txtJobstationName" runat="server" BackColor="#ffffff" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
                </tr>
                <tr>
               
                <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Asset Type : "></asp:Label></td>
                <td><asp:DropDownList ID="DropDownList1" runat="server"  CssClass="ddList" AutoPostBack="True" >
                    <asp:ListItem>Motor Vehicle</asp:ListItem>
                                </asp:DropDownList> </td>

                </tr>
                      
      
                 <tr>
                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="In Use Jobstation : "></asp:Label></td>
               <%-- <td><asp:DropDownList ID="DdlUseJob" runat="server"  CssClass="ddList"></asp:DropDownList> </td>--%>
               <td><asp:TextBox ID="txtUseJobstationName" runat="server" BackColor="#ffffff" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
                     </tr>
                    <tr>

                <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="BRTA Vehicle Type: "></asp:Label></td>
                <%--<td><asp:DropDownList ID="DdlBRTAType" runat="server"  CssClass="ddList"></asp:DropDownList> </td>--%>
               <td><asp:TextBox ID="txtVheicleType" runat="server" BackColor="#ffffff" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
                        </tr>
                    <tr>
                 <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Owner Name: "></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="TxtOwner" CssClass="txtBox" runat="server"></asp:TextBox></td>
                    
                </tr>
                 <tr>
                     <td></td>
                     <td> <asp:Button ID="BtnView" runat="server" Text="View" OnClick="BtnView_Click" />
                     
                           <asp:Button ID="BtnUpdate" runat="server" Text="Update on selection" OnClick="BtnUpdate_Click" />
                        
                     </td>
                 </tr>
          
                </table>
        
          <table>
              <tr>
                  <td>
               <asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False">
                   <Columns>
                             <asp:TemplateField HeaderText="SL.N">
                                 <HeaderTemplate>
                                       
                         <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>
                               
                                    
                                    </HeaderTemplate>
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>

                        
                              <asp:TemplateField HeaderText="AssetID">
                                  <ItemTemplate>
                                      <asp:Label ID="strAssetCode" runat="server" Text='<%# Eval("strAssetID") %>'></asp:Label>
                                  </ItemTemplate>
                        </asp:TemplateField>
                             
                    <asp:BoundField DataField="strNameOfAsset" HeaderText="Vehicle No" SortExpression="strNameOfAsset"/>
                       <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                       <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                   
                  
                        <asp:BoundField DataField="strInUseJobstation" HeaderText="InUseJobstation" SortExpression="strInUseJobstation" />         
                             <asp:BoundField DataField="strItem" HeaderText="BRTA Type" SortExpression="strItem" />
                         <asp:BoundField DataField="strVehicleRegisteredTo" HeaderText="RegisteredTo" SortExpression="strVehicleRegisteredTo" />
                    <asp:BoundField DataField="strAssetTypeName" HeaderText="Type" SortExpression="strAssetTypeName" />
                    <asp:BoundField DataField="strCategoryName" HeaderText="Category" SortExpression="strCategoryName" />
                    
                 
                   
                 
                            
                            
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
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
