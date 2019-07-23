<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCashBookDITF.aspx.cs" Inherits="UI.AEFPS.frmCashBookDITF" %>
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
       <div style="font-size:18px"  class="tabs_container"><b> Cash Book</b><hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">

        <tr><td colspan="4">&nbsp;</td></tr> 
        <tr><td >Report Type :</td><td > 
        <asp:DropDownList ID="ddlReporttype" CssClass="ddList" runat="server">
        <asp:ListItem Value="1">Cash Book</asp:ListItem>
        <asp:ListItem Value="2">Shop Ledger</asp:ListItem>
        </asp:DropDownList>
        </td><td colspan="2" ></td></tr>
        <tr>
        <td style="text-align:right;">From Date</td>                
        <td><asp:TextBox ID="txtfdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtfdate"></cc1:CalendarExtender></td>                                

        <td style="text-align:right;"><asp:Label ID="lblQty" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="txttdate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="190px" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txttdate"></cc1:CalendarExtender></td>              
        </tr>
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblemployeesearch" runat="server" CssClass="lbl" Text="Whare House :"></asp:Label></td>                
        <td colspan="2"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" runat="server" Width="195px"></asp:DropDownList><asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
        
        </td><td><asp:Button ID="btnSave" runat="server" Font-Bold="true" Text="Show" class="myButton" OnClick="btnShow_Click" /></td> </tr>
        <tr><td style="text-align:right" colspan="4"></td></tr>             
        <tr><td colspan="4"><hr /></td></tr>             
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblWHName" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblHeading" runat="server"  CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
        <tr><td colspan="4" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblDate" runat="server"  CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
        <tr><td><asp:Label ID="lbl" Font-Bold="true" runat="server" Text="Opening Balance :"></asp:Label><asp:Label ID="lblops" runat="server" ></asp:Label></td>
            <td>&nbsp&nbsp&nbsp<asp:Label ID="Label1"  Font-Bold="true" runat="server" Text="Receive :"></asp:Label><asp:Label ID="lblR" runat="server" ></asp:Label></td>
            <td><asp:Label ID="Label2" runat="server"  Font-Bold="true" Text="Cost :"></asp:Label><asp:Label ID="lblCost" runat="server" ></asp:Label></td>
            <td> <asp:Label ID="Label4" runat="server"  Font-Bold="true" Text="Cash In Hand :"></asp:Label><asp:Label ID="lblCashinHand" runat="server" ></asp:Label></td>
        </tr>
      
        <tr><td style="text-align:right;" colspan="4">
        
        <asp:GridView ID="dgvRptTemp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
        BorderWidth="1px" CellPadding="5" ShowFooter="true"  OnRowDataBound="dgvRptTemp_RowDataBound" ForeColor="Black" GridLines="Vertical"   FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No" Visible="true"  ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
        <ItemTemplate>         
        <asp:Label ID="lblSLNO" runat="server" Width="50px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intid","{0:d}")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
   
        <asp:TemplateField HeaderText="Date"  Visible="true"  ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
        <ItemTemplate>         
        <asp:Label ID="lbldate" runat="server" Width="80px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dtedate","{0:d}")) %>'></asp:Label></ItemTemplate></asp:TemplateField>


        <asp:TemplateField HeaderText=" Code" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strQRCode" >
        <ItemTemplate><asp:Label ID="lblstrQRCode" runat="server" Width="90px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("code")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                             
        <asp:TemplateField HeaderText="Discribtion" SortExpression="intProductID">
        <ItemTemplate><asp:Label ID="lbldiscribtions" runat="server" Text='<%# Bind("discribtion") %>' Width="200px"></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lbldiscribtionID" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
               
        <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="right" SortExpression="MRRValue" >
        <ItemTemplate><asp:Label ID="lblDebitss" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("mondebit"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldmmonAmount" runat="server" DataFormatString="{0:0.00}" Text ='<%# Totaldebit %>' /></FooterTemplate></asp:TemplateField>
    
        
        <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="right" SortExpression="MRRValue" >
        <ItemTemplate><asp:Label ID="lblmoncreditss" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("moncredit"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldmmonAmount" runat="server" DataFormatString="{0:0.00}" Text ='<%# Totalcredit %>' /></FooterTemplate></asp:TemplateField>
          
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td>
        </tr>  
        <tr><td colspan="4">

        
        </td></tr>
       
        <tr><td colspan="4">

       
        </td></tr>
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
