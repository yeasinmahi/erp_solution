<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maintenance_Service_Cost_Update.aspx.cs" Inherits="UI.Asset.Maintenance_Service_Cost_Update" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Maintenance Service Cost Update</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />

    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/CSS/jquery-ui.min.css" rel="stylesheet" />


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
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div style="height: 50px; width: 100%"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="container">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Maintenance Service Cost Update" Font-Bold="true" Font-Size="16px"></asp:Label></div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label20" runat="server" Text="Job Station Name"></asp:Label>
                                    <asp:DropDownList ID="ddlJobStation" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True"></asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
                                    <asp:DropDownList ID="ddlType" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" Enabled="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                         <asp:ListItem Text="--Select Type--"></asp:ListItem>
                                        <asp:ListItem Text="Job"></asp:ListItem>
                                        <asp:ListItem Text="Bill"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                              
                            </div>
                            <div class="row">
                                 <div class="col-md-6 hidden" id="jobCard">
                                    <asp:Label ID="Label1" runat="server" Text="Job Card No"></asp:Label>
                                    <asp:TextBox ID="txtJobCard" CssClass="form-control col-md-12 col-sm-12 col-xs-12" onkeypress="if ( isNaN( String.fromCharCode(event.keyCode) )) return false;" runat="server" placeholder="Insert Job Card No"></asp:TextBox>
                                </div>
                                <div class="col-md-6 hidden" id="JobSearch">
                                    <asp:Label ID="Label4" runat="server" Text="Job Search"></asp:Label>
                                    <asp:TextBox ID="txtJobSearch" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Search Job"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtJobSearch"
                                     ServiceMethod="AutoSearchJobStation" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>

                                </div>
                                <div class="col-md-6 hidden" id="AssetSearch">
                                    <asp:Label ID="Label5" runat="server" Text="Asset Search"></asp:Label>
                                    <asp:TextBox ID="txtAssetSearch" CssClass="form-control col-md-12 col-sm-12 col-xs-12" runat="server" placeholder="Search Asset"></asp:TextBox>
                                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtAssetSearch"
                                     ServiceMethod="AutoSearchAssetVehicle" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                                </div>
                            </div>
                            <div class="row" style="padding-top:10px;">                              
                                <div class="col-md-12 btn-toolbar hidden" id="btnshow">
                                    <asp:Button ID="btnShow" runat="server" class="btn btn-primary btn-md-6 form-control pull-right" Text="Show Service Cost" OnClientClick="return Validate();" OnClick="btnShow_Click" />
                                </div>
                                 <div class="col-md-12 btn-toolbar hidden" id="btnupdate">
                                    <asp:Button ID="btnUnitUpdate" runat="server" CssClass="btn btn-primary btn-md-6 form-control pull-right" Text="Update" OnClick="btnUnitUpdate_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-info" id="itemPanel">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Service Task" Font-Bold="true" Font-Size="16px"></asp:Label></div>
                        <div class="panel-body">
                            <asp:GridView ID="gvServiceCostUpdate" runat="server" CellPadding="4" ForeColor="#333333" GridLines="Both" AutoGenerateColumns="False" DataKeyNames="intID" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("strServiceName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control input-xs" Text='<%# Bind("monServiceCost","{0:n2}") %>'></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />

                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success btn-xs" Text="Update" OnClick="btnUpdate_Click"></asp:Button>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </form>
    <script>
        function showPanel() {
            var itemPanel = document.getElementById("itemPanel");
            itemPanel.classList.remove("hidden");
            return true;

           
        }
        function showPanelJoB() {
            var jobCardid = document.getElementById("jobCard");
            jobCard.classList.remove("hidden");

            var assetSearch = document.getElementById("AssetSearch");
            assetSearch.classList.add("hidden");

            var JobSearch = document.getElementById("JobSearch");
            JobSearch.classList.remove("hidden");

            var show = document.getElementById("btnshow");
            show.classList.remove("hidden");
            show.classList.remove("col-md-12");
            show.classList.add("col-md-6");

            var update = document.getElementById("btnupdate");
            update.classList.remove("hidden");
            update.classList.remove("col-md-12");
            update.classList.add("col-md-6");
            return true;
           
        }
        function showPanelAsset() {
            var jobCardid = document.getElementById("jobCard");
            jobCard.classList.add("hidden");

            var assetSearch = document.getElementById("AssetSearch");
            assetSearch.classList.remove("hidden");

            var JobSearch = document.getElementById("JobSearch");
            JobSearch.classList.remove("hidden");

            var show = document.getElementById("btnshow");
            show.classList.add("hidden");

            var update = document.getElementById("btnupdate");
            update.classList.remove("hidden");
            return true;
           
        }
        function hidePanel() {
            var itemPanel = document.getElementById("itemPanel");
            itemPanel.classList.add("hidden");

        }
        function Validate() {
            var jobCard = document.getElementById("txtJobCard").value;

            if (jobCard === null || jobCard === "") {
                alert("Job Card can not be empty");
                return false;
            }
            return true;
        }

    </script>
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

        #gridView tr {
            font-size: 10px;
        }
    </style>
</body>
</html>

