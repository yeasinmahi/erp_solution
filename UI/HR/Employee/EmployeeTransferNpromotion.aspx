<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTransferNpromotion.aspx.cs" Inherits="UI.HR.Employee.EmployeeTransferNpromotion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Transfer & Promotion</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
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
    <form id="frmEmployeeTransferPromotion" runat="server">
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
                <div class="leaveApplication_container">
                    <asp:Button Text="New Employee Transfer" ID="tabNewEmpTransfer" CssClass="Initial tabstyle" runat="server" OnClick="tabNewEmpTransfer_Click" />
                    <asp:Button Text="Employee Promotion" ID="tabEmpPromotion" CssClass="Initial tabstyle" runat="server" OnClick="tabEmpPromotion_Click" />
                    <asp:Button Text="Old Employee Transfer" ID="tabOldEmpTransfer" CssClass="Initial tabstyle" runat="server" OnClick="tabOldEmpTransfer_Click" />
                    <asp:Button Text="Old Employee Resign" ID="tabOldEmpResign" CssClass="Initial tabstyle" runat="server" OnClick="tabOldEmpResign_Click" />
                    <asp:Label ID="lblEmpTransferNpromotion" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                    <asp:MultiView runat="server" ID="mainView">
                        <asp:View runat="server" ID="vwNewEmpTransfer">
                            <table class="tablestyle" style="width:50%">
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle">Designation : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETDesignation" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle">Channel : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Region : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlNETRegion" CssClass="ddlstyle"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlNETRegion_SelectedIndexChanged"></asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Area : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlNETArea_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Territory : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlNETTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Point : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETPoint" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> New Employee Enroll : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtETNEnroll" CssClass="txtstyle" Height="22px" 
                                        AutoPostBack="true" OnTextChanged="txtETNEnroll_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> New Employee Name : </asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtNETEmpName" CssClass="txtstyle" Height="22px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Transfer Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNETDate" CssClass="txtstyle" Height="22px"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtNETDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdstyle-btn"><asp:Button runat="server" ID="btnNETUpdate" Text="Update" CssClass="btnstyle-sm" OnClick="btnNETUpdate_Click" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="vwEmpPromotion">

                        </asp:View>
                        <asp:View runat="server" ID="vwOldEmpTransfer">

                        </asp:View>
                        <asp:View runat="server" ID="vwOldEmpResign">

                        </asp:View>
                    </asp:MultiView>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
