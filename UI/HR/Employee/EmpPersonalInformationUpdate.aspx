<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpPersonalInformationUpdate.aspx.cs" Inherits="UI.HR.Employee.EmpPersonalInformationUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/CSS/MyStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="../../Content/JS/EmpPersonalInformationUpdate.js"></script>

    <style type="text/css">
        /*.auto-style5 {
            height: 40px;
        }*/
        
        .auto-style6 {
            height: 38px;
        }
        .auto-style7 {
            height: 40px;
        }
        
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
                    <table style="width: 600px; outline-color: blue; table-layout: auto; vertical-align: top; background-color: #DDD;" class="tblrowodd">
                        <tr class="tblrowodd">
                            <%--#45546d;--%>
                            <tr><td style="text-align:center; font:25px bold;" colspan="4">Update Employee Information</td></tr>
                            <tr>
                                <td style="text-align: right;">
                                    <asp:Label ID="LblEmployee" runat="server" CssClass="lbl" Font-Size="small" Text="Search Employee:"></asp:Label>
                                </td>
                                <td colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="TxtEmployee" runat="server" AutoPostBack="true" CssClass="txtBoxSearch txtBox" Font-Bold="False" OnTextChanged="TxtEmployee_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="1" CompletionListCssClass="autocomplete_completionListElementBig" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listItem" CompletionSetCount="1" EnableCaching="false" FirstRowSelected="true" MinimumPrefixLength="1" ServiceMethod="GetWearHouseRequesision" TargetControlID="TxtEmployee">
                                    </cc1:AutoCompleteExtender>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="LblName" runat="server" CssClass="lbl" Font-Size="small" Text="Name:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtName" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="LblDesignation" runat="server" CssClass="lbl" Font-Size="small" Text="Designation:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtDesignation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td style="text-align: right;">
                                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Font-Size="small" Text="Department:"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="TxtDepartment" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Font-Size="small" Text="Date of Join:"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="TxtDateOfJoin" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="Label3" runat="server" CssClass="lbl" Font-Size="small" Text="Unit Name:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtUnit" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Font-Size="small" Text="Job Station:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtJobStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <%-- <div>
                            <caption>
                                <hr style="border: 1px solid #8c8b8b;"></hr>
                            </caption>
                        </div>--%>
                            <tr class="tblrowodd">
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Font-Size="small" Text="Father's Name:"></asp:Label>
                                </td>
                                <td class="auto-style5" style="text-align: left;">
                                    <asp:TextBox ID="TxtFather" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Font-Size="small" Text="Mother's Name:"></asp:Label>
                                </td>
                                <td class="auto-style5" style="text-align: left;">
                                    <asp:TextBox ID="TxtMother" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="LblSpouse" runat="server" CssClass="lbl" Font-Size="Small" Text="Spouse Name:"></asp:Label>
                                </td>
                                <td class="auto-style5" colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="TxtSpouse" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td colspan="4">
                                    <h4 style="text-decoration: underline;"><span>Permanent Address</span></h4>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Font-Size="small" Text="Village:"></asp:Label>
                                </td>
                                <td class="auto-style5" style="text-align: left;">
                                    <asp:TextBox ID="TxtVillage" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label8" runat="server" CssClass="lbl" Font-Size="small" Text="Post Office:"></asp:Label>
                                </td>
                                <td class="auto-style5" style="text-align: left;">
                                    <asp:TextBox ID="TxtPermanentPostOffice" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td style="text-align: right;">
                                    <asp:Label ID="Label9" runat="server" CssClass="lbl" Font-Size="small" Text="Police Station:"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="TxtPermanentPoliceStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label10" runat="server" CssClass="lbl" Font-Size="small" Text="District:"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="TxtPermanentDistricts" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td colspan="4">
                                    <h4 style="text-decoration: underline;"><span>Present Address</span> </h4>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label11" runat="server" CssClass="lbl" Font-Size="small" Text="House:"></asp:Label>
                                </td>
                                <td class="auto-style6" style="text-align: left;">
                                    <asp:TextBox ID="TxtHouse" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label12" runat="server" CssClass="lbl" Font-Size="small" Text="Road No:"></asp:Label>
                                </td>
                                <td class="auto-style5" style="text-align: left;">
                                    <asp:TextBox ID="TxtRoad" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="Label13" runat="server" CssClass="lbl" Font-Size="small" Text="Post Office:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtPresentPostOffice" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td class="auto-style7" style="text-align: right;">
                                    <asp:Label ID="Label14" runat="server" CssClass="lbl" Font-Size="small" Text="Police Station:"></asp:Label>
                                </td>
                                <td class="auto-style7" style="text-align: left;">
                                    <asp:TextBox ID="TxtPresentPoliceStation" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowodd">
                                <td class="auto-style5" style="text-align: right;">
                                    <asp:Label ID="Label15" runat="server" CssClass="lbl" Font-Size="small" Text="District:"></asp:Label>
                                </td>
                                <td class="auto-style5" colspan="3" style="text-align: left;">
                                    <asp:TextBox ID="TxtPresentDistricts" runat="server" CssClass="txtBox" Font-Bold="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="tblrowfooter">
                                <td colspan="4" style="text-align: right;">
                                    <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-default" OnClick="BtnUpdate_Click" OnClientClick="return Confirm();" Text="Update" />
                                </td>
                            </tr>

                        </tr>
                        
                    </table>
                    <div style="width:300px; padding-top:30px;">
                         <asp:GridView ID="GVPersonalInfoUpdateList" runat="server" CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2">
                             <FooterStyle BackColor="#CCCCCC" />
                             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                             <RowStyle BackColor="White" />
                             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                             <SortedAscendingCellStyle BackColor="#F1F1F1" />
                             <SortedAscendingHeaderStyle BackColor="#808080" />
                             <SortedDescendingCellStyle BackColor="#CAC9C9" />
                             <SortedDescendingHeaderStyle BackColor="#383838" />
                         </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
