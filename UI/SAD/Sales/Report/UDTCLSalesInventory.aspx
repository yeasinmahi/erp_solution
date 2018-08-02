<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UDTCLSalesInventory.aspx.cs" Inherits="UI.SAD.Sales.Report.UDTCLSalesInventory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.: Manual Attendance Insertion :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
        <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script src="../../Content/JS/datepickr.min.js"></script>
     <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    

    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script> 

    <script type="text/javascript">
       
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
               // return false;
            }
           
             else if (report == null || report=="") {
                alert('Insert Report Type');
               // return false;
            }
            
            //return true;
        }

    </script>
   
    </head>
<body>
    <form id="frmaclmanatt" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">--%>
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
        <div class="tabs_container" id="head"> UDTCL Sales Report :<hr /></div>

        <%-- =======Data Insert Table======= --%>
        <table border="0"; style="width:Auto"; id="insertForm">
        <tr class="tblrowodd">    
        <td style="text-align:right;">
        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="From Date:" ></asp:Label></td>
        <td>
        <asp:TextBox ID="txtFormDate" CssClass="txtBox" runat="server"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
        <img id="imgCal_1"  src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
        </td>
        <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl"  runat="server" Text="To Date:"></asp:Label></td>
        <td>
        <asp:TextBox ID="txtToDate" CssClass="txtBox" runat="server"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
        <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
        </td>
        </tr>

        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl"  runat="server" Text="Unit:"></asp:Label></td>
        <td><asp:DropDownList ID="ddlUnit" CssClass="dropdownList" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="GetData" TypeName="HR_DAL.Global.UnitTDSTableAdapters.SprGetUnitTableAdapter">
        <SelectParameters>
        <asp:SessionParameter Name="intUserID" SessionField="sesUserID" Type="Int32" />
        </SelectParameters>
        </asp:ObjectDataSource>
        </td> 
        <td colspan="3" style="text-align:right;">
        <asp:Button ID="btnShow" runat="server" Font-Size="12px" OnClick="btnShow_Click" BackColor="#ffff99" OnClientClick = "ConfirmforShow()" Text="Show Report" CssClass="button" />
        <asp:Button ID="btnDownloads" runat="server" CssClass="button" Font-Size="12px"  Text="Export" OnClick="btnDownloads_Click" />
        </td>
        </tr> 

        <tr class="tblrowodd">   
        
        
        </tr>   
        </table>
         <table>                      
                <tr>
                    <td>
                        <asp:GridView ID="dgvSales" runat="server" ShowFooter="True"  OnRowDataBound="GvSalesReport_RowDataBound"  AutoGenerateColumns="False"   BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                            <Columns>
                                <asp:TemplateField HeaderText="SL">
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" ItemStyle-HorizontalAlign="left" >
                                </asp:BoundField>
                                <asp:BoundField DataField="ChDate" DataFormatString="{0:yyyy/MM/dd}"   HeaderText="Challan Date" SortExpression="ChDate" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                </asp:BoundField>
                                <asp:BoundField DataField="Productname" HeaderText="Code" SortExpression="Code" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                </asp:BoundField>                                   
                                       
                                <asp:BoundField DataField="UOM" HeaderText="Narration" SortExpression="Narration" ItemStyle-HorizontalAlign="Center" FooterText="Total:">
                                </asp:BoundField>
                                      
                                <asp:TemplateField HeaderText="Pieces" SortExpression="numPieces">                                           
                                <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("numPieces", "{0:N2}") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <div style="text-align:right;"><asp:Label ID="lblquantity" runat="server" ForeColor="Red"></asp:Label></div>
                                                
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="right" Width="90px"/>
                                </asp:TemplateField>
                                      
                                                                      
                                       
                                <asp:TemplateField HeaderText="Amount" SortExpression="monTotalAmount">                                           
                                <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("monTotalAmount", "{0:N3}") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <div style="text-align:right;"><asp:Label ID="lblamount" runat="server" ForeColor="Red"></asp:Label></div>
                                                
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
                    </td>
                </tr>

            </table> 

        </div>
   <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
   <%-- </asp:UpdatePanel>--%>
    </form>
</body>
</html>