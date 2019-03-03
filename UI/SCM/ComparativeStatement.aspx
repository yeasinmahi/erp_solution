<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComparativeStatement.aspx.cs" Inherits="UI.SCM.ComparativeStatement"  EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />

    <script>
        function Print() {
            //document.getElementById("btnEmail").hidden = true;
            //document.getElementById("btnprint").style.display = "none";
            window.print();
        }
    </script>

    <style type="text/css">
        @media print {
            body * {
                visibility: hidden;
            }

            #dvTable, #dvTable * {
                visibility: visible;
            }

            #section-to-print {
                position: absolute;
                left: 0;
                top: 0;
            }
        }

        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background: url("../Images/InitialImage.png") no-repeat right top;
            color: Black;
            font-weight: bold;
        }

            .Initial:hover {
                color: White;
                background: #eeeeee;
            }

        .Clicked {
            float: left;
            display: block;
            background: padding-box;
            padding: 4px 18px 4px 18px;
            color: Black;
            font-weight: bold;
            color: Green;
        }

        .auto-style1 {
            width: 819px;
        }
    </style>
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
        }

        .auto-style2 {
            height: 20px;
        }
    </style>

</head>
<body>
    <form id="frmaccountsrealize" runat="server">

        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                            <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                        </marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <div id="loading"></div>
                <%--=========================================Start My Code From Here===============================================--%>
                <div class="leaveApplication_container">
                    <asp:HiddenField ID="hdnUnitId" runat="server" />
                    <asp:HiddenField ID="hdnUnitName" runat="server" />
                    <asp:HiddenField ID="hdnWHId" runat="server" />
                    <asp:HiddenField ID="hdnWHName" runat="server" />
                    <asp:HiddenField ID="hdnPreConfirm" runat="server" />
                    <td>
                        <asp:Button Text="Indent View" BorderStyle="Solid" ID="Tab1" CssClass="Initial" runat="server"
                            OnClick="Tab1_Click" BackColor="#FFCC99" />
                        <asp:Button Text="Indent Detail" BorderStyle="Solid" ID="Tab2" CssClass="Initial" runat="server"
                            BackColor="#FFCC99" OnClick="Tab2_Click" />
                        <asp:Button Text="RFQ" BorderStyle="Solid" ID="Tab3" CssClass="Initial" runat="server"
                            BackColor="#FFCC99" OnClick="Tab3_OnClick" />


                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <table style="width: 80%; border-width: 1px; background-color: white; border-color: #666; border-style: solid">
                                    <table>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label16" runat="server" CssClass="lbl" Text="Department:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlDepts" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"></asp:DropDownList></td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="WH-Name:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Text="From-Date : "></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtDtefroms" autocomplete="off" runat="server" CssClass="txtBox"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDtefroms"></cc1:CalendarExtender>

                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="To-Date : "></asp:Label>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtDteTo" runat="server" autocomplete="off" CssClass="txtBox"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDteTo"></cc1:CalendarExtender>
                                            </td>

                                            <%-- </td>
                          </td>--%>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Indent No:"></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:TextBox ID="txtIndentNo" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearchIndent" runat="server" ForeColor="blue" Text="Search Indent" OnClick="btnSearchIndent_Click" />
                                            </td>
                                            <td style="text-align: right">
                                                <asp:Button ID="btnShow" runat="server" ForeColor="blue" OnClick="btnShow_Click" OnClientClick="showLoader()" Text="Show Indent" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:GridView ID="dgvIndent" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" Font-Size="10px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL No.">
                                                            <ItemStyle HorizontalAlign="center" Width="60px" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit" SortExpression="strUnit" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("strUnit") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location" SortExpression="strWareHoseName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Bind("strWareHoseName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Indent No" ItemStyle-HorizontalAlign="right" SortExpression="intIndentID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIndent" runat="server" Text='<%# Bind("intIndentID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Indent Date" ItemStyle-HorizontalAlign="center" SortExpression="dteIndentDate" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldteIndent" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dteIndentDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approve Date" ItemStyle-HorizontalAlign="center" SortExpression="dteApproveDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldteApprove" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("dteApproveDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Approved By" ItemStyle-HorizontalAlign="right" SortExpression="strName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApproveBy" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Due Date" ItemStyle-HorizontalAlign="right" ControlStyle-ForeColor="Red" SortExpression="dteDueDate">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldteDue" runat="server" Text='<%# Bind("dteDueDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Detalis">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnIndentDet" runat="server" ForeColor="blue" OnClick="btnIndentDetalis_Click" Text="Detalis" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                </table>
                            </asp:View>
                            <%--//Indent Detalis TAB--%>
                            <asp:View ID="View2" runat="server">
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                    <tr>
                                        <td class="auto-style1" />
                                        <table>
                                            <tr>
                                                <td style="vertical-align: top">
                                                    <table>
                                                        <div>
                                                            <table>
                                                                <tr style="text-align: center">
                                                                    <td colspan="5" style="text-align: center">
                                                                        <asp:Label ID="lblIndentDetUnit" Font-Bold="true" Font-Size="Medium" runat="server" /></td>
                                                                </tr>
                                                                <tr style="text-align: center">
                                                                    <td colspan="5" style="text-align: center">
                                                                        <asp:Label ID="lblIndentDetWH" Font-Bold="true" runat="server" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Indent No:"></asp:Label></td>
                                                                    <td style="text-align: left;">
                                                                        <asp:TextBox ID="txtIndentNoDet" Width="70px" CssClass="txtBox" Font-Bold="False" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                        <asp:Button ID="btnIndentDetShow" runat="server" ForeColor="Blue" Text="Show" OnClick="btnIndentDetShow_Click" /></td>


                                                                    <td style="text-align: right;">
                                                                        <asp:Label ID="lblItem" CssClass="lbl" runat="server" Text="Item: "></asp:Label></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlItem" CssClass="ddList" Width="400px" runat="server"></asp:DropDownList></td>
                                                                    <td>
                                                                        <asp:Button ID="btnAddItem" runat="server" ForeColor="Blue" Text="Add" OnClick="btnAddItem_Click" />

                                                                        <asp:Button ID="btnPrepareRfq" ForeColor="Blue" runat="server" Text="Prepare RFQ" OnClick="btnPrepareRfq_OnClick" />

                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </div>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: top">
                                                    <table>
                                                        <div style="display: inline-block">
                                                            <tr style="text-align: left">
                                                                <td>Indent Type :</td>
                                                                <td>
                                                                    <asp:Label ID="lblIndentType" ForeColor="blue" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr style="text-align: left">
                                                                <td>Indent Date:</td>
                                                                <td>
                                                                    <asp:Label ID="lblIndentDate" runat="server" /></td>
                                                            </tr>
                                                            <tr style="text-align: left">
                                                                <td>Approve Date :</td>
                                                                <td>
                                                                    <asp:Label ID="lblindentApproveDate" runat="server" /></td>
                                                            </tr>

                                                            <tr>
                                                                <td>Due Date:</td>
                                                                <td>
                                                                    <asp:Label ID="lblInDueDate" ForeColor="red" runat="server" /></td>
                                                            </tr>
                                                        </div>
                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="dgvIndentDet" runat="server" AutoGenerateColumns="False" OnRowDeleting="dgvIndentDet_RowDeleting" Font-Size="10px" BackColor="White" BorderColor="#999999" BorderStyle="Solid"
                                                        BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-BackColor="#999999" FooterStyle-HorizontalAlign="Right" OnRowDataBound="dgvIndentDet_OnRowDataBound">
                                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle HorizontalAlign="center" Width="30px" />
                                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Indent Id" Visible="true" SortExpression="indentId">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIndentId" runat="server" Text='<%# Bind("indentId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Item ID" SortExpression="ItemId">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("ItemId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ItemName" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItem") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" Width="250px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="UoM" ItemStyle-HorizontalAlign="center" Visible="true" SortExpression="strUom">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUom") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="HS Code" ItemStyle-HorizontalAlign="right" SortExpression="strHsCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHsCode" runat="server" Text='<%# Bind("strHsCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Purpose" ItemStyle-HorizontalAlign="right" SortExpression="strDesc">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPurpose" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("strDesc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Current Stock" ItemStyle-HorizontalAlign="right" SortExpression="numCurStock">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCurrentStock" runat="server" Text='<%# Bind("numCurStock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Safty Stock" ItemStyle-HorizontalAlign="right" Visible="true" SortExpression="numSafetyStock">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSaftyStock" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numSafetyStock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Indent Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIndentQty" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numIndentQty") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                            </asp:TemplateField>

                                                           

                                                            <asp:TemplateField HeaderText="PO Issue" ItemStyle-HorizontalAlign="right" SortExpression="numPoIssued">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPoIssue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numPoIssued") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Remain" ItemStyle-HorizontalAlign="right" SortExpression="numRemain">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemaining" runat="server" Text='<%# Bind("numRemain") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RFQ Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRfqQty" runat="server"  Width="80px"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="80px" />
                                                            </asp:TemplateField>

                                                            <%--                                                    <asp:TemplateField HeaderText="Specification"  ItemStyle-HorizontalAlign="right" SortExpression="strSpecification">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSpecification" runat="server" DataFormatString="{0:0.00}" TextMode="MultiLine" Text='<%# Bind("strSpecification") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Wrap="true" />
                                                    </asp:TemplateField>--%>


                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True">
                                                                <ControlStyle ForeColor="Red" />
                                                            </asp:CommandField>


                                                        </Columns>
                                                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </tr>
                            </asp:View>

                            <asp:View ID="View3" runat="server">
                                <div style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Supplier:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlSupplier" runat="server" AutoPostBack="true" CssClass="ddList" Font-Bold="False" OnSelectedIndexChanged="ddlSupplier_OnSelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Supplier Name:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblSupplierName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Supplier Contact:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblSupplierContact" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                                <td style="text-align: center; font: bold 13px verdana;">
                                                    <a id="btnprint" href="#" class="nextclick" style="cursor: pointer" onclick="Print()">Print</a>
                                                </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Supplier Address:"></asp:Label></td>
                                            <td  colspan="3" style="text-align: left;">
                                                <asp:Label ID="lblSupplierAddress" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            <td style="text-align: right;">
                                                <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Supplier Email:"></asp:Label></td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblSupplierEmail" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                            
                                            <td>
                                                <asp:Button ID="btnEmail" runat="server" Text="Email" OnClick="btnEmail_OnClick" />
                                            </td>
                                            <%--<td>
                                                <asp:Button runat="server" ID="btnSentEmail" Text="SentEmail" OnClick="btnSentEmail_OnClick"/>
                                            </td>--%>
                                        </tr>
                                    </table>
                                    <div id="dvTable" runat="server" style="width: auto; background-color: white; padding-left: 50px; padding-right: 50px; padding-top: 10px; padding-bottom: 20px;">

                                        <table style="width: 700px">
                                           

                                            <tr>

                                                <td rowspan="3" style="width: 80px">
                                                    <asp:Image ID="imgUnit" Width="80" AlternateText="Unit Image" runat="server" />
                                                </td>
                                                <td style="text-align: center; font-size: medium; font-weight: bold;">
                                                    <asp:Label ID="lblUnitName" runat="server" Text="Akij Group" Font-Underline="true"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <asp:Label ID="lblWH" Font-Size="Small" Font-Bold="true" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Label ID="lblDetalis" runat="server" Font-Bold="true" Font-Underline="true" Font-Size="Small" Text="Request for quotation"></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table>

                                            <tr>
                                                <td>
                                                    <asp:Label runat="server" Text="RFQ No:"></asp:Label>
                                                    <asp:Label ID="lblRfqNo" Font-Bold="true" Font-Size="small" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label runat="server" Text="RFQ Date:"></asp:Label>
                                                    <asp:Label ID="lblRfqDate" Font-Bold="true" Font-Size="small" runat="server"></asp:Label>
                                                </td>
                                                <%--<td>
                                                    <asp:Label ID="Label5" runat="server" Text="Indent Type:"></asp:Label><asp:Label ID="lblType" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="Indent Date:"></asp:Label><asp:Label ID="lbldteIndent" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="Due Date:"></asp:Label><asp:Label ID="lbldteDue" Font-Bold="true" Font-Size="small" runat="server"></asp:Label></td>--%>
                                            </tr>
                                        </table>
                                        <table style="width: 800px">
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvRfq" runat="server" AutoGenerateColumns="False" Font-Size="10px" BackColor="White" BorderColor="#999999"
                                                        BorderWidth="1px" CellPadding="5" GridLines="Vertical" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" BorderStyle="Solid" FooterStyle-BackColor="#999999" ForeColor="Black" OnRowDeleting="dgvIndentDet_RowDeleting">

                                                        <AlternatingRowStyle BackColor="#CCCCCC" />

                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemStyle HorizontalAlign="center" Width="30px" />
                                                                <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Indent Id" SortExpression="indentId" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIndentId" runat="server" Text='<%# Bind("intIndentId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Item ID" SortExpression="ItemId">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Bind("intItemId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Item Name" ItemStyle-HorizontalAlign="right" SortExpression="strItem">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("strItemName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="left" Width="250px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="UoM" Visible="true" ItemStyle-HorizontalAlign="center" SortExpression="strUom">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUom" runat="server" Text='<%# Bind("strUom") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="center" />
                                                            </asp:TemplateField>

                                                            <%--<asp:TemplateField HeaderText="HS Code" ItemStyle-HorizontalAlign="right" SortExpression="strHsCode">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblHsCode" runat="server" Text='<%# Bind("strHsCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>--%>

                                                            <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="right" SortExpression="strDesc">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" ></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RFQ Qty" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRfqQuantity" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numRfqQty") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" Enabled="False"  Width="50px" ></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="50px"/>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" SortExpression="numIndentQty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox runat="server" Enabled="False"  Width="80px" ></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="80px"/>
                                                            </asp:TemplateField>

                                                            <%--<asp:TemplateField HeaderText="PO Issue" ItemStyle-HorizontalAlign="right" SortExpression="numPoIssued">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPoIssue" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numPoIssued") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Remain" ItemStyle-HorizontalAlign="right" SortExpression="numRemain">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRemaining" runat="server" Text='<%# Bind("numRemain") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>RFQ Prepared By:</td>
                                                <td>
                                                    <asp:Label ID="lblRfqBy" Font-Bold="true" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>e-Approved By: </td>
                                                <td>
                                                    <asp:Label ID="lblApproveBy" runat="server" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                </div>

                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
