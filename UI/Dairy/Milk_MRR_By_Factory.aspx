<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Milk_MRR_By_Factory.aspx.cs" Inherits="UI.Dairy.Milk_MRR_By_Factory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Transfer Out </title>
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

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">

        /*===== Quantity Input  ==============================================================================*/
        function Add(txt) {   
            
            var a, isst = 0, b, receiveqty;
            r = txt.value;

            var grandTotal = 0; var grandTotalIssue = 0; grandTotalDed = 0, dedqty1 = 0, dedfat1 = 0, grandTNet1 = 0, issueValue1 = 0;
            $("[id*=lblIssueQtyTotal]").html(0);
            $("[id*=lblIssueQty]").each(function () {
                grandTotalIssue = grandTotalIssue + parseFloat($(this).html());
                isst = grandTotalIssue;
            });
            $("[id*=lblIssueQtyTotal]").html(parseFloat(grandTotalIssue.toString()).toFixed(2));

            $("[id*=lblRecQty]").each(function () {
                var row = $(this).closest("tr");
                
                if (r == "" || r == "0")
                {
                    $("[id*=lblRecQty]", row).val(0);
                    $("[id*=lblDeductQtyAmount]", row).val(0);
                }
                else if (isst <= r)
                {
                    a = parseFloat($("[id*=lblIssueQty]", row).html());

                    //$("[id*=txtAIT]", row).val((rate * parseFloat(txt.value.toString())) / 100);

                    //$("[id*=lblRecQty]", row).html(a);
                    $("[id*=lblRecQty]", row).val(a);
                    $("[id*=lblDeductQtyAmount]", row).val(0);
                }
                else {
                    a = parseFloat($("[id*=lblIssueQty]", row).html());
                    $("[id*=lblRecQty]", row).val((a * (100 - ((isst - r) / isst * 100)) * 0.01).toFixed(2));
                    
                    c = parseFloat($("[id*=lblIssueRate]", row).html());

                    $("[id*=lblDeductQtyAmount]", row).val(((a - (a * (100 - ((isst - r) / isst * 100)) * 0.01)) * c).toFixed(4));
                }

                dedqty1 = parseFloat($("[id*=lblDeductQtyAmount]", row).val());
                dedfat1 = parseFloat($("[id*=lblDeductFatPer]", row).val());
                issuvalcal1 = parseFloat($("[id*=lblIssueValue]", row).html());
                $("[id*=lblNetValue]", row).val((issuvalcal1 - (dedqty1 + dedfat1)).toFixed(2));
            });
            $("[id*=lblRecQtyTotal]").val(0);
            $("[id*=lblRecQty]").each(function () {
                grandTotal = grandTotal + parseFloat($(this).val());
            });
            $("[id*=lblRecQtyTotal]").html(parseFloat(grandTotal.toString()).toFixed(2));

            $("[id*=lblDeductQtyAmountTotal]").val(0);
            $("[id*=lblDeductQtyAmount]").each(function () {
                grandTotalDed = grandTotalDed + parseFloat($(this).val());
            });
            $("[id*=lblDeductQtyAmountTotal]").html(parseFloat(grandTotalDed.toString()).toFixed(2));

            $("[id*=lblNetValueTotal]").val(0);
            $("[id*=lblNetValue]").each(function () {
                grandTNet1 = grandTNet1 + parseFloat($(this).val());
            });
            $("[id*=lblNetValueTotal]").html(parseFloat(grandTNet1.toString()).toFixed(2));
            
            
        }        
        /*===== Quantity Input  ==============================================================================*/

        /*===== Fat % Input  ==============================================================================*/
        function FatPer(fat) {

            var issueValue = 0, isst = 0, d, issfat = 0, isstvalue = 0; deffFatPer = 0, deffValue = 0, defftk = 0, totalissuqty = 0, grandTotalIssueqty = 0, issuvalcal = 0, dedqty = 0, dedfat = 0, grandTNet = 0;
            fatper = fat.value;

            var grandTIssueValue = 0; grandTotalFat = 0;
            $("[id*=lblIssueValueTotal]").html(0);
            $("[id*=lblIssueValue]").each(function () {
                grandTIssueValue = grandTIssueValue + parseFloat($(this).html());
                isstvalue = grandTIssueValue;
            });
            $("[id*=lblIssueValueTotal]").html(parseFloat(grandTIssueValue.toString()).toFixed(2));

            totalissuqty = 0; grandTotalIssueqty = 0; count = 0;
            $("[id*=lblIssueQtyTotal]").html(0);
            $("[id*=lblIssueQty]").each(function () {
                grandTotalIssueqty = grandTotalIssueqty + parseFloat($(this).html());
                totalissuqty = grandTotalIssueqty;
            });
            $("[id*=lblIssueQtyTotal]").html(parseFloat(totalissuqty.toString()).toFixed(2));

            $("[id*=lblDeductFatPer]").each(function () {
                var row = $(this).closest("tr");

                issfat = parseFloat($("[id*=lblIssueFat]", row).html());
                

                if (fatper == issfat) {
                    deffFatPer= 0;
                }
                else if (issfat < fatper) {
                    deffFatPer = 0;
                }
                else if ((issfat - fatper - 0.1) < 0) {
                    deffFatPer = 0;
                }
                else {
                    deffFatPer = (issfat - fatper - 0.1);
                }

                deffValue = (9.4 * deffFatPer * totalissuqty);
                defftk = (isstvalue - deffValue);

                issueValue = parseFloat($("[id*=lblIssueValue]", row).html());
                $("[id*=lblDeductFatPer]", row).val(0);
                $("[id*=lblDeductFatPer]", row).val((issueValue - issueValue * (100 - ((isstvalue - defftk) / isstvalue * 100)) * 0.01).toFixed(2));

                dedqty = parseFloat($("[id*=lblDeductQtyAmount]", row).val());
                dedfat = parseFloat($("[id*=lblDeductFatPer]", row).val());
                //issuvalcal = parseFloat($("[id*=lblIssueValue]", row).html());
                $("[id*=lblNetValue]", row).val((issueValue - (dedqty + dedfat)).toFixed(2));

                if (fatper == "" || fatper == "0")
                {
                    $("[id*=lblDeductFatPer]", row).val(0);
                }
            });
            $("[id*=lblDeductFatPerTotal]").val(0);
            $("[id*=lblDeductFatPer]").each(function () {
                grandTotalFat = grandTotalFat + parseFloat($(this).val());
            });
            $("[id*=lblDeductFatPerTotal]").html(parseFloat(grandTotalFat.toString()).toFixed(2));

            $("[id*=lblNetValueTotal]").val(0);
            $("[id*=lblNetValue]").each(function () {
                grandTNet = grandTNet + parseFloat($(this).val());
            });
            $("[id*=lblNetValueTotal]").html(parseFloat(grandTNet.toString()).toFixed(2));
        }
        /*===== Quantity Input  ==============================================================================*/

</script>        
      
</head>
<body>
    <form id="frmTransferOut" runat="server">        
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
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> MILK MRR<hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>                
                <td style="text-align:right;"><asp:Label ID="lblFromWH" runat="server" CssClass="lbl" Text="Chilling Center :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlChillingCenter" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlChillingCenter_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Vehicle No. :"></asp:Label></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlVehicleNo" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlVehicleNo_SelectedIndexChanged"></asp:DropDownList></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="dteFrom" runat="server" CssClass="lbl" Text="Challan Date :"></asp:Label></td>
                <td style="text-align:left"><asp:TextBox ID="txtFrom" runat="server" CssClass="txtBox1" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="dtpFrom" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                <td colspan="2" style="text-align:right; padding: 7px 0px 0px 0px"><asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" Width="100px" OnClick="btnShow_Click"/></td>        
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" runat="server" Text="Quantity"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtTQuantity" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();" onKeyUp="javascript:Add(this);"></asp:TextBox></td>              
                <td style="text-align:right; width:15px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Fat Percentage"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtTFatPercentage" runat="server" CssClass="txtBox1" onkeypress="return onlyNumbers();" onKeyUp="javascript:FatPer(this);"></asp:TextBox></td>                              
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" runat="server" CssClass="lbl" Text="MRR Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left"><asp:TextBox ID="txtMRRDate" runat="server" CssClass="txtBox1" autocomplete="off"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtMRRDate"></cc1:CalendarExtender></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="CLR"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:TextBox ID="txtCLR" runat="server" CssClass="txtBox1"></asp:TextBox></td>        
            </tr>
            <tr>
                <td colspan="5" style="text-align:right; padding: 7px 0px 0px 0px"><asp:Button ID="btnMRRSave" runat="server" class="myButtonGrey" Text="Submit" Width="100px" OnClientClick="ConfirmAll()" OnClick="btnMRRSave_Click" /></td>
            </tr>
            <tr><td colspan="5"><hr /></td></tr> 
        </table>
        
        <table>
        <tr><td><hr /></td></tr>
        <tr><td>   
            <asp:GridView ID="dgvMRR" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvMRR_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Challan Date Of Chilling Center" SortExpression="dteTransactionDate">
            <ItemTemplate><asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("dteTransactionDate", "{0:yyyy-MM-dd}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Date of Chilling Center" SortExpression="dteReceiveDate">
            <ItemTemplate><asp:Label ID="lblReceiveDate" runat="server" Text='<%#Eval("dteReceiveDate", "{0:yyyy-MM-dd}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Chilling Center Name" SortExpression="strChillingCenterName">
            <ItemTemplate><asp:Label ID="lblChillingCenter" runat="server" Text='<%# Bind("strChillingCenterName") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Supplier Name" SortExpression="strSupplierName">
            <ItemTemplate><asp:Label ID="lblSupplier" runat="server" Text='<%# Bind("strSupplierName") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="150px" /></asp:TemplateField>
                 
            <asp:TemplateField HeaderText="Challan No." SortExpression="strIssueChallanNo">
            <ItemTemplate><asp:Label ID="lblChallanNo" runat="server" Text='<%# Bind("strIssueChallanNo") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="100px" />
            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                       
            <asp:TemplateField HeaderText="Issue Quantity" SortExpression="ReceiveQty">
            <ItemTemplate><asp:Label ID="lblIssueQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("ReceiveQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblIssueQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalissueqty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Fat% (Average)" SortExpression="intOutFatPercent">
            <ItemTemplate><asp:Label ID="lblIssueFat" runat="server" Text='<%# Bind("intOutFatPercent") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Rate (Average)" SortExpression="monOutRate">
            <ItemTemplate><asp:Label ID="lblIssueRate" runat="server" Text='<%# Bind("monOutRate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="center" Width="45px" /></asp:TemplateField>
           
            <asp:TemplateField HeaderText="Issue Value" SortExpression="RecValue">
            <ItemTemplate><asp:Label ID="lblIssueValue" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("RecValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblIssueValueTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalissuevalue %>" /></FooterTemplate></asp:TemplateField>

            <%--<asp:TemplateField HeaderText="Receive Quantity" SortExpression="RecValue">
            <ItemTemplate><asp:Label ID="lblRecQty" runat="server" DataFormatString="{0:0.00}"  Text="0" Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblRecQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalrecqty %>" /></FooterTemplate></asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Receive Quantity" SortExpression="RecValue">
            <ItemTemplate><asp:TextBox ID="lblRecQty" runat="server" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblRecQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalrecqty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Deduct Qty. Amount" SortExpression="RecValue">
            <ItemTemplate><asp:TextBox ID="lblDeductQtyAmount" runat="server" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblDeductQtyAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqtydedamou %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Deduct Fat% Amount" SortExpression="RecValue">
            <ItemTemplate><asp:TextBox ID="lblDeductFatPer" runat="server" DataFormatString="{0:0.00}"  Text="<%# totalfatdedamou %>" Width="80px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblDeductFatPerTotal" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Net Value" SortExpression="RecValue">
            <ItemTemplate><asp:TextBox ID="lblNetValue" runat="server" DataFormatString="{0:0.00}" Text="0" Width="80px"></asp:TextBox>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
            <FooterTemplate><asp:Label ID="lblNetValueTotal" runat="server" DataFormatString="{0:0.00}" Text="0" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="IssueID" Visible="false" SortExpression="intIssueID"><ItemTemplate>            
            <asp:Label ID="lblIssueID" runat="server" Text='<%# Bind("intIssueID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField> 
                
            <asp:TemplateField HeaderText="SupplierID" Visible="false" SortExpression="intSupplierID"><ItemTemplate>            
            <asp:Label ID="lblSupplierID" runat="server" Text='<%# Bind("intSupplierID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                                
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
        </td></tr>  
        </table>      




    </div> 
                
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>