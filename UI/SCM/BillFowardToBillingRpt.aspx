<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillFowardToBillingRpt.aspx.cs" Inherits="UI.SCM.BillFowardToBillingRpt" %>

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
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
    <%--<link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />--%> 
  
    <script type="text/javascript">
       
    $("[id*=txtReturnQty]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') { 
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var poqty = parseFloat($("[id*=lblPoQty]", row).html());
                    var returnQty = parseFloat($(this).val());
                 
                    if (poqty > returnQty) {
                         $("[id*=txtReturnQty]", row).val('0');
                        
                       alert('Please Return Qty Grather then Po Qty');
                    }
                    else {
                      
                    }
                    

                }
            } else {
                $(this).val('');
            } 

        });
    </script>
   
    <script type="text/javascript"> 
        function funConfirmAll() { 
        var confirm_value = document.createElement("INPUT"); 
        confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
        if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
        else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        } 
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
    
       <div class="tabs_container" style="text-align:left"><hr /></div>
           <table style="width:700px"> 
                <tr><td colspan="2" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
                <tr>   
                <td><asp:Image ID="imgUnit" runat="server"   /></td>
                <td style="text-align:center; font-size:medium; font-weight:bold; font:u" ><asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                </tr>
                <tr> 
                <td></td>
                <td  style="text-align:center"><asp:Label ID="lblWHs" Font-Size="Small" Font-Bold="true" runat="server" Font-Underline="true"></asp:Label></td>
                </tr>
               
                <tr> 
                <td></td>
                <td  style="text-align:center"><asp:Label ID="lblbill" Font-Size="Small" Font-Bold="true" Text="Bill Forward List for Billing Department' Performance Report" runat="server"></asp:Label></td>
                </tr>
               
                <tr><td></td></tr>
              </table> 
       <table>
        <tr> 
        <td  style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"     >
        <asp:ListItem Text="Local"></asp:ListItem> <asp:ListItem Text="Fabrication"></asp:ListItem> <asp:ListItem Text="Import"></asp:ListItem>
         </asp:DropDownList></td>                                                                                      
         

        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"     ></asp:DropDownList></td>                                                                                      
         
        <td><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click"   /></td>
        
        </tr>  
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvBill" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="800px"  CssClass="GridViewStyle">   
            <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
            <asp:TemplateField HeaderText="PONO" SortExpression="intPo"><ItemTemplate>
            <asp:Label ID="lblPo" runat="server" Width="60px" Text='<%# Bind("intPo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
            <asp:TemplateField HeaderText="PO Date" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="poDate" >
            <ItemTemplate><asp:Label ID="lblPodate" runat="server"  Text='<%# Bind("poDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
              
            <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="right" SortExpression="strSupplier" >
            <ItemTemplate><asp:Label ID="lblSupplier" runat="server"  Width="150px" Text='<%# Bind("strSupplier") %>'></asp:Label></ItemTemplate>
            
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO Amount" ItemStyle-HorizontalAlign="right" SortExpression="monPOamount" >
            <ItemTemplate><asp:Label ID="lblPOamount" runat="server" Width="50px"  Text='<%# Bind("monPOamount") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

            <asp:TemplateField HeaderText="MRR Amount" ItemStyle-HorizontalAlign="right" SortExpression="monmrrAmount" >
            <ItemTemplate><asp:Label ID="lblMrrAmount" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monmrrAmount") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="PO Issuer" ItemStyle-HorizontalAlign="right" SortExpression="strPOIssuer" >
            <ItemTemplate><asp:Label ID="lblPOIsser" runat="server" Text='<%# Bind("strPOIssuer") %>'  ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            </Columns> 
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
