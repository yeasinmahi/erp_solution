<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PointTargetChange.aspx.cs" Inherits="UI.HR.Employee.PointTargetChange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Overtime Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
</head>
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
                                    <asp:Label runat="server" Text="Point Target Change Input" Font-Bold="true" Font-Size="16px"></asp:Label>

                                </div>
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-3 col-sm-6">
                                            <asp:Label ID="Label20" runat="server" Text="Line:"></asp:Label>
                                            <asp:DropDownList ID="ddlLine" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                             <asp:Label ID="Label2" runat="server" Text="Region:"></asp:Label>
                                            <asp:DropDownList ID="ddlRegion" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                            <asp:Label ID="Label4" runat="server" Text="Area:"></asp:Label>
                                            <asp:DropDownList ID="ddlArea" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 col-sm-6">
                                             <asp:Label ID="Label5" runat="server" Text="Territory:"></asp:Label>
                                            <asp:DropDownList ID="ddlTerritory" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="true" OnSelectedIndexChanged="ddlTerritory_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                         <div class="col-md-3 col-sm-6">
                                             <asp:Label ID="Label6" runat="server" Text="Point:"></asp:Label>
                                            <asp:DropDownList ID="ddlPoint" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True">
                                            </asp:DropDownList>
                                        </div>
                                         <div class="col-md-3 col-sm-6">
                                             <asp:Label ID="Label1" runat="server" Text="Date:"></asp:Label>
                                            <asp:TextBox ID="txtDate" placeholder="Click Here" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoComplete="off">
                                            </asp:TextBox>
                                             <cc1:CalendarExtender ID="fd" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>
                                        </div>
                                        <div class="col-md-12 col-sm-12" style="padding-top: 10px">
                                            <asp:Button ID="btnShow" runat="server" class="btn btn-primary form-control pull-right" Text="Show" OnClientClick="return ValidateDate();" OnClick="btnShow_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                       
                    <div class="panel panel-info" id="panel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Point Target Change Form" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                DataKeyNames="intproductid" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="20"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductId" runat="server" Text='<%# Bind("intproductid") %>' Width="80"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstrcode" runat="server" Width="80" Text='<%# Bind("strcode") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QTY">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblmontargetconvqty" Width="80" runat="server" Text='<%# Bind("montargetconvqty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="center" Width="80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UOM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpackqty" runat="server" Text='<%# Bind("intpackqty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QTYPcs">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQTYPcs" runat="server" Text="0.00"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"></ItemStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" Width="80" runat="server" CssClass="btn btn-sm btn-success" Text="Update" class="button" CommandName="Update" OnClick="btnUpdate_Click" />
                                        </ItemTemplate>
                                         <ItemStyle Width="80"></ItemStyle>
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


