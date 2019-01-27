<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsumpReport.aspx.cs" Inherits="UI.SCM.ConsumpReport" %>

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

   <script>
     function Print() {
         document.getElementById("btnprint").style.display = "none"; window.print(); self.close();
     }
    </script> 
   <!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
    gtag('config', 'UA-125570863-1');
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
    
       <div class="tabs_container" style="text-align:left; background-color:white"><hr /></div>
           <table style="width:600px"> 
                <tr><td colspan="2" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
                <tr>   
                <td><asp:Image ID="imgUnit" runat="server"   /></td>
                <td style="text-align:center; font-size:medium; font-weight:bold; font:u" ><asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                </tr>
                <tr> 
                <td></td>
                <td  style="text-align:center"><asp:DropDownList ID="ddlWh" Font-Size="Small" CssClass="ddList"  Font-Bold="true" runat="server" Font-Underline="true" OnSelectedIndexChanged="ddlWh_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
               
                <tr> 
                <td></td>
                <td  style="text-align:center"><asp:Label ID="lblbill" Font-Size="Small" Font-Bold="true" Text="Comsump. Statement Report" runat="server"></asp:Label></td>
                </tr>
               
                <tr><td></td></tr>
              </table> 
       <table>
        <tr> 
           <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server"  autocomplete="off" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server" autocomplete="off"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
            </cc1:CalendarExtender> </td> 

        </tr> 
           <tr>
                <td  style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Filter By"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlFilter" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"       >
        
         </asp:DropDownList><asp:Button ID="btnFilterDept" runat="server" Text="Show" OnClick="btnFilterDept_Click"    /></td>                                                                                      
         

        <td  style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Section"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlSection" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"  ></asp:DropDownList>
            <asp:Button ID="btnSection" runat="server" Text="Show" OnClick="btnShow_Click"   />
        </td>                                                                                      
     
           </tr>
           <tr>
                
                <td colspan="4" style="text-align:right;"></td>
           </tr>
       </table>
       <table> 
         <tr> 
            <td><asp:GridView ID="dgvConsump" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="700px"  CssClass="GridViewStyle">   
            <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
  
            <asp:TemplateField HeaderText="Product Name" SortExpression="strItem"><ItemTemplate>
            <asp:Label ID="lblItem" runat="server" Width="300px" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>
                
            <asp:TemplateField HeaderText="Uom" Visible="true" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
              
            <asp:TemplateField HeaderText="Sub Category" ItemStyle-HorizontalAlign="right" SortExpression="strSubCategory" >
            <ItemTemplate><asp:Label ID="lblSubcegory" runat="server"  Width="90px" Text='<%# Bind("strSubCategory") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Used Qty" ItemStyle-HorizontalAlign="right" SortExpression="usedQty" >
            <ItemTemplate><asp:Label ID="lblUsedQty" runat="server" Width="150px"  Text='<%# Bind("usedQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>

            <asp:TemplateField HeaderText="Used Value" ItemStyle-HorizontalAlign="right" SortExpression="usedValue" >
            <ItemTemplate><asp:Label ID="lblUsedValue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("usedValue","{0:n2}") %>'></asp:Label></ItemTemplate>
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
