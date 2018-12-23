<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventory_Statement_Report.aspx.cs" Inherits="UI.Inventory.Inventory_Statement_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>.:  :.</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="X-Frame-Options" content="allow"/>
    <asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
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
        
       <div class="container">
                       <asp:HiddenField ID="hdnEnroll" runat="server" />
                       <table>
                            <tr class="tblheader"><td class="tdheader" colspan="9"> Employee Attendance with Overtime Status :</td></tr>        
                            <tr class="tblheader"><td style=" height:2px; background-color:#c1bdbd;" colspan="9"> </td></tr>
                            <tr><td colspan="9" style="height:5px;"></td></tr>
                           <tr>
                               
                               <td><asp:Label ID="Label1" runat="server" Text="From Date" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label2" runat="server" Text="To Date" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label3" runat="server" Text="Ware House" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label4" runat="server" Text="Search By" ></asp:Label></td><td></td>
                           </tr>
                           <tr>
                              
                               <td>
                                   <asp:TextBox ID="txtFromDate" runat="server" ></asp:TextBox>
                                   <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender>

                               </td><td></td>
                               <td>
                                   <asp:TextBox ID="txtToDate" runat="server" ></asp:TextBox>
                                   <cc1:CalendarExtender ID="td" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender>
                               </td><td></td>
                               <td>
                                   <asp:DropDownList ID="ddlWH" runat="server"></asp:DropDownList>
                               </td><td></td>
                               <td>
                                   <asp:DropDownList ID="ddlSearchBy" runat="server" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="true">
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
                               </td
                             
    
                           </tr>
                          <tr>
                               
                               <td colspan="3"><asp:Label ID="Label5" runat="server" Text="Sub Category" ></asp:Label></td><td></td>
                               <td><asp:Label ID="Label6" runat="server" Text="Item ID" ></asp:Label></td><td></td>
                           </tr>
                           <tr>
                               <td colspan="3"><asp:DropDownList ID="ddlSubCategory" runat="server" Width="290"></asp:DropDownList></td><td></td>
                               <td><asp:TextBox ID="txtItemID" runat="server"></asp:TextBox></td><td></td>
                                 <td>
                                   <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"/>
                               </td>
                           </tr>
                       </table>
                                        
                             
                    <div>
                         <iframe runat="server" oncontextmenu="return false;" id="frame" name="frame" style="width:100%; height:1000px; border:0px solid red;"></iframe>
                    </div>
                    </div>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>