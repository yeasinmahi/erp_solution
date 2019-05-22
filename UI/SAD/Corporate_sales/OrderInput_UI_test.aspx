<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderInput_UI_test.aspx.cs" Inherits="UI.SAD.Corporate_sales.OrderInput_UI_test" %>
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
    //function Changed() {
    //    document.getElementById('hdfSearchBoxTextChange').value = 'true';
    //}
    //function SearchText() {
    //    $("#txtItem").autocomplete({
    //        source: function (request, response) {
    //            $.ajax({
    //                type: "POST",
    //                contentType: "application/json;",
    //                url: "Requisition.aspx/GetAutoCompleteData",
    //                data: '{"whid":"' + $("#hdnwh").val() + '","searchKey":"' + document.getElementById('txtItem').value + '"}',
    //                dataType: "json",
    //                success: function (data) {
    //                    response(data.d);
    //                },
    //                error: function (result) {
    //                    alert("Error");
    //                }
    //            });
    //        }
    //    });
    //}

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



    //function Viewdetails(id) {
    //    window.open('RequisitionDetails.aspx?ID=' + id, '', "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
    //}
    function Viewdetails(url) {
        newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
        if (window.focus) { newwindow.focus() }
    }
</script>
      


    <style type="text/css">
        .txtBox {
            height: 22px;
        }
    </style>
      


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
    <div class="leaveApplication_container"><table border="0"; style="width:500PX"; >
    <tr><td colspan="2" class="tblheader">Order Input From:<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
     <asp:HiddenField ID="hdnBlance" runat="server" /> <asp:HiddenField ID="hdncredit" runat="server" /> 
         <asp:HiddenField ID="hdnTotal" runat="server" />
        </td></tr>
        <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"  ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
    ServiceMethod="GetCustomerName" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"> </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" />
    </td></tr>
        <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="lbldudt" CssClass="lbl" runat="server" Text="Blance : "></asp:Label></td>
    <td><asp:TextBox ID="txtBlance"  runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Credit Limit : "></asp:Label></td>
    <td><asp:TextBox ID="txtCreditlim" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>  
    <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Product Name : "></asp:Label></td>
    <td>
    <asp:TextBox ID="txtProduct" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtProduct_TextChanged"  ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtProduct"
        ServiceMethod="GetProductNameSearch" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"> </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdnProduct" runat="server" /><asp:HiddenField ID="hdnProductID" runat="server" />
    </td></tr>
    <tr class='tblroweven'><td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
    <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" Text="0" TextMode="Number"></asp:TextBox></td>
    </tr>
   <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Ship Point: "></asp:Label></td>
    <td><asp:DropDownList ID="ddlShipPoint" runat="server" CssClass="ddList" ></asp:DropDownList>     
   </tr>
    <tr class=""><td style="text-align:justify;" colspan="2">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting1" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="CustomerName" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lblCust" runat="server" Text='<%# Bind("itemCust") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="170px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="ProductName" SortExpression="sec">
    <ItemTemplate><asp:Label ID="itemProducts" runat="server" Text='<%# Bind("itemProduct") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
    <asp:TemplateField HeaderText="Quantity" >
    <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

        <asp:BoundField DataField="price" HeaderText="Price" />

        <asp:BoundField DataField="totalprice" HeaderText="Total Price" SortExpression="totalprice" />

    <asp:TemplateField HeaderText="ShipPoint" >
    <ItemTemplate><asp:Label ID="lblShip" runat="server" Text='<%# Bind("spoint") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>
    

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
        <ControlStyle Font-Bold="True" ForeColor="Red" />
        </asp:CommandField>
        </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td></tr>
    <tr class='tblrowodd'><td colspan="2" style="text-align:right;"><asp:Button ID="btnAdd" runat="server" Text="Add" Font-Bold="true" OnClick="btnAdd_Click"  />
   <asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click"  /></td></tr>

   </table></div>

 <div class="leaveSummary_container"> 
        <div class="tabs_container">Order Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="dteDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="intOrderNo" HeaderText="Order Number" ItemStyle-HorizontalAlign="Center" SortExpression="intOrderNo">
        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:BoundField>
        <asp:BoundField DataField="strName" HeaderText="CustomerName" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
            <asp:BoundField DataField="qty" HeaderText="Qty" SortExpression="qty" />
            <asp:BoundField DataField="total" HeaderText="Total Price" SortExpression="total" />
                         
            <asp:TemplateField HeaderText="Detalis"><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("intOrderNo") %>' Text="Details" OnClick="btnDetails_Click"  />
        </ItemTemplate><ItemStyle HorizontalAlign="Left" />

            </asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
       
    </div>


         </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

