<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionView.aspx.cs" Inherits="UI.Inventory.RequisitionView" %>
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
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
   
    <script type="text/javascript">
        function ConfirmforShow() {
            var fdate = document.getElementById("txtFormDate").value;
            var tdate = document.getElementById("txtToDate").value;
            if (fdate == "" || fdate == null) {
                alert("Insert From Date");
                return false;
            }
            else if (tdate == null || tdate == "") {
                alert("Insert To Date");
                return false;
            }
            else {
                return true;
            }
        }
        function Viewdetails(id) {
    window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
        <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee> </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
                <div class="tabs_container">Requisition Summary :<hr /></div>
                <table border="0"; style="width:Auto"; id="insertForm">
                    <tr><td><asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" /></td><asp:HiddenField ID="hdnEnroll" runat="server"/>        
    </tr>
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Ware House : "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
                        <td><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" DataSourceID="odswh" DataTextField="WH" DataValueField="intWHID" OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
                        <asp:ObjectDataSource ID="odswh" runat="server" SelectMethod="GetWarehouseList" TypeName="HR_BLL.Global.DaysOfWeek">
                        <SelectParameters><asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" /><asp:ControlParameter ControlID="hdntype" Name="type" PropertyName="Value" Type="Int32" />
                        </SelectParameters></asp:ObjectDataSource><asp:HiddenField ID="hdnwh" runat="server"/>
                        </td>
                        <td style="text-align: right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="From Date:"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtFormDate" CssClass="txtBox" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFormDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_1" ID="CalendarExtender1" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                            <img id="imgCal_1" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                        </td>
                        <td style="text-align: right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="To Date:"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtToDate" CssClass="txtBox" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtToDate" Format="yyyy/MM/dd" PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true"></cc1:CalendarExtender>
                            <img id="imgCal_2" src="../../../Content/images/img/calbtn.gif" style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                        </td>
                        <td>
                            <asp:Button ID="btnShow" runat="server" Font-Size="14px" OnClick="btnShow_Click" BackColor="Silver" OnClientClick = "return ConfirmforShow()" Text="Show Report" Font-Bold="True" ForeColor="White" Height="21px"/>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="GvList" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Requisition Code" SortExpression="strCode">                                    
                                        <ItemTemplate>
                                            <asp:Label ID="code" runat="server" Text='<%# Bind("strCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="170px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="strEmployeeName" HeaderText="Requester Name" ItemStyle-HorizontalAlign="Center" SortExpression="strEmployeeName">
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dteReqDate" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteReqDate" DataFormatString="{0:yyyy-MM-dd}">
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDetails" runat="server" class="nextclick" Style="cursor: pointer; font-size: 12px;" CommandArgument='<%# Eval("intReqID") %>' Text="Details" OnClick="Dtls_Click" CommandName="GV" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </td>
                    </tr>
                </table>

<%--=========================================End My Code From Here=================================================--%>
               

        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
