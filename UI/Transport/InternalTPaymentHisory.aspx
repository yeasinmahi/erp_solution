<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalTPaymentHisory.aspx.cs" Inherits="UI.Transport.InternalTPaymentHisory" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
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
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>

    <script type="text/javascript">       
        $(document).ready(function () {
            GridviewScroll();
        });
        function GridviewScroll() {

            $('#<%=dgvPaymentHisory.ClientID%>').gridviewScroll({
                 width: 925,
                 height: 300,
                 startHorizontal: 0,
                 wheelstep: 10,
                 barhovercolor: "#3399FF",
                 barcolor: "#3399FF"
             });
         }
    </script>
    <script type="text/javascript">
        function hideGrid1() {
            document.getElementById("divVendorTReport").style.display = "none";
        }
        function hideGrid2() {
            document.getElementById("divPaymentHisory").style.display = "none";
        }
        function hideGridAll() {
            document.getElementById("divPaymentHisory").style.display = "none";
            document.getElementById("divVendorTReport").style.display = "none";
        }
    </script>
    
</head>
<body>
    <form id="frmpaymenthistory" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    
<%--=========================================Start My Code From Here===============================================--%>
        </br><div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        <asp:HiddenField ID="hdnTopSheetCount" runat="server" /><asp:HiddenField ID="hdnFuelCostCount" runat="server" /> 
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        
        <div class="tabs_container"> PAYMENT HISTORY <hr /></div>
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
        </tr>
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        
        <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>        
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblReport" runat="server" CssClass="lbl" Text="Report:"></asp:Label></td>                
        <td>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="true" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="1">Internal Transport</asp:ListItem><asp:ListItem Value="2">Vendor Transport</asp:ListItem>                
            </asp:DropDownList>
        </td> 
        <td style="text-align:right;"><asp:Label ID="lblVehicleSupplier" runat="server" CssClass="lbl" Text="Vehicle Supplier:"></asp:Label></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlVehicleSupplier" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlVehicleSupplier_SelectedIndexChanged"></asp:DropDownList>                                                                                       
        </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClientClick="LoaderBusy()" OnClick="btnShowReport_Click"/></td>
        </tr>    
        </table>
        </div>

        <div id="divPaymentHisory">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
        <%--===========Top Sheet Report============--%>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitN" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromTo" runat="server"></asp:Label></td></tr>
            
        <tr><td> 
        <asp:GridView ID="dgvPaymentHisory" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvPaymentHisory_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
        <asp:TemplateField HeaderText="From Date (Billing Period)" SortExpression="dteFrom"><ItemTemplate>
        <asp:Label ID="lblFromDate" runat="server" Width="80px" Text='<%# Eval("dteFrom", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="80px"/>
        <FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="" /></div></FooterTemplate></asp:TemplateField>
      
        <asp:TemplateField HeaderText="To Date (Billing Period)" SortExpression="dteTo"><ItemTemplate>
        <asp:Label ID="lblToDate" runat="server" Width="80px" Text='<%# Eval("dteTo", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="80px"/>
        <FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="" /></div></FooterTemplate></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Transport Approved Date" SortExpression="dteTransport"><ItemTemplate>
        <asp:Label ID="lblTransportAppDate" runat="server" Width="80px" Text='<%# Eval("dteTransport", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="80px"/>
        <FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="" /></div></FooterTemplate></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Audit Approved Date" SortExpression="dteAudit"><ItemTemplate>
        <asp:Label ID="lblAuditAppDate" runat="server" Width="80px" Text='<%# Eval("dteAudit", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="80px"/>
        <FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="Grand Total :" /></div></FooterTemplate></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Total Millage (KM)" ItemStyle-HorizontalAlign="right" SortExpression="monTMilage">
        <ItemTemplate><asp:Label ID="lblMilla1" runat="server" Width="60px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTMilage"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalmilla1 %>' /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Fuel Cash" ItemStyle-HorizontalAlign="right" SortExpression="monTFuelCash" >
        <ItemTemplate><asp:Label ID="lblTotalFuelCash" Width="40px" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTFuelCash"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalFuelCash %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Fuel Credit" ItemStyle-HorizontalAlign="right" SortExpression="monTFuelCredit" >
        <ItemTemplate><asp:Label ID="lblTotalFuelCredit1" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTFuelCredit"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="65px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalFuelCredit %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Standared Fuel Cost (Approved)" ItemStyle-HorizontalAlign="right" SortExpression="TFuelCost" > 
        <ItemTemplate><asp:Label ID="lblTotalFuelCost" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("TFuelCost"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalfuelcost %>' /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Others Cost(Administrative and Driver)" ItemStyle-HorizontalAlign="right" SortExpression="monTOther" > 
        <ItemTemplate><asp:Label ID="lblOthers" runat="server" Width="95px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTOther"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="95px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalothers %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Total Route EXP." ItemStyle-HorizontalAlign="right" SortExpression="monTRouteExp" >
        <ItemTemplate><asp:Label ID="lblTotalRouteEXP" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTRouteExp"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="65px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltotalRouteexp1 %>' /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Trip Fare(Approved)" ItemStyle-HorizontalAlign="right" SortExpression="monTripFare" > 
        <ItemTemplate><asp:Label ID="lblTripFare" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTripFare"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltripfare1 %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Additional Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTAditionalFare" > 
        <ItemTemplate><asp:Label ID="lblAddTripFare" runat="server" Width="60px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTAditionalFare"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="60px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladdtripfare1 %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Down Trip Fare Cash" ItemStyle-HorizontalAlign="right" SortExpression="monDTFareCash" >
        <ItemTemplate><asp:Label ID="lblTotalDownTripFareCash1" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDTFareCash"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="65px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalDTFareCash %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Down Trip Fare Credit" ItemStyle-HorizontalAlign="right" SortExpression="monDTFareCredit" >
        <ItemTemplate><asp:Label ID="lblTotalDownTripFarecred" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monDTFareCredit"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="70px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalTotalDTFareCredit %>' /></FooterTemplate></asp:TemplateField>
                
        <asp:TemplateField HeaderText="Total Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTTripFare" > 
        <ItemTemplate><asp:Label ID="lblTotalTripFare" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTTripFare"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="65px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltotaltripfare1 %>' /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Net Payable" ItemStyle-HorizontalAlign="right" SortExpression="monNetP" >
        <ItemTemplate><asp:Label ID="lblNetPayable1" runat="server" Width="65px" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monNetP"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="65px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalnetpayable1 %>' /></FooterTemplate></asp:TemplateField>

        </Columns><HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" /></asp:GridView></td>
        </tr>
        </table>     
        </div>

        <div id="divVendorTReport">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Fuel Station Wise Details Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label20" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label21" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="Label22" runat="server"></asp:Label></td></tr>

            <tr><td> 
            <asp:GridView ID="dgvVendorsTReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvVendorsTReport_RowDataBound"> 
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="Challan Date" SortExpression="CompleteDate"><ItemTemplate>            
            <asp:Label ID="lblCompleteDate" runat="server" Text='<%# Bind("CompleteDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Trip SL No." SortExpression="strTripSLNo"><ItemTemplate>            
            <asp:Label ID="lblTripSLNo1" runat="server" Text='<%# Bind("strTripSLNo") %>' Width="140px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Vehicle No." SortExpression="strRegNo"><ItemTemplate>            
            <asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strRegNo") %>' Width="140px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Challan No." SortExpression="strChallanNo"><ItemTemplate>            
            <asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("strChallanNo") %>' Width="90px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="75px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Address" SortExpression="strAddress"><ItemTemplate>            
            <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("strAddress") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="intQuantity" > 
            <ItemTemplate><asp:Label ID="lblQuantity" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("intQuantity"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalqty %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Trip Fare" ItemStyle-HorizontalAlign="right" SortExpression="monTotalTripFareVT" > 
            <ItemTemplate><asp:Label ID="lblTripFareVT" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monTotalTripFareVT"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaltfvt %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Special Fare" ItemStyle-HorizontalAlign="right" SortExpression="monSpecialFareVT" > 
            <ItemTemplate><asp:Label ID="lblSpecialFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monSpecialFareVT"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalspf %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Additional Fare" ItemStyle-HorizontalAlign="right" SortExpression="monAddFareVT" > 
            <ItemTemplate><asp:Label ID="lblAdditionalFare" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monAddFareVT"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totaladf %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Company Dem." ItemStyle-HorizontalAlign="right" SortExpression="monCompanyDemVT" > 
            <ItemTemplate><asp:Label ID="lblCompanyDem" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monCompanyDemVT"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalcmd %>' /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Party Dem." ItemStyle-HorizontalAlign="right" SortExpression="monPartyDemVT" > 
            <ItemTemplate><asp:Label ID="lblPartyDem" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("monPartyDemVT"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalpd %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Payable" ItemStyle-HorizontalAlign="right" SortExpression="NetPayable" > 
            <ItemTemplate><asp:Label ID="lblNetPayable10" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("NetPayable"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalntp %>' /></FooterTemplate></asp:TemplateField>
  
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>        

         </table>     
      </div>

        <div class="loading" align="center">
        <%--Loading. Please wait.</hr><br />--%> 
        <%--<img src="../Content/Images/imagesCAAL9MHY.jpg" /> --%>
        <%--<img src="../Content/Images/imagesCAU8JX1Y.png" />--%>
        <%--<img src="../Content/Images/imagesCA35MWNI.png" /> --%>         
        <%--<img src="../../Content/images/gicon/loader.gif" />--%>
        <img src="../../Content/images/gicon/Final-Product-2.GIF" />
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
