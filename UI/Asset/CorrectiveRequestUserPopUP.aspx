<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CorrectiveRequestUserPopUP.aspx.cs" Inherits="UI.Asset.CorrectiveRequestUserPopUP" %>

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
            $("#txtPartsSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "IssueAssetMaintenance.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtPartsSearch').value + "'}",
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
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }

         function Registrationparts(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         function RegistrationSchedule(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         </script> 
   
   

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
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
    <div class="tabs_container" align="Center" >Maintenance Service Request Detalis</div>
   
      <%-- <asp:GridView ID="dgvView" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                             <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" Visible="False" />
                             <asp:BoundField DataField="strAssetNumber" HeaderText="Asset Code" SortExpression="strAssetNumber" />
                             <asp:BoundField DataField="strNameOfAsset" HeaderText="Name of Asset" SortExpression="strNameOfAsset" />
                              <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                             <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
                             <asp:BoundField DataField="dteFixed/Repair" HeaderText="Req Date" SortExpression="dteFixed/Repair" />
                             <asp:BoundField DataField="dteServiceEndDate" HeaderText="End Date" SortExpression="dteServiceEndDate" />
                             <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                             <asp:BoundField DataField="strLocation" HeaderText="Location" SortExpression="strLocation" />
                             <asp:BoundField DataField="strDepatrment" HeaderText="Request to Dept" SortExpression="strDepatrment" />
                             <asp:BoundField DataField="strItemName" HeaderText="Parts" SortExpression="strItemName" />
                             <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                         </Columns>
                     </asp:GridView>--%>
          <asp:GridView ID="dgvView" runat="server" AutoGenerateColumns="False">
              <Columns>
                  <asp:TemplateField HeaderText="SL">
                      <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" Visible="False" />
                  <asp:BoundField DataField="strNameOfAsset" HeaderText="Name of Asset" SortExpression="strNameOfAsset" />

                  <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                  <asp:BoundField DataField="strJobStationName" HeaderText="Job Station" SortExpression="strJobStationName" />
                  <asp:BoundField DataField="strAssetNumber" HeaderText="Asset Code" SortExpression="strAssetNumber" />
                  <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                  <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
                  <asp:BoundField DataField="ReqDate" HeaderText="Req Date" SortExpression="ReqDate" />
                  <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                  <asp:BoundField DataField="strLocation" HeaderText="Location" SortExpression="strLocation" />

                  <asp:BoundField DataField="SPartsName" HeaderText="Require S.Parts Name" SortExpression="SPartsName" />
                  <asp:BoundField DataField="SPartsStatus" HeaderText="S.Parts Status" SortExpression="SPartsStatus" />
                  <asp:BoundField DataField="JobStatus" HeaderText="Job Status" SortExpression="JobStatus" />
                  <asp:BoundField DataField="dteServiceEndDate" HeaderText="End Date" SortExpression="dteServiceEndDate" />
                  <asp:BoundField DataField="VehicleCondition" ItemStyle-HorizontalAlign="Center" HeaderText="Vehicle Condition" SortExpression="VehicleCondition" />

              </Columns>
          </asp:GridView>
             
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

