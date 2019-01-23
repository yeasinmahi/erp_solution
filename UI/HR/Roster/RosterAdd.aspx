<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RosterAdd.aspx.cs" Inherits="UI.HR.Roster.RosterAdd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Overtime Entry</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
      <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel0" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <cc1:alwaysvisiblecontrolextender targetcontrolid="pnlUpperControl" id="AlwaysVisibleControlExtender1" runat="server">
                </cc1:alwaysvisiblecontrolextender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Roster Shift" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label20" runat="server" Text="Unit"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlUnit" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlUnit_OnSelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label2" runat="server" Text="Job Station"></asp:Label>
                                    <%--<span style="color: red; font-size: 14px; text-align: left">*</span>--%>
                                    <asp:DropDownList ID="ddlJobStation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlJobStation_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label3" runat="server" Text="Sequence"></asp:Label>
                                    <asp:DropDownList ID="ddlSequence" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlSequenceId_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label1" runat="server" Text="Team"></asp:Label>
                                    <asp:DropDownList ID="ddlTeam" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlTeam_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label4" runat="server" Text="Shift"></asp:Label>
                                    <asp:DropDownList ID="ddlShift" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" AutoPostBack="True" OnSelectedIndexChanged="ddlShift_OnSelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label5" runat="server" Text="Shift Start"></asp:Label>
                                    <asp:TextBox ID="txtShiftStart" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="false" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label6" runat="server" Text="Shift End"></asp:Label>
                                    <asp:TextBox ID="txtShiftEnd" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="false" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label7" runat="server" Text="Punch Last Time"></asp:Label>
                                    <asp:TextBox ID="txtPunchLastTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="false" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label8" runat="server" Text="Duty Time"></asp:Label>
                                    <asp:TextBox ID="txtDutyTime" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="false" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label9" runat="server" Text="Roster Duty Date"></asp:Label>
                                    <asp:TextBox ID="txtDutyDate" CssClass="form-control col-md-12 col-sm-12 col-xs-12" AutoComplete="off"  runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label11" runat="server" Text="Employee Enroll"></asp:Label>
                                    <asp:TextBox ID="txtEnroll" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" ></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-sm-6">
                               <asp:Label ID="LblAsset" runat="server" CssClass="lbl" font-size="small" Text="Asset Number:"></asp:Label> 
          
                                <asp:TextBox ID="TxtAsset"   CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server"    AutoPostBack="true" OnTextChanged="TxtAsset_TextChanged" ></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="TxtAsset"
                                ServiceMethod="GetAssetAutoSearch" MinimumPrefixLength="1" CompletionSetCount="1"
                                CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>  
                                </div>
                                <div class="col-md-6 col-sm-6">
                                    <asp:Label ID="Label10" runat="server" Text="Asset Location:"></asp:Label>
                                       <asp:TextBox ID="txtAssetLocation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" ></asp:TextBox>
                                    
                                </div>
                                <div class="col-md-12" style="padding-top: 10px">
                                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary form-control pull-right" Text="Add" OnClientClick="return Validate();" OnClick="btnAdd_OnClick" />
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="panel panel-info" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Roster Shift Details" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Width="100%"
                                DataKeyNames="empEnroll" OnRowDeleting="GridView_OnRowDeleting" GridLines="Both">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Enroll">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpEnroll" runat="server" Text='<%# Bind("empEnroll") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shift">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShift" runat="server" Text='<%# Bind("shift") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jobstation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobstation" runat="server" Text='<%# Bind("jobstation") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sequence">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSequence" runat="server" Text='<%# Bind("sequence") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs" CommandName="Delete" OnClick="btnDelete_OnClick" />
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
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
                            <div class="col-md-12" style="padding-top: 15px;">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary form-control pull-right" OnClick="btnSubmit_OnClick" />
                            </div>
                        </div>

                    </div>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function showPanel() {
                var itemPanel = document.getElementById("itemPanel");
                itemPanel.classList.remove("hidden");
                return true;
            }
            function hidePanel() {
                var itemPanel = document.getElementById("itemPanel");
                itemPanel.classList.add("hidden");

            }
            function Validate() {
                var txtEnroll = document.getElementById("txtEnroll").value;
                var txtDate = document.getElementById("txtDutyDate").value;
                var ddlShift = document.getElementById("ddlShift");
                var strUser = ddlShift.options[ddlShift.selectedIndex].value;
                if (txtEnroll === null || txtEnroll === "") {
                    ShowNotification('Enter Employee Enroll', 'Roster', 'warning');
                    return false;
                }
                if (txtDate === null || txtDate === "") {
                    ShowNotification('Date can not be blank', 'Roster', 'warning');
                    return false;
                }
                if (strUser === null || strUser === "") {
                    ShowNotification('Shift can not be blank', 'Roster', 'warning');
                    return false;
                }
                return true;
            }
            $(function () {
                Init();
                //ShowHideGridviewPanels();
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
                //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(ShowHideGridviewPanels);
            });

            function Init() {
                $('#txtDutyDate').datepicker();
            }
        </script>
    </form>

    <style>
        table {
            max-width: 100%;
            background-color: transparent;
            text-align: center;
        }

        th {
            text-align: center;
        }

        .table {
            width: 100%;
            margin-bottom: 20px;
        }

        tr {
            font-size: 14px;
        }

        .datepicker {
            -ms-transform: translate(0, 3.1em);
            -webkit-transform: translate(0, 3.1em);
            transform: translate(0, 3.1em);
        }
    </style>
</body>
</html>
