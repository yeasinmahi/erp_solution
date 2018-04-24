<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveSingle.aspx.cs" Inherits="UI.PaymentModule.ApproveSingle" %>
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

    <script language="javascript">        

        function ViewBillDetailsPopup(Id) {
            window.open('BillDetails.aspx?ID=' + Id, 'sub', "height=600, width=1100, scrollbars=yes, left=100, top=25, resizable=no, title=Preview");
        }
    </script>
    
</head>
<body>
    <form id="frmBillRegistration" runat="server">        
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel0" runat="server">
    <ContentTemplate>
    
    <%--=========================================Start My Code From Here===============================================--%>
    <asp:HiddenField ID="hdnconfirm" runat="server" /><asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnPOID" runat="server" />
    <asp:HiddenField ID="hdnBillID" runat="server" /><asp:HiddenField ID="hdnEntryType" runat="server" /><asp:HiddenField ID="hdnLevel" runat="server" />   
    
    <div class="divbody" style="padding-right:10px;">
        <%--<div class="tabs_container" style="background-color:#dcdbdb; padding-top:10px; padding-left:5px; padding-right:-50px; border-radius:5px;"> AUDIT APPROVE FORM<hr /></div>--%>
                
        <table>
            <%--<tr>        
                <td colspan="4" style="color:blue; text-align:left; font-weight:900;"><a id="btnBack" href="BillDetails.aspx" class="nextclick" style="cursor:pointer; text-align:right;">Back</a></td>
                
            </tr>--%>
            <tr><td colspan="9" style="text-align:center;"><asp:Label ID="lblUnitName" runat="server" Text="APPROVE FORM" CssClass="lbl" Font-Size="18px" Font-Bold="true" Font-Underline="true"></asp:Label></td></tr>
            
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblC" runat="server" Text="ENTRY CODE.:" CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;" colspan="6"><asp:Label ID="lblEntryCode" runat="server" Text="CHALLAN NO" CssClass="lbl" ForeColor="Blue"></asp:Label></td>                
                
                <td style="text-align:right;"><asp:Label ID="Label8" runat="server" Text="BILL AMOUNT: " CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="lblBillAmount" runat="server" Text="0" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label10" runat="server" Text="APPROVED BY: " CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;" colspan="6"><asp:Label ID="lblArrovedLevel" runat="server" Text="Approved Level:" CssClass="lbl" ForeColor="Blue"></asp:Label></td>                
                <td style="text-align:right;"><asp:Label ID="Label18" runat="server" Text="NET PAY: " CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="lblNetPay" runat="server" Text="0" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label20" runat="server" Text="PARTY: " CssClass="lbl"></asp:Label></td>  
                <td style="text-align:left;"><asp:Label ID="lblParty" runat="server" Text="Party" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label3" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                                
                <td style="text-align:left;"><asp:Label ID="Label2" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label1" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label26" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="Label27" runat="server" Text="" CssClass="lbl" ForeColor="Blue"></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label28" runat="server" Text="PREVIOUS ADVANCE :" CssClass="lbl"></asp:Label></td>
                <td style="text-align:left;"><asp:Label ID="lblPreviousAdvance" runat="server" Text="0" CssClass="lbl" ForeColor="Red"></asp:Label></td>                
            </tr> 
            <tr><td colspan="9"><hr /></td></tr> 
            <tr>
                <td style="text-align:right;"><asp:Label ID="lblLoanType" runat="server" CssClass="lbl" Text="CURRENT ACTION"></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td style="text-align:left;">
                <asp:DropDownList ID="ddlCurrentAction" CssClass="ddList" Font-Bold="False" runat="server" width="220px" height="23px" AutoPostBack="false"></asp:DropDownList></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label9" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right; width:15px;"><asp:Label ID="Label11" runat="server" Text=""></asp:Label></td>
                <td style="text-align:right;"><asp:Label ID="Label4" runat="server" Text="AMOUNT" CssClass="lbl" ></asp:Label><span style="color:red; font-size:14px;">*</span><span> :</span></td>
                <td><asp:TextBox ID="txtAmount" runat="server" CssClass="txtBox1"></asp:TextBox></td>                             
            </tr>
            <tr>
                <td style="text-align:right;"><asp:Label ID="Label12" runat="server" Text="REMARKS :" CssClass="lbl" ></asp:Label></td>
                <td colspan="9"><asp:TextBox ID="txtRemarks" runat="server" CssClass="txtBox1" Width="725px"></asp:TextBox></td>  
            </tr>
            <tr>
                <td colspan="9" style="text-align:right; padding: 10px 0px 5px 0px"><asp:Button ID="btnSaveAction" runat="server" class="myButton" Text="Save Action" OnClientClick = "ConfirmAll()" OnClick="btnSaveAction_Click"/></td>        
            </tr>
            <tr><td colspan="9"><hr /></td></tr> 
            <tr><td colspan="9">PREVIOUS ACTIONS :<hr /></td></tr> 
            <tr>
                <td colspan="9"> 
                <asp:GridView ID="dgvPreviousStatus" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
                CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />    
                <Columns>
                <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px" /><ItemTemplate> <%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action" SortExpression="strApproveType">
                <ItemTemplate><asp:Label ID="lblAction" runat="server" Text='<%# Bind("strApproveType") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="100px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Date" SortExpression="dteApproveTime">
                <ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Bind("dteApproveTime", "{0:yyyy-MM-dd}") %>' Width="120px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="center" Width="120px"/></asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action By" SortExpression="strEmployeeName">
                <ItemTemplate><asp:Label ID="lblActionBy" runat="server" Text='<%# Bind("strEmployeeName") %>' Width="200px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="200px"/></asp:TemplateField>

                <asp:TemplateField HeaderText="Amount)" SortExpression="monApproveAmount">
                <ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%# Bind("monApproveAmount", "{0:n2}") %>' Width="100px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="right" Width="100px" /></asp:TemplateField>

                <asp:TemplateField HeaderText="Remarks" SortExpression="strRemarks">
                <ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Bind("strRemarks") %>' Width="340px"></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="left" Width="340px"/></asp:TemplateField>
                    
                </Columns>
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                </asp:GridView>
                </td>
            </tr> 

        </table>
    </div>


    <%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>