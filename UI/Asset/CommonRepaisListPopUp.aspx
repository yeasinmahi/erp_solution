<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommonRepaisListPopUp.aspx.cs" Inherits="UI.Asset.CommonRepaisListPopUp" %>

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
   <script type="text/javascript">
       function RefreshParent() {
           if (window.opener != null && !window.opener.closed) {
               window.opener.location.reload();
           }
       }
       window.onbeforeunload = RefreshParent;
</script> 
    

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 268435488px;
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
    <div class="tabs_container" align="Center" >Common Repairs List</div>
   
         
                <td>
                <asp:Button Text="New Service" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
                OnClick="Tab1_Click" BackColor="#FFCC99" />
                <asp:Button Text="Update Service" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                BackColor="#FFCC99" OnClick="Tab2_Click"/>
         
                <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="View1" runat="server">
                <table style="width:85%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                <td>
                <h3>
                <span>

     
              <tr class="tblrowodd">
                  
       <td style="text-align:right;"> <asp:Label ID="LblRepairs" runat="server" CssClass="lbl" font-size="small" Text="Common Repairs Item:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtRepairs" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"  ></asp:TextBox></td>
       <td style="text-align:right;"> <asp:Label ID="Label4" runat="server" CssClass="lbl" font-size="small" Text="Service Charge:"></asp:Label></td>

        <td><asp:TextBox ID="TxtCommonRepSCost" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"   ></asp:TextBox></td>
           
              
                <td><asp:Button ID="BtnIssue" runat="server" Text="Add" Height="20px" Width="52px" OnClick="BtnIssue_Click" /></td>            
                  </tr>
               
                   
           
             </table>
         <table width="700" class="tblroweven">
            
           </table> 
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvcommonrepairs" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                             <asp:BoundField DataField="strRepairs" HeaderText="Common Repairs Name" SortExpression="strRepairs" />
                              <asp:BoundField DataField="monServiceCharge" HeaderText="ServiceCharge" SortExpression="monServiceCharge" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
     

                </span>
                </h3>
                </td>
                </tr>
            
                </span></h3>
                
                </asp:View>


         <asp:View ID="View2" runat="server">
                <table style="width:85%; border-width: 1px; border-color: #666; border-style: solid">
                <tr>
                <td>
                <h3>
                <span>

     
              <tr class="tblrowodd">
                   <td style="text-align:right;"> <asp:Label ID="Label3" runat="server" CssClass="lbl" font-size="small" Text="Common Service Item:"></asp:Label></td>
              <td><asp:DropDownList ID="DdlServiceName" runat="server"  CssClass="dropdownList"  AutoPostBack="True" OnSelectedIndexChanged="DdlServiceName_SelectedIndexChanged" ></asp:DropDownList>
           
       <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" CssClass="lbl" font-size="small" Text="Common Repairs Name:"></asp:Label></td>
          <td><asp:TextBox ID="TxtCommonRepname" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"   ></asp:TextBox>
           <td style="text-align:right;"> <asp:Label ID="Label2" runat="server" CssClass="lbl" font-size="small" Text="Service Charge:"></asp:Label></td>
        
                <td><asp:TextBox ID="TxtCommonReCharge" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true"   ></asp:TextBox></td>
  
              
              <td><asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click"   /></td>            
                  </tr>
               
                   
           
             </table>
         <table width="700" class="tblroweven">
            
           </table> 
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                             <asp:BoundField DataField="strRepairs" HeaderText="Common Repairs Name" SortExpression="strRepairs" />
                         </Columns>
                     </asp:GridView>
                 </td>
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

