<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MaintenancePendingRequest.aspx.cs" Inherits="UI.Asset.MaintenanceServiceRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />

    <script src="../../Content/JS/datepickr.min.js"></script>
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <%--<link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />--%>
    <%--<link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />--%>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script>
        function Print() {
            document.getElementById("BtnPrint").style.display = "none";
            document.getElementById("BtnShow").style.display = "none";
            //document.getElementById("head").style.display = "none";
            document.getElementById("dtedate").style.display = "none";
            document.getElementById("msg").style.display = "none";
            window.print(); self.close();
        }
    </script>
    <style>
        .tblborder{
            border:1px solid black;
            border-collapse:collapse;
        }
        .btn{
            background-color:#3a9bfc;
            margin-left:5px;
            border-radius:5px;
            padding:5px;
            color:black;
            font-size:14px;
        }
    </style>
</head>
<body>
    <form id="frmaclmanatt" runat="server">
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

                <div class="leaveApplication_container">
                    <%--<div class="tabs_container" id="head" style="text-align:center;">Maintenance pending report for workshop:<hr /></div>--%>
                    <div style="background-color:white;width:100%;">
                    <table>
                        <tr style="text-align:center;">
                            <td colspan="4" style="width:712px;"><b>Maintenance Pending Report For Workshop:</b><hr /></td>
                        </tr>
                    </table>
                    <table style="background-color:white; border:2px solid #b5a8b1;">
                       
                        <tr id="dtedate" class="tblborder">
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="From Date:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtFormDate" CssClass="txtBox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="To Date:"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtToDate" CssClass="txtBox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
                        </tr>
                        <tr class="tblborder">
                             <td   style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Bold="true" Text="Request Service Station"></asp:Label></td>
                             <td style="text-align:left;" colspan="4" ><asp:DropDownList ID="ddlJobStation" Width="220" CssClass="ddList"  Font-Bold="true" AutoPostBack="true" runat="server"></asp:DropDownList></td> 
                            
                            
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:right"><asp:Button ID="BtnShow" CssClass="btn" runat="server" Text="Show Report" OnClick="BtnShow_Click"/><%--</td>--%>
                            <%--<td style="width:80px;">--%><asp:Button ID="BtnPrint" CssClass="btn" runat="server" Text="Print" OnClientClick="Print()"/></td>
                        </tr>
                        
                    </table>
                    <table style="background-color:white; width:100%">
                        <tr>
                            <td>
                                Maintenance Service Request <asp:Label ID="lbldate" runat="server" CssClass="lbl" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GVMaintenanceReport" runat="server" AutoGenerateColumns="False">

                                    <Columns>
                                        <asp:TemplateField HeaderText="SL.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:BoundField DataField="intMaintenanceNo" HeaderText="Job Code" SortExpression="intMaintenanceNo" />
                                        <asp:BoundField DataField="strNameOfAsset" HeaderText="Name Of Asset" ItemStyle-Width="100" SortExpression="strNameOfAsset" />
                                        <asp:BoundField DataField="strBilUnit" HeaderText="Unit" SortExpression="strBilUnit" />
                                        <asp:BoundField DataField="strJobStation" HeaderText="Job Station" SortExpression="strJobStation" />
                                        <asp:BoundField DataField="strAssetCode" HeaderText="Asset Code" SortExpression="strAssetCode" />
                                        <asp:BoundField DataField="strServiceName" HeaderText="Service Name" SortExpression="strServiceName" />
                                        <asp:BoundField DataField="strProblem" HeaderText="Problem" SortExpression="strProblem" />
                                        <asp:BoundField DataField="ServiceLocation" HeaderText="Service Location" SortExpression="ServiceLocation" />
                                        <asp:BoundField DataField="requestDate" ItemStyle-Width="75" HeaderText="Request Date" SortExpression="requestDate" DataFormatString="{0:yyyy-MM-dd}"/>
                                        <asp:BoundField DataField="monMaterial" HeaderText="Sprear Parts Cost" ItemStyle-HorizontalAlign="Right" SortExpression="monMaterial" />
                                        <asp:BoundField DataField="monService" HeaderText="Service Cost" ItemStyle-HorizontalAlign="Right" SortExpression="monService" />
                                        <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" ItemStyle-HorizontalAlign="Right" SortExpression="TotalCost" />
                                        <asp:BoundField DataField="VehicleCondition" HeaderText="Vehicle Condition" ItemStyle-HorizontalAlign="center" SortExpression="VehicleCondition" />
                                    </Columns>

                                </asp:GridView>
                                
                            </td>
                        </tr>
                    </table>
                        </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
