<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndentApproval_UI.aspx.cs" Inherits="UI.Accounts.Approval.IndentApproval_UI" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <!DOCTYPE html>
     <html xmlns="http://www.w3.org/1999/xhtml">   
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
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

    <script type="text/javascript">
         function OpenHdnDiv() {
             $("#hdnDivision").fadeIn("slow");
             document.getElementById('hdnDivision').style.visibility = 'visible';
         }
         function ClosehdnDivision() {
             $("#hdnDivision").fadeOut("slow");
         }
    </script>
    <style type="text/css"> 
        .rounds {
            height:50px;
            width:100px;
           -moz-border-colors:25px;
         border-radius:25px;
         } 
   .HyperLinkButtonStyle { float:left; text-align:left; border: none; background: none; 
    color: blue; text-decoration: underline; font: normal 10px verdana;} 
    .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
    width:100%; height:50%; margin-left:auto; margin-right:10px;margin-top:10px; padding: 20px; overflow-y:scroll; }
  
     </style>
     <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        
        }
        .ddList {}
        .txtBox {}
        </style>
    </head>
    <body>
    <form id="frmaccountsrealize" runat="server">
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
       <asp:HiddenField ID="hdnIndent" runat="server" /><asp:HiddenField ID="hdnCOS" runat="server" />
    <asp:HiddenField ID="hdnintYear" runat="server" /><asp:HiddenField ID="hdnIntMonth" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hdnCOA" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            <div class="leaveApplication_container">
    <div class="tabs_container" align="Left" >Indent Approval Form</div>
   
        <table>
        <tr>       
        <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Unit-:"></asp:Label></td>
                    
        <td style="text-align: left;"><asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged" >
        </asp:DropDownList></td> 
        <td style="text-align:right;"><asp:Label ID="lblwh" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Ware-House:"></asp:Label></td>
                    
        <td style="text-align: left;"><asp:DropDownList ID="ddlwh" runat="server" CssClass="ddList" Font-Bold="true" AutoPostBack="True">
        </asp:DropDownList></td></tr>
        <tr>
                
        <td style="text-align:right;"><asp:Label ID="lblfdate" runat="server" CssClass="lbl"  Font-Bold="true" Text="From Date"></asp:Label></td>
        <td><asp:TextBox ID="txtFdate" runat="server" Font-Bold="true" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtenderMonthly" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFdate"></cc1:CalendarExtender></td>

        <td style="text-align:right;"><asp:Label ID="lblTodate" runat="server" CssClass="lbl"  Font-Bold="true" Text="To Date"></asp:Label></td>
        <td><asp:TextBox ID="txtTodate" runat="server" Font-Bold="true" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTodate"></cc1:CalendarExtender></td></tr>
        <tr>
        <td></td><td><asp:RadioButton ID="radApprove" GroupName="indent" Text="Approved" AutoPostBack="true" runat="server" OnCheckedChanged="radApprove_CheckedChanged" /><asp:RadioButton ID="radPending" runat="server" GroupName="indent" AutoPostBack="true" Text="Pending" OnCheckedChanged="radPending_CheckedChanged" /></td>
        <td></td><td><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td></tr>  
                        
        </Table>
          <table>
                     
              <tr>
                  
              <td> <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
                   <Columns>
                    <asp:TemplateField HeaderText="SL.N">
                    <ItemTemplate>  <%# Container.DataItemIndex + 1 %>
                   <asp:HiddenField  ID="hdnIndentID" runat="server" Value='<%# Bind("intIndentID") %>'></asp:HiddenField>
                   <asp:HiddenField  ID="hdnCostCenter" runat="server" Value='<%# Bind("intCostCenter") %>'></asp:HiddenField>
                    <asp:HiddenField  ID="hdnglobalCoA" runat="server" Value='<%# Bind("intGlobalCOA") %>'></asp:HiddenField>

                      </ItemTemplate>  </asp:TemplateField>
                      <asp:BoundField DataField="intIndentID" HeaderText="IndentNo" SortExpression="intIndentID"  />
                    
                      <asp:TemplateField HeaderText="IndentDate">                                 
                       <ItemTemplate> <asp:Label ID="lblIndentDate" runat="server" Text='<%#Eval("dteIndentDate", "{0:dd-MM-yyyy}") %>' ></asp:Label> </ItemTemplate>                                 
                       </asp:TemplateField>
                             
                       <asp:BoundField DataField="dteForwardDate" HeaderText="ForwardDate" SortExpression="dteForwardDate" DataFormatString="{0:dd-M-yyyy}" />
                       <asp:BoundField DataField="dteBudgetMonth" HeaderText="ForwardDate" SortExpression="dteBudgetMonth" DataFormatString="{0:dd-M-yyyy}" />
                      
                       <asp:BoundField DataField="strIndentType" HeaderText="IndentType" SortExpression="strIndentType" />
                       <asp:BoundField DataField="dteAccountAppTime" HeaderText="AccountAppTime" SortExpression="dteAccountAppTime"  />
                       <asp:BoundField DataField="strCCName" HeaderText="CCName"  SortExpression="strCCName" />
                        
                       <asp:TemplateField HeaderText="Detalis">
                                 
                        <ItemTemplate><asp:Button ID="btnDetalis" runat="server" Text="Detalis" CommandName="Detalis" CommandArgument='<%#GetJSFunctionString( Eval("intIndentID"),Eval("dteBudgetMonth"),Eval("intGlobalCOA"),Eval("intCostCenter")) %>' OnClick="btnIndentDetalis_Click" /> </ItemTemplate>
                                
                        </asp:TemplateField>
                       
           </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           </asp:GridView>  </td> </tr>
                
                  
                  
             
          </table>
   
        <div id="hdnDivision" class="hdnDivision" style="width:auto;">
            <table>
            <tr class="tblrowodd"><td colspan="3" style="text-align:left;"><asp:Label ID="lbldetalis" Font-Size="Small" Font-Bold="true" CssClass="lbl" runat="server"></asp:Label>
          </td></tr>
            <tr><td style="text-align:right;"><asp:Label ID="lblCost" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="CostCenter-:"></asp:Label></td>
                   
            <td style="text-align: left;"><asp:DropDownList ID="ddlCostCenter" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlCostcenter_SelectedIndexChanged"  >
            </asp:DropDownList></td>
           <td style="text-align:right;"><asp:Label ID="lblCoa" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="COA-:"></asp:Label></td>
                   
            <td style="text-align: left;"><asp:DropDownList ID="ddlCOA" runat="server" AutoPostBack="True" CssClass="ddList" OnSelectedIndexChanged="ddlCOA_SelectedIndexChanged" Font-Bold="true"  >
            </asp:DropDownList></td>
            </tr> 
            <tr>
            <td style="text-align:right;"><asp:Label ID="tblBudget" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Budget-:"></asp:Label></td>
                   
            <td style="text-align: left;"><asp:TextBox ID="txtBudget" runat="server" CssClass="ddList" Font-Bold="true"  >
            </asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="lblRemaing" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Remaining-:"></asp:Label></td>
                   
            <td style="text-align: left;"><asp:TextBox ID="txtRemaing" runat="server" CssClass="ddList" Font-Bold="true"  >
            </asp:TextBox></td>
        
            </tr>   
                </table>
            <table>       
           <tr>
            <td style="text-align:right;"><asp:Label ID="lblnaration" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Narration:"></asp:Label></td>
                   
            <td style="text-align: left;"><asp:TextBox ID="txtNarration" TextMode="MultiLine" runat="server" Width="550px" CssClass="ddList" Font-Bold="true"  >
            </asp:TextBox></td>
            </tr>
            <tr>
          <td></td>
          <td style="text-align:right;"><asp:Button ID="btnDivClose" runat="server"  OnClick="btnDivClose_Click"  Text="Close" />
           <asp:Button ID="btnApproved" runat="server" Text="Approve" OnClick="btnApproved_Click" /></td>
     
           </tr>
         </table>
        <table>          
            <tr><td><asp:GridView ID="dgvDetalis" ShowFooter="true" runat="server"  AutoGenerateColumns="False" BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>                 
               <asp:TemplateField HeaderText="Sl.N"> <ItemTemplate> <%# Container.DataItemIndex + 1 %>
                 <asp:HiddenField  ID="hdnItemID" runat="server" Value='<%# Bind("intItemID") %>'></asp:HiddenField>
                 
                 </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="strItem" HeaderText="ItemName"  SortExpression="strItem"  ItemStyle-HorizontalAlign="left" />
                <asp:BoundField DataField="numQty" HeaderText="Qty" SortExpression="numQty" DataFormatString="{0:N}" />
                <asp:BoundField DataField="lastprice" HeaderText="LastPrice" SortExpression="lastprice" DataFormatString="{0:N}"/>
               </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />                     
              </asp:GridView> </td></tr> 
                             
            </table>
            </div>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
