<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportApproveStatus.aspx.cs" Inherits="UI.Import.ImportApproveStatus" %>

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
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
        

     <script>   function CloseWindow() { window.close(); }</script>
   <script>
       function DocViewData(url) {
           newwindow = window.open(url, 'scrollbars=yes,toolbar=0,height=600,width=1000,top=50,left=170, close=no');
           if (window.focus) { newwindow.focus() }
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnTopSheetCount" runat="server" />
   
        
        <div class="tabs_container">INDENT DETALIS REPORT <hr /></div>
        
   <table>
       <tr>
        <td> <b><h3>Quotation wise summary</h3></b></td>
    </tr>
      
       
    <tr>
        <td>
          <asp:GridView ID="DgvApproval" runat="server" Font-Size="Small" AutoGenerateColumns="False">
              <Columns>
                   <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                  <asp:BoundField DataField="intSupplier" HeaderText="Supplier ID" SortExpression="intSupplier" />
                   <asp:BoundField DataField="strSColumn" HeaderText="SColumn" SortExpression="strSColumn" />
                  <asp:BoundField DataField="strSupplier" HeaderText="Supplier Name" SortExpression="strSupplier" />
                 
                  <asp:BoundField DataField="StrDocumentLink" HeaderText="PathFile"  Visible="false" SortExpression="StrDocumentLink" />
                  <asp:BoundField DataField="monQoutedAmount"   HeaderText="QoutedAmount" SortExpression="monQoutedAmount" />
                  <asp:BoundField DataField="remarks"   HeaderText="Remarks" SortExpression="remarks" />
                  <asp:BoundField DataField="approve"   HeaderText="Status" SortExpression="approve" />
                  <asp:TemplateField HeaderText="View Doc">
                      <ItemTemplate>
                          <asp:Button ID="BtnView" runat="server" Text="View" CommandArgument='<%#Eval("StrDocumentLink") %>' OnClick="BtnView_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
              
            </asp:GridView>
        </td>
    </tr>
</table>   
<table>
     <tr>
        <td></td>
    </tr>
     <tr>
        <td></td>
    </tr>
    <tr>
        <td> <h4>Quotation wise details</h4></td>
    </tr>
  
    <tr>
        <td>
          <asp:GridView ID="DgvReport"  runat="server">
            </asp:GridView>
        </td>
    </tr>
</table>
       
       
        
       
       
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>