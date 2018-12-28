<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="UI.Personal.Default" CodeBehind="Default.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Welcome to Akij Group</title>
    <asp:PlaceHolder ID="PlaceHolder0" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference0" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/hrCSS" />
    <%--hidden visible--%>
    <style>
        .HyperLinkButtonStyle {
            float: left;
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
            width: 5%;
            height: 5%;
            margin-left: auto;
            margin-right: auto;
            padding: 15px;
            overflow-y: scroll;
        }
    </style>

    <script>
        function OpenhdnDivision() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }
        function ClosehdnDivision(sts) {
            if (sts == '1') { $("#hdnDivision").fadeOut("slow"); }
            else { alert(sts); $("#hdnDivision").fadeOut("slow"); }
        }
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }
        function ViewDocument(enroll, vwtype) { window.open('DocView.aspx?EN=' + enroll + '&TP=' + vwtype, 'sub', "height=550, width=850, scrollbars=yes, left=300, top=250, resizable=yes, title=Preview"); }
        function ViewPolicy(id, filepath) { window.open('DocPView.aspx?ID=' + id + '&FP=' + filepath, 'sub', "height=550, width=850, scrollbars=yes, left=300, top=250, resizable=yes, title=Preview"); }
        function ViewOthers(url) {
            window.open(url, '', "scrollbars=yes,toolbar=0,height=550,width=500,top=200,left=300, resizable=yes, title=Preview");
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" LoadScriptsBeforeUI="false"></asp:ScriptManager>
        <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
            <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                </marquee>
            </div>
            <%--<div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;"></div>--%>
        </asp:Panel>
        <div style="height: 30px;"></div>
        <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
        </cc1:AlwaysVisibleControlExtender>

        <%--=========================================Start My Code From Here===============================================--%>
        <div class="divs_content_container" style="background: none; border: 0px solid red;">
            <table border="0" style="width: Auto;">
                <tr>
                    <td>
                        <asp:Panel ID="pnlpersonalinformation" runat="server"><%# strinformation %></asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblmsg" runat="server" Text="Policy Document:"></asp:Label><br />
                        <asp:GridView ID="dgvpolicy" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White">
                            <Columns>
                                <asp:TemplateField HeaderText="SL.">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="strPolicyName" HeaderText="Policy Name" ItemStyle-HorizontalAlign="Center" SortExpression="strPolicyName">
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="strDepartment" HeaderText="Department" ItemStyle-HorizontalAlign="Center" SortExpression="strDepartment">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="strVersion" HeaderText="Version" ItemStyle-HorizontalAlign="Center" SortExpression="strVersion">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Document">
                                    <ItemTemplate>
                                        <input id="btnPView" type="button" class="HyperLinkButtonStyle" style="cursor: pointer; font-size: 10px;" value='<%# Eval("strFtpFilePath") %>' onclick="<%# ViewPolicy(Eval("Rowid"), Eval("strFtpFilePath")) %>" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td>
                        <br />
                        <asp:Label ID="lblper" runat="server" Text="Personal Document :"></asp:Label><br />
                        <asp:GridView ID="dgvdoc" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White">
                            <Columns>
                                <asp:TemplateField HeaderText="SL.">
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document Type">
                                    <ItemTemplate>
                                        <input id="btnView" type="button" class="HyperLinkButtonStyle" style="cursor: pointer; font-size: 10px;" value='<%# Eval("DocumentType") %>' onclick="<%# ViewDocument(Eval("Enroll"), Eval("DocumentType")) %>" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="250px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NoOfPage" HeaderText="No Of Pages" ItemStyle-HorizontalAlign="Center" SortExpression="NoOfPage">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Status">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td><a class="nextclick" onclick="OpenhdnDivision()">Upload</a></td>
                </tr>
            </table>
        </div>

        <div id="hdnDivision" class="hdnDivision" style="width: auto;">
            <table style="width: auto; float: left;">
                <tr class="tblrowodd">
                    <td style="text-align: right;">
                        <asp:Label ID="lblitem" runat="server" Text="Type List : "></asp:Label></td>
                    <td style="text-align: left;">
                        <asp:DropDownList ID="ddlist" runat="server" CssClass="dropdownList" DataSourceID="odsdoctplst" DataTextField="DocumentType" DataValueField="Enroll"></asp:DropDownList>
                        <asp:ObjectDataSource ID="odsdoctplst" runat="server" SelectMethod="GetDocumentList" TypeName="HR_BLL.Global.ApplicationType"></asp:ObjectDataSource>
                    </td>
                    <td style="text-align: right;">
                        <asp:Label ID="lbldoc" CssClass="lbl" runat="server" Text="Document : "></asp:Label></td>
                    <td>
                        <asp:FileUpload ID="docUpload" runat="server" CssClass="txtBox" /><asp:HiddenField ID="hdnField" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4"><a class="nextclick" onclick="ClosehdnDivision(1)">Cancel</a><a class="nextclick" onclick="Save()">Save</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>