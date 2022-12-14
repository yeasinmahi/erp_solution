<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerView.aspx.cs" Inherits="UI.CreativeSupportModule.CustomerView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
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


    <style type="text/css">
        .rounds {
            height: 500px;
            width: 60px;
            -moz-border-colors: 25px;
            -ms-border-radius: 25px;
            border-radius: 25px;
        }

        .hdnDivision {
            background-color: #ffffff;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 50%;
            height: 100%;
            margin-left: 5px;
            margin-top: 120px;
            margin-right: 50px;
            padding: 15px;
        }
    </style>

    <script>
        function FTPUpload() {
            document.getElementById("hdnconfirm").value = "2";
            __doPostBack();
        }
        function FTPUpload2() {
            document.getElementById("hdnconfirm").value = "4";
           __doPostBack();
        }
        function FTPUpload1() {
            document.getElementById("hdnconfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) { confirm_value.value = "Yes"; document.getElementById("hdnconfirm").value = "3"; }
            else { confirm_value.value = "No"; document.getElementById("hdnconfirm").value = "0"; }
            __doPostBack();
        }

        function CloseWindow() {
            window.close();
        }
    </script>

    <script language="javascript" type="text/javascript">  


        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function ViewCustomerView(Id) {
            window.open('CustomerView.aspx?ID=' + Id, 'sub', "height=650, width=970, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
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
                <asp:HiddenField ID="hdnLoanID" runat="server" />
                <asp:HiddenField ID="hdnPoint" runat="server" />
                <div style="padding-right: 10px;">
                    <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> BILL REGISTRATION<hr /></div>--%>
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td colspan="5">
                                <img src="img/Banner.png" width="950px" height="120px" />
                            </td>
                        </tr>

                    </table>
                </div>

                <div class="divbody" style="margin-left: 110px; margin-top: 20px; padding-left: 15px;">
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right; padding-top: 10px;">
                                <asp:Label ID="lblEName" runat="server" Text="Assign By :" CssClass="lbl"></asp:Label></td>
                            <td colspan="5" style="padding-top: 10px;">
                                <asp:TextBox ID="txtName" runat="server" CssClass="txtBox1" Enabled="true" BackColor="WhiteSmoke" Width="547px" TabIndex="1"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" TargetControlID="txtName"
                                    ServiceMethod="GetEmpListForCreativeSupportList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-top: 10px">
                                <asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="Required Date"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td style="padding-top: 10px">
                                <asp:TextBox ID="txtReqDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" autocomplete="off" TabIndex="2"></asp:TextBox>
                                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtReqDate"></cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                            <td style="text-align: right; padding-left: 55px">
                                <asp:Label ID="lblstart" runat="server" CssClass="lbl" Text="Required Time :"></asp:Label></td>
                            <td><%--<MKB:TimeSelector ID="tmsReqTime" runat="server" SelectedTimeFormat="TwentyFour"></MKB:TimeSelector>--%>
                                <cc1:TimeSelector ID="tmsReqTime" runat="server" AllowSecondEditing="true"></cc1:TimeSelector>
                            </td>

                        </tr>
                        <tr style="text-align: center;">
                            <td style="text-align: right; padding-top: 10px">
                                <asp:Label ID="Label14" runat="server" Text="Special Assign To :" CssClass="lbl"></asp:Label></td>
                            <td colspan="5" style="text-align: left; padding-top: 10px">
                                <asp:TextBox ID="txtSearchAssignedTo" runat="server" AutoPostBack="false" CssClass="txtBox1" Width="547px" TabIndex="3"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSearchAssignedTo"
                                    ServiceMethod="GetEmpListForCreativeSupportList" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-top: 10px">
                                <asp:Label ID="lblJobDesc" runat="server" CssClass="lbl" Text="Job Description"></asp:Label>
                                <span style="color: red; font-size: 14px;">*</span>
                                <span>:</span>
                            </td>
                            <td style="text-align: left; padding-top: 10px">
                                <asp:DropDownList ID="ddlJobDescription" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="23px" DataSourceID="odsJobDes" DataTextField="strJobDescription" DataValueField="intJobDesID" AutoPostBack="true" OnSelectedIndexChanged="ddlJobDescription_SelectedIndexChanged" TabIndex="4"></asp:DropDownList>
                                <asp:ObjectDataSource ID="odsJobDes" runat="server" SelectMethod="GetJobDescription" TypeName="HR_BLL.CreativeSupport.CreativeSBll"></asp:ObjectDataSource>
                            </td>

                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                            <td colspan="3" style="padding-top: 10px; padding-left: 15px" id="jobTypeTd" runat="server">
                                <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Job Type"></asp:Label>
                                <span style="color: red; font-size: 14px;">*</span>
                                <span>:</span>
                                <asp:DropDownList ID="ddlJobType" CssClass="ddList" Font-Bold="False" runat="server" Width="200px" Height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlJobType_SelectedIndexChanged" TabIndex="5">
                                    <asp:ListItem Selected="True" Value="0">Please Select Job Type</asp:ListItem>
                                    <asp:ListItem Value="1">Large</asp:ListItem>
                                    <asp:ListItem Value="2">Moderate</asp:ListItem>
                                    <asp:ListItem Value="3">Minor</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-top: 10px" id="itemTd" runat="server">
                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Item"></asp:Label>
                                <span style="color: red; font-size: 14px;">*</span>
                                <span>:</span>
                            </td>
                            <td colspan="5" style="text-align: left; padding-top: 10px">
                                <asp:TextBox ID="txtCRItem" runat="server" AutoPostBack="false" CssClass="txtBox1" Width="547px" TabIndex="6"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCRItem"
                                    ServiceMethod="AutoCreativeItem" MinimumPrefixLength="1" CompletionSetCount="1"
                                    CompletionInterval="1" FirstRowSelected="true" EnableCaching="false" CompletionListCssClass="autocomplete_completionListElementBig"
                                    CompletionListItemCssClass="autocomplete_listItem" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                                </cc1:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-top: 10px" id="quantityTd" runat="server">
                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Quantity"></asp:Label>
                                <span style="color: red; font-size: 14px;">*</span>
                                <span>:</span>
                            </td>
                            <td colspan="4" style="text-align: left; padding-top: 10px">
                                <asp:TextBox ID="txtQty" CssClass="txtBox1" runat="server" Width="150px" AutoPostBack="false"  onblur="javascript:FTPUpload2();" TabIndex="7"></asp:TextBox>
                                <span style="padding-left: 50px">
                                    <asp:Label ID="Label7" runat="server" Text="Point :" CssClass="lbl"></asp:Label>
                                    <asp:TextBox ID="txtPoint" runat="server" CssClass="txtBox1" Width="150px" Enabled="false" BackColor="WhiteSmoke" TabIndex="8"></asp:TextBox></span>
                            </td>


                            <td style="text-align: right; padding: 15px 17px 8px 10px">
                                <asp:Button ID="btnItemAdd" runat="server" class="myButton" Text="Add" Height="30px" OnClick="btnItemAdd_Click" TabIndex="9" /></td>
                        </tr>
                        <tr>
                            <%--<td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>--%>
                            <td colspan="6">
                                <asp:GridView ID="dgvCrItem" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Width="100%"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" RowStyle-Height="16px"
                                    HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                                    FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="center" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvCrItem_RowDataBound" OnRowDeleting="dgvCrItem_RowDeleting">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL No.">
                                            <ItemStyle HorizontalAlign="center" Width="40px" />
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Item Name" SortExpression="name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            <FooterTemplate>
                                                <asp:Label ID="lblT" runat="server" Text="Total" />
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" SortExpression="qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center"/>
                                            <FooterTemplate>
                                                <asp:Label ID="lblQtyTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalqty %>" />
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Point" SortExpression="point">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoint" runat="server" Text='<%# Bind("point") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center"/>
                                            <FooterTemplate>
                                                <asp:Label ID="lblPointTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalpoint %>" />
                                            </FooterTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ItemID" SortExpression="itemid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemID" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="center" />
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red"  HeaderText="Action" ControlStyle-Font-Bold="true" >
                                            <ItemStyle Width="20px"></ItemStyle>
                                        </asp:CommandField>

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
                            <td style="text-align: right; width: 120px;">
                                <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="PO ID"></asp:Label>
                                <span id="poidTd" runat="server">
                                    <span style="color: red; font-size: 14px;">*</span>
                                    <span>:</span>
                                </span>
                            </td>
                            <td colspan="2" style="text-align: left;">
                                <asp:TextBox ID="txtPOID" runat="server" CssClass="txtBox1" Width="100px" TabIndex="10"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Work Order/ Attachment" Width="100px"></asp:Label>
                                <span id="WorkOrderTd" runat="server">
                                    <span style="color: red; font-size: 14px;">*</span>
                                    <span>:</span>
                                </span>
                            </td>
                            <%--<td style="text-align: right; width: 120px;">
                                <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="Work Order/ Attachment" Width="73px"></asp:Label>
                                <div id="WorkOrderTd" runat="server">
                                    <span style="color: red; font-size: 14px;">*</span>
                                    <span>:</span>
                                </div>
                              </td>--%>
                            <td colspan="2" style="text-align: right; width: 120px;">
                                <asp:FileUpload ID="txtDocUpload" runat="server" AllowMultiple="true" Height="25px" Width="217px" TabIndex="11" />
                            </td>
                            <td   style="padding-left: 22px">
                                <asp:Button ID="btnDocUpload" runat="server" class="myButton" Text="Add" Height="30px" OnClientClick="FTPUpload()" TabIndex="12" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:GridView ID="dgvDocUp" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8" Width="100%"
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
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:CommandField ShowDeleteButton="true" HeaderText="Action" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true">
                                        <ItemStyle Width="20px"></ItemStyle>
                                        </asp:CommandField>
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
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Width="547px" Height="50px" TabIndex="13"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: right; padding: 15px 15px 8px 10px">
                                <span>
                                    <asp:Button ID="btnClose" runat="server" class="myButton" Text="Close" Height="30px" OnClick="btnClose_Click" TabIndex="14" /></span>
                                <span style="padding-left: 50px">
                                    <asp:Button ID="btnClear" runat="server" class="myButton" Text="Clear" Height="30px" OnClick="btnClear_Click" TabIndex="15" /></span>
                                <span style="padding-left: 50px;">
                                    <asp:Button ID="btnSubmit" runat="server" class="myButton" Text="Submit" Height="30px" OnClientClick="FTPUpload1()" TabIndex="16" /></span></td>
                        </tr>
                    </table>
                </div>

                <div>
                    <img style="padding-top: 37px" height="40px" width="100%" src="img/20171103%20_%20CREATIVE%20SUPPORT%20UI%20DASHBOARD%20_%20FOOTER.png" />
                </div>


                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
