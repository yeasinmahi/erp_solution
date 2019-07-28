<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpSalaryAdditionDeduction.aspx.cs" Inherits="UI.HR.Salary.EmpSalaryAdditionDeduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/updatedJs") %></asp:PlaceHolder>
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/updatedCss" />
    <script>
        function check() {

            var confirm_value = document.createElement("input");

            if (document.getElementById('<%=ddlType.ClientID%>').selectedIndex == 0) {
                ShowNotification('Please Select Type', 'Product Cost Sheet', 'warning');
                return false;
            }
            else {
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

                return true;
            }

            return true;

        }
    </script>
    <style>
        
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="MULTIPART/FORM-DATA">
        <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>


        <%--=========== Start Code =====================================================================--%>

        <asp:HiddenField ID="hdnConfirm" runat="server" />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <asp:Label runat="server" Text="Employee Salary Addition Deduction" Font-Bold="true" Font-Size="16px"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" Text="Download Excel Format" OnClick="btnDownload_Click" />
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Type:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control col-md-12 col-sm-12 col-xs-12"></asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Import Excel File:" CssClass="row col-md-12 col-sm-12 col-xs-12"></asp:Label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass=""></asp:FileUpload>
                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-12">
                                    <asp:Button ID="btnUpload" runat="server" class="btn btn-primary form-control" Text="Upload" OnClick="btnUpload_Click" />
                                    <asp:Button ID="btnSubmitExcel" runat="server" class="btn btn-success form-control" OnClientClick="return check();" Text="Submit" OnClick="btnSubmitExcel_Click" />

                                </div>
                            </div>
                            <div class="row form-group">
                                <div class="col-md-12" style="padding-top: 20px;">
                                    <asp:GridView ID="gvExcelFile" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">

                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("intEmployeeID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("strEmployeeName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesig" runat="server" Text='<%# Bind("strDesignation") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("strUnit") %>' ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBank" runat="server" Text='<%# Bind("strDepatrment") %>' ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left"  />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount","{0:N2}" )%>' ></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right"  />
                                            </asp:TemplateField>
                                        </Columns>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <%--=========== End Code =====================================================================--%>
    </form>
</body>
</html>
