<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CafeteriaService.aspx.cs" Inherits="UI.HR.Cafeteria.CafeteriaService" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><title></title>
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
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />

    <style type="text/css"> 
    .rounds { height: 200px; width: 150px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:500%; height: 47%; margin-left:300px; margin-top: -280px; margin-right:00px; padding: 15px; overflow-y:scroll;}    
    </style>
</head>
<body>
    <form id="frmcaf" runat="server">
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
       
    
    <table>
    <tr>
    <td>
        <table style="vertical-align:top;"><asp:HiddenField ID="hdnconfirm" runat="server" />
        <tr style="vertical-align:top;">
        <td>
            <div class="leaveApplication_container">
            <table class="tbldecoration" style="width:auto; float:left;">
            <tr class="tblheader"><td colspan="4" style="color:black; text-align:center; font-size:18px"> Meal Requisition </td></tr>

            <tr class="tblroweven"><td style="text-align:right;"><asp:Label ID="lblst" CssClass="lbl" runat="server" Text="Select Type : "></asp:Label></td>
            <td colspan="3" style="text-align:left; font-size:14px; font-weight:bold;">
            <asp:RadioButton ID="PR" runat="server" Text=" Private" AutoPostBack="True" OnCheckedChanged="PR_CheckedChanged"/>
            <asp:RadioButton ID="PB" runat="server" Text=" Public" AutoPostBack="True" OnCheckedChanged="PB_CheckedChanged"/></td>
            </tr>
            <tr class="tblrowodd"><td style="text-align:right;"><asp:Label ID="lblEmpName" CssClass="lbl" runat="server" Text="Employee Name : "></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSearchEmp" runat="server" AutoPostBack="true"  CssClass="txtBox"  Enabled="true" OnTextChanged="txtSearchEmp_TextChanged"></asp:TextBox>
            <asp:HiddenField ID="hdnEnroll" runat="server" /><cc1:AutoCompleteExtender ID="ACE" runat="server" TargetControlID="txtSearchEmp"
            ServiceMethod="GetSearchAssignedTo" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td> 
              
            <td style="text-align:right;"><asp:Label ID="lbldesignation" CssClass="lbl" runat="server" Text="Designation : "></asp:Label></td>
            <td><asp:TextBox ID="txtDesignation" runat="server" CssClass="txtBox" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr class="tblroweven">
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

            <%--<tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblType" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" CssClass="dropdownList">
            <asp:ListItem Selected="True" Value="1">Regular</asp:ListItem><asp:ListItem Value="2">E-Regular</asp:ListItem>
            </asp:DropDownList></td> 
            <td style="text-align:right;"><asp:Label ID="lblMeal" runat="server" CssClass="lbl" Text="Meal :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlMeal" runat="server" AutoPostBack="false" CssClass="dropdownList">
            <asp:ListItem Selected="True" Value="1">Option-1</asp:ListItem><asp:ListItem Value="2">Option-2</asp:ListItem>
            </asp:DropDownList></td>             
            </tr>--%>
            <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>                
            <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true"></asp:TextBox>
            <cc1:CalendarExtender ID="tdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>  
            <td style="text-align:right;"><asp:Label ID="lblMealStatus" CssClass="lbl" runat="server" Text="Meal Status : "></asp:Label></td>
                        
            <td style="text-align:left; font-size:10px; font-weight:bold;">
            <asp:RadioButton ID="rdoOwn" runat="server" Text=" Own" AutoPostBack="True" OnCheckedChanged="rdoOwn_CheckedChanged"/>
            <asp:RadioButton ID="rdoGuest" runat="server" Text=" Guest" AutoPostBack="True" OnCheckedChanged="rdoGuest_CheckedChanged"/></td>    
            
            <%--<td><asp:RadioButtonList runat="server" ID="rdoMealStatus" AutoPostBack="false" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false">
            <asp:ListItem Text=" Own" Value="1" Selected="True"></asp:ListItem><asp:ListItem Text=" Guest" Value="2"></asp:ListItem></asp:RadioButtonList></td>--%>    
            <%--<td colspan="2" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" ForeColor="DarkGreen" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>--%>
            </tr> 
            <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblnom" CssClass="lbl" runat="server" Text="No Of Meal : "></asp:Label></td>
            <td><asp:TextBox ID="txtMealno" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>        
            <td style="text-align:right;"><asp:Label ID="lblremark" CssClass="lbl" runat="server" Text="Remarks : "></asp:Label></td>
            <td><asp:TextBox ID="txtRemark" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
            </tr>
            <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblType" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>                
            <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false" CssClass="dropdownList">
            <asp:ListItem Selected="True" Value="2">Irregular</asp:ListItem><asp:ListItem Value="1">Regular</asp:ListItem>
            </asp:DropDownList></td> 
            <td style="text-align:left; color:red; font-weight:bold;" colspan="2" ><asp:Label ID="lblPresentStatus" runat="server"></asp:Label></td>
            </tr>
            <tr class="tblroweven">        
            <td colspan="4" style="text-align:right;"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" ForeColor="Black" Text="Submit" OnClientClick="ConfirmAll()" OnClick="btnSubmit_Click"/></td>   
            </tr>
            </table>
            </div>
        </td>    
        </tr>
        <tr>
        <td>
            <table style="vertical-align:top">            
            <tr><td colspan="2" style="font-weight:bold; font-size:16px; color:black; text-align:center;">MEAL DETAILS<hr /></td></tr>  
            <tr><td style="vertical-align:top" >Your Schedule Meal :<hr />
            <asp:GridView ID="dgvMealR" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="Date"><ItemTemplate>
            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("dteMeal", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>        
            <asp:TemplateField HeaderText="No Of Meal" SortExpression="MealNo"><ItemTemplate>
            <asp:Label ID="lblNOM" runat="server" Text='<%# Eval("MealNo", "{0:0}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField>             
            <asp:TemplateField HeaderText="Remarks" SortExpression="Details"><ItemTemplate>            
            <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("strNarration") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
        
        
            <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Red" >
            <ItemTemplate><asp:Button ID="btnCancel" runat="server" class="nextclick" OnCommand="btnAction_OnCommand" OnClientClick="ConfirmAll()" CommandName="CANCEL" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("dteMeal") %>' Text="Cancel"/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>--%>            
             
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="true" HeaderText="" ControlStyle-ForeColor="Red" >
            <ItemTemplate><asp:Button ID="btnReject" runat="server" class="nextclick" OnCommand="btnAction_OnCommand" CommandName="CANCEL" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("dteMeal") %>' Text="Cancel"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            
            <td style="vertical-align:top">Your Consume Meal :<hr />
            <asp:GridView ID="dgvMealAppr" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            <asp:TemplateField HeaderText="Date" SortExpression="Date"><ItemTemplate>
            <asp:Label ID="lblDate" runat="server" Text='<%# Eval("dteMeal", "{0:dd-MM-yyyy}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>      
        
            <asp:TemplateField HeaderText="No Of Meal" SortExpression="MealNo"><ItemTemplate>
            <asp:Label ID="lblNOM" runat="server" Text='<%# Eval("MealNo", "{0:0}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="center" Width="50px"/></asp:TemplateField> 

            <asp:TemplateField HeaderText="Remarks" SortExpression="Details"><ItemTemplate>            
            <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("strNarration") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
                    
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>
            </table> 
        </td>
        </tr>
        </table>
    </td>
    <td style="vertical-align:top">
        <table><tr>
        <td style="text-align:justify;">Menu List:<hr />
        <asp:GridView ID="dgvMenuList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" RowStyle-BorderStyle="Double" HeaderStyle-BorderStyle="Double" HeaderStyle-BorderColor="Black" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                  
        <asp:TemplateField HeaderText="Day Name" SortExpression="strDayName"><ItemTemplate>            
        <asp:Label ID="lblDayN" runat="server" Text='<%# Bind("strDayName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

        <asp:TemplateField HeaderText="Menu List" SortExpression="strMenuList"><ItemTemplate>
        <asp:HiddenField ID="hdnDayId" runat="server" Value='<%# Eval("intDayOffId") %>'/>
        <asp:TextBox ID="txtMenu" Width="600px" runat="server" BorderStyle="None" CssClass="lblgd" Wrap="true" TextMode="MultiLine" Height="22px" Text='<%# Bind("strMenuList") %>'></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="left"/></asp:TemplateField>

        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView><br />
        <asp:Label ForeColor="Blue" BackColor="Yellow" Font-Bold="true" Font-Size="16px" ID="lblMsg" runat="server" Text="Menu Option(or) will be Served as per First Come First Service."></asp:Label>
        <asp:Button ID="btnMenu" runat="server" CssClass="nextclick"  ForeColor="Black" Text="Menu Update" OnClientClick="ConfirmAll()" OnCommand="btnAction_OnCommand" CommandName="UPDATE"/>
        </td>
        </tr>
        </table>
    </td>
    </tr>
    </table>

    <%--<div id="hdnDivision" class="hdnDivision" style="width:auto;"><table style="width:auto; float:left; ">            
    <tr><td style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>            
    <tr><td style="text-align:justify;">Menu List For Update :<hr /><asp:GridView ID="dgvMenuLUpdate" runat="server" AutoGenerateColumns="False" Font-Size="9px" BackColor="White" BorderColor="#999999" 
    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="35px"/></asp:TemplateField>
    
    <asp:TemplateField HeaderText="Day Name" SortExpression="strDayName"><ItemTemplate>            
    <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("strDayName") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="90px"/></asp:TemplateField>
            
    <%--<asp:TemplateField HeaderText="Menu List" SortExpression="strMenuList"><ItemTemplate>            
    <asp:Label ID="lblDetails" runat="server" Text='<%# Bind("strMenuList") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>--%>

    <%--<asp:TemplateField HeaderText="Menu List" SortExpression="strMenuList"><ItemTemplate>
    <asp:TextBox ID="txtQuantity" CssClass="txtBox" Width="300px" runat="server" TextMode="MultiLine" Text='<%# Bind("strMenuList") %>'></asp:TextBox></ItemTemplate>
    <ItemStyle HorizontalAlign="left"/></asp:TemplateField>

    </Columns><HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
    </asp:GridView>
    </td></tr>
    <tr class="tblroweven"><td style="text-align:right;"><asp:Button ID="btnUpdate" runat="server" CssClass="nextclick" Text="Update" OnClientClick="ConfirmAll()" OnCommand="btnAction_OnCommand" CommandName="UPDATE"/></td></tr>
    </table>
    </div>--%>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
