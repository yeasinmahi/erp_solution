<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishGoodRouting.aspx.cs" Inherits="UI.SCM.BOM.FinishGoodRouting" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%> 
  
    
   
    <script type="text/javascript"> 
         
        function Confirms() {
             var r=  document.getElementById('txtRemarsk')
            var e = document.getElementById("ddlTransferItem");
            var transferID = e.options[e.selectedIndex].value;
            var e = document.getElementById("ddlLcation");
            var locationId = e.options[e.selectedIndex].value; 

            var inItem = document.getElementById("txtItem").value;
            var remarks = document.getElementById("txtRemarsk").value;
            var quantity =parseFloat(document.getElementById("txtQty").value);
           var inQty= parseFloat(document.getElementById("hdnInQty").value); 
      
            if ($.trim(transferID) == 0 || $.trim(transferID) == "" || $.trim(transferID) == null || $.trim(transferID) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Transfer In Item'); }
            else if ($.trim(locationId) == 0 || $.trim(locationId) == "" || $.trim(locationId) == null || $.trim(locationId) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select Sotre Location'); }
            else if ($.trim(inItem) == 0 || $.trim(inItem) == "" || $.trim(inItem) == null || $.trim(inItem) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please select In Item'); }
            else if ($.trim(remarks) == 0 || $.trim(remarks) == "" || $.trim(remarks) == null || $.trim(remarks) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please Input Remarks'); }
            else if ($.trim(quantity) == 0 || $.trim(quantity) == "" || $.trim(quantity) == null || $.trim(quantity) == undefined) { document.getElementById("hdnPreConfirm").value = "0"; alert('Please input Quantity'); }
            else if ( parseFloat(inQty)<parseFloat(quantity)){ document.getElementById("hdnPreConfirm").value = "0"; alert('input Quantity greater then Transfer In Quantity'); }
                else {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
                if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnPreConfirm").value = "1"; }
                else { confirm_value.value = "No"; document.getElementById("hdnPreConfirm").value = "0"; } 

               // document.getElementById("hdnPreConfirm").value = "1";
            }
             
           
        }
    </script> 
    <style type="text/css">
        .auto-style1 {
            width: 668px;
        }
    </style>
</head>
<body>
<form id="frmTransferOrder" runat="server">
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
        <asp:HiddenField ID="hdnPreConfirm" runat="server" /><asp:HiddenField ID="hdnTransfromValue" runat="server" /><asp:HiddenField ID="hdnInQty" runat="server" />
       <div class="tabs_container">INVENTORY TRANSFER <hr /></div>
        
        <table    style="width:750px; text-align:center ">   
            <tr>
             <td></td><td></td>  <td></td><td></td> 
            <td style="text-align:right;">WH Name:</td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlWh"  CssClass="ddList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged"></asp:DropDownList>  </td> 
        </tr>
            <tr>
                <td></td>
            </tr>
         </table>
        <table>
              <tr>
            <td style='text-align: right;'>Item Name</td>
            <td><asp:TextBox ID="txtFgItem" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true" Width="600px"    OnTextChanged="txtItem_TextChanged"    ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" TargetControlID="txtFgItem"
            ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  

            </tr>
        </table>
        <table style="border-radius:1px; width:800px; border-style:groove">
            <caption style="text-align:left">Asset</caption>
         
            <tr>
            <td style='text-align: right;'>Name</td>
            <td><asp:TextBox ID="txtAsset" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true"    OnTextChanged="txtItem_TextChanged"    ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAsset"
            ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  
           <td style="text-align:right;" ><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="  Date :"></asp:Label></td>

            <td style="text-align:left"><asp:TextBox ID="txtdteDate" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteDate"></cc1:CalendarExtender> 
           <asp:DropDownList ID="ddlFromTime" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server">
            <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
           </asp:DropDownList>
            <asp:DropDownList ID="ddlFromToTime" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server" >
                 <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
            </asp:DropDownList> </td>
           </tr>
            <tr>
            
            <td style="text-align:right" colspan="4"><asp:Button ID="btnAssetAdd" Text="Add" runat="server" /> 
            </tr>
            
             <tr>
            <td colspan="6"> <asp:GridView ID="GridView1" Width="600px" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvWolabor_RowDeleting">
            <Columns>
            <asp:BoundField DataField="strEmployeeName" HeaderText="Performer by" SortExpression="strEmployeeName" />
            <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
            <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="ID" Visible="False">
            <ItemTemplate>
            <asp:Label ID="Label20" runat="server" Text='<%# Bind("intId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView> </td>
            </tr>
            
            
        </table>

        <table><tr><td></td></tr></table> 
         <table style="border-radius:1px; width:800px; border-style:groove">
            <caption style="text-align:left">Man Power</caption> 
             <tr>
             <td colspan="4"><asp:RadioButton ID="radLocal" AutoPostBack="true" runat="server" Text="Local" GroupName="man" /><asp:RadioButton ID="radVendor" AutoPostBack="true" runat="server"  Text="Vendor" GroupName="man" /></td>
             </tr>
            <tr> 
            <td style='text-align: right;'>Name</td>
            <td><asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true"    OnTextChanged="txtItem_TextChanged"    ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  
           <td style="text-align:right;" ><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="  Date :"></asp:Label></td>

            <td style="text-align:left"><asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteDate"></cc1:CalendarExtender> 
           <asp:DropDownList ID="DropDownList1" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server">
            <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
           </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server" >
                 <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
            </asp:DropDownList> </td>
           </tr>
            <tr> 
            <td style="text-align:right" colspan="4"><asp:Button ID="Button1" Text="Add" runat="server" /> 
            </tr>
             <tr>
            <td colspan="6"> <asp:GridView ID="dgvWolabor" Width="600px" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvWolabor_RowDeleting">
            <Columns>
            <asp:BoundField DataField="strEmployeeName" HeaderText="Performer by" SortExpression="strEmployeeName" />
            <asp:BoundField DataField="type" HeaderText="Type" SortExpression="type" />
            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
            <asp:BoundField DataField="strHour" HeaderText="Hour" SortExpression="strHour" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="ID" Visible="False">
            <ItemTemplate>
            <asp:Label ID="Label20" runat="server" Text='<%# Bind("intId") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            </asp:GridView> </td>
            </tr>
        </table>

        <table><tr><td></td></tr></table> 
         <table style="border-radius:1px; width:800px; border-style:groove">
            <caption style="text-align:left">Man power</caption> 
            <tr>
            <td style='text-align: right;'>Item Name</td>
            <td><asp:TextBox ID="TextBox3" runat="server" AutoCompleteType="Search"   CssClass="txtBox" AutoPostBack="true"    OnTextChanged="txtItem_TextChanged"    ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>  
           <td style="text-align:right;" ><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="  Date :"></asp:Label></td>

            <td style="text-align:left"><asp:TextBox ID="TextBox4" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteDate"></cc1:CalendarExtender> 
           <asp:DropDownList ID="DropDownList3" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server">
            <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
           </asp:DropDownList>
            <asp:DropDownList ID="DropDownList4" CssClass="ddList" Font-Bold="False" Width="100px" AutoPostBack="true" runat="server" >
                 <asp:ListItem>12:00 AM</asp:ListItem>
            <asp:ListItem>1:00 AM</asp:ListItem>
            <asp:ListItem>2:00 AM</asp:ListItem>
            <asp:ListItem>3:00 AM</asp:ListItem>
            <asp:ListItem>4:00 AM</asp:ListItem>
            <asp:ListItem>5:00 AM</asp:ListItem>
            <asp:ListItem>6:00 AM</asp:ListItem>
            <asp:ListItem>7:00 AM</asp:ListItem>
            <asp:ListItem>8:00 AM</asp:ListItem>
            <asp:ListItem>9:00 AM</asp:ListItem>
            <asp:ListItem>10:00 AM</asp:ListItem>
            <asp:ListItem>11:00 AM</asp:ListItem>
            <asp:ListItem>12:00 PM</asp:ListItem>
            <asp:ListItem>1:00 PM</asp:ListItem>
            <asp:ListItem>2:00 PM</asp:ListItem>
            <asp:ListItem>3:00 PM</asp:ListItem>
            <asp:ListItem>4:00 PM</asp:ListItem>
            <asp:ListItem>5:00 PM</asp:ListItem>
            <asp:ListItem>6:00 PM</asp:ListItem>
            <asp:ListItem>7:00 PM</asp:ListItem>
            <asp:ListItem>8:00 PM</asp:ListItem>
            <asp:ListItem>9:00 PM</asp:ListItem>
            <asp:ListItem>10:00 PM</asp:ListItem>
            <asp:ListItem>11:59 PM</asp:ListItem> 
            </asp:DropDownList> </td>
           </tr>
            <tr> 
            <td style="text-align:right" colspan="4"><asp:Button ID="Button2" Text="Add" runat="server" /> 
            </tr> 
        </table>
        </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
