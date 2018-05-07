<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Bill_Detalis_PopUp.aspx.cs" Inherits="UI.Asset.Vehicle_Bill_Detalis_PopUp" %>

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
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
   
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
             if (window.focus) { newwindow.focus() }
         }

         function Registrationparts(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
             if (window.focus) { newwindow.focus() }
         }
         function RegistrationSchedule(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=900,top=50,left=230, close=no');
             if (window.focus) { newwindow.focus() }
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
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            
    <div class="tabs_container" align="Center" >Maintenance Service Bill</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; "class="tblrowodd" >
              <tr  class="tblrowodd">
                 
                  <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text="Vehicle Number:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtVehicleNo" runat="server" CssClass="txtBox" ReadOnly="true" Font-Bold="False"></asp:TextBox>
      <td style="text-align:right;"> <asp:Label ID="Label2" font-size="small" runat="server" CssClass="lbl" Text="Job Card No.    :"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtJobNo" runat="server" CssClass="txtBox" ReadOnly="true" Font-Bold="False"></asp:TextBox>
       </tr>
           <tr>
  <td style="text-align:right;"> <asp:Label ID="Label3" font-size="small" runat="server" CssClass="lbl" Text="Nature of Vehicle:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="txtNature" runat="server" CssClass="txtBox" ReadOnly="true" Font-Bold="False"></asp:TextBox>
       <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small"  CssClass="lbl" Text="Job Entrance Date:"></asp:Label></td>
       <td><asp:TextBox ID="TxtEntanceDate" runat="server" CssClass="txtBox" ReadOnly="true" Font-Bold="False"></asp:TextBox>
              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtEntanceDate"></cc1:CalendarExtender> 
       
           </tr>
          <tr>
                     <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Model & CC :"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtModel" runat="server" ReadOnly="true" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
            </td>
       <td style="text-align:right;"> <asp:Label ID="Label6" runat="server" font-size="small" CssClass="lbl" Text="Delivery Date:"></asp:Label></td>
         <td><asp:TextBox ID="TxtDeliveyDate" runat="server" CssClass="txtBox" ReadOnly="true"  Font-Bold="False"></asp:TextBox>
              <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDeliveyDate"></cc1:CalendarExtender> 

           </tr>
           <tr>
                    
               <td style="text-align:right;"> <asp:Label ID="Label8" runat="server" font-size="small" CssClass="lbl" Text="Present Mileage:"></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="TxtPresentMilege" ReadOnly="true" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
        <td style="text-align:right;"> <asp:Label ID="Label10" runat="server" font-size="small" CssClass="lbl" Text="Next Mileage  :"></asp:Label></td>
         <td style="text-align:left;"><asp:TextBox ID="TxtNextMilege" ReadOnly="true" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
       
           </tr>
           <tr>
                     <td style="text-align:right;"> <asp:Label ID="Label7" font-size="small" runat="server" CssClass="lbl" Text="Own ACW Billing Unit:"></asp:Label></td>
               <td style="text-align:left;"><asp:DropDownList ID="DdlAcwOwn" BorderColor="Green"  runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="true">
           </asp:DropDownList></td>
              
         <td style="text-align:right;"> <asp:Label ID="Label4" font-size="small" runat="server" CssClass="lbl" Text="Int.Co.Others Billing Unit:"></asp:Label></td>
               <td style="text-align:left;"><asp:DropDownList ID="DdlInterCompany" BorderColor="Green"  runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="true">
           </asp:DropDownList></td>
       
           </tr>
           <tr>
                     <td style="text-align:right;"> <asp:Label ID="Label9" font-size="small" runat="server" CssClass="lbl" Text="Present Problem of"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtProblem" runat="server" ReadOnly="true" CssClass="txtBox"  TextMode="MultiLine" Font-Bold="False"></asp:TextBox>
            <td style="text-align:right;"> <asp:Label ID="Label5" font-size="small" runat="server" CssClass="lbl" Text="Company Name  :"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtCompany" runat="server" ReadOnly="true" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                    </td>
       
           </tr>
           <tr>
               <td></td><td></td><td></td><td> <asp:Button ID="Btn" runat="server" BorderColor="Green" Text="Submit" OnClick="Btn_Click" /> </td>
           </tr>
            </table>
          <table>
              
                  <tr> <td></td> </tr> <tr> <td></td> </tr> 
                     
                 
              <tr>
                  <td>
                      <asp:GridView ID="dgvPartsView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                          <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                      <%# Container.DataItemIndex + 1 %>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="strItemName" HeaderText="Spare_Parts_Name" SortExpression="strItemName" />
                              <asp:BoundField DataField="intqty" HeaderText="Qty" SortExpression="intqty" />
                             
                              <asp:BoundField DataField="intReqID" HeaderText="ReqID" SortExpression="intReqID" />
                               <asp:BoundField DataField="monValue" HeaderText="Value" SortExpression="monValue" />
                          </Columns>
                      </asp:GridView>
                  </td>
                  <td>
                      <asp:GridView ID="dgvServiceCharge" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                          <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                      <%# Container.DataItemIndex + 1 %>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                              <asp:BoundField DataField="Typess" HeaderText="Maintenance Type" SortExpression="Typess" />
                              <asp:BoundField DataField="monServiceCost" HeaderText="Charge" SortExpression="monServiceCost" />
                          </Columns>
                      </asp:GridView>
                  </td>
              </tr>
          
        </Table>
         
             <table>
                  <asp:GridView ID="DgvPerformer" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                      <Columns>
                        <asp:TemplateField HeaderText="Sl.N"> <ItemTemplate>   <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                 
                          <asp:BoundField DataField="Name" HeaderText="EmpName" SortExpression="Name" />
                          <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
                      </Columns>
                      </asp:GridView>
                  
      
          </table>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
