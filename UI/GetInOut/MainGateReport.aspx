<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainGateReport.aspx.cs" Inherits="UI.GetInOut.MainGateReport" %>

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
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        </style>
    </head>
<body>
   
   <%--  <script type="text/javascript">
         // for check all checkbox   
         function CheckAll(Checkbox) {
             var GridVwHeaderCheckbox = document.getElementById("<%=dgvGetpassOut.ClientID %>");
             for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                 GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
             }
         }
   </script> 
    <script type="text/javascript">
        // for check all checkbox   
        function CheckAll(Checkbox) {
            var GridVwHeaderCheckbox = document.getElementById("<%=GridView1.ClientID %>");
            for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
   </script> --%>
    <%-- <script type="text/javascript">
         // for check all checkbox   
         function CheckAll(Checkbox) {
             var GridVwHeaderCheckbox = document.getElementById("<%=Finisheddgv.ClientID %>");
             for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                 GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
             }
         }
   </script>--%>


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
    <div class="tabs_container" align="Center">Vehicle and Materials IN Out Report</div>
         <br />
         <br />
         <table>
            </table>
         <table>
             <tr>
                 
                     <td style="text-align:right;"><asp:Label ID="Lblunit" runat="server" CssClass="lbl" Text="JobStation:"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DdlUnit" CssClass="dropdownList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" > 
                    </asp:DropDownList> 
                       
                   <td style="text-align:right;"><asp:Label ID="Label26" runat="server" CssClass="lbl" Text="Category :"></asp:Label></td>
                    <td style="text-align:left;" ><asp:DropDownList ID="DropDownList1" CssClass="dropdownList" Font-Bold="False" runat="server" Height="25px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" > 
                    <asp:ListItem>PO</asp:ListItem>
                        <asp:ListItem>Getpass Out</asp:ListItem>
                        <asp:ListItem>Getpass In</asp:ListItem>
                        <asp:ListItem>Finished Product Out</asp:ListItem>
                          <asp:ListItem>Local Challan</asp:ListItem>
                        <asp:ListItem>Vehicle</asp:ListItem>
                    </asp:DropDownList> 

             </tr>
            
        
        
             <tr>
                  <td style="text-align:right;"><asp:Label ID="LbldteFrom"  runat="server" CssClass="lbl" Text="From Date:"></asp:Label></td>
                <td><asp:TextBox ID="TxtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDte" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteFrom"></cc1:CalendarExtender> </td>

               <td style="text-align:right;"><asp:Label ID="LblDteTo" runat="server" CssClass="lbl" Text="To Date:"></asp:Label></td>
               <td><asp:TextBox ID="TxtDteTo" runat="server" CssClass="txtBox"></asp:TextBox>
               <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteTo"></cc1:CalendarExtender> </td>
              <td><asp:Button ID="BtnReport" runat="server" Text="Report" OnClick="BtnReport_Click" /></td>
               </tr>
             
         
       
     <tr>
                 
                     <td style="text-align:right;" ><asp:Label ID="Label12" runat="server" CssClass="lbl" Text="  Search:"></asp:Label>
                
                 
                     <td><asp:TextBox ID="Txtnumber" runat="server" CssClass="txtBox"></asp:TextBox>
<%--                          
                    <td><asp:RadioButton ID="RadioButton1" runat="server" Text=" PO Number:" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
                 
                
                      <td><asp:RadioButton ID="RadioButton2" runat="server" Text=" Getpass Number:" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged"/>
                  
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="Local Challan:" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged"/>
                                 --%>
             </tr>
         </table>
             <table>
             <tr>
                
              <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#009933" HeaderStyle-BackColor="#009933">
                  <Columns>
                      <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="intRTGetInPO" HeaderText="PO Number" SortExpression="intRTGetInPO" />
                      <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                      <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                      <asp:BoundField DataField="DteInTime" HeaderText="In Time" SortExpression="DteInTime" />
                      <asp:BoundField DataField="monNetWeight" HeaderText="Net Weight" SortExpression="monNetWeight" />
                      <asp:BoundField DataField="strChallanNo" HeaderText="Local Challan" SortExpression="strChallanNo" />
                      <asp:BoundField DataField="strMaterials" HeaderText="Materials" SortExpression="strMaterials" />
                      <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                  </Columns>
                  </asp:GridView></td>

                 
             </tr>

                 <tr>
                     <td>
                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
                             <Columns>
                                 <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                                 <asp:BoundField DataField="strCode" HeaderText="Getpass No" SortExpression="strCode" />
                                 <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                                 <asp:BoundField DataField="DteOutTime" HeaderText="Out Time" SortExpression="DteOutTime" />
                                 <asp:BoundField DataField="strFAddress" HeaderText="From Address" SortExpression="strFAddress" />
                                 <asp:BoundField DataField="strTAddress" HeaderText="To Address" SortExpression="strTAddress" />
                                 <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                                 <asp:BoundField DataField="intQuantity" HeaderText="Qty" SortExpression="intQuantity" />
                                 <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                             </Columns>
                         </asp:GridView>
                     </td>
                 </tr>

                 <tr>
                     <td><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                             <asp:BoundField DataField="intRTGetInGetPass" HeaderText="Getpass No" SortExpression="intRTGetInGetPass" />
                             <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                             <asp:BoundField DataField="DteInTime" HeaderText="In Time" SortExpression="DteInTime" />
                             <asp:BoundField DataField="strFAddress" HeaderText="From Address" SortExpression="strFAddress" />
                             <asp:BoundField DataField="strTAddress" HeaderText="To Address" SortExpression="strTAddress" />
                             <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                             <asp:BoundField DataField="intQuantity" HeaderText="Qty" SortExpression="intQuantity" />
                             <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                         </Columns>
                         </asp:GridView></td>
                 </tr>
                 <tr>
                     <td> <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False">
                          <Columns>
                              <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                              <asp:BoundField DataField="strCode" HeaderText="Challan No" SortExpression="strCode" />
                              <asp:BoundField DataField="dteDate" HeaderText="Date" SortExpression="dteDate" />
                              <asp:BoundField DataField="strVehicleRegNo" HeaderText="Vehicle No" SortExpression="strVehicleRegNo" />
                              <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                          </Columns>
                         </asp:GridView> </td>
                 </tr>
         </table>
         <table>
             <tr>
             <td><asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                     <asp:BoundField DataField="strChallanNo" HeaderText="Local Chalaln" SortExpression="strChallanNo" />
                     <asp:BoundField DataField="intRTGetInPO" HeaderText="Po Number" SortExpression="intRTGetInPO" />
                     <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                     <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                     <asp:BoundField DataField="DteInTime" HeaderText="In Time" SortExpression="DteInTime" />
                     <asp:BoundField DataField="strScaleId" HeaderText="Scale ID" SortExpression="strScaleId" />
                     <asp:BoundField DataField="strMaterials" HeaderText="Materials" SortExpression="strMaterials" />
                     <asp:BoundField DataField="intQty" HeaderText="Qty" SortExpression="intQty" />
                     <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                 </Columns>
                 </asp:GridView></td>
                 </tr>
         </table>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvVehicle" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                             <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                             <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                             <asp:BoundField DataField="strContactNo" HeaderText="ContactNo" SortExpression="strContactNo" />
                             <asp:BoundField DataField="DteInTime" HeaderText="In Time" SortExpression="DteInTime" />
                             <asp:BoundField DataField="DteOutTime" HeaderText="Out Time" SortExpression="DteOutTime" />
                             <asp:BoundField DataField="intRTGetInGetPass" HeaderText="Getpass In" SortExpression="intRTGetInGetPass" />
                             <asp:BoundField DataField="intRTGetOutGetPass" HeaderText="Getpass Out" SortExpression="intRTGetOutGetPass" />
                             <asp:BoundField DataField="intRTGetInPO" HeaderText="PO In" SortExpression="intRTGetInPO" />
                             <asp:BoundField DataField="strChallanNo" HeaderText="Challan No" SortExpression="strChallanNo" />
                             <asp:BoundField DataField="strMaterials" HeaderText="Materials" SortExpression="strMaterials" />
                             <asp:BoundField DataField="monNetWeight" HeaderText="NetWeight" SortExpression="monNetWeight" />
                             <asp:BoundField DataField="intQty" HeaderText="Qty" SortExpression="intQty" />
                             <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvVehicle2" runat="server" AutoGenerateColumns="False">
                          <Columns>
                               <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                             <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
                             <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                             <asp:BoundField DataField="strContactNo" HeaderText="ContactNo" SortExpression="strContactNo" />
                             <asp:BoundField DataField="DteInTime" HeaderText="In Time" SortExpression="DteInTime" />
                             <asp:BoundField DataField="DteOutTime" HeaderText="Out Time" SortExpression="DteOutTime" />
                             <asp:BoundField DataField="intRTGetInGetPass" HeaderText="Getpass In" SortExpression="intRTGetInGetPass" />
                             <asp:BoundField DataField="intRTGetOutGetPass" HeaderText="Getpass Out" SortExpression="intRTGetOutGetPass" />
                             <asp:BoundField DataField="intRTGetInPO" HeaderText="PO In" SortExpression="intRTGetInPO" />
                             <asp:BoundField DataField="strChallanNo" HeaderText="Challan No" SortExpression="strChallanNo" />
                             <asp:BoundField DataField="strMaterials" HeaderText="Materials" SortExpression="strMaterials" />
                             <asp:BoundField DataField="monNetWeight" HeaderText="NetWeight" SortExpression="monNetWeight" />
                             <asp:BoundField DataField="intQty" HeaderText="Qty" SortExpression="intQty" />
                             <asp:BoundField DataField="strUom" HeaderText="Uom" SortExpression="strUom" />
                         </Columns>

                     </asp:GridView>
                 </td>
             </tr>
         </table>
         <table>
         </table>

         <%--=========================================End My Code From Here=================================================--%>
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


