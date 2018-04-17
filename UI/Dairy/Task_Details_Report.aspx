<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Task_Details_Report.aspx.cs" Inherits="UI.Dairy.Task_Details_Report" %>
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
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }

</script>

<script>
    function DocListView(reqsid) {
        window.open('TaskDocView.aspx?intID=' + reqsid, 'sub', "height=650, width=930, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");
        //window.open('Task_DocDownAndView.aspx?intID=' + reqsid, 'sub', "height=650, width=930, scrollbars=yes, left=150, top=50, resizable=no, title=Preview");        
    }
</script>

<%--<script> function CloseWindow() {
     window.close();
 } </script>--%>

<%--<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>--%>
                  
</head>
<body>
    <form id="frmselfresign" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
   <%-- <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container" runat="server" id="UpdateReportDiv"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /> <asp:HiddenField ID="hdnFTP" runat="server" />
    <asp:HiddenField ID="hdnCmComm" runat="server" />
          
    <div class="tabs_container"> TASK DETAILS REPORT <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">

            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvReport_RowDataBound"> 
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="20px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                     
            <asp:TemplateField HeaderText="intDetailsID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intDetailsID" >
            <ItemTemplate><asp:Label ID="lblDetailsID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intDetailsID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="dteDate" HeaderText="Date & Time" ItemStyle-HorizontalAlign="Center" SortExpression="dteDate">
            <ItemStyle HorizontalAlign="center" Width="140px"/></asp:BoundField>

            <asp:BoundField DataField="intComPer" HeaderText="% Com" ItemStyle-HorizontalAlign="Center" SortExpression="intComPer">
            <ItemStyle HorizontalAlign="center" Width="50px"/></asp:BoundField>

            <asp:BoundField DataField="strStatus" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="strStatus">
            <ItemStyle HorizontalAlign="center" Width="80px"/></asp:BoundField>

            <asp:BoundField DataField="strDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" SortExpression="strDescription">
            <ItemStyle HorizontalAlign="left" Width="400px"/></asp:BoundField>
                
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Document View" >
            <ItemTemplate><asp:Button ID="btnDocVew" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intDetailsID") %>' Text="Document View" OnClick="btnDocVew_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>


        </table>
    </div>

    <div class="leaveApplication_container" runat="server" id="WorkPlanDiv">
            <table class="tbldecoration" style="width:auto; float:left;">
            <tr><td colspan="6" style="font-weight:bold; font-size:13px; color:black;">WORK PLAN<hr /></td></tr>

            <tr><td colspan="6"> 
                <asp:GridView ID="dgvWorkPlan" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                <%--<asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>--%>              
                    
                <asp:TemplateField HeaderText="Objectives (What do you want to accomplish?)" SortExpression="strObjective"><ItemTemplate>            
                <asp:Label ID="lblObjective" runat="server" Text='<%# Bind("strObjective") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Activities (How are you going to accomplish the objective?)" SortExpression="strActivities"><ItemTemplate>            
                <asp:Label ID="lblActivities" runat="server" Text='<%# Bind("strActivities") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Who (Who is responsible for the activities?)" SortExpression="strWho"><ItemTemplate>            
                <asp:Label ID="lblWho" runat="server" Text='<%# Bind("strWho") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="When (When will the activity begin & end?)" SortExpression="strWhen"><ItemTemplate>            
                <asp:Label ID="lblWhen" runat="server" Text='<%# Bind("strWhen") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Outcomes (What are the desired results?)" SortExpression="strOutcomes"><ItemTemplate>            
                <asp:Label ID="lblOutcomes" runat="server" Text='<%# Bind("strOutcomes") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Evaluation (How are you going to measure the outcomes?)" SortExpression="strEvaluation"><ItemTemplate>            
                <asp:Label ID="lblEvaluation" runat="server" Text='<%# Bind("strEvaluation") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Status & Notes" SortExpression="strNotes"><ItemTemplate>            
                <asp:Label ID="lblNotes" runat="server" Text='<%# Bind("strNotes") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="115px"/></asp:TemplateField>

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
