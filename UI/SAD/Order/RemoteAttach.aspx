<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteAttach.aspx.cs" Inherits="UI.SAD.Order.RemoteAttach" %>
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


   

    function Registration(url) {
        window.open('TAandDADocPathList.aspx?ID=' + url, '', "height=600, width=800, scrollbars=yes, left=50, top=100, resizable=yes, title=Preview");
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
    <table border="1px"; style="width:Auto"; align="center" >
        <tr class="tblroweven">
        <td style="text-align:right; column-span=3"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td><asp:TextBox ID="txtFromDate" runat="server" CssClass="txtBox" Enabled="true" Width="100"></asp:TextBox>
        <script type="text/javascript"> new datepickr('txtFromDate', { 'dateFormat': 'Y-m-d' });</script></td>
           <%--  <td style="text-align:right; column-span=3"> <asp:TextBox ID="txtEffectiveDate" runat="server" CssClass="txtBox"  Enabled="true"></asp:TextBox>
         <cc1:CalendarExtender ID="CFD" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEffectiveDate"></cc1:CalendarExtender>  </td>--%>

      
        </tr>  
        <tr class="tblrowodd">
            <td style="text-align:right">
                <asp:Label ID="lblAttachType" runat="server" CssClass="lbl" Text="Attachment Type"></asp:Label>

            </td>
            <td colspan="4">
                <asp:DropDownList ID="drdlAttachType" runat="server" CssClass="ddList" DataSourceID="odsRmtAttahmentType" DataTextField="strBillAttachmentType" DataValueField="ID"></asp:DropDownList> 
                <asp:ObjectDataSource ID="odsRmtAttahmentType" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="taRemoteAttachmentType" TypeName="SAD_DAL.Customer.Report.StatementTDSTableAdapters.tblTADAAttachmentTypeTableAdapter">
                    <InsertParameters>
                        <asp:Parameter Name="strBillAttachmentType" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>

        </tr>

        <tr>
                   
            <td><asp:FileUpload ID="DUpload" runat="server" CssClass="txtBox"/><asp:HiddenField ID="HiddenUnit" runat="server"/>
              <asp:HiddenField ID="HiddenField1" runat="server" /> <asp:HiddenField ID="hdnJobstation" runat="server" />    </td>
            <td><asp:HiddenField ID="hdnField" runat="server" /><a class="nextclick"  onclick="Save()">Attachment Upload</a></td>
                
            <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Show-report(Attchment)"  BackColor="#ffcc66" OnClick="Button1_Click"/></td>
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

