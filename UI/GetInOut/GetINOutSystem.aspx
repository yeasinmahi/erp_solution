<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetINOutSystem.aspx.cs" Inherits="UI.GetInOut.GetINOutSystem" %>


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
   
     <script type="text/javascript">
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
   </script> 
    <%-- <script type="text/javascript">
         // for check all checkbox   
         function CheckAll(Checkbox) {
             var GridVwHeaderCheckbox = document.getElementById("<%=Finisheddgv.ClientID %>");
             for (i = 1; i < GridVwHeaderCheckbox.rows.length; i++) {
                 GridVwHeaderCheckbox.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
             }
         }
   </script>--%>
       <script>
           $(document).ready(function () {
               SearchTextemp();
           });
           function Changeds() {
               document.getElementById('HdfTechnicinSearchbox').value = 'true';
           }
           function SearchTextemp() {
               $("#TxtTechnichinSearch").autocomplete({
                   source: function (request, response) {
                       $.ajax({
                           type: "POST",
                           contentType: "application/json;",
                           url: "GetINOutSystem.aspx/GetAutoCompleteDataemp",
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
   <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" /></td>
       <asp:HiddenField ID="HiddenField1" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" /> 
          <div class="tabs_container" align="Center">Materials Getpass In Out</div>
         <br />
         <br />
         <table>
             
                     
             <tr>
               <%--  <td style="text-align:right;"><asp:Label ID="LblJobstation" runat="server" CssClass="lbl" Text="Job Station :"></asp:Label></td>
                 <td style="text-align:right;"><asp:DropDownList ID="DdlJobstation" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlJobstation_SelectedIndexChanged" ></asp:DropDownList> </td>--%>

                 <td style="text-align:right;"><asp:Label ID="Lblscaleid" runat="server" CssClass="lbl" ForeColor="Blue" Text="Vehicle List :"></asp:Label></td>
                 <td style="text-align:right;"><asp:DropDownList ID="DdlVehicle" BorderColor="#008000" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" ></asp:DropDownList> </td>
                   
    
                 </tr>
             </table>
         <td><asp:Label ID="Label1" runat="server" Text="Material Getpass Out"></asp:Label><td>
                   <table>
                       <tr>
                           <td>
                     <asp:GridView ID="dgvGetpassOut" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvGetpassOut_RowDeleting" OnRowDataBound="dgvGetpassOut_RowDataBound">
                         <Columns>
                             <asp:TemplateField HeaderText="SL.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="IntId">
                                 <ItemTemplate>
                                     <asp:Label ID="intID" runat="server" Text='<%# Eval("intRID") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Code">
                                 <ItemTemplate>
                                     <asp:Label ID="strcode" runat="server" Text='<%# Eval("strCode") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Date">
                                 <ItemTemplate>
                                     <asp:Label ID="strChallan" runat="server" Text='<%# Eval("dteChallan") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Description">
                                 <ItemTemplate>
                                     <asp:Label ID="strDescription" runat="server" Text='<%# Eval("strDescription") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Qty">
                                 <ItemTemplate>
                                     <asp:Label ID="intQuantity" runat="server" Text='<%# Eval("intQuantity") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="info" HeaderText="Issue By" SortExpression="info" />
                             <asp:TemplateField HeaderText="To Address">
                                 <ItemTemplate>
                                     <asp:Label ID="strTAddress" runat="server" Text='<%# Eval("strTAddress") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField HeaderText="ToID">
                                 <ItemTemplate>
                                     <asp:Label ID="intToID" runat="server" Text='<%# Eval("intToID") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:TemplateField>
                                        

                                 <HeaderTemplate>
                                     <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="OUT" />
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:CheckBox ID="chkSelect"  BorderColor="#008000" runat="server" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
             </table>
         <td>
                     <asp:Label ID="Label5" runat="server" Text="Material Getpass In and   "></asp:Label><td>
        <td  style="text-align:right;"><asp:Label ID="LblTechnichin" runat="server" CssClass="lbl"  ForeColor="Blue" Text="  Foward To:"></asp:Label> </td>
          <td  style="text-align:left;"> <asp:TextBox ID="TxtTechnichinSearch" runat="server" BorderColor="#008000" CssClass="txtBox" AutoPostBack="false" onchange="javascript: Changeds();" Font-Bold="False"></asp:TextBox>  
           </td>
         <table>
             <tr>
                 
                     
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  autopostback="true" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                         <Columns>
                             <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="IntId">
                                 <ItemTemplate>
                                     <asp:Label ID="IntRID" runat="server" Text='<%# Eval("intRID") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Challan">
                                 <ItemTemplate>
                                     <asp:Label ID="strCode" runat="server" Text='<%# Eval("strCode") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Date">
                                 <ItemTemplate>
                                     <asp:Label ID="dteChallan" runat="server" Text='<%# Eval("dteChallan") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Description">
                                 <ItemTemplate>
                                     <asp:Label ID="strDescription" runat="server" Text='<%# Eval("strDescription") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Address">
                                 <ItemTemplate>
                                     <asp:Label ID="strFAddress" runat="server" Text='<%# Eval("strFAddress") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Qty">
                                 <ItemTemplate>
                                     <asp:Label ID="monQty" runat="server" Text='<%# Eval("intQuantity") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vehicle No">
                                 <ItemTemplate>
                                     <asp:Label ID="strVechileNo" runat="server" Text='<%# Eval("strVechileNo") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Driver Name">
                                 <ItemTemplate>
                                     <asp:Label ID="strDrivername" runat="server" Text='<%# Eval("strDrivername") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField>
                                 <HeaderTemplate>
                                     <asp:Button ID="Button1" runat="server" Text="IN" OnClick="Button1_Click" />
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:CheckBox ID="chkSelect2" runat="server" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
      
         </table>
        
        
         <table>
             <tr>
                 <td  colspan="5">
                     <asp:GridView ID="dgvGetpassRecieve" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="intRTGetInGetPass" HeaderText="GetPass No" SortExpression="intRTGetInGetPass" />
                             <asp:BoundField DataField="strFAddress" HeaderText="From Address" SortExpression="strFAddress" />
                             <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                             <asp:BoundField DataField="intQuantity" HeaderText="Qty" SortExpression="intQuantity" />
                             <asp:BoundField DataField="strDrivername" HeaderText="Driver Name" SortExpression="strDrivername" />
                             <asp:BoundField DataField="strVechileNo" HeaderText="Vehicle No" SortExpression="strVechileNo" />
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

