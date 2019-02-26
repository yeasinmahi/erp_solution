<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierEnlistment.aspx.cs" Inherits="UI.Inventory.SupplierEnlistment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <%-- <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>--%>
    <link href="../Content/CSS/Suppliercss.css" rel="stylesheet" />
    <script src="../Content/JS/JQUERY/SuppluChain&Others.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function FTPUpload1() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnconfirm").value = "3";
            }
            else {
                confirm_value.value = "No";
                document.getElementById("hdnconfirm").value = "0";
            }
            __doPostBack();
        }
    </script>
    <script> function CloseWindow() {
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
    <form id="frmauditdeptrealize" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%" Height="63px">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                    <%--<div id="divControl" class="divPopUp2" style="width: 100%; height: 20px; float: right;">&nbsp;</div>--%>
                </asp:Panel>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <br />
                <br />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <div class="divs_content_container" style="width: 630px; float: left;">
                    <br />
                    <asp:HiddenField ID="hdnconfirm" runat="server" />
                    <asp:HiddenField ID="hdnUnit" runat="server" />
                    <br />
                    <h1 class="auto-style30">New Supplier Enlistment</h1>
                    <fieldset class="row2">
                        <legend style="color: #3399FF; font-size: 10px;">
                            <span class="auto-style20">Details</span>
                        </legend>
                        <table style="height: auto">
                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblSupname" runat="server" CssClass="lbl" Text="Supplier Name :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtSuppliername" runat="server" CssClass="txtBox" Width="190px" BackColor="white" AutoPostBack="true" OnTextChanged="txtSuppliername_TextChanged" BorderColor="Gray" BorderStyle="Ridge"></asp:TextBox>
                                    <span style="color: red; font-size: 16px">*</span>
                                </td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Org. Contact :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Address :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox>
                                    <span style="color: red; font-size: 16px">*</span>
                                </td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Fax No :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFax" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Email :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtemail" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray" ForeColor="Blue"></asp:TextBox></td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="BIN :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtBin" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Vat Reg. :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtVatReg" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="TIN :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtTin" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Trade License :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtTradeLicn" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>

                                <td style="text-align: right;">
                                    <asp:Label ID="lblCategory" runat="server" CssClass="lbl" Text="Business Type :"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style1">
                                    <asp:DropDownList ID="ddlBussType" CssClass="ddList" Font-Bold="False" BackColor="Lightgray" BorderColor="Gray" runat="server" Width="195px" ForeColor="Black">
                                        <asp:ListItem>Proprietorship</asp:ListItem>
                                        <asp:ListItem>Partnership</asp:ListItem>
                                        <asp:ListItem>Company</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label12" runat="server" CssClass="lbl" Text="Contact Person :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtContactP" runat="server" CssClass="txtBox" Width="190px" BackColor="white" BorderColor="Gray"></asp:TextBox></td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Service Type :"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style1">
                                    <asp:DropDownList ID="ddlservice" CssClass="ddList" Font-Bold="False" BackColor="Lightgray" BorderColor="Gray" runat="server" Width="195px" ForeColor="Black">
                                        <asp:ListItem>Agent</asp:ListItem>
                                        <asp:ListItem>Dealer</asp:ListItem>
                                        <asp:ListItem>Retailer</asp:ListItem>
                                        <asp:ListItem>OEM</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label13" runat="server" CssClass="lbl" Text="Phone No :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="txtBox" Width="190px" BackColor="white" onkeypress="javascript:return isNumber (event)" BorderColor="Gray"></asp:TextBox>
                                    <span style="color: red; font-size: 16px">*</span>
                                </td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Supplier Type :"></asp:Label></td>
                                <td style="text-align: left;" class="auto-style1">
                                    <asp:DropDownList ID="ddlSupplierType" CssClass="ddList" Font-Bold="False" BackColor="Lightgray" BorderColor="Gray" runat="server" Width="195px" ForeColor="Black" OnSelectedIndexChanged="ddlSupplierType_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="1">Local Purchase</asp:ListItem>
                                        <asp:ListItem Value="2">Local Fabrication</asp:ListItem>
                                        <asp:ListItem Value="3">Foreign Purchase</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Short Name :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtShortName" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Width="190px" Enabled="false"></asp:TextBox>

                                </td>

                                <td style="text-align: right;">
                                    <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Enlishment Date :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtEnlishmentDate" runat="server" BackColor="white" BorderColor="Gray"
                                        CssClass="txtBox" Font-Bold="True" ForeColor="#006600" Style="text-align: center" Width="190px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSubmitForeign" runat="server" ForeColor="Blue" Height="25px" OnClick="submit_ClickForeign" OnClientClick="ValidationBasicInfo()" Style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="105px" />
                                </td>

                                <td></td>
                                <td style="font-weight: 700; font-size: x-small">
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtEnlishmentDate">
                                    </cc1:CalendarExtender>
                                    <asp:CheckBox ID="chkBox1" AutoPostBack="true" runat="server" Visible="false" Text="Temporary Supplier" OnCheckedChanged="chkBox1_CheckedChanged" Style="color: #3333FF" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <br />
                    <fieldset class="row2">
                        <legend id="legend1" style="font-size: 10pt; color: #3399FF;"><span class="auto-style20">Other Information</span> </legend>

                        <%--<div id="Divinfo" runat="server">           --%>

                        <table>

                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="lblpayto" runat="server" CssClass="lbl" Text="Pay To Name :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtPayTo" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" Width="190px"></asp:TextBox>
                                    <span style="color: red; font-size: 16px">*</span>
                                </td>

                                <td style="text-align: right;">
                                    <asp:Label ID="lblrouting" runat="server" CssClass="lbl" Text="Routing :"></asp:Label></td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtRouting" runat="server" BackColor="Lightyellow" BorderColor="Gray" CssClass="txtBox" onkeypress="return RoutingNoCheck();" ForeColor="#990000" Style="text-align: center" Width="120px"></asp:TextBox>
                                    <span style="color: red; font-size: 16px">*</span>
                                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" Style="font-weight: 700; color: #0000FF" Text="Check" /></td>
                                <tr>

                                    <td style="text-align: right;">
                                        <asp:Label ID="lblAcNo" runat="server" CssClass="lbl" Text="A C Number :"></asp:Label></td>
                                    <%--<td  style="text-align:left;"><asp:TextBox ID="txtACNo" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" onchange="javascript: Changed(this.value);" onkeypress="javascript:return isNumber (event)" Width="190px"></asp:TextBox></td>--%>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtACNo" runat="server" BackColor="white" BorderColor="Gray" CssClass="txtBox" onkeypress="return ACNoCheck();" Width="190px"></asp:TextBox>
                                        <span style="color: red; font-size: 16px">*</span>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="lblbank" runat="server" CssClass="lbl" Text="Bank :"></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtBank" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Width="190px" ForeColor="#0066FF" Enabled="false"></asp:TextBox></td>
                                </tr>

                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblbankid" runat="server" CssClass="lbl" Text="Bank ID :"></asp:Label>
                                    </td>

                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtBankId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                    </td>

                                    <td style="text-align: right;">
                                        <asp:Label ID="lblbranch" runat="server" CssClass="lbl" Text="Branch :"></asp:Label></td>
                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtBranch" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lbldistrictid" runat="server" CssClass="lbl" Text="District ID :"></asp:Label>
                                    </td>

                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtDistrictId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                    </td>

                                    <td style="text-align: right; width: auto;">
                                        <asp:Label ID="lblbranchid" runat="server" CssClass="lbl" Text="Branch ID :"></asp:Label>
                                    </td>

                                    <td style="text-align: left;">
                                        <asp:TextBox ID="txtBranchId" runat="server" BackColor="Lightgray" BorderColor="Gray" CssClass="txtBox" Enabled="false" ForeColor="#0066FF" Width="190px"></asp:TextBox>
                                    </td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hid" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnTempory" runat="server" ForeColor="Blue" Height="30px" Visible="false" OnClick="btnTempory_Click" Style="text-align: center" Text="Insert Temporary" Width="140px" />
                                    </td>
                                    <td>

                                        <asp:Button ID="Button3" Visible="false" runat="server" ForeColor="Blue" Height="30px" OnClick="submitTempory_Click" OnClientClick="ValidationBasicInfo()" Style="text-align: center; background-color: #8CD7FB;" Text="SubmitSecondtermp" Width="110px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEdit0" runat="server" ForeColor="Blue" Height="29px" OnClick="submit_ClickforignDump" Visible="false" Style="text-align: center" Text="Insert Master (Foreign)" Width="135px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style25">
                                        <td>
                                            <%--<asp:Button ID="Button1" runat="server" ForeColor="Blue" Height="30px" OnClick="submit_Click" OnClientClick="ValidationBasicInfo()" style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="130px" />--%>
                                            <asp:Button ID="Button1" runat="server" ForeColor="Blue" Height="30px" OnClientClick="FTPUpload1()" Style="text-align: center; background-color: #8CD7FB;" Text="Submit" Width="130px" OnClick="Button1_Click" />
                                        </td>
                                        <td class="auto-style6">
                                            <asp:Button ID="btnApprove" runat="server" ForeColor="Blue" Height="28px" OnClick="btnEdit_Click" Style="text-align: center" Text="Approve" Visible="false" Width="110px" />
                                            &nbsp;</td>
                                    </td>
                                    <td class="auto-style6">
                                        <asp:Button ID="btnEdit" runat="server" ForeColor="Blue" Height="30px" OnClientClick="ValidationBasicInfo()" OnClick="btnEdit_Click" Visible="false" Style="text-align: center" Text="Insert Master (Local)" Width="140px" />
                                    </td>
                                </tr>

                                <tr class="tblrowodd">

                                    <td style="text-align: right;">
                                        <asp:Label ID="lblReport" runat="server" CssClass="lbl" Text="Report:"></asp:Label></td>
                                    <td>
                                        <asp:DropDownList ID="ddlDocType" runat="server" CssClass="ddList" Font-Bold="false" AutoPostBack="false">
                                            <asp:ListItem Selected="True" Value="1">Cheque-Statement</asp:ListItem>
                                            <asp:ListItem Value="2">Trade License</asp:ListItem>
                                            <asp:ListItem Value="3">VAT Registration</asp:ListItem>
                                            <asp:ListItem Value="4">TIN</asp:ListItem>
                                            <asp:ListItem Value="5">BIN</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <td style='text-align: right; width: 120px;'>Document Upload : </td>
                                    <td style='text-align: center;'>
                                        <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true" />
                                    </td>
                                    <td style="text-align: right;">
                                        <a class="nextclick" onclick="FTPUpload()">Add</a> </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                            BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" OnRowDeleting="dgvDocUp_RowDeleting1">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL No.">
                                                    <ItemStyle HorizontalAlign="center" Width="15px" />
                                                    <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="File Name" SortExpression="strFileName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="530px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
                                            </Columns>
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                    </fieldset>
                </div>

                <div class="leaveSummary_container" style="width: 364px; height: 396px; margin-right: 10px">
                    <%--//<h1 class="auto-style29">&nbsp;</h1>--%>
                    <h1 class="auto-style29"></h1>
                    <h1 class="auto-style29">Requested Suppliers Status</h1>
                    <asp:GridView ID="dgvlist" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" DataSourceID="odsqwnreq" Font-Size="Smaller" PageSize="15" Style="font-size: xx-small; margin-left: 0px;" CellSpacing="2" ForeColor="Black" Width="400px">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="strSuppMasterName" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Supplier Name" ItemStyle-HorizontalAlign="Center" SortExpression="strSuppMasterName">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="strOrgAddress" HeaderText="Address" ItemStyle-HorizontalAlign="Center" SortExpression="strOrgAddress">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dteLastActionTime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="Request Date" ItemStyle-HorizontalAlign="Center" SortExpression="dteLastActionTime">
                                <ItemStyle HorizontalAlign="Left" Width="65px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign="Center" SortExpression="Status">
                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                    <asp:ObjectDataSource ID="odsqwnreq" runat="server" SelectMethod="EnrollWiseSupplier" TypeName="Purchase_BLL.SupplyChain.CSM">
                        <SelectParameters>
                            <asp:SessionParameter Name="intRequestBy" SessionField="sesUserID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
