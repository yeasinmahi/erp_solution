<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRequisition.aspx.cs" Inherits="UI.SCM.BOM.EditRequisition" %>

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
        function funConfirmAll() { 
            var confirm_value = document.createElement("INPUT"); 
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value"; 
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnConfirm").value = "1"; } 
            else { confirm_value.value = "No"; document.getElementById("hdnConfirm").value = "0"; } 
        }

</script> 
     <script>

         function Viewdetails(srrId,itemId,whid,Vtype,dteFrom,dteTo) {
             window.open('EditRequisitionDetalis.aspx?srrId=' + srrId + '&itemId=' + itemId + '&whid=' + whid + '&Vtype=' + Vtype +'&dteFrom=' + dteFrom +'&dteTo=' + dteTo, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
              
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
        width:100%; height: 100%;    margin-left: 70px;  margin-top:100px; margin-right:00px; padding: 15px; overflow-y:scroll; }
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
     <div class="tabs_container" style="text-align:left">Store Issue for Production From<hr /></div>
         
       <table>
            <tr>
            <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
            <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"    ></asp:DropDownList></td>                                                                                      
            <td style="text-align:right;"><asp:Label ID="lblFrom" runat="server" CssClass="lbl" Text="InterVal :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlInterval" runat="server" CssClass="ddList">
            <asp:ListItem Text="12:00-12:00"></asp:ListItem>
            <asp:ListItem Text="6:00-6:00"></asp:ListItem>
            </asp:DropDownList></td>
            </tr>
           <tr>

            <td style="text-align:right;"><asp:Label ID="lblTo" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtdteDate" runat="server" AutoPostBack="false" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="dteTo" runat="server" Format="yyyy-MM-dd"  TargetControlID="txtdteDate"></cc1:CalendarExtender></td> 

            <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Type :"></asp:Label></td>
            <td style="text-align:left"><asp:DropDownList ID="ddlvTypes" runat="server" CssClass="ddList" AutoPostBack="True"> 
            <asp:ListItem Text="SR"></asp:ListItem>
            <asp:ListItem Text="Item"></asp:ListItem>
            </asp:DropDownList></td>
          
          
           <td style="text-align:right"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /> </td>
            </tr> 
        </table>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvReq" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false"><ItemTemplate>
            <asp:Label ID="lblReqId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="SR NO And Dept" SortExpression="strCode"><ItemTemplate>
            <asp:Label ID="lblReqSR" runat="server" Text='<%# Bind("strCode") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>

             
            <asp:TemplateField HeaderText="ProductionOrder" ItemStyle-HorizontalAlign="right" SortExpression="intProdOrderID" > 
            <ItemTemplate><asp:Label ID="lblProduction"    runat="server"  Text='<%# Bind("intProdOrderID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

             <asp:TemplateField HeaderText="ProductionOrder Of" ItemStyle-HorizontalAlign="right" SortExpression="total" > 
            <ItemTemplate><asp:Label ID="lblProducQty"    runat="server"  Text='<%# Bind("total") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalisReq" runat="server" Text="Detalis" OnClick="btnDetalisReq_Click"     /> </ItemTemplate> 
            </asp:TemplateField>

            </Columns>
             <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
        </tr> 
           
        </table>

             <table>
           <tr><td> 
            <asp:GridView ID="dgvItem" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="ItemID" SortExpression="intItemID" ><ItemTemplate>
            <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Item Name" SortExpression="strItem"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right" SortExpression="strUom" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"   Text='<%# Bind("strUom") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField> 
            <asp:TemplateField HeaderText="Requesition" ItemStyle-HorizontalAlign="right" SortExpression="requesition" > 
            <ItemTemplate><asp:Label ID="lblrequesition"    runat="server"  Text='<%# Bind("requesition") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

             <asp:TemplateField HeaderText="Issued" ItemStyle-HorizontalAlign="right" SortExpression="issued" > 
            <ItemTemplate><asp:Label ID="lblProducQty"    runat="server"  Text='<%# Bind("issued") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Pending" ItemStyle-HorizontalAlign="right" SortExpression="pending" > 
            <ItemTemplate><asp:Label ID="lblPending"    runat="server"  Text='<%# Bind("pending") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Right" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalisItem" runat="server" Text="Detalis"  OnClick="btnDetalisItem_Click"    /> </ItemTemplate> 
            </asp:TemplateField>

            </Columns>
             <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />

            </asp:GridView></td> 
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
