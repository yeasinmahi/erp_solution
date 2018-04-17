<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Getpass.aspx.cs" Inherits="UI.Inventory.Getpass" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html> <head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
<link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
<script>
    function ConfirmAll() {
        document.getElementById("hdnconfirm").value = "0";
        var txtRemarks = document.forms["frmgp"]["txtRemarks"].value;
        var txtUom = document.forms["frmgp"]["txtUom"].value;
        var txtQuantity = document.forms["frmgp"]["txtQuantity"].value;
        var txtDate = document.forms["frmgp"]["txtDate"].value;
        if (txtDate == null || txtDate == "") {
            alert("Date must be filled by valid formate (year-month-day).");
        }
        else if (!isDecimal(txtQuantity) || txtQuantity.length <= 0 || txtQuantity == "0" || txtQuantity == "0.00")
        { alert("Please enter valid quantity ."); }
 
        else if (txtUom == null || txtUom == "") {
            alert("Uom must be filled..");
        }
        else if (txtRemarks == null || txtRemarks == "") {
            alert("Remarks must be filled..");
        }
        else {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "1"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
        }
    }
    function isDecimal(value) {
        return parseFloat(value) == value; // Check Intiger values by value % 1 === 0;
    }
    function Viewdetails(id, status) {
        window.open('Gatepassprint.aspx?ID=' + id + '&STS=' + status, '', "height=375, width=530, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
    }

</script>

</head>
<body>
     <form id="frmgp" runat="server">
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate><asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"></cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <div class="tabs_container"> Get Pass Entry : <hr /></div>
        <table border="0"; style="width:Auto"; >
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lbldt" CssClass="lbl" runat="server" Text="Date : "></asp:Label></td>
        <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="dt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>  
        <td style="text-align:right;"><asp:Label ID="lblfadd" CssClass="lbl" runat="server" Text="From-Address : "></asp:Label></td>
        <td><asp:TextBox ID="txtFromAddress" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>  </tr>        
                
        
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblto" CssClass="lbl" runat="server" Text="To-Address : "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtAddress"  runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  Width="467px"></asp:TextBox>
         <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAddress"
        ServiceMethod="GetEmplyeeAdd" MinimumPrefixLength="1" CompletionSetCount="1"
        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
        </cc1:AutoCompleteExtender>
        <%-- <td><asp:DropDownList ID="ddlTo" runat="server" CssClass="ddList" Width="200px" DataSourceID="odspnt" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
        <asp:ObjectDataSource ID="odspnt" runat="server" SelectMethod="GetAllJobStation" TypeName="HR_BLL.Global.JobStation"></asp:ObjectDataSource>--%>
        <asp:CheckBox ID="chkOther" runat="server" Text="Other" AutoPostBack="true" OnCheckedChanged="chkOther_CheckedChanged" /><br />            
        <asp:TextBox ID="txtToOther" Width="467px" runat="server" CssClass="txtBox"></asp:TextBox></td></tr>
        
        <tr><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Item List : "></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtItem" runat="server" Width="467px" CssClass="txtBox"></asp:TextBox></td>  </tr>     
        
        <tr><td style="text-align:right;"><asp:Label ID="lblremarks" CssClass="lbl" runat="server" Text="Remarks :"></asp:Label></td>
        <td colspan="3"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox" TextMode="MultiLine" Width="467px"></asp:TextBox></td>
        </tr>
            
        <tr>
        <td style="text-align:right;"><asp:Label ID="lblquantity" CssClass="lbl" runat="server" Text="Quantity : "></asp:Label></td>
        <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox" Width="100px" Text="0.0000"></asp:TextBox>
        <asp:TextBox ID="txtUom" runat="server" CssClass="txtBox" Width="50px"></asp:TextBox>
        <asp:CheckBox ID="chkRtn" runat="server" Text="Returnable" AutoPostBack="false"/>
        </td>
        <td style="text-align:right;" colspan="2"><asp:Button ID="btnAdd" runat="server" Text="ADD" Font-Bold="true"
        OnClientClick = "ConfirmAll()" OnClick="btnAdd_Click"></asp:Button><asp:HiddenField ID="hdnconfirm" runat="server" /></td></tr>

        <tr class=""><td style="text-align:justify;" colspan="4">
        <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="1" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgv_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField> 
        <asp:TemplateField HeaderText="Date" SortExpression="dt">
        <ItemTemplate><asp:Label ID="lbldt" runat="server" Text='<%# Bind("dt") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Description" SortExpression="item">
        <ItemTemplate><asp:Label ID="lbldesc" runat="server" Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="quantity">
        <ItemTemplate><asp:Label ID="lblquantity" runat="server" Text='<%# Bind("quantity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="55px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Uom" SortExpression="uom">
        <ItemTemplate><asp:Label ID="lblUom" runat="server" Text='<%# Bind("uom") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Center" Width="35px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks" SortExpression="remarks">
        <ItemTemplate><asp:Label ID="lblremarks" runat="server" Text='<%# Bind("remarks") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" /> </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>
        <tr class='tblrowodd'><td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Font-Bold="true" OnClick="btnSubmit_Click" /></td></tr>
        </table>
     </div>

    <div class="leaveSummary_container"> 
        <div class="tabs_container">Gatepass Summary :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" AllowPaging="false"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
        <asp:BoundField DataField="CDate" HeaderText="Entry Date" ItemStyle-HorizontalAlign="Center" SortExpression="CDate" DataFormatString="{0:yyyy-MM-dd}">
        <ItemStyle HorizontalAlign="Left" Width="80px" /></asp:BoundField> 
        <asp:BoundField DataField="Code" HeaderText="Challan Code" ItemStyle-HorizontalAlign="Center" SortExpression="Code">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
        <asp:BoundField DataField="Status_" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Status_">
        <ItemStyle HorizontalAlign="Left" Width="120px"/></asp:BoundField>
 
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details" ><ItemTemplate>
        <asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" CommandArgument='<%# Eval("RId") +"^"+ Eval("Status_") %>' Text="Details"  OnClick="Dtls_Click"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                         
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
