<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WHLocationTransfer.aspx.cs" Inherits="UI.SCM.WHLocationTransfer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/CommonStyle.css" rel="stylesheet" />
    <script type="text/javascript">
        function Search_dgvservice(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }

        }
    </script>
    <script type="text/javascript">
        function funConfirmAll() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden"; confirm_value.name = "confirm_value";
            if (confirm("Do you want to proceed?")) {
                confirm_value.value = "Yes";
                document.getElementById("hdnConfirm").value = "1";
                showLoader();
            }
            else {
                confirm_value.value = "No";
                document.getElementById("hdnConfirm").value = "0";
            }
        }
    </script>
    <script type="text/javascript">

        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });
    </script>
    <style type="text/css">
        .rounds {
            height: 50px;
            width: 50px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }

        .HyperLinkButtonStyle {
            float: left;
            text-align: left;
            border: none;
            background: none;
            color: blue;
            text-decoration: underline;
            font: normal 10px verdana;
        }

        .hdnDivision {
            background-color: #EFEFEF;
            position: absolute;
            z-index: 1;
            visibility: hidden;
            border: 10px double black;
            text-align: center;
            width: 10%;
            height: 10%;
            margin-left: auto;
            margin-right: auto;
            padding: 20px;
            overflow-y: scroll;
        }
    </style>
    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
            background: white;
        }

        .ddList {
        }

        .txtBox {
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
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                </asp:Panel>
                <div style="height: 30px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>
                <%--=========================================Start My Code From Here===============================================--%>
                <td>
                    <asp:HiddenField ID="hdn1" runat="server" />
                    <asp:HiddenField ID="hdn2" runat="server" />
                    <asp:HiddenField ID="hdn3" runat="server" />
                    <asp:HiddenField ID="hdn4" runat="server" />
                    <asp:HiddenField ID="hdn5" runat="server" />
                    <asp:HiddenField ID="hdn6" runat="server" />
                    <asp:HiddenField ID="hdn7" runat="server" />
                    <asp:HiddenField ID="hdn8" runat="server" />
                    <asp:HiddenField ID="hdn9" runat="server" />
                    <asp:HiddenField ID="hdn10" runat="server" />
                    <asp:HiddenField ID="hdnOpID" runat="server" />
                    <asp:HiddenField ID="hdnOpName" runat="server" />
                    <asp:HiddenField ID="hdnConfirm" runat="server" />
                    <div class="tabs_container" align="left">WH Location Create Form </div>
                    <div class="leaveApplication_container">
                        <table style="width: 700px; outline-color: blue; table-layout: auto; vertical-align: top">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:Label ID="Label1" CssClass="lbl" runat="server" Font-Bold="true" Text="WH Name : "></asp:Label>
                                    <asp:DropDownList ID="ddlWH" runat="server" AutoPostBack="True" CssClass="ddList" Font-Bold="true" OnSelectedIndexChanged="ddlWH_SelectedIndexChanged"></asp:DropDownList>
                                </td>

                                <td>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="funConfirmAll()" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="Small" OnCommand="LinkButton1_Click" Text="0"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" Font-Size="Small" OnCommand="LinkButton2_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" Font-Size="Small" OnCommand="LinkButton3_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" Font-Size="Small" OnCommand="LinkButton4_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton5" runat="server" Font-Size="Small" OnCommand="LinkButton5_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton6" runat="server" Font-Size="Small" OnCommand="LinkButton6_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton7" runat="server" Font-Size="Small" OnCommand="LinkButton7_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton8" runat="server" Font-Size="Small" OnCommand="LinkButton8_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton9" runat="server" Font-Size="Small" OnCommand="LinkButton9_Click" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton10" runat="server" Font-Size="Small" OnCommand="LinkButton10_Click"></asp:LinkButton>
                                </td>
                            </tr>

                        </table>
                        <table>
                            <tr class="tblrowodd">
                                <td>WH/Location-:</td>
                                <td>
                                    <asp:ListBox ID="ListBox1" runat="server" Width="500px" Height="150px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox></td>
                            </tr>
                        </table>
                        <table>
                            <div class="tabs_container">WH Location Summary : </div>
                            <div class="leaveSummary_container">



                                <asp:GridView ID="dgvWHLocation" runat="server" AutoGenerateColumns="False" Font-Size="11px" BackColor="White" BorderStyle="Solid"
                                    BorderWidth="0px" CellPadding="1" ForeColor="Black" GridLines="Vertical" PageSize="25">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <HeaderTemplate>

                                                <asp:TextBox ID="TxtServiceConfg" runat="server" Width="70" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvWHLocation')"></asp:TextBox>
                                            </HeaderTemplate>
                                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location Id" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Location Name" Visible="true">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocName" runat="server" Text='<%# Bind("strName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:GridView>
                        </table>
                    </div>
                    </div> 
           
          
         
            
                    <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
