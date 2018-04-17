<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyUploadForAFBL.aspx.cs" Inherits="UI.Document_Inventory.PolicyUploadForAFBL" %>

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
            
             <td style="text-align:right">
                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Unit Name"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="DdlUnit" runat="server" CssClass="ddlist" AutoPostBack="True" OnSelectedIndexChanged="DdlUnit_SelectedIndexChanged">
                    </asp:DropDownList></td>
             
            
                  <td style="text-align:right">
                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Type"></asp:Label>
                </td>
                <td>
                     <asp:DropDownList ID="DdlType" runat="server" CssClass="ddlist" AutoPostBack="True">
                    </asp:DropDownList></td>
             
              <td>
                   
               
            
         </tr>
         <tr>

            <td colspan="1" style="text-align:right;">
                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Version:  "></asp:Label>
            </td>
            <td colspan="1">
                <asp:TextBox ID="TxtVersion" runat="server" AutoPostBack="False" CssClass="txtBox" Enabled="true"></asp:TextBox></td>
            <td colspan="1" style="text-align:right;">
                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Browser:  "></asp:Label>
            </td>
                
                 <td>
                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="txtBox" />
                <asp:HiddenField ID="HiddenField6" runat="server" />
                <asp:HiddenField ID="HiddenField7" runat="server" />
                <asp:HiddenField ID="HiddenField8" runat="server" />
            </td>

                </tr>
           
         <tr>
             <td></td><td></td><td></td>
             <td>
              <asp:HiddenField ID="HiddenField9" runat="server" />
                <a class="nextclick" onclick="SavePolicy()">Attachment Upload</a></td>
         </tr>
       
        </table>
        
        <tr>
            <td>
                
              </td>
        </tr>
       </left>
    </table>
        <table border="1px"; style="width:Auto"; align="center" >
            <tr>
                <td colspan="4">
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
