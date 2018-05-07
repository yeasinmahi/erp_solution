<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBrandrollReceive.aspx.cs" Inherits="UI.SAD.Vat.frmBrandrollReceive" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html>
<head runat="server"><title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"><%: Scripts.Render("~/Content/Bundle/jqueryJS") %></asp:PlaceHolder> 
    <webopt:BundleReference ID="BundleReference2" runat="server" Path="~/Content/Bundle/defaultCSS" />     
    <webopt:BundleReference ID="BundleReference3" runat="server" Path="~/Content/Bundle/hrCSS" />
    <link href="../../Content/CSS/SettlementStyle.css" rel="stylesheet" />
    <link href="../../Content/CSS/AutoComplete.css" rel="stylesheet" type="text/css" />  
    <script>
        function ValidationBasicInfo() {
            document.getElementById("hdnconfirm").value = "0";
            var Matrialname = document.forms["frmPurchase"]["txtMatrialName"].value;
            var PurDate = document.forms["frmPurchase"]["txtFrom"].value;
            var SuppName = document.forms["frmPurchase"]["txtSupplierName"].value;           
            var ChallanNo = document.forms["frmPurchase"]["txtChallanNo"].value;
            var ChallanDate = document.forms["frmPurchase"]["txtChallandate"].value;
            var Exam = document.forms["frmPurchase"]["ddlExam"].value;
           

            if (Matrialname == null || Matrialname == "") {
                alert("Please Matrial Fill-Up !");
            }

            else if (PurDate == null || PurDate == "") {
                alert("Purchase Date Select !");
            }
            else if (SuppName == null || SuppName == "") {
                alert("Please Select Supplier !");
            }

            else if (ChallanNo == null || ChallanNo == "") {
                alert("Please Fill-up Challan No!");
            }

            else if (ChallanDate == null || ChallanDate == "") {
                alert("Please Fill-up Challan Date!");
            }
            else if (Exam == null || Exam == "") {
                alert("Please select whether this purchase is tax exempted or not.");
            }
            else {  document.getElementById("hdnconfirm").value = "1"; }
        }

    </script>
</head>
<body>
    <form id="frmBandroll" runat="server">
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
    <div class="leaveApplication_container"> <asp:HiddenField ID="hdnEnroll" runat="server" /><asp:HiddenField ID="hdnconfirm" runat="server" />
    <asp:HiddenField ID="hdnVatAccount" runat="server" /><asp:HiddenField ID="hdnVatRegNo" runat="server" />
    <asp:HiddenField ID="hdnAccno" runat="server" /> <asp:HiddenField ID="hdnysnFactory" runat="server" />
    <asp:HiddenField ID="hdnUnit" runat="server" />
    <div class="tabs_container"> PRODUCTION ENTRY <hr /></div>
    <table><tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">                            
        <tr><td>Entry Type </td>
           <td><asp:DropDownList ID="ddltype" CssClass="ddList" runat="server">
           <asp:ListItem Value="1">Bandroll Receive</asp:ListItem>
           <asp:ListItem Value="2">Bandroll Reject</asp:ListItem>
           </asp:DropDownList></td>
       </tr> 
        <tr><td>Bandroll</td>
        <td> <asp:DropDownList ID="ddlBandrollList" CssClass="ddList" runat="server"></asp:DropDownList></td>
        <td>Dem Order No: </td>
        <td><asp:TextBox ID="txtDemandOrderno" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Date</td>
        <td><asp:TextBox ID="txtdtedate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtdtedate" Format="dd/MM/yyyy" PopupButtonID="imgCal_12"
            ID="CalendarExtender2" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_12" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>  
        </tr> 
        <tr><td>Delivery Order No:</td>
        <td><asp:TextBox ID="txtDeliveryOrderno" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td>Do Date</td>
        <td><asp:TextBox ID="txtDodate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtDodate" Format="dd/MM/yyyy" PopupButtonID="imgCal_13"
            ID="CalendarExtender1" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_13" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /> </td>
            <td>Receive Date</td>
            <td><asp:TextBox ID="txtReceiveDate" runat="server" Enabled="false"  Height="22px"></asp:TextBox>
            <cc1:CalendarExtender CssClass="cal_Theme1" TargetControlID="txtReceiveDate" Format="dd/MM/yyyy" PopupButtonID="imgCal_15"
            ID="CalendarExtender5" runat="server" EnableViewState="true">
            </cc1:CalendarExtender>
            <img id="imgCal_15" src="../../Content/images/img/calbtn.gif" style="border: 0px;
            width: 34px; height: 23px; vertical-align: bottom;" /></td>
        </tr>
        <tr><td>Qty </td><td><asp:TextBox ID="txtQty" runat="server" CssClass="txtBox"   MaxLength="10" AutoPostBack="true" ></asp:TextBox></td>
        <td style="margin-left: 40px;text-align:right" colspan="6"><asp:Button ID="btnAdd" runat="server" Text="Add"  OnClientClick="ValidationBasicInfo()" OnClick="btnAdd_Click" /><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
        <td colspan="2">&nbsp;</td>                   
        </tr>
        <tr><td colspan="5"><hr /></td></tr>          
                   
    </table>
    </td></tr>
    <tr><td>
    <table  class="tbldecoration" style="width:auto; float:left;">    
     <tr><td colspan="5" style="text-align:right"></td>                                     
     <tr><td colspan="5"><hr /></td></tr> 
     <tr><td colspan="5">
        <asp:GridView ID="dgvBrandroll" runat="server" AutoGenerateColumns="False" AllowPaging="false" PageSize="8"
        CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr" ShowFooter="true" 
        HeaderStyle-Font-Size="10px" FooterStyle-Font-Size="11px" HeaderStyle-Font-Bold="true"
        FooterStyle-BackColor="#808080" FooterStyle-Height="25px" FooterStyle-ForeColor="White" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" ForeColor="Black" GridLines="Vertical" 
        OnRowDeleting="dgvPurchase_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />    
        <Columns>
             
        <asp:TemplateField HeaderText="brandroll id" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblbrandrollid" runat="server" Text='<%# Bind("brandrollid") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="20px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="brandroll name" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblbrandrollname" runat="server" Text='<%# Bind("brandrollname") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Dem.Order No" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblDemorderno" runat="server" Text='<%# Bind("Demorderno") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Dem.Order Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldemordedate" runat="server" Text='<%# Bind("demordedate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Do NO" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblDono" runat="server" Text='<%# Bind("Deliveryno") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

         <asp:TemplateField HeaderText="Do Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lbldodate" runat="server" Text='<%# Bind("deliverydate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

          <asp:TemplateField HeaderText="Receive Date" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblreceivedate" runat="server" Text='<%# Bind("receivedate") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:TemplateField HeaderText="Quantity" SortExpression="itemname">
        <ItemTemplate><asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("qty") %>' Width="20px"></asp:Label>
        </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30px" /></asp:TemplateField>

        <asp:CommandField ShowDeleteButton="true" ControlStyle-ForeColor="red" ControlStyle-Font-Bold="true" />
            
        </Columns>
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        </asp:GridView>
     </td></tr>  
    </tr>             
    </table>
    </td></tr></table>
    </div>

<%--=========================================End My Code From Here=================================================--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
