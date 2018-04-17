<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptTransferReport.aspx.cs" Inherits="UI.SCM.Transfer.rptTransferReport" %>
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
<form id="frmTransferrot" runat="server">
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
       <div class="tabs_container"> TRANSFER ORDER<hr /></div>
        <table  class="tbldecoration" style="width:auto; float:left;">                           
        <tr><td colspan="5"><hr /></td></tr>                              
        <tr class="tblrowodd">           
            <td style="text-align:left;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlshippoint" runat="server"></asp:DropDownList>  </td>
            <td style='text-align: left; width:120px;' colspan="2">
                <asp:CheckBox ID="CheckBox1" Text="Total By Product" runat="server" />
            </td>
            
            <td style="text-align:right;"> 
                &nbsp;</td>
        </tr>   
        <tr><td>From WH</td>
            <td><asp:DropDownList ID="ddlFromWH" runat="server"  AutoPostBack="True"></asp:DropDownList>
            </td>
            <td>To WH</td>
            <td colspan="2"><asp:DropDownList ID="ddlToWH" runat="server"  AutoPostBack="True"></asp:DropDownList></td></tr>
         <tr ><td >Item Name</td>
            <td colspan="5"><asp:TextBox ID="txtItemName" Height="25" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItemName"
            ServiceMethod="ItemnameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender>
            </td>
          
        </tr>  
        <tr><td>From Date </td>
            <td><asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
            <td>To Date </td><td><asp:TextBox ID="txtTo" Enabled="false"  runat="server" CssClass="txtbox"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtTo" Format="dd/MM/yyyy"
            PopupButtonID="imgCal_2" ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
             width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr>
        <tr>     
        <td colspan="4" style="text-align:right">&nbsp; &nbsp; &nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" style="height: 26px" />
        </td>
        </tr>                        
        <tr><td colspan="5"><hr />
            <asp:GridView ID="dgvRptProductTotal" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns> 
                 
             <asp:BoundField DataField="intItemID" HeaderText="Item Id" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strItem" HeaderText="Item Name" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="strUoM" HeaderText="UOM" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="Qty" HeaderText="Qty" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="WH" HeaderText="WH Name" ReadOnly="True" SortExpression="Point"/>
           
             <asp:BoundField DataField="Column1" HeaderText="Type" ReadOnly="True" SortExpression="Point"/>
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
             <asp:GridView ID="dgvDetails" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small"  ShowFooter="True">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns> 
                 
            
            <asp:BoundField DataField="intItemID" HeaderText="Item Id" ReadOnly="True" SortExpression="strline"/>
            <asp:BoundField DataField="strItem" HeaderText="Item Name" ReadOnly="True" SortExpression="strregion"/>
            <asp:BoundField DataField="strUoM" HeaderText="UOM" ReadOnly="True" SortExpression="strarea"/>
            <asp:BoundField DataField="Qty" HeaderText="Qty" ReadOnly="True" SortExpression="strTerritory"/>
            <asp:BoundField DataField="WH" HeaderText="WH Name" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="strItemTransferType" HeaderText="Item Type" ReadOnly="True" SortExpression="Point"/>
            <asp:BoundField DataField="strSadChallan" HeaderText="Challan No" ReadOnly="True" SortExpression="Point"/>
           
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
            </td></tr>          
        </tr>             
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>