<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requisition.aspx.cs" Inherits="UI.Inventory.Requisition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
 <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script src="../Content/JS/datepickr.min.js"></script>

<script type="text/javascript">
    

function Confirm() {
    document.getElementById("hdnconfirm").value = "0";
    var txtSection = document.forms["frmreq"]["txtSection"].value;
    var txtQuantity = document.forms["frmreq"]["txtQuantity"].value;
    if (txtSection == null || txtSection == "") { alert("Please enter valid section ."); }
    else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00") { alert("Please enter valid quantity ."); }
    else { document.getElementById("hdnconfirm").value = "1"; }
}
function isDecimal(value) {
    return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
}
 


function Viewdetails(id) {
    window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
}
</script>


</head>
<body>
    <form id="frmreq" runat="server">
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
    <div class="leaveApplication_container"><table border="0"; style="width:Auto"; >
    <tr><td colspan="2" class="tblheader">Store Requisition Entry :<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnpoint" runat="server" /><asp:HiddenField ID="hdnunit" runat="server" /></td><asp:HiddenField ID="hdnEnroll" runat="server"/>        
    </tr>
    <tr class="tblrowodd"> 
    <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Ware House : "></asp:Label><asp:HiddenField ID="hdntype" runat="server"/></td>
    <td><asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" DataSourceID="odswh" DataTextField="WH" DataValueField="intWHID" OnDataBound="ddlWH_DataBound" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
    <asp:ObjectDataSource ID="odswh" runat="server" SelectMethod="GetWarehouseList" TypeName="HR_BLL.Global.DaysOfWeek">
    <SelectParameters><asp:SessionParameter Name="enroll" SessionField="sesUserID" Type="Int32" /><asp:ControlParameter ControlID="hdntype" Name="type" PropertyName="Value" Type="Int32" />
    </SelectParameters></asp:ObjectDataSource><asp:HiddenField ID="hdnwh" runat="server"/>
    </td>
    <td style="text-align:right;"><asp:Label ID="lbldpt" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
    <td><asp:Label ID="lblDept" CssClass="lbl" runat="server"></asp:Label></td>
    </tr>

    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Due-Date : "></asp:Label></td>
    <td><asp:TextBox ID="txtDueDate" runat="server" CssClass="txtBox"></asp:TextBox><script type="text/javascript"> new datepickr('txtDueDate', { 'dateFormat': 'Y-m-d' });</script></td>
    <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
    <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" Text="0.00"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
    <%--<td colspan="3"><asp:TextBox ID="txtItem" runat="server" CssClass="txtBox" Width="500px" AutoPostBack="false" onchange="javascript: Changed();"></asp:TextBox>--%>
    <td colspan="3"><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="500px" ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
    ServiceMethod="GetWearHouseRequesision" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
    </td></tr>

    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
    <td colspan="3"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="500px"></asp:TextBox></td></tr>
    <tr class='tblroweven'>
       <td style="text-align:right;"><asp:Label ID="lblsec" CssClass="lbl" runat="server" Text="Section Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtSection" runat="server" CssClass="txtBox" AutoPostBack="false"></asp:TextBox></td>
         <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Cost Center: "></asp:Label></td>
    <td><asp:DropDownList ID="DdlCostCenter" runat="server" AutoPostBack="true"></asp:DropDownList>
    <asp:Button ID="btnAdd" runat="server" Text="ADD" Font-Bold="true"
    OnClientClick = "Confirm()" OnClick="btnAdd_Click"></asp:Button><asp:HiddenField ID="hdnconfirm" runat="server" /></td>
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblReqBy" CssClass="lbl" runat="server" Text="Requisition By :"></asp:Label></td>
    <td colspan="3"><asp:TextBox ID="txtSearchAssignedTo" runat="server" AutoPostBack="true"  CssClass="txtBox" Width="500px" OnTextChanged="txtSearchAssignedTo_TextChanged"></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSearchAssignedTo"
    ServiceMethod="GetItemListsForStoreReq" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender></td></tr>

    <tr class=""><td style="text-align:justify;" colspan="4">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %><asp:HiddenField ID="hdnitmid" runat="server" Value='<%# Bind("itemid") %>' /></ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="Due Date" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lbldudt" runat="server" Text='<%# Bind("dudt") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="70px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Section" SortExpression="sec">
    <ItemTemplate><asp:Label ID="lblSec" runat="server" Text='<%# Bind("sec") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
    <asp:TemplateField HeaderText="Description" SortExpression="item">
    <ItemTemplate><asp:Label ID="lblitem" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="250px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Quantity" SortExpression="quantity">
    <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("quantity") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    <tr class='tblrowodd'><td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click" /></td></tr>
    </table></div>


   <div class="leaveSummary_container"> 
        <div class="tabs_container">Requisition Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="True" Pagesize="25" DataSourceID="odsqwnreq"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="Edate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="Edate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="Code" HeaderText="Requisition Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
        <asp:BoundField DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center" SortExpression="Section">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details" ><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("Req") %>' Text="Details"  OnClick="Dtls_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsqwnreq" runat="server" SelectMethod="CreateStoreRequisition" TypeName="HR_BLL.Global.DaysOfWeek">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
            <asp:SessionParameter DefaultValue="" Name="actionby" SessionField="sesUserID" Type="Int32" />
            <asp:Parameter DefaultValue="" Name="xml" Type="String" />
            <asp:Parameter DefaultValue="0" Name="id" Type="Int32" />
            <asp:Parameter DefaultValue="2015-10-01" Name="fdate" Type="DateTime" />
            <asp:Parameter DefaultValue="2020-12-31" Name="tdate" Type="DateTime" />
            <asp:SessionParameter DefaultValue="" Name="intInsertBy" SessionField="sesUserID" Type="Int32" />
        </SelectParameters>
        </asp:ObjectDataSource>
    </div>








<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
