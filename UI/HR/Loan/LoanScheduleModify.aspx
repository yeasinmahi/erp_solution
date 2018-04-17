<%@ Page Language="C#" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="UI.HR.Loan.LoanScheduleModify" Codebehind="LoanScheduleModify.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html >
<head runat="server">
    <title>Update Loan Schedule</title>
     <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />   
    <webopt:BundleReference ID="BundleReference1" runat="server" Path="~/Content/Bundle/gridCalanderCSS" />  
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
   
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">     
          <%: Scripts.Render("~/Content/Bundle/jqueryJS") %>
    </asp:PlaceHolder>  
    
     
   



    <script type="text/javascript">
        $(document).ready(function () {
            SearchText();
        });
        function SearchText() {
            $("#txtSearchEmployee").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "LoanScheduleModify.aspx/GetAutoCompleteData",
                        data: "{'strSearchKey':'" + document.getElementById('txtSearchEmployee').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (result) {
                            alert("Error");
                        }
                    });
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpperControl" runat="server" Width="100%">
                <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;">
                    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2"
                        scrolldelay="-1" width="100%">
                    	<span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span>
                	</marquee>
                </div>
                <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">
                    <br />
                    <br />
                    <br />
                    <table width="100%">
                        <tr style="text-align: center">
                            <td>
                                <b>Update Loan Schedule</b>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <div style="height: 100px;">
            </div>
            <ajaxToolkit:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1"
                runat="server">
            </ajaxToolkit:AlwaysVisibleControlExtender>
            <div>
                <table>
                    <tr>
                        <td style="width: 645px;">
                            <div>
                                <table>
                                    <tr style="text-align: left">
                                        <td style="width: 100px">
                                            <asp:Label ID="Label6" runat="server" CssClass="label" Text="Search Employee"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSearchEmployee"  runat="server" AutoPostBack="true"
                                                Width="250px" Height="20px"></asp:TextBox>
                                            <ajaxToolkit:TextBoxWatermarkExtender ID="TBWE2" runat="server" TargetControlID="txtSearchEmployee"
                                                WatermarkText="Type Name / Code Here" WatermarkCssClass="watermarked" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="btnSearch" Width="30px" Height="30px" ImageUrl="../../Images/Search.jpg"
                                                runat="server" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 480px; vertical-align: top">
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="dgvUpdateLoanSchedule" DataKeyNames="intLoanApplicationId,intScheduleId"
                                                runat="server" AutoGenerateColumns="false" CssClass="grid" HeaderStyle-BackColor="#61A6F8"
                                                ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                OnRowCancelingEdit="dgvUpdateLoanSchedule_RowCancelingEdit" OnRowEditing="dgvUpdateLoanSchedule_RowEditing"
                                                OnRowUpdating="dgvUpdateLoanSchedule_RowUpdating" OnRowCommand="dgvUpdateLoanSchedule_RowCommand"
                                                OnRowDataBound="dgvUpdateLoanSchedule_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <EditItemTemplate>
                                                            <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="../../Images/update.jpg"
                                                                ToolTip="Update" Height="20px" Width="20px" />
                                                            <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="../../Images/Cancel.jpg"
                                                                ToolTip="Cancel" Height="20px" Width="20px" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'
                                                                runat="server" ImageUrl="../../Images/Edit.jpg" ToolTip="Edit" Height="20px"
                                                                Width="20px" />
                                                            <%--<asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                                                ImageUrl="../../Images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />--%>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="../../Images/AddNewitem.jpg"
                                                                CommandName="AddNew" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>'
                                                                Width="30px" Height="30px" ToolTip="Add new User" ValidationGroup="validaiton" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Installment">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtInstallmentAmount" Width="100px" runat="server" Text='<%#Eval("intInstallmentAmount") %>' />
                                                            <asp:RequiredFieldValidator ID="rfvtxtInstallmentAmount" runat="server" ControlToValidate="txtInstallmentAmount"
                                                                Text="*" ValidationGroup="validaiton" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtInstallmentAmount" runat="server"
                                                                FilterType="Custom, Numbers" TargetControlID="txtInstallmentAmount" ValidChars="123456789.">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInstallmentAmount" runat="server" Text='<%#Eval("intInstallmentAmount") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtftrInstallmentAmount" Width="100px" runat="server" />
                                                            <asp:RequiredFieldValidator ID="rfvInstallmentAmount" runat="server" ControlToValidate="txtftrInstallmentAmount"
                                                                Text="*" ValidationGroup="validaiton" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender" runat="server"
                                                                FilterType="Custom, Numbers" TargetControlID="txtftrInstallmentAmount" ValidChars="123456789.">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:HiddenField ID="hdnLoanScheduleId" runat="server" Value='<%# Bind("intScheduleId") %>' />
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Month">
                                                        <EditItemTemplate>
                                                            <%--<asp:DropDownList ID="ddlMonth" runat="server" Width="90px" CssClass="DropDown">
                                                                <asp:ListItem Value="1" Text="January" />
                                                                <asp:ListItem Value="2" Text="February" />
                                                                <asp:ListItem Value="3" Text="March" />
                                                                <asp:ListItem Value="4" Text="Appril" />
                                                                <asp:ListItem Value="5" Text="May" />
                                                                <asp:ListItem Value="6" Text="June" />
                                                                <asp:ListItem Value="7" Text="July" />
                                                                <asp:ListItem Value="8" Text="August" />
                                                                <asp:ListItem Value="9" Text="September" />
                                                                <asp:ListItem Value="10" Text="October" />
                                                                <asp:ListItem Value="11" Text="November" />
                                                                <asp:ListItem Value="12" Text="December" />
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvddlftrMonth" runat="server" ControlToValidate="ddlMonth"
                                                                Text="*" ValidationGroup="validaiton" />--%>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("strMonth") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("strMonth") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:DropDownList ID="ddlftrMonth" runat="server" Width="90px" CssClass="DropDown">
                                                                <asp:ListItem Value="1" Text="January" />
                                                                <asp:ListItem Value="2" Text="February" />
                                                                <asp:ListItem Value="3" Text="March" />
                                                                <asp:ListItem Value="4" Text="Appril" />
                                                                <asp:ListItem Value="5" Text="May" />
                                                                <asp:ListItem Value="6" Text="June" />
                                                                <asp:ListItem Value="7" Text="July" />
                                                                <asp:ListItem Value="8" Text="August" />
                                                                <asp:ListItem Value="9" Text="September" />
                                                                <asp:ListItem Value="10" Text="October" />
                                                                <asp:ListItem Value="11" Text="November" />
                                                                <asp:ListItem Value="12" Text="December" />
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvddlftrMonth" runat="server" ControlToValidate="ddlftrMonth"
                                                                Text="*" ValidationGroup="validaiton" />
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="110px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year">
                                                        <EditItemTemplate>
                                                            <%--<asp:TextBox ID="txtYear" Width="80px" runat="server" Text='<%#Eval("intYear") %>' />
                                                            <asp:RequiredFieldValidator ID="rfvYear" runat="server" ControlToValidate="txtYear"
                                                                Text="*" ValidationGroup="validaiton" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtYear" runat="server" FilterType="Custom, Numbers"
                                                                TargetControlID="txtYear" ValidChars="123456789.">
                                                            </ajaxToolkit:FilteredTextBoxExtender>--%>
                                                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("intYear") %>' />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("intYear") %>' />
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtftrYear" Width="80px" runat="server" />
                                                            <asp:RequiredFieldValidator ID="rfvftrYear" runat="server" ControlToValidate="txtftrYear"
                                                                Text="*" ValidationGroup="validaiton" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtftrYear" runat="server" FilterType="Custom, Numbers"
                                                                TargetControlID="txtftrYear" ValidChars="123456789.">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </FooterTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <tr style="background-color: Green;">
                                                        <th scope="col" style="width: 50px">
                                                        </th>
                                                        <th scope="col" style="width: 100px">
                                                            Installment
                                                        </th>
                                                        <th scope="col" style="width: 110px">
                                                            Month
                                                        </th>
                                                        <th scope="col" style="width: 100px">
                                                            Year
                                                        </th>
                                                    </tr>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                        <td style="width: 320px; vertical-align: top">
                            <fieldset>
                                <legend>Personal Information:</legend>
                                <div>
                                    <table>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label5" runat="server" Text="Name" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtName" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label12" runat="server" Text="Unit" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtUnit" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label13" runat="server" Text="Department" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="txt" Width="200px" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label14" runat="server" Text="Designation" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtDesignation" CssClass="txt" Width="200px" runat="server" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="Label15" runat="server" Text="Job Status" CssClass="label"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtJobStatus" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 80px">
                                                <asp:Label ID="lblJoiningDate" runat="server" CssClass="label" Text="Joining Date"></asp:Label>
                                            </td>
                                            <td style="width: 200px">
                                                <asp:TextBox ID="txtJoiningDate" runat="server" Width="200px" CssClass="txt" ReadOnly="True"
                                                    BorderStyle="None" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblTotalRemaining" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </fieldset>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 645px;">
                            <div>
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lblTotal" runat="server" CssClass="label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px">
                                        </td>
                                        <td>
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="button" OnClick="btnUpdate_Click"
                                                Text="Update" ValidationGroup="VG" Width="60px" />
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfEmpCode" runat="server" />
                            <asp:HiddenField ID="hdfTotalLoanScheduleAmount" runat="server" />
                            <asp:HiddenField ID="hdfLoanApplicationId" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
