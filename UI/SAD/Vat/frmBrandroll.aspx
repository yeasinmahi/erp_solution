<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBrandroll.aspx.cs" Inherits="UI.SAD.Vat.frmBrandroll" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var txtDemandOrderno = document.forms["frmBandroll"]["txtDemandOrderno"].value;
            var PurDate = document.forms["frmBandroll"]["txtdtedate"].value;
            var txtQty = document.forms["frmBandroll"]["txtQty"].value;           

            if (txtDemandOrderno == null || txtDemandOrderno == "") {
                alert("Please Entry Order No !");
            }

            else if (PurDate == null || PurDate == "") {
                alert("Purchase Date Select !");
            }
            else if (PurDate == null || PurDate == "") {
                alert("Please Select Date !");
            }

            else if (txtQty == null || txtQty == "") {
                alert("Please Fill-up Quantity !");
            }
        
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
</head>
<body>
    <form id="frmBandroll" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> BANDROLL ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                             
        <tr><td>Bandroll</td>
        <td> <asp:DropDownList ID="ddlBandrollList" CssClass="ddList" runat="server" OnSelectedIndexChanged="ddlBandrollList_SelectedIndexChanged"></asp:DropDownList></td>
        <td>Product name </td>
        <td><asp:DropDownList ID="ddlBandrollProduct" CssClass="ddList" runat="server" OnSelectedIndexChanged="ddlBandrollList_SelectedIndexChanged"></asp:DropDownList></td>
        <td>Qty</td>
        <td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>  
        </tr> 
        <tr><td>Demand Order No:</td>
        <td><asp:TextBox ID="txtDemandOrderno" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Date</td>
        <td><asp:TextBox ID="txtdtedate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtedate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
        <td style="margin-left: 40px;text-align:right" colspan="6"><asp:Button ID="btnAdd" runat="server" Text="Add"  OnClientClick="ValidationBasicInfo()" OnClick="btnAdd_Click" /><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        <td colspan="2">&nbsp;</td>                   
       </tr>                                          
       <tr><td colspan="6"><hr /></td></tr>                             
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;"> 
    <tr><td colspan="5" class="auto-style1">PURCHASE REPORT</td>  
    <tr><td>Production Date</td>
        <td><asp:TextBox ID="txtfdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtfdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_123"
        ID="CalendarExtender3" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_123" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
        <td><asp:TextBox ID="txttdate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
        <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txttdate" Format="dd/MM/yyyy" PopupButtonID="imgCal_2"
        ID="CalendarExtender4" runat="server" EnableViewState="true">
        </cc1:CalendarExtender>
        <img id="imgCal_2" src="../../Content/images/img/calbtn.gif" style="border: 0px;
        width: 34px; height: 23px; vertical-align: bottom;" /></td>
    </tr> 
    <tr><td>SUMMARIZED BY</td>
        <td><asp:DropDownList ID="ddlShorby" runat="server">
            <asp:ListItem Value="1">Day</asp:ListItem>
            <asp:ListItem Value="2">Challan</asp:ListItem>
            <asp:ListItem Value="3">Material</asp:ListItem>
            <asp:ListItem Value="4">Material Total</asp:ListItem>
            </asp:DropDownList> </td>
        <td style="text-align:left"><asp:Button ID="btnReport" runat="server" Text="Report" OnClick="btnReport_Click" /></td>
            
     </tr> 
     <tr><td colspan="5" style="text-align:right"></td>                                     
     <tr><td colspan="5"><hr /></td></tr> 
     <tr><td colspan="5"><asp:GridView ID="dgvPurChaseRpt" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical"  OnRowDataBound="dgvProductRpt_RowDataBound"
        >
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px" /><ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
 
        <asp:TemplateField HeaderText="Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldate" runat="server" Text='<%# Bind("dtePurchaseDate","{0:d}") %>' Width="100px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Material Name" SortExpression="itemname">
        <ItemTemplate> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("Column3") %>' Width="200px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Challan/BoE No" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblItemid" runat="server" Text='<%# Bind("Column4") %>' Width="30px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column5","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalQty %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Without SD/Vat" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblSDVATQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column6","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblsdvatTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSDVAT %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="SD" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblsd" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column7","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblsdTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalSD %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="VAT" SortExpression="qty">
        <ItemTemplate><asp:Label ID="lblvatQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column8","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalVAT %>" /></FooterTemplate></asp:TemplateField>



        <asp:TemplateField HeaderText="Amount" SortExpression="value">
        <ItemTemplate><asp:Label ID="lblAmount" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("Column9","{0:n0}") %>' Width="80px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
        <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValue %>" /></FooterTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="Delete"><ItemTemplate> 
        <asp:Button ID="btndelete" ForeColor="Red" runat="server" Text="Delete" CommandName="complete"  OnClick="btnDelete" Font-Bold="true" BackColor="#00ccff"  CommandArgument='<%# Eval("intID")%>' />
        </ItemTemplate> </asp:TemplateField>

        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        <asp:GridView ID="dgvBrandroll" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" 
        OnRowDeleting="dgvPurchase_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
           
        <asp:TemplateField HeaderText="Product Id" SortExpression="itemname">
        <ItemTemplate><asp:HiddenField ID="hdnProductid" Value='<%# Bind("Productid") %>' runat="server" /> <asp:Label ID="lblintItemnames" runat="server" Text='<%# Bind("strItemname") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Product Name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblProductname" runat="server" Text='<%# Bind("Productname") %>' Width="100px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Package" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblpackagetype" runat="server" Text='<%# Bind("packagetype") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="brandroll id" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblbrandrollid" runat="server" Text='<%# Bind("brandrollid") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="brandroll name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblbrandrollname" runat="server" Text='<%# Bind("brandrollname") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("qty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("Remarks") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
        </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
