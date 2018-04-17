<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTReportForAccounts.aspx.cs" Inherits="UI.Transport.InternalTReportForAccounts" %>
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
            document.getElementById("divTopSheet").style.display = "none";
        }
        function hideGridAll() {
            document.getElementById("divTopSheet").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
        }
        function BillSubmitOfVehicleCost() {
            document.getElementById("divTopSheet").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
        }
        function BillSubmitOfFuelCost() {
            document.getElementById("divTopSheet").style.display = "none";
            document.getElementById("divFuelStationWiseBill").style.display = "none";
            alert("Bill Submit Successfully.");
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
        
        <div class="tabs_container"> REPORT FOR ACCOUNTS <hr /></div>

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

     <div id="divTopSheet">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvTopSheet" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvTopSheet_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Vehicle No." SortExpression="strRegNo"><ItemTemplate>            
            <asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strRegNo") %>' Width="140px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
                            
            <asp:TemplateField HeaderText="Millage (KM)" ItemStyle-HorizontalAlign="right" SortExpression="intTotalMillage">
            <ItemTemplate><asp:Label ID="lblMillage1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intTotalMillage"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmillage1 %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Standard Fuel Cost" ItemStyle-HorizontalAlign="right" SortExpression="TotalFuelCost" > 
            <ItemTemplate><asp:Label ID="lblTotalFuelCost" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("TotalFuelCost"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalfuelcost %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Administrative Cost" ItemStyle-HorizontalAlign="right" SortExpression="AdministrativeCost" > 
            <ItemTemplate><asp:Label ID="lblAdministrativeCost" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("AdministrativeCost"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="20px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladministrativecost %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Driver Exp" ItemStyle-HorizontalAlign="right" SortExpression="DriverExp" >
            <ItemTemplate><asp:Label ID="lblDriverExp" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("DriverExp"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaldriverexp %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Route EXP." ItemStyle-HorizontalAlign="right" SortExpression="monTotalRouteEXP" >
            <ItemTemplate><asp:Label ID="lblTotalRouteEXP" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalRouteEXP"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltotalRouteexp1 %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Total Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTotalTripFare" > 
            <ItemTemplate><asp:Label ID="lblTotalTripFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalTripFare"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltotaltripfare1 %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Income" ItemStyle-HorizontalAlign="right" SortExpression="NetIncome" >
            <ItemTemplate><asp:Label ID="lblNetIncome1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("NetIncome"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalnetincome1 %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Down Trip Fare Cash" ItemStyle-HorizontalAlign="right" SortExpression="monTotalDTripFareCash" >
            <ItemTemplate><asp:Label ID="lblTotalDownTripFareCash1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalDTripFareCash"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalDTFareCash %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Fuel Credit" ItemStyle-HorizontalAlign="right" SortExpression="TotalFuelCredit" >
            <ItemTemplate><asp:Label ID="lblTotalFuelCredit1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("TotalFuelCredit"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalFuelCredit %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Payable" ItemStyle-HorizontalAlign="right" SortExpression="monNetPayable" >
            <ItemTemplate><asp:Label ID="lblNetPayable1" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monNetPayable"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalnetpayable1 %>' /></FooterTemplate></asp:TemplateField>
            
            <%--<asp:TemplateField HeaderText="intReffID" Visible="false" SortExpression="intID"><ItemTemplate>            
            <asp:Label ID="lblReffID" runat="server" Text='<%# Bind("intID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>--%>

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
