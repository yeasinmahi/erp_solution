<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportMainApporval_UI.aspx.cs" Inherits="UI.Import.ImportMainApporval_UI" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
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
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/Lstyle.css" rel="stylesheet" />
        

    <script>

        function Viewdetails() {
            window.open('Registration_UI.aspx?ID=' + ID, "height=375, width=730, scrollbars=yes, left=250, top=200, resizable=no, title=Preview");
        }

        //function ViewDocument(enroll, vwtype)
        //{ window.open('DocViews.aspx?EN=' + enroll + '&TP=' + vwtype, 'sub', "height=550, width=850, scrollbars=yes, left=300, top=250, resizable=yes, title=Preview");}
        function ViewDocument(PathFile)
        { window.open('DocView.aspx?EN=' + PathFile, 'sub', "height=550, width=850, scrollbars=yes, left=300, top=250, resizable=yes, title=Preview"); }

</script>
   <script>
       function DocMViewDatas(url) {
           newwindow = window.open(url, 'sub', 'height=550, width=850, scrollbars=yes, left=300, top=180, resizable=yes, title=Preview');
           if (window.focus) { newwindow.focus() }
       }
       

      
         </script> 
          
</head>
<body>
    <form id="frmselfresign" runat="server">        
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" /><asp:HiddenField ID="hdnTopSheetCount" runat="server" />
   
        
        <div class="tabs_container">INDENT DETALIS REPORT <hr /></div>
        
        <table >
        <tr>  
            <td style="text-align:right;"><asp:Label ID="Label151" CssClass="lbl" runat="server" Text="Unit Name: "></asp:Label></td>
                <td><asp:DropDownList ID="DdlUnit" runat="server"  CssClass="dropdownList" AutoPostBack="True"></asp:DropDownList> 
                         
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Type:"></asp:Label></td>
            <td><asp:DropDownList ID="DdlType" runat="server"  CssClass="dropdownList" OnSelectedIndexChanged="DdlType_SelectedIndexChanged" AutoPostBack="True">
               <asp:ListItem  Value="0">Pending</asp:ListItem>
                <asp:ListItem Value="1">Approved</asp:ListItem>
                </asp:DropDownList> 
             <td style="text-align:left;"><asp:Button ID="btnShowReport" runat="server" Font-Bold="true"   Text  ="Show Report" OnClick="btnShowReport_Click" /></td>
        </tr>
</table>
<table>
    <tr>
        <td>
          <asp:GridView ID="DgvMReport" runat="server"  AutoGenerateColumns="False">

              <Columns>
                  <asp:TemplateField HeaderText="SL."><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                  
                  <asp:BoundField DataField="intRFQID" HeaderText="ReFIQID" SortExpression="intRFQID" />
                  <asp:BoundField DataField="strIndent" HeaderText="IndentNo" SortExpression="strIndent" />
                  <asp:BoundField DataField="strCreateBy" HeaderText="CreateBy" SortExpression="strCreateBy" />
                  <asp:BoundField DataField="ysnComplete" HeaderText="Ysn"  Visible="false" SortExpression="ysnComplete" />
                  <asp:BoundField DataField="dteRFQDate" HeaderText="RFQDate" SortExpression="dteRFQDate" />
                  <asp:BoundField DataField="numQuote" HeaderText="Quote" SortExpression="numQuote" />
                  <asp:TemplateField HeaderText="Detalis">
                      <ItemTemplate>
                          <asp:Button ID="BtnDetalis" runat="server" Text="Detalis" CommandName="Submit"  CommandArgument='<%#GetJSFunctionString( Eval("intRFQID"),Eval("ysnComplete"),Eval("numQuote")) %>' OnClick="BtnDetalis_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>

            </asp:GridView>
        </td>
  
</table>


        
       
        
       
       
        
        <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

