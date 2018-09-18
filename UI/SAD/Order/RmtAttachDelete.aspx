<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RmtAttachDelete.aspx.cs" Inherits="UI.SAD.Order.RmtAttachDelete" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">   
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>

      <script>
          function Save() {
              document.getElementById("hdnField").value = "1";
              __doPostBack();

          }
    </script>
   
<script>
    //function ViewDocList() {
    //    window.open('RmtTADAAttachDocPathlist.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
    //}
    function Registration(url) {
        window.open('RmtTADAAttachDocPathlist.aspx?ID=' + url, '', "height=600, width=800, scrollbars=yes, left=50, top=100, resizable=yes, title=Preview");
    }


</script>

     <script type="text/javascript">

         $(document).ready(function () {
             $("#<%=txtFullName.ClientID %>").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getNoOfficeEmailEmployeeList") %>',
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
    <div class="divs_content_container">
    <table border="0px"; style="width:Auto"; align="center" >
        <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" Width="100"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtToDate" runat="server" CssClass="txtBox" Enabled="true" Width="100"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtToDate', { 'dateFormat': 'Y-m-d' });</script></td>          
        </tr>
        <tr class="tblrowodd">
            <td style="text-align:right"> <asp:Label ID="lblUserName" runat="server" CssClass="lbl" Text="Name"></asp:Label>  </td>
            <td colspan="3"> 
                <asp:HiddenField ID="hdnsearch" runat="server"/>
                <asp:HiddenField ID="hdnField" runat="server"/>
                <asp:TextBox ID="txtFullName" Width="300px" CssClass="txtBox" runat="server"></asp:TextBox></td>
  
        </tr>

        <tr>
             <td  style="text-align:right">
                <asp:Label ID="lblAttachType" runat="server" CssClass="lbl" Text="Attachment Type"></asp:Label>

            </td>
            <td>
                <asp:DropDownList ID="drdlAttachType" CssClass="ddList" runat="server">
                    <asp:ListItem  Text="TADA Attachment" Value="1"></asp:ListItem>
                    <asp:ListItem  Text="Challan Attachment" Value="2"></asp:ListItem>
                </asp:DropDownList> 
                
            </td>
             <td  style="text-align:right">
                <asp:Label ID="lbl" runat="server" CssClass="lbl" Text="Unit"></asp:Label>

            </td>
            <td>
                <asp:DropDownList ID="drdlUnit" runat="server" DataSourceID="odsUnit" DataTextField="strUnit" CssClass="ddList" DataValueField="intUnitID"></asp:DropDownList> 
                
                <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="getUnitName" TypeName="SAD_BLL.Customer.Report.StatementC"></asp:ObjectDataSource>
                
            </td>

        </tr>
        
        <tr>
                   
               
            <td colspan="2"><asp:Button ID="btnShowAttachment" runat="server" Text="Show-report(Attchment)"  BackColor="#ffcc66" OnClick="btnShowAttachment_Click"/></td>
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
  

 <ItemTemplate><asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("strPathurl") %>' OnClick="DownloadFile" runat="server"></asp:LinkButton></ItemTemplate>
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
