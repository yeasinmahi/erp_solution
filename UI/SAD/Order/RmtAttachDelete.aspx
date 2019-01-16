<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RmtAttachDelete.aspx.cs" Inherits="UI.SAD.Order.RmtAttachDelete" %>

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
                         url: "RmtAttachDelete.aspx/getemplontadasupervisor",
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
<script>
    //function ViewDocList() {
    //    window.open('RmtTADAAttachDocPathlist.aspx?ID=' + 'sub', "scrollbars=yes,toolbar=0,height=250,width=500,top=200,left=300, resizable=no, title=Preview");
    //}
    function Registration(url) {
        window.open('RmtTADAAttachDocPathlist.aspx?ID=' + url, '', "height=600, width=800, scrollbars=yes, left=50, top=100, resizable=yes, title=Preview");
    }


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
    <table border="0px"; style="width:300px"; align="center" >
           <tr class="tblroweven">
        <td style="text-align:right;"><asp:Label ID="lblFromDate" CssClass="lbl" runat="server" Text="From Date:  "></asp:Label></td>
        <td>
                                <asp:TextBox ID="txtDate" Enabled="false" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDate" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_1" ID="CalendarExtender2" runat="server">
                                </cc1:CalendarExtender>
                                <img runat="server" id="imgCal_1" src="../../Content/images/img/calbtn.gif" style="border: 0px;
                                    width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>

        <td style="text-align:right;"><asp:Label ID="Label1" CssClass="lbl" runat="server" Text="To Date:  "></asp:Label></td>
         <td>
                                <asp:TextBox ID="txtDelDate" Enabled="false" runat="server" AutoPostBack="True"></asp:TextBox>
                                <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDelDate" Format="dd/MM/yyyy"
                                    PopupButtonID="imgCal_2" ID="CalendarExtender1" runat="server">
                                </cc1:CalendarExtender>
                                <img id="imgCal_2" src="../../Content/images/img/calbtn.gif"
                                    style="border: 0px; width: 34px; height: 23px; vertical-align: bottom;" />
                            </td>
            
        </tr>
          <tr class="tblroweven">
                <td style="text-align:right;"><asp:Label ID="lbltype" CssClass="lbl" runat="server" Text="User Type:  "></asp:Label>
                <td><asp:RadioButtonList ID="rdbUserOption" runat="server" OnSelectedIndexChanged="rdbUserOption_SelectedIndexChanged"
                RepeatDirection="Horizontal" AutoPostBack="true">
                <asp:ListItem Text="Own" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Other" Value="1"></asp:ListItem>
                 
                </asp:RadioButtonList>
                </td>  
                    <td style="text-align:right;"><asp:Label ID="lblfullname" CssClass="lbl" runat="server"  Text="Employee Name: "></asp:Label></td>
          <td>  <asp:TextBox ID="txtEmployeeSearch" runat="server" CssClass="txtBox" Width="350px" AutoPostBack="true" onchange="javascript: Changed();"></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdnAction" runat="server" />
        </td>
                </tr>
     
  

        <tr class="tblrowodd">
            <asp:HiddenField ID="hdnsearch" runat="server"/>
                <asp:HiddenField ID="hdnField" runat="server"/>
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
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText = "No files uploaded" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            
            
                       <asp:BoundField DataField="dtebilldate" HeaderText="billdate" SortExpression="dtebilldate" DataFormatString="{0:dd-M-yyyy}" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>
                       
                       <asp:BoundField DataField="dteinsertdate" HeaderText="insertdate" DataFormatString="{0:dd-M-yyyy}" SortExpression="dteinsertdate" ItemStyle-HorizontalAlign="Center" >

                      <ItemStyle HorizontalAlign="Center" /> </asp:BoundField>

                     <asp:BoundField DataField="strcontent" HeaderText="FILE  Name" SortExpression="strName" ItemStyle-HorizontalAlign="Center" >
                       <ItemStyle HorizontalAlign="Center" />
                      </asp:BoundField>


                     
            
            
 
<asp:TemplateField>
  

 <ItemTemplate><asp:LinkButton ID="btnDelete" Text = "Delete" CommandArgument = '<%# Eval("id") %>' OnClick="btnDelete_Click" runat="server"></asp:LinkButton></ItemTemplate>
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
