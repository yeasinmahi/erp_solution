<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service Requisition.aspx.cs" Inherits="UI.HR.Cafeteria.Service_Requisition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Dispatch Register </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="frmServiceRegistration" runat="server">        
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
    <asp:HiddenField ID="hdnEnroll" runat="server" />
    
    <table>
    <tr><td>
        <table>
        <tr><td>
                <div class="leaveApplication_container">        
                <table class="tbldecoration" style="width:auto; float:left;">
                <tr class="tblheader"><td colspan="4" style="color:green; text-align:center; font-size:18px"> Meal Service Registration </td></tr>

                <tr class="tblroweven"><td style="text-align:right;"><asp:Label ID="lblst" CssClass="lbl" runat="server" Text="Select Type : "></asp:Label></td>
                <td colspan="3" style="text-align:left; font-size:14px; font-weight:bold;">
                <asp:RadioButton ID="PR" runat="server" Text=" Private" AutoPostBack="True" OnCheckedChanged="PR_CheckedChanged"/>
                <asp:RadioButton ID="PB" runat="server" Text=" Public" AutoPostBack="True" OnCheckedChanged="PB_CheckedChanged"/></td>
                </tr>
                <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblEmpName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
                <td style="text-align:left;"><asp:TextBox ID="txtSearchEmp" runat="server" AutoPostBack="true"  CssClass="txtBox"  Enabled="false" OnTextChanged="txtSearchEmp_TextChanged"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchEmp"
                ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </cc1:AutoCompleteExtender></td> 
       
                <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
                <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department : "></asp:Label></td>
                <td><asp:TextBox ID="txtDept" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>        
                <td style="text-align:right;"><asp:Label ID="lblUnit" CssClass="lbl" runat="server" Text="Unit : "></asp:Label></td>
                <td><asp:TextBox ID="txtUnit" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblJobType" CssClass="lbl" runat="server" Text="Job Type : "></asp:Label></td>
                <td><asp:TextBox ID="txtJobType" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>        
                <td style="text-align:right;"><asp:Label ID="lblJobStation" CssClass="lbl" runat="server" Text="Job Station : "></asp:Label></td>
                <td><asp:TextBox ID="txtJobStation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr class="tblrowodd">
                <td style="text-align:right;"><asp:Label ID="lblServiceT" CssClass="lbl" runat="server" Text="Service Type : "></asp:Label></td>
                <td><asp:RadioButtonList runat="server" ID="rdoServiceT" AutoPostBack="false" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false">
                <asp:ListItem Text=" Regular" Value="1" Selected="True"></asp:ListItem><asp:ListItem Text=" Irregular" Value="2"></asp:ListItem></asp:RadioButtonList></td>
    
                <td colspan="2" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>

                </tr>   
                </table>
                </div>    
        </td></tr>
        <tr><td>
            <table class="tbldecoration" style="width:auto; float:left;"> 
            <tr class="tblheader"> <td colspan='2' style="text-align:justify; font-size:12px; background-color:white;"><br/>Condition for Service :-<br /><br /></tr>
    
            <tr class="tblheader"> 
            <td style=" width:40px; background-color:white;"></td>
            <td style="text-align:justify; font-size:11px; background-color:white;">
            1) All interested employee must be register for Lunch service as Regular or Irregular. <br /><br />
            2) Must confirm/cancel before 10 AM of the specific day.<br /><br />
            3) To serve official guest it must be confirmed by the attending employee before 10 AM. <br /><br />
            4) Food is served as per the menu showed in ERP system. <br /> <br />  
            5) As per company policy monthly lunch bill will be adjusted from salary of the employee. <br /><br />
            6) Self Service <br />   
            </td></tr> 
            </table>      
        </td></tr>
        </table><br /><br /><br />
    </td>
        <td><img src="../../Content/images/Cafeteria/MealImmage.jpg"  /></td>   
    </tr>    
    </table>
            

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>