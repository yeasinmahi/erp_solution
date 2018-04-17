<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteEmployeeEnrolvsCOAID.aspx.cs" Inherits="UI.SAD.Order.RemoteEmployeeEnrolvsCOAID" %>


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
            $("#txtFullName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "RemoteEmployeeEnrolvsCOAID.aspx/GetAutoCompleteDataForTADA",
                        data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
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

    <script type="text/javascript">
        $(document).ready(function () {
            SearchTextforCOA();
        });
        function Changedcoa() {
            document.getElementById('hdfSearchBoxTextChangeCOAName').value = 'true';
        }
        function SearchTextforCOA() {
            $("#txtCOAName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "RemoteEmployeeEnrolvsCOAID.aspx/GetAutoCompleteDataForEmplEnrolvsCOAID",
                        data: "{'strSearchKey':'" + document.getElementById('txtCOAName').value + "'}",
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
    <form id="frmpdv" runat="server">
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
         <div class="tabs_container"> Employee Enrol vs COA ID Tag  :<asp:HiddenField ID="hdnenroll" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="ApproverEnrol" runat="server"/><asp:HiddenField ID="hdnAreamanagerEnrol" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="hdfSearchBoxTextChangeCOAName" runat="server"/><asp:HiddenField ID="hdnInsertbyenrol" runat="server"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
        <asp:HiddenField ID="hdnJobstationid" runat="server"/><asp:HiddenField ID="hdnconfirm" runat="server" />  <input type="hidden" id="DATE" name="DATE" value="WOULD_LIKE_TO_ADD_DATE_HERE">
        <hr /></div>
        <table border="0"; style="width:Auto"; >  
            <tr class="tblroweven">
            <td style="text-align:right;"><asp:Label ID="lblCOAName" CssClass="lbl" runat="server" Text="COA Name: "></asp:Label> </td>
            <td colspan="4"><asp:TextBox ID="txtCOAName" runat="server" Font-Bold="true" CssClass="txtBox" Width="350" AutoPostBack="true" BackColor="#ffffcc" onchange="javascript: Changedcoa();"></asp:TextBox> </td>
            </tr>  
        <tr class="tblrowodd">
            <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server" onchange="javascript: Changed();" Text="Employee Name: "></asp:Label></td>
            <td><asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True"></asp:TextBox>
            <span style="color:red">*</span>

            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
            <td style="text-align:right;"><asp:Label ID="lblDesignation" CssClass="lbl" runat="server" Text="Designation: "></asp:Label> </td>
            <td><asp:TextBox ID="txtDesignation" Font-Bold="true" runat="server" AutoPostBack="false" CssClass="txtBox" BackColor="#ffffcc" Enabled="false"></asp:TextBox>      

        </tr>
        

        <tr class="tblroweven">
             <td style="text-align:right;"><asp:Label ID="lblEnrol" CssClass="lbl" runat="server" Text="Code: "></asp:Label> </td>
            <td><asp:TextBox ID="textEnrol" runat="server" Font-Bold="true" AutoPostBack="false" BackColor="#ffffcc"  CssClass="txtBox" Enabled="false"></asp:TextBox> </td>
            
            <td style="text-align:right;"><asp:Label ID="lblDept" CssClass="lbl" runat="server" Text="Department: "></asp:Label> </td>
            <td><asp:TextBox ID="txtDepartment" runat="server" AutoPostBack="false" Font-Bold="true" BackColor="#ffffcc" CssClass="txtBox" Enabled="false"></asp:TextBox></td> 

        </tr>
           
      <tr class="tblroweven">
          <td colspan="4">
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnsubmit_Click" />
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