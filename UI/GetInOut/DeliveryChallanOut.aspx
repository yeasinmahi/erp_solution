<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryChallanOut.aspx.cs" Inherits="UI.GetInOut.DeliveryChallanOut" %>
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
    <div class="tabs_container" align="Center">Delivery Challan  Out</div>
         <br />
         <br />
         <table>
             <tr>
                 <td><asp:GridView ID="Finisheddgv" runat="server" AutoGenerateColumns="False">
                     <Columns>
                         <asp:TemplateField HeaderText="Challan">
                             <ItemTemplate>
                                 <asp:Label ID="strCode" runat="server" Text='<%# Eval("strCode") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Vehicle No">
                             <ItemTemplate>
                                 <asp:Label ID="strVehicleRegNo" runat="server" Text='<%# Eval("strVehicleRegNo") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="VatChallanNo">
                             <ItemTemplate>
                                 <asp:Label ID="intVatChallanNo" runat="server" Text='<%# Bind("intVatChallanNo") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField>
                             <HeaderTemplate>
                                 <asp:Button ID="Button3" runat="server" Text="OUT" OnClick="Button3_Click" />
                             </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox ID="chkSelect3" runat="server" />
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

