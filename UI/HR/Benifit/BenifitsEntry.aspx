<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BenifitsEntry.aspx.cs" Inherits="UI.HR.Benifit.BenifitsEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
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
    <link href="../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function CheckRow(objRef) {

            var row = objRef.parentNode.parentNode;
            //var oldcolor = row.style.backgroundColor;
            if (objRef.checked) {

                row.style.backgroundColor = "#acf0f9";
            }
            else {

                row.style.backgroundColor = "white";
            }

            var GridView = row.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {

                var headerCheckBox = inputList[0];
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }
        function checkAllRow(objRef) {
        }

        function check() {
            var date = document.getElementById("txtDate").value;
            if (date == null || date == "") {
                alert("Date cannot be blank.");
            }
            else {
                var confirm_value = document.createElement("input");

                confirm_value.type = "hidden";
                confirm_value.name = "Confirm_value";
                if (confirm("Do you want to proceed?")) {
                    confirm.value = "Yes";
                    document.getElementById("hdnConfirm").value = "1";
                }
                else {
                    confirm.value = "No";
                    document.getElementById("hdnConfirm").value = "0";
                }
            }




        }
    </script>

    <style type="text/css">
        .CellWidth {
            width: 80px;
        }

        .auto-style1 {
            height: 41px;
        }

        .auto-style2 {
            height: 5px;
        }

        .auto-style4 {
            width: 138px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server" enctype="MULTIPART/FORM-DATA">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
       <%-- <asp:UpdatePanel ID="UpdatePanel0" runat="server">--%>
            <%--<ContentTemplate>--%>
                <%--<asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                        <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%">
                        <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee>
                    </div>
                    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div>
                </asp:Panel>
                <div style="height: 100px;"></div>
                <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server">
                </cc1:AlwaysVisibleControlExtender>--%>

                <%--=========== Start Code =====================================================================--%>


                <%--<div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Employee Benifits Entry :" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>--%>
                <asp:HiddenField ID="hdnConfirm" runat="server" />
                <div class="leaveApplication_container">
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr class="tblheader">
                            <td class="tdheader" colspan="5">Employee Benifits Entry :</td>
                        </tr>


                        <tr>
                            <td colspan="4" class="auto-style2"></td>
                        </tr>
                        <tr>
                            <%--<td class="" style="text-align: right;">
                                <asp:Label ID="lblD" runat="server" Text="Download Excel Format:" CssClass="lbl"></asp:Label>
                                
                            </td>--%>
                            <td colspan="2">
                                <asp:Button ID="btnDownload" runat="server" class="myButton" Text="Download Excel Format" OnClick="btnDownload_Click" /></td>


                            <td class="auto-style4" style="text-align: right;">
                                <%--<asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Employee ID: " Visible="false"></asp:Label>--%>
                            </td>
                            <td class="tdheight">
                                <%--<asp:TextBox ID="txtEmp" runat="server" CssClass="txtBox1" Visible="false"></asp:TextBox>--%>
                            </td>
                            <td class="" style="text-align: right;">
                                <%--<asp:Button ID="btnShow" runat="server" Visible="false" class="myButton" Text="Show" Width="100px" OnClientClick="" OnClick="btnShow_Click" />--%></td>
                        </tr>
                        <%-- <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>--%>
                        <tr>

                            <td class="" style="text-align: right;">
                                <%--<asp:Label ID="Label11" CssClass="lbl" runat="server" Text="Date : "></asp:Label>--%>
                                <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Job Station : "></asp:Label>
                            </td>
                            <td class="">
                                <%--<asp:TextBox ID="txtDate" runat="server" CssClass="txtBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"></cc1:CalendarExtender>--%>
                                <asp:DropDownList ID="ddlJobStation" runat="server" CssClass="ddList" Font-Bold="False" Font-Size="11px" ForeColor="Black" Height="24px">
                                </asp:DropDownList>
                            </td>

                            <td style="text-align: right;" class="auto-style4">
                                <%--<asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Amount : "></asp:Label>--%>
                                <asp:Label ID="Label11" runat="server" CssClass="lbl" Text="Date : "></asp:Label>
                            </td>
                            <td class="tdheight">
                                <%--<asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox1" Visible="false"></asp:TextBox>--%>
                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtBox1"></asp:TextBox>
                                <cc1:CalendarExtender ID="reqDate" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td class="auto-style1">
                                <%--<asp:Button ID="btnSubmit" runat="server" class="myButton" Visible="false" Text="Submit" Width="100px" OnClientClick="check()" OnClick="btnSubmit_Click" />--%></td>

                        </tr>
                        <tr>
                            <td class="" style="text-align: right;">
                                <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="Import Excel File : "></asp:Label></td>
                            <td class="tdheight">
                                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload></td>
                            <td class="auto-style1">
                                <asp:Button ID="btnUpload" runat="server" class="myButton" Text="Upload" Width="100px" OnClick="btnUpload_Click" /></td>
                            <td class="auto-style1">
                                <asp:Button ID="btnSubmitExcel" runat="server" class="myButton" Text="Submit" Width="100px" OnClientClick="check()" OnClick="btnSubmitExcel_Click" /></td>
                        </tr>

                    </table>

                </div>

                <div id="divItemInfo" runat="server" class="leaveApplication_container">
                    <table class="tbldecoration" style="width: auto; float: left;">
                        <tr>
                            <td>
                                <asp:GridView ID="dgvEmployeeInfo" runat="server" AutoGenerateColumns="False" PageSize="10"
                                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="false"
                                    FooterStyle-BackColor="#808080" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" DataKeyNames="intEmployeeID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="2px" CellPadding="4">
                                    <AlternatingRowStyle />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SL">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="intEmployeeID" HeaderText="Employee ID" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeID">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="strEmployeeName" HeaderText="Employee Name" SortExpression="strEmployeeName">
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strDesignation" HeaderText="Designation" SortExpression="strDesignation">
                                            <ItemStyle HorizontalAlign="left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="strDepatrment" HeaderText="Department" SortExpression="strDepatrment">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAllRow(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" onclick="CheckRow(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                    </Columns>
                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                    <SortedDescendingHeaderStyle BackColor="#002876" />
                                </asp:GridView>
                                <asp:GridView ID="gvExcelFile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>

                <%--=========== End Code =====================================================================--%>
           <%-- </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
                <asp:PostBackTrigger ControlID="btnDownload" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>

