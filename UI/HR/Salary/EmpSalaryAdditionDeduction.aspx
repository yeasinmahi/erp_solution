<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpSalaryAdditionDeduction.aspx.cs" Inherits="UI.HR.Salary.EmpSalaryAdditionDeduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
</head>
<body>
    <form id="form1" runat="server" enctype="MULTIPART/FORM-DATA">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>


        <%--=========== Start Code =====================================================================--%>


        <%--<div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Employee Benifits Entry :" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>--%>
        <asp:HiddenField ID="hdnConfirm" runat="server" />
        <div class="leaveApplication_container">
            <table class="tbldecoration" style="width: auto; float: left;">
                <tr class="tblheader">
                    <td class="tdheader" colspan="5">Employee Salary Addition Deduction :</td>
                </tr>
                <tr>
                    <td colspan="4" class="auto-style2"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnDownload" runat="server" class="myButton" Text="Download Excel Format" OnClick="btnDownload_Click" /></td>
                    <td class="auto-style4" style="text-align: right;">
                        <%--<asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Employee ID: " Visible="false"></asp:Label>--%>
                    </td>
                    <td class="tdheight">
                        <%--<asp:TextBox ID="txtEmp" runat="server" CssClass="txtBox1" Visible="false"></asp:TextBox>--%>
                    </td>
                </tr>
                <%-- <tr>
                            <td colspan="4" style="height: 5px;"></td>
                        </tr>--%>
                <tr>

                    <td class="" style="text-align: right;">
                        <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Type : "></asp:Label>
                    </td>
                    <td class="">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="ddList" Font-Bold="False" Font-Size="11px" ForeColor="Black" Height="24px">
                        </asp:DropDownList>
                    </td>

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
                <tr>
                    <td colspan="4">
                        <div id="divItemInfo" runat="server" class="leaveApplication_container">
                            <table class="tbldecoration" style="width: auto; float: left;">
                                <tr>
                                    <td>
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
                    </td>
                </tr>

            </table>

        </div>



        <%--=========== End Code =====================================================================--%>
    </form>
</body>
</html>
