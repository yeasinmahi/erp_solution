<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fpsDueReport.aspx.cs" Inherits="UI.AEFPS.fpsDueReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
   <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
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
    
   <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../Content/JS/datepickr.min.js"></script>

</head>
<body>
    <form id="frmSubledger" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
       <asp:HiddenField ID="hdnSalary" runat="server" /><asp:HiddenField ID="hdnMillage" runat="server" /><asp:HiddenField ID="hdnSaleAmount" runat="server" />
       <asp:HiddenField ID="hdnDTFare" runat="server" /><asp:HiddenField ID="hdnSingleMillage100KM" runat="server" /><asp:HiddenField ID="hdnSingleMillage100AboveKM" runat="server" />
       <asp:HiddenField ID="hdnSalesQty" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
       <asp:HiddenField ID="hdnDieselTotalTk" runat="server" /><asp:HiddenField ID="hdnCNGTotalTk" runat="server" />
       <asp:HiddenField ID="hdnDTFCount" runat="server" /> <asp:HiddenField ID="hdnDTFCountCash" runat="server" /> 
       <asp:HiddenField ID="hdnstockQty" runat="server" /> <asp:HiddenField ID="hdnQty" runat="server" />
        <asp:HiddenField ID="hdnDieselPerKMOutStation" runat="server" /><asp:HiddenField ID="hdnCNGPerKMOutStation" runat="server" />
       <div style="font-size:18px"  class="tabs_container"><b> EMPLOYEEDUE REPORT </b><hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">

        <tr><td colspan="4">&nbsp;</td></tr> 
       
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblInDate" runat="server" CssClass="lbl" Text="Wear House :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList>
            </td>                                

            <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtfdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfdate"></cc1:CalendarExtender></td>              
        </tr>
       
               
        <tr><td colspan="4"><hr /></td></tr>             
        <tr><td colspan="4"><hr /></td></tr> 
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblWHName" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblHeading" runat="server" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblDate" runat="server"  CssClass="lbl" Font-Size="16px"></asp:Label>    </td></tr>
        
          <tr>
          <td style="text-align:right;" colspan="4">
                
           <asp:Button ID="btnSave" runat="server" class="myButton" Text="Show" OnClick="btnSave_Click" />
           <asp:GridView ID="dgvRptTemp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5"  ForeColor="Black" GridLines="Vertical" ShowFooter="true"   FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
            <asp:TemplateField HeaderText="Enroll" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
            <ItemTemplate> <asp:Label ID="lbldate" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intWHEnrollNo")) %>'></asp:Label>
            </ItemTemplate></asp:TemplateField>


            <asp:TemplateField HeaderText="Employee Name" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
            <ItemTemplate><asp:Label ID="lblstrEmployeeName" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strEmployeeName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                             
            <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="Left"   SortExpression="intProductID">
            <ItemTemplate ><asp:Label ID="lblstrdesignation"  runat="server" Text='<%# Bind("strdesignation") %>' Width="200px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lbldiscribtionID" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Unit Name" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="mondebit" >
            <ItemTemplate><asp:Label ID="lblstrUnit" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strUnit")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
              <asp:TemplateField HeaderText="Depatrment Name" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="mondebit" >
            <ItemTemplate><asp:Label ID="lblstrDepatrment" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strDepatrment")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
         

            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="MRRValue" >
            <ItemTemplate><asp:Label ID="lblmonAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("Amount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldmmonAmount" runat="server" DataFormatString="{0:0.00}" Text ='<%# TotalAmounts %>' /></FooterTemplate></asp:TemplateField>
            
            

           </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>  
            <tr><td colspan="4"></td></tr>
            <tr style="background-color:lightgray">
             <td colspan="4"> </td>
            </tr>
            </tr> 
            
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
