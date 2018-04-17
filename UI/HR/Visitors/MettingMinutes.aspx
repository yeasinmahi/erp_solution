<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MettingMinutes.aspx.cs" Inherits="UI.HR.Visitors.MettingMinutes" %>

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
        .auto-style1 {
            width: 526px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            width: 173px;
        }
        .auto-style6 {
            height: 26px;
            width: 173px;
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
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
     <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
                
    <div class="tabs_container" align="Center">Meeting Minutes</div>
        
         <br />
         <table>
             <tr>
             <td style="text-align:right;"><asp:Label ID="LblMinutes" runat="server" width="180" CssClass="lbl" Text="Meeting Title :"></asp:Label></td>
             <td><asp:Textbox ID="TxtMinuts" CssClass="Textbox" Font-Bold="False" Width="600" runat="server" ></asp:Textbox>
             </tr>
             </table>
         <table>

             <tr>         
             <td style="text-align:right;" ><asp:Label ID="LblMetInfo" runat="server" CssClass="lbl" width="180" Text="Meeting Information :"></asp:Label></td>
             <td  ><asp:Textbox ID="TxtMetInfo" CssClass="Textbox" Font-Bold="False" runat="server"  Width="600px"></asp:Textbox> 
            </tr>
             </table>
         <table>
            <tr>
            <td style="text-align:right;" ><asp:Label ID="LblObjective" runat="server" CssClass="lbl" width="180" Text="Objective :"></asp:Label></td>
            <td style="text-align:left;" ><asp:Textbox ID="TxtObjective" CssClass="Textbox" Font-Bold="False" runat="server" Width="600px"></asp:Textbox> 
            </tr>
          </table>
          <table>
            <tr>
                 <td style="text-align:right;" ><asp:Label ID="LblLocation" runat="server" width="180" CssClass="lbl" Text="Location :"></asp:Label></td>
            <td style="text-align:left;"  ><asp:Textbox ID="TxtLocation" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 

            <td style="text-align:right;" ><asp:Label ID="LblCalled" runat="server" CssClass="lbl" Text="Called By :"></asp:Label></td>
           <td style="text-align:left;"  ><asp:Textbox ID="TxtCalled" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox>
               
                <td style="text-align:right;" ><asp:Label ID="LblReffNo" runat="server" CssClass="lbl" Text="Meeting Reff No :"></asp:Label></td>
           <td style="text-align:left;"  ><asp:Textbox ID="TxtReffNo" CssClass="Textbox" Font-Bold="False" runat="server"></asp:Textbox> 
                
            </tr>
              <tr>
            <td style="text-align:right;"  ><asp:Label ID="LblDte" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>
            <td><asp:TextBox ID="txtDte" runat="server" CssClass="txtBox"></asp:TextBox>
            <cc1:CalendarExtender ID="CEJ" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDte"></cc1:CalendarExtender> </td>

            <td style="text-align:right;"><asp:Label ID="LblTime" runat="server" CssClass="lbl" Text="Time :"></asp:Label></td>
            
             <td><cc1:TimeSelector ID="TimeSelector1" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td>
             </tr>
              <tr>
                 <td style="text-align:right;" ><asp:Label ID="LblStarttime" runat="server" CssClass="lbl" Text="Meeting Start Time :"></asp:Label></td>
            <td><cc1:TimeSelector ID="TimeSelector2" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td> 
                 <td style="text-align:right;" ><asp:Label ID="LblEndtime" runat="server" CssClass="lbl" Text="Meeting End Time:"></asp:Label></td>
            <td ><cc1:TimeSelector ID="TimeSelector3" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td> 
            </tr>
              </table>
          <table>
           <tr>
           <td style="text-align:right;" ><asp:Label ID="LblPersonAttn" runat="server" width="180" CssClass="lbl" Text="Person attend of the metting :"></asp:Label></td>
           <td style="text-align:left;" ><asp:Textbox ID="TxtPersonAttn" CssClass="Textbox" Font-Bold="False" runat="server" Width="500px"></asp:Textbox> <asp:Button ID="BtnAtend" runat="server" Text="Add" OnClick="BtnAtend_Click"  />
            
               
           </tr>
             
        
            <tr><td></td></tr>
           <tr>
                   <td colspan="4"><asp:GridView ID="dgv" align="center"  runat="server" AutoGenerateColumns="False" OnRowDeleting="dgv_RowDeleting">
                       <Columns>
                           <asp:TemplateField HeaderText="Sl.No"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="Person Attend of the metting">
                               <ItemTemplate>
                                   <asp:Label ID="Label1" runat="server" Text='<%# Bind("pattend") %>'></asp:Label>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                       </Columns>
                       </asp:GridView></td>
                   
               </tr>
            </table>
                 <tr><td></td></tr>
         <tr><td></td></tr>
                   <table>
                       <tr><td></td></tr>
                     <tr>
                         <td style="text-align:right;"><asp:Label ID="LblAgenda" Width="180" runat="server" CssClass="lbl" Text="Agenda :"></asp:Label> </td>
                             
                        
                         <td  style="text-align:left;"> <asp:TextBox ID="TxtAgenda" runat="server" CssClass="Textbox" Font-Bold="False" Width="500px"></asp:TextBox>

                                                     
                     </tr>
                       </table>
                      <table>
                     <tr>
                         <td  style="text-align:right;"><asp:Label ID="LblPresenter" width="180" runat="server" CssClass="lbl" Text="Presenter :"></asp:Label></td>
                             
                         
                         <td ><asp:TextBox ID="TxtPresenter" runat="server" CssClass="Textbox" Font-Bold="False"></asp:TextBox>
                         <td><asp:Label ID="LblAlloted" runat="server" CssClass="lbl" Text="Time Allotted :"></asp:Label></td>   
                         <td><asp:TextBox ID="TxtAlloted" runat="server" CssClass="Textbox" Font-Bold="False"></asp:TextBox>     
                             
                         <td> <asp:Button ID="BtnAgenda" runat="server" OnClick="BtnAgenda_Click" Text="Add" /></td>
                     
                     </tr>
                        </table>
                       <table>
                     <tr>
                         <td class="auto-style5" style="text-align:right;"></td>
                         <td class="auto-style" style="text-align:left;"></td>
                     </tr>
                     <tr>
                         <td colspan="4">
                             <asp:GridView ID="dgv2" runat="server" align="center" AutoGenerateColumns="False" OnRowDeleting="dgv2_RowDeleting" >
                                 <Columns>
                                     <asp:TemplateField HeaderText="Sl.No">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Agenda">
                                         <ItemTemplate>
                                             <asp:Label ID="Label2" runat="server" Text='<%# Bind("agendaname") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Presenter">
                                         <ItemTemplate>
                                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("presentername") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Time Alloted">
                                         <ItemTemplate>
                                             <asp:Label ID="Label4" runat="server" Text='<%# Bind("timeallot") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                 </Columns>
                             </asp:GridView>
                         </td>
                     </tr>
                           <tr><td></td></tr>
                           
                     <tr>
                         <td class="auto-style5" style="text-align:right;">
                             <asp:Label ID="LblDecisions" runat="server" CssClass="lbl" Text="Decisions :"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style5" style="text-align:right;">
                             <asp:Label ID="Lbl1" runat="server" CssClass="lbl" Text="1 :"></asp:Label>
                         </td>
                         <td class="auto-style" style="text-align:left;">
                             <asp:TextBox ID="TxtDecssions1" runat="server" CssClass="Textbox" Font-Bold="False" Width="500px"></asp:TextBox>
                             <asp:Button ID="BtnDecissions" runat="server" OnClick="BtnDecissions_Click" Text="Add" />
                         </td>
                     </tr>
                    
                     
                     <tr>
                         <td colspan="4">
                             <asp:GridView ID="dgv3" runat="server"  align="center"  AutoGenerateColumns="False" OnRowDeleting="dgv3_RowDeleting" >
                                 <Columns>
                                     <asp:TemplateField HeaderText="Sl.No">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Decisions">
                                         <ItemTemplate>
                                             <asp:Label ID="Label5" runat="server" Text='<%# Bind("decission1") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                 </Columns>
                             </asp:GridView>
                         </td>
                     </tr>
                           </table>
         <div class="tabs_container" align="Center">Next Meeting Schedule</div>
                     <table>
                     <tr>
                         <td style="text-align:Right;"><asp:Label ID="LblDteNextmet" width="180" runat="server" CssClass="lbl" Text="Date :"></asp:Label> </td>
                           <td ><asp:TextBox ID="TxtDteNextmet" runat="server" CssClass="txtBox"></asp:TextBox>    
                         <cc1:CalendarExtender ID="CEDteNextmet" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtDteNextmet">
                         </cc1:CalendarExtender>
                            <td style="text-align:Right;"><asp:Label ID="Lbltimeselector" runat="server" CssClass="lbl" Text="Time:"></asp:Label> </td>
                            <td><cc1:TimeSelector ID="TimeSelector4" runat="server" AllowSecondEditing="true"></cc1:TimeSelector></td> 
                             
                            
                             
                        
                     </tr>
                    </Table>
                    <table>
                     <tr>
                         <td style="text-align:right;">
                             <asp:Label ID="LblNextAgenda" runat="server" CssClass="lbl" Text="Agenda:"></asp:Label>
                         </td>
                         <td class="auto-style" style="text-align:left;">
                             <asp:TextBox ID="TxtNextAgenda" runat="server" CssClass="Textbox" Font-Bold="False" Width="524px"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td  style="text-align:right;">
                             <asp:Label ID="LblParticipants" runat="server" CssClass="lbl" Text="Name of the participants:"></asp:Label>
                         </td>
                         <td class="auto-style" style="text-align:left;">
                             <asp:TextBox ID="TxtParticipants" runat="server" CssClass="Textbox" Font-Bold="False" width="524"></asp:TextBox>
                             <asp:Button ID="BtnNextMetting" runat="server" OnClick="BtnNextMetting_Click" Text="Add" />
                             <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" Width="90px" />
                         </td>
                     </tr>
                        <tr><td></td></tr>
                     <tr>
                         <td colspan="4">
                             <asp:GridView ID="dgv4" runat="server" align="center" AutoGenerateColumns="False"  OnRowDeleting="dgv4_RowDeleting">
                                 <Columns>
                                     <asp:TemplateField HeaderText="Sl.No">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Date">
                                         <ItemTemplate>
                                             <asp:Label ID="Label8" runat="server" Text='<%# Bind("dtenextmet") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Time">
                                         <ItemTemplate>
                                             <asp:Label ID="Label9" runat="server" Text='<%# Bind("nextmettime") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Agenda">
                                         <ItemTemplate>
                                             <asp:Label ID="Label10" runat="server" Text='<%# Bind("nextagenda") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Name of Participants">
                                         <ItemTemplate>
                                             <asp:Label ID="Label11" runat="server" Text='<%# Bind("nextparticipant") %>'></asp:Label>
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                     <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                 </Columns>
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

