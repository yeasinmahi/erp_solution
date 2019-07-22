<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AGLandTrxGeneralNew.aspx.cs" Inherits="UI.Property.AGLandTrxGeneralNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AG Land Trx. General</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <link href="../Content/CSS/PropertyStyle.css" rel="stylesheet" />
    <style>
        .tabstyle {
            border-style: solid;
            background-color: #FFCC99;
        }

        .txtstyle {
            width: 250px;
            height: 25px;
            font-size: 15px;
            border-radius: 5px;
        }

        .ddlstyle {
            width: 250px;
            height: 30px;
            font-size: 12px;
            border-radius: 5px
        }

        .lblstyle {
            font-size: 15px;
            padding-right: 2px
        }

        .tablestyle {
            width: 100%;
            border-width: 1px;
            background-color: #d0cdcd;
            border-color: #666;
            border-style: solid;
            margin-top: 15px
        }

        .tdstyle {
            text-align: right;
        }

        .tdstyle-btn {
            text-align: right;
        }

        .btnstyle-sm {
            width: 75px;
            height: 30px;
            color: #000000;
            font-size: 15px;
            font-weight: bold;
        }

        .btnstyle-lg {
            width: 100px;
            height: 30px;
            color: #eeeeee;
            font-size: 15px;
            font-weight: bold;
            background: Green
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
</head>
<body>
    <form id="frmAGLandTrxGeneral" runat="server">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
        <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">
            <ContentTemplate>--%>
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
        <asp:HiddenField ID="hfConfirm" runat="server" />
        <asp:HiddenField ID="hdnconfirm" runat="server" />
        <div class="leaveApplication_container">
            <div style="height: 30px;">
                <asp:Button Text="LM Master" ID="tabLMMaster" CssClass="Initial tabstyle" runat="server" OnClick="tabLMMaster_Click" />
                <asp:Button Text="LM Detail" ID="tabLMDetails" CssClass="Initial tabstyle" runat="server" OnClick="tabLMDetails_Click" />
                <asp:Button Text="LM Document" ID="tabLMDocument" CssClass="Initial tabstyle" runat="server" OnClick="tabLMDocument_Click" />
                <asp:Label ID="lblLandManagement" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#000099"></asp:Label>
            </div>
            <div>
                <asp:MultiView runat="server" ID="mainView">
                    <asp:View runat="server" ID="viewLMMaster">
                        <table class="table2">
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label1" runat="server" CssClass="lbl-txt" Text="Unit :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:DropDownList runat="server" ID="ddlUnit" CssClass="ddl-field">
                                    </asp:DropDownList>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label2" CssClass="lbl-txt" runat="server" Text="Deed No :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtDeedNo" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label3" runat="server" CssClass="lbl-txt" Text="Mouza :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:DropDownList runat="server" ID="ddlMouza" CssClass="ddl-field" AutoPostBack="true" OnSelectedIndexChanged="ddlMouza_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label4" CssClass="lbl-txt" runat="server" Text="Deed Date :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtDeedDate" runat="server" CssClass="txt-field"></asp:TextBox>
                                    <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtDeedDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl-txt" Text="Sub-Office :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:DropDownList runat="server" ID="ddlSubOffice" CssClass="ddl-field">
                                    </asp:DropDownList>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label6" CssClass="lbl-txt" runat="server" Text="Seller Name :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtSellerName" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label7" runat="server" CssClass="lbl-txt" Text="Deed Type :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:DropDownList runat="server" ID="ddlDeedType" CssClass="ddl-field">
                                    </asp:DropDownList>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label8" CssClass="lbl-txt" runat="server" Text="Purchase Land :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtPurchaseLand" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label9" runat="server" CssClass="lbl-txt" Text="Complete :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:DropDownList runat="server" ID="ddlComplete" CssClass="ddl-field">
                                    </asp:DropDownList>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label10" CssClass="lbl-txt" runat="server" Text="Remarks :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txt-field" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div style="margin-top: 5px"></div>
                        <table class="table2">
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label11" runat="server" CssClass="lbl-txt" Text="Deed Value :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox runat="server" ID="txtDeedValue" CssClass="txt-field"></asp:TextBox>

                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label12" CssClass="lbl-txt" runat="server" Text="AIT :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtAIT" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label13" runat="server" CssClass="lbl-txt" Text="VAT :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtVat" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label14" CssClass="lbl-txt" runat="server" Text="Mutation Fee :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtMutationFee" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label15" runat="server" CssClass="lbl-txt" Text="Extended Value :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtExtendedValue" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label16" CssClass="lbl-txt" runat="server" Text="Other Cost :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtOtherCost" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label17" runat="server" CssClass="lbl-txt" Text="Broker :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtBroker" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label18" CssClass="lbl-txt" runat="server" Text="Other Cost Remarks :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtOtherCostRemarks" runat="server" CssClass="txt-field" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label19" runat="server" CssClass="lbl-txt" Text="Registration Cost :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtRegistrationCost" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                        <div style="margin-top: 5px"></div>
                        <table class="table2">
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label20" runat="server" CssClass="lbl-txt" Text="North :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox runat="server" ID="txtNorth" CssClass="txt-field">
                                    </asp:TextBox>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label21" CssClass="lbl-txt" runat="server" Text="South :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtSouth" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label22" runat="server" CssClass="lbl-txt" Text="East :"></asp:Label>
                                </td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtEast" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                                <td class="td-lbl2">
                                    <asp:Label ID="Label23" CssClass="lbl-txt" runat="server" Text="West :"></asp:Label></td>
                                <td class="td-txt-ddl2">
                                    <asp:TextBox ID="txtWest" runat="server" CssClass="txt-field"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View runat="server" ID="viewDetail">
                        <div style="width: 100%">
                            <div class="div-body-left">
                                <table class="table3">
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label24" runat="server" CssClass="lbl-txt" Text="Khatian CS :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtKhatianCS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label25" CssClass="lbl-txt" runat="server" Text="Plot CS :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotCS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label26" runat="server" CssClass="lbl-txt" Text="Khatian SA :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtKhatianSA" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label27" CssClass="lbl-txt" runat="server" Text="Plot SA :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotSA" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label28" runat="server" CssClass="lbl-txt" Text="Khatian RS :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtKhatianRS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label29" CssClass="lbl-txt" runat="server" Text="Plot RS :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotRS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label30" runat="server" CssClass="lbl-txt" Text="Khatian BS :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtKhatianBS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label31" CssClass="lbl-txt" runat="server" Text="Plot BS :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotBS" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label32" runat="server" CssClass="lbl-txt" Text="Kha.Mutation :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtKhatianMutation" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label33" CssClass="lbl-txt" runat="server" Text="Plot Mutation:"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotMutation" runat="server" CssClass="txt-field" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="margin-top: 5px"></div>
                                <table class="table3">
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label34" runat="server" CssClass="lbl-txt" Text="Plot Type :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:DropDownList runat="server" ID="ddlPlotType" CssClass="ddl-field" AutoPostBack="true" OnSelectedIndexChanged="ddlPlotType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label35" CssClass="lbl-txt" runat="server" Text="Plot No :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPlotNo" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label36" runat="server" CssClass="lbl-txt" Text="Purchased Plot :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtPurchasedPlot" runat="server" CssClass="txt-field" AutoPostBack="true" OnTextChanged="txtPurchasedPlot_TextChanged"></asp:TextBox>
                                            <asp:HiddenField runat="server" ID="hfPurshedPlot" />
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label37" CssClass="lbl-txt" runat="server" Text="Updated LDTR:"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:DropDownList ID="ddlUpdatedLDTR" runat="server" CssClass="txt-field"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label38" runat="server" CssClass="lbl-txt" Text="Rem.DeedArea :"></asp:Label>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtRemDeedArea" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label39" CssClass="lbl-txt" runat="server" Text="Rem.PlotArea :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtRemPlotArea" runat="server" CssClass="txt-field"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:Button runat="server" ID="btnCalculation" CssClass="btn btn-submit" Text="Calculation" OnClick="btnCalculation_Click" />
                                            <asp:Button runat="server" ID="btnSubmit" CssClass="btnn" Text="Submit" OnClick="btnSubmit_Click" Visible="false" />
                                            <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-add" Text="Add" OnClick="btnAdd_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                                <div style="margin-top: 5px"></div>
                                <table class="table3">
                                    <tr>
                                        <td class="td-lbl2">
                                            <%--<asp:Label ID="Label40" runat="server" CssClass="lbl-txt" Text="Attachment :"></asp:Label>--%>
                                        </td>
                                        <td class="td-txt-ddl2">
                                            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                        </td>
                                        <td class="td-lbl2">
                                            <asp:Label ID="Label41" CssClass="lbl-txt" runat="server" Text="Total Cost :"></asp:Label></td>
                                        <td class="td-txt-ddl2">
                                            <asp:TextBox ID="txtTotalExpence" runat="server" CssClass="txt-field" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="div-body-right" style="height: 450px; overflow: scroll">
                                <asp:GridView ID="dgvExistPlotArea" runat="server" AutoGenerateColumns="False" 
                                    Font-Size="11px" BackColor="White"
                                    BorderColor="#999999" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="5" 
                                    ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="15px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plot Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFilePlotType" runat="server" Text='<%# Bind("strPlotType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plot No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFilePlotNo" runat="server" Text='<%# Bind("strPlotNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plot Area" SortExpression="strFileName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFileName" runat="server" Text='<%# Bind("numPlotArea") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left"/>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                            </div>
                        </div>


                        <div style="margin-top: 2px">
                            <asp:GridView ID="gvLandTrxGeneral" runat="server" AutoGenerateColumns="False" Width="80%"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="5" Font-Size="12px" FooterStyle-BackColor="#999999" FooterStyle-Font-Bold="true"
                                FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mouza">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMouza" runat="server" Text='<%# Bind("mouza") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plot Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlotType" runat="server" Text='<%# Bind("plotType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="35px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plot No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlotNo" runat="server" Text='<%# Bind("strPlotNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="65px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purchased Plot Area">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPurchasedPlotArea" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("numPurchasedPlotArea") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plot By Mouza">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPlotByMouza" runat="server" DataFormatString="{0:0.00}" Text='<%# Bind("plotByMouza") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#999999" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="viewDocument">
                        <div style="margin-top: 2px">
                            <table class="table2" style="width: 30%">
                                <tr>
                                    <td class="td-lbl2">
                                        <asp:Label ID="Label43" runat="server" CssClass="lbl-txt" Text="Plot Type :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl2">
                                        <asp:DropDownList runat="server" ID="ddlFilePlotType" CssClass="ddl-field">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-lbl2">
                                        <asp:Label ID="Label44" CssClass="lbl-txt" runat="server" Text="Plot No :"></asp:Label></td>
                                    <td class="td-txt-ddl2">
                                        <asp:TextBox ID="txtFilePlotNo" runat="server" CssClass="txt-field"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="td-lbl2">
                                        <asp:Label ID="Label42" runat="server" CssClass="lbl-txt" Text="Attachment :"></asp:Label>
                                    </td>
                                    <td class="td-txt-ddl2">
                                        <asp:FileUpload ID="fuDocUpload" runat="server" AllowMultiple="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnFileAdd" runat="server" Text="File Add" CssClass="btn btn-add" OnClick="btnFileAdd_Click" Style="float: right"></asp:Button>
                                        <asp:Button ID="btnFileUploadSubmit" runat="server" class="btn btn-submit" Font-Bold="true" Style="float: right" OnClientClick="FTPUpload1()" Text="Submit" />
                                    </td>
                                </tr>
                            </table>
                            <div style="margin-top: 5px"></div>
                            <asp:GridView ID="dgvFileUp" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White"
                                BorderColor="#999999" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="5" ForeColor="Black" GridLines="Vertical"
                                OnRowDeleting="dgvFileUp_RowDeleting">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SL No.">
                                        <ItemStyle HorizontalAlign="center" Width="15px" />
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plot Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFilePlotType" runat="server" Text='<%# Bind("strPlotType") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Plot No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFilePlotNo" runat="server" Text='<%# Bind("plotNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="File Name" SortExpression="strFileName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblgvFileName" runat="server" Text='<%# Bind("strFileName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="530px" />
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField HeaderText="doctypeid" Visible="false" ItemStyle-HorizontalAlign="right" SortExpression="doctypeid">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldoctypeid" runat="server" DataFormatString="{0:0.00}" Text='<%# (""+Eval("doctypeid")) %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                    <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />

                                </Columns>
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>

        </div>
        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>

    <script>
        //function FTPUpload() {
        //    document.getElementById("hdnconfirm").value = "2";
        //    __doPostBack();
        //}
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
</body>
</html>
