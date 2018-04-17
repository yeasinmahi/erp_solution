<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportApproval.aspx.cs" Inherits="UI.Import.ImportApproval" %>

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
        
     <script>   function CloseWindow() { window.close();  }</script>

   <script>
       function DocViewData(url) {
           newwindow = window.open(url, 'height=550, width=850, scrollbars=yes, left=300, top=180, resizable=yes, title=Preview');
           if (window.focus) { newwindow.focus() }
         }
        
         </script> 

    <style type="text/css">
        .dynamicDivbn {
            margin: 5px 5px 5px 5px;    width: Auto; 
    	    height: auto;
            background-color:#FFFFFF;
            font-size: 11px;
            font-family: verdana;
            color: #000;
            padding: 5px 5px 5px 5px;
        }
    .frame { width: 99%; height: 550px; border: 0px; }
    .frame {zoom: 0.99;-moz-transform: scale(0.99);-moz-transform-origin: 0 0;-o-transform: scale(0.99);-o-transform-origin: 0 0;
    -webkit-transform: scale(0.99);-webkit-transform-origin: 0 0}
    </style>

     <style>
        .verticaltext
        {
            /*flipv*/

            writing-mode: bt-rl   ;
            /*filter:  fliph ;*/
            color: Maroon;
             width: Auto;
              padding:Auto;
             
            
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnTopSheetCount" runat="server" />
   
        
        <div class="tabs_container">INDENT DETALIS REPORT <hr /></div>
        
   <table>
       <tr>
        <td> <b><h3>Quotation wise summary</h3></b></td>
    </tr>
      
           <tr>
               <td>
                   <asp:GridView ID="DgvApproval" runat="server"  Font-Size="Small" AutoGenerateColumns="False">
                       <Columns>
                           <asp:TemplateField HeaderText="SL.">
                               <ItemTemplate>
                                   <%# Container.DataItemIndex + 1 %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:BoundField DataField="intSupplier" HeaderText="Supplier ID" SortExpression="intSupplier" Visible="False" />
                           <asp:BoundField DataField="strSColumn" HeaderText="SColumn" SortExpression="strSColumn" Visible="False" />
                           <asp:BoundField DataField="strSupplier" HeaderText="Supplier Name" SortExpression="strSupplier" />
                           <asp:BoundField DataField="StrDocumentLink" HeaderText="PathFile" SortExpression="StrDocumentLink" Visible="false" />
                           <asp:BoundField DataField="monQoutedAmount" HeaderText="TotalAmount" SortExpression="monQoutedAmount" />
                           <asp:TemplateField HeaderText="Remarks"><ItemTemplate><asp:TextBox ID="txtRemarks" Width="200px" runat="server"   /></ItemTemplate></asp:TemplateField> 
                           
                           
                           <asp:TemplateField HeaderText="View Doc">
                               <ItemTemplate>
                                   <asp:Button ID="BtnView" runat="server" CommandArgument='<%#Eval("StrDocumentLink") %>' OnClick="BtnView_Click" Text="View" />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Approve">
                               <ItemTemplate>
                                   <asp:Button ID="BtnApprove" runat="server" CommandArgument='<%#Eval("intSupplier") %>' OnClick="BtnApprove_Click" Text="Approve" />
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
        <td> <b><h3>Quotation wise details</h3></b></td>
    </tr>
  
    
    <tr>
        <td>
          <asp:GridView ID="DgvReport"  OnRowDataBound="DgvReport_RowDataBound"    runat="server" >
              
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td><asp:Button ID="BtnDownload" runat="server"   Text="Download" /></td>
    </tr>
</table>
        </div>
        <div  style="width:auto;">
      <table style="width:auto;">
         
          <asp:PlaceHolder ID="myPanel" runat="server"></asp:PlaceHolder>
        </table>
            
            </div>
            
         
                
         
        
       
       
        
       
       
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
