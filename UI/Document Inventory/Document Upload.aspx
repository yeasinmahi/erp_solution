<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Document Upload.aspx.cs" Inherits="UI.Document_Inventory.Document_Upload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server"><title></title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>  
<webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
<webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
      <script src="../../../../Content/JS/datepickr.min.js"></script>
    
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }
        function SavePolicy() {
            document.getElementById("HiddenField9").value = "1";
            __doPostBack();
        }
       function Registration(url) {
           newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0, height=550, width=850, top=10,left=10, close=yes');
           if (window.focus) { newwindow.focus() }
       }
       function ViewOthers(url) {
           window.open(url, '', "scrollbars=yes,toolbar=0,height=550,width=850,top=200,left=300, resizable=yes, title=Preview");
       }
       function ViewDocList() {
           window.open('TAandDADocPathList.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
       }
</script>
    
</head>
<body>
    <form id="frmattachment" runat="server">
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
    <div style="height: 100px;"></div>
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>


<%--=========================================Start My Code From Here===============================================--%>
    <div class="divs_content_container">
          <div class="tabs_container" align="Center">Document Upload</div>
    <table border="1px"; style="width:Auto"; align="center" >
        <tr>
            <left>
                <td style="text-align:right">
                    <asp:Label ID="LblUnit" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                    <td colspan="1" style="text-align:right;">
                        <asp:Label ID="lblEnroll" runat="server" CssClass="lbl" Text="Enroll:  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnroll" runat="server" AutoPostBack="true" CssClass="txtBox" Enabled="true" OnTextChanged="txtEnroll_TextChanged"></asp:TextBox>
                    </td>
                </td>
            </left>
        </tr>
        <tr>

            <td colspan="1" style="text-align:right;">
                <asp:Label ID="LblEmployee" runat="server" CssClass="lbl" Text="Employee Name:  "></asp:Label>
            </td>
            <td colspan="1">
                <asp:TextBox ID="TxtEmployee" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <td  style="text-align:left;">
                    <asp:Label ID="LblDesination" runat="server" CssClass="lbl" Text="Designation:  "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDesignation" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true"></asp:TextBox>
                </td>
            </td>
        </tr>
        <tr>
            <td colspan="1" style="text-align:right;">
                <asp:Label ID="LblDepartment" runat="server" CssClass="lbl" Text=" Department:  "></asp:Label>
            </td>
            <td colspan="1">
                <asp:TextBox ID="TxtDepartment" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                <td style="text-align:right">
                    <asp:Label ID="lblAttachType" runat="server" CssClass="lbl" Text="Attachment Type"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drdlAttachType" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <%--<td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" Width="100"></asp:TextBox>--%></td>
        </tr>
        





        <tr>
            <td>
                <asp:FileUpload ID="DUpload" runat="server" CssClass="txtBox" />
                <asp:HiddenField ID="HiddenUnit" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdnJobstation" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="hdnField" runat="server" />
                <a class="nextclick" onclick="Save()">Attachment Upload</a></td>
            <%--<td colspan="2"><asp:Button ID="Button1" runat="server" Text="Show-report(Attchment)" AutoPostBack="False" BackColor="#ffcc66" OnClick="Button1_Click1"  /></td>--%>
        </tr>
        <tr>
            <td colspan="4" style="text-align:right;">
                <asp:Label ID="lbldoc" runat="server" CssClass="lbl"></asp:Label>
            </td>
        </tr>
        </table>
        
        <tr>
            <td>
                
              </td>
        </tr>
       </left>
    </table>
        <div class="tabs_container" align="Center">Document Policy</div>
     <table border="1px"; style="width:Auto"; align="center" >
        <tr>
            <left>
                <td style="text-align:right">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Ploicy Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPolicy" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                    <td colspan="1" style="text-align:right;">
                        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Department:  "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtPolicyDept" runat="server" CssClass="txtBox" Enabled="true"></asp:TextBox>
                    </td>
                </td>
            </left>
        </tr>
        <tr>

            <td colspan="1" style="text-align:right;">
                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Version:  "></asp:Label>
            </td>
            <td colspan="1">
                <asp:TextBox ID="TxtVersion" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true"></asp:TextBox>
                
                 <td>
                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="txtBox" />
                <asp:HiddenField ID="HiddenField6" runat="server" />
                <asp:HiddenField ID="HiddenField7" runat="server" />
                <asp:HiddenField ID="HiddenField8" runat="server" />
            </td>
            <td>
                <asp:HiddenField ID="HiddenField9" runat="server" />
                <a class="nextclick" onclick="SavePolicy()">Attachment Upload</a></td>
         



            </td>
      
       
        </table>
        
        <tr>
            <td>
                
              </td>
        </tr>
       </left>
    </table>
        <table>
            <tr>
                <td class="4">
                    <asp:GridView ID="GridViewPolicy" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="SL.N">
                           <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                      </asp:TemplateField>
                            <asp:BoundField DataField="Rowid" HeaderText="Rowid" SortExpression="Rowid" Visible="False" />
                            <asp:BoundField DataField="strPolicyName" HeaderText="Policy Name" SortExpression="strPolicyName" />
                            <asp:BoundField DataField="strDepartment" HeaderText="Department" SortExpression="strDepartment" />
                            <asp:BoundField DataField="strVersion" HeaderText="Version" SortExpression="strVersion" />
                            <asp:BoundField />
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Button ID="BtnPolicyView" runat="server" CommandName="Detalis"  CommandArgument='<%# Eval("Rowid") +"^"+ Eval("strFtpFilePath") %>' Text="View" OnClick="BtnPolicyView_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
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
