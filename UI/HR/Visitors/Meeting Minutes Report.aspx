<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Meeting Minutes Report.aspx.cs" Inherits="UI.HR.Visitors.Meeting_Minutes_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .Textbox {}
        .auto-style6 {
            height: 17px;
            width: 400px;
        }
        .auto-style7 {
            width: 400px;
        }
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
         <script>
             function Registration(url) {
                 newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
                 if (window.focus) { newwindow.focus() }
             }
         </script> 

    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                
    <div class="tabs_container" align="Center">Meeting Minutes Report</div>
        
         <br />
         <table>
             <tr>

          <td style="text-align:right;"  ><asp:Label ID="LblDte" runat="server" CssClass="lbl" Text="From Date :"></asp:Label></td>
            <td><asp:TextBox ID="txtDtefo" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDtefo"></cc1:CalendarExtender> </td>


                  <td style="text-align:right;"  ><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To Date :"></asp:Label></td>
            <td><asp:TextBox ID="txtDteto" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtdteto"></cc1:CalendarExtender> </td>
               <td><asp:Button ID="Btnshow" runat="server" Text="Show" OnClick="BtnShow_Click" /></td>
                  </tr>
            
           
             
             <tr>
                
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
                         <Columns>
                             <asp:BoundField DataField="intid" HeaderText="ID" SortExpression="intid" />
                             <asp:BoundField DataField="strMeettitle" HeaderText="Meeting Title" SortExpression="strMeetTitle" />
                             <asp:BoundField DataField="strMeetinfo" HeaderText="Meeting Info" SortExpression="strMeetInfo" />
                             <asp:BoundField DataField="strlocation" HeaderText="Location" SortExpression="location" />
                             <asp:BoundField DataField="strCalledby" HeaderText="Called by" SortExpression="strCalledby" />
                             <asp:BoundField DataField="strReffno" HeaderText="ReffNo" SortExpression="strReffno" />
                             <asp:TemplateField HeaderText="Detalis">
                       

                                 <ItemTemplate>
                                     <asp:Button ID="Detalis" runat="server" Text="Detalis"  CommandName="Detalis" OnClick="BtnDetalis_Click" CommandArgument='<%# Eval("intid") %>' />"  
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                 
             </tr>
                 </table>




         
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
