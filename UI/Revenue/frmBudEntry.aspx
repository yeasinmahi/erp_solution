<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBudEntry.aspx.cs" Inherits="UI.Revenue.frmBudEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
     <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
   
   
</head>
<body>
    <form id="frmCreditnote" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnCustid" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnEnroll" runat="server" /> <asp:HiddenField ID="hdnitemid" runat="server" /> <asp:HiddenField ID="hdnCustAddress" runat="server" />
    <div class="tabs_container"> </div>
    <table>
     <tr><td colspan="2" style="text-align:center; padding: 0px 0px 20px 0px;" class="auto-style1"><asp:Label ID="lblCompany" runat="server" CssClass="lbl" Font-Size="20px"></asp:Label></td></tr>
     <tr><td colspan="2" style="text-align:center; padding: 0px 0px 20px 0px;" class="auto-style1"><asp:Label ID="lblHeading" runat="server" Text="Inventory Summary Report" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
     <tr><td style="text-align:left;">WH Name:</td> <td style="text-align:left;"> <asp:DropDownList ID="ddlWh"  CssClass="ddList" runat="server" AutoPostBack="True"></asp:DropDownList>  </td>  </tr>
     <tr><td>Report Type :</td><td class="auto-style1"><asp:DropDownList ID="ddlRptType"  CssClass="ddList" runat="server" AutoPostBack="True">
         <asp:ListItem Value="0">ALL</asp:ListItem>
         <asp:ListItem Value="1">Local</asp:ListItem>
         <asp:ListItem Value="2">Import</asp:ListItem>
         </asp:DropDownList></td></tr>
     <tr><td>From Date :</td><td><asp:TextBox ID="txtFrom" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
         <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td></tr>
     <tr><td>From Date :</td><td><asp:TextBox ID="txtTo" placeholder="Click for date selection" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
         <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td></tr>
     <tr><td>&nbsp;</td><td style="text-align:right"><asp:Button ID="btnShow" Text="Show" runat="server" OnClick="btnShow_Click" /></td></tr>
     <tr><td colspan="2"> 
         <asp:GridView ID="dgvRpt"  runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="false">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="Item ID"  SortExpression="Productid"><ItemTemplate>
        <asp:Label ID="lblintItem" runat="server"  Text='<%# Bind("intItem") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
        </FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Item Name"  SortExpression="Productid"><ItemTemplate>
        <asp:Label ID="lblstrMaterialName" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="70px"/><FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" Width="100px"  runat="server" Text="Grand-Total :" /></div>
        </FooterTemplate></asp:TemplateField>
         
      
        <asp:TemplateField HeaderText="UoM" SortExpression="monOpenValue"><ItemTemplate>
        <asp:Label ID="lblstrUoM"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("strUoM","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="MRR No" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblintMRRID"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("intMRRID","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="MRR Date" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lbldteMRRDate"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("dteMRRDate","{0:d}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
         <asp:TemplateField HeaderText="MRR Qty" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblMRRQty"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("MRRQty","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Present Stock" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblmonPresentStock"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("monPresentStock","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>
      
        <asp:TemplateField HeaderText="Stock Value" SortExpression="Quantity"><ItemTemplate>
        <asp:Label ID="lblmonPresentValue"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("monPresentValue","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Expairy Date" SortExpression="ExpairyDate"><ItemTemplate>
        <asp:Label ID="lblExpairyDate"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("ExpairyDate","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="NO Of Days" SortExpression="ExpairyDate"><ItemTemplate>
        <asp:Label ID="lblDaycount"  runat="server" Width="60px" TextMode="Number" Text='<%# Bind("Daycount","{0:n0}") %>' AutoPostBack="false"    ></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="60px"/></asp:TemplateField>


        </Columns>
        <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

         </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
