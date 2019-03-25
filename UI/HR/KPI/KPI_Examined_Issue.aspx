<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KPI_Examined_Issue.aspx.cs" Inherits="UI.HR.KPI.KPI_Examined_Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <script src="../../Content/JS/datepickr.min.js"></script>
    <script src="../../Content/JS/JSSettlement.js"></script>
    <link href="jquery-ui.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>


    <script type="text/javascript">
        $("[id*=chkHeader]").live("click", function () {
            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
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


        $(function () {
            $("[id*=TxtRegMarks]").val("0");
        });

        $("[id*=TxtRegMarks]").live("change", function () {
            if (isNaN(parseFloat($(this).val()))) {
                $(this).val('0');
            } else { $(this).val(parseFloat($(this).val()).toString()); }
        });

        $("[id*=TxtRegMarks]").live("keyup", function () {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    //$(this).val('0');
                    // $("[id*=lblGrade]", row).html('A');

                    if (parseFloat($(this).val()) > 100) { $("[id*=TxtRegMarks]", row).val('0'); alert("Out of 100"); }




                }
            }


        });




    </script>
    <script type="text/javascript">
        function OpenHdnDiv() {
            $("#hdnDivision").fadeIn("slow");
            document.getElementById('hdnDivision').style.visibility = 'visible';
        }

        function ClosehdnDivision() {

            $("#hdnDivision").fadeOut("slow");
        }
    </script>
    <style type="text/css">
        .rounds {
            height: 80px;
            width: 30px;
            -moz-border-colors: 25px;
            border-radius: 25px;
        }


        .HyperLinkButtonStyle {
            float: right;
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
            width: 8%;
            height: 20%;
            margin-left: 530px;
            margin-top: 00px;
            margin-right: 00px;
            padding: 15px;
            overflow-y: scroll;
        }
    </style>

    <script>
        function Save() {
            document.getElementById("hdnField").value = "1";
            __doPostBack();
        }

    </script>



    <style type="text/css">
        .leaveApplication_container {
            margin-top: 0px;
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
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>






                <%--=========================================Start My Code From Here===============================================--%>
                <asp:HiddenField ID="hdnEnroll" runat="server" />
                <asp:HiddenField ID="hdnsearch" runat="server" />
                <asp:HiddenField ID="hdnEnrollUnit" runat="server" />
                <asp:HiddenField ID="hdnUnitIDByddl" runat="server" />
                <asp:HiddenField ID="hdnBankID" runat="server" />
                <asp:HiddenField ID="hfEmployeeIdp" runat="server" />
                <asp:HiddenField ID="hdnwh" runat="server" />
                <asp:HiddenField ID="HdnServiceCost" runat="server" />
                <asp:HiddenField ID="hdnRepairsCost" runat="server" />
                <div class="leaveApplication_container">

                    <div class="tabs_container" align="Center">Employee Performance Assessment Examine by Supervisor</div>

                    <table class="tbldecoration">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="Lblstatus" runat="server" CssClass="lbl" Font-Bold="true"></asp:Label>
                            </td>
                    </table>

                    <table class="tbldecoration">
                        <tr>
                            <td style="text-align: right;">
                                <asp:Label ID="LblDtePO" runat="server" CssClass="lbl" Font-Bold="true" Text="Evaluation Month"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TxtDte" runat="server" AutoPostBack="true" CssClass="txtBox" Font-Bold="true" OnTextChanged="TxtDte_TextChanged"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderMonthly" runat="server" Format="yyyy-MMMM" TargetControlID="TxtDte">
                                </cc1:CalendarExtender>
                            </td>
                            <td style="text-align: right;">
                                <asp:Button ID="btiView" runat="server" BackColor="YellowGreen" OnClick="btiView_Click" Text="View" />
                                <asp:Button ID="BtnEmp" runat="server" BackColor="YellowGreen" OnClick="BtnEmp_Click" Text="Submit" />
                            </td>
                        </tr>
                    </table>
                    <table class="tbldecoration">

                        <tr class="tblroweven">
                            <td>
                                <asp:Label ID="lblTask" runat="server" Text="Assignment Assessment: " Font-Size="small" Font-Bold="true"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="dgvGridView" runat="server" Font-Size="13px" BackColor="White" AutoGenerateColumns="False">
                                    <Columns>


                                        <asp:TemplateField HeaderText="SL.N">
                                            <HeaderTemplate>

                                                <asp:TextBox ID="TxtServiceConfg" runat="server" Width="70" placeholder="Search" onkeyup="Search_dgvservice(this, 'dgvGridView')"></asp:TextBox>


                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TaskID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskID" runat="server" Text='<%# Bind("intTaskID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="EmpID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEnrolment" runat="server" Text='<%# Bind("intAssignTo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task Title" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTitle" runat="server" Text='<%# Bind("strTaskTitle") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="140px" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="strPriority" HeaderText="Priority" SortExpression="strPriority" />
                                        <asp:BoundField DataField="strRemarks" HeaderText="Remarks" SortExpression="strRemarks">
                                            <ItemStyle HorizontalAlign="right" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dteComplete" HeaderText="CompleteDate" SortExpression="dteComplete" />

                                        <asp:TemplateField HeaderText="Proposed Marks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMarks" runat="server" Text='<%# Bind("intPropostMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approved Marks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExamineMarks" runat="server" Text='<%# Bind("intApproveMarks") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="45px" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="strGrade" HeaderText="Grade" SortExpression="strGrade" />

                                    </Columns>
                                </asp:GridView>

                            </td>


                        </tr>
                    </table>

                    <table class="tbldecoration">

                        <tr class="tblroweven">
                            <td>
                                <asp:Label ID="lblJdcs" runat="server" Font-Size="Small" Font-Bold="true" Text="Routine Dscription Assessment"></asp:Label></td>
                        </tr>

                        <tr>
                            <td>
                                <asp:GridView ID="DgvRegular" runat="server" Font-Size="13px" BackColor="White" AutoGenerateColumns="False">
                                    <Columns>


                                        <asp:TemplateField HeaderText="SL.N">

                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmpID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJDC" runat="server" Text='<%# Bind("intAutoID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("strDescription") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="240px" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Marks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtRegMarks" runat="server" Text='<%# Bind("decMarks") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="45px" />
                                        </asp:TemplateField>



                                    </Columns>
                                </asp:GridView>

                            </td>


                        </tr>
                    </table>

                    <table class="tbldecoration">

                        <tr class="tblroweven">
                            <td>
                                <asp:Label ID="lblBehaviors" Font-Size="Small" Font-Bold="true" runat="server" Text="Behavior Assessment Of competencies :"></asp:Label></td>
                        </tr>

                        <tr>

                            <td>
                                <asp:GridView ID="dgvBehavior" Font-Size="13px" BackColor="White" runat="server" AutoGenerateColumns="False">
                                    <Columns>


                                        <asp:TemplateField HeaderText="SL.N">

                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmpID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBID" runat="server" Text='<%# Bind("intID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Behavior" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBehavior" runat="server" Text='<%# Bind("strBehavior") %>'></asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="140px" />
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Marks">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtBehaviorMarks" runat="server" ReadOnly="true" Width="50" Text='<%# Bind("decMarks") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total marks :  100">
                                            <ItemTemplate>
                                                <asp:RadioButtonList ID="rdograding" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" Font-Size="10px" Font-Bold="false" OnSelectedIndexChanged="rdograding_SelectedIndexChanged">
                                                    <asp:ListItem Text="EXCELENT (10)" Value="10"></asp:ListItem>
                                                    <asp:ListItem Text="Very GOOD (8)" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="GOOD (6)" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="SATISFACTORY (4)" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="UNSATISFACTORY (0)" Value="0"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                </asp:GridView>

                            </td>


                        </tr>
                        <tr class="tblrowodd">
                            <td style="font: bold 12px verdana; background-color: yellow; text-align: right; padding-right: 25px;">
                                <asp:Label ID="lblrcd" runat="server"></asp:Label>
                                <asp:Label ID="lblgrdTotal" runat="server"></asp:Label></td>
                        </tr>

                    </table>
                </div>
                <div id="hdnDivision" class="hdnDivision" style="width: auto;">
                    <table style="width: auto; float: left;">
                        <tr>
                            <td></td>
                        </tr>
                        <tr class="tblrowodd">

                            <td style="text-align: right;">
                                <asp:Label ID="lbldoc" CssClass="lbl" runat="server" Text="Task Weight : "></asp:Label></td>

                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTaskWeight" Width="100" TextMode="Number" Text="0" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr class="tblrowodd">

                            <td style="text-align: right;">
                                <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="JobDescription Weight : "></asp:Label></td>

                            <td style="text-align: left;">
                                <asp:TextBox ID="txtJdWight" Width="100" Text="0" runat="server"></asp:TextBox></td>
                        </tr>

                        <tr class="tblrowodd">
                            <td></td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnSaves" runat="server" BackColor="GreenYellow" OnClick="BtnSubmit_Click" Text="Submit" />
                                <asp:Button ID="btnCancel" runat="server" BackColor="GreenYellow" Text="Cancel" /></td>

                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </table>
                </div>



                <%--=========================================End My Code From Here=================================================--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

