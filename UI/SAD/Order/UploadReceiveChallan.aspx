<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadReceiveChallan.aspx.cs" Inherits="UI.SAD.Order.UploadReceiveChallan" %>

<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
       
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }
        function Registration(url) {
        window.open('UploadedReceiveChallanDetaills.aspx?ID=' + url, '', "height=600, width=800, scrollbars=yes, left=50, top=100, resizable=yes, title=Preview");
    }



</script>
     <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>

</head>
<body>
    <form id="frmattachment" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference name="MicrosoftAjax.js"/>
	<asp:ScriptReference name="MicrosoftAjaxWebForms.js"/>
	<asp:ScriptReference name="MicrosoftAjaxTimer.js" assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>
	<asp:ScriptReference name="Common.Common.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.DateTime.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Compat.Timer.Timer.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.Animations.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="ExtenderBase.BaseScripts.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Animation.AnimationBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="PopupExtender.PopupBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Common.Threading.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="Calendar.CalendarBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AutoComplete.AutoCompleteBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
	<asp:ScriptReference name="AlwaysVisibleControl.AlwaysVisibleControlBehavior.js" assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"/>
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          
                <asp:Panel ID="pnlMarque" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;
                        z-index: 1; position: absolute;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                            scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
                    </div>
                </asp:Panel>


<%--=========================================Start My Code From Here===============================================--%>
    <div class="divs_content_container">
    <table border="1px"; style="width:Auto"; align="center" >
         
        <tr class="tblroweven">
       <td>

       </td>
          <td>

          </td>
      
        </tr>  

                <tr class="tblroweven">
       <td>

       </td>
          <td>

          </td>
      
        </tr> 
        <tr class="tblroweven">
        <td style="text-align:right; column-span=3"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="Received Challan No:  "></asp:Label></td>
        <td colspan="2"><asp:TextBox ID="txtReceiveChallan" runat="server" CssClass="txtBox" Enabled="true"  Width="300px"></asp:TextBox>
          <td><asp:Button ID="btnshowchallan" runat="server" Text="Show" OnClick="btnshowchallan_Click" /></td>
        </td>
          
      
        </tr>  
        <tr class="tblrowodd">
            <td style="text-align:right">
                <asp:Label ID="Customer" runat="server" CssClass="lbl" Text="Customer:"></asp:Label>
                </td>
            <td>
                <asp:Label ID="lblCustname" runat="server" CssClass="lbl"></asp:Label>
            </td>
          <td style="text-align:left">
                <asp:Label ID="lblchqnt" runat="server" CssClass="lbl" Text="Challan Qnt:"></asp:Label>
               </td>
             <td>
                <asp:Label ID="lblChqntval" runat="server" CssClass="lbl"></asp:Label>
            </td>

        </tr>

        <tr>
             <td style="text-align:right">
                <asp:Label ID="lblchdate" runat="server" CssClass="lbl" Text="Challan Date:"></asp:Label>
                 </td>
            <td>
                <asp:Label ID="lblchdateval" runat="server" CssClass="lbl"></asp:Label>
            </td>
            <td style="text-align:right">
                <asp:Label ID="lbldonumber" runat="server" CssClass="lbl" Text="D.O Number:"></asp:Label>
                </td>
            <td>
                <asp:Label ID="lbldoval" runat="server" CssClass="lbl"></asp:Label>
            </td>
        </tr>
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" Width="170" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
                          
        

        <td style="text-align:right;"><asp:Label ID="Label2" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" Width="170" autocomplete="off"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>      
          
        </tr>
        <tr>
                   
            <td><asp:FileUpload ID="DUpload" runat="server" CssClass="txtBox"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
              <asp:HiddenField ID="HiddenField1" runat="server" /> <asp:HiddenField ID="hdnJobstation" runat="server" />    </td>
            <td><asp:HiddenField ID="hdnField" runat="server" /><a class="nextclick"  onclick="Save()">Recv. Challan Upload</a></td>
                
            <td colspan="2"><asp:Button ID="btnshow" runat="server" Text="Show(Attchment)"  BackColor="#ffcc66" OnClick="btnshow_Click"/></td>
        </tr>
        <tr>
             <td style="text-align:right;" colspan="4"><asp:Label ID="lbldoc" CssClass="lbl" runat="server" ></asp:Label></td>
       

        </tr>
        <tr><td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
             <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            
             <asp:BoundField DataField="strContentName" HeaderText="FILE  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       <asp:BoundField DataField="strType" HeaderText="Type" SortExpression="strDesg" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="decSize" HeaderText="File Size" SortExpression="strFromAdr" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>

                      <asp:BoundField DataField="strPathurl" HeaderText="File PATH" SortExpression="strFromAdr" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>


                     
            
            
 
<asp:TemplateField>
  

 <ItemTemplate><asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("strPathurl") %>' OnClick="lnkDownload_Click" runat="server"></asp:LinkButton></ItemTemplate>
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

