<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vehicle_Loan_EMI.aspx.cs" Inherits="UI.SAD.Corporate_sales.Claim_Settlement.Vehicle_Loan_EMI" %>

    <!DOCTYPE html>
    <html>
    <head runat="server">
    <title>Vehicle EMI</title>
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
    <style>.hidden {display:none}</style>
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
   <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
<%--=========================================Start My Code From Here===============================================--%>
    <div style="width:100%">
    <h3 class="td">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Vehicle Loan Details</h3>      
    <table style="width:60%">
    <tr style="height:15px">
    <td style="padding:0 0 0 500px">     
    <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" Width="70px" />
    &nbsp;</td></tr></table>    
    </div> 
    <table class="" style="width:100%; height:2px ">  
    <tr style="width:100%" >       
    <td style="text-align:justify;font-size:12px; background-color:white;">
    <p class="MsoNormal">
    <asp:GridView ID="gvdistlist" runat="server" AutoGenerateColumns="False"  Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" FooterStyle-HorizontalAlign="Right" 
    BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" ShowFooter="false">
    <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:TemplateField HeaderText="SL." ><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="50px"/></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer ID" SortExpression="icustid"><ItemTemplate>
    <asp:Label ID="lblintcustomerid" runat="server" Text='<%# Bind("icustid") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="COA ID" SortExpression="icustcoaid" HeaderStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" ControlStyle-CssClass="hidden"><ItemTemplate>
    <asp:Label ID="lblintCOAid" runat="server" Text='<%# Bind("icustcoaid") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Cust Name" SortExpression="scustname" ><ItemTemplate>
    <asp:Label ID="lblstrCustName" runat="server" Text='<%# Bind("scustname") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="300px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Vehicle ID" SortExpression="ipaymentid" HeaderStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" ControlStyle-CssClass="hidden"><ItemTemplate>
    <asp:Label ID="lblintvehiclepaymentid" runat="server" Text='<%# Bind("ipaymentid","{0:d}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Loan ID" SortExpression="icustidl"><ItemTemplate>
    <asp:Label ID="lblintCustloanid" runat="server" Text='<%# Bind("icustidl") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Loan CoID" SortExpression="icustcoaidl" HeaderStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ItemStyle-CssClass="hidden" ControlStyle-CssClass="hidden"><ItemTemplate>
    <asp:Label ID="lblintCustloanCOid" runat="server" Text='<%# Bind("icustcoaidl","{0:d}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Customer Loan name" SortExpression="strvehiclename"><ItemTemplate>
    <asp:Label ID="lblstrCustloanname" runat="server" Text='<%# Bind("scustnamel") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="300px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>    
    <asp:TemplateField HeaderText="Delivery Date" SortExpression="dtdeliverydate"><ItemTemplate>
    <asp:Label ID="lbldtdeliverydate" runat="server" Text='<%# Bind("dtdeliverydate","{0:d}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>
    <asp:TemplateField HeaderText="Price" SortExpression="monvehicleprice"><ItemTemplate>
    <asp:Label ID="lblmonvehicleprice" runat="server" Text='<%# Bind("monvehicleprice","{0:n0}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>   
    <asp:TemplateField HeaderText="Loan Period" SortExpression="monloanperiod"><ItemTemplate>
    <asp:Label ID="lblmonloanperiod" runat="server" Text='<%# Bind("monloanperiod","{0:n0}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>        
    <asp:TemplateField HeaderText="Monthly Instalment" SortExpression="monemi"><ItemTemplate>
    <asp:Label ID="lblmonemi" runat="server" Text='<%# Bind("monemi","{0:n0}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>         
    <asp:TemplateField HeaderText="Total Paid" SortExpression="monemi"><ItemTemplate>
    <asp:Label ID="lblpaid" runat="server" Text='<%# Bind("paid","{0:n0}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>        
    <asp:TemplateField HeaderText="Total Due" SortExpression="due"><ItemTemplate>
    <asp:Label ID="lbldue" runat="server" Text='<%# Bind("due","{0:n0}") %>'></asp:Label></ItemTemplate>
    <ItemStyle HorizontalAlign="Left"  Height="5px" Width="100px"/><FooterTemplate>
    </FooterTemplate></asp:TemplateField>              
    </Columns>
    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    </asp:GridView></p></td></tr> 
    <tr style="text-align:justify">
    <td style="padding:0 0 0 500px">
    <asp:Button ID="get" runat="server" Text="Get All EMI" OnClick="get_Click"  /></td>
    </tr></table>
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </body>
    </html>
