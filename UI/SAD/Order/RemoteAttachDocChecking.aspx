<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteAttachDocChecking.aspx.cs" Inherits="UI.SAD.Order.RemoteAttachDocChecking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title>
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
    </script>
   
<script>
    //function ViewDocList() {
    //    window.open('RemoteTADADocChkPathlist.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
    //    return false;
    //}
    function Registration(url) {

        window.open('RemoteTADADocChkPathlist.aspx?ID=' + url, '', "height=500, width=1350, scrollbars=yes, left=10, top=200, resizable=yes, title=Preview");

    }

</script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFullName.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getApplicantListForBikeAndCarUserBillApprove") %>',
                        data: '{"ApproverEnrol":"' + $("#hdnAreamanagerEnrol").val() + '","prefix":"' + request.term + '"}',
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) { response($.map(data.d, function (item) { return { label: item.split('^')[0], val: item.split(',')[1] } })) },
                        error: function (response) { },
                        failure: function (response) { }
                    });
                },
                select: function (e, i) {
                    $("#<%=hdnsearch.ClientID %>").val(i.item.val);
                }, minLength: 1
            });
        });

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
    <table border="1px"; style="width:Auto"; align="center" >
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" Width="170"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" Width="170"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
        <tr  class="tblrowOdd">
        <td  style="text-align:right"><asp:Label ID="lblAttachType" runat="server" CssClass="lbl" Text="Attachment Type"></asp:Label></td>
        <td>
        <asp:DropDownList ID="drdlAttachType" CssClass="ddl" runat="server" DataSourceID="odsRmtAttahmentType"  DataTextField="strBillAttachmentType" DataValueField="ID"></asp:DropDownList> 
        <asp:ObjectDataSource ID="odsRmtAttahmentType" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteAttachmentType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblTADAAttachmentTypeTableAdapter">
        <InsertParameters>
            <asp:Parameter Name="strBillAttachmentType" Type="String" />
        </InsertParameters>
        </asp:ObjectDataSource>
        </td>
             <td><asp:Label ID="lbl" runat="server" CssClass="lbl" Text="Unit"></asp:Label></td>
            <td><asp:DropDownList ID="drdlunit" runat="server" DataSourceID="odsunit" DataTextField="strUnit" DataValueField="intUnitID"></asp:DropDownList> 
                <asp:ObjectDataSource ID="odsunit" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr class="tblroweven">
        <td> <asp:Label ID="lblName" runat="server" Text="Employee Name"></asp:Label></td>
        <td colspan="3" style="text-align:right;"><asp:TextBox ID="txtFullName"  Width="400px" runat="server"></asp:TextBox> </td> </tr>


        <caption>
            <tr>
                <td colspan="4" style="text-align:right;">
                    <asp:HiddenField ID="HiddenUnit" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="hdnJobstation" runat="server" />
                    <asp:HiddenField ID="hdnField" runat="server" />
                    <asp:HiddenField ID="hdnAreamanagerEnrol" runat="server" />
                    <asp:HiddenField ID="hdnsearch" runat="server" />
                    <asp:Button ID="btnShowAttachment" runat="server" BackColor="#ffcc66" OnClick="btnShowAttachment_Click" Text="Show(Attchment)" />
                </td>
            </tr>
        </caption>


        <tr  class="tblroweven"> <td style="text-align:right;" colspan="4"><asp:Label ID="lbldoc" CssClass="lbl" runat="server" ></asp:Label></td> </tr>
        <tr class="tblrowOdd"><td colspan="4">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
        <Columns>
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