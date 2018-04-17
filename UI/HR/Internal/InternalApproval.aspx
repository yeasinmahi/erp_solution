<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalApproval.aspx.cs" Inherits="UI.HR.Internal.InternalApproval" %>

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
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=700,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }

         function Registrationparts(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=150,left=350, close=no');
             if (window.focus) { newwindow.focus() }
         }
         function RegistrationSchedule(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=700,top=150,left=350, close=no');
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
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center" >Internal Approval</div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto;vertical-align: top; background-color: #808080;"class="tblrowodd" >
           <tr  class="tblrowodd">
                  
       <td style="text-align:right;" > <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="To Address:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtEmpAddress" runat="server" CssClass="txtBox" Width="457px" AutoPostBack="false" onchange="javascript: Changed();"  Font-Bold="False"  ></asp:TextBox>
            <asp:HiddenField ID="hdfEmpCode" runat="server" /><asp:HiddenField ID="hdfSearchBoxTextChange" runat="server" /></td>         
             
                    </tr>
               <tr  class="tblrowodd">
           <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Subject:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtSubject" runat="server" CssClass="txtBox" Width="457px" Font-Bold="False"></asp:TextBox>
          </tr>
           <tr>
             <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text="Attachment:"></asp:Label></td>
    
            <td><asp:FileUpload ID="DUpload" runat="server" Width="457px" /></td>
           </tr>
           <tr>
               <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="Description:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtDescription" runat="server" CssClass="txtBox" Font-Bold="False" Height="75px" Width="457px" TextMode="MultiLine"></asp:TextBox>
      
           </tr>
             <tr>
               <td style="text-align:right;"> <asp:Label ID="Label2" runat="server" font-size="small" CssClass="lbl" Text="Total Amount:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="txtBox" Font-Bold="False" Width="457px" ></asp:TextBox>
      
           </tr>
             
           
            
             <tr>
                      
          
                
              <td></td>
                 <td style="text-align:right;">  <asp:HiddenField ID="hdnField" runat="server" />
                       <a class="nextclick" onclick="Save()">Submit</a> </td>
            <%--<td style="text-align:right;"><asp:Button ID="Button1" runat="server" Text="Add"/><asp:Button ID="BtnRequest" runat="server" Text="Submit"/></td>
           --%>  </tr>
           </table> 
          </div>
     
                   <div class="leaveSummary_container"> 
                 <div class="tabs_container">
                     <caption>
                         Approval Summary :<hr /></caption>
                       </div>
                 <td>
                      <asp:GridView ID="dgvStatus" runat="server" AutoGenerateColumns="False">
                         <Columns>
                              <asp:TemplateField HeaderText="Sl.N">
                                  <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                                         </ItemTemplate>
                             </asp:TemplateField>
                              <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" />
                             <asp:BoundField DataField="strSubJect" HeaderText="Subject" SortExpression="strSubJect">
                                 <ItemStyle HorizontalAlign="Left" Width="200px"/> </asp:BoundField >
                            
                              <asp:TemplateField HeaderText="Detalis">
                                  <ItemTemplate>
                                      <asp:Button ID="BtnDetalisView" runat="server" Text="Detalis" CommandName="Detalis"  CommandArgument='<%# Eval("intID")%>' OnClick="BtnDetalisView_Click" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                            
                         </Columns>
                     </asp:GridView>
                 </td>
                 </div>
             </tr>
       
         </div>
        
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
