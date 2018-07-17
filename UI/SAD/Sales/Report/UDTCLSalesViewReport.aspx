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
            //alert("ok");
            var fromdate = document.getElementById('txtFormDate').value;
            var todate = document.getElementById('txtToDate').value;
            if (fromdate == null) {
                alert('Insert From Date');
            }
            else if (todate == null) {
                alert('Insert To Date');
            }
        }
    </script>
    <style>
        .divHeader{
            background-color: #45546d;
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
                <div>
                    <div class="divHeader">UDTCL Sales View Report</div>
                    <table style="width: 700px;  outline-color: blue;table-layout: auto; vertical-align: top; background-color: #DDD;" class="tblRowOdd">
                        <tr >
                           <td style="text-align:right;">
                                <asp:Label ID="Label1" runat="server" Text="Issue Date:" CssClass="lbl"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtFormDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_1"  src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                            <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Expire Date:"></asp:Label></td>
                            <td>
                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                    <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                                </td>
                          
                        </tr>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="Unit:"></asp:Label></td>
                            <td><asp:DropDownList ID="ddlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList>

                                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetData" TypeName="HR_DAL.Global.UnitTDSTableAdapters.SprGetUnitTableAdapter">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="intUserID" SessionField="sesUserID" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                            </td>
                            <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Sales Office:"></asp:Label></td>
                            <td><asp:DropDownList ID="DdlSalesOffice" runat="server" autoPostback="True"  CssClass="dropdownList" DataSourceID="odsSalesOffice" DataTextField="strName" DataValueField="intId"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsSalesOffice" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSalesOfficeByUnitId" TypeName="HR_DAL.TourPlan.CustomerBankGauranteeTableAdapters.TblSalesOfficeTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intUnitId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                            
                        </tr>
                         <tr>
                             <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Customer Name:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DdlCustomer" runat="server" >
                                    <asp:ListItem Value="">---Select Customer---</asp:ListItem>
                                    <asp:ListItem Value="0">Transfer Challan</asp:ListItem>
                                    <asp:ListItem Value="1">Customer</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Shipping Point:"></asp:Label></td>
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
                            <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Report Type:"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="DdlReport" runat="server" >
                                    <asp:ListItem Value="">---Select Report Type---</asp:ListItem>
                                    <asp:ListItem Value="1">Transfer Challan and Customer Challan</asp:ListItem>
                                    <asp:ListItem Value="2">Only  Transfer Challan Details</asp:ListItem>
                                    <asp:ListItem Value="3">Only Customer Challan</asp:ListItem>
                                    <asp:ListItem Value="4">Only  Transfer Challan Topsheet</asp:ListItem>
                                    <asp:ListItem Value="5">Only  Customer Challan Topsheet</asp:ListItem>
                                </asp:DropDownList></td>
                             <td style="text-align:right;">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td colspan="6" style="text-align:right;">
                                <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" BackColor="#ffff99" OnClientClick = "ConfirmforShow()" Text="Show Report" CssClass="button" />
                                </td>
                        </tr>
                       
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="GvSalesReport" runat="server" AutoGenerateColumns="False" DataSourceID="odsSalesReport">
                                    <Columns>
                                        <asp:BoundField DataField="strchallan" HeaderText="Challan Name" SortExpression="strchallan" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="pdqnt" HeaderText="Quantity" SortExpression="pdqnt" ItemStyle-HorizontalAlign="Center"/>
                                        <%--<asp:BoundField DataField="pdprice" HeaderText="Price" SortExpression="pdprice" />--%>
                                        <asp:BoundField DataField="strcustname" HeaderText="Customer Name" SortExpression="strcustname" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px"/>
                                        <asp:BoundField DataField="strProductname" HeaderText="Product Name" SortExpression="strProductname" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="strSalesoffice" HeaderText="Sales office Name" SortExpression="strSalesoffice" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="strPoint" HeaderText="Point Name" SortExpression="strPoint" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="intcustid" HeaderText="Customer Id" SortExpression="intcustid" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="intitmid" HeaderText="Item Id" SortExpression="intitmid" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="intsalesoffid" HeaderText="Sales Office Id" SortExpression="intsalesoffid" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="intshippingpointid" HeaderText="Shipping PointId" SortExpression="intshippingpointid" ItemStyle-HorizontalAlign="Center"/>
                                        <asp:BoundField DataField="dtechallandate" HeaderText="Challan Date" SortExpression="dtechallandate" DataFormatString="{0:yyyy/MM/dd}" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px"/>
                                    </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsSalesReport" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUDTCLSalesData" TypeName="SAD_DAL.Sales.Report.UDTCLSalesTDSTableAdapters.sprUDTCLSalesStausTableAdapter">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtFormDate" Name="fromdate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="txtToDate" Name="todate" PropertyName="Text" Type="DateTime" />
                                        <asp:ControlParameter ControlID="ddlUnit" Name="intunitid" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:ControlParameter ControlID="DdlCustomer" Name="intcustid" PropertyName="SelectedValue" Type="Int32" />
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
