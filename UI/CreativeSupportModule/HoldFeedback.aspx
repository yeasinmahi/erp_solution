<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoldFeedback.aspx.cs" Inherits="UI.CreativeSupportModule.HoldFeedback" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. HOLD & FEEDBACK </title>
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

    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }

        function FTPUpload1() {
            document.getElementById("hdnconfirm").value = "0";
            var confirmValue = document.createElement("INPUT");
            confirmValue.type = "hidden";
            confirmValue.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirmValue.value = "Yes";
                document.getElementById("hdnconfirm").value = "3";
            } else {
                confirmValue.value = "No";
                document.getElementById("hdnconfirm").value = "0";
            }
            //__doPostBack();
        }

        function CloseWindow() {
            window.close();
        }
    </script>

    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
            }
        }
        window.onbeforeunload = RefreshParent;
    </script>

</head>
<body>
    <form id="frmBillRegistration" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>

                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnJobID" runat="server" />
                <asp:HiddenField ID="hdnJobStatusID" runat="server" />
                <div style="padding-right: 10px;">
                    <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
                    <table class="tbldecoration" style="width: auto; float: left; padding-bottom: 15px;">
                        <tr>
                            <td colspan="5">
                                <img src="img/Banner.png" width="950px" height="120px" /></td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: center; padding-top: 40px;"><span style="font-size: 20px; text-align: center; font-weight: bold;">Hold & Feedback Form </span></div>
                <div class="divbody" style="margin-left: 150px; margin-top: 20px; padding-left: 15px;">

                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right; padding-top: 10px">
                                <asp:Label ID="lblJobDesc" runat="server" CssClass="lbl" Text="Status :"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtStatus" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" Text="Job Code :" CssClass="lbl"></asp:Label></td>
                            <td style="padding-right: 10px">
                                <asp:TextBox ID="txtJobCode" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="Sender :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSender" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Receiver :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtReceiver" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" Text="Job Description :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtJobDescription" runat="server" CssClass="txtBox1" Enabled="false" BackColor="WhiteSmoke"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" Text="Attachment :" CssClass="lbl"></asp:Label></td>
                            <td colspan="5" style="text-align: left;">
                                <asp:FileUpload ID="txtWorkOrderUpload" runat="server" AllowMultiple="true" Height="25px" Width="130px" />
                                <span style="padding-left: 18px">
                                    <asp:Button ID="btnDocUpload" runat="server" class="myButton" Text="Add" Height="30px" OnClientClick="FTPUpload()" /></span>
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
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="File Name" SortExpression="strFileName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="440px" />
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>



                        <tr>
                            <td style="text-align: right; padding-top: 12px; padding-left: 27px; position: absolute;">
                                <asp:Label ID="Label9" runat="server" Text="Remarks" CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td colspan="5" style="padding-top: 10px; padding-right: 10px">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Width="520px" Height="100px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: right; padding: 15px 10px 8px 10px">
                                <span>
                                    <asp:Button ID="btnClose" runat="server" class="myButton" Text="Close" Height="30px" OnClick="btnClose_Click" /></span>
                                <span style="padding-left: 50px">
                                    <asp:Button ID="btnClear" runat="server" class="myButton" Text="Clear" Height="30px" OnClick="btnClear_Click" /></span>
                                <span style="padding-left: 50px">
                                    <asp:Button ID="btnSend" runat="server" class="myButton" Text="Send" Height="30px" OnClientClick="FTPUpload1()" /></span></td>
                        </tr>

                    </table>
                </div>

                <div>
                    <img style="padding-top: 90px" height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" />
                </div>


                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
