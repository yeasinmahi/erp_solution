<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmItemDiscountSetup.aspx.cs" Inherits="UI.SAD.Item.frmItemDiscountSetup" %>
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
</head>
<body>
    <form id="frmItemPromotion" runat="server">
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
       <div class="tabs_container">Sales Item Discount Setup <hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td>Discount Product Type </td>
            <td colspan="5"><asp:DropDownList ID="ddlGroupOrProduct" runat="server" OnSelectedIndexChanged="ddlGroupProduct_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="1">By Product</asp:ListItem>
                <asp:ListItem Value="2">By Group</asp:ListItem>
                </asp:DropDownList></td>
        </tr>   
            
        <tr class="tblrowodd">           
            <td style="text-align:left;">Discount Name:</td>
            <td style="text-align:left;"><asp:TextBox ID="txtPromotionName" runat="server" AutoPostBack="true" CssClass="txtBox" MaxLength="10"></asp:TextBox></td>
            <td style='text-align: left; width:120px;'>Discount Group</td>
            <td colspan="2" style='text-align: left;'> <asp:DropDownList ID="ddlDGroup" CssClass="ddllist" runat="server" OnSelectedIndexChanged="ddlPGroup_SelectedIndexChanged">
            <asp:ListItem Value="2">By Office</asp:ListItem>
            <asp:ListItem Value="1">Single Customer</asp:ListItem>

            <asp:ListItem Value="3">National</asp:ListItem>
            </asp:DropDownList></td>              
        </tr>    
        <tr><td><asp:Label ID="lblproductGroup" runat="server"></asp:Label> </td>
            <td><asp:TextBox ID="txtSalesItem" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSalesItem"
            ServiceMethod="GetProductList" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>

            <asp:DropDownList ID="ddlPGroupList" runat="server" ></asp:DropDownList>
            </td>
            <td>Sales Office Name</td>
            <td colspan="2"> <asp:DropDownList ID="ddloffice" runat="server" CssClass="ddllist"> </asp:DropDownList></td>            
        </tr> 
        <tr><td>Sales :UOM Name</td>
            <td> <asp:DropDownList ID="ddlUom" runat="server" CssClass="ddllist"></asp:DropDownList></td>
            <td>Customer Name&nbsp; </td>
            <td colspan="2"><asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtCustomer"
            ServiceMethod="CustomerSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
        </tr> 
        <tr><td>Sales Qty</td>
            <td><asp:TextBox ID="txtSalesQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>From Date</td> 
            <td colspan="2"><asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr>
        <tr><td>Discount Amount</td>
            <td><asp:TextBox ID="txtDiscountAmount" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
            <td>To Date &nbsp;&nbsp;&nbsp; </td>
            <td colspan="2"><asp:TextBox ID="txtTo" Enabled="false"  runat="server" CssClass="txtbox"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
            PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
             width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr> 
      
        
         <tr><td>Adjustment Type :</td>
             <td> <asp:DropDownList ID="ddlAdjustmenttype" CssClass="ddllist" runat="server">
            <asp:ListItem Value="1">Discount</asp:ListItem>
            <asp:ListItem Value="2">Transport</asp:ListItem>           
                 <asp:ListItem Value="3">SRSubsidiary</asp:ListItem>
            </asp:DropDownList></td><td>Calculation Type</td><td><asp:DropDownList ID="ddlcalcuationtype" runat="server">
             <asp:ListItem Value="1">Qty Base</asp:ListItem>
             <asp:ListItem Value="2">Slab Discount</asp:ListItem>
             </asp:DropDownList> </td>
             <td style="text-align:right" ><asp:Button ID="btnSave" Font-Bold="true" runat="server" Text="Save" OnClick="btnSave_Click" style="height: 26px" /></td></tr>
         <tr><td>Group Offcer</td>

             <td></td>

         </tr>
            <tr><td colspan="6"><hr /></td></tr>
        <tr><td>Report Tyep</td>

           <td><asp:Label ID="lblnaes" runat="server"></asp:Label></td>


            <td><asp:DropDownList ID="ddlReporType" CssClass="ddllist" runat="server">
            <asp:ListItem Value="1">Active</asp:ListItem>
            <asp:ListItem Value="2">In-Active</asp:ListItem>           
            </asp:DropDownList> </td>
            <td style="text-align:right">Report By</td>
            <td style="text-align:left"><asp:DropDownList ID="ddlReportBy" CssClass="ddllist" runat="server">
            <asp:ListItem Value="3">National</asp:ListItem>
            <asp:ListItem Value="1">Customer Wise</asp:ListItem>          
                <asp:ListItem Value="2">By Office</asp:ListItem>
            </asp:DropDownList></td>
            
        </tr> 
            <tr>
            <td>Cancel Type</td>
            <td><asp:DropDownList ID="ddlCancelType" CssClass="ddllist" runat="server">
            <asp:ListItem Value="3">National</asp:ListItem>
                <asp:ListItem Value="1">Single Customer</asp:ListItem>
            <asp:ListItem Value="2">Office</asp:ListItem>          
            </asp:DropDownList></td>
            <td colspan="3" style="text-align:left">

            &nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancel" runat="server" Font-Bold="true" OnClick="btnCancel_Click" Text="Cancel" />
                           
            &nbsp; &nbsp; &nbsp; <asp:Button ID="btnReport" runat="server" Font-Bold="true" OnClick="btnReport_Click" Text="Report" />
            </td>
        </tr>                      
        <tr><td colspan="5"><hr />
            
            
            </td></tr>          
        </table>
        <table><tr><td><asp:GridView ID="dgvPromotionReport" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns> 
                 
            <asp:TemplateField HeaderText="Batch Code" SortExpression="Custid"><ItemTemplate><asp:Label ID="lblstrBatchCode" runat="server" Text='<%# Bind("strBatchCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="70px"/>
            </asp:TemplateField>                           
            <asp:BoundField DataField="strProductName" HeaderText="Product Name" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strSalesuom" HeaderText="Sales uom" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="numSalesQuentity" HeaderText="Sales Quentity" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="strProductName1" HeaderText="Promotion Product Name" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="strUOM" HeaderText="Promotion UOM" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="numPromQuentity" HeaderText="Prom Quentity" ReadOnly="True" SortExpression="strName"/>             
             <asp:BoundField DataField="dteStartTime" HeaderText="Start Date" ReadOnly="True" SortExpression="strName"/>             
           <asp:BoundField DataField="dteEndTime" HeaderText="End Date" ReadOnly="True" SortExpression="strName"/>             
           <asp:BoundField DataField="dteInsertionTime" HeaderText="Insert Date" ReadOnly="True" SortExpression="strName"/>             
              
         <%--   <asp:TemplateField HeaderText="Pending Qty" SortExpression="Pending">
            <ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%# (""+Eval("qty","{0:n0}")) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="120px"/><FooterTemplate><asp:Label ID="lblPending" runat="server" Text='<%# Pendingtotal %>' /></FooterTemplate>
            </asp:TemplateField>--%>
           
            </Columns>
            <FooterStyle BackColor="#F3CCC2" BorderStyle="None" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView></td></tr></table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>