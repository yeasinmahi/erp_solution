<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPI_UI.aspx.cs" Inherits="UI.HR.KPI.KPI_UI" %>

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
     <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
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


    <script type="text/javascript">

        //lblGrandTotalAvFatPer, lblAveFatPer
        //if (isNaN(a) == true) { a = 0;}
        $(function () {
            $("[id*=txtGradeNumber]").val("0");
        });

        $("[id*=txtGradeNumber]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { $(this).val(parseFloat($(this).val()).toString()); }
        });

        $("[id*=txtGradeNumber]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    //$(this).val('0');
                    $("[id*=lblGrade]", row).html('A');

                    if (parseFloat($(this).val()) == 0 || parseFloat($(this).val()) == '') { $("[id*=lblGrade]", row).html(''); }
                    else if (parseFloat($(this).val()) >= 90) { $("[id*=lblGrade]", row).html('A+'); }
                    else if (parseFloat($(this).val()) >= 80) { $("[id*=lblGrade]", row).val('A'); }
                    else if (parseFloat($(this).val()) >= 70) { $("[id*=lblGrade]", row).html('B'); }
                    else if (parseFloat($(this).val()) >= 60) { $("[id*=lblGrade]", row).html('C'); }
                    else if (parseFloat($(this).val()) >= 50) { $("[id*=lblGrade]", row).html('D'); }                    
                    else { $("[id*=lblGrade]", row).html('F'); }
                   
                    //if ((parseFloat($(".balqty", row).html()) < parseFloat($(this).val()))) {
                    //    //if ((parseFloat($(".blqt", row).html()) < parseFloat($(this).val()))) {
                    //    $(this).val('0');
                    //    $("[id*=lblIssueVal]", row).html((parseFloat($(".price", row).html()) * 0).toFixed(0));
                    //    $("[id*=lblAveFatPer]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                    //    alert("Please Check Quantity.");
                    //} else {

                    //    $("[id*=lblIssueVal]", row).html((parseFloat($(".price", row).html()) * parseFloat($(this).val())).toFixed(0));
                    //    $("[id*=lblAveFatPer]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                    //    $("[id*=Label1]", row).html((parseFloat($(".ftp", row).html()) * parseFloat($(this).val())).toFixed(0));
                                        
                    //}

                }
            } /*else { $(this).val(''); }*/

            
        });

</script>
            












    
  
    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
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
    <asp:HiddenField ID="hfEmployeeIdp" runat="server" /><asp:HiddenField ID="hdnwh" runat="server" />       
          <asp:HiddenField ID="HdnServiceCost" runat="server" />   <asp:HiddenField ID="hdnRepairsCost" runat="server" />   
            <div class="leaveApplication_container">
    <div class="tabs_container" align="Center" >Employee Performance Assessment Through KPI</div>
   
                <table class="tblrowodd" >
                     <tr>
                         <td></td>
                     </tr>
                    <tr>
                        <td style="text-align:right;">
                            <asp:Label ID="LblDtePO" runat="server" CssClass="lbl"  Font-Bold="true"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtDte" runat="server" Font-Bold="true" CssClass="txtBox"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtenderMonthly" runat="server" Format="yyyy-MMMM" TargetControlID="TxtDte">
                            </cc1:CalendarExtender>

                       


                        </td>
                    <td style="text-align:right;">
                    <asp:Label ID="Label2" runat="server" CssClass="lbl" font-size="small" Font-Bold="true" Text="Type-:"></asp:Label>
                    </td>
                    <td style="text-align: left;">
                    <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                    </td>
                        </tr>
                    <tr>
                        <td></td> <td></td> <td></td> 
                     
                      <td style="text-align: right;"><asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />

                        
                        
                            <asp:Button ID="btnSubmit" autopostback="true" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

                        </td>
                    </tr>
                </table>
        
          <table>
              <tr>
                  <td>
               <asp:GridView ID="dgvGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound = "OnRowDataBound" >
                   <Columns>
                    
                            
                      <asp:TemplateField HeaderText="SL.N">
                                 <HeaderTemplate>          
                                 <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>
                                </HeaderTemplate>
                              <ItemTemplate>
                                             <%# Container.DataItemIndex + 1 %>
                              </ItemTemplate>
                      </asp:TemplateField>

                        
                              <asp:TemplateField HeaderText="EmpID">
                                  <ItemTemplate>
                                      <asp:Label ID="intEmployeeID" runat="server" Text='<%# Eval("intEmployeeID") %>'></asp:Label>
                                  </ItemTemplate>
                        </asp:TemplateField>
                             
                    <asp:BoundField DataField="strEmployeeName" HeaderText="EmpName" SortExpression="strEmployeeName"/>
                     
                       <asp:BoundField DataField="strJobStationName" HeaderText="Jobstation" SortExpression="strJobStationName" />
                       <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment" />
                  
                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation" />         
                           
                       
                 
                            
            <asp:TemplateField HeaderText="Marks"><ItemTemplate>
            <asp:TextBox ID="txtGradeNumber" runat="server" CssClass="txtBoxGridAmount" TextMode="Number" MaxLength="3"   Width="100px" Text='<%# Bind("decGradeNumber") %>'></asp:TextBox></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="45px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Grade" ItemStyle-HorizontalAlign="center">
            <ItemTemplate><asp:Label ID="lblGrade" runat="server" CssClass="gradepoint" Text='<%# Bind("strGrade") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="right" Width="40px"/></asp:TemplateField>

                            

            
              
                           

                 
                            
             <asp:TemplateField>
            <HeaderTemplate>
                <asp:CheckBox ID="chkHeader" runat="server" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
                       
                   </Columns>
                      </asp:GridView>
                  </td>
                  
                  
              </tr>
          </table>
          </div>
        <div class="leaveSummary_container"  style="width:200px ;"> 
        <div class="tabs_container">Grading Charts :<hr /></div>
        <asp:GridView ID="dgvlist" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid" 
        BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical"><AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
        <asp:TemplateField HeaderText="SL"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
       
        <asp:BoundField DataField="strGrade" HeaderText="Grade"  ItemStyle-HorizontalAlign="Center" SortExpression="strGrade">
        <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:BoundField>
         
        <asp:BoundField DataField="marks" HeaderText="Marks" ItemStyle-HorizontalAlign="Center" SortExpression="marks">
        <ItemStyle HorizontalAlign="Left"  Width="100px"/></asp:BoundField>
          
            
                         
        </Columns><HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
       
    </div>
        
         
            
<%--=========================================End My Code From Here=================================================--%>
      
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

