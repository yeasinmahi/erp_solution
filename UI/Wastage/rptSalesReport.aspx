<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptSalesReport.aspx.cs" Inherits="UI.Wastage.rptSalesReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Sales Report .:: </title>
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
   <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }

         function CloseHdnDiv() {
             $("#hdnDivision").fadeOut("slow"); 
         }
    </script>
   <script>
       function Add() {
           var a, b, c;
            var a = document.forms["frmSO"]["txtQty"].value;           
            if (isNaN(a) == true) { a = 0; }
              var b = document.forms["frmSO"]["txtRate"].value;
            if (isNaN(b) == true) { b = 0; }            
            document.forms["frmSO"]["txtValue"].value = (a*b).toFixed(0);
        }
  </script>  
     <script>
        function PrintPage() {          
            window.print();
            self.close();
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
    <form id="frmSalesAndPending" runat="server">        
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
    <asp:HiddenField ID="hdnRpt" runat="server" /> <asp:HiddenField ID="hdnOpening" runat="server" />     
    <div class="divbody" style="padding-right:10px;">
    <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> Sales &amp; Order Report<hr /></div>
    <table class="tbldecoration" style="width:auto; float:left;">
        <tr>
            <td style="text-align:right;"><asp:Label ID="lblunit" runat="server" CssClass="lbl" Text="Transfer Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"><asp:TextBox ID="txtSODate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
            <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtSODate"></cc1:CalendarExtender></td>
            <td style="text-align:right; width:15px;"><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;"><asp:Label ID="lblDept" runat="server" CssClass="lbl" Text="To Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td style="text-align:left;"><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
         </tr>
         <tr>               
            <td style="text-align:right;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name"></asp:Label>]<span style="color:red; font-size:14px;">*</span><span> :</span></td>                
            <td><asp:DropDownList ID="ddlWHName" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
            <td style="text-align:right; width:15px;">&nbsp;</td> 
            <td style="text-align:right;">&nbsp;</td>
            <td style="text-align:left;">&nbsp;</td>
          </tr>
        <tr>               
            <td>
                <asp:RadioButton ID="rdnReport" GroupName="lblRpt" Text="Sales Report" runat="server" OnCheckedChanged="rdnReport_CheckedChanged" /><asp:RadioButton ID="rdnRptDetails" GroupName="lblRpt" Text="Pending Report" runat="server" OnCheckedChanged="rdnRptDetails_CheckedChanged" />
            </td>                
            <td colspan="4"></td>
          </tr>
         <tr><td colspan="5"><hr /></td></tr> 
          <tr>
             <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"> <asp:Button ID="btnprint" runat="server" class="myButtonGrey" Text="Print" Width="100px" OnClientClick="PrintPage()" />
                               &nbsp&nbsp 
                 <asp:Button ID="btnShow" runat="server" class="myButtonGrey" Text="Show" OnClick="btnShow_Click" /> </td>        
          </tr>
    </table>
    </div>
    <table>
        <tr><td><hr /></td></tr>
        <tr><td><asp:Label ID="lblHeder" runat="server"></asp:Label>   </td></tr>         
        <tr><td><asp:Panel ID="Panel1" runat="server"> <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="True" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvReport_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Sales Date" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lbljobstation" runat="server" Text='<%# Bind("dteIssueDate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Customer Name" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("strCustomerName") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Sales Order No" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblSalesOrderNo" runat="server" Text='<%# Bind("strSalesOrderNo") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Delivery Challan No" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblSalesValue" runat="server" Text='<%# Bind("intDeliveryChallanNo") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Sales Value" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("SalesValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# TotalValueSales %>" /></FooterTemplate></asp:TemplateField>
           
            <asp:TemplateField HeaderText="Details">
            <ItemTemplate>
            <asp:Button ID="btnDetails" Width="90px" Font-Bold="true" BackColor="#5effff" runat="server" Text="Details" 
                CommandName="complete1" OnClick="btnDetails_Click"  
                CommandArgument='<%#  Eval("strSalesOrderNo")+ "," +Eval("intDeliveryChallanNo")+ "," +Eval("strCustomerName")+ "," +Eval("dteIssueDate")  %>' /></ItemTemplate>
            </asp:TemplateField>
          
            </Columns>
            <FooterStyle BackColor="Gray" Font-Bold="True" Font-Size="11px" ForeColor="White" Height="25px" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
           </asp:Panel> 
            <asp:Panel ID="Panel2" runat="server"> <asp:GridView ID="dgvPending" runat="server" AutoGenerateColumns="False" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="True" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvPending_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Sales Date" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lbljobstation" runat="server" Text='<%# Bind("dteSalesDate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
            <asp:TemplateField HeaderText="Customer Name" SortExpression="itemname">
            <ItemTemplate><asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("strCustName") %>' Width="200px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="200px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Sales Order No" SortExpression="uom">
            <ItemTemplate><asp:Label ID="lblSalesOrderNo" runat="server" Text='<%# Bind("strSalesOrderNo") %>' Width="60px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Pending Qty" SortExpression="qty">
            <ItemTemplate><asp:Label ID="lblQty" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("monRemaining") %>' Width="80px"></asp:Label>
            </ItemTemplate><FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# stotalQty %>" /></FooterTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Details">
            <ItemTemplate>
            <asp:Button ID="btnDetails" Width="90px" Font-Bold="true" BackColor="#5effff" runat="server" Text="Details" CommandName="complete1" 
                OnClick="btnDetailsPending_Click"   
                CommandArgument='<%# Eval("strSalesOrderNo")+ "," +Eval("strCustName")+ "," +Eval("dteSalesDate") %>' /></ItemTemplate>
            </asp:TemplateField>
          
            </Columns>
            <FooterStyle BackColor="Gray" Font-Bold="True" Font-Size="11px" ForeColor="White" Height="25px" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
           </asp:Panel>
            </td></tr>  
        <tr><td><hr /></td></tr> 
        <tr>
         <td style="text-align:right; padding: 0px 0px 0px 0px"></td>        
        </tr>
    </table>   
    <div id="hdnDivision"   class="hdnDivision"  style="width:auto;  height:500px;">  
    <table>
         <tr>
             <td style="text-align:right;">
                 <strong><label>Customer Name : </label></strong>
                 <asp:Label ID="lblCustomer" CssClass="lbl" runat="server" Text=""></asp:Label></td>
              <td style="text-align:right;">
                <strong><label id="lblDChalanNo" runat="server"> Delivery Challan No : </label></strong>
                <asp:Label ID="lblDeliveryChallan" CssClass="lbl" runat="server" Text=""></asp:Label></td>
            <td style="text-align:right;">
                <strong><label> Issue Date : </label></strong>
                <asp:Label ID="lblissuedate" CssClass="lbl" runat="server" Text=""></asp:Label></td>
            <td style="text-align:Left;"><asp:Label ID="lblissueDatedata" CssClass="lbl" runat="server"  ></asp:Label></td>           
            <td style="text-align:Left;"><asp:Label ID="lblDeliveryChallanData" CssClass="lbl" runat="server"  ></asp:Label></td>            
            <td style="text-align:Left;"><asp:Label ID="lblCustomerData" CssClass="lbl" runat="server"  ></asp:Label></td>           
           </tr>
         <tr><td colspan="4" style="text-align:right"><asp:Button runat="server" ID="btnClsoe"  OnClick="btnClsoe_Click" Text="Close" /> </td></tr>
    </table>
    <table style="width:800px; ">
        <tr><td>Details Report</td></tr>
        <tr><td>  
        <asp:GridView ID="dgvDetalis" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="800px"  
        CssClass="GridViewStyle">            
        <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                 
        <asp:TemplateField HeaderText="strItemName" SortExpression="strItemName"><ItemTemplate>
        <asp:Label ID="lblstrItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left"  /></asp:TemplateField>
                
        <asp:TemplateField HeaderText="UOM"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
        <ItemTemplate><asp:Label ID="lblstrUOM" runat="server"  Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" Width="300px" />  </asp:TemplateField>  
   
        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("intIssueQty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
        <asp:TemplateField HeaderText="Rate " ItemStyle-HorizontalAlign="right" SortExpression="monIssRate" > 
        <ItemTemplate><asp:Label ID="lblmonIssRate"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monIssRate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="numSafetyStock" > 
        <ItemTemplate><asp:Label ID="lblmonIssValue"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monIssValue") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="Purpose" > 
        <ItemTemplate><asp:Label ID="lblstrSalesRemarks"    runat="server"   Text='<%# Bind("strSalesRemarks") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" Width="400px" /> </asp:TemplateField> 
    
        </Columns> 
        </asp:GridView>

        <asp:GridView ID="dgvPendingDetails" runat="server" AutoGenerateColumns="False" ShowFooter="true" ShowHeader="true"  Width="800px"  
        CssClass="GridViewStyle">            
        <HeaderStyle CssClass="HeaderStyle" />  <FooterStyle CssClass="FooterStyle" /> <RowStyle CssClass="RowStyle" />  <PagerStyle CssClass="PagerStyle" /> 
        <Columns>
        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                 
        <asp:TemplateField HeaderText="strItemName" SortExpression="strItemName"><ItemTemplate>
        <asp:Label ID="lblstrItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left"  /></asp:TemplateField>
                
        <asp:TemplateField HeaderText="UOM"   ItemStyle-HorizontalAlign="right" SortExpression="dteIndentDate" >
        <ItemTemplate><asp:Label ID="lblstrUOM" runat="server"  Text='<%# Bind("strUOM") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" Width="300px" />  </asp:TemplateField>  
   
        <asp:TemplateField HeaderText="Pending Quantity" ItemStyle-HorizontalAlign="right" SortExpression="numQty" >
        <ItemTemplate><asp:Label ID="lblPendingQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("PendingQty") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>
            
        <asp:TemplateField HeaderText="Rate " ItemStyle-HorizontalAlign="right" SortExpression="monIssRate" > 
        <ItemTemplate><asp:Label ID="lblmonIssRate"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("monSalesRate") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="numSafetyStock" > 
        <ItemTemplate><asp:Label ID="lblmonIssValue"    runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("PendingValue") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="Purpose" > 
        <ItemTemplate><asp:Label ID="lblstrSalesRemarks"    runat="server"   Text='<%# Bind("strSalesRemarks") %>'></asp:Label></ItemTemplate>
        <ItemStyle HorizontalAlign="left" Width="400px" /> </asp:TemplateField> 
    
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