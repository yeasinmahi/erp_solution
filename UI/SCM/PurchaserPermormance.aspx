<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaserPermormance.aspx.cs" Inherits="UI.SCM.PurchaserPermormance" %> 
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
     <div class="tabs_container" style="text-align:left"><hr /></div>
         
         <table style="width:700px"> 
                <tr><td colspan="2" style="text-align:center; font:bold 13px verdana;"><a id="btnprint" href="#" class="nextclick" style="cursor:pointer" onclick="Print()">Print</a></td></tr>
                <tr>   
                <td><asp:Image ID="imgUnit" runat="server"   /></td>
                <td style="text-align:center; font-size:medium; font-weight:bold; font:u" ><asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                </tr>
                <tr> 
                <td></td>
                <td  style="text-align:center"><asp:Label ID="lblWH" Font-Size="Small" Font-Bold="true" Text="Purchasers' Performance Report" runat="server"></asp:Label></td>
                </tr>
                <tr>
                <td></td>
                <td style="text-align:center;"><asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" ></asp:Label></td>
                </tr>
                <tr><td></td></tr>
              </table> 
        <table style="width:700px">
           <tr>  
            
            <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtDteFrom" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtDteFrom">
            </cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="lbldteTo" CssClass="lbl" runat="server" Text="To Date: "></asp:Label></td>            
            <td style="text-align:left;"  ><asp:TextBox ID="txtdteTo" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" SelectedDate="<%# DateTime.Today %>" Format="yyyy-MM-dd" TargetControlID="txtdteTo">
            </cc1:CalendarExtender> </td>
            <td style="text-align:left"> <td style="text-align:left"><asp:Button ID="btnStatement" runat="server" Text="Show"  OnClick="btnStatement_Click"/> </td>
            </tr> 
        </table>
        

         <table>
           <tr><td> 
            <asp:GridView ID="dgvStatement" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right"  > 
            <AlternatingRowStyle BackColor="#CCCCCC" /> 
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="40px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Procurement Personal" SortExpression="Personal"><ItemTemplate>
            <asp:Label ID="lblProcurement" runat="server" Text='<%# Bind("Personal") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="60px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Value of Total PO"   ItemStyle-HorizontalAlign="right" SortExpression="POTotal" >
            <ItemTemplate><asp:Label ID="lblValueTo" runat="server"  Text='<%# Bind("POTotal") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Number of Total PO"   ItemStyle-HorizontalAlign="right" SortExpression="NoOfPo" >
            <ItemTemplate><asp:Label ID="lblNumsTP" runat="server"  Text='<%# Bind("NoOfPo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Number of Unique Supp"   ItemStyle-HorizontalAlign="right" SortExpression="NoOfEniqueSuppliers" >
            <ItemTemplate><asp:Label ID="lblNumUN" runat="server"  Text='<%# Bind("NoOfEniqueSuppliers") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="No of Total Itms" ItemStyle-HorizontalAlign="right" SortExpression="NoOfTotalItems" >
            <ItemTemplate><asp:Label ID="lblUnique" runat="server"   Text='<%# Bind("NoOfTotalItems") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
            <asp:TemplateField HeaderText="AVG Item Per PO" ItemStyle-HorizontalAlign="right" SortExpression="AvgItemperPo" >
            <ItemTemplate><asp:Label ID="lblAvgItem" runat="server"  Text='<%# Bind("AvgItemperPo") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
           
            <asp:TemplateField HeaderText="NoOfUniqueItems"   ItemStyle-HorizontalAlign="right" SortExpression="NoOfUniqueItems" >
            <ItemTemplate><asp:Label ID="lblRating" runat="server"  Text='<%# Bind("NoOfUniqueItems") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="Highest Value PO"   ItemStyle-HorizontalAlign="right" SortExpression="HeighestPoValue" >
            <ItemTemplate><asp:Label ID="lblHeigstPOVal" runat="server"  Text='<%# Bind("HeighestPoValue" ) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 
            
            <%--<asp:TemplateField HeaderText="Rating"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblRating2" runat="server"  Text='<%# Bind("numQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

            <asp:TemplateField HeaderText="Maximum Procured"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblMaximPorocue" runat="server"  Text='<%# Bind("numQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> 

            <asp:TemplateField HeaderText="Maximum Total Value Procured"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
            <ItemTemplate><asp:Label ID="lblVlueProcured" runat="server"  Text='<%# Bind("numQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField> --%>

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
