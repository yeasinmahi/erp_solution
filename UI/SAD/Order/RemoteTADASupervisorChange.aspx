<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoteTADASupervisorChange.aspx.cs" Inherits="UI.SAD.Order.RemoteTADASupervisorChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><title></title><meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />

    
     <link href="../../../../Content/CSS/GridHEADER.css" rel="stylesheet" />
    <script src="../../../../Content/JS/JQUERY/jquery-1.10.2.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/jquery-ui.min.js"></script>
    <script src="../../../../Content/JS/datepickr.min.js"></script>
    <script src="../../../../Content/JS/JQUERY/MigrateJS.js"></script>
    <script src="../../../../Content/JS/JQUERY/GridviewScroll.min.js"></script>
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />

    <script type="text/javascript">
        $(document).ready(function () {

            SearchBox();
        });
        function EmplnameChanged() {
            document.getElementById('hdfEmplSearchBoxTextChange').value = 'true';
        }
        function SearchBox() {
            $("#<%=grdvForTADASupervisorUPdate.ClientID%>").find(".txtBox").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: '<%=ResolveUrl("~/ClassFiles/AutoCompleteSearch.asmx/getSupervisorForUpdate") %>',
                          data: '{"intJobstaionid":"' + $("#hdnstation").val() + '","prefix":"' + request.term + '"}',

                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          success: function (data) {
                              response($.map(data.d, function (item) {
                                  return {
                                      label: item.split('^')[0],
                                      val: item.split('^')[1]
                                  }
                              }))
                          },
                          error: function (response) {
                              alert(response.responseText);
                          },
                          failure: function (response) {
                              alert(response.responseText);
                          }
                      });
                  },
                 minLength: 1
             });
          }


          $(document).ready(function () {
              GridviewScroll();
          });
          function GridviewScroll() {

              $('#<%=grdvForTADASupervisorUPdate.ClientID%>').gridviewScroll({
                width: 1025,
                height: 340,
                startHorizontal: 0,
                wheelstep: 10,
                barhovercolor: "#3399FF",
                barcolor: "#3399FF"
            });
        }

        function DisplayLoadingDiv() { document.getElementById('dvDisable').style.visibility = 'visible'; }


         </script>

     <script type="text/javascript">
         $(document).ready(function () {
             SearchText();
         });
         function Changed() {
             document.getElementById('hdfSearchBoxTextChange').value = 'true';
         }
         function SearchText() {
             $("#txtFullName").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         type: "POST",
                         contentType: "application/json;",
                         url: "RemoteTADASupervisorChange.aspx/GetAutoCompleteDataForTADA",
                         data: "{'strSearchKey':'" + document.getElementById('txtFullName').value + "'}",
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








</head>
<body>
    <form id="frmpdv" runat="server">
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
        
          <div class="leaveApplication_container"> 
    <div class="tabs_container"> TA DA Supervisor change:<asp:HiddenField ID="hdnApplicantEnrol" runat="server"/>
        <asp:HiddenField ID="hdnstation" runat="server"/><asp:HiddenField ID="hdnsearch" runat="server"/>
        <asp:HiddenField ID="hdnofficeEmail" runat="server"/>
       <asp:HiddenField ID="hdfSearchBoxTextChange" runat="server"/><asp:HiddenField ID="hdnAction" runat="server"/>
        <asp:HiddenField ID="HiddenUnit" runat="server"/>
       <asp:HiddenField ID="hdfEmplSearchBoxTextChange" runat="server"/>
         <asp:HiddenField ID="hdfEmpEnrol" runat="server"/>
        <hr /></div>
        <table border="0"; style="width:Auto"; > 


        
         <tr class="tblrowOdd">
                                
                          
                                  <td><asp:Label ID="lblUpdateType" runat="server" CssClass="lbl"  Text="Update Type: "></asp:Label></td>
                    <td><asp:RadioButtonList ID="rdbUpdateType" runat="server" OnSelectedIndexChanged="rdbUpdateType_SelectedIndexChanged"
                    RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Text="Single User update" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Multiple User update" Value="2" Selected="True"></asp:ListItem>
                     <asp:ListItem Text="Single user Insertion" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>  
            </tr>   
            <tr>
            <td>
                     <asp:Label ID="lblEmplyeEnrol" runat="server" CssClass="lbl"   Text="Employee Enrol "></asp:Label>

               </td>
                <td>
                    <%--<asp:TextBox ID="txtEnrol"  runat="server" CssClass="txt" Width="300px" placeholder="Type Employee Enrolment Number"></asp:TextBox>--%>
                    <asp:TextBox ID="txtEnrol" runat="server"  placeholder="Type Employee Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True" onchange="javascript: EmplnameChanged();"></asp:TextBox>
                </td>

                 <td>
                     <asp:Label ID="lblSupervisorEnrol" runat="server" CssClass="lbl"   Text="Supervisor Enrol "></asp:Label>

               </td>
                <td>
                    <asp:TextBox ID="txtFullName" runat="server"  placeholder="Type  Name"  Font-Bold="true" CssClass="txtBox" AutoPostBack="True" onchange="javascript: Changed();"></asp:TextBox>

                </td>

           </tr>   
             
            <tr>
                <td>
                     <asp:Label ID="lblUnit" runat="server" CssClass="lbl"   Text="Unit"></asp:Label>

               </td>
                <td colspan="3">
                    <asp:DropDownList ID="drdlUnit" runat="server" Width="300px" DataSourceID="objUnitPermissionbyUser" DataTextField="strUnit" DataValueField="intUnitID" AutoPostBack="true"></asp:DropDownList>

                    <asp:ObjectDataSource ID="objUnitPermissionbyUser" runat="server" SelectMethod="getUnitPermission" TypeName="SAD_BLL.Customer.Report.StatementC">
                        <SelectParameters>
                            <asp:SessionParameter Name="Enrol" SessionField="sesUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

               </td>
            </tr>
            <tr>
                <td>
                      <asp:Label ID="lblJobstation" runat="server" CssClass="lbl"   Text="Jobstation"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="drdlJobstation" runat="server" Width="300px" DataSourceID="objJobstationlist" DataTextField="strJobStationName" DataValueField="intEmployeeJobStationId"></asp:DropDownList>
                    <asp:ObjectDataSource ID="objJobstationlist" runat="server" SelectMethod="getJobstationbasedonUnit" TypeName="SAD_BLL.Customer.Report.StatementC">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="drdlUnit" Name="Unitid" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
           
          
           
          
            <tr class="tblrowOdd"><td style="text-align:right" colspan="4"> <asp:Button ID="btnShow" runat="server" Text="Show"  OnClientClick="DisplayLoadingDiv()"  OnClick="btnShow_Click" /></td> </tr>
            


        <div>
                <table>
        <tr class="tblrowodd">
              <td>
              <asp:GridView ID="grdvForTADASupervisorUPdate" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdvForTADASupervisorUPdate_PageIndexChanging" OnRowDataBound="grdvForTADASupervisorUPdate_RowDataBound"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
              
              <Columns>
                   
                   <asp:BoundField DataField="Sl" HeaderText="Sl" SortExpression="intsl" />
                   <asp:BoundField DataField="intidtbl" HeaderText="intid" SortExpression="intidtbl" />
                   <asp:BoundField DataField="intEmplenrol" HeaderText="Enrol" SortExpression="intEmplenrol" />
                   <asp:BoundField DataField="strEmployeename" HeaderText="Employee Name" SortExpression="strEmployeename" />
                   <asp:BoundField DataField="strEmplDesgnation" HeaderText="Desg." SortExpression="strEmplDesgnation" />
                   <asp:BoundField DataField="strEmplJobstation" HeaderText="EmployeeJobstation" SortExpression="strEmplJobstation"  />
                   <asp:BoundField DataField="intjobstationid" HeaderText="Jobstaionid" SortExpression="intjobstationid" Visible="false" />
                   <asp:BoundField DataField="strSupervisro" HeaderText="Supervisor" SortExpression="strSupervisro" />
                   <asp:BoundField DataField="intsupvid" HeaderText="Supid" SortExpression="intsupvid" />
                   <asp:TemplateField HeaderText="Search" SortExpression=""> 
                       <ItemTemplate>
                         
                           <asp:TextBox ID="txtSearch" CssClass="txtBox" Width="200px" runat="server"></asp:TextBox>

                       </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100px"/></asp:TemplateField>
                    <asp:TemplateField HeaderText="Update.">
                    <ItemTemplate>
                     <asp:Button ID="btnSupervisorUpdate" runat="server" Text="Update" class="button" CommandName="complete" OnClick="btnSupervisorUpdate_Click" CommandArgument='<%# Eval("intidtbl")+","+Eval("intEmplenrol")%>' /></ItemTemplate>
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
                 <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                   </asp:GridView>
                  </td>
          </tr>
                    </table>
            </div> 


             <div>
                <table>
        <tr class="tblrowodd">
              <td>
              <asp:GridView ID="grdvForSpervisorInsertion" runat="server" AutoGenerateColumns="False" AllowPaging="false"  BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  OnPageIndexChanging="grdvForSpervisorInsertion_PageIndexChanging" OnRowDataBound="grdvForSpervisorInsertion_RowDataBound"  >
              
                  <AlternatingRowStyle BackColor="#CCCCCC" />
        
                 
              <Columns>

                   <asp:BoundField DataField="intenrolins" HeaderText="Enrol" SortExpression="intEmplenrol" />
                   <asp:BoundField DataField="strnameemplins" HeaderText="Employee Name" SortExpression="strEmployeename" />
                   <asp:BoundField DataField="strEmplDesgnationins" HeaderText="Desg." SortExpression="strEmplDesgnation" />
                   <asp:BoundField DataField="strEmplJobstationins" HeaderText="EmployeeJobstation" SortExpression="strEmplJobstation"  />
                   <asp:TemplateField HeaderText="Insert.">
                    <ItemTemplate>
                     <asp:Button ID="btnsupervisorInsert" runat="server" Text="Insert" class="button" CommandName="complete" OnClick="btnsupervisorInsert_Click" CommandArgument='<%# Eval("intenrolins")%>' /></ItemTemplate>
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
                 <HeaderStyle CssClass="GridviewScrollHeader" /><PagerStyle CssClass="GridviewScrollPager" />
                   </asp:GridView>
                  </td>
          </tr>
                    </table>
            </div> 
   </table>

                  <div id="dvDisable" class="clsWaitPage"><h1 style="font:bold 50px Bernard MT Condensed; font-style:italic; color:white;">Loading ... ...</h1>
    <img src="../../Content/images/img/loading.gif" width="300" height="300"/>
    </div>

            </div>
        




<%--=========================================End My Code From Here=================================================--%>
         </ContentTemplate>
    </asp:UpdatePanel>
           </form>
</body>
</html>