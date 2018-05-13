<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCustomerBridge.aspx.cs" Inherits="UI.Wastage.frmCustomerBridge" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html>
<head runat="server">
    <title>::. Customer Bridge .:: </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
    
</head>
<body>
    <form id="frmCustomerBridge" runat="server">        
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
    <asp:HiddenField ID="hdnLoanID" runat="server" />      
    <div class="divbody" style="padding-right:10px;">
      <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> CUSTOMER CREATE &amp; BRIDGE<hr /></div>               
        <table>
        <tr><td><asp:RadioButton ID="rdnItem" AutoPostBack="true" Text="Item" GroupName="itemCust" runat="server" OnCheckedChanged="rdnItem_CheckedChanged" />
            <asp:RadioButton ID="rdnCust" AutoPostBack="true" Text="Customer" GroupName="itemCust" runat="server" OnCheckedChanged="rdnCust_CheckedChanged" /></td>
        </tr>               
        <tr><td>
        <asp:Panel ID="Panel1" runat="server">
        <table class="tbldecoration" style="width:auto; float:left;">
          <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlUnitCust" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
            </td>
            <td style="text-align:right; ">&nbsp;</td>
            <td style="text-align:right;">&nbsp;</td>                
            <td>&nbsp;</td>
            </tr>
          <tr>
            <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Customer Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"><asp:TextBox ID="txtCustName" runat="server" CssClass="txtBox1"  BackColor="WhiteSmoke"></asp:TextBox> </td>
            <td style="text-align:left;"><asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span> </td>
            <td style="text-align:left;"><asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox1"  BackColor="WhiteSmoke"></asp:TextBox> </td>
            <td style="text-align:right; ">&nbsp;</td>
            <td style="text-align:right;"><span style="color:red; font-size:14px;">*</span><span> </span></td>                
            <td>&nbsp;</td>
           </tr>
          <tr>
            <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Phone No"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"> <asp:TextBox ID="txtPhone" runat="server" CssClass="txtBox1"  BackColor="WhiteSmoke"></asp:TextBox></td>
            <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text="COA Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span> </td>
            <td style="text-align:right;"><asp:DropDownList ID="ddlCOAName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>                
            <td></td>
            </tr>
          <tr>
            <td style="text-align:right;" colspan="4"><asp:Button ID="btnCustSave" runat="server" class="myButtonGrey"  Text="Save" OnClick="btnCustSave_Click"/> &nbsp <asp:Button ID="btnCustReport" runat="server" class="myButtonGrey"  Text="Show" OnClick="btnCustReport_Click"/></td>              
          </tr> 
          <tr>
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Customer Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"> <asp:DropDownList ID="ddlcustlist" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
            <td style="text-align:right; "><span style="color:red; font-size:14px;">*</span><span> </span> </td>
            <td style="text-align:right;"><asp:Button ID="btnUpdate" runat="server" class="myButtonGrey"  Text="Update" OnClick="btnUpdate_Click"/> </td>                
            <td></td>
           </tr>
        </table>
        </asp:Panel>
        </td></tr>
        <tr><td>
        <table><tr><td>
            <asp:Panel ID="Panel2" runat="server">
            <asp:GridView ID="dgvCustomerList" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Customer Name" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblstrCustomerName" runat="server" Text='<%# Bind("strCustomerName") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Cust Address" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblCustAddress" runat="server" Text='<%# Bind("strCustAddress") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Phone" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblPhone" runat="server" Text='<%# Bind("strPhone") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="COA Name" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblCOAName" runat="server" Text='<%# Bind("strCOAName") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

           </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView> </asp:Panel></td>
            </tr>
        </table>
        </td></tr>
        </table> 
     </div>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>