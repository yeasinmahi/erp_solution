<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HR_EmpSalaryStop.aspx.cs" Inherits="UI.Dairy.HR_EmpSalaryStop" %>
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

    
  <script type="text/javascript">
      $("[id*=chkHeader]").live("click", function () {
          var chkHeader = $(this);
          var grid = $(this).closest("table");
          $("input[type=checkbox]", grid).each(function () {
              if (chkHeader.is(":checked")) {
                  $(this).attr("checked", "checked");
                  $("td", $(this).closest("tr")).addClass("selected");
              } else {
                  $(this).removeAttr("checked");
                  $("td", $(this).closest("tr")).removeClass("selected");
              }
          });
      });
      $("[id*=chkRow]").live("click", function () {
          var grid = $(this).closest("table");
          var chkHeader = $("[id*=chkHeader]", grid);
          if (!$(this).is(":checked")) {
              $("td", $(this).closest("tr")).removeClass("selected");
              chkHeader.removeAttr("checked");
          } else {
              $("td", $(this).closest("tr")).addClass("selected");
              if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                  chkHeader.attr("checked", "checked");
              }
          }
      });
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
    <asp:HiddenField ID="hdnconfirm" runat="server" />
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
        
        <div class="tabs_container"> EMPLOYEE LIST FOR SALARY HOLD<hr /></div>

        <table  class="tbldecoration" style="width:auto; float:left;">
        <tr>                
            <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" Width="120px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList>                                                                                       
            </td>

            <td style="text-align:right;"><asp:Label ID="lblJobStation" runat="server" CssClass="lbl" Text="Job Station :"></asp:Label></td>
            <td style="text-align:left;">
                <asp:DropDownList ID="ddlJobStation" CssClass="ddList" AutoPostBack="true" Font-Bold="False" runat="server" OnSelectedIndexChanged="ddlJobStation_SelectedIndexChanged"></asp:DropDownList>                                                                       
            </td>      
            
            <td>
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Date :"></asp:Label></td>                
                <td><asp:TextBox ID="txtDate" runat="server" AutoPostBack="false" CssClass="txtBox" Enabled="true" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender></td> 
            
            </td>                  
        </tr>
            
        <tr>
            <td  colspan="2">
                <asp:CheckBox ID="cbSalaryHoldR" runat="server" Text="Salary Hold Report" AutoPostBack="true" OnCheckedChanged="cbSalaryHoldR_CheckedChanged" />
            </td>
            <td colspan="3" style="text-align:left;"><asp:Button ID="btnShow" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Show Report" OnClick="btnShow_Click"/></td>                      
            <td colspan="2" style="text-align:left;"><asp:Button ID="btnAllHold" runat="server" ForeColor="Green" Font-Bold="true" class="nextclick" Text="Hold" OnClientClick="ConfirmAll()" OnClick="btnAllHold_Click"/></td>            
            
        </tr>
            
        </table>
        </div>

        <div class="tabs_container" runat="server" id="ReportDiv">

        <table class="tbldecoration" style="width:auto; float:left;">
        <tr><td style="font-weight:bold; font-size:13px; float:center;"><hr /></td></tr>   

            <tr><td> 
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  
            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" Font-Bold="false"> 
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>            
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="20px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
                     
            <asp:TemplateField HeaderText="Enroll" ItemStyle-HorizontalAlign="center" SortExpression="intEmployeeID" >
            <ItemTemplate><asp:Label ID="lblEnroll" runat="server" Text='<%# (""+Eval("intEmployeeID")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Employee Code" ItemStyle-HorizontalAlign="left" SortExpression="strEmployeeCode" >
            <ItemTemplate><asp:Label ID="lblEmpCode" runat="server" Text='<%# (""+Eval("strEmployeeCode")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="left" SortExpression="strEmployeeName" >
            <ItemTemplate><asp:Label ID="lblEmpName" runat="server" Text='<%# (""+Eval("strEmployeeName")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Designation" ItemStyle-HorizontalAlign="left" SortExpression="strDesignation" >
            <ItemTemplate><asp:Label ID="lblDesignation" runat="server" Text='<%# (""+Eval("strDesignation")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Depatrment" ItemStyle-HorizontalAlign="left" SortExpression="strDepatrment" >
            <ItemTemplate><asp:Label ID="lblDepartment" runat="server" Text='<%# (""+Eval("strDepatrment")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Job Type" ItemStyle-HorizontalAlign="left" SortExpression="strJobType" >
            <ItemTemplate><asp:Label ID="lblJobType" runat="server" Text='<%# (""+Eval("strJobType")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:TemplateField HeaderText="Office Email" ItemStyle-HorizontalAlign="left" SortExpression="strOfficeEmail" >
            <ItemTemplate><asp:Label ID="lblEmail" runat="server" Text='<%# (""+Eval("strOfficeEmail")) %>'></asp:Label></ItemTemplate></asp:TemplateField>

            <asp:BoundField DataField="dteJoiningDate" HeaderText="Joining Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteJoiningDate">
            <ItemStyle HorizontalAlign="center" Width="82px"/></asp:BoundField>
                            
            <asp:TemplateField><HeaderTemplate><asp:CheckBox ID="chkHeader" runat="server" ItemStyle-HorizontalAlign="Center" HeaderText="Select All"/></HeaderTemplate>
            <ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate></asp:TemplateField>
                
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Salary Hold" >
            <ItemTemplate><asp:Button ID="btnHold" runat="server" class="nextclick" style="cursor:pointer; font-size:11px;" 
            CommandArgument='<%# Eval("intEmployeeID") %>' Text="Hold" OnClientClick="ConfirmAll()" OnClick="btnHold_Click"/>
            </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="25PX" /></asp:TemplateField>

            </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView></td>
            </tr>


        </table>
    </div>







<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
