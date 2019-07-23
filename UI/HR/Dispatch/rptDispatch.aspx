<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDispatch.aspx.cs" Inherits="UI.HR.Dispatch.rptDispatch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Dispatch Register </title>
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

 <script type="text/javascript">
    function ViewDocList(Id) {        
        window.open('DispatchDocView.aspx?ID=' + Id, 'sub', "height=600, width=900, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");        
    }   
 </script>

</head>
<body>
    <form id="frmdispatch" runat="server">        
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
    
    <div class="leaveApplication_container"> 
    <table class="tbldecoration" style="width:auto; float:left;">    
    <tr class="tblheader"><td colspan="4"> DISPATCH REPORT </td></tr>
    <tr>
    <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
    <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
    <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
    <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
    <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
    <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
    </tr>
    
    <tr>
        <td colspan="4"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" Text="Show" OnClick="btnShow_Click"/></td>        
    </tr>
    </table> 
    </div>    
    <div>
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr><td> 
    <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>           
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
    <asp:TemplateField HeaderText="intID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intID" >
    <ItemTemplate><asp:Label ID="lblDPID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

    <asp:TemplateField HeaderText="Dispatched Number" ItemStyle-HorizontalAlign="left" SortExpression="strDispatchNo" >
    <ItemTemplate><asp:Label ID="lblDNumber" runat="server" Width="170px" Text='<%# (""+Eval("strDispatchNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
           
    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center" SortExpression="dteDate" >
    <ItemTemplate><asp:Label ID="lblDate" runat="server" Width="75px" Text='<%# (""+Eval("dteDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

    <asp:TemplateField HeaderText="To whom Dispatched" ItemStyle-HorizontalAlign="left" SortExpression="strNameAndAddress" >
    <ItemTemplate><asp:Label ID="lblFAddress" runat="server" Width="250px" Text='<%# (""+Eval("strNameAndAddress")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
           
    <asp:TemplateField HeaderText="Subjet" ItemStyle-HorizontalAlign="left" SortExpression="strSubject" >
    <ItemTemplate><asp:Label ID="lblSubjet" runat="server" Width="150px" Text='<%# (""+Eval("strSubject")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                   
    <asp:TemplateField HeaderText="Unit" ItemStyle-HorizontalAlign="left" SortExpression="strUnit" >
    <ItemTemplate><asp:Label ID="lblUnit" runat="server" Width="60px" Text='<%# (""+Eval("strUnit")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                   
    <asp:TemplateField HeaderText="Job Station Name" ItemStyle-HorizontalAlign="left" SortExpression="strJobStationName" >
    <ItemTemplate><asp:Label ID="lblJobStationName" runat="server" Width="160px" Text='<%# (""+Eval("strJobStationName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                    
    <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="left" SortExpression="strRemarks" >
    <ItemTemplate><asp:Label ID="lblstrRemarks" runat="server" Width="200px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strRemarks")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
           
    <asp:TemplateField HeaderText="Document Name" ItemStyle-HorizontalAlign="center" SortExpression="strDocName" >
    <ItemTemplate><asp:Button ID="btnDName" runat="server" class="HyperLinkButtonStyle" style="cursor:pointer;" 
    CommandName="docview" CommandArgument='<%# Eval("intID") %>' Text='<%# Eval("strDocName") %>' OnCommand="btnDslVew_Click"/></ItemTemplate>
    <ItemStyle HorizontalAlign="left" Width="280px"/></asp:TemplateField>
              
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