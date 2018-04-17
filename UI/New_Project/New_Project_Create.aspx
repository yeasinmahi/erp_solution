<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Project_Create.aspx.cs" Inherits="UI.New_Project.New_Project_Create" %>

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


    function Viewdetails(url) {
        newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=200, close=no');
        if (window.focus) { newwindow.focus() }
    }
</script>
 
    <style type="text/css">
        .txtBox {
            height: 22px;
        }
        .auto-style1 {
            width: 284px;
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
<%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"><table border="0"; style="width:1000PX"; >
    <tr><td colspan="4" class="tblheader">Create New Project<asp:HiddenField ID="hdnsearch" runat="server"/><asp:HiddenField ID="hdnUom" runat="server" /><asp:HiddenField ID="hdnprice" runat="server" />
    <asp:HiddenField ID="hdnBlance" runat="server" /> <asp:HiddenField ID="hdncredit" runat="server" /> 
    <asp:HiddenField ID="hdnTotal" runat="server" /></td>
    </tr>
    <tr class='tblrowodd'><td style="text-align:right;"><asp:Label ID="lblProjectCode" CssClass="lbl" runat="server" Text="Project Code: "></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtProjectCode" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="lbladdress" CssClass="lbl" runat="server" Text="Address : "></asp:Label></td>
    <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblunit" CssClass="lbl" runat="server" Text="Unit Name :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlunit" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    <td style="text-align:right;"><asp:Label ID="lblLocation" CssClass="lbl" runat="server" Text="Location : "></asp:Label></td>
    <td><asp:TextBox ID="txtLocation" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblCostcenter" CssClass="lbl" runat="server" Text="Cost Center :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlCostcenter" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    <td style="text-align:right;"><asp:Label ID="lblObjective" CssClass="lbl" runat="server" Text="Objective : "></asp:Label></td>
    <td><asp:TextBox ID="txtObjective" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblProjecttype" CssClass="lbl" runat="server" Text="Project Type :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlProjectType" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    <td style="text-align:right;"><asp:Label ID="lbl" CssClass="lbl" runat="server" Text="Objective : "></asp:Label></td>
    <td><asp:TextBox ID="txt" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Project Name :"></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtProjectName" runat="server" CssClass="txtBox"></asp:TextBox></td>
    <td style="text-align:right;"><asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Objective : "></asp:Label></td>
    <td><asp:DropDownList ID="ddlSource" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;">&nbsp;</td>
    <td class="auto-style1"></td>      
    <td style="text-align:right;">&nbsp;</td>
    <td><asp:Button ID="btnSave" runat="server"  CssClass="btn" Text="Submit" /> </td>  
    </tr>
   <%-- <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Customer Name : "></asp:Label></td>
    <td><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" OnTextChanged="txtItem_TextChanged"  ></asp:TextBox>
    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
    ServiceMethod="GetCustomerName" MinimumPrefixLength="1" CompletionSetCount="1"
    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </cc1:AutoCompleteExtender>
    <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /> </td>
    </tr>--%>

    <tr class='tblrowodd'>    
    <td colspan="4"> </td>
 
    </tr>
    <tr class='tblroweven'>    
    <td colspan="2">
   <table border="0" style="width:100%"; >
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblitemtype" CssClass="lbl" runat="server" Text="Item Type :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlItemType" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="lblItem" CssClass="lbl" runat="server" Text="Item Name :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="ddlItem" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    </tr> 
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Item Name :"></asp:Label></td>
    <td class="auto-style1"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddList" ></asp:DropDownList>   </td>  
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Quantity :"></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Rate :"></asp:Label></td>
    <td class="auto-style1"><asp:TextBox ID="txtRate" runat="server" CssClass="txtBox"></asp:TextBox></td>
   
    </tr>
    <tr class="tblrowodd">
    <td style="text-align:right;"></td>
    <td style="text-align:right"><asp:Button ID="Button2" runat="server" Text="Add" /></td>
   
    </tr>
  </table>

    </td>
    <td colspan="2">
    <table border="0" style="width:100%";>
    <tr class="tblrowodd">
    <td style="text-align:right;" colspan="2"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Responsible Person :"></asp:Label></td>
    <td colspan="2"><asp:TextBox ID="txtResponsibleEmpName" runat="server" CssClass="txtBox"></asp:TextBox></td>
    </tr>
    <tr class="tblrowodd">
    <td colspan="2" style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="Responsibility :"></asp:Label></td>
    <td colspan="2"><asp:TextBox ID="txtResponsibility" runat="server" TextMode="MultiLine" CssClass="txtBox"></asp:TextBox></td>
    </tr> 
    <tr class="tblrowodd">
    <td style="text-align:right;">From Date :</td>
    <td style="text-align:right;">
    <asp:TextBox ID="txtFrom" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
    ID="CalendarExtender1" runat="server" EnableViewState="true">
    </cc1:CalendarExtender>
    <img id="imgCal_1" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" /></td>
     <td style="text-align:right;">Todate</td>
     <td style="text-align:right;"> 
    <asp:TextBox ID="TextBox1" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
    <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtFrom" Format="dd/MM/yyyy" PopupButtonID="imgCal_1"
    ID="CalendarExtender2" runat="server" EnableViewState="true">
    </cc1:CalendarExtender>
    <img id="imgCal_1" src="../Content/images/img/calbtn.gif" style="border: 0px;
    width: 34px; height: 23px; vertical-align: bottom;" /></td>
   
    </tr>
  
    <tr class="tblrowodd">
    <td colspan="4" style="text-align:right;">
   
    </td>
   
    </tr>
    <tr><td style="text-align:right" colspan="4"></td></tr>
    <tr><td style="text-align:right" colspan="4"><asp:Button ID="Button1" runat="server" Text="Add" /></td></tr>
  </table>

    </td>
    </tr>
  <%--OnRowDeleting="dgv_RowDeleting1"--%> 
    <tr class=""><td style="text-align:justify;" colspan="2">
    <asp:GridView ID="dgv" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="1" ForeColor="Black" GridLines="Vertical" ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="Item Type" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lblItemtype" runat="server" Text='<%# Bind("itemCust") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="170px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Item Name" SortExpression="sec">
    <ItemTemplate><asp:Label ID="itemProducts" runat="server" Text='<%# Bind("itemProduct") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
    <asp:TemplateField HeaderText="Quantity" >
    <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    <asp:BoundField DataField="Rate" HeaderText="Price" />

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
    <ControlStyle Font-Bold="True" ForeColor="Red" />
    </asp:CommandField>
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td>
    <td colspan="2">
        <%--OnRowDeleting="dgv_RowDeleting1"--%>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
    CellPadding="1" ForeColor="Black" GridLines="Vertical"  ><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %> </ItemTemplate></asp:TemplateField> 
    <asp:TemplateField HeaderText="Responsible" SortExpression="dudt">
    <ItemTemplate><asp:Label ID="lblItemtype" runat="server" Text='<%# Bind("itemCust") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="170px" /></asp:TemplateField>

    <asp:TemplateField HeaderText="Responsibility" SortExpression="sec">
    <ItemTemplate><asp:Label ID="itemProducts" runat="server" Text='<%# Bind("itemProduct") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="120px" /></asp:TemplateField>
             
    <asp:TemplateField HeaderText="Start Date" >
    <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="75px" /></asp:TemplateField>

    <asp:BoundField DataField="End Date" HeaderText="Price" />

    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" > 
    <ControlStyle Font-Bold="True" ForeColor="Red" />
    </asp:CommandField>
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td>
    </tr>
    <tr class='tblrowodd'>
    <td colspan="4" style="text-align:right;">+

    </td></tr>

   </table></div>

 <%--<div class="leaveSummary_container"> 
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
       
    </div>--%>
  








<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
