<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoanCompleteScheduleWise.aspx.cs" Inherits="UI.HR.Loan.LoanCompleteScheduleWise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Loan Schedule Details </title>
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

    <script> function CloseWindow() {
     window.close();     
    }
    </script>

<script type="text/javascript">
    function RefreshParent() {
        if (window.opener != null && !window.opener.closed) {
            window.opener.location.reload();
        }
    }
    window.onbeforeunload = RefreshParent;
</script>  

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
    
</head>
<body>
    <form id="frmLoanScheduleDetails" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>  
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" />
    <asp:HiddenField ID="hdnApplicationID" runat="server" />

    <div class="divbody" style="padding-right:10px;">
        <div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> LOAN SCHEDULE DETAILS<hr /></div>

        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="Remarks :" CssClass="lbl"></asp:Label></td>
                            <td ><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" TextMode="MultiLine" Height="35px" Width="508px"></asp:TextBox></td>                
                        </tr> 
                        <tr><td colspan="5"><hr /></td></tr> 
                        <tr>
                            <td colspan="5" style="text-align:right; padding: 0px 0px 0px 0px"><asp:Button ID="btnComplete" runat="server" class="myButtonGrey" Text="Complete" OnClientClick = "ConfirmAll()" OnClick="btnComplete_Click" /></td>        
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table>            
                        <tr><td><hr /></td></tr>
                        <tr><td>   
                            <asp:GridView ID="dgvLoan" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
                            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
                            FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" OnRowDataBound="dgvLoan_RowDataBound">
                            <AlternatingRowStyle BackColor="#CCCCCC" />    
                            <Columns>
                            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
                            <asp:TemplateField HeaderText="Schedule ID" SortExpression="intScheduleId" Visible="false">
                            <ItemTemplate><asp:Label ID="lblScheduleID" runat="server" Text='<%# Bind("intScheduleId") %>' Width="80px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                
                            <asp:TemplateField HeaderText="Application Id" SortExpression="intLoanID">
                            <ItemTemplate><asp:Label ID="lblApplicationID" runat="server" Text='<%# Bind("intLoanID") %>' Width="80px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>
                                                
                            <asp:TemplateField HeaderText="Installment Month" SortExpression="InstallmentMonth">
                            <ItemTemplate><asp:Label ID="lblMonth" runat="server" Text='<%# Bind("InstallmentMonth") %>' Width="110px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="110px"/></asp:TemplateField>
                                
                            <asp:TemplateField HeaderText="Installment Year" SortExpression="InstallmentYear">
                            <ItemTemplate><asp:Label ID="lblYear" runat="server" Text='<%# Bind("InstallmentYear") %>' Width="100px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="100px" />
                            <FooterTemplate><asp:Label ID="lblT" runat="server" Text="Total" /></FooterTemplate></asp:TemplateField>
                                
                            <asp:TemplateField HeaderText="Total Loan Amount" SortExpression="InstallAmount">
                            <ItemTemplate><asp:Label ID="lblLoanAmountT" runat="server" DataFormatString="{0:0.00}"  Text='<%# Bind("InstallAmount") %>' Width="80px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" />
                            <FooterTemplate><asp:Label ID="lblLoanAmountTotal" runat="server" DataFormatString="{0:0.00}" Text="<%# totalloanamountn %>" /></FooterTemplate></asp:TemplateField>

                            <asp:TemplateField HeaderText="Loan Installment Status" SortExpression="InstallmentStatus">
                            <ItemTemplate><asp:Label ID="lblInsStatus" runat="server" Text='<%#Eval("InstallmentStatus") %>' Width="90px"></asp:Label>
                            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="90px"/></asp:TemplateField>
                  
                            <asp:TemplateField><HeaderTemplate><asp:Label ID="lblInsStatus" runat="server" Text="All" Width="21px"></asp:Label><br />
                            <asp:CheckBox ID="chkHeader" runat="server" Width="21px" />
                            </HeaderTemplate><ItemTemplate><asp:CheckBox ID="chkRow" runat="server" /></ItemTemplate>
                            </asp:TemplateField>

                            </Columns>
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td></tr>  
                    </table> 
                </td>      
            </tr>
        </table>
    </div>

    <%--=========================================End My Code From Here=================================================--%>
    
    </form>
</body>
</html>