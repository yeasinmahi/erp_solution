<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManagerStoreNew.aspx.cs" Inherits="UI.SCM.ItemManagerStoreNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>::. Item Manager [Procurement Part] </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode > 57))
                return false;
            return true;
        }
        function TotalLeadTime1() {
            var POTime = document.getElementById('txtPOTime').value;
            if (isNaN(POTime) == true) { POTime = 0; }
            var ShipmentTime = document.getElementById('txtDeliveryTime').value;
            if (isNaN(ShipmentTime) == true) { ShipmentTime = 0; }
            var ProcessTime = document.getElementById('txtProcessingTime').value;
            if (isNaN(ProcessTime) == true) { ProcessTime = 0; }
            var TotalTime = (POTime - ShipmentTime);
            document.getElementById('txtTotalLeadTime').value = TotalTime;
        }
        function TotalLeadTime() {
            var total = 0;
            if (document.getElementById('txtPOTime').value != '') {
                total += parseFloat(document.getElementById('txtPOTime').value);
            }
            if (document.getElementById('txtDeliveryTime').value != '') {
                total += parseFloat(document.getElementById('txtDeliveryTime').value);
            }
            if (document.getElementById('txtProcessingTime').value != '') {
                total += parseFloat(document.getElementById('txtProcessingTime').value);
            }
            document.getElementById('txtTotalLeadTime').value = total;
        }
        function CloseWindow() {
            window.close();
            window.opener.location.reload();
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
    <style>
        ::placeholder {
            color: red;
            opacity: 1; /* Firefox */
        }

        :-ms-input-placeholder { /* Internet Explorer 10-11 */
            color: red;
        }

        ::-ms-input-placeholder { /* Microsoft Edge */
            color: red;
        }
    </style>

    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="frmLoanApplication" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnWHID" runat="server" />
                <asp:HiddenField ID="hdnGroupID" runat="server" />
                <asp:HiddenField ID="hdnCategoryID" runat="server" />
                <asp:HiddenField ID="hdnItemID" runat="server" />

                <div class="leaveApplication_container">
                    <table class="tbldecoration" style="width: auto; float: left;">

                        <tr class="tblheader">
                            <td class="tdheader" colspan="4">ADD MASTER ITEM BY PURCHASE DEPT :</td>
                        </tr>
                        <tr class="tblheader">
                            <td style="height: 2px; background-color: #c1bdbd;" colspan="4"></td>
                        </tr>
                        <tr>
                            <td style="padding: 15px 0px 0px 5px;" colspan="4"></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="lblBaseName" runat="server" Text="Item Name :" CssClass="lbl" Width="150px"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtItemName" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblDescription" runat="server" Text="Colour :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtColour" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ></asp:TextBox>
                            </td>

                            <td style="text-align: right;" class="auto-style7">&nbsp;</td>
                            <td style="text-align: right;">
                                <asp:Label ID="lblSearch" runat="server" CssClass="lbl" Text="Search :"></asp:Label></td>

                            <td style="text-align: left;" class="auto-style1">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="txtBox1" Width="248px" Height="19px" BackColor="WhiteSmoke" ForeColor="Black"></asp:TextBox>
                                <td style="text-align: right;">
                                    <asp:Button ID="btnSearch" runat="server" class="myButtonGrey" Text="Search" OnClick="btnSearch_Click" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label2" runat="server" Text="UoM :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlUoMN" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label4" runat="server" Text="Origin :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtOriginn" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ></asp:TextBox>
                            </td>

                            <td style="text-align:right;"></td>
                    <td style="text-align:right;" colspan="3"; rowspan="12" >
                    <asp:ListBox ID="ItemList" runat="server" Height="300px" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ItemList_SelectedIndexChanged"></asp:ListBox>
                  </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label22" runat="server" Text="Part No :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPartNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label23" runat="server" Text="Other Spec :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtOtherSpec" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label10" runat="server" Text="Model No :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtModelNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label6" runat="server" Text="Brand :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtBrand" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>

                        </tr>

                        </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="Label13" runat="server" Text="Length :" CssClass="lbl"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtLength" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                <td style="text-align: right;">
                    <asp:Label ID="Label15" runat="server" Text="Length Uom :" CssClass="lbl"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlLengthUom" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>

            </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label24" runat="server" Text="Width :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtWidth" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label25" runat="server" Text="Width Uom. :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlWidthUom" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label12" runat="server" Text="Hight:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtHight" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label17" runat="server" Text="Hight UoM :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlHeightUoM" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>

                            <td style="text-align: right;">
                                <asp:Label ID="Label27" runat="server" Text="Inner Dia:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextInnerDia" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label28" runat="server" Text="ID UoM :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlIdUom" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label29" runat="server" Text="Outer Dia:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextOuterDia" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="OD UoM :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlOdUom" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label3" runat="server" Text="Gross Wt:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextGrossWt" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label5" runat="server" Text="Net Wt :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextNetWt" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label14" runat="server" Text="Alter. UoM" CssClass="lbl"></asp:Label><span> :</span></td>
                            <td>
                                <asp:DropDownList ID="ddlAlterUoM" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label16" runat="server" Text="Plant" CssClass="lbl"></asp:Label><span> :</span></td>
                            <td>
                                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label18" runat="server" Text="Is MRP:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlIsMRP" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label19" runat="server" Text="Re-Order Point:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtReOrderPoint" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label20" runat="server" Text="Min. Stock:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMinStock" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox>

                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label7" runat="server" Text="Max. Stock:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMaxStock" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" Text="Safty Stock:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSaftyStock" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox>

                            </td>
                            <%-- <td style="text-align: right;">
                                <asp:Label ID="Label9" runat="server" Text="Max. Stock :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox>

                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: right; padding: 10px 0px 0px 0px">
                                <asp:Button ID="btnSubmit" runat="server" class="myButton" OnClick="btnSubmit_Click" OnClientClick="ConfirmAll()" Text="Submit" /></td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
