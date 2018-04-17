<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AFBLReconcile.aspx.cs" Inherits="UI.SAD.Corporate_sales.AFBLReconcile" %>
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
    
       <script>
           function Registration(url) {
               newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=400,width=700,top=50,left=150, close=no');
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
<div>
    <table>
    <tr class="tblroweven" > 
        
    <td style="text-align:justify;width:100%; font-size:12px; background-color:white;" " >
    
    <div>  
      <h3 class="td">Account Incomplete Amount </h3>      
    </div>
        
       </td>
    </tr> 
    </table>
    </div>
    <div style="width:100%">
        <table style="width:80%">
  

            <tr class='tblroweven'><td style="text-align:center;"><asp:Button ID="btnSubmit" runat="server" Text="Show" Font-Bold="true" OnClick="btnSubmit_Click" />

        </table>
   
      </div> 
       <table class="" style="width:100%; height:2px ">
    
           <caption>
               <p class="MsoNormal">
                   <center>
                       <tr>
                           <td class="auto-style1" style="text-align:justify;font-size:16px; background-color:white;">
                               <asp:GridView ID="dgvtrgt" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" DataKeyNames="intID" Font-Names="Calibri" Font-Size="12px" ForeColor="Black" GridLines="Vertical" >
                                   <AlternatingRowStyle BackColor="#CCCCCC" />
                                   <Columns>
                                       <asp:BoundField DataField="intID" HeaderText="intID" InsertVisible="False" ReadOnly="True" SortExpression="intID" Visible="false" />
                                       <asp:BoundField DataField="intAccountID" HeaderText="intAccountID" SortExpression="intAccountID" Visible="false" />
                                       <asp:BoundField DataField="date" HeaderText="date" ReadOnly="True" SortExpression="date" />
                                       <asp:BoundField DataField="strParticulars" HeaderText="strParticulars" SortExpression="strParticulars" />
                                       <asp:BoundField DataField="strChequeNo" HeaderText="strChequeNo" SortExpression="strChequeNo" Visible="false" />
                                       <asp:BoundField DataField="monAmount" HeaderText="monAmount" SortExpression="monAmount" />
                                       <asp:BoundField DataField="unit" HeaderText="unit" ReadOnly="True" SortExpression="unit" />
                                       <asp:BoundField DataField="bank" HeaderText="bank" ReadOnly="True" SortExpression="bank" />
                                       <asp:BoundField DataField="bankaccountid" HeaderText="bankaccountid" ReadOnly="True" SortExpression="bankaccountid" />
                                       <asp:TemplateField HeaderText="Complete">
                                           <ItemTemplate>
                                               <asp:Button ID="Option" runat="server" CommandArgument='<%# Eval("intID") %>' CommandName="complete" OnClick="Complete_Click" Text="Edit" />
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                                   <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                   <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                               </asp:GridView>
                               <p>
                               </p>
                           </td>
                       </tr>
                   </center>
                   <caption>
                       <p>
                       </p>
                   </caption>
                   <caption>
                       <p>
                       </p>
                   </caption>
               </p>
           </caption>
    </table>
  
<asp:HiddenField ID="hdnID" runat="server" /><asp:HiddenField ID="hdnamount" runat="server" />
      <asp:HiddenField ID="hdncheque" runat="server" /><asp:HiddenField ID="hdndate" runat="server" /><asp:HiddenField ID="hdnnaration" runat="server" />
      <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnbank" runat="server" />

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
