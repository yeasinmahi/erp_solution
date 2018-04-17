<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemReqisition.aspx.cs" Inherits="UI.Inventory.BrandItemReqisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<script src="../Content/JS/datepickr.min.js"></script>

 <script type="text/javascript">
     $(document).ready(function () {
         SearchText();
     });
     function Changed() {
         document.getElementById('hdfSearchBoxTextChange').value = 'true';
     }
     function SearchText() {
         $("#txtFullName").autocomplete({
             source: function (request, response) {
                 $.ajax({
                     type: "POST",
                     contentType: "application/json;",
                     url: "BrandItemReqisition.aspx/GetAutoCompleteDataForTADA",
                     data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
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
  
     <script type="text/javascript">
         $(document).ready(function () {
             SearchItemText();
         });
         function Changed() {
             document.getElementById('hdfItemSearchBoxTextChange').value = 'true';
         }
         function SearchItemText() {
             $("#txtItem").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "BrandItemReqisition.aspx/GetAutoCompleteBrandItemName",
                         data: "{'prefix':'" + document.getElementById('txtItem').value + "'}",
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

       <script type="text/javascript">
             function Confirm() {
                 document.getElementById("hdnconfirm").value = "0";
                 var txtSection = document.forms["frmreq"]["txtSection"].value;
                 var txtQuantity = document.forms["frmreq"]["txtQuantity"].value;
                 if (txtSection == null || txtSection == "") { alert("Please enter valid section ."); }
                 else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00") { alert("Please enter valid quantity ."); }
                 else { document.getElementById("hdnconfirm").value = "1"; }
             }
             function isDecimal(value) {
                 return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
             }



             function Viewdetails(id) {
                 window.open('BradndItemRequisitonDetaills.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
             }
</script>


</head>
<body>
    <form id="frmreq" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 70px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

         <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
             
    <tr><td colspan="4" class="tblheader">Brand Item Requisiton Form :</td></tr>
              <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Due-Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtDueDate', { 'dateFormat': 'Y-m-d' });</script></td>
  
     <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Item List : "></asp:Label></td>
    <td colspan="1"><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfItemSearchBoxTextChange" runat="server" />
    </td>

    <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
    <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" Text="0.00"></asp:TextBox></td>
    
 
     <tr class="tblroweven">
        <%-- <td><asp:Label ID="lblRegion" CssClass="lbl" runat="server" Text="Region: "></asp:Label></td>
         <td> <asp:DropDownList ID="drdlRegion" CssClass="ddList" runat="server" DataSourceID="odsBrandReqRegion" DataTextField="strRegionName" DataValueField="intRegionid" AutoPostBack="true"></asp:DropDownList>
             <asp:ObjectDataSource ID="odsBrandReqRegion" runat="server" SelectMethod="getRegionName" TypeName="HR_BLL.TourPlan.TourPlanning">
                 <SelectParameters>
                     <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                     <asp:SessionParameter Name="strOfficeEmail" SessionField="sesEmail" Type="String" />
                 </SelectParameters>
             </asp:ObjectDataSource>
         </td>
         <td><asp:Label ID="lblArea" CssClass="lbl" runat="server" Text="Area: "></asp:Label></td>
           <td><asp:DropDownList ID="drdlArea" runat="server" DataSourceID="odsAreaName" DataTextField="strAreaName" DataValueField="intAreaid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsAreaName" runat="server" SelectMethod="getTourAreaName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlRegion" Name="RegionId" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
         <td><asp:Label ID="lblTerritory" CssClass="lbl" runat="server" Text="Territory: "></asp:Label></td>
          <td><asp:DropDownList ID="drdlTerritory" runat="server" DataSourceID="odsTourTerritoryName" DataTextField="strTerritoryName" DataValueField="intTerritoryid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsTourTerritoryName" runat="server" SelectMethod="getTourTerritoryName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlArea" Name="Areaid" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>--%>



          <td><asp:Label ID="lblRegion" runat="server" Text="Region"></asp:Label></td>
                <td ><asp:DropDownList ID="drdlRegion" CssClass="ddList" runat="server" DataSourceID="odsTourRegionName" DataTextField="strRegionName" DataValueField="intRegionid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsTourRegionName"  runat="server" SelectMethod="getRegionName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                            <asp:SessionParameter Name="strOfficeEmail" SessionField="sesEmail" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                
                <td><asp:Label ID="lblArea" runat="server" Text="Area"></asp:Label></td>
                <td><asp:DropDownList ID="drdlArea" CssClass="ddList" runat="server" DataSourceID="odsAreaName" DataTextField="strAreaName" DataValueField="intAreaid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsAreaName" runat="server" SelectMethod="getTourAreaName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlRegion" Name="RegionId" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="intUnitID" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td><asp:Label ID="lblTerritory" runat="server" Text="Territory"></asp:Label></td>
                <td><asp:DropDownList ID="drdlTerritory" CssClass="ddList" runat="server" DataSourceID="odsTourTerritoryName" DataTextField="strTerritoryName" DataValueField="intTerritoryid" AutoPostBack="true"></asp:DropDownList>
                    <asp:ObjectDataSource ID="odsTourTerritoryName" runat="server" SelectMethod="getTourTerritoryName" TypeName="HR_BLL.TourPlan.TourPlanning">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlArea" Name="Areaid" PropertyName="SelectedValue" Type="Int32" />
                            <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>






     </tr>
         
             <tr class="tblrowodd">
          <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Employee Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True"></asp:TextBox>
                <span style="color:red">*</span>
                <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
                <%--txtDepartment--%>
            </td>
            <td style="text-align:right;"><asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Code: "></asp:Label> </td>
            <td><asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
            
            <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department: "></asp:Label> </td>
            <td><asp:TextBox ID="txtSection" runat="server" AutoPostBack="false" Font-Bold="true" BackColor="#ffffcc" CssClass="txtBox" Enabled="false"></asp:TextBox>
                 <asp:HiddenField ID="hdnstation" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnAction" runat="server"/>
       
                <asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" />
            </td> 
     </tr>
             
                 
      <tr class="tblrowodd"> 
    <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Ship Point: "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
    <td><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" DataSourceID="odswh" DataTextField="WH" DataValueField="intWHID" OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
    <asp:ObjectDataSource ID="odswh" runat="server" SelectMethod="GetWarehouseList" TypeName="HR_BLL.Global.DaysOfWeek">
    <SelectParameters><asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" /><asp:ControlParameter ControlID="hdntype" Name="type" PropertyName="Value" Type="Int32" />
    </SelectParameters></asp:ObjectDataSource><asp:HiddenField ID="hdnwh" runat="server"/>
    </td>
    <td style="text-align:right;"><asp:Label ID="lbldpt" CssClass="lbl" runat="server" Text="Jobstation : "></asp:Label></td>
    <td><asp:Label ID="lblJobstation" CssClass="lbl" runat="server"></asp:Label></td>
     <td style="text-align:right;"><asp:Label ID="lblcont" CssClass="lbl" runat="server" Text="Contact No. : "></asp:Label></td>
    <td><asp:Label ID="lblContactNumber" CssClass="lbl" runat="server"></asp:Label></td>    
    </tr>

   
    <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
    <td colspan="5"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" Width="750" TextMode="MultiLine"></asp:TextBox></td>
    </tr>

    <tr class='tblroweven'>
       
    <td style="text-align:right;" colspan="3"><asp:Button ID="btnAdd" runat="server" Text="ADD" Font-Bold="true"
    OnClientClick = "Confirm()" OnClick="btnAdd_Click"></asp:Button><asp:HiddenField ID="hdnconfirm" runat="server" /></td>
        <td  style="text-align:right;"><asp:Button ID="btnSubmit" BackColor="#ffffcc" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click" /></td>
    </tr>
                  </table>
   <div>
       <table>
    <tr class=""><td style="text-align:justify;">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnitmid" runat="server" Value='<%# Bind("itemid") %>' /></ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="Due Date" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lbldudt" runat="server" Text='<%# Bind("dudt") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Section" SortExpression="sec">
    <ItemTemplate><asp:Label ID="lblSec" runat="server" Text='<%# Bind("sec") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
    <asp:TemplateField HeaderText="Description" SortExpression="item">
    <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Quantity" SortExpression="quantity">
    <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("quantity") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Enrol" SortExpression="userenrol">
    <ItemTemplate><asp:Label ID="lblEnrol" runat="server" Text='<%# Bind("userEnrol") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Territoryid" SortExpression="terrid">
    <ItemTemplate><asp:Label ID="lblTerid" runat="server" Text='<%# Bind("territoryid") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

        

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
        <ControlStyle Font-Bold="True" ForeColor="Red" />
        </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    </td></tr>
    </table></div>

<div class="leaveSummary_container"> 
        <div class="tabs_container">Requisition Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="LightGoldenrodYellow" 
        BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AllowPaging="True" Pagesize="25" DataSourceID="odsqwnreq" BorderColor="Tan"><AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Edate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="Edate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="Code" HeaderText="Requisition Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
        <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center" SortExpression="Section">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details" ><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("Req") %>' Text="Details"  OnClick="btnDetails_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                         
        </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
     <asp:ObjectDataSource ID="odsqwnreq" runat="server" SelectMethod="CreateStoreRequisitionForBrandItem" TypeName="HR_BLL.TourPlan.TourPlanning">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="actionby" SessionField="sesUserID" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="xml" Type="String" />
            <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
            <asp:Parameter DefaultValue="2015-10-01" Name="fdate" Type="DateTime" />
            <asp:Parameter DefaultValue="2020-12-31" Name="tdate" Type="DateTime" />
        </SelectParameters>
        </asp:ObjectDataSource>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
