<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExecutionPAppByAccount.aspx.cs" Inherits="UI.Projects.Local.ExecutionPAppByAccount" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Execution Plan </title>
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
    
    <style type="text/css"> 
    .rounds { height: 200px; width: 150px; -moz-border-colors:25px; border-radius:25px;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:500%; height: 55%; margin-left:50px; margin-top: 00px; margin-right:00px; padding: 15px; overflow-y:scroll;}    
    </style>

</head>
<body>
    <form id="frmExecutionPlanApproveByAccounts" runat="server">        
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

    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnProjectID" runat="server" />
    <div class="leaveApplication_container">
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4" style="color:black; text-align:left; font-size:14px"> EXECUTION PLAN APPROVE FORM (By Accounts) </td></tr>
    <tr><td colspan="4"><hr /></td></tr>

    <tr>
    <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit Name :"></asp:Label></td>
    <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="True" DataSourceID="odsunt" DataTextField="strUnit" DataValueField="intUnitID" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsunt" runat="server" SelectMethod="GetUnitListForTransport" TypeName="SAD_BLL.Transport.InternalTransportBLL">
    <SelectParameters><asp:SessionParameter Name="Enroll" SessionField="sesUserID" Type="Int32" /></SelectParameters> </asp:ObjectDataSource></td>

    <td style="text-align:right;"><asp:Label ID="lblDept" runat="server" CssClass="lbl" Text="Department :"></asp:Label></td>
    <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" DataSourceID="odsDept" DataTextField="Names" DataValueField="ID" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"></asp:DropDownList>
    <asp:ObjectDataSource ID="odsDept" runat="server" SelectMethod="GetDepartmentList" TypeName="Projects_BLL.Project_Class">
    <SelectParameters><asp:ControlParameter ControlID="hdnUnit" Name="intUnitid" PropertyName="Value" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td>
    </tr>
    <tr>
    <td colspan="4"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" Text="Show" OnClick="btnShow_Click"></asp:Button></td>
    </tr>
    <tr>
    <td colspan="4">
    <asp:GridView ID="dgvExecutionP" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
    <asp:TemplateField HeaderText="ProjectID" SortExpression="intProject" Visible="false">
    <ItemTemplate><asp:Label ID="lblProjectID" runat="server" Text='<%# (""+Eval("intProject")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
    <asp:TemplateField HeaderText="Event Name" SortExpression="strActivity">
    <ItemTemplate><asp:Label ID="lblActivity" runat="server" Text='<%# Bind("strActivity") %>'></asp:Label>
    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="280px" /></asp:TemplateField>
                            
    <asp:TemplateField HeaderText="Budget Amount" ItemStyle-HorizontalAlign="right" SortExpression="BudgetAmount">
    <ItemTemplate><asp:Label ID="lblBAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("BudgetAmount"))) %>'></asp:Label>
    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="90px" /></asp:TemplateField>
            
    <asp:TemplateField HeaderText="Request Amount" ItemStyle-HorizontalAlign="right" SortExpression="RequestAmount">
    <ItemTemplate><asp:Label ID="lblRAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("RequestAmount"))) %>'></asp:Label>
    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="90px" /></asp:TemplateField>
            
    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
    <ItemTemplate><asp:Button ID="btnDetails" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
    CommandArgument='<%# Eval("intProject") %>' Text="Details" OnClick="btnDetails_Click"/>
    </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>

    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView>
    </td>
    </tr>
    </table>
    </div>

    <div id="hdnDivision" class="hdnDivision" style="width:auto;">
    <table style="width:auto; float:left; ">
    <tr><td colspan="3" style="text-align:right; font:bold 14px verdana;"><a class="button" onclick="ClosehdnDivision('1')" title="Close" style="cursor:pointer;text-align:right; color:red; font:bold 10px verdana;">X</a></td></tr>
    <tr><td colspan="3" style="text-align:center;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Font-Underline="true" Font-Bold="true" Font-Size="14px"></asp:Label>
    <asp:Label ID="Label2" CssClass="lbl" runat="server" Font-Underline="true" Font-Bold="true" Font-Size="11px"></asp:Label></td></tr>
    
    <tr class="tblheader"><td colspan="3"> EXECUTION PLAN APPROVE (By Accounts) </td></tr>    
    <tr><td colspan="3">
    <asp:GridView ID="dgvExecutionEdit" runat="server"  AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="None" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="White"
    BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvExecutionEdit_RowDataBound">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
    <asp:TemplateField HeaderText="ProjectID" SortExpression="intProject" Visible="false">
    <ItemTemplate><asp:Label ID="lblProjectID" runat="server" Text='<%# (""+Eval("intProject")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
    <asp:TemplateField HeaderText="Activityid" SortExpression="intRow" Visible="false">
    <ItemTemplate><asp:Label ID="lblActivitryid" runat="server" Text='<%# (""+Eval("intRow")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
    <asp:TemplateField HeaderText="Event Name" SortExpression="strActivity">
    <ItemTemplate><asp:Label ID="lblActivity" runat="server" Text='<%# Bind("strActivity") %>'></asp:Label>
    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="390px" />
    <FooterTemplate><div style="padding:0 0 5px 0"><asp:Label ID="lbl" runat="server" Text="Grand Total :" /></div></FooterTemplate></asp:TemplateField>
    
    <asp:TemplateField HeaderText="Request Amount" ItemStyle-HorizontalAlign="right" SortExpression="RequestAmount">
    <ItemTemplate><asp:Label ID="lblRAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("RequestAmount"))) %>'></asp:Label>
    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="90px" />
    <FooterTemplate><asp:Label ID="lblRAmount" runat="server" Width="100px" Text='<%# totalamo %>' /></FooterTemplate></asp:TemplateField>

    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="" ControlStyle-ForeColor="Blue" >
    <ItemTemplate><asp:Button ID="btnDetails" runat="server" class="nextclick" Enabled="false" style="cursor:pointer; font-size:11px;" 
    CommandArgument='<%# Eval("intRow") %>' Text="PO Create"/>
    </ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
      
    </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" /></asp:GridView>
    </td></tr>
    <tr><td colspan="3"><hr /></td></tr>
    <tr>
        <td colspan="3" style="text-align:left;"><asp:Label ID="lblAdvance" runat="server" CssClass="lbl" Text="Advance Required Amount :"></asp:Label>
        <asp:TextBox ID="txtAdvance" runat="server" CssClass="txtBox" ReadOnly="true" Width="100px"></asp:TextBox>
        </td>
    </tr>
    <tr><td colspan="3"><hr /></td></tr>
    <tr>
    <td style="text-align:left;"><asp:Label ID="lblCostCenter" runat="server" CssClass="lbl" Text="Cost Center :"></asp:Label>
    <asp:DropDownList ID="ddlCostCenter" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>
    <asp:Label ID="lblCOA" runat="server" CssClass="lbl" Text="COA :"></asp:Label>
    <asp:DropDownList ID="ddlCOA" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>        
    </td>
    </tr>

    <tr><td colspan="3"><hr /></td></tr>
    <tr>
        <td colspan="3"><asp:Button ID="btnApprove" runat="server" CssClass="nextclick" OnClientClick="ConfirmAll()" Text="Approve" OnClick="btnApprove_Click"></asp:Button></td>
    </tr>
    </table>
    </div>
        
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>