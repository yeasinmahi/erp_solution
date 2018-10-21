<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupporterUser.aspx.cs" Inherits="UI.CreativeSupportModule.SupporterUser" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Supporter Add/Remove</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>

    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <script src="../Content/JS/datepickr.min.js"></script>

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />

    <style type="text/css">
        /*.my-float{
            padding-top: 20px;
            padding-right: 20px;
        }*/
        .full-screen {
            width: 90%;
            margin: 0;
            top: 0;
            left: 0;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Supporter Add/Remove" Font-Bold="true" Font-Size="16px"></asp:Label> 
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="Label20" runat="server" Text="Enroll"></asp:Label>
                                    <span style="color: red; font-size: 14px; text-align: left">*</span>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtEnroll" TextMode="Number" CssClass="form-control col-md-8" runat="server" placeholder="Enroll"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control" Text="Add" OnClick="btnAdd_OnClick" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Users" Font-Bold="true" Font-Size="16px"></asp:Label> 
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Both" Width="100%" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" ID="supportUserId" Value='<%# Bind("supportUserId") %>'/>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEmployeeName" runat="server"  Text='<%# Bind("strEmployeeName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmployeeName" runat="server"  CssClass="pull-left" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEnroll" runat="server" Text='<%# Bind("enroll") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnroll" runat="server" Text='<%# Bind("enroll") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Permission Date & Time">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtInsertDate" runat="server" Text='<%# Bind("insertDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblInsertDate" runat="server"  Text='<%# Bind("insertDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnRemove" runat="server" class="btn btn-danger form-control col-lg-12" Text="Remove" OnClientClick ="return ConfirmRemove()" OnClick="btnRemove_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
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
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    
    <style>
        table {
            max-width: 100%;
            background-color: transparent;
            text-align:center;
        }
        th {
            text-align: center;
        }

        .table {
            width: 100%;
            margin-bottom: 20px;
        } 
    </style>
    <script type="text/javascript">
        function ConfirmRemove() {
            if (confirm("Are you want to remove?"))
            {
                return true;
            }
            return false;
        }
    </script>
    <style>
        #gridView tr
        {
            font-size: 14px !important; 
        }
        .container{
            padding-top:50px;
        }
    </style>
</body>
</html>
