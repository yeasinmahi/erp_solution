<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeetingMinutesPrint.aspx.cs" Inherits="UI.HR.Visitors.MeetingMinutesPrint" %>


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
       <%-- <script>
            function Registration(url) {
                newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
                if (window.focus) { newwindow.focus() }
            }
         </script>--%>

    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container">  <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                
    <div class="tabs_container" align="left">Meeting Minutes</div>
       
         <br />
         
         <table > 
             
             <tr >
             <td style="text-align: left;"><asp:Label ID="LblMinutes" align="" runat="server" width="180"  Style="text-align: left" CssClass="lbl" Text="Meeting Title :"></asp:Label></td>
             <td style="text-align: left;"><asp:Textbox ID="TxtMinuts" CssClass="Textbox" Font-Bold="False" Width="600" runat="server" ></asp:Textbox>
                 </tr>
             
             </table>
         <table>

             <tr>         
             <td style="text-align:left;" ><asp:Label ID="LblMetInfo" runat="server" Style="text-align: left"  CssClass="lbl" width="180" Text="Meeting Information :"></asp:Label></td>
             <td  style="text-align:left;"><asp:Textbox ID="TxtMetInfo" CssClass="Textbox" Font-Bold="False" runat="server"  Width="600px"></asp:Textbox> 
            </tr>
             </table>
         <table>
            <tr>
            <td style="text-align:left;" ><asp:Label ID="LblObjective" runat="server" Style="text-align: left"  CssClass="lbl" width="180" Text="Objective :"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="TxtObjective" CssClass="Textbox" Font-Bold="False" runat="server" Width="600px"></asp:Textbox> 
            </tr>
          </table>
          <table>
            <tr>
                 <td style="text-align:right;" ><asp:Label ID="LblLocation" runat="server"  Style="text-align: left"  width="180" CssClass="lbl" Text="Location :"></asp:Label></td>
            <td style="text-align:left;"  ><asp:Textbox ID="TxtLocation" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

            <td style="text-align:right;" ><asp:Label ID="LblCalled" runat="server" Style="text-align: left"  CssClass="lbl" Text="Called By :"></asp:Label></td>
           <td style="text-align:left;"  ><asp:Textbox ID="TxtCalled" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
               
         
            </tr>
              <tr>
            <td style="text-align:right;"  ><asp:Label ID="LblDte" Style="text-align: left" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td><asp:TextBox ID="txtDte" runat="server" CssClass="txtBox"></asp:TextBox>
            
              <td style="text-align:right;" ><asp:Label ID="LblReffNo" runat="server" CssClass="lbl" Text="Reff No :"></asp:Label></td>
           <td style="text-align:left;"  ><asp:Textbox ID="TxtReffNo" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 
                

            <%--<%--<td style="text-align:right;"><%--<asp:Label ID="LblTime" runat="server" CssClass="lbl" Text="Time :"></asp:Label></td>--%>
            
           <%--  <td><asp:TextBox ID="TxtTime" runat="server" CssClass="txtBox"></asp:TextBox>--%>
             </tr>
              <tr>
                 <td style="text-align:right;" ><asp:Label ID="LblStarttime" runat="server" CssClass="lbl" Text="Meeting Start Time :"></asp:Label></td>
            <td><asp:TextBox ID="TxtStartTime" runat="server" CssClass="txtBox"></asp:TextBox>
                 <td style="text-align:right;" ><asp:Label ID="LblEndtime" runat="server" CssClass="lbl" Text="Meeting End Time:"></asp:Label></td>
           <td><asp:TextBox ID="TxtEndTime" runat="server" CssClass="txtBox"></asp:TextBox>
            </tr>
            
          
  
            <tr><td></td></tr>
            </table>
         <left>
         <table>
             
           <tr>
                   <td class="auto-style7" ><asp:GridView ID="dgv" align="left" width="200" runat="server" AutoGenerateColumns="False" >
                       <Columns>
                           <asp:TemplateField HeaderText="Sl.">
                                <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="PersonAttendName">
                               <ItemTemplate>
                                   <asp:Label ID="Label12" runat="server" Text='<%# Bind("strPersonAttendName") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                       </asp:GridView>
                       <%--<asp:ObjectDataSource ID="odsPersonAttend" runat="server"  TypeName="HR_DAL.Visitors.MeetingReportTDS"></asp:ObjectDataSource>--%>
                   </td>
                   
               </tr>
           
       
                   
                      
                     <tr>
                         
                             
                        
                         <td>
                            <b> Meeting Minutes Agenda</b>
                         </td> 

                                                     
                     </tr>
                      
                      
                     
                     
                     <tr>

                         <td class="auto-style7">
                             <asp:GridView ID="dgv2" runat="server"  AutoGenerateColumns="False"  >
                                 <Columns>
                                     <asp:TemplateField HeaderText="Sl.No">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Agenda">
                                         <ItemTemplate>
                                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("strAgenda") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Presenter">
                                         <ItemTemplate>
                                             <asp:Label ID="Label3" runat="server" Text='<%# Eval("strPresenter") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Time Alloted">
                                         <ItemTemplate>
                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("strTimeAlloted") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                             </asp:GridView>
                         </td>
                     </tr>
                          
                           
                     
                     <tr>
                         <td>
                            <b> Meeting Minutes Decisions</b>
                         </td>
                         <tr>
                             <td class="auto-style7">
                                 <asp:GridView ID="dgv3" runat="server" AutoGenerateColumns="False">
                                     <Columns>
                                         <asp:TemplateField HeaderText="Sl.No">
                                             <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Decisions">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label5" runat="server" Text='<%# Eval("strDecissions") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                             </td>
                         </tr>
                         <tr>
                             <td><b>Next Meeting Schedule </b></td>
                         </tr>
                         <tr>
                             <td class="auto-style7">
                                 <asp:GridView ID="dgv4" runat="server" AutoGenerateColumns="False">
                                     <Columns>
                                         <asp:TemplateField HeaderText="Sl.No">
                                             <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Date"  >
                                             <ItemTemplate>
                                                 <asp:Label ID="Label8" runat="server"  Text='<%# Eval("Expr1" ,"{0:MMMM d, yyyy}") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Time">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label9" runat="server" Text='<%# Eval("Expr2") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Agenda">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label10" runat="server" Text='<%# Bind("strAgenda") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Name of Participants">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label11" runat="server" Text='<%# Eval("strParticipants") %>'></asp:Label>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>
                             </td>
                         </tr>
                     </tr>
         
                   
                  
               
           </table>

</left>


         
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
