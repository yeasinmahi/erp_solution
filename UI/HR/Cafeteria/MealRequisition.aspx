<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MealRequisition.aspx.cs" Inherits="UI.HR.Cafeteria.MealRequisition" %>
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
    <form id="frmMealRequisition" runat="server">        
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
    <div class="leaveApplication_container">        
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr class="tblheader"><td colspan="4" style="color:green; text-align:center; font-size:18px"> Meal Requisition </td></tr>

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
        <tr><td colspan="4"><hr /></td></tr>

        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td> 
            
        <td style="text-align:right;"><asp:Label ID="lblToDate" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>                
        <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" autocomplete="off"></asp:TextBox>
        <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>  
        </tr>
        <tr class="tblrowodd">
        <td style="text-align:right;"><asp:Label ID="lblMealStatus" CssClass="lbl" runat="server" Text="Meal Status : "></asp:Label></td>
        <td><asp:RadioButtonList runat="server" ID="rdoMealStatus" AutoPostBack="false" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false">
        <asp:ListItem Text=" Own" Value="1" Selected="True"></asp:ListItem><asp:ListItem Text=" Guest" Value="2"></asp:ListItem></asp:RadioButtonList></td>    
        <td colspan="2" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" ForeColor="DarkGreen" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>
        </tr>    
    </table>

    <table class="tbldecoration" style="width:auto; float:left;">
        <tr><td  style="text-align:justify;"><hr />
        <asp:GridView ID="dgvAnnual" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Enroll" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="activityid" >
        <ItemTemplate><asp:Label ID="lblEnroll" runat="server" Text='<%# (""+Eval("activityid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Employee Name" SortExpression="activity"><ItemTemplate>            
        <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("activity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="180px"/></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Designation" SortExpression="activity"><ItemTemplate>            
        <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("activity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="180px"/></asp:TemplateField>
          
        <asp:TemplateField HeaderText="Department" SortExpression="activity"><ItemTemplate>            
        <asp:Label ID="lblDepartment" runat="server" Text='<%# Bind("activity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="150px"/></asp:TemplateField>
       
        <asp:TemplateField HeaderText="Date" SortExpression="Names"><ItemTemplate>
        <asp:Label ID="lblDate" runat="server" Text='<%# Eval("dteDate", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Meal Status" SortExpression="activity"><ItemTemplate>            
        <asp:Label ID="lblMealStatus" runat="server" Text='<%# Bind("activity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="50px"/></asp:TemplateField>
        
        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Red" >
        <ItemTemplate><asp:Button ID="btnReject" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
        CommandArgument='<%# Eval("intProject") %>' Text="Cancel"/>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>            

        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>
        </tr> 
    </table>            
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>