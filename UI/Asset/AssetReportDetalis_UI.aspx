<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetReportDetalis_UI.aspx.cs" Inherits="UI.Asset.AssetReportDetalis_UI" %>


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
     
   
     <style type="text/css">
    .Initial
{
  display: block;
  padding: 4px 18px 4px 18px;
  float: left;
  background: url("../Images/InitialImage.png") no-repeat right top;
  color: Black;
  font-weight: bold;
}
     .Initial:hover
     {
  color:blue;
  background:#eeeeee;
   }
     .Clicked
     {
  float: left;
  display: block;
  background:padding-box;
  padding: 4px 18px 4px 18px;
  color: Black;
  font-weight: bold;
  color:Green;
}
</style>

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
    <%--<div class="tabs_container" align="Center" >Maintenance Service Report </div>--%>
         
     <div class="tabs_container">Spare Parts  Summary :</div>  
                      
                  <asp:GridView ID="dgvPartsView" runat="server" AutoGenerateColumns="False" ShowFooter="true">
                      <Columns>
                          <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                      <%# Container.DataItemIndex + 1 %>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          <asp:BoundField DataField="strItemName" HeaderText="SpareParts" SortExpression="strItemName" />
                          <asp:BoundField DataField="intqty" HeaderText="Qty" SortExpression="intqty" />
                          <asp:BoundField DataField="intReqID" HeaderText="ReqesitionID" SortExpression="intReqID"/>
                          <asp:BoundField DataField="monValue" HeaderText="Value" SortExpression="monValue"/> 
                      </Columns>
                      
                      </asp:GridView> 
        <div class="leaveSummary_container"> 
        <div class="tabs_container">Employee Work Summary :<hr /></div> 
              
                  <asp:GridView ID="DgvPerformer" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="Name" HeaderText="EmpName" SortExpression="Name" />
                          <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
                      </Columns>
                      </asp:GridView>
                  
          </div>
          <div class="tabs_container">Service Summary :<hr /></div> 
              
                  <asp:GridView ID="dgvService" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                          <asp:BoundField DataField="monServiceCost" HeaderText="Amount" SortExpression="monServiceCost" />
                      </Columns>
                      </asp:GridView>
                  
          </div>
         
         
          
        
         
            
<%--=========================================End My Code From Here=================================================--%>
       
    </ContentTemplate>
    </asp:UpdatePanel>
        
    </form>
</body>
</html>

