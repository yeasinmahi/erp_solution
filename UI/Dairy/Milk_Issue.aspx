<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_Issue.aspx.cs" Inherits="UI.Dairy.Milk_Issue" %>
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
    <script src="../Content/JS/CustomizeScript.js"></script>

    
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
          
        <div class="tabs_container"> MILK ISSUE FROM <hr /></div>

        <table class="tbldecoration" style="width:auto; float:left;">        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>
            
            <td style="text-align:right;"><asp:Label ID="lblReceiveDate" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>                
            <td ><asp:TextBox ID="txtReceiveDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="210px" autocomplete="off"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReceiveDate"></cc1:CalendarExtender></td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblChillingCenter" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlChillingCenter" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlChillingCenter_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td> 

            <td style="text-align:right;"><asp:Label ID="lblVehicleNo" runat="server" CssClass="lbl" Text="Vehicle No. :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlVehicleNo" CssClass="ddList" Font-Bold="False" runat="server"></asp:DropDownList>                                                                                       
            </td> 
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblChamberNo" runat="server" CssClass="lbl" Text="Chamber No. :"></asp:Label></td>
            <td style="text-align:left;"><asp:TextBox ID="txtChamberNo" runat="server" CssClass="txtBox" Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblAverageFatPercent" runat="server" CssClass="lbl" Text="Fat% (Average) :"></asp:Label></td>
            <td style="text-align:right;"><asp:TextBox ID="txtAverageFatPercent" runat="server" CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
        </tr>
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblIssueQty" runat="server" CssClass="lbl" Text="Total Issue Qty. :"></asp:Label></td>
            <td style="text-align:right;"><asp:TextBox ID="txtTotalIssuQty" runat="server" CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   

            <td style="text-align:right;"><asp:Label ID="lblIssuValue" runat="server" CssClass="lbl" Text="Total Issue Amount :"></asp:Label></td>
            <td style="text-align:right;"><asp:TextBox ID="txtTotalIssuValue" runat="server" CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
        </tr>        
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblTotalBalanceQty" runat="server" CssClass="lbl" Text="Total Balance Qty. :"></asp:Label></td>
            <td style="text-align:right;"><asp:TextBox ID="txtTotalBalanceQty" runat="server" CssClass="txtBox" BackColor="LightGray"  Width="210px"></asp:TextBox></td>                                                   
            
            <%--<td>
                <asp:Label ID="lblhdnGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label>
            </td>--%>

            <td style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShowReport_Click"/></td>            
            <td style="text-align:left;"><asp:Button ID="btnIssue" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Submit"  OnClientClick="ConfirmAll()" OnClick="btnIssue_Click"/></td>            
        </tr>

     </table>
    </div>

    <div id="divFundApproval">          
        <table  class="tbldecoration" style="width:auto; float:left;">  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>

            <tr><td> 
            <asp:GridView ID="dgvIssue" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="None" FooterStyle-BorderStyle="None" FooterStyle-BorderColor="White"
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvIssue_RowDataBound" OnSelectedIndexChanged="dgvIssue_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                      
            <asp:TemplateField HeaderText="Receive Date" SortExpression="rdate"><ItemTemplate>            
            <asp:Label ID="lbldteTransactionDate" runat="server" Text='<%# Bind("rdate") %>' Width="70px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="55px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Supplier Name" SortExpression="supplname"><ItemTemplate>            
            <asp:Label ID="lblSupplierName" runat="server" Text='<%# Bind("supplname") %>' Width="150px"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="250px"/><FooterTemplate><asp:Label ID="lblT" runat="server" Text ="" /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Receive Qty. (Ltr)" ItemStyle-HorizontalAlign="right" SortExpression="recqty" >
            <ItemTemplate><asp:Label ID="lblReceiveQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("recqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalreceive %>' /></FooterTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Previous Issue Qty. (Ltr)" ItemStyle-HorizontalAlign="right" SortExpression="preissuqty" >
            <ItemTemplate><asp:Label ID="lblPreQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("preissuqty"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldmqty" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalpreqty %>' /></FooterTemplate></asp:TemplateField>
            
            <%--<asp:TemplateField HeaderText="Balance Qty. (Ltr)" SortExpression="balanceqty"><ItemTemplate>
            <asp:TextBox ID="txtbalancqty" runat="server" CssClass="blqt" Text='<%# Bind("balanceqty") %>' TextMode="Number" Width="45px"></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="45px" />
            <FooterTemplate><asp:Label ID="lblGrandbalancqty" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label></FooterTemplate></asp:TemplateField>--%>
                
            <%--<asp:BoundField DataField="balanceqty" HeaderText="Balance Qty. (Ltr)" ItemStyle-HorizontalAlign="Center" SortExpression="balanceqty"  ItemStyle-CssClass="balqty">
            <ItemStyle HorizontalAlign="left" Width="50px"/></asp:BoundField>--%>
                        
            <asp:TemplateField HeaderText="Balance Qty. (Ltr)" ItemStyle-HorizontalAlign="right" SortExpression="balanceqty">
            <ItemTemplate><asp:Label ID="lblbalancqty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("balanceqty"))) %>' CssClass="balqty"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalbalanc %>' /></FooterTemplate></asp:TemplateField>            
                            
            <asp:TemplateField HeaderText="Issue Qty." SortExpression="issuqty"><ItemTemplate>
            <asp:TextBox ID="txtIssueQty" runat="server" CssClass="txtBoxGridAmount" Text='<%# Bind("issuqty") %>' DataFormatString="{0:0.00}" Width="45px"></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="45px" />
            <FooterTemplate><asp:Label ID="lblGrandTotalQty" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label></FooterTemplate></asp:TemplateField>
            
            <%--<asp:BoundField DataField="rate" HeaderText="Rate (Average)" ItemStyle-HorizontalAlign="Center" SortExpression="rate"  ItemStyle-CssClass="price">
            <ItemStyle HorizontalAlign="left" Width="40px"/></asp:BoundField>--%>

            <asp:TemplateField HeaderText="Rate (Average)" ItemStyle-HorizontalAlign="right" SortExpression="rate" >
            <ItemTemplate><asp:Label ID="lblRate" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("rate"))) %>' CssClass="price"></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='' /></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Issue Value" ItemStyle-HorizontalAlign="right" SortExpression="issuvalu" >
            <ItemTemplate><asp:Label ID="lblIssueVal" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("issuvalu"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/>
            <FooterTemplate><asp:Label ID="lblGrandTotal" runat="server" DataFormatString="{0:0.00}" Text="0"></asp:Label></FooterTemplate></asp:TemplateField>
                          
            <asp:BoundField DataField="fatper" HeaderText="Calculative Field" ItemStyle-HorizontalAlign="Center" SortExpression="fatper" ItemStyle-CssClass="ftp" ItemStyle-BackColor="White" 
            ItemStyle-BorderStyle="None" FooterStyle-BackColor="White" HeaderStyle-BackColor="White" HeaderStyle-BorderStyle="None" FooterStyle-BorderColor="White" 
            HeaderStyle-ForeColor="White" ItemStyle-BorderColor="White" ItemStyle-BorderWidth="0" FooterStyle-BorderStyle="None">
            <ItemStyle HorizontalAlign="left" BorderColor="White" BorderStyle="None" BackColor="White" ForeColor="White" Width="1px"/></asp:BoundField>
                
            <%--<asp:TemplateField HeaderText="Fat%" ItemStyle-HorizontalAlign="right" SortExpression="fatper" >
            <ItemTemplate><asp:Label ID="lblFatPer" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("fatper"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='' /></FooterTemplate></asp:TemplateField>--%>
                  
            <asp:TemplateField HeaderText="Bill Amount" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="billamount" >
            <ItemTemplate><asp:Label ID="lblBillAmo"  runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("billamount"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" DataFormatString="{0:0.00}" Text ='<%# totalbillamou %>' /></FooterTemplate></asp:TemplateField>
               
            <asp:TemplateField HeaderText="Supplier ID" Visible="false"  ItemStyle-HorizontalAlign="right" SortExpression="suppid" >
            <ItemTemplate><asp:Label ID="lblSuppID" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("suppid"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/><FooterTemplate><asp:Label ID="lbldm" runat="server" Text ='' /></FooterTemplate></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Calculative Field" ItemStyle-Width="1px" ItemStyle-HorizontalAlign="right" SortExpression="avftp" ItemStyle-BackColor="White" 
            ItemStyle-BorderStyle="None" FooterStyle-BackColor="White" HeaderStyle-BackColor="White" HeaderStyle-BorderStyle="None" FooterStyle-BorderColor="White" 
            HeaderStyle-ForeColor="White" ItemStyle-BorderColor="White" ItemStyle-BorderWidth="0">
            <ItemTemplate><asp:Label ID="lblAveFatPer" runat="server" Width="1px" BorderColor="White" ForeColor="White" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("avftp"))) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" BorderStyle="None" Width="1px"/>
            <FooterTemplate></FooterTemplate></asp:TemplateField>
                
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
