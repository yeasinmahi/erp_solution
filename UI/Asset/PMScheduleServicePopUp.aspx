<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PMScheduleServicePopUp.aspx.cs" Inherits="UI.Asset.PMScheduleServicePopUp" %>

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
  

   
    
<script> function CloseWindow() {
     window.close();
 } </script> 

    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }
        window.onbeforeunload = RefreshParent;
</script> 
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "VehicleMaintenanceBill.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
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
     <script>
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=10,left=10, close=no');
             if (window.focus) { newwindow.focus() }
         }
         </script> 
   
    

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {
            margin-left: 0px;
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
    <div class="tabs_container" align="Center" >Preventive Maintenance Service </div>
   
                <td>
                <asp:Button Text="New Service" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
                OnClick="Tab1_Click" BackColor="#FFCC99" />
                <asp:Button Text="Update Service" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                BackColor="#FFCC99" OnClick="Tab2_Click"/>
         
                <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="View1" runat="server">
                <table style="width:75%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                <td>
                <h3>
                <span>

                        
                    
           
                <tr class="tblrowodd">
                  
                <td style="text-align:right;"> <asp:Label ID="LblService" runat="server" CssClass="lbl" font-size="small" Text="Service Name:"></asp:Label></td>
                <td style="text-align:left;"> <asp:TextBox ID="TxtService" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" ></asp:TextBox></td>
                <td style="text-align:right;"> <asp:Label ID="Label4" runat="server" CssClass="lbl" font-size="small" Text="Service Charge:"></asp:Label></td>
              <td style="text-align:left;"> <asp:TextBox ID="TxtSeviceCost" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" ></asp:TextBox>
                  </td>
                    
             <td> <asp:Button ID="BtnIssue" runat="server" Text="Add" Height="22px" Width="52px" OnClick="BtnIssue_Click"  /></td>
                </tr>
                </table>
                <table>
                <tr>
                <td>
                <asp:GridView ID="dgvServiceName" runat="server" AutoGenerateColumns="False">
                <Columns>
                <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                    
                      <asp:BoundField DataField="monServiceCharge" HeaderText="Service Charge" SortExpression="monServiceCharge" />     
                </Columns>
                </asp:GridView>
             
                </tr>
                </table>

                </span>
                </h3>
                </td>
                </tr>
            
                </span></h3>
                
                </asp:View>



         <asp:View ID="View2" runat="server">
                <table style="width:80%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                <td>
                <h3>
                <span>

                        
                    
           
                <tr class="tblrowodd">
                  
                <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" CssClass="lbl" font-size="small" Text="Service Item:"></asp:Label></td>
              <td><asp:DropDownList ID="DdlServiceName" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="DdlServiceName_SelectedIndexChanged"></asp:DropDownList>
              <td style="text-align:right;"> <asp:Label ID="Label2" runat="server" CssClass="lbl" font-size="small" Text="Service Name:"></asp:Label></td>
              <td style="text-align:left;"> <asp:TextBox ID="TxtServiceU" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" ></asp:TextBox></td>

          <td style="text-align:right;"> <asp:Label ID="Label3" runat="server" CssClass="lbl" font-size="small" Text="Service Charge:"></asp:Label></td>
              <td style="text-align:left;"> <asp:TextBox ID="TxtServiceCharge" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" ></asp:TextBox>
             </td>
                  <td><asp:Button ID="BtnUpdateService" runat="server" Text="Update" Height="22px" Width="52px" OnClick="BtnUpdateService_Click"   /></td>
                
                </tr>
                </table>
               

                </span>
                </h3>
                </td>
                </tr>
            
                </span></h3>
                
                </asp:View>
                </asp:MultiView>
     
                </formview>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
