<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseVoucharDetalis.aspx.cs" Inherits="UI.PaymentModule.PurchaseVoucharDetalis" %> 
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
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="../../Content/JS/datepickr.min.js"></script> 
    <script src="../../Content/JS/JSSettlement.js"></script> 
    <link href="jquery-ui.css" rel="stylesheet" /> 
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" /> 
    <script src="jquery.min.js"></script> 
    <script src="jquery-ui.min.js"></script> 
    <link href="../Content/CSS/GridView.css" rel="stylesheet" />
       
     
  
    <style type="text/css"> 
        .rounds {
        height: 80px;
        width: 30px; 
        -moz-border-colors:25px;
        border-radius:25px;
        } 

        .HyperLinkButtonStyle { float:right; text-align:left; border: none; background: none; 
        color: blue; text-decoration: underline; font: normal 10px verdana;} 
        .hdnDivision { background-color: #EFEFEF; position:absolute;z-index:1; visibility:hidden; border:10px double black; text-align:center;
        width:100%; height: 100%;    margin-left: 70px;  margin-top:00px; margin-right:00px; padding: 15px; overflow-y:scroll; }
        .auto-style1 {
            height: 26px;
        }
        </style>
</head>

<body>

    <form id="frmselfresign" runat="server"> 
    <asp:ScriptManager ID="ScriptManager0" EnablePageMethods="true" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel0" runat="server"> 
    <ContentTemplate> 
    <asp:Panel ID="pnlUpperControl" runat="server" Width="100%"> 
    <div id="navbar" name="navbar" style="width: 100%; height: 20px; vertical-align: top;"> 
    <marquee height="17" onmouseout="this.start()" onmouseover="this.stop()" scrollamount="2" scrolldelay="-1" width="100%"> 
    <span class="message-text" id="msg"><%# UI.ClassFiles.CommonClass.GetGlobalMessage() %></span></marquee></div> 
    <div id="divControl" class="divPopUp2" style="width: 100%; height: 80px; float: right;">&nbsp;</div></asp:Panel> 
    <div style="height: 100px;"></div> 
    <cc1:AlwaysVisibleControlExtender TargetControlID="pnlUpperControl" ID="AlwaysVisibleControlExtender1" runat="server"> 
    </cc1:AlwaysVisibleControlExtender>

<%--=========================================Start My Code From Here===============================================--%>

    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnConfirm" runat="server" /><asp:HiddenField ID="hdnUnit" runat="server" />
     <asp:HiddenField ID="hdnIndentNo" runat="server" /><asp:HiddenField ID="hdnIndentDate" runat="server" />
     <asp:HiddenField ID="hdnDueDate" runat="server" /><asp:HiddenField ID="hdnIndentType" runat="server" /> 
     <div class="tabs_container" style="text-align:left">Issue Statement<hr /></div>
        <table style="width:800px">
            <tr>
            <td>Entry Code</td>
            <td><asp:Label ID="lblEntryCode" runat="server"></asp:Label></td>
            <td>Amount Without Tax</td>
            <td><asp:Label ID="lblAmountWithoutTax" runat="server"></asp:Label></td>
            <td>Vat Challan</td>
            <td><asp:Label ID="lblVatChallan" runat="server"></asp:Label></td>
            <td>AIT</td>
            <td><asp:Label ID="lblAIT" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td>Party</td>
            <td colspan="4"><asp:Label ID="lblParty" runat="server"></asp:Label></td>
            <td>Total Amount</td>
            <td colspan="2"><asp:Label ID="lblTotalAmount" runat="server"></asp:Label></td>
            </tr>
            <tr>
            <td  colspan="5"></td>
            <td >Location</td>
            <td colspan="2"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>
            </tr>
        </table>
        <table  style="border-color:black;  width:800px;border-radius:10px; border:1px solid blue;">
            <caption style="text-align:left">Mrr Detail</caption>
            <tr>
                <td>
             <asp:GridView ID="dgvInvnetory"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvBillReport_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Item Name" SortExpression="intMRR"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("intMRR") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="UOM"   ItemStyle-HorizontalAlign="right" SortExpression="intPO" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("intPO") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Quantity"   ItemStyle-HorizontalAlign="right" SortExpression="dteDate" >
            <ItemTemplate><asp:Label ID="lblQuantity" runat="server"  Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Value"   ItemStyle-HorizontalAlign="right" SortExpression="intParty" >
            <ItemTemplate><asp:Label ID="lblValue" Width="60px" runat="server"  Text='<%# Bind("intParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Used For" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblUsedFor" runat="server"  Width=""  Text='<%# Bind("strParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            </Columns>
                 <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
                </td>
            </tr>
        </table>
        <table style="border-color:black;  width:800px;border-radius:10px; border:1px solid blue;">
            <tr><td></td></tr>
        </table>
           
        <table style="border-color:black;  width:800px;border-radius:10px; border:1px solid blue;">
             <caption style="text-align:left; color:blue">Voucher Entry</caption>
            
            <tr> 
                <td></td>
                <td><asp:RadioButton ID="radDebit" GroupName="voucher" runat="server" Text="Debit" OnCheckedChanged="radDebit_CheckedChanged" /> 
                <asp:RadioButton ID="radCredit" GroupName="voucher" runat="server" Text="Credit" OnCheckedChanged="radCredit_CheckedChanged" /></td>
               
            </tr>
            <tr> 
                <td>AC/Head</td>
                <td colspan="2"><asp:DropDownList ID="ddlHead" Width="300px" CssClass="ddList" runat="server"></asp:DropDownList></td>
                <td>TK</td>
                <td><asp:TextBox ID="txtTaka" runat="server"></asp:TextBox></td>
                <td ><asp:Button ID="btnAdd"  Text="Add" runat="server" />  
                  <asp:Button ID="btn" runat="server" Text="Del" /> 
                  <asp:Button ID="btnEdit" runat="server" Text="Edit" /></td>
            </tr>
            <tr>
                <td class="auto-style1">Narration</td>
                <td colspan="5" class="auto-style1"><asp:TextBox ID="txtNaration" CssClass="txtBox" Width="707px" runat="server"></asp:TextBox></td>
            </tr>
            </table>
        <table style="border-color:black;  width:800px;border-radius:10px; border:1px solid blue;">
            <tr>
                 <td colspan="8">
             <asp:GridView ID="GridView1"  runat="server" Width="800px" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
            CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
            HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
            ForeColor="Black" GridLines="Vertical" OnRowCommand="dgvBillReport_RowCommand">
            <AlternatingRowStyle BackColor="#CCCCCC" />     
            <Columns>
            <asp:TemplateField HeaderText="SL No."><ItemStyle HorizontalAlign="center" Width="60px"/><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate></asp:TemplateField>              
 
            <asp:TemplateField HeaderText="Acc ID" SortExpression="intMRR"><ItemTemplate>
            <asp:Label ID="lblItemName" runat="server" Text='<%# Bind("intMRR") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" Width="80px"/></asp:TemplateField>

            <asp:TemplateField HeaderText="Account Name"   ItemStyle-HorizontalAlign="right" SortExpression="intPO" >
            <ItemTemplate><asp:Label ID="lblUom" runat="server"  Text='<%# Bind("intPO") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>   
                
            <asp:TemplateField HeaderText="Naration"   ItemStyle-HorizontalAlign="right" SortExpression="dteDate" >
            <ItemTemplate><asp:Label ID="lblQuantity" runat="server"  Text='<%# Bind("dteDate") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  
            
            <asp:TemplateField HeaderText="Debit"   ItemStyle-HorizontalAlign="right" SortExpression="intParty" >
            <ItemTemplate><asp:Label ID="lblValue" Width="60px" runat="server"  Text='<%# Bind("intParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" />  </asp:TemplateField>  

            <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="right" SortExpression="strItem" >
            <ItemTemplate><asp:Label ID="lblUsedFor" runat="server"  Width=""  Text='<%# Bind("strParty") %>'></asp:Label></ItemTemplate>
            <ItemStyle HorizontalAlign="left" /> </asp:TemplateField>  
            </Columns>
                 <FooterStyle Font-Size="11px" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            </asp:GridView>
                </td>
            </tr>
            <tr>
                <td  colspan="5"> </td>
                <td  > </td>
                <td style="text-align:right">Date 
                 <asp:TextBox ID="txtdteDate"  runat="server" autocomplete="off"></asp:TextBox></td>
                <td style="text-align:left"><asp:Button ID="btnSave" runat="server" Text="Save" /></td>
            </tr>
        </table>
            
    </div> 
    </div>

<%--=========================================End My Code From Here=================================================--%>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>