<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemManagerAccountsPopUp.aspx.cs" Inherits="UI.SCM.ItemManagerAccountsPopUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Application </title>
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
    <link href="../Content/JS/dist/css/select2.min.css" rel="stylesheet" />
    <script src="../Content/JS/dist/js/select2.min.js"></script>
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
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 0px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 10px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <asp:HiddenField ID="hdnconfirm" runat="server" />
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnUnit" runat="server" />
                <asp:HiddenField ID="hdnWHID" runat="server" />
                <asp:HiddenField ID="hdnGroupID" runat="server" />
                <asp:HiddenField ID="hdnCategoryID" runat="server" />
                <asp:HiddenField ID="hdnItemID" runat="server" />
                <asp:HiddenField ID="hfStoreMasterId" runat="server" />

                <div id="hdnDivision" class="hdnDivision" style="width: auto;">
                    <table style="width: auto; float: left;">
                        <tr>
                            <td style="text-align: right; font: bold 14px verdana;"></td>
                        </tr>
                        <tr>
                            <td>
                                <div class="leaveApplication_container">
                                    <table class="tbldecoration" style="width: auto; float: left;">

                                        <tr class="tblheader">
                                            <td class="tdheader" colspan="4">ITEM APPROVE BY ACCOUNTS DEPT :</td>
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
                                                <asp:TextBox ID="txtItemName" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="lblDescription" runat="server" Text="Colour :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtColour" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label2" runat="server" Text="UoM :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlUoMN" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label4" runat="server" Text="Origin :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtOriginn" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label1" runat="server" Text="Part No :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtPartNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label3" runat="server" Text="Other Spec :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtOtherSpec" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label5" runat="server" Text="Model No :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtModelNo" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke"></asp:TextBox></td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label6" runat="server" Text="Brand :" CssClass="lbl"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtBrand" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();" Enabled="false"></asp:TextBox></td>

                                        </tr>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label13" runat="server" Text="Length :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtLength" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();" Enabled="false"></asp:TextBox></td>
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
                                <asp:Label ID="Label7" runat="server" Text="Hight UoM :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlHeightUoM" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></td>

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

                            <%--<td style="text-align:right;"><asp:Label ID="Label1" runat="server" Text="UOM :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtUOM" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="Label3" runat="server" Text="Group :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtGroup" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td> --%>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label29" runat="server" Text="Outer Dia:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextOuterDia" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label8" runat="server" Text="OD UoM :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlOdUom" CssClass="ddList" Font-Bold="False" runat="server" Width="220px" Height="24px" BackColor="WhiteSmoke" AutoPostBack="true"></asp:DropDownList></asp:TextBox></td>
                            <%--<td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="Category :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="Label6" runat="server" Text="Sub-Category :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtSubCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td> --%>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label11" runat="server" Text="Gross Wt:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextGrossWt" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label26" runat="server" Text="Net Wt :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="TextNetWt" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            </td>
            <%--<td style="text-align:right;"><asp:Label ID="Label7" runat="server" Text="Minor Category :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtMinorCategory" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
            <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Plant :" CssClass="lbl"></asp:Label></td>
            <td><asp:TextBox ID="txtPlant" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td> --%>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label9" runat="server" Text="Alter. UoM" CssClass="lbl"></asp:Label><span> :</span></td>
                            <td>
                                <asp:DropDownList ID="ddlAlterUoM" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label10" runat="server" Text="Plant" CssClass="lbl"></asp:Label><span> :</span></td>
                            <td>
                                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label17" runat="server" Text="Is MRP:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlIsMRP" runat="server" CssClass="ddList" Width="220px" Height="24px"></asp:DropDownList></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label21" runat="server" Text="Re-Order Point:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtReOrderPoint" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label30" runat="server" Text="Min. Stock:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMinStock" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox>

                            </td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label31" runat="server" Text="Max. Stock:" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMaxStock" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label32" runat="server" Text="Safty Stock:" CssClass="lbl"></asp:Label></td>
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
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <%--  <tr>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="Procure Type :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtPurchaseType" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label9" runat="server" Text="HS Code :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtHSCode" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label14" runat="server" Text="Max Lead Time :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMaxLeadTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="Min Lead Time :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMinLeadTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label17" runat="server" Text="Avg Lead Time :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtAvgLeadTime" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false" ></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="Ordering Lot Size :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtLotSize" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label19" runat="server" Text="Economic Order Qty. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtEOQ" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="Min Order Qty. :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtMOQ" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="SDE Classification :" CssClass="lbl"></asp:Label></td>
                <td><asp:TextBox ID="txtSDE" runat="server" CssClass="txtBox1" BackColor="WhiteSmoke" Enabled="false"></asp:TextBox></td>
                
            </tr>--%>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label14" runat="server" Text="HSCode " CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td>
                                <asp:TextBox ID="txtCode" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label16" runat="server" Text="Origin " CssClass="lbl"></asp:Label><span style="color: red; font-size: 14px;">*</span><span> :</span></td>
                            <td>
                                <asp:TextBox ID="txtPOrigin" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label18" runat="server" Text="Min Order Qty :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtMinOrderQty" runat="server" CssClass="txtBox1" BackColor="White"></asp:TextBox></td>
                            <td style="text-align: right;">
                                <asp:Label ID="Label19" runat="server" Text="Lead Time. :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtLeadTime" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label20" runat="server" Text="Purchase Description. :" CssClass="lbl"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPurchaseDescription" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox></td>
                            <%--<td style="text-align:right;"><asp:Label ID="Label21" runat="server" Text="SDE Classification " CssClass="lbl"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
            <td><asp:DropDownList ID="ddlSDE" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="24px" BackColor="White"><asp:ListItem Selected="True" Value="0" Text=" Select SDE Classification"></asp:ListItem>
            <asp:ListItem Value="1">Scarce</asp:ListItem><asp:ListItem Value="2">Difficult</asp:ListItem><asp:ListItem Value="3">Easily</asp:ListItem></asp:DropDownList></td>--%>
                        </tr>
                        <%--<tr>
            <td colspan="4" style="text-align:right; padding: 10px 0px 0px 0px"><asp:Button ID="Button1" runat="server" class="myButton" OnClick="btnApprove_Click" OnClientClick="ConfirmAll()" Text="Approve" /></td>
        </tr>--%>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label33" runat="server" Text="Min. Order Qty. :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSAMinOrderQty" runat="server" CssClass="txtBox1" Font-Bold="false" Width="220px" Height="24px" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox>
                            </td>
                             <td style="text-align: right;">
                                <asp:Label ID="Label34" runat="server" Text="Min. Delv. Qty. :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSAMinDelvQty" runat="server" CssClass="txtBox1" Font-Bold="false" Width="220px" Height="24px" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label35" runat="server" Text="Salling UoM :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSASallingUoM" runat="server" CssClass="ddlList" BackColor="White" Font-Bold="false" Width="220px" Height="24px" ></asp:DropDownList>
                            </td>
                             <td style="text-align: right;">
                                <asp:Label ID="Label36" runat="server" Text="Product Heirarchy :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSAProductHeirarchy" runat="server" CssClass="txtBox1" BackColor="White" onkeypress="return onlyNumbers();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="lblCOA" runat="server" Text="GL Code " CssClass="lbl"></asp:Label><span> :</span>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="ddlGLCode" runat="server" CssClass="ddlList mqmm" Font-Bold="false" Width="220px" Height="24px" BackColor="White"></asp:DropDownList>
                            </td>
                             <td style="text-align: right;">
                                <asp:Label ID="Label38" runat="server" Text="Cost Center :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSACostCenter" runat="server" CssClass="ddlList" Font-Bold="false" Width="220px" Height="24px" BackColor="White"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Label37" runat="server" Text="Profit Center :" CssClass="lbl"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSAProfitCenter" runat="server" CssClass="ddlList" Font-Bold="false" Width="220px" Height="24px" BackColor="White"></asp:DropDownList>
                            </td>
                            <td colspan="2" style="text-align: right; padding: 10px 0px 0px 0px">
                                <asp:Button ID="btnApprove" runat="server" class="myButton" OnClick="btnApprove_Click" OnClientClick="ConfirmAll()" Text="Submit" /></td>
                        </tr>
                    </table>
                </div>
                </td></tr>
        </table>
        </div>
        

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script type="text/javascript"> 
        $(document).ready(function () {
            $(".mqmm").select2();
        });
    </script>
</body>
</html>
