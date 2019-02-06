<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTForTransportDeptLavel1.aspx.cs" Inherits="UI.Transport.InternalTForTransportDeptLavel1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
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
    <script src="../Content/JS/CustomizeScript.js"></script>

    <script type="text/javascript">
        function hideGrid1() {
            document.getElementById("divFuelStationWiseBill").style.display = "none";
        }
        function hideGrid2() {
            document.getElementById("divExport").style.display = "none";
        }
        function hideGridAll() {
            document.getElementById("divExport").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
        }
        function BillSubmitOfVehicleCost() {
            document.getElementById("divExport").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
        }
        function BillSubmitOfFuelCost() {
            document.getElementById("divExport").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
        }

        function TripDetails(reqsid) {
            window.open('InternalTTripDetails.aspx?intID=' + reqsid, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
        }

        function ViewDocList(Id) {
            //window.open('InternalTDocPathList.aspx?ID=' + Id, 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
            window.open('InternalTDocPathList.aspx?ID=' + Id, 'sub', "height=400, width=670, scrollbars=yes, left=330, top=50, resizable=no, title=Preview");
            ///Transport/DocPathList.aspx
            //newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=250,width=500,top=50,left=150, close=no');
            //if (window.focus) { newwindow.focus() }
        }


    </script>

</head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnTopSheetCount" runat="server" /><asp:HiddenField ID="hdnFuelCostCount" runat="server" /> 
    <asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <div class="tabs_container"> REPORT FOR TRANSPORT DEPT Lavel-1 <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblShipPoint" runat="server" CssClass="lbl" Text="Ship Point"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlShipPoint" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlShipPoint_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>                                                                         

            <%--<td style="text-align:right;"><asp:Label ID="lblSearchBuyerReff" runat="server" CssClass="lbl" Text="Trip SL No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchTripSLNo" runat="server" CssClass="txtBox"></asp:TextBox></td>              --%>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblReport" runat="server" CssClass="lbl" Text="Report:"></asp:Label></td>                
            <td>
                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="true" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="1">Vehicle Wise Trip Cost Report</asp:ListItem><asp:ListItem Value="2">Fuel Cost Report</asp:ListItem>                
                </asp:DropDownList>
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblBill" CssClass="lbl" runat="server" Text="Bill Status : "></asp:Label></td>
            <td><asp:RadioButton ID="rdoPending" runat="server" Checked="true" Text="Pending" OnCheckedChanged="rdoPending_CheckedChanged" AutoPostBack="true" />
            <asp:RadioButton ID="rdoComplete" runat="server" Text="Complete" OnCheckedChanged="rdoComplete_CheckedChanged"  AutoPostBack="true"  /></td>
                        
            <%--<td colspan="6" style="text-align:left;"><asp:Button ID="btnExportToExcel" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Export To Excel" OnClick="btnExportToExcel_Click" OnClientClick="ExportDivDataToExcel2()"/></td>--%>            
        </tr>        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblSearchVehicle" runat="server" CssClass="lbl" Text="Vehicle No.:"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchVehicle" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                       

            <td style="text-align:right;"><asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Report Type:"></asp:Label></td>                
            <td><asp:RadioButton ID="rdoAll" runat="server" Checked="true" Text="All" AutoPostBack="true" OnCheckedChanged="rdoAll_CheckedChanged"/>
            <asp:RadioButton ID="rdoAutoEntry" runat="server" Text="Auto Entry" AutoPostBack="true" OnCheckedChanged="rdoAutoEntry_CheckedChanged"/>
            <asp:RadioButton ID="rdoManualEntry" runat="server" Text="Manual Entry" AutoPostBack="true" OnCheckedChanged="rdoManualEntry_CheckedChanged"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:left;"><asp:Button ID="btnBillSubmit" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Bill Submit"  OnClientClick="ConfirmAll()" OnClick="btnBillSubmit_Click"/></td>
            <td style="text-align:left;"><asp:Button ID="btnSearchV" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Search Vehicle" OnClick="btnSearchV_Click"/></td>
            <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
        </tr>
                  

    </table>
    </div>

     <div id="divExport">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Summary Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>

            <tr><td> 
            <asp:GridView ID="dgvReportVehicleNDateWise" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvReportVehicleNDateWise_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="intid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intID" >
            <ItemTemplate><asp:Label ID="lblTripID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Vehicle No." SortExpression="strRegNo"><ItemTemplate>            
            <asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strRegNo") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Driver Name" SortExpression="DriverName"><ItemTemplate>            
            <asp:Label ID="lblDriverName1" runat="server" Text='<%# Bind("DriverName") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Trip SL No." SortExpression="strTripSLNo"><ItemTemplate>            
            <asp:Label ID="lblTripSLNo" runat="server" Text='<%# Bind("strTripSLNo") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Final Destination" SortExpression="strName"><ItemTemplate>            
            <asp:Label ID="lblCustomerName1" runat="server" Text='<%# Bind("strName") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
                            
            <asp:TemplateField HeaderText="Out Date" SortExpression="dteDate"><ItemTemplate>            
            <asp:Label ID="lblOutDate" runat="server" Text='<%# Bind("dteDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="In Date" SortExpression="dteInDate"><ItemTemplate>            
            <asp:Label ID="lblInDate" runat="server" Text='<%# Bind("dteInDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Millage (KM)" ItemStyle-HorizontalAlign="right" SortExpression="intMillage">
            <ItemTemplate><asp:Label ID="lblMillagekm" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intMillage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# millage %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Cause Of Additional Millage" SortExpression="strCauseOfAdditionalMillage"><ItemTemplate>            
            <asp:Label ID="lblAddMC" runat="server" Text='<%# Bind("strCauseOfAdditionalMillage") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Additional Millage(KM)" ItemStyle-HorizontalAlign="right" SortExpression="intAdditionalMillage">
            <ItemTemplate><asp:Label ID="lblAMillage" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intAdditionalMillage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# almillage %>' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Total Millage (KM)" ItemStyle-HorizontalAlign="right" SortExpression="intTotalMillage">
            <ItemTemplate><asp:Label ID="lblMillage" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intTotalMillage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmillage %>' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Diesel (Tk)" ItemStyle-HorizontalAlign="right" SortExpression="monDieselTotalTk" >
            <ItemTemplate><asp:Button ID="btnDslVew" runat="server" class="HyperLinkButtonStyle" style="cursor:pointer;" 
             CommandName="diesel" CommandArgument='<%# Eval("intID") %>' Text='<%# Eval("monDieselTotalTk") %>' OnCommand="btnDslVew_Click"/>
            <%--<asp:Label ID="lblDieselTk" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDieselTotalTk"))) %>'></asp:Label>--%></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldieseltk %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="CNG (Tk)" ItemStyle-HorizontalAlign="right" SortExpression="monCNGTotalTk" >
            <ItemTemplate><asp:Button ID="btnCngVew" runat="server" class="HyperLinkButtonStyle" style="cursor:pointer;" 
             CommandName="cng" CommandArgument='<%# Eval("intID") %>' Text='<%# Eval("monCNGTotalTk") %>' OnCommand="btnDslVew_Click"/>
            <%--<asp:Label ID="lblDieselTk" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDieselTotalTk"))) %>'></asp:Label>--%></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngtk %>' /></FooterTemplate></asp:TemplateField>


            <%--<asp:TemplateField HeaderText="CNG (Tk)" ItemStyle-HorizontalAlign="right" SortExpression="monCNGTotalTk" >
            <ItemTemplate><asp:Label ID="lblCNGTk" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monCNGTotalTk"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngtk %>' /></FooterTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Ferry Exp." ItemStyle-HorizontalAlign="right" SortExpression="monFerryEXP" >
            <ItemTemplate><asp:Label ID="lblFerryExp" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFerryEXP"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalferry %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Bridge Exp." ItemStyle-HorizontalAlign="right" SortExpression="monBridgeToll" >
            <ItemTemplate><asp:Label ID="lblBridgeExp" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monBridgeToll"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalbridge %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Cause Of Maintenance" SortExpression="strMaintenanceDesc"><ItemTemplate>            
            <asp:Label ID="lblCauseOfM" runat="server" Text='<%# Bind("strMaintenanceDesc") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Maintenance" ItemStyle-HorizontalAlign="right" SortExpression="monMaintenanceTK" >
            <ItemTemplate><asp:Button ID="btnMaintananceVew" runat="server" class="HyperLinkButtonStyle" style="cursor:pointer;" 
             CommandName="mainttk" CommandArgument='<%# Eval("intID") %>' Text='<%# Eval("monMaintenanceTK") %>' OnCommand="btnDslVew_Click"/>
            <%--<asp:Label ID="lblDieselTk" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDieselTotalTk"))) %>'></asp:Label>--%></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmaintenance %>' /></FooterTemplate></asp:TemplateField>
                                                
            <%--<asp:TemplateField HeaderText="Maintenance" ItemStyle-HorizontalAlign="right" SortExpression="monMaintenanceTK" >
            <ItemTemplate><asp:Label ID="lblMaintenance" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monMaintenanceTK"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmaintenance %>' /></FooterTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Police Tips" ItemStyle-HorizontalAlign="right" SortExpression="monPoliceEXP" >
            <ItemTemplate><asp:Label ID="lblpolice" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPoliceEXP"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalpolice %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Labour Cost" ItemStyle-HorizontalAlign="right" SortExpression="monLabourEXP" >
            <ItemTemplate><asp:Label ID="lblLabour" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monLabourEXP"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totallabour %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Cause Of Other's" SortExpression="strOhtersDetail"><ItemTemplate>            
            <asp:Label ID="lblCauseOfOthers" runat="server" Text='<%# Bind("strOhtersDetail") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Others Cost" ItemStyle-HorizontalAlign="right" SortExpression="monOthersTK" >
            <ItemTemplate><asp:Button ID="btnOtherVew" runat="server" class="HyperLinkButtonStyle" style="cursor:pointer;" 
             CommandName="othertk" CommandArgument='<%# Eval("intID") %>' Text='<%# Eval("monOthersTK") %>' OnCommand="btnDslVew_Click"/>
            <%--<asp:Label ID="lblDieselTk" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDieselTotalTk"))) %>'></asp:Label>--%></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalOther %>' /></FooterTemplate></asp:TemplateField>
                                 
                
            <%--<asp:TemplateField HeaderText="Others Cost" ItemStyle-HorizontalAlign="right" SortExpression="monOthersTK" >
            <ItemTemplate><asp:Label ID="lblOther" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monOthersTK"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalOther %>' /></FooterTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Millage Allowance" ItemStyle-HorizontalAlign="right" SortExpression="monMillageAllow" >
            <ItemTemplate><asp:Label ID="lblMillageAllow" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monMillageAllow"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmillageallow %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Down Trip Allowance" ItemStyle-HorizontalAlign="right" SortExpression="monDownTripAllow" >
            <ItemTemplate><asp:Label ID="lblDTripAllow" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDownTripAllow"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldtripallow %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Daily Allowance" ItemStyle-HorizontalAlign="right" SortExpression="monDailyAllow" >
            <ItemTemplate><asp:Label ID="lblDailyAllow" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDailyAllow"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldailyallow %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Trip Bonus" ItemStyle-HorizontalAlign="right" SortExpression="monTripBonus" >
            <ItemTemplate><asp:Label ID="lblTripBonus" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTripBonus"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltripbonus %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Time Allowance" ItemStyle-HorizontalAlign="right" SortExpression="monTimeAllow" >
            <ItemTemplate><asp:Label ID="lblTimeAllow" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTimeAllow"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltimeallow %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Fuel Cash" ItemStyle-HorizontalAlign="right" SortExpression="monFuelCash" >
            <ItemTemplate><asp:Label ID="lblFuelCash" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFuelCash"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalfuelcash %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Route Exp." ItemStyle-HorizontalAlign="right" SortExpression="monTotalRouteEXP" >
            <ItemTemplate><asp:Label ID="lblTotalRouteExp" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalRouteEXP"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalrouteexp %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTripFare" >
            <ItemTemplate><asp:Label ID="lblTripFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTripFare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltripfare %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Cause Of Additional Fare" SortExpression="strCauseOfAdditionalFare"><ItemTemplate>            
            <asp:Label ID="lblCauseOfAddFare" runat="server" Text='<%# Bind("strCauseOfAdditionalFare") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Additional Fare" ItemStyle-HorizontalAlign="right" SortExpression="monAdditionalFare" >
            <ItemTemplate><asp:Label ID="lblAdditionalFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAdditionalFare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladitionalfare %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Fare + Additional Fare" ItemStyle-HorizontalAlign="right" SortExpression="monFareAndAddiFare" >
            <ItemTemplate><asp:Label ID="lblFareAdditionalFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monFareAndAddiFare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalfareaditionalfare %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Down Trip Fare Cash" ItemStyle-HorizontalAlign="right" SortExpression="monTotalDTripFareCash" >
            <ItemTemplate><asp:Label ID="lblDTFCash" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalDTripFareCash"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldtfcash %>' /></FooterTemplate></asp:TemplateField>
         
            <asp:TemplateField HeaderText="Down Trip Fare Credit" ItemStyle-HorizontalAlign="right" SortExpression="monTotalDownTFareCredit" >
            <ItemTemplate><asp:Label ID="lblDTFCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalDownTFareCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldtfcredit %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTotalTripFare" >
            <ItemTemplate><asp:Label ID="lblTotalTripFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalTripFare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotaltripfare %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Diesel Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="monTotalDieselCredit" >
            <ItemTemplate><asp:Label ID="lblDieselTotalCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalDieselCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldieseltotalcredit %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="CNG Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="monTotalCNGCredit" >
            <ItemTemplate><asp:Label ID="lblCNGTotalCredit" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalCNGCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngtotalcredit %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Income" ItemStyle-HorizontalAlign="right" SortExpression="NetIncome" >
            <ItemTemplate><asp:Label ID="lblNetIncome" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("NetIncome"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalnetincome %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Payable" ItemStyle-HorizontalAlign="right" SortExpression="monNetPayable" >
            <ItemTemplate><asp:Label ID="lblNetPayable" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monNetPayable"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalnetpayable %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Trip Details" >
            <ItemTemplate><asp:Button ID="btnActionDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intID") %>' Text="Trip Details" OnClick="TripDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Document View" >
            <ItemTemplate><asp:Button ID="btnDocVew" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intID") %>' Text="Document View" OnClick="btnDocVew_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

            <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="center" SortExpression="">
            <ItemTemplate><a class="button" style="Font-Size:10px; color:black" href="#" onclick="<%#  ViewDocList(""+Eval("intID")) %>">Document List</a></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>--%>

            <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><a class="button" style="Font-Size:10px; color:Red" href="#" onclick="<%#  RejectClick(""+Eval("intApplicationID")) %>">Reject</a></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="35px" /></asp:TemplateField>--%>

            
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>            
        </table>     
    </div>
  
    <div id="divFuelStationWiseBill">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Fuel Station Wise Details Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label7" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label8" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label9" runat="server"></asp:Label></td></tr>


            <tr><td> 
            <asp:GridView ID="dgvFuelStationWiseBill" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvFuelStationWiseBill_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Fuel Party Name" SortExpression="strPartyName"><ItemTemplate>            
            <asp:Label ID="lblFuelParty" runat="server" Text='<%# Bind("strPartyName") %>' Width="300px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Diesel Credit" ItemStyle-HorizontalAlign="right" SortExpression="monDieselCredit" > 
            <ItemTemplate><asp:Label ID="lblDieselCredit1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDieselCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldieselc1 %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="CNG Credit" ItemStyle-HorizontalAlign="right" SortExpression="monCNGCredit" >
            <ItemTemplate><asp:Label ID="lblCNGC1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monCNGCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcngc1 %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Credit" ItemStyle-HorizontalAlign="right" SortExpression="TotalCredit" > 
            <ItemTemplate><asp:Label ID="lblTotalCredit1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("TotalCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltotalc1 %>' /></FooterTemplate></asp:TemplateField>
                        
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>        

         </table>     
      </div>


<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
