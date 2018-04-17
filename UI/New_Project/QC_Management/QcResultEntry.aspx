<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QcResultEntry.aspx.cs" Inherits="UI.QC_Management.QcResultEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html >
<html >
<head >
    <title>Untitled Page</title>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
        </asp:PlaceHolder>  
    
    <webopt:BundleReference ID="BundleReference4" runat="server" Path="~/Content/Bundle/hrCSS" />
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />
             
    <script>
        function Save() {
            document.getElementById("hdnApprove").value = "1";
            __doPostBack();
        }
</script>

    

</head>
<body>
    <form id="frmshvssls" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
       <CompositeScript>
           <Scripts>
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

           </Scripts>
       </CompositeScript>

    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;">

    </div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>
<%--=========================================Start My Code From Here===============================================--%>
        <asp:HiddenField ID="HdfSearchbox" runat="server" /><asp:HiddenField ID="HdfTechnicinCode" runat="server" />
        <center>
         <table>
            
              <tr>
                <td style="background-color:#e9dddd">
                     &nbsp;</td>
               
                
               
            </tr>  
            <tr>
                <td>
                   
                    
                    <table>
                    
                        

                       
                
                <tr><td style="text-align:left" class="auto-style7">
                  <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_" Height="26px"></asp:Button>
                 <asp:HiddenField ID="hdnApprove" runat="server" />
                       <a class="nextclick" onclick="Save()">Approve</a> 



<asp:FileUpload ID="dupload" runat="server"></asp:FileUpload>


                    </td>
                    <td class="auto-style7">
                    <label id="Label8" runat="server" ></label>

                    </td>

                </tr>
                          
                       
                    </td>
                    </tr>
                    <tr>
                        <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical" Font-Names="Calibri" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>



                        
                          <asp:TemplateField HeaderText="intid" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="itemid" runat="server" Value='<%# Eval("intid") %>' /><asp:HiddenField ID="idintitemids" runat="server" Value='<%# Eval("intid") %>' />
                         <asp:Label ID="lblintid" runat="server" Text='<%# Bind("intid") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField> 

                             
                          <asp:TemplateField HeaderText="itemid" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="itemidstest" runat="server" Value='<%# Eval("itemid") %>' /><asp:HiddenField ID="idintitemidsss" runat="server" Value='<%# Eval("itemid") %>' />
                         <asp:Label ID="lblitemid" runat="server" Text='<%# Bind("itemid") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField> 
                        
                          <asp:TemplateField HeaderText="strItemName" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="strItemName" runat="server" Value='<%# Eval("strItemName") %>' /><asp:HiddenField ID="stritemnamesss" runat="server" Value='<%# Eval("strItemName") %>' />
                         <asp:Label ID="lblstrItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField>                        
                        
                          <asp:TemplateField HeaderText="strattributename" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="strattributename" runat="server" Value='<%# Eval("strattributename") %>' /><asp:HiddenField ID="stratrbutes" runat="server" Value='<%# Eval("strattributename") %>' />
                         <asp:Label ID="lblstrattributename" runat="server" Text='<%# Bind("strattributename") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField>                        
                        
                        <asp:TemplateField HeaderText="labeqptname" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="labeqptnames" runat="server" Value='<%# Eval("labeqptname") %>' /><asp:HiddenField ID="strastrbutes" runat="server" Value='<%# Eval("labeqptname") %>' />
                         <asp:Label ID="lbllabeqptname" runat="server" Text='<%# Bind("labeqptname") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField>                        
                        
                        <asp:TemplateField HeaderText="labeqptid" SortExpression="id"><ItemTemplate>
                         <asp:HiddenField ID="labeqptid" runat="server" Value='<%# Eval("labeqptid1") %>' /><asp:HiddenField ID="strastrbutesss" runat="server" Value='<%# Eval("labeqptid1") %>' />
                         <asp:Label ID="lbllabeqptid" runat="server" Text='<%# Bind("labeqptid1") %>'></asp:Label></ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" BorderStyle="Inset" Height="5px" Width="60px"/></asp:TemplateField>                        
                        
                       
 
  <asp:TemplateField HeaderText="Result Currect" SortExpression="strMntCategory">
                               <ItemTemplate> 
                                  <asp:DropDownList Width="150px" ID="DropDownList117" BackColor="#6fb7ff" runat="server"  AutoPostBack="false">
                                      <asp:ListItem Value="1">--Select--</asp:ListItem>
                                      <asp:ListItem Value="2">Ok</asp:ListItem>
                                        <asp:ListItem Value="3">No</asp:ListItem>
                                  
                                </asp:DropDownList>
                                   

                               </ItemTemplate>
                             </asp:TemplateField> 
                        
       <%--  <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity"> <ItemTemplate>
       
         <asp:TextBox ID="lblqty"  CssClass="txtBox" runat="server"  Width="75px"  Text='<%# Bind("Qty") %>'    ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" />
         </asp:TemplateField>--%>

                      
                     
          <asp:TemplateField HeaderText="Result Entry" SortExpression="Quantity">
        <ItemTemplate>
         <asp:HiddenField  ID="rate" runat="server" Value='<%# Bind("Qty") %>'></asp:HiddenField>
        <asp:TextBox ID="lblqty" CssClass="txtBox" runat="server" Width="75px" Text='<%# Bind("Qty") %>' AutoPostBack="false" ></asp:TextBox></ItemTemplate>
        <ItemStyle HorizontalAlign="Left" Width="75px" />
        </asp:TemplateField>

        

                    </Columns>
                  <FooterStyle BackColor="#F3CCC2" BorderStyle="Outset" />
                    
                    <HeaderStyle BackColor="Black" Font-Bold="True" BorderStyle="Outset" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    
                             
                          
                </td>
             
               </tr>
             <tr>
                 <td>
                     
              </td>
             </tr>
        </table>
                        </div>
       
        </td>
             </tr>
                </table>
         </center>
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>   
    </form>
</body>
</html>

