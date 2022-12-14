<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueItemByRequesitionDetalis.aspx.cs" Inherits="UI.SCM.IssueItemByRequesitionDetalis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">

    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />

    <script type="text/javascript">
        $("[id*=txtIssue]").live("change", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");
                    var IssueQty = parseFloat($(this).val())
                    var StockQty = parseFloat($("[id*=lblStock]", row).html());
                    var remain = parseFloat($("[id*=lblRemainIssue]", row).html());
                    var actual = parseFloat($("[id*=lblActual]", row).html());

                    if (actual >= IssueQty) {
                        if (remain >= IssueQty) {
                            if (StockQty >= IssueQty) {

                            }
                            else {
                                $("[id*=txtIssue]", row).val('0');
                                alert("Please Check Issue Quantity");
                            }
                        }
                        else {
                            $("[id*=txtIssue]", row).val('0');
                            alert("Please Check Issue Quantity");
                        }
                    }
                    else {
                        $("[id*=txtIssue]", row).val('0');
                        alert("Please Check Stock Quantity");
                    }

                }
            }


        });
        function CloseWindow() { window.close(); window.onbeforeunload = RefreshParent(); }
        //function RefreshParent() {
        //    if (window.opener != null && !window.opener.closed) {
        //        window.opener.location.reload();
        //    }
        //}
        
        function funConfirmAll() {
            
            if (confirm("Do you want to proceed?")) {
                showLoader();
                return true;
            } else {
                return false;
            }
        }
        $(document).ready(function () {

            GetCellValues();
        });
        function GetCellValues() {
            var table = document.getElementById('dgvDetalis');
            for (var r = 1, n = table.rows.length-1; r < n; r++) {
                if (parseInt(table.rows[r].cells[7].getElementsByTagName("span")[0].innerText) === 0) {
                    table.rows[r].style.backgroundColor = "#e0ffbf";
                } else {
                    table.rows[r].style.backgroundColor = "#fcfcf9";
                }
            }
        }

    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125570863-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());
        gtag('config', 'UA-125570863-1');
    </script>
    <style type="text/css">
        .rounds {
            height: 80px;
            width: 30px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }

        .HyperLinkButtonStyle {
            float: right;
            text-align: left;
            border: none;
            background: none;
            color: blue;
            text-decoration: underline;
            font: normal 10px verdana;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 100%;
            height: 100%;
            margin-left: 70px;
            margin-top: 100px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }
        th {
            font-size: 11px;
        }
    </style>
</head>

<body>

    <form id="frmselfresign" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%"> 
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 20px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <%--=========================================Start My Code From Here===============================================--%>

                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <asp:HiddenField ID="hdnIndentNo" runat="server" />
                    <asp:HiddenField ID="hdnIndentDate" runat="server" />
                    <asp:HiddenField ID="hdnDueDate" runat="server" />
                    <asp:HiddenField ID="hdnIndentType" runat="server" />
                    <asp:HiddenField ID="hdnEnroll" runat="server" />
                    <div class="tabs_container" style="text-align: left">Store Issue From<hr />
                    </div>

                    <table>

                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Cost Center"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:DropDownList ID="ddlCost" CssClass="ddList" AutoPostBack="false" Font-Bold="true" runat="server"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Receive By"></asp:Label></td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtReceiveBy" CssClass="txtBox" AutoPostBack="false"  runat="server"></asp:TextBox></td>
                            <td style="text-align: right">
                                <asp:Button ID="btnIssue" Style="border-radius: 1px; height: 29px" ForeColor="blue" runat="server" Text="Store Issue" OnClientClick='return funConfirmAll();' OnClick="btnIssue_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                        </tr>
                    </table>
                    <table style="width: 900px;">
                        <tr>
                            <td style="text-align: left;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Req Code:"></asp:Label>
                                <asp:Label ID="lblReqCode" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Req Date:"></asp:Label>
                                <asp:Label ID="lblReqDate" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Req By:"></asp:Label>
                                <asp:Label ID="lblReqBy" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="Req Dept:"></asp:Label>
                                <asp:Label ID="lblReqDept" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label8" CssClass="lbl" runat="server" Text="Section:"></asp:Label>
                                <asp:Label ID="lblSection" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Approved By:"></asp:Label>
                                <asp:Label ID="lblApproved" CssClass="lbl" runat="server" Font-Bold="true"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="dgvDetalis" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView_RowDataBound" ShowFooter="True" Width="900px"
                                    CssClass="GridViewStyle" CellPadding="4" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                                    <HeaderStyle CssClass="HeaderStyle" BackColor="#6B696B" Font-Bold="True" Font-Size="12px" ForeColor="White"  />
                                    <FooterStyle CssClass="FooterStyle" BackColor="#CCCC99" />
                                    <RowStyle CssClass="RowStyle" BackColor="#F7F7DE" />
                                    <PagerStyle CssClass="PagerStyle" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Id" SortExpression="intItemID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItem" runat="server"  Width="160px" Text='<%# Bind("strItem") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left"/>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Uom" ItemStyle-HorizontalAlign="right" SortExpression="strUoM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUom" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strUoM") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Req Qty" ItemStyle-HorizontalAlign="right" SortExpression="numReqQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReqQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numReqQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Issue Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIssueQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIssueQty" runat="server" Text='<%# Bind("numIssueQty") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Approve Qty" ItemStyle-HorizontalAlign="right" SortExpression="numApproveQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApprQty" runat="server" Text='<%# Bind("numApproveQty","{0:n2}") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remain Issue" ItemStyle-HorizontalAlign="right" SortExpression="numRemainToIssueQty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemainIssue" runat="server" Text='<%# Bind("numRemainToIssueQty") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Stock" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStock" runat="server" Text="0"></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Actual Stock" ItemStyle-HorizontalAlign="right" SortExpression="monStock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActual" runat="server" Text='<%# Bind("monStock") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Issue" ItemStyle-HorizontalAlign="right" SortExpression="monValue">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIssue" CssClass="txtBox" Width="60px" runat="server" Text="0"></asp:TextBox></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Store Location" ItemStyle-HorizontalAlign="right">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlStoreLocation" runat="server" AutoPostBack="true" CssClass="ddList" OnSelectedIndexChanged="ddlStoreLocation_SelectedIndexChanged"></asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Value" ItemStyle-HorizontalAlign="right" SortExpression="monValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblValue" runat="server" Text='<%# Bind("monValue") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Locations" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="strLocation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocationName" runat="server" Text='<%# Bind("strLocation") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="100px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strRemarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="left" Width="150px" />
                                        </asp:TemplateField>

                                    </Columns>
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                    <SortedAscendingHeaderStyle BackColor="#848384" />
                                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                    <SortedDescendingHeaderStyle BackColor="#575357" />
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
