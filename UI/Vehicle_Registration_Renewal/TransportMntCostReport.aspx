<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransportMntCostReport.aspx.cs" Inherits="UI.Vehicle_Registration_Renewal.TransportMntCostReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
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
    SearchText();
});
function Changed() {
    document.getElementById('hdfSearchBoxTextChange').value = 'true';
}
function SearchText() {
    $("#txtVheicleNumber").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json;",
                url: "TransportMntCostReport.aspx/GetAutoserachingVheicleName",
                data: "{'strSearchKey':'" + document.getElementById('txtVheicleNumber').value + "'}",
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
           
            var txtDteFrom = document.forms["frmpdv"]["txtEffectiveDate"].value;
            var txtvhcl = document.forms["frmpdv"]["txtVheicleNumber"].value;

            if (txtDteFrom == null || txtDteFrom == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtEffectiveDate").focus();
            }
            else if (txtvhcl == null || txtvhcl == "") {
                alert("From date must be filled by valid formate (yyyy-MM-dd).");
                document.getElementById("txtVheicleNumber").focus();
            }
           

            else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            }
        }
            
          
</script>
    <script type="text/javascript">
            function isNumber(evt) {
                var iKeyCode = (evt.which) ? evt.which : evt.keyCode
                if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                    return false;

                return true;
            }
            function RemoveRow(item) {
                var table = document.getElementById('GridView1');
                table.deleteRow(item.parentNode.parentNode.rowIndex);
                return false;
            }
            function sum() {
                var txtDriverAllowance1 = document.getElementById('txtDriverAllowance').value;
                var txtMntcostfactory1 = document.getElementById('txtMntcostfactory').value;
                var txtMntcostHO1 = document.getElementById('txtMntcostHO').value;
                var txtMntWSHP1 = document.getElementById('txtMntWSHP').value;

                if (txtDriverAllowance1 == "")
                    txtDriverAllowance1 = 0;
                if (txtMntcostfactory1 == "")
                    txtMntcostfactory1 = 0;
                if (txtMntcostHO1 == "")
                    txtMntcostHO1 = 0;
                if (txtMntWSHP1 == "")
                    txtMntWSHP1 = 0;
                var result = parseInt(txtDriverAllowance1) + parseInt(txtMntcostfactory1) + parseInt(txtMntcostHO1) + parseInt(txtMntWSHP1);
                if (!isNaN(result)) {
                    document.getElementById('txtTotal').value = result;
                }
            }



            </script>

    
</head>
<body>
    <form id="frmpdv" runat="server">
  <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        <CompositeScript><Scripts>
        <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts></CompositeScript>
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

<div class="leaveApplication_container"> 
    <div class="tabs_container"> Transport Bill info Inactive :<asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        <asp:HiddenField ID="HiddenUnit" runat="server"/><asp:HiddenField ID="hdnData" runat="server"/>
       
        <hr /></div>
        <table border="0"; style="width:Auto"; >  
            <tr>
                 <td>
                                From
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnFrm" runat="server" />
                                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                                               
                            </td>
                  <td>
                                To
                            </td>
                            <td>
                                <asp:HiddenField ID="hdnTo" runat="server" />
                                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                                                        
                            </td>
                    </tr>
            <tr class="tblroweven">
                 <td style="text-align:right"><asp:Label ID="lblVheicleNumber" CssClass="lbl" runat="server" Text="Vheicle No.:  "></asp:Label></td>
        <td> <asp:TextBox ID="txtVheicleNumber" runat="server" BackColor="#ff6666" AutoPostBack="false" CssClass="txtBox"  Width="200px" ></asp:TextBox></td>
       <td style="text-align:right;">
                <asp:Label runat="server" Text="ReportType" AutoPostBack="true"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drdlreporttype" runat="server">
                    <asp:ListItem Text="Individual" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Topsheet" Value="2"></asp:ListItem>
                     <asp:ListItem Text="Income and Expense" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
              <tr><td style="text-align:right" colspan="3">
            <asp:Button ID="btnShowDelvRepot" runat="server" Text="Show Report" CssClass="button" OnClick="btnShowDelvRepot_Click"  /></td>
             <td style="text-align:right"> <asp:Button ID="btnExportToExcel" runat="server" Text="Export" OnClick="btnExportToExcel_Click" /></td>

        </tr>
            <tr>
                <td>
                               Unit
                               
                            </td>
                 <td>
                     <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="True" DataSourceID="odsUnit"
                                    DataTextField="strUnit" DataValueField="intUnitID" OnDataBound="ddlUnit_DataBound"
                                    OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetUnits" TypeName="HR_BLL.Global.Unit">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="1" Name="userID" SessionField="sesUserID" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                </td>
            </tr>


</table>
    </div>
        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    <asp:GridView ID="grdvMntcostentryReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvMntcostentryReport_RowDataBound" OnRowDeleting="grdvMntcostentryReport_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                        <%--strname ,vhclid ,vtype ,billdate ,fmnt , homnt ,wshpmnt ,drvallwnce ,dectotalcost ,remarks ,dteinserdate--%>
                        <Columns>
                            <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("BillDate") %>' /></ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="strname" HeaderText="Vheicle Name" SortExpression="strname" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             
                            <asp:TemplateField HeaderText="Driver Allowance" HeaderStyle-HorizontalAlign="Center" SortExpression="busfair">
                            <ItemTemplate><asp:Label ID="lbldrvallownce" runat="server" Text='<%# (""+Eval("drvallwnce")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lbldrvallownce1" runat="server" Font-Bold="true"  Text='<%# drvallow %>'  /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Factory Mnt." HeaderStyle-HorizontalAlign="Center" SortExpression="Rickfai">
                            <ItemTemplate><asp:Label ID="lblfactorymnt" runat="server" Text='<%# (""+Eval("fmnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblfactorymnt1" runat="server" Font-Bold="true"  Text='<%# factmnt %>'  /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="H.O Mnt. Cost" HeaderStyle-HorizontalAlign="Center" SortExpression="cngfair">
                            <ItemTemplate><asp:Label ID="lblhomnt" runat="server" Text='<%# (""+Eval("homnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblhomnt1" runat="server" Font-Bold="true" Text='<%# homnts %>' /></FooterTemplate></asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Central W. Shop" HeaderStyle-HorizontalAlign="Center" SortExpression="trainfair">
                            <ItemTemplate><asp:Label ID="lblcworkshp" runat="server" Text='<%# (""+Eval("wshpmnt")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblcworkshp1" runat="server" Font-Bold="true"   Text='<%# workshpmnt %>'/></FooterTemplate></asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Total Cost" HeaderStyle-HorizontalAlign="Center" SortExpression="trainfair">
                            <ItemTemplate><asp:Label ID="lblGrandTotal" runat="server" Text='<%# (""+Eval("dectotalcost")) %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="120px"/><FooterTemplate><asp:Label ID="lblGrandTotal1" runat="server" Font-Bold="true"   Text='<%# grandtotal %>'/></FooterTemplate></asp:TemplateField>
                            
                            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                        </Columns>
                    </asp:GridView></td></tr>
            </table>

        </div>

        <div class="leaveApplication_container">
            <table>
             <tr class="tblroweven">
                <td>
                    <asp:GridView ID="grdvOwnVhclIncomeExpense" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="grdvOwnVhclIncomeExpense_RowDataBound" OnRowDeleting="grdvOwnVhclIncomeExpense_RowDeleting">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                      
                        <Columns>
                            <asp:TemplateField  HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnSL" runat="server" Value='<%# Bind("strRegNo") %>' /></ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="strRegNo" HeaderText="Vheicle Name" SortExpression="strRegNo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="intTotalMillage" HeaderText="Total Milage" SortExpression="intTotalMillage" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                           <asp:BoundField DataField="interpcounttrip" HeaderText="SW Trip" SortExpression="interpcounttrip" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="decerpcountdelv" HeaderText="SW Delv" SortExpression="decerpcountdelv" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="monerpcountlogisticcharge" HeaderText="SW Logistic Charge" SortExpression="decerpcountdelv" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="monTripFare" HeaderText="Manual Trip Fare" SortExpression="monTripFare" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="monTotalTripFare" HeaderText="Manual Total Trip Fare" SortExpression="monTotalTripFare" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="monTripFare" HeaderText="Manual Trip Fare" SortExpression="monTripFare" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="monDieselTotalTk" HeaderText="Disel" SortExpression="monDieselTotalTk" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="monCNGTotalTk" HeaderText="CNG" SortExpression="monCNGTotalTk" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="totalfuelcost" HeaderText="Total Fuel Cost" SortExpression="totalfuelcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="monTotalRouteEXP" HeaderText="Total Route Expense" SortExpression="monTotalRouteEXP" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="mondrvallowance" HeaderText="DriverAllowance" SortExpression="mondrvallowance" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="monFactmnt" HeaderText="Factory Mnt." SortExpression="monFactmnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            <asp:BoundField DataField="monhomnt" HeaderText="HO Mnt." SortExpression="monhomnt" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="monTotalRouteEXP" HeaderText="Total Route Expense" SortExpression="monTotalRouteEXP" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                              <asp:BoundField DataField="moncworskhop" HeaderText="CW Mnt." SortExpression="moncworskhop" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                             <asp:BoundField DataField="montotalmntcost" HeaderText="Total Mnt. Cost" SortExpression="montotalmntcost" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />
                            
                            
                            
                            
                            
                            <asp:BoundField DataField="POL" HeaderText="Balance" SortExpression="POL" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" />


                            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> 

                        </Columns>
                    </asp:GridView></td></tr>
            </table>

        </div>




<%--=========================================End My Code From Here=================================================--%>
  
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>