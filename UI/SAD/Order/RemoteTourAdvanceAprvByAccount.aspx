<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTourAdvanceAprvByAccount.aspx.cs" Inherits="UI.SAD.Order.RemoteTourAdvanceAprvByAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html> <head id="Head1" runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

        <script>
            function Registration(url) {
                newwindow = window.open('RemoteTADATourAdvanceApproveAccountDetaills.aspx', 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
                if (window.focus) { newwindow.focus() }
            }
        </script>


</head>
<body>
    <form id="frmapp" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>

         <div class="leaveApplication_container"> <div class="tabs_container"> Advance TA DA Information : <asp:HiddenField ID="hdnuserid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" /><hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
       
        <tr><td style="text-align:right;" colspan="4"><asp:Button ID="btnShow" runat="server" Text="Show" Font-Bold="true" OnClick="btnShow_Click"></asp:Button></td></tr>

        <tr class=""><td style="text-align:justify;" colspan="4">
        <asp:GridView ID="dgvlistTADA" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="false"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
     
    <%-- intidDet,strEmplNameDet, intEnrolDet,strMoveSportDet,strPurpouseDet,dteTourStartdateDet,dteTourEndDateDet,intTotaldayDet,decAdvAmountDet, decApproveAmountDet,strJobTpeDet,strRemarksDet--%>



             <asp:BoundField DataField="intidDet" HeaderText="intID" ItemStyle-HorizontalAlign="Center" SortExpression="intidDet">
        <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:BoundField> 
        <asp:BoundField DataField="strEmplNameDet" HeaderText="Name" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:BoundField>
        <asp:BoundField DataField="intEnrolDet" HeaderText="Enrol" ItemStyle-HorizontalAlign="Center" SortExpression="Section">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
        <asp:BoundField DataField="intTotaldayDet" HeaderText="TotalDay" ItemStyle-HorizontalAlign="Center" SortExpression="WHouse">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
        <asp:BoundField DataField="decAdvAmountDet" HeaderText="Advance Amount" ItemStyle-HorizontalAlign="Center" SortExpression="Department">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>

        <asp:BoundField DataField="decApproveAmountDet" HeaderText="Aprv by Supervisor" ItemStyle-HorizontalAlign="Center" SortExpression="decApproveAmountDet">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
                

        <asp:TemplateField HeaderText="Det.">
                     <ItemTemplate>
                     <asp:Button ID="Complete" runat="server" Text="Deaills" class="button" CommandName="complete" OnClick="Complete_Click"  CommandArgument='<%# Eval("intidDet") %>' /></ItemTemplate>
                     </asp:TemplateField>  

                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        </table>
     </div>

     


 <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>


