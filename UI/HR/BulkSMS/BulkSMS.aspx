<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BulkSMS.aspx.cs" Inherits="UI.HR.BulkSMS.BulkSMS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html >
<html >
<head id="Head1" runat="server">
    <title>Bulk SMS </title>
    
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />  
 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    <CompositeScript>
    <Scripts>
    <asp:ScriptReference name="MicrosoftAjax.js"/>
    <asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
    <asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
    <asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
    <asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
    <asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
    <asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
    <asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
    </Scripts>
    </CompositeScript>
    </asp:ScriptManager>
 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
            <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
            <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
            scrolldelay="-1" width="100%">
            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
            </marquee>
            </div>
            <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
            <div>
            <table>
            <tr>
                <td>
                        </td>
                <td>
                </td>
                <td>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnUserID" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    <asp:HiddenField ID="hdfEmpCode" runat="server" />
                </td>
            </tr>
            </table>
            </div>
            </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
            runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            
            </ContentTemplate>
       
            </asp:UpdatePanel>
              
            <div style="background-color:#ccc;width:700px"   >
            <asp:RadioButton ID="RadioButton1" Text="Single SMS" GroupName="SMS" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" />
                    <asp:RadioButton ID="RadioButton2" Text="Bulk SMS" GroupName="SMS" AutoPostBack="true" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" />
            <table><tr><td>             
            <table> 
            <tr >
            <td> <asp:Label ID="Label1" runat="server" Text="Contact No:"></asp:Label>  </td>
            <td><asp:TextBox ID="TextBox2" CssClass="txtBox" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox></td>
            </tr>
            <tr>
            <td style="text-align:initial"> <asp:Label ID="Label2" runat="server" Text="Massage Type :"></asp:Label>  </td>
            <td><asp:TextBox ID="txtSMS" TextMode="MultiLine" Width="500px" Height=100px CssClass="txtBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            <td></td>
            <td style="text-align:right" > <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click" /> </td>
            <td rowspan="2"></td>
            </tr>
             
            </table>
            </td>
            <td>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  Font-Names="Calibri" Font-Size="Small">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:BoundField DataField="strFileName" HeaderText="File Name" ReadOnly="True" SortExpression="strFileName" />
            <asp:BoundField DataField="intid" HeaderText="SL" ReadOnly="True" SortExpression="intid" />
                   
            <asp:TemplateField HeaderText="Download">
            <ItemTemplate>
            <asp:Button ID="Complete" runat="server" Text="Download" CommandName="complete" OnClick="Complete_Click"   CommandArgument='<%# Eval("strFileName") %>' /></ItemTemplate>
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
            </tr></table>  
            
            <asp:FileUpload ID="fu_ImportCSV" runat="server" />
            <asp:Button ID="btn_ImportCSV" runat="server" Text="Show" OnClick="btn_ImportCSV_Click" /><asp:Button ID="Button2" runat="server" Text="Clear" OnClick="btn1_ImportCSV_Click" />
            <asp:Button ID="Button3" runat="server" Text="Send" OnClick="Button5_Click" />
   
            </div>
            <div> 
          
            <br />
            <asp:Label ID="lbl_ErrorMsg" runat="server" Visible="false"></asp:Label>
      
            <br />
            <table>
            <tr>
            <td>
            <%-- <asp:GridView ID="gv_GridView" runat="server" CellPadding="4" AutoGenerateColumns="false" ForeColor="#333333"
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#EFF3FB" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            </asp:GridView>--%>


            <asp:GridView ID="gv_GridView" runat="server" AutoGenerateColumns="False" Font-Size="12px" BackColor="White" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
            <asp:TemplateField HeaderText="Mobile No" SortExpression="Mobile_N0o"><ItemTemplate>
            <asp:HiddenField ID="Mobile_No0" runat="server" Value='<%# Eval("Mobile_No") %>' /><asp:HiddenField ID="testMobile_No" runat="server" Value='<%# Eval("Mobile_No") %>' />
            <asp:Label ID="lblMobile_No1" runat="server" Text='<%# Bind("Mobile_No") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

       
            <asp:TemplateField HeaderText="Message" SortExpression="Messagetxt"><ItemTemplate>
            <asp:HiddenField ID="Message0" runat="server" Value='<%# Eval("Message_type") %>' /><asp:HiddenField ID="testMessage" runat="server" Value='<%# Eval("Message_type") %>' />
            <asp:Label ID="lblMessage" runat="server" Text='<%# Bind("Message_type") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="80px"/></asp:TemplateField> 

       
                         
    
                          
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
                    
                   

                </td>
            <td>
                      
                                          
                       
            </td>
            </tr>
            </table>
                   
    </div>
    </form>
</body>
</html>
