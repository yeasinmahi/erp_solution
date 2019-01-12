<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceWorkOrderPopUp.aspx.cs" Inherits="UI.Asset.MaintenanceWorkOrderPopUp" %>


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
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       

    <script>   function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
        function RefreshParent() {
            window.opener.location.reload();
            //if (window.opener != null && !window.opener.closed) {
            //    window.opener.location.reload();
            //}
        }

    </script> 
   <script>
       $(document).ready(function () {
           SearchTextemp();
       });
       function Changeds() {
           document.getElementById('HdfTechnicinSearchbox').value = 'true';
       }
       function SearchTextemp() {
           $("#TxtAssign").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       type: "POST",
                       contentType: "application/json;",
                       url: "MaintenanceWorkOrderPopUp.aspx/GetAutoCompleteDataemp",
                       data: "{'strSearchKeyemp':'" + document.getElementById('TxtAssign').value + "'}",
                       dataType: "json",
                       success: function (data) {
                           response(data.d);
                       },
                       error: function (result) {

                       }
                   });
               }
           });
       }

    </script>

       <script>
           $(document).ready(function () {
               SearchTextItem();
           });
           function ChangedItem() {
               document.getElementById('HiddenItem').value = 'true';
           }
           function SearchTextItem() {
               $("#SearchItem").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           type: "POST",
                           contentType: "application/json;",
                           url: "MaintenanceWorkOrderPopUp.aspx/GetAutoCompleteDataItem",
                           //data: "{'strSearchKeyItem':'" + document.getElementById('SearchItem').value + "'}",
                           data: '{"Uid":"' + $("#HdnUnit").val() + '","strSearchKeyItem":"' + document.getElementById('SearchItem').value + '"}',
                           dataType: "json",
                           success: function (data) {
                               response(data.d);
                           },
                           error: function (result) {

                           }
                       });
                   }
               });
           }

    </script>
     <script>
         $(document).ready(function () {
             SearchTextempIndent();
         });
         function ChangedIndent() {
             document.getElementById('HiddenQc').value = 'true';
         }
         function SearchTextempIndent() {
             $("#TxtTechnichinSearch").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "MaintenanceWorkOrderPopUp.aspx/GetAutoCompleteDataempstIndent",
                         data: "{'strSearchKeyemp':'" + document.getElementById('TxtTechnichinSearch').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {

                         }
                     });
                 }
             });
         }

    </script>
     <script>
         function Registration(url) {
             window.location.href("WorkOrderPartsPopUp.aspx")
             //newwindow =window.open(url,' ', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=180, close=no');
             //if (window.focus) { newwindow.focus() }
         } 
         function sp(reqsid) {
             window.open('ServiceMaterialsPopup.aspx?intID=' + reqsid, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
         }
         </script> 
   
    <script type="text/javascript"> 
        function funConfirmAll() { 
        var confirm_value = document.createElement("INPUT"); 
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
        else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnConfirm" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />  <asp:HiddenField ID="HdnAssetid" runat="server" />        
    <div class="tabs_container" align="Center">Maintenance Services </div>
   
         <table  border="1px" width="900" class="tblrowodd">
            <tr> 
            <td style="text-align:right;"> <asp:Label ID="Lbblorder" runat="server" CssClass="lbl" Text="Work Order#:"></asp:Label></td> 
            <td style="text-align:left;"> <asp:TextBox ID="TxtOrder" runat="server" Enabled="false" CssClass="txtBox" Font-Bold="False"></asp:TextBox> 
            <td style="text-align:right;"><asp:Label ID="LblStatus" runat="server" CssClass="lbl" Text="Status:"></asp:Label> </td>
            <td style="text-align:left;"><asp:DropDownList ID="DdlStatus" runat="server" CssClass="ddList" Font-Bold="False">
            <asp:ListItem>Open</asp:ListItem>
            <asp:ListItem>Pending</asp:ListItem>
            <asp:ListItem>Wating for parts</asp:ListItem>
            <asp:ListItem>Close</asp:ListItem>
            </asp:DropDownList> 
            <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Reparing Type:"></asp:Label></td> 
            <td style="text-align:left;"><asp:DropDownList ID="DdlReType" runat="server" CssClass="ddList" Font-Bold="False">
            <asp:ListItem>Prenventive</asp:ListItem> <asp:ListItem>Repair</asp:ListItem> </asp:DropDownList></td>  
            </tr>
            <tr> 
            <td style="text-align:right;"><asp:Label ID="LbldteStarted" runat="server" CssClass="lbl" Text="Start Date:"></asp:Label></td>
            <td><asp:TextBox ID="TxtdteStarted" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteStarted"></cc1:CalendarExtender>  

            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Priority:"></asp:Label> </td>
            <td style="text-align:left;"><asp:DropDownList ID="DdlPriority" runat="server" CssClass="ddList" Font-Bold="False">
            <asp:ListItem>Normal</asp:ListItem><asp:ListItem>High</asp:ListItem><asp:ListItem>Low</asp:ListItem></asp:DropDownList>
            
            <td style="text-align:right;"><asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Cost Center:"></asp:Label> </td>
            <td style="text-align:left;"><asp:DropDownList ID="DdlCostCenter" runat="server" CssClass="ddList" Font-Bold="False">
            </asp:DropDownList> 
            </tr> 
             </table>
         <table  border="1px" width="900" class="tblroweven">
            
             <tr>
                 <td class="auto-style1">Assign To</td>
               
                  <td class="auto-style1" style="text-align:left;">
                             <asp:TextBox ID="TxtAssign" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: Changeds();" placeholder="Please Search Enroll" Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" /></td>
                

                     <td class="auto-style1" style="text-align:right;">
                         <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Notes:"></asp:Label>
                     </td>
                     <td class="auto-style1" style="text-align:left;">
                         <asp:TextBox ID="TxtNotes" runat="server" CssClass="txtBox" Font-Bold="False" Height="34px" Width="455px"></asp:TextBox>
                     </td>
                
             </tr>
             </table>
         <table>
            <tr>
            <td class="auto-style1" style="text-align:right;">
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Present Mileage:"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align:left;">
            <asp:TextBox ID="TxtPresentMilege" runat="server" TextMode="Number" CssClass="txtBox" ForeColor="Green" Width="110px" Font-Bold="False"  ></asp:TextBox>
            </td>
            <td class="auto-style1" style="text-align:right;">
            <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Next Mileage:"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align:left;">
            <asp:TextBox ID="TxtNextMilege" runat="server" CssClass="txtBox"  TextMode="Number" Width="110px" Font-Bold="False"  ></asp:TextBox>
                     
            </td><td><asp:Label ID="lbHevvy" runat="server" CssClass="lbl" Text="Maintenance Type:"></asp:Label></td>
            <td> <asp:DropDownList ID="DdlHevvyVehicle"    runat="server" ForeColor="Green" CssClass="ddList" Font-Bold="False"  Width="110px">
            <asp:ListItem Value="0">Light Vehicle</asp:ListItem>
            <asp:ListItem Value="1">Heavy Vehicle</asp:ListItem> 
            </asp:DropDownList></td> 
            </tr>

             <tr>
                  <td class="auto-style1" style="text-align:right;">
            <asp:Label ID="lblDriver" runat="server" CssClass="lbl" Text="Driver Name:"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align:left;">
                <asp:TextBox ID="txtDriverName" runat="server" CssClass="txtBox" Width="110px" Font-Bold="False"  ></asp:TextBox>
            
            </td> 
            <td class="auto-style1" style="text-align:right;">
            <asp:Label ID="lblContact" runat="server" CssClass="lbl" Text="Contact No:"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align:left;">
             <asp:TextBox ID="txtContactNo" runat="server" CssClass="txtBox" Width="110px" Font-Bold="False"  ></asp:TextBox>           
            </td>
             <td class="auto-style1" style="text-align:right;">
            <asp:Label ID="lblUser" runat="server" CssClass="lbl" Text="User Name:"></asp:Label>
            </td>
            <td class="auto-style1" style="text-align:left;">
             <asp:TextBox ID="txtUser" runat="server" CssClass="txtBox" Width="110px" Font-Bold="False"  ></asp:TextBox>           
            </td>
             </tr>
             <tr>
            <td colspan="3" class="auto-style1" style="text-align:right;">
            <asp:Label ID="lblunit" runat="server" ForeColor="Red" CssClass="lbl" Text="Bill Unit:"></asp:Label>
            </td>
           
             </tr>
           </table> 
          <div class="tabs_container" >Maitenance Task Services </div>
         <table  border="1px" width="900" class="tblrowodd">
             <tr>

        <td class="auto-style1" style="text-align:right;">ServiceType</td> <td><asp:RadioButton ID="RadioPreventive" Text="Preventive" AutoPostBack="True" runat="server" OnCheckedChanged="RadioPreventive_CheckedChanged"  />
             <asp:RadioButton ID="RadioRepair" Text="Common Repair Item" runat="server" AutoPostBack="True" OnCheckedChanged="RadioRepair_CheckedChanged" /></td>

        
                 
                 <tr>
                     <td style="text-align:right;">
                         <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Service:"></asp:Label>
                     </td>
                     <td style="text-align:left;">
                         <asp:DropDownList ID="DdlService" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True" OnSelectedIndexChanged="DdlService_SelectedIndexChanged">
                         </asp:DropDownList>
                         <td style="text-align:right;">
                             <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Type:"></asp:Label>
                         </td>
                         <td style="text-align:left;">
                             <asp:DropDownList ID="DdlType" runat="server" CssClass="ddList" Font-Bold="False">
                                 <asp:ListItem>Normal</asp:ListItem>
                                 <asp:ListItem>High</asp:ListItem>
                                 <asp:ListItem>Low</asp:ListItem>
                             </asp:DropDownList>
                             <td style="text-align:right;">
                                 <asp:Label ID="LblCost" runat="server" CssClass="lbl" Text="Service Cost:"></asp:Label>
                             </td>
                             <td style="text-align:left;">
                                 <asp:TextBox ID="TxtCost" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                 <td style="text-align:right;">
                                     <asp:Button ID="BtnMTask" runat="server" OnClick="BtnMTask_Click" Text="Add" />
                                 </td>
                             </td>
                         </td>
                     </td>
                 </tr>

       </table> 
          <table border="1px" width="900" class="tblrowodd" >
             <tr> <td style="text-align:right;"><asp:Button ID="btnclose" BackColor="YellowGreen" runat="server" Text="Back" OnClick="btnclose_Click"/>
                 <asp:Button ID="BtnSave" BackColor="YellowGreen" runat="server" Text="Save" OnClientClick="funConfirmAll();" OnClick="BtnSave_Click"   /> 
                 
                  </td>    

             </tr>
              <tr>
                     <td><asp:GridView ID="dgvTask" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="ID" Visible="false">
                                 <ItemTemplate>
                                     <asp:Label ID="lblServiceID" Text='<%# Bind("intID") %>' runat="server"/>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:BoundField HeaderText="ID" DataField="intID" SortExpression="intID" />
                             <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                             <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
                             <asp:TemplateField HeaderText="Service Cost">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtServiceCharge" Text='<%# Bind("monServiceCost","{0:n2}") %>' runat="server"    />
                                 </ItemTemplate>
                             </asp:TemplateField>
                              
                             <asp:TemplateField HeaderText="Description">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtServiceDesc" Width="250px"  Text='<%# Bind("strDescription") %>' runat="server"    />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Update">
                                 <ItemTemplate>
                                     <asp:Button ID="btnServiceCharge" runat="server" Text="Update" OnClientClick="funConfirmAll();"  BackColor="LightYellow"   OnClick="btnServiceCharge_Click"/>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="AddService">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnService" runat="server" Text="Add Service"  BackColor="YellowGreen" CommandName="Detalis"  CommandArgument='<%# Eval("intID")%>' OnClick="BtnService_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                         </asp:GridView></td>
                    
                 </tr>
      
         </table>
         <td><asp:CheckBox ID="CheckBoxIndent" autopostback="true"  Font-Bold="true" Font-Size="Large" Text="Do you Want to Services Indent" runat="server" /></td>
         <table  border="1px" width="900" class="tblrowodd" >
             
              <tr >
          

          <td style="text-align:right;"> <asp:Label ID="LblUnitW" runat="server" CssClass="lbl" font-size="small" Text="Unit :"></asp:Label></td>
         <td style="text-align: left;" class="auto-style3">
          <asp:DropDownList ID="DdlUnitName" runat="server" backColor="WhiteSmoke" CssClass="ddList" Font-Bold="False" AutoPostBack="True" > 
         </asp:DropDownList>
                     
             </tr>
             <tr>
                 
               <td style="text-align:right;"> <asp:Label ID="LblSearchI" runat="server" CssClass="lbl" font-size="small" Text="Item :"></asp:Label></td>
               <td  style="text-align:left;"> <asp:TextBox ID="SearchItem" backColor="WhiteSmoke" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: ChangedItem();"  Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HiddenItem" runat="server" /><asp:HiddenField ID="HiddenItemcode" runat="server" /></td>
              <asp:HiddenField ID="HdnUnit" runat="server" />

       <td style="text-align:right;"> <asp:Label ID="LblQty" runat="server" font-size="small" CssClass="lbl" Text="Quentity:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtQty" runat="server" backColor="WhiteSmoke" CssClass="txtBox" Font-Bold="False" ></asp:TextBox>
        

           <td style="text-align:right;"> <asp:Label ID="LblIType" runat="server" CssClass="lbl" font-size="small" Text="Type :"></asp:Label></td>
           <td style="text-align: left;" class="auto-style3">
             <asp:DropDownList ID="DdlIType" runat="server" CssClass="ddList" backColor="WhiteSmoke" Font-Bold="False" AutoPostBack="True">
             <asp:ListItem>Fabrication</asp:ListItem></asp:DropDownList>
                      
                     
      </tr>
          
              <tr>
                  <td style="text-align:right;"> <asp:Label ID="LblQcperson" runat="server" font-size="small" CssClass="lbl" Text="QC Person:"></asp:Label></td>
              <td  style="text-align:left;"> <asp:TextBox ID="TxtTechnichinSearch" backColor="WhiteSmoke" runat="server" CssClass="txtBox" AutoPostBack="false" onchange="javascript: ChangedIndent();" placeholder="Please Search Enroll" Font-Bold="False"></asp:TextBox>  
             <asp:HiddenField ID="HiddenQc" runat="server" /><asp:HiddenField ID="HiddenQCCode" runat="server" /></td>
     
                  
                   
             <td style="text-align:right;"> <asp:Label ID="LblDueDate" runat="server" font-size="small" CssClass="lbl" Text="Due Date:"></asp:Label></td>
           <td><asp:TextBox ID="Txtdte" runat="server" backColor="WhiteSmoke" CssClass="txtBox"></asp:TextBox>
           <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="Txtdte"></cc1:CalendarExtender></td> 
         
           <td style="text-align:right;"> <asp:Label ID="LblPurpose" runat="server" font-size="small" CssClass="lbl" Text="Purpose:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtPurpose" runat="server" backColor="WhiteSmoke" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
           </tr>
             </table>

              <table border="1px" width="900" class="tblrowodd" >
             <tr> <td style="text-align:right;"><asp:Button ID="BtnAddIndent" BackColor="YellowGreen" runat="server" Text="Add" OnClick="BtnAddIndent_Click" />
                 <asp:Button ID="BtnSubmitIn" BackColor="YellowGreen" runat="server" Text="Submit Indent" OnClick="BtnSubmitIn_Click"    /> 
                 
                  </td>    

             </tr>
              <tr>
                  <td>
                      <asp:GridView ID="dgvservice" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" OnRowDeleting="dgvservice_RowDeleting"  >
                          <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                              <asp:TemplateField HeaderText="ItemSpecification">
                                  <ItemTemplate>
                                      <asp:Label ID="LblItemS" runat="server" Text='<%# Bind("itemName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle Width="70px"></ItemStyle></asp:TemplateField>
                              <asp:TemplateField HeaderText="ItemValue">
                                  <ItemTemplate>
                                      <asp:Label ID="LblItemValue" runat="server" Text='<%# Bind("itemvalue") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Qty">
                                  <ItemTemplate>
                                      <asp:Label ID="Lblqty" runat="server"  autopostback="true" Text='<%# Bind("qty") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="date">
                                  <ItemTemplate>
                                      <asp:Label ID="Lbldate" runat="server"  autopostback="true" Text='<%# Bind("dtedate") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText = "QcPerson">
                        <ItemTemplate>
                            <asp:Label ID="QcpersonaN" runat="server" Text='<%# Bind("qcpersonName") %>' ></asp:Label>
                             </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="QcPersonItem">
                                  <ItemTemplate>
                                      <asp:Label ID="lblQcPersonalValue" runat="server" Text='<%# Bind("qcpersonvalue") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="QCPurpose">
                                  <ItemTemplate>
                                      <asp:Label ID="LblqcPurpose" runat="server" Text='<%# Bind("purpose") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:CommandField HeaderText="Clear" ShowDeleteButton="True" />
                          </Columns>
                        
                      </asp:GridView>
                      </td>
                  </tr>
                  <tr>
                      <td>
                      <asp:GridView ID="dgvSrviceIndentView" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False"   >
                          <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                              <asp:TemplateField HeaderText="ItemSpecification">
                                  <ItemTemplate>
                                      <asp:Label ID="LblItemSs" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle Width="70px"></ItemStyle></asp:TemplateField>
                              <asp:TemplateField HeaderText="Qty">
                                  <ItemTemplate>
                                      <asp:Label ID="LblItemValues" runat="server" Text='<%# Bind("monqty") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Due Date">
                                  <ItemTemplate>
                                      <asp:Label ID="Lblqtys" runat="server"  autopostback="true" Text='<%# Bind("dteDueDate") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Issue Date">
                                  <ItemTemplate>
                                      <asp:Label ID="Lbldates" runat="server"  autopostback="true" Text='<%# Bind("dteDate") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText = "Purpose">
                        <ItemTemplate>
                            <asp:Label ID="QcpersonaN" runat="server" Text='<%# Bind("strPurpose") %>' ></asp:Label>
                             </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="QC Person">
                                  <ItemTemplate>
                                      <asp:Label ID="lblQcPersonalValues" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Purpose">
                                  <ItemTemplate>
                                      <asp:Label ID="LblqcPurposes" runat="server" Text='<%# Bind("strPurpose") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              
                              <asp:BoundField DataField="strIndentType" HeaderText="Type" SortExpression="strIndentType" />
                              <asp:BoundField DataField="strstatus" HeaderText="Status" SortExpression="strstatus" />
                              
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
