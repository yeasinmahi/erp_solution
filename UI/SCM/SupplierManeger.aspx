<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierManeger.aspx.cs" Inherits="UI.SCM.SupplierManeger" %>

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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
       
     
  
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left: 70px;  margin-top:00px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Supplier Manager From<hr /></div>
          <table style="width:700px"> 
              <tr>   
                <td></td>
                <td style="text-align:center; font-size:medium; font-weight:bold; font:u" ><asp:Label ID="lblUnitName" runat="server" Text="Manage Supplier" Font-Underline="true"></asp:Label></td>
                </tr> 
           </table>
         <table style="width:700px"> 
                <tr>
                    <td>Department</td>
                    <td class="3"><asp:DropDownList ID="ddlDept" Width="300px" runat="server" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                        <asp:ListItem Text="Local"></asp:ListItem>
                         <asp:ListItem Text="Febrication"></asp:ListItem>
                         <asp:ListItem Text="Import"></asp:ListItem>
                         </asp:DropDownList></td>
                </tr>
                <tr>
                <td>Supplier List</td>
                <td><asp:TextBox ID="txtSupplier" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" OnTextChanged="txtSupplier_TextChanged"    ></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtenders2" runat="server" TargetControlID="txtSupplier"
                ServiceMethod="GetMasterSupplierSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender> </td> 
                </tr>
               <tr>
                   <td>Select Unit</td>
                   <td><asp:DropDownList ID="ddlUnit" Width="300px" runat="server"></asp:DropDownList> 
                    <asp:Button ID="btnAdd" runat="server" Text="Add Supplier" OnClick="btnAdd_Click" /></td>
               </tr>
              </table>         

         <table >
           <tr>
               <td>Basic Information:</td>
           </tr>
            <tr>
            <td><asp:Label ID="lbl1" Text="Supplier Name" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblSupplierName" runat="server"></asp:Label></td>
            </tr>
             <tr>
            <td><asp:Label ID="Label1" Text="Postral Address" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblPostralAdd" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label3" Text="Phone Number" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblPhoneNo" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label5" Text="Fax No" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblFaxNo" runat="server"></asp:Label></td>
            </tr>
           <tr>
            <td><asp:Label ID="Label7" Text="Email Address" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
            </tr>
             <tr>
            <td><asp:Label ID="Label9" Text="Contact Person" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblContactPerson" runat="server"></asp:Label></td>
            <tr>
            <td><asp:Label ID="Label11" Text="Contact No" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblContactNo" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label13" Text="Pay To" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblPayTo" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td><asp:Label ID="Label15" Text="Status" runat="server"></asp:Label></td>
            <td><asp:Label ID="lblStatus" runat="server"></asp:Label></td>
            </tr>
            </tr>
        </table>
        </div>
        

        </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
