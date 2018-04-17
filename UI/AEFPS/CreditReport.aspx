<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditReport.aspx.cs" Inherits="UI.AEFPS.CreditReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
   
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
    <form id="frmSalesReturn" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div>
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel>
    <div style="height: 100px;"></div>
    <%--<cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
    </cc1:AlwaysVisibleControlExtender>--%>
    <%--=========================================Start My Code From Here===============================================--%>
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnconfirm" runat="server" /> <asp:HiddenField ID="hdnJobStation" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="leaveApplication_container"> 
    <div class="tabs_container"> CREDIT REPORT <hr/></div>        
        
        <table class="tbldecoration" style="width:auto; float:left;">    
            
        <tr>                
            <td style="text-align:center;"><asp:Label ID="lblWH" runat="server" CssClass="lbl" Text="WH Name:"></asp:Label>
                <asp:DropDownList ID="ddlWH" runat="server" CssClass="ddList" AutoPostBack="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList></td>
        
            <td style="text-align:right;"><asp:Button ID="btnShow" runat="server" CssClass="nextclick" ForeColor="Black" Text="Show" OnClick="btnShow_Click"/></td>   
        </tr>
        <tr><td colspan="2"><hr /></td></tr>
        
        </table>

        <table>
        <tr>
            <td style="text-align:center;">
                <asp:GridView ID="dgvCreditReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" ShowFooter="true" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvCreditReport_RowDataBound">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="15px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                                        
                        <asp:TemplateField HeaderText="Enroll" SortExpression="intWHEnrollNo" HeaderStyle-HorizontalAlign="Center">
                        <HeaderTemplate><asp:TextBox ID="TxtServiceConfg" runat="server" Width="40px" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvCreditReport')"></asp:TextBox></HeaderTemplate>
                        <ItemTemplate><asp:Label ID="lblEnroll" Width="40px" runat="server" Text='<%# Bind("intWHEnrollNo") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Employee Name" SortExpression="strEmployeeName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblName" Width="140px" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="140px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation" SortExpression="strDesignation" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblDesignation" Width="100px" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Department" SortExpression="strDepatrment" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblDepartment" Width="130px" runat="server" Text='<%# Bind("strDepatrment") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="130px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Unit" SortExpression="strUnit" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblUnit" Width="60px" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px" /></asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Station" SortExpression="strJobStationName" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblJobStation" Width="130px" runat="server" Text='<%# Bind("strJobStationName") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="130px" /><FooterTemplate><asp:Label ID="lblTotal" runat="server" Text ="Total :" /></FooterTemplate></asp:TemplateField>

                        <asp:TemplateField HeaderText="Due Amount" SortExpression="monAmount" HeaderStyle-HorizontalAlign="Center"><ItemTemplate>
                        <asp:Label ID="lblDue" Width="60px" runat="server" Text='<%# (decimal.Parse(""+Eval("monAmount", "{0:n}"))) %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="60px" /><FooterTemplate><asp:Label ID="lblAmountT" runat="server" Text ='<%# totalamount %>' /></FooterTemplate></asp:TemplateField>

                        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
            </td>
        </tr>

       </table>
       </div>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
