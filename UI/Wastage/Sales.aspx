<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="UI.Wastage.Sales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
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

    <script type="text/javascript">

    //lblGrandTotalAvFatPer, lblAveFatPer
    //if (isNaN(a) == true) { a = 0;}
    $(function () {
        $("[id*=txtIssueQty]").val("0");      
    });

    $("[id*=txtIssueQty]").live("change", function () {
        if (isNaN(parseFloat($(this).val()))) {
            $(this).val('0');
        } else { $(this).val(parseFloat($(this).val()).toString()); }
    });

    $("[id*=txtIssueQty]").live("keyup", function () {
        if (!jQuery.trim($(this).val()) == '') {
            if (!isNaN(parseFloat($(this).val()))) {
                var row = $(this).closest("tr");
                //lblGrandbalancqty
                //$("[id*=lblTotal]", row).html(parseFloat($("[id*=txtUnitprice]", row).html()) * parseFloat($(this).val()));

                if ((parseFloat($(".balqty", row).html()) < parseFloat($(this).val()))) {
                //if ((parseFloat($(".blqt", row).html()) < parseFloat($(this).val()))) {
                    $(this).val('0');
                    $("[id*=lblIssueVal]", row).html((parseFloat($(".price", row).html()) * 0).toFixed(0));
                    $("[id*=lblAveFatPer]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                    alert("Please Check Quantity.");
                } else {

                    $("[id*=lblIssueVal]", row).html((parseFloat($(".price", row).html()) * parseFloat($(this).val())).toFixed(0));
                    $("[id*=lblAveFatPer]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                    $("[id*=Label1]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                                        
                }

            }
        } else { $(this).val(''); }

        var grandTotal = 0;
        var grandTotalqty = 0;
        var grandTotalftp = 0;
        var gtblqt = 0;
        
        $("[id*=lblIssueVal]").each(function () {
            grandTotal = grandTotal + parseFloat($(this).html());
        });
        $("[id*=lblGrandTotal]").html(grandTotal.toString());
        document.getElementById("txtTotalIssuValue").value = grandTotal;

        $("[id*=txtIssueQty]").each(function () {
            grandTotalqty = grandTotalqty + parseFloat($(this).val());
        });
        $("[id*=lblGrandTotalQty]").html(grandTotalqty.toString());
        document.getElementById("txtTotalIssuQty").value = grandTotalqty;

        $("[id*=lblAveFatPer]").each(function () {
            grandTotalftp = grandTotalftp + parseFloat($(this).html());
        });

        $("[id*=lblbalancqty]").each(function () {
            gtblqt = gtblqt + parseFloat($(this).html());
        });        
        document.getElementById("txtTotalBalanceQty").value = (gtblqt - grandTotalqty).toFixed(2);
        document.getElementById("txtAverageFatPercent").value = (grandTotalftp / grandTotalqty).toFixed(2);

        document.getElementById("txtTotalBalanceQty").readOnly = true;
        document.getElementById("txtAverageFatPercent").readOnly = true;
        document.getElementById("txtTotalIssuQty").readOnly = true;
        document.getElementById("txtTotalIssuValue").readOnly = true;
                

    });
    
</script>
        
</head>
<body>
    <form id="frmLoanApplication" runat="server">        
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
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> SALES<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="WH Name"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList>                                                                                       
                </td>
                <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Sales Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td><asp:TextBox ID="txtSalesDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSalesDate"></cc1:CalendarExtender></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Sales Order No."></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlSalesOrderNo" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Customer Name :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Sales Order Date :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
                <td style="text-align:right; "><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="MR No. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Location"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlLocation" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td> 
                <td style="text-align:right; "><asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="Delivery Challan No. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="TextBox4" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td> 
            </tr>           
            <tr>
                <td colspan="5" style="text-align:right; padding: 15px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>        
            </tr>
            <tr><td colspan="5"><hr /></td></tr>
        </table>
    </div>
    <table>
        <tr><td><hr /></td></tr>
        <tr><td>   
            <asp:GridView ID="dgvSOItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvSOItem_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Item ID" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblItemID" runat="server" Text='<%# Bind("itemid") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Sales ID" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblSalesID" runat="server" Text='<%# Bind("itemid") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Item Name" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblItemName" runat="server" Text='<%# Bind("itemname") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("uom") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                                
            <asp:TemplateField HeaderText="S. Order Qty" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblSOQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Issued Qty" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblIssuedQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Sales Rate" ItemStyle-HorizontalAlign="right" SortExpression="rate" >
            <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("rate"))) %>' CssClass="price"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='' /></FooterTemplate></asp:TemplateField>
              

            <asp:TemplateField HeaderText="Value" SortExpression="value">
            <ItemTemplate><asp:Label ID="lblValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("value") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
<%--            <FooterTemplate><asp:Label ID="lblValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalvalue %>" /></FooterTemplate>--%></asp:TemplateField>

            <asp:TemplateField HeaderText="Balance Qty" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblBalanceQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Available Qty" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblAvailableQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("qty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Remarks" SortExpression="remarks">
            <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("remarks") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Qty." SortExpression="issuqty"><ItemTemplate>
            <asp:TextBox ID="txtIssueQty" runat="server" CssClass="txtBoxGridAmount" Text='<%# Bind("issuqty") %>' DataFormatString="{0:0.00}" Width="60px"></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="60px" />
            <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Issue Value" ItemStyle-HorizontalAlign="right" SortExpression="issuvalu" >
            <ItemTemplate><asp:Label ID="lblIssueVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("issuvalu"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/>
            <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label></FooterTemplate></asp:TemplateField>
                          

            <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </td></tr>  
        <tr><td><hr /></td></tr> 
        <tr>
            <td style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Submnit" OnClick="btnSubmit_Click" /></td>        
        </tr>
    </table>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>