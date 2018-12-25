<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRequisitionDetalis.aspx.cs" Inherits="UI.SCM.BOM.EditRequisitionDetalis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="MKB" %>

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
        .auto-style1 {
            height: 26px;
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

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Production Output<hr /></div>
         
        
         
           
        <table style="width:900px"> 
            <tr> 
                
            <td style="text-align:right;"   ><asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="true"  Text="SR Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtDate" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="claenderDte" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
              
            </tr>
              </table>
          
         

         <table style="border-color:black;  width:900px;border-radius:10px;">
             <caption style="text-align:left; color:blue">Item Detalis</caption>
            <tr>
            <td>
             <asp:GridView ID="dgvReq"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical"  >
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns> 

            <asp:TemplateField HeaderText="SR NO"   ItemStyle-HorizontalAlign="right" SortExpression="intReqID" >
            <ItemTemplate><asp:Label ID="LblSr" runat="server"  Text='<%# Bind("intReqID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Production"   ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblProduction" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Item ID"   ItemStyle-HorizontalAlign="right" SortExpression="intItemID" >
            <ItemTemplate><asp:Label ID="lblItemId" Width="60px" runat="server"  Text='<%# Bind("intItemID" ) %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Req Qty" ItemStyle-HorizontalAlign="right" SortExpression="numApproveQty" >
            <ItemTemplate><asp:Label ID="lblStore" runat="server"  Width=""  Text='<%# Bind("numApproveQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="Issue Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIssueQty" >
            <ItemTemplate><asp:Label ID="lblIssueQty" runat="server"  Width=""  Text='<%# Bind("numIssueQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="Remain Qty" ItemStyle-HorizontalAlign="right" SortExpression="numRemainToIssueQty" >
            <ItemTemplate><asp:Label ID="lblRemainQty" runat="server"  Width=""  Text='<%# Bind("numRemainToIssueQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
            </Columns>
            <FooterStyle Font-Size="11px" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>
            
        </table>
        <table style="border-color:black;  width:900px;border-radius:10px; ">
              
            <tr>
            <td>
             <asp:GridView ID="dgvItems"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical"  >
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns> 

            <asp:TemplateField HeaderText="ItemID"   ItemStyle-HorizontalAlign="right" SortExpression="intItemID" >
            <ItemTemplate><asp:Label ID="LblSr" runat="server"  Text='<%# Bind("intItemID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="ITEM"   ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblItem" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="UOM"   ItemStyle-HorizontalAlign="right" SortExpression="strUoM" >
            <ItemTemplate><asp:Label ID="lblUom" Width="60px" runat="server"  Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Production" ItemStyle-HorizontalAlign="right" SortExpression="intProdOrderID" >
            <ItemTemplate><asp:Label ID="lblProduction" runat="server"  Width=""  Text='<%# Bind("intProdOrderID") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  

            <asp:TemplateField HeaderText="REQ QTY" ItemStyle-HorizontalAlign="right" SortExpression="numApproveQty" >
            <ItemTemplate><asp:Label ID="lblReqQty" runat="server"  Width=""  Text='<%# Bind("numApproveQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
            <asp:TemplateField HeaderText="ISSUE QTY" ItemStyle-HorizontalAlign="right" SortExpression="numIssueQty" >
            <ItemTemplate><asp:Label ID="lblIssueQty" runat="server"  Width=""  Text='<%# Bind("numIssueQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 

             <asp:TemplateField HeaderText="REMAIN QTY" ItemStyle-HorizontalAlign="right" SortExpression="numRemainToIssueQty" >
            <ItemTemplate><asp:Label ID="lblRemainQty" runat="server"  Width=""  Text='<%# Bind("numRemainToIssueQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            
            </Columns>
            <FooterStyle Font-Size="11px" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td>
            </tr>
            
        </table>
        <table>
            <caption>


                <tr>
                    <td style="text-align:right;">
                        <asp:Label ID="lblitm" runat="server" CssClass="lbl" Font-Bold="true" Text="Item List :"></asp:Label>
                        <td>
                            <asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" AutoPostBack="true" CssClass="txtBox" Width="250px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetItemSerach" TargetControlID="txtItem">
                            </cc1:AutoCompleteExtender>
                        </td>
                        <td>
                            <asp:Label ID="lblUom" runat="server" Text="ChangeQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtChangeQty" runat="server" CssClass="txtBox" Text="0" Width="100px"></asp:TextBox>
                        </td>
                        <td style="text-align:right">
                            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click"   />
                            <asp:Button ID="btnSaves" runat="server" BackColor="#ffccff" Font-Bold="true" ForeColor="Black" Text="Save Edit" />
                        </td>
                    </td>
                </tr>
            </caption>
             
            </table>
            
    </div> 
    </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>