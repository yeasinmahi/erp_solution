<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionReport.aspx.cs" Inherits="UI.Inventory.RequisitionReport" %>

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
 
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>  
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .auto-style1 {
            height: 24px;
        }
        .auto-style2 {
            height: 139px;
        }
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    

             
    <div class="tabs_container" align="Center" >Requesition Details </div>
   
                <table class="tblrowodd" >                       
               <tr>            
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Requesition Code"  Font-Bold="true"></asp:Label></td>
                <td><asp:TextBox ID="TxtCode" runat="server" Font-Bold="true"  CssClass="txtBox"  ></asp:TextBox>                           
               <td><asp:Button ID="BtnShow" runat="server" Text="Show" OnClick="BtnShow_Click"  />
              
               </table>
            <table>             
           <tr> <td style=" text-align:start; vertical-align:top"><asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False"  Font-Size="12px" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
                 <Columns>
                 <asp:TemplateField HeaderText="SL.N"> 
                 <ItemTemplate>  <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>  
                <asp:TemplateField HeaderText="RequesitionCode" Visible="True">                                 
                <ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%# Eval("ReqCode") %>'></asp:Label></ItemTemplate> </asp:TemplateField>
                <asp:BoundField DataField="ItemName" HeaderText="ItemName" SortExpression="ItemName"/>      
                <asp:BoundField DataField="ReqDate"  DataFormatString="{0:dd-MMMM-yyyy}" HeaderText="ReqDate" SortExpression="ReqDate"/>
                <asp:BoundField DataField="ReqQty" HeaderText="ReqQty" SortExpression="ReqQty"/>  
                <asp:BoundField DataField="ApprovedDate" HeaderText="ApprovedDate"  DataFormatString="{0:dd-MMMM-yyyy}" SortExpression="ApprovedDate"/> 
                <asp:BoundField DataField="ApproveQty" HeaderText="ApproveQty" SortExpression="ApproveQty"/>
                <asp:BoundField DataField="IssueQty" HeaderText="IssueQty" SortExpression="IssueQty"/>  
                <asp:BoundField DataField="ReqBy" HeaderText="ReqBy" SortExpression="ReqBy"/>  
                <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovedBy" SortExpression="ApprovedBy"/>  
                </Columns>                   
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView></td>
              </tr>
          </table>
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
