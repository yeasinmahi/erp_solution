<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Approved.aspx.cs" Inherits="UI.SAD.Corporate_sales.Approved" %>

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
    <div class="leaveApplication_container"></div>

 <div class="leaveSummary_container"> 
    <asp:HiddenField ID="hdnapp" runat="server" />
        <div class="tabs_container">Order Summary :<hr /></div>
     <asp:RadioButton ID="rdbutton" GroupName="orderg" runat="server" AutoPostBack="true"  Text="No Approved" OnCheckedChanged="rdbutton_CheckedChanged"/>
     <asp:RadioButton ID="RadioButton1" GroupName="orderg" runat="server" AutoPostBack="true"  Text="Approved" OnCheckedChanged="RadioButton1_CheckedChanged"/>

        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Pagesize="25" ><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:BoundField DataField="intOrderno" HeaderText="Order No" ItemStyle-HorizontalAlign="Center" SortExpression="dteDate">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="strName" HeaderText="Cust Name" ItemStyle-HorizontalAlign="Center" SortExpression="intOrderNo">
        <ItemStyle HorizontalAlign="Left" Width="70px"/></asp:BoundField>
        <asp:BoundField DataField="qty" HeaderText="qty" ItemStyle-HorizontalAlign="Center" SortExpression="strName">
        <ItemStyle HorizontalAlign="Left" Width="130px"/></asp:BoundField>
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="qty" />
            <asp:BoundField DataField="total" HeaderText="Total Price" SortExpression="total" />
           <asp:BoundField DataField="dteDate" HeaderText="Date Price" SortExpression="dteDate" />
                         
            <asp:TemplateField HeaderText="Detalis"><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("intOrderNo") %>' Text="Details" OnClick="btnDetails_Click"  />
        </ItemTemplate><ItemStyle HorizontalAlign="Left" />

            </asp:TemplateField>
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
       
    </div>
  








<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

