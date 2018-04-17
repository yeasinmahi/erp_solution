<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetpassRecieveDetalis.aspx.cs" Inherits="UI.GetInOut.GetpassRecieveDetalis" %>

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
   
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
   <asp:HiddenField ID="HdfTechnicinCode" runat="server" /><asp:HiddenField ID="HdfTechnicinSearchbox" runat="server" /></td>
        <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
    <tr><td colspan="3" class="tblheader">Materials and Document Getpass Receive :<asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" /></td></tr>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="dgvGetpassDetalis" runat="server" AutoGenerateColumns="False">
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