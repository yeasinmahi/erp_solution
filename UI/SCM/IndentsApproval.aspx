<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentsApproval.aspx.cs" Inherits="UI.SCM.IndentsApproval" %>

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
     <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function CloseHdnDiv() {
             $("#hdnDivision").fadeOut("slow"); 
         }
    </script>
  <script type="text/javascript">
         $("[id*=chkHeader]").live("click", function () {
             var chkHeader = $(this);
             var grid = $(this).closest("table");
             $("input[type=checkbox]", grid).each(function () {
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     $("td", $(this).closest("tr")).addClass("selected");
                 } else {
                     $(this).removeAttr("checked");
                     $("td", $(this).closest("tr")).removeClass("selected");
                 }
             });
         });
         $("[id*=chkRow]").live("click", function () {
             var grid = $(this).closest("table");
             var chkHeader = $("[id*=chkHeader]", grid);
             if (!$(this).is(":checked")) {
                 $("td", $(this).closest("tr")).removeClass("selected");
                 chkHeader.removeAttr("checked");
             } else {
                 $("td", $(this).closest("tr")).addClass("selected");
                 if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                     chkHeader.attr("checked", "checked");
                 }
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

  
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left: 70px;  margin-top:00px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        </style>
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
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Indent Approval  From<hr /></div>
         
       <table>
            <tr> <td colspan="3" style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"   ></asp:DropDownList></td>                                                                                      
            </tr>

            <tr> 
            <td style="text-align:left;"><asp:Label ID="lblAPproval" runat="server" CssClass="lbl" Text="Approval"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlApproval" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlApproval_SelectedIndexChanged">
            <asp:ListItem Value="1">Pending</asp:ListItem><asp:ListItem Value="2" >Approve</asp:ListItem><asp:ListItem Value="3">Reject</asp:ListItem> </asp:DropDownList></td>  
                         
            <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
            </cc1:CalendarExtender> </td>
            </tr>

            <tr>
            <td colspan="6" style="text-align:right"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /> </td>
            </tr> 
        </table>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Indent Id" SortExpression="intIndentID"><ItemTemplate>
            <asp:Label ID="lblIndent" runat="server" Text='<%# Bind("intIndentID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Indent Date" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblIndentDate" runat="server"  Text='<%# Bind("dteIndentDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Due Date" ItemStyle-HorizontalAlign="right" SortExpression="dteDueDate" >
            <ItemTemplate><asp:Label ID="lblDueDate" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dteDueDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Indent Type" ItemStyle-HorizontalAlign="right" SortExpression="strIndentType" >
            <ItemTemplate><asp:Label ID="lblIndentType" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strIndentType") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Indent By" ItemStyle-HorizontalAlign="right" SortExpression="strEmployeeName" > 
            <ItemTemplate><asp:Label ID="lblIndentBy"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strEmployeeName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClick="btnDetalis_Click" /> </ItemTemplate> 
            </asp:TemplateField>

            </Columns>
                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>
        </div>
         <div id="hdnDivision"   class="hdnDivision"  style="width:auto;  height:500px;">  
              <table style="width:800px; " > 
                <tr>
                <td style="text-align:right;"><asp:Label ID="Label5" CssClass="lbl" runat="server" Text="IndentNo:"></asp:Label></td>
                <td style="text-align:Left;"><asp:Label ID="lblIndentNo" CssClass="lbl" runat="server"  ></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label7" CssClass="lbl" runat="server" Text="IndentDate:"></asp:Label></td>
                <td style="text-align:Left;"><asp:Label ID="lblIndentDate" CssClass="lbl" runat="server"  ></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label9" CssClass="lbl" runat="server" Text="DueDate:"></asp:Label></td>
                <td style="text-align:Left;"><asp:Label ID="lblDueDate" CssClass="lbl" runat="server"  ></asp:Label></td>
                </tr>

                <tr> 
                <td style="text-align:right;"><asp:Label ID="Label11" CssClass="lbl" runat="server" Text="IndentType:"></asp:Label></td> 
                <td style="text-align:Left;"><asp:Label ID="lblIndentType" CssClass="lbl" runat="server"  ></asp:Label></td>  

                <td colspan="4" style="text-align:right"><asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Reject"/><asp:Button ID="btnApprove" runat="server" Text="Approve" OnClientClick="funConfirmAll()" OnClick="btnApprove_Click" /> </td>
                </tr>

                <tr><td></td></tr>
              </table>
              <table style="width:800px; ">
                <tr>
                <td>  
                <asp:GridView ID="dgvDetalis" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="800px"  
                CssClass="GridViewStyle">            
                <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                 
                <asp:TemplateField HeaderText="ItemId" SortExpression="intItemID"><ItemTemplate>
                <asp:Label ID="lblItemIds" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left"  /></asp:TemplateField>
                
                <asp:TemplateField HeaderText="Item Name"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
                <ItemTemplate><asp:Label ID="lblItem" runat="server"  Text='<%# Bind("Descriptions") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" Width="300px" />  </asp:TemplateField>  

                <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
                <ItemTemplate><asp:Label ID="lblUom" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
                <ItemTemplate><asp:Label ID="lblQuantity" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numQty") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
                <asp:TemplateField HeaderText="Stock Qty" ItemStyle-HorizontalAlign="right" SortExpression="CurrentStock" > 
                <ItemTemplate><asp:Label ID="lblCurrentQty"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("CurrentStock") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
                <asp:TemplateField HeaderText="Safty Qty" ItemStyle-HorizontalAlign="right" SortExpression="numSafetyStock" > 
                <ItemTemplate><asp:Label ID="lblSafeQty"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numSafetyStock") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

                <asp:TemplateField HeaderText="Purpose" ItemStyle-HorizontalAlign="right" SortExpression="Purpose" > 
                <ItemTemplate><asp:Label ID="lblPurpsoe"    runat="server"   Text='<%# Bind("Purpose") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" Width="400px" /> </asp:TemplateField> 
           
                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="right" SortExpression="Statuss" > 
                <ItemTemplate><asp:Label ID="lblStatus"    runat="server"   Text='<%# Bind("Statuss") %>'></asp:Label></ItemTemplate>
                <ItemStyle HorizontalAlign="left" Width="150px" /> </asp:TemplateField>
                <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" />
                </HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate>
                </asp:TemplateField>
                </Columns> 
                </asp:GridView></td> 
                </tr> 
                <tr>
                <td style="text-align:right">
                <asp:Button runat="server" ID="btnClsoe"  OnClick="btnClsoe_Click" Text="Close" />
                </td>
                </tr>
              </table>

         </div>

        </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
