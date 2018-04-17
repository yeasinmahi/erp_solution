<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="UI.Asset.Maintenance" %>

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
  
    
    
    

   <script type="text/javascript">
       function Search_GridView1(strKey, strGV) {

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
       

       function Search_dgvPM(strKey, strGV) {

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


       function Search_dgvRepair(strKey, strGV) {

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
      <script>  function ConfirmAll() {
      document.getElementById("hdnconfirm").value = "0";
      var confirm_value = document.createElement("INPUT");
      confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
      if (confirm("Do you want to Submit Store Requisition?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
      else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
  }
      function ConfirmWorkorder() {
          document.getElementById("hdnconfirm").value = "0";
          var confirm_value = document.createElement("INPUT");
          confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
          if (confirm("Do you want to Work Order?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
          else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
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
             window.location.href("MaintenanceWorkOrderPopUp.aspx")
             //newwindow = window.open(url,'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=170, close=yes');
             //if (window.focus) { newwindow.focus() }
         }
         </script> 

 


  <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] td").hover(function ()
            
            {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });

        $(function () {
            $("[id*=DgvPoWorkorders] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });

        $(function () {
            $("[id*=dgvRepair] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });

        $(function () {
            $("[id*=dgvPM] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
        
        
</script>

    <style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    td
    {
        cursor: pointer;
    }
    .hover_row
    {
        background-color: #A1DCF2;
    }
</style>
    

 <style type="text/css">
	
     .tooltip {
    position: absolute;
        
       margin-left: -150px;
       margin-top: -10px;
       z-index: 3;
        display: none;
        background-color:blue;
        color: White;
        padding:5px;
        font-size:8pt;
        font-family: Arial;
        
     
        
        
}

    td
    {
        cursor:pointer;
        
    }
</style>

    

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
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" style="text-align:center" >Maintenance </div>
   
 
         <div class="tabs_container" style="background-color:AppWorkspace "><b>Internal Work Order</b></div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridView1"    runat="server" OnRowDataBound="OnRowDataBound" AutoGenerateColumns="False">
                   
                         
                             <Columns>
                               
                             <asp:BoundField DataField="intMaintenanceNo" HeaderText="WO ID" SortExpression="intMaintenanceNo" />
                             <asp:TemplateField HeaderText="Asset Number">
                                 <HeaderTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="75"  placeholder="AssetNumber&Search" onkeyup="Search_GridView1(this, 'GridView1')"></asp:TextBox>
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("strAssetCode") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="AssetName" SortExpression="strNameOfAsset" />
                             <asp:TemplateField HeaderText="Status">
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("strStatus") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Repair Type">
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("strRepairType") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Priority">
                                 <ItemTemplate>
                                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("strPriority") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Start Date">
                                 <ItemTemplate>
                                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("dteStartDate") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField> 
                             <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                             <asp:TemplateField HeaderText="Detalis">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnDetalis" runat="server" Text="Detalis"  CommandName="Detalis"  CommandArgument='<%# Eval("intMaintenanceNo")%>' OnClick="BtnDetalis_Click" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Requesition">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnRequesition" runat="server" Text="Requesition" CommandName="Detalis"  CommandArgument='<%# Eval("intMaintenanceNo")%>' OnClick="BtnRequesition_Click" OnClientClick="ConfirmAll()"/>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="StatusView" HeaderText="StatusView" SortExpression="StatusView" Visible="False" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
         <div class="tabs_container" style="background-color:AppWorkspace " ><b>PO Work Order</b></div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="DgvPoWorkorders" OnRowDataBound="OnDataDgvPoWorkorders" runat="server" AutoGenerateColumns="False">
                    <Columns>
                             <asp:BoundField DataField="intMaintenanceNo" HeaderText="WO ID" SortExpression="intMaintenanceNo" />
                             <asp:TemplateField HeaderText="Asset Number">
                                 <ItemTemplate>
                                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("strAssetCode") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="AssetName" SortExpression="strNameOfAsset" />
                             <asp:TemplateField HeaderText="Status">
                                 <ItemTemplate>
                                     <asp:Label ID="Label4" runat="server" Text='<%# Bind("strStatus") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Repair Type">
                                 <ItemTemplate>
                                     <asp:Label ID="Label5" runat="server" Text='<%# Bind("strRepairType") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Priority">
                                 <ItemTemplate>
                                     <asp:Label ID="Label6" runat="server" Text='<%# Bind("strPriority") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Start Date">
                                 <ItemTemplate>
                                     <asp:Label ID="Label7" runat="server" Text='<%# Bind("dteStartDate") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField> 
                             <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                             <asp:TemplateField HeaderText="PODetalis">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnPODetalis" runat="server" Text="Detalis"  CommandName="Detalis"  CommandArgument='<%# Eval("intMaintenanceNo")%>' OnClick="BtnPODetalis_Click"  />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="StatusView" HeaderText="StatusView" SortExpression="StatusView" Visible="False" />
                         </Columns>
                     </asp:GridView>            
                     
                 </td>
                 
             </tr>
         </table>
         <div class="tabs_container" align="Center" style="background-color: #669999" ><b>User Corrective Maintenance Request </b></div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvuserRequest"  OnRowDataBound="ondatadgvUserrequest" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField />
                             <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" />
                             <asp:BoundField DataField="strAssetNumber" HeaderText="Asset Number" SortExpression="strAssetNumber" />
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
                             <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                             <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
                             <asp:BoundField DataField="dteFixed/Repair" HeaderText="Request Date" DataFormatString="{0:d}" SortExpression="dteFixed/Repair" />
                             <asp:BoundField DataField="strLocation" HeaderText="Location" SortExpression="strLocation" />
                             <asp:BoundField DataField="Name" HeaderText="Request By" SortExpression="Name" />
                             <asp:TemplateField HeaderText="WorkOrder">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnUserRequestWO" runat="server"  CommandName="WorkOrder"  CommandArgument='<%# Eval("intID")%>' Text="WorkOrder" OnClick="BtnUserRequestWO_Click" OnClientClick="ConfirmWorkorder()" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="StatusView" HeaderText="StatusView" SortExpression="StatusView" Visible="False" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
           <div class="tabs_container" align="Center" style="background-color: #009933" >Corrective Repairs Request </div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvRepair" runat="server" OnRowDataBound="ondatadgvRepair" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="ID">
                                 <HeaderTemplate>
                                     <asp:TextBox ID="TextBox2" Width="75"   onkeyup="Search_dgvRepair(this, 'dgvRepair')" PlaceHolder="Search" runat="server"></asp:TextBox>
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label8" runat="server" Text='<%# Eval("intID") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField HeaderText="ID" DataField="intID" SortExpression="intID" Visible="False" />
                             <asp:BoundField HeaderText="Asset Code" DataField="strAssetNumber" SortExpression="strAssetNumber" />
                             <asp:BoundField HeaderText="Asset Name" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
                             <asp:BoundField HeaderText="ServiceName" DataField="strServiceName" SortExpression="strServiceName" />
                             <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="YesnServiceType" />
                             <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
                             <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" DataFormatString="{0:d}" SortExpression="dteFixed/Repair" />
                             <asp:BoundField DataField="strServiceProvideBy" HeaderText="Provide By" SortExpression="strServiceProvideBy" />
                             <asp:TemplateField HeaderText="Status">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnRepWorkorder" runat="server" Text="WorkOrder" CommandName="WorkOrder"  CommandArgument='<%# Eval("intID")%>' OnClick="BtnRepWorkorder_Click"  OnClientClick="ConfirmWorkorder()" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="StatusView" HeaderText="StatusView" SortExpression="StatusView" Visible="False" />
                         </Columns>
                     </asp:GridView>
                 </td>
             </tr>
         </table>
           <div class="tabs_container" align="Center"  style="background-color: #CC33FF">Preventive Repair Request</div>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="dgvPM" runat="server" OnRowDataBound="OndatadgvPM" AutoGenerateColumns="False">
                         <Columns>
                            <asp:TemplateField HeaderText="ID">
                                 <HeaderTemplate>
                                     <asp:TextBox ID="TextBox3" Width="75" onkeyup="Search_dgvPM(this, 'dgvPM')"  PlaceHolder="Search" runat="server"></asp:TextBox>
                                 </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:Label ID="Label8" runat="server" Text='<%# Eval("intID") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>

                             <asp:BoundField HeaderText="ID" DataField="intID" SortExpression="intID" Visible="false" />
                             <asp:BoundField HeaderText="Asset Code" DataField="strAssetNumber" SortExpression="strAssetNumber" />
                             <asp:BoundField HeaderText="Asset Name" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
                             <asp:BoundField HeaderText="ServiceName" DataField="strServiceName" SortExpression="strServiceName" />
                             <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="YesnServiceType" />
                             <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
                             <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" DataFormatString="{0:d}" SortExpression="dteFixed/Repair" />
                             <asp:BoundField DataField="strServiceProvideBy" HeaderText="Provide By" SortExpression="strServiceProvideBy" />
                             <asp:TemplateField HeaderText="Work Order">
                                 <ItemTemplate>
                                     <asp:Button ID="BtnWorkorder" runat="server" Text="Work Order" CommandName="WorkOrder"  CommandArgument='<%# Eval("intID")%>'  OnClick="BtnWorkorder_Click"  OnClientClick="ConfirmWorkorder()"/>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="StatusView" HeaderText="StatusView" SortExpression="StatusView" Visible="False" />
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
