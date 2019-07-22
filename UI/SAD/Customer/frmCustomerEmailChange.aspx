<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCustomerEmailChange.aspx.cs" Inherits="UI.SAD.Customer.frmCustomerEmailChange" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <script>
        function ShowPopUp(url) {
            url = url + '&shippoint=' + document.getElementById("ddlshippoint").value + '&Office=' + document.getElementById("ddlOfficeName").value + '&enroll=' + document.getElementById("hdnEnroll").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=400,width=1200,top=70,left=50');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script>
        function ShowPopUpCust(url) {            
            url = url + '&shipid=' + document.getElementById("ddlshippoint").value + '&offid=' + document.getElementById("ddlOfficeName").value + '&Custid=' + document.getElementById("hdnCustid").value + '&slipno=' + document.getElementById("hdnSlipno").value + '&CustName=' + document.getElementById("hdnCustname").value + '&userEnroll=' + document.getElementById("hdnEnroll").value;
            newwindow = window.open(url, 'sub', 'scrollbars=yes,toolbar=0,height=600,width=700,top=70,left=50');
            if (window.focus) { newwindow.focus() }
        }
    </script>
    <script type="text/javascript">
      function Search_dgvservice(strKey, strGV) {

          var strData = strKey.value.toLowerCase().split(" ");
          var tblData = document.getElementById(strGV);
          var rowData;
          for (var i = 1; i < tblData.rows.length; i++) {
              rowData = tblData.rows[i].innerHTML;
              var styleDisplay = 'none';
              for (var j = 0; j < strData.length; j++) {
                  if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                      styleDisplay = '';
                  else {
                      styleDisplay = 'none';
                      break;
                  }
              }
              tblData.rows[i].style.display = styleDisplay;
          }

      }
        </script>
</head>
<body>
    <form id="frmAutoChallProcess" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
      <div class="tabs_container"> AUTO CHALLAN <hr /></div>
        <asp:HiddenField ID="hdnCustid" runat="server"/> <asp:HiddenField ID="hdnSlipno" runat="server"/>  
        <asp:HiddenField ID="hdnCustname" runat="server"/>
        <table class="tbldecoration" style="width:auto; float:left;">                                  
         
        <tr><td>&nbsp;</td>
            <td>Customer Name</td>
            <td><asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox"  AutoPostBack="true"  ></asp:TextBox>
            <cc1:AutoCompleteExtender ID="empsearch" runat="server" TargetControlID="txtCustomer"
            ServiceMethod="CustomerSearch" MinimumPrefixLength="1" CompletionSetCount="1"
            CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
            CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </cc1:AutoCompleteExtender></td>
            <td>
                Email Address:<asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true"  ></asp:TextBox>
            </td>
            <td style="text-align:left"><asp:Button ID="btnuploadSingle" Font-Bold="true" runat="server" Text="Upload" OnClick="btnuploadSingle_Click" /></td>
         </tr>                       
        <tr><td colspan="5"><hr />
            </td></tr>  
       </table>                        
    </div>
<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
