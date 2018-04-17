<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanReport_UI.aspx.cs" Inherits="UI.HR.KPI.WorkPlanReport_UI" %>

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
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

</script>
    <script>
        $(document).ready(function () {
            SearchText();
        });
        function Changed() {
            document.getElementById('hdfSearchBoxTextChange').value = 'true';
        }
        function SearchText() {
            $("#TxtEmpAddress").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "InternalApproval.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('TxtEmpAddress').value + "'}",
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
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=800,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
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
    <form id="frmaccountsrealize" runat="server">
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
     <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center" >Work Plan Report</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top;"class="tblrowodd" >
          
           
           <tr>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged" ></asp:DropDownList>                                                                                       
            </td>
               <td style="text-align:right;"> <asp:Label ID="Label1" runat="server" font-size="small" CssClass="lbl" Text="Finencial year:"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlFinanencialYear" CssClass="ddList" Font-Bold="False" runat="server" AutoPostBack="true" ></asp:DropDownList>                                                                                       
           
               <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" /></td>
           </tr>
           
           </table>
          <table style="width:700px; outline-color:blue;vertical-align: top;"class="tblrowodd">
           <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" >
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
          <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>              
            <asp:BoundField DataField="intAutoID" HeaderText="ID" Visible="false" SortExpression="intAutoID" />
            <asp:TemplateField HeaderText="Name"  SortExpression="Name"><ItemTemplate>            
            <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("Name") %>'  ></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="200px"></ItemStyle></asp:TemplateField>
         <asp:BoundField DataField="strWordetalis" HeaderText="Description"  SortExpression="strWordetalis" >
             <ItemStyle HorizontalAlign="Left" Width="230px"></ItemStyle > </asp:BoundField>

                                              
            

                <asp:TemplateField HeaderText="View">
                    <ItemTemplate>
                        <asp:Button ID="btnDetalis" runat="server" CommandArgument='<%# Eval("intAutoID")%>' Text="Detalis" OnClick="btnDetalis_Click"  />
                    </ItemTemplate>
                </asp:TemplateField>

                                              
            
                
            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView> 
        </tr>
                  
         </table> 
         
     
                   
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
