<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptInventory.aspx.cs" Inherits="UI.Wastage.rptInventory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Inventory .:: </title>
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
    <script language="javascript" type="text/javascript">        
        function onlyNumbers(evt) {
            var e = event || evt;
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
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
</head>
<body>
    <form id="frmTransfer" runat="server">        
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
    <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> INVENTORY REPORT<hr /></div>
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
                &nbsp;</td>                
            <td colspan="4"></td>
          </tr>
         <tr><td colspan="5"><hr /></td></tr> 
         <tr>
             <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px">&nbsp&nbsp <asp:Button ID="btnSubmit" runat="server" class="myButtonGrey" Text="Show" OnClick="btnSubmit_Click" /> </td>        
         </tr>
    </table>
    </div>
    <table>
        <tr><td><hr /></td></tr>
        <tr><td><asp:Label ID="lblHeder" runat="server"></asp:Label>   </td></tr>        
        <tr><td><asp:Panel ID="Panel1" runat="server"> 
           </asp:Panel> 
            <asp:Panel ID="Panel2" runat="server"> <asp:GridView ID="dgvReportDetails" runat="server" AutoGenerateColumns="False" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="True" 
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvReport_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
          
            <asp:TemplateField HeaderText="Material Name" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblMaterial" runat="server" Text='<%# Bind("strItemName") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
         
           
            <asp:TemplateField HeaderText="UOM" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%# Bind("strUOM") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Opening Qty" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblOPSQty" runat="server" Text='<%# Bind("OpeQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
         
            <asp:TemplateField HeaderText="Opening Rate" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblOPSRate" runat="server" Text='<%# Bind("OpeRate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
          
            <asp:TemplateField HeaderText="Opening Value" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblOPSValue" runat="server" Text='<%# Bind("OpeValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            <FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# OtotalOpening %>" /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Qty" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblRecqty" runat="server" Text='<%# Bind("RecQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Rate" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblRecRate" runat="server" Text='<%# Bind("RecRate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Receive Value" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblRecValue" runat="server" Text='<%# Bind("RecValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            <FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# recvalue %>" /></FooterTemplate>
            </asp:TemplateField>

             
            <asp:TemplateField HeaderText="Available Qty" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblAvailableqty" runat="server" Text='<%# Bind("TotalQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Available Rate" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblAvailableRate" runat="server" Text='<%# Bind("TotalRate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Available Value" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblAvailableValue" runat="server" Text='<%# Bind("TotalValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            <FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# avavalue %>" /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Qty" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblIssueqty" runat="server" Text='<%# Bind("IssQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Rate" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblIssueRate" runat="server" Text='<%# Bind("IssRate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Issue Value" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblIssueValue" runat="server" Text='<%# Bind("IssValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            <FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# issvalue %>" /></FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Closing Qty" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblClosingqty" runat="server" Text='<%# Bind("CloQty") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Closing Rate" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblIssueRate" runat="server" Text='<%# Bind("CloRate") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Closing Value" SortExpression="itemid">
            <ItemTemplate><asp:Label ID="lblClosingValue" runat="server" Text='<%# Bind("CloValue") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/>
            <FooterTemplate><asp:Label ID="lblValueTotalqty" runat="server" DataFormatString="{0:0.00}" Text="<%# clovalue %>" /></FooterTemplate>
            </asp:TemplateField>

   
          
            </Columns>
            <FooterStyle BackColor="Gray" Font-Bold="True" Font-Size="11px" ForeColor="White" Height="25px" HorizontalAlign="Right" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
           </asp:Panel>
            </td></tr>  
        <tr><td><hr /></td></tr> 
        <tr><td style="text-align:right; padding: 0px 0px 0px 0px"></td>        
        </tr>
    </table>   

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>