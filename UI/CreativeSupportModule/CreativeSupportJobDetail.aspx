<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreativeSupportJobDetail.aspx.cs" Inherits="UI.CreativeSupportModule.CreativeSupportJobDetail" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. CUSTOMERS VIEW </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script language="javascript">        

        function ViewDocument(Id) {
            window.open('DocView.aspx?ID=' + Id, 'sub', "height=650, width=970, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>
</head>
<body>
    <form id="frmBillRegistration" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
        --%>
        <%--=========================================Start My Code From Here===============================================--%>

        <div style="padding-right: 10px;">
            <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
            <table class="tbldecoration" style="width: auto; float: left;">
                <tr>
                    <td colspan="5">
                        <img src="img/Banner.png" width="950px" height="120px" /></td>
                </tr>

            </table>
        </div>

        <div class="divbody" style="margin-left: 135px; margin-top: 20px; padding-left: 15px;">
            <table class="tbldecoration" style="width: auto; float: left;">
                <tr>
                    <td style="text-align: right; padding-top: 10px;">
                        <asp:Label ID="lblEName" runat="server" Text="Assign By :" CssClass="lbl"></asp:Label></td>
                    <td colspan="5" style="padding-top: 10px;">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke" Width="547px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-top: 10px">
                        <asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Required Date :"></asp:Label></td>
                    <td style="padding-top: 10px">
                        <asp:TextBox ID="txtRequiredDate" runat="server" CssClass="txtBox1" Width="120px" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox>
                        <span style="padding-left: 20px;">
                            <asp:Label ID="lblstart" runat="server" CssClass="lbl" Text="Required Time :"></asp:Label>
                            <asp:TextBox ID="txtRequiredTime" runat="server" CssClass="txtBox1" Width="110px" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></span>
                    </td>

                    <td style="text-align: right; padding-top: 10px; padding-left: 20px">
                        <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="PO ID :"></asp:Label></td>
                    <td colspan="5" style="text-align: left; padding-top: 10px">
                        <asp:TextBox ID="txtPOID" runat="server" CssClass="txtBox1" Width="110px" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>

                </tr>
                <tr style="text-align: center;">
                    <td style="text-align: right; padding-top: 10px">
                        <asp:Label ID="Label14" runat="server" Text="Special Assign To :" CssClass="lbl"></asp:Label></td>
                    <td colspan="5" style="text-align: left; padding-top: 10px">
                        <asp:TextBox ID="txtSpecialAssignTo" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke" Width="547px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right; padding-top: 10px">
                        <asp:Label ID="lblJobDesc" runat="server" CssClass="lbl" Text="Job Description :"></asp:Label></td>
                    <td colspan="4" style="text-align: left; padding-top: 10px">
                        <asp:TextBox ID="txtJobDesc" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox>
                        <span style="padding-left: 43px">
                            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Job Type :"></asp:Label>
                            <span style="border-left-style: groove; border-left-width: 0.1px; border-color: gainsboro; padding: 10px 10px 10px 5px">
                                <asp:RadioButton ID="rdoLarge" runat="server" Checked="true" Text=" Large" /></span>
                            <span style="border-left-style: groove; border-left-width: 0.1px; border-color: gainsboro; padding: 10px 10px 10px 5px">
                                <asp:RadioButton ID="rdoModerate" runat="server" Text=" Moderate" /></span>
                            <span style="border-left-style: groove; border-left-width: 0.1px; border-color: gainsboro; padding: 10px 10px 10px 5px">
                                <asp:RadioButton ID="rdoMinor" runat="server" Text=" Minor" /></span></span>
                    </td>
                </tr>

                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                    <td colspan="5">
                        <asp:GridView ID="dgvCrItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" RowStyle-Height="16px"
                            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="center" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvCrItem_RowDataBound">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="40px" />
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item Name" SortExpression="strCreativeItemName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strCreativeItemName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="322px" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Quantity" SortExpression="intQty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("intQty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="85px" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" /></FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Point" SortExpression="intPoint">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPoint" runat="server" Text='<%# Bind("intPoint") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" Width="85px" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblPointTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalpoint %>" /></FooterTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                    <td colspan="5">
                        <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvDocUp_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="40px" />
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="File Name" SortExpression="strFilePath">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFilePath") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="View"
                                            Text="View" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Download" ItemStyle-HorizontalAlign="Center" SortExpression="">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDownload" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Download"
                                            Text="Download" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
                
                <tr>
                    <td style="text-align: right; padding-top: 10px">
                        <asp:Label ID="Label9" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
                    <td colspan="5" style="padding-top: 10px">
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Width="547px" Height="50px" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td colspan="5">
                        <asp:GridView ID="gvStatusDetails" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Width ="100%"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvStatusDetails_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="SL No.">
                                    <ItemStyle HorizontalAlign="center" Width="40px" />
                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action By">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("strStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status Remarks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusRemarks" runat="server" Text='<%# Bind("strStatusRemarks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action Date and Time">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateTime" runat="server" Text='<%# Bind("dteInsertDateTime") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="File Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocFileName" runat="server" Text='<%# Bind("strFilePath") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="330px" />
                                </asp:TemplateField>

                                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate >
                                        <asp:Button ID="btnDownloadAll" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="DownloadAll"
                                            Text="Download All" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDownload" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="Download"
                                            Text="Download" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>

        <div>
            <img style="padding-top: 195px" height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" />
        </div>


        <%--=========================================End My Code From Here=================================================--%>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
