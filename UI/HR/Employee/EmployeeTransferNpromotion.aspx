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
    <link href="../../Content/CSS/jquery-ui.min.css" rel="stylesheet" />
    <script src="../../Content/JS/jquery-ui.min.js"></script>
    <script src="../../Content/JS/jquery-3.3.1.js"></script>
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
            font-size: 12px;
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
                    <asp:HiddenField ID="hfConfirm" runat="server" />
                    <asp:Button Text="New Employee Transfer" ID="tabNewEmpTransfer" CssClass="Initial tabstyle" runat="server" OnClick="tabNewEmpTransfer_Click" />
                    <asp:Button Text="Employee Promotion" ID="tabEmpPromotion" CssClass="Initial tabstyle" runat="server" OnClick="tabEmpPromotion_Click" />
                    <asp:Button Text="Old Employee Transfer" ID="tabOldEmpTransfer" CssClass="Initial tabstyle" runat="server" OnClick="tabOldEmpTransfer_Click" />
                    <asp:Button Text="Old Employee Resign" ID="tabOldEmpResign" CssClass="Initial tabstyle" runat="server" OnClick="tabOldEmpResign_Click" />
                    <asp:Label ID="lblEmpTransferNpromotion" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="#000099"></asp:Label>
                    <asp:MultiView runat="server" ID="mainView">
                        <asp:View runat="server" ID="vwNewEmpTransfer">
                            <table class="tablestyle" style="width:80%">
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle">Designation : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlNETDesignation" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlNETDesignation_SelectedIndexChanged"></asp:DropDownList></td>
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
                                    <td><asp:DropDownList runat="server" ID="ddlNETPoint" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlNETPoint_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> New Employee Enroll : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNETEnroll" CssClass="txtstyle" Height="22px" 
                                        AutoPostBack="true" OnTextChanged="txtNETEnroll_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> New Employee Name : </asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtNETEmpName" CssClass="txtstyle" Height="22px" Enabled="false"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Transfer Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtNETDate" CssClass="txtstyle" Height="22px"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtNETDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdstyle-btn"><asp:Button runat="server" ID="btnNETUpdate" Text="Update" CssClass="btnstyle-sm" OnClientClick="Confirm()" OnClick="btnNETUpdate_Click" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="vwEmpPromotion">
                            <table class="tablestyle" style="width:100%">
                                <tr>
                                    <td><asp:Label runat="server" ID="Label1" Text="Designation : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldDesignation" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPoldDesignation_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label2" Text="New Designation : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewDesignation" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label3" Text="Channel : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label4" Text="New Channel : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label5" Text="Region : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldRegion" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPoldRegion_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label6" Text="Region : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewRegion" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPnewRegion_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label7" Text="Area : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPoldArea_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label8" Text="Area : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPnewArea_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label9" Text="Territory : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPoldTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label10" Text="Territory : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPnewTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label11" Text="Point : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPoldPoint" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlEPoldPoint_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label12" Text="Point : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlEPnewPoint" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label13" Text="Emp. Enroll : "></asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtEPEmpEnroll" CssClass="ddlstyle"
                                        AutoPostBack="true" OnTextChanged="txtEPEmpEnroll_TextChanged"></asp:TextBox></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label14" Text="Emp. Name : "></asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtEPEmpName" CssClass="txtstyle"></asp:TextBox></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label15" Text="Date : "></asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtEPDate" CssClass="txtstyle"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtEPDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="tdstyle-btn"><asp:Button runat="server" ID="btnEPUpdate" Text="Update" CssClass="btnstyle-sm" OnClientClick="Confirm()" OnClick="btnEPUpdate_Click" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="vwOldEmpTransfer">
                            <table class="tablestyle" style="width:100%">
                                <tr>
                                    <td><asp:Label runat="server" ID="Label16" Text="Designation : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldDesignation" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETOldDesignation_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label18" Text="Channel : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label19" Text="New Channel : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETNewChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label20" Text="Region : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldRegion" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETOldRegion_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label21" Text="Region : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETnewRegion" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETnewRegion_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label22" Text="Area : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETOldArea_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label23" Text="Area : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETNewArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETNewArea_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label24" Text="Territory : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETOldTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label25" Text="Territory : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETNewTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETNewTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label26" Text="Point : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETOldPoint" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETOldPoint_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td><asp:Label runat="server" ID="Label27" Text="Point : "></asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOETNewPoint" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOETNewPoint_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label28" Text="Emp. Enroll : "></asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtOETEmpEnroll" CssClass="txtstyle"
                                        AutoPostBack="true" OnTextChanged="txtOETEmpEnroll_TextChanged"></asp:TextBox></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label29" Text="Emp. Name : "></asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtOETEmpName" CssClass="txtstyle"></asp:TextBox></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" ID="Label30" Text="Date : "></asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOETDate" CssClass="txtstyle"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender3" TargetControlID="txtOETDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="tdstyle-btn"><asp:Button runat="server" ID="btnOETUpdate" Text="Update" CssClass="btnstyle-sm" OnClientClick="Confirm()" OnClick="btnOETUpdate_Click" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View runat="server" ID="vwOldEmpResign">
                            <table class="tablestyle" style="width:80%">
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle">Designation : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOERDesignation" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOERDesignation_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle">Channel : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOERChannel" CssClass="ddlstyle"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Region : </asp:Label></td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlOERRegion" CssClass="ddlstyle"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlOERRegion_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Area : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOERArea" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOERArea_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Territory : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOERTerritory" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOERTerritory_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Point : </asp:Label></td>
                                    <td><asp:DropDownList runat="server" ID="ddlOERPoint" CssClass="ddlstyle"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlOERPoint_SelectedIndexChanged"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Employee Enroll : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOEREmployeeEnroll" CssClass="txtstyle" Height="22px" 
                                        AutoPostBack="true" OnTextChanged="txtOEREmployeeEnroll_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Employee Name : </asp:Label></td>
                                    <td><asp:TextBox runat="server" ID="txtOEREmployeeName" CssClass="txtstyle" Height="22px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label runat="server" CssClass="lblstyle"> Date : </asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtOERDate" CssClass="txtstyle" Height="22px"></asp:TextBox>
                                        <cc1:CalendarExtender runat="server" ID="CalendarExtender4" TargetControlID="txtOERDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdstyle-btn"><asp:Button runat="server" ID="btnOERUpdate" Text="Update" CssClass="btnstyle-sm" OnClientClick="Confirm()" OnClick="btnOERUpdate_Click" /></td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script>
        function Confirm() {
            document.getElementById("hfConfirm").value = "0";
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?"))
            {
                confirm_value.value = "Yes";
                document.getElementById("hfConfirm").value = "1";
            }
            else
            {
                confirm_value.value = "No";
                document.getElementById("hfConfirm").value = "0";
            }
        }
    </script>
    
</body>
</html>
