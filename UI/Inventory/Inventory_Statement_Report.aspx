<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory_Statement_Report.aspx.cs" Inherits="UI.Inventory.Inventory_Statement_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:  :.</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/jquery-ui.min.css" rel="stylesheet" />

    <script>
        function loadIframe(iframeName, url) {
            var $iframe = $('#' + iframeName);
            if ($iframe.length) {
                $iframe.attr('src', url); 
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            position: relative;
            min-height: 1px;
            top: 1px;
            left: 0px;
            float: left;
            width: 25%;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</head>
<body>
    <form id="frmattendancedetails" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender2" runat="server">
    </cc1:AlwaysVisibleControlExtender>
    <%--=========================================Start My Code From Here===============================================--%>
        
       <div class="container pull-left">
                       <asp:HiddenField ID="hdnEnroll" runat="server" />
            <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Inventory Statement Report" Font-Bold="true" Font-Size="16px"></asp:Label>

                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="auto-style1">
                                    <asp:Label ID="Label1" runat="server" Text="From Date" ></asp:Label>
                                     <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
                                     <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>

                                    </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label2" runat="server" Text="To Date" ></asp:Label>
                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:TextBox>
                                   <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                                    </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label3" runat="server" Text="Ware House" ></asp:Label>
                                     <asp:DropDownList ID="ddlWH" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                                    </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label4" runat="server" Text="Search By" ></asp:Label>
                                <asp:DropDownList ID="ddlSearchBy" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="true">
                                       <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                       <asp:ListItem Text="Category" Value="1"></asp:ListItem>
                                       <asp:ListItem Text="Sub-Category" Value="2"></asp:ListItem>
                                       <asp:ListItem Text="Item ID" Value="3"></asp:ListItem>
                                       <asp:ListItem Text="Item Name" Value="4"></asp:ListItem>
                                       <asp:ListItem Text="Purchase Type (Local/Foreign)" Value="5"></asp:ListItem>
                                       <asp:ListItem Text="Major Category" Value="6"></asp:ListItem>
                                       <asp:ListItem Text="Cluster" Value="7"></asp:ListItem>
                                       <asp:ListItem Text="Commodity" Value="8"></asp:ListItem>
                                       <asp:ListItem Text="Store Location" Value="9"></asp:ListItem>
                                       <asp:ListItem Text="Plant" Value="10"></asp:ListItem>
                                   </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row form-group">
                                     <div class="col-md-4 hidden" id="subcategory">
                                     
                                          <asp:Label ID="Label5" runat="server" Text="Type" ></asp:Label>
                                          <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 "></asp:DropDownList>
                                   
                              
                                     </div>
                                    <div class="col-md-5 hidden" id="itemname">
                                        <asp:Label ID="Label6" runat="server" Text="Item Name" ></asp:Label>
                                        <asp:TextBox ID="txtItemName" runat="server" AutoCompleteType="Search" CssClass="form-control col-md-12 col-sm-12 col-xs-12 " AutoPostBack="true"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItemName"
                                        ServiceMethod="GetIndentItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
                                        CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                        CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                        </cc1:AutoCompleteExtender>
                             
                                     </div>
                                    <div class="col-md-3 hidden" id="itemid">
                                       <asp:Label ID="Label7" runat="server" Text="Item ID" ></asp:Label>
                                         <asp:TextBox ID="txtItemID" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12 "></asp:TextBox>
                                     </div>
                                 </div>
                             <div class="row">
                                  <div class="col-md-12 btn-toolbar">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClick="btnShow_Click" />
                                </div>
                                 </div>
                                </div>
                      
                     </div>               
                  
                    </div>
                     <div>
                         <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1000px; border:0px solid red;"></iframe>
                    </div>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
        <script>
         function showPanel() {
            
             var search = document.getElementById("ddlSearchBy").value;
             var subcategory = document.getElementById("subcategory");
             var itemname = document.getElementById("itemname");
             var itemid = document.getElementById("itemid");
             if (search == 3) {
                 itemid.classList.remove("hidden");
                 //subcategory.classList.remove("hidden");
             }
             else if (search == 4) {
                 //subcategory.classList.remove("hidden");
                 itemname.classList.remove("hidden");
             }
             else {
                 subcategory.classList.remove("hidden");
             }
            
            return true;
        }
       
            </script>
    </form>

</body>
</html>