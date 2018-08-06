﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillRegisterReport.aspx.cs" Inherits="UI.PaymentModule.BillRegisterReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Registration </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <script src="../Content/JS/datepickr.min.js"></script>
    <script src="../Content/JS/JSSettlement.js"></script>   
    <link href="jquery-ui.css" rel="stylesheet" />
    <link href="../Content/CSS/Application.css" rel="stylesheet" />
    <script src="jquery.min.js"></script>
    <script src="jquery-ui.min.js"></script>    
    <script src="../Content/JS/CustomizeScript.js"></script>
    <link href="../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />
    <link href="../Content/CSS/Gridstyle.css" rel="stylesheet" />

    <script>
         function ViewBillDetailsPopup(Id) {
             window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
         }
    </script>


    </head>
<body>
    <form id="frmSupplierCOA" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" /><asp:HiddenField ID="hdnysnPay" runat="server" /><asp:HiddenField ID="hdnysnDutyVoucher" runat="server" />
    <asp:HiddenField ID="hdnEmail" runat="server" />

    <div class="divbody" style="padding-right:10px;">
        <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="Bill Register" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
        <table class="tbldecoration" style="width:auto; float:left;">
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblUnit" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;"><asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="110px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td><asp:TextBox ID="txtFrom" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="110"></asp:TextBox>
                <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFrom"></cc1:CalendarExtender></td>
                <td style="text-align:right; "><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:right;"><asp:Label ID="Label1" runat="server" CssClass="lbl" Text="To"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                <td><asp:TextBox ID="txtTo" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="110px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtTo"></cc1:CalendarExtender></td>
                <td style="text-align:right; "><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>  
                <td style="text-align:right; padding: 5px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></td> 
            </tr>
        </table>
    </div>

    <table>
        <tr><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></td></tr>
        <tr><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server" Font-Bold="true" Font-Size="16px"></asp:Label></td></tr>
        <tr><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server" Font-Bold="true" Font-Size="16px"></asp:Label></td></tr>
        <tr><td><hr /></td></tr>
            <tr><td>   
            <asp:GridView ID="dgvReport" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true" RowStyle-Height="25px"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvReport_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />    
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
            
            <asp:TemplateField HeaderText="Bill ID" SortExpression="intBill">
            <ItemTemplate><asp:Label ID="lblBillID" runat="server" Text='<%# Bind("intBill") %>' Width="50px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="50px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill Reg Code" SortExpression="strBillCode">
            <ItemTemplate><asp:Label ID="lblBillRegNo" runat="server" Text='<%# Bind("strBillCode") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px"/></asp:TemplateField>

            
            <asp:TemplateField HeaderText="Reff" SortExpression="strReff">
            <ItemTemplate><asp:Label ID="lblReff" runat="server" Text='<%# Bind("strReff") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill No" SortExpression="strBillNo">
            <ItemTemplate><asp:Label ID="lblBillNo" runat="server" Text='<%# Bind("strBillNo") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill Date" SortExpression="dteBillDate">
            <ItemTemplate><asp:Label ID="lblBillDate" runat="server" Text='<%# Bind("dteBillDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Rcv Date" SortExpression="dteRcvDate">
            <ItemTemplate><asp:Label ID="lblRcvDate" runat="server" Text='<%# Bind("dteRcvDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Bill Amount" SortExpression="monBillAmount">
            <ItemTemplate><asp:Label ID="lblBillAmount" runat="server" Text='<%# Bind("monBillAmount", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="100px" /></asp:TemplateField>

           

            <asp:TemplateField HeaderText="Remarks" SortExpression="strRemarks">
            <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px" /></asp:TemplateField>

           <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
            <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strParty") %>' Width="250px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>


            <asp:TemplateField HeaderText="Audit Status" SortExpression="strAuditStatus">
            <ItemTemplate><asp:Label ID="lblAuditStatus" runat="server" Text='<%# Bind("strAuditStatus") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="100px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Audit Date" SortExpression="dteAuditDate">
            <ItemTemplate><asp:Label ID="lblAuditDate" runat="server" Text='<%# Bind("dteAuditDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="center" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Audit Remarks" SortExpression="strAuditRemarks">
            <ItemTemplate><asp:Label ID="lblAuditRemarks" runat="server" Text='<%# Bind("strAuditRemarks") %>' Width="150px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="150px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Approve Amount" SortExpression="monApproveAmount">
            <ItemTemplate><asp:Label ID="lblApproveAmount" runat="server" Text='<%# Bind("monApproveAmount", "{0:n2}") %>' Width="100px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="100px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Approve AIT" SortExpression="monApprovedAIT" Visible="false">
            <ItemTemplate><asp:Label ID="lblApproveAIT" runat="server" Text='<%# Bind("monApprovedAIT", "{0:n2}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="right" Width="80px" /></asp:TemplateField>

            <asp:TemplateField HeaderText="Pay Date" SortExpression="dtePayDate">
            <ItemTemplate><asp:Label ID="lblPayDate" runat="server" Text='<%# Bind("dtePayDate", "{0:yyyy-MM-dd}") %>' Width="80px"></asp:Label>
            </ItemTemplate><ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Show Detail" ItemStyle-HorizontalAlign="Center" SortExpression="">
            <ItemTemplate><asp:Button ID="btnShowDetail" class="myButtonGrid" Font-Bold="true" CommandArgument="<%# Container.DataItemIndex %>" runat="server" CommandName="View"  
            Text="View"/></ItemTemplate><ItemStyle HorizontalAlign="center"/></asp:TemplateField>
                                        
            </Columns>
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
            </td></tr> 
    </table>


                  
    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>