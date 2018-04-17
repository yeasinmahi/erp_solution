<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDispatchReportForExcel.aspx.cs" Inherits="UI.HR.Dispatch.rptDispatchReportForExcel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
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

    <script language="javascript" type="text/javascript">
    function ExportDivDataToExcel() {
        var html = $("#divExport").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $("input[id$='HdnValue']").val(html);
    }
 </script> 
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
    <form id="frmcafr" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    <%--<br /><br /><br /><br /><br /><br /><br />--%>
    <asp:HiddenField ID="hdnEnroll" runat="server" />
        
        <table>
        <tr><td>
            <div class="leaveApplication_container"> <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnDispatchID" runat="server" /> 
            <div class="tabs_container"> DISPATCH REPORT FOR DISPATCH DEPT <hr /></div>
            <table class="tbldecoration" style="width:auto; float:left;">
            <tr class="tblrowodd">
                <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>
                <td colspan="2" style="text-align:left; width:20px;"></td>
                <td colspan="2" style="text-align:right;"><asp:Button ID="btnExport" runat="server" CssClass="nextclick" ForeColor="Black" Text="Export To Excel" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()"/></td>                   
            </tr>
            </table>
            </div>  
        </td></tr>
        <tr><td>         
            <div id="divExport">
                <table>
                    <tr><td  style="text-align:justify;">List For Dispatch :<hr />
                    <asp:GridView ID="dgvReportForExcel" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5"               
                    Font-Size="10px"><AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                    <asp:TemplateField HeaderText="intDispatchID" SortExpression="intDispatchID" Visible="false">
                    <ItemTemplate><asp:Label ID="lblDispatchID" runat="server" Text='<%# (""+Eval("intDispatchID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
       
                    <asp:TemplateField HeaderText="Date" SortExpression="CreateDate">
                    <ItemTemplate><asp:Label ID="lblDate" runat="server" Width="70px" Text='<%# Bind("CreateDate") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="70px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Tracking No" SortExpression="strDispatchCode">
                    <ItemTemplate><asp:Label ID="lblDispatchCode" runat="server" Text='<%# Bind("strDispatchCode") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Tracking No" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strTaskTitle" HeaderStyle-Height="30px" HeaderStyle-VerticalAlign="Top" HeaderStyle-Wrap="true">
                    <HeaderTemplate>
                    <asp:Label ID="lblAssignBy" runat="server" CssClass="lbl" Text="Tracking No"></asp:Label>
                    <asp:TextBox ID="TxtServiceConfg" ToolTip="Search Task Tile" runat="server"  width="150" TextMode="MultiLine"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvReport')"></asp:TextBox></HeaderTemplate>
                    <ItemTemplate><asp:Label ID="lblDispatchCode" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDispatchCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
            
                    <asp:TemplateField HeaderText="Sender" SortExpression="Sender">
                    <ItemTemplate><asp:Label ID="lblSender" runat="server" Text='<%# Bind("Sender") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Sender Address" SortExpression="strStationAddress">
                    <ItemTemplate><asp:Label ID="lblSenderAddress" runat="server" Text='<%# Bind("strStationAddress") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Receiver" SortExpression="strReceiver">
                    <ItemTemplate><asp:Label ID="lblReceiver" runat="server" Text='<%# Bind("strReceiver") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Receiver Address" SortExpression="strAddress">
                    <ItemTemplate><asp:Label ID="lblReceiverAddress" runat="server" Text='<%# Bind("strAddress") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bearer" SortExpression="strBearer">
                    <ItemTemplate><asp:Label ID="lblBearer" runat="server" Text='<%# Bind("strBearer") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Vehicle No" SortExpression="strVehicleNo">
                    <ItemTemplate><asp:Label ID="lblVehicleNo" runat="server" Text='<%# Bind("strVehicleNo") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Bearar Contact No." SortExpression="strContactNo">
                    <ItemTemplate><asp:Label ID="lblDispStatus" runat="server" Text='<%# Bind("strContactNo") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="120px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Receive By Dispatch Dept." SortExpression="ApproveStatus">
                    <ItemTemplate><asp:Label ID="lblAppStatus" runat="server" Text='<%# Bind("ApproveStatus") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>
                        
                    <%--<asp:TemplateField HeaderText="Receive By Owner" SortExpression="OwnerReceiveStatus">
                    <ItemTemplate><asp:Label ID="lblRecStatus" runat="server" Text='<%# Bind("OwnerReceiveStatus") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>--%>
            
                    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView></td>
                    </tr>
                </table>    
                <asp:HiddenField ID="HdnValue" runat="server" />    
            </div>
    </td></tr>
    </table>

    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>