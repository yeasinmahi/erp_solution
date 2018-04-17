<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnnualPlan.aspx.cs" Inherits="UI.Projects.Local.AnnualPlan" %>
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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
     </script>
</head>
<body>
    <form id="frmAnnualPlan" runat="server">        
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
    <div class="leaveApplication_container">        
    <table class="tbldecoration" style="width:auto; float:left;">
    <tr class="tblheader"><td colspan="4" style="color:black; text-align:left; font-size:14px"> ANNUAL PLAN ENTRY FORM </td></tr>
    <tr><td colspan="4"><hr /></td></tr>      
    <tr>
        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date:"></asp:Label></td>
        <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px"></asp:TextBox>
        <cc1:CalendarExtender ID="dt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>                                

        <td style="text-align:right;"><asp:Label ID="lblDept" runat="server" CssClass="lbl" Text="Department :"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsDept" DataTextField="Names" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsDept" runat="server" SelectMethod="GetDepartmentList" TypeName="Projects_BLL.Project_Class">
        <SelectParameters><asp:ControlParameter ControlID="hdnUnit" Name="intUnitid" PropertyName="Value" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td>
    </tr>
    <tr>
        <td style="text-align:right;"><asp:Label ID="lblEvent" runat="server" CssClass="lbl" Text="Event :"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlEvent" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsEvent" DataTextField="Names" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsEvent" runat="server" SelectMethod="GetEventList" TypeName="Projects_BLL.Project_Class">
        <SelectParameters><asp:ControlParameter ControlID="hdnUnit" Name="intUnitid" PropertyName="Value" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td>

        <td style="text-align:right;"><asp:Label ID="lblLocation" runat="server" CssClass="lbl" Text="Location :"></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="txtLocation" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td> 
    </tr>
    <tr>
        <td style="text-align:right;"><asp:Label ID="lblType" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlType" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" DataSourceID="odsType" DataTextField="Names" DataValueField="ID" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="GetEventTypeList" TypeName="Projects_BLL.Project_Class"></asp:ObjectDataSource></td>

        <td style="text-align:right;"><asp:Label ID="lblBrand" runat="server" CssClass="lbl" Text="Brand :"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlBrand" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsBrand" DataTextField="Names" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsBrand" runat="server" SelectMethod="GetBrandList" TypeName="Projects_BLL.Project_Class"></asp:ObjectDataSource></td>
    </tr>
    <tr><td colspan="4"><hr /></td></tr>  
    <tr>
        <td style="text-align:right;"><asp:Label ID="lblActivityList" runat="server" CssClass="lbl" Text="Activity List :"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlActivity" CssClass="ddList" Font-Bold="False" runat="server" DataSourceID="odsActivity" DataTextField="Names" DataValueField="ID"></asp:DropDownList>
        <asp:ObjectDataSource ID="odsActivity" runat="server" SelectMethod="GetActivityList" TypeName="Projects_BLL.Project_Class">
        <SelectParameters><asp:ControlParameter ControlID="ddlType" Name="intEventTypeid" PropertyName="SelectedValue" Type="Int32" />
        <asp:ControlParameter ControlID="hdnUnit" Name="intUnitid" PropertyName="Value" Type="Int32" /></SelectParameters></asp:ObjectDataSource></td>

        <td style="text-align:right;"><asp:Label ID="lblAmount" runat="server" CssClass="lbl" Text="Amount :"></asp:Label></td>
        <td style="text-align:left;"><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox" Width="160px" onkeypress="return onlyNumbers();"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" CssClass="nextclick" Text="Add" Width="30px" OnClick="btnAdd_Click"/></td>        
    </tr>
    <tr>
        <td colspan="4"> 
        <asp:GridView ID="dgvActivity" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" 
        FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvActivity_RowDataBound" 
        OnRowDeleting="dgvActivity_RowDeleting"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                            
        <asp:TemplateField HeaderText="Activity id" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="activityid" >
        <ItemTemplate><asp:Label ID="lblActivityid" runat="server" Text='<%# (""+Eval("activityid")) %>'></asp:Label></ItemTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Activity" SortExpression="activity"><ItemTemplate>            
        <asp:Label ID="lblActivity" runat="server" Text='<%# Bind("activity") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="400px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="Total" /></FooterTemplate></asp:TemplateField>
            
        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="right" SortExpression="amount" >
        <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("amount"))) %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="right" Width="90px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalactivity %>' /></FooterTemplate></asp:TemplateField>
                
        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView></td>
    </tr> 
    <tr>
        <td colspan="4"><asp:Button ID="btnSubmit" runat="server" CssClass="nextclick" OnClientClick="ConfirmAll()" Text="Submit" OnClick="btnSubmit_Click"/></td>        
    </tr>
    </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>