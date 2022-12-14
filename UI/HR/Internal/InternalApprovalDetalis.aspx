<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InternalApprovalDetalis.aspx.cs" Inherits="UI.HR.Internal.InternalApprovalDetalis" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
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
            document.getElementById("hdnApprove").value = "1";
            __doPostBack();
        }

</script>
        <script>
            function SaveF() {
                document.getElementById("HiddenForward").value = "2";
                __doPostBack();
            }

</script>
        <script>
            function SaveR() {
                document.getElementById("HiddenReject").value = "3";
                __doPostBack();
            }

</script>
        <script>
            function SaveC() {
                document.getElementById("HiddenClose").value = "4";
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
                        url: "InternalApprovalDetalis.aspx/GetAutoCompleteData",
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
    


       
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {}
        </style>
    </head>

     <body>
    <form id="form1" runat="server">

<%--<body>
    <form id="frmaccountsrealize" runat="server">
   <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>--%>
   <%-- <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>






<%--=========================================Start My Code From Here===============================================--%>
      <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnsearch" runat="server" />
    <asp:HiddenField ID="hdnEnrollUnit" runat="server" /><asp:HiddenField ID="hdnUnitIDByddl" runat="server" /><asp:HiddenField ID="hdnBankID" runat="server" />
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnstation" runat="server" />         
    <div class="tabs_container" align="Center" >Internal Approval</div>
   
      <table style="width:600px; outline-color:white;">
         <tr>
             <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="Small" Text="Subject:"></asp:Label> <asp:Label ID="lblSubject" ForeColor="Green"  runat="server"  Font-Bold="true"  Font-Size="Small" ></asp:Label></td>
                     
         </tr>
           <tr>
             <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Small" Text="Total Bill Amount:"></asp:Label> <asp:Label ID="lblBill"  Font-Bold="true" ForeColor="Green" runat="server" Font-Size="Small" ></asp:Label></td>
                     
         </tr>
             <tr>
                  
             <td> Approval Owner:</td>
           </tr>
           
            <tr>
                <td>
                    <asp:GridView ID="dgvViewRequest" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="EmpName" HeaderText="Approve By" SortExpression="EmpName" />
                            <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                            <asp:BoundField DataField="strFtpFilePath" HeaderText="FtpFilePath" SortExpression="strFtpFilePath" Visible="False" />
                            <asp:BoundField DataField="dteDate" HeaderText="Date" SortExpression="dteDate" />
                            <asp:BoundField DataField="ApproveStatus" HeaderText="Status" SortExpression="ApproveStatus" />
                            <asp:TemplateField HeaderText="Download">
                                <ItemTemplate>
                                    <asp:Button ID="BtnDetalisdownload" runat="server" Text='<%# Bind("download") %>'  CommandArgument='<%# Eval("strFtpFilePath") %>'  OnClick="BtnDetalisdownload_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
          <td> Main request Owner:</td>
          <table>
              <tr>
                  <td>
                         
    
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:GridView ID="dgvMainRequest" Text="Main Request Owner" runat="server" AutoGenerateColumns="False">
                          <Columns>
                              <asp:BoundField DataField="EmpName" HeaderText="Request by" SortExpression="EmpName" />
                              <asp:BoundField DataField="strDescription" HeaderText="Description" SortExpression="strDescription" />
                              <asp:BoundField DataField="strSubJect" HeaderText="Subject" SortExpression="strSubJect" />
                              <asp:BoundField DataField="dteDate" HeaderText="Date" SortExpression="dteDate" />
                              <asp:BoundField DataField="strFtpFilePath" HeaderText="strFtpFilePath" SortExpression="strFtpFilePath" Visible="False" />
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Button ID="BtnDownload" runat="server"  CommandArgument='<%# Eval("strFtpFilePath") %>' Text='<%# Bind("download") %>' OnClick="BtnDownload_Click" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                      </asp:GridView>
                  </td>
              </tr>
          </table>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
