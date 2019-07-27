<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeCostCenterUpdate.aspx.cs" Inherits="UI.HR.Employee.EmployeeCostCenterUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>costcenter</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
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

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container pull-left">
                    <div class="row">
                        <div class="col-md-10 col-sm-12 col-lg-10 col-xs-12">
                            <div class="panel panel-info">
                                <div class="panel-heading">
                                    <asp:Label runat="server" Text="Employee Costcenter update" Font-Bold="true" Font-Size="16px"></asp:Label>

                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-3 col-sm-6">
                                            <asp:Label ID="Label20" runat="server" Text="Unit:"></asp:Label>
                                            <asp:DropDownList ID="ddlunit" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlunit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                       
                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show"  OnClick="btnShow_Click" />
                                            <asp:Button ID="btnupdate" runat="server" class="btn btn-primary form-control pull-right" Text="Update" OnClick="btnupdate_Click1" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                       
                    <div class="panel panel-info" id="panel">
                        
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                 GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                   
                                      <asp:TemplateField HeaderText="SL.N"><HeaderTemplate>                                 
                                       
                     <asp:TextBox ID="TxtServiceConfg" runat="server"  width="70"  placeholder="Search" onkeyup="Search_dgvservice(this, 'gridView')"></asp:TextBox></HeaderTemplate>


                        <ItemTemplate><%# Container.DataItemIndex + 1 %>  </ItemTemplate>
                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll">
                                        <ItemTemplate>
                                            <asp:Label ID="lblintEmployeeID" runat="server" Text='<%# Bind("intEmployeeID") %>' Width="80"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrEmployeeCode" runat="server" Width="80" Text='<%# Bind("strEmployeeCode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrEmployeeName" runat="server" Width="80" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                      <ItemTemplate>
                                            <asp:Label ID="lblstrDesignation" runat="server" Width="80" Text='<%# Bind("strDesignation") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="strDepatrment">
                                      <ItemTemplate>
                                            <asp:Label ID="lblstrDepatrment" runat="server" Width="80" Text='<%# Bind("strDepatrment") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Jobtype">
                                      <ItemTemplate>
                                            <asp:Label ID="lblstrJobType" runat="server" Width="80" Text='<%# Bind("strJobType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Group Name">
                                      <ItemTemplate>
                                            <asp:Label ID="lblstrGroupName" runat="server" Width="80" Text='<%# Bind("strGroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Unit  Name">
                                      <ItemTemplate>
                                            <asp:Label ID="lblstrUnit" runat="server" Width="80" Text='<%# Bind("strUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jobstation  Name">
                                       <ItemTemplate>
                                            <asp:Label ID="lblstrJobStationName" runat="server" Width="80" Text='<%# Bind("strJobStationName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Cost Center  Name">
                                      <ItemTemplate>
                                             <asp:TextBox ID="txtCustomer" runat="server" AutoCompleteType="Search" CssClass="txtBox" AutoPostBack="true" Width="300px" placeholde="Search Customer"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtCustomer" 
                                    ServiceMethod="GetCustomerList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender> 
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
                         </div>
                    </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
       <script type="text/javascript">
           
            $(function () {

                Init();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
            });

           function Init() {
               $("input[type='text'][id*=lblmontargetconvqty]").keyup(function () {
                   var quantity = parseFloat($.trim($(this).val()));
                   if (isNaN(quantity)) {
                       quantity = 0;
                   }
                   var row = $(this).closest("tr");
                   $("[id*=lblQTYPcs]", row).html(parseFloat($("[id*=lblpackqty]", row).html()) * parseFloat($(this).val())).val();
 
               });
               


            }
        </script>
    </form>

</body>
</html>


