<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssertReport.aspx.cs" Inherits="UI.Asset.AssertReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" /> 
  </head>

 <body> 
    <form id="frmTransferOrders" runat="server"><asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
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
  <div class="leaveApplication_container">   
  <div class="tabs_container" align="left">Maintenance Service Report </div> 
 
 <div>
<table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; " class="tblrowodd">
    <tr class="tblrowodd">
      <td style="text-align:right;">
        <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Asset/Job Number:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:TextBox ID="TxtAsset" runat="server" CssClass="txtBox" Font-Bold="False" OnTextChanged="TxtAsset_TextChanged">
        </asp:TextBox>
      <td style="text-align:right;">
        <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Name of Asset:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False">
        </asp:TextBox>
    </tr>
    <tr>
      <td style="text-align:right;">
        <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="JobStation:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:DropDownList ID="DdlJostation" runat="server" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="DdlJostation_SelectedIndexChanged">
       </asp:DropDownList></td>
      <td style="text-align:right;">
        <asp:Label ID="LblDept" runat="server" font-size="small" CssClass="lbl" Text="Department:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:DropDownList ID="DdlDept" runat="server" CssClass="ddList" Font-Bold="False" AutoPostBack="True">
        </asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td style="text-align:right;">
        <asp:Label ID="LbldteIssue" runat="server" CssClass="lbl" Text="From Date:">
        </asp:Label>
      </td>
      <td>
        <asp:TextBox ID="TxtdteFrom" runat="server" CssClass="txtBox">
        </asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteFrom">
        </cc1:CalendarExtender>
      <td style="text-align:right;">
        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date:">
        </asp:Label>
      </td>
      <td>
        <asp:TextBox ID="TxtdteTo" runat="server" CssClass="txtBox">
        </asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteTo">
        </cc1:CalendarExtender>
      </td>
    </tr>
    <tr>
      <td style="text-align:right;">
        <asp:Label ID="LblTypet" runat="server" CssClass="lbl" font-size="small" Text="Report Type:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:DropDownList ID="DdlType" runat="server" CssClass="ddList" Font-Bold="False">
          <asp:listitem>PM Service</asp:listitem>
          <asp:listitem>Corrective Service</asp:listitem>
          <asp:listitem>User Request Service</asp:listitem>
          <asp:listitem>Maintenance</asp:listitem>
          <asp:listitem>Workorder</asp:listitem>
          <asp:listitem>Asset Register</asp:listitem>
          <asp:listitem>Vehicle Register</asp:listitem>
          <asp:listitem>Land</asp:listitem>
          <asp:listitem>Land Devlopment</asp:listitem>
        </asp:DropDownList>
      <td style="text-align:right;">
        <asp:Label ID="Label2" runat="server" CssClass="lbl" font-size="small" Text="Type:">
        </asp:Label>
      </td>
      <td style="text-align:left;">
        <asp:DropDownList ID="DdlAssetClas" runat="server" CssClass="ddList" Font-Bold="False">
        </asp:DropDownList></td>
    </tr> 
       <tr> 
       <td style="text-align:right;">
        <asp:Label ID="Label3" runat="server" CssClass="lbl" font-size="small" >
        </asp:Label>
      </td>
        <td style="text-align:right;" colspan="5"  >
        <asp:Button ID="btnShow" runat="server" AutoPostBack="true" Text="Show" OnClick="btnShow_Click" />
        </td> 
        </tr>

  </table>
 
<table>
  <tr>
    <td>
      <asp:GridView ID="dgview" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate>
              <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
              </asp:TemplateField>
            <asp:BoundField DataField="intMaintenanceNo" HeaderText="WO.No" SortExpression="intMaintenanceNo" />
            <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strServiceName" HeaderText="ServiceName" SortExpression="strServiceName" />
            <asp:BoundField DataField="Assignto" HeaderText="Assign To" SortExpression="Assignto" />
            <asp:BoundField DataField="ServiceType" HeaderText="ServiceType" SortExpression="ServiceType" />
            <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
            <asp:BoundField DataField="dteStartDate" HeaderText="StartDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteStartDate" />
            <asp:BoundField DataField="dteEndDate" HeaderText="EndDate" dataformatstring="{0: d MMMM, yyyy}" SortExpression="dteEndDate" />
            <asp:TemplateField HeaderText="Detalis">
              <ItemTemplate>
                <asp:Button ID="BtnMDetalis" CommandName="Detalis" CommandArgument='<%# Eval("intMaintenanceNo") %>' runat="server" Text="Detalis" OnClick="BtnMDetalis_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </td>
  </tr>
  </table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvPMService" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate>
              <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
              </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="intID" SortExpression="intID" />
            <asp:BoundField HeaderText="Asset Code" DataField="strAssetNumber" SortExpression="strAssetNumber" />
            <asp:BoundField HeaderText="Asset Name" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
            <asp:BoundField HeaderText="ServiceName" DataField="strServiceName" SortExpression="strServiceName" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="YesnServiceType" />
            <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
            <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" SortExpression="dteFixed/Repair" />
            </Columns>
          </asp:GridView>
        </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvCorrectiveService" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate>
              <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
              </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="intID" SortExpression="intID" />
            <asp:BoundField HeaderText="Asset Code" DataField="strAssetNumber" SortExpression="strAssetNumber" />
            <asp:BoundField HeaderText="Asset Name" DataField="strNameOfAsset" SortExpression="strNameOfAsset" />
            <asp:BoundField HeaderText="ServiceName" DataField="strServiceName" SortExpression="strServiceName" />
            <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="YesnServiceType" />
            <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
            <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" SortExpression="dteFixed/Repair" />
            <asp:BoundField DataField="StatusView" HeaderText="Status" SortExpression="StatusView" />
            </Columns>
          </asp:GridView>
        </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvUserRequest" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="strAssetNumber" HeaderText="Asset Code" SortExpression="strAssetNumber" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strLocation" HeaderText="Location" SortExpression="strLocation" />
            <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
            <asp:BoundField DataField="dteFixed/Repair" HeaderText="Date" SortExpression="dteFixed/Repair" />
            <asp:BoundField DataField="strPriroty" HeaderText="Priority" SortExpression="strPriroty" />
           </Columns>
          </asp:GridView>
        </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvAssetregister" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Sl.N"><HeaderTemplate> 
            <asp:TextBox ID="TxtAssetregister" runat="server" width="75" placeholder="Search">
            </asp:TextBox></HeaderTemplate> 
            <ItemTemplate> <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField> 
            <asp:BoundField DataField="strAssetID" HeaderText="Asset Code" SortExpression="strAssetID" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strJobStationName" HeaderText="JobStation" SortExpression="strJobStationName" />
            <asp:BoundField DataField="strAssetMainType" HeaderText="Type" SortExpression="strAssetMainType" />
            <asp:BoundField DataField="strAssetTypeName" HeaderText="Asset Class" SortExpression="strAssetTypeName" />
            <asp:BoundField DataField="strPlantName" HeaderText="PlantName" SortExpression="strPlantName" />
            <asp:BoundField DataField="strCategoryName" HeaderText="Category" SortExpression="strCategoryName" />
            <asp:BoundField DataField="strCCName" HeaderText="CostCenter" SortExpression="strCCName" />
            <asp:BoundField DataField="strDescriptionAsset" HeaderText="Description" SortExpression="strDescriptionAsset" />
            <asp:BoundField DataField="strHSCode" HeaderText="HS Code" SortExpression="strHSCode" />
            <asp:BoundField DataField="strNameManufacturer" HeaderText="Manufacturer" SortExpression="strNameManufacturer" />
            <asp:BoundField DataField="strCountryOrigin" HeaderText="Origin" SortExpression="strCountryOrigin" />
            <asp:BoundField DataField="strCountryManufacturing" HeaderText="Country" SortExpression="strCountryManufacturing" />
            <asp:BoundField DataField="strSupplierName" HeaderText="Supplier" SortExpression="strSupplierName" />
            <asp:BoundField DataField="strLCNo" HeaderText="LC No" SortExpression="strLCNo" />
            <asp:BoundField DataField="dteLCDate" HeaderText="LC Date" DataFormatString="{0:d}" SortExpression="dteLCDate" />
            <asp:BoundField DataField="strPoNo" HeaderText="PO No" SortExpression="strPoNo" />
            <asp:BoundField DataField="dtePoNo" HeaderText="Po Date" DataFormatString="{0:d}" SortExpression="dtePoNo" />
            <asp:BoundField DataField="strCurrency" HeaderText="Currency" SortExpression="strCurrency" />
            <asp:BoundField DataField="strIncoterms" HeaderText="Incoterms" SortExpression="strIncoterms" />
            <asp:BoundField DataField="strInstallationLocation" HeaderText="Location" SortExpression="strInstallationLocation" />
            <asp:BoundField DataField="strFunctionoftheAsset" HeaderText="Function" SortExpression="strFunctionoftheAsset" />
            <asp:BoundField DataField="dteInstallation" HeaderText="Installation Date" DataFormatString="{0:d}" SortExpression="dteInstallation" />
            <asp:BoundField DataField="monErectionInstallCost" HeaderText="Erection Cost" SortExpression="monErectionInstallCost" />
            <asp:BoundField DataField="strDepatrment" HeaderText="Dept" SortExpression="strDepatrment" />
            <asp:BoundField DataField="dtrAcusition" HeaderText="Acusition Date" SortExpression="dtrAcusition" />
            <asp:BoundField DataField="strRecommanLife" HeaderText="Life " SortExpression="strRecommanLife" />
            <asp:BoundField DataField="monEstSolvageValue" HeaderText="EstSolvage" SortExpression="monEstSolvageValue" />
            <asp:BoundField DataField="monLandedCost" HeaderText="LandedCost" SortExpression="monLandedCost" />
            <asp:BoundField DataField="monTAccumulatedCost" HeaderText="TAccumulatedCost" SortExpression="monTAccumulatedCost" />
            <asp:BoundField DataField="monRateOfDepeciation" HeaderText="RateDepeciation" SortExpression="monRateOfDepeciation" />
            <asp:BoundField DataField="monAccumulatedDepeciation" HeaderText="Acc.Depeciation" SortExpression="monAccumulatedDepeciation" />
            <asp:BoundField DataField="strMethodDepeciation" HeaderText="Method" SortExpression="strMethodDepeciation" />
            <asp:BoundField DataField="monValueAfterDepeciation" HeaderText="ValueADepeciation" SortExpression="monValueAfterDepeciation" />
            <asp:BoundField DataField="monWritDownValue" HeaderText="WritDownValue" SortExpression="monWritDownValue" />
            <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks" />
            <asp:BoundField DataField="strManufacProvideSL" HeaderText="Serial Number" SortExpression="strManufacProvideSL" />
            </Columns>
          </asp:GridView>
        </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvJobcard" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate> </asp:TemplateField> 
            <asp:BoundField DataField="intMaintenanceNo" HeaderText="WO.No" SortExpression="intMaintenanceNo" />
            <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strItemName" HeaderText="Parts" SortExpression="strItemName" />
            <asp:BoundField DataField="intQty" HeaderText="Qty" SortExpression="intQty" />
            <asp:BoundField DataField="strEmployeeName" HeaderText="Performer by" SortExpression="strEmployeeName" />
            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
            <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
            <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
            <asp:BoundField DataField="strpath" HeaderText="DocPath" SortExpression="strpath" />
            </Columns>
          </asp:GridView>
        </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvVehicleRegister" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <HeaderTemplate> Search <br /> 
            <asp:TextBox ID="TextBox1" runat="server" width="75" ></asp:TextBox> 
            </HeaderTemplate>
            <ItemTemplate>  <%# Container.DataItemIndex + 1 %>  </ItemTemplate> </asp:TemplateField> 
            <asp:BoundField DataField="strAssetID" HeaderText="Asset Code" SortExpression="strAssetID" />
            <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="NameOfFixedAsset" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strAssetTypeName" HeaderText="Type" SortExpression="strAssetTypeName" />
            <asp:BoundField DataField="strCategoryName" HeaderText="Category" SortExpression="strCategoryName" />
            <asp:BoundField DataField="strDescriptionAsset" HeaderText="Description" SortExpression="strDescriptionAsset" />
            <asp:BoundField DataField="strHSCode" HeaderText="HS Code" SortExpression="strHSCode" />
            <asp:BoundField DataField="strNameManufacturer" HeaderText="Manufacturer" SortExpression="strNameManufacturer" />
            <asp:BoundField DataField="strCountryOrigin" HeaderText="Origin" SortExpression="strCountryOrigin" />
            <asp:BoundField DataField="strCountryManufacturing" HeaderText="Country" SortExpression="strCountryManufacturing" />
            <asp:BoundField DataField="strSupplierName" HeaderText="Supplier" SortExpression="strSupplierName" />
            <asp:BoundField DataField="strLCNo" HeaderText="LC No" SortExpression="strLCNo" />
            <asp:BoundField DataField="dteLCDate" HeaderText="LC Date" DataFormatString="{0:d}" SortExpression="dteLCDate" />
            <asp:BoundField DataField="strPoNo" HeaderText="PO No" SortExpression="strPoNo" />
            <asp:BoundField DataField="dtePoNo" HeaderText="Po Date" DataFormatString="{0:d}" SortExpression="dtePoNo" />
            <asp:BoundField DataField="strCurrency" HeaderText="Currency" SortExpression="strCurrency" />
            <asp:BoundField DataField="strIncoterms" HeaderText="Incoterms" SortExpression="strIncoterms" />
            <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" />
            <asp:BoundField DataField="dtrAcusition" HeaderText="Aquesition" DataFormatString="{0:d}" SortExpression="dtrAcusition" />
            <asp:BoundField DataField="strRecommanLife" HeaderText="Recomanded life" SortExpression="strRecommanLife" />
            <asp:BoundField DataField="strVServiceType" HeaderText="Service Type" SortExpression="strVServiceType" />
            <asp:BoundField DataField="strVBrand" HeaderText="Brand" SortExpression="strVBrand" />
            <asp:BoundField DataField="strVModel" HeaderText="Model" SortExpression="strVModel" />
            <asp:BoundField DataField="strVCC" HeaderText="CC" SortExpression="strVCC" />
            <asp:BoundField DataField="strVColor" HeaderText="Color" SortExpression="strVColor" />
            <asp:BoundField DataField="strVEngineNo" HeaderText="Engine" SortExpression="strVEngineNo" />
            <asp:BoundField DataField="strVChasisNo" HeaderText="Chasis No" SortExpression="strVChasisNo" />
            <asp:BoundField DataField="strVInetialMilege" HeaderText="Mileage" SortExpression="strVInetialMilege" />
            <asp:BoundField DataField="strVFuelstatus" HeaderText="Fuel Status" SortExpression="strVFuelstatus" />
            <asp:BoundField DataField="IntVUserEnroll" HeaderText="User Enroll" SortExpression="IntVUserEnroll" />
            <asp:BoundField DataField="strVehicleLodan" HeaderText="LadenW" SortExpression="strVehicleLodan" />
            <asp:BoundField DataField="strVehicleUnLodan" HeaderText="UnLodan W" SortExpression="strVehicleUnLodan" />
            <asp:BoundField DataField="DteVRegistrationDate" HeaderText="Registration Date" DataFormatString="{0:d}" SortExpression="DteVRegistrationDate" />
            <asp:BoundField DataField="DteVTaxToken" HeaderText="Token" SortExpression="DteVTaxToken" />
            <asp:BoundField DataField="DteVFitnessDate" HeaderText="Fitness" DataFormatString="{0:d}" SortExpression="DteVFitnessDate" />
            <asp:BoundField DataField="DteVInsuranceDate" HeaderText="Insurance" DataFormatString="{0:d}" SortExpression="DteVInsuranceDate" />
            <asp:BoundField DataField="dteVRootPermitValidity" HeaderText="Root Validity" DataFormatString="{0:d}" SortExpression="dteVRootPermitValidity" />
            <asp:BoundField DataField="strVehiclePolicyNo" HeaderText="Policy no" SortExpression="strVehiclePolicyNo" />
            <asp:BoundField DataField="strVehiclePolicyType" HeaderText="PolicyType" SortExpression="strVehiclePolicyType" />
            <asp:BoundField DataField="monEstSolvageValue" HeaderText="EstSolvage" SortExpression="monEstSolvageValue" />
            <asp:BoundField DataField="monLandedCost" HeaderText="LandedCost" SortExpression="monLandedCost" />
            <asp:BoundField DataField="monTAccumulatedCost" HeaderText="TAccumulatedCost" SortExpression="monTAccumulatedCost" />
            <asp:BoundField DataField="monRateOfDepeciation" HeaderText="RateDepeciation" SortExpression="monRateOfDepeciation" />
            <asp:BoundField DataField="monAccumulatedDepeciation" HeaderText="Acc.Depeciation" SortExpression="monAccumulatedDepeciation" />
            <asp:BoundField DataField="strMethodDepeciation" HeaderText="Method" SortExpression="strMethodDepeciation" />
            <asp:BoundField DataField="monValueAfterDepeciation" HeaderText="ValueADepeciation" SortExpression="monValueAfterDepeciation" />
            <asp:BoundField DataField="monWritDownValue" HeaderText="WritDownValue" SortExpression="monWritDownValue" />
            <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks" />
            </Columns>
          <HeaderStyle BackColor="#3AC0F2" ForeColor="White" />
          </asp:GridView>
     </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="dgvLand" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate> <%# Container.DataItemIndex + 1 %> </ItemTemplate>  </asp:TemplateField> 
            <asp:BoundField DataField="strAssetID" HeaderText="Asset Code" SortExpression="strAssetID" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
            <asp:BoundField DataField="strJobStationName" HeaderText="JobStation" SortExpression="strJobStationName" />
            <asp:BoundField DataField="strDescriptionAsset" HeaderText="Description" SortExpression="strDescriptionAsset" />
            <asp:BoundField DataField="strPoNo" HeaderText="PO" SortExpression="strPoNo" />
            <asp:BoundField DataField="strBuyerName" HeaderText="Buyer Name" SortExpression="strBuyerName" />
            <asp:BoundField DataField="strNameofSeller" HeaderText="Seller Name" SortExpression="strNameofSeller" />
            <asp:BoundField DataField="strClassofLand" HeaderText="Land Class" SortExpression="strClassofLand" />
            <asp:BoundField DataField="strDistrict" HeaderText="District" SortExpression="strDistrict" />
            <asp:BoundField DataField="Thana" HeaderText="Thana" SortExpression="Thana" />
            <asp:BoundField DataField="strMouza" HeaderText="Mouja" SortExpression="strMouza" />
            <asp:BoundField DataField="strCSkhatianNo" HeaderText="CSkhatianNo" SortExpression="strCSkhatianNo" />
            <asp:BoundField DataField="strSAkhatianNo" HeaderText="SAkhatianNo" SortExpression="strSAkhatianNo" />
            <asp:BoundField DataField="strRSkhatianNo" HeaderText="RSkhatianNo" SortExpression="strRSkhatianNo" />
            <asp:BoundField DataField="strDSkhatianNo" HeaderText="DSkhatianNo" SortExpression="strDSkhatianNo" />
            <asp:BoundField DataField="strDPkhatianNo" HeaderText="DPkhatianNo" SortExpression="strDPkhatianNo" />
            <asp:BoundField DataField="strCSdagNo" HeaderText="CSdagNo" SortExpression="strCSdagNo" />
            <asp:BoundField DataField="strSAdagNo" HeaderText="strSAdagNo" SortExpression="strSAdagNo" />
            <asp:BoundField DataField="dteDeedDate" HeaderText="DeedDate" SortExpression="dteDeedDate" />
            <asp:BoundField DataField="dteDeedCertifiedCopyReceivedDate" HeaderText="DeedCertifiedCopyReceivedDate" DataFormatString="{0:d}" SortExpression="dteDeedCertifiedCopyReceivedDate" />
            <asp:BoundField DataField="dteOriginalCopyReceivedDate" HeaderText="OriginalCopyReceivedDate" DataFormatString="{0:d}" SortExpression="dteOriginalCopyReceivedDate" />
            <asp:BoundField DataField="numAreaofLnadinKhata" HeaderText="AreaofLnadinKhata" SortExpression="numAreaofLnadinKhata" />
            <asp:BoundField DataField="numAreaofLnadindecimal" HeaderText="AreaofLnadindecimal" SortExpression="numAreaofLnadindecimal" />
            <asp:BoundField DataField="monPriceperKhata" HeaderText="PriceperKhata" SortExpression="monPriceperKhata" />
            <asp:BoundField DataField="monPriceperDecimal" HeaderText="PriceperDecimal" SortExpression="monPriceperDecimal" />
            <asp:BoundField DataField="monTotalValueofLand" HeaderText="TotalValueofLand" SortExpression="monTotalValueofLand" />
            <asp:BoundField DataField="monRegistryBinaAmount" HeaderText="RegistryBinaAmount" SortExpression="monRegistryBinaAmount" />
            <asp:BoundField DataField="monBalanceofLandValue" HeaderText="BalanceofLandValue" SortExpression="monBalanceofLandValue" />
            <asp:BoundField DataField="monRegistrationExp" HeaderText="RegistrationExp" SortExpression="monRegistrationExp" />
            <asp:BoundField DataField="monDeedValueofLand" HeaderText="DeedValueofLand" SortExpression="monDeedValueofLand" />
            <asp:BoundField DataField="monOfficeVolumeCheckingExp" HeaderText="OfficeVolumeCheckingExp" SortExpression="monOfficeVolumeCheckingExp" />
            <asp:BoundField DataField="monNFees" HeaderText="NFees" SortExpression="monNFees" />
            <asp:BoundField DataField="monLocalGovtTax" HeaderText="LocalGovtTax" SortExpression="monLocalGovtTax" />
            <asp:BoundField DataField="monStampCharge" HeaderText="StampCharge" SortExpression="monStampCharge" />
            <asp:BoundField DataField="monIncomeTax" HeaderText="IncomeTax" SortExpression="monIncomeTax" />
            <asp:BoundField DataField="monGainTax" HeaderText="GainTax" SortExpression="monGainTax" />
            <asp:BoundField DataField="monPayorderExp" HeaderText="PayorderExp" SortExpression="monPayorderExp" />
            <asp:BoundField DataField="monSubRegisterCom" HeaderText="SubRegisterCom" SortExpression="monSubRegisterCom" />
            <asp:BoundField DataField="monDeedCertifiedCopyExp" HeaderText="DeedCertifiedCopyExp" SortExpression="monDeedCertifiedCopyExp" />
            <asp:BoundField DataField="monMutationExp" HeaderText="MutationExp" SortExpression="monMutationExp" />
            <asp:BoundField DataField="monOtherExpenses" HeaderText="OtherExpenses" SortExpression="monOtherExpenses" />
            <asp:BoundField DataField="numTotalAreaofLandmuted" HeaderText="TotalAreaofLandmuted" SortExpression="numTotalAreaofLandmuted" />
            <asp:BoundField DataField="strJLNo" HeaderText="JLNo" SortExpression="strJLNo" />
            <asp:BoundField DataField="strHoldingNo" HeaderText="HoldingNo" SortExpression="strHoldingNo" />
            <asp:BoundField DataField="monLanddevelopmentTaxExp" HeaderText="LanddevelopmentTaxExp" SortExpression="monLanddevelopmentTaxExp" />
            <asp:BoundField DataField="monBrokerCom" HeaderText="BrokerCom" SortExpression="monBrokerCom" />
            <asp:BoundField DataField="monTAccumulatedCost" HeaderText="TAccumulatedCost" SortExpression="monTAccumulatedCost" />
            <asp:BoundField DataField="monTotalLandAccusitionCost" HeaderText="TotalLandAccusitionCost" SortExpression="monTotalLandAccusitionCost" />
            </Columns>
          </asp:GridView>
     </td>
  </tr>
</table>
<table>
  <tr>
    <td>
      <asp:GridView ID="DgvlandDevlopment" runat="server" AutoGenerateColumns="False">
        <Columns>
          <asp:TemplateField HeaderText="Sl.N">
            <ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate> </asp:TemplateField> 
            <asp:BoundField DataField="strAssetID" HeaderText="AssetCode" SortExpression="strAssetID" />
            <asp:BoundField DataField="strNameOfAsset" HeaderText="Asset Name" SortExpression="strNameOfAsset" />
            <asp:BoundField DataField="strUnit" HeaderText="Unit Name" SortExpression="strUnit" />
            <asp:BoundField DataField="strJobStationName" HeaderText="JobStation" SortExpression="strJobStationName" />
            <asp:BoundField DataField="strAssetTypeName" HeaderText="Asset type" SortExpression="strAssetTypeName" />
            <asp:BoundField DataField="strDescriptionAsset" HeaderText="Description" SortExpression="strDescriptionAsset" />
            <asp:BoundField DataField="strCategoryName" HeaderText="Category" SortExpression="strCategoryName" />
            <asp:BoundField DataField="strInstallationLocation" HeaderText="Location" SortExpression="strInstallationLocation" />
            <asp:BoundField DataField="strPoNo" HeaderText="PO" SortExpression="strPoNo" />
            <asp:BoundField DataField="dtePoNo" HeaderText="Po Date" SortExpression="dtePoNo" />
            <asp:BoundField DataField="strSupplierName" HeaderText="Suppliyer" SortExpression="strSupplierName" />
            <asp:BoundField DataField="strRecommanLife" HeaderText="Estimateded Life" SortExpression="strRecommanLife" />
            <asp:BoundField DataField="monTAccumulatedCost" HeaderText="TAccumulatedCost" SortExpression="monTAccumulatedCost" />
            <asp:BoundField DataField="strRequestby" HeaderText="Requestby" SortExpression="strRequestby" />
            <asp:BoundField DataField="strRequestApproved" HeaderText="RequestApproved" SortExpression="strRequestApproved" />
            <asp:BoundField DataField="DtePorjectstardtDate" HeaderText="PorjectstartDate" SortExpression="DtePorjectstardtDate" />
            <asp:BoundField DataField="DteDeliverydate" HeaderText="DeliveryDate" SortExpression="DteDeliverydate" />
            <asp:BoundField DataField="strProjectNumber" HeaderText="ProjectNumber" SortExpression="strProjectNumber" />
            <asp:BoundField DataField="strLength" HeaderText="Length" SortExpression="strLength" />
            <asp:BoundField DataField="strBreadth" HeaderText="Breadth" SortExpression="strBreadth" />
            <asp:BoundField DataField="strHeight" HeaderText="Height" SortExpression="strHeight" />
            <asp:BoundField DataField="strTotalArea" HeaderText="TotalArea" SortExpression="strTotalArea" />
            <asp:BoundField DataField="monEstimatiCost" HeaderText="EstematedCost" SortExpression="monEstimatiCost" />
            <asp:BoundField DataField="monEstmateConstriuction" HeaderText="EstmateConstriuction Cost" SortExpression="monEstmateConstriuction" />
            <asp:BoundField DataField="monActualConstruction" HeaderText="ActualConstruction" SortExpression="monActualConstruction" />
            <asp:BoundField DataField="strConstructorYear" HeaderText="ContructorYear" SortExpression="strConstructorYear" />
            <asp:BoundField DataField="ServiceDept" HeaderText="ServiceDept" SortExpression="ServiceDept" />
            <asp:BoundField DataField="strFunndingSource" HeaderText="FunndingSource" SortExpression="strFunndingSource" />
            <asp:BoundField DataField="strConsultant" HeaderText="Consultant" SortExpression="strConsultant" />
            <asp:BoundField DataField="strContractorName" HeaderText="ContractorName" SortExpression="strContractorName" />
            <asp:BoundField DataField="strEovationWork" HeaderText="EovationWork" HtmlEncodeFormatString="False" SortExpression="strEovationWork" />
            <asp:BoundField DataField="strApproximiatly" HeaderText="Approximiatly" SortExpression="strApproximiatly" />
            <asp:BoundField DataField="strRenovationmateralis" HeaderText="Renovationmateralis" SortExpression="strRenovationmateralis" />
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