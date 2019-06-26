<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FpsRackItemIssue.aspx.cs" Inherits="UI.AEFPS.FpsRackItemIssue" %>

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

    <script language="javascript" type="text/javascript">

         
        $("[id*=txtIssueQty]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var IssueQty = parseFloat($(this).val())
                    var StockQty = $("[id*=lblGodownQty]", row).html(); 

                    if (StockQty >= IssueQty) {
                         
                    }
                    else {
                        $("[id*=txtIssueQty]", row).val('0');
                        alert("Please Check Issue Quantity");
                    }

                }
            }
        });

       


</script>
   <script type = "text/javascript">
       function PrintPanel() {
          // window.print();
          
          
      }
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
    <div class="leaveApplication_container">  
       <asp:HiddenField ID="hdnConfirm" runat="server" /> 
        
       <div class="tabs_container">Rack Issue From<hr /></div>
         <table>
       <tr>
           

           <td style="text-align:right;"><asp:Label ID="Label1" Font-Bold="true" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>                                                                                       
           </td>
            
            <td     style="text-align:right; font-size:14px; font-weight:bold;">
                  <asp:RadioButton ID="raRack" runat="server" GroupName="group"  Text=" Rack" AutoPostBack="True" OnCheckedChanged="raRack_CheckedChanged"  />
        <asp:RadioButton ID="ragodwon" runat="server" GroupName="group" Text=" Godown" AutoPostBack="True" OnCheckedChanged="ragodwon_CheckedChanged"  />
      </td> 
        <td style="text-align:right;"  ><asp:Label ID="lblRack" runat="server" Font-Bold="true" CssClass="lbl" Text="Rack  Name"></asp:Label></td>
            <td style="text-align:left;">
            <asp:DropDownList ID="ddlRack" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server" Width="195px" OnSelectedIndexChanged="ddlRack_SelectedIndexChanged"  ></asp:DropDownList>
              
                <asp:Button ID="btnPrintBarcode" runat="server" Text="Print"  OnClick="btnPrintBarcode_Click"   />
                <%--OnClick="btnPrintBarcode_Click"--%>

            </td>
       </tr>
             <tr>
                 <td></td>
                
             </tr>
             
         <tr><td colspan="5"> 
            <asp:GridView ID="dgvReceive" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"  ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
            
            <asp:TemplateField HeaderText="ItemId" Visible="false" SortExpression="intItemId"><ItemTemplate>            
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="MrrID" Visible="True" SortExpression="intMrrId"><ItemTemplate>            
            <asp:Label ID="lblMrrId" runat="server" Text='<%# Bind("intMrrId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
            
                
               
            <asp:TemplateField HeaderText="Product Name" SortExpression="strItemName"><ItemTemplate>            
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Rack Name" SortExpression="RakName"><ItemTemplate>            
            <asp:Label ID="lblRackName" runat="server" Text='<%# Bind("RakName") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Rack ID" Visible="false" SortExpression="intRackId"><ItemTemplate>            
            <asp:Label ID="lblRackId" runat="server" Text='<%# Bind("intRackId") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="300px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Godown Qty"   SortExpression="numReceiveQty"><ItemTemplate>            
            <asp:Label ID="lblGodownQty" runat="server" Text='<%# Bind("numReceiveQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>
                 <asp:TemplateField HeaderText="Sales Price"   SortExpression="numRate"><ItemTemplate>            
            <asp:Label ID="lblSalesPrice" runat="server" Text='<%# Bind("numRate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="45px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUoM" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
             </asp:TemplateField>
                         
             
                
            

            
                
            

                                
            <asp:TemplateField HeaderText="Issue Qty" ItemStyle-HorizontalAlign="right" SortExpression="issueQty" >
            <ItemTemplate><asp:TextBox ID="txtIssueQty" runat="server" DataFormatString="{0:0.00}" Text='<%# (decimal.Parse(""+Eval("issueQty"))) %>'></asp:TextBox></ItemTemplate>
             </asp:TemplateField> 

             

             
                                             
            <asp:TemplateField HeaderText="Issue"><ItemTemplate>
            <asp:Button ID="btnPrint" runat="server" Text="Issue" OnClientClick="funConfirmAll()"  OnClick="btnPrint_Click" />
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

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

