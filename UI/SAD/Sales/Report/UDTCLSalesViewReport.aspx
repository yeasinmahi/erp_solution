<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UDTCLSalesViewReport.aspx.cs" Inherits="UI.SAD.Sales.Report.UDTCLSalesViewReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />--%>
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script>
        function ConfirmforShow() {           
            //debugger;
            var fromdate = document.getElementById("txtFormDate").value;
            var todate = document.getElementById("txtToDate").value;
            var report = document.getElementById("DdlReport").value;
            
            if (fromdate == null || fromdate=="") {
                alert('Insert From Date');
                return false;
            }
            else if (todate == null || todate=="") {
                alert('Insert To Date');
                return false;
            }
           
             else if (report == null || report=="") {
                alert('Insert Report Type');
                return false;
            }
            
            return true;
        }
    </script>
    <style>
        .divHeader{
            background-color:#9bb4dd; 
             border: 0px solid #000;
            text-align: center;
            color: #fff;
            width: 700px;
            height: 25px;
           font-weight: bold;
        }
       
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <div >
                    <div class="divHeader">UDTCL Sales View Report</div>
                    <table style="width: 700px; table-layout: auto; vertical-align: top; background-color: #DDD;" class="tblRowOdd">
                        <tr >
                           <td style="text-align:right;">
                                <asp:Label ID="Label1" runat="server" Text="From Date:" ></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtFormDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_1"  src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            <td style="text-align:right;"><asp:Label ID="Label2"  runat="server" Text="To Date:"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                          
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label9"  runat="server" Text="Unit:"></asp:Label></td>
                            <td><asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true"></asp:DropDownList>
                                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetData" TypeName="HR_DAL.Global.UnitTDSTableAdapters.SprGetUnitTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUserID" SessionField="sesUserID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </td>
                            <td style="text-align:right;"><asp:Label ID="Label3"  runat="server" Text="Sales Office:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlSalesOffice" runat="server"   CssClass="dropdownList" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intId" AutoPostBack="true"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSalesOffice" runat="server"  SelectMethod="GetSalesOfficeByUnitId" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblSalesOfficeTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            
                        </tr>
                         <tr>
                             <td style="text-align:right;"><asp:Label ID="Label6"  runat="server" Text="Report Type:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DdlReport" runat="server" >
                                    <asp:ListItem Value="">---Select Report Type---</asp:ListItem>
                                    <asp:ListItem Value="1">Transfer Challan and Customer Challan</asp:ListItem>
                                    <asp:ListItem Value="2">Only  Transfer Challan Details</asp:ListItem>
                                    <asp:ListItem Value="3">Only Customer Challan</asp:ListItem>
                                    <%--<asp:ListItem Value="4">Only  Transfer Challan Topsheet</asp:ListItem>
                                    <asp:ListItem Value="5">Only  Customer Challan Topsheet</asp:ListItem>--%>
                                </asp:DropDownList></td>
                            <td style="text-align:right;"><asp:Label ID="Label5"  runat="server" Text="Shipping Point:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DdlShippingPoint" runat="server" DataSourceID="odsShippingPoint" DataTextField="strName" DataValueField="intId"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsShippingPoint" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetShippingPointDataByUnitid" TypeName="SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters.tblShippingPointTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                             </td>
                            
                        </tr>
                       
                        
                        <tr>
                            <td colspan="6" style="text-align:right;">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" BackColor="#ffff99" OnClientClick = "ConfirmforShow()" Text="Show Report" CssClass="button" />
                                </td>
                        </tr>
                       
                    </table>
                    <table>
                        <%-- ===========================Sales Report View for Transfer Challan without topsheet ============================ --%>
                        <tr>
                            <td>
                                <asp:GridView ID="GvSalesReport" runat="server" ShowFooter="True" AutoGenerateColumns="False" DataSourceID="odsSalesReport" OnRowDataBound="GvSalesReport_RowDataBound" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                                    <Columns>
                                       <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="strchallan" HeaderText="Challan No" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dtechallandate" HeaderText="Date" SortExpression="dtechallandate" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strcustname" HeaderText="Customer" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <HeaderStyle Width="200px" />
                                        <ItemStyle HorizontalAlign="left" Width="200px" />
                                        </asp:BoundField>                                      
                                       
                                        <asp:BoundField DataField="strnarration" HeaderText="Narration" SortExpression="strnarration" ItemStyle-HorizontalAlign="Center" FooterText="Total : " >
                                        <FooterStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Right" />
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="left" Width="480px" />
                                        </asp:BoundField>
                                         <asp:TemplateField HeaderText="Pieces" SortExpression="pdqnt">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("pdqnt", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                                 <div style="text-align:right;"><asp:Label ID="lblTotal" runat="server" ForeColor="Red"></asp:Label></div>
                                                
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="90px"/>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsSalesReport" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUDTCLSalesData" TypeName="SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters.sprUDTCLSalesStausTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFormDate" Name="fromdate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="txtToDate" Name="todate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intunitid" PropertyName="SelectedValue" Type="Int32" />                                     
                                        <asp:ControlParameter ControlID="DdlReport" Name="rpttype" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlSalesOffice" Name="intsalesoffid" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlShippingPoint" Name="intshippingpointid" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>

                        <%-- ===========================Sales Report View for TopSheet============================ --%>

                        <tr>
                            <td>
                                <asp:GridView ID="GvSalesReportAnother" runat="server" ShowFooter="True" AutoGenerateColumns="False" DataSourceID="odsSalesReportanother"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                                    <Columns>
                                       
                                        <asp:BoundField DataField="strchallan" HeaderText="Challan No" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dtechallandate" HeaderText="Date" SortExpression="dtechallandate" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strcustname" HeaderText="Customer" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                        <HeaderStyle Width="200px" />
                                        <ItemStyle HorizontalAlign="left" Width="200px" />
                                        </asp:BoundField>                                      
                                       
                                        <asp:BoundField DataField="strnarration" HeaderText="Narration" SortExpression="strnarration" ItemStyle-HorizontalAlign="Center" FooterText="Total : "  >
                                        <FooterStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Right" />
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="left" Width="400px" />
                                        </asp:BoundField>
                                         <asp:TemplateField HeaderText="Pieces" SortExpression="pdqnt">
                                           
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("pdqnt", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                             <FooterTemplate>
                                                <asp:Label ID="lblTotal" runat="server" ForeColor="Red" CssClass="align"></asp:Label>
                                            </FooterTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="90px"/>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsSalesReportanother" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUDTCLSalesData" TypeName="SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters.sprUDTCLSalesStausTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFormDate" Name="fromdate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="txtToDate" Name="todate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intunitid" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlReport" Name="rpttype" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlSalesOffice" Name="intsalesoffid" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlShippingPoint" Name="intshippingpointid" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
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
