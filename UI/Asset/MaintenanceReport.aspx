<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenanceReport.aspx.cs" Inherits="UI.Asset.MaintenanceReport" %>

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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
       
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }
    </script>


   <%-- <script>
         $(document).ready(function () {
             $("#<%=txtEmployeeSearchp.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("Service.asmx/GetSpareParts") %>',
                         data: '{"station":"' + $("#hdnstation").val() + '","prefix":"' + request.term + '"}',
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         success: function (data) {
                             response($.map(data.d, function (item) {
                                 return {
                                     label: item.split('^')[0],
                                     val: item.split('^')[1]
                                 }
                             }))
                         },
                         error: function (response) {
                             //alert(response.responseText);
                         },
                         failure: function (response) {
                             //alert(response.responseText);
                         }
                     });
                 },
                 select: function (e, i) {
                     $("#<%=hfEmployeeIdp.ClientID %>").val(i.item.val);
                 },
                 minLength: 3
             });

         });
</script>
   --%>
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 30px;
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
    <div class="tabs_container" align="Center">Maintenance Report</div>
     <br>
         <br />
          <table>

              <tr>
                 
                      <td style="text-align:right;">
                          <asp:Label ID="LblFromDte" runat="server" CssClass="lbl" Text="From Date:"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtDteFrom" runat="server" CssClass="txtBox"></asp:TextBox>
                          <cc1:CalendarExtender ID="txtDteJobEntranc" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
                          </cc1:CalendarExtender>
                      </td>
                      <td style="text-align:right;">
                          <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date:"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="TxtdteTo" runat="server" CssClass="txtBox"></asp:TextBox>
                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteTo">
                          </cc1:CalendarExtender>
                      </td>
                      <td>
                          <asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click" />
                      </td>
                  </td>
              </tr>
              </table>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridView1" runat="server">
                     </asp:GridView>
                 </td>
             </tr>
             </table>
    
  </table> 
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>