<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TADAInfoDelete.aspx.cs" Inherits="UI.SAD.Order.TADAInfoDelete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler" TagPrefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
     <script type="text/javascript">
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtEmployeeSearch").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "TADAInfoDelete.aspx/GetAutoCompleteData",
                         data: "{'strSearchKey':'" + document.getElementById('txtEmployeeSearch').value + "'}",
                         dataType: "json",
                         success: function (data) {
                             response(data.d);
                         },
                         error: function (result) {
                             alert("Error");
                         }
                     });
                 }
             });
         }


    </script>
</head>
<body>
    <form id="frmemployeepunishment" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        <CompositeScript><Scripts>
        <asp:ScriptReference name="MicrosoftAjax.js"/>
		<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
		<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
		<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
        </Scripts></CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
      


         <div class="leaveApplication_container"> 
    <div class="tabs_container"> TA - DA information Delete (Before approve by Supervisor)  :
         <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="HiddenField1" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
        <asp:HiddenField ID="hdnJobstationid" runat="server"/>
        <hr />
    </div>

        <table border="0"; style="width:Auto"; >    

         <tr>
                <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="Bill:  "></asp:Label>
                <td><asp:RadioButtonList ID="rdbUserOption" runat="server" OnSelectedIndexChanged="rdbUserOption_SelectedIndexChanged"
                RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Text="In- Active" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                 
                </asp:RadioButtonList>
                </td>  

                </tr>
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox" Width="350px" Enabled="true"></asp:TextBox>
         <cc1:CalendarExtender ID="CFD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEffectiveDate"></cc1:CalendarExtender>  
        </tr>
                

         <tr class="tblrowOdd"><td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
          
           <td>  <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" Width="350px" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
        </td>
             
             
              </tr>
           

        <tr class="tblrowOdd"><td style="text-align:right" colspan="2"> <asp:Button ID="btnShowdata" runat="server" Text="Show Bill Info" OnClick="btnShowdata_Click"/></td> 
           
                                                                                                                        
        </tr>
            </table>
            

           </div>
             <div class="leaveApplication_container"> 
                 <table>
              
          <tr class="tblroweven"><td>
              </td>
         </tr>          
         <tr class="tblrowOdd" >
             <td>
                 <asp:GridView ID="grdvTADAInfoDelete" runat="server" AutoGenerateColumns="False" PageSize="3000" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" HeaderStyle-Wrap="true" OnRowDataBound="grdvTADAInfoDelete_RowDataBound" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                    <%--intsl ,intID ,dteDate ,intENROL , ysnapprove ,decrowTotal ,strName ,strJobstation,strUnit--%>    
                   

                  <asp:BoundField DataField="intsl" HeaderText="Sl No." SortExpression="intsl" />
                  <asp:BoundField DataField="intID" HeaderText="PK ID" SortExpression="intid" />
                   <asp:BoundField DataField="dteDate" HeaderText="Bill date" DataFormatString="{0:dd/MM/yyyy}" SortExpression="dteDate" />
                   <asp:BoundField DataField="intENROL" HeaderText="Employe Enrol" SortExpression="intENROL" />
                   <asp:BoundField DataField="ysnapprove" HeaderText="Status" SortExpression="ysnapprove" />
                   <asp:BoundField DataField="decrowTotal" HeaderText="Total Bill" SortExpression="decrowTotal" />
                   <asp:BoundField DataField="strName" HeaderText="Name" SortExpression="strName" />
                     <asp:BoundField DataField="strJobstation" HeaderText="Jobstation" SortExpression="strJobstation" />
                  <asp:BoundField DataField="strUnit" HeaderText="Unit" SortExpression="strUnit" />
                  
                <asp:TemplateField HeaderText="Det.">
                <ItemTemplate>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="button" CommandName="complete" OnClick="btnSubmit_Click" CommandArgument='<%# Eval("intid")+","+Eval("intENROL")%>' /></ItemTemplate>
                </asp:TemplateField>  
    </Columns>
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>
             </td>
             
         </tr>  
  </table>
 </div>

<%--=========================================End My Code From Here=================================================--%>
   </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>