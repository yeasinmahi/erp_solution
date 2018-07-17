<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BudgetEntry.aspx.cs" Inherits="UI.BudgetPlan.BudgetEntry" %>
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
    <script src="../Content/JS/gridviewscroll.min.js"></script>
<script  type="text/javascript">
   

    function onlyNumbers(evt) {
        var e = event || evt; // for trans-browser compatibility
        var charCode = e.which || e.keyCode;

        if ((charCode > 57))
            return false;
        return true;
    }  
</script>
    <script type="text/javascript">
       
        function gridviewScroll() {
            $('#<%=dgvBudget.ClientID%>').gridviewScroll({
                 width:1100,
                 height: 360,
                 
                 freezesize: 3
             });
        } 
        function PostBack() {
             
            __doPostBack();
        }
    </script>

    <style type="text/css">
    .GridviewScrollHeader TH, .GridviewScrollHeader TD 
    { 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #EFEFEF; 
    text-align: left; 
    vertical-align: bottom; 
    } 
    .GridviewScrollItem TD 
    { 
    padding: 5px; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
    } 
    .GridviewScrollPager  
    { 
    border-top: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
    } 
    .GridviewScrollPager TD 
    { 
    padding-top: 3px; 
    font-size: 14px; 
    padding-left: 5px; 
    padding-right: 5px; 
    } 
    .GridviewScrollPager A 
    { 
    color: #666666; 
    }
    .GridviewScrollPager SPAN

    {

    font-size: 16px;

    font-weight: bold;

    }
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
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> BUDGET ENTRY <hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" AutoPostBack="true" Width="120px" runat="server"  OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblCostCenter" runat="server" CssClass="lbl" Text="Cost Center :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlCostCenter" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlCostCenter_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblYear" runat="server" CssClass="lbl" Text="Year:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlYear" CssClass="ddList" Font-Bold="False" Width="120px" runat="server" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>
            <td style="width:5px"></td>    
            <td style="text-align:left;"><asp:Button ID="btnBudgetSave" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick"  Visible="false" Text="Save Budget" OnClientClick="ConfirmAll()"  OnClick="btnBudgetSave_Click"/></td>                                                    
        </tr>        
        </table>
           
        <table>  
            <%--===========Top Sheet Report============--%>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblUnitName" runat="server"></asp:Label></td></tr>
            <tr class="tblheader"><td style='text-align: left;'><asp:Label ID="lblCCName" runat="server"></asp:Label></td></tr>
           
            <tr><td style="text-align:left"> 
            <asp:GridView ID="dgvBudget" runat="server" AutoGenerateColumns="False"   Width="100%" OnRowDeleting="dgvBudget_RowDeleting" >
           
            <Columns>
            <asp:TemplateField HeaderText="SL No." Visible="false"><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>          
                    
            <asp:CommandField DeleteText="Save"   HeaderText="Save" ShowDeleteButton="True"    ControlStyle-Width="40px" ControlStyle-Font-Bold="true" ControlStyle-ForeColor="Blue"/>

           
            <asp:TemplateField HeaderText="COAID" Visible="false"  SortExpression="intGlobalCOA" >
            <ItemTemplate><asp:Label ID="lblCOAID" runat="server"   DataFormatString="{0:0.00}" Text='<%# (""+Eval("intGlobalCOA")) %>'></asp:Label></ItemTemplate>
            </asp:TemplateField>

                         
            <asp:TemplateField HeaderText="COA Code" SortExpression="strAccountCode" ItemStyle-BackColor="#EFEFEF"><ItemTemplate>            
            <asp:Label ID="lblCOACode" runat="server" Text='<%# Bind("strAccountCode") %>' Width="70px"></asp:Label></ItemTemplate>
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Account Head" SortExpression="strAccountName" ItemStyle-BackColor="#EFEFEF"><ItemTemplate>            
            <asp:Label ID="lblSupplierName" runat="server" Text='<%# Bind("strAccountName") %>' Width="150px"></asp:Label></ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Total Amount"  ItemStyle-HorizontalAlign="right" SortExpression="TotalAmount"><ItemTemplate>
            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="txtBox" Text='<%# Bind("TotalAmount") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            <FooterTemplate><asp:Label ID="lblGTAmount" runat="server" DataFormatString="{0:0.00}" Text ='<%# grandTotal %>'></asp:Label></FooterTemplate></asp:TemplateField>
              
            <asp:TemplateField HeaderText="Amount July"  ItemStyle-HorizontalAlign="right" SortExpression="JulAmo"><ItemTemplate>
            <asp:TextBox ID="txtJulAmo" runat="server" CssClass="txtBox" Text='<%# Bind("JulAmo") %>' DataFormatString="{0:0.00}" Width="50px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
             </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance July"  ItemStyle-HorizontalAlign="right" SortExpression="JulTol"><ItemTemplate>
            <asp:TextBox ID="txtJulTol" runat="server" CssClass="txtBox" Text='<%# Bind("JulTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Aug"  ItemStyle-HorizontalAlign="right" SortExpression="AugAmo"><ItemTemplate>
            <asp:TextBox ID="txtAugAmo" runat="server" CssClass="txtBox" Text='<%# Bind("AugAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Aug"  ItemStyle-HorizontalAlign="right" SortExpression="AugTol"><ItemTemplate>
            <asp:TextBox ID="txtAugTol" runat="server" CssClass="txtBox" Text='<%# Bind("AugTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Sep"  ItemStyle-HorizontalAlign="right" SortExpression="SepAmo"><ItemTemplate>
            <asp:TextBox ID="txtSepAmo" runat="server" CssClass="txtBox" Text='<%# Bind("SepAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Sep"  ItemStyle-HorizontalAlign="right" SortExpression="SepTol"><ItemTemplate>
            <asp:TextBox ID="txtSepTol" runat="server" CssClass="txtBox" Text='<%# Bind("SepTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Oct"  ItemStyle-HorizontalAlign="right" SortExpression="OctAmo"><ItemTemplate>
            <asp:TextBox ID="txtOctAmo" runat="server" CssClass="txtBox" Text='<%# Bind("OctAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Oct"  ItemStyle-HorizontalAlign="right" SortExpression="OctTol"><ItemTemplate>
            <asp:TextBox ID="txtOctTol" runat="server" CssClass="txtBox" Text='<%# Bind("OctTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Nov"  ItemStyle-HorizontalAlign="right" SortExpression="NovAmo"><ItemTemplate>
            <asp:TextBox ID="txtNovAmo" runat="server" CssClass="txtBox" Text='<%# Bind("NovAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
           </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Nov"  ItemStyle-HorizontalAlign="right" SortExpression="NovTol"><ItemTemplate>
            <asp:TextBox ID="txtNovTol" runat="server" CssClass="txtBox" Text='<%# Bind("NovTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Dec" SortExpression="DecAmo"><ItemTemplate>
            <asp:TextBox ID="txtDecAmo" runat="server" CssClass="txtBox" Text='<%# Bind("DecAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Dec" SortExpression="DecTol"><ItemTemplate>
            <asp:TextBox ID="txtDecTol" runat="server" CssClass="txtBox" Text='<%# Bind("DecTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Jan" SortExpression="JanAmo"><ItemTemplate>
            <asp:TextBox ID="txtJanAmo" runat="server" CssClass="txtBox" Text='<%# Bind("JanAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Jan" SortExpression="JanTol"><ItemTemplate>
            <asp:TextBox ID="txtJanTol" runat="server" CssClass="txtBox" Text='<%# Bind("JanTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
          
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Amount Feb" SortExpression="FebAmo"><ItemTemplate>
            <asp:TextBox ID="txtFebAmo" runat="server" CssClass="txtBox" Text='<%# Bind("FebAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Feb" SortExpression="FebTol"><ItemTemplate>
            <asp:TextBox ID="txtFebTol" runat="server" CssClass="txtBox" Text='<%# Bind("FebTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Amount Mar" SortExpression="MarAmo"><ItemTemplate>
            <asp:TextBox ID="txtMarAmo" runat="server" CssClass="txtBox" Text='<%# Bind("MarAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
           
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Mar" SortExpression="MarTol"><ItemTemplate>
            <asp:TextBox ID="txtMarTol" runat="server" CssClass="txtBox" Text='<%# Bind("MarTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Amount Apr" SortExpression="AprAmo"><ItemTemplate>
            <asp:TextBox ID="txtAprAmo" runat="server" CssClass="txtBox" Text='<%# Bind("AprAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Apr" SortExpression="AprTol"><ItemTemplate>
            <asp:TextBox ID="txtAprTol" runat="server" CssClass="txtBox" Text='<%# Bind("AprTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            </asp:TemplateField>
             
            <asp:TemplateField HeaderText="Amount May" SortExpression="MayAmo"><ItemTemplate>
            <asp:TextBox ID="txtMayAmo" runat="server" CssClass="txtBox" Text='<%# Bind("MayAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
            </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance May" SortExpression="MayTol"><ItemTemplate>
            <asp:TextBox ID="txtMayTol" runat="server" CssClass="txtBox"  Text='<%# Bind("MayTol") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             </asp:TemplateField>
               
            <asp:TemplateField HeaderText="Amount Jun" SortExpression="JunAmo"><ItemTemplate>
            <asp:TextBox ID="txtJunAmo" runat="server" CssClass="txtBox" Text='<%# Bind("JunAmo") %>' DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             </asp:TemplateField>
              
            <asp:TemplateField HeaderText="Tolerance Jun" SortExpression="JunTol"><ItemTemplate>
            <asp:TextBox ID="txtJunTol" runat="server" CssClass="txtBox" Text='<%# Bind("JunTol") %>'  DataFormatString="{0:0.00}" Width="60px" onkeypress="return onlyNumbers();"></asp:TextBox></ItemTemplate>
             </asp:TemplateField>
                                          
                              
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
