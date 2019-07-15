<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AfblDistManager.aspx.cs" Inherits="UI.SAD.Setup.AfblDistManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AFBL Distributor Manager</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />



</head>
<body>
    <form id="frmDistManager" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>

                <div class="divbody" style="padding-right: 10px;">
                    <div class="tabs_container" style="background-color: #dcdbdb; padding-top: 10px; padding-left: 5px; padding-right: -50px; border-radius: 5px;">
                        AFBL Distribution Manager<hr />
                    </div>
                    <table class="tblDistMang" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="text-align: right; width: 15px;">
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="5" style="text-align: right; padding: 0px 0px 0px 0px">&nbsp&nbsp
                                <asp:Button ID="btnShow" runat="server" class="myButtonNew" Text="Show Report" OnClick="btnShow_Click" />
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="divGrV" style="padding-right: 10px;">
                    <%-- <table>
                        <tr>
                            <td>--%>
                    <asp:GridView ID="gvDistribute" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true"
                        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White"
                        FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right"
                        OnRowUpdating="gvDistribute_RowUpdating"
                        ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>

                            <asp:TemplateField HeaderText=" Update ">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" Width="90px"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SL No.">
                                <ItemStyle HorizontalAlign="center" Width="60px" />
                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustId" Visible="false" runat="server" Text='<%# Bind("intCustID") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblParentId" runat="server" Text='<%# Bind("intParentID") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblLevelId" runat="server" Text='<%# Bind("intLevelID") %>' Width="40px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="40px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Customer Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CustName" runat="server" Text='<%# Bind("strCustName") %>' Width="350px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="350px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Customer Email">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_CustEmail" runat="server" Text='<%# Bind("strCustEmailAddress") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Enroll">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEnroll" Width="75px" runat="server" Text='<%# Bind("intEnroll") %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="75px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Employee Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("strDesignation") %>' Width="140px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Personal Phone No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersonalPhone" runat="server" Text='<%# Bind("strPersonalPhoneNo") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Office Phone No">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficePhone" runat="server" Text='<%# Bind("strOfficePhoneNo") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Office Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficeEmail" runat="server" Text='<%# Bind("strOfficeEmail") %>' Width="300px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("strDiscription") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Code">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" runat="server" Text='<%# Bind("strCode") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Line">
                                <ItemTemplate>
                                    <asp:Label ID="lblLine" runat="server" Text='<%# Bind("strLine") %>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Region">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%# Bind("strRegion") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Area">
                                <ItemTemplate>
                                    <asp:Label ID="lblArea" runat="server" Text='<%# Bind("strArea") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Territory">
                                <ItemTemplate>
                                    <asp:Label ID="lblTerritory" runat="server" Text='<%# Bind("strTerritory") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Distributor">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistributor" runat="server" Text='<%# Bind("strDistributor") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Section">
                                <ItemTemplate>
                                    <asp:Label ID="lblSection" runat="server" Text='<%# Bind("strSection") %>' Width="110px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="110px" />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenID" runat="server" Value='<%#Eval("intID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustName" runat="server" Text='<%# Bind("strCustName") %>' Width="300px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustEmail" runat="server" Text='<%# Bind("strCustEmailAddress") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="180px" />
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCEnroll" runat="server" Text='<%# Bind("intEnroll") %>' Width="80px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="80px" />
                            </asp:TemplateField>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblOfficePhoneNo" runat="server" Text='<%# Bind("strOfficePhoneNo") %>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="100px" />
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="#2eb8b8" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    <%--</td>
                        </tr>
                    </table>--%>
                </div>
                               
                <asp:UpdateProgress ID="updateProgress" runat="server">
                    <ProgressTemplate>
                        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                            <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../../Content/images/img/loading.gif" AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
