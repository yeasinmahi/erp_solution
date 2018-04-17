﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_MRReport.aspx.cs" Inherits="UI.Dairy.Milk_MRReport" %>
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

    <script>
        function MRDetailsReport(intccid, intmrrno, dtemrrdate) {
            window.open('Milk_MR_Details_Report.aspx?CCID=' + intccid + '&MRNO=' + intmrrno + '&MRDATE=' + dtemrrdate, 'sub', "scrollbars=yes,toolbar=0,height=480,width=690,top=50,left=50, resizable=no, title=Preview");
        }
    </script> 

    </head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
          
        <div class="tabs_container"> MILK MR REPORT <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlChillingCenter" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlChillingCenter_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 

            <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td> 
        </tr>
        <tr>
            <td colspan="4" style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>            
        </tr>

        </table>
    </div>

    <div id="divInventory">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server"></asp:Label></td></tr>
            
            <tr><td> 
            <asp:GridView ID="dgvMRReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvMRReport_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
             
            <asp:TemplateField HeaderText="Chilling Center Name" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="strChillingCenterName" >
            <ItemTemplate><asp:Label ID="lblCCName" runat="server" Width="150px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strChillingCenterName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
                             
            <asp:TemplateField HeaderText="MR Date" SortExpression="dteMRRReceivedDate"><ItemTemplate>            
            <asp:Label ID="lblMRDate" runat="server" Text='<%# Bind("dteMRRReceivedDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="MR No." Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="intMRRNo" >
            <ItemTemplate><asp:Label ID="lblMRNo" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intMRRNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="MR Qty" ItemStyle-HorizontalAlign="right" SortExpression="MRRQty" >
            <ItemTemplate><asp:Label ID="lblMRQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("MRRQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tmrqty %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="intMRRFatPercentage" HeaderText="MR Fat %" ItemStyle-HorizontalAlign="Center" SortExpression="intMRRFatPercentage">
            <ItemStyle HorizontalAlign="right" Width="40px"/></asp:BoundField>

            <asp:TemplateField HeaderText="Deduct Qty Amount" ItemStyle-HorizontalAlign="right" SortExpression="DeductAmount" >
            <ItemTemplate><asp:Label ID="lblDeductAmou" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("DeductAmount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tdeducqtyamo %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Deduct Fat% Amount" ItemStyle-HorizontalAlign="right" SortExpression="DeductFatPerAmount" >
            <ItemTemplate><asp:Label ID="lblDeductFatPAmou" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("DeductFatPerAmount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tdecucfatamo %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="MR Amount" ItemStyle-HorizontalAlign="right" SortExpression="MRRValue" >
            <ItemTemplate><asp:Label ID="lblMRAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("MRRValue"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tmramo %>' /></FooterTemplate></asp:TemplateField>
            
            <%--<asp:TemplateField HeaderText="Challan Date" Visible="true" ItemStyle-HorizontalAlign="left" SortExpression="dteChallanDate" >
            <ItemTemplate><asp:Label ID="lblChallanDate" runat="server" Width="55px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("dteChallanDate")) %>'></asp:Label></ItemTemplate></asp:TemplateField>--%>
            
            <asp:TemplateField HeaderText="Challan Date" SortExpression="dteChallanDate"><ItemTemplate>            
            <asp:Label ID="lblChallanDate" runat="server" Text='<%# Bind("dteChallanDate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Challan No." Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="strChallanNo" >
            <ItemTemplate><asp:Label ID="lblChallanNo" runat="server" Width="70px" DataFormatString="{0:0.00}" Text='<%# (""+Eval("strChallanNo")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Challan Qty." ItemStyle-HorizontalAlign="right" SortExpression="ChallanQty" >
            <ItemTemplate><asp:Label ID="lblChallanQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("ChallanQty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tchalanqty %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:BoundField DataField="intChallanFatPercent" HeaderText="Challan Fat %" ItemStyle-HorizontalAlign="Center" SortExpression="intChallanFatPercent">
            <ItemStyle HorizontalAlign="left" Width="40px"/></asp:BoundField>

            <asp:TemplateField HeaderText="Challan Amount" ItemStyle-HorizontalAlign="right" SortExpression="ChallanAmount" >
            <ItemTemplate><asp:Label ID="lblChallanAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("ChallanAmount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# tchalanamo %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="intCCID" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="intChillingCenterID" >
            <ItemTemplate><asp:Label ID="lblTripID" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("intChillingCenterID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details" >
            <ItemTemplate><asp:Button ID="btnActionDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intChillingCenterID") + "," +Eval("intMRRNo") + "," +Eval("dteMRRReceivedDate") %>' Text="Details" OnClick="btnDetails_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 

                <%--CommandArgument='<%#Eval("IdTemplate") + ";" +Eval("EntityId")%>'--%>

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
