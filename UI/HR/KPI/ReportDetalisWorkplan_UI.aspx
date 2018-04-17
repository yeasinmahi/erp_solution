<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDetalisWorkplan_UI.aspx.cs" Inherits="UI.HR.KPI.ReportDetalisWorkplan_UI" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
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
   
    
       <script>
           function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
           function RefreshParent() {
               if (window.opener != null && !window.opener.closed) {
                   window.opener.location.reload();
               }
           }
        </script> 
    


      

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>
    </head>

     <body>
    <form id="form1" runat="server">

<%--<body>
    <form id="frmaccountsrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
   <%-- <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>






<%--=========================================Start My Code From Here===============================================--%>
       <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnmail" runat="server" />  <asp:HiddenField ID="HiddenForward"  runat="server" />       
    <div class="tabs_container" align="Center" >Work Plan</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #808080;"class="tblrowodd" >
          
           <tr  class="tblrowodd">
           <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Subject:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtSubject" runat="server" CssClass="txtBox" Width="600px" Font-Bold="False"></asp:TextBox></td>
          </tr>
           <tr>
               <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="Description:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False" Height="75px" Width="600px" TextMode="MultiLine"></asp:TextBox></td>
      
           </tr>
           
           <td> Document</td>
           <tr><td colspan="2"> 
            <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>

            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                    <asp:BoundField DataField="intID" HeaderText="ID"  SortExpression="intID" >
             <ItemStyle HorizontalAlign="Left" Width="100px"/> </asp:BoundField>
            <asp:TemplateField HeaderText="File Name" SortExpression="strFileName"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFtpPath") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="430px"/></asp:TemplateField>

                                              
            

                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" runat="server" Text="DownLoad" CommandArgument='<%# Eval("strFtpPath") %>'  OnClick="btnDownload_Click" />
                    </ItemTemplate>
                </asp:TemplateField>

                                              
            
                
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
        </tr>
                  
         </table> 
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
   
    </form>
</body>
</html>
