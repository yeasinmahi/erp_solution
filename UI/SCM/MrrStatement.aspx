<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MrrStatement.aspx.cs" Inherits="UI.SCM.MrrStatement" %>

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
       
    <script>
        function Viewdetails(MrrId) {
            window.open('MrrStatementDetalis.aspx?MrrId=' + MrrId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
         }
    </script>
    <script>
        function DocViewdetails(MrrId) {
            window.open('MrrDocAttachmentPopUp.aspx?MrrId=' + MrrId, 'sub', "scrollbars=yes,toolbar=0,height=500,width=950,top=100,left=200, resizable=yes, directories=no,location=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no, addressbar=no");
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
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">MRR Statement<hr /></div>
         
       <table>
        <tr>
        <td   style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH Name"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlWH" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"     ></asp:DropDownList></td>                                                                                      
           
        <td   style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Department"></asp:Label></td>
        <td style="text-align:left;"><asp:DropDownList ID="ddlDept" CssClass="ddList" Font-Bold="False" AutoPostBack="true" runat="server"     ></asp:DropDownList></td>                                                                                      

        </tr>
        <tr>                      
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
        <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server"   CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
        </cc1:CalendarExtender> </td>

        <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
        <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server"   CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
        </cc1:CalendarExtender> </td> 
        </tr>
        <tr>
        <td style="text-align:right;"><asp:Label ID="Label3" CssClass="lbl" runat="server" Text="MRR No: "></asp:Label></td>     
        <td><asp:TextBox ID="txtMrrNo" runat="server" CssClass="txtBox" ></asp:TextBox></td>
        <td style="text-align:left"> </td><td style="text-align:left"><asp:Button ID="btnStatement" runat="server" Text="Statement"  OnClick="btnStatement_Click"/> </td>
        </tr> 
        </table>
        <table>
           <tr><td> 
            <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="MRR Id" SortExpression="intMrr"><ItemTemplate>
            <asp:Label ID="lblMrrId" runat="server" Text='<%# Bind("intMrr") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="PO ID"   ItemStyle-HorizontalAlign="right" SortExpression="intPo" >
            <ItemTemplate><asp:Label ID="lblPo" runat="server"  Text='<%# Bind("intPo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Supplier"   ItemStyle-HorizontalAlign="right" SortExpression="strSupp" >
            <ItemTemplate><asp:Label ID="lblSupp" runat="server"  Text='<%# Bind("strSupp") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="MRR Date"   ItemStyle-HorizontalAlign="right" SortExpression="dteMrr" >
            <ItemTemplate><asp:Label ID="lbldteMrr" Width="60px" runat="server"  Text='<%# Bind("dteMrr","{0:yyyy-MM-dd}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Product" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblItem" runat="server"  Width=""  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="right"   SortExpression="uom" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"   Text='<%# Bind("uom" ) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="monQty" >
            <ItemTemplate><asp:Label ID="lblmonQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Value"   ItemStyle-HorizontalAlign="right" SortExpression="monValue" >
            <ItemTemplate><asp:Label ID="lblmonValue" runat="server"  Text='<%# Bind("monValue" ) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strRemarks" > 
            <ItemTemplate><asp:Label ID="lblRemarks"  Width="60px"   runat="server"  Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            
             <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnAttachment" runat="server" Text="Detalis" OnClick="btnAttachment_Click"   /> </ItemTemplate> 
            </asp:TemplateField>
             
            <asp:TemplateField HeaderText="Detalis">
            <ItemTemplate>   <asp:Button ID="btnDetalis" runat="server" Text="Detalis" OnClick="btnDetalis_Click"   /> </ItemTemplate> 
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
