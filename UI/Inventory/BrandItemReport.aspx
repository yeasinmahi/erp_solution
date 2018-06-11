<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrandItemReport.aspx.cs" Inherits="UI.Inventory.BrandItemReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

   <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

    
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
                         url: "BrandItemReport.aspx/GetAutoCompleteBrandItemNameWithStockStatus",
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

         $(document).ready(function () {
             SearchSupplierlistText();
         });
         function Changed() {
             document.getElementById('hdfSupplierNameserachboxchange').value = 'true';
         }
         function SearchSupplierlistText() {
             $("#txtSupplierName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "BrandItemReport.aspx/GetAutoCompleteSupplierName",
                         data: "{'prefix':'" + document.getElementById('txtSupplierName').value + "'}",
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
             SearchCustnameText();
         });
         function Changed() {
             document.getElementById('hdfCustnamSearchbox').value = 'true';
         }
         function SearchCustnameText() {
             $("#txtCustName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "BrandItemReport.aspx/GetAutoCompleteDepotName",
                         data: "{'prefix':'" + document.getElementById('txtCustName').value + "'}",
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
               var txtItem = document.forms["frmpdv"]["txtItem"].value;

               var txtChallanNumber = document.forms["frmpdv"]["txtChallan"].value;
               var txtQuantity = document.forms["frmpdv"]["txtQuantity"].value;
               var txtSupplierName = document.forms["frmpdv"]["txtSupplierName"].value;
               if (txtChallanNumber == null || txtChallanNumber == "") { alert("Please enter valid Challan ."); }
               else if (txtItem == null || txtItem == "") { alert("Please select item list ."); }
               else if (txtSupplierName == null || txtSupplierName == "") { alert("Please select Supplier Name ."); }
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
     <form id="frmpdv" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
 
<%--=========================================Start My Code From Here===============================================--%>

         <div class="leaveApplication_container"> <div class="tabs_container"> Brand Item Report Checking : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnunitid" runat="server"/><hr /></div>
<table border="0"; style="width:Auto"; >
             
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtDueDate', { 'dateFormat': 'Y-m-d' });</script></td>
    <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
<td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
<script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>  


               
    </tr>
          
           
               
       

    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Ware House : "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
    <td><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="True" CssClass="ddList" DataTextField="WH" DataValueField="intWHID" OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged" DataSourceID="odswh"></asp:DropDownList>
               
               
        <asp:ObjectDataSource ID="odswh" runat="server" SelectMethod="GetBrandItemWarehouseList" TypeName="HR_BLL.TourPlan.TourPlanning">
            <SelectParameters>
                <asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" />
                <asp:ControlParameter ControlID="hdnuserid" Name="type" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
               
               
    </td>
        <td style="text-align:right;"><asp:Label ID="lblSupplierName" CssClass="lbl" runat="server"  Text="Supplier Name: "></asp:Label></td>
    <td>
    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
    </td>

    </tr>
    <tr class="tblroweven">
    <td style="text-align:right"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit Name:  "></asp:Label></td>
                         
                <td><asp:DropDownList ID="drdlUnitName" CssClass="ddList"  runat="server" DataSourceID="odsUnitNameByEnrol" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>
            
        <asp:ObjectDataSource ID="odsUnitNameByEnrol" runat="server" SelectMethod="getUnitNamebyEnrol" TypeName="HR_BLL.TourPlan.TourPlanning">
            <SelectParameters>
                <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
</td>
        <td style="text-align:right"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Report Type:  "></asp:Label></td>
                    <%-- <td><asp:DropDownList ID="ddlReportType" CssClass="ddList" runat="server" DataSourceID="odsRept" DataTextField="strReportType" DataValueField="intID"></asp:DropDownList>
                                    
                        <asp:ObjectDataSource ID="odsRept" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteTaDaReportType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblRemoteTADAReportTypeTableAdapter">
                            <InsertParameters>
                                <asp:Parameter Name="strReportType" Type="String" />
                            </InsertParameters>
                        </asp:ObjectDataSource>
                                    
    </td>--%>

            <td><asp:DropDownList ID="ddlReportType" CssClass="ddList" runat="server">
                <asp:ListItem Value="2">Topsheet</asp:ListItem>
                <asp:ListItem Value="1">Detaills</asp:ListItem>
                <asp:ListItem Value="1018">Allotmetn Aprv Topsheet</asp:ListItem>
                <asp:ListItem Value="1019">All point Allotment vs Recv</asp:ListItem>
                <asp:ListItem Value="1020">Individual point Allotment vs Recv</asp:ListItem>
                <asp:ListItem Value="1021">Stock status at a Glance Horizontally</asp:ListItem>
                <asp:ListItem Value="1022">Challan status at a Glance</asp:ListItem>
                <asp:ListItem Value="1023">Receive status at a Glance Horizontally</asp:ListItem>
                <asp:ListItem Value="1024">Stock status at a Glance Vertically</asp:ListItem>
                <asp:ListItem Value="1025">Receive status at a Glance Vertically</asp:ListItem>
                <asp:ListItem Value="1026">Receive status Vertically (Det)</asp:ListItem>
                <asp:ListItem Value="1027">Receive status Supplier Detaills (Specific Supplier)</asp:ListItem>
                <asp:ListItem Value="1028">RCV item vs grandtotal (Specific supplier) </asp:ListItem>
                <asp:ListItem Value="1029">RCV item vs grandtotal (All supplier) </asp:ListItem>

                <asp:ListItem Value="1030">Challan  at a Glance Vertically (Det)</asp:ListItem>
                <asp:ListItem Value="1031">Challan  at a Glance Vertically (Topsheet) </asp:ListItem>
                <asp:ListItem Value="1032">Challan  without challan Specifice customer</asp:ListItem>
                <asp:ListItem Value="1033">Challan  without challan Specifice Item </asp:ListItem>
                <asp:ListItem Value="1034">Challan  Specifice Item vs Specific customer </asp:ListItem>
                <asp:ListItem Value="1035">Specific Item Inventory </asp:ListItem>
                <asp:ListItem Value="1036">All Item Inventory </asp:ListItem>

                </asp:DropDownList>
                                    
                                    
                                    
    </td>

        </tr>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Item List : "></asp:Label></td>
        <td><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
        <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfItemSearchBoxTextChange" runat="server" /><asp:HiddenField ID="hdfSupplierNameserachboxchange" runat="server" />
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdfCustnamSearchbox" runat="server" />
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnAction" runat="server"/><asp:HiddenField ID="hdnunit" runat="server"/><asp:HiddenField ID="hdnwh" runat="server"/>
        </td>
            <%--DataTextField="pointname" DataValueField="pointID" DataSourceID="odspointlist"--%>
        <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Ship Point: "></asp:Label><asp:HiddenField ID="HiddenField1" runat="server"/></td>
    <td colspan="3"><asp:DropDownList ID="drdlPointNamelist" runat="server" AutoPostBack="True" CssClass="ddList"  OnDataBound="drdlPointNamelist_DataBound" OnSelectedIndexChanged="drdlPointNamelist_SelectedIndexChanged" DataSourceID="odsDirectPointList" DataTextField="pointname" DataValueField="pointID" ></asp:DropDownList>
               
               
               
               
         
               
        <asp:ObjectDataSource ID="odsDirectPointList" runat="server" SelectMethod="GetAclDirectPointList" TypeName="HR_BLL.TourPlan.TourPlanning">
            <SelectParameters>
                <asp:SessionParameter Name="Unitid" SessionField="sesUnit" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
               
               
               
               
         
               
    </td>
                   


        </tr>
<tr>
    <td style="text-align:right;"><asp:Label ID="lblDepot" runat="server" CssClass="lbl" Text="Depot Name"></asp:Label></td>
    <td>
    <asp:TextBox ID="txtCustName" runat="server" CssClass="txtBox" AutoPostBack="true"></asp:TextBox>
    </td>

</tr>
        <tr class="tblrowOdd"><td style="text-align:right" > <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
        <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>
        </tr>
                
</table>
<table>
<div>
<table>

    <tr class="tblrowodd">
            <td>
                  

            <asp:GridView ID="grdvBrandItemWHBaseTopsheet" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvBrandItemWHBaseTopsheet_PageIndexChanging" OnRowDataBound="grdvBrandItemWHBaseTopsheet_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="strItemName" HeaderText="Item Name" SortExpression="strItemName" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"  />
            </asp:BoundField>
            <asp:BoundField DataField="monStock" HeaderText="StockQnt" SortExpression="monStock" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"  />
            </asp:BoundField>
            <asp:BoundField DataField="ItemNumber" HeaderText="Itemid" SortExpression="ItemNumber" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"  />
            </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

    </td>
</tr>

</table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                  
        <asp:GridView ID="grdvVheicleStatusMonitoring" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdvVheicleStatusMonitoring_PageIndexChanging" OnRowDataBound="grdvVheicleStatusMonitoring_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Req" HeaderText="ReqID" SortExpression="Req" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Items" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="AppQuantity" HeaderText="Qnt" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strCustname" HeaderText="strCustname" SortExpression="strCustname" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strVheiclename" HeaderText="Vheicle Name" SortExpression="strVheiclename" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strDrivername" HeaderText="Driver" SortExpression="strDrivername" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strDrvPhone" HeaderText="Driver" SortExpression="strDrvPhone" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strDrvPhone" HeaderText="Phone" SortExpression="strDrvPhone" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="Edate" HeaderText="Vheicle Name" SortExpression="Edate" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="strTripcode" HeaderText="TripCode" SortExpression="strTripcode" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Right" BackColor="#F7F7DE" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvRptFromRequisitionToUserRecv" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdvRptFromRequisitionToUserRecv_PageIndexChanging" OnRowDataBound="grdvRptFromRequisitionToUserRecv_RowDataBound">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Code" HeaderText="ReqCode" SortExpression="Code" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="intid" HeaderText="intid" SortExpression="intid" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Items" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                <asp:BoundField DataField="Edate" HeaderText="Date" SortExpression="Edate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="200px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Qnt" SortExpression="Quantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="AppQuantity" HeaderText="AppQuantity" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                <asp:BoundField DataField="supervaprvqntPending" HeaderText="SupvAprvPending" SortExpression="supervaprvqntPending" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="eventDeptAprvQnt" HeaderText="eventDAprvQnt" SortExpression="eventDeptAprvQnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                <asp:BoundField DataField="eventDeptPendingQnt" HeaderText="eventDPendingQnt" SortExpression="eventDeptPendingQnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="IssQuantity" HeaderText="WHIssueQnt" SortExpression="IssQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="UserRecvQnt" HeaderText="UserRecvQnt" SortExpression="UserRecvQnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                <asp:BoundField DataField="UserRecvQntPending" HeaderText="UserRecvPending" SortExpression="UserRecvQntPending" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                   
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvRptForACLEmailsendtoSupplier" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdvRptForACLEmailsendtoSupplier_PageIndexChanging" OnRowDataBound="grdvRptForACLEmailsendtoSupplier_RowDataBound">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Code" HeaderText="Req Code Number" ItemStyle-Width="200px" SortExpression="Code" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
            <asp:BoundField DataField="Edate" HeaderText="Date" ItemStyle-Width="200px" SortExpression="Edate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Items" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="AppQuantity" HeaderText="Approve Quantity" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                     
                      
                <asp:BoundField DataField="strPointName" HeaderText="Point Name" ItemStyle-Width="200px" SortExpression="strPointName" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="200px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvAllpointRcvCompare" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="4" GridLines="None" OnPageIndexChanging="grdvAllpointRcvCompare_PageIndexChanging" OnRowDataBound="grdvAllpointRcvCompare_RowDataBound" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:BoundField DataField="strPointName" HeaderText="Point Name" ItemStyle-Width="200px" SortExpression="strPointName" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Items" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="AppQuantity" HeaderText="Approve Quantity" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="numQntRecvbyPoint" HeaderText="Rcv Quantity By Point" SortExpression="numQntRecvbyPoint" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="200px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Center" BackColor="#FFCC66" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvSinglePointAllotmentVsRcvCompare" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="3000" CellPadding="4" GridLines="None" OnPageIndexChanging="grdvAllpointRcvCompare_PageIndexChanging" OnRowDataBound="grdvAllpointRcvCompare_RowDataBound" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:BoundField DataField="strPointName" HeaderText="Point Name" ItemStyle-Width="200px" SortExpression="strPointName" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>
        <asp:BoundField DataField="Items" HeaderText="Items" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="AppQuantity" HeaderText="Approve Quantity" SortExpression="AppQuantity" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="numQntRecvbyPoint" HeaderText="Rcv Quantity By Point" SortExpression="numQntRecvbyPoint" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="200px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        </Columns>
            <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
    <table>
        <tr>
            <td>
                <asp:GridView ID="grdvStockStatusHorizontaly" runat="server" AutoGenerateColumns="true">

                </asp:GridView>
            </td>
        </tr>
    </table>
</div>

<div>
    <table>
        <tr>
            <td>
                <asp:GridView ID="grdvBrandItemChallan" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />

                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
<div>
    <table>
        <tr>
            <td>
                <asp:GridView ID="grdvReceiveChallan" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />

                </asp:GridView>
            </td>
        </tr>
    </table>
</div>
<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvVerticalyrptReceive" runat="server" AutoGenerateColumns="False" AllowPaging="True" ShowFooter="true" PageSize="3000" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdvVerticalyrptReceive_PageIndexChanging" OnRowDataBound="grdvVerticalyrptReceive_RowDataBound" ForeColor="Black" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:BoundField DataField="rcvdate" HeaderText="Date" ItemStyle-Width="300px" SortExpression="rcvdate" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>

            <asp:BoundField DataField="challan" HeaderText="challan" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        <asp:BoundField DataField="itmid" HeaderText="itmid" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="itmname" HeaderText="itmname" ItemStyle-Width="400px"  SortExpression="itmname" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="qnt" HeaderText="Rcv Quantity By Point" SortExpression="qnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="strsupplier" HeaderText="strsupplier" ItemStyle-Width="400px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

<div>
        <table>

        <tr class="tblrowodd">
        <td>
                 
        <asp:GridView ID="grdvchallanVerticallay" runat="server" AutoGenerateColumns="False" ShowFooter="true" AllowPaging="True" PageSize="3000" CellPadding="3" GridLines="Vertical" OnPageIndexChanging="grdvchallanVerticallay_PageIndexChanging" OnRowDataBound="grdvchallanVerticallay_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
        <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:BoundField DataField="intcustid" HeaderText="CustomerID" ItemStyle-Width="300px" SortExpression="rcvdate" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>

            <asp:BoundField DataField="custname" HeaderText="Customer Name" ItemStyle-Width="200px" SortExpression="Items" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        <asp:BoundField DataField="dtedate" HeaderText="InsertDate"  ItemStyle-Width="400px" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dtedate" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="productid" HeaderText="Item ID" ItemStyle-Width="400px"  SortExpression="itmname" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="strprdname" HeaderText="ItemName" ItemStyle-Width="600px" SortExpression="qnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="decqnt" HeaderText="Quantity" ItemStyle-Width="400px" SortExpression="Remarks" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

            <asp:BoundField DataField="strchallannumber" HeaderText="Challan number" ItemStyle-Width="400px" SortExpression="strchallannumber" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        </td>

        </tr>
        </table>


</div>

    <div>
    <table>

        <tr class="tblrowodd">
        <td>
        <%--intSL,whid,dtedate,itmid,itmname,opnqnt,receiveqnt,issueqnt,balnceqnt--%>
        <asp:GridView ID="grdvBranditemInventoryRpt" runat="server" AutoGenerateColumns="False" ShowFooter="True" AllowPaging="True" PageSize="3000" CellPadding="3" OnPageIndexChanging="grdvBranditemInventoryRpt_PageIndexChanging" OnRowDataBound="grdvBranditemInventoryRpt_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="intSL" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
            <asp:BoundField DataField="dtedate" HeaderText="DateOfMonth" ItemStyle-Width="400px" DataFormatString="{0:dd-MM-yyyy}" SortExpression="rcvdate" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
                    </asp:BoundField>

            <asp:BoundField DataField="itmid" HeaderText="itmid" ItemStyle-Width="200px" SortExpression="itmid" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        <asp:BoundField DataField="itmname" HeaderText="ProductName"  ItemStyle-Width="800px"  SortExpression="itmname" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="opnqnt" HeaderText="Opening Qnt" ItemStyle-Width="400px"  SortExpression="opnqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="receiveqnt" HeaderText="Receive Qnt" ItemStyle-Width="600px" SortExpression="receiveqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="issueqnt" HeaderText="Issue Qnt" ItemStyle-Width="400px" SortExpression="issueqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

            <asp:BoundField DataField="balnceqnt" HeaderText="Balance Qnt" ItemStyle-Width="400px" SortExpression="balnceqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td>

        </tr>
        </table>
    <table>
        <tr>
            <td>

            </td>
        </tr>
    </table>
    </div>
     <div>
    <table>

        <tr class="tblrowodd">
        <td>
        <%--intSL,whid,dtedate,itmid,itmname,opnqnt,receiveqnt,issueqnt,balnceqnt--%>
        <asp:GridView ID="grdvBrandItemInventoryTopsheet" runat="server" AutoGenerateColumns="False" ShowFooter="True" AllowPaging="True" PageSize="3000" CellPadding="3" OnPageIndexChanging="grdvBrandItemInventoryTopsheet_PageIndexChanging" OnRowDataBound="grdvBrandItemInventoryTopsheet_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="intSL" HeaderText="Sl" SortExpression="Sl" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
          

            <asp:BoundField DataField="itmid" HeaderText="itmid" ItemStyle-Width="200px" SortExpression="itmid" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        <asp:BoundField DataField="itmname" HeaderText="ProductName"  ItemStyle-Width="800px"  SortExpression="itmname" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

                       
        <asp:BoundField DataField="opnqnt" HeaderText="Opening Qnt" ItemStyle-Width="400px"  SortExpression="opnqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
            <asp:BoundField DataField="receiveqnt" HeaderText="Receive Qnt" ItemStyle-Width="600px" SortExpression="receiveqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>
                      
                      
                         
        <asp:BoundField DataField="issueqnt" HeaderText="Issue Qnt" ItemStyle-Width="400px" SortExpression="issueqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

            <asp:BoundField DataField="balnceqnt" HeaderText="Balance Qnt" ItemStyle-Width="400px" SortExpression="balnceqnt" ItemStyle-HorizontalAlign="Center" >
        <ItemStyle HorizontalAlign="Center"  />
        </asp:BoundField>

        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        </td>

        </tr>
        </table>


     </div>         
    
    </table>
             </div>
        <%--=========================================End My Code From Here=================================================--%>
  
    </form>
</body>
</html>
