<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BandrollReceive.aspx.cs" Inherits="UI.VAT_Management.BandrollReceive" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Treasury Entry </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />
    
</head>
<body>
    <form id="frmProductionEntry" runat="server">        
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
    <asp:HiddenField ID="hdnVatAccID" runat="server" /><asp:HiddenField ID="hdnysnFactory" runat="server" />
          
    <div class="divbody" style="padding-right:10px;">
        
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" CssClass="lbl" Text="VAT Account :"></asp:Label></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlVatAccount" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVatAccount_SelectedIndexChanged"></asp:DropDownList>                                                                                       
                </td>
            </tr>
            <tr><td colspan="8"><hr /></td></tr> 
            <tr><td colspan="8" style="text-align:center; padding: 0px 0px 5px 0px;"><asp:Label ID="lblVatAccount" runat="server" Text="" CssClass="lbl" Font-Size="20px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            <tr><td colspan="8" style="text-align:center; padding: 0px 0px 20px 0px;"><asp:Label ID="lblHeading" runat="server" Text="Bandroll Receive Entry" CssClass="lbl" Font-Size="16px"></asp:Label></td></tr>
               
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Bandroll :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlBandroll" CssClass="ddList" Font-Bold="False" runat="server" height="23px" width="310px"></asp:DropDownList>                              
                </td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="Dem. Order No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDemOrderNo" runat="server" CssClass="txtBox1" Width="130px"></asp:TextBox></td>             
                <td style="text-align:right; width:15px;"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label11" runat="server" Text="Date :" CssClass="lbl"></asp:Label></td>               
                <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="130px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="Delivery Order No :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtDeliveryOrderNo" runat="server" CssClass="txtBox1" Width="100px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="DO Date :" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="txtDODate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="130px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDODate"></cc1:CalendarExtender></td> 
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Receive Date :" CssClass="lbl"></asp:Label></td>               
                <td><asp:TextBox ID="txtReceiveDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="130px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReceiveDate"></cc1:CalendarExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Quantity :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtQuantity" runat="server" CssClass="txtBox1" Width="130px"></asp:TextBox></td>             
            </tr>
            <tr>
                <td colspan="6" style="text-align:right; padding: 10px 20px 10px 0px;"><asp:Button ID="btnAdd" runat="server" class="myButton" Text="ADD" OnClick="btnAdd_Click"/></td>
                <td colspan="2" style="text-align:right; padding: 10px 0px 10px 0px;"><asp:Button ID="btnSaveReceive" runat="server" class="myButton" Text="Save Receive" OnClientClick = "ConfirmAll()"/></td>
            </tr>
         </table>
        <table>
            <tr><td><hr /></td></tr>
            <tr><td>   
                <asp:GridView ID="dgvBandrollReceive" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                ShowFooter="true"  HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvBandrollReceive_RowDeleting" OnRowDataBound="dgvBandrollReceive_RowDataBound">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="35px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                <asp:TemplateField HeaderText="Bandroll ID" SortExpression="brid">
                <ItemTemplate><asp:Label ID="lblBandrollID" runat="server" Text='<%# Bind("brid") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Bandroll Name" SortExpression="brname">
                <ItemTemplate><asp:Label ID="lblBandrollName" runat="server" Text='<%# Bind("brname") %>' Width="250px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>
                
                <asp:TemplateField HeaderText="Dem.O No" SortExpression="demno">
                <ItemTemplate><asp:Label ID="lblDemONo" runat="server" Text='<%# Bind("demno") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Dem.O Date" SortExpression="demdate">
                <ItemTemplate><asp:Label ID="lblDemODate" runat="server" Text='<%# Bind("demdate") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="DO No" SortExpression="dono">
                <ItemTemplate><asp:Label ID="lblDONo" runat="server" Text='<%# Bind("dono") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="DO Date" SortExpression="dodate">
                <ItemTemplate><asp:Label ID="lblDODate" runat="server" Text='<%# Bind("dodate") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Receive Date" SortExpression="recdate">
                <ItemTemplate><asp:Label ID="lblReceiveDate" runat="server" Text='<%# Bind("recdate") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/>
                <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Receive Qty" SortExpression="recqty">
                <ItemTemplate><asp:Label ID="lblReceiveQty" runat="server" Text='<%# Bind("recqty") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/>
                <FooterTemplate><asp:Label ID="lblRceQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# rceqtygrandtotal %>" /></FooterTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" /> 

                </Columns>
                <FooterStyle Font-Size="11px" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr> 
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>