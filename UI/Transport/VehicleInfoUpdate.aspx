<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleInfoUpdate.aspx.cs" Inherits="UI.Transport.VehicleInfoUpdate" %>

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
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
          
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
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> CUSTOMER WISE ROUTE COST UPDATE FORM<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

                    
        </tr>

        </table>

        </div>

        <div>
            <table class="tbldecoration" style="width:auto; float:left;">
                <tr><td> <hr /></td></tr>
                <tr><td style="font-weight:bold; font-size:11px; color:#3369ff;">REPORT FOR UPDATE<hr /></td></tr>
                <tr>
                    <td><asp:GridView ID="dgvTripWiseCustomer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                    <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px" /><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" SortExpression="intID"><ItemTemplate>
                    <asp:Label ID="lblid" runat="server" Text='<%# Bind("intID") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                          
                    <asp:TemplateField HeaderText="Reg. No" ><ItemTemplate>
                    <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("strRegNo") %>' Width="120px"></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="Type" ><ItemTemplate>
                    <asp:Label ID="lblType" runat="server" Text='<%# Bind("strType") %>' Width="75px"></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="TypeId" SortExpression="intTypeId" Visible="false"><ItemTemplate>
                    <asp:Label ID="lblTypeId" runat="server" Text='<%# Bind("intTypeId") %>'></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName"><ItemTemplate>
                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtBox" Text='<%# Bind("strEmployeeName") %>' Width="100px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Driver Enroll" SortExpression="intDriverEnroll"><ItemTemplate>
                    <asp:TextBox ID="txtDriverEnroll" runat="server" CssClass="txtBox" Text='<%# Bind("intDriverEnroll") %>' TextMode="Number" Width="50px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                             
                    <asp:TemplateField HeaderText="Driver DA" SortExpression="driverDA"><ItemTemplate>
                    <asp:TextBox ID="txtdriverDA" runat="server" CssClass="txtBox" Text='<%# Bind("driverDA") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Helper" SortExpression="helper"><ItemTemplate>
                    <asp:TextBox ID="txthelper" runat="server" CssClass="txtBox" Text='<%# Bind("helper") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Helper DA" SortExpression="helperDA"><ItemTemplate>
                    <asp:TextBox ID="txthelperDA" runat="server" CssClass="txtBox" Text='<%# Bind("helperDA") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Trip Bonus" SortExpression="monTripBonus"><ItemTemplate>
                    <asp:TextBox ID="txtTripBonus" runat="server" CssClass="txtBox" Text='<%# Bind("monTripBonus") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Diesel PerKM" SortExpression="monDieselPerKM"><ItemTemplate>
                    <asp:TextBox ID="txtDieselPerKM" runat="server" CssClass="txtBox" Text='<%# Bind("monDieselPerKM") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Diesel PerKM OutStation" SortExpression="monDieselPerKMOutStation"><ItemTemplate>
                    <asp:TextBox ID="txtDieselPerKMOutStation" runat="server" CssClass="txtBox" Text='<%# Bind("monDieselPerKMOutStation") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="CNG PerKM" SortExpression="monCNGPerKM"><ItemTemplate>
                    <asp:TextBox ID="txtCNGPerKM" runat="server" CssClass="txtBox" Text='<%# Bind("monCNGPerKM") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="CNG PerKM OutStation" SortExpression="monCNGPerKMOutStation"><ItemTemplate>
                    <asp:TextBox ID="txtCNGPerKMOutStation" runat="server" CssClass="txtBox" Text='<%# Bind("monCNGPerKMOutStation") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Down Trip DA" SortExpression="DownTripDA"><ItemTemplate>
                    <asp:TextBox ID="txtDownTripDA" runat="server" CssClass="txtBox" Text='<%# Bind("DownTripDA") %>'  Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="CNG Allowance" SortExpression="monCNGAllowance"><ItemTemplate>
                    <asp:TextBox ID="txtCNGAllowance" runat="server" CssClass="txtBox" Text='<%# Bind("monCNGAllowance") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Millage Allow 100KM" SortExpression="monMillageAllow100KM"><ItemTemplate>
                    <asp:TextBox ID="txtMillageAllow100KM" runat="server" CssClass="txtBox" Text='<%# Bind("monMillageAllow100KM") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Millage Allow 100KM Above" SortExpression="monMillageAllow100KMAbove"><ItemTemplate>
                    <asp:TextBox ID="txtMillageAllow100KMAbove" runat="server" CssClass="txtBox" Text='<%# Bind("monMillageAllow100KMAbove") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>
                                
                    <asp:TemplateField HeaderText="Millage Allowance Local" SortExpression="monMillageAllowanceLocal"><ItemTemplate>
                    <asp:TextBox ID="txtMillageAllowanceLocal" runat="server" CssClass="txtBox" Text='<%# Bind("monMillageAllowanceLocal") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    <asp:TemplateField HeaderText="Millage Allowance Out Station" SortExpression="monMillageAllowanceOutStation"><ItemTemplate>
                    <asp:TextBox ID="txtMillageAllowanceOutStation" runat="server" CssClass="txtBox" Text='<%# Bind("monMillageAllowanceOutStation") %>' Width="45px"></asp:TextBox></ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45px" /></asp:TemplateField>

                    </Columns>
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td>
                </tr>
                <tr style="background-color:lightgray">
                    <td><asp:Button ID="btnUpdate" runat="server" class="nextclick" Font-Bold="true" ForeColor="Green" Text="Update" OnClientClick="ConfirmAll()" OnClick="btnUpdate_Click" /></td>
                </tr>
            </table>
        </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
