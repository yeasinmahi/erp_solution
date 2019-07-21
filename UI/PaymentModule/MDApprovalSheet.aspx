<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MDApprovalSheet.aspx.cs" Inherits="UI.PaymentModule.MDApprovalSheet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>::. Bill Approval </title>
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

    <script language="javascript" type="text/javascript">
        function divVisibleFalse() {
            document.getElementById("divExport").style.display = "none";            
        }                
    </script>
    <script language="javascript" type="text/javascript">
        function ExportDivDataToExcel() {
            var html = $("#divExport").html();
            html = $.trim(html);
            html = html.replace(/>/g, '&gt;');
            html = html.replace(/</g, '&lt;');
            $("input[id$='HdnValue']").val(html);
        }
 </script>
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 567px;
            left: 17px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 565px;
            left: 398px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 563px;
            left: 783px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 550px;
            left: 785px;
            z-index: 1;
            width: 102px;
        }
        .auto-style5 {
            position: absolute;
            top: 555px;
            left: 397px;
            z-index: 1;
            height: 22px;
            width: 74px;
        }
        .auto-style6 {
            position: absolute;
            top: 560px;
            left: 19px;
            z-index: 1;
            height: 22px;
            width: 90px;
        }
    </style>
</head>
<body>
    <form id="frmBillApproval" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>--%>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
    <asp:HiddenField ID="hdnLevel" runat="server" />    
    <table>
        <tr><td>
            <div class="divbody" style="padding-right:10px;">
                <div id="divLevel1" class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> <asp:Label ID="lblHeading" runat="server" CssClass="lbl" Text="MD APPROVAL SHEET" Font-Bold="true" Font-Size="16px"></asp:Label><hr /></div>
                
                <table class="tbldecoration" style="width:auto; float:left;">
                    <tr>
                        <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="Unit"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                        <td style="text-align:left;">
                        <asp:DropDownList ID="ddlUnit" CssClass="ddList" Font-Bold="False" runat="server" width="110px" height="23px" AutoPostBack="true" OnSelectedIndexChanged="ddlUnit_SelectedIndexChanged"></asp:DropDownList></td>
                        <td style="text-align:right; "><asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right; "><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="lblDate" runat="server" CssClass="lbl" Text="From Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                        <td><asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender ID="fdt" runat="server" Format="yyyy-MM-dd" TargetControlID="txtFromDate"></cc1:CalendarExtender></td>
                        <td style="text-align:right; "><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right;"><asp:Label ID="Label2" runat="server" CssClass="lbl" Text="To Date"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>                
                        <td><asp:TextBox ID="txtToDate" runat="server" AutoPostBack="false" CssClass="txtBox1" Enabled="true" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtToDate"></cc1:CalendarExtender></td>
                        <td style="text-align:right; "><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnShow" runat="server" class="myButton" Text="Show" Height="30px" OnClick="btnShow_Click"/></td> 
                        <td style="text-align:right; padding: 10px 0px 5px 10px"><asp:Button ID="btnExport" runat="server" class="myButton" Text="Export To Excel" Height="30px" Width="145px" OnClick="btnExport_Click" OnClientClick="ExportDivDataToExcel()"/></td> 
                    </tr>
                </table>
            </div>
        </td></tr>
        <tr><td>    
            <div id="divExport">
                <table>
                    <tr><td style='text-align: center;'><asp:Label ID="lblUnitName" runat="server" Font-Bold="true" Font-Size="20px"></asp:Label></td></tr>
                    <tr><td style='text-align: center;'><asp:Label ID="lblAddress" runat="server" Font-Size="15px"></asp:Label></td></tr>
                    <tr><td style='text-align: center;'><asp:Label ID="lblReportName" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label></td></tr>
                    <tr><td style='text-align: center;'><asp:Label ID="lblFromToDate" runat="server" Font-Bold="true" Font-Size="15px"></asp:Label></td></tr>

                    <tr><td style="padding-bottom:35px">   
                    <asp:GridView ID="dgvMDApprovalSheet" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="12" Font-Size="11px"
                    CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" RowStyle-Height="22px"
                    HeaderStyle-Font-Size="11px" FooterStyle-Font-Size="10px" HeaderStyle-Font-Bold="true"
                    ForeColor="Black" GridLines="Both" >
                    <AlternatingRowStyle BackColor="White"/>    
                    <Columns>
                    <%--<asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="30px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>--%>
            
                    <asp:TemplateField HeaderText="SL No." SortExpression="intID">
                    <ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%# Bind("intID") %>' Width="40px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="center" Width="40px"/></asp:TemplateField>                
            
                    <asp:TemplateField HeaderText="Party Name" SortExpression="strParty">
                    <ItemTemplate><asp:Label ID="lblPartyName" runat="server" Text='<%# Bind("strParty") %>' Width="220px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="220px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Description" SortExpression="strDescription">
                    <ItemTemplate><asp:Label ID="lblDiscription" runat="server" Text='<%# Bind("strDescription") %>' Width="250px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="250px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Expense Code" SortExpression="strExpCode">
                    <ItemTemplate><asp:Label ID="lblDiscription" runat="server" Text='<%# Bind("strExpCode") %>' Width="180px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="left" Width="180px"/></asp:TemplateField>

                    <asp:TemplateField HeaderText="Approved for Pay" SortExpression="monApprove">
                    <ItemTemplate><asp:Label ID="lblApprovedForPay" runat="server" Text='<%# Bind("monApprove", "{0:n0}") %>' Width="130px"></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="right" Width="130px" Font-Size="14px"/></asp:TemplateField>

                    </Columns>
                    <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    </asp:GridView>
                    </td></tr> 
                    <tr>
                         <td> 
                             <asp:Label ID="Label10" runat="server" CssClass="auto-style5">-------------</asp:Label>
                             <asp:Label ID="Label7" runat="server" CssClass="auto-style5">-------------</asp:Label>
                            <asp:Label ID="Label8" runat="server" CssClass="auto-style4">---------------------</asp:Label>
                             
                             <asp:Label ID="Label9" runat="server" CssClass="auto-style6">-------------</asp:Label>
                        </td>
                        <td> <asp:Label ID="lblsignature" runat="server" CssClass="auto-style1">Prepared By</asp:Label>
                              <asp:Label ID="Label6" runat="server" CssClass="auto-style2">Reviewed By</asp:Label>
                            <asp:Label ID="Label5" runat="server" CssClass="auto-style3">Recommended By</asp:Label>
                        </td>
                        
                    </tr>
                </table>
                <asp:HiddenField ID="HdnValue" runat="server" />
            </div>
        </td></tr>
    </table>

     <%--=========================================End My Code From Here=================================================--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>