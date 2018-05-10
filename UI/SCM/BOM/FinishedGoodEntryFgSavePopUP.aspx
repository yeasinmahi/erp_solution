<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinishedGoodEntryFgSavePopUP.aspx.cs" Inherits="UI.SCM.BOM.FinishedGoodEntryFgSavePopUP" %>

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
        <table style="width:750px">
            <tr>
            <td style="text-align:left">Product Name: 
           <asp:Label ID="lblProductName" runat="server"></asp:Label></td> 
            </tr>
            <tr>
            <td style="text-align:left">Production ID:
            <asp:Label ID="lblProductionId" runat="server"></asp:Label></td>
            <td>Plan Qty :
            <asp:Label ID="lblPlanQty" Text="100" runat="server"></asp:Label></td>
            <td>Date & Time :
            <asp:Label ID="lblDate" Text="2018-05-07 To 2018-05-07" runat="server"></asp:Label></td>
            </tr> 
        </table>
        
         
           
        <table style="width:900px"> 
            <tr> 
            <td style="text-align:right;"><asp:Label ID="lblitm" CssClass="lbl" Font-Bold="true" runat="server" Text="Item List :"></asp:Label>           
            <td ><asp:TextBox ID="txtItem" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  Width="250px" OnTextChanged="txtItem_TextChanged"  ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtItem"
            ServiceMethod="GetItemSerach" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td style="text-align:left;"  ><asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Bold="true"  Text="Date :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtDate" runat="server"   CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="claenderDte" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td>
             
             <td style="text-align:right;"  ><asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Bold="true"  Text="Time :"></asp:Label></td>
            <td style="text-align:left"><asp:TextBox ID="txtTime" runat="server" CssClass="txtBox" Width="50px" ></asp:TextBox></td>
            <td>Job No</td>
             <td><asp:TextBox ID="txtJob" runat="server" CssClass="txtBox" Width="70px" ></asp:TextBox></td>
            </tr>
              </table>
          <table>
            <tr>
                <%--<MKB:TimeSelector ID="tpkEndTime" runat="server" SelectedTimeFormat="TwentyFour" ></MKB:TimeSelector>--%>
                <td style="text-align:left; width:20px; display: inline"><asp:Label ID="lblProductQty" Font-Bold="true" runat="server" Text="Product Qty" ></asp:Label> </td>
                <td style="text-align:left" ><asp:TextBox ID="txtProductQty" Width="100px" Text="0" CssClass="txtBox" runat="server"></asp:TextBox></td> 
                 <td><asp:Label ID="lblUom1" runat="server"  ForeColor="Blue"></asp:Label></td>
                <td style="text-align:right" ><asp:Label  Font-Bold="true" ID="lblSendStore" runat="server" Text="Send To Store" ></asp:Label></td>
                <td  ><asp:TextBox ID="txtSendToStore"   CssClass="txtBox" Text="0" Width="100px" runat="server"></asp:TextBox></td>
                 <td><asp:Label ID="lblUom2" ForeColor="Blue" runat="server"></asp:Label></td>
                
                 <td style="text-align:right" ><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                <asp:Button ID="btnSaves" ForeColor="Black" BackColor="#ffccff" Font-Bold="true" runat="server" Text="Save" OnClick="btnSaves_Click" /></td> 
     
            </tr>
             
            </table>
        <table style="border-color:black;  width:900px;border-radius:10px;">
            <tr>
             <td>
             <asp:GridView ID="dgvStore"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" OnRowDeleting="dgvGridView_RowDeleting"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical"  >
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>   
            <asp:TemplateField HeaderText="Product Name"   ItemStyle-HorizontalAlign="right" SortExpression="item" >
            <ItemTemplate><asp:Label ID="lblProductName" runat="server"  Text='<%# Bind("item") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Time"   ItemStyle-HorizontalAlign="right" SortExpression="times" >
            <ItemTemplate><asp:Label ID="lblTime" runat="server"  Text='<%# Bind("times") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Production"   ItemStyle-HorizontalAlign="right" SortExpression="qty" >
            <ItemTemplate><asp:Label ID="lblProductionQty" Width="60px" runat="server"  Text='<%# Bind("qty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
                 
            <asp:TemplateField HeaderText="Store" ItemStyle-HorizontalAlign="right" SortExpression="storeQty" >
            <ItemTemplate><asp:Label ID="lblStore" runat="server"  Width=""  Text='<%# Bind("storeQty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
              
             <asp:TemplateField HeaderText="Job No" ItemStyle-HorizontalAlign="right" SortExpression="jobno" >
            <ItemTemplate><asp:Label ID="lblJobNo" runat="server"  Width=""  Text='<%# Bind("jobno") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField> 
            <asp:CommandField ShowDeleteButton="True" ControlStyle-ForeColor="Red" ControlStyle-Font-Bold="true" />
            </Columns>
                 <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
                </td>
            </tr>
             
        </table>

         <table style="border-color:black;  width:900px;border-radius:10px; border:1px solid blue;">
             <caption style="text-align:left; color:blue">Previous Entry</caption>
            <tr>
            <td>
             <asp:GridView ID="dgvProductionEntry"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical"  >
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns> 

            <asp:TemplateField HeaderText="Product Name"   ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblProductName" runat="server"  Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Time"   ItemStyle-HorizontalAlign="right" SortExpression="strTime" >
            <ItemTemplate><asp:Label ID="lblTime" runat="server"  Text='<%# Bind("strTime") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Production"   ItemStyle-HorizontalAlign="right" SortExpression="numProdQty" >
            <ItemTemplate><asp:Label ID="lblProductionQty" Width="60px" runat="server"  Text='<%# Bind("numProdQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Store" ItemStyle-HorizontalAlign="right" SortExpression="numSendStoreQty" >
            <ItemTemplate><asp:Label ID="lblStore" runat="server"  Width=""  Text='<%# Bind("numSendStoreQty","{0:n2}") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            
            </Columns>
            <FooterStyle Font-Size="11px" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
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
