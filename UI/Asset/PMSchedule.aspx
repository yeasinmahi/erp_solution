<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PMSchedule.aspx.cs" Inherits="UI.Asset.PMSchedule" %>


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
            $("#txtEmployeeSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json;",
                        url: "VehicleMaintenanceBill.aspx/GetAutoCompleteData",
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
         function Registration(url) {
             newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=500,width=1000,top=10,left=10, close=no');
             if (window.focus) { newwindow.focus() }
         }
         </script> 
   
    <script> function CloseWindow() {
     window.close();
 } </script> 

    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }
        .ddList {}
        .txtBox {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 268435488px;
        }
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
    <div class="tabs_container" align="Center" >Preventive Maintenance Schedule </div>
   
       <table style="width:700px; outline-color:blue;table-layout:auto; vertical-align: top;"class="tblrowodd" >
              <tr class="tblrowodd">
                  
       <td style="text-align:right;"> <asp:Label ID="LblScheduleName" runat="server" CssClass="lbl" font-size="small" Text="Schedule Name:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtScheduleName" runat="server" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" Width="291px" ></asp:TextBox>
                
                   <asp:Button ID="BtnIssue" runat="server" Text="Add" Height="23px" Width="52px" OnClick="BtnIssue_Click"  />         
          
                    </tr>
              <%-- <tr>
                     <td style="text-align:right;"> <asp:Label ID="LblName" font-size="small" runat="server" CssClass="lbl" Text="Name of Asset:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
         <td style="text-align:right;"> <asp:Label ID="LblStation" runat="server" font-size="small" CssClass="lbl" Text="JobStation:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TxtStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
       
               </tr>
           <tr>
                 <td style="text-align:right;"> <asp:Label ID="Label1" font-size="small" runat="server" CssClass="lbl" Text="Schedule"></asp:Label></td>
  
                <td style="text-align:left;"><asp:DropDownList ID="DdlStatus" runat="server" CssClass="ddList" Font-Bold="False">
                              <asp:ListItem>Open</asp:ListItem>
                              <asp:ListItem>Pending</asp:ListItem>
                              <asp:ListItem>Wating for parts</asp:ListItem>
                              <asp:ListItem>Close</asp:ListItem>
                          </asp:DropDownList>      
                    
                     <td style="text-align:right;"> <asp:Label ID="Label3" font-size="small" runat="server" CssClass="lbl" Text="Schedule Type"></asp:Label></td>
  
                <td style="text-align:left;"><asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddList" Font-Bold="False">
                              <asp:ListItem>Open</asp:ListItem>
                              <asp:ListItem>Pending</asp:ListItem>
                              <asp:ListItem>Wating for parts</asp:ListItem>
                              <asp:ListItem>Close</asp:ListItem>
                          </asp:DropDownList>              
           </tr>
           <tr>
               <td style="text-align:right;"> <asp:Label ID="Label8" runat="server" font-size="small" CssClass="lbl" Text="Service Name:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TextBox1" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
        <td style="text-align:right;"> <asp:Label ID="Label9" runat="server" font-size="small" CssClass="lbl" Text="Service Type:"></asp:Label></td>
   
            <td style="text-align:left;"><asp:DropDownList ID="DropDownList2" runat="server" CssClass="ddList" Font-Bold="False">
                              <asp:ListItem>Open</asp:ListItem>
                              <asp:ListItem>Pending</asp:ListItem>
                              <asp:ListItem>Wating for parts</asp:ListItem>
                              <asp:ListItem>Close</asp:ListItem>
                          </asp:DropDownList>  
           </tr>
           <tr>
                  <td style="text-align:right;"> <asp:Label ID="Label10" runat="server" font-size="small" CssClass="lbl" Text="Service Priority:"></asp:Label></td>
   
     
                <td style="text-align:left;"><asp:DropDownList ID="DropDownList3" runat="server" CssClass="ddList" Font-Bold="False">
                              <asp:ListItem>Open</asp:ListItem>
                              <asp:ListItem>Pending</asp:ListItem>
                              <asp:ListItem>Wating for parts</asp:ListItem>
                              <asp:ListItem>Close</asp:ListItem>
                          </asp:DropDownList>  

                         <td style="text-align:right;"> <asp:Label ID="Label11" runat="server" font-size="small" CssClass="lbl" Text="Service Hour:"></asp:Label></td>
          <td style="text-align:left;"> <asp:TextBox ID="TextBox2" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
    
           </tr>
           <tr>
                      <td style="text-align:right;"><asp:Label ID="LbldteIssue" runat="server" CssClass="lbl" Text="From Date:"></asp:Label></td>
        <td><asp:TextBox ID="TxtdteIssue" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CEA" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteIssue"></cc1:CalendarExtender> 
        <td style="text-align:right;"><asp:Label ID="LbldteStarted" runat="server" CssClass="lbl" Text="To Date:"></asp:Label></td>
       <td><asp:TextBox ID="TxtdteStarted" runat="server" CssClass="txtBox"></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="TxtdteStarted"></cc1:CalendarExtender> 

           </tr>--%>
             </table>
        <%-- <table width="700" class="tblroweven">--%>
            
        <%--     <tr>
                  <td></td> <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                     <td  class="auto-style1" style="text-align:right;">
                         <asp:Label ID="LblProblem" runat="server" font-size="small" CssClass="lbl" Text="Problem :"></asp:Label>
                     </td>
                     <td class="auto-style1" style="text-align:left;">
                         <asp:TextBox ID="TxtProblem" runat="server" CssClass="txtBox" Font-Bold="False" Height="34px" Width="406px"></asp:TextBox>
                     </td>
               <td>
                   <asp:Button ID="BtnIssue" runat="server" Text="Issue" Height="32px" Width="52px"  /></td>
             </tr>
<%--           </table> --%>
         <table>
             <tr>
                 <td>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField DataField="intID" HeaderText="ID" SortExpression="intID" />
                             <asp:BoundField DataField="strScheduleName" HeaderText="Schedule Name" SortExpression="strScheduleName" />
                             <asp:BoundField DataField="dteInsertDate" HeaderText="Date" SortExpression="dteInsertDate" />
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