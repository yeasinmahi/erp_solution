<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_MRR_ForExcel.aspx.cs" Inherits="UI.Dairy.Milk_MRR_ForExcel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<!DOCTYPE html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title>
    <%--<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>--%>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>

 
    </head>
<body>
    <form id="form1" runat="server">  
        
        
<script language="javascript" type="text/javascript">
    function ExportDivDataToExcel() {
        var html = $("#divExport").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $("input[id$='HdnValue']").val(html);
    }
 </script>
             
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
    <br /><br /><br /><br /><br /><br /><br /><div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server"/>
    <asp:HiddenField ID="HiddenUnit" runat="server"/>
          
        <div class="tabs_container"> SUPPLIER WISE MILK MR REPORT FOR EXCEL <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 

            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtTo" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td> 
        </tr>
        <tr>
            <%--<td colspan="2" style="text-align:left;"><asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" /></td>--%>
            <td colspan="2" style="text-align:left;"><asp:Button ID="Button1" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" onclick="Button1_Click" Text="Export to Excel" OnClientClick="ExportDivDataToExcel()"/></td>
            <td colspan="2" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>            
        </tr>

        <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
        <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
        </table>
    </div>

    <%--<div id="divExport">           
        <table  class="tbldecoration" style="width:auto; float:left;">  --%>
        <div id="divExport">    
        <table  class="tbldecoration" style="width:auto; float:left;">
            <asp:HiddenField ID="hdnData" runat="server"/>
        <%--<table class="tbldecoration" style="width:auto; float:left;">--%>   
        

            <%--===========Top Sheet Report============--%>
            
            <tr><td> 
            <asp:GridView ID="dgvMRReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <%--<asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>--%>              
             
            <asp:TemplateField HeaderText="Partner Code" ItemStyle-HorizontalAlign="center" SortExpression="PartnerCode" >
            <ItemTemplate><asp:Label ID="lblPartnerCode" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("PartnerCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="From Date" ItemStyle-HorizontalAlign="center" SortExpression="dteFrom" >
            <ItemTemplate><asp:Label ID="lblMRRReceivedDate"  runat="server" Width="70px" Text='<%# (""+Eval("dteFrom")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="To Date" ItemStyle-HorizontalAlign="center" SortExpression="dteTo" >
            <ItemTemplate><asp:Label ID="lblMRRReceivedDateTo"  runat="server" Width="70px" Text='<%# (""+Eval("dteTo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Period Covered" SortExpression="dteMRRReceivedDate"><ItemTemplate>            
            <asp:Label ID="lblMRRReceivedDate" runat="server" Text='<%# Bind("dteMRRReceivedDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>--%>

            <%--<asp:BoundField DataField="dteMRRReceivedDate" HeaderText="Period Covered" ItemStyle-HorizontalAlign="Center" SortExpression="dteMRRReceivedDate">
            <ItemStyle HorizontalAlign="center" Width="60px"/></asp:BoundField>--%>
            
            <asp:TemplateField HeaderText="Farmer Code" ItemStyle-HorizontalAlign="left" SortExpression="strSupplierCode" >
            <ItemTemplate><asp:Label ID="lblSupplierCode" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strSupplierCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                         
            <asp:TemplateField HeaderText="Farmer Name" ItemStyle-HorizontalAlign="left" SortExpression="SupplierName" >
            <ItemTemplate><asp:Label ID="lblSupplierName" runat="server" Width="170px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("SupplierName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="MCC Code" ItemStyle-HorizontalAlign="center" SortExpression="intMCCCode" >
            <ItemTemplate><asp:Label ID="lblMCCCode" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intMCCCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Volume" ItemStyle-HorizontalAlign="right" SortExpression="intMRRQty" >
            <ItemTemplate><asp:Label ID="lblMRRQty" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intMRRQty")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Average Fat Content" ItemStyle-HorizontalAlign="right" SortExpression="intMRRFatPercentage" >
            <ItemTemplate><asp:Label ID="lblMRRFatPercentage" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intMRRFatPercentage")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
             
            <asp:TemplateField HeaderText="Payment" ItemStyle-HorizontalAlign="right" SortExpression="monMRRValue" >
            <ItemTemplate><asp:Label ID="lblMRRValue" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("monMRRValue")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
             
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>        

         </table>     
      </div>
    <asp:HiddenField ID="HdnValue" runat="server" />

    <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
   </asp:UpdatePanel>--%>
    </form>
</body>
</html>